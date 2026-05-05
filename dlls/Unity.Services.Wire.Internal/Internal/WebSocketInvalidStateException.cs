using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000037 RID: 55
	internal class WebSocketInvalidStateException : WebSocketException
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x00003D2C File Offset: 0x00001F2C
		public WebSocketInvalidStateException()
		{
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003D34 File Offset: 0x00001F34
		public WebSocketInvalidStateException(string message) : base(message)
		{
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00003D3D File Offset: 0x00001F3D
		public WebSocketInvalidStateException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
