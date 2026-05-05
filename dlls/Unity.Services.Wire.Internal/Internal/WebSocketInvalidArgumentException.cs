using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000036 RID: 54
	internal class WebSocketInvalidArgumentException : WebSocketException
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x00003D11 File Offset: 0x00001F11
		public WebSocketInvalidArgumentException()
		{
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00003D19 File Offset: 0x00001F19
		public WebSocketInvalidArgumentException(string message) : base(message)
		{
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00003D22 File Offset: 0x00001F22
		public WebSocketInvalidArgumentException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
