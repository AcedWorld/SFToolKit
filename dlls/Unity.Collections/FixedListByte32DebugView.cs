using System;

namespace Unity.Collections
{
	// Token: 0x0200004C RID: 76
	[Obsolete("FixedListByte32DebugView is deprecated. (UnityUpgradable) -> FixedList32BytesDebugView<byte>", true)]
	internal sealed class FixedListByte32DebugView
	{
		// Token: 0x06000286 RID: 646 RVA: 0x00007F1B File Offset: 0x0000611B
		public FixedListByte32DebugView(FixedList32Bytes<byte> list)
		{
			this.m_List = list;
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00007F2A File Offset: 0x0000612A
		public byte[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000B4 RID: 180
		private FixedList32Bytes<byte> m_List;
	}
}
