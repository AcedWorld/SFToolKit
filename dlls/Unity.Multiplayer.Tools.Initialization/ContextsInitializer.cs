using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Multiplayer.Tools.Common;
using UnityEngine;

namespace Unity.Multiplayer.Tools.Context
{
	// Token: 0x02000004 RID: 4
	internal static class ContextsInitializer
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020C3 File Offset: 0x000002C3
		static ContextsInitializer()
		{
			Application.quitting += ContextsInitializer.DisableRuntimeContexts;
			ContextsInitializer.s_Contexts = ContextsDefinition.Get();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020E0 File Offset: 0x000002E0
		private static void EnableEditorContexts()
		{
			IContext[] array = ContextsInitializer.s_Contexts;
			for (int i = 0; i < array.Length; i++)
			{
				IEditorSetupHandler editorSetupHandler = array[i] as IEditorSetupHandler;
				if (editorSetupHandler != null)
				{
					editorSetupHandler.EditorSetup();
				}
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002114 File Offset: 0x00000314
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void EnableRuntimeContexts()
		{
			IContext[] array = ContextsInitializer.s_Contexts;
			for (int i = 0; i < array.Length; i++)
			{
				IRuntimeSetupHandler runtimeSetupHandler = array[i] as IRuntimeSetupHandler;
				if (runtimeSetupHandler != null)
				{
					runtimeSetupHandler.RuntimeSetup();
				}
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002148 File Offset: 0x00000348
		private static void DisableRuntimeContexts()
		{
			IContext[] array = ContextsInitializer.s_Contexts;
			for (int i = 0; i < array.Length; i++)
			{
				IRuntimeSetupHandler runtimeSetupHandler = array[i] as IRuntimeSetupHandler;
				if (runtimeSetupHandler != null)
				{
					runtimeSetupHandler.RuntimeTeardown();
				}
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000217B File Offset: 0x0000037B
		[Conditional("UNITY_MP_TOOLS_CONTEXT_TRACE_CALLS")]
		private static void TraceCall([CallerMemberName] string methodName = "")
		{
			Debug.Log("ContextsInitializer." + methodName);
		}

		// Token: 0x04000001 RID: 1
		private static readonly IContext[] s_Contexts;
	}
}
