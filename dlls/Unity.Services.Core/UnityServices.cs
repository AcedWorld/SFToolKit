using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Unity.Services.Core
{
	// Token: 0x0200000E RID: 14
	public static class UnityServices
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600002B RID: 43 RVA: 0x000022D0 File Offset: 0x000004D0
		// (remove) Token: 0x0600002C RID: 44 RVA: 0x000022E4 File Offset: 0x000004E4
		public static event Action Initialized
		{
			add
			{
				if (UnityServices.Instance != null)
				{
					UnityServices.Instance.Initialized += value;
				}
			}
			remove
			{
				if (UnityServices.Instance != null)
				{
					UnityServices.Instance.Initialized -= value;
				}
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600002D RID: 45 RVA: 0x000022F8 File Offset: 0x000004F8
		// (remove) Token: 0x0600002E RID: 46 RVA: 0x0000230C File Offset: 0x0000050C
		public static event Action<Exception> InitializeFailed
		{
			add
			{
				if (UnityServices.Instance != null)
				{
					UnityServices.Instance.InitializeFailed += value;
				}
			}
			remove
			{
				if (UnityServices.Instance != null)
				{
					UnityServices.Instance.InitializeFailed -= value;
				}
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002320 File Offset: 0x00000520
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00002327 File Offset: 0x00000527
		public static IUnityServices Instance { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000031 RID: 49 RVA: 0x0000232F File Offset: 0x0000052F
		public static IReadOnlyDictionary<string, IUnityServices> Services
		{
			get
			{
				return UnityServices.s_Services;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002336 File Offset: 0x00000536
		// (set) Token: 0x06000033 RID: 51 RVA: 0x0000233D File Offset: 0x0000053D
		internal static TaskCompletionSource<object> InstantiationCompletion { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002345 File Offset: 0x00000545
		private static Dictionary<string, IUnityServices> s_Services { get; } = new Dictionary<string, IUnityServices>();

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000035 RID: 53 RVA: 0x0000234C File Offset: 0x0000054C
		public static ServicesInitializationState State
		{
			get
			{
				if (!UnityThreadUtils.IsRunningOnUnityThread)
				{
					throw new ServicesInitializationException("You are attempting to access UnityServices.State from a non-Unity Thread. UnityServices.State can only be accessed from Unity Thread");
				}
				if (UnityServices.Instance != null)
				{
					return UnityServices.Instance.State;
				}
				TaskCompletionSource<object> instantiationCompletion = UnityServices.InstantiationCompletion;
				if (instantiationCompletion != null && instantiationCompletion.Task.Status == TaskStatus.WaitingForActivation)
				{
					return ServicesInitializationState.Initializing;
				}
				return ServicesInitializationState.Uninitialized;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000239B File Offset: 0x0000059B
		// (set) Token: 0x06000037 RID: 55 RVA: 0x000023A7 File Offset: 0x000005A7
		public static string ExternalUserId
		{
			get
			{
				return UnityServices.ExternalUserIdProperty.UserId;
			}
			set
			{
				UnityServices.ExternalUserIdProperty.UserId = value;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000023B4 File Offset: 0x000005B4
		public static Task InitializeAsync()
		{
			return UnityServices.InitializeAsync(new InitializationOptions());
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000023C0 File Offset: 0x000005C0
		[PreserveDependency("Register()", "Unity.Services.Core.Registration.CorePackageInitializer", "Unity.Services.Core.Registration")]
		[PreserveDependency("CreateStaticInstance()", "Unity.Services.Core.Internal.UnityServicesInitializer", "Unity.Services.Core.Internal")]
		[PreserveDependency("EnableServicesInitializationAsync()", "Unity.Services.Core.Internal.UnityServicesInitializer", "Unity.Services.Core.Internal")]
		[PreserveDependency("CaptureUnityThreadInfo()", "Unity.Services.Core.UnityThreadUtils", "Unity.Services.Core")]
		public static Task InitializeAsync(InitializationOptions options)
		{
			UnityServices.<InitializeAsync>d__26 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeAsync>d__.options = options;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<UnityServices.<InitializeAsync>d__26>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002404 File Offset: 0x00000604
		public static IUnityServices CreateServices()
		{
			return UnityServices.CreateServices(Guid.NewGuid().ToString());
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000242C File Offset: 0x0000062C
		public static IUnityServices CreateServices(string servicesId)
		{
			if (string.IsNullOrEmpty(servicesId))
			{
				throw new ArgumentException("The services identifier cannot be null or empty");
			}
			if (UnityServices.s_Services.ContainsKey(servicesId))
			{
				throw new ServicesCreationException("The services identifier '" + servicesId + "' is already registered.");
			}
			IUnityServices unityServices = UnityServicesBuilder.Create(servicesId);
			UnityServices.s_Services[servicesId] = unityServices;
			return unityServices;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002483 File Offset: 0x00000683
		internal static void ClearServices()
		{
			UnityServices.s_Services.Clear();
		}

		// Token: 0x0400001B RID: 27
		internal static ExternalUserIdProperty ExternalUserIdProperty = new ExternalUserIdProperty();
	}
}
