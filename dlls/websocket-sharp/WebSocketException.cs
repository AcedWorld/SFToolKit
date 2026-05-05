using System;

namespace WebSocketSharp
{
	// Token: 0x0200000F RID: 15
	public class WebSocketException : Exception
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00009588 File Offset: 0x00007788
		internal WebSocketException() : this(CloseStatusCode.Abnormal, null, null)
		{
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00009599 File Offset: 0x00007799
		internal WebSocketException(Exception innerException) : this(CloseStatusCode.Abnormal, null, innerException)
		{
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000095AA File Offset: 0x000077AA
		internal WebSocketException(string message) : this(CloseStatusCode.Abnormal, message, null)
		{
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000095BB File Offset: 0x000077BB
		internal WebSocketException(CloseStatusCode code) : this(code, null, null)
		{
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000095C8 File Offset: 0x000077C8
		internal WebSocketException(string message, Exception innerException) : this(CloseStatusCode.Abnormal, message, innerException)
		{
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000095D9 File Offset: 0x000077D9
		internal WebSocketException(CloseStatusCode code, Exception innerException) : this(code, null, innerException)
		{
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000095E6 File Offset: 0x000077E6
		internal WebSocketException(CloseStatusCode code, string message) : this(code, message, null)
		{
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000095F3 File Offset: 0x000077F3
		internal WebSocketException(CloseStatusCode code, string message, Exception innerException) : base(message ?? code.GetMessage(), innerException)
		{
			this._code = code;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00009610 File Offset: 0x00007810
		public CloseStatusCode Code
		{
			get
			{
				return this._code;
			}
		}

		// Token: 0x0400006B RID: 107
		private CloseStatusCode _code;
	}
}
