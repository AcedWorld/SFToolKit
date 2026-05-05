using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x02000040 RID: 64
	internal sealed class FixedList128BytesDebugView<[IsUnmanaged] T> where T : struct, ValueType
	{
		// Token: 0x060001EE RID: 494 RVA: 0x00006787 File Offset: 0x00004987
		public FixedList128BytesDebugView(FixedList128Bytes<T> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00006796 File Offset: 0x00004996
		public T[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000A9 RID: 169
		private FixedList128Bytes<T> m_List;
	}
}
