using System;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x0200052B RID: 1323
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IReadOnlyList
	{
		// Token: 0x17000C1B RID: 3099
		// (get) Token: 0x0600364E RID: 13902
		int Count { get; }

		// Token: 0x17000C1C RID: 3100
		object this[int index]
		{
			get;
		}

		// Token: 0x06003650 RID: 13904
		int IndexOf(object value);

		// Token: 0x06003651 RID: 13905
		bool Contains(object value);
	}
}
