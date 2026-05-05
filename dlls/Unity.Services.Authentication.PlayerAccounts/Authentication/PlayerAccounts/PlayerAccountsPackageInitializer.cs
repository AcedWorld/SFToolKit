using System;
using System.Threading.Tasks;
using Unity.Services.Core.Configuration.Internal;
using Unity.Services.Core.Internal;
using UnityEngine;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200000E RID: 14
	internal class PlayerAccountsPackageInitializer : IInitializablePackageV2, IInitializablePackage
	{
		// Token: 0x06000049 RID: 73 RVA: 0x000029FD File Offset: 0x00000BFD
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoad()
		{
			new PlayerAccountsPackageInitializer().Register(CorePackageRegistry.Instance);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002A10 File Offset: 0x00000C10
		public void Register(CorePackageRegistry registry)
		{
			registry.Register<PlayerAccountsPackageInitializer>(this).DependsOn<ICloudProjectId>();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002A2D File Offset: 0x00000C2D
		public Task Initialize(CoreRegistry registry)
		{
			PlayerAccountService.Instance = this.InitializeService(registry);
			return Task.CompletedTask;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002A40 File Offset: 0x00000C40
		public Task InitializeInstanceAsync(CoreRegistry registry)
		{
			this.InitializeService(registry);
			return Task.CompletedTask;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002A50 File Offset: 0x00000C50
		private PlayerAccountServiceInternal InitializeService(CoreRegistry registry)
		{
			UnityPlayerAccountSettings unityPlayerAccountSettings = UnityPlayerAccountSettings.Load();
			if (unityPlayerAccountSettings == null)
			{
				return null;
			}
			NetworkHandler networkingClient = new NetworkHandler();
			JwtDecoder jwtDecoder = new JwtDecoder(new DateTimeWrapper());
			ICloudProjectId serviceComponent = registry.GetServiceComponent<ICloudProjectId>();
			PlayerAccountServiceInternal playerAccountServiceInternal = new PlayerAccountServiceInternal(unityPlayerAccountSettings, serviceComponent, jwtDecoder, networkingClient);
			registry.RegisterService<IPlayerAccountService>(playerAccountServiceInternal);
			return playerAccountServiceInternal;
		}
	}
}
