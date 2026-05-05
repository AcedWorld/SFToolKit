using System;
using Rewired.Interfaces;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004D5 RID: 1237
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IPoolableObject_Internal : IPoolableObject, IDisposable
	{
		// Token: 0x17000B3C RID: 2876
		// (get) Token: 0x060031A7 RID: 12711
		// (set) Token: 0x060031A8 RID: 12712
		IObjectPool pool { get; set; }

		// Token: 0x060031A9 RID: 12713
		void Clear();
	}
}
