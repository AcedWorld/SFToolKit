using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000055 RID: 85
	internal class UnityServicesInternal : IUnityServices
	{
		// Token: 0x1400000F RID: 15
		// (add) Token: 0x0600017A RID: 378 RVA: 0x00003CB0 File Offset: 0x00001EB0
		// (remove) Token: 0x0600017B RID: 379 RVA: 0x00003CE8 File Offset: 0x00001EE8
		public event Action Initialized;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x0600017C RID: 380 RVA: 0x00003D20 File Offset: 0x00001F20
		// (remove) Token: 0x0600017D RID: 381 RVA: 0x00003D58 File Offset: 0x00001F58
		public event Action<Exception> InitializeFailed;

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00003D8D File Offset: 0x00001F8D
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00003D95 File Offset: 0x00001F95
		public ServicesInitializationState State { get; private set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00003D9E File Offset: 0x00001F9E
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00003DAB File Offset: 0x00001FAB
		public InitializationOptions Options
		{
			get
			{
				return this.Registry.Options;
			}
			internal set
			{
				this.Registry.Options = value;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00003DB9 File Offset: 0x00001FB9
		[NotNull]
		internal CoreRegistry Registry { get; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00003DC1 File Offset: 0x00001FC1
		[NotNull]
		internal CoreMetrics Metrics { get; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00003DC9 File Offset: 0x00001FC9
		[NotNull]
		internal CoreDiagnostics Diagnostics { get; }

		// Token: 0x06000185 RID: 389 RVA: 0x00003DD1 File Offset: 0x00001FD1
		public UnityServicesInternal([NotNull] CoreRegistry registry, [NotNull] CoreMetrics coreMetrics, [NotNull] CoreDiagnostics coreDiagnostics)
		{
			this.Registry = registry;
			this.Metrics = coreMetrics;
			this.Diagnostics = coreDiagnostics;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00003DF0 File Offset: 0x00001FF0
		public Task InitializeAsync(InitializationOptions options)
		{
			UnityServicesInternal.<InitializeAsync>d__27 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.options = options;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<UnityServicesInternal.<InitializeAsync>d__27>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00003E3B File Offset: 0x0000203B
		public string GetIdentifier()
		{
			return this.Registry.InstanceId;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00003E48 File Offset: 0x00002048
		private void TriggerInitializeSuccess()
		{
			try
			{
				Action initialized = this.Initialized;
				if (initialized != null)
				{
					initialized();
				}
			}
			catch (Exception arg)
			{
				CoreLogger.LogError(string.Format("{0} {1}", "Exception in services initialization success event handler: ", arg));
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00003E90 File Offset: 0x00002090
		private void TriggerInitializeFailed(Exception initException)
		{
			try
			{
				Action<Exception> initializeFailed = this.InitializeFailed;
				if (initializeFailed != null)
				{
					initializeFailed(initException);
				}
			}
			catch (Exception arg)
			{
				CoreLogger.LogError(string.Format("{0} {1}", "Exception in services initialization failure event handler: ", arg));
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00003EDC File Offset: 0x000020DC
		public T GetService<T>()
		{
			return this.Registry.GetService<T>();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00003EE9 File Offset: 0x000020E9
		private bool HasRequestedInitialization()
		{
			return this.m_Initialization != null;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00003EF8 File Offset: 0x000020F8
		private Task InitializeServicesAsync()
		{
			UnityServicesInternal.<InitializeServicesAsync>d__33 <InitializeServicesAsync>d__;
			<InitializeServicesAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeServicesAsync>d__.<>4__this = this;
			<InitializeServicesAsync>d__.<>1__state = -1;
			<InitializeServicesAsync>d__.<>t__builder.Start<UnityServicesInternal.<InitializeServicesAsync>d__33>(ref <InitializeServicesAsync>d__);
			return <InitializeServicesAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00003F3C File Offset: 0x0000213C
		internal void SendInitializationMetrics(List<PackageInitializationInfo> packageInitInfos)
		{
			foreach (PackageInitializationInfo packageInitializationInfo in packageInitInfos)
			{
				this.Metrics.SendInitTimeMetricForPackage(packageInitializationInfo.PackageType, packageInitializationInfo.InitializationTimeInSeconds);
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00003F9C File Offset: 0x0000219C
		internal void EnableInitialization()
		{
			this.CanInitialize = true;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00003FA8 File Offset: 0x000021A8
		internal Task EnableInitializationAsync()
		{
			UnityServicesInternal.<EnableInitializationAsync>d__36 <EnableInitializationAsync>d__;
			<EnableInitializationAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<EnableInitializationAsync>d__.<>4__this = this;
			<EnableInitializationAsync>d__.<>1__state = -1;
			<EnableInitializationAsync>d__.<>t__builder.Start<UnityServicesInternal.<EnableInitializationAsync>d__36>(ref <EnableInitializationAsync>d__);
			return <EnableInitializationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00003FEB File Offset: 0x000021EB
		[CompilerGenerated]
		private bool <InitializeAsync>g__HasInitializationFailed|27_0()
		{
			return this.m_Initialization.Task.IsCompleted && this.m_Initialization.Task.Status != TaskStatus.RanToCompletion;
		}

		// Token: 0x0400006E RID: 110
		internal const string InitSuccessEventInvocationError = "Exception in services initialization success event handler: ";

		// Token: 0x0400006F RID: 111
		internal const string InitFailureEventInvocationError = "Exception in services initialization failure event handler: ";

		// Token: 0x04000073 RID: 115
		internal bool CanInitialize;

		// Token: 0x04000074 RID: 116
		private TaskCompletionSource<object> m_Initialization;
	}
}
