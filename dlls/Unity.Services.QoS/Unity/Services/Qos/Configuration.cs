using System;
using System.Collections.Generic;

namespace Unity.Services.Qos
{
	// Token: 0x0200000F RID: 15
	internal class Configuration
	{
		// Token: 0x06000041 RID: 65 RVA: 0x0000345A File Offset: 0x0000165A
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

		// Token: 0x06000042 RID: 66 RVA: 0x00003494 File Offset: 0x00001694
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

		// Token: 0x04000042 RID: 66
		public string BasePath;

		// Token: 0x04000043 RID: 67
		public int? RequestTimeout;

		// Token: 0x04000044 RID: 68
		public int? NumberOfRetries;

		// Token: 0x04000045 RID: 69
		public IDictionary<string, string> Headers;
	}
}
