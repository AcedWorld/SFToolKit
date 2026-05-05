using System;

namespace Unity.Collections
{
	// Token: 0x02000052 RID: 82
	[Obsolete("FixedListByte512DebugView is deprecated. (UnityUpgradable) -> FixedList512BytesDebugView<byte>", true)]
	internal sealed class FixedListByte512DebugView
	{
		// Token: 0x0600028C RID: 652 RVA: 0x00007F6F File Offset: 0x0000616F
		public FixedListByte512DebugView(FixedList512Bytes<byte> list)
		{
			this.m_List = list;
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600028D RID: 653 RVA: 0x00007F7E File Offset: 0x0000617E
		public byte[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000B7 RID: 183
		private FixedList512Bytes<byte> m_List;
	}
}
