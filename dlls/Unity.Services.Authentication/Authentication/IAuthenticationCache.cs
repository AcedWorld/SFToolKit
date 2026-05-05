using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000050 RID: 80
	internal interface IAuthenticationCache : ICache
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600021F RID: 543
		string Profile { get; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000220 RID: 544
		string CloudProjectId { get; }

		// Token: 0x06000221 RID: 545
		void Migrate(string key);
	}
}
