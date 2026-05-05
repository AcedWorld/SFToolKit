using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Rewired.Config;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	// Token: 0x020000BC RID: 188
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal static class Logger
	{
		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00008118 File Offset: 0x00006318
		private static List<string> screenLog
		{
			get
			{
				List<string> result;
				if ((result = Logger.__screenLog) == null)
				{
					result = (Logger.__screenLog = new List<string>());
				}
				return result;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000716 RID: 1814 RVA: 0x0000812E File Offset: 0x0000632E
		private static LogLevelFlags logLevel
		{
			get
			{
				if (!ReInput.isReady || ReInput.configVars == null)
				{
					return LogLevelFlags.Info | LogLevelFlags.Warning | LogLevelFlags.Error;
				}
				return ReInput.configVars.logLevel;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x0000814A File Offset: 0x0000634A
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x0003BE88 File Offset: 0x0003A088
		public static bool logToScreen
		{
			get
			{
				return Logger._logToScreen;
			}
			set
			{
				if (value == Logger._logToScreen)
				{
					return;
				}
				if (value)
				{
					Logger._guiText = new GameObject("Screen Log").AddComponent<GUIText>();
					Logger._guiText.anchor = TextAnchor.LowerLeft;
				}
				else if (Logger._guiText != null)
				{
					Object.Destroy(Logger._guiText.gameObject);
				}
				Logger._logToScreen = value;
			}
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00008151 File Offset: 0x00006351
		public static void LogEditor(object msg)
		{
			Logger.LogEditor(msg, false);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0000815A File Offset: 0x0000635A
		public static void LogEditor(object msg, bool requiredThreadSafety)
		{
			if (!requiredThreadSafety && !Application.isEditor)
			{
				return;
			}
			if (UnityTools.isInitialized && !UnityTools.isEditor)
			{
				return;
			}
			Logger.Log(msg, requiredThreadSafety);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0000817D File Offset: 0x0000637D
		public static void LogWarningEditor(object msg)
		{
			Logger.LogWarningEditor(msg, false);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00008186 File Offset: 0x00006386
		public static void LogWarningEditor(object msg, bool requiredThreadSafety)
		{
			if (!requiredThreadSafety && !Application.isEditor)
			{
				return;
			}
			if (UnityTools.isInitialized && !UnityTools.isEditor)
			{
				return;
			}
			Logger.LogWarning(msg, requiredThreadSafety);
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x000081A9 File Offset: 0x000063A9
		public static void LogErrorEditor(object msg)
		{
			Logger.LogErrorEditor(msg, false);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x000081B2 File Offset: 0x000063B2
		public static void LogErrorEditor(object msg, bool requiredThreadSafety)
		{
			if (!requiredThreadSafety && !Application.isEditor)
			{
				return;
			}
			if (UnityTools.isInitialized && !UnityTools.isEditor)
			{
				return;
			}
			Logger.LogError(msg, requiredThreadSafety);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x000081D5 File Offset: 0x000063D5
		public static void Log(object msg)
		{
			Logger.Log(msg, false);
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x000081DE File Offset: 0x000063DE
		public static void Log(object msg, bool requiredThreadSafety)
		{
			if (!Logger.IsLoggingAllowed(LogLevel.Info))
			{
				return;
			}
			if (msg == null)
			{
				msg = string.Empty;
			}
			Logger.LogNow(msg, requiredThreadSafety);
			if (Logger._logToScreen)
			{
				Logger.LogToScreen(msg);
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00008207 File Offset: 0x00006407
		public static void LogWarning(object msg)
		{
			Logger.LogWarning(msg, false);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0003BEE4 File Offset: 0x0003A0E4
		public static void LogWarning(object msg, bool requiredThreadSafety)
		{
			if (!Logger.IsLoggingAllowed(LogLevel.Warning))
			{
				return;
			}
			if (msg == null)
			{
				msg = string.Empty;
			}
			if (ReInput.isReady && !UnityTools.isEditor)
			{
				msg = "[WARNING] " + ((msg != null) ? msg.ToString() : null);
			}
			Logger.LogWarningNow(msg, requiredThreadSafety);
			if (Logger._logToScreen)
			{
				Logger.LogToScreen(msg);
			}
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00008210 File Offset: 0x00006410
		public static void LogError(object msg)
		{
			Logger.LogError(msg, false);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0003BF40 File Offset: 0x0003A140
		public static void LogError(object msg, bool requiredThreadSafety)
		{
			if (!Logger.IsLoggingAllowed(LogLevel.Error))
			{
				return;
			}
			if (msg == null)
			{
				msg = string.Empty;
			}
			if (ReInput.isReady && !UnityTools.isEditor)
			{
				msg = "[ERROR] " + ((msg != null) ? msg.ToString() : null);
			}
			msg = ((msg != null) ? msg.ToString() : null) + "\n------- Rewired System Info -------\n";
			msg = ((msg != null) ? msg.ToString() : null) + "Unity version: " + UnityTools.unityVersionString + "\n";
			msg = ((msg != null) ? msg.ToString() : null) + "Rewired version: " + ReInput.programVersion + "\n";
			msg = ((msg != null) ? msg.ToString() : null) + "Platform: " + UnityTools.platform.ToString() + "\n";
			if (UnityTools.editorPlatform != EditorPlatform.None)
			{
				msg = ((msg != null) ? msg.ToString() : null) + "Editor Platform: " + UnityTools.editorPlatform.ToString() + "\n";
			}
			if (UnityTools.webplayerPlatform != WebplayerPlatform.None)
			{
				msg = ((msg != null) ? msg.ToString() : null) + "Webplayer Platform: " + UnityTools.webplayerPlatform.ToString() + "\n";
			}
			msg = ((msg != null) ? msg.ToString() : null) + "Using Unity input: " + ReInput.usingUnityInput.ToString() + "\n";
			if (ReInput.isReady && ReInput.UserData != null && ReInput.UserData.ConfigVars != null)
			{
				msg = ((msg != null) ? msg.ToString() : null) + ReInput.UserData.ConfigVars.GetDebugConfigSettings();
			}
			Logger.LogErrorNow(msg, requiredThreadSafety);
			if (Logger._logToScreen)
			{
				Logger.LogToScreen(msg);
			}
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00008219 File Offset: 0x00006419
		public static void LogException(Exception exception, object msg)
		{
			Logger.LogException(exception, msg, false);
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0003C0FC File Offset: 0x0003A2FC
		public static void LogException(Exception exception, object msg, bool requiredThreadSafety)
		{
			if (msg == null)
			{
				msg = string.Empty;
			}
			if (ReInput.isReady && !UnityTools.isEditor)
			{
				msg = "[EXCEPTION] " + ((msg != null) ? msg.ToString() : null);
			}
			msg = ((msg != null) ? msg.ToString() : null) + "\n------- Rewired System Info -------\n";
			msg = ((msg != null) ? msg.ToString() : null) + "Unity version: " + UnityTools.unityVersionString + "\n";
			msg = ((msg != null) ? msg.ToString() : null) + "Rewired version: " + ReInput.programVersion + "\n";
			msg = ((msg != null) ? msg.ToString() : null) + "Platform: " + UnityTools.platform.ToString() + "\n";
			if (UnityTools.editorPlatform != EditorPlatform.None)
			{
				msg = ((msg != null) ? msg.ToString() : null) + "Editor Platform: " + UnityTools.editorPlatform.ToString() + "\n";
			}
			if (UnityTools.webplayerPlatform != WebplayerPlatform.None)
			{
				msg = ((msg != null) ? msg.ToString() : null) + "Webplayer Platform: " + UnityTools.webplayerPlatform.ToString() + "\n";
			}
			msg = ((msg != null) ? msg.ToString() : null) + "Using Unity input: " + ReInput.usingUnityInput.ToString() + "\n";
			if (ReInput.isReady && ReInput.UserData != null && ReInput.UserData.ConfigVars != null)
			{
				msg = ((msg != null) ? msg.ToString() : null) + ReInput.UserData.ConfigVars.GetDebugConfigSettings();
			}
			Logger.LogExceptionNow(exception, msg, requiredThreadSafety);
			if (Logger._logToScreen)
			{
				Logger.LogToScreen(msg);
			}
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00008223 File Offset: 0x00006423
		private static void LogNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				Debug.Log(Logger.FormatMessage(msg));
				return;
			}
			if (UnityTools.logToDebugLog)
			{
				Debug.unityLogger.Log("Rewired", msg);
				return;
			}
			Console.WriteLine(Logger.FormatMessage(msg));
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x00008257 File Offset: 0x00006457
		private static void LogWarningNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				Debug.LogWarning(Logger.FormatMessage(msg));
				return;
			}
			if (UnityTools.logToDebugLog)
			{
				Debug.unityLogger.LogWarning("Rewired", msg);
				return;
			}
			Console.WriteLine(Logger.FormatMessage(msg));
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0000828B File Offset: 0x0000648B
		private static void LogErrorNow(object msg, bool requireThreadSafety)
		{
			if (requireThreadSafety)
			{
				Debug.LogError(Logger.FormatMessage(msg));
				return;
			}
			if (UnityTools.logToDebugLog)
			{
				Debug.unityLogger.LogError("Rewired", msg);
				return;
			}
			Console.WriteLine(Logger.FormatMessage(msg));
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0003C2B0 File Offset: 0x0003A4B0
		private static void LogExceptionNow(Exception exception, object msg, bool requireThreadSafety)
		{
			if (msg is string && string.IsNullOrEmpty((string)msg))
			{
				msg = null;
			}
			if (requireThreadSafety)
			{
				if (Logger.IsLoggingAllowed(LogLevel.Error) && msg != null)
				{
					Debug.LogError(Logger.FormatMessage(msg));
				}
				Debug.LogException(exception);
				return;
			}
			if (UnityTools.logToDebugLog)
			{
				if (Logger.IsLoggingAllowed(LogLevel.Error) && msg != null)
				{
					Debug.unityLogger.LogError("Rewired", msg);
				}
				Debug.unityLogger.LogException(exception);
				return;
			}
			if (Logger.IsLoggingAllowed(LogLevel.Error) && msg != null)
			{
				Console.WriteLine(Logger.FormatMessage(msg));
			}
			Console.WriteLine(exception.ToString());
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0003C344 File Offset: 0x0003A544
		private static bool IsLoggingAllowed(LogLevel logLevel)
		{
			switch (logLevel)
			{
			case LogLevel.Info:
				if ((Logger.logLevel & LogLevelFlags.Info) != LogLevelFlags.Off)
				{
					return true;
				}
				break;
			case LogLevel.Warning:
				if ((Logger.logLevel & LogLevelFlags.Warning) != LogLevelFlags.Off)
				{
					return true;
				}
				break;
			case LogLevel.Error:
				if ((Logger.logLevel & LogLevelFlags.Error) != LogLevelFlags.Off)
				{
					return true;
				}
				break;
			case LogLevel.Debug:
				if ((Logger.logLevel & LogLevelFlags.Debug) != LogLevelFlags.Off)
				{
					return true;
				}
				break;
			default:
				throw new NotImplementedException();
			}
			return false;
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0003C39C File Offset: 0x0003A59C
		private static void LogToScreen(object msg)
		{
			if (msg == null)
			{
				return;
			}
			string text = msg.ToString();
			if (Regex.IsMatch(text, "(\r\n|\r|\n)"))
			{
				Regex.Replace(text, "(\r\n|\r|\n)", "\n");
				string[] array = text.Split('\n', StringSplitOptions.None);
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i]))
					{
						array[i] = array[i].Trim();
						if (!string.IsNullOrEmpty(array[i]))
						{
							Logger.screenLog.Add(array[i]);
						}
					}
				}
			}
			else
			{
				Logger.screenLog.Add(text);
			}
			int num = Logger.screenLog.Count - 50;
			if (num > 0)
			{
				Logger.screenLog.RemoveRange(0, num);
			}
			Logger._guiText.text = "";
			if (Logger.screenLog.Count > 0)
			{
				for (int j = 0; j < Logger.screenLog.Count; j++)
				{
					GUIText guiText = Logger._guiText;
					guiText.text = guiText.text + Logger.screenLog[j] + "\n";
				}
			}
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x000082BF File Offset: 0x000064BF
		[Conditional("LOG_INIT")]
		public static void LogInit(object o)
		{
			Logger.Log(o, true);
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x000082C8 File Offset: 0x000064C8
		[Conditional("LOG_INIT")]
		public static void LogInitError(object o)
		{
			Logger.LogError(o, true);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x000082D1 File Offset: 0x000064D1
		[Conditional("LOG_INIT")]
		public static void LogInitWarning(object o)
		{
			Logger.LogWarning(o, true);
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x000082DA File Offset: 0x000064DA
		[Conditional("LOG_VC")]
		public static void Log_VCTest(object o)
		{
			Logger.Log(o);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x000082BF File Offset: 0x000064BF
		[Conditional("LOG_UPDATE")]
		public static void LogUpdate(object o)
		{
			Logger.Log(o, true);
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x000082E2 File Offset: 0x000064E2
		private static object FormatMessage(object o)
		{
			if (!(o is string))
			{
				return o;
			}
			if (string.IsNullOrEmpty((string)o))
			{
				return o;
			}
			return "Rewired: " + ((o != null) ? o.ToString() : null);
		}

		// Token: 0x0400043D RID: 1085
		private const int screenLogLength = 50;

		// Token: 0x0400043E RID: 1086
		private static List<string> __screenLog;

		// Token: 0x0400043F RID: 1087
		private static GUIText _guiText;

		// Token: 0x04000440 RID: 1088
		private static bool _logToScreen;
	}
}
