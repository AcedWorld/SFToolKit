using System;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000015 RID: 21
	internal interface IDateTimeWrapper
	{
		// Token: 0x0600006D RID: 109
		double SecondsSinceUnixEpoch();

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600006E RID: 110
		DateTime UtcNow { get; }
	}
}
