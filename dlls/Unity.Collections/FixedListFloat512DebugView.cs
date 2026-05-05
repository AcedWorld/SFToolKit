using System;

namespace Unity.Collections
{
	// Token: 0x02000066 RID: 102
	[Obsolete("FixedListFloat512DebugView is deprecated. (UnityUpgradable) -> FixedList512BytesDebugView<float>", true)]
	internal sealed class FixedListFloat512DebugView
	{
		// Token: 0x060002A0 RID: 672 RVA: 0x00008087 File Offset: 0x00006287
		public FixedListFloat512DebugView(FixedList512Bytes<float> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x00008096 File Offset: 0x00006296
		public float[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000C1 RID: 193
		private FixedList512Bytes<float> m_List;
	}
}
