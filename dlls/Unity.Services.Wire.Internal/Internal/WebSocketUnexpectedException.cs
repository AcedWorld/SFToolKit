using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000035 RID: 53
	internal class WebSocketUnexpectedException : WebSocketException
	{
		// Token: 0x060000D2 RID: 210 RVA: 0x00003CF6 File Offset: 0x00001EF6
		public WebSocketUnexpectedException()
		{
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003CFE File Offset: 0x00001EFE
		public WebSocketUnexpectedException(string message) : base(message)
		{
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00003D07 File Offset: 0x00001F07
		public WebSocketUnexpectedException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
