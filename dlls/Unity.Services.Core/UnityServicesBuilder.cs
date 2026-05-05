using System;

namespace Unity.Services.Core
{
	// Token: 0x0200000F RID: 15
	internal static class UnityServicesBuilder
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000024A5 File Offset: 0x000006A5
		// (set) Token: 0x0600003F RID: 63 RVA: 0x000024AC File Offset: 0x000006AC
		internal static UnityServicesBuilder.CreationDelegate InstanceCreationDelegate { get; set; }

		// Token: 0x06000040 RID: 64 RVA: 0x000024B4 File Offset: 0x000006B4
		public static IUnityServices Create(string servicesId)
		{
			if (UnityServicesBuilder.InstanceCreationDelegate == null)
			{
				throw new ServicesCreationException("Error creating services. The creation delegate has not been initialized.");
			}
			return UnityServicesBuilder.InstanceCreationDelegate(servicesId);
		}

		// Token: 0x02000014 RID: 20
		// (Invoke) Token: 0x06000048 RID: 72
		internal delegate IUnityServices CreationDelegate(string servicesId);
	}
}
