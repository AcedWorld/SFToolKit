using System;
using System.Diagnostics;
using UnityEngine;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000019 RID: 25
	internal static class Logger
	{
		// Token: 0x06000078 RID: 120 RVA: 0x00003119 File Offset: 0x00001319
		public static void Log(object message)
		{
			Debug.unityLogger.Log("[PlayerAccounts]", message);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000312B File Offset: 0x0000132B
		public static void LogWarning(object message)
		{
			Debug.unityLogger.LogWarning("[PlayerAccounts]", message);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000313D File Offset: 0x0000133D
		public static void LogError(object message)
		{
			Debug.unityLogger.LogError("[PlayerAccounts]", message);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000314F File Offset: 0x0000134F
		public static void LogException(Exception exception)
		{
			Debug.unityLogger.Log(LogType.Exception, "[PlayerAccounts]", exception);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003162 File Offset: 0x00001362
		[Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message)
		{
			Debug.unityLogger.Log(LogType.Assert, "[PlayerAccounts]", message);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003175 File Offset: 0x00001375
		[Conditional("ENABLE_UNITY_SERVICES_VERBOSE_LOGGING")]
		[Conditional("ENABLE_UNITY_AUTHENTICATION_VERBOSE_LOGGING")]
		public static void LogVerbose(object message)
		{
			Debug.unityLogger.Log("[PlayerAccounts]", message);
		}

		// Token: 0x0400004D RID: 77
		private const string k_Tag = "[PlayerAccounts]";

		// Token: 0x0400004E RID: 78
		internal const string k_GlobalVerboseLoggingDefine = "ENABLE_UNITY_SERVICES_VERBOSE_LOGGING";

		// Token: 0x0400004F RID: 79
		internal const string k_AuthenticationVerboseLoggingDefine = "ENABLE_UNITY_AUTHENTICATION_VERBOSE_LOGGING";
	}
}
