using System;

namespace Unity.Collections
{
	// Token: 0x0200005A RID: 90
	[Obsolete("FixedListInt128DebugView is deprecated. (UnityUpgradable) -> FixedList128BytesDebugView<int>", true)]
	internal sealed class FixedListInt128DebugView
	{
		// Token: 0x06000294 RID: 660 RVA: 0x00007FDF File Offset: 0x000061DF
		public FixedListInt128DebugView(FixedList128Bytes<int> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000295 RID: 661 RVA: 0x00007FEE File Offset: 0x000061EE
		public int[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000BB RID: 187
		private FixedList128Bytes<int> m_List;
	}
}
