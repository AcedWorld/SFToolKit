using System;

namespace UnityWebSocketSharp
{
	// Token: 0x02000016 RID: 22
	internal class WebSocketException : Exception
	{
		// Token: 0x06000153 RID: 339 RVA: 0x0000809E File Offset: 0x0000629E
		private WebSocketException(ushort code, string message, Exception innerException) : base(message ?? code.GetErrorMessage(), innerException)
		{
			this._code = code;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000080B9 File Offset: 0x000062B9
		internal WebSocketException() : this(CloseStatusCode.Abnormal, null, null)
		{
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000080C8 File Offset: 0x000062C8
		internal WebSocketException(Exception innerException) : this(CloseStatusCode.Abnormal, null, innerException)
		{
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000080D7 File Offset: 0x000062D7
		internal WebSocketException(string message) : this(CloseStatusCode.Abnormal, message, null)
		{
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000080E6 File Offset: 0x000062E6
		internal WebSocketException(CloseStatusCode code) : this(code, null, null)
		{
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000080F1 File Offset: 0x000062F1
		internal WebSocketException(string message, Exception innerException) : this(CloseStatusCode.Abnormal, message, innerException)
		{
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00008100 File Offset: 0x00006300
		internal WebSocketException(CloseStatusCode code, Exception innerException) : this(code, null, innerException)
		{
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000810B File Offset: 0x0000630B
		internal WebSocketException(CloseStatusCode code, string message) : this(code, message, null)
		{
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00008116 File Offset: 0x00006316
		internal WebSocketException(CloseStatusCode code, string message, Exception innerException) : this((ushort)code, message, innerException)
		{
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00008121 File Offset: 0x00006321
		public ushort Code
		{
			get
			{
				return this._code;
			}
		}

		// Token: 0x04000088 RID: 136
		private ushort _code;
	}
}
