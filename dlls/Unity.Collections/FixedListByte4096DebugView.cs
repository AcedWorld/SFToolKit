using System;

namespace Unity.Collections
{
	// Token: 0x02000054 RID: 84
	[Obsolete("FixedListByte4096DebugView is deprecated. (UnityUpgradable) -> FixedList4096BytesDebugView<byte>", true)]
	internal sealed class FixedListByte4096DebugView
	{
		// Token: 0x0600028E RID: 654 RVA: 0x00007F8B File Offset: 0x0000618B
		public FixedListByte4096DebugView(FixedList4096Bytes<byte> list)
		{
			this.m_List = list;
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600028F RID: 655 RVA: 0x00007F9A File Offset: 0x0000619A
		public byte[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000B8 RID: 184
		private FixedList4096Bytes<byte> m_List;
	}
}
