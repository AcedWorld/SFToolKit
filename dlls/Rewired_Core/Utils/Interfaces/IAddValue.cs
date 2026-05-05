using System;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x02000531 RID: 1329
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IAddValue<TValue>
	{
		// Token: 0x06003660 RID: 13920
		void Add(TValue value);
	}
}
