using System;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x02000532 RID: 1330
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IAddKeyValue<TKey, TValue>
	{
		// Token: 0x06003661 RID: 13921
		void Add(TKey key, TValue value);
	}
}
