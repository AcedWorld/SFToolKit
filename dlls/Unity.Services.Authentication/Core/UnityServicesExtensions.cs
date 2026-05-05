using System;
using Unity.Services.Authentication;

namespace Unity.Services.Core
{
	// Token: 0x02000003 RID: 3
	public static class UnityServicesExtensions
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		public static IAuthenticationService GetAuthenticationService(this IUnityServices unityServices)
		{
			return unityServices.GetService<IAuthenticationService>();
		}
	}
}
