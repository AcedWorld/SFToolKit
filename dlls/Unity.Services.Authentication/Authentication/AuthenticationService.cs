using System;
using Unity.Services.Core;

namespace Unity.Services.Authentication
{
	// Token: 0x02000004 RID: 4
	public static class AuthenticationService
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020C8 File Offset: 0x000002C8
		// (set) Token: 0x06000005 RID: 5 RVA: 0x000020E1 File Offset: 0x000002E1
		public static IAuthenticationService Instance
		{
			get
			{
				if (AuthenticationService.s_Instance == null)
				{
					throw new ServicesInitializationException("Singleton is not initialized. Please call UnityServices.InitializeAsync() to initialize.");
				}
				return AuthenticationService.s_Instance;
			}
			internal set
			{
				AuthenticationService.s_Instance = value;
			}
		}

		// Token: 0x04000001 RID: 1
		private static IAuthenticationService s_Instance;
	}
}
