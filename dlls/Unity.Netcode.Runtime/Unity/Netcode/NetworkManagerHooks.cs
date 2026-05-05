using System;
using Unity.Netcode.Transports.UTP;

namespace Unity.Netcode
{
	// Token: 0x02000076 RID: 118
	internal class NetworkManagerHooks : INetworkHooks
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x0000E459 File Offset: 0x0000C659
		internal NetworkManagerHooks(NetworkManager manager)
		{
			this.m_NetworkManager = manager;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeSendMessage<T>(ulong clientId, ref T message, NetworkDelivery delivery) where T : INetworkMessage
		{
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterSendMessage<T>(ulong clientId, ref T message, NetworkDelivery delivery, int messageSizeBytes) where T : INetworkMessage
		{
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeReceiveMessage(ulong senderId, Type messageType, int messageSizeBytes)
		{
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterReceiveMessage(ulong senderId, Type messageType, int messageSizeBytes)
		{
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeSendBatch(ulong clientId, int messageCount, int batchSizeInBytes, NetworkDelivery delivery)
		{
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterSendBatch(ulong clientId, int messageCount, int batchSizeInBytes, NetworkDelivery delivery)
		{
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeReceiveBatch(ulong senderId, int messageCount, int batchSizeInBytes)
		{
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterReceiveBatch(ulong senderId, int messageCount, int batchSizeInBytes)
		{
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000E468 File Offset: 0x0000C668
		public bool OnVerifyCanSend(ulong destinationId, Type messageType, NetworkDelivery delivery)
		{
			return !this.m_NetworkManager.MessageManager.StopProcessing;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000E480 File Offset: 0x0000C680
		public bool OnVerifyCanReceive(ulong senderId, Type messageType, FastBufferReader messageContent, ref NetworkContext context)
		{
			if (this.m_NetworkManager.IsServer)
			{
				if (messageType == typeof(ConnectionApprovedMessage))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						string transportErrorMessage = NetworkManagerHooks.GetTransportErrorMessage(messageContent, this.m_NetworkManager);
						NetworkLog.LogError("A ConnectionApprovedMessage was received from a client on the server side. " + transportErrorMessage);
					}
					return false;
				}
				PendingClient pendingClient;
				if (this.m_NetworkManager.ConnectionManager.PendingClients.TryGetValue(senderId, out pendingClient) && (pendingClient.ConnectionState == PendingClient.State.PendingApproval || (pendingClient.ConnectionState == PendingClient.State.PendingConnection && messageType != typeof(ConnectionRequestMessage))))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning(string.Format("Message received from {0}={1} before it has been accepted.", "senderId", senderId));
					}
					return false;
				}
				NetworkClient networkClient;
				if (this.m_NetworkManager.ConnectedClients.TryGetValue(senderId, out networkClient) && messageType == typeof(ConnectionRequestMessage))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						string transportErrorMessage2 = NetworkManagerHooks.GetTransportErrorMessage(messageContent, this.m_NetworkManager);
						NetworkLog.LogError("A ConnectionRequestMessage was received from a client when the connection has already been established. " + transportErrorMessage2);
					}
					return false;
				}
			}
			else
			{
				if (messageType == typeof(ConnectionRequestMessage))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						string transportErrorMessage3 = NetworkManagerHooks.GetTransportErrorMessage(messageContent, this.m_NetworkManager);
						NetworkLog.LogError("A ConnectionRequestMessage was received from the server on the client side. " + transportErrorMessage3);
					}
					return false;
				}
				if (this.m_NetworkManager.IsConnectedClient && messageType == typeof(ConnectionApprovedMessage))
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						string transportErrorMessage4 = NetworkManagerHooks.GetTransportErrorMessage(messageContent, this.m_NetworkManager);
						NetworkLog.LogError("A ConnectionApprovedMessage was received from the server when the connection has already been established. " + transportErrorMessage4);
					}
					return false;
				}
			}
			return !this.m_NetworkManager.MessageManager.StopProcessing;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000E624 File Offset: 0x0000C824
		private static string GetTransportErrorMessage(FastBufferReader messageContent, NetworkManager networkManager)
		{
			if (!(networkManager.NetworkConfig.NetworkTransport is UnityTransport))
			{
				return string.Format("NetworkTransport: {0}. Please report this to the maintainer of transport layer.", networkManager.NetworkConfig.NetworkTransport.GetType());
			}
			string transportVersion = NetworkManagerHooks.GetTransportVersion(networkManager);
			return string.Format("{0}. This should not happen. Please report this to the Netcode for GameObjects team at https://github.com/Unity-Technologies/com.unity.netcode.gameobjects/issues and include the following data: Message Size: {1}. Message Content: {2}", transportVersion, messageContent.Length, NetworkMessageManager.ByteArrayToString(messageContent.ToArray(), 0, messageContent.Length));
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000E690 File Offset: 0x0000C890
		private static string GetTransportVersion(NetworkManager networkManager)
		{
			string str = "NetworkTransport: ";
			Type type = networkManager.NetworkConfig.NetworkTransport.GetType();
			string text = str + ((type != null) ? type.ToString() : null);
			UnityTransport unityTransport = networkManager.NetworkConfig.NetworkTransport as UnityTransport;
			if (unityTransport != null)
			{
				text = text + " UnityTransportProtocol: " + unityTransport.Protocol.ToString();
			}
			return text;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnBeforeHandleMessage<T>(ref T message, ref NetworkContext context) where T : INetworkMessage
		{
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00004E3E File Offset: 0x0000303E
		public void OnAfterHandleMessage<T>(ref T message, ref NetworkContext context) where T : INetworkMessage
		{
		}

		// Token: 0x04000184 RID: 388
		private NetworkManager m_NetworkManager;
	}
}
