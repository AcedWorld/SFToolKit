using System;

namespace Unity.Netcode
{
	// Token: 0x0200006D RID: 109
	internal struct ServerRpcMessage : INetworkMessage
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600029B RID: 667 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000E098 File Offset: 0x0000C298
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			RpcMessageHelpers.Serialize(ref writer, ref this.Metadata, ref this.WriteBuffer);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000E0AD File Offset: 0x0000C2AD
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			return RpcMessageHelpers.Deserialize(ref reader, ref context, ref this.Metadata, ref this.ReadBuffer);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000E0C4 File Offset: 0x0000C2C4
		public void Handle(ref NetworkContext context)
		{
			__RpcParams _RpcParams = new __RpcParams
			{
				Server = new ServerRpcParams
				{
					Receive = new ServerRpcReceiveParams
					{
						SenderClientId = context.SenderId
					}
				}
			};
			RpcMessageHelpers.Handle(ref context, ref this.Metadata, ref this.ReadBuffer, ref _RpcParams);
		}

		// Token: 0x04000168 RID: 360
		public RpcMetadata Metadata;

		// Token: 0x04000169 RID: 361
		public FastBufferWriter WriteBuffer;

		// Token: 0x0400016A RID: 362
		public FastBufferReader ReadBuffer;
	}
}
