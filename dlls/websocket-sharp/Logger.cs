using System;
using System.Diagnostics;
using System.IO;

namespace WebSocketSharp
{
	// Token: 0x02000012 RID: 18
	public class Logger
	{
		// Token: 0x0600012D RID: 301 RVA: 0x000097EF File Offset: 0x000079EF
		public Logger() : this(LogLevel.Error, null, null)
		{
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000097FC File Offset: 0x000079FC
		public Logger(LogLevel level) : this(level, null, null)
		{
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00009809 File Offset: 0x00007A09
		public Logger(LogLevel level, string file, Action<LogData, string> output)
		{
			this._level = level;
			this._file = file;
			this._output = (output ?? new Action<LogData, string>(Logger.defaultOutput));
			this._sync = new object();
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00009848 File Offset: 0x00007A48
		// (set) Token: 0x06000131 RID: 305 RVA: 0x00009864 File Offset: 0x00007A64
		public string File
		{
			get
			{
				return this._file;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					this._file = value;
					this.Warn(string.Format("The current path to the log file has been changed to {0}.", this._file));
				}
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000132 RID: 306 RVA: 0x000098C8 File Offset: 0x00007AC8
		// (set) Token: 0x06000133 RID: 307 RVA: 0x000098E4 File Offset: 0x00007AE4
		public LogLevel Level
		{
			get
			{
				return this._level;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					this._level = value;
					this.Warn(string.Format("The current logging level has been changed to {0}.", this._level));
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000134 RID: 308 RVA: 0x0000994C File Offset: 0x00007B4C
		// (set) Token: 0x06000135 RID: 309 RVA: 0x00009964 File Offset: 0x00007B64
		public Action<LogData, string> Output
		{
			get
			{
				return this._output;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					this._output = (value ?? new Action<LogData, string>(Logger.defaultOutput));
					this.Warn("The current output action has been changed.");
				}
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000099C8 File Offset: 0x00007BC8
		private static void defaultOutput(LogData data, string path)
		{
			string value = data.ToString();
			Console.WriteLine(value);
			bool flag = path != null && path.Length > 0;
			if (flag)
			{
				Logger.writeToFile(value, path);
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00009A00 File Offset: 0x00007C00
		private void output(string message, LogLevel level)
		{
			object sync = this._sync;
			lock (sync)
			{
				bool flag2 = this._level > level;
				if (!flag2)
				{
					try
					{
						LogData logData = new LogData(level, new StackFrame(2, true), message);
						this._output(logData, this._file);
					}
					catch (Exception ex)
					{
						LogData logData = new LogData(LogLevel.Fatal, new StackFrame(0, true), ex.Message);
						Console.WriteLine(logData.ToString());
					}
				}
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00009AB0 File Offset: 0x00007CB0
		private static void writeToFile(string value, string path)
		{
			using (StreamWriter streamWriter = new StreamWriter(path, true))
			{
				using (TextWriter textWriter = TextWriter.Synchronized(streamWriter))
				{
					textWriter.WriteLine(value);
				}
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00009B0C File Offset: 0x00007D0C
		public void Debug(string message)
		{
			bool flag = this._level > LogLevel.Debug;
			if (!flag)
			{
				this.output(message, LogLevel.Debug);
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00009B34 File Offset: 0x00007D34
		public void Error(string message)
		{
			bool flag = this._level > LogLevel.Error;
			if (!flag)
			{
				this.output(message, LogLevel.Error);
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00009B5C File Offset: 0x00007D5C
		public void Fatal(string message)
		{
			this.output(message, LogLevel.Fatal);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00009B68 File Offset: 0x00007D68
		public void Info(string message)
		{
			bool flag = this._level > LogLevel.Info;
			if (!flag)
			{
				this.output(message, LogLevel.Info);
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00009B90 File Offset: 0x00007D90
		public void Trace(string message)
		{
			bool flag = this._level > LogLevel.Trace;
			if (!flag)
			{
				this.output(message, LogLevel.Trace);
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00009BB8 File Offset: 0x00007DB8
		public void Warn(string message)
		{
			bool flag = this._level > LogLevel.Warn;
			if (!flag)
			{
				this.output(message, LogLevel.Warn);
			}
		}

		// Token: 0x04000077 RID: 119
		private volatile string _file;

		// Token: 0x04000078 RID: 120
		private volatile LogLevel _level;

		// Token: 0x04000079 RID: 121
		private Action<LogData, string> _output;

		// Token: 0x0400007A RID: 122
		private object _sync;
	}
}
