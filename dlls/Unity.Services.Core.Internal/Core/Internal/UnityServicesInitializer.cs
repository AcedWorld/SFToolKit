using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000054 RID: 84
	internal static class UnityServicesInitializer
	{
		// Token: 0x06000177 RID: 375 RVA: 0x00003BE0 File Offset: 0x00001DE0
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void CreateStaticInstance()
		{
			UnityServices.ClearServices();
			UnityServicesBuilder.InstanceCreationDelegate = new UnityServicesBuilder.CreationDelegate(UnityServicesInitializer.CreateInstance);
			CorePackageRegistry corePackageRegistry = new CorePackageRegistry();
			CoreRegistry coreRegistry = new CoreRegistry(corePackageRegistry.Registry, ServicesType.Default, null);
			CorePackageRegistry.Instance = corePackageRegistry;
			CoreRegistry.Instance = coreRegistry;
			CoreMetrics coreMetrics = new CoreMetrics();
			CoreDiagnostics coreDiagnostics = new CoreDiagnostics();
			UnityServices.Instance = new UnityServicesInternal(coreRegistry, coreMetrics, coreDiagnostics);
			TaskCompletionSource<object> instantiationCompletion = UnityServices.InstantiationCompletion;
			if (instantiationCompletion != null)
			{
				instantiationCompletion.TrySetResult(null);
			}
			CoreMetrics.Instance = coreMetrics;
			CoreDiagnostics.Instance = coreDiagnostics;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00003C58 File Offset: 0x00001E58
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void EnableServicesInitializationAsync()
		{
			UnityServicesInitializer.<EnableServicesInitializationAsync>d__1 <EnableServicesInitializationAsync>d__;
			<EnableServicesInitializationAsync>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<EnableServicesInitializationAsync>d__.<>1__state = -1;
			<EnableServicesInitializationAsync>d__.<>t__builder.Start<UnityServicesInitializer.<EnableServicesInitializationAsync>d__1>(ref <EnableServicesInitializationAsync>d__);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00003C87 File Offset: 0x00001E87
		internal static IUnityServices CreateInstance(string servicesId)
		{
			UnityServicesInternal unityServicesInternal = new UnityServicesInternal(new CoreRegistry(CorePackageRegistry.Instance.Registry, ServicesType.Instance, servicesId), CoreMetrics.Instance, CoreDiagnostics.Instance);
			unityServicesInternal.EnableInitialization();
			return unityServicesInternal;
		}
	}
}
