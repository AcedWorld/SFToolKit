using System;

namespace Unity.Collections
{
	// Token: 0x02000062 RID: 98
	[Obsolete("FixedListFloat64DebugView is deprecated. (UnityUpgradable) -> FixedList64BytesDebugView<float>", true)]
	internal sealed class FixedListFloat64DebugView
	{
		// Token: 0x0600029C RID: 668 RVA: 0x0000804F File Offset: 0x0000624F
		public FixedListFloat64DebugView(FixedList64Bytes<float> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600029D RID: 669 RVA: 0x0000805E File Offset: 0x0000625E
		public float[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000BF RID: 191
		private FixedList64Bytes<float> m_List;
	}
}
