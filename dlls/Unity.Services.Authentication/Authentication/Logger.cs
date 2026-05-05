using System;
using System.Diagnostics;
using UnityEngine;

namespace Unity.Services.Authentication
{
	// Token: 0x02000057 RID: 87
	internal static class Logger
	{
		// Token: 0x06000244 RID: 580 RVA: 0x000069C7 File Offset: 0x00004BC7
		public static void Log(object message)
		{
			Debug.unityLogger.Log("[Authentication]", message);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000069D9 File Offset: 0x00004BD9
		public static void LogWarning(object message)
		{
			Debug.unityLogger.LogWarning("[Authentication]", message);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000069EB File Offset: 0x00004BEB
		public static void LogError(object message)
		{
			Debug.unityLogger.LogError("[Authentication]", message);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000069FD File Offset: 0x00004BFD
		public static void LogException(Exception exception)
		{
			Debug.unityLogger.Log(LogType.Exception, "[Authentication]", exception);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00006A10 File Offset: 0x00004C10
		[Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message)
		{
			Debug.unityLogger.Log(LogType.Assert, "[Authentication]", message);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00006A23 File Offset: 0x00004C23
		[Conditional("ENABLE_UNITY_SERVICES_VERBOSE_LOGGING")]
		[Conditional("ENABLE_UNITY_AUTHENTICATION_VERBOSE_LOGGING")]
		public static void LogVerbose(object message)
		{
			Debug.unityLogger.Log("[Authentication]", message);
		}

		// Token: 0x04000120 RID: 288
		private const string k_Tag = "[Authentication]";

		// Token: 0x04000121 RID: 289
		internal const string k_GlobalVerboseLoggingDefine = "ENABLE_UNITY_SERVICES_VERBOSE_LOGGING";

		// Token: 0x04000122 RID: 290
		internal const string k_AuthenticationVerboseLoggingDefine = "ENABLE_UNITY_AUTHENTICATION_VERBOSE_LOGGING";
	}
}
