using System;
using System.Diagnostics;

namespace UnityEngine.UIElements
{
	// Token: 0x0200015E RID: 350
	internal class DisposeHelper
	{
		// Token: 0x06000B72 RID: 2930 RVA: 0x0002D8B0 File Offset: 0x0002BAB0
		[Conditional("UNITY_UIELEMENTS_DEBUG_DISPOSE")]
		public static void NotifyMissingDispose(IDisposable disposable)
		{
			bool flag = disposable == null;
			if (!flag)
			{
				Debug.LogError("An IDisposable instance of type '" + disposable.GetType().FullName + "' has not been disposed.");
			}
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0002D8E8 File Offset: 0x0002BAE8
		public static void NotifyDisposedUsed(IDisposable disposable)
		{
			Debug.LogError("An instance of type '" + disposable.GetType().FullName + "' is being used although it has been disposed.");
		}
	}
}
