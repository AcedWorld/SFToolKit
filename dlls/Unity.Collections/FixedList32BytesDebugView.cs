using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x02000036 RID: 54
	internal sealed class FixedList32BytesDebugView<[IsUnmanaged] T> where T : struct, ValueType
	{
		// Token: 0x06000158 RID: 344 RVA: 0x0000500F File Offset: 0x0000320F
		public FixedList32BytesDebugView(FixedList32Bytes<T> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000159 RID: 345 RVA: 0x0000501E File Offset: 0x0000321E
		public T[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x0400009F RID: 159
		private FixedList32Bytes<T> m_List;
	}
}
