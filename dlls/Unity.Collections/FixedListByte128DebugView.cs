using System;

namespace Unity.Collections
{
	// Token: 0x02000050 RID: 80
	[Obsolete("FixedListByte128DebugView is deprecated. (UnityUpgradable) -> FixedList128BytesDebugView<byte>", true)]
	internal sealed class FixedListByte128DebugView
	{
		// Token: 0x0600028A RID: 650 RVA: 0x00007F53 File Offset: 0x00006153
		public FixedListByte128DebugView(FixedList128Bytes<byte> list)
		{
			this.m_List = list;
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00007F62 File Offset: 0x00006162
		public byte[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000B6 RID: 182
		private FixedList128Bytes<byte> m_List;
	}
}
