using System;
using System.Collections.Generic;

namespace Unity.Services.Qos.V2
{
	// Token: 0x0200001F RID: 31
	internal class Configuration
	{
		// Token: 0x0600007F RID: 127 RVA: 0x00003EF9 File Offset: 0x000020F9
		public Configuration(string basePath, int? requestTimeout, int? numRetries, IDictionary<string, string> headers)
		{
			this.BasePath = basePath;
			this.RequestTimeout = requestTimeout;
			this.NumberOfRetries = numRetries;
			if (headers == null)
			{
				this.Headers = new Dictionary<string, string>();
				return;
			}
			this.Headers = new Dictionary<string, string>(headers);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003F34 File Offset: 0x00002134
		public static Configuration MergeConfigurations(Configuration a, Configuration b)
		{
			if (a == null || b == null)
			{
				return a ?? b;
			}
			Configuration configuration = new Configuration(a.BasePath, a.RequestTimeout, a.NumberOfRetries, a.Headers);
			if (configuration.BasePath == null)
			{
				configuration.BasePath = b.BasePath;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (b.Headers != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in b.Headers)
				{
					dictionary[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			if (configuration.Headers != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair2 in configuration.Headers)
				{
					dictionary[keyValuePair2.Key] = keyValuePair2.Value;
				}
			}
			configuration.Headers = dictionary;
			Configuration configuration2 = configuration;
			int? num = configuration.RequestTimeout;
			configuration2.RequestTimeout = ((num != null) ? num : b.RequestTimeout);
			Configuration configuration3 = configuration;
			num = configuration.NumberOfRetries;
			configuration3.NumberOfRetries = ((num != null) ? num : b.NumberOfRetries);
			return configuration;
		}

		// Token: 0x04000068 RID: 104
		public string BasePath;

		// Token: 0x04000069 RID: 105
		public int? RequestTimeout;

		// Token: 0x0400006A RID: 106
		public int? NumberOfRetries;

		// Token: 0x0400006B RID: 107
		public IDictionary<string, string> Headers;
	}
}
