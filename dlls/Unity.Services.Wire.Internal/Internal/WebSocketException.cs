using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000034 RID: 52
	public class WebSocketException : Exception
	{
		// Token: 0x060000CF RID: 207 RVA: 0x00003CDB File Offset: 0x00001EDB
		public WebSocketException()
		{
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00003CE3 File Offset: 0x00001EE3
		public WebSocketException(string message) : base(message)
		{
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003CEC File Offset: 0x00001EEC
		public WebSocketException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
