using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000005 RID: 5
	internal static class RuntimeUtils
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020D0 File Offset: 0x000002D0
		public static void NoEffectWarning(this object source, [CallerMemberName] string caller = "")
		{
			source.NoEffectWarning(caller);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020DC File Offset: 0x000002DC
		public static T NoEffectWarning<T>(this object source, [CallerMemberName] string caller = "")
		{
			string name = source.GetType().Name;
			Debug.LogWarning(string.Concat(new string[]
			{
				"\"",
				name,
				".",
				caller,
				"\" has no effect as it has been disabled by scripting symbols."
			}));
			return default(T);
		}
	}
}
