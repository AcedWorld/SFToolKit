using System;
using System.Collections.Generic;

namespace Rewired
{
	// Token: 0x02000038 RID: 56
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class SteamActionSet
	{
		// Token: 0x06000210 RID: 528 RVA: 0x00003C90 File Offset: 0x00001E90
		public SteamActionSet(string A_1, ulong A_2)
		{
			this.name = A_1;
			this.handle = A_2;
			this.actions = new Dictionary<string, SteamAction>();
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00003CB1 File Offset: 0x00001EB1
		public void AddAction(SteamAction action)
		{
			if (action == null)
			{
				throw new ArgumentNullException();
			}
			this.actions.Add(action.name, action);
		}

		// Token: 0x040000F4 RID: 244
		public readonly string name;

		// Token: 0x040000F5 RID: 245
		public readonly ulong handle;

		// Token: 0x040000F6 RID: 246
		public readonly Dictionary<string, SteamAction> actions;
	}
}
