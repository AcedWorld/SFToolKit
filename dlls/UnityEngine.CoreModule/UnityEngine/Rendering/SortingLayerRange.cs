using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000476 RID: 1142
	public struct SortingLayerRange : IEquatable<SortingLayerRange>
	{
		// Token: 0x060026D8 RID: 9944 RVA: 0x00042B86 File Offset: 0x00040D86
		public SortingLayerRange(short lowerBound, short upperBound)
		{
			this.m_LowerBound = lowerBound;
			this.m_UpperBound = upperBound;
		}

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x060026D9 RID: 9945 RVA: 0x00042B98 File Offset: 0x00040D98
		// (set) Token: 0x060026DA RID: 9946 RVA: 0x00042BB0 File Offset: 0x00040DB0
		public short lowerBound
		{
			get
			{
				return this.m_LowerBound;
			}
			set
			{
				this.m_LowerBound = value;
			}
		}

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x060026DB RID: 9947 RVA: 0x00042BBC File Offset: 0x00040DBC
		// (set) Token: 0x060026DC RID: 9948 RVA: 0x00042BD4 File Offset: 0x00040DD4
		public short upperBound
		{
			get
			{
				return this.m_UpperBound;
			}
			set
			{
				this.m_UpperBound = value;
			}
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x060026DD RID: 9949 RVA: 0x00042BE0 File Offset: 0x00040DE0
		public static SortingLayerRange all
		{
			get
			{
				return new SortingLayerRange
				{
					m_LowerBound = short.MinValue,
					m_UpperBound = short.MaxValue
				};
			}
		}

		// Token: 0x060026DE RID: 9950 RVA: 0x00042C10 File Offset: 0x00040E10
		public bool Equals(SortingLayerRange other)
		{
			return this.m_LowerBound == other.m_LowerBound && this.m_UpperBound == other.m_UpperBound;
		}

		// Token: 0x060026DF RID: 9951 RVA: 0x00042C44 File Offset: 0x00040E44
		public override bool Equals(object obj)
		{
			bool flag = !(obj is SortingLayerRange);
			return !flag && this.Equals((SortingLayerRange)obj);
		}

		// Token: 0x060026E0 RID: 9952 RVA: 0x00042C78 File Offset: 0x00040E78
		public static bool operator !=(SortingLayerRange lhs, SortingLayerRange rhs)
		{
			return !lhs.Equals(rhs);
		}

		// Token: 0x060026E1 RID: 9953 RVA: 0x00042C98 File Offset: 0x00040E98
		public static bool operator ==(SortingLayerRange lhs, SortingLayerRange rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x060026E2 RID: 9954 RVA: 0x00042CB4 File Offset: 0x00040EB4
		public override int GetHashCode()
		{
			return (int)this.m_UpperBound << 16 | ((int)this.m_LowerBound & 65535);
		}

		// Token: 0x04000EAD RID: 3757
		private short m_LowerBound;

		// Token: 0x04000EAE RID: 3758
		private short m_UpperBound;
	}
}
