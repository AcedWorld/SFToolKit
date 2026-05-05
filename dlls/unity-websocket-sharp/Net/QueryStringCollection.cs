using System;
using System.Collections.Specialized;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000046 RID: 70
	internal sealed class QueryStringCollection : NameValueCollection
	{
		// Token: 0x06000497 RID: 1175 RVA: 0x000156E1 File Offset: 0x000138E1
		public QueryStringCollection()
		{
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x000156E9 File Offset: 0x000138E9
		public QueryStringCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x000156F2 File Offset: 0x000138F2
		public static QueryStringCollection Parse(string query)
		{
			return QueryStringCollection.Parse(query, Encoding.UTF8);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00015700 File Offset: 0x00013900
		public static QueryStringCollection Parse(string query, Encoding encoding)
		{
			if (query == null)
			{
				return new QueryStringCollection(1);
			}
			if (query.Length == 0)
			{
				return new QueryStringCollection(1);
			}
			if (query == "?")
			{
				return new QueryStringCollection(1);
			}
			if (query[0] == '?')
			{
				query = query.Substring(1);
			}
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			QueryStringCollection queryStringCollection = new QueryStringCollection();
			foreach (string text in query.Split('&', StringSplitOptions.None))
			{
				int length = text.Length;
				if (length != 0 && !(text == "="))
				{
					string name = null;
					int num = text.IndexOf('=');
					string value;
					if (num < 0)
					{
						value = text.UrlDecode(encoding);
					}
					else if (num == 0)
					{
						value = text.Substring(1).UrlDecode(encoding);
					}
					else
					{
						name = text.Substring(0, num).UrlDecode(encoding);
						int num2 = num + 1;
						value = ((num2 < length) ? text.Substring(num2).UrlDecode(encoding) : string.Empty);
					}
					queryStringCollection.Add(name, value);
				}
			}
			return queryStringCollection;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00015810 File Offset: 0x00013A10
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string text in this.AllKeys)
			{
				stringBuilder.AppendFormat("{0}={1}&", text, base[text]);
			}
			if (stringBuilder.Length > 0)
			{
				StringBuilder stringBuilder2 = stringBuilder;
				int i = stringBuilder2.Length;
				stringBuilder2.Length = i - 1;
			}
			return stringBuilder.ToString();
		}
	}
}
