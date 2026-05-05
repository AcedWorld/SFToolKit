using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000FB RID: 251
	internal struct UnsafeHashMapDataEnumerator
	{
		// Token: 0x060009B2 RID: 2482 RVA: 0x0001F437 File Offset: 0x0001D637
		internal unsafe UnsafeHashMapDataEnumerator(UnsafeHashMapData* data)
		{
			this.m_Buffer = data;
			this.m_Index = -1;
			this.m_BucketIndex = 0;
			this.m_NextIndex = -1;
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0001F455 File Offset: 0x0001D655
		internal bool MoveNext()
		{
			return UnsafeHashMapData.MoveNext(this.m_Buffer, ref this.m_BucketIndex, ref this.m_NextIndex, out this.m_Index);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x0001F474 File Offset: 0x0001D674
		internal void Reset()
		{
			this.m_Index = -1;
			this.m_BucketIndex = 0;
			this.m_NextIndex = -1;
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0001F48C File Offset: 0x0001D68C
		internal KeyValue<TKey, TValue> GetCurrent<TKey, TValue>() where TKey : struct, IEquatable<TKey> where TValue : struct
		{
			return new KeyValue<TKey, TValue>
			{
				m_Buffer = this.m_Buffer,
				m_Index = this.m_Index
			};
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0001F4BC File Offset: 0x0001D6BC
		internal unsafe TKey GetCurrentKey<TKey>() where TKey : struct, IEquatable<TKey>
		{
			if (this.m_Index != -1)
			{
				return UnsafeUtility.ReadArrayElement<TKey>((void*)this.m_Buffer->keys, this.m_Index);
			}
			return default(TKey);
		}

		// Token: 0x04000363 RID: 867
		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeHashMapData* m_Buffer;

		// Token: 0x04000364 RID: 868
		internal int m_Index;

		// Token: 0x04000365 RID: 869
		internal int m_BucketIndex;

		// Token: 0x04000366 RID: 870
		internal int m_NextIndex;
	}
}
