using System;
using System.Diagnostics;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000FA RID: 250
	[DebuggerDisplay("Key = {Key}, Value = {Value}")]
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int),
		typeof(int)
	})]
	public struct KeyValue<TKey, TValue> where TKey : struct, IEquatable<TKey> where TValue : struct
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x0001F360 File Offset: 0x0001D560
		public static KeyValue<TKey, TValue> Null
		{
			get
			{
				return new KeyValue<TKey, TValue>
				{
					m_Index = -1
				};
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060009AF RID: 2479 RVA: 0x0001F380 File Offset: 0x0001D580
		public unsafe TKey Key
		{
			get
			{
				if (this.m_Index != -1)
				{
					return UnsafeUtility.ReadArrayElement<TKey>((void*)this.m_Buffer->keys, this.m_Index);
				}
				return default(TKey);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x0001F3B6 File Offset: 0x0001D5B6
		public unsafe ref TValue Value
		{
			get
			{
				return UnsafeUtility.AsRef<TValue>((void*)(this.m_Buffer->values + UnsafeUtility.SizeOf<TValue>() * this.m_Index));
			}
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0001F3D8 File Offset: 0x0001D5D8
		public unsafe bool GetKeyValue(out TKey key, out TValue value)
		{
			if (this.m_Index != -1)
			{
				key = UnsafeUtility.ReadArrayElement<TKey>((void*)this.m_Buffer->keys, this.m_Index);
				value = UnsafeUtility.ReadArrayElement<TValue>((void*)this.m_Buffer->values, this.m_Index);
				return true;
			}
			key = default(TKey);
			value = default(TValue);
			return false;
		}

		// Token: 0x04000360 RID: 864
		internal unsafe UnsafeHashMapData* m_Buffer;

		// Token: 0x04000361 RID: 865
		internal int m_Index;

		// Token: 0x04000362 RID: 866
		internal int m_Next;
	}
}
