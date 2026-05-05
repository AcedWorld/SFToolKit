using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Unity.Services.Core.Configuration;
using Unity.Services.Core.Configuration.Internal;
using Unity.Services.Core.Device;
using Unity.Services.Core.Device.Internal;
using Unity.Services.Core.Environments.Internal;
using Unity.Services.Core.Internal;
using Unity.Services.Core.Internal.Serialization;
using Unity.Services.Core.Scheduler.Internal;
using Unity.Services.Core.Telemetry.Internal;
using Unity.Services.Core.Threading.Internal;
using UnityEngine;

namespace Unity.Services.Core.Registration
{
	// Token: 0x02000003 RID: 3
	internal class CorePackageInitializer : IInitializablePackageV2, IInitializablePackage, IDiagnosticsComponentProvider
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020B8 File Offset: 0x000002B8
		// (set) Token: 0x06000004 RID: 4 RVA: 0x000020C0 File Offset: 0x000002C0
		internal ActionScheduler ActionScheduler { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020C9 File Offset: 0x000002C9
		// (set) Token: 0x06000006 RID: 6 RVA: 0x000020D1 File Offset: 0x000002D1
		internal InstallationId InstallationId { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020DA File Offset: 0x000002DA
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020E2 File Offset: 0x000002E2
		internal ProjectConfiguration ProjectConfig { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020EB File Offset: 0x000002EB
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000020F3 File Offset: 0x000002F3
		internal Environments Environments { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020FC File Offset: 0x000002FC
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00002104 File Offset: 0x00000304
		internal ExternalUserId ExternalUserId { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000210D File Offset: 0x0000030D
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002115 File Offset: 0x00000315
		internal ICloudProjectId CloudProjectId { get; private set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000F RID: 15 RVA: 0x0000211E File Offset: 0x0000031E
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002126 File Offset: 0x00000326
		internal IDiagnosticsFactory DiagnosticsFactory { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000212F File Offset: 0x0000032F
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002137 File Offset: 0x00000337
		internal IMetricsFactory MetricsFactory { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002140 File Offset: 0x00000340
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002148 File Offset: 0x00000348
		internal UnityThreadUtilsInternal UnityThreadUtils { get; private set; }

		// Token: 0x06000015 RID: 21 RVA: 0x00002151 File Offset: 0x00000351
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoad()
		{
			new CorePackageInitializer(new NewtonsoftSerializer(null)).Register(CorePackageRegistry.Instance);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002168 File Offset: 0x00000368
		public void Register(CorePackageRegistry registry)
		{
			CoreDiagnostics.Instance.DiagnosticsComponentProvider = this;
			registry.Register<CorePackageInitializer>(this).ProvidesComponent<IInstallationId>().ProvidesComponent<ICloudProjectId>().ProvidesComponent<IActionScheduler>().ProvidesComponent<IEnvironments>().ProvidesComponent<IProjectConfiguration>().ProvidesComponent<IMetricsFactory>().ProvidesComponent<IDiagnosticsFactory>().ProvidesComponent<IUnityThreadUtils>().ProvidesComponent<IExternalUserId>();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000021D0 File Offset: 0x000003D0
		public CorePackageInitializer()
		{
			this.m_Serializer = new NewtonsoftSerializer(null);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000021E4 File Offset: 0x000003E4
		public CorePackageInitializer(IJsonSerializer serializer)
		{
			this.m_Serializer = serializer;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000021F3 File Offset: 0x000003F3
		public Task Initialize(CoreRegistry registry)
		{
			this.m_Registry = registry;
			return this.InitializeComponents();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002202 File Offset: 0x00000402
		public Task InitializeInstanceAsync(CoreRegistry registry)
		{
			this.m_Registry = registry;
			return this.InitializeComponents();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002214 File Offset: 0x00000414
		private Task InitializeComponents()
		{
			CorePackageInitializer.<InitializeComponents>d__47 <InitializeComponents>d__;
			<InitializeComponents>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeComponents>d__.<>4__this = this;
			<InitializeComponents>d__.<>1__state = -1;
			<InitializeComponents>d__.<>t__builder.Start<CorePackageInitializer.<InitializeComponents>d__47>(ref <InitializeComponents>d__);
			return <InitializeComponents>d__.<>t__builder.Task;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002257 File Offset: 0x00000457
		private bool HaveInitOptionsChanged()
		{
			return this.m_CurrentInitializationOptions != null && !this.m_CurrentInitializationOptions.Values.ValueEquals(this.m_Registry.Options.Values);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002286 File Offset: 0x00000486
		private void FreeOptionsDependantComponents()
		{
			this.ProjectConfig = null;
			this.Environments = null;
			this.DiagnosticsFactory = null;
			this.MetricsFactory = null;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000022A4 File Offset: 0x000004A4
		internal void InitializeInstallationId()
		{
			if (this.InstallationId != null)
			{
				return;
			}
			InstallationId installationId = new InstallationId();
			installationId.CreateIdentifier();
			this.InstallationId = installationId;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000022D0 File Offset: 0x000004D0
		internal void InitializeActionScheduler()
		{
			if (this.ActionScheduler != null)
			{
				return;
			}
			ActionScheduler actionScheduler = new ActionScheduler();
			actionScheduler.JoinPlayerLoopSystem();
			this.ActionScheduler = actionScheduler;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000022FC File Offset: 0x000004FC
		internal Task InitializeProjectConfigAsync([NotNull] InitializationOptions options)
		{
			CorePackageInitializer.<InitializeProjectConfigAsync>d__52 <InitializeProjectConfigAsync>d__;
			<InitializeProjectConfigAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeProjectConfigAsync>d__.<>4__this = this;
			<InitializeProjectConfigAsync>d__.options = options;
			<InitializeProjectConfigAsync>d__.<>1__state = -1;
			<InitializeProjectConfigAsync>d__.<>t__builder.Start<CorePackageInitializer.<InitializeProjectConfigAsync>d__52>(ref <InitializeProjectConfigAsync>d__);
			return <InitializeProjectConfigAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002348 File Offset: 0x00000548
		internal Task<ProjectConfiguration> GenerateProjectConfigurationAsync([NotNull] InitializationOptions options)
		{
			CorePackageInitializer.<GenerateProjectConfigurationAsync>d__53 <GenerateProjectConfigurationAsync>d__;
			<GenerateProjectConfigurationAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ProjectConfiguration>.Create();
			<GenerateProjectConfigurationAsync>d__.<>4__this = this;
			<GenerateProjectConfigurationAsync>d__.options = options;
			<GenerateProjectConfigurationAsync>d__.<>1__state = -1;
			<GenerateProjectConfigurationAsync>d__.<>t__builder.Start<CorePackageInitializer.<GenerateProjectConfigurationAsync>d__53>(ref <GenerateProjectConfigurationAsync>d__);
			return <GenerateProjectConfigurationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002394 File Offset: 0x00000594
		internal static Task<SerializableProjectConfiguration> GetSerializedConfigOrEmptyAsync()
		{
			CorePackageInitializer.<GetSerializedConfigOrEmptyAsync>d__54 <GetSerializedConfigOrEmptyAsync>d__;
			<GetSerializedConfigOrEmptyAsync>d__.<>t__builder = AsyncTaskMethodBuilder<SerializableProjectConfiguration>.Create();
			<GetSerializedConfigOrEmptyAsync>d__.<>1__state = -1;
			<GetSerializedConfigOrEmptyAsync>d__.<>t__builder.Start<CorePackageInitializer.<GetSerializedConfigOrEmptyAsync>d__54>(ref <GetSerializedConfigOrEmptyAsync>d__);
			return <GetSerializedConfigOrEmptyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000023D0 File Offset: 0x000005D0
		internal void InitializeExternalUserId(IProjectConfiguration projectConfiguration)
		{
			if (UnityServices.ExternalUserId == null)
			{
				string @string = projectConfiguration.GetString("com.unity.services.core.analytics-user-id", null);
				if (!string.IsNullOrEmpty(@string))
				{
					UnityServices.ExternalUserId = @string;
				}
			}
			if (this.ExternalUserId != null)
			{
				return;
			}
			this.ExternalUserId = new ExternalUserId();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002414 File Offset: 0x00000614
		internal void InitializeEnvironments(IProjectConfiguration projectConfiguration)
		{
			if (this.Environments != null)
			{
				return;
			}
			string @string = projectConfiguration.GetString("com.unity.services.core.environment-name", "production");
			this.Environments = new Environments
			{
				Current = @string
			};
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000244D File Offset: 0x0000064D
		internal void InitializeMetrics()
		{
			if (this.MetricsFactory != null)
			{
				return;
			}
			this.MetricsFactory = new MetricsFactory();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002463 File Offset: 0x00000663
		internal void InitializeDiagnostics()
		{
			if (this.DiagnosticsFactory != null)
			{
				return;
			}
			this.DiagnosticsFactory = new DiagnosticsFactory();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002479 File Offset: 0x00000679
		internal void InitializeCloudProjectId(ICloudProjectId cloudProjectId = null)
		{
			if (this.CloudProjectId != null)
			{
				return;
			}
			this.CloudProjectId = (cloudProjectId ?? new CloudProjectId());
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002494 File Offset: 0x00000694
		internal void InitializeUnityThreadUtils()
		{
			if (this.UnityThreadUtils != null)
			{
				return;
			}
			this.UnityThreadUtils = new UnityThreadUtilsInternal();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000024AC File Offset: 0x000006AC
		public Task<IDiagnosticsFactory> CreateDiagnosticsComponents()
		{
			CorePackageInitializer.<CreateDiagnosticsComponents>d__61 <CreateDiagnosticsComponents>d__;
			<CreateDiagnosticsComponents>d__.<>t__builder = AsyncTaskMethodBuilder<IDiagnosticsFactory>.Create();
			<CreateDiagnosticsComponents>d__.<>4__this = this;
			<CreateDiagnosticsComponents>d__.<>1__state = -1;
			<CreateDiagnosticsComponents>d__.<>t__builder.Start<CorePackageInitializer.<CreateDiagnosticsComponents>d__61>(ref <CreateDiagnosticsComponents>d__);
			return <CreateDiagnosticsComponents>d__.<>t__builder.Task;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000024F0 File Offset: 0x000006F0
		[Conditional("ENABLE_UNITY_SERVICES_CORE_VERBOSE_LOGGING")]
		private void LogInitializationInfoJson()
		{
			JObject jobject = new JObject();
			JObject jobject2 = JObject.Parse(this.m_Serializer.SerializeObject<IReadOnlyDictionary<string, string>>(this.DiagnosticsFactory.CommonTags));
			JObject value = JObject.Parse(this.ProjectConfig.ToJson());
			JObject content = JObject.Parse("{\"installation_id\": \"" + this.InstallationId.Identifier + "\"}");
			jobject2.Merge(content);
			jobject.Add("CommonSettings", jobject2);
			jobject.Add("ServicesRuntimeSettings", value);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002570 File Offset: 0x00000770
		public Task<string> GetSerializedProjectConfigurationAsync()
		{
			CorePackageInitializer.<GetSerializedProjectConfigurationAsync>d__63 <GetSerializedProjectConfigurationAsync>d__;
			<GetSerializedProjectConfigurationAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<GetSerializedProjectConfigurationAsync>d__.<>4__this = this;
			<GetSerializedProjectConfigurationAsync>d__.<>1__state = -1;
			<GetSerializedProjectConfigurationAsync>d__.<>t__builder.Start<CorePackageInitializer.<GetSerializedProjectConfigurationAsync>d__63>(ref <GetSerializedProjectConfigurationAsync>d__);
			return <GetSerializedProjectConfigurationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000025B4 File Offset: 0x000007B4
		[CompilerGenerated]
		private void <InitializeComponents>g__RegisterProvidedComponents|47_0()
		{
			this.m_Registry.RegisterServiceComponent<IInstallationId>(this.InstallationId);
			this.m_Registry.RegisterServiceComponent<IActionScheduler>(this.ActionScheduler);
			this.m_Registry.RegisterServiceComponent<IProjectConfiguration>(this.ProjectConfig);
			this.m_Registry.RegisterServiceComponent<IEnvironments>(this.Environments);
			this.m_Registry.RegisterServiceComponent<IMetricsFactory>(this.MetricsFactory);
			this.m_Registry.RegisterServiceComponent<IDiagnosticsFactory>(this.DiagnosticsFactory);
			this.m_Registry.RegisterServiceComponent<ICloudProjectId>(this.CloudProjectId);
			this.m_Registry.RegisterServiceComponent<IUnityThreadUtils>(this.UnityThreadUtils);
			this.m_Registry.RegisterServiceComponent<IExternalUserId>(this.ExternalUserId);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000265A File Offset: 0x0000085A
		[CompilerGenerated]
		internal static bool <InitializeComponents>g__SendFailedInitDiagnostic|47_1(Exception reason)
		{
			return false;
		}

		// Token: 0x04000001 RID: 1
		internal const string CorePackageName = "com.unity.services.core";

		// Token: 0x04000002 RID: 2
		internal const string ProjectUnlinkMessage = "To use Unity's dashboard services, you need to link your Unity project to a project ID. To do this, go to Project Settings to select your organization, select your project and then link a project ID. You also need to make sure your organization has access to the required products. Visit https://dashboard.unity3d.com to sign up.";

		// Token: 0x0400000C RID: 12
		private CoreRegistry m_Registry;

		// Token: 0x0400000D RID: 13
		private readonly IJsonSerializer m_Serializer;

		// Token: 0x0400000E RID: 14
		private InitializationOptions m_CurrentInitializationOptions;
	}
}
