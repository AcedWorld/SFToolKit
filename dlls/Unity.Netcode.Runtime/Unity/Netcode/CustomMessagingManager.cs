using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x0200004C RID: 76
	public class CustomMessagingManager
	{
		// Token: 0x0600021E RID: 542 RVA: 0x0000B355 File Offset: 0x00009555
		internal CustomMessagingManager(NetworkManager networkManager)
		{
			this.m_NetworkManager = networkManager;
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x0600021F RID: 543 RVA: 0x0000B390 File Offset: 0x00009590
		// (remove) Token: 0x06000220 RID: 544 RVA: 0x0000B3C8 File Offset: 0x000095C8
		public event CustomMessagingManager.UnnamedMessageDelegate OnUnnamedMessage;

		// Token: 0x06000221 RID: 545 RVA: 0x0000B400 File Offset: 0x00009600
		internal void InvokeUnnamedMessage(ulong clientId, FastBufferReader reader, int serializedHeaderSize)
		{
			if (this.OnUnnamedMessage != null)
			{
				int position = reader.Position;
				foreach (Delegate @delegate in this.OnUnnamedMessage.GetInvocationList())
				{
					reader.Seek(position);
					((CustomMessagingManager.UnnamedMessageDelegate)@delegate)(clientId, reader);
				}
			}
			this.m_NetworkManager.NetworkMetrics.TrackUnnamedMessageReceived(clientId, (long)(reader.Length + serializedHeaderSize));
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000B469 File Offset: 0x00009669
		public void SendUnnamedMessageToAll(FastBufferWriter messageBuffer, NetworkDelivery networkDelivery = NetworkDelivery.ReliableSequenced)
		{
			this.SendUnnamedMessage(this.m_NetworkManager.ConnectedClientsIds, messageBuffer, networkDelivery);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000B480 File Offset: 0x00009680
		public void SendUnnamedMessage(IReadOnlyList<ulong> clientIds, FastBufferWriter messageBuffer, NetworkDelivery networkDelivery = NetworkDelivery.ReliableSequenced)
		{
			if (!this.m_NetworkManager.IsServer)
			{
				throw new InvalidOperationException("Can not send unnamed messages to multiple users as a client");
			}
			if (clientIds == null)
			{
				throw new ArgumentNullException("clientIds", "You must pass in a valid clientId List");
			}
			this.ValidateMessageSize(messageBuffer, networkDelivery, false);
			if (this.m_NetworkManager.IsHost)
			{
				for (int i = 0; i < clientIds.Count; i++)
				{
					if (clientIds[i] == this.m_NetworkManager.LocalClientId)
					{
						this.InvokeUnnamedMessage(this.m_NetworkManager.LocalClientId, new FastBufferReader(messageBuffer, Allocator.None, -1, 0, Allocator.Temp), 0);
					}
				}
			}
			UnnamedMessage unnamedMessage = new UnnamedMessage
			{
				SendData = messageBuffer
			};
			int num = this.m_NetworkManager.ConnectionManager.SendMessage<UnnamedMessage, IReadOnlyList<ulong>>(ref unnamedMessage, networkDelivery, clientIds);
			if (num != 0)
			{
				this.m_NetworkManager.NetworkMetrics.TrackUnnamedMessageSent(clientIds, (long)num);
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000B550 File Offset: 0x00009750
		public void SendUnnamedMessage(ulong clientId, FastBufferWriter messageBuffer, NetworkDelivery networkDelivery = NetworkDelivery.ReliableSequenced)
		{
			this.ValidateMessageSize(messageBuffer, networkDelivery, false);
			if (this.m_NetworkManager.IsHost && clientId == this.m_NetworkManager.LocalClientId)
			{
				this.InvokeUnnamedMessage(this.m_NetworkManager.LocalClientId, new FastBufferReader(messageBuffer, Allocator.None, -1, 0, Allocator.Temp), 0);
				return;
			}
			UnnamedMessage unnamedMessage = new UnnamedMessage
			{
				SendData = messageBuffer
			};
			int num = this.m_NetworkManager.ConnectionManager.SendMessage<UnnamedMessage>(ref unnamedMessage, networkDelivery, clientId);
			if (num != 0)
			{
				this.m_NetworkManager.NetworkMetrics.TrackUnnamedMessageSent(clientId, (long)num);
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000B5DC File Offset: 0x000097DC
		internal void InvokeNamedMessage(ulong hash, ulong sender, FastBufferReader reader, int serializedHeaderSize)
		{
			int num = reader.Length + serializedHeaderSize;
			if (this.m_NetworkManager == null)
			{
				CustomMessagingManager.HandleNamedMessageDelegate handleNamedMessageDelegate;
				if (this.m_NamedMessageHandlers32.TryGetValue(hash, out handleNamedMessageDelegate))
				{
					string messageName = this.m_MessageHandlerNameLookup32[hash];
					handleNamedMessageDelegate(sender, reader);
					this.m_NetworkManager.NetworkMetrics.TrackNamedMessageReceived(sender, messageName, (long)num);
				}
				CustomMessagingManager.HandleNamedMessageDelegate handleNamedMessageDelegate2;
				if (this.m_NamedMessageHandlers64.TryGetValue(hash, out handleNamedMessageDelegate2))
				{
					string messageName2 = this.m_MessageHandlerNameLookup64[hash];
					handleNamedMessageDelegate2(sender, reader);
					this.m_NetworkManager.NetworkMetrics.TrackNamedMessageReceived(sender, messageName2, (long)num);
					return;
				}
			}
			else
			{
				HashSize rpcHashSize = this.m_NetworkManager.NetworkConfig.RpcHashSize;
				CustomMessagingManager.HandleNamedMessageDelegate handleNamedMessageDelegate4;
				if (rpcHashSize != HashSize.VarIntFourBytes)
				{
					if (rpcHashSize != HashSize.VarIntEightBytes)
					{
						return;
					}
					CustomMessagingManager.HandleNamedMessageDelegate handleNamedMessageDelegate3;
					if (this.m_NamedMessageHandlers64.TryGetValue(hash, out handleNamedMessageDelegate3))
					{
						string messageName3 = this.m_MessageHandlerNameLookup64[hash];
						handleNamedMessageDelegate3(sender, reader);
						this.m_NetworkManager.NetworkMetrics.TrackNamedMessageReceived(sender, messageName3, (long)num);
					}
				}
				else if (this.m_NamedMessageHandlers32.TryGetValue(hash, out handleNamedMessageDelegate4))
				{
					string messageName4 = this.m_MessageHandlerNameLookup32[hash];
					handleNamedMessageDelegate4(sender, reader);
					this.m_NetworkManager.NetworkMetrics.TrackNamedMessageReceived(sender, messageName4, (long)num);
					return;
				}
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000B710 File Offset: 0x00009910
		public void RegisterNamedMessageHandler(string name, CustomMessagingManager.HandleNamedMessageDelegate callback)
		{
			if (string.IsNullOrEmpty(name))
			{
				if (this.m_NetworkManager.LogLevel <= LogLevel.Error)
				{
					Debug.LogError("[RegisterNamedMessageHandler] Cannot register a named message of type null or empty!");
				}
				return;
			}
			uint num = name.Hash32();
			ulong key = name.Hash64();
			this.m_NamedMessageHandlers32[(ulong)num] = callback;
			this.m_NamedMessageHandlers64[key] = callback;
			this.m_MessageHandlerNameLookup32[(ulong)num] = name;
			this.m_MessageHandlerNameLookup64[key] = name;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000B784 File Offset: 0x00009984
		public void UnregisterNamedMessageHandler(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				if (this.m_NetworkManager.LogLevel <= LogLevel.Error)
				{
					Debug.LogError("[UnregisterNamedMessageHandler] Cannot unregister a named message of type null or empty!");
				}
				return;
			}
			uint num = name.Hash32();
			ulong key = name.Hash64();
			this.m_NamedMessageHandlers32.Remove((ulong)num);
			this.m_NamedMessageHandlers64.Remove(key);
			this.m_MessageHandlerNameLookup32.Remove((ulong)num);
			this.m_MessageHandlerNameLookup64.Remove(key);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000B7F6 File Offset: 0x000099F6
		public void SendNamedMessageToAll(string messageName, FastBufferWriter messageStream, NetworkDelivery networkDelivery = NetworkDelivery.ReliableSequenced)
		{
			this.SendNamedMessage(messageName, this.m_NetworkManager.ConnectedClientsIds, messageStream, networkDelivery);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000B80C File Offset: 0x00009A0C
		public void SendNamedMessage(string messageName, ulong clientId, FastBufferWriter messageStream, NetworkDelivery networkDelivery = NetworkDelivery.ReliableSequenced)
		{
			this.ValidateMessageSize(messageStream, networkDelivery, true);
			ulong hash = 0UL;
			HashSize rpcHashSize = this.m_NetworkManager.NetworkConfig.RpcHashSize;
			if (rpcHashSize != HashSize.VarIntFourBytes)
			{
				if (rpcHashSize == HashSize.VarIntEightBytes)
				{
					hash = messageName.Hash64();
				}
			}
			else
			{
				hash = (ulong)messageName.Hash32();
			}
			if (this.m_NetworkManager.IsHost && clientId == this.m_NetworkManager.LocalClientId)
			{
				this.InvokeNamedMessage(hash, this.m_NetworkManager.LocalClientId, new FastBufferReader(messageStream, Allocator.None, -1, 0, Allocator.Temp), 0);
				return;
			}
			NamedMessage namedMessage = new NamedMessage
			{
				Hash = hash,
				SendData = messageStream
			};
			int num = this.m_NetworkManager.ConnectionManager.SendMessage<NamedMessage>(ref namedMessage, networkDelivery, clientId);
			if (num != 0)
			{
				this.m_NetworkManager.NetworkMetrics.TrackNamedMessageSent(clientId, messageName, (long)num);
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000B8D4 File Offset: 0x00009AD4
		public void SendNamedMessage(string messageName, IReadOnlyList<ulong> clientIds, FastBufferWriter messageStream, NetworkDelivery networkDelivery = NetworkDelivery.ReliableSequenced)
		{
			if (!this.m_NetworkManager.IsServer)
			{
				throw new InvalidOperationException("Can not send unnamed messages to multiple users as a client");
			}
			if (clientIds == null)
			{
				throw new ArgumentNullException("clientIds", "You must pass in a valid clientId List");
			}
			this.ValidateMessageSize(messageStream, networkDelivery, true);
			ulong hash = 0UL;
			HashSize rpcHashSize = this.m_NetworkManager.NetworkConfig.RpcHashSize;
			if (rpcHashSize != HashSize.VarIntFourBytes)
			{
				if (rpcHashSize == HashSize.VarIntEightBytes)
				{
					hash = messageName.Hash64();
				}
			}
			else
			{
				hash = (ulong)messageName.Hash32();
			}
			if (this.m_NetworkManager.IsHost)
			{
				for (int i = 0; i < clientIds.Count; i++)
				{
					if (clientIds[i] == this.m_NetworkManager.LocalClientId)
					{
						this.InvokeNamedMessage(hash, this.m_NetworkManager.LocalClientId, new FastBufferReader(messageStream, Allocator.None, -1, 0, Allocator.Temp), 0);
					}
				}
			}
			NamedMessage namedMessage = new NamedMessage
			{
				Hash = hash,
				SendData = messageStream
			};
			int num = this.m_NetworkManager.ConnectionManager.SendMessage<NamedMessage, IReadOnlyList<ulong>>(ref namedMessage, networkDelivery, clientIds);
			if (num != 0)
			{
				this.m_NetworkManager.NetworkMetrics.TrackNamedMessageSent(clientIds, messageName, (long)num);
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00004E3E File Offset: 0x0000303E
		private void ValidateMessageSize(FastBufferWriter messageStream, NetworkDelivery networkDelivery, bool isNamed)
		{
		}

		// Token: 0x0400011A RID: 282
		private readonly NetworkManager m_NetworkManager;

		// Token: 0x0400011C RID: 284
		private Dictionary<ulong, CustomMessagingManager.HandleNamedMessageDelegate> m_NamedMessageHandlers32 = new Dictionary<ulong, CustomMessagingManager.HandleNamedMessageDelegate>();

		// Token: 0x0400011D RID: 285
		private Dictionary<ulong, CustomMessagingManager.HandleNamedMessageDelegate> m_NamedMessageHandlers64 = new Dictionary<ulong, CustomMessagingManager.HandleNamedMessageDelegate>();

		// Token: 0x0400011E RID: 286
		private Dictionary<ulong, string> m_MessageHandlerNameLookup32 = new Dictionary<ulong, string>();

		// Token: 0x0400011F RID: 287
		private Dictionary<ulong, string> m_MessageHandlerNameLookup64 = new Dictionary<ulong, string>();

		// Token: 0x0200004D RID: 77
		// (Invoke) Token: 0x0600022D RID: 557
		public delegate void UnnamedMessageDelegate(ulong clientId, FastBufferReader reader);

		// Token: 0x0200004E RID: 78
		// (Invoke) Token: 0x06000231 RID: 561
		public delegate void HandleNamedMessageDelegate(ulong senderClientId, FastBufferReader messagePayload);
	}
}
