using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x02000045 RID: 69
	internal sealed class FixedList512BytesDebugView<[IsUnmanaged] T> where T : struct, ValueType
	{
		// Token: 0x06000239 RID: 569 RVA: 0x00007343 File Offset: 0x00005543
		public FixedList512BytesDebugView(FixedList512Bytes<T> list)
		{
			this.m_List = list;
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600023A RID: 570 RVA: 0x00007352 File Offset: 0x00005552
		public T[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000AE RID: 174
		private FixedList512Bytes<T> m_List;
	}
}
