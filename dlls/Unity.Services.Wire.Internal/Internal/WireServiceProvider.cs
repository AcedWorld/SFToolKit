using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Configuration.Internal;
using Unity.Services.Core.Internal;
using Unity.Services.Core.Scheduler.Internal;
using Unity.Services.Core.Telemetry.Internal;
using Unity.Services.Core.Threading.Internal;
using UnityEngine;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x0200003B RID: 59
	internal class WireServiceProvider : IInitializablePackageV2, IInitializablePackage
	{
		// Token: 0x060000EE RID: 238 RVA: 0x000041A3 File Offset: 0x000023A3
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoad()
		{
			new WireServiceProvider().Register(CorePackageRegistry.Instance);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000041B4 File Offset: 0x000023B4
		public void Register(CorePackageRegistry registry)
		{
			registry.Register<WireServiceProvider>(this).DependsOn<IAccessToken>().DependsOn<IPlayerId>().DependsOn<IActionScheduler>().DependsOn<IUnityThreadUtils>().DependsOn<IMetricsFactory>().DependsOn<IProjectConfiguration>().ProvidesComponent<IWire>();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004201 File Offset: 0x00002401
		public Task Initialize(CoreRegistry registry)
		{
			return this.InitializeComponent(registry);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000420A File Offset: 0x0000240A
		public Task InitializeInstanceAsync(CoreRegistry registry)
		{
			return this.InitializeComponent(registry);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004214 File Offset: 0x00002414
		private Task InitializeComponent(CoreRegistry registry)
		{
			WireServiceProvider.<InitializeComponent>d__6 <InitializeComponent>d__;
			<InitializeComponent>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeComponent>d__.<>4__this = this;
			<InitializeComponent>d__.registry = registry;
			<InitializeComponent>d__.<>1__state = -1;
			<InitializeComponent>d__.<>t__builder.Start<WireServiceProvider.<InitializeComponent>d__6>(ref <InitializeComponent>d__);
			return <InitializeComponent>d__.<>t__builder.Task;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00004260 File Offset: 0x00002460
		internal Configuration GetConfiguration(IAccessToken token, IProjectConfiguration projectCfg)
		{
			string address = "wss://wire.unity3d.com/v2/ws";
			if (((projectCfg != null) ? projectCfg.GetString("com.unity.services.core.cloud-environment", null) : null) == "staging")
			{
				address = "wss://wire-stg.unity3d.com/v2/ws";
			}
			return new Configuration
			{
				token = token,
				address = address
			};
		}

		// Token: 0x040000BB RID: 187
		private const string k_CloudEnvironmentKey = "com.unity.services.core.cloud-environment";

		// Token: 0x040000BC RID: 188
		private const string k_StagingEnvironment = "staging";
	}
}
