using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace WebSocketSharp.Net
{
	// Token: 0x0200001E RID: 30
	internal sealed class EndPointManager
	{
		// Token: 0x06000218 RID: 536 RVA: 0x00009BF3 File Offset: 0x00007DF3
		private EndPointManager()
		{
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000E5C0 File Offset: 0x0000C7C0
		private static void addPrefix(string uriPrefix, HttpListener listener)
		{
			HttpListenerPrefix httpListenerPrefix = new HttpListenerPrefix(uriPrefix, listener);
			IPAddress ipaddress = EndPointManager.convertToIPAddress(httpListenerPrefix.Host);
			bool flag = ipaddress == null;
			if (flag)
			{
				string message = "The URI prefix includes an invalid host.";
				throw new HttpListenerException(87, message);
			}
			bool flag2 = !ipaddress.IsLocal();
			if (flag2)
			{
				string message2 = "The URI prefix includes an invalid host.";
				throw new HttpListenerException(87, message2);
			}
			int num;
			bool flag3 = !int.TryParse(httpListenerPrefix.Port, out num);
			if (flag3)
			{
				string message3 = "The URI prefix includes an invalid port.";
				throw new HttpListenerException(87, message3);
			}
			bool flag4 = !num.IsPortNumber();
			if (flag4)
			{
				string message4 = "The URI prefix includes an invalid port.";
				throw new HttpListenerException(87, message4);
			}
			string path = httpListenerPrefix.Path;
			bool flag5 = path.IndexOf('%') != -1;
			if (flag5)
			{
				string message5 = "The URI prefix includes an invalid path.";
				throw new HttpListenerException(87, message5);
			}
			bool flag6 = path.IndexOf("//", StringComparison.Ordinal) != -1;
			if (flag6)
			{
				string message6 = "The URI prefix includes an invalid path.";
				throw new HttpListenerException(87, message6);
			}
			IPEndPoint ipendPoint = new IPEndPoint(ipaddress, num);
			EndPointListener endPointListener;
			bool flag7 = EndPointManager._endpoints.TryGetValue(ipendPoint, out endPointListener);
			if (flag7)
			{
				bool flag8 = endPointListener.IsSecure ^ httpListenerPrefix.IsSecure;
				if (flag8)
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

		// Token: 0x0600021A RID: 538 RVA: 0x0000E744 File Offset: 0x0000C944
		private static IPAddress convertToIPAddress(string hostname)
		{
			bool flag = hostname == "*";
			IPAddress result;
			if (flag)
			{
				result = IPAddress.Any;
			}
			else
			{
				bool flag2 = hostname == "+";
				if (flag2)
				{
					result = IPAddress.Any;
				}
				else
				{
					result = hostname.ToIPAddress();
				}
			}
			return result;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000E78C File Offset: 0x0000C98C
		private static void removePrefix(string uriPrefix, HttpListener listener)
		{
			HttpListenerPrefix httpListenerPrefix = new HttpListenerPrefix(uriPrefix, listener);
			IPAddress ipaddress = EndPointManager.convertToIPAddress(httpListenerPrefix.Host);
			bool flag = ipaddress == null;
			if (!flag)
			{
				bool flag2 = !ipaddress.IsLocal();
				if (!flag2)
				{
					int num;
					bool flag3 = !int.TryParse(httpListenerPrefix.Port, out num);
					if (!flag3)
					{
						bool flag4 = !num.IsPortNumber();
						if (!flag4)
						{
							string path = httpListenerPrefix.Path;
							bool flag5 = path.IndexOf('%') != -1;
							if (!flag5)
							{
								bool flag6 = path.IndexOf("//", StringComparison.Ordinal) != -1;
								if (!flag6)
								{
									IPEndPoint key = new IPEndPoint(ipaddress, num);
									EndPointListener endPointListener;
									bool flag7 = !EndPointManager._endpoints.TryGetValue(key, out endPointListener);
									if (!flag7)
									{
										bool flag8 = endPointListener.IsSecure ^ httpListenerPrefix.IsSecure;
										if (!flag8)
										{
											endPointListener.RemovePrefix(httpListenerPrefix);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000E878 File Offset: 0x0000CA78
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

		// Token: 0x0600021D RID: 541 RVA: 0x0000E8C8 File Offset: 0x0000CAC8
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

		// Token: 0x0600021E RID: 542 RVA: 0x0000E9B4 File Offset: 0x0000CBB4
		public static void AddPrefix(string uriPrefix, HttpListener listener)
		{
			object syncRoot = ((ICollection)EndPointManager._endpoints).SyncRoot;
			lock (syncRoot)
			{
				EndPointManager.addPrefix(uriPrefix, listener);
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000EA00 File Offset: 0x0000CC00
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

		// Token: 0x06000220 RID: 544 RVA: 0x0000EA84 File Offset: 0x0000CC84
		public static void RemovePrefix(string uriPrefix, HttpListener listener)
		{
			object syncRoot = ((ICollection)EndPointManager._endpoints).SyncRoot;
			lock (syncRoot)
			{
				EndPointManager.removePrefix(uriPrefix, listener);
			}
		}

		// Token: 0x040000C1 RID: 193
		private static readonly Dictionary<IPEndPoint, EndPointListener> _endpoints = new Dictionary<IPEndPoint, EndPointListener>();
	}
}
