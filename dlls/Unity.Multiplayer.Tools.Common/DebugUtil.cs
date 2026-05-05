using System;
using System.Diagnostics;
using UnityEngine;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000019 RID: 25
	internal static class DebugUtil
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00002D81 File Offset: 0x00000F81
		[Conditional("UNITY_MP_TOOLS_DEBUG_TRACE")]
		public static void Trace(string message)
		{
			Debug.Log(message);
		}
	}
}
