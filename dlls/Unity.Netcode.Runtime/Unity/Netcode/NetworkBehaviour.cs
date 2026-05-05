using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x0200001B RID: 27
	public abstract class NetworkBehaviour : MonoBehaviour
	{
		// Token: 0x0600008D RID: 141 RVA: 0x000051A6 File Offset: 0x000033A6
		protected internal virtual string __getTypeName()
		{
			return "NetworkBehaviour";
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000051AD File Offset: 0x000033AD
		protected FastBufferWriter __beginSendServerRpc(uint rpcMethodId, ServerRpcParams serverRpcParams, RpcDelivery rpcDelivery)
		{
			return new FastBufferWriter(1024, Allocator.Temp, 65536);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000051C0 File Offset: 0x000033C0
		protected void __endSendServerRpc(ref FastBufferWriter bufferWriter, uint rpcMethodId, ServerRpcParams serverRpcParams, RpcDelivery rpcDelivery)
		{
			ServerRpcMessage serverRpcMessage = new ServerRpcMessage
			{
				Metadata = new RpcMetadata
				{
					NetworkObjectId = this.NetworkObjectId,
					NetworkBehaviourId = this.NetworkBehaviourId,
					NetworkRpcMethodId = rpcMethodId
				},
				WriteBuffer = bufferWriter
			};
			NetworkDelivery delivery;
			if (rpcDelivery == RpcDelivery.Reliable || rpcDelivery != RpcDelivery.Unreliable)
			{
				delivery = NetworkDelivery.ReliableFragmentedSequenced;
			}
			else
			{
				if (bufferWriter.Length > this.NetworkManager.MessageManager.NonFragmentedMessageMaxSize)
				{
					throw new OverflowException("RPC parameters are too large for unreliable delivery.");
				}
				delivery = NetworkDelivery.Unreliable;
			}
			if (this.IsHost || this.IsServer)
			{
				using (FastBufferReader readBuffer = new FastBufferReader(bufferWriter, Allocator.Temp, -1, 0, Allocator.Temp))
				{
					NetworkContext networkContext = new NetworkContext
					{
						SenderId = 0UL,
						Timestamp = this.NetworkManager.RealTimeProvider.RealTimeSinceStartup,
						SystemOwner = this.NetworkManager,
						Header = default(NetworkMessageHeader),
						SerializedHeaderSize = 0,
						MessageSize = 0U
					};
					serverRpcMessage.ReadBuffer = readBuffer;
					serverRpcMessage.Handle(ref networkContext);
					int length = readBuffer.Length;
					goto IL_135;
				}
			}
			this.NetworkManager.ConnectionManager.SendMessage<ServerRpcMessage>(ref serverRpcMessage, delivery, 0UL);
			IL_135:
			bufferWriter.Dispose();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000051AD File Offset: 0x000033AD
		protected FastBufferWriter __beginSendClientRpc(uint rpcMethodId, ClientRpcParams clientRpcParams, RpcDelivery rpcDelivery)
		{
			return new FastBufferWriter(1024, Allocator.Temp, 65536);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00005318 File Offset: 0x00003518
		protected void __endSendClientRpc(ref FastBufferWriter bufferWriter, uint rpcMethodId, ClientRpcParams clientRpcParams, RpcDelivery rpcDelivery)
		{
			ClientRpcMessage clientRpcMessage = new ClientRpcMessage
			{
				Metadata = new RpcMetadata
				{
					NetworkObjectId = this.NetworkObjectId,
					NetworkBehaviourId = this.NetworkBehaviourId,
					NetworkRpcMethodId = rpcMethodId
				},
				WriteBuffer = bufferWriter
			};
			NetworkDelivery networkDelivery;
			if (rpcDelivery == RpcDelivery.Reliable || rpcDelivery != RpcDelivery.Unreliable)
			{
				networkDelivery = NetworkDelivery.ReliableFragmentedSequenced;
			}
			else
			{
				if (bufferWriter.Length > this.NetworkManager.MessageManager.NonFragmentedMessageMaxSize)
				{
					throw new OverflowException("RPC parameters are too large for unreliable delivery.");
				}
				networkDelivery = NetworkDelivery.Unreliable;
			}
			bool flag = false;
			if (clientRpcParams.Send.TargetClientIds != null)
			{
				foreach (ulong num in clientRpcParams.Send.TargetClientIds)
				{
					if (num == 0UL)
					{
						flag = true;
						break;
					}
					if (this.NetworkManager.LogLevel >= LogLevel.Error && !this.NetworkObject.Observers.Contains(num))
					{
						NetworkLog.LogError(this.GenerateObserverErrorMessage(clientRpcParams, num));
					}
				}
				this.NetworkManager.ConnectionManager.SendMessage<ClientRpcMessage, IReadOnlyList<ulong>>(ref clientRpcMessage, networkDelivery, clientRpcParams.Send.TargetClientIds);
			}
			else if (clientRpcParams.Send.TargetClientIdsNativeArray != null)
			{
				NativeArray<ulong> value = clientRpcParams.Send.TargetClientIdsNativeArray.Value;
				foreach (ulong num2 in value)
				{
					if (num2 == 0UL)
					{
						flag = true;
						break;
					}
					if (this.NetworkManager.LogLevel >= LogLevel.Error && !this.NetworkObject.Observers.Contains(num2))
					{
						NetworkLog.LogError(this.GenerateObserverErrorMessage(clientRpcParams, num2));
					}
				}
				NetworkConnectionManager connectionManager = this.NetworkManager.ConnectionManager;
				NetworkDelivery delivery = networkDelivery;
				value = clientRpcParams.Send.TargetClientIdsNativeArray.Value;
				connectionManager.SendMessage<ClientRpcMessage>(ref clientRpcMessage, delivery, value);
			}
			else
			{
				HashSet<ulong>.Enumerator enumerator3 = this.NetworkObject.Observers.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					if (this.IsHost && enumerator3.Current == this.NetworkManager.LocalClientId)
					{
						flag = true;
					}
					else
					{
						this.NetworkManager.ConnectionManager.SendMessage<ClientRpcMessage>(ref clientRpcMessage, networkDelivery, enumerator3.Current);
					}
				}
			}
			if (flag)
			{
				using (FastBufferReader readBuffer = new FastBufferReader(bufferWriter, Allocator.Temp, -1, 0, Allocator.Temp))
				{
					NetworkContext networkContext = new NetworkContext
					{
						SenderId = 0UL,
						Timestamp = this.NetworkManager.RealTimeProvider.RealTimeSinceStartup,
						SystemOwner = this.NetworkManager,
						Header = default(NetworkMessageHeader),
						SerializedHeaderSize = 0,
						MessageSize = 0U
					};
					clientRpcMessage.ReadBuffer = readBuffer;
					clientRpcMessage.Handle(ref networkContext);
				}
			}
			bufferWriter.Dispose();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00005614 File Offset: 0x00003814
		protected FastBufferWriter __beginSendRpc(uint rpcMethodId, RpcParams rpcParams, RpcAttribute.RpcAttributeParams attributeParams, SendTo defaultTarget, RpcDelivery rpcDelivery)
		{
			if (attributeParams.RequireOwnership && !this.IsOwner)
			{
				throw new RpcException("This RPC can only be sent by its owner.");
			}
			return new FastBufferWriter(1024, Allocator.Temp, 65536);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00005644 File Offset: 0x00003844
		protected void __endSendRpc(ref FastBufferWriter bufferWriter, uint rpcMethodId, RpcParams rpcParams, RpcAttribute.RpcAttributeParams attributeParams, SendTo defaultTarget, RpcDelivery rpcDelivery)
		{
			RpcMessage rpcMessage = new RpcMessage
			{
				Metadata = new RpcMetadata
				{
					NetworkObjectId = this.NetworkObjectId,
					NetworkBehaviourId = this.NetworkBehaviourId,
					NetworkRpcMethodId = rpcMethodId
				},
				SenderClientId = this.NetworkManager.LocalClientId,
				WriteBuffer = bufferWriter
			};
			NetworkDelivery delivery;
			if (rpcDelivery == RpcDelivery.Reliable || rpcDelivery != RpcDelivery.Unreliable)
			{
				delivery = NetworkDelivery.ReliableFragmentedSequenced;
			}
			else
			{
				if (bufferWriter.Length > this.NetworkManager.MessageManager.NonFragmentedMessageMaxSize)
				{
					throw new OverflowException("RPC parameters are too large for unreliable delivery.");
				}
				delivery = NetworkDelivery.Unreliable;
			}
			if (rpcParams.Send.Target == null)
			{
				switch (defaultTarget)
				{
				case SendTo.Owner:
					rpcParams.Send.Target = this.RpcTarget.Owner;
					break;
				case SendTo.NotOwner:
					rpcParams.Send.Target = this.RpcTarget.NotOwner;
					break;
				case SendTo.Server:
					rpcParams.Send.Target = this.RpcTarget.Server;
					break;
				case SendTo.NotServer:
					rpcParams.Send.Target = this.RpcTarget.NotServer;
					break;
				case SendTo.Me:
					rpcParams.Send.Target = this.RpcTarget.Me;
					break;
				case SendTo.NotMe:
					rpcParams.Send.Target = this.RpcTarget.NotMe;
					break;
				case SendTo.Everyone:
					rpcParams.Send.Target = this.RpcTarget.Everyone;
					break;
				case SendTo.ClientsAndHost:
					rpcParams.Send.Target = this.RpcTarget.ClientsAndHost;
					break;
				case SendTo.SpecifiedInParams:
					throw new RpcException("This method requires a runtime-specified send target.");
				}
			}
			else if (defaultTarget != SendTo.SpecifiedInParams && !attributeParams.AllowTargetOverride)
			{
				throw new RpcException("Target override is not allowed for this method.");
			}
			if (rpcParams.Send.LocalDeferMode == LocalDeferMode.Default)
			{
				rpcParams.Send.LocalDeferMode = (attributeParams.DeferLocal ? LocalDeferMode.Defer : LocalDeferMode.SendImmediate);
			}
			rpcParams.Send.Target.Send(this, ref rpcMessage, delivery, rpcParams);
			bufferWriter.Dispose();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00005857 File Offset: 0x00003A57
		protected static NativeList<T> __createNativeList<[IsUnmanaged] T>() where T : struct, ValueType
		{
			return new NativeList<T>(Allocator.Temp);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00005864 File Offset: 0x00003A64
		internal string GenerateObserverErrorMessage(ClientRpcParams clientRpcParams, ulong targetClientId)
		{
			string arg = (clientRpcParams.Send.TargetClientIds != null) ? "TargetClientIds" : "TargetClientIdsNativeArray";
			return string.Format("Sending ClientRpc to non-observer! {0} contains clientId {1} that is not an observer!", arg, targetClientId);
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000096 RID: 150 RVA: 0x0000589C File Offset: 0x00003A9C
		public NetworkManager NetworkManager
		{
			get
			{
				NetworkObject networkObject = this.NetworkObject;
				if (!(((networkObject != null) ? networkObject.NetworkManager : null) != null))
				{
					return NetworkManager.Singleton;
				}
				NetworkObject networkObject2 = this.NetworkObject;
				if (networkObject2 == null)
				{
					return null;
				}
				return networkObject2.NetworkManager;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000097 RID: 151 RVA: 0x000058CF File Offset: 0x00003ACF
		public RpcTarget RpcTarget
		{
			get
			{
				return this.NetworkManager.RpcTarget;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000098 RID: 152 RVA: 0x000058DC File Offset: 0x00003ADC
		// (set) Token: 0x06000099 RID: 153 RVA: 0x000058E4 File Offset: 0x00003AE4
		public bool IsLocalPlayer { get; private set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600009A RID: 154 RVA: 0x000058ED File Offset: 0x00003AED
		// (set) Token: 0x0600009B RID: 155 RVA: 0x000058F5 File Offset: 0x00003AF5
		public bool IsOwner { get; internal set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600009C RID: 156 RVA: 0x000058FE File Offset: 0x00003AFE
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00005906 File Offset: 0x00003B06
		public bool IsServer { get; private set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000590F File Offset: 0x00003B0F
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00005917 File Offset: 0x00003B17
		public bool ServerIsHost { get; private set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00005920 File Offset: 0x00003B20
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00005928 File Offset: 0x00003B28
		public bool IsClient { get; private set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00005931 File Offset: 0x00003B31
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00005939 File Offset: 0x00003B39
		public bool IsHost { get; private set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00005942 File Offset: 0x00003B42
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x0000594A File Offset: 0x00003B4A
		public bool IsOwnedByServer { get; internal set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00005953 File Offset: 0x00003B53
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x0000595B File Offset: 0x00003B5B
		public bool IsSpawned { get; internal set; }

		// Token: 0x060000A8 RID: 168 RVA: 0x00005964 File Offset: 0x00003B64
		internal bool IsBehaviourEditable()
		{
			return !this.m_NetworkObject || this.m_NetworkObject.NetworkManager == null || !this.m_NetworkObject.NetworkManager.IsListening || this.m_NetworkObject.NetworkManager.IsServer;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x000059B8 File Offset: 0x00003BB8
		public NetworkObject NetworkObject
		{
			get
			{
				if (this.m_NetworkObject != null)
				{
					return this.m_NetworkObject;
				}
				try
				{
					this.m_NetworkObject = base.GetComponentInParent<NetworkObject>();
				}
				catch (Exception)
				{
					return null;
				}
				if (this.IsSpawned && this.m_NetworkObject == null && (NetworkManager.Singleton == null || !NetworkManager.Singleton.ShutdownInProgress) && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Could not get NetworkObject for the NetworkBehaviour. Are you missing a NetworkObject component?");
				}
				return this.m_NetworkObject;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00005A48 File Offset: 0x00003C48
		public bool HasNetworkObject
		{
			get
			{
				return this.NetworkObject != null;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00005A56 File Offset: 0x00003C56
		// (set) Token: 0x060000AC RID: 172 RVA: 0x00005A5E File Offset: 0x00003C5E
		public ulong NetworkObjectId { get; internal set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00005A67 File Offset: 0x00003C67
		// (set) Token: 0x060000AE RID: 174 RVA: 0x00005A6F File Offset: 0x00003C6F
		public ushort NetworkBehaviourId { get; internal set; }

		// Token: 0x060000AF RID: 175 RVA: 0x00005A78 File Offset: 0x00003C78
		protected NetworkBehaviour GetNetworkBehaviour(ushort behaviourId)
		{
			return this.NetworkObject.GetNetworkBehaviourAtOrderIndex(behaviourId);
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00005A86 File Offset: 0x00003C86
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x00005A8E File Offset: 0x00003C8E
		public ulong OwnerClientId { get; internal set; }

		// Token: 0x060000B2 RID: 178 RVA: 0x00005A98 File Offset: 0x00003C98
		internal void UpdateNetworkProperties()
		{
			if (this.NetworkObject != null)
			{
				this.NetworkObjectId = this.NetworkObject.NetworkObjectId;
				this.IsLocalPlayer = this.NetworkObject.IsLocalPlayer;
				this.NetworkBehaviourId = this.NetworkObject.GetNetworkBehaviourOrderIndex(this);
				this.IsOwnedByServer = this.NetworkObject.IsOwnedByServer;
				this.IsOwner = this.NetworkObject.IsOwner;
				this.OwnerClientId = this.NetworkObject.OwnerClientId;
				if (this.NetworkManager != null)
				{
					this.IsHost = (this.NetworkManager.IsListening && this.NetworkManager.IsHost);
					this.IsClient = (this.NetworkManager.IsListening && this.NetworkManager.IsClient);
					this.IsServer = (this.NetworkManager.IsListening && this.NetworkManager.IsServer);
					this.ServerIsHost = (this.NetworkManager.IsListening && this.NetworkManager.ServerIsHost);
					return;
				}
			}
			else
			{
				this.OwnerClientId = (this.NetworkObjectId = 0UL);
				this.IsOwnedByServer = (this.IsOwner = (this.IsHost = (this.IsClient = (this.IsServer = (this.ServerIsHost = false)))));
				this.NetworkBehaviourId = 0;
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004E3E File Offset: 0x0000303E
		protected virtual void OnNetworkPreSpawn(ref NetworkManager networkManager)
		{
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004E3E File Offset: 0x0000303E
		public virtual void OnNetworkSpawn()
		{
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004E3E File Offset: 0x0000303E
		protected virtual void OnNetworkPostSpawn()
		{
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004E3E File Offset: 0x0000303E
		protected virtual void OnNetworkSessionSynchronized()
		{
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004E3E File Offset: 0x0000303E
		protected virtual void OnInSceneObjectsSpawned()
		{
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004E3E File Offset: 0x0000303E
		public virtual void OnNetworkDespawn()
		{
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00005C04 File Offset: 0x00003E04
		internal void NetworkPreSpawn(ref NetworkManager networkManager)
		{
			try
			{
				this.OnNetworkPreSpawn(ref networkManager);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00005C34 File Offset: 0x00003E34
		internal void InternalOnNetworkSpawn()
		{
			this.IsSpawned = true;
			this.InitializeVariables();
			this.UpdateNetworkProperties();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00005C4C File Offset: 0x00003E4C
		internal void VisibleOnNetworkSpawn()
		{
			try
			{
				this.OnNetworkSpawn();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			this.InitializeVariables();
			if (this.IsServer)
			{
				this.PostNetworkVariableWrite(true);
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00005C90 File Offset: 0x00003E90
		internal void NetworkPostSpawn()
		{
			try
			{
				this.OnNetworkPostSpawn();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00005CBC File Offset: 0x00003EBC
		internal void NetworkSessionSynchronized()
		{
			try
			{
				this.OnNetworkSessionSynchronized();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00005CE8 File Offset: 0x00003EE8
		internal void InSceneNetworkObjectsSpawned()
		{
			try
			{
				this.OnInSceneObjectsSpawned();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00005D14 File Offset: 0x00003F14
		internal void InternalOnNetworkDespawn()
		{
			this.IsSpawned = false;
			this.UpdateNetworkProperties();
			try
			{
				this.OnNetworkDespawn();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004E3E File Offset: 0x0000303E
		public virtual void OnGainedOwnership()
		{
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00005D50 File Offset: 0x00003F50
		internal void InternalOnGainedOwnership()
		{
			this.UpdateNetworkProperties();
			if (this.OwnerClientId == this.NetworkManager.LocalClientId)
			{
				this.UpdateNetworkVariableOnOwnershipChanged();
			}
			this.OnGainedOwnership();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004E3E File Offset: 0x0000303E
		protected virtual void OnOwnershipChanged(ulong previous, ulong current)
		{
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00005D77 File Offset: 0x00003F77
		internal void InternalOnOwnershipChanged(ulong previous, ulong current)
		{
			this.OnOwnershipChanged(previous, current);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004E3E File Offset: 0x0000303E
		public virtual void OnLostOwnership()
		{
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00005D81 File Offset: 0x00003F81
		internal void InternalOnLostOwnership()
		{
			this.UpdateNetworkProperties();
			this.OnLostOwnership();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004E3E File Offset: 0x0000303E
		public virtual void OnNetworkObjectParentChanged(NetworkObject parentNetworkObject)
		{
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004E3E File Offset: 0x0000303E
		protected virtual void __initializeVariables()
		{
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004E3E File Offset: 0x0000303E
		protected virtual void __initializeRpcs()
		{
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00005D8F File Offset: 0x00003F8F
		protected void __registerRpc(uint hash, NetworkBehaviour.RpcReceiveHandler handler, string rpcMethodName)
		{
			NetworkBehaviour.__rpc_func_table[base.GetType()][hash] = handler;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00005DA8 File Offset: 0x00003FA8
		protected void __nameNetworkVariable(NetworkVariableBase variable, string varName)
		{
			variable.Name = varName;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00005DB4 File Offset: 0x00003FB4
		internal void InitializeVariables()
		{
			if (this.m_VarInit)
			{
				return;
			}
			this.m_VarInit = true;
			if (!NetworkBehaviour.__rpc_func_table.ContainsKey(base.GetType()))
			{
				NetworkBehaviour.__rpc_func_table[base.GetType()] = new Dictionary<uint, NetworkBehaviour.RpcReceiveHandler>();
				this.__initializeRpcs();
			}
			this.__initializeVariables();
			Dictionary<NetworkDelivery, int> dictionary = new Dictionary<NetworkDelivery, int>();
			int num = 0;
			for (int i = 0; i < this.NetworkVariableFields.Count; i++)
			{
				NetworkDelivery networkDelivery = NetworkDelivery.ReliableFragmentedSequenced;
				if (!dictionary.ContainsKey(networkDelivery))
				{
					dictionary.Add(networkDelivery, num);
					this.m_DeliveryTypesForNetworkVariableGroups.Add(networkDelivery);
					num++;
				}
				if (dictionary[networkDelivery] >= this.m_DeliveryMappedNetworkVariableIndices.Count)
				{
					this.m_DeliveryMappedNetworkVariableIndices.Add(new HashSet<int>());
				}
				this.m_DeliveryMappedNetworkVariableIndices[dictionary[networkDelivery]].Add(i);
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00005E82 File Offset: 0x00004082
		internal void PreNetworkVariableWrite()
		{
			this.NetworkVariableIndexesToReset.Clear();
			this.NetworkVariableIndexesToResetSet.Clear();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00005E9C File Offset: 0x0000409C
		internal void PostNetworkVariableWrite(bool forced = false)
		{
			if (forced)
			{
				for (int i = 0; i < this.NetworkVariableFields.Count; i++)
				{
					NetworkVariableBase networkVariableBase = this.NetworkVariableFields[i];
					if (networkVariableBase.IsDirty() && networkVariableBase.CanSend())
					{
						networkVariableBase.UpdateLastSentTime();
						networkVariableBase.ResetDirty();
						networkVariableBase.SetDirty(false);
					}
				}
				return;
			}
			for (int j = 0; j < this.NetworkVariableIndexesToReset.Count; j++)
			{
				NetworkVariableBase networkVariableBase2 = this.NetworkVariableFields[this.NetworkVariableIndexesToReset[j]];
				if (networkVariableBase2.IsDirty() && networkVariableBase2.CanSend())
				{
					networkVariableBase2.UpdateLastSentTime();
					networkVariableBase2.ResetDirty();
					networkVariableBase2.SetDirty(false);
				}
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00005F44 File Offset: 0x00004144
		internal void PreVariableUpdate()
		{
			if (!this.m_VarInit)
			{
				this.InitializeVariables();
			}
			this.PreNetworkVariableWrite();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00005F5C File Offset: 0x0000415C
		internal void NetworkVariableUpdate(ulong targetClientId, int behaviourIndex, bool forceSend = false)
		{
			if (!forceSend && !this.CouldHaveDirtyNetworkVariables())
			{
				return;
			}
			NetworkManager networkManager = this.NetworkManager;
			NetworkObject networkObject = this.NetworkObject;
			NetworkMessageManager messageManager = networkManager.MessageManager;
			NetworkConnectionManager connectionManager = networkManager.ConnectionManager;
			for (int i = 0; i < this.m_DeliveryMappedNetworkVariableIndices.Count; i++)
			{
				bool flag = false;
				int j = 0;
				while (j < this.NetworkVariableFields.Count)
				{
					NetworkVariableBase networkVariableBase = this.NetworkVariableFields[j];
					if (networkVariableBase.IsDirty() && networkVariableBase.CanClientRead(targetClientId))
					{
						if (networkVariableBase.CanSend())
						{
							flag = true;
							break;
						}
						break;
					}
					else
					{
						j++;
					}
				}
				if (flag)
				{
					NetworkVariableDeltaMessage networkVariableDeltaMessage = new NetworkVariableDeltaMessage
					{
						NetworkObjectId = this.NetworkObjectId,
						NetworkBehaviourIndex = networkObject.GetNetworkBehaviourOrderIndex(this),
						NetworkBehaviour = this,
						TargetClientId = targetClientId,
						DeliveryMappedNetworkVariableIndex = this.m_DeliveryMappedNetworkVariableIndices[i],
						NetworkDelivery = this.m_DeliveryTypesForNetworkVariableGroups[i]
					};
					if (this.IsServer && targetClientId == 0UL)
					{
						FastBufferWriter fastBufferWriter = new FastBufferWriter(messageManager.NonFragmentedMessageMaxSize, Allocator.Temp, messageManager.FragmentedMessageMaxSize);
						using (fastBufferWriter)
						{
							networkVariableDeltaMessage.Serialize(fastBufferWriter, networkVariableDeltaMessage.Version);
							goto IL_137;
						}
					}
					connectionManager.SendMessage<NetworkVariableDeltaMessage>(ref networkVariableDeltaMessage, this.m_DeliveryTypesForNetworkVariableGroups[i], targetClientId);
				}
				IL_137:;
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000060C8 File Offset: 0x000042C8
		private bool CouldHaveDirtyNetworkVariables()
		{
			for (int i = 0; i < this.NetworkVariableFields.Count; i++)
			{
				NetworkVariableBase networkVariableBase = this.NetworkVariableFields[i];
				if (networkVariableBase.IsDirty())
				{
					if (networkVariableBase.CanSend())
					{
						return true;
					}
					this.NetworkManager.BehaviourUpdater.AddForUpdate(this.NetworkObject);
				}
			}
			return false;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00006124 File Offset: 0x00004324
		internal void UpdateNetworkVariableOnOwnershipChanged()
		{
			for (int i = 0; i < this.NetworkVariableFields.Count; i++)
			{
				if (this.NetworkVariableFields[i].CanClientWrite(this.OwnerClientId))
				{
					this.NetworkVariableFields[i].OnInitialize();
				}
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00006174 File Offset: 0x00004374
		internal void MarkVariablesDirty(bool dirty)
		{
			for (int i = 0; i < this.NetworkVariableFields.Count; i++)
			{
				this.NetworkVariableFields[i].SetDirty(dirty);
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000061AC File Offset: 0x000043AC
		internal void MarkOwnerReadVariablesDirty()
		{
			for (int i = 0; i < this.NetworkVariableFields.Count; i++)
			{
				if (this.NetworkVariableFields[i].ReadPerm == NetworkVariableReadPermission.Owner)
				{
					this.NetworkVariableFields[i].SetDirty(true);
				}
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000061F8 File Offset: 0x000043F8
		internal void WriteNetworkVariableData(FastBufferWriter writer, ulong targetClientId)
		{
			if (this.NetworkVariableFields.Count == 0)
			{
				return;
			}
			for (int i = 0; i < this.NetworkVariableFields.Count; i++)
			{
				if (this.NetworkVariableFields[i].CanClientRead(targetClientId))
				{
					if (this.NetworkManager.NetworkConfig.EnsureNetworkVariableLengthSafety)
					{
						int position = writer.Position;
						ushort num = 0;
						writer.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
						int position2 = writer.Position;
						this.NetworkVariableFields[i].WriteFieldSynchronization(writer);
						int num2 = writer.Position - position2;
						writer.Seek(position);
						num = (ushort)num2;
						writer.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
						writer.Seek(position2 + num2);
					}
					else
					{
						this.NetworkVariableFields[i].WriteFieldSynchronization(writer);
					}
				}
				else if (this.NetworkManager.NetworkConfig.EnsureNetworkVariableLengthSafety)
				{
					ushort num = 0;
					writer.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
				}
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00006304 File Offset: 0x00004504
		internal void SetNetworkVariableData(FastBufferReader reader, ulong clientId)
		{
			if (this.NetworkVariableFields.Count == 0)
			{
				return;
			}
			int i = 0;
			while (i < this.NetworkVariableFields.Count)
			{
				ushort num = 0;
				int num2 = 0;
				if (this.NetworkManager.NetworkConfig.EnsureNetworkVariableLengthSafety)
				{
					reader.ReadValueSafe<ushort>(out num, default(FastBufferWriter.ForPrimitives));
					if (num != 0)
					{
						num2 = reader.Position;
						goto IL_64;
					}
				}
				else if (this.NetworkVariableFields[i].CanClientRead(clientId))
				{
					goto IL_64;
				}
				IL_104:
				i++;
				continue;
				IL_64:
				this.NetworkVariableFields[i].ReadField(reader);
				if (!this.NetworkManager.NetworkConfig.EnsureNetworkVariableLengthSafety)
				{
					goto IL_104;
				}
				if (reader.Position > num2 + (int)num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning(string.Format("Var data read too far. {0} bytes.", reader.Position - (num2 + (int)num)));
					}
					reader.Seek(num2 + (int)num);
					goto IL_104;
				}
				if (reader.Position < num2 + (int)num)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning(string.Format("Var data read too little. {0} bytes.", num2 + (int)num - reader.Position));
					}
					reader.Seek(num2 + (int)num);
					goto IL_104;
				}
				goto IL_104;
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000642C File Offset: 0x0000462C
		protected NetworkObject GetNetworkObject(ulong networkId)
		{
			NetworkObject result;
			if (!this.NetworkManager.SpawnManager.SpawnedObjects.TryGetValue(networkId, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004E3E File Offset: 0x0000303E
		protected virtual void OnSynchronize<T>(ref BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004E3E File Offset: 0x0000303E
		public virtual void OnReanticipate(double lastRoundTripTime)
		{
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00006456 File Offset: 0x00004656
		// (set) Token: 0x060000DA RID: 218 RVA: 0x0000645E File Offset: 0x0000465E
		private protected ulong m_TargetIdBeingSynchronized { protected get; private set; }

		// Token: 0x060000DB RID: 219 RVA: 0x00006468 File Offset: 0x00004668
		internal bool Synchronize<T>(ref BufferSerializer<T> serializer, ulong targetClientId = 0UL) where T : IReaderWriter
		{
			this.m_TargetIdBeingSynchronized = targetClientId;
			if (serializer.IsWriter)
			{
				FastBufferWriter fastBufferWriter = serializer.GetFastBufferWriter();
				int position = fastBufferWriter.Position;
				ushort num = this.NetworkBehaviourId;
				fastBufferWriter.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
				int position2 = fastBufferWriter.Position;
				num = 0;
				fastBufferWriter.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
				int position3 = fastBufferWriter.Position;
				bool flag = false;
				try
				{
					this.OnSynchronize<T>(ref serializer);
				}
				catch (Exception ex)
				{
					flag = true;
					if (this.NetworkManager.LogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning(base.name + " threw an exception during synchronization serialization, this NetworkBehaviour is being skipped and will not be synchronized!");
						if (this.NetworkManager.LogLevel == LogLevel.Developer)
						{
							NetworkLog.LogError(ex.Message + "\n " + ex.StackTrace);
						}
					}
				}
				int position4 = fastBufferWriter.Position;
				this.m_TargetIdBeingSynchronized = 0UL;
				if (position4 == position3 || flag)
				{
					fastBufferWriter.Seek(position);
					fastBufferWriter.Truncate(-1);
					return false;
				}
				int num2 = position4 - position3;
				fastBufferWriter.Seek(position2);
				num = (ushort)num2;
				fastBufferWriter.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.Seek(position4);
				return true;
			}
			else
			{
				FastBufferReader fastBufferReader = serializer.GetFastBufferReader();
				ushort num3;
				fastBufferReader.ReadValueSafe<ushort>(out num3, default(FastBufferWriter.ForPrimitives));
				int position5 = fastBufferReader.Position;
				bool flag2 = false;
				try
				{
					this.OnSynchronize<T>(ref serializer);
				}
				catch (Exception ex2)
				{
					if (this.NetworkManager.LogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning(base.name + " threw an exception during synchronization deserialization, this NetworkBehaviour is being skipped and will not be synchronized!");
						if (this.NetworkManager.LogLevel == LogLevel.Developer)
						{
							NetworkLog.LogError(ex2.Message + "\n " + ex2.StackTrace);
						}
					}
					flag2 = true;
				}
				int num4 = fastBufferReader.Position - position5;
				if (num4 != (int)num3)
				{
					if (this.NetworkManager.LogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning(string.Format("{0} read {1} bytes but was expected to read {2} bytes during synchronization deserialization! This {3} is being skipped and will not be synchronized!", new object[]
						{
							base.name,
							num4,
							num3,
							"NetworkBehaviour"
						}));
					}
					flag2 = true;
				}
				this.m_TargetIdBeingSynchronized = 0UL;
				if (flag2)
				{
					int where = position5 + (int)num3;
					fastBufferReader.Seek(where);
					return false;
				}
				return true;
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000066B4 File Offset: 0x000048B4
		public virtual void OnDestroy()
		{
			if (this.NetworkObject != null && this.NetworkObject.IsSpawned && this.IsSpawned)
			{
				this.NetworkObject.OnNetworkBehaviourDestroyed(this);
			}
			if (!this.m_VarInit)
			{
				this.InitializeVariables();
			}
			for (int i = 0; i < this.NetworkVariableFields.Count; i++)
			{
				this.NetworkVariableFields[i].Dispose();
			}
		}

		// Token: 0x04000068 RID: 104
		protected internal static readonly Dictionary<Type, Dictionary<uint, NetworkBehaviour.RpcReceiveHandler>> __rpc_func_table = new Dictionary<Type, Dictionary<uint, NetworkBehaviour.RpcReceiveHandler>>();

		// Token: 0x04000069 RID: 105
		[NonSerialized]
		protected internal NetworkBehaviour.__RpcExecStage __rpc_exec_stage;

		// Token: 0x0400006A RID: 106
		private const int k_RpcMessageDefaultSize = 1024;

		// Token: 0x0400006B RID: 107
		private const int k_RpcMessageMaximumSize = 65536;

		// Token: 0x04000074 RID: 116
		private NetworkObject m_NetworkObject;

		// Token: 0x04000077 RID: 119
		internal ushort NetworkBehaviourIdCache;

		// Token: 0x04000079 RID: 121
		private bool m_VarInit;

		// Token: 0x0400007A RID: 122
		private readonly List<HashSet<int>> m_DeliveryMappedNetworkVariableIndices = new List<HashSet<int>>();

		// Token: 0x0400007B RID: 123
		private readonly List<NetworkDelivery> m_DeliveryTypesForNetworkVariableGroups = new List<NetworkDelivery>();

		// Token: 0x0400007C RID: 124
		protected internal readonly List<NetworkVariableBase> NetworkVariableFields = new List<NetworkVariableBase>();

		// Token: 0x0400007D RID: 125
		internal readonly List<int> NetworkVariableIndexesToReset = new List<int>();

		// Token: 0x0400007E RID: 126
		internal readonly HashSet<int> NetworkVariableIndexesToResetSet = new HashSet<int>();

		// Token: 0x0200001C RID: 28
		// (Invoke) Token: 0x060000E0 RID: 224
		public delegate void RpcReceiveHandler(NetworkBehaviour behaviour, FastBufferReader reader, __RpcParams parameters);

		// Token: 0x0200001D RID: 29
		protected enum __RpcExecStage
		{
			// Token: 0x04000081 RID: 129
			Send,
			// Token: 0x04000082 RID: 130
			Execute,
			// Token: 0x04000083 RID: 131
			None = 0,
			// Token: 0x04000084 RID: 132
			Server,
			// Token: 0x04000085 RID: 133
			Client
		}
	}
}
