using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x0200004A RID: 74
	public static class NetworkLog
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000213 RID: 531 RVA: 0x0000B1C5 File Offset: 0x000093C5
		public static LogLevel CurrentLogLevel
		{
			get
			{
				if (!(NetworkManager.Singleton == null))
				{
					return NetworkManager.Singleton.LogLevel;
				}
				return LogLevel.Normal;
			}
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000B1E0 File Offset: 0x000093E0
		public static void LogInfo(string message)
		{
			Debug.Log("[Netcode] " + message);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000B1F2 File Offset: 0x000093F2
		public static void LogWarning(string message)
		{
			Debug.LogWarning("[Netcode] " + message);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000B204 File Offset: 0x00009404
		public static void LogError(string message)
		{
			Debug.LogError("[Netcode] " + message);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000B216 File Offset: 0x00009416
		public static void LogInfoServer(string message)
		{
			NetworkLog.LogServer(message, NetworkLog.LogType.Info);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000B21F File Offset: 0x0000941F
		public static void LogWarningServer(string message)
		{
			NetworkLog.LogServer(message, NetworkLog.LogType.Warning);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000B228 File Offset: 0x00009428
		public static void LogErrorServer(string message)
		{
			NetworkLog.LogServer(message, NetworkLog.LogType.Error);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000B234 File Offset: 0x00009434
		private static void LogServer(string message, NetworkLog.LogType logType)
		{
			NetworkManager networkManager;
			if ((networkManager = NetworkLog.NetworkManagerOverride) == null)
			{
				networkManager = (NetworkLog.NetworkManagerOverride = NetworkManager.Singleton);
			}
			NetworkManager networkManager2 = networkManager;
			ulong sender = (networkManager2 != null) ? networkManager2.LocalClientId : 0UL;
			bool flag = networkManager2 == null || networkManager2.IsServer;
			switch (logType)
			{
			case NetworkLog.LogType.Info:
				if (flag)
				{
					NetworkLog.LogInfoServerLocal(message, sender);
				}
				else
				{
					NetworkLog.LogInfo(message);
				}
				break;
			case NetworkLog.LogType.Warning:
				if (flag)
				{
					NetworkLog.LogWarningServerLocal(message, sender);
				}
				else
				{
					NetworkLog.LogWarning(message);
				}
				break;
			case NetworkLog.LogType.Error:
				if (flag)
				{
					NetworkLog.LogErrorServerLocal(message, sender);
				}
				else
				{
					NetworkLog.LogError(message);
				}
				break;
			}
			if (!flag && networkManager2.NetworkConfig.EnableNetworkLogs)
			{
				ServerLogMessage serverLogMessage = new ServerLogMessage
				{
					LogType = logType,
					Message = message
				};
				int num = networkManager2.ConnectionManager.SendMessage<ServerLogMessage>(ref serverLogMessage, NetworkDelivery.ReliableFragmentedSequenced, 0UL);
				networkManager2.NetworkMetrics.TrackServerLogSent(0UL, (uint)logType, (long)num);
			}
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000B30D File Offset: 0x0000950D
		internal static void LogInfoServerLocal(string message, ulong sender)
		{
			Debug.Log(string.Format("[Netcode-Server Sender={0}] {1}", sender, message));
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000B325 File Offset: 0x00009525
		internal static void LogWarningServerLocal(string message, ulong sender)
		{
			Debug.LogWarning(string.Format("[Netcode-Server Sender={0}] {1}", sender, message));
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000B33D File Offset: 0x0000953D
		internal static void LogErrorServerLocal(string message, ulong sender)
		{
			Debug.LogError(string.Format("[Netcode-Server Sender={0}] {1}", sender, message));
		}

		// Token: 0x04000114 RID: 276
		internal static NetworkManager NetworkManagerOverride;

		// Token: 0x0200004B RID: 75
		internal enum LogType : byte
		{
			// Token: 0x04000116 RID: 278
			Info,
			// Token: 0x04000117 RID: 279
			Warning,
			// Token: 0x04000118 RID: 280
			Error,
			// Token: 0x04000119 RID: 281
			None
		}
	}
}
