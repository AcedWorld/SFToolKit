using System;
using System.Collections.Generic;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000118 RID: 280
	internal sealed class UnsafeMultiHashMapDebuggerTypeProxy<TKey, TValue> where TKey : struct, IEquatable<TKey>, IComparable<TKey> where TValue : struct
	{
		// Token: 0x06000AB5 RID: 2741 RVA: 0x00021BFD File Offset: 0x0001FDFD
		public UnsafeMultiHashMapDebuggerTypeProxy(UnsafeMultiHashMap<TKey, TValue> target)
		{
			this.m_Target = target;
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x00021C0C File Offset: 0x0001FE0C
		public static ValueTuple<NativeArray<TKey>, int> GetUniqueKeyArray(ref UnsafeMultiHashMap<TKey, TValue> hashMap, AllocatorManager.AllocatorHandle allocator)
		{
			NativeArray<TKey> keyArray = hashMap.GetKeyArray(allocator);
			keyArray.Sort<TKey>();
			int item = keyArray.Unique<TKey>();
			return new ValueTuple<NativeArray<TKey>, int>(keyArray, item);
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x00021C34 File Offset: 0x0001FE34
		public List<ListPair<TKey, List<TValue>>> Items
		{
			get
			{
				List<ListPair<TKey, List<TValue>>> list = new List<ListPair<TKey, List<TValue>>>();
				ValueTuple<NativeArray<TKey>, int> uniqueKeyArray = UnsafeMultiHashMapDebuggerTypeProxy<TKey, TValue>.GetUniqueKeyArray(ref this.m_Target, Allocator.Temp);
				using (uniqueKeyArray.Item1)
				{
					for (int i = 0; i < uniqueKeyArray.Item2; i++)
					{
						List<TValue> list2 = new List<TValue>();
						TValue item2;
						NativeMultiHashMapIterator<TKey> nativeMultiHashMapIterator;
						if (this.m_Target.TryGetFirstValue(uniqueKeyArray.Item1[i], out item2, out nativeMultiHashMapIterator))
						{
							do
							{
								list2.Add(item2);
							}
							while (this.m_Target.TryGetNextValue(out item2, ref nativeMultiHashMapIterator));
						}
						list.Add(new ListPair<TKey, List<TValue>>(uniqueKeyArray.Item1[i], list2));
					}
				}
				return list;
			}
		}

		// Token: 0x0400039F RID: 927
		private UnsafeMultiHashMap<TKey, TValue> m_Target;
	}
}
