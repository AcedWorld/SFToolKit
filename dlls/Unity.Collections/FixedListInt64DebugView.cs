using System;

namespace Unity.Collections
{
	// Token: 0x02000058 RID: 88
	[Obsolete("FixedListInt64DebugView is deprecated. (UnityUpgradable) -> FixedList64BytesDebugView<int>", true)]
	internal sealed class FixedListInt64DebugView
	{
		// Token: 0x06000292 RID: 658 RVA: 0x00007FC3 File Offset: 0x000061C3
		public FixedListInt64DebugView(FixedList64Bytes<int> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00007FD2 File Offset: 0x000061D2
		public int[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000BA RID: 186
		private FixedList64Bytes<int> m_List;
	}
}
