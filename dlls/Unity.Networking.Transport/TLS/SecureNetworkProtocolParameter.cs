using System;
using Unity.Collections;

namespace Unity.Networking.Transport.TLS
{
	// Token: 0x02000087 RID: 135
	public struct SecureNetworkProtocolParameter : INetworkParameter
	{
		// Token: 0x06000260 RID: 608 RVA: 0x0000D4B3 File Offset: 0x0000B6B3
		public bool Validate()
		{
			return true;
		}

		// Token: 0x040001BD RID: 445
		public FixedString4096Bytes Pem;

		// Token: 0x040001BE RID: 446
		public FixedString4096Bytes Rsa;

		// Token: 0x040001BF RID: 447
		public FixedString4096Bytes RsaKey;

		// Token: 0x040001C0 RID: 448
		public FixedString32Bytes Hostname;

		// Token: 0x040001C1 RID: 449
		public SecureTransportProtocol Protocol;

		// Token: 0x040001C2 RID: 450
		public SecureClientAuthPolicy ClientAuthenticationPolicy;

		// Token: 0x040001C3 RID: 451
		public uint SSLReadTimeoutMs;

		// Token: 0x040001C4 RID: 452
		public uint SSLHandshakeTimeoutMax;

		// Token: 0x040001C5 RID: 453
		public uint SSLHandshakeTimeoutMin;
	}
}
