using System;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Experimental.Rendering
{
	// Token: 0x020004D4 RID: 1236
	[NativeHeader("Runtime/Camera/ScriptableRuntimeReflectionSystem.h")]
	[RequiredByNativeCode]
	public static class ScriptableRuntimeReflectionSystemSettings
	{
		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x06002B26 RID: 11046 RVA: 0x00049108 File Offset: 0x00047308
		// (set) Token: 0x06002B27 RID: 11047 RVA: 0x00049120 File Offset: 0x00047320
		public static IScriptableRuntimeReflectionSystem system
		{
			get
			{
				return ScriptableRuntimeReflectionSystemSettings.Internal_ScriptableRuntimeReflectionSystemSettings_system;
			}
			set
			{
				bool flag = value == null || value.Equals(null);
				if (flag)
				{
					Debug.LogError("'null' cannot be assigned to ScriptableRuntimeReflectionSystemSettings.system");
				}
				else
				{
					bool flag2 = !(ScriptableRuntimeReflectionSystemSettings.system is BuiltinRuntimeReflectionSystem) && !(value is BuiltinRuntimeReflectionSystem) && ScriptableRuntimeReflectionSystemSettings.system != value;
					if (flag2)
					{
						Debug.LogWarningFormat("ScriptableRuntimeReflectionSystemSettings.system is assigned more than once. Only a the last instance will be used. (Last instance {0}, New instance {1})", new object[]
						{
							ScriptableRuntimeReflectionSystemSettings.system,
							value
						});
					}
					ScriptableRuntimeReflectionSystemSettings.Internal_ScriptableRuntimeReflectionSystemSettings_system = value;
				}
			}
		}

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x06002B28 RID: 11048 RVA: 0x00049198 File Offset: 0x00047398
		// (set) Token: 0x06002B29 RID: 11049 RVA: 0x000491B4 File Offset: 0x000473B4
		private static IScriptableRuntimeReflectionSystem Internal_ScriptableRuntimeReflectionSystemSettings_system
		{
			get
			{
				return ScriptableRuntimeReflectionSystemSettings.s_Instance.implementation;
			}
			[RequiredByNativeCode]
			set
			{
				bool flag = ScriptableRuntimeReflectionSystemSettings.s_Instance.implementation != value;
				if (flag)
				{
					bool flag2 = ScriptableRuntimeReflectionSystemSettings.s_Instance.implementation != null;
					if (flag2)
					{
						ScriptableRuntimeReflectionSystemSettings.s_Instance.implementation.Dispose();
					}
				}
				ScriptableRuntimeReflectionSystemSettings.s_Instance.implementation = value;
			}
		}

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x06002B2A RID: 11050 RVA: 0x00049208 File Offset: 0x00047408
		private static ScriptableRuntimeReflectionSystemWrapper Internal_ScriptableRuntimeReflectionSystemSettings_instance
		{
			[RequiredByNativeCode]
			get
			{
				return ScriptableRuntimeReflectionSystemSettings.s_Instance;
			}
		}

		// Token: 0x06002B2B RID: 11051
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		[StaticAccessor("ScriptableRuntimeReflectionSystem", StaticAccessorType.DoubleColon)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ScriptingDirtyReflectionSystemInstance();

		// Token: 0x04001022 RID: 4130
		private static ScriptableRuntimeReflectionSystemWrapper s_Instance = new ScriptableRuntimeReflectionSystemWrapper();
	}
}
