using System;
using Unity.Services.Core;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200000C RID: 12
	public static class PlayerAccountService
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000231E File Offset: 0x0000051E
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002337 File Offset: 0x00000537
		public static IPlayerAccountService Instance
		{
			get
			{
				if (PlayerAccountService.s_Instance == null)
				{
					throw new ServicesInitializationException("Singleton is not initialized. Please call UnityServices.InitializeAsync() to initialize. Please make sure Player Accounts is configured in the Unity Editor Settings");
				}
				return PlayerAccountService.s_Instance;
			}
			internal set
			{
				PlayerAccountService.s_Instance = value;
			}
		}

		// Token: 0x04000020 RID: 32
		private static IPlayerAccountService s_Instance;
	}
}
