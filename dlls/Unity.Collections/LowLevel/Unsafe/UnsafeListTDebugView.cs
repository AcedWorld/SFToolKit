using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x0200010E RID: 270
	internal sealed class UnsafeListTDebugView<[IsUnmanaged] T> where T : struct, ValueType
	{
		// Token: 0x06000A5A RID: 2650 RVA: 0x000213E8 File Offset: 0x0001F5E8
		public UnsafeListTDebugView(UnsafeList<T> data)
		{
			this.Data = data;
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000A5B RID: 2651 RVA: 0x000213F8 File Offset: 0x0001F5F8
		public unsafe T[] Items
		{
			get
			{
				T[] array = new T[this.Data.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this.Data.Ptr[(IntPtr)i * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
				}
				return array;
			}
		}

		// Token: 0x04000389 RID: 905
		private UnsafeList<T> Data;
	}
}
