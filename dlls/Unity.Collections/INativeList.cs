using System;

namespace Unity.Collections
{
	// Token: 0x0200009A RID: 154
	public interface INativeList<T> : IIndexable<T> where T : struct
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000671 RID: 1649
		// (set) Token: 0x06000672 RID: 1650
		int Capacity { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000673 RID: 1651
		bool IsEmpty { get; }

		// Token: 0x170000B0 RID: 176
		T this[int index]
		{
			get;
			set;
		}

		// Token: 0x06000676 RID: 1654
		void Clear();
	}
}
