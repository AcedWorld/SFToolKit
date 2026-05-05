using System;
using System.Collections.Generic;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x02000100 RID: 256
	internal sealed class UnsafeHashMapDebuggerTypeProxy<TKey, TValue> where TKey : struct, IEquatable<TKey> where TValue : struct
	{
		// Token: 0x060009D6 RID: 2518 RVA: 0x0001F7E5 File Offset: 0x0001D9E5
		public UnsafeHashMapDebuggerTypeProxy(UnsafeHashMap<TKey, TValue> target)
		{
			this.m_Target = target;
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060009D7 RID: 2519 RVA: 0x0001F7F4 File Offset: 0x0001D9F4
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

		// Token: 0x0400036E RID: 878
		private UnsafeHashMap<TKey, TValue> m_Target;
	}
}
