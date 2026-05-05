using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x0200011B RID: 283
	internal sealed class UnsafeRingQueueDebugView<[IsUnmanaged] T> where T : struct, ValueType
	{
		// Token: 0x06000ACE RID: 2766 RVA: 0x00022057 File Offset: 0x00020257
		public UnsafeRingQueueDebugView(UnsafeRingQueue<T> data)
		{
			this.Data = data;
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000ACF RID: 2767 RVA: 0x00022068 File Offset: 0x00020268
		public unsafe T[] Items
		{
			get
			{
				T[] array = new T[this.Data.Length];
				int read = this.Data.Control.Read;
				int capacity = this.Data.Control.Capacity;
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this.Data.Ptr[(IntPtr)((read + i) % capacity) * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
				}
				return array;
			}
		}

		// Token: 0x040003A7 RID: 935
		private UnsafeRingQueue<T> Data;
	}
}
