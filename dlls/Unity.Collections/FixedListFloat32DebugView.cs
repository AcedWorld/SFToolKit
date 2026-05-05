using System;

namespace Unity.Collections
{
	// Token: 0x02000060 RID: 96
	[Obsolete("FixedListFloat32DebugView is deprecated. (UnityUpgradable) -> FixedList32BytesDebugView<float>", true)]
	internal sealed class FixedListFloat32DebugView
	{
		// Token: 0x0600029A RID: 666 RVA: 0x00008033 File Offset: 0x00006233
		public FixedListFloat32DebugView(FixedList32Bytes<float> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00008042 File Offset: 0x00006242
		public float[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000BE RID: 190
		private FixedList32Bytes<float> m_List;
	}
}
