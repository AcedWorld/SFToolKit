using System;
using Unity.Netcode;
using UnityEngine;

namespace __GEN
{
	// Token: 0x0200013B RID: 315
	internal class INetworkMessageHelper
	{
		// Token: 0x060009B9 RID: 2489 RVA: 0x000251F8 File Offset: 0x000233F8
		[RuntimeInitializeOnLoadMethod]
		internal static void InitializeMessages()
		{
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(DisconnectReasonMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<DisconnectReasonMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<DisconnectReasonMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(AnticipationCounterSyncPingMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<AnticipationCounterSyncPingMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<AnticipationCounterSyncPingMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(AnticipationCounterSyncPongMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<AnticipationCounterSyncPongMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<AnticipationCounterSyncPongMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(ChangeOwnershipMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<ChangeOwnershipMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<ChangeOwnershipMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(ClientConnectedMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<ClientConnectedMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<ClientConnectedMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(ClientDisconnectedMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<ClientDisconnectedMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<ClientDisconnectedMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(ConnectionApprovedMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<ConnectionApprovedMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<ConnectionApprovedMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(ConnectionRequestMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<ConnectionRequestMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<ConnectionRequestMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(CreateObjectMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<CreateObjectMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<CreateObjectMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(DestroyObjectMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<DestroyObjectMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<DestroyObjectMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(NamedMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<NamedMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<NamedMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(NetworkVariableDeltaMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<NetworkVariableDeltaMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<NetworkVariableDeltaMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(ParentSyncMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<ParentSyncMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<ParentSyncMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(ProxyMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<ProxyMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<ProxyMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(ServerRpcMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<ServerRpcMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<ServerRpcMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(ClientRpcMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<ClientRpcMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<ClientRpcMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(RpcMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<RpcMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<RpcMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(SceneEventMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<SceneEventMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<SceneEventMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(ServerLogMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<ServerLogMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<ServerLogMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(TimeSyncMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<TimeSyncMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<TimeSyncMessage>)
			});
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(UnnamedMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<UnnamedMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<UnnamedMessage>)
			});
		}
	}
}
