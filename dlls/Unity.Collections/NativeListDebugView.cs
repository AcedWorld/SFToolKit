using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x0200009F RID: 159
	internal sealed class NativeListDebugView<[IsUnmanaged] T> where T : struct, ValueType
	{
		// Token: 0x060006B6 RID: 1718 RVA: 0x0001619F File Offset: 0x0001439F
		public NativeListDebugView(NativeList<T> array)
		{
			this.m_Array = array;
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x000161B0 File Offset: 0x000143B0
		public T[] Items
		{
			get
			{
				return this.m_Array.AsArray().ToArray();
			}
		}

		// Token: 0x04000278 RID: 632
		private NativeList<T> m_Array;
	}
}
