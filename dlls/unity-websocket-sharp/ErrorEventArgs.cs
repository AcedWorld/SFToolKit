using System;

namespace UnityWebSocketSharp
{
	// Token: 0x02000007 RID: 7
	internal class ErrorEventArgs : EventArgs
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000020F8 File Offset: 0x000002F8
		internal ErrorEventArgs(string message) : this(message, null)
		{
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002102 File Offset: 0x00000302
		internal ErrorEventArgs(string message, Exception exception)
		{
			this._message = message;
			this._exception = exception;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002118 File Offset: 0x00000318
		public Exception Exception
		{
			get
			{
				return this._exception;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002120 File Offset: 0x00000320
		public string Message
		{
			get
			{
				return this._message;
			}
		}

		// Token: 0x04000017 RID: 23
		private Exception _exception;

		// Token: 0x04000018 RID: 24
		private string _message;
	}
}
