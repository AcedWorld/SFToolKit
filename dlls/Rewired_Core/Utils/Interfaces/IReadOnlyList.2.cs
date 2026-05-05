using System;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x0200052C RID: 1324
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IReadOnlyList<T> : IReadOnlyList
	{
		// Token: 0x17000C1D RID: 3101
		T this[int index]
		{
			get;
		}

		// Token: 0x06003653 RID: 13907
		int IndexOf(T value);

		// Token: 0x06003654 RID: 13908
		bool Contains(T value);
	}
}
