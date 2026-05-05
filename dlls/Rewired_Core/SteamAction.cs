using System;

namespace Rewired
{
	// Token: 0x02000037 RID: 55
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class SteamAction
	{
		// Token: 0x0600020F RID: 527 RVA: 0x00003C7A File Offset: 0x00001E7A
		public SteamAction(string A_1, ulong A_2)
		{
			this.name = A_1;
			this.handle = A_2;
		}

		// Token: 0x040000F2 RID: 242
		public readonly string name;

		// Token: 0x040000F3 RID: 243
		public readonly ulong handle;
	}
}
