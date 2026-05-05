using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000E2 RID: 226
	internal sealed class UnsafePtrListDebugView
	{
		// Token: 0x0600091E RID: 2334 RVA: 0x0001CB4C File Offset: 0x0001AD4C
		public UnsafePtrListDebugView(UnsafePtrList data)
		{
			this.Data = data;
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x0001CB5C File Offset: 0x0001AD5C
		public unsafe IntPtr[] Items
		{
			get
			{
				IntPtr[] array = new IntPtr[this.Data.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (IntPtr)(*(IntPtr*)(this.Data.Ptr + (IntPtr)i * (IntPtr)sizeof(void*) / (IntPtr)sizeof(void*)));
				}
				return array;
			}
		}

		// Token: 0x04000324 RID: 804
		private UnsafePtrList Data;
	}
}
