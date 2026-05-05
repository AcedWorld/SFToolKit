using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000469 RID: 1129
	public struct RenderQueueRange : IEquatable<RenderQueueRange>
	{
		// Token: 0x06002607 RID: 9735 RVA: 0x00041288 File Offset: 0x0003F488
		public RenderQueueRange(int lowerBound, int upperBound)
		{
			bool flag = lowerBound < 0 || lowerBound > 5000;
			if (flag)
			{
				throw new ArgumentOutOfRangeException("lowerBound", lowerBound, string.Format("The lower bound must be at least {0} and at most {1}.", 0, 5000));
			}
			bool flag2 = upperBound < 0 || upperBound > 5000;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException("upperBound", upperBound, string.Format("The upper bound must be at least {0} and at most {1}.", 0, 5000));
			}
			this.m_LowerBound = lowerBound;
			this.m_UpperBound = upperBound;
		}

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x06002608 RID: 9736 RVA: 0x00041320 File Offset: 0x0003F520
		public static RenderQueueRange all
		{
			get
			{
				return new RenderQueueRange
				{
					m_LowerBound = 0,
					m_UpperBound = 5000
				};
			}
		}

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x06002609 RID: 9737 RVA: 0x0004134C File Offset: 0x0003F54C
		public static RenderQueueRange opaque
		{
			get
			{
				return new RenderQueueRange
				{
					m_LowerBound = 0,
					m_UpperBound = 2500
				};
			}
		}

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x0600260A RID: 9738 RVA: 0x00041378 File Offset: 0x0003F578
		public static RenderQueueRange transparent
		{
			get
			{
				return new RenderQueueRange
				{
					m_LowerBound = 2501,
					m_UpperBound = 5000
				};
			}
		}

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x0600260B RID: 9739 RVA: 0x000413A8 File Offset: 0x0003F5A8
		// (set) Token: 0x0600260C RID: 9740 RVA: 0x000413C0 File Offset: 0x0003F5C0
		public int lowerBound
		{
			get
			{
				return this.m_LowerBound;
			}
			set
			{
				bool flag = value < 0 || value > 5000;
				if (flag)
				{
					throw new ArgumentOutOfRangeException(string.Format("The lower bound must be at least {0} and at most {1}.", 0, 5000));
				}
				this.m_LowerBound = value;
			}
		}

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x0600260D RID: 9741 RVA: 0x00041408 File Offset: 0x0003F608
		// (set) Token: 0x0600260E RID: 9742 RVA: 0x00041420 File Offset: 0x0003F620
		public int upperBound
		{
			get
			{
				return this.m_UpperBound;
			}
			set
			{
				bool flag = value < 0 || value > 5000;
				if (flag)
				{
					throw new ArgumentOutOfRangeException(string.Format("The upper bound must be at least {0} and at most {1}.", 0, 5000));
				}
				this.m_UpperBound = value;
			}
		}

		// Token: 0x0600260F RID: 9743 RVA: 0x00041468 File Offset: 0x0003F668
		public bool Equals(RenderQueueRange other)
		{
			return this.m_LowerBound == other.m_LowerBound && this.m_UpperBound == other.m_UpperBound;
		}

		// Token: 0x06002610 RID: 9744 RVA: 0x0004149C File Offset: 0x0003F69C
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is RenderQueueRange && this.Equals((RenderQueueRange)obj);
		}

		// Token: 0x06002611 RID: 9745 RVA: 0x000414D4 File Offset: 0x0003F6D4
		public override int GetHashCode()
		{
			return this.m_LowerBound * 397 ^ this.m_UpperBound;
		}

		// Token: 0x06002612 RID: 9746 RVA: 0x000414FC File Offset: 0x0003F6FC
		public static bool operator ==(RenderQueueRange left, RenderQueueRange right)
		{
			return left.Equals(right);
		}

		// Token: 0x06002613 RID: 9747 RVA: 0x00041518 File Offset: 0x0003F718
		public static bool operator !=(RenderQueueRange left, RenderQueueRange right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000E6E RID: 3694
		private int m_LowerBound;

		// Token: 0x04000E6F RID: 3695
		private int m_UpperBound;

		// Token: 0x04000E70 RID: 3696
		private const int k_MinimumBound = 0;

		// Token: 0x04000E71 RID: 3697
		public static readonly int minimumBound = 0;

		// Token: 0x04000E72 RID: 3698
		private const int k_MaximumBound = 5000;

		// Token: 0x04000E73 RID: 3699
		public static readonly int maximumBound = 5000;
	}
}
