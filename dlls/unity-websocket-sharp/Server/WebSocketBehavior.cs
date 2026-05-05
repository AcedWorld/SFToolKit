using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Principal;
using UnityWebSocketSharp.Net;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp.Server
{
	// Token: 0x0200001D RID: 29
	internal abstract class WebSocketBehavior : IWebSocketSession
	{
		// Token: 0x060001DA RID: 474 RVA: 0x00009EA2 File Offset: 0x000080A2
		protected WebSocketBehavior()
		{
			this._startTime = DateTime.MaxValue;
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00009EB5 File Offset: 0x000080B5
		protected NameValueCollection Headers
		{
			get
			{
				if (this._context == null)
				{
					throw new InvalidOperationException("The session has not started yet.");
				}
				return this._context.Headers;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00009ED5 File Offset: 0x000080D5
		protected bool IsAlive
		{
			get
			{
				if (this._websocket == null)
				{
					throw new InvalidOperationException("The session has not started yet.");
				}
				return this._websocket.IsAlive;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00009EF5 File Offset: 0x000080F5
		protected NameValueCollection QueryString
		{
			get
			{
				if (this._context == null)
				{
					throw new InvalidOperationException("The session has not started yet.");
				}
				return this._context.QueryString;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00009F15 File Offset: 0x00008115
		protected WebSocketState ReadyState
		{
			get
			{
				if (this._websocket == null)
				{
					throw new InvalidOperationException("The session has not started yet.");
				}
				return this._websocket.ReadyState;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00009F35 File Offset: 0x00008135
		protected WebSocketSessionManager Sessions
		{
			get
			{
				if (this._sessions == null)
				{
					throw new InvalidOperationException("The session has not started yet.");
				}
				return this._sessions;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00009F50 File Offset: 0x00008150
		protected IPrincipal User
		{
			get
			{
				if (this._context == null)
				{
					throw new InvalidOperationException("The session has not started yet.");
				}
				return this._context.User;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00009F70 File Offset: 0x00008170
		protected IPEndPoint UserEndPoint
		{
			get
			{
				if (this._context == null)
				{
					throw new InvalidOperationException("The session has not started yet.");
				}
				return this._context.UserEndPoint;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00009F90 File Offset: 0x00008190
		// (set) Token: 0x060001E3 RID: 483 RVA: 0x00009F98 File Offset: 0x00008198
		public Func<CookieCollection, CookieCollection, bool> CookiesValidator
		{
			get
			{
				return this._cookiesValidator;
			}
			set
			{
				this._cookiesValidator = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x00009FA1 File Offset: 0x000081A1
		// (set) Token: 0x060001E5 RID: 485 RVA: 0x00009FBD File Offset: 0x000081BD
		public bool EmitOnPing
		{
			get
			{
				if (this._websocket == null)
				{
					return this._emitOnPing;
				}
				return this._websocket.EmitOnPing;
			}
			set
			{
				if (this._websocket != null)
				{
					this._websocket.EmitOnPing = value;
					return;
				}
				this._emitOnPing = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00009FDB File Offset: 0x000081DB
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x00009FE3 File Offset: 0x000081E3
		public Func<string, bool> HostValidator
		{
			get
			{
				return this._hostValidator;
			}
			set
			{
				this._hostValidator = value;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x00009FEC File Offset: 0x000081EC
		public string ID
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00009FF4 File Offset: 0x000081F4
		// (set) Token: 0x060001EA RID: 490 RVA: 0x00009FFC File Offset: 0x000081FC
		public bool IgnoreExtensions
		{
			get
			{
				return this._ignoreExtensions;
			}
			set
			{
				this._ignoreExtensions = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001EB RID: 491 RVA: 0x0000A005 File Offset: 0x00008205
		// (set) Token: 0x060001EC RID: 492 RVA: 0x0000A00D File Offset: 0x0000820D
		public Func<string, bool> OriginValidator
		{
			get
			{
				return this._originValidator;
			}
			set
			{
				this._originValidator = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001ED RID: 493 RVA: 0x0000A016 File Offset: 0x00008216
		// (set) Token: 0x060001EE RID: 494 RVA: 0x0000A03C File Offset: 0x0000823C
		public string Protocol
		{
			get
			{
				string protocol;
				if (this._websocket == null)
				{
					if ((protocol = this._protocol) == null)
					{
						return string.Empty;
					}
				}
				else
				{
					protocol = this._websocket.Protocol;
				}
				return protocol;
			}
			set
			{
				if (this._websocket != null)
				{
					throw new InvalidOperationException("The session has already started.");
				}
				if (value == null || value.Length == 0)
				{
					this._protocol = null;
					return;
				}
				if (!value.IsToken())
				{
					throw new ArgumentException("Not a token.", "value");
				}
				this._protocol = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000A08E File Offset: 0x0000828E
		public DateTime StartTime
		{
			get
			{
				return this._startTime;
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000A098 File Offset: 0x00008298
		private string checkHandshakeRequest(WebSocketContext context)
		{
			if (this._hostValidator != null && !this._hostValidator(context.Host))
			{
				return "The Host header is invalid.";
			}
			if (this._originValidator != null && !this._originValidator(context.Origin))
			{
				return "The Origin header is non-existent or invalid.";
			}
			if (this._cookiesValidator != null)
			{
				CookieCollection cookieCollection = context.CookieCollection;
				CookieCollection cookieCollection2 = context.WebSocket.CookieCollection;
				if (!this._cookiesValidator(cookieCollection, cookieCollection2))
				{
					return "The Cookie header is non-existent or invalid.";
				}
			}
			return null;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000A118 File Offset: 0x00008318
		private void onClose(object sender, CloseEventArgs e)
		{
			if (this._id == null)
			{
				return;
			}
			this._sessions.Remove(this._id);
			this.OnClose(e);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000A13C File Offset: 0x0000833C
		private void onError(object sender, ErrorEventArgs e)
		{
			this.OnError(e);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000A145 File Offset: 0x00008345
		private void onMessage(object sender, MessageEventArgs e)
		{
			this.OnMessage(e);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000A14E File Offset: 0x0000834E
		private void onOpen(object sender, EventArgs e)
		{
			this._id = this._sessions.Add(this);
			if (this._id == null)
			{
				this._websocket.Close(CloseStatusCode.Away);
				return;
			}
			this._startTime = DateTime.Now;
			this.OnOpen();
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000A18C File Offset: 0x0000838C
		internal void Start(WebSocketContext context, WebSocketSessionManager sessions)
		{
			this._context = context;
			this._sessions = sessions;
			this._websocket = context.WebSocket;
			this._websocket.CustomHandshakeRequestChecker = new Func<WebSocketContext, string>(this.checkHandshakeRequest);
			this._websocket.EmitOnPing = this._emitOnPing;
			this._websocket.IgnoreExtensions = this._ignoreExtensions;
			this._websocket.Protocol = this._protocol;
			TimeSpan waitTime = sessions.WaitTime;
			if (waitTime != this._websocket.WaitTime)
			{
				this._websocket.WaitTime = waitTime;
			}
			this._websocket.OnOpen += this.onOpen;
			this._websocket.OnMessage += this.onMessage;
			this._websocket.OnError += this.onError;
			this._websocket.OnClose += this.onClose;
			this._websocket.Accept();
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000A28A File Offset: 0x0000848A
		protected void Close()
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.Close();
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000A2AA File Offset: 0x000084AA
		protected void Close(ushort code, string reason)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.Close(code, reason);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000A2CC File Offset: 0x000084CC
		protected void Close(CloseStatusCode code, string reason)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.Close(code, reason);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000A2EE File Offset: 0x000084EE
		protected void CloseAsync()
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.CloseAsync();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000A30E File Offset: 0x0000850E
		protected void CloseAsync(ushort code, string reason)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.CloseAsync(code, reason);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000A330 File Offset: 0x00008530
		protected void CloseAsync(CloseStatusCode code, string reason)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.CloseAsync(code, reason);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000A352 File Offset: 0x00008552
		protected virtual void OnClose(CloseEventArgs e)
		{
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000A354 File Offset: 0x00008554
		protected virtual void OnError(ErrorEventArgs e)
		{
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000A356 File Offset: 0x00008556
		protected virtual void OnMessage(MessageEventArgs e)
		{
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000A358 File Offset: 0x00008558
		protected virtual void OnOpen()
		{
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000A35A File Offset: 0x0000855A
		protected bool Ping()
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			return this._websocket.Ping();
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000A37A File Offset: 0x0000857A
		protected bool Ping(string message)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			return this._websocket.Ping(message);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000A39B File Offset: 0x0000859B
		protected void Send(byte[] data)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.Send(data);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000A3BC File Offset: 0x000085BC
		protected void Send(FileInfo fileInfo)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.Send(fileInfo);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000A3DD File Offset: 0x000085DD
		protected void Send(string data)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.Send(data);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000A3FE File Offset: 0x000085FE
		protected void Send(Stream stream, int length)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.Send(stream, length);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000A420 File Offset: 0x00008620
		protected void SendAsync(byte[] data, Action<bool> completed)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.SendAsync(data, completed);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000A442 File Offset: 0x00008642
		protected void SendAsync(FileInfo fileInfo, Action<bool> completed)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.SendAsync(fileInfo, completed);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000A464 File Offset: 0x00008664
		protected void SendAsync(string data, Action<bool> completed)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.SendAsync(data, completed);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000A486 File Offset: 0x00008686
		protected void SendAsync(Stream stream, int length, Action<bool> completed)
		{
			if (this._websocket == null)
			{
				throw new InvalidOperationException("The session has not started yet.");
			}
			this._websocket.SendAsync(stream, length, completed);
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000A4A9 File Offset: 0x000086A9
		WebSocket IWebSocketSession.WebSocket
		{
			get
			{
				return this._websocket;
			}
		}

		// Token: 0x040000B5 RID: 181
		private WebSocketContext _context;

		// Token: 0x040000B6 RID: 182
		private Func<CookieCollection, CookieCollection, bool> _cookiesValidator;

		// Token: 0x040000B7 RID: 183
		private bool _emitOnPing;

		// Token: 0x040000B8 RID: 184
		private Func<string, bool> _hostValidator;

		// Token: 0x040000B9 RID: 185
		private string _id;

		// Token: 0x040000BA RID: 186
		private bool _ignoreExtensions;

		// Token: 0x040000BB RID: 187
		private Func<string, bool> _originValidator;

		// Token: 0x040000BC RID: 188
		private string _protocol;

		// Token: 0x040000BD RID: 189
		private WebSocketSessionManager _sessions;

		// Token: 0x040000BE RID: 190
		private DateTime _startTime;

		// Token: 0x040000BF RID: 191
		private WebSocket _websocket;
	}
}
