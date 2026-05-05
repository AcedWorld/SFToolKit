using System;
using System.Collections.Generic;

namespace Unity.Services.Relay
{
	// Token: 0x02000005 RID: 5
	internal class Configuration
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020F0 File Offset: 0x000002F0
		public Configuration(string basePath, int? requestTimeout, int? numRetries, IDictionary<string, string> headers)
		{
			this.BasePath = basePath;
			this.RequestTimeout = requestTimeout;
			this.NumberOfRetries = numRetries;
			if (headers == null)
			{
				this.Headers = headers;
				return;
			}
			this.Headers = new Dictionary<string, string>(headers);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002128 File Offset: 0x00000328
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

		// Token: 0x04000002 RID: 2
		public string BasePath;

		// Token: 0x04000003 RID: 3
		public int? RequestTimeout;

		// Token: 0x04000004 RID: 4
		public int? NumberOfRetries;

		// Token: 0x04000005 RID: 5
		public IDictionary<string, string> Headers;
	}
}
