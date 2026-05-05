using System;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004D3 RID: 1235
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IObjectPool
	{
		// Token: 0x060031A1 RID: 12705
		void Clear(bool reduceSize = false);

		// Token: 0x060031A2 RID: 12706
		object Get();

		// Token: 0x060031A3 RID: 12707
		bool Return(object item);
	}
}
