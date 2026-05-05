using System;
using System.Diagnostics;
using UnityEngine;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000026 RID: 38
	internal class Logger
	{
		// Token: 0x06000110 RID: 272 RVA: 0x00005135 File Offset: 0x00003335
		public static void Log(object message)
		{
			Debug.unityLogger.Log("[Lobby]", message);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00005147 File Offset: 0x00003347
		public static void LogWarning(object message)
		{
			Debug.unityLogger.LogWarning("[Lobby]", message);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005159 File Offset: 0x00003359
		public static void LogError(object message)
		{
			Debug.unityLogger.LogError("[Lobby]", message);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000516B File Offset: 0x0000336B
		public static void LogException(Exception exception)
		{
			Debug.unityLogger.Log(LogType.Exception, "[Lobby]", exception);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000517E File Offset: 0x0000337E
		[Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message)
		{
			Debug.unityLogger.Log(LogType.Assert, "[Lobby]", message);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00005191 File Offset: 0x00003391
		[Conditional("ENABLE_UNITY_LOBBY_VERBOSE_LOGGING")]
		public static void LogVerbose(object message)
		{
			Debug.unityLogger.Log("[Lobby]", message);
		}

		// Token: 0x0400009B RID: 155
		private const string k_Tag = "[Lobby]";

		// Token: 0x0400009C RID: 156
		private const string k_VerboseLoggingDefine = "ENABLE_UNITY_LOBBY_VERBOSE_LOGGING";
	}
}
