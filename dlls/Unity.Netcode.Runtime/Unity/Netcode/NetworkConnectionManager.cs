using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000013 RID: 19
	public sealed class NetworkConnectionManager
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000042 RID: 66 RVA: 0x0000327E File Offset: 0x0000147E
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00003286 File Offset: 0x00001486
		public string DisconnectReason { get; internal set; }

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000044 RID: 68 RVA: 0x00003290 File Offset: 0x00001490
		// (remove) Token: 0x06000045 RID: 69 RVA: 0x000032C8 File Offset: 0x000014C8
		public event Action<ulong> OnClientConnectedCallback;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000046 RID: 70 RVA: 0x00003300 File Offset: 0x00001500
		// (remove) Token: 0x06000047 RID: 71 RVA: 0x00003338 File Offset: 0x00001538
		public event Action<ulong> OnClientDisconnectCallback;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000048 RID: 72 RVA: 0x00003370 File Offset: 0x00001570
		// (remove) Token: 0x06000049 RID: 73 RVA: 0x000033A8 File Offset: 0x000015A8
		public event Action<NetworkManager, ConnectionEventData> OnConnectionEvent;

		// Token: 0x0600004A RID: 74 RVA: 0x000033E0 File Offset: 0x000015E0
		internal void InvokeOnClientConnectedCallback(ulong clientId)
		{
			try
			{
				Action<ulong> onClientConnectedCallback = this.OnClientConnectedCallback;
				if (onClientConnectedCallback != null)
				{
					onClientConnectedCallback(clientId);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			if (!this.NetworkManager.IsServer)
			{
				NativeArray<ulong> nativeArray = new NativeArray<ulong>(Math.Max(this.NetworkManager.ConnectedClientsIds.Count - 1, 0), Allocator.Temp, NativeArrayOptions.ClearMemory);
				using (nativeArray)
				{
					int num = 0;
					foreach (ulong num2 in this.NetworkManager.ConnectedClientsIds)
					{
						if (num2 != this.NetworkManager.LocalClientId && nativeArray.Length > num)
						{
							nativeArray[num] = num2;
							num++;
						}
					}
					try
					{
						Action<NetworkManager, ConnectionEventData> onConnectionEvent = this.OnConnectionEvent;
						if (onConnectionEvent != null)
						{
							onConnectionEvent(this.NetworkManager, new ConnectionEventData
							{
								ClientId = this.NetworkManager.LocalClientId,
								EventType = ConnectionEvent.ClientConnected,
								PeerClientIds = nativeArray
							});
						}
						return;
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
						return;
					}
				}
			}
			try
			{
				Action<NetworkManager, ConnectionEventData> onConnectionEvent2 = this.OnConnectionEvent;
				if (onConnectionEvent2 != null)
				{
					onConnectionEvent2(this.NetworkManager, new ConnectionEventData
					{
						ClientId = clientId,
						EventType = ConnectionEvent.ClientConnected
					});
				}
			}
			catch (Exception exception3)
			{
				Debug.LogException(exception3);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000356C File Offset: 0x0000176C
		internal void InvokeOnClientDisconnectCallback(ulong clientId)
		{
			try
			{
				Action<ulong> onClientDisconnectCallback = this.OnClientDisconnectCallback;
				if (onClientDisconnectCallback != null)
				{
					onClientDisconnectCallback(clientId);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			try
			{
				Action<NetworkManager, ConnectionEventData> onConnectionEvent = this.OnConnectionEvent;
				if (onConnectionEvent != null)
				{
					onConnectionEvent(this.NetworkManager, new ConnectionEventData
					{
						ClientId = clientId,
						EventType = ConnectionEvent.ClientDisconnected
					});
				}
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000035EC File Offset: 0x000017EC
		internal void InvokeOnPeerConnectedCallback(ulong clientId)
		{
			try
			{
				Action<NetworkManager, ConnectionEventData> onConnectionEvent = this.OnConnectionEvent;
				if (onConnectionEvent != null)
				{
					onConnectionEvent(this.NetworkManager, new ConnectionEventData
					{
						ClientId = clientId,
						EventType = ConnectionEvent.PeerConnected
					});
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003644 File Offset: 0x00001844
		internal void InvokeOnPeerDisconnectedCallback(ulong clientId)
		{
			try
			{
				Action<NetworkManager, ConnectionEventData> onConnectionEvent = this.OnConnectionEvent;
				if (onConnectionEvent != null)
				{
					onConnectionEvent(this.NetworkManager, new ConnectionEventData
					{
						ClientId = clientId,
						EventType = ConnectionEvent.PeerDisconnected
					});
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600004E RID: 78 RVA: 0x0000369C File Offset: 0x0000189C
		// (remove) Token: 0x0600004F RID: 79 RVA: 0x000036D4 File Offset: 0x000018D4
		public event Action OnTransportFailure;

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00003709 File Offset: 0x00001909
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00003711 File Offset: 0x00001911
		public bool IsListening { get; internal set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000052 RID: 82 RVA: 0x0000371A File Offset: 0x0000191A
		internal IReadOnlyDictionary<ulong, PendingClient> PendingClients
		{
			get
			{
				return this.m_PendingClients;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003722 File Offset: 0x00001922
		internal void StartClientApprovalCoroutine(ulong clientId)
		{
			this.LocalClientApprovalCoroutine = this.NetworkManager.StartCoroutine(this.ApprovalTimeout(clientId));
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000373C File Offset: 0x0000193C
		internal void StopClientApprovalCoroutine()
		{
			if (this.LocalClientApprovalCoroutine != null)
			{
				this.NetworkManager.StopCoroutine(this.LocalClientApprovalCoroutine);
				this.LocalClientApprovalCoroutine = null;
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003760 File Offset: 0x00001960
		internal void AddPendingClient(ulong clientId)
		{
			this.m_PendingClients.Add(clientId, new PendingClient
			{
				ClientId = clientId,
				ConnectionState = PendingClient.State.PendingConnection,
				ApprovalCoroutine = this.NetworkManager.StartCoroutine(this.ApprovalTimeout(clientId))
			});
			this.NetworkManager.PendingClients.Add(clientId, this.PendingClients[clientId]);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000037C4 File Offset: 0x000019C4
		internal void RemovePendingClient(ulong clientId)
		{
			if (this.m_PendingClients.ContainsKey(clientId) && this.m_PendingClients[clientId].ApprovalCoroutine != null)
			{
				this.NetworkManager.StopCoroutine(this.m_PendingClients[clientId].ApprovalCoroutine);
			}
			this.m_PendingClients.Remove(clientId);
			this.NetworkManager.PendingClients.Remove(clientId);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003830 File Offset: 0x00001A30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal ulong TransportIdToClientId(ulong transportId)
		{
			if (transportId == this.GetServerTransportId())
			{
				return 0UL;
			}
			ulong result;
			if (this.TransportIdToClientIdMap.TryGetValue(transportId, out result))
			{
				return result;
			}
			if (NetworkLog.CurrentLogLevel == LogLevel.Developer)
			{
				NetworkLog.LogWarning(string.Format("Trying to get the NGO client ID map for the transport ID ({0}) but did not find the map entry! Returning default transport ID value.", transportId));
			}
			return 0UL;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000387C File Offset: 0x00001A7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal ulong ClientIdToTransportId(ulong clientId)
		{
			if (clientId == 0UL)
			{
				return this.GetServerTransportId();
			}
			ulong result;
			if (this.ClientIdToTransportIdMap.TryGetValue(clientId, out result))
			{
				return result;
			}
			if (NetworkLog.CurrentLogLevel == LogLevel.Developer)
			{
				NetworkLog.LogWarning(string.Format("Trying to get the transport client ID map for the NGO client ID ({0}) but did not find the map entry! Returning default transport ID value.", clientId));
			}
			return 0UL;
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000059 RID: 89 RVA: 0x000038C3 File Offset: 0x00001AC3
		internal ulong ServerTransportId
		{
			get
			{
				return this.GetServerTransportId();
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000038CC File Offset: 0x00001ACC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private ulong GetServerTransportId()
		{
			if (!(this.NetworkManager != null))
			{
				throw new Exception("There is no NetworkManager assigned to this instance!");
			}
			NetworkTransport networkTransport = this.NetworkManager.NetworkConfig.NetworkTransport;
			if (networkTransport != null)
			{
				return networkTransport.ServerClientId;
			}
			throw new NullReferenceException("The transport in the active NetworkConfig is null");
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003920 File Offset: 0x00001B20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal ulong TransportIdCleanUp(ulong transportId)
		{
			if (!this.LocalClient.IsServer && !this.TransportIdToClientIdMap.ContainsKey(transportId))
			{
				return this.NetworkManager.LocalClientId;
			}
			ulong num = this.TransportIdToClientId(transportId);
			this.TransportIdToClientIdMap.Remove(transportId);
			this.ClientIdToTransportIdMap.Remove(num);
			return num;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003978 File Offset: 0x00001B78
		internal void PollAndHandleNetworkEvents()
		{
			NetworkEvent networkEvent;
			do
			{
				ulong transportClientId;
				ArraySegment<byte> payload;
				float receiveTime;
				networkEvent = this.NetworkManager.NetworkConfig.NetworkTransport.PollEvent(out transportClientId, out payload, out receiveTime);
				this.HandleNetworkEvent(networkEvent, transportClientId, payload, receiveTime);
			}
			while (this.NetworkManager.IsListening && networkEvent != NetworkEvent.Nothing);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000039BC File Offset: 0x00001BBC
		internal void HandleNetworkEvent(NetworkEvent networkEvent, ulong transportClientId, ArraySegment<byte> payload, float receiveTime)
		{
			switch (networkEvent)
			{
			case NetworkEvent.Data:
				this.DataEventHandler(transportClientId, ref payload, receiveTime);
				return;
			case NetworkEvent.Connect:
				this.ConnectEventHandler(transportClientId);
				return;
			case NetworkEvent.Disconnect:
				this.DisconnectEventHandler(transportClientId);
				return;
			case NetworkEvent.TransportFailure:
				this.TransportFailureEventHandler(false);
				return;
			default:
				return;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000039F8 File Offset: 0x00001BF8
		internal void ConnectEventHandler(ulong transportClientId)
		{
			ulong num;
			if (this.LocalClient.IsServer)
			{
				ulong nextClientId = this.m_NextClientId;
				this.m_NextClientId = nextClientId + 1UL;
				num = nextClientId;
			}
			else
			{
				num = 0UL;
			}
			this.ClientIdToTransportIdMap[num] = transportClientId;
			this.TransportIdToClientIdMap[transportClientId] = num;
			this.MessageManager.ClientConnected(num);
			if (this.LocalClient.IsServer)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
				{
					NetworkLog.LogInfo("Client Connected");
				}
				this.AddPendingClient(num);
				return;
			}
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("Connected");
			}
			this.SendConnectionRequest();
			this.StartClientApprovalCoroutine(num);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003A98 File Offset: 0x00001C98
		internal void DataEventHandler(ulong transportClientId, ref ArraySegment<byte> payload, float receiveTime)
		{
			ulong clientId = this.TransportIdToClientId(transportClientId);
			this.MessageManager.HandleIncomingData(clientId, payload, receiveTime);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003AC0 File Offset: 0x00001CC0
		internal void DisconnectEventHandler(ulong transportClientId)
		{
			ulong num = this.TransportIdCleanUp(transportClientId);
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo(string.Format("Disconnect Event From {0}", num));
			}
			if (!this.NetworkManager.IsServer && num == 0UL)
			{
				num = this.NetworkManager.LocalClientId;
			}
			this.MessageManager.ProcessIncomingMessageQueue();
			if (this.LocalClient.IsServer)
			{
				this.OnClientDisconnectFromServer(num);
				this.InvokeOnClientDisconnectCallback(num);
				if (this.LocalClient.IsHost)
				{
					this.InvokeOnPeerDisconnectedCallback(num);
				}
			}
			else
			{
				this.InvokeOnClientDisconnectCallback(num);
				if (!this.NetworkManager.ShutdownInProgress)
				{
					this.NetworkManager.Shutdown(true);
				}
			}
			if (this.NetworkManager.IsServer)
			{
				this.MessageManager.ClientDisconnected(num);
				return;
			}
			this.MessageManager.ClientDisconnected(0UL);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003B94 File Offset: 0x00001D94
		internal void TransportFailureEventHandler(bool duringStart = false)
		{
			string text = this.LocalClient.IsServer ? (this.LocalClient.IsHost ? "Host" : "Server") : "Client";
			string text2 = duringStart ? "start failure" : "failure";
			NetworkLog.LogError(string.Concat(new string[]
			{
				text,
				" is shutting down due to network transport ",
				text2,
				" of ",
				this.NetworkManager.NetworkConfig.NetworkTransport.GetType().Name,
				"!"
			}));
			Action onTransportFailure = this.OnTransportFailure;
			if (onTransportFailure != null)
			{
				onTransportFailure();
			}
			if (duringStart)
			{
				this.LocalClient.SetRole(false, false, null);
				this.NetworkManager.ShutdownInternal();
				return;
			}
			this.NetworkManager.Shutdown(true);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003C68 File Offset: 0x00001E68
		private void SendConnectionRequest()
		{
			ConnectionRequestMessage connectionRequestMessage = new ConnectionRequestMessage
			{
				ConfigHash = this.NetworkManager.NetworkConfig.GetConfig(false),
				ShouldSendConnectionData = this.NetworkManager.NetworkConfig.ConnectionApproval,
				ConnectionData = this.NetworkManager.NetworkConfig.ConnectionData,
				MessageVersions = new NativeArray<MessageVersionData>(this.MessageManager.MessageHandlers.Length, Allocator.Temp, NativeArrayOptions.ClearMemory)
			};
			for (int i = 0; i < this.MessageManager.MessageHandlers.Length; i++)
			{
				if (this.MessageManager.MessageTypes[i] != null)
				{
					Type type = this.MessageManager.MessageTypes[i];
					connectionRequestMessage.MessageVersions[i] = new MessageVersionData
					{
						Hash = type.FullName.Hash32(),
						Version = this.MessageManager.GetLocalVersion(type)
					};
				}
			}
			this.SendMessage<ConnectionRequestMessage>(ref connectionRequestMessage, NetworkDelivery.ReliableSequenced, 0UL);
			connectionRequestMessage.MessageVersions.Dispose();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003D6F File Offset: 0x00001F6F
		private IEnumerator ApprovalTimeout(ulong clientId)
		{
			float num = this.LocalClient.IsServer ? this.NetworkManager.LocalTime.TimeAsFloat : this.NetworkManager.RealTimeProvider.RealTimeSinceStartup;
			bool flag = false;
			bool flag2 = false;
			bool connectionNotApproved = false;
			float timeoutMarker = num + (float)this.NetworkManager.NetworkConfig.ClientConnectionBufferTimeout;
			while (this.NetworkManager.IsListening && !this.NetworkManager.ShutdownInProgress && !flag && !flag2)
			{
				yield return null;
				flag = (timeoutMarker < (this.LocalClient.IsServer ? this.NetworkManager.LocalTime.TimeAsFloat : this.NetworkManager.RealTimeProvider.RealTimeSinceStartup));
				if (this.LocalClient.IsServer)
				{
					flag2 = (!this.PendingClients.ContainsKey(clientId) && this.ConnectedClients.ContainsKey(clientId));
					connectionNotApproved = (!this.PendingClients.ContainsKey(clientId) && !this.ConnectedClients.ContainsKey(clientId));
				}
				else
				{
					flag2 = this.NetworkManager.LocalClient.IsApproved;
				}
			}
			if (!this.NetworkManager.IsListening || this.NetworkManager.ShutdownInProgress)
			{
				yield break;
			}
			if (flag || connectionNotApproved)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
				{
					if (flag)
					{
						if (this.LocalClient.IsServer)
						{
							NetworkLog.LogWarning(string.Format("Server detected a transport connection from Client-{0}, but timed out waiting for the connection request message.", clientId));
						}
						else
						{
							NetworkLog.LogInfo("Timed out waiting for the server to approve the connection request.");
						}
					}
					else if (connectionNotApproved)
					{
						NetworkLog.LogInfo(string.Format("Client-{0} was either denied approval or disconnected while being approved.", clientId));
					}
				}
				if (this.LocalClient.IsServer)
				{
					this.DisconnectClient(clientId, null);
				}
				else
				{
					this.NetworkManager.Shutdown(true);
				}
			}
			yield break;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003D88 File Offset: 0x00001F88
		internal void ApproveConnection(ref ConnectionRequestMessage connectionRequestMessage, ref NetworkContext context)
		{
			NetworkManager.ConnectionApprovalResponse connectionApprovalResponse = new NetworkManager.ConnectionApprovalResponse();
			this.ClientsToApprove[context.SenderId] = connectionApprovalResponse;
			this.ConnectionApprovalCallback(new NetworkManager.ConnectionApprovalRequest
			{
				Payload = connectionRequestMessage.ConnectionData,
				ClientNetworkId = context.SenderId
			}, connectionApprovalResponse);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003DDC File Offset: 0x00001FDC
		internal void ProcessPendingApprovals()
		{
			List<ulong> list = null;
			foreach (KeyValuePair<ulong, NetworkManager.ConnectionApprovalResponse> keyValuePair in this.ClientsToApprove)
			{
				NetworkManager.ConnectionApprovalResponse value = keyValuePair.Value;
				ulong key = keyValuePair.Key;
				if (!value.Pending)
				{
					try
					{
						this.HandleConnectionApproval(key, value);
						if (list == null)
						{
							list = new List<ulong>();
						}
						list.Add(key);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			if (list != null)
			{
				foreach (ulong key2 in list)
				{
					this.ClientsToApprove.Remove(key2);
				}
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003EBC File Offset: 0x000020BC
		internal void HandleConnectionApproval(ulong ownerClientId, NetworkManager.ConnectionApprovalResponse response)
		{
			this.LocalClient.IsApproved = response.Approved;
			if (!response.Approved)
			{
				if (!string.IsNullOrEmpty(response.Reason))
				{
					DisconnectReasonMessage disconnectReasonMessage = new DisconnectReasonMessage
					{
						Reason = response.Reason
					};
					this.SendMessage<DisconnectReasonMessage>(ref disconnectReasonMessage, NetworkDelivery.Reliable, ownerClientId);
					this.MessageManager.ProcessSendQueues();
				}
				this.DisconnectRemoteClient(ownerClientId);
				return;
			}
			this.RemovePendingClient(ownerClientId);
			NetworkClient networkClient = this.AddClient(ownerClientId);
			if (response.CreatePlayerObject && (response.PlayerPrefabHash != null || this.NetworkManager.NetworkConfig.PlayerPrefab != null))
			{
				NetworkObject networkObjectToSpawn;
				if (response.PlayerPrefabHash == null)
				{
					NetworkSpawnManager spawnManager = this.NetworkManager.SpawnManager;
					uint globalObjectIdHash = this.NetworkManager.NetworkConfig.PlayerPrefab.GetComponent<NetworkObject>().GlobalObjectIdHash;
					Vector3? position = response.Position;
					Vector3? position2 = (position != null) ? position : null;
					Quaternion? rotation = response.Rotation;
					networkObjectToSpawn = spawnManager.GetNetworkObjectToSpawn(globalObjectIdHash, ownerClientId, position2, (rotation != null) ? rotation : null, false);
				}
				else
				{
					NetworkSpawnManager spawnManager2 = this.NetworkManager.SpawnManager;
					uint value = response.PlayerPrefabHash.Value;
					Vector3? position = response.Position;
					Vector3? position3 = (position != null) ? position : null;
					Quaternion? rotation = response.Rotation;
					networkObjectToSpawn = spawnManager2.GetNetworkObjectToSpawn(value, ownerClientId, position3, (rotation != null) ? rotation : null, false);
				}
				NetworkObject networkObject = networkObjectToSpawn;
				this.NetworkManager.SpawnManager.SpawnNetworkObjectLocally(networkObject, this.NetworkManager.SpawnManager.GetNetworkObjectId(), false, true, ownerClientId, false);
				networkClient.AssignPlayerObject(ref networkObject);
			}
			if (ownerClientId != 0UL)
			{
				ConnectionApprovedMessage connectionApprovedMessage = new ConnectionApprovedMessage
				{
					OwnerClientId = ownerClientId,
					NetworkTick = this.NetworkManager.LocalTime.Tick,
					ConnectedClientIds = new NativeArray<ulong>(this.ConnectedClientIds.Count, Allocator.Temp, NativeArrayOptions.ClearMemory)
				};
				int num = 0;
				foreach (ulong value2 in this.ConnectedClientIds)
				{
					connectionApprovedMessage.ConnectedClientIds[num] = value2;
					num++;
				}
				if (!this.NetworkManager.NetworkConfig.EnableSceneManagement)
				{
					this.NetworkManager.SpawnManager.UpdateObservedNetworkObjects(ownerClientId);
					if (this.NetworkManager.SpawnManager.SpawnedObjectsList.Count != 0)
					{
						connectionApprovedMessage.SpawnedObjectsList = this.NetworkManager.SpawnManager.SpawnedObjectsList;
					}
				}
				connectionApprovedMessage.MessageVersions = new NativeArray<MessageVersionData>(this.MessageManager.MessageHandlers.Length, Allocator.Temp, NativeArrayOptions.ClearMemory);
				for (int i = 0; i < this.MessageManager.MessageHandlers.Length; i++)
				{
					if (this.MessageManager.MessageTypes[i] != null)
					{
						Type type = this.MessageManager.MessageTypes[i];
						connectionApprovedMessage.MessageVersions[i] = new MessageVersionData
						{
							Hash = type.FullName.Hash32(),
							Version = this.MessageManager.GetLocalVersion(type)
						};
					}
				}
				this.SendMessage<ConnectionApprovedMessage>(ref connectionApprovedMessage, NetworkDelivery.ReliableFragmentedSequenced, ownerClientId);
				connectionApprovedMessage.MessageVersions.Dispose();
				connectionApprovedMessage.ConnectedClientIds.Dispose();
				if (!this.NetworkManager.NetworkConfig.EnableSceneManagement)
				{
					this.NetworkManager.ConnectedClients[ownerClientId].IsConnected = true;
					this.InvokeOnClientConnectedCallback(ownerClientId);
					if (this.LocalClient.IsHost)
					{
						this.InvokeOnPeerConnectedCallback(ownerClientId);
					}
				}
				else
				{
					this.NetworkManager.SceneManager.SynchronizeNetworkObjects(ownerClientId);
				}
			}
			else
			{
				this.LocalClient = networkClient;
				this.NetworkManager.SpawnManager.UpdateObservedNetworkObjects(ownerClientId);
				this.LocalClient.IsConnected = true;
			}
			if (!response.CreatePlayerObject || (response.PlayerPrefabHash == null && this.NetworkManager.NetworkConfig.PlayerPrefab == null))
			{
				return;
			}
			this.ApprovedPlayerSpawn(ownerClientId, response.PlayerPrefabHash ?? this.NetworkManager.NetworkConfig.PlayerPrefab.GetComponent<NetworkObject>().GlobalObjectIdHash);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00004308 File Offset: 0x00002508
		internal void ApprovedPlayerSpawn(ulong clientId, uint playerPrefabHash)
		{
			foreach (KeyValuePair<ulong, NetworkClient> keyValuePair in this.ConnectedClients)
			{
				if (keyValuePair.Key != clientId && keyValuePair.Key != 0UL && !(this.ConnectedClients[clientId].PlayerObject == null) && this.ConnectedClients[clientId].PlayerObject.Observers.Contains(keyValuePair.Key))
				{
					CreateObjectMessage createObjectMessage = new CreateObjectMessage
					{
						ObjectInfo = this.ConnectedClients[clientId].PlayerObject.GetMessageSceneObject(keyValuePair.Key)
					};
					createObjectMessage.ObjectInfo.Hash = playerPrefabHash;
					createObjectMessage.ObjectInfo.IsSceneObject = false;
					createObjectMessage.ObjectInfo.HasParent = false;
					createObjectMessage.ObjectInfo.IsPlayerObject = true;
					createObjectMessage.ObjectInfo.OwnerClientId = clientId;
					int num = this.SendMessage<CreateObjectMessage>(ref createObjectMessage, NetworkDelivery.ReliableFragmentedSequenced, keyValuePair.Key);
					this.NetworkManager.NetworkMetrics.TrackObjectSpawnSent(keyValuePair.Key, this.ConnectedClients[clientId].PlayerObject, (long)num);
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004470 File Offset: 0x00002670
		internal NetworkClient AddClient(ulong clientId)
		{
			NetworkClient networkClient = this.LocalClient;
			networkClient = new NetworkClient();
			networkClient.SetRole(clientId == 0UL, true, this.NetworkManager);
			networkClient.ClientId = clientId;
			this.ConnectedClients.Add(clientId, networkClient);
			this.ConnectedClientsList.Add(networkClient);
			this.ConnectedClientIds.Add(clientId);
			if (clientId != 0UL)
			{
				ClientConnectedMessage clientConnectedMessage = new ClientConnectedMessage
				{
					ClientId = clientId
				};
				this.NetworkManager.MessageManager.SendMessage<ClientConnectedMessage, List<ulong>>(ref clientConnectedMessage, NetworkDelivery.ReliableFragmentedSequenced, this.ConnectedClientIds);
			}
			return networkClient;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000044F8 File Offset: 0x000026F8
		internal void OnClientDisconnectFromServer(ulong clientId)
		{
			if (!this.LocalClient.IsServer)
			{
				throw new Exception("[OnClientDisconnectFromServer] Was invoked by non-server instance!");
			}
			if (this.NetworkManager.ShutdownInProgress && clientId == 0UL)
			{
				return;
			}
			NetworkClient networkClient;
			if (this.ConnectedClients.TryGetValue(clientId, out networkClient))
			{
				NetworkObject playerObject = networkClient.PlayerObject;
				if (playerObject != null)
				{
					if (!playerObject.DontDestroyWithOwner)
					{
						if (this.NetworkManager.PrefabHandler.ContainsHandler(this.ConnectedClients[clientId].PlayerObject.GlobalObjectIdHash))
						{
							if (playerObject.IsSpawned)
							{
								this.NetworkManager.SpawnManager.DespawnObject(this.ConnectedClients[clientId].PlayerObject, false);
							}
							this.NetworkManager.PrefabHandler.HandleNetworkPrefabDestroy(this.ConnectedClients[clientId].PlayerObject);
						}
						else if (playerObject.IsSpawned)
						{
							this.NetworkManager.SpawnManager.DespawnObject(playerObject, true);
						}
					}
					else if (!this.NetworkManager.ShutdownInProgress)
					{
						playerObject.RemoveOwnership();
					}
				}
				List<NetworkObject> clientOwnedObjects = this.NetworkManager.SpawnManager.GetClientOwnedObjects(clientId);
				for (int i = clientOwnedObjects.Count - 1; i >= 0; i--)
				{
					NetworkObject networkObject = clientOwnedObjects[i];
					if (networkObject)
					{
						if (!networkObject.DontDestroyWithOwner)
						{
							if (this.NetworkManager.PrefabHandler.ContainsHandler(clientOwnedObjects[i].GlobalObjectIdHash))
							{
								if (networkObject.IsSpawned)
								{
									this.NetworkManager.SpawnManager.DespawnObject(networkObject, false);
								}
								this.NetworkManager.PrefabHandler.HandleNetworkPrefabDestroy(clientOwnedObjects[i]);
							}
							else
							{
								Object.Destroy(networkObject.gameObject);
							}
						}
						else if (!this.NetworkManager.ShutdownInProgress)
						{
							networkObject.RemoveOwnership();
						}
					}
				}
				foreach (NetworkObject networkObject2 in this.NetworkManager.SpawnManager.SpawnedObjectsList)
				{
					networkObject2.Observers.Remove(clientId);
				}
				if (this.ConnectedClients.ContainsKey(clientId))
				{
					this.ConnectedClientsList.Remove(this.ConnectedClients[clientId]);
					this.ConnectedClients.Remove(clientId);
				}
				this.ConnectedClientIds.Remove(clientId);
				ClientDisconnectedMessage clientDisconnectedMessage = new ClientDisconnectedMessage
				{
					ClientId = clientId
				};
				NetworkMessageManager messageManager = this.MessageManager;
				if (messageManager != null)
				{
					messageManager.SendMessage<ClientDisconnectedMessage, List<ulong>>(ref clientDisconnectedMessage, NetworkDelivery.ReliableFragmentedSequenced, this.ConnectedClientIds);
				}
			}
			if (this.ClientIdToTransportIdMap.ContainsKey(clientId))
			{
				ulong num = this.ClientIdToTransportId(clientId);
				this.NetworkManager.NetworkConfig.NetworkTransport.DisconnectRemoteClient(num);
				this.InvokeOnClientDisconnectCallback(clientId);
				if (this.LocalClient.IsHost)
				{
					this.InvokeOnPeerDisconnectedCallback(clientId);
				}
				this.TransportIdCleanUp(num);
			}
			this.RemovePendingClient(clientId);
			this.MessageManager.ClientDisconnected(clientId);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000047F0 File Offset: 0x000029F0
		internal void DisconnectRemoteClient(ulong clientId)
		{
			this.MessageManager.ProcessSendQueues();
			this.OnClientDisconnectFromServer(clientId);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004804 File Offset: 0x00002A04
		internal void DisconnectClient(ulong clientId, string reason = null)
		{
			if (!this.LocalClient.IsServer)
			{
				throw new NotServerException("Only server can disconnect remote clients. Please use `Shutdown()` instead.");
			}
			if (clientId == 0UL)
			{
				Debug.LogWarning("Disconnecting the local server-host client is not allowed. Use NetworkManager.Shutdown instead.");
				return;
			}
			if (!string.IsNullOrEmpty(reason))
			{
				DisconnectReasonMessage disconnectReasonMessage = new DisconnectReasonMessage
				{
					Reason = reason
				};
				this.SendMessage<DisconnectReasonMessage>(ref disconnectReasonMessage, NetworkDelivery.Reliable, clientId);
			}
			this.DisconnectRemoteClient(clientId);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004864 File Offset: 0x00002A64
		internal void Initialize(NetworkManager networkManager)
		{
			this.LocalClient.IsApproved = false;
			this.m_PendingClients.Clear();
			this.ConnectedClients.Clear();
			this.ConnectedClientsList.Clear();
			this.ConnectedClientIds.Clear();
			this.ClientIdToTransportIdMap.Clear();
			this.TransportIdToClientIdMap.Clear();
			this.ClientsToApprove.Clear();
			NetworkObject.OrphanChildren.Clear();
			this.DisconnectReason = string.Empty;
			this.NetworkManager = networkManager;
			this.MessageManager = networkManager.MessageManager;
			this.NetworkManager.NetworkConfig.NetworkTransport.NetworkMetrics = this.NetworkManager.MetricsManager.NetworkMetrics;
			this.NetworkManager.NetworkConfig.NetworkTransport.OnTransportEvent += this.HandleNetworkEvent;
			this.NetworkManager.NetworkConfig.NetworkTransport.Initialize(networkManager);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00004950 File Offset: 0x00002B50
		internal void Shutdown()
		{
			if (this.LocalClient.IsServer)
			{
				HashSet<ulong> hashSet = new HashSet<ulong>();
				ulong serverClientId = this.NetworkManager.NetworkConfig.NetworkTransport.ServerClientId;
				foreach (KeyValuePair<ulong, NetworkClient> keyValuePair in this.ConnectedClients)
				{
					if (!hashSet.Contains(keyValuePair.Key) && keyValuePair.Key != serverClientId)
					{
						hashSet.Add(keyValuePair.Key);
					}
				}
				foreach (KeyValuePair<ulong, PendingClient> keyValuePair2 in this.PendingClients)
				{
					if (!hashSet.Contains(keyValuePair2.Key) && keyValuePair2.Key != serverClientId)
					{
						hashSet.Add(keyValuePair2.Key);
					}
				}
				foreach (ulong clientId in hashSet)
				{
					this.DisconnectRemoteClient(clientId);
				}
				NetworkMessageManager messageManager = this.MessageManager;
				if (messageManager != null)
				{
					messageManager.ProcessSendQueues();
				}
			}
			else if (this.NetworkManager != null && this.NetworkManager.IsListening && this.LocalClient.IsClient)
			{
				NetworkMessageManager messageManager2 = this.MessageManager;
				if (messageManager2 != null)
				{
					messageManager2.ProcessSendQueues();
				}
				try
				{
					this.NetworkManager.NetworkConfig.NetworkTransport.DisconnectLocalClient();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			this.LocalClient.IsApproved = false;
			this.LocalClient.IsConnected = false;
			this.ConnectedClients.Clear();
			this.ConnectedClientIds.Clear();
			this.ConnectedClientsList.Clear();
			if (this.NetworkManager != null)
			{
				NetworkConfig networkConfig = this.NetworkManager.NetworkConfig;
				if (((networkConfig != null) ? networkConfig.NetworkTransport : null) != null)
				{
					this.NetworkManager.NetworkConfig.NetworkTransport.OnTransportEvent -= this.HandleNetworkEvent;
				}
			}
			if (this.IsListening)
			{
				NetworkConfig networkConfig2 = this.NetworkManager.NetworkConfig;
				NetworkTransport networkTransport = (networkConfig2 != null) ? networkConfig2.NetworkTransport : null;
				if (networkTransport != null)
				{
					networkTransport.Shutdown();
					if (this.NetworkManager.LogLevel <= LogLevel.Developer)
					{
						NetworkLog.LogInfo("NetworkConnectionManager.Shutdown() -> IsListening && NetworkTransport != null -> NetworkTransport.Shutdown()");
					}
				}
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00004BDC File Offset: 0x00002DDC
		internal unsafe int SendMessage<TMessageType, TClientIdListType>(ref TMessageType message, NetworkDelivery delivery, in TClientIdListType clientIds) where TMessageType : INetworkMessage where TClientIdListType : IReadOnlyList<ulong>
		{
			TClientIdListType tclientIdListType;
			if (!this.LocalClient.IsServer)
			{
				tclientIdListType = clientIds;
				if (tclientIdListType.Count == 1)
				{
					tclientIdListType = clientIds;
					if (tclientIdListType[0] == 0UL)
					{
						return this.MessageManager.SendMessage<TMessageType, TClientIdListType>(ref message, delivery, clientIds);
					}
				}
				throw new ArgumentException("Clients may only send messages to ServerClientId");
			}
			tclientIdListType = clientIds;
			ulong* ptr = stackalloc ulong[checked(unchecked((UIntPtr)tclientIdListType.Count) * 8)];
			int num = 0;
			int num2 = 0;
			for (;;)
			{
				int num3 = num2;
				tclientIdListType = clientIds;
				if (num3 >= tclientIdListType.Count)
				{
					break;
				}
				tclientIdListType = clientIds;
				if (tclientIdListType[num2] != 0UL)
				{
					ref long ptr2 = ref *(long*)(ptr + (IntPtr)(num++) * 8);
					tclientIdListType = clientIds;
					ptr2 = (long)tclientIdListType[num2];
				}
				num2++;
			}
			if (num == 0)
			{
				return 0;
			}
			return this.MessageManager.SendMessage<TMessageType>(ref message, delivery, ptr, num);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00004CC8 File Offset: 0x00002EC8
		internal unsafe int SendMessage<T>(ref T message, NetworkDelivery delivery, ulong* clientIds, int numClientIds) where T : INetworkMessage
		{
			if (this.LocalClient.IsServer)
			{
				ulong* ptr = stackalloc ulong[checked(unchecked((UIntPtr)numClientIds) * 8)];
				int num = 0;
				for (int i = 0; i < numClientIds; i++)
				{
					if (clientIds[i] != 0UL)
					{
						ptr[(IntPtr)(num++) * 8] = clientIds[i];
					}
				}
				if (num == 0)
				{
					return 0;
				}
				return this.MessageManager.SendMessage<T>(ref message, delivery, ptr, num);
			}
			else
			{
				if (numClientIds != 1 || *clientIds != 0UL)
				{
					throw new ArgumentException("Clients may only send messages to ServerClientId");
				}
				return this.MessageManager.SendMessage<T>(ref message, delivery, clientIds, numClientIds);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00004D50 File Offset: 0x00002F50
		internal unsafe int SendMessage<T>(ref T message, NetworkDelivery delivery, in NativeArray<ulong> clientIds) where T : INetworkMessage
		{
			ulong* unsafePtr = (ulong*)clientIds.GetUnsafePtr<ulong>();
			NativeArray<ulong> nativeArray = clientIds;
			return this.SendMessage<T>(ref message, delivery, unsafePtr, nativeArray.Length);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004D7E File Offset: 0x00002F7E
		internal int SendMessage<T>(ref T message, NetworkDelivery delivery, ulong clientId) where T : INetworkMessage
		{
			if (this.LocalClient.IsServer && clientId == 0UL)
			{
				return 0;
			}
			if (!this.LocalClient.IsServer && clientId != 0UL)
			{
				throw new ArgumentException("Clients may only send messages to ServerClientId");
			}
			return this.MessageManager.SendMessage<T>(ref message, delivery, clientId);
		}

		// Token: 0x0400004B RID: 75
		internal NetworkManager NetworkManager;

		// Token: 0x0400004C RID: 76
		internal NetworkMessageManager MessageManager;

		// Token: 0x0400004D RID: 77
		internal NetworkClient LocalClient = new NetworkClient();

		// Token: 0x0400004E RID: 78
		internal Dictionary<ulong, NetworkManager.ConnectionApprovalResponse> ClientsToApprove = new Dictionary<ulong, NetworkManager.ConnectionApprovalResponse>();

		// Token: 0x0400004F RID: 79
		internal Dictionary<ulong, NetworkClient> ConnectedClients = new Dictionary<ulong, NetworkClient>();

		// Token: 0x04000050 RID: 80
		internal Dictionary<ulong, ulong> ClientIdToTransportIdMap = new Dictionary<ulong, ulong>();

		// Token: 0x04000051 RID: 81
		internal Dictionary<ulong, ulong> TransportIdToClientIdMap = new Dictionary<ulong, ulong>();

		// Token: 0x04000052 RID: 82
		internal List<NetworkClient> ConnectedClientsList = new List<NetworkClient>();

		// Token: 0x04000053 RID: 83
		internal List<ulong> ConnectedClientIds = new List<ulong>();

		// Token: 0x04000054 RID: 84
		internal Action<NetworkManager.ConnectionApprovalRequest, NetworkManager.ConnectionApprovalResponse> ConnectionApprovalCallback;

		// Token: 0x04000055 RID: 85
		private Dictionary<ulong, PendingClient> m_PendingClients = new Dictionary<ulong, PendingClient>();

		// Token: 0x04000056 RID: 86
		internal Coroutine LocalClientApprovalCoroutine;

		// Token: 0x04000057 RID: 87
		private ulong m_NextClientId = 1UL;
	}
}
