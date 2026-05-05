using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200025D RID: 605
	[Obsolete("IDataWatchHandle is no longer supported and will be removed soon", true)]
	internal interface IDataWatchHandle : IDisposable
	{
		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06001152 RID: 4434
		Object watched { get; }

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06001153 RID: 4435
		bool disposed { get; }
	}
}
