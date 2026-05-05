using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x0200002C RID: 44
	internal struct Long1024 : IIndexable<long>
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00003E00 File Offset: 0x00002000
		// (set) Token: 0x060000DD RID: 221 RVA: 0x000024A3 File Offset: 0x000006A3
		public int Length
		{
			get
			{
				return 1024;
			}
			set
			{
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003E08 File Offset: 0x00002008
		public unsafe ref long ElementAt(int index)
		{
			fixed (Long512* ptr = &this.f0)
			{
				return UnsafeUtility.AsRef<long>((void*)((byte*)ptr + (IntPtr)index * 8));
			}
		}

		// Token: 0x0400008F RID: 143
		internal Long512 f0;

		// Token: 0x04000090 RID: 144
		internal Long512 f1;
	}
}
