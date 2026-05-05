using System;
using System.Threading.Tasks;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Configuration.Internal;
using Unity.Services.Core.Internal;
using Unity.Services.Qos.Internal;
using Unity.Services.Relay.Http;
using UnityEngine;

namespace Unity.Services.Relay
{
	// Token: 0x02000008 RID: 8
	internal class RelayServiceProvider : IInitializablePackage
	{
		// Token: 0x0600000E RID: 14 RVA: 0x000022C0 File Offset: 0x000004C0
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Register()
		{
			CoreRegistration coreRegistration = CoreRegistry.Instance.RegisterPackage<RelayServiceProvider>(new RelayServiceProvider());
			coreRegistration.DependsOn<IAccessToken>();
			coreRegistration.DependsOn<IProjectConfiguration>();
			coreRegistration.DependsOn<IQosResults>();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000022F8 File Offset: 0x000004F8
		public Task Initialize(CoreRegistry registry)
		{
			HttpClient httpClient = new HttpClient();
			IAccessToken serviceComponent = registry.GetServiceComponent<IAccessToken>();
			IProjectConfiguration serviceComponent2 = registry.GetServiceComponent<IProjectConfiguration>();
			IQosResults serviceComponent3 = registry.GetServiceComponent<IQosResults>();
			if (serviceComponent != null)
			{
				RelayServiceSdk.Instance = new InternalRelayService(httpClient, serviceComponent2, serviceComponent, serviceComponent3);
			}
			return Task.CompletedTask;
		}
	}
}
