using System;
using System.Security.Authentication;
using UnityWebSocketSharp;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x02000038 RID: 56
	internal class WebSocket : IWebSocket
	{
		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060000DB RID: 219 RVA: 0x00003D48 File Offset: 0x00001F48
		// (remove) Token: 0x060000DC RID: 220 RVA: 0x00003D80 File Offset: 0x00001F80
		public event WebSocketOpenEventHandler OnOpen;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060000DD RID: 221 RVA: 0x00003DB8 File Offset: 0x00001FB8
		// (remove) Token: 0x060000DE RID: 222 RVA: 0x00003DF0 File Offset: 0x00001FF0
		public event WebSocketMessageEventHandler OnMessage;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060000DF RID: 223 RVA: 0x00003E28 File Offset: 0x00002028
		// (remove) Token: 0x060000E0 RID: 224 RVA: 0x00003E60 File Offset: 0x00002060
		public event WebSocketErrorEventHandler OnError;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060000E1 RID: 225 RVA: 0x00003E98 File Offset: 0x00002098
		// (remove) Token: 0x060000E2 RID: 226 RVA: 0x00003ED0 File Offset: 0x000020D0
		public event WebSocketCloseEventHandler OnClose;

		// Token: 0x060000E3 RID: 227 RVA: 0x00003F08 File Offset: 0x00002108
		public WebSocket(string url)
		{
			try
			{
				this.ws = new WebSocket(url, Array.Empty<string>());
				this.ws.OnOpen += delegate(object sender, EventArgs ev)
				{
					WebSocketOpenEventHandler onOpen = this.OnOpen;
					if (onOpen == null)
					{
						return;
					}
					onOpen();
				};
				this.ws.OnMessage += delegate(object sender, MessageEventArgs ev)
				{
					if (ev.RawData != null)
					{
						WebSocketMessageEventHandler onMessage = this.OnMessage;
						if (onMessage == null)
						{
							return;
						}
						onMessage(ev.RawData);
					}
				};
				this.ws.OnError += delegate(object sender, ErrorEventArgs ev)
				{
					WebSocketErrorEventHandler onError = this.OnError;
					if (onError == null)
					{
						return;
					}
					onError(ev.Message);
				};
				this.ws.OnClose += delegate(object sender, CloseEventArgs ev)
				{
					WebSocketCloseEventHandler onClose = this.OnClose;
					if (onClose == null)
					{
						return;
					}
					onClose(WebSocketHelpers.ParseCloseCodeEnum((int)ev.Code));
				};
			}
			catch (Exception inner)
			{
				throw new WebSocketUnexpectedException("Failed to create WebSocket Client.", inner);
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003FA8 File Offset: 0x000021A8
		public void Connect()
		{
			if (this.ws.ReadyState == WebSocketState.Open || this.ws.ReadyState == WebSocketState.Closing)
			{
				throw new WebSocketInvalidStateException("WebSocket is already connected or is closing.");
			}
			try
			{
				if (this.ws.IsSecure)
				{
					this.ws.SslConfiguration.EnabledSslProtocols = SslProtocols.Tls12;
				}
				this.ws.ConnectAsync();
			}
			catch (Exception inner)
			{
				throw new WebSocketUnexpectedException("Failed to connect.", inner);
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000402C File Offset: 0x0000222C
		public void Close(WebSocketCloseCode code = WebSocketCloseCode.Normal, string reason = null)
		{
			if (this.ws.ReadyState == WebSocketState.Closing)
			{
				throw new WebSocketInvalidStateException("WebSocket is already closing.");
			}
			if (this.ws.ReadyState == WebSocketState.Closed)
			{
				throw new WebSocketInvalidStateException("WebSocket is already closed.");
			}
			try
			{
				this.ws.CloseAsync((ushort)code, reason);
			}
			catch (Exception inner)
			{
				throw new WebSocketUnexpectedException("Failed to close the connection.", inner);
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000409C File Offset: 0x0000229C
		public void Send(byte[] data)
		{
			if (this.ws.ReadyState != WebSocketState.Open)
			{
				throw new WebSocketInvalidStateException("WebSocket is not in open state.");
			}
			try
			{
				this.ws.Send(data);
			}
			catch (Exception inner)
			{
				throw new WebSocketUnexpectedException("Failed to send message.", inner);
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000040F0 File Offset: 0x000022F0
		public WebSocketState GetState()
		{
			switch (this.ws.ReadyState)
			{
			case WebSocketState.Connecting:
				return WebSocketState.Connecting;
			case WebSocketState.Open:
				return WebSocketState.Open;
			case WebSocketState.Closing:
				return WebSocketState.Closing;
			case WebSocketState.Closed:
				return WebSocketState.Closed;
			default:
				return WebSocketState.Closed;
			}
		}

		// Token: 0x040000B0 RID: 176
		protected WebSocket ws;
	}
}
