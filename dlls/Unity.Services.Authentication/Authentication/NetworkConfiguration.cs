using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000042 RID: 66
	internal class NetworkConfiguration : INetworkConfiguration
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00005309 File Offset: 0x00003509
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00005311 File Offset: 0x00003511
		public int Retries { get; set; } = 2;

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600019A RID: 410 RVA: 0x0000531A File Offset: 0x0000351A
		// (set) Token: 0x0600019B RID: 411 RVA: 0x00005322 File Offset: 0x00003522
		public int Timeout { get; set; } = 10;

		// Token: 0x040000CD RID: 205
		private const int k_DefaultRetries = 2;

		// Token: 0x040000CE RID: 206
		private const int k_DefaultTimeout = 10;
	}
}
