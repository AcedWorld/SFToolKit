using System;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x02000534 RID: 1332
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface ISetValue<T>
	{
		// Token: 0x06003663 RID: 13923
		void SetValue(T value);
	}
}
