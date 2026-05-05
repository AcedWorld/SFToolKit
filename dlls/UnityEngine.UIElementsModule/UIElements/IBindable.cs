using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000073 RID: 115
	public interface IBindable
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000541 RID: 1345
		// (set) Token: 0x06000542 RID: 1346
		IBinding binding { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000543 RID: 1347
		// (set) Token: 0x06000544 RID: 1348
		string bindingPath { get; set; }
	}
}
