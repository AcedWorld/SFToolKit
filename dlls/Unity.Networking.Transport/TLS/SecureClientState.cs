using System;
using Unity.TLS.LowLevel;

namespace Unity.Networking.Transport.TLS
{
	// Token: 0x0200007F RID: 127
	internal struct SecureClientState
	{
		// Token: 0x04000197 RID: 407
		public unsafe Binding.unitytls_client* ClientPtr;

		// Token: 0x04000198 RID: 408
		public unsafe Binding.unitytls_client_config* ClientConfig;

		// Token: 0x04000199 RID: 409
		public SessionIdToken ReceiveToken;

		// Token: 0x0400019A RID: 410
		public long LastHandshakeUpdate;
	}
}
