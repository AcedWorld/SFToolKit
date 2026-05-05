using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Networking.Transport.Error;
using Unity.Networking.Transport.Protocols;
using Unity.Networking.Transport.Relay;
using Unity.Networking.Transport.TLS;
using Unity.Networking.Transport.Utilities;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x0200002F RID: 47
	public struct NetworkDriver : IDisposable
	{
		// Token: 0x060000EA RID: 234 RVA: 0x0000527C File Offset: 0x0000347C
		public NetworkDriver.Concurrent ToConcurrent()
		{
			return new NetworkDriver.Concurrent
			{
				m_NetworkSendInterface = this.m_NetworkSendInterface,
				m_NetworkProtocolInterface = this.m_NetworkProtocolInterface,
				m_EventQueue = this.m_EventQueue.ToConcurrent(),
				m_ConnectionList = this.m_ConnectionList,
				m_DataStream = this.m_DataStream,
				m_DisconnectReasons = this.m_DisconnectReasons,
				m_PipelineProcessor = this.m_PipelineProcessor.ToConcurrent(),
				m_DefaultHeaderFlags = this.m_DefaultHeaderFlags,
				m_ConcurrentParallelSendQueue = this.m_ParallelSendQueue.AsParallelWriter(),
				m_MaxMessageSize = this.m_NetworkParams.config.maxMessageSize
			};
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005330 File Offset: 0x00003530
		private NetworkDriver.Concurrent ToConcurrentSendOnly()
		{
			return new NetworkDriver.Concurrent
			{
				m_NetworkSendInterface = this.m_NetworkSendInterface,
				m_NetworkProtocolInterface = this.m_NetworkProtocolInterface,
				m_EventQueue = default(NetworkEventQueue.Concurrent),
				m_ConnectionList = this.m_ConnectionList,
				m_DataStream = this.m_DataStream,
				m_DisconnectReasons = this.m_DisconnectReasons,
				m_PipelineProcessor = this.m_PipelineProcessor.ToConcurrent(),
				m_DefaultHeaderFlags = this.m_DefaultHeaderFlags,
				m_ConcurrentParallelSendQueue = this.m_ParallelSendQueue.AsParallelWriter(),
				m_MaxMessageSize = this.m_NetworkParams.config.maxMessageSize
			};
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000EC RID: 236 RVA: 0x000053DC File Offset: 0x000035DC
		internal INetworkInterface NetworkInterface
		{
			get
			{
				return NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex];
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000ED RID: 237 RVA: 0x000053EE File Offset: 0x000035EE
		internal INetworkProtocol NetworkProtocol
		{
			get
			{
				return NetworkDriver.s_NetworkProtocols[this.m_NetworkProtocolIndex];
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00005400 File Offset: 0x00003600
		internal int ProtocolStatus
		{
			get
			{
				return this.m_ProtocolStatus.Value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000EF RID: 239 RVA: 0x0000540D File Offset: 0x0000360D
		public long LastUpdateTime
		{
			get
			{
				return this.m_UpdateTime;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00005415 File Offset: 0x00003615
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00005426 File Offset: 0x00003626
		public bool Listening
		{
			get
			{
				return this.m_InternalState[0] != 0;
			}
			private set
			{
				this.m_InternalState[0] = (value ? 1 : 0);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x0000543B File Offset: 0x0000363B
		public bool Bound
		{
			get
			{
				return this.m_InternalState[1] == 1;
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000544C File Offset: 0x0000364C
		public static NetworkDriver Create(NetworkSettings settings)
		{
			return new NetworkDriver(default(BaselibNetworkInterface), settings);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000546D File Offset: 0x0000366D
		public static NetworkDriver Create()
		{
			return NetworkDriver.Create(new NetworkSettings(Allocator.Temp));
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000547A File Offset: 0x0000367A
		public static NetworkDriver Create<N>(N networkInterface) where N : INetworkInterface
		{
			return NetworkDriver.Create<N>(networkInterface, new NetworkSettings(Allocator.Temp));
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00005488 File Offset: 0x00003688
		public static NetworkDriver Create<N>(N networkInterface, NetworkSettings settings) where N : INetworkInterface
		{
			return new NetworkDriver(networkInterface, settings);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00005498 File Offset: 0x00003698
		public NetworkDriver(INetworkInterface netIf)
		{
			this = new NetworkDriver(netIf, default(NetworkSettings));
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000054B5 File Offset: 0x000036B5
		[Obsolete("Use Create(NetworkSettings) instead", false)]
		public static NetworkDriver Create(params INetworkParameter[] param)
		{
			return NetworkDriver.Create(NetworkSettings.FromArray(param));
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000054C2 File Offset: 0x000036C2
		[Obsolete("Use NetworkDriver(INetworkInterface, NetworkSettings) instead", false)]
		public NetworkDriver(INetworkInterface netIf, params INetworkParameter[] param)
		{
			this = new NetworkDriver(netIf, NetworkSettings.FromArray(param));
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000054D1 File Offset: 0x000036D1
		[Obsolete("Use NetworkDriver(INetworkInterface, NetworkSettings) instead", false)]
		internal NetworkDriver(INetworkInterface netIf, INetworkProtocol netProtocol, params INetworkParameter[] param)
		{
			this = new NetworkDriver(netIf, netProtocol, NetworkSettings.FromArray(param));
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000054E4 File Offset: 0x000036E4
		private static int InsertInAvailableIndex<T>(List<T> list, T element)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				if (list[i] == null)
				{
					list[i] = element;
					return i;
				}
			}
			list.Add(element);
			return count;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00005524 File Offset: 0x00003724
		private static INetworkProtocol GetProtocolForParameters(NetworkSettings settings)
		{
			RelayNetworkParameter relayNetworkParameter;
			if (settings.TryGet<RelayNetworkParameter>(out relayNetworkParameter))
			{
				return default(RelayNetworkProtocol);
			}
			SecureNetworkProtocolParameter secureNetworkProtocolParameter;
			if (settings.TryGet<SecureNetworkProtocolParameter>(out secureNetworkProtocolParameter))
			{
				return default(SecureNetworkProtocol);
			}
			return default(UnityTransportProtocol);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00005574 File Offset: 0x00003774
		public NetworkDriver(INetworkInterface netIf, NetworkSettings settings)
		{
			this = new NetworkDriver(netIf, NetworkDriver.GetProtocolForParameters(settings), settings);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00005584 File Offset: 0x00003784
		internal NetworkDriver(INetworkInterface netIf, INetworkProtocol netProtocol, NetworkSettings settings)
		{
			this.m_NetworkParams = new NetworkDriver.Parameters(settings);
			netProtocol.Initialize(settings);
			this.m_NetworkProtocolIndex = NetworkDriver.InsertInAvailableIndex<INetworkProtocol>(NetworkDriver.s_NetworkProtocols, netProtocol);
			this.m_NetworkProtocolInterface = netProtocol.CreateProtocolInterface();
			this.m_NetworkInterfaceIndex = NetworkDriver.InsertInAvailableIndex<INetworkInterface>(NetworkDriver.s_NetworkInterfaces, netIf);
			int num = netIf.Initialize(settings);
			if (num != 0)
			{
				Debug.LogError(string.Format("Failed to initialize the NetworkInterface. Error Code: {0}.", num));
			}
			this.m_NetworkSendInterface = netIf.CreateSendInterface();
			this.m_PipelineProcessor = new NetworkPipelineProcessor(settings);
			this.m_ParallelSendQueue = new NativeQueue<QueuedSendMessage>(Allocator.Persistent);
			long timestamp = Stopwatch.GetTimestamp();
			long num2 = timestamp / (Stopwatch.Frequency / 1000L);
			this.m_UpdateTime = ((this.m_NetworkParams.config.fixedFrameTimeMS > 0) ? 1L : num2);
			this.m_UpdateTimeAdjustment = 0L;
			this.m_Rand = new Unity.Mathematics.Random((uint)timestamp);
			int num3 = this.m_NetworkParams.dataStream.size;
			if (num3 == 0)
			{
				num3 = 65536;
			}
			this.m_DataStream = new NativeList<byte>(num3, Allocator.Persistent);
			this.m_DataStream.ResizeUninitialized(num3);
			this.m_DataStreamHead = new NativeArray<int>(1, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.m_DefaultHeaderFlags = (UdpCHeader.HeaderFlags)0;
			this.m_NetworkAcceptQueue = new NativeQueue<int>(Allocator.Persistent);
			this.m_ConnectionList = new NativeList<NetworkDriver.Connection>(1, Allocator.Persistent);
			this.m_FreeList = new NativeQueue<int>(Allocator.Persistent);
			this.m_EventQueue = new NetworkEventQueue(100);
			this.m_DisconnectReasons = new NativeArray<byte>(4, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			for (int i = 0; i < 4; i++)
			{
				this.m_DisconnectReasons[i] = (byte)i;
			}
			this.m_InternalState = new NativeArray<int>(2, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.m_PendingFree = new NativeQueue<int>(Allocator.Persistent);
			this.m_ProtocolStatus = new NativeReference<int>(Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.m_ProtocolStatus.Value = 0;
			this.m_ErrorCodes = new NativeArray<int>(2, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.Listening = false;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00005774 File Offset: 0x00003974
		public void Dispose()
		{
			if (!this.IsCreated)
			{
				return;
			}
			NetworkDriver.s_NetworkProtocols[this.m_NetworkProtocolIndex].Dispose();
			NetworkDriver.s_NetworkProtocols[this.m_NetworkProtocolIndex] = null;
			NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex].Dispose();
			NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex] = null;
			this.m_NetworkProtocolIndex = -1;
			this.m_NetworkInterfaceIndex = -1;
			this.m_DataStream.Dispose();
			this.m_DataStreamHead.Dispose();
			this.m_PipelineProcessor.Dispose();
			this.m_EventQueue.Dispose();
			this.m_DisconnectReasons.Dispose();
			this.m_NetworkAcceptQueue.Dispose();
			this.m_ConnectionList.Dispose();
			this.m_FreeList.Dispose();
			this.m_InternalState.Dispose();
			this.m_PendingFree.Dispose();
			this.m_ProtocolStatus.Dispose();
			this.m_ErrorCodes.Dispose();
			this.m_ParallelSendQueue.Dispose();
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00005873 File Offset: 0x00003A73
		public bool IsCreated
		{
			get
			{
				return this.m_InternalState.IsCreated;
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005880 File Offset: 0x00003A80
		private unsafe SessionIdToken GenerateRandomSessionIdToken(ref SessionIdToken token)
		{
			for (uint num = 0U; num < 8U; num += 1U)
			{
				*(ref token.Value.FixedElementField + (UIntPtr)num) = (byte)(this.m_Rand.NextUInt() & 255U);
			}
			return token;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000058C0 File Offset: 0x00003AC0
		private void UpdateLastUpdateTime()
		{
			long timestamp = Stopwatch.GetTimestamp();
			long num = (this.m_NetworkParams.config.fixedFrameTimeMS > 0) ? (this.m_UpdateTime + (long)this.m_NetworkParams.config.fixedFrameTimeMS) : (timestamp / (Stopwatch.Frequency / 1000L) - this.m_UpdateTimeAdjustment);
			this.m_Rand.InitState((uint)timestamp);
			long num2 = num - this.m_UpdateTime;
			if (this.m_NetworkParams.config.maxFrameTimeMS > 0 && num2 > (long)this.m_NetworkParams.config.maxFrameTimeMS)
			{
				this.m_UpdateTimeAdjustment += num2 - (long)this.m_NetworkParams.config.maxFrameTimeMS;
				num = this.m_UpdateTime + (long)this.m_NetworkParams.config.maxFrameTimeMS;
			}
			this.m_UpdateTime = num;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005994 File Offset: 0x00003B94
		public JobHandle ScheduleUpdate(JobHandle dep = default(JobHandle))
		{
			this.UpdateLastUpdateTime();
			NetworkDriver.UpdateJob jobData = new NetworkDriver.UpdateJob
			{
				driver = this
			};
			if (this.Bound)
			{
				JobHandle jobHandle = new NetworkDriver.ClearEventQueue
				{
					dataStream = this.m_DataStream,
					dataStreamHead = this.m_DataStreamHead,
					eventQueue = this.m_EventQueue
				}.Schedule(dep);
				jobHandle = jobData.Schedule(jobHandle);
				jobHandle = NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex].ScheduleReceive(new NetworkPacketReceiver
				{
					m_Driver = this
				}, jobHandle);
				return NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex].ScheduleSend(this.m_ParallelSendQueue, jobHandle);
			}
			return jobData.Schedule(dep);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00005A5C File Offset: 0x00003C5C
		public JobHandle ScheduleFlushSend(JobHandle dep)
		{
			if (this.Bound)
			{
				return NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex].ScheduleSend(this.m_ParallelSendQueue, dep);
			}
			return dep;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00005A84 File Offset: 0x00003C84
		private void InternalUpdate()
		{
			this.m_PipelineProcessor.Timestamp = this.m_UpdateTime;
			int num;
			while (this.m_PendingFree.TryDequeue(out num))
			{
				int num2 = this.m_ConnectionList[num].Version + 1;
				if (num2 == 0)
				{
					num2 = 1;
				}
				this.m_ConnectionList[num] = new NetworkDriver.Connection
				{
					Id = num,
					Version = num2,
					IsAccepted = 0
				};
				this.m_FreeList.Enqueue(num);
			}
			this.CheckTimeouts();
			if (this.m_NetworkProtocolInterface.NeedsUpdate)
			{
				NetworkSendQueueHandle networkSendQueueHandle = NetworkSendQueueHandle.ToTempHandle(this.m_ParallelSendQueue.AsParallelWriter());
				this.m_NetworkProtocolInterface.Update.Ptr.Invoke(this.m_UpdateTime, ref this.m_NetworkSendInterface, ref networkSendQueueHandle, this.m_NetworkProtocolInterface.UserData);
			}
			int num3;
			this.m_PipelineProcessor.UpdateReceive(this, out num3);
			int num4 = math.max(0, (this.m_ConnectionList.Length - this.m_FreeList.Count) * 64);
			if (num3 > num4)
			{
				Debug.LogWarning(FixedString.Format("A lot of pipeline updates have been queued, possibly too many being scheduled in pipeline logic, queue count: {0}", num3));
			}
			this.m_DefaultHeaderFlags = UdpCHeader.HeaderFlags.HasPipeline;
			this.m_PipelineProcessor.UpdateSend(this.ToConcurrentSendOnly(), out num3);
			if (num3 > num4)
			{
				Debug.LogWarning(FixedString.Format("A lot of pipeline updates have been queued, possibly too many being scheduled in pipeline logic, queue count: {0}", num3));
			}
			this.m_DefaultHeaderFlags = (UdpCHeader.HeaderFlags)0;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00005BEF File Offset: 0x00003DEF
		public NetworkPipeline CreatePipeline(params Type[] stages)
		{
			return this.m_PipelineProcessor.CreatePipeline(stages);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00005C00 File Offset: 0x00003E00
		public int Bind(NetworkEndPoint endpoint)
		{
			NetworkInterfaceEndPoint networkInterfaceEndPoint;
			if (NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex].CreateInterfaceEndPoint(endpoint, out networkInterfaceEndPoint) != 0)
			{
				return -1;
			}
			int num = NetworkDriver.s_NetworkProtocols[this.m_NetworkProtocolIndex].Bind(NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex], ref networkInterfaceEndPoint);
			this.m_InternalState[1] = ((num == 0) ? 1 : 0);
			return num;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005C65 File Offset: 0x00003E65
		public int Listen()
		{
			if (!this.Bound)
			{
				return -1;
			}
			int num = NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex].Listen();
			if (num == 0)
			{
				this.Listening = true;
			}
			return num;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00005C90 File Offset: 0x00003E90
		public NetworkConnection Accept()
		{
			if (!this.Listening)
			{
				return default(NetworkConnection);
			}
			int num;
			if (!this.m_NetworkAcceptQueue.TryDequeue(out num))
			{
				return default(NetworkConnection);
			}
			NetworkDriver.Connection connection = this.m_ConnectionList[num];
			connection.State = NetworkConnection.State.Connected;
			connection.IsAccepted = 1;
			this.SetConnection(connection);
			return new NetworkConnection
			{
				m_NetworkId = num,
				m_NetworkVersion = this.m_ConnectionList[num].Version
			};
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00005D18 File Offset: 0x00003F18
		public NetworkConnection Connect(NetworkEndPoint endpoint)
		{
			if (!this.Bound)
			{
				NetworkEndPoint endpoint2 = (endpoint.Family == NetworkFamily.Ipv6) ? NetworkEndPoint.AnyIpv6 : NetworkEndPoint.AnyIpv4;
				if (this.Bind(endpoint2) != 0)
				{
					return default(NetworkConnection);
				}
			}
			NetworkInterfaceEndPoint address;
			if (NetworkDriver.s_NetworkProtocols[this.m_NetworkProtocolIndex].CreateConnectionAddress(NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex], endpoint, out address) != 0)
			{
				return default(NetworkConnection);
			}
			int length;
			NetworkDriver.Connection connection;
			if (!this.m_FreeList.TryDequeue(out length))
			{
				length = this.m_ConnectionList.Length;
				connection = default(NetworkDriver.Connection);
				connection.Id = length;
				connection.Version = 1;
				this.m_ConnectionList.Add(connection);
			}
			int version = this.m_ConnectionList[length].Version;
			SessionIdToken receiveToken = default(SessionIdToken);
			this.GenerateRandomSessionIdToken(ref receiveToken);
			connection = new NetworkDriver.Connection
			{
				Id = length,
				Version = version,
				State = NetworkConnection.State.Connecting,
				Address = address,
				ConnectAttempts = 1,
				LastNonDataSend = this.m_UpdateTime,
				LastReceive = 0L,
				SendToken = default(SessionIdToken),
				ReceiveToken = receiveToken,
				IsAccepted = 0
			};
			NetworkDriver.Connection connection2 = connection;
			this.SetConnection(connection2);
			NetworkConnection networkConnection = new NetworkConnection
			{
				m_NetworkId = length,
				m_NetworkVersion = version
			};
			NetworkSendQueueHandle networkSendQueueHandle = NetworkSendQueueHandle.ToTempHandle(this.m_ParallelSendQueue.AsParallelWriter());
			this.m_NetworkProtocolInterface.Connect.Ptr.Invoke(ref connection2, ref this.m_NetworkSendInterface, ref networkSendQueueHandle, this.m_NetworkProtocolInterface.UserData);
			this.m_PipelineProcessor.initializeConnection(networkConnection);
			return networkConnection;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00005ED0 File Offset: 0x000040D0
		public int Disconnect(NetworkConnection id)
		{
			NetworkDriver.Connection connection;
			if ((connection = this.GetConnection(id)) == NetworkDriver.Connection.Null)
			{
				return 0;
			}
			if (connection.State == NetworkConnection.State.Connected)
			{
				NetworkSendQueueHandle networkSendQueueHandle = NetworkSendQueueHandle.ToTempHandle(this.m_ParallelSendQueue.AsParallelWriter());
				this.m_NetworkProtocolInterface.Disconnect.Ptr.Invoke(ref connection, ref this.m_NetworkSendInterface, ref networkSendQueueHandle, this.m_NetworkProtocolInterface.UserData);
			}
			this.RemoveConnection(connection);
			return 0;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00005F48 File Offset: 0x00004148
		public void GetPipelineBuffers(NetworkPipeline pipeline, NetworkPipelineStageId stageId, NetworkConnection connection, out NativeArray<byte> readProcessingBuffer, out NativeArray<byte> writeProcessingBuffer, out NativeArray<byte> sharedBuffer)
		{
			if (connection.m_NetworkId < 0 || connection.m_NetworkId >= this.m_ConnectionList.Length || this.m_ConnectionList[connection.m_NetworkId].Version != connection.m_NetworkVersion)
			{
				Debug.LogError("Trying to get pipeline buffers for invalid connection.");
				readProcessingBuffer = default(NativeArray<byte>);
				writeProcessingBuffer = default(NativeArray<byte>);
				sharedBuffer = default(NativeArray<byte>);
				return;
			}
			this.m_PipelineProcessor.GetPipelineBuffers(pipeline, stageId, connection, out readProcessingBuffer, out writeProcessingBuffer, out sharedBuffer);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00005FC8 File Offset: 0x000041C8
		public NetworkConnection.State GetConnectionState(NetworkConnection con)
		{
			NetworkDriver.Connection connection;
			if ((connection = this.GetConnection(con)) == NetworkDriver.Connection.Null)
			{
				return NetworkConnection.State.Disconnected;
			}
			return connection.State;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005FF4 File Offset: 0x000041F4
		public NetworkEndPoint RemoteEndPoint(NetworkConnection id)
		{
			if (id == default(NetworkConnection))
			{
				return default(NetworkEndPoint);
			}
			NetworkDriver.Connection connection;
			if ((connection = this.GetConnection(id)) == NetworkDriver.Connection.Null)
			{
				return default(NetworkEndPoint);
			}
			return NetworkDriver.s_NetworkProtocols[this.m_NetworkProtocolIndex].GetRemoteEndPoint(NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex], connection.Address);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00006068 File Offset: 0x00004268
		public NetworkEndPoint LocalEndPoint()
		{
			NetworkInterfaceEndPoint localEndPoint = NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex].LocalEndPoint;
			return NetworkDriver.s_NetworkInterfaces[this.m_NetworkInterfaceIndex].GetGenericEndPoint(localEndPoint);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000060A4 File Offset: 0x000042A4
		public int MaxHeaderSize(NetworkPipeline pipe)
		{
			return this.ToConcurrentSendOnly().MaxHeaderSize(pipe);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000060C0 File Offset: 0x000042C0
		internal int MaxProtocolHeaderSize()
		{
			return this.m_NetworkProtocolInterface.PaddingSize;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000060D0 File Offset: 0x000042D0
		public int BeginSend(NetworkPipeline pipe, NetworkConnection id, out DataStreamWriter writer, int requiredPayloadSize = 0)
		{
			return this.ToConcurrentSendOnly().BeginSend(pipe, id, out writer, requiredPayloadSize);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000060F0 File Offset: 0x000042F0
		public int BeginSend(NetworkConnection id, out DataStreamWriter writer, int requiredPayloadSize = 0)
		{
			return this.ToConcurrentSendOnly().BeginSend(NetworkPipeline.Null, id, out writer, requiredPayloadSize);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00006114 File Offset: 0x00004314
		public int EndSend(DataStreamWriter writer)
		{
			return this.ToConcurrentSendOnly().EndSend(writer);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00006130 File Offset: 0x00004330
		public void AbortSend(DataStreamWriter writer)
		{
			this.ToConcurrentSendOnly().AbortSend(writer);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000614C File Offset: 0x0000434C
		public NetworkEvent.Type PopEvent(out NetworkConnection con, out DataStreamReader reader)
		{
			NetworkPipeline networkPipeline;
			return this.PopEvent(out con, out reader, out networkPipeline);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00006164 File Offset: 0x00004364
		public NetworkEvent.Type PopEvent(out NetworkConnection con, out DataStreamReader reader, out NetworkPipeline pipeline)
		{
			reader = default(DataStreamReader);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int id = 0;
			NetworkEvent.Type type;
			for (;;)
			{
				type = this.m_EventQueue.PopEvent(out num, out num2, out num3, out id);
				if (num < 0 || type != NetworkEvent.Type.Data || this.m_ConnectionList[num].IsAccepted != 0)
				{
					break;
				}
				Debug.LogWarning("A NetworkEvent.Data event was discarded for a connection that had not been accepted yet. To avoid this, consider calling Accept() prior to PopEvent() in your project's network update loop, or only use PopEventForConnection() in conjunction with Accept().");
			}
			pipeline = new NetworkPipeline
			{
				Id = id
			};
			if (type == NetworkEvent.Type.Disconnect && num2 < 0)
			{
				reader = new DataStreamReader(this.m_DisconnectReasons.GetSubArray(math.abs(num2), 1));
			}
			else if (num3 > 0)
			{
				reader = new DataStreamReader(this.m_DataStream.GetSubArray(num2, num3));
			}
			con = ((num < 0) ? default(NetworkConnection) : new NetworkConnection
			{
				m_NetworkId = num,
				m_NetworkVersion = this.m_ConnectionList[num].Version
			});
			return type;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00006264 File Offset: 0x00004464
		public NetworkEvent.Type PopEventForConnection(NetworkConnection connectionId, out DataStreamReader reader)
		{
			NetworkPipeline networkPipeline;
			return this.PopEventForConnection(connectionId, out reader, out networkPipeline);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000627C File Offset: 0x0000447C
		public NetworkEvent.Type PopEventForConnection(NetworkConnection connectionId, out DataStreamReader reader, out NetworkPipeline pipeline)
		{
			reader = default(DataStreamReader);
			pipeline = default(NetworkPipeline);
			if (connectionId.m_NetworkId < 0 || connectionId.m_NetworkId >= this.m_ConnectionList.Length || this.m_ConnectionList[connectionId.m_NetworkId].Version != connectionId.m_NetworkVersion)
			{
				return NetworkEvent.Type.Empty;
			}
			int num;
			int num2;
			int id;
			NetworkEvent.Type type = this.m_EventQueue.PopEventForConnection(connectionId.m_NetworkId, out num, out num2, out id);
			pipeline = new NetworkPipeline
			{
				Id = id
			};
			if (type == NetworkEvent.Type.Disconnect && num < 0)
			{
				reader = new DataStreamReader(this.m_DisconnectReasons.GetSubArray(math.abs(num), 1));
				return type;
			}
			if (num2 > 0)
			{
				reader = new DataStreamReader(this.m_DataStream.GetSubArray(num, num2));
			}
			return type;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000634C File Offset: 0x0000454C
		public int GetEventQueueSizeForConnection(NetworkConnection connectionId)
		{
			if (connectionId.m_NetworkId < 0 || connectionId.m_NetworkId >= this.m_ConnectionList.Length || this.m_ConnectionList[connectionId.m_NetworkId].Version != connectionId.m_NetworkVersion)
			{
				return 0;
			}
			return this.m_EventQueue.GetCountForConnection(connectionId.m_NetworkId);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000063A8 File Offset: 0x000045A8
		private void AddConnectEvent(int id)
		{
			this.m_EventQueue.PushEvent(new NetworkEvent
			{
				connectionId = id,
				type = NetworkEvent.Type.Connect
			});
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000063DC File Offset: 0x000045DC
		private void AddDisconnectEvent(int id, DisconnectReason reason = DisconnectReason.Default)
		{
			this.m_EventQueue.PushEvent(new NetworkEvent
			{
				connectionId = id,
				type = NetworkEvent.Type.Disconnect,
				status = (int)reason
			});
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00006418 File Offset: 0x00004618
		private NetworkDriver.Connection GetConnection(NetworkConnection id)
		{
			if (id.m_NetworkId < 0 || id.m_NetworkId >= this.m_ConnectionList.Length)
			{
				return NetworkDriver.Connection.Null;
			}
			NetworkDriver.Connection connection = this.m_ConnectionList[id.m_NetworkId];
			if (connection.Version != id.m_NetworkVersion)
			{
				return NetworkDriver.Connection.Null;
			}
			return connection;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00006470 File Offset: 0x00004670
		private NetworkDriver.Connection GetConnection(NetworkInterfaceEndPoint address, SessionIdToken sessionId)
		{
			for (int i = 0; i < this.m_ConnectionList.Length; i++)
			{
				if (address == this.m_ConnectionList[i].Address && this.m_ConnectionList[i].ReceiveToken == sessionId)
				{
					return this.m_ConnectionList[i];
				}
			}
			return NetworkDriver.Connection.Null;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000064D8 File Offset: 0x000046D8
		private NetworkDriver.Connection GetNewConnection(NetworkInterfaceEndPoint address, SessionIdToken sessionId)
		{
			for (int i = 0; i < this.m_ConnectionList.Length; i++)
			{
				if (address == this.m_ConnectionList[i].Address && this.m_ConnectionList[i].SendToken == sessionId)
				{
					return this.m_ConnectionList[i];
				}
			}
			return NetworkDriver.Connection.Null;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000653F File Offset: 0x0000473F
		private void SetConnection(NetworkDriver.Connection connection)
		{
			this.m_ConnectionList[connection.Id] = connection;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00006554 File Offset: 0x00004754
		private bool RemoveConnection(NetworkDriver.Connection connection)
		{
			if (connection.State != NetworkConnection.State.Disconnected && connection == this.m_ConnectionList[connection.Id])
			{
				connection.State = NetworkConnection.State.Disconnected;
				this.m_ConnectionList[connection.Id] = connection;
				this.m_PendingFree.Enqueue(connection.Id);
				return true;
			}
			return false;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000065B0 File Offset: 0x000047B0
		private void UpdateConnection(NetworkDriver.Connection connection)
		{
			if (connection == this.m_ConnectionList[connection.Id])
			{
				this.SetConnection(connection);
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000065D4 File Offset: 0x000047D4
		private void CheckTimeouts()
		{
			for (int i = 0; i < this.m_ConnectionList.Length; i++)
			{
				NetworkDriver.Connection connection = this.m_ConnectionList[i];
				if (!(connection == NetworkDriver.Connection.Null))
				{
					long updateTime = this.m_UpdateTime;
					NetworkConnection id = new NetworkConnection
					{
						m_NetworkId = connection.Id,
						m_NetworkVersion = connection.Version
					};
					if (connection.State == NetworkConnection.State.Connecting && updateTime - connection.LastNonDataSend > (long)this.m_NetworkParams.config.connectTimeoutMS)
					{
						if (connection.ConnectAttempts >= this.m_NetworkParams.config.maxConnectAttempts)
						{
							this.Disconnect(id);
							this.AddDisconnectEvent(connection.Id, DisconnectReason.MaxConnectionAttempts);
							goto IL_20E;
						}
						int connectAttempts = connection.ConnectAttempts + 1;
						connection.ConnectAttempts = connectAttempts;
						connection.ConnectAttempts = connectAttempts;
						connection.LastNonDataSend = updateTime;
						this.SetConnection(connection);
						NetworkSendQueueHandle networkSendQueueHandle = NetworkSendQueueHandle.ToTempHandle(this.m_ParallelSendQueue.AsParallelWriter());
						this.m_NetworkProtocolInterface.Connect.Ptr.Invoke(ref connection, ref this.m_NetworkSendInterface, ref networkSendQueueHandle, this.m_NetworkProtocolInterface.UserData);
					}
					if (connection.State == NetworkConnection.State.Connected && updateTime - connection.LastReceive > (long)this.m_NetworkParams.config.disconnectTimeoutMS)
					{
						this.Disconnect(id);
						this.AddDisconnectEvent(connection.Id, DisconnectReason.Timeout);
						connection = this.m_ConnectionList[i];
					}
					if (connection.State == NetworkConnection.State.Connected && connection.DidReceiveData != 0 && this.m_NetworkParams.config.heartbeatTimeoutMS > 0 && updateTime - connection.LastReceive > (long)this.m_NetworkParams.config.heartbeatTimeoutMS && updateTime - connection.LastNonDataSend > (long)this.m_NetworkParams.config.heartbeatTimeoutMS)
					{
						connection.LastNonDataSend = updateTime;
						this.SetConnection(connection);
						NetworkSendQueueHandle networkSendQueueHandle2 = NetworkSendQueueHandle.ToTempHandle(this.m_ParallelSendQueue.AsParallelWriter());
						this.m_NetworkProtocolInterface.ProcessSendPing.Ptr.Invoke(ref connection, ref this.m_NetworkSendInterface, ref networkSendQueueHandle2, this.m_NetworkProtocolInterface.UserData);
					}
				}
				IL_20E:;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00006804 File Offset: 0x00004A04
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00006812 File Offset: 0x00004A12
		public int ReceiveErrorCode
		{
			get
			{
				return this.m_ErrorCodes[0];
			}
			internal set
			{
				if (value != 0)
				{
					Debug.LogError(FixedString.Format("Error on receive, errorCode = {0}", value));
				}
				this.m_ErrorCodes[0] = value;
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00006840 File Offset: 0x00004A40
		internal bool IsAddressUsed(NetworkInterfaceEndPoint address)
		{
			for (int i = 0; i < this.m_ConnectionList.Length; i++)
			{
				if (address == this.m_ConnectionList[i].Address)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00006880 File Offset: 0x00004A80
		internal void AppendPacket(IntPtr dataStream, ref NetworkInterfaceEndPoint endpoint, int dataLen)
		{
			ProcessPacketCommand processPacketCommand = default(ProcessPacketCommand);
			NetworkSendQueueHandle networkSendQueueHandle = NetworkSendQueueHandle.ToTempHandle(this.m_ParallelSendQueue.AsParallelWriter());
			this.m_NetworkProtocolInterface.ProcessReceive.Ptr.Invoke(dataStream, ref endpoint, dataLen, ref this.m_NetworkSendInterface, ref networkSendQueueHandle, this.m_NetworkProtocolInterface.UserData, ref processPacketCommand);
			switch (processPacketCommand.Type)
			{
			case ProcessPacketCommandType.Drop:
			case ProcessPacketCommandType.ConnectionReject:
				break;
			case ProcessPacketCommandType.AddressUpdate:
				for (int i = 0; i < this.m_ConnectionList.Length; i++)
				{
					if (processPacketCommand.Address == this.m_ConnectionList[i].Address && processPacketCommand.SessionId == this.m_ConnectionList[i].ReceiveToken)
					{
						this.m_ConnectionList.ElementAt(i).Address = processPacketCommand.As.AddressUpdate.NewAddress;
					}
				}
				return;
			case ProcessPacketCommandType.ConnectionAccept:
			{
				NetworkDriver.Connection connection = this.GetConnection(processPacketCommand.Address, processPacketCommand.SessionId);
				if (connection != NetworkDriver.Connection.Null)
				{
					connection.DidReceiveData = 1;
					connection.LastReceive = this.m_UpdateTime;
					this.SetConnection(connection);
					if (connection.State == NetworkConnection.State.Connecting)
					{
						connection.SendToken = processPacketCommand.As.ConnectionAccept.ConnectionToken;
						connection.State = NetworkConnection.State.Connected;
						connection.IsAccepted = 1;
						this.UpdateConnection(connection);
						this.AddConnectEvent(connection.Id);
						return;
					}
				}
				break;
			}
			case ProcessPacketCommandType.ConnectionRequest:
			{
				if (!this.Listening)
				{
					return;
				}
				NetworkDriver.Connection connection2 = this.GetNewConnection(processPacketCommand.Address, processPacketCommand.SessionId);
				if (connection2 == NetworkDriver.Connection.Null || connection2.State == NetworkConnection.State.Disconnected)
				{
					SessionIdToken receiveToken = default(SessionIdToken);
					this.GenerateRandomSessionIdToken(ref receiveToken);
					int length;
					NetworkDriver.Connection connection3;
					if (!this.m_FreeList.TryDequeue(out length))
					{
						length = this.m_ConnectionList.Length;
						connection3 = default(NetworkDriver.Connection);
						connection3.Id = length;
						connection3.Version = 1;
						this.m_ConnectionList.Add(connection3);
					}
					int version = this.m_ConnectionList[length].Version;
					connection3 = new NetworkDriver.Connection
					{
						Id = length,
						Version = version,
						ReceiveToken = receiveToken,
						SendToken = processPacketCommand.SessionId,
						State = NetworkConnection.State.Connected,
						Address = processPacketCommand.Address,
						ConnectAttempts = 1,
						LastReceive = this.m_UpdateTime,
						IsAccepted = 0
					};
					connection2 = connection3;
					this.m_PipelineProcessor.initializeConnection(new NetworkConnection
					{
						m_NetworkId = length,
						m_NetworkVersion = connection2.Version
					});
					this.m_NetworkAcceptQueue.Enqueue(length);
				}
				connection2.LastNonDataSend = this.m_UpdateTime;
				this.SetConnection(connection2);
				this.m_NetworkProtocolInterface.ProcessSendConnectionAccept.Ptr.Invoke(ref connection2, ref this.m_NetworkSendInterface, ref networkSendQueueHandle, this.m_NetworkProtocolInterface.UserData);
				return;
			}
			case ProcessPacketCommandType.Data:
			{
				NetworkDriver.Connection connection4 = this.GetConnection(processPacketCommand.Address, processPacketCommand.SessionId);
				if (connection4 == NetworkDriver.Connection.Null)
				{
					return;
				}
				connection4.DidReceiveData = 1;
				connection4.LastReceive = this.m_UpdateTime;
				this.UpdateConnection(connection4);
				if (connection4.State == NetworkConnection.State.Connected)
				{
					int num = this.PinMemoryTillUpdate(processPacketCommand.As.Data.Offset + processPacketCommand.As.Data.Length) + processPacketCommand.As.Data.Offset;
					if (processPacketCommand.As.Data.HasPipeline)
					{
						NetworkConnection connection5 = new NetworkConnection
						{
							m_NetworkId = connection4.Id,
							m_NetworkVersion = connection4.Version
						};
						this.m_PipelineProcessor.Receive(this, connection5, this.m_DataStream.GetSubArray(num, processPacketCommand.As.Data.Length));
						return;
					}
					this.m_EventQueue.PushEvent(new NetworkEvent
					{
						connectionId = connection4.Id,
						type = NetworkEvent.Type.Data,
						offset = num,
						size = processPacketCommand.As.Data.Length
					});
					return;
				}
				break;
			}
			case ProcessPacketCommandType.Disconnect:
			{
				NetworkDriver.Connection connection6 = this.GetConnection(processPacketCommand.Address, processPacketCommand.SessionId);
				if (connection6 != NetworkDriver.Connection.Null && this.RemoveConnection(connection6))
				{
					this.AddDisconnectEvent(connection6.Id, DisconnectReason.ClosedByRemote);
					return;
				}
				break;
			}
			case ProcessPacketCommandType.DataWithImplicitConnectionAccept:
			{
				NetworkDriver.Connection connection7 = this.GetConnection(processPacketCommand.Address, processPacketCommand.SessionId);
				if (connection7 == NetworkDriver.Connection.Null)
				{
					return;
				}
				connection7.DidReceiveData = 1;
				connection7.LastReceive = this.m_UpdateTime;
				this.UpdateConnection(connection7);
				if (connection7.State == NetworkConnection.State.Connecting)
				{
					connection7.SendToken = processPacketCommand.As.DataWithImplicitConnectionAccept.ConnectionToken;
					connection7.State = NetworkConnection.State.Connected;
					this.UpdateConnection(connection7);
					this.AddConnectEvent(connection7.Id);
				}
				if (connection7.State == NetworkConnection.State.Connected)
				{
					int num2 = this.PinMemoryTillUpdate(processPacketCommand.As.DataWithImplicitConnectionAccept.Offset + processPacketCommand.As.DataWithImplicitConnectionAccept.Length) + processPacketCommand.As.DataWithImplicitConnectionAccept.Offset;
					if (processPacketCommand.As.DataWithImplicitConnectionAccept.HasPipeline)
					{
						NetworkConnection connection8 = new NetworkConnection
						{
							m_NetworkId = connection7.Id,
							m_NetworkVersion = connection7.Version
						};
						this.m_PipelineProcessor.Receive(this, connection8, this.m_DataStream.GetSubArray(num2, processPacketCommand.As.DataWithImplicitConnectionAccept.Length));
						return;
					}
					this.m_EventQueue.PushEvent(new NetworkEvent
					{
						connectionId = connection7.Id,
						type = NetworkEvent.Type.Data,
						offset = num2,
						size = processPacketCommand.As.DataWithImplicitConnectionAccept.Length
					});
					return;
				}
				break;
			}
			case ProcessPacketCommandType.Ping:
			{
				NetworkDriver.Connection connection9 = this.GetConnection(processPacketCommand.Address, processPacketCommand.SessionId);
				if (connection9 == NetworkDriver.Connection.Null || connection9.State != NetworkConnection.State.Connected)
				{
					return;
				}
				connection9.DidReceiveData = 1;
				connection9.LastReceive = this.m_UpdateTime;
				connection9.LastNonDataSend = this.m_UpdateTime;
				this.UpdateConnection(connection9);
				this.m_NetworkProtocolInterface.ProcessSendPong.Ptr.Invoke(ref connection9, ref this.m_NetworkSendInterface, ref networkSendQueueHandle, this.m_NetworkProtocolInterface.UserData);
				return;
			}
			case ProcessPacketCommandType.Pong:
			{
				NetworkDriver.Connection connection10 = this.GetConnection(processPacketCommand.Address, processPacketCommand.SessionId);
				if (connection10 != NetworkDriver.Connection.Null)
				{
					connection10.DidReceiveData = 1;
					connection10.LastReceive = this.m_UpdateTime;
					this.UpdateConnection(connection10);
					return;
				}
				break;
			}
			case ProcessPacketCommandType.ProtocolStatusUpdate:
				this.m_ProtocolStatus.Value = processPacketCommand.As.ProtocolStatusUpdate.Status;
				break;
			default:
				return;
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00006F88 File Offset: 0x00005188
		internal unsafe void PushDataEvent(NetworkConnection con, int pipelineId, byte* dataPtr, int dataLength)
		{
			int offset;
			if (!this.IsPointerInsideDataStream(dataPtr, dataLength, out offset))
			{
				int num = dataLength;
				IntPtr value = this.AllocateMemory(ref num);
				if (value == IntPtr.Zero || num < dataLength)
				{
					return;
				}
				UnsafeUtility.MemCpy(value.ToPointer(), (void*)dataPtr, (long)dataLength);
				offset = this.PinMemoryTillUpdate(dataLength);
			}
			this.m_EventQueue.PushEvent(new NetworkEvent
			{
				pipelineId = (short)pipelineId,
				connectionId = con.m_NetworkId,
				type = NetworkEvent.Type.Data,
				offset = offset,
				size = dataLength
			});
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00007020 File Offset: 0x00005220
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal int PinMemoryTillUpdate(int length)
		{
			int num = this.m_DataStreamHead[0];
			this.m_DataStreamHead[0] = num + length;
			return num;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000704C File Offset: 0x0000524C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe bool IsPointerInsideDataStream(byte* dataPtr, int dataLength, out int sliceOffset)
		{
			sliceOffset = 0;
			byte* unsafePtr = (byte*)this.m_DataStream.GetUnsafePtr<byte>();
			bool flag = dataPtr >= unsafePtr && dataPtr + dataLength == unsafePtr + this.m_DataStreamHead[0];
			if (flag)
			{
				sliceOffset = (int)((long)(dataPtr - unsafePtr));
			}
			return flag;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00007094 File Offset: 0x00005294
		internal unsafe IntPtr AllocateMemory(ref int dataLen)
		{
			NativeList<byte> dataStream = this.m_DataStream;
			int num = this.m_DataStreamHead[0];
			if (this.m_NetworkParams.dataStream.size == 0)
			{
				dataStream.ResizeUninitializedTillPowerOf2(num + dataLen);
			}
			else if (num + dataLen > dataStream.Length)
			{
				dataLen = dataStream.Length - num;
				if (dataLen <= 0)
				{
					dataLen = 0;
					return IntPtr.Zero;
				}
			}
			return new IntPtr((void*)((byte*)dataStream.GetUnsafePtr<byte>() + num));
		}

		// Token: 0x0400007E RID: 126
		private static List<INetworkInterface> s_NetworkInterfaces = new List<INetworkInterface>();

		// Token: 0x0400007F RID: 127
		private static List<INetworkProtocol> s_NetworkProtocols = new List<INetworkProtocol>();

		// Token: 0x04000080 RID: 128
		private int m_NetworkInterfaceIndex;

		// Token: 0x04000081 RID: 129
		private NetworkSendInterface m_NetworkSendInterface;

		// Token: 0x04000082 RID: 130
		private int m_NetworkProtocolIndex;

		// Token: 0x04000083 RID: 131
		private NetworkProtocol m_NetworkProtocolInterface;

		// Token: 0x04000084 RID: 132
		private NativeQueue<QueuedSendMessage> m_ParallelSendQueue;

		// Token: 0x04000085 RID: 133
		private NetworkEventQueue m_EventQueue;

		// Token: 0x04000086 RID: 134
		private NativeArray<byte> m_DisconnectReasons;

		// Token: 0x04000087 RID: 135
		private NativeQueue<int> m_FreeList;

		// Token: 0x04000088 RID: 136
		private NativeQueue<int> m_NetworkAcceptQueue;

		// Token: 0x04000089 RID: 137
		private NativeList<NetworkDriver.Connection> m_ConnectionList;

		// Token: 0x0400008A RID: 138
		[NativeDisableContainerSafetyRestriction]
		private NativeArray<int> m_InternalState;

		// Token: 0x0400008B RID: 139
		private NativeReference<int> m_ProtocolStatus;

		// Token: 0x0400008C RID: 140
		private NativeQueue<int> m_PendingFree;

		// Token: 0x0400008D RID: 141
		private NativeArray<int> m_ErrorCodes;

		// Token: 0x0400008E RID: 142
		private NetworkDriver.Parameters m_NetworkParams;

		// Token: 0x0400008F RID: 143
		private NativeList<byte> m_DataStream;

		// Token: 0x04000090 RID: 144
		private NativeArray<int> m_DataStreamHead;

		// Token: 0x04000091 RID: 145
		private NetworkPipelineProcessor m_PipelineProcessor;

		// Token: 0x04000092 RID: 146
		private UdpCHeader.HeaderFlags m_DefaultHeaderFlags;

		// Token: 0x04000093 RID: 147
		private long m_UpdateTime;

		// Token: 0x04000094 RID: 148
		private long m_UpdateTimeAdjustment;

		// Token: 0x04000095 RID: 149
		private Unity.Mathematics.Random m_Rand;

		// Token: 0x04000096 RID: 150
		private const int InternalStateListening = 0;

		// Token: 0x04000097 RID: 151
		private const int InternalStateBound = 1;

		// Token: 0x02000030 RID: 48
		public struct Concurrent
		{
			// Token: 0x0600012D RID: 301 RVA: 0x0000711C File Offset: 0x0000531C
			public NetworkEvent.Type PopEventForConnection(NetworkConnection connectionId, out DataStreamReader reader)
			{
				NetworkPipeline networkPipeline;
				return this.PopEventForConnection(connectionId, out reader, out networkPipeline);
			}

			// Token: 0x0600012E RID: 302 RVA: 0x00007134 File Offset: 0x00005334
			public NetworkEvent.Type PopEventForConnection(NetworkConnection connectionId, out DataStreamReader reader, out NetworkPipeline pipeline)
			{
				pipeline = default(NetworkPipeline);
				reader = default(DataStreamReader);
				if (connectionId.m_NetworkId < 0 || connectionId.m_NetworkId >= this.m_ConnectionList.Length || this.m_ConnectionList[connectionId.m_NetworkId].Version != connectionId.m_NetworkVersion)
				{
					return NetworkEvent.Type.Empty;
				}
				int num;
				int num2;
				int id;
				NetworkEvent.Type type = this.m_EventQueue.PopEventForConnection(connectionId.m_NetworkId, out num, out num2, out id);
				pipeline = new NetworkPipeline
				{
					Id = id
				};
				if (type == NetworkEvent.Type.Disconnect && num < 0)
				{
					reader = new DataStreamReader(this.m_DisconnectReasons.GetSubArray(math.abs(num), 1));
					return type;
				}
				if (num2 > 0)
				{
					reader = new DataStreamReader(this.m_DataStream.GetSubArray(num, num2));
				}
				return type;
			}

			// Token: 0x0600012F RID: 303 RVA: 0x00007204 File Offset: 0x00005404
			public int MaxHeaderSize(NetworkPipeline pipe)
			{
				int num = this.m_NetworkProtocolInterface.PaddingSize;
				if (pipe.Id > 0)
				{
					num += this.m_PipelineProcessor.SendHeaderCapacity(pipe) + 1;
				}
				return num;
			}

			// Token: 0x06000130 RID: 304 RVA: 0x00007238 File Offset: 0x00005438
			internal int MaxProtocolHeaderSize()
			{
				return this.m_NetworkProtocolInterface.PaddingSize;
			}

			// Token: 0x06000131 RID: 305 RVA: 0x00007245 File Offset: 0x00005445
			public int BeginSend(NetworkConnection id, out DataStreamWriter writer, int requiredPayloadSize = 0)
			{
				return this.BeginSend(NetworkPipeline.Null, id, out writer, requiredPayloadSize);
			}

			// Token: 0x06000132 RID: 306 RVA: 0x00007258 File Offset: 0x00005458
			public unsafe int BeginSend(NetworkPipeline pipe, NetworkConnection id, out DataStreamWriter writer, int requiredPayloadSize = 0)
			{
				writer = default(DataStreamWriter);
				if (id.m_NetworkId < 0 || id.m_NetworkId >= this.m_ConnectionList.Length)
				{
					return -1;
				}
				NetworkDriver.Connection connection = this.m_ConnectionList[id.m_NetworkId];
				if (connection.Version != id.m_NetworkVersion)
				{
					return -2;
				}
				if (connection.State != NetworkConnection.State.Connected)
				{
					return -3;
				}
				int num = (pipe.Id > 0) ? (this.m_PipelineProcessor.SendHeaderCapacity(pipe) + 1) : 0;
				int num2 = this.m_PipelineProcessor.PayloadCapacity(pipe);
				int num4;
				int num3 = this.m_NetworkProtocolInterface.ComputePacketOverhead.Ptr.Invoke(ref connection, out num4);
				int num5 = (num2 == 0) ? (this.m_MaxMessageSize - num3 - num) : num2;
				int num6 = (num2 == 0) ? this.m_MaxMessageSize : (num2 + num3 + num);
				if (num5 < requiredPayloadSize)
				{
					return -4;
				}
				if (requiredPayloadSize > 0 && num5 > requiredPayloadSize)
				{
					int num7 = num5 - requiredPayloadSize;
					num5 -= num7;
					num6 -= num7;
				}
				NetworkInterfaceSendHandle networkInterfaceSendHandle = default(NetworkInterfaceSendHandle);
				if (num6 > this.m_MaxMessageSize)
				{
					networkInterfaceSendHandle.data = (IntPtr)UnsafeUtility.Malloc((long)num6, 8, Allocator.Temp);
					networkInterfaceSendHandle.capacity = num6;
					networkInterfaceSendHandle.id = 0;
					networkInterfaceSendHandle.size = 0;
					networkInterfaceSendHandle.flags = SendHandleFlags.AllocatedByDriver;
				}
				else
				{
					int num8 = this.m_NetworkSendInterface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle, this.m_NetworkSendInterface.UserData, num6);
					if (num8 != 0)
					{
						return num8;
					}
				}
				if (networkInterfaceSendHandle.capacity < num6)
				{
					return -4;
				}
				NativeArray<byte> data = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>((void*)((byte*)((byte*)((void*)networkInterfaceSendHandle.data) + num4) + num), num5, Allocator.Invalid);
				writer = new DataStreamWriter(data);
				writer.m_SendHandleData = (IntPtr)UnsafeUtility.Malloc((long)UnsafeUtility.SizeOf<NetworkDriver.Concurrent.PendingSend>(), UnsafeUtility.AlignOf<NetworkDriver.Concurrent.PendingSend>(), Allocator.Temp);
				*(NetworkDriver.Concurrent.PendingSend*)((void*)writer.m_SendHandleData) = new NetworkDriver.Concurrent.PendingSend
				{
					Pipeline = pipe,
					Connection = id,
					SendHandle = networkInterfaceSendHandle,
					headerSize = num4
				};
				return 0;
			}

			// Token: 0x06000133 RID: 307 RVA: 0x0000745C File Offset: 0x0000565C
			public unsafe int EndSend(DataStreamWriter writer)
			{
				NetworkDriver.Concurrent.PendingSend* ptr = (NetworkDriver.Concurrent.PendingSend*)((void*)writer.m_SendHandleData);
				if (ptr == null || ptr->Connection == default(NetworkConnection))
				{
					return -8;
				}
				if (this.m_ConnectionList[ptr->Connection.m_NetworkId].Version != ptr->Connection.m_NetworkVersion)
				{
					return -2;
				}
				if (writer.HasFailedWrites)
				{
					this.AbortSend(writer);
					return -4;
				}
				NetworkDriver.Concurrent.PendingSend pendingSend = *(NetworkDriver.Concurrent.PendingSend*)((void*)writer.m_SendHandleData);
				ptr->Connection = default(NetworkConnection);
				pendingSend.SendHandle.size = pendingSend.headerSize + writer.Length;
				int num;
				if (pendingSend.Pipeline.Id > 0)
				{
					pendingSend.SendHandle.size = pendingSend.SendHandle.size + (this.m_PipelineProcessor.SendHeaderCapacity(pendingSend.Pipeline) + 1);
					UdpCHeader.HeaderFlags defaultHeaderFlags = this.m_DefaultHeaderFlags;
					this.m_DefaultHeaderFlags = UdpCHeader.HeaderFlags.HasPipeline;
					num = this.m_PipelineProcessor.Send(this, pendingSend.Pipeline, pendingSend.Connection, pendingSend.SendHandle, pendingSend.headerSize);
					this.m_DefaultHeaderFlags = defaultHeaderFlags;
				}
				else
				{
					num = this.CompleteSend(pendingSend.Connection, pendingSend.SendHandle, (this.m_DefaultHeaderFlags & UdpCHeader.HeaderFlags.HasPipeline) > (UdpCHeader.HeaderFlags)0);
				}
				if (num <= 0)
				{
					return num;
				}
				return writer.Length;
			}

			// Token: 0x06000134 RID: 308 RVA: 0x000075AC File Offset: 0x000057AC
			public unsafe void AbortSend(DataStreamWriter writer)
			{
				NetworkDriver.Concurrent.PendingSend* ptr = (NetworkDriver.Concurrent.PendingSend*)((void*)writer.m_SendHandleData);
				if (ptr == null || ptr->Connection == default(NetworkConnection))
				{
					Debug.LogError("AbortSend without matching BeginSend");
					return;
				}
				NetworkDriver.Concurrent.PendingSend pendingSend = *(NetworkDriver.Concurrent.PendingSend*)((void*)writer.m_SendHandleData);
				ptr->Connection = default(NetworkConnection);
				this.AbortSend(pendingSend.SendHandle);
			}

			// Token: 0x06000135 RID: 309 RVA: 0x00007614 File Offset: 0x00005814
			internal unsafe int CompleteSend(NetworkConnection sendConnection, NetworkInterfaceSendHandle sendHandle, bool hasPipeline)
			{
				if ((sendHandle.flags & SendHandleFlags.AllocatedByDriver) != (SendHandleFlags)0)
				{
					NetworkInterfaceSendHandle networkInterfaceSendHandle = sendHandle;
					int result;
					if ((result = this.m_NetworkSendInterface.BeginSendMessage.Ptr.Invoke(out sendHandle, this.m_NetworkSendInterface.UserData, 1472)) != 0)
					{
						return result;
					}
					UnsafeUtility.MemCpy((void*)sendHandle.data, (void*)networkInterfaceSendHandle.data, (long)networkInterfaceSendHandle.size);
					sendHandle.size = networkInterfaceSendHandle.size;
				}
				NetworkDriver.Connection connection = this.m_ConnectionList[sendConnection.m_NetworkId];
				NetworkSendQueueHandle networkSendQueueHandle = NetworkSendQueueHandle.ToTempHandle(this.m_ConcurrentParallelSendQueue);
				return this.m_NetworkProtocolInterface.ProcessSend.Ptr.Invoke(ref connection, hasPipeline, ref this.m_NetworkSendInterface, ref sendHandle, ref networkSendQueueHandle, this.m_NetworkProtocolInterface.UserData);
			}

			// Token: 0x06000136 RID: 310 RVA: 0x000076E0 File Offset: 0x000058E0
			internal void AbortSend(NetworkInterfaceSendHandle sendHandle)
			{
				if ((sendHandle.flags & SendHandleFlags.AllocatedByDriver) == (SendHandleFlags)0)
				{
					this.m_NetworkSendInterface.AbortSendMessage.Ptr.Invoke(ref sendHandle, this.m_NetworkSendInterface.UserData);
				}
			}

			// Token: 0x06000137 RID: 311 RVA: 0x00007714 File Offset: 0x00005914
			public NetworkConnection.State GetConnectionState(NetworkConnection id)
			{
				if (id.m_NetworkId < 0 || id.m_NetworkId >= this.m_ConnectionList.Length)
				{
					return NetworkConnection.State.Disconnected;
				}
				NetworkDriver.Connection connection = this.m_ConnectionList[id.m_NetworkId];
				if (connection.Version != id.m_NetworkVersion)
				{
					return NetworkConnection.State.Disconnected;
				}
				return connection.State;
			}

			// Token: 0x04000098 RID: 152
			internal NetworkSendInterface m_NetworkSendInterface;

			// Token: 0x04000099 RID: 153
			internal NetworkProtocol m_NetworkProtocolInterface;

			// Token: 0x0400009A RID: 154
			internal NetworkEventQueue.Concurrent m_EventQueue;

			// Token: 0x0400009B RID: 155
			internal NativeArray<byte> m_DisconnectReasons;

			// Token: 0x0400009C RID: 156
			[ReadOnly]
			internal NativeList<NetworkDriver.Connection> m_ConnectionList;

			// Token: 0x0400009D RID: 157
			[ReadOnly]
			internal NativeList<byte> m_DataStream;

			// Token: 0x0400009E RID: 158
			internal NetworkPipelineProcessor.Concurrent m_PipelineProcessor;

			// Token: 0x0400009F RID: 159
			internal UdpCHeader.HeaderFlags m_DefaultHeaderFlags;

			// Token: 0x040000A0 RID: 160
			internal NativeQueue<QueuedSendMessage>.ParallelWriter m_ConcurrentParallelSendQueue;

			// Token: 0x040000A1 RID: 161
			internal int m_MaxMessageSize;

			// Token: 0x02000031 RID: 49
			private struct PendingSend
			{
				// Token: 0x040000A2 RID: 162
				public NetworkPipeline Pipeline;

				// Token: 0x040000A3 RID: 163
				public NetworkConnection Connection;

				// Token: 0x040000A4 RID: 164
				public NetworkInterfaceSendHandle SendHandle;

				// Token: 0x040000A5 RID: 165
				public int headerSize;
			}
		}

		// Token: 0x02000032 RID: 50
		internal struct Connection
		{
			// Token: 0x06000138 RID: 312 RVA: 0x00007767 File Offset: 0x00005967
			public static bool operator ==(NetworkDriver.Connection lhs, NetworkDriver.Connection rhs)
			{
				return lhs.Id == rhs.Id && lhs.Version == rhs.Version && lhs.Address == rhs.Address;
			}

			// Token: 0x06000139 RID: 313 RVA: 0x00007798 File Offset: 0x00005998
			public static bool operator !=(NetworkDriver.Connection lhs, NetworkDriver.Connection rhs)
			{
				return lhs.Id != rhs.Id || lhs.Version != rhs.Version || lhs.Address != rhs.Address;
			}

			// Token: 0x0600013A RID: 314 RVA: 0x000077C9 File Offset: 0x000059C9
			public override bool Equals(object compare)
			{
				return this == (NetworkDriver.Connection)compare;
			}

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x0600013B RID: 315 RVA: 0x000077DC File Offset: 0x000059DC
			public static NetworkDriver.Connection Null
			{
				get
				{
					return new NetworkDriver.Connection
					{
						Id = 0,
						Version = 0
					};
				}
			}

			// Token: 0x0600013C RID: 316 RVA: 0x00007802 File Offset: 0x00005A02
			public override int GetHashCode()
			{
				return this.Id;
			}

			// Token: 0x0600013D RID: 317 RVA: 0x0000780A File Offset: 0x00005A0A
			public bool Equals(NetworkDriver.Connection connection)
			{
				return connection.Id == this.Id && connection.Version == this.Version && connection.Address == this.Address;
			}

			// Token: 0x040000A6 RID: 166
			public NetworkInterfaceEndPoint Address;

			// Token: 0x040000A7 RID: 167
			public long LastNonDataSend;

			// Token: 0x040000A8 RID: 168
			public long LastReceive;

			// Token: 0x040000A9 RID: 169
			public int Id;

			// Token: 0x040000AA RID: 170
			public int Version;

			// Token: 0x040000AB RID: 171
			public int ConnectAttempts;

			// Token: 0x040000AC RID: 172
			public NetworkConnection.State State;

			// Token: 0x040000AD RID: 173
			public SessionIdToken ReceiveToken;

			// Token: 0x040000AE RID: 174
			public SessionIdToken SendToken;

			// Token: 0x040000AF RID: 175
			public byte DidReceiveData;

			// Token: 0x040000B0 RID: 176
			public byte IsAccepted;
		}

		// Token: 0x02000033 RID: 51
		private enum ErrorCodeType
		{
			// Token: 0x040000B2 RID: 178
			ReceiveError,
			// Token: 0x040000B3 RID: 179
			SendError,
			// Token: 0x040000B4 RID: 180
			NumErrorCodes
		}

		// Token: 0x02000034 RID: 52
		private struct Parameters
		{
			// Token: 0x0600013E RID: 318 RVA: 0x0000783B File Offset: 0x00005A3B
			public Parameters(NetworkSettings settings)
			{
				this.dataStream = ref settings.GetDataStreamParameters();
				this.config = ref settings.GetNetworkConfigParameters();
			}

			// Token: 0x040000B5 RID: 181
			public NetworkDataStreamParameter dataStream;

			// Token: 0x040000B6 RID: 182
			public NetworkConfigParameter config;
		}

		// Token: 0x02000035 RID: 53
		[BurstCompile]
		private struct UpdateJob : IJob
		{
			// Token: 0x0600013F RID: 319 RVA: 0x00007857 File Offset: 0x00005A57
			public void Execute()
			{
				this.driver.InternalUpdate();
			}

			// Token: 0x040000B7 RID: 183
			public NetworkDriver driver;
		}

		// Token: 0x02000036 RID: 54
		[BurstCompile]
		private struct ClearEventQueue : IJob
		{
			// Token: 0x06000140 RID: 320 RVA: 0x00007864 File Offset: 0x00005A64
			public void Execute()
			{
				this.eventQueue.Clear();
				this.dataStreamHead[0] = 0;
			}

			// Token: 0x040000B8 RID: 184
			public NativeList<byte> dataStream;

			// Token: 0x040000B9 RID: 185
			public NativeArray<int> dataStreamHead;

			// Token: 0x040000BA RID: 186
			public NetworkEventQueue eventQueue;
		}
	}
}
