using System;
using Unity.Netcode;
using UnityEngine;

namespace __GEN
{
	// Token: 0x02000028 RID: 40
	internal class INetworkMessageHelper
	{
		// Token: 0x06000146 RID: 326 RVA: 0x00009EE4 File Offset: 0x000080E4
		[RuntimeInitializeOnLoadMethod]
		internal static void InitializeMessages()
		{
			ILPPMessageProvider.__network_message_types.Add(new NetworkMessageManager.MessageWithHandler
			{
				MessageType = typeof(NetworkTransformMessage),
				Handler = new NetworkMessageManager.MessageHandler(NetworkMessageManager.ReceiveMessage<NetworkTransformMessage>),
				GetVersion = new NetworkMessageManager.VersionGetter(NetworkMessageManager.CreateMessageAndGetVersion<NetworkTransformMessage>)
			});
		}
	}
}
