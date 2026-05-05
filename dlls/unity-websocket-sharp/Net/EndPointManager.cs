using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200002E RID: 46
	internal sealed class EndPointManager
	{
		// Token: 0x06000354 RID: 852 RVA: 0x0000FB6C File Offset: 0x0000DD6C
		private EndPointManager()
		{
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000FB74 File Offset: 0x0000DD74
		private static void addPrefix(string uriPrefix, HttpListener listener)
		{
			HttpListenerPrefix httpListenerPrefix = new HttpListenerPrefix(uriPrefix, listener);
			IPAddress ipaddress = EndPointManager.convertToIPAddress(httpListenerPrefix.Host);
			if (ipaddress == null)
			{
				string message = "The URI prefix includes an invalid host.";
				throw new HttpListenerException(87, message);
			}
			if (!ipaddress.IsLocal())
			{
				string message2 = "The URI prefix includes an invalid host.";
				throw new HttpListenerException(87, message2);
			}
			int num;
			if (!int.TryParse(httpListenerPrefix.Port, out num))
			{
				string message3 = "The URI prefix includes an invalid port.";
				throw new HttpListenerException(87, message3);
			}
			if (!num.IsPortNumber())
			{
				string message4 = "The URI prefix includes an invalid port.";
				throw new HttpListenerException(87, message4);
			}
			string path = httpListenerPrefix.Path;
			if (path.IndexOf('%') != -1)
			{
				string message5 = "The URI prefix includes an invalid path.";
				throw new HttpListenerException(87, message5);
			}
			if (path.IndexOf("//", StringComparison.Ordinal) != -1)
			{
				string message6 = "The URI prefix includes an invalid path.";
				throw new HttpListenerException(87, message6);
			}
			IPEndPoint ipendPoint = new IPEndPoint(ipaddress, num);
			EndPointListener endPointListener;
			if (EndPointManager._endpoints.TryGetValue(ipendPoint, out endPointListener))
			{
				if (endPointListener.IsSecure ^ httpListenerPrefix.IsSecure)
				{
					string message7 = "The URI prefix includes an invalid scheme.";
					throw new HttpListenerException(87, message7);
				}
			}
			else
			{
				endPointListener = new EndPointListener(ipendPoint, httpListenerPrefix.IsSecure, listener.CertificateFolderPath, listener.SslConfiguration, listener.ReuseAddress);
				EndPointManager._endpoints.Add(ipendPoint, endPointListener);
			}
			endPointListener.AddPrefix(httpListenerPrefix);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000FCA3 File Offset: 0x0000DEA3
		private static IPAddress convertToIPAddress(string hostname)
		{
			if (hostname == "*")
			{
				return IPAddress.Any;
			}
			if (hostname == "+")
			{
				return IPAddress.Any;
			}
			return hostname.ToIPAddress();
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000FCD4 File Offset: 0x0000DED4
		private static void removePrefix(string uriPrefix, HttpListener listener)
		{
			HttpListenerPrefix httpListenerPrefix = new HttpListenerPrefix(uriPrefix, listener);
			IPAddress ipaddress = EndPointManager.convertToIPAddress(httpListenerPrefix.Host);
			if (ipaddress == null)
			{
				return;
			}
			if (!ipaddress.IsLocal())
			{
				return;
			}
			int num;
			if (!int.TryParse(httpListenerPrefix.Port, out num))
			{
				return;
			}
			if (!num.IsPortNumber())
			{
				return;
			}
			string path = httpListenerPrefix.Path;
			if (path.IndexOf('%') != -1)
			{
				return;
			}
			if (path.IndexOf("//", StringComparison.Ordinal) != -1)
			{
				return;
			}
			IPEndPoint key = new IPEndPoint(ipaddress, num);
			EndPointListener endPointListener;
			if (!EndPointManager._endpoints.TryGetValue(key, out endPointListener))
			{
				return;
			}
			if (endPointListener.IsSecure ^ httpListenerPrefix.IsSecure)
			{
				return;
			}
			endPointListener.RemovePrefix(httpListenerPrefix);
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000FD74 File Offset: 0x0000DF74
		internal static bool RemoveEndPoint(IPEndPoint endpoint)
		{
			object syncRoot = ((ICollection)EndPointManager._endpoints).SyncRoot;
			bool result;
			lock (syncRoot)
			{
				result = EndPointManager._endpoints.Remove(endpoint);
			}
			return result;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000FDC0 File Offset: 0x0000DFC0
		public static void AddListener(HttpListener listener)
		{
			List<string> list = new List<string>();
			object syncRoot = ((ICollection)EndPointManager._endpoints).SyncRoot;
			lock (syncRoot)
			{
				try
				{
					foreach (string text in listener.Prefixes)
					{
						EndPointManager.addPrefix(text, listener);
						list.Add(text);
					}
				}
				catch
				{
					foreach (string uriPrefix in list)
					{
						EndPointManager.removePrefix(uriPrefix, listener);
					}
					throw;
				}
			}
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000FE98 File Offset: 0x0000E098
		public static void AddPrefix(string uriPrefix, HttpListener listener)
		{
			object syncRoot = ((ICollection)EndPointManager._endpoints).SyncRoot;
			lock (syncRoot)
			{
				EndPointManager.addPrefix(uriPrefix, listener);
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000FEE0 File Offset: 0x0000E0E0
		public static void RemoveListener(HttpListener listener)
		{
			object syncRoot = ((ICollection)EndPointManager._endpoints).SyncRoot;
			lock (syncRoot)
			{
				foreach (string uriPrefix in listener.Prefixes)
				{
					EndPointManager.removePrefix(uriPrefix, listener);
				}
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000FF58 File Offset: 0x0000E158
		public static void RemovePrefix(string uriPrefix, HttpListener listener)
		{
			object syncRoot = ((ICollection)EndPointManager._endpoints).SyncRoot;
			lock (syncRoot)
			{
				EndPointManager.removePrefix(uriPrefix, listener);
			}
		}

		// Token: 0x04000128 RID: 296
		private static readonly Dictionary<IPEndPoint, EndPointListener> _endpoints = new Dictionary<IPEndPoint, EndPointListener>();
	}
}
