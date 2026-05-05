using System;
using UnityEngine;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x0200000A RID: 10
	public class Logger
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000023D2 File Offset: 0x000005D2
		public static bool IsLogLevelVisible(Logger.LogLevel logLevel)
		{
			return logLevel >= Logger.CurrentLogLevel;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023DF File Offset: 0x000005DF
		public static void UpdateCurrentLogLevel()
		{
			if (Logger.OnGetLogLevel != null)
			{
				Logger.CurrentLogLevel = Logger.OnGetLogLevel();
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000023F7 File Offset: 0x000005F7
		public static void Log(string message)
		{
			Logger.UpdateCurrentLogLevel();
			if (Logger.IsLogLevelVisible(Logger.LogLevel.Log))
			{
				Debug.Log("UGUI Blurred Background: " + message + "\nYou can change the verbosity of logs in the Settings under Tools > UGUI Blurred Background > Settings : LogLevel");
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000241B File Offset: 0x0000061B
		public static void LogWarning(string message)
		{
			Logger.UpdateCurrentLogLevel();
			if (Logger.IsLogLevelVisible(Logger.LogLevel.Warning))
			{
				Debug.LogWarning("UGUI Blurred Background: " + message + "\nYou can change the verbosity of logs in the Settings under Tools > UGUI Blurred Background > Settings : LogLevel");
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000243F File Offset: 0x0000063F
		public static void LogError(string message)
		{
			Logger.UpdateCurrentLogLevel();
			if (Logger.IsLogLevelVisible(Logger.LogLevel.Error))
			{
				Debug.LogError("UGUI Blurred Background: " + message + "\nYou can change the verbosity of logs in the Settings under Tools > UGUI Blurred Background > Settings : LogLevel");
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002463 File Offset: 0x00000663
		public static void LogMessage(string message)
		{
			Logger.UpdateCurrentLogLevel();
			if (Logger.IsLogLevelVisible(Logger.LogLevel.Message))
			{
				Debug.Log("UGUI Blurred Background: " + message + "\nYou can change the verbosity of logs in the Settings under Tools > UGUI Blurred Background > Settings : LogLevel");
			}
		}

		// Token: 0x04000018 RID: 24
		public const string Prefix = "UGUI Blurred Background: ";

		// Token: 0x04000019 RID: 25
		public static Logger.LogLevel CurrentLogLevel = Logger.LogLevel.Warning;

		// Token: 0x0400001A RID: 26
		public static Func<Logger.LogLevel> OnGetLogLevel = null;

		// Token: 0x0400001B RID: 27
		private const string changeHint = "\nYou can change the verbosity of logs in the Settings under Tools > UGUI Blurred Background > Settings : LogLevel";

		// Token: 0x0200001E RID: 30
		// (Invoke) Token: 0x060000F7 RID: 247
		public delegate void LogCallback(string msg, Logger.LogLevel logLevel);

		// Token: 0x0200001F RID: 31
		public enum LogLevel
		{
			// Token: 0x04000088 RID: 136
			Log,
			// Token: 0x04000089 RID: 137
			Warning,
			// Token: 0x0400008A RID: 138
			Error,
			// Token: 0x0400008B RID: 139
			Message,
			// Token: 0x0400008C RID: 140
			NoLogs = 99
		}
	}
}
