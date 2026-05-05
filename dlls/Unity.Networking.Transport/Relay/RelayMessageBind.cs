using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x0200008A RID: 138
	internal static class RelayMessageBind
	{
		// Token: 0x0600026F RID: 623 RVA: 0x0000D9C4 File Offset: 0x0000BBC4
		internal unsafe static void Write(DataStreamWriter writer, byte acceptMode, ushort nonce, byte* connectionDataPtr, byte* hmac)
		{
			RelayMessageHeader relayMessageHeader = RelayMessageHeader.Create(RelayMessageType.Bind);
			writer.WriteBytes((byte*)(&relayMessageHeader), 4);
			writer.WriteByte(acceptMode);
			writer.WriteUShort(nonce);
			writer.WriteByte(byte.MaxValue);
			writer.WriteBytes(connectionDataPtr, 255);
			writer.WriteBytes(hmac, 32);
		}

		// Token: 0x040001CA RID: 458
		private const byte k_ConnectionDataLength = 255;

		// Token: 0x040001CB RID: 459
		private const byte k_HMACLength = 32;

		// Token: 0x040001CC RID: 460
		public const int Length = 295;
	}
}
