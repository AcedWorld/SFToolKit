using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200045F RID: 1119
	public struct RasterState : IEquatable<RasterState>
	{
		// Token: 0x06002592 RID: 9618 RVA: 0x0004018D File Offset: 0x0003E38D
		public RasterState(CullMode cullingMode = CullMode.Back, int offsetUnits = 0, float offsetFactor = 0f, bool depthClip = true)
		{
			this.m_CullingMode = cullingMode;
			this.m_OffsetUnits = offsetUnits;
			this.m_OffsetFactor = offsetFactor;
			this.m_DepthClip = Convert.ToByte(depthClip);
			this.m_Conservative = Convert.ToByte(false);
			this.m_Padding1 = 0;
			this.m_Padding2 = 0;
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x06002593 RID: 9619 RVA: 0x000401CC File Offset: 0x0003E3CC
		// (set) Token: 0x06002594 RID: 9620 RVA: 0x000401E4 File Offset: 0x0003E3E4
		public CullMode cullingMode
		{
			get
			{
				return this.m_CullingMode;
			}
			set
			{
				this.m_CullingMode = value;
			}
		}

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x06002595 RID: 9621 RVA: 0x000401F0 File Offset: 0x0003E3F0
		// (set) Token: 0x06002596 RID: 9622 RVA: 0x0004020D File Offset: 0x0003E40D
		public bool depthClip
		{
			get
			{
				return Convert.ToBoolean(this.m_DepthClip);
			}
			set
			{
				this.m_DepthClip = Convert.ToByte(value);
			}
		}

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x06002597 RID: 9623 RVA: 0x0004021C File Offset: 0x0003E41C
		// (set) Token: 0x06002598 RID: 9624 RVA: 0x00040239 File Offset: 0x0003E439
		public bool conservative
		{
			get
			{
				return Convert.ToBoolean(this.m_Conservative);
			}
			set
			{
				this.m_Conservative = Convert.ToByte(value);
			}
		}

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x06002599 RID: 9625 RVA: 0x00040248 File Offset: 0x0003E448
		// (set) Token: 0x0600259A RID: 9626 RVA: 0x00040260 File Offset: 0x0003E460
		public int offsetUnits
		{
			get
			{
				return this.m_OffsetUnits;
			}
			set
			{
				this.m_OffsetUnits = value;
			}
		}

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x0600259B RID: 9627 RVA: 0x0004026C File Offset: 0x0003E46C
		// (set) Token: 0x0600259C RID: 9628 RVA: 0x00040284 File Offset: 0x0003E484
		public float offsetFactor
		{
			get
			{
				return this.m_OffsetFactor;
			}
			set
			{
				this.m_OffsetFactor = value;
			}
		}

		// Token: 0x0600259D RID: 9629 RVA: 0x00040290 File Offset: 0x0003E490
		public bool Equals(RasterState other)
		{
			return this.m_CullingMode == other.m_CullingMode && this.m_OffsetUnits == other.m_OffsetUnits && this.m_OffsetFactor.Equals(other.m_OffsetFactor) && this.m_DepthClip == other.m_DepthClip && this.m_Conservative == other.m_Conservative;
		}

		// Token: 0x0600259E RID: 9630 RVA: 0x000402F0 File Offset: 0x0003E4F0
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is RasterState && this.Equals((RasterState)obj);
		}

		// Token: 0x0600259F RID: 9631 RVA: 0x00040328 File Offset: 0x0003E528
		public override int GetHashCode()
		{
			int num = (int)this.m_CullingMode;
			num = (num * 397 ^ this.m_OffsetUnits);
			num = (num * 397 ^ this.m_OffsetFactor.GetHashCode());
			num = (num * 397 ^ this.m_DepthClip.GetHashCode());
			return num * 397 ^ this.m_Conservative.GetHashCode();
		}

		// Token: 0x060025A0 RID: 9632 RVA: 0x00040390 File Offset: 0x0003E590
		public static bool operator ==(RasterState left, RasterState right)
		{
			return left.Equals(right);
		}

		// Token: 0x060025A1 RID: 9633 RVA: 0x000403AC File Offset: 0x0003E5AC
		public static bool operator !=(RasterState left, RasterState right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000E3B RID: 3643
		public static readonly RasterState defaultValue = new RasterState(CullMode.Back, 0, 0f, true);

		// Token: 0x04000E3C RID: 3644
		private CullMode m_CullingMode;

		// Token: 0x04000E3D RID: 3645
		private int m_OffsetUnits;

		// Token: 0x04000E3E RID: 3646
		private float m_OffsetFactor;

		// Token: 0x04000E3F RID: 3647
		private byte m_DepthClip;

		// Token: 0x04000E40 RID: 3648
		private byte m_Conservative;

		// Token: 0x04000E41 RID: 3649
		private byte m_Padding1;

		// Token: 0x04000E42 RID: 3650
		private byte m_Padding2;
	}
}
