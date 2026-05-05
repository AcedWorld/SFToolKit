using System;

namespace Unity.Collections
{
	// Token: 0x0200004E RID: 78
	[Obsolete("FixedListByte64DebugView is deprecated. (UnityUpgradable) -> FixedList64BytesDebugView<byte>", true)]
	internal sealed class FixedListByte64DebugView
	{
		// Token: 0x06000288 RID: 648 RVA: 0x00007F37 File Offset: 0x00006137
		public FixedListByte64DebugView(FixedList64Bytes<byte> list)
		{
			this.m_List = list;
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000289 RID: 649 RVA: 0x00007F46 File Offset: 0x00006146
		public byte[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000B5 RID: 181
		private FixedList64Bytes<byte> m_List;
	}
}
