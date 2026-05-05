using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200002D RID: 45
	internal sealed class EndPointListener
	{
		// Token: 0x0600033F RID: 831 RVA: 0x0000F2C4 File Offset: 0x0000D4C4
		internal EndPointListener(IPEndPoint endpoint, bool secure, string certificateFolderPath, ServerSslConfiguration sslConfig, bool reuseAddress)
		{
			this._endpoint = endpoint;
			if (secure)
			{
				X509Certificate2 certificate = EndPointListener.getCertificate(endpoint.Port, certificateFolderPath, sslConfig.ServerCertificate);
				if (certificate == null)
				{
					throw new ArgumentException("No server certificate could be found.");
				}
				this._secure = true;
				this._sslConfig = new ServerSslConfiguration(sslConfig);
				this._sslConfig.ServerCertificate = certificate;
			}
			this._prefixes = new List<HttpListenerPrefix>();
			this._connections = new Dictionary<HttpConnection, HttpConnection>();
			this._connectionsSync = ((ICollection)this._connections).SyncRoot;
			this._socket = new Socket(endpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			if (reuseAddress)
			{
				this._socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			}
			this._socket.Bind(endpoint);
			this._socket.Listen(500);
			this._socket.BeginAccept(new AsyncCallback(EndPointListener.onAccept), this);
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000340 RID: 832 RVA: 0x0000F3AD File Offset: 0x0000D5AD
		public IPAddress Address
		{
			get
			{
				return this._endpoint.Address;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000341 RID: 833 RVA: 0x0000F3BA File Offset: 0x0000D5BA
		public bool IsSecure
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000342 RID: 834 RVA: 0x0000F3C2 File Offset: 0x0000D5C2
		public int Port
		{
			get
			{
				return this._endpoint.Port;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000343 RID: 835 RVA: 0x0000F3CF File Offset: 0x0000D5CF
		public ServerSslConfiguration SslConfiguration
		{
			get
			{
				return this._sslConfig;
			}
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000F3D8 File Offset: 0x0000D5D8
		private static void addSpecial(List<HttpListenerPrefix> prefixes, HttpListenerPrefix prefix)
		{
			string path = prefix.Path;
			using (List<HttpListenerPrefix>.Enumerator enumerator = prefixes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Path == path)
					{
						string message = "The prefix is already in use.";
						throw new HttpListenerException(87, message);
					}
				}
			}
			prefixes.Add(prefix);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000F448 File Offset: 0x0000D648
		private void clearConnections()
		{
			HttpConnection[] array = null;
			object connectionsSync = this._connectionsSync;
			lock (connectionsSync)
			{
				int count = this._connections.Count;
				if (count == 0)
				{
					return;
				}
				array = new HttpConnection[count];
				this._connections.Values.CopyTo(array, 0);
				this._connections.Clear();
			}
			HttpConnection[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Close(true);
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000F4DC File Offset: 0x0000D6DC
		private static RSACryptoServiceProvider createRSAFromFile(string path)
		{
			RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider(2048);
			byte[] keyBlob = File.ReadAllBytes(path);
			rsacryptoServiceProvider.ImportCspBlob(keyBlob);
			return rsacryptoServiceProvider;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000F504 File Offset: 0x0000D704
		private static X509Certificate2 getCertificate(int port, string folderPath, X509Certificate2 defaultCertificate)
		{
			if (folderPath == null || folderPath.Length == 0)
			{
				folderPath = EndPointListener._defaultCertFolderPath;
			}
			try
			{
				string text = Path.Combine(folderPath, string.Format("{0}.cer", port));
				string path = Path.Combine(folderPath, string.Format("{0}.key", port));
				if (File.Exists(text) && File.Exists(path))
				{
					return new X509Certificate2(text)
					{
						PrivateKey = EndPointListener.createRSAFromFile(path)
					};
				}
			}
			catch
			{
			}
			return defaultCertificate;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000F590 File Offset: 0x0000D790
		private void leaveIfNoPrefix()
		{
			if (this._prefixes.Count > 0)
			{
				return;
			}
			List<HttpListenerPrefix> list = this._unhandled;
			if (list != null && list.Count > 0)
			{
				return;
			}
			list = this._all;
			if (list != null && list.Count > 0)
			{
				return;
			}
			this.Close();
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000F5DC File Offset: 0x0000D7DC
		private static void onAccept(IAsyncResult asyncResult)
		{
			EndPointListener endPointListener = (EndPointListener)asyncResult.AsyncState;
			Socket socket = null;
			try
			{
				socket = endPointListener._socket.EndAccept(asyncResult);
			}
			catch (ObjectDisposedException)
			{
				return;
			}
			catch (Exception)
			{
			}
			try
			{
				endPointListener._socket.BeginAccept(new AsyncCallback(EndPointListener.onAccept), endPointListener);
			}
			catch (Exception)
			{
				if (socket != null)
				{
					socket.Close();
				}
				return;
			}
			if (socket == null)
			{
				return;
			}
			EndPointListener.processAccepted(socket, endPointListener);
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000F668 File Offset: 0x0000D868
		private static void processAccepted(Socket socket, EndPointListener listener)
		{
			HttpConnection httpConnection = null;
			try
			{
				httpConnection = new HttpConnection(socket, listener);
			}
			catch (Exception)
			{
				socket.Close();
				return;
			}
			object connectionsSync = listener._connectionsSync;
			lock (connectionsSync)
			{
				listener._connections.Add(httpConnection, httpConnection);
			}
			httpConnection.BeginReadRequest();
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000F6D8 File Offset: 0x0000D8D8
		private static bool removeSpecial(List<HttpListenerPrefix> prefixes, HttpListenerPrefix prefix)
		{
			string path = prefix.Path;
			int count = prefixes.Count;
			for (int i = 0; i < count; i++)
			{
				if (prefixes[i].Path == path)
				{
					prefixes.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000F720 File Offset: 0x0000D920
		private static HttpListener searchHttpListenerFromSpecial(string path, List<HttpListenerPrefix> prefixes)
		{
			if (prefixes == null)
			{
				return null;
			}
			HttpListener result = null;
			int num = -1;
			foreach (HttpListenerPrefix httpListenerPrefix in prefixes)
			{
				string path2 = httpListenerPrefix.Path;
				int length = path2.Length;
				if (length >= num && path.StartsWith(path2, StringComparison.Ordinal))
				{
					num = length;
					result = httpListenerPrefix.Listener;
				}
			}
			return result;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000F79C File Offset: 0x0000D99C
		internal static bool CertificateExists(int port, string folderPath)
		{
			if (folderPath == null || folderPath.Length == 0)
			{
				folderPath = EndPointListener._defaultCertFolderPath;
			}
			string path = Path.Combine(folderPath, string.Format("{0}.cer", port));
			string path2 = Path.Combine(folderPath, string.Format("{0}.key", port));
			return File.Exists(path) && File.Exists(path2);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000F7F8 File Offset: 0x0000D9F8
		internal void RemoveConnection(HttpConnection connection)
		{
			object connectionsSync = this._connectionsSync;
			lock (connectionsSync)
			{
				this._connections.Remove(connection);
			}
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000F840 File Offset: 0x0000DA40
		internal bool TrySearchHttpListener(Uri uri, out HttpListener listener)
		{
			listener = null;
			if (uri == null)
			{
				return false;
			}
			string host = uri.Host;
			bool flag = Uri.CheckHostName(host) == UriHostNameType.Dns;
			string b = uri.Port.ToString();
			string text = HttpUtility.UrlDecode(uri.AbsolutePath);
			if (text[text.Length - 1] != '/')
			{
				text += "/";
			}
			if (host != null && host.Length > 0)
			{
				List<HttpListenerPrefix> prefixes = this._prefixes;
				int num = -1;
				foreach (HttpListenerPrefix httpListenerPrefix in prefixes)
				{
					if (flag)
					{
						string host2 = httpListenerPrefix.Host;
						if (Uri.CheckHostName(host2) == UriHostNameType.Dns && host2 != host)
						{
							continue;
						}
					}
					if (!(httpListenerPrefix.Port != b))
					{
						string path = httpListenerPrefix.Path;
						int length = path.Length;
						if (length >= num && text.StartsWith(path, StringComparison.Ordinal))
						{
							num = length;
							listener = httpListenerPrefix.Listener;
						}
					}
				}
				if (num != -1)
				{
					return true;
				}
			}
			listener = EndPointListener.searchHttpListenerFromSpecial(text, this._unhandled);
			if (listener != null)
			{
				return true;
			}
			listener = EndPointListener.searchHttpListenerFromSpecial(text, this._all);
			return listener != null;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000F98C File Offset: 0x0000DB8C
		public void AddPrefix(HttpListenerPrefix prefix)
		{
			List<HttpListenerPrefix> list;
			if (prefix.Host == "*")
			{
				List<HttpListenerPrefix> list2;
				do
				{
					list = this._unhandled;
					list2 = ((list != null) ? new List<HttpListenerPrefix>(list) : new List<HttpListenerPrefix>());
					EndPointListener.addSpecial(list2, prefix);
				}
				while (Interlocked.CompareExchange<List<HttpListenerPrefix>>(ref this._unhandled, list2, list) != list);
				return;
			}
			if (prefix.Host == "+")
			{
				List<HttpListenerPrefix> list2;
				do
				{
					list = this._all;
					list2 = ((list != null) ? new List<HttpListenerPrefix>(list) : new List<HttpListenerPrefix>());
					EndPointListener.addSpecial(list2, prefix);
				}
				while (Interlocked.CompareExchange<List<HttpListenerPrefix>>(ref this._all, list2, list) != list);
				return;
			}
			int num;
			for (;;)
			{
				list = this._prefixes;
				num = list.IndexOf(prefix);
				if (num > -1)
				{
					break;
				}
				if (Interlocked.CompareExchange<List<HttpListenerPrefix>>(ref this._prefixes, new List<HttpListenerPrefix>(list)
				{
					prefix
				}, list) == list)
				{
					return;
				}
			}
			if (list[num].Listener != prefix.Listener)
			{
				string message = string.Format("There is another listener for {0}.", prefix);
				throw new HttpListenerException(87, message);
			}
			return;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000FA78 File Offset: 0x0000DC78
		public void Close()
		{
			this._socket.Close();
			this.clearConnections();
			EndPointManager.RemoveEndPoint(this._endpoint);
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000FA98 File Offset: 0x0000DC98
		public void RemovePrefix(HttpListenerPrefix prefix)
		{
			List<HttpListenerPrefix> list;
			List<HttpListenerPrefix> list2;
			if (prefix.Host == "*")
			{
				do
				{
					list = this._unhandled;
					if (list == null)
					{
						break;
					}
					list2 = new List<HttpListenerPrefix>(list);
				}
				while (EndPointListener.removeSpecial(list2, prefix) && Interlocked.CompareExchange<List<HttpListenerPrefix>>(ref this._unhandled, list2, list) != list);
				this.leaveIfNoPrefix();
				return;
			}
			if (prefix.Host == "+")
			{
				do
				{
					list = this._all;
					if (list == null)
					{
						break;
					}
					list2 = new List<HttpListenerPrefix>(list);
				}
				while (EndPointListener.removeSpecial(list2, prefix) && Interlocked.CompareExchange<List<HttpListenerPrefix>>(ref this._all, list2, list) != list);
				this.leaveIfNoPrefix();
				return;
			}
			do
			{
				list = this._prefixes;
				if (!list.Contains(prefix))
				{
					break;
				}
				list2 = new List<HttpListenerPrefix>(list);
				list2.Remove(prefix);
			}
			while (Interlocked.CompareExchange<List<HttpListenerPrefix>>(ref this._prefixes, list2, list) != list);
			this.leaveIfNoPrefix();
		}

		// Token: 0x0400011E RID: 286
		private List<HttpListenerPrefix> _all;

		// Token: 0x0400011F RID: 287
		private Dictionary<HttpConnection, HttpConnection> _connections;

		// Token: 0x04000120 RID: 288
		private object _connectionsSync;

		// Token: 0x04000121 RID: 289
		private static readonly string _defaultCertFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		// Token: 0x04000122 RID: 290
		private IPEndPoint _endpoint;

		// Token: 0x04000123 RID: 291
		private List<HttpListenerPrefix> _prefixes;

		// Token: 0x04000124 RID: 292
		private bool _secure;

		// Token: 0x04000125 RID: 293
		private Socket _socket;

		// Token: 0x04000126 RID: 294
		private ServerSslConfiguration _sslConfig;

		// Token: 0x04000127 RID: 295
		private List<HttpListenerPrefix> _unhandled;
	}
}
