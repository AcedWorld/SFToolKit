using System;

namespace Unity.Collections
{
	// Token: 0x02000099 RID: 153
	public interface IIndexable<T> where T : struct
	{
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600066E RID: 1646
		// (set) Token: 0x0600066F RID: 1647
		int Length { get; set; }

		// Token: 0x06000670 RID: 1648
		ref T ElementAt(int index);
	}
}
