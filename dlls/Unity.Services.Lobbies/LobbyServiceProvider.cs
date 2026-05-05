using System;
using System.Threading.Tasks;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Internal;
using Unity.Services.Core.Telemetry.Internal;
using Unity.Services.Lobbies.Http;
using Unity.Services.Vivox.Internal;
using Unity.Services.Wire.Internal;
using UnityEngine;

namespace Unity.Services.Lobbies
{
	// Token: 0x0200000A RID: 10
	internal class LobbyServiceProvider : IInitializablePackage
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00004644 File Offset: 0x00002844
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Register()
		{
			CoreRegistry.Instance.RegisterPackage<LobbyServiceProvider>(new LobbyServiceProvider()).DependsOn<IAccessToken>().DependsOn<IMetricsFactory>().OptionallyDependsOn<IWire>().OptionallyDependsOn<IEnvironmentId>().OptionallyDependsOn<IVivox>();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000468C File Offset: 0x0000288C
		public Task Initialize(CoreRegistry registry)
		{
			HttpClient httpClient = new HttpClient();
			bool serviceComponent = registry.GetServiceComponent<IAccessToken>() != null;
			IWire serviceComponent2 = registry.GetServiceComponent<IWire>();
			if (serviceComponent2 == null)
			{
				Logger.LogWarning("The IWire component is not available. LobbyEvents functionality unavailable.");
			}
			if (serviceComponent)
			{
				IMetrics metrics = registry.GetServiceComponent<IMetricsFactory>().Create("com.unity.services.lobby");
				LobbyServiceSdk.Instance = new InternalLobbyService(httpClient, registry.GetServiceComponent<IAccessToken>(), serviceComponent2, metrics);
			}
			return Task.CompletedTask;
		}

		// Token: 0x04000016 RID: 22
		private const string k_PackageName = "com.unity.services.lobby";
	}
}
