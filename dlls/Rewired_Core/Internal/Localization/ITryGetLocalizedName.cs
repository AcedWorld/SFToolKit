using System;

namespace Rewired.Internal.Localization
{
	// Token: 0x02000435 RID: 1077
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal interface ITryGetLocalizedName
	{
		// Token: 0x06002B6E RID: 11118
		bool TryGetLocalizedName(out string value);
	}
}
