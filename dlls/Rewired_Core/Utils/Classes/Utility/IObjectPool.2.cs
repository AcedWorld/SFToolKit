using System;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004D4 RID: 1236
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IObjectPool<T>
	{
		// Token: 0x060031A4 RID: 12708
		void Clear(bool reduceSize = false);

		// Token: 0x060031A5 RID: 12709
		T Get();

		// Token: 0x060031A6 RID: 12710
		bool Return(T item);
	}
}
