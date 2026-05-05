using System;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Networking.Transport
{
	// Token: 0x02000023 RID: 35
	[BurstCompile]
	public struct IPCNetworkInterface : INetworkInterface, IDisposable
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00004A3B File Offset: 0x00002C3B
		public NetworkInterfaceEndPoint LocalEndPoint
		{
			get
			{
				return this.m_LocalEndPoint[0];
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004A49 File Offset: 0x00002C49
		public int CreateInterfaceEndPoint(NetworkEndPoint address, out NetworkInterfaceEndPoint endpoint)
		{
			if (!address.IsLoopback && !address.IsAny)
			{
				endpoint = default(NetworkInterfaceEndPoint);
				return -9;
			}
			endpoint = IPCManager.Instance.CreateEndPoint(address.Port);
			return 0;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004A80 File Offset: 0x00002C80
		public NetworkEndPoint GetGenericEndPoint(NetworkInterfaceEndPoint endpoint)
		{
			ushort port;
			if (!IPCManager.Instance.GetEndPointPort(endpoint, out port))
			{
				return default(NetworkEndPoint);
			}
			return NetworkEndPoint.LoopbackIpv4.WithPort(port);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004AB4 File Offset: 0x00002CB4
		public int Initialize(NetworkSettings settings)
		{
			IPCManager.Instance.AddRef();
			this.m_LocalEndPoint = new NativeArray<NetworkInterfaceEndPoint>(1, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			NetworkInterfaceEndPoint value = default(NetworkInterfaceEndPoint);
			int result;
			if ((result = this.CreateInterfaceEndPoint(NetworkEndPoint.LoopbackIpv4, out value)) != 0)
			{
				return result;
			}
			this.m_LocalEndPoint[0] = value;
			return 0;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004B04 File Offset: 0x00002D04
		public void Dispose()
		{
			this.m_LocalEndPoint.Dispose();
			IPCManager.Instance.Release();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004B1C File Offset: 0x00002D1C
		public JobHandle ScheduleReceive(NetworkPacketReceiver receiver, JobHandle dep)
		{
			dep = new IPCNetworkInterface.ReceiveJob
			{
				receiver = receiver,
				ipcManager = IPCManager.Instance,
				localEndPoint = this.LocalEndPoint
			}.Schedule(JobHandle.CombineDependencies(dep, IPCManager.ManagerAccessHandle));
			IPCManager.ManagerAccessHandle = dep;
			return dep;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004B6C File Offset: 0x00002D6C
		public JobHandle ScheduleSend(NativeQueue<QueuedSendMessage> sendQueue, JobHandle dep)
		{
			dep = new IPCNetworkInterface.SendUpdate
			{
				ipcManager = IPCManager.Instance,
				ipcQueue = sendQueue,
				localEndPoint = this.m_LocalEndPoint
			}.Schedule(JobHandle.CombineDependencies(dep, IPCManager.ManagerAccessHandle));
			IPCManager.ManagerAccessHandle = dep;
			return dep;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004BBC File Offset: 0x00002DBC
		public int Bind(NetworkInterfaceEndPoint endpoint)
		{
			this.m_LocalEndPoint[0] = endpoint;
			return 0;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00002C09 File Offset: 0x00000E09
		public int Listen()
		{
			return 0;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004BCC File Offset: 0x00002DCC
		public NetworkSendInterface CreateSendInterface()
		{
			return new NetworkSendInterface
			{
				BeginSendMessage = IPCNetworkInterface.BeginSendMessageFunctionPointer,
				EndSendMessage = IPCNetworkInterface.EndSendMessageFunctionPointer,
				AbortSendMessage = IPCNetworkInterface.AbortSendMessageFunctionPointer
			};
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004C06 File Offset: 0x00002E06
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkSendInterface.BeginSendMessageDelegate))]
		private static int BeginSendMessage(out NetworkInterfaceSendHandle handle, IntPtr userData, int requiredPayloadSize)
		{
			handle.id = 0;
			handle.size = 0;
			handle.capacity = requiredPayloadSize;
			handle.data = (IntPtr)UnsafeUtility.Malloc((long)handle.capacity, 8, Allocator.Temp);
			handle.flags = (SendHandleFlags)0;
			return 0;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004C40 File Offset: 0x00002E40
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkSendInterface.EndSendMessageDelegate))]
		private unsafe static int EndSendMessage(ref NetworkInterfaceSendHandle handle, ref NetworkInterfaceEndPoint address, IntPtr userData, ref NetworkSendQueueHandle sendQueueHandle)
		{
			NativeQueue<QueuedSendMessage>.ParallelWriter parallelWriter = sendQueueHandle.FromHandle();
			QueuedSendMessage value = default(QueuedSendMessage);
			value.Dest = address;
			value.DataLength = handle.size;
			UnsafeUtility.MemCpy((void*)(&value.Data.FixedElementField), (void*)handle.data, (long)handle.size);
			parallelWriter.Enqueue(value);
			return handle.size;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003CAF File Offset: 0x00001EAF
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkSendInterface.AbortSendMessageDelegate))]
		private static void AbortSendMessage(ref NetworkInterfaceSendHandle handle, IntPtr userData)
		{
		}

		// Token: 0x0400005B RID: 91
		[ReadOnly]
		private NativeArray<NetworkInterfaceEndPoint> m_LocalEndPoint;

		// Token: 0x0400005C RID: 92
		private static TransportFunctionPointer<NetworkSendInterface.BeginSendMessageDelegate> BeginSendMessageFunctionPointer = new TransportFunctionPointer<NetworkSendInterface.BeginSendMessageDelegate>(new NetworkSendInterface.BeginSendMessageDelegate(IPCNetworkInterface.BeginSendMessage));

		// Token: 0x0400005D RID: 93
		private static TransportFunctionPointer<NetworkSendInterface.EndSendMessageDelegate> EndSendMessageFunctionPointer = new TransportFunctionPointer<NetworkSendInterface.EndSendMessageDelegate>(new NetworkSendInterface.EndSendMessageDelegate(IPCNetworkInterface.EndSendMessage));

		// Token: 0x0400005E RID: 94
		private static TransportFunctionPointer<NetworkSendInterface.AbortSendMessageDelegate> AbortSendMessageFunctionPointer = new TransportFunctionPointer<NetworkSendInterface.AbortSendMessageDelegate>(new NetworkSendInterface.AbortSendMessageDelegate(IPCNetworkInterface.AbortSendMessage));

		// Token: 0x02000024 RID: 36
		[BurstCompile]
		private struct SendUpdate : IJob
		{
			// Token: 0x060000D4 RID: 212 RVA: 0x00004CF7 File Offset: 0x00002EF7
			public void Execute()
			{
				this.ipcManager.Update(this.localEndPoint[0], this.ipcQueue);
			}

			// Token: 0x0400005F RID: 95
			public IPCManager ipcManager;

			// Token: 0x04000060 RID: 96
			public NativeQueue<QueuedSendMessage> ipcQueue;

			// Token: 0x04000061 RID: 97
			[ReadOnly]
			public NativeArray<NetworkInterfaceEndPoint> localEndPoint;
		}

		// Token: 0x02000025 RID: 37
		[BurstCompile]
		private struct ReceiveJob : IJob
		{
			// Token: 0x060000D5 RID: 213 RVA: 0x00004D18 File Offset: 0x00002F18
			public void Execute()
			{
				this.receiver.ReceiveErrorCode = 0;
				int num;
				for (;;)
				{
					int length = 1472;
					IntPtr intPtr = this.receiver.AllocateMemory(ref length);
					if (intPtr == IntPtr.Zero)
					{
						break;
					}
					NetworkInterfaceEndPoint networkInterfaceEndPoint = default(NetworkInterfaceEndPoint);
					num = this.NativeReceive(intPtr.ToPointer(), length, ref networkInterfaceEndPoint);
					if (num <= 0)
					{
						goto Block_2;
					}
					if (!this.receiver.AppendPacket(intPtr, ref networkInterfaceEndPoint, num, NetworkPacketReceiver.AppendPacketMode.NoCopyNeeded))
					{
						return;
					}
				}
				return;
				Block_2:
				if (num != 0)
				{
					this.receiver.ReceiveErrorCode = -num;
				}
			}

			// Token: 0x060000D6 RID: 214 RVA: 0x00004D93 File Offset: 0x00002F93
			private unsafe int NativeReceive(void* data, int length, ref NetworkInterfaceEndPoint address)
			{
				return this.ipcManager.ReceiveMessageEx(this.localEndPoint, data, length, ref address);
			}

			// Token: 0x04000062 RID: 98
			public NetworkPacketReceiver receiver;

			// Token: 0x04000063 RID: 99
			public IPCManager ipcManager;

			// Token: 0x04000064 RID: 100
			public NetworkInterfaceEndPoint localEndPoint;
		}
	}
}
