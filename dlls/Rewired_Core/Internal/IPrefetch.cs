using System;

namespace Rewired.Internal
{
	// Token: 0x0200042C RID: 1068
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal interface IPrefetch
	{
		// Token: 0x06002AFE RID: 11006
		void Prefetch();
	}
}
