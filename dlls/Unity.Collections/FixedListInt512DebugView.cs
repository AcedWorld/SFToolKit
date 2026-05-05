using System;

namespace Unity.Collections
{
	// Token: 0x0200005C RID: 92
	[Obsolete("FixedListInt512DebugView is deprecated. (UnityUpgradable) -> FixedList512BytesDebugView<int>", true)]
	internal sealed class FixedListInt512DebugView
	{
		// Token: 0x06000296 RID: 662 RVA: 0x00007FFB File Offset: 0x000061FB
		public FixedListInt512DebugView(FixedList512Bytes<int> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000800A File Offset: 0x0000620A
		public int[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000BC RID: 188
		private FixedList512Bytes<int> m_List;
	}
}
