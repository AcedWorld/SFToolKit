using System;
using System.Diagnostics;
using System.IO;

namespace UnityWebSocketSharp
{
	// Token: 0x0200000E RID: 14
	internal class Logger
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x000044B9 File Offset: 0x000026B9
		public Logger() : this(LogLevel.Error, null, null)
		{
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000044C4 File Offset: 0x000026C4
		public Logger(LogLevel level) : this(level, null, null)
		{
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000044CF File Offset: 0x000026CF
		public Logger(LogLevel level, string file, Action<LogData, string> output)
		{
			this._level = level;
			this._file = file;
			this._output = (output ?? new Action<LogData, string>(Logger.defaultOutput));
			this._sync = new object();
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x0000450B File Offset: 0x0000270B
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x00004518 File Offset: 0x00002718
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
				}
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x0000455C File Offset: 0x0000275C
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00004568 File Offset: 0x00002768
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
				}
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000AA RID: 170 RVA: 0x000045AC File Offset: 0x000027AC
		// (set) Token: 0x060000AB RID: 171 RVA: 0x000045B4 File Offset: 0x000027B4
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
				}
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00004608 File Offset: 0x00002808
		private static void defaultOutput(LogData data, string path)
		{
			string value = data.ToString();
			Console.WriteLine(value);
			if (path != null && path.Length > 0)
			{
				Logger.writeToFile(value, path);
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00004638 File Offset: 0x00002838
		private void output(string message, LogLevel level)
		{
			object sync = this._sync;
			lock (sync)
			{
				if (this._level <= level)
				{
					try
					{
						LogData arg = new LogData(level, new StackFrame(2, true), message);
						this._output(arg, this._file);
					}
					catch (Exception ex)
					{
						Console.WriteLine(new LogData(LogLevel.Fatal, new StackFrame(0, true), ex.Message).ToString());
					}
				}
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000046D0 File Offset: 0x000028D0
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

		// Token: 0x060000AF RID: 175 RVA: 0x00004728 File Offset: 0x00002928
		public void Debug(string message)
		{
			if (this._level > LogLevel.Debug)
			{
				return;
			}
			this.output(message, LogLevel.Debug);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000473E File Offset: 0x0000293E
		public void Error(string message)
		{
			if (this._level > LogLevel.Error)
			{
				return;
			}
			this.output(message, LogLevel.Error);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004754 File Offset: 0x00002954
		public void Fatal(string message)
		{
			if (this._level > LogLevel.Fatal)
			{
				return;
			}
			this.output(message, LogLevel.Fatal);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000476A File Offset: 0x0000296A
		public void Info(string message)
		{
			if (this._level > LogLevel.Info)
			{
				return;
			}
			this.output(message, LogLevel.Info);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004780 File Offset: 0x00002980
		public void Trace(string message)
		{
			if (this._level > LogLevel.Trace)
			{
				return;
			}
			this.output(message, LogLevel.Trace);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004796 File Offset: 0x00002996
		public void Warn(string message)
		{
			if (this._level > LogLevel.Warn)
			{
				return;
			}
			this.output(message, LogLevel.Warn);
		}

		// Token: 0x04000030 RID: 48
		private volatile string _file;

		// Token: 0x04000031 RID: 49
		private volatile LogLevel _level;

		// Token: 0x04000032 RID: 50
		private Action<LogData, string> _output;

		// Token: 0x04000033 RID: 51
		private object _sync;
	}
}
