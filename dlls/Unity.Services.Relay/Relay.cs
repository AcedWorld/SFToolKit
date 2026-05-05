using System;

namespace Unity.Services.Relay
{
	// Token: 0x02000013 RID: 19
	public static class Relay
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002636 File Offset: 0x00000836
		public static IRelayServiceSDK Instance
		{
			get
			{
				return (IRelayServiceSDK)RelayService.Instance;
			}
		}
	}
}
