using System;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200001D RID: 29
	internal class NetworkConfiguration : INetworkConfiguration
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600008B RID: 139 RVA: 0x0000330C File Offset: 0x0000150C
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00003314 File Offset: 0x00001514
		public int Retries { get; set; } = 2;

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600008D RID: 141 RVA: 0x0000331D File Offset: 0x0000151D
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00003325 File Offset: 0x00001525
		public int Timeout { get; set; } = 5;

		// Token: 0x04000052 RID: 82
		private const int k_DefaultRetries = 2;

		// Token: 0x04000053 RID: 83
		private const int k_DefaultTimeout = 5;
	}
}
