using System;

namespace Unity.Netcode
{
	// Token: 0x0200006E RID: 110
	internal struct ClientRpcMessage : INetworkMessage
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600029F RID: 671 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000E11C File Offset: 0x0000C31C
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			RpcMessageHelpers.Serialize(ref writer, ref this.Metadata, ref this.WriteBuffer);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000E131 File Offset: 0x0000C331
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			return RpcMessageHelpers.Deserialize(ref reader, ref context, ref this.Metadata, ref this.ReadBuffer);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000E148 File Offset: 0x0000C348
		public void Handle(ref NetworkContext context)
		{
			__RpcParams _RpcParams = new __RpcParams
			{
				Client = new ClientRpcParams
				{
					Receive = default(ClientRpcReceiveParams)
				}
			};
			RpcMessageHelpers.Handle(ref context, ref this.Metadata, ref this.ReadBuffer, ref _RpcParams);
		}

		// Token: 0x0400016B RID: 363
		public RpcMetadata Metadata;

		// Token: 0x0400016C RID: 364
		public FastBufferWriter WriteBuffer;

		// Token: 0x0400016D RID: 365
		public FastBufferReader ReadBuffer;
	}
}
