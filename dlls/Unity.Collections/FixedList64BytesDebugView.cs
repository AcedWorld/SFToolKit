using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x0200003B RID: 59
	internal sealed class FixedList64BytesDebugView<[IsUnmanaged] T> where T : struct, ValueType
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x00005BCB File Offset: 0x00003DCB
		public FixedList64BytesDebugView(FixedList64Bytes<T> list)
		{
			this.m_List = list;
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00005BDA File Offset: 0x00003DDA
		public T[] Items
		{
			get
			{
				return this.m_List.ToArray();
			}
		}

		// Token: 0x040000A4 RID: 164
		private FixedList64Bytes<T> m_List;
	}
}
