using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001CC RID: 460
	[UsedByNativeCode]
	[Serializable]
	public struct BoneWeight1 : IEquatable<BoneWeight1>
	{
		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06001205 RID: 4613 RVA: 0x000191D8 File Offset: 0x000173D8
		// (set) Token: 0x06001206 RID: 4614 RVA: 0x000191F0 File Offset: 0x000173F0
		public float weight
		{
			get
			{
				return this.m_Weight;
			}
			set
			{
				this.m_Weight = value;
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06001207 RID: 4615 RVA: 0x000191FC File Offset: 0x000173FC
		// (set) Token: 0x06001208 RID: 4616 RVA: 0x00019214 File Offset: 0x00017414
		public int boneIndex
		{
			get
			{
				return this.m_BoneIndex;
			}
			set
			{
				this.m_BoneIndex = value;
			}
		}

		// Token: 0x06001209 RID: 4617 RVA: 0x00019220 File Offset: 0x00017420
		public override bool Equals(object other)
		{
			return other is BoneWeight1 && this.Equals((BoneWeight1)other);
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x0001924C File Offset: 0x0001744C
		public bool Equals(BoneWeight1 other)
		{
			return this.boneIndex.Equals(other.boneIndex) && this.weight.Equals(other.weight);
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x00019290 File Offset: 0x00017490
		public override int GetHashCode()
		{
			return this.boneIndex.GetHashCode() ^ this.weight.GetHashCode();
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x000192C0 File Offset: 0x000174C0
		public static bool operator ==(BoneWeight1 lhs, BoneWeight1 rhs)
		{
			return lhs.boneIndex == rhs.boneIndex && lhs.weight == rhs.weight;
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x000192F8 File Offset: 0x000174F8
		public static bool operator !=(BoneWeight1 lhs, BoneWeight1 rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x0400064D RID: 1613
		[SerializeField]
		private float m_Weight;

		// Token: 0x0400064E RID: 1614
		[SerializeField]
		private int m_BoneIndex;
	}
}
