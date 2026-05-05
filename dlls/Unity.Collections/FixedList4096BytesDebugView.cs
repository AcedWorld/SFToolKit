using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x0200004A RID: 74
	internal sealed class FixedList4096BytesDebugView<[IsUnmanaged] T> where T : struct, ValueType
	{
		// Token: 0x06000284 RID: 644 RVA: 0x00007EFF File Offset: 0x000060FF
		public FixedList4096BytesDebugView(FixedList4096Bytes<T> list)
		{
			this.m_List = list;
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00007F0E File Offset: 0x0000610E
		public T[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000B3 RID: 179
		private FixedList4096Bytes<T> m_List;
	}
}
