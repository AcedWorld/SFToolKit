using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x0200005B RID: 91
	internal class ApiConfiguration : IApiConfiguration
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00006AEF File Offset: 0x00004CEF
		// (set) Token: 0x06000258 RID: 600 RVA: 0x00006AF7 File Offset: 0x00004CF7
		public virtual string BasePath
		{
			get
			{
				return this._basePath;
			}
			set
			{
				this._basePath = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00006B00 File Offset: 0x00004D00
		// (set) Token: 0x0600025A RID: 602 RVA: 0x00006B08 File Offset: 0x00004D08
		public virtual IDictionary<string, string> DefaultHeaders { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600025B RID: 603 RVA: 0x00006B11 File Offset: 0x00004D11
		// (set) Token: 0x0600025C RID: 604 RVA: 0x00006B19 File Offset: 0x00004D19
		public virtual int Timeout { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600025D RID: 605 RVA: 0x00006B22 File Offset: 0x00004D22
		// (set) Token: 0x0600025E RID: 606 RVA: 0x00006B2A File Offset: 0x00004D2A
		public virtual string UserAgent { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00006B33 File Offset: 0x00004D33
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00006B3B File Offset: 0x00004D3B
		public virtual string Username { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00006B44 File Offset: 0x00004D44
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00006B4C File Offset: 0x00004D4C
		public virtual string Password { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00006B55 File Offset: 0x00004D55
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00006B5D File Offset: 0x00004D5D
		public virtual string AccessToken { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00006B66 File Offset: 0x00004D66
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00006B6E File Offset: 0x00004D6E
		public virtual string DateTimeFormat
		{
			get
			{
				return this._dateTimeFormat;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this._dateTimeFormat = "o";
					return;
				}
				this._dateTimeFormat = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00006B8B File Offset: 0x00004D8B
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00006B93 File Offset: 0x00004D93
		public virtual IDictionary<string, string> ApiKeyPrefix
		{
			get
			{
				return this._apiKeyPrefix;
			}
			set
			{
				if (value == null)
				{
					throw new InvalidOperationException("ApiKeyPrefix collection may not be null.");
				}
				this._apiKeyPrefix = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00006BAA File Offset: 0x00004DAA
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00006BB2 File Offset: 0x00004DB2
		public virtual IDictionary<string, string> ApiKey
		{
			get
			{
				return this._apiKey;
			}
			set
			{
				if (value == null)
				{
					throw new InvalidOperationException("ApiKey collection may not be null.");
				}
				this._apiKey = value;
			}
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00006BCC File Offset: 0x00004DCC
		public ApiConfiguration()
		{
			this.UserAgent = WebUtility.UrlEncode("openapi-generator/csharp");
			this.DefaultHeaders = new ConcurrentDictionary<string, string>();
			this.ApiKey = new ConcurrentDictionary<string, string>();
			this.ApiKeyPrefix = new ConcurrentDictionary<string, string>();
			this.Timeout = 10;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00006C30 File Offset: 0x00004E30
		public ApiConfiguration(IDictionary<string, string> defaultHeaders, IDictionary<string, string> apiKey, IDictionary<string, string> apiKeyPrefix, string basePath) : this()
		{
			if (string.IsNullOrWhiteSpace(basePath))
			{
				throw new ArgumentException("The provided basePath is invalid.", "basePath");
			}
			if (defaultHeaders == null)
			{
				throw new ArgumentNullException("defaultHeaders");
			}
			if (apiKey == null)
			{
				throw new ArgumentNullException("apiKey");
			}
			if (apiKeyPrefix == null)
			{
				throw new ArgumentNullException("apiKeyPrefix");
			}
			this.BasePath = basePath;
			foreach (KeyValuePair<string, string> item in defaultHeaders)
			{
				this.DefaultHeaders.Add(item);
			}
			foreach (KeyValuePair<string, string> item2 in apiKey)
			{
				this.ApiKey.Add(item2);
			}
			foreach (KeyValuePair<string, string> item3 in apiKeyPrefix)
			{
				this.ApiKeyPrefix.Add(item3);
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00006D48 File Offset: 0x00004F48
		public string GetApiKeyWithPrefix(string apiKeyIdentifier)
		{
			string text;
			this.ApiKey.TryGetValue(apiKeyIdentifier, out text);
			string str;
			if (this.ApiKeyPrefix.TryGetValue(apiKeyIdentifier, out str))
			{
				return str + " " + text;
			}
			return text;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00006D82 File Offset: 0x00004F82
		public void AddApiKey(string key, string value)
		{
			this.ApiKey[key] = value;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00006D91 File Offset: 0x00004F91
		public void AddApiKeyPrefix(string key, string value)
		{
			this.ApiKeyPrefix[key] = value;
		}

		// Token: 0x04000128 RID: 296
		public const string ISO8601_DATETIME_FORMAT = "o";

		// Token: 0x0400012F RID: 303
		private string _basePath;

		// Token: 0x04000130 RID: 304
		private IDictionary<string, string> _apiKey;

		// Token: 0x04000131 RID: 305
		private IDictionary<string, string> _apiKeyPrefix;

		// Token: 0x04000132 RID: 306
		private string _dateTimeFormat = "o";

		// Token: 0x04000133 RID: 307
		private string _tempFolderPath = Path.GetTempPath();
	}
}
