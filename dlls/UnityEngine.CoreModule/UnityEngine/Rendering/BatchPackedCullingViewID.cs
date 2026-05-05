using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200043B RID: 1083
	public struct BatchPackedCullingViewID : IEquatable<BatchPackedCullingViewID>
	{
		// Token: 0x06002451 RID: 9297 RVA: 0x0003D0EC File Offset: 0x0003B2EC
		public override int GetHashCode()
		{
			return this.handle.GetHashCode();
		}

		// Token: 0x06002452 RID: 9298 RVA: 0x0003D10C File Offset: 0x0003B30C
		public bool Equals(BatchPackedCullingViewID other)
		{
			return this.handle == other.handle;
		}

		// Token: 0x06002453 RID: 9299 RVA: 0x0003D12C File Offset: 0x0003B32C
		public override bool Equals(object obj)
		{
			bool flag = !(obj is BatchPackedCullingViewID);
			return !flag && this.Equals((BatchPackedCullingViewID)obj);
		}

		// Token: 0x06002454 RID: 9300 RVA: 0x0003D160 File Offset: 0x0003B360
		public static bool operator ==(BatchPackedCullingViewID lhs, BatchPackedCullingViewID rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x06002455 RID: 9301 RVA: 0x0003D17C File Offset: 0x0003B37C
		public static bool operator !=(BatchPackedCullingViewID lhs, BatchPackedCullingViewID rhs)
		{
			return !lhs.Equals(rhs);
		}

		// Token: 0x06002456 RID: 9302 RVA: 0x0003D199 File Offset: 0x0003B399
		public BatchPackedCullingViewID(int instanceID, int sliceIndex)
		{
			this.handle = ((ulong)instanceID | (ulong)((ulong)((long)sliceIndex) << 32));
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x0003D1AC File Offset: 0x0003B3AC
		public int GetInstanceID()
		{
			return (int)(this.handle & (ulong)-1);
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x0003D1C8 File Offset: 0x0003B3C8
		public int GetSliceIndex()
		{
			return (int)(this.handle >> 32);
		}

		// Token: 0x04000D55 RID: 3413
		internal ulong handle;
	}
}
