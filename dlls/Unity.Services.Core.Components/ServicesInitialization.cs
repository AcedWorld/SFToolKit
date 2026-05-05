using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Services.Core.Environments;
using Unity.Services.Core.Internal;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.Services.Core.Components
{
	// Token: 0x02000004 RID: 4
	[AddComponentMenu("Services/Services Initialization")]
	public class ServicesInitialization : ServicesBehaviour
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000021B7 File Offset: 0x000003B7
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000021BF File Offset: 0x000003BF
		internal bool IsSetupDone { get; private set; }

		// Token: 0x0600000E RID: 14 RVA: 0x000021C8 File Offset: 0x000003C8
		internal ServicesInitialization()
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021E8 File Offset: 0x000003E8
		protected override void OnServicesReady()
		{
			ServicesInitialization.<OnServicesReady>d__9 <OnServicesReady>d__;
			<OnServicesReady>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnServicesReady>d__.<>4__this = this;
			<OnServicesReady>d__.<>1__state = -1;
			<OnServicesReady>d__.<>t__builder.Start<ServicesInitialization.<OnServicesReady>d__9>(ref <OnServicesReady>d__);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000221F File Offset: 0x0000041F
		protected override void OnServicesInitialized()
		{
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002221 File Offset: 0x00000421
		protected override void Cleanup()
		{
			if (base.Services != null)
			{
				base.Services.Initialized -= this.OnInitialized;
				base.Services.InitializeFailed -= this.OnInitializeFailed;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000225C File Offset: 0x0000045C
		internal Task SetupAsync()
		{
			ServicesInitialization.<SetupAsync>d__12 <SetupAsync>d__;
			<SetupAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SetupAsync>d__.<>4__this = this;
			<SetupAsync>d__.<>1__state = -1;
			<SetupAsync>d__.<>t__builder.Start<ServicesInitialization.<SetupAsync>d__12>(ref <SetupAsync>d__);
			return <SetupAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022A0 File Offset: 0x000004A0
		internal Task InitializeOnStartAsync()
		{
			ServicesInitialization.<InitializeOnStartAsync>d__13 <InitializeOnStartAsync>d__;
			<InitializeOnStartAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeOnStartAsync>d__.<>4__this = this;
			<InitializeOnStartAsync>d__.<>1__state = -1;
			<InitializeOnStartAsync>d__.<>t__builder.Start<ServicesInitialization.<InitializeOnStartAsync>d__13>(ref <InitializeOnStartAsync>d__);
			return <InitializeOnStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000022E4 File Offset: 0x000004E4
		internal InitializationOptions BuildInitializationOptions()
		{
			InitializationOptions initializationOptions = new InitializationOptions();
			if (this.UseCustomEnvironment)
			{
				initializationOptions.SetEnvironmentName(this.EnvironmentName);
			}
			return initializationOptions;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000230D File Offset: 0x0000050D
		private void OnInitialized()
		{
			ServicesInitializationEvents events = this.Events;
			if (events == null)
			{
				return;
			}
			UnityEvent initialized = events.Initialized;
			if (initialized == null)
			{
				return;
			}
			initialized.Invoke();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002329 File Offset: 0x00000529
		private void OnInitializeFailed(Exception e)
		{
			ServicesInitializationEvents events = this.Events;
			if (events == null)
			{
				return;
			}
			UnityEvent<Exception> initializeFailed = events.InitializeFailed;
			if (initializeFailed == null)
			{
				return;
			}
			initializeFailed.Invoke(e);
		}

		// Token: 0x04000004 RID: 4
		[Header("Automation")]
		[Tooltip("This will attempt to initialize the services in Start().")]
		[SerializeField]
		public bool InitializeOnStart;

		// Token: 0x04000005 RID: 5
		[SerializeField]
		[Tooltip("Use this to set a custom environment in the initialization options. Defaults to the environment defined in the project settings or production.")]
		[Visibility("InitializeOnStart", true)]
		public bool UseCustomEnvironment;

		// Token: 0x04000006 RID: 6
		[SerializeField]
		[Tooltip("Choose the environment name to pass in the initialization options. You can configure environments in the unity dashboard.")]
		[Visibility("UseCustomEnvironment", true)]
		public string EnvironmentName = "production";

		// Token: 0x04000007 RID: 7
		[Header("Events")]
		[SerializeField]
		public ServicesInitializationEvents Events = new ServicesInitializationEvents();
	}
}
