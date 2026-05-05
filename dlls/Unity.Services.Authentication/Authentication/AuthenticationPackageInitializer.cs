using System;
using System.Threading.Tasks;
using Unity.Services.Authentication.Generated;
using Unity.Services.Authentication.Internal;
using Unity.Services.Authentication.Shared;
using Unity.Services.Core.Configuration.Internal;
using Unity.Services.Core.Environments.Internal;
using Unity.Services.Core.Internal;
using Unity.Services.Core.Scheduler.Internal;
using Unity.Services.Core.Telemetry.Internal;
using UnityEngine;

namespace Unity.Services.Authentication
{
	// Token: 0x02000008 RID: 8
	internal class AuthenticationPackageInitializer : IInitializablePackageV2, IInitializablePackage
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00003DFF File Offset: 0x00001FFF
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoad()
		{
			new AuthenticationPackageInitializer().Register(CorePackageRegistry.Instance);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003E10 File Offset: 0x00002010
		public void Register(CorePackageRegistry registry)
		{
			registry.Register<AuthenticationPackageInitializer>(this).DependsOn<IEnvironments>().DependsOn<IActionScheduler>().DependsOn<ICloudProjectId>().DependsOn<IProjectConfiguration>().DependsOn<IMetricsFactory>().ProvidesComponent<IPlayerId>().ProvidesComponent<IAccessToken>().ProvidesComponent<IAccessTokenObserver>().ProvidesComponent<IEnvironmentId>();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003E6D File Offset: 0x0000206D
		public Task Initialize(CoreRegistry registry)
		{
			AuthenticationService.Instance = this.InitializeService(registry);
			return Task.CompletedTask;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003E80 File Offset: 0x00002080
		public Task InitializeInstanceAsync(CoreRegistry registry)
		{
			this.InitializeService(registry);
			return Task.CompletedTask;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003E90 File Offset: 0x00002090
		private AuthenticationServiceInternal InitializeService(CoreRegistry registry)
		{
			IAuthenticationSettings settings = new AuthenticationSettings();
			IActionScheduler serviceComponent = registry.GetServiceComponent<IActionScheduler>();
			IEnvironments serviceComponent2 = registry.GetServiceComponent<IEnvironments>();
			ICloudProjectId serviceComponent3 = registry.GetServiceComponent<ICloudProjectId>();
			IProjectConfiguration serviceComponent4 = registry.GetServiceComponent<IProjectConfiguration>();
			ProfileComponent profile = new ProfileComponent(this.GetProfile(serviceComponent4));
			AuthenticationMetrics metrics = new AuthenticationMetrics(registry.GetServiceComponent<IMetricsFactory>());
			JwtDecoder jwtDecoder = new JwtDecoder();
			AuthenticationCache cache = new AuthenticationCache(serviceComponent3, profile);
			AccessTokenComponent accessToken = new AccessTokenComponent();
			EnvironmentIdComponent environmentId = new EnvironmentIdComponent();
			PlayerIdComponent playerId = new PlayerIdComponent(cache);
			PlayerNameComponent playerName = new PlayerNameComponent(cache);
			SessionTokenComponent sessionToken = new SessionTokenComponent(cache);
			NetworkConfiguration configuration = new NetworkConfiguration();
			NetworkHandler networkHandler = new NetworkHandler(configuration);
			string playerAuthHost = this.GetPlayerAuthHost(serviceComponent4);
			PlayerNamesApi playerNamesApi = new PlayerNamesApi(new AuthenticationApiClient(configuration), new ApiConfiguration
			{
				BasePath = this.GetPlayerNamesHost(serviceComponent4)
			});
			AuthenticationNetworkClient networkClient = new AuthenticationNetworkClient(playerAuthHost, serviceComponent3, serviceComponent2, networkHandler, accessToken);
			AuthenticationServiceInternal authenticationServiceInternal = new AuthenticationServiceInternal(settings, networkClient, playerNamesApi, profile, jwtDecoder, cache, serviceComponent, metrics, accessToken, environmentId, playerId, playerName, sessionToken, serviceComponent2);
			registry.RegisterService<IAuthenticationService>(authenticationServiceInternal);
			registry.RegisterServiceComponent<IAccessToken>(authenticationServiceInternal.AccessTokenComponent);
			registry.RegisterServiceComponent<IAccessTokenObserver>(authenticationServiceInternal.AccessTokenComponent);
			registry.RegisterServiceComponent<IEnvironmentId>(authenticationServiceInternal.EnvironmentIdComponent);
			registry.RegisterServiceComponent<IPlayerId>(authenticationServiceInternal.PlayerIdComponent);
			return authenticationServiceInternal;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003FB8 File Offset: 0x000021B8
		private string GetProfile(IProjectConfiguration projectConfiguration)
		{
			return projectConfiguration.GetString("com.unity.services.authentication.profile", "default");
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003FCA File Offset: 0x000021CA
		private string GetPlayerAuthHost(IProjectConfiguration projectConfiguration)
		{
			if (((projectConfiguration != null) ? projectConfiguration.GetString("com.unity.services.core.cloud-environment", null) : null) == "staging")
			{
				return "https://player-auth-stg.services.api.unity.com";
			}
			return "https://player-auth.services.api.unity.com";
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003FF5 File Offset: 0x000021F5
		private string GetPlayerNamesHost(IProjectConfiguration projectConfiguration)
		{
			if (((projectConfiguration != null) ? projectConfiguration.GetString("com.unity.services.core.cloud-environment", null) : null) == "staging")
			{
				return "https://social-stg.services.api.unity.com/v1";
			}
			return "https://social.services.api.unity.com/v1";
		}

		// Token: 0x0400002C RID: 44
		private const string k_CloudEnvironmentKey = "com.unity.services.core.cloud-environment";

		// Token: 0x0400002D RID: 45
		private const string k_StagingEnvironment = "staging";

		// Token: 0x0400002E RID: 46
		private const string k_DefaultProfile = "default";

		// Token: 0x0400002F RID: 47
		private const string k_EditorModeArg = "-editor-mode";

		// Token: 0x04000030 RID: 48
		private const string k_NameArg = "-name";
	}
}
