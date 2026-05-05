using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000051 RID: 81
	internal interface ICache
	{
		// Token: 0x06000222 RID: 546
		bool HasKey(string key);

		// Token: 0x06000223 RID: 547
		void DeleteKey(string key);

		// Token: 0x06000224 RID: 548
		void SetString(string key, string value);

		// Token: 0x06000225 RID: 549
		string GetString(string key);
	}
}
