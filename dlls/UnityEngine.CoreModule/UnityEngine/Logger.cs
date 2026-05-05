using System;
using System.Globalization;

namespace UnityEngine
{
	// Token: 0x020001E6 RID: 486
	public class Logger : ILogger, ILogHandler
	{
		// Token: 0x060014C9 RID: 5321 RVA: 0x00009E2F File Offset: 0x0000802F
		private Logger()
		{
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x0001E48E File Offset: 0x0001C68E
		public Logger(ILogHandler logHandler)
		{
			this.logHandler = logHandler;
			this.logEnabled = true;
			this.filterLogType = LogType.Log;
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x060014CB RID: 5323 RVA: 0x0001E4B0 File Offset: 0x0001C6B0
		// (set) Token: 0x060014CC RID: 5324 RVA: 0x0001E4B8 File Offset: 0x0001C6B8
		public ILogHandler logHandler { get; set; }

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x060014CD RID: 5325 RVA: 0x0001E4C1 File Offset: 0x0001C6C1
		// (set) Token: 0x060014CE RID: 5326 RVA: 0x0001E4C9 File Offset: 0x0001C6C9
		public bool logEnabled { get; set; }

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x060014CF RID: 5327 RVA: 0x0001E4D2 File Offset: 0x0001C6D2
		// (set) Token: 0x060014D0 RID: 5328 RVA: 0x0001E4DA File Offset: 0x0001C6DA
		public LogType filterLogType { get; set; }

		// Token: 0x060014D1 RID: 5329 RVA: 0x0001E4E4 File Offset: 0x0001C6E4
		public bool IsLogTypeAllowed(LogType logType)
		{
			bool logEnabled = this.logEnabled;
			if (logEnabled)
			{
				bool flag = logType == LogType.Exception;
				if (flag)
				{
					return true;
				}
				bool flag2 = this.filterLogType != LogType.Exception;
				if (flag2)
				{
					return logType <= this.filterLogType;
				}
			}
			return false;
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x0001E530 File Offset: 0x0001C730
		private static string GetString(object message)
		{
			bool flag = message == null;
			string result;
			if (flag)
			{
				result = "Null";
			}
			else
			{
				IFormattable formattable = message as IFormattable;
				bool flag2 = formattable != null;
				if (flag2)
				{
					result = formattable.ToString(null, CultureInfo.InvariantCulture);
				}
				else
				{
					result = message.ToString();
				}
			}
			return result;
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x0001E57C File Offset: 0x0001C77C
		public void Log(LogType logType, object message)
		{
			bool flag = this.IsLogTypeAllowed(logType);
			if (flag)
			{
				this.logHandler.LogFormat(logType, null, "{0}", new object[]
				{
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x0001E5B8 File Offset: 0x0001C7B8
		public void Log(LogType logType, object message, Object context)
		{
			bool flag = this.IsLogTypeAllowed(logType);
			if (flag)
			{
				this.logHandler.LogFormat(logType, context, "{0}", new object[]
				{
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x0001E5F4 File Offset: 0x0001C7F4
		public void Log(LogType logType, string tag, object message)
		{
			bool flag = this.IsLogTypeAllowed(logType);
			if (flag)
			{
				this.logHandler.LogFormat(logType, null, "{0}: {1}", new object[]
				{
					tag,
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x0001E634 File Offset: 0x0001C834
		public void Log(LogType logType, string tag, object message, Object context)
		{
			bool flag = this.IsLogTypeAllowed(logType);
			if (flag)
			{
				this.logHandler.LogFormat(logType, context, "{0}: {1}", new object[]
				{
					tag,
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x0001E674 File Offset: 0x0001C874
		public void Log(object message)
		{
			bool flag = this.IsLogTypeAllowed(LogType.Log);
			if (flag)
			{
				this.logHandler.LogFormat(LogType.Log, null, "{0}", new object[]
				{
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x0001E6B0 File Offset: 0x0001C8B0
		public void Log(string tag, object message)
		{
			bool flag = this.IsLogTypeAllowed(LogType.Log);
			if (flag)
			{
				this.logHandler.LogFormat(LogType.Log, null, "{0}: {1}", new object[]
				{
					tag,
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x0001E6F0 File Offset: 0x0001C8F0
		public void Log(string tag, object message, Object context)
		{
			bool flag = this.IsLogTypeAllowed(LogType.Log);
			if (flag)
			{
				this.logHandler.LogFormat(LogType.Log, context, "{0}: {1}", new object[]
				{
					tag,
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x0001E730 File Offset: 0x0001C930
		public void LogWarning(string tag, object message)
		{
			bool flag = this.IsLogTypeAllowed(LogType.Warning);
			if (flag)
			{
				this.logHandler.LogFormat(LogType.Warning, null, "{0}: {1}", new object[]
				{
					tag,
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x0001E770 File Offset: 0x0001C970
		public void LogWarning(string tag, object message, Object context)
		{
			bool flag = this.IsLogTypeAllowed(LogType.Warning);
			if (flag)
			{
				this.logHandler.LogFormat(LogType.Warning, context, "{0}: {1}", new object[]
				{
					tag,
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x0001E7B0 File Offset: 0x0001C9B0
		public void LogError(string tag, object message)
		{
			bool flag = this.IsLogTypeAllowed(LogType.Error);
			if (flag)
			{
				this.logHandler.LogFormat(LogType.Error, null, "{0}: {1}", new object[]
				{
					tag,
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x0001E7F0 File Offset: 0x0001C9F0
		public void LogError(string tag, object message, Object context)
		{
			bool flag = this.IsLogTypeAllowed(LogType.Error);
			if (flag)
			{
				this.logHandler.LogFormat(LogType.Error, context, "{0}: {1}", new object[]
				{
					tag,
					Logger.GetString(message)
				});
			}
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x0001E830 File Offset: 0x0001CA30
		public void LogException(Exception exception)
		{
			bool logEnabled = this.logEnabled;
			if (logEnabled)
			{
				this.logHandler.LogException(exception, null);
			}
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x0001E858 File Offset: 0x0001CA58
		public void LogException(Exception exception, Object context)
		{
			bool logEnabled = this.logEnabled;
			if (logEnabled)
			{
				this.logHandler.LogException(exception, context);
			}
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x0001E880 File Offset: 0x0001CA80
		public void LogFormat(LogType logType, string format, params object[] args)
		{
			bool flag = this.IsLogTypeAllowed(logType);
			if (flag)
			{
				this.logHandler.LogFormat(logType, null, format, args);
			}
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x0001E8AC File Offset: 0x0001CAAC
		public void LogFormat(LogType logType, Object context, string format, params object[] args)
		{
			bool flag = this.IsLogTypeAllowed(logType);
			if (flag)
			{
				this.logHandler.LogFormat(logType, context, format, args);
			}
		}

		// Token: 0x040007CD RID: 1997
		private const string kNoTagFormat = "{0}";

		// Token: 0x040007CE RID: 1998
		private const string kTagFormat = "{0}: {1}";
	}
}
