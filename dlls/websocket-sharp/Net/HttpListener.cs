using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;

namespace WebSocketSharp.Net
{
	// Token: 0x02000020 RID: 32
	public sealed class HttpListener : IDisposable
	{
		// Token: 0x0600023A RID: 570 RVA: 0x0000F678 File Offset: 0x0000D878
		public HttpListener()
		{
			this._authSchemes = AuthenticationSchemes.Anonymous;
			this._contextQueue = new Queue<HttpListenerContext>();
			this._contextRegistry = new LinkedList<HttpListenerContext>();
			this._contextRegistrySync = ((ICollection)this._contextRegistry).SyncRoot;
			this._log = new Logger();
			this._objectName = base.GetType().ToString();
			this._prefixes = new HttpListenerPrefixCollection(this);
			this._waitQueue = new Queue<HttpListenerAsyncResult>();
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600023B RID: 571 RVA: 0x0000F6F4 File Offset: 0x0000D8F4
		// (set) Token: 0x0600023C RID: 572 RVA: 0x0000F70C File Offset: 0x0000D90C
		internal bool ReuseAddress
		{
			get
			{
				return this._reuseAddress;
			}
			set
			{
				this._reuseAddress = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600023D RID: 573 RVA: 0x0000F718 File Offset: 0x0000D918
		// (set) Token: 0x0600023E RID: 574 RVA: 0x0000F748 File Offset: 0x0000D948
		public AuthenticationSchemes AuthenticationSchemes
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._authSchemes;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._authSchemes = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600023F RID: 575 RVA: 0x0000F774 File Offset: 0x0000D974
		// (set) Token: 0x06000240 RID: 576 RVA: 0x0000F7A4 File Offset: 0x0000D9A4
		public Func<HttpListenerRequest, AuthenticationSchemes> AuthenticationSchemeSelector
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._authSchemeSelector;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._authSchemeSelector = value;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000241 RID: 577 RVA: 0x0000F7D0 File Offset: 0x0000D9D0
		// (set) Token: 0x06000242 RID: 578 RVA: 0x0000F800 File Offset: 0x0000DA00
		public string CertificateFolderPath
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._certFolderPath;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._certFolderPath = value;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000243 RID: 579 RVA: 0x0000F82C File Offset: 0x0000DA2C
		// (set) Token: 0x06000244 RID: 580 RVA: 0x0000F85C File Offset: 0x0000DA5C
		public bool IgnoreWriteExceptions
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._ignoreWriteExceptions;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._ignoreWriteExceptions = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000245 RID: 581 RVA: 0x0000F888 File Offset: 0x0000DA88
		public bool IsListening
		{
			get
			{
				return this._listening;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000246 RID: 582 RVA: 0x0000F8A4 File Offset: 0x0000DAA4
		public static bool IsSupported
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000247 RID: 583 RVA: 0x0000F8B8 File Offset: 0x0000DAB8
		public Logger Log
		{
			get
			{
				return this._log;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000248 RID: 584 RVA: 0x0000F8D0 File Offset: 0x0000DAD0
		public HttpListenerPrefixCollection Prefixes
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._prefixes;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000249 RID: 585 RVA: 0x0000F900 File Offset: 0x0000DB00
		// (set) Token: 0x0600024A RID: 586 RVA: 0x0000F930 File Offset: 0x0000DB30
		public string Realm
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._realm;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._realm = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000F95C File Offset: 0x0000DB5C
		public ServerSslConfiguration SslConfiguration
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				bool flag = this._sslConfig == null;
				if (flag)
				{
					this._sslConfig = new ServerSslConfiguration();
				}
				return this._sslConfig;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
		// (set) Token: 0x0600024D RID: 589 RVA: 0x0000F9A2 File Offset: 0x0000DBA2
		public bool UnsafeConnectionNtlmAuthentication
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600024E RID: 590 RVA: 0x0000F9AC File Offset: 0x0000DBAC
		// (set) Token: 0x0600024F RID: 591 RVA: 0x0000F9DC File Offset: 0x0000DBDC
		public Func<IIdentity, NetworkCredential> UserCredentialsFinder
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._userCredFinder;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._userCredFinder = value;
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000FA08 File Offset: 0x0000DC08
		private HttpListenerAsyncResult beginGetContext(AsyncCallback callback, object state)
		{
			object contextRegistrySync = this._contextRegistrySync;
			HttpListenerAsyncResult result;
			lock (contextRegistrySync)
			{
				bool flag2 = !this._listening;
				if (flag2)
				{
					string message = this._disposed ? "The listener is closed." : "The listener is stopped.";
					throw new HttpListenerException(995, message);
				}
				HttpListenerAsyncResult httpListenerAsyncResult = new HttpListenerAsyncResult(callback, state);
				bool flag3 = this._contextQueue.Count == 0;
				if (flag3)
				{
					this._waitQueue.Enqueue(httpListenerAsyncResult);
				}
				else
				{
					HttpListenerContext context = this._contextQueue.Dequeue();
					httpListenerAsyncResult.Complete(context, true);
				}
				result = httpListenerAsyncResult;
			}
			return result;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000FAC4 File Offset: 0x0000DCC4
		private void cleanupContextQueue(bool force)
		{
			bool flag = this._contextQueue.Count == 0;
			if (!flag)
			{
				if (force)
				{
					this._contextQueue.Clear();
				}
				else
				{
					HttpListenerContext[] array = this._contextQueue.ToArray();
					this._contextQueue.Clear();
					foreach (HttpListenerContext httpListenerContext in array)
					{
						httpListenerContext.ErrorStatusCode = 503;
						httpListenerContext.SendError();
					}
				}
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000FB44 File Offset: 0x0000DD44
		private void cleanupContextRegistry()
		{
			int count = this._contextRegistry.Count;
			bool flag = count == 0;
			if (!flag)
			{
				HttpListenerContext[] array = new HttpListenerContext[count];
				this._contextRegistry.CopyTo(array, 0);
				this._contextRegistry.Clear();
				foreach (HttpListenerContext httpListenerContext in array)
				{
					httpListenerContext.Connection.Close(true);
				}
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000FBB4 File Offset: 0x0000DDB4
		private void cleanupWaitQueue(string message)
		{
			bool flag = this._waitQueue.Count == 0;
			if (!flag)
			{
				HttpListenerAsyncResult[] array = this._waitQueue.ToArray();
				this._waitQueue.Clear();
				foreach (HttpListenerAsyncResult httpListenerAsyncResult in array)
				{
					HttpListenerException exception = new HttpListenerException(995, message);
					httpListenerAsyncResult.Complete(exception);
				}
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000FC20 File Offset: 0x0000DE20
		private void close(bool force)
		{
			bool flag = !this._listening;
			if (flag)
			{
				this._disposed = true;
			}
			else
			{
				this._listening = false;
				this.cleanupContextQueue(force);
				this.cleanupContextRegistry();
				string message = "The listener is closed.";
				this.cleanupWaitQueue(message);
				EndPointManager.RemoveListener(this);
				this._disposed = true;
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000FC7C File Offset: 0x0000DE7C
		private string getRealm()
		{
			string realm = this._realm;
			return (realm != null && realm.Length > 0) ? realm : HttpListener._defaultRealm;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000FCAC File Offset: 0x0000DEAC
		private AuthenticationSchemes selectAuthenticationScheme(HttpListenerRequest request)
		{
			Func<HttpListenerRequest, AuthenticationSchemes> authSchemeSelector = this._authSchemeSelector;
			bool flag = authSchemeSelector == null;
			AuthenticationSchemes result;
			if (flag)
			{
				result = this._authSchemes;
			}
			else
			{
				try
				{
					result = authSchemeSelector(request);
				}
				catch
				{
					result = AuthenticationSchemes.None;
				}
			}
			return result;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000FCF8 File Offset: 0x0000DEF8
		internal bool AuthenticateContext(HttpListenerContext context)
		{
			HttpListenerRequest request = context.Request;
			AuthenticationSchemes authenticationSchemes = this.selectAuthenticationScheme(request);
			bool flag = authenticationSchemes == AuthenticationSchemes.Anonymous;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = authenticationSchemes == AuthenticationSchemes.None;
				if (flag2)
				{
					context.ErrorStatusCode = 403;
					context.ErrorMessage = "Authentication not allowed";
					context.SendError();
					result = false;
				}
				else
				{
					string realm = this.getRealm();
					IPrincipal principal = HttpUtility.CreateUser(request.Headers["Authorization"], authenticationSchemes, realm, request.HttpMethod, this._userCredFinder);
					bool flag3 = principal != null && principal.Identity.IsAuthenticated;
					bool flag4 = !flag3;
					if (flag4)
					{
						context.SendAuthenticationChallenge(authenticationSchemes, realm);
						result = false;
					}
					else
					{
						context.User = principal;
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000FDC4 File Offset: 0x0000DFC4
		internal void CheckDisposed()
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000FDE8 File Offset: 0x0000DFE8
		internal bool RegisterContext(HttpListenerContext context)
		{
			bool flag = !this._listening;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				object contextRegistrySync = this._contextRegistrySync;
				lock (contextRegistrySync)
				{
					bool flag3 = !this._listening;
					if (flag3)
					{
						result = false;
					}
					else
					{
						context.Listener = this;
						this._contextRegistry.AddLast(context);
						bool flag4 = this._waitQueue.Count == 0;
						if (flag4)
						{
							this._contextQueue.Enqueue(context);
						}
						else
						{
							HttpListenerAsyncResult httpListenerAsyncResult = this._waitQueue.Dequeue();
							httpListenerAsyncResult.Complete(context, false);
						}
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000FEA8 File Offset: 0x0000E0A8
		internal void UnregisterContext(HttpListenerContext context)
		{
			object contextRegistrySync = this._contextRegistrySync;
			lock (contextRegistrySync)
			{
				this._contextRegistry.Remove(context);
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000FEF4 File Offset: 0x0000E0F4
		public void Abort()
		{
			bool disposed = this._disposed;
			if (!disposed)
			{
				object contextRegistrySync = this._contextRegistrySync;
				lock (contextRegistrySync)
				{
					bool disposed2 = this._disposed;
					if (!disposed2)
					{
						this.close(true);
					}
				}
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000FF54 File Offset: 0x0000E154
		public IAsyncResult BeginGetContext(AsyncCallback callback, object state)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
			bool flag = this._prefixes.Count == 0;
			if (flag)
			{
				string message = "The listener has no URI prefix on which listens.";
				throw new InvalidOperationException(message);
			}
			bool flag2 = !this._listening;
			if (flag2)
			{
				string message2 = "The listener has not been started.";
				throw new InvalidOperationException(message2);
			}
			return this.beginGetContext(callback, state);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000FFC8 File Offset: 0x0000E1C8
		public void Close()
		{
			bool disposed = this._disposed;
			if (!disposed)
			{
				object contextRegistrySync = this._contextRegistrySync;
				lock (contextRegistrySync)
				{
					bool disposed2 = this._disposed;
					if (!disposed2)
					{
						this.close(false);
					}
				}
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00010028 File Offset: 0x0000E228
		public HttpListenerContext EndGetContext(IAsyncResult asyncResult)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
			bool flag = asyncResult == null;
			if (flag)
			{
				throw new ArgumentNullException("asyncResult");
			}
			HttpListenerAsyncResult httpListenerAsyncResult = asyncResult as HttpListenerAsyncResult;
			bool flag2 = httpListenerAsyncResult == null;
			if (flag2)
			{
				string message = "A wrong IAsyncResult instance.";
				throw new ArgumentException(message, "asyncResult");
			}
			object syncRoot = httpListenerAsyncResult.SyncRoot;
			lock (syncRoot)
			{
				bool endCalled = httpListenerAsyncResult.EndCalled;
				if (endCalled)
				{
					string message2 = "This IAsyncResult instance cannot be reused.";
					throw new InvalidOperationException(message2);
				}
				httpListenerAsyncResult.EndCalled = true;
			}
			bool flag4 = !httpListenerAsyncResult.IsCompleted;
			if (flag4)
			{
				httpListenerAsyncResult.AsyncWaitHandle.WaitOne();
			}
			return httpListenerAsyncResult.Context;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00010104 File Offset: 0x0000E304
		public HttpListenerContext GetContext()
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
			bool flag = this._prefixes.Count == 0;
			if (flag)
			{
				string message = "The listener has no URI prefix on which listens.";
				throw new InvalidOperationException(message);
			}
			bool flag2 = !this._listening;
			if (flag2)
			{
				string message2 = "The listener has not been started.";
				throw new InvalidOperationException(message2);
			}
			HttpListenerAsyncResult httpListenerAsyncResult = this.beginGetContext(null, null);
			httpListenerAsyncResult.EndCalled = true;
			bool flag3 = !httpListenerAsyncResult.IsCompleted;
			if (flag3)
			{
				httpListenerAsyncResult.AsyncWaitHandle.WaitOne();
			}
			return httpListenerAsyncResult.Context;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000101A4 File Offset: 0x0000E3A4
		public void Start()
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
			object contextRegistrySync = this._contextRegistrySync;
			lock (contextRegistrySync)
			{
				bool disposed2 = this._disposed;
				if (disposed2)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				bool listening = this._listening;
				if (!listening)
				{
					EndPointManager.AddListener(this);
					this._listening = true;
				}
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00010230 File Offset: 0x0000E430
		public void Stop()
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
			object contextRegistrySync = this._contextRegistrySync;
			lock (contextRegistrySync)
			{
				bool flag2 = !this._listening;
				if (!flag2)
				{
					this._listening = false;
					this.cleanupContextQueue(false);
					this.cleanupContextRegistry();
					string message = "The listener is stopped.";
					this.cleanupWaitQueue(message);
					EndPointManager.RemoveListener(this);
				}
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000102C8 File Offset: 0x0000E4C8
		void IDisposable.Dispose()
		{
			bool disposed = this._disposed;
			if (!disposed)
			{
				object contextRegistrySync = this._contextRegistrySync;
				lock (contextRegistrySync)
				{
					bool disposed2 = this._disposed;
					if (!disposed2)
					{
						this.close(true);
					}
				}
			}
		}

		// Token: 0x040000D9 RID: 217
		private AuthenticationSchemes _authSchemes;

		// Token: 0x040000DA RID: 218
		private Func<HttpListenerRequest, AuthenticationSchemes> _authSchemeSelector;

		// Token: 0x040000DB RID: 219
		private string _certFolderPath;

		// Token: 0x040000DC RID: 220
		private Queue<HttpListenerContext> _contextQueue;

		// Token: 0x040000DD RID: 221
		private LinkedList<HttpListenerContext> _contextRegistry;

		// Token: 0x040000DE RID: 222
		private object _contextRegistrySync;

		// Token: 0x040000DF RID: 223
		private static readonly string _defaultRealm = "SECRET AREA";

		// Token: 0x040000E0 RID: 224
		private bool _disposed;

		// Token: 0x040000E1 RID: 225
		private bool _ignoreWriteExceptions;

		// Token: 0x040000E2 RID: 226
		private volatile bool _listening;

		// Token: 0x040000E3 RID: 227
		private Logger _log;

		// Token: 0x040000E4 RID: 228
		private string _objectName;

		// Token: 0x040000E5 RID: 229
		private HttpListenerPrefixCollection _prefixes;

		// Token: 0x040000E6 RID: 230
		private string _realm;

		// Token: 0x040000E7 RID: 231
		private bool _reuseAddress;

		// Token: 0x040000E8 RID: 232
		private ServerSslConfiguration _sslConfig;

		// Token: 0x040000E9 RID: 233
		private Func<IIdentity, NetworkCredential> _userCredFinder;

		// Token: 0x040000EA RID: 234
		private Queue<HttpListenerAsyncResult> _waitQueue;
	}
}
