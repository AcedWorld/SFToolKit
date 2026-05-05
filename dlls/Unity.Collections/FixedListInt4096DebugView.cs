using System;

namespace Unity.Collections
{
	// Token: 0x0200005E RID: 94
	[Obsolete("FixedListInt4096DebugView is deprecated. (UnityUpgradable) -> FixedList4096BytesDebugView<int>", true)]
	internal sealed class FixedListInt4096DebugView
	{
		// Token: 0x06000298 RID: 664 RVA: 0x00008017 File Offset: 0x00006217
		public FixedListInt4096DebugView(FixedList4096Bytes<int> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00008026 File Offset: 0x00006226
		public int[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000BD RID: 189
		private FixedList4096Bytes<int> m_List;
	}
}
