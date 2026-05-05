using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x0200001A RID: 26
	internal static class HttpUtilities
	{
		// Token: 0x0600007E RID: 126 RVA: 0x00003188 File Offset: 0x00001388
		public static IDictionary<string, string> ParseQueryString(string queryString)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (string text in queryString.Split(new char[]
			{
				'?',
				'&'
			}))
			{
				int num = text.IndexOf('=');
				if (num >= 0)
				{
					string key = HttpUtilities.UnescapeUrlString(text.Substring(0, num));
					string value = HttpUtilities.UnescapeUrlString(text.Substring(num + 1));
					dictionary[key] = value;
				}
			}
			return dictionary;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003200 File Offset: 0x00001400
		public static string EncodeQueryString(IDictionary<string, string> queryParams)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			foreach (KeyValuePair<string, string> keyValuePair in queryParams)
			{
				if (!flag)
				{
					stringBuilder.Append('&');
				}
				else
				{
					flag = false;
				}
				stringBuilder.Append(HttpUtilities.EscapeUrlString(keyValuePair.Key)).Append('=').Append(HttpUtilities.EscapeUrlString(keyValuePair.Value));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000328C File Offset: 0x0000148C
		public static bool TryBindListenerOnFreePort(out HttpListener httpListener, out int port)
		{
			for (port = 49215; port < 65535; port++)
			{
				httpListener = new HttpListener();
				httpListener.Prefixes.Add(string.Format("http://localhost:{0}/", port));
				try
				{
					httpListener.Start();
					return true;
				}
				catch
				{
				}
			}
			port = 0;
			httpListener = null;
			return false;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000032FC File Offset: 0x000014FC
		private static string EscapeUrlString(string rawString)
		{
			return Uri.EscapeDataString(rawString);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003304 File Offset: 0x00001504
		private static string UnescapeUrlString(string urlString)
		{
			return Uri.UnescapeDataString(urlString);
		}

		// Token: 0x04000050 RID: 80
		private const int k_MinPort = 49215;

		// Token: 0x04000051 RID: 81
		private const int k_MaxPort = 65535;
	}
}
