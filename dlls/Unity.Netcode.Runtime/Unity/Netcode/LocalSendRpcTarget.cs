using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Netcode
{
	// Token: 0x02000098 RID: 152
	internal class LocalSendRpcTarget : BaseRpcTarget
	{
		// Token: 0x06000323 RID: 803 RVA: 0x00004E3E File Offset: 0x0000303E
		public override void Dispose()
		{
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00010110 File Offset: 0x0000E310
		internal override void Send(NetworkBehaviour behaviour, ref RpcMessage message, NetworkDelivery delivery, RpcParams rpcParams)
		{
			NetworkManager networkManager = behaviour.NetworkManager;
			NetworkContext networkContext = new NetworkContext
			{
				SenderId = this.m_NetworkManager.LocalClientId,
				Timestamp = networkManager.RealTimeProvider.RealTimeSinceStartup,
				SystemOwner = networkManager,
				Header = default(NetworkMessageHeader),
				SerializedHeaderSize = 0,
				MessageSize = 0U
			};
			if (rpcParams.Send.LocalDeferMode == LocalDeferMode.Defer)
			{
				using (FastBufferWriter writer = new FastBufferWriter(message.WriteBuffer.Length + UnsafeUtility.SizeOf<RpcMetadata>(), Allocator.Temp, int.MaxValue))
				{
					message.Serialize(writer, message.Version);
					using (FastBufferReader reader = new FastBufferReader(writer, Allocator.None, -1, 0, Allocator.Temp))
					{
						networkContext.Header = new NetworkMessageHeader
						{
							MessageSize = (uint)reader.Length,
							MessageType = this.m_NetworkManager.MessageManager.GetMessageType(typeof(RpcMessage))
						};
						behaviour.NetworkManager.DeferredMessageManager.DeferMessage(IDeferredNetworkMessageManager.TriggerType.OnNextFrame, 0UL, reader, ref networkContext);
						int length = reader.Length;
						return;
					}
				}
			}
			using (FastBufferReader readBuffer = new FastBufferReader(message.WriteBuffer, Allocator.None, -1, 0, Allocator.Temp))
			{
				message.ReadBuffer = readBuffer;
				message.Handle(ref networkContext);
				int length2 = readBuffer.Length;
			}
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00010076 File Offset: 0x0000E276
		internal LocalSendRpcTarget(NetworkManager manager) : base(manager)
		{
		}
	}
}
