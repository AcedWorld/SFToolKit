using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000105 RID: 261
	internal sealed class UnsafeHashSetDebuggerTypeProxy<[IsUnmanaged] T> where T : struct, ValueType, IEquatable<T>
	{
		// Token: 0x060009F0 RID: 2544 RVA: 0x0001F9D1 File Offset: 0x0001DBD1
		public UnsafeHashSetDebuggerTypeProxy(UnsafeHashSet<T> data)
		{
			this.Data = data;
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x0001F9E0 File Offset: 0x0001DBE0
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

		// Token: 0x04000374 RID: 884
		private UnsafeHashSet<T> Data;
	}
}
