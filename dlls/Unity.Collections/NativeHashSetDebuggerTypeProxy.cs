using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Unity.Collections
{
	// Token: 0x02000097 RID: 151
	internal sealed class NativeHashSetDebuggerTypeProxy<[IsUnmanaged] T> where T : struct, ValueType, IEquatable<T>
	{
		// Token: 0x06000654 RID: 1620 RVA: 0x000151B2 File Offset: 0x000133B2
		public NativeHashSetDebuggerTypeProxy(NativeHashSet<T> data)
		{
			this.Data = data;
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x000151C4 File Offset: 0x000133C4
		public List<T> Items
		{
			get
			{
				List<T> list = new List<T>();
				using (NativeArray<T> nativeArray = this.Data.ToNativeArray(Allocator.Temp))
				{
					for (int i = 0; i < nativeArray.Length; i++)
					{
						list.Add(nativeArray[i]);
					}
				}
				return list;
			}
		}

		// Token: 0x04000272 RID: 626
		private NativeHashSet<T> Data;
	}
}
