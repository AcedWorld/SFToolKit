using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000034 RID: 52
	internal sealed class HttpListener : IDisposable
	{
		// Token: 0x0600038F RID: 911 RVA: 0x00010B78 File Offset: 0x0000ED78
		public HttpListener()
		{
			this._authSchemes = AuthenticationSchemes.Anonymous;
			this._contextQueue = new Queue<HttpListenerContext>();
			this._contextRegistry = new LinkedList<HttpListenerContext>();
			this._contextRegistrySync = ((ICollection)this._contextRegistry).SyncRoot;
			this._log = new Logger();
			this._objectName = base.GetType().ToString();
			this._prefixes = new HttpListenerPrefixCollection(this);
			this._sync = new object();
			this._waitQueue = new Queue<HttpListenerAsyncResult>();
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00010BFB File Offset: 0x0000EDFB
		// (set) Token: 0x06000391 RID: 913 RVA: 0x00010C03 File Offset: 0x0000EE03
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

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000392 RID: 914 RVA: 0x00010C0C File Offset: 0x0000EE0C
		// (set) Token: 0x06000393 RID: 915 RVA: 0x00010C28 File Offset: 0x0000EE28
		public AuthenticationSchemes AuthenticationSchemes
		{
			get
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._authSchemes;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._authSchemes = value;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000394 RID: 916 RVA: 0x00010C45 File Offset: 0x0000EE45
		// (set) Token: 0x06000395 RID: 917 RVA: 0x00010C61 File Offset: 0x0000EE61
		public Func<HttpListenerRequest, AuthenticationSchemes> AuthenticationSchemeSelector
		{
			get
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._authSchemeSelector;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._authSchemeSelector = value;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00010C7E File Offset: 0x0000EE7E
		// (set) Token: 0x06000397 RID: 919 RVA: 0x00010C9A File Offset: 0x0000EE9A
		public string CertificateFolderPath
		{
			get
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._certFolderPath;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._certFolderPath = value;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00010CB7 File Offset: 0x0000EEB7
		// (set) Token: 0x06000399 RID: 921 RVA: 0x00010CD3 File Offset: 0x0000EED3
		public bool IgnoreWriteExceptions
		{
			get
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._ignoreWriteExceptions;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._ignoreWriteExceptions = value;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00010CF0 File Offset: 0x0000EEF0
		public bool IsListening
		{
			get
			{
				return this._listening;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00010CFA File Offset: 0x0000EEFA
		public static bool IsSupported
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00010CFD File Offset: 0x0000EEFD
		public Logger Log
		{
			get
			{
				return this._log;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600039D RID: 925 RVA: 0x00010D05 File Offset: 0x0000EF05
		public HttpListenerPrefixCollection Prefixes
		{
			get
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._prefixes;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00010D21 File Offset: 0x0000EF21
		// (set) Token: 0x0600039F RID: 927 RVA: 0x00010D3D File Offset: 0x0000EF3D
		public string Realm
		{
			get
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._realm;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._realm = value;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00010D5A File Offset: 0x0000EF5A
		public ServerSslConfiguration SslConfiguration
		{
			get
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				if (this._sslConfig == null)
				{
					this._sslConfig = new ServerSslConfiguration();
				}
				return this._sslConfig;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x00010D89 File Offset: 0x0000EF89
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x00010D90 File Offset: 0x0000EF90
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

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x00010D97 File Offset: 0x0000EF97
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x00010DB3 File Offset: 0x0000EFB3
		public Func<IIdentity, NetworkCredential> UserCredentialsFinder
		{
			get
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				return this._userCredFinder;
			}
			set
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				this._userCredFinder = value;
			}
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00010DD0 File Offset: 0x0000EFD0
		private bool authenticateClient(HttpListenerContext context)
		{
			AuthenticationSchemes authenticationSchemes = this.selectAuthenticationScheme(context.Request);
			if (authenticationSchemes == AuthenticationSchemes.Anonymous)
			{
				return true;
			}
			if (authenticationSchemes == AuthenticationSchemes.None)
			{
				string message = "Authentication not allowed";
				context.SendError(403, message);
				return false;
			}
			string realm = this.getRealm();
			if (!context.SetUser(authenticationSchemes, realm, this._userCredFinder))
			{
				context.SendAuthenticationChallenge(authenticationSchemes, realm);
				return false;
			}
			return true;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00010E30 File Offset: 0x0000F030
		private HttpListenerAsyncResult beginGetContext(AsyncCallback callback, object state)
		{
			object contextRegistrySync = this._contextRegistrySync;
			HttpListenerAsyncResult result;
			lock (contextRegistrySync)
			{
				if (!this._listening)
				{
					string message = "The method is canceled.";
					throw new HttpListenerException(995, message);
				}
				HttpListenerAsyncResult httpListenerAsyncResult = new HttpListenerAsyncResult(callback, state);
				if (this._contextQueue.Count == 0)
				{
					this._waitQueue.Enqueue(httpListenerAsyncResult);
					result = httpListenerAsyncResult;
				}
				else
				{
					HttpListenerContext context = this._contextQueue.Dequeue();
					httpListenerAsyncResult.Complete(context, true);
					result = httpListenerAsyncResult;
				}
			}
			return result;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00010EC8 File Offset: 0x0000F0C8
		private void cleanupContextQueue(bool force)
		{
			if (this._contextQueue.Count == 0)
			{
				return;
			}
			if (force)
			{
				this._contextQueue.Clear();
				return;
			}
			HttpListenerContext[] array = this._contextQueue.ToArray();
			this._contextQueue.Clear();
			HttpListenerContext[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].SendError(503);
			}
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00010F24 File Offset: 0x0000F124
		private void cleanupContextRegistry()
		{
			int count = this._contextRegistry.Count;
			if (count == 0)
			{
				return;
			}
			HttpListenerContext[] array = new HttpListenerContext[count];
			object contextRegistrySync = this._contextRegistrySync;
			lock (contextRegistrySync)
			{
				this._contextRegistry.CopyTo(array, 0);
				this._contextRegistry.Clear();
			}
			HttpListenerContext[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Connection.Close(true);
			}
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00010FB4 File Offset: 0x0000F1B4
		private void cleanupWaitQueue(string message)
		{
			if (this._waitQueue.Count == 0)
			{
				return;
			}
			HttpListenerAsyncResult[] array = this._waitQueue.ToArray();
			this._waitQueue.Clear();
			foreach (HttpListenerAsyncResult httpListenerAsyncResult in array)
			{
				HttpListenerException exception = new HttpListenerException(995, message);
				httpListenerAsyncResult.Complete(exception);
			}
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0001100C File Offset: 0x0000F20C
		private void close(bool force)
		{
			object sync = this._sync;
			lock (sync)
			{
				if (!this._disposed)
				{
					object contextRegistrySync = this._contextRegistrySync;
					lock (contextRegistrySync)
					{
						if (!this._listening)
						{
							this._disposed = true;
							return;
						}
						this._listening = false;
					}
					this.cleanupContextQueue(force);
					this.cleanupContextRegistry();
					string message = "The listener is closed.";
					this.cleanupWaitQueue(message);
					EndPointManager.RemoveListener(this);
					this._disposed = true;
				}
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x000110C0 File Offset: 0x0000F2C0
		private string getRealm()
		{
			string realm = this._realm;
			if (realm == null || realm.Length <= 0)
			{
				return HttpListener._defaultRealm;
			}
			return realm;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x000110E8 File Offset: 0x0000F2E8
		private bool registerContext(HttpListenerContext context)
		{
			if (!this._listening)
			{
				return false;
			}
			object contextRegistrySync = this._contextRegistrySync;
			bool result;
			lock (contextRegistrySync)
			{
				if (!this._listening)
				{
					result = false;
				}
				else
				{
					context.Listener = this;
					this._contextRegistry.AddLast(context);
					if (this._waitQueue.Count == 0)
					{
						this._contextQueue.Enqueue(context);
						result = true;
					}
					else
					{
						this._waitQueue.Dequeue().Complete(context, false);
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00011184 File Offset: 0x0000F384
		private AuthenticationSchemes selectAuthenticationScheme(HttpListenerRequest request)
		{
			Func<HttpListenerRequest, AuthenticationSchemes> authSchemeSelector = this._authSchemeSelector;
			if (authSchemeSelector == null)
			{
				return this._authSchemes;
			}
			AuthenticationSchemes result;
			try
			{
				result = authSchemeSelector(request);
			}
			catch
			{
				result = AuthenticationSchemes.None;
			}
			return result;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x000111C4 File Offset: 0x0000F3C4
		internal void CheckDisposed()
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
		}

		// Token: 0x060003AF RID: 943 RVA: 0x000111DA File Offset: 0x0000F3DA
		internal bool RegisterContext(HttpListenerContext context)
		{
			if (!this.authenticateClient(context))
			{
				return false;
			}
			if (!this.registerContext(context))
			{
				context.SendError(503);
				return false;
			}
			return true;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00011200 File Offset: 0x0000F400
		internal void UnregisterContext(HttpListenerContext context)
		{
			object contextRegistrySync = this._contextRegistrySync;
			lock (contextRegistrySync)
			{
				this._contextRegistry.Remove(context);
			}
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00011248 File Offset: 0x0000F448
		public void Abort()
		{
			if (this._disposed)
			{
				return;
			}
			this.close(true);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0001125C File Offset: 0x0000F45C
		public IAsyncResult BeginGetContext(AsyncCallback callback, object state)
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
			if (!this._listening)
			{
				throw new InvalidOperationException("The listener has not been started.");
			}
			if (this._prefixes.Count == 0)
			{
				throw new InvalidOperationException("The listener has no URI prefix on which listens.");
			}
			return this.beginGetContext(callback, state);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x000112B2 File Offset: 0x0000F4B2
		public void Close()
		{
			if (this._disposed)
			{
				return;
			}
			this.close(false);
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x000112C4 File Offset: 0x0000F4C4
		public HttpListenerContext EndGetContext(IAsyncResult asyncResult)
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
			if (!this._listening)
			{
				throw new InvalidOperationException("The listener has not been started.");
			}
			if (asyncResult == null)
			{
				throw new ArgumentNullException("asyncResult");
			}
			HttpListenerAsyncResult httpListenerAsyncResult = asyncResult as HttpListenerAsyncResult;
			if (httpListenerAsyncResult == null)
			{
				throw new ArgumentException("A wrong IAsyncResult instance.", "asyncResult");
			}
			object syncRoot = httpListenerAsyncResult.SyncRoot;
			lock (syncRoot)
			{
				if (httpListenerAsyncResult.EndCalled)
				{
					throw new InvalidOperationException("This IAsyncResult instance cannot be reused.");
				}
				httpListenerAsyncResult.EndCalled = true;
			}
			if (!httpListenerAsyncResult.IsCompleted)
			{
				httpListenerAsyncResult.AsyncWaitHandle.WaitOne();
			}
			return httpListenerAsyncResult.Context;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00011384 File Offset: 0x0000F584
		public HttpListenerContext GetContext()
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
			if (!this._listening)
			{
				throw new InvalidOperationException("The listener has not been started.");
			}
			if (this._prefixes.Count == 0)
			{
				throw new InvalidOperationException("The listener has no URI prefix on which listens.");
			}
			HttpListenerAsyncResult httpListenerAsyncResult = this.beginGetContext(null, null);
			httpListenerAsyncResult.EndCalled = true;
			if (!httpListenerAsyncResult.IsCompleted)
			{
				httpListenerAsyncResult.AsyncWaitHandle.WaitOne();
			}
			return httpListenerAsyncResult.Context;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x000113FC File Offset: 0x0000F5FC
		public void Start()
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
			object sync = this._sync;
			lock (sync)
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				object contextRegistrySync = this._contextRegistrySync;
				lock (contextRegistrySync)
				{
					if (!this._listening)
					{
						EndPointManager.AddListener(this);
						this._listening = true;
					}
				}
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x000114A0 File Offset: 0x0000F6A0
		public void Stop()
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(this._objectName);
			}
			object sync = this._sync;
			lock (sync)
			{
				if (this._disposed)
				{
					throw new ObjectDisposedException(this._objectName);
				}
				object contextRegistrySync = this._contextRegistrySync;
				lock (contextRegistrySync)
				{
					if (!this._listening)
					{
						return;
					}
					this._listening = false;
				}
				this.cleanupContextQueue(false);
				this.cleanupContextRegistry();
				string message = "The listener is stopped.";
				this.cleanupWaitQueue(message);
				EndPointManager.RemoveListener(this);
			}
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00011564 File Offset: 0x0000F764
		void IDisposable.Dispose()
		{
			if (this._disposed)
			{
				return;
			}
			this.close(true);
		}

		// Token: 0x0400014C RID: 332
		private AuthenticationSchemes _authSchemes;

		// Token: 0x0400014D RID: 333
		private Func<HttpListenerRequest, AuthenticationSchemes> _authSchemeSelector;

		// Token: 0x0400014E RID: 334
		private string _certFolderPath;

		// Token: 0x0400014F RID: 335
		private Queue<HttpListenerContext> _contextQueue;

		// Token: 0x04000150 RID: 336
		private LinkedList<HttpListenerContext> _contextRegistry;

		// Token: 0x04000151 RID: 337
		private object _contextRegistrySync;

		// Token: 0x04000152 RID: 338
		private static readonly string _defaultRealm = "SECRET AREA";

		// Token: 0x04000153 RID: 339
		private bool _disposed;

		// Token: 0x04000154 RID: 340
		private bool _ignoreWriteExceptions;

		// Token: 0x04000155 RID: 341
		private volatile bool _listening;

		// Token: 0x04000156 RID: 342
		private Logger _log;

		// Token: 0x04000157 RID: 343
		private string _objectName;

		// Token: 0x04000158 RID: 344
		private HttpListenerPrefixCollection _prefixes;

		// Token: 0x04000159 RID: 345
		private string _realm;

		// Token: 0x0400015A RID: 346
		private bool _reuseAddress;

		// Token: 0x0400015B RID: 347
		private ServerSslConfiguration _sslConfig;

		// Token: 0x0400015C RID: 348
		private object _sync;

		// Token: 0x0400015D RID: 349
		private Func<IIdentity, NetworkCredential> _userCredFinder;

		// Token: 0x0400015E RID: 350
		private Queue<HttpListenerAsyncResult> _waitQueue;
	}
}
