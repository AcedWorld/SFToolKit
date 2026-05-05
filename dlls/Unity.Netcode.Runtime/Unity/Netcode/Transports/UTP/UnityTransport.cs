using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Networking.Transport;
using Unity.Networking.Transport.Relay;
using Unity.Networking.Transport.Utilities;
using UnityEngine;

namespace Unity.Netcode.Transports.UTP
{
	// Token: 0x0200012D RID: 301
	[AddComponentMenu("Netcode/Unity Transport")]
	public class UnityTransport : NetworkTransport, INetworkStreamDriverConstructor
	{
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000969 RID: 2409 RVA: 0x00023967 File Offset: 0x00021B67
		public INetworkStreamDriverConstructor DriverConstructor
		{
			get
			{
				return UnityTransport.s_DriverConstructor ?? this;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x00023973 File Offset: 0x00021B73
		// (set) Token: 0x0600096B RID: 2411 RVA: 0x0002397B File Offset: 0x00021B7B
		public int MaxPacketQueueSize
		{
			get
			{
				return this.m_MaxPacketQueueSize;
			}
			set
			{
				this.m_MaxPacketQueueSize = value;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x00023984 File Offset: 0x00021B84
		// (set) Token: 0x0600096D RID: 2413 RVA: 0x0002398C File Offset: 0x00021B8C
		public int MaxPayloadSize
		{
			get
			{
				return this.m_MaxPayloadSize;
			}
			set
			{
				this.m_MaxPayloadSize = value;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x00023995 File Offset: 0x00021B95
		// (set) Token: 0x0600096F RID: 2415 RVA: 0x0002399D File Offset: 0x00021B9D
		public int MaxSendQueueSize
		{
			get
			{
				return this.m_MaxSendQueueSize;
			}
			set
			{
				this.m_MaxSendQueueSize = value;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000970 RID: 2416 RVA: 0x000239A6 File Offset: 0x00021BA6
		// (set) Token: 0x06000971 RID: 2417 RVA: 0x000239AE File Offset: 0x00021BAE
		public int HeartbeatTimeoutMS
		{
			get
			{
				return this.m_HeartbeatTimeoutMS;
			}
			set
			{
				this.m_HeartbeatTimeoutMS = value;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000972 RID: 2418 RVA: 0x000239B7 File Offset: 0x00021BB7
		// (set) Token: 0x06000973 RID: 2419 RVA: 0x000239BF File Offset: 0x00021BBF
		public int ConnectTimeoutMS
		{
			get
			{
				return this.m_ConnectTimeoutMS;
			}
			set
			{
				this.m_ConnectTimeoutMS = value;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x000239C8 File Offset: 0x00021BC8
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x000239D0 File Offset: 0x00021BD0
		public int MaxConnectAttempts
		{
			get
			{
				return this.m_MaxConnectAttempts;
			}
			set
			{
				this.m_MaxConnectAttempts = value;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x000239D9 File Offset: 0x00021BD9
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x000239E1 File Offset: 0x00021BE1
		public int DisconnectTimeoutMS
		{
			get
			{
				return this.m_DisconnectTimeoutMS;
			}
			set
			{
				this.m_DisconnectTimeoutMS = value;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x000239EA File Offset: 0x00021BEA
		// (set) Token: 0x06000979 RID: 2425 RVA: 0x000239F2 File Offset: 0x00021BF2
		internal uint? DebugSimulatorRandomSeed { get; set; }

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x0600097A RID: 2426 RVA: 0x000239FC File Offset: 0x00021BFC
		// (remove) Token: 0x0600097B RID: 2427 RVA: 0x00023A30 File Offset: 0x00021C30
		internal static event Action<int, NetworkDriver> TransportInitialized;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x0600097C RID: 2428 RVA: 0x00023A64 File Offset: 0x00021C64
		// (remove) Token: 0x0600097D RID: 2429 RVA: 0x00023A98 File Offset: 0x00021C98
		internal static event Action<int> TransportDisposed;

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x00023ACB File Offset: 0x00021CCB
		internal NetworkDriver NetworkDriver
		{
			get
			{
				return this.m_Driver;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600097F RID: 2431 RVA: 0x00023AD3 File Offset: 0x00021CD3
		public override ulong ServerClientId
		{
			get
			{
				return this.m_ServerClientId;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x00023ADB File Offset: 0x00021CDB
		public UnityTransport.ProtocolType Protocol
		{
			get
			{
				return this.m_ProtocolType;
			}
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00023AE4 File Offset: 0x00021CE4
		private void InitDriver()
		{
			this.DriverConstructor.CreateDriver(this, out this.m_Driver, out this.m_UnreliableFragmentedPipeline, out this.m_UnreliableSequencedFragmentedPipeline, out this.m_ReliableSequencedPipeline);
			Action<int, NetworkDriver> transportInitialized = UnityTransport.TransportInitialized;
			if (transportInitialized == null)
			{
				return;
			}
			transportInitialized(base.GetInstanceID(), this.NetworkDriver);
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x00023B30 File Offset: 0x00021D30
		private void DisposeInternals()
		{
			if (this.m_Driver.IsCreated)
			{
				this.m_Driver.Dispose();
			}
			this.m_NetworkSettings.Dispose();
			foreach (BatchedSendQueue batchedSendQueue in this.m_SendQueue.Values)
			{
				batchedSendQueue.Dispose();
			}
			this.m_SendQueue.Clear();
			Action<int> transportDisposed = UnityTransport.TransportDisposed;
			if (transportDisposed == null)
			{
				return;
			}
			transportDisposed(base.GetInstanceID());
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x00023BCC File Offset: 0x00021DCC
		private NetworkPipeline SelectSendPipeline(NetworkDelivery delivery)
		{
			switch (delivery)
			{
			case NetworkDelivery.Unreliable:
				return this.m_UnreliableFragmentedPipeline;
			case NetworkDelivery.UnreliableSequenced:
				return this.m_UnreliableSequencedFragmentedPipeline;
			case NetworkDelivery.Reliable:
			case NetworkDelivery.ReliableSequenced:
			case NetworkDelivery.ReliableFragmentedSequenced:
				return this.m_ReliableSequencedPipeline;
			default:
				Debug.LogError(string.Format("Unknown {0} value: {1}", "NetworkDelivery", delivery));
				return NetworkPipeline.Null;
			}
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x00023C2C File Offset: 0x00021E2C
		private bool ClientBindAndConnect()
		{
			NetworkEndPoint endpoint = default(NetworkEndPoint);
			if (this.m_ProtocolType == UnityTransport.ProtocolType.RelayUnityTransport)
			{
				if (this.m_RelayServerData.Equals(default(RelayServerData)))
				{
					Debug.LogError("You must call SetRelayServerData() at least once before calling StartClient.");
					return false;
				}
				ref this.m_NetworkSettings.WithRelayParameters(ref this.m_RelayServerData, this.m_HeartbeatTimeoutMS);
				endpoint = this.m_RelayServerData.Endpoint;
			}
			else
			{
				endpoint = this.ConnectionData.ServerEndPoint;
			}
			if (endpoint.Family == NetworkFamily.Invalid)
			{
				Debug.LogError("Target server network address (" + this.ConnectionData.Address + ") is Invalid!");
				return false;
			}
			this.InitDriver();
			NetworkEndPoint endpoint2 = (endpoint.Family == NetworkFamily.Ipv6) ? NetworkEndPoint.AnyIpv6 : NetworkEndPoint.AnyIpv4;
			if (this.m_Driver.Bind(endpoint2) != 0)
			{
				Debug.LogError("Client failed to bind");
				return false;
			}
			NetworkConnection utpConnectionId = this.m_Driver.Connect(endpoint);
			this.m_ServerClientId = UnityTransport.ParseClientId(utpConnectionId);
			return true;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x00023D28 File Offset: 0x00021F28
		private bool ServerBindAndListen(NetworkEndPoint endPoint)
		{
			if (endPoint.Family == NetworkFamily.Invalid)
			{
				Debug.LogError("Network listen address (" + this.ConnectionData.Address + ") is Invalid!");
				return false;
			}
			this.InitDriver();
			if (this.m_Driver.Bind(endPoint) != 0)
			{
				Debug.LogError("Server failed to bind. This is usually caused by another process being bound to the same port.");
				return false;
			}
			if (this.m_Driver.Listen() != 0)
			{
				Debug.LogError("Server failed to listen.");
				return false;
			}
			this.m_State = UnityTransport.State.Listening;
			return true;
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x00023DA0 File Offset: 0x00021FA0
		private void SetProtocol(UnityTransport.ProtocolType inProtocol)
		{
			this.m_ProtocolType = inProtocol;
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x00023DAC File Offset: 0x00021FAC
		public void SetRelayServerData(string ipv4Address, ushort port, byte[] allocationIdBytes, byte[] keyBytes, byte[] connectionDataBytes, byte[] hostConnectionDataBytes = null, bool isSecure = false)
		{
			byte[] hostConnectionData = hostConnectionDataBytes ?? connectionDataBytes;
			this.m_RelayServerData = new RelayServerData(ipv4Address, port, allocationIdBytes, connectionDataBytes, hostConnectionData, keyBytes, isSecure);
			this.SetProtocol(UnityTransport.ProtocolType.RelayUnityTransport);
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x00023DDE File Offset: 0x00021FDE
		public void SetRelayServerData(RelayServerData serverData)
		{
			this.m_RelayServerData = serverData;
			this.SetProtocol(UnityTransport.ProtocolType.RelayUnityTransport);
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x00023DEE File Offset: 0x00021FEE
		public void SetHostRelayData(string ipAddress, ushort port, byte[] allocationId, byte[] key, byte[] connectionData, bool isSecure = false)
		{
			this.SetRelayServerData(ipAddress, port, allocationId, key, connectionData, null, isSecure);
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00023E00 File Offset: 0x00022000
		public void SetClientRelayData(string ipAddress, ushort port, byte[] allocationId, byte[] key, byte[] connectionData, byte[] hostConnectionData, bool isSecure = false)
		{
			this.SetRelayServerData(ipAddress, port, allocationId, key, connectionData, hostConnectionData, isSecure);
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x00023E14 File Offset: 0x00022014
		public void SetConnectionData(string ipv4Address, ushort port, string listenAddress = null)
		{
			this.ConnectionData = new UnityTransport.ConnectionAddressData
			{
				Address = ipv4Address,
				Port = port,
				ServerListenAddress = (listenAddress ?? ipv4Address)
			};
			this.SetProtocol(UnityTransport.ProtocolType.UnityTransport);
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00023E54 File Offset: 0x00022054
		public void SetConnectionData(NetworkEndPoint endPoint, NetworkEndPoint listenEndPoint = default(NetworkEndPoint))
		{
			string ipv4Address = endPoint.Address.Split(':', StringSplitOptions.None)[0];
			string listenAddress = string.Empty;
			if (listenEndPoint != default(NetworkEndPoint))
			{
				listenAddress = listenEndPoint.Address.Split(':', StringSplitOptions.None)[0];
				if (endPoint.Port != listenEndPoint.Port)
				{
					Debug.LogError(string.Format("Port mismatch between server and listen endpoints ({0} vs {1}).", endPoint.Port, listenEndPoint.Port));
				}
			}
			this.SetConnectionData(ipv4Address, endPoint.Port, listenAddress);
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00023EE4 File Offset: 0x000220E4
		public void SetDebugSimulatorParameters(int packetDelay, int packetJitter, int dropRate)
		{
			if (this.m_Driver.IsCreated)
			{
				Debug.LogError("SetDebugSimulatorParameters() must be called before StartClient() or StartServer().");
				return;
			}
			this.DebugSimulator = new UnityTransport.SimulatorParameters
			{
				PacketDelayMS = packetDelay,
				PacketJitterMS = packetJitter,
				PacketDropRate = dropRate
			};
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00023F30 File Offset: 0x00022130
		private bool StartRelayServer()
		{
			if (this.m_RelayServerData.Equals(default(RelayServerData)))
			{
				Debug.LogError("You must call SetRelayServerData() at least once before calling StartServer.");
				return false;
			}
			ref this.m_NetworkSettings.WithRelayParameters(ref this.m_RelayServerData, this.m_HeartbeatTimeoutMS);
			return this.ServerBindAndListen(NetworkEndPoint.AnyIpv4);
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00023F90 File Offset: 0x00022190
		private void SendBatchedMessages(UnityTransport.SendTarget sendTarget, BatchedSendQueue queue)
		{
			if (!this.m_Driver.IsCreated)
			{
				return;
			}
			int mtu = 0;
			if (this.NetworkManager)
			{
				ulong clientId = this.NetworkManager.ConnectionManager.TransportIdToClientId(sendTarget.ClientId);
				mtu = this.NetworkManager.GetPeerMTU(clientId);
			}
			new UnityTransport.SendBatchedMessagesJob
			{
				Driver = this.m_Driver.ToConcurrent(),
				Target = sendTarget,
				Queue = queue,
				ReliablePipeline = this.m_ReliableSequencedPipeline,
				MTU = mtu
			}.Run<UnityTransport.SendBatchedMessagesJob>();
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00024024 File Offset: 0x00022224
		private bool AcceptConnection()
		{
			NetworkConnection networkConnection = this.m_Driver.Accept();
			if (networkConnection == default(NetworkConnection))
			{
				return false;
			}
			base.InvokeOnTransportEvent(NetworkEvent.Connect, UnityTransport.ParseClientId(networkConnection), default(ArraySegment<byte>), this.m_RealTimeProvider.RealTimeSinceStartup);
			return true;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00024074 File Offset: 0x00022274
		private void ReceiveMessages(ulong clientId, NetworkPipeline pipeline, DataStreamReader dataReader)
		{
			BatchedReceiveQueue batchedReceiveQueue;
			if (pipeline == this.m_ReliableSequencedPipeline)
			{
				if (this.m_ReliableReceiveQueues.TryGetValue(clientId, out batchedReceiveQueue))
				{
					batchedReceiveQueue.PushReader(dataReader);
				}
				else
				{
					batchedReceiveQueue = new BatchedReceiveQueue(dataReader);
					this.m_ReliableReceiveQueues[clientId] = batchedReceiveQueue;
				}
			}
			else
			{
				batchedReceiveQueue = new BatchedReceiveQueue(dataReader);
			}
			while (!batchedReceiveQueue.IsEmpty)
			{
				ArraySegment<byte> arraySegment = batchedReceiveQueue.PopMessage();
				if (arraySegment == default(ArraySegment<byte>))
				{
					break;
				}
				base.InvokeOnTransportEvent(NetworkEvent.Data, clientId, arraySegment, this.m_RealTimeProvider.RealTimeSinceStartup);
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x000240FC File Offset: 0x000222FC
		private bool ProcessEvent()
		{
			NetworkConnection utpConnectionId;
			DataStreamReader dataReader;
			NetworkPipeline pipeline;
			NetworkEvent.Type type = this.m_Driver.PopEvent(out utpConnectionId, out dataReader, out pipeline);
			ulong num = UnityTransport.ParseClientId(utpConnectionId);
			switch (type)
			{
			case NetworkEvent.Type.Data:
				this.ReceiveMessages(num, pipeline, dataReader);
				return true;
			case NetworkEvent.Type.Connect:
				base.InvokeOnTransportEvent(NetworkEvent.Connect, num, default(ArraySegment<byte>), this.m_RealTimeProvider.RealTimeSinceStartup);
				this.m_State = UnityTransport.State.Connected;
				return true;
			case NetworkEvent.Type.Disconnect:
				if (this.m_State == UnityTransport.State.Connected)
				{
					this.m_State = UnityTransport.State.Disconnected;
					this.m_ServerClientId = 0UL;
				}
				else if (this.m_State == UnityTransport.State.Disconnected)
				{
					Debug.LogError("Failed to connect to server.");
					this.m_ServerClientId = 0UL;
				}
				this.m_ReliableReceiveQueues.Remove(num);
				this.ClearSendQueuesForClientId(num);
				base.InvokeOnTransportEvent(NetworkEvent.Disconnect, num, default(ArraySegment<byte>), this.m_RealTimeProvider.RealTimeSinceStartup);
				return true;
			default:
				return false;
			}
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x000241DC File Offset: 0x000223DC
		private void Update()
		{
			if (this.m_Driver.IsCreated)
			{
				foreach (KeyValuePair<UnityTransport.SendTarget, BatchedSendQueue> keyValuePair in this.m_SendQueue)
				{
					this.SendBatchedMessages(keyValuePair.Key, keyValuePair.Value);
				}
				this.m_Driver.ScheduleUpdate(default(JobHandle)).Complete();
				if (this.m_ProtocolType == UnityTransport.ProtocolType.RelayUnityTransport && this.m_Driver.GetRelayConnectionStatus() == RelayConnectionStatus.AllocationInvalid)
				{
					Debug.LogError("Transport failure! Relay allocation needs to be recreated, and NetworkManager restarted. Use NetworkManager.OnTransportFailure to be notified of such events programmatically.");
					base.InvokeOnTransportEvent(NetworkEvent.TransportFailure, 0UL, default(ArraySegment<byte>), this.m_RealTimeProvider.RealTimeSinceStartup);
					return;
				}
				while (this.AcceptConnection() && this.m_Driver.IsCreated)
				{
				}
				while (this.ProcessEvent() && this.m_Driver.IsCreated)
				{
				}
				if (this.NetworkManager)
				{
					this.ExtractNetworkMetrics();
				}
			}
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x000242E4 File Offset: 0x000224E4
		private void OnDestroy()
		{
			this.DisposeInternals();
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x000242EC File Offset: 0x000224EC
		private void ExtractNetworkMetrics()
		{
			if (this.NetworkManager.IsServer)
			{
				using (IEnumerator<ulong> enumerator = this.NetworkManager.ConnectedClients.Keys.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ulong num = enumerator.Current;
						if (num != 0UL || !this.NetworkManager.IsHost)
						{
							ulong transportClientId = this.NetworkManager.ConnectionManager.ClientIdToTransportId(num);
							this.ExtractNetworkMetricsForClient(transportClientId);
						}
					}
					return;
				}
			}
			if (this.m_ServerClientId != 0UL)
			{
				this.ExtractNetworkMetricsForClient(this.m_ServerClientId);
			}
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00024388 File Offset: 0x00022588
		private void ExtractNetworkMetricsForClient(ulong transportClientId)
		{
			NetworkConnection networkConnection = UnityTransport.ParseClientId(transportClientId);
			this.ExtractNetworkMetricsFromPipeline(this.m_UnreliableFragmentedPipeline, networkConnection);
			this.ExtractNetworkMetricsFromPipeline(this.m_UnreliableSequencedFragmentedPipeline, networkConnection);
			this.ExtractNetworkMetricsFromPipeline(this.m_ReliableSequencedPipeline, networkConnection);
			int rtt = this.NetworkManager.IsServer ? 0 : this.ExtractRtt(networkConnection);
			this.NetworkMetrics.UpdateRttToServer(rtt);
			float packetLoss = this.NetworkManager.IsServer ? 0f : this.ExtractPacketLoss(networkConnection);
			this.NetworkMetrics.UpdatePacketLoss(packetLoss);
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00024410 File Offset: 0x00022610
		private unsafe void ExtractNetworkMetricsFromPipeline(NetworkPipeline pipeline, NetworkConnection networkConnection)
		{
			if (this.m_Driver.GetConnectionState(networkConnection) != NetworkConnection.State.Connected)
			{
				return;
			}
			NativeArray<byte> nativeArray;
			NativeArray<byte> nativeArray2;
			NativeArray<byte> nativeArray3;
			this.m_Driver.GetPipelineBuffers(pipeline, NetworkPipelineStageCollection.GetStageId(typeof(NetworkMetricsPipelineStage)), networkConnection, out nativeArray, out nativeArray2, out nativeArray3);
			NetworkMetricsContext* unsafePtr = (NetworkMetricsContext*)nativeArray3.GetUnsafePtr<byte>();
			this.NetworkMetrics.TrackPacketSent(unsafePtr->PacketSentCount);
			this.NetworkMetrics.TrackPacketReceived(unsafePtr->PacketReceivedCount);
			unsafePtr->PacketSentCount = 0U;
			unsafePtr->PacketReceivedCount = 0U;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00024488 File Offset: 0x00022688
		private unsafe int ExtractRtt(NetworkConnection networkConnection)
		{
			if (this.m_Driver.GetConnectionState(networkConnection) != NetworkConnection.State.Connected)
			{
				return 0;
			}
			NativeArray<byte> nativeArray;
			NativeArray<byte> nativeArray2;
			NativeArray<byte> nativeArray3;
			this.m_Driver.GetPipelineBuffers(this.m_ReliableSequencedPipeline, NetworkPipelineStageCollection.GetStageId(typeof(ReliableSequencedPipelineStage)), networkConnection, out nativeArray, out nativeArray2, out nativeArray3);
			ReliableUtility.SharedContext* unsafePtr = (ReliableUtility.SharedContext*)nativeArray3.GetUnsafePtr<byte>();
			return unsafePtr->RttInfo.LastRtt;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x000244E0 File Offset: 0x000226E0
		private unsafe float ExtractPacketLoss(NetworkConnection networkConnection)
		{
			if (this.m_Driver.GetConnectionState(networkConnection) != NetworkConnection.State.Connected)
			{
				return 0f;
			}
			NativeArray<byte> nativeArray;
			NativeArray<byte> nativeArray2;
			NativeArray<byte> nativeArray3;
			this.m_Driver.GetPipelineBuffers(this.m_ReliableSequencedPipeline, NetworkPipelineStageCollection.GetStageId(typeof(ReliableSequencedPipelineStage)), networkConnection, out nativeArray, out nativeArray2, out nativeArray3);
			ReliableUtility.SharedContext* unsafePtr = (ReliableUtility.SharedContext*)nativeArray3.GetUnsafePtr<byte>();
			float num = (float)(unsafePtr->stats.PacketsReceived - this.m_PacketLossCache.PacketsReceived);
			float num2 = (float)(unsafePtr->stats.PacketsDropped - this.m_PacketLossCache.PacketsDropped);
			if (num2 == 0f && num == 0f)
			{
				return this.m_PacketLossCache.PacketLoss;
			}
			this.m_PacketLossCache.PacketsReceived = unsafePtr->stats.PacketsReceived;
			this.m_PacketLossCache.PacketsDropped = unsafePtr->stats.PacketsDropped;
			this.m_PacketLossCache.PacketLoss = ((num > 0f) ? (num2 / num) : 0f);
			return this.m_PacketLossCache.PacketLoss;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x000245D9 File Offset: 0x000227D9
		private unsafe static ulong ParseClientId(NetworkConnection utpConnectionId)
		{
			return (ulong)(*(long*)(&utpConnectionId));
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x000245DF File Offset: 0x000227DF
		private unsafe static NetworkConnection ParseClientId(ulong netcodeConnectionId)
		{
			return *(NetworkConnection*)(&netcodeConnectionId);
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x000245EC File Offset: 0x000227EC
		private void ClearSendQueuesForClientId(ulong clientId)
		{
			using (NativeList<UnityTransport.SendTarget> nativeList = new NativeList<UnityTransport.SendTarget>(16, Allocator.Temp))
			{
				foreach (UnityTransport.SendTarget sendTarget in this.m_SendQueue.Keys)
				{
					if (sendTarget.ClientId == clientId)
					{
						nativeList.Add(sendTarget);
					}
				}
				foreach (UnityTransport.SendTarget key in nativeList)
				{
					this.m_SendQueue[key].Dispose();
					this.m_SendQueue.Remove(key);
				}
			}
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x000246D4 File Offset: 0x000228D4
		private void FlushSendQueuesForClientId(ulong clientId)
		{
			foreach (KeyValuePair<UnityTransport.SendTarget, BatchedSendQueue> keyValuePair in this.m_SendQueue)
			{
				if (keyValuePair.Key.ClientId == clientId)
				{
					this.SendBatchedMessages(keyValuePair.Key, keyValuePair.Value);
				}
			}
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x00024744 File Offset: 0x00022944
		public override void DisconnectLocalClient()
		{
			if (this.m_State == UnityTransport.State.Connected)
			{
				this.FlushSendQueuesForClientId(this.m_ServerClientId);
				if (this.m_Driver.Disconnect(UnityTransport.ParseClientId(this.m_ServerClientId)) == 0)
				{
					this.m_State = UnityTransport.State.Disconnected;
					this.m_ReliableReceiveQueues.Remove(this.m_ServerClientId);
					this.ClearSendQueuesForClientId(this.m_ServerClientId);
					base.InvokeOnTransportEvent(NetworkEvent.Disconnect, this.m_ServerClientId, default(ArraySegment<byte>), this.m_RealTimeProvider.RealTimeSinceStartup);
				}
			}
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x000247C4 File Offset: 0x000229C4
		public override void DisconnectRemoteClient(ulong clientId)
		{
			if (this.m_State == UnityTransport.State.Listening)
			{
				this.FlushSendQueuesForClientId(clientId);
				this.m_ReliableReceiveQueues.Remove(clientId);
				this.ClearSendQueuesForClientId(clientId);
				NetworkConnection networkConnection = UnityTransport.ParseClientId(clientId);
				if (this.m_Driver.GetConnectionState(networkConnection) != NetworkConnection.State.Disconnected)
				{
					this.m_Driver.Disconnect(networkConnection);
				}
			}
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x00024818 File Offset: 0x00022A18
		public override ulong GetCurrentRtt(ulong clientId)
		{
			if (this.NetworkManager != null)
			{
				ulong netcodeConnectionId = this.NetworkManager.ConnectionManager.ClientIdToTransportId(clientId);
				int num = this.ExtractRtt(UnityTransport.ParseClientId(netcodeConnectionId));
				if (num > 0)
				{
					return (ulong)((long)num);
				}
			}
			return (ulong)((long)this.ExtractRtt(UnityTransport.ParseClientId(clientId)));
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x00024868 File Offset: 0x00022A68
		public NetworkEndPoint GetEndpoint(ulong clientId)
		{
			if (this.m_Driver.IsCreated && this.NetworkManager != null && this.NetworkManager.IsListening)
			{
				NetworkConnection networkConnection = UnityTransport.ParseClientId(this.NetworkManager.ConnectionManager.ClientIdToTransportId(clientId));
				if (this.m_Driver.GetConnectionState(networkConnection) == NetworkConnection.State.Connected)
				{
					return this.m_Driver.RemoteEndPoint(networkConnection);
				}
			}
			return default(NetworkEndPoint);
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x000248DC File Offset: 0x00022ADC
		public override void Initialize(NetworkManager networkManager = null)
		{
			this.NetworkManager = networkManager;
			if (this.NetworkManager && this.NetworkManager.PortOverride.Overidden)
			{
				this.ConnectionData.Port = this.NetworkManager.PortOverride.Value;
			}
			IRealTimeProvider realTimeProvider2;
			if (!this.NetworkManager)
			{
				IRealTimeProvider realTimeProvider = new RealTimeProvider();
				realTimeProvider2 = realTimeProvider;
			}
			else
			{
				realTimeProvider2 = this.NetworkManager.RealTimeProvider;
			}
			this.m_RealTimeProvider = realTimeProvider2;
			this.m_NetworkSettings = new NetworkSettings(Allocator.Persistent);
			int payloadCapacity = this.m_MaxPayloadSize + 4;
			ref this.m_NetworkSettings.WithFragmentationStageParameters(payloadCapacity);
			ref this.m_NetworkSettings.WithReliableStageParameters(64);
			ref this.m_NetworkSettings.WithBaselibNetworkInterfaceParameters(this.m_MaxPacketQueueSize, this.m_MaxPacketQueueSize, 2000U);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0002499E File Offset: 0x00022B9E
		public override NetworkEvent PollEvent(out ulong clientId, out ArraySegment<byte> payload, out float receiveTime)
		{
			clientId = 0UL;
			payload = default(ArraySegment<byte>);
			receiveTime = 0f;
			return NetworkEvent.Nothing;
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x000249B4 File Offset: 0x00022BB4
		public override void Send(ulong clientId, ArraySegment<byte> payload, NetworkDelivery networkDelivery)
		{
			NetworkPipeline networkPipeline = this.SelectSendPipeline(networkDelivery);
			if (networkPipeline != this.m_ReliableSequencedPipeline && payload.Count > this.m_MaxPayloadSize)
			{
				Debug.LogError(string.Format("Unreliable payload of size {0} larger than configured 'Max Payload Size' ({1}).", payload.Count, this.m_MaxPayloadSize));
				return;
			}
			UnityTransport.SendTarget sendTarget = new UnityTransport.SendTarget(clientId, networkPipeline);
			BatchedSendQueue batchedSendQueue;
			if (!this.m_SendQueue.TryGetValue(sendTarget, out batchedSendQueue))
			{
				int val = (this.m_MaxSendQueueSize > 0) ? this.m_MaxSendQueueSize : (this.m_DisconnectTimeoutMS * 5376);
				batchedSendQueue = new BatchedSendQueue(Math.Max(val, this.m_MaxPayloadSize));
				this.m_SendQueue.Add(sendTarget, batchedSendQueue);
			}
			if (!batchedSendQueue.PushMessage(payload))
			{
				if (networkPipeline == this.m_ReliableSequencedPipeline)
				{
					NetworkManager networkManager = this.NetworkManager;
					ulong num = (networkManager != null) ? networkManager.ConnectionManager.TransportIdToClientId(clientId) : clientId;
					Debug.LogError(string.Format("Couldn't add payload of size {0} to reliable send queue. ", payload.Count) + string.Format("Closing connection {0} as reliability guarantees can't be maintained.", num));
					if (clientId == this.m_ServerClientId)
					{
						this.DisconnectLocalClient();
						return;
					}
					this.DisconnectRemoteClient(clientId);
					base.InvokeOnTransportEvent(NetworkEvent.Disconnect, clientId, default(ArraySegment<byte>), this.m_RealTimeProvider.RealTimeSinceStartup);
					return;
				}
				else
				{
					this.m_Driver.ScheduleFlushSend(default(JobHandle)).Complete();
					this.SendBatchedMessages(sendTarget, batchedSendQueue);
					batchedSendQueue.PushMessage(payload);
				}
			}
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x00024B31 File Offset: 0x00022D31
		public override bool StartClient()
		{
			if (this.m_Driver.IsCreated)
			{
				return false;
			}
			bool flag = this.ClientBindAndConnect();
			if (!flag && this.m_Driver.IsCreated)
			{
				this.m_Driver.Dispose();
			}
			return flag;
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x00024B64 File Offset: 0x00022D64
		public override bool StartServer()
		{
			if (this.m_Driver.IsCreated)
			{
				return false;
			}
			UnityTransport.ProtocolType protocolType = this.m_ProtocolType;
			if (protocolType == UnityTransport.ProtocolType.UnityTransport)
			{
				bool flag = this.ServerBindAndListen(this.ConnectionData.ListenEndPoint);
				if (!flag && this.m_Driver.IsCreated)
				{
					this.m_Driver.Dispose();
				}
				return flag;
			}
			if (protocolType != UnityTransport.ProtocolType.RelayUnityTransport)
			{
				return false;
			}
			bool flag2 = this.StartRelayServer();
			if (!flag2 && this.m_Driver.IsCreated)
			{
				this.m_Driver.Dispose();
			}
			return flag2;
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public override void Shutdown()
		{
			if (this.NetworkManager && !this.NetworkManager.ShutdownInProgress)
			{
				Debug.LogWarning("Directly calling `UnityTransport.Shutdown()` results in unexpected shutdown behaviour. All pending events will be lost. Use `NetworkManager.Shutdown()` instead.");
			}
			if (this.m_Driver.IsCreated)
			{
				foreach (KeyValuePair<UnityTransport.SendTarget, BatchedSendQueue> keyValuePair in this.m_SendQueue)
				{
					this.SendBatchedMessages(keyValuePair.Key, keyValuePair.Value);
				}
				this.m_Driver.ScheduleUpdate(default(JobHandle)).Complete();
			}
			this.DisposeInternals();
			this.m_ReliableReceiveQueues.Clear();
			this.m_State = UnityTransport.State.Disconnected;
			this.m_ServerClientId = 0UL;
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x00024CB0 File Offset: 0x00022EB0
		private void ConfigureSimulatorForUtp1()
		{
			ref this.m_NetworkSettings.WithSimulatorStageParameters(300, 1400, this.DebugSimulator.PacketDelayMS, this.DebugSimulator.PacketJitterMS, 0, this.DebugSimulator.PacketDropRate, 0, 0, this.DebugSimulatorRandomSeed ?? ((uint)Stopwatch.GetTimestamp()));
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x00024D16 File Offset: 0x00022F16
		public void SetServerSecrets(string serverCertificate, string serverPrivateKey)
		{
			this.m_ServerPrivateKey = serverPrivateKey;
			this.m_ServerCertificate = serverCertificate;
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x00024D26 File Offset: 0x00022F26
		public void SetClientSecrets(string serverCommonName, string caCertificate = null)
		{
			this.m_ServerCommonName = serverCommonName;
			this.m_ClientCaCertificate = caCertificate;
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00024D38 File Offset: 0x00022F38
		public void CreateDriver(UnityTransport transport, out NetworkDriver driver, out NetworkPipeline unreliableFragmentedPipeline, out NetworkPipeline unreliableSequencedFragmentedPipeline, out NetworkPipeline reliableSequencedPipeline)
		{
			NetworkPipelineStageCollection.RegisterPipelineStage(default(NetworkMetricsPipelineStage));
			int maxConnectAttempts = transport.m_MaxConnectAttempts;
			ref this.m_NetworkSettings.WithNetworkConfigParameters(transport.m_ConnectTimeoutMS, maxConnectAttempts, transport.m_DisconnectTimeoutMS, transport.m_HeartbeatTimeoutMS, 0, 0, 1400);
			driver = NetworkDriver.Create(this.m_NetworkSettings);
			this.SetupPipelinesForUtp1(driver, out unreliableFragmentedPipeline, out unreliableSequencedFragmentedPipeline, out reliableSequencedPipeline);
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x00024DA8 File Offset: 0x00022FA8
		private void SetupPipelinesForUtp1(NetworkDriver driver, out NetworkPipeline unreliableFragmentedPipeline, out NetworkPipeline unreliableSequencedFragmentedPipeline, out NetworkPipeline reliableSequencedPipeline)
		{
			unreliableFragmentedPipeline = driver.CreatePipeline(new Type[]
			{
				typeof(FragmentationPipelineStage),
				typeof(NetworkMetricsPipelineStage)
			});
			unreliableSequencedFragmentedPipeline = driver.CreatePipeline(new Type[]
			{
				typeof(FragmentationPipelineStage),
				typeof(UnreliableSequencedPipelineStage),
				typeof(NetworkMetricsPipelineStage)
			});
			reliableSequencedPipeline = driver.CreatePipeline(new Type[]
			{
				typeof(ReliableSequencedPipelineStage),
				typeof(NetworkMetricsPipelineStage)
			});
		}

		// Token: 0x040003A3 RID: 931
		public const int InitialMaxPacketQueueSize = 128;

		// Token: 0x040003A4 RID: 932
		public const int InitialMaxPayloadSize = 6144;

		// Token: 0x040003A5 RID: 933
		[Obsolete("MaxSendQueueSize is now determined dynamically (can still be set programmatically using the MaxSendQueueSize property). This initial value is not used anymore.", false)]
		public const int InitialMaxSendQueueSize = 98304;

		// Token: 0x040003A6 RID: 934
		private const int k_MaxReliableThroughput = 5376;

		// Token: 0x040003A7 RID: 935
		private static UnityTransport.ConnectionAddressData s_DefaultConnectionAddressData = new UnityTransport.ConnectionAddressData
		{
			Address = "127.0.0.1",
			Port = 7777,
			ServerListenAddress = string.Empty
		};

		// Token: 0x040003A8 RID: 936
		public static INetworkStreamDriverConstructor s_DriverConstructor;

		// Token: 0x040003A9 RID: 937
		[Tooltip("Which protocol should be selected (Relay/Non-Relay).")]
		[SerializeField]
		private UnityTransport.ProtocolType m_ProtocolType;

		// Token: 0x040003AA RID: 938
		[Tooltip("The maximum amount of packets that can be in the internal send/receive queues. Basically this is how many packets can be sent/received in a single update/frame.")]
		[SerializeField]
		private int m_MaxPacketQueueSize = 128;

		// Token: 0x040003AB RID: 939
		[Tooltip("The maximum size of an unreliable payload that can be handled by the transport. The memory for MaxPayloadSize is allocated once per connection and is released when the connection is closed.")]
		[SerializeField]
		private int m_MaxPayloadSize = 6144;

		// Token: 0x040003AC RID: 940
		private int m_MaxSendQueueSize;

		// Token: 0x040003AD RID: 941
		[Tooltip("Timeout in milliseconds after which a heartbeat is sent if there is no activity.")]
		[SerializeField]
		private int m_HeartbeatTimeoutMS = 500;

		// Token: 0x040003AE RID: 942
		[Tooltip("Timeout in milliseconds indicating how long we will wait until we send a new connection attempt.")]
		[SerializeField]
		private int m_ConnectTimeoutMS = 1000;

		// Token: 0x040003AF RID: 943
		[Tooltip("The maximum amount of connection attempts we will try before disconnecting.")]
		[SerializeField]
		private int m_MaxConnectAttempts = 60;

		// Token: 0x040003B0 RID: 944
		[Tooltip("Inactivity timeout after which a connection will be disconnected. The connection needs to receive data from the connected endpoint within this timeout. Note that with heartbeats enabled, simply not sending any data will not be enough to trigger this timeout (since heartbeats count as connection events).")]
		[SerializeField]
		private int m_DisconnectTimeoutMS = 30000;

		// Token: 0x040003B1 RID: 945
		public UnityTransport.ConnectionAddressData ConnectionData = UnityTransport.s_DefaultConnectionAddressData;

		// Token: 0x040003B2 RID: 946
		public UnityTransport.SimulatorParameters DebugSimulator = new UnityTransport.SimulatorParameters
		{
			PacketDelayMS = 0,
			PacketJitterMS = 0,
			PacketDropRate = 0
		};

		// Token: 0x040003B6 RID: 950
		private UnityTransport.PacketLossCache m_PacketLossCache;

		// Token: 0x040003B7 RID: 951
		private UnityTransport.State m_State;

		// Token: 0x040003B8 RID: 952
		private NetworkDriver m_Driver;

		// Token: 0x040003B9 RID: 953
		private NetworkSettings m_NetworkSettings;

		// Token: 0x040003BA RID: 954
		private ulong m_ServerClientId;

		// Token: 0x040003BB RID: 955
		private NetworkPipeline m_UnreliableFragmentedPipeline;

		// Token: 0x040003BC RID: 956
		private NetworkPipeline m_UnreliableSequencedFragmentedPipeline;

		// Token: 0x040003BD RID: 957
		private NetworkPipeline m_ReliableSequencedPipeline;

		// Token: 0x040003BE RID: 958
		private RelayServerData m_RelayServerData;

		// Token: 0x040003BF RID: 959
		internal NetworkManager NetworkManager;

		// Token: 0x040003C0 RID: 960
		private IRealTimeProvider m_RealTimeProvider;

		// Token: 0x040003C1 RID: 961
		private readonly Dictionary<UnityTransport.SendTarget, BatchedSendQueue> m_SendQueue = new Dictionary<UnityTransport.SendTarget, BatchedSendQueue>();

		// Token: 0x040003C2 RID: 962
		private readonly Dictionary<ulong, BatchedReceiveQueue> m_ReliableReceiveQueues = new Dictionary<ulong, BatchedReceiveQueue>();

		// Token: 0x040003C3 RID: 963
		private string m_ServerPrivateKey;

		// Token: 0x040003C4 RID: 964
		private string m_ServerCertificate;

		// Token: 0x040003C5 RID: 965
		private string m_ServerCommonName;

		// Token: 0x040003C6 RID: 966
		private string m_ClientCaCertificate;

		// Token: 0x0200012E RID: 302
		public enum ProtocolType
		{
			// Token: 0x040003C8 RID: 968
			UnityTransport,
			// Token: 0x040003C9 RID: 969
			RelayUnityTransport
		}

		// Token: 0x0200012F RID: 303
		private enum State
		{
			// Token: 0x040003CB RID: 971
			Disconnected,
			// Token: 0x040003CC RID: 972
			Listening,
			// Token: 0x040003CD RID: 973
			Connected
		}

		// Token: 0x02000130 RID: 304
		[Serializable]
		public struct ConnectionAddressData
		{
			// Token: 0x060009AF RID: 2479 RVA: 0x00024F28 File Offset: 0x00023128
			private static NetworkEndPoint ParseNetworkEndpoint(string ip, ushort port, bool silent = false)
			{
				NetworkEndPoint result = default(NetworkEndPoint);
				if (!NetworkEndPoint.TryParse(ip, port, out result, NetworkFamily.Ipv4) && !NetworkEndPoint.TryParse(ip, port, out result, NetworkFamily.Ipv6) && !silent)
				{
					Debug.LogError(string.Format("Invalid network endpoint: {0}:{1}.", ip, port));
				}
				return result;
			}

			// Token: 0x170000E8 RID: 232
			// (get) Token: 0x060009B0 RID: 2480 RVA: 0x00024F70 File Offset: 0x00023170
			public NetworkEndPoint ServerEndPoint
			{
				get
				{
					return UnityTransport.ConnectionAddressData.ParseNetworkEndpoint(this.Address, this.Port, false);
				}
			}

			// Token: 0x170000E9 RID: 233
			// (get) Token: 0x060009B1 RID: 2481 RVA: 0x00024F84 File Offset: 0x00023184
			public NetworkEndPoint ListenEndPoint
			{
				get
				{
					if (string.IsNullOrEmpty(this.ServerListenAddress))
					{
						NetworkEndPoint networkEndPoint = NetworkEndPoint.LoopbackIpv4;
						if (!string.IsNullOrEmpty(this.Address) && this.ServerEndPoint.Family == NetworkFamily.Ipv6)
						{
							networkEndPoint = NetworkEndPoint.LoopbackIpv6;
						}
						return networkEndPoint.WithPort(this.Port);
					}
					return UnityTransport.ConnectionAddressData.ParseNetworkEndpoint(this.ServerListenAddress, this.Port, false);
				}
			}

			// Token: 0x170000EA RID: 234
			// (get) Token: 0x060009B2 RID: 2482 RVA: 0x00024FEC File Offset: 0x000231EC
			public bool IsIpv6
			{
				get
				{
					return !string.IsNullOrEmpty(this.Address) && UnityTransport.ConnectionAddressData.ParseNetworkEndpoint(this.Address, this.Port, true).Family == NetworkFamily.Ipv6;
				}
			}

			// Token: 0x040003CE RID: 974
			[Tooltip("IP address of the server (address to which clients will connect to).")]
			[SerializeField]
			public string Address;

			// Token: 0x040003CF RID: 975
			[Tooltip("UDP port of the server.")]
			[SerializeField]
			public ushort Port;

			// Token: 0x040003D0 RID: 976
			[Tooltip("IP address the server will listen on. If not provided, will use localhost.")]
			[SerializeField]
			public string ServerListenAddress;
		}

		// Token: 0x02000131 RID: 305
		[Serializable]
		public struct SimulatorParameters
		{
			// Token: 0x040003D1 RID: 977
			[Tooltip("Delay to add to every send and received packet (in milliseconds). Only applies in the editor and in development builds. The value is ignored in production builds.")]
			[SerializeField]
			public int PacketDelayMS;

			// Token: 0x040003D2 RID: 978
			[Tooltip("Jitter (random variation) to add/substract to the packet delay (in milliseconds). Only applies in the editor and in development builds. The value is ignored in production builds.")]
			[SerializeField]
			public int PacketJitterMS;

			// Token: 0x040003D3 RID: 979
			[Tooltip("Percentage of sent and received packets to drop. Only applies in the editor and in the editor and in developments builds.")]
			[SerializeField]
			public int PacketDropRate;
		}

		// Token: 0x02000132 RID: 306
		private struct PacketLossCache
		{
			// Token: 0x040003D4 RID: 980
			public int PacketsReceived;

			// Token: 0x040003D5 RID: 981
			public int PacketsDropped;

			// Token: 0x040003D6 RID: 982
			public float PacketLoss;
		}

		// Token: 0x02000133 RID: 307
		[BurstCompile]
		private struct SendBatchedMessagesJob : IJob
		{
			// Token: 0x060009B3 RID: 2483 RVA: 0x00025028 File Offset: 0x00023228
			public void Execute()
			{
				ulong clientId = this.Target.ClientId;
				NetworkConnection id = UnityTransport.ParseClientId(clientId);
				NetworkPipeline networkPipeline = this.Target.NetworkPipeline;
				while (!this.Queue.IsEmpty)
				{
					DataStreamWriter writer;
					int num = this.Driver.BeginSend(networkPipeline, id, out writer, 0);
					if (num != 0)
					{
						Debug.LogError(string.Format("Error sending message: {0}", ErrorUtilities.ErrorToFixedString(num, clientId)));
						return;
					}
					int num2 = (networkPipeline == this.ReliablePipeline) ? this.Queue.FillWriterWithBytes(ref writer, this.MTU) : this.Queue.FillWriterWithMessages(ref writer, this.MTU);
					num = this.Driver.EndSend(writer);
					if (num != num2)
					{
						if (num != -5)
						{
							Debug.LogError(string.Format("Error sending the message: {0}", ErrorUtilities.ErrorToFixedString(num, clientId)));
							this.Queue.Consume(num2);
						}
						return;
					}
					this.Queue.Consume(num2);
				}
			}

			// Token: 0x040003D7 RID: 983
			public NetworkDriver.Concurrent Driver;

			// Token: 0x040003D8 RID: 984
			public UnityTransport.SendTarget Target;

			// Token: 0x040003D9 RID: 985
			public BatchedSendQueue Queue;

			// Token: 0x040003DA RID: 986
			public NetworkPipeline ReliablePipeline;

			// Token: 0x040003DB RID: 987
			public int MTU;
		}

		// Token: 0x02000134 RID: 308
		private struct SendTarget : IEquatable<UnityTransport.SendTarget>
		{
			// Token: 0x060009B4 RID: 2484 RVA: 0x00025121 File Offset: 0x00023321
			public SendTarget(ulong clientId, NetworkPipeline networkPipeline)
			{
				this.ClientId = clientId;
				this.NetworkPipeline = networkPipeline;
			}

			// Token: 0x060009B5 RID: 2485 RVA: 0x00025134 File Offset: 0x00023334
			public bool Equals(UnityTransport.SendTarget other)
			{
				return this.ClientId == other.ClientId && this.NetworkPipeline.Equals(other.NetworkPipeline);
			}

			// Token: 0x060009B6 RID: 2486 RVA: 0x00025168 File Offset: 0x00023368
			public override bool Equals(object obj)
			{
				if (obj is UnityTransport.SendTarget)
				{
					UnityTransport.SendTarget other = (UnityTransport.SendTarget)obj;
					return this.Equals(other);
				}
				return false;
			}

			// Token: 0x060009B7 RID: 2487 RVA: 0x00025190 File Offset: 0x00023390
			public override int GetHashCode()
			{
				return this.ClientId.GetHashCode() * 397 ^ this.NetworkPipeline.GetHashCode();
			}

			// Token: 0x040003DC RID: 988
			public readonly ulong ClientId;

			// Token: 0x040003DD RID: 989
			public readonly NetworkPipeline NetworkPipeline;
		}
	}
}
