using System;
using System.Collections.Generic;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x0200005F RID: 95
	internal class ApiRequestPathBuilder
	{
		// Token: 0x06000284 RID: 644 RVA: 0x00006E8F File Offset: 0x0000508F
		public ApiRequestPathBuilder(string baseUrl, string path)
		{
			this._baseUrl = baseUrl;
			this._path = path;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00006EB0 File Offset: 0x000050B0
		public void AddPathParameters(Dictionary<string, string> parameters)
		{
			foreach (KeyValuePair<string, string> keyValuePair in parameters)
			{
				this._path = this._path.Replace("{" + keyValuePair.Key + "}", Uri.EscapeDataString(keyValuePair.Value));
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00006F2C File Offset: 0x0000512C
		public void AddQueryParameters(Multimap<string, string> parameters)
		{
			foreach (KeyValuePair<string, IList<string>> keyValuePair in parameters)
			{
				foreach (string stringToEscape in keyValuePair.Value)
				{
					this._query = string.Concat(new string[]
					{
						this._query,
						keyValuePair.Key,
						"=",
						Uri.EscapeDataString(stringToEscape),
						"&"
					});
				}
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00006FE0 File Offset: 0x000051E0
		public string GetFullUri()
		{
			return this._baseUrl + this._path + this._query.Substring(0, this._query.Length - 1);
		}

		// Token: 0x04000142 RID: 322
		private string _baseUrl;

		// Token: 0x04000143 RID: 323
		private string _path;

		// Token: 0x04000144 RID: 324
		private string _query = "?";
	}
}
