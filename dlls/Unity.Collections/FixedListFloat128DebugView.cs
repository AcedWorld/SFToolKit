using System;

namespace Unity.Collections
{
	// Token: 0x02000064 RID: 100
	[Obsolete("FixedListFloat128DebugView is deprecated. (UnityUpgradable) -> FixedList128BytesDebugView<float>", true)]
	internal sealed class FixedListFloat128DebugView
	{
		// Token: 0x0600029E RID: 670 RVA: 0x0000806B File Offset: 0x0000626B
		public FixedListFloat128DebugView(FixedList128Bytes<float> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600029F RID: 671 RVA: 0x0000807A File Offset: 0x0000627A
		public float[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000C0 RID: 192
		private FixedList128Bytes<float> m_List;
	}
}
