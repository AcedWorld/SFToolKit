using System;
using AOT;
using Unity.Baselib.LowLevel;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Networking.Transport.Utilities.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x0200000A RID: 10
	[BurstCompile]
	public struct BaselibNetworkInterface : INetworkInterface, IDisposable
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000025B2 File Offset: 0x000007B2
		public NetworkInterfaceEndPoint LocalEndPoint
		{
			get
			{
				return this.m_Baselib[0].m_LocalEndpoint;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000025C5 File Offset: 0x000007C5
		public bool IsCreated
		{
			get
			{
				return this.m_Baselib.IsCreated;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000025D2 File Offset: 0x000007D2
		public int CreateInterfaceEndPoint(NetworkEndPoint address, out NetworkInterfaceEndPoint endpoint)
		{
			return this.CreateInterfaceEndPoint(address.rawNetworkAddress, out endpoint);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000025E4 File Offset: 0x000007E4
		private unsafe int CreateInterfaceEndPoint(Binding.Baselib_NetworkAddress address, out NetworkInterfaceEndPoint endpoint)
		{
			Binding.Baselib_RegisteredNetwork_BufferSlice dstSlice = this.m_LocalAndTempEndpoint.AtIndexAsSlice(0, 28U);
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			endpoint = default(NetworkInterfaceEndPoint);
			Binding.Baselib_RegisteredNetwork_Endpoint baselib_RegisteredNetwork_Endpoint = Binding.Baselib_RegisteredNetwork_Endpoint_Create(&address, dstSlice, &baselib_ErrorState);
			if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
			{
				return (int)baselib_ErrorState.code;
			}
			endpoint.dataLength = (int)baselib_RegisteredNetwork_Endpoint.slice.size;
			fixed (byte* ptr = &endpoint.data.FixedElementField)
			{
				void* destination = (void*)ptr;
				UnsafeUtility.MemCpy(destination, (void*)baselib_RegisteredNetwork_Endpoint.slice.data, (long)endpoint.dataLength);
			}
			return 0;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002670 File Offset: 0x00000870
		private unsafe NetworkInterfaceEndPoint GetLocalEndPoint(Binding.Baselib_RegisteredNetwork_Socket_UDP socket)
		{
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			Binding.Baselib_NetworkAddress address;
			Binding.Baselib_RegisteredNetwork_Socket_UDP_GetNetworkAddress(socket, &address, &baselib_ErrorState);
			NetworkInterfaceEndPoint result = default(NetworkInterfaceEndPoint);
			if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
			{
				return result;
			}
			this.CreateInterfaceEndPoint(address, out result);
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000026B0 File Offset: 0x000008B0
		public unsafe NetworkEndPoint GetGenericEndPoint(NetworkInterfaceEndPoint endpoint)
		{
			NetworkEndPoint result = default(NetworkEndPoint);
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			Binding.Baselib_RegisteredNetwork_BufferSlice slice = this.m_LocalAndTempEndpoint.AtIndexAsSlice(0, 28U);
			Binding.Baselib_RegisteredNetwork_Endpoint baselib_RegisteredNetwork_Endpoint;
			baselib_RegisteredNetwork_Endpoint.slice = slice;
			baselib_RegisteredNetwork_Endpoint.slice.size = (uint)endpoint.dataLength;
			UnsafeUtility.MemCpy((void*)baselib_RegisteredNetwork_Endpoint.slice.data, (void*)(&endpoint.data.FixedElementField), (long)endpoint.dataLength);
			Binding.Baselib_RegisteredNetwork_Endpoint_GetNetworkAddress(baselib_RegisteredNetwork_Endpoint, &result.rawNetworkAddress, &baselib_ErrorState);
			if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
			{
				return default(NetworkEndPoint);
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002744 File Offset: 0x00000944
		public int Initialize(NetworkSettings settings)
		{
			this.configuration = ref settings.GetBaselibNetworkInterfaceParameters();
			this.m_Baselib = new NativeArray<BaselibNetworkInterface.BaselibData>(1, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			BaselibNetworkInterface.BaselibData value = default(BaselibNetworkInterface.BaselibData);
			this.m_PayloadsTx = new BaselibNetworkInterface.Payloads(this.configuration.sendQueueCapacity, this.configuration.maximumPayloadSize);
			this.m_PayloadsRx = new BaselibNetworkInterface.Payloads(this.configuration.receiveQueueCapacity, this.configuration.maximumPayloadSize);
			this.m_LocalAndTempEndpoint = new UnsafeBaselibNetworkArray(2, 28);
			value.m_PayloadsTx = this.m_PayloadsTx;
			this.m_Baselib[0] = value;
			return 0;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000027E0 File Offset: 0x000009E0
		public void Dispose()
		{
			if (this.m_Baselib[0].m_Socket.handle != IntPtr.Zero)
			{
				Binding.Baselib_RegisteredNetwork_Socket_UDP_Close(this.m_Baselib[0].m_Socket);
			}
			this.m_LocalAndTempEndpoint.Dispose();
			if (this.m_PayloadsTx.IsCreated)
			{
				this.m_PayloadsTx.Dispose();
			}
			if (this.m_PayloadsRx.IsCreated)
			{
				this.m_PayloadsRx.Dispose();
			}
			this.m_Baselib.Dispose();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000286C File Offset: 0x00000A6C
		private static void MarkSocketAsNeedingRecreate(NativeArray<BaselibNetworkInterface.BaselibData> baselib)
		{
			BaselibNetworkInterface.BaselibData value = baselib[0];
			value.m_SocketStatus = BaselibNetworkInterface.SocketStatus.SocketNeedsRecreate;
			baselib[0] = value;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002894 File Offset: 0x00000A94
		private void RecreateSocket(long updateTime)
		{
			BaselibNetworkInterface.BaselibData baselibData = this.m_Baselib[0];
			if (baselibData.m_LastSocketRecreateTime == baselibData.m_LastUpdateTime || baselibData.m_NumSocketRecreate >= 1000U)
			{
				Debug.LogError("Unrecoverable socket failure. An unknown condition is preventing the application from reliably creating sockets.");
				baselibData.m_SocketStatus = BaselibNetworkInterface.SocketStatus.SocketFailed;
				this.m_Baselib[0] = baselibData;
				return;
			}
			Debug.LogWarning("Socket error encountered; attempting recovery by creating a new one.");
			this.Bind(baselibData.m_LocalEndpoint);
			baselibData = this.m_Baselib[0];
			baselibData.m_LastSocketRecreateTime = updateTime;
			baselibData.m_NumSocketRecreate += 1U;
			this.m_Baselib[0] = baselibData;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002930 File Offset: 0x00000B30
		public JobHandle ScheduleReceive(NetworkPacketReceiver receiver, JobHandle dep)
		{
			if (this.m_Baselib[0].m_SocketStatus == BaselibNetworkInterface.SocketStatus.SocketNeedsRecreate)
			{
				this.RecreateSocket(receiver.LastUpdateTime);
			}
			if (this.m_Baselib[0].m_SocketStatus == BaselibNetworkInterface.SocketStatus.SocketFailed)
			{
				receiver.ReceiveErrorCode = -10;
				return dep;
			}
			return new BaselibNetworkInterface.ReceiveJob
			{
				Baselib = this.m_Baselib,
				Rx = this.m_PayloadsRx,
				Receiver = receiver
			}.Schedule(dep);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000029B0 File Offset: 0x00000BB0
		public JobHandle ScheduleSend(NativeQueue<QueuedSendMessage> sendQueue, JobHandle dep)
		{
			if (this.m_Baselib[0].m_SocketStatus != BaselibNetworkInterface.SocketStatus.SocketNormal)
			{
				return dep;
			}
			return new BaselibNetworkInterface.FlushSendJob
			{
				Baselib = this.m_Baselib,
				Tx = this.m_PayloadsTx
			}.Schedule(dep);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000029FC File Offset: 0x00000BFC
		public unsafe int Bind(NetworkInterfaceEndPoint endpoint)
		{
			BaselibNetworkInterface.BaselibData baselibData = this.m_Baselib[0];
			Binding.Baselib_RegisteredNetwork_BufferSlice baselib_RegisteredNetwork_BufferSlice = this.m_LocalAndTempEndpoint.AtIndexAsSlice(0, 28U);
			UnsafeUtility.MemCpy((void*)baselib_RegisteredNetwork_BufferSlice.data, (void*)(&endpoint.data.FixedElementField), (long)endpoint.dataLength);
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			Binding.Baselib_RegisteredNetwork_Endpoint endpoint2;
			endpoint2.slice = baselib_RegisteredNetwork_BufferSlice;
			Binding.Baselib_NetworkAddress address;
			Binding.Baselib_RegisteredNetwork_Endpoint_GetNetworkAddress(endpoint2, &address, &baselib_ErrorState);
			bool flag = this.WouldBindFailWithoutAddressReuse(address);
			Binding.Baselib_RegisteredNetwork_Socket_UDP socket = checked(Binding.Baselib_RegisteredNetwork_Socket_UDP_Create(&address, Binding.Baselib_NetworkAddress_AddressReuse.Allow, (uint)this.configuration.sendQueueCapacity, (uint)this.configuration.receiveQueueCapacity, &baselib_ErrorState));
			if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
			{
				if (baselib_ErrorState.code == Binding.Baselib_ErrorCode.AddressInUse)
				{
					Debug.LogError("Failed to bind the socket because address is already in use. It is likely that another process is already listening on the same port.");
				}
				if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.UnexpectedError)
				{
					return (int)(-(int)baselib_ErrorState.code);
				}
				return -10;
			}
			else
			{
				if (this.m_Baselib[0].m_Socket.handle != IntPtr.Zero)
				{
					Binding.Baselib_RegisteredNetwork_Socket_UDP_Close(this.m_Baselib[0].m_Socket);
					this.m_PayloadsRx.Dispose();
					this.m_PayloadsRx = new BaselibNetworkInterface.Payloads(this.configuration.receiveQueueCapacity, this.configuration.maximumPayloadSize);
				}
				int num = BaselibNetworkInterface.ScheduleAllReceives(socket, ref this.m_PayloadsRx);
				if (num < 0)
				{
					return num;
				}
				if (baselibData.m_SocketStatus != BaselibNetworkInterface.SocketStatus.SocketNeedsRecreate && flag)
				{
					ushort port = this.GetGenericEndPoint(endpoint).Port;
					Debug.LogWarning(string.Format("Port {0} is likely already in use by another application. ", port) + "Socket was still created, but expect erroneous behavior. This condition will become a failure starting in version 2.0 of Unity Transport.");
				}
				baselibData.m_Socket = socket;
				baselibData.m_SocketStatus = BaselibNetworkInterface.SocketStatus.SocketNormal;
				baselibData.m_LocalEndpoint = this.GetLocalEndPoint(socket);
				this.m_Baselib[0] = baselibData;
				return 0;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002BB4 File Offset: 0x00000DB4
		private unsafe bool WouldBindFailWithoutAddressReuse(Binding.Baselib_NetworkAddress address)
		{
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			Binding.Baselib_RegisteredNetwork_Socket_UDP socket = checked(Binding.Baselib_RegisteredNetwork_Socket_UDP_Create(&address, Binding.Baselib_NetworkAddress_AddressReuse.DoNotAllow, (uint)this.configuration.sendQueueCapacity, (uint)this.configuration.receiveQueueCapacity, &baselib_ErrorState));
			if (baselib_ErrorState.code == Binding.Baselib_ErrorCode.Success)
			{
				Binding.Baselib_RegisteredNetwork_Socket_UDP_Close(socket);
			}
			return baselib_ErrorState.code == Binding.Baselib_ErrorCode.AddressInUse;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002C09 File Offset: 0x00000E09
		public int Listen()
		{
			return 0;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002C0C File Offset: 0x00000E0C
		public NetworkSendInterface CreateSendInterface()
		{
			return new NetworkSendInterface
			{
				BeginSendMessage = BaselibNetworkInterface.BeginSendMessageFunctionPointer,
				EndSendMessage = BaselibNetworkInterface.EndSendMessageFunctionPointer,
				AbortSendMessage = BaselibNetworkInterface.AbortSendMessageFunctionPointer,
				UserData = (IntPtr)this.m_Baselib.GetUnsafePtr<BaselibNetworkInterface.BaselibData>()
			};
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002C60 File Offset: 0x00000E60
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkSendInterface.BeginSendMessageDelegate))]
		private unsafe static int BeginSendMessage(out NetworkInterfaceSendHandle handle, IntPtr userData, int requiredPayloadSize)
		{
			BaselibNetworkInterface.BaselibData* ptr = (BaselibNetworkInterface.BaselibData*)((void*)userData);
			handle = default(NetworkInterfaceSendHandle);
			int num = ptr->m_PayloadsTx.AcquireHandle();
			if (num < 0)
			{
				return -5;
			}
			Binding.Baselib_RegisteredNetwork_Request requestFromHandle = ptr->m_PayloadsTx.GetRequestFromHandle(num);
			if (requestFromHandle.payload.size < (uint)requiredPayloadSize)
			{
				ptr->m_PayloadsTx.ReleaseHandle(num);
				return -4;
			}
			handle.id = num;
			handle.size = 0;
			handle.data = requestFromHandle.payload.data;
			handle.capacity = (int)requestFromHandle.payload.size;
			return 0;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002CEC File Offset: 0x00000EEC
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkSendInterface.EndSendMessageDelegate))]
		private unsafe static int EndSendMessage(ref NetworkInterfaceSendHandle handle, ref NetworkInterfaceEndPoint address, IntPtr userData, ref NetworkSendQueueHandle sendQueueHandle)
		{
			BaselibNetworkInterface.BaselibData* ptr = (BaselibNetworkInterface.BaselibData*)((void*)userData);
			int id = handle.id;
			Binding.Baselib_RegisteredNetwork_Request requestFromHandle = ptr->m_PayloadsTx.GetRequestFromHandle(id);
			requestFromHandle.requestUserdata = (IntPtr)(id + 1);
			requestFromHandle.payload.size = (uint)handle.size;
			NetworkInterfaceEndPoint networkInterfaceEndPoint = address;
			UnsafeUtility.MemCpy((void*)requestFromHandle.remoteEndpoint.slice.data, (void*)(&networkInterfaceEndPoint.data.FixedElementField), (long)address.dataLength);
			Binding.Baselib_RegisteredNetwork_Request* requests = &requestFromHandle;
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			int num = (int)Binding.Baselib_RegisteredNetwork_Socket_UDP_ScheduleSend(ptr->m_Socket, requests, 1U, &baselib_ErrorState);
			if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success || (long)num != 1L)
			{
				ptr->m_PayloadsTx.ReleaseHandle(id);
				return -5;
			}
			return handle.size;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002DB0 File Offset: 0x00000FB0
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkSendInterface.AbortSendMessageDelegate))]
		private unsafe static void AbortSendMessage(ref NetworkInterfaceSendHandle handle, IntPtr userData)
		{
			BaselibNetworkInterface.BaselibData* ptr = (BaselibNetworkInterface.BaselibData*)((void*)userData);
			int id = handle.id;
			ptr->m_PayloadsTx.ReleaseHandle(id);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002DD8 File Offset: 0x00000FD8
		private unsafe static int ScheduleAllReceives(Binding.Baselib_RegisteredNetwork_Socket_UDP socket, ref BaselibNetworkInterface.Payloads PayloadsRx)
		{
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			Binding.Baselib_RegisteredNetwork_Request* ptr = stackalloc Binding.Baselib_RegisteredNetwork_Request[checked(unchecked((UIntPtr)64) * (UIntPtr)sizeof(Binding.Baselib_RegisteredNetwork_Request))];
			for (;;)
			{
				int num = 0;
				while ((long)num < 64L && PayloadsRx.InUse < PayloadsRx.Capacity)
				{
					int num2 = PayloadsRx.AcquireHandle();
					ptr[num] = PayloadsRx.GetRequestFromHandle(num2);
					ptr[num].requestUserdata = (IntPtr)num2 + 1;
					num++;
				}
				if (num > 0)
				{
					Binding.Baselib_RegisteredNetwork_Socket_UDP_ScheduleRecv(socket, ptr, (uint)num, &baselib_ErrorState);
					if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
					{
						break;
					}
				}
				if ((long)num != 64L)
				{
					return 0;
				}
			}
			if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.UnexpectedError)
			{
				return (int)(-(int)baselib_ErrorState.code);
			}
			return -10;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002E8A File Offset: 0x0000108A
		private bool ValidateParameters(BaselibNetworkParameter param)
		{
			return param.receiveQueueCapacity > 0 && param.sendQueueCapacity > 0;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002EA4 File Offset: 0x000010A4
		private bool TryExtractParameters(out BaselibNetworkParameter config, params INetworkParameter[] param)
		{
			for (int i = 0; i < param.Length; i++)
			{
				if (param[i] is BaselibNetworkParameter && this.ValidateParameters((BaselibNetworkParameter)param[i]))
				{
					config = (BaselibNetworkParameter)param[i];
					return true;
				}
			}
			config = default(BaselibNetworkParameter);
			return false;
		}

		// Token: 0x0400000D RID: 13
		public static BaselibNetworkParameter DefaultParameters = new BaselibNetworkParameter
		{
			receiveQueueCapacity = 64,
			sendQueueCapacity = 64,
			maximumPayloadSize = 2000U
		};

		// Token: 0x0400000E RID: 14
		private BaselibNetworkParameter configuration;

		// Token: 0x0400000F RID: 15
		private const int k_defaultRxQueueSize = 64;

		// Token: 0x04000010 RID: 16
		private const int k_defaultTxQueueSize = 64;

		// Token: 0x04000011 RID: 17
		private const int k_defaultMaximumPayloadSize = 2000;

		// Token: 0x04000012 RID: 18
		private const uint k_MaxNumSocketRecreate = 1000U;

		// Token: 0x04000013 RID: 19
		private const uint k_RequestsBatchSize = 64U;

		// Token: 0x04000014 RID: 20
		[ReadOnly]
		internal NativeArray<BaselibNetworkInterface.BaselibData> m_Baselib;

		// Token: 0x04000015 RID: 21
		[NativeDisableContainerSafetyRestriction]
		private BaselibNetworkInterface.Payloads m_PayloadsRx;

		// Token: 0x04000016 RID: 22
		[NativeDisableContainerSafetyRestriction]
		private BaselibNetworkInterface.Payloads m_PayloadsTx;

		// Token: 0x04000017 RID: 23
		private UnsafeBaselibNetworkArray m_LocalAndTempEndpoint;

		// Token: 0x04000018 RID: 24
		private static TransportFunctionPointer<NetworkSendInterface.BeginSendMessageDelegate> BeginSendMessageFunctionPointer = new TransportFunctionPointer<NetworkSendInterface.BeginSendMessageDelegate>(new NetworkSendInterface.BeginSendMessageDelegate(BaselibNetworkInterface.BeginSendMessage));

		// Token: 0x04000019 RID: 25
		private static TransportFunctionPointer<NetworkSendInterface.EndSendMessageDelegate> EndSendMessageFunctionPointer = new TransportFunctionPointer<NetworkSendInterface.EndSendMessageDelegate>(new NetworkSendInterface.EndSendMessageDelegate(BaselibNetworkInterface.EndSendMessage));

		// Token: 0x0400001A RID: 26
		private static TransportFunctionPointer<NetworkSendInterface.AbortSendMessageDelegate> AbortSendMessageFunctionPointer = new TransportFunctionPointer<NetworkSendInterface.AbortSendMessageDelegate>(new NetworkSendInterface.AbortSendMessageDelegate(BaselibNetworkInterface.AbortSendMessage));

		// Token: 0x0200000B RID: 11
		internal struct Payloads : IDisposable
		{
			// Token: 0x17000003 RID: 3
			// (get) Token: 0x06000024 RID: 36 RVA: 0x00002F6F File Offset: 0x0000116F
			public int InUse
			{
				get
				{
					return this.m_Handles.InUse;
				}
			}

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000025 RID: 37 RVA: 0x00002F7C File Offset: 0x0000117C
			public int Capacity
			{
				get
				{
					return this.m_Handles.Capacity;
				}
			}

			// Token: 0x06000026 RID: 38 RVA: 0x00002F89 File Offset: 0x00001189
			public Payloads(int capacity, uint maxPayloadSize)
			{
				this.m_PayloadSize = maxPayloadSize;
				this.m_Handles = new UnsafeAtomicFreeList(capacity, Allocator.Persistent);
				this.m_PayloadArray = new UnsafeBaselibNetworkArray(capacity, (int)maxPayloadSize);
				this.m_EndpointArray = new UnsafeBaselibNetworkArray(capacity, 28);
			}

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000027 RID: 39 RVA: 0x00002FBA File Offset: 0x000011BA
			public bool IsCreated
			{
				get
				{
					return this.m_Handles.IsCreated;
				}
			}

			// Token: 0x06000028 RID: 40 RVA: 0x00002FC7 File Offset: 0x000011C7
			public void Dispose()
			{
				this.m_Handles.Dispose();
				this.m_PayloadArray.Dispose();
				this.m_EndpointArray.Dispose();
			}

			// Token: 0x06000029 RID: 41 RVA: 0x00002FEC File Offset: 0x000011EC
			public Binding.Baselib_RegisteredNetwork_Request GetRequestFromHandle(int handle)
			{
				return new Binding.Baselib_RegisteredNetwork_Request
				{
					payload = this.m_PayloadArray.AtIndexAsSlice(handle, this.m_PayloadSize),
					remoteEndpoint = new Binding.Baselib_RegisteredNetwork_Endpoint
					{
						slice = this.m_EndpointArray.AtIndexAsSlice(handle, 28U)
					}
				};
			}

			// Token: 0x0600002A RID: 42 RVA: 0x00003040 File Offset: 0x00001240
			public int AcquireHandle()
			{
				return this.m_Handles.Pop();
			}

			// Token: 0x0600002B RID: 43 RVA: 0x0000304D File Offset: 0x0000124D
			public void ReleaseHandle(int handle)
			{
				this.m_Handles.Push(handle);
			}

			// Token: 0x0400001B RID: 27
			public UnsafeAtomicFreeList m_Handles;

			// Token: 0x0400001C RID: 28
			public UnsafeBaselibNetworkArray m_PayloadArray;

			// Token: 0x0400001D RID: 29
			public UnsafeBaselibNetworkArray m_EndpointArray;

			// Token: 0x0400001E RID: 30
			private uint m_PayloadSize;
		}

		// Token: 0x0200000C RID: 12
		internal enum SocketStatus
		{
			// Token: 0x04000020 RID: 32
			SocketNormal,
			// Token: 0x04000021 RID: 33
			SocketNeedsRecreate,
			// Token: 0x04000022 RID: 34
			SocketFailed
		}

		// Token: 0x0200000D RID: 13
		internal struct BaselibData
		{
			// Token: 0x04000023 RID: 35
			public Binding.Baselib_RegisteredNetwork_Socket_UDP m_Socket;

			// Token: 0x04000024 RID: 36
			public BaselibNetworkInterface.SocketStatus m_SocketStatus;

			// Token: 0x04000025 RID: 37
			public BaselibNetworkInterface.Payloads m_PayloadsTx;

			// Token: 0x04000026 RID: 38
			public NetworkInterfaceEndPoint m_LocalEndpoint;

			// Token: 0x04000027 RID: 39
			public long m_LastUpdateTime;

			// Token: 0x04000028 RID: 40
			public long m_LastSocketRecreateTime;

			// Token: 0x04000029 RID: 41
			public uint m_NumSocketRecreate;
		}

		// Token: 0x0200000E RID: 14
		[BurstCompile]
		private struct FlushSendJob : IJob
		{
			// Token: 0x0600002C RID: 44 RVA: 0x0000305C File Offset: 0x0000125C
			public unsafe void Execute()
			{
				Binding.Baselib_RegisteredNetwork_CompletionResult* ptr = stackalloc Binding.Baselib_RegisteredNetwork_CompletionResult[checked(unchecked((UIntPtr)64) * (UIntPtr)sizeof(Binding.Baselib_RegisteredNetwork_CompletionResult))];
				Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
				for (int i = 0; i < this.Tx.Capacity; i++)
				{
					Binding.Baselib_RegisteredNetwork_ProcessStatus baselib_RegisteredNetwork_ProcessStatus = Binding.Baselib_RegisteredNetwork_Socket_UDP_ProcessSend(this.Baselib[0].m_Socket, &baselib_ErrorState);
					if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
					{
						Debug.LogError(string.Format("Error on baselib processing send ({0})", baselib_ErrorState.code));
						BaselibNetworkInterface.MarkSocketAsNeedingRecreate(this.Baselib);
						return;
					}
					if (baselib_RegisteredNetwork_ProcessStatus != Binding.Baselib_RegisteredNetwork_ProcessStatus.Pending)
					{
						break;
					}
				}
				long num = (long)this.Tx.Capacity / 64L + 1L;
				int num2;
				while ((num2 = (int)Binding.Baselib_RegisteredNetwork_Socket_UDP_DequeueSend(this.Baselib[0].m_Socket, ptr, 64U, &baselib_ErrorState)) > 0)
				{
					if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
					{
						BaselibNetworkInterface.MarkSocketAsNeedingRecreate(this.Baselib);
						return;
					}
					for (int j = 0; j < num2; j++)
					{
						this.Tx.ReleaseHandle((int)ptr[j].requestUserdata - 1);
					}
					long num3 = num;
					num = num3 - 1L;
					if (num3 < 0L)
					{
						break;
					}
				}
			}

			// Token: 0x0400002A RID: 42
			public BaselibNetworkInterface.Payloads Tx;

			// Token: 0x0400002B RID: 43
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<BaselibNetworkInterface.BaselibData> Baselib;
		}

		// Token: 0x0200000F RID: 15
		[BurstCompile]
		private struct ReceiveJob : IJob
		{
			// Token: 0x0600002D RID: 45 RVA: 0x00003170 File Offset: 0x00001370
			public unsafe void Execute()
			{
				Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
				BaselibNetworkInterface.BaselibData value = this.Baselib[0];
				value.m_LastUpdateTime = this.Receiver.LastUpdateTime;
				this.Baselib[0] = value;
				int num = 0;
				while (Binding.Baselib_RegisteredNetwork_Socket_UDP_ProcessRecv(this.Baselib[0].m_Socket, &baselib_ErrorState) == Binding.Baselib_RegisteredNetwork_ProcessStatus.Pending && num++ < this.Rx.Capacity)
				{
				}
				Binding.Baselib_RegisteredNetwork_CompletionResult* ptr = stackalloc Binding.Baselib_RegisteredNetwork_CompletionResult[checked(unchecked((UIntPtr)64) * (UIntPtr)sizeof(Binding.Baselib_RegisteredNetwork_CompletionResult))];
				int num2 = 0;
				int num3 = 0;
				for (;;)
				{
					int num4 = (int)Binding.Baselib_RegisteredNetwork_Socket_UDP_DequeueRecv(this.Baselib[0].m_Socket, ptr, 64U, &baselib_ErrorState);
					if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
					{
						break;
					}
					num2 += num4;
					for (int i = 0; i < num4; i++)
					{
						if (ptr[i].status == Binding.Baselib_RegisteredNetwork_CompletionStatus.Failed)
						{
							num3++;
						}
						else
						{
							int bytesTransferred = (int)ptr[i].bytesTransferred;
							if (bytesTransferred > 0)
							{
								int handle = (int)ptr[i].requestUserdata - 1;
								Binding.Baselib_RegisteredNetwork_Request requestFromHandle = this.Rx.GetRequestFromHandle(handle);
								Binding.Baselib_RegisteredNetwork_BufferSlice slice = requestFromHandle.remoteEndpoint.slice;
								NetworkInterfaceEndPoint networkInterfaceEndPoint = default(NetworkInterfaceEndPoint);
								networkInterfaceEndPoint.dataLength = (int)slice.size;
								UnsafeUtility.MemCpy((void*)(&networkInterfaceEndPoint.data.FixedElementField), (void*)slice.data, (long)slice.size);
								this.Receiver.AppendPacket(requestFromHandle.payload.data, ref networkInterfaceEndPoint, bytesTransferred, NetworkPacketReceiver.AppendPacketMode.None);
								this.Rx.ReleaseHandle(handle);
							}
						}
					}
					if ((long)num4 != 64L)
					{
						goto Block_6;
					}
				}
				this.Receiver.ReceiveErrorCode = -10;
				return;
				Block_6:
				if (num2 > 0 && num3 == num2)
				{
					BaselibNetworkInterface.MarkSocketAsNeedingRecreate(this.Baselib);
				}
				int num5 = BaselibNetworkInterface.ScheduleAllReceives(this.Baselib[0].m_Socket, ref this.Rx);
				if (num5 < 0)
				{
					this.Receiver.ReceiveErrorCode = num5;
					BaselibNetworkInterface.MarkSocketAsNeedingRecreate(this.Baselib);
				}
			}

			// Token: 0x0400002C RID: 44
			public NetworkPacketReceiver Receiver;

			// Token: 0x0400002D RID: 45
			public BaselibNetworkInterface.Payloads Rx;

			// Token: 0x0400002E RID: 46
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<BaselibNetworkInterface.BaselibData> Baselib;
		}
	}
}
