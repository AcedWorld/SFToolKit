using System;
using System.Diagnostics;
using UnityEngine;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x0200002B RID: 43
	internal class Logger
	{
		// Token: 0x060000AB RID: 171 RVA: 0x00003BC1 File Offset: 0x00001DC1
		[Conditional("ENABLE_UNITY_WIRE_VERBOSE_LOGGING")]
		public static void Log(object message)
		{
			Debug.unityLogger.Log("[Wire]", message);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003BD3 File Offset: 0x00001DD3
		[Conditional("ENABLE_UNITY_WIRE_VERBOSE_LOGGING")]
		public static void LogWarning(object message)
		{
			Debug.unityLogger.LogWarning("[Wire]", message);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003BE5 File Offset: 0x00001DE5
		[Conditional("ENABLE_UNITY_WIRE_VERBOSE_LOGGING")]
		public static void LogError(object message)
		{
			Debug.unityLogger.LogError("[Wire]", message);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003BF7 File Offset: 0x00001DF7
		[Conditional("ENABLE_UNITY_WIRE_VERBOSE_LOGGING")]
		public static void LogException(Exception exception)
		{
			Debug.unityLogger.Log(LogType.Exception, "[Wire]", exception);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003C0A File Offset: 0x00001E0A
		[Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message)
		{
			Debug.unityLogger.Log(LogType.Assert, "[Wire]", message);
		}

		// Token: 0x04000096 RID: 150
		private const string k_Tag = "[Wire]";

		// Token: 0x04000097 RID: 151
		private const string k_VerboseLoggingDefine = "ENABLE_UNITY_WIRE_VERBOSE_LOGGING";
	}
}
