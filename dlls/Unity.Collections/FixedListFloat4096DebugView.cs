using System;

namespace Unity.Collections
{
	// Token: 0x02000068 RID: 104
	[Obsolete("FixedListFloat4096DebugView is deprecated. (UnityUpgradable) -> FixedList4096BytesDebugView<float>", true)]
	internal sealed class FixedListFloat4096DebugView
	{
		// Token: 0x060002A2 RID: 674 RVA: 0x000080A3 File Offset: 0x000062A3
		public FixedListFloat4096DebugView(FixedList4096Bytes<float> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x000080B2 File Offset: 0x000062B2
		public float[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000C2 RID: 194
		private FixedList4096Bytes<float> m_List;
	}
}
