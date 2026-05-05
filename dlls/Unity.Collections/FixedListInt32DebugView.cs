using System;

namespace Unity.Collections
{
	// Token: 0x02000056 RID: 86
	[Obsolete("FixedListInt32DebugView is deprecated. (UnityUpgradable) -> FixedList32BytesDebugView<int>", true)]
	internal sealed class FixedListInt32DebugView
	{
		// Token: 0x06000290 RID: 656 RVA: 0x00007FA7 File Offset: 0x000061A7
		public FixedListInt32DebugView(FixedList32Bytes<int> list)
		{
			this.m_List = list;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00007FB6 File Offset: 0x000061B6
		public int[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000B9 RID: 185
		private FixedList32Bytes<int> m_List;
	}
}
