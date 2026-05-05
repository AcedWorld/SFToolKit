using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Collections
{
	// Token: 0x02000092 RID: 146
	internal sealed class NativeHashMapDebuggerTypeProxy<TKey, TValue> where TKey : struct, IEquatable<TKey> where TValue : struct
	{
		// Token: 0x06000633 RID: 1587 RVA: 0x00014ED6 File Offset: 0x000130D6
		public NativeHashMapDebuggerTypeProxy(NativeHashMap<TKey, TValue> target)
		{
			this.m_Target = target.m_HashMapData;
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000634 RID: 1588 RVA: 0x00014EEC File Offset: 0x000130EC
		public List<Pair<TKey, TValue>> Items
		{
			get
			{
				List<Pair<TKey, TValue>> list = new List<Pair<TKey, TValue>>();
				using (NativeKeyValueArrays<TKey, TValue> keyValueArrays = this.m_Target.GetKeyValueArrays(Allocator.Temp))
				{
					for (int i = 0; i < keyValueArrays.Length; i++)
					{
						List<Pair<TKey, TValue>> list2 = list;
						NativeArray<TKey> keys = keyValueArrays.Keys;
						TKey k = keys[i];
						NativeArray<TValue> values = keyValueArrays.Values;
						list2.Add(new Pair<TKey, TValue>(k, values[i]));
					}
				}
				return list;
			}
		}

		// Token: 0x0400026E RID: 622
		private UnsafeHashMap<TKey, TValue> m_Target;
	}
}
