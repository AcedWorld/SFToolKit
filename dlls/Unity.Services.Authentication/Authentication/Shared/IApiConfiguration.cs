using System;
using System.Collections.Generic;

namespace Unity.Services.Authentication.Shared
{
	// Token: 0x02000066 RID: 102
	internal interface IApiConfiguration
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002BD RID: 701
		// (set) Token: 0x060002BE RID: 702
		string AccessToken { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002BF RID: 703
		// (set) Token: 0x060002C0 RID: 704
		IDictionary<string, string> ApiKey { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002C1 RID: 705
		// (set) Token: 0x060002C2 RID: 706
		IDictionary<string, string> ApiKeyPrefix { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002C3 RID: 707
		// (set) Token: 0x060002C4 RID: 708
		IDictionary<string, string> DefaultHeaders { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060002C5 RID: 709
		// (set) Token: 0x060002C6 RID: 710
		string BasePath { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002C7 RID: 711
		// (set) Token: 0x060002C8 RID: 712
		string DateTimeFormat { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002C9 RID: 713
		// (set) Token: 0x060002CA RID: 714
		int Timeout { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002CB RID: 715
		// (set) Token: 0x060002CC RID: 716
		string UserAgent { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002CD RID: 717
		// (set) Token: 0x060002CE RID: 718
		string Username { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002CF RID: 719
		// (set) Token: 0x060002D0 RID: 720
		string Password { get; set; }

		// Token: 0x060002D1 RID: 721
		string GetApiKeyWithPrefix(string apiKeyIdentifier);
	}
}
