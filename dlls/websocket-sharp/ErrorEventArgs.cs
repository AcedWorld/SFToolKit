using System;

namespace WebSocketSharp
{
	// Token: 0x02000006 RID: 6
	public class ErrorEventArgs : EventArgs
	{
		// Token: 0x06000079 RID: 121 RVA: 0x000047E0 File Offset: 0x000029E0
		internal ErrorEventArgs(string message) : this(message, null)
		{
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000047EC File Offset: 0x000029EC
		internal ErrorEventArgs(string message, Exception exception)
		{
			this._message = message;
			this._exception = exception;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00004804 File Offset: 0x00002A04
		public Exception Exception
		{
			get
			{
				return this._exception;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600007C RID: 124 RVA: 0x0000481C File Offset: 0x00002A1C
		public string Message
		{
			get
			{
				return this._message;
			}
		}

		// Token: 0x0400000D RID: 13
		private Exception _exception;

		// Token: 0x0400000E RID: 14
		private string _message;
	}
}
