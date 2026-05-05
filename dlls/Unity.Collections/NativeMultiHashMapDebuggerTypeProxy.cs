using System;
using System.Collections.Generic;

namespace Unity.Collections
{
	// Token: 0x020000A5 RID: 165
	internal sealed class NativeMultiHashMapDebuggerTypeProxy<TKey, TValue> where TKey : struct, IEquatable<TKey>, IComparable<TKey> where TValue : struct
	{
		// Token: 0x060006E4 RID: 1764 RVA: 0x000164EF File Offset: 0x000146EF
		public NativeMultiHashMapDebuggerTypeProxy(NativeMultiHashMap<TKey, TValue> target)
		{
			this.m_Target = target;
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060006E5 RID: 1765 RVA: 0x00016500 File Offset: 0x00014700
		public List<ListPair<TKey, List<TValue>>> Items
		{
			get
			{
				List<ListPair<TKey, List<TValue>>> list = new List<ListPair<TKey, List<TValue>>>();
				ValueTuple<NativeArray<TKey>, int> uniqueKeyArray = this.m_Target.GetUniqueKeyArray(Allocator.Temp);
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

		// Token: 0x04000284 RID: 644
		private NativeMultiHashMap<TKey, TValue> m_Target;
	}
}
