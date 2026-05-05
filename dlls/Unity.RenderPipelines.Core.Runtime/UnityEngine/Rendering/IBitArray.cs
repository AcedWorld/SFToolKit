using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000C7 RID: 199
	public interface IBitArray
	{
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600062F RID: 1583
		uint capacity { get; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000630 RID: 1584
		bool allFalse { get; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000631 RID: 1585
		bool allTrue { get; }

		// Token: 0x170000F1 RID: 241
		bool this[uint index]
		{
			get;
			set;
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000634 RID: 1588
		string humanizedData { get; }

		// Token: 0x06000635 RID: 1589
		IBitArray BitAnd(IBitArray other);

		// Token: 0x06000636 RID: 1590
		IBitArray BitOr(IBitArray other);

		// Token: 0x06000637 RID: 1591
		IBitArray BitNot();
	}
}
