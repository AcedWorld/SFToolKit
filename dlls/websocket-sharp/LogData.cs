using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace WebSocketSharp
{
	// Token: 0x02000010 RID: 16
	public class LogData
	{
		// Token: 0x06000127 RID: 295 RVA: 0x00009628 File Offset: 0x00007828
		internal LogData(LogLevel level, StackFrame caller, string message)
		{
			this._level = level;
			this._caller = caller;
			this._message = (message ?? string.Empty);
			this._date = DateTime.Now;
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000128 RID: 296 RVA: 0x0000965C File Offset: 0x0000785C
		public StackFrame Caller
		{
			get
			{
				return this._caller;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00009674 File Offset: 0x00007874
		public DateTime Date
		{
			get
			{
				return this._date;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600012A RID: 298 RVA: 0x0000968C File Offset: 0x0000788C
		public LogLevel Level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600012B RID: 299 RVA: 0x000096A4 File Offset: 0x000078A4
		public string Message
		{
			get
			{
				return this._message;
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000096BC File Offset: 0x000078BC
		public override string ToString()
		{
			string text = string.Format("{0}|{1,-5}|", this._date, this._level);
			MethodBase method = this._caller.GetMethod();
			Type declaringType = method.DeclaringType;
			string arg = string.Format("{0}{1}.{2}|", text, declaringType.Name, method.Name);
			string[] array = this._message.Replace("\r\n", "\n").TrimEnd(new char[]
			{
				'\n'
			}).Split(new char[]
			{
				'\n'
			});
			bool flag = array.Length <= 1;
			string result;
			if (flag)
			{
				result = string.Format("{0}{1}", arg, this._message);
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder(string.Format("{0}{1}\n", arg, array[0]), 64);
				string format = string.Format("{{0,{0}}}{{1}}\n", text.Length);
				for (int i = 1; i < array.Length; i++)
				{
					stringBuilder.AppendFormat(format, "", array[i]);
				}
				StringBuilder stringBuilder2 = stringBuilder;
				int length = stringBuilder2.Length;
				stringBuilder2.Length = length - 1;
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x0400006C RID: 108
		private StackFrame _caller;

		// Token: 0x0400006D RID: 109
		private DateTime _date;

		// Token: 0x0400006E RID: 110
		private LogLevel _level;

		// Token: 0x0400006F RID: 111
		private string _message;
	}
}
