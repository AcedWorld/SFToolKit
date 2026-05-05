using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000F4 RID: 244
	[BurstCompatible]
	public struct UnsafeHashMapBucketData
	{
		// Token: 0x0600098D RID: 2445 RVA: 0x0001E428 File Offset: 0x0001C628
		internal unsafe UnsafeHashMapBucketData(byte* v, byte* k, byte* n, byte* b, int bcm)
		{
			this.values = v;
			this.keys = k;
			this.next = n;
			this.buckets = b;
			this.bucketCapacityMask = bcm;
		}

		// Token: 0x0400034E RID: 846
		public unsafe readonly byte* values;

		// Token: 0x0400034F RID: 847
		public unsafe readonly byte* keys;

		// Token: 0x04000350 RID: 848
		public unsafe readonly byte* next;

		// Token: 0x04000351 RID: 849
		public unsafe readonly byte* buckets;

		// Token: 0x04000352 RID: 850
		public readonly int bucketCapacityMask;
	}
}
