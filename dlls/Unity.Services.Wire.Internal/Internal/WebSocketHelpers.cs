using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000033 RID: 51
	internal static class WebSocketHelpers
	{
		// Token: 0x060000CD RID: 205 RVA: 0x00003C25 File Offset: 0x00001E25
		public static WebSocketCloseCode ParseCloseCodeEnum(int closeCode)
		{
			if (Enum.IsDefined(typeof(WebSocketCloseCode), closeCode))
			{
				return (WebSocketCloseCode)closeCode;
			}
			return WebSocketCloseCode.Undefined;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003C48 File Offset: 0x00001E48
		public static WebSocketException GetErrorMessageFromCode(int errorCode, Exception inner)
		{
			switch (errorCode)
			{
			case -7:
				return new WebSocketInvalidArgumentException("Cannot close WebSocket. An invalid code was specified or reason is too long.", inner);
			case -6:
				return new WebSocketInvalidStateException("WebSocket is not in open state.", inner);
			case -5:
				return new WebSocketInvalidStateException("WebSocket is already closed.", inner);
			case -4:
				return new WebSocketInvalidStateException("WebSocket is already closing.", inner);
			case -3:
				return new WebSocketInvalidStateException("WebSocket is not connected.", inner);
			case -2:
				return new WebSocketInvalidStateException("WebSocket is already connected or in connecting state.", inner);
			case -1:
				return new WebSocketUnexpectedException("WebSocket instance not found.", inner);
			default:
				return new WebSocketUnexpectedException("Unknown error.", inner);
			}
		}
	}
}
