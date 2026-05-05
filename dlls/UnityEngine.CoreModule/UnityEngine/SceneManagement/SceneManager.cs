using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine.SceneManagement
{
	// Token: 0x02000323 RID: 803
	[RequiredByNativeCode]
	[NativeHeader("Runtime/Export/SceneManager/SceneManager.bindings.h")]
	public class SceneManager
	{
		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x0600207F RID: 8319
		public static extern int sceneCount { [NativeHeader("Runtime/SceneManager/SceneManager.h")] [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)] [NativeMethod("GetSceneCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x06002080 RID: 8320
		public static extern int loadedSceneCount { [StaticAccessor("GetSceneManager()", StaticAccessorType.Dot)] [NativeHeader("Runtime/SceneManager/SceneManager.h")] [NativeMethod("GetLoadedSceneCount")] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x06002081 RID: 8321 RVA: 0x00035EB0 File Offset: 0x000340B0
		public static int sceneCountInBuildSettings
		{
			get
			{
				return SceneManagerAPI.ActiveAPI.GetNumScenesInBuildSettings();
			}
		}

		// Token: 0x06002082 RID: 8322 RVA: 0x00035ECC File Offset: 0x000340CC
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		internal static bool CanSetAsActiveScene(Scene scene)
		{
			return SceneManager.CanSetAsActiveScene_Injected(ref scene);
		}

		// Token: 0x06002083 RID: 8323 RVA: 0x00035ED8 File Offset: 0x000340D8
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static Scene GetActiveScene()
		{
			Scene result;
			SceneManager.GetActiveScene_Injected(out result);
			return result;
		}

		// Token: 0x06002084 RID: 8324 RVA: 0x00035EED File Offset: 0x000340ED
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		[NativeThrows]
		public static bool SetActiveScene(Scene scene)
		{
			return SceneManager.SetActiveScene_Injected(ref scene);
		}

		// Token: 0x06002085 RID: 8325 RVA: 0x00035EF8 File Offset: 0x000340F8
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static Scene GetSceneByPath(string scenePath)
		{
			Scene result;
			SceneManager.GetSceneByPath_Injected(scenePath, out result);
			return result;
		}

		// Token: 0x06002086 RID: 8326 RVA: 0x00035F10 File Offset: 0x00034110
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static Scene GetSceneByName(string name)
		{
			Scene result;
			SceneManager.GetSceneByName_Injected(name, out result);
			return result;
		}

		// Token: 0x06002087 RID: 8327 RVA: 0x00035F28 File Offset: 0x00034128
		public static Scene GetSceneByBuildIndex(int buildIndex)
		{
			return SceneManagerAPI.ActiveAPI.GetSceneByBuildIndex(buildIndex);
		}

		// Token: 0x06002088 RID: 8328 RVA: 0x00035F48 File Offset: 0x00034148
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		[NativeThrows]
		public static Scene GetSceneAt(int index)
		{
			Scene result;
			SceneManager.GetSceneAt_Injected(index, out result);
			return result;
		}

		// Token: 0x06002089 RID: 8329 RVA: 0x00035F60 File Offset: 0x00034160
		[NativeThrows]
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static Scene CreateScene([NotNull("ArgumentNullException")] string sceneName, CreateSceneParameters parameters)
		{
			Scene result;
			SceneManager.CreateScene_Injected(sceneName, ref parameters, out result);
			return result;
		}

		// Token: 0x0600208A RID: 8330 RVA: 0x00035F78 File Offset: 0x00034178
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		[NativeThrows]
		private static bool UnloadSceneInternal(Scene scene, UnloadSceneOptions options)
		{
			return SceneManager.UnloadSceneInternal_Injected(ref scene, options);
		}

		// Token: 0x0600208B RID: 8331 RVA: 0x00035F82 File Offset: 0x00034182
		[NativeThrows]
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		private static AsyncOperation UnloadSceneAsyncInternal(Scene scene, UnloadSceneOptions options)
		{
			return SceneManager.UnloadSceneAsyncInternal_Injected(ref scene, options);
		}

		// Token: 0x0600208C RID: 8332 RVA: 0x00035F8C File Offset: 0x0003418C
		private static AsyncOperation LoadSceneAsyncNameIndexInternal(string sceneName, int sceneBuildIndex, LoadSceneParameters parameters, bool mustCompleteNextFrame)
		{
			bool flag = !SceneManager.s_AllowLoadScene;
			AsyncOperation result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = SceneManagerAPI.ActiveAPI.LoadSceneAsyncByNameOrIndex(sceneName, sceneBuildIndex, parameters, mustCompleteNextFrame);
			}
			return result;
		}

		// Token: 0x0600208D RID: 8333 RVA: 0x00035FBC File Offset: 0x000341BC
		private static AsyncOperation UnloadSceneNameIndexInternal(string sceneName, int sceneBuildIndex, bool immediately, UnloadSceneOptions options, out bool outSuccess)
		{
			bool flag = !SceneManager.s_AllowLoadScene;
			AsyncOperation result;
			if (flag)
			{
				outSuccess = false;
				result = null;
			}
			else
			{
				result = SceneManagerAPI.ActiveAPI.UnloadSceneAsyncByNameOrIndex(sceneName, sceneBuildIndex, immediately, options, out outSuccess);
			}
			return result;
		}

		// Token: 0x0600208E RID: 8334 RVA: 0x00035FF3 File Offset: 0x000341F3
		[NativeThrows]
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static void MergeScenes(Scene sourceScene, Scene destinationScene)
		{
			SceneManager.MergeScenes_Injected(ref sourceScene, ref destinationScene);
		}

		// Token: 0x0600208F RID: 8335 RVA: 0x00035FFE File Offset: 0x000341FE
		[NativeThrows]
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		public static void MoveGameObjectToScene([NotNull("ArgumentNullException")] GameObject go, Scene scene)
		{
			SceneManager.MoveGameObjectToScene_Injected(go, ref scene);
		}

		// Token: 0x06002090 RID: 8336 RVA: 0x00036008 File Offset: 0x00034208
		[NativeThrows]
		[StaticAccessor("SceneManagerBindings", StaticAccessorType.DoubleColon)]
		private static void MoveGameObjectsToSceneByInstanceId(IntPtr instanceIds, int instanceCount, Scene scene)
		{
			SceneManager.MoveGameObjectsToSceneByInstanceId_Injected(instanceIds, instanceCount, ref scene);
		}

		// Token: 0x06002091 RID: 8337 RVA: 0x00036014 File Offset: 0x00034214
		public static void MoveGameObjectsToScene(NativeArray<int> instanceIDs, Scene scene)
		{
			bool flag = !instanceIDs.IsCreated;
			if (flag)
			{
				throw new ArgumentException("NativeArray is uninitialized", "instanceIDs");
			}
			bool flag2 = instanceIDs.Length == 0;
			if (!flag2)
			{
				SceneManager.MoveGameObjectsToSceneByInstanceId((IntPtr)instanceIDs.GetUnsafeReadOnlyPtr<int>(), instanceIDs.Length, scene);
			}
		}

		// Token: 0x06002092 RID: 8338 RVA: 0x0003606C File Offset: 0x0003426C
		[RequiredByNativeCode]
		internal static AsyncOperation LoadFirstScene_Internal(bool async)
		{
			return SceneManagerAPI.ActiveAPI.LoadFirstScene(async);
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06002093 RID: 8339 RVA: 0x0003608C File Offset: 0x0003428C
		// (remove) Token: 0x06002094 RID: 8340 RVA: 0x000360C0 File Offset: 0x000342C0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event UnityAction<Scene, LoadSceneMode> sceneLoaded;

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06002095 RID: 8341 RVA: 0x000360F4 File Offset: 0x000342F4
		// (remove) Token: 0x06002096 RID: 8342 RVA: 0x00036128 File Offset: 0x00034328
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event UnityAction<Scene> sceneUnloaded;

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06002097 RID: 8343 RVA: 0x0003615C File Offset: 0x0003435C
		// (remove) Token: 0x06002098 RID: 8344 RVA: 0x00036190 File Offset: 0x00034390
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event UnityAction<Scene, Scene> activeSceneChanged;

		// Token: 0x06002099 RID: 8345 RVA: 0x000361C4 File Offset: 0x000343C4
		[Obsolete("Use SceneManager.sceneCount and SceneManager.GetSceneAt(int index) to loop the all scenes instead.")]
		public static Scene[] GetAllScenes()
		{
			Scene[] array = new Scene[SceneManager.sceneCount];
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				array[i] = SceneManager.GetSceneAt(i);
			}
			return array;
		}

		// Token: 0x0600209A RID: 8346 RVA: 0x00036208 File Offset: 0x00034408
		public static Scene CreateScene(string sceneName)
		{
			CreateSceneParameters parameters = new CreateSceneParameters(LocalPhysicsMode.None);
			return SceneManager.CreateScene(sceneName, parameters);
		}

		// Token: 0x0600209B RID: 8347 RVA: 0x0003622C File Offset: 0x0003442C
		public static void LoadScene(string sceneName, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode)
		{
			LoadSceneParameters parameters = new LoadSceneParameters(mode);
			SceneManager.LoadScene(sceneName, parameters);
		}

		// Token: 0x0600209C RID: 8348 RVA: 0x0003624C File Offset: 0x0003444C
		[ExcludeFromDocs]
		public static void LoadScene(string sceneName)
		{
			LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Single);
			SceneManager.LoadScene(sceneName, parameters);
		}

		// Token: 0x0600209D RID: 8349 RVA: 0x0003626C File Offset: 0x0003446C
		public static Scene LoadScene(string sceneName, LoadSceneParameters parameters)
		{
			SceneManager.LoadSceneAsyncNameIndexInternal(sceneName, -1, parameters, true);
			return SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
		}

		// Token: 0x0600209E RID: 8350 RVA: 0x00036294 File Offset: 0x00034494
		public static void LoadScene(int sceneBuildIndex, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode)
		{
			LoadSceneParameters parameters = new LoadSceneParameters(mode);
			SceneManager.LoadScene(sceneBuildIndex, parameters);
		}

		// Token: 0x0600209F RID: 8351 RVA: 0x000362B4 File Offset: 0x000344B4
		[ExcludeFromDocs]
		public static void LoadScene(int sceneBuildIndex)
		{
			LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Single);
			SceneManager.LoadScene(sceneBuildIndex, parameters);
		}

		// Token: 0x060020A0 RID: 8352 RVA: 0x000362D4 File Offset: 0x000344D4
		public static Scene LoadScene(int sceneBuildIndex, LoadSceneParameters parameters)
		{
			SceneManager.LoadSceneAsyncNameIndexInternal(null, sceneBuildIndex, parameters, true);
			return SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
		}

		// Token: 0x060020A1 RID: 8353 RVA: 0x000362FC File Offset: 0x000344FC
		public static AsyncOperation LoadSceneAsync(int sceneBuildIndex, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode)
		{
			LoadSceneParameters parameters = new LoadSceneParameters(mode);
			return SceneManager.LoadSceneAsync(sceneBuildIndex, parameters);
		}

		// Token: 0x060020A2 RID: 8354 RVA: 0x00036320 File Offset: 0x00034520
		[ExcludeFromDocs]
		public static AsyncOperation LoadSceneAsync(int sceneBuildIndex)
		{
			LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Single);
			return SceneManager.LoadSceneAsync(sceneBuildIndex, parameters);
		}

		// Token: 0x060020A3 RID: 8355 RVA: 0x00036344 File Offset: 0x00034544
		public static AsyncOperation LoadSceneAsync(int sceneBuildIndex, LoadSceneParameters parameters)
		{
			return SceneManager.LoadSceneAsyncNameIndexInternal(null, sceneBuildIndex, parameters, false);
		}

		// Token: 0x060020A4 RID: 8356 RVA: 0x00036360 File Offset: 0x00034560
		public static AsyncOperation LoadSceneAsync(string sceneName, [DefaultValue("LoadSceneMode.Single")] LoadSceneMode mode)
		{
			LoadSceneParameters parameters = new LoadSceneParameters(mode);
			return SceneManager.LoadSceneAsync(sceneName, parameters);
		}

		// Token: 0x060020A5 RID: 8357 RVA: 0x00036384 File Offset: 0x00034584
		[ExcludeFromDocs]
		public static AsyncOperation LoadSceneAsync(string sceneName)
		{
			LoadSceneParameters parameters = new LoadSceneParameters(LoadSceneMode.Single);
			return SceneManager.LoadSceneAsync(sceneName, parameters);
		}

		// Token: 0x060020A6 RID: 8358 RVA: 0x000363A8 File Offset: 0x000345A8
		public static AsyncOperation LoadSceneAsync(string sceneName, LoadSceneParameters parameters)
		{
			return SceneManager.LoadSceneAsyncNameIndexInternal(sceneName, -1, parameters, false);
		}

		// Token: 0x060020A7 RID: 8359 RVA: 0x000363C4 File Offset: 0x000345C4
		[Obsolete("Use SceneManager.UnloadSceneAsync. This function is not safe to use during triggers and under other circumstances. See Scripting reference for more details.")]
		public static bool UnloadScene(Scene scene)
		{
			return SceneManager.UnloadSceneInternal(scene, UnloadSceneOptions.None);
		}

		// Token: 0x060020A8 RID: 8360 RVA: 0x000363E0 File Offset: 0x000345E0
		[Obsolete("Use SceneManager.UnloadSceneAsync. This function is not safe to use during triggers and under other circumstances. See Scripting reference for more details.")]
		public static bool UnloadScene(int sceneBuildIndex)
		{
			bool result;
			SceneManager.UnloadSceneNameIndexInternal("", sceneBuildIndex, true, UnloadSceneOptions.None, out result);
			return result;
		}

		// Token: 0x060020A9 RID: 8361 RVA: 0x00036404 File Offset: 0x00034604
		[Obsolete("Use SceneManager.UnloadSceneAsync. This function is not safe to use during triggers and under other circumstances. See Scripting reference for more details.")]
		public static bool UnloadScene(string sceneName)
		{
			bool result;
			SceneManager.UnloadSceneNameIndexInternal(sceneName, -1, true, UnloadSceneOptions.None, out result);
			return result;
		}

		// Token: 0x060020AA RID: 8362 RVA: 0x00036424 File Offset: 0x00034624
		public static AsyncOperation UnloadSceneAsync(int sceneBuildIndex)
		{
			bool flag;
			return SceneManager.UnloadSceneNameIndexInternal("", sceneBuildIndex, false, UnloadSceneOptions.None, out flag);
		}

		// Token: 0x060020AB RID: 8363 RVA: 0x00036448 File Offset: 0x00034648
		public static AsyncOperation UnloadSceneAsync(string sceneName)
		{
			bool flag;
			return SceneManager.UnloadSceneNameIndexInternal(sceneName, -1, false, UnloadSceneOptions.None, out flag);
		}

		// Token: 0x060020AC RID: 8364 RVA: 0x00036468 File Offset: 0x00034668
		public static AsyncOperation UnloadSceneAsync(Scene scene)
		{
			return SceneManager.UnloadSceneAsyncInternal(scene, UnloadSceneOptions.None);
		}

		// Token: 0x060020AD RID: 8365 RVA: 0x00036484 File Offset: 0x00034684
		public static AsyncOperation UnloadSceneAsync(int sceneBuildIndex, UnloadSceneOptions options)
		{
			bool flag;
			return SceneManager.UnloadSceneNameIndexInternal("", sceneBuildIndex, false, options, out flag);
		}

		// Token: 0x060020AE RID: 8366 RVA: 0x000364A8 File Offset: 0x000346A8
		public static AsyncOperation UnloadSceneAsync(string sceneName, UnloadSceneOptions options)
		{
			bool flag;
			return SceneManager.UnloadSceneNameIndexInternal(sceneName, -1, false, options, out flag);
		}

		// Token: 0x060020AF RID: 8367 RVA: 0x000364C8 File Offset: 0x000346C8
		public static AsyncOperation UnloadSceneAsync(Scene scene, UnloadSceneOptions options)
		{
			return SceneManager.UnloadSceneAsyncInternal(scene, options);
		}

		// Token: 0x060020B0 RID: 8368 RVA: 0x000364E4 File Offset: 0x000346E4
		[RequiredByNativeCode]
		private static void Internal_SceneLoaded(Scene scene, LoadSceneMode mode)
		{
			bool flag = SceneManager.sceneLoaded != null;
			if (flag)
			{
				SceneManager.sceneLoaded(scene, mode);
			}
		}

		// Token: 0x060020B1 RID: 8369 RVA: 0x00036510 File Offset: 0x00034710
		[RequiredByNativeCode]
		private static void Internal_SceneUnloaded(Scene scene)
		{
			bool flag = SceneManager.sceneUnloaded != null;
			if (flag)
			{
				SceneManager.sceneUnloaded(scene);
			}
		}

		// Token: 0x060020B2 RID: 8370 RVA: 0x00036538 File Offset: 0x00034738
		[RequiredByNativeCode]
		private static void Internal_ActiveSceneChanged(Scene previousActiveScene, Scene newActiveScene)
		{
			bool flag = SceneManager.activeSceneChanged != null;
			if (flag)
			{
				SceneManager.activeSceneChanged(previousActiveScene, newActiveScene);
			}
		}

		// Token: 0x060020B5 RID: 8373
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CanSetAsActiveScene_Injected(ref Scene scene);

		// Token: 0x060020B6 RID: 8374
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetActiveScene_Injected(out Scene ret);

		// Token: 0x060020B7 RID: 8375
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool SetActiveScene_Injected(ref Scene scene);

		// Token: 0x060020B8 RID: 8376
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSceneByPath_Injected(string scenePath, out Scene ret);

		// Token: 0x060020B9 RID: 8377
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSceneByName_Injected(string name, out Scene ret);

		// Token: 0x060020BA RID: 8378
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSceneAt_Injected(int index, out Scene ret);

		// Token: 0x060020BB RID: 8379
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CreateScene_Injected(string sceneName, ref CreateSceneParameters parameters, out Scene ret);

		// Token: 0x060020BC RID: 8380
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool UnloadSceneInternal_Injected(ref Scene scene, UnloadSceneOptions options);

		// Token: 0x060020BD RID: 8381
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AsyncOperation UnloadSceneAsyncInternal_Injected(ref Scene scene, UnloadSceneOptions options);

		// Token: 0x060020BE RID: 8382
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MergeScenes_Injected(ref Scene sourceScene, ref Scene destinationScene);

		// Token: 0x060020BF RID: 8383
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MoveGameObjectToScene_Injected(GameObject go, ref Scene scene);

		// Token: 0x060020C0 RID: 8384
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MoveGameObjectsToSceneByInstanceId_Injected(IntPtr instanceIds, int instanceCount, ref Scene scene);

		// Token: 0x04000AB9 RID: 2745
		internal static bool s_AllowLoadScene = true;
	}
}
