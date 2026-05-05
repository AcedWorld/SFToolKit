using System;
using Unity.Services.Core.Configuration.Internal;

namespace Unity.Services.Authentication.PlayerAccounts
{
	// Token: 0x02000011 RID: 17
	internal static class BrowserUtils
	{
		// Token: 0x0600005A RID: 90 RVA: 0x00002C0E File Offset: 0x00000E0E
		internal static IBrowserUtils CreateBrowserUtils(ICloudProjectId cloudProjectId, UnityPlayerAccountSettings settings, Action<string> onAuthCodeReceived)
		{
			StandaloneBrowserUtils standaloneBrowserUtils = new StandaloneBrowserUtils();
			standaloneBrowserUtils.AuthCodeReceivedEvent += onAuthCodeReceived;
			return standaloneBrowserUtils;
		}
	}
}
