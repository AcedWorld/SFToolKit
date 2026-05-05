using System;

namespace Unity.Netcode
{
	// Token: 0x0200006F RID: 111
	internal struct RpcMessage : INetworkMessage
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int Version
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000E193 File Offset: 0x0000C393
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			BytePacker.WriteValuePacked(writer, this.SenderClientId);
			RpcMessageHelpers.Serialize(ref writer, ref this.Metadata, ref this.WriteBuffer);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000E1B4 File Offset: 0x0000C3B4
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			ByteUnpacker.ReadValuePacked(reader, out this.SenderClientId);
			return RpcMessageHelpers.Deserialize(ref reader, ref context, ref this.Metadata, ref this.ReadBuffer);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000E1D8 File Offset: 0x0000C3D8
		public void Handle(ref NetworkContext context)
		{
			__RpcParams _RpcParams = new __RpcParams
			{
				Ext = new RpcParams
				{
					Receive = new RpcReceiveParams
					{
						SenderClientId = this.SenderClientId
					}
				}
			};
			RpcMessageHelpers.Handle(ref context, ref this.Metadata, ref this.ReadBuffer, ref _RpcParams);
		}

		// Token: 0x0400016E RID: 366
		public RpcMetadata Metadata;

		// Token: 0x0400016F RID: 367
		public ulong SenderClientId;

		// Token: 0x04000170 RID: 368
		public FastBufferWriter WriteBuffer;

		// Token: 0x04000171 RID: 369
		public FastBufferReader ReadBuffer;
	}
}
