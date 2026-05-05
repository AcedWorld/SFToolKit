using System;
using System.Threading.Tasks;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Configuration.Internal;
using Unity.Services.Core.Internal;
using Unity.Services.Core.Telemetry.Internal;
using Unity.Services.Qos.Http;
using Unity.Services.Qos.Internal;
using Unity.Services.Qos.Runner;
using Unity.Services.Qos.V2;
using Unity.Services.Qos.V2.Apis.QosDiscovery;
using Unity.Services.Qos.V2.Http;
using UnityEngine;

namespace Unity.Services.Qos
{
	// Token: 0x02000013 RID: 19
	internal class QosPackageInitializer : IInitializablePackageV2, IInitializablePackage
	{
		// Token: 0x0600004B RID: 75 RVA: 0x00003647 File Offset: 0x00001847
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		internal static void InitializeOnLoad()
		{
			new QosPackageInitializer().Register(CorePackageRegistry.Instance);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003658 File Offset: 0x00001858
		public void Register(CorePackageRegistry registry)
		{
			registry.Register<QosPackageInitializer>(this).DependsOn<IAccessToken>().DependsOn<IMetricsFactory>().DependsOn<IProjectConfiguration>().ProvidesComponent<IQosResults>().ProvidesComponent<IQosServiceComponent>();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003698 File Offset: 0x00001898
		internal void Register(CoreRegistry registry)
		{
			registry.RegisterPackage<QosPackageInitializer>(this).DependsOn<IAccessToken>().DependsOn<IMetricsFactory>().DependsOn<IProjectConfiguration>().ProvidesComponent<IQosResults>().ProvidesComponent<IQosServiceComponent>();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000036D5 File Offset: 0x000018D5
		public Task Initialize(CoreRegistry registry)
		{
			QosService.Instance = this.InitializeService(registry);
			return Task.CompletedTask;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000036E8 File Offset: 0x000018E8
		public Task InitializeInstanceAsync(CoreRegistry registry)
		{
			this.InitializeService(registry);
			return Task.CompletedTask;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000036F8 File Offset: 0x000018F8
		private IQosService InitializeService(CoreRegistry registry)
		{
			IProjectConfiguration serviceComponent = registry.GetServiceComponent<IProjectConfiguration>();
			IAccessToken serviceComponent2 = registry.GetServiceComponent<IAccessToken>();
			IMetrics metrics = registry.GetServiceComponent<IMetricsFactory>().Create("com.unity.services.qos");
			Unity.Services.Qos.Http.HttpClient httpClient = new Unity.Services.Qos.Http.HttpClient();
			InternalQosDiscoveryService internalQosDiscoveryService = new InternalQosDiscoveryService(this.GetHost(serviceComponent), httpClient, serviceComponent2);
			Unity.Services.Qos.V2.Http.IHttpClient httpClient2 = new Unity.Services.Qos.V2.Http.HttpClient();
			Configuration configuration = new Configuration(this.GetHost(serviceComponent), new int?(10), new int?(4), null);
			QosDiscoveryApiClient qosDiscoveryApiClientV = new QosDiscoveryApiClient(httpClient2, serviceComponent2, configuration);
			WrappedQosService wrappedQosService = new WrappedQosService(internalQosDiscoveryService.QosDiscoveryApi, qosDiscoveryApiClientV, new BaselibQosRunner(null, null), serviceComponent2, metrics);
			registry.RegisterService<IQosService>(wrappedQosService);
			registry.RegisterServiceComponent<IQosResults>(new QosResults(wrappedQosService));
			registry.RegisterServiceComponent<IQosServiceComponent>(new QosServiceComponent(wrappedQosService));
			return wrappedQosService;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000379E File Offset: 0x0000199E
		private string GetHost(IProjectConfiguration projectConfiguration)
		{
			if (((projectConfiguration != null) ? projectConfiguration.GetString("com.unity.services.core.cloud-environment", null) : null) == "staging")
			{
				return "https://qos-discovery-stg.services.api.unity.com";
			}
			return "https://qos-discovery.services.api.unity.com";
		}

		// Token: 0x0400004A RID: 74
		private const string k_CloudEnvironmentKey = "com.unity.services.core.cloud-environment";

		// Token: 0x0400004B RID: 75
		private const string k_PackageName = "com.unity.services.qos";

		// Token: 0x0400004C RID: 76
		private const string k_StagingEnvironment = "staging";
	}
}
