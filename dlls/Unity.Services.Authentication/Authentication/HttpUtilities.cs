using System;
using System.Collections.Generic;
using System.Text;

namespace Unity.Services.Authentication
{
	// Token: 0x02000048 RID: 72
	internal static class HttpUtilities
	{
		// Token: 0x060001DB RID: 475 RVA: 0x00005E54 File Offset: 0x00004054
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

		// Token: 0x060001DC RID: 476 RVA: 0x00005ECC File Offset: 0x000040CC
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

		// Token: 0x060001DD RID: 477 RVA: 0x00005F58 File Offset: 0x00004158
		private static string EscapeUrlString(string rawString)
		{
			return Uri.EscapeDataString(rawString);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00005F60 File Offset: 0x00004160
		private static string UnescapeUrlString(string urlString)
		{
			return Uri.UnescapeDataString(urlString);
		}
	}
}
