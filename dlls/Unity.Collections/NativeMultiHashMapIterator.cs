using System;

namespace Unity.Collections
{
	// Token: 0x020000A0 RID: 160
	[BurstCompatible(GenericTypeArguments = new Type[]
	{
		typeof(int)
	})]
	public struct NativeMultiHashMapIterator<TKey> where TKey : struct
	{
		// Token: 0x060006B8 RID: 1720 RVA: 0x000161D0 File Offset: 0x000143D0
		public int GetEntryIndex()
		{
			return this.EntryIndex;
		}

		// Token: 0x04000279 RID: 633
		internal TKey key;

		// Token: 0x0400027A RID: 634
		internal int NextEntryIndex;

		// Token: 0x0400027B RID: 635
		internal int EntryIndex;
	}
}
