using System;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x02000060 RID: 96
	internal interface IApiResponse
	{
		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000288 RID: 648
		object Content { get; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000289 RID: 649
		int StatusCode { get; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600028A RID: 650
		Multimap<string, string> Headers { get; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600028B RID: 651
		string ErrorText { get; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600028C RID: 652
		string RawContent { get; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600028D RID: 653
		bool IsSuccessful { get; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600028E RID: 654
		bool IsRedirection { get; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600028F RID: 655
		bool IsClientError { get; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000290 RID: 656
		bool IsServerError { get; }
	}
}
