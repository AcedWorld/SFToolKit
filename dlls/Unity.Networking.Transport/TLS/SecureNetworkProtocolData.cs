using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.Transport.TLS
{
	// Token: 0x02000080 RID: 128
	internal struct SecureNetworkProtocolData
	{
		// Token: 0x0400019B RID: 411
		public UnsafeHashMap<NetworkInterfaceEndPoint, SecureClientState> SecureClients;

		// Token: 0x0400019C RID: 412
		public FixedString4096Bytes Pem;

		// Token: 0x0400019D RID: 413
		public FixedString4096Bytes Rsa;

		// Token: 0x0400019E RID: 414
		public FixedString4096Bytes RsaKey;

		// Token: 0x0400019F RID: 415
		public FixedString32Bytes Hostname;

		// Token: 0x040001A0 RID: 416
		public uint Protocol;

		// Token: 0x040001A1 RID: 417
		public uint SSLReadTimeoutMs;

		// Token: 0x040001A2 RID: 418
		public uint SSLHandshakeTimeoutMax;

		// Token: 0x040001A3 RID: 419
		public uint SSLHandshakeTimeoutMin;

		// Token: 0x040001A4 RID: 420
		public uint ClientAuth;

		// Token: 0x040001A5 RID: 421
		public long LastUpdate;

		// Token: 0x040001A6 RID: 422
		public long LastHalfOpenPrune;
	}
}
