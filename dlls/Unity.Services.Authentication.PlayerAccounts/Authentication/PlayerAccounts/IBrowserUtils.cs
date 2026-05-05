using System;
using System.Threading.Tasks;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000012 RID: 18
	internal interface IBrowserUtils
	{
		// Token: 0x0600005B RID: 91
		Task LaunchUrlAsync(string url);

		// Token: 0x0600005C RID: 92
		bool Bind();

		// Token: 0x0600005D RID: 93
		void Dismiss();

		// Token: 0x0600005E RID: 94
		string GetRedirectUri();
	}
}
