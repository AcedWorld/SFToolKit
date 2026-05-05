using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace UnityWebSocketSharp
{
	// Token: 0x0200000D RID: 13
	internal class LogData
	{
		// Token: 0x0600009D RID: 157 RVA: 0x0000435C File Offset: 0x0000255C
		internal LogData(LogLevel level, StackFrame caller, string message)
		{
			this._level = level;
			this._caller = caller;
			this._message = (message ?? string.Empty);
			this._date = DateTime.Now;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000438D File Offset: 0x0000258D
		public StackFrame Caller
		{
			get
			{
				return this._caller;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00004395 File Offset: 0x00002595
		public DateTime Date
		{
			get
			{
				return this._date;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x0000439D File Offset: 0x0000259D
		public LogLevel Level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000043A5 File Offset: 0x000025A5
		public string Message
		{
			get
			{
				return this._message;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000043B0 File Offset: 0x000025B0
		public override string ToString()
		{
			string text = string.Format("[{0}]", this._date);
			string text2 = string.Format("{0,-5}", this._level.ToString().ToUpper());
			MethodBase method = this._caller.GetMethod();
			Type declaringType = method.DeclaringType;
			string text3 = string.Format("{0}.{1}", declaringType.Name, method.Name);
			string[] array = this._message.Replace("\r\n", "\n").TrimEnd('\n').Split('\n', StringSplitOptions.None);
			if (array.Length <= 1)
			{
				return string.Format("{0} {1} {2} {3}", new object[]
				{
					text,
					text2,
					text3,
					this._message
				});
			}
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.AppendFormat("{0} {1} {2}\n\n", text, text2, text3);
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.AppendFormat("  {0}\n", array[i]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0400002C RID: 44
		private StackFrame _caller;

		// Token: 0x0400002D RID: 45
		private DateTime _date;

		// Token: 0x0400002E RID: 46
		private LogLevel _level;

		// Token: 0x0400002F RID: 47
		private string _message;
	}
}
