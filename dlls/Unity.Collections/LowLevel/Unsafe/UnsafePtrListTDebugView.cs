using System;
using System.Runtime.CompilerServices;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000113 RID: 275
	internal sealed class UnsafePtrListTDebugView<[IsUnmanaged] T> where T : struct, ValueType
	{
		// Token: 0x06000A8C RID: 2700 RVA: 0x00021830 File Offset: 0x0001FA30
		public UnsafePtrListTDebugView(UnsafePtrList<T> data)
		{
			this.Data = data;
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x00021840 File Offset: 0x0001FA40
		public unsafe T*[] Items
		{
			get
			{
				T*[] array = new T*[this.Data.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = *(IntPtr*)(this.Data.Ptr + (IntPtr)i * (IntPtr)sizeof(T*) / (IntPtr)sizeof(T*));
				}
				return array;
			}
		}

		// Token: 0x04000394 RID: 916
		private UnsafePtrList<T> Data;
	}
}
