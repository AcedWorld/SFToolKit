using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200046A RID: 1130
	public struct RenderStateBlock : IEquatable<RenderStateBlock>
	{
		// Token: 0x06002615 RID: 9749 RVA: 0x00041547 File Offset: 0x0003F747
		public RenderStateBlock(RenderStateMask mask)
		{
			this.m_BlendState = BlendState.defaultValue;
			this.m_RasterState = RasterState.defaultValue;
			this.m_DepthState = DepthState.defaultValue;
			this.m_StencilState = StencilState.defaultValue;
			this.m_StencilReference = 0;
			this.m_Mask = mask;
		}

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x06002616 RID: 9750 RVA: 0x00041584 File Offset: 0x0003F784
		// (set) Token: 0x06002617 RID: 9751 RVA: 0x0004159C File Offset: 0x0003F79C
		public BlendState blendState
		{
			get
			{
				return this.m_BlendState;
			}
			set
			{
				this.m_BlendState = value;
			}
		}

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x06002618 RID: 9752 RVA: 0x000415A8 File Offset: 0x0003F7A8
		// (set) Token: 0x06002619 RID: 9753 RVA: 0x000415C0 File Offset: 0x0003F7C0
		public RasterState rasterState
		{
			get
			{
				return this.m_RasterState;
			}
			set
			{
				this.m_RasterState = value;
			}
		}

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x0600261A RID: 9754 RVA: 0x000415CC File Offset: 0x0003F7CC
		// (set) Token: 0x0600261B RID: 9755 RVA: 0x000415E4 File Offset: 0x0003F7E4
		public DepthState depthState
		{
			get
			{
				return this.m_DepthState;
			}
			set
			{
				this.m_DepthState = value;
			}
		}

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x0600261C RID: 9756 RVA: 0x000415F0 File Offset: 0x0003F7F0
		// (set) Token: 0x0600261D RID: 9757 RVA: 0x00041608 File Offset: 0x0003F808
		public StencilState stencilState
		{
			get
			{
				return this.m_StencilState;
			}
			set
			{
				this.m_StencilState = value;
			}
		}

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x0600261E RID: 9758 RVA: 0x00041614 File Offset: 0x0003F814
		// (set) Token: 0x0600261F RID: 9759 RVA: 0x0004162C File Offset: 0x0003F82C
		public int stencilReference
		{
			get
			{
				return this.m_StencilReference;
			}
			set
			{
				this.m_StencilReference = value;
			}
		}

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x06002620 RID: 9760 RVA: 0x00041638 File Offset: 0x0003F838
		// (set) Token: 0x06002621 RID: 9761 RVA: 0x00041650 File Offset: 0x0003F850
		public RenderStateMask mask
		{
			get
			{
				return this.m_Mask;
			}
			set
			{
				this.m_Mask = value;
			}
		}

		// Token: 0x06002622 RID: 9762 RVA: 0x0004165C File Offset: 0x0003F85C
		public bool Equals(RenderStateBlock other)
		{
			return this.m_BlendState.Equals(other.m_BlendState) && this.m_RasterState.Equals(other.m_RasterState) && this.m_DepthState.Equals(other.m_DepthState) && this.m_StencilState.Equals(other.m_StencilState) && this.m_StencilReference == other.m_StencilReference && this.m_Mask == other.m_Mask;
		}

		// Token: 0x06002623 RID: 9763 RVA: 0x000416DC File Offset: 0x0003F8DC
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is RenderStateBlock && this.Equals((RenderStateBlock)obj);
		}

		// Token: 0x06002624 RID: 9764 RVA: 0x00041714 File Offset: 0x0003F914
		public override int GetHashCode()
		{
			int num = this.m_BlendState.GetHashCode();
			num = (num * 397 ^ this.m_RasterState.GetHashCode());
			num = (num * 397 ^ this.m_DepthState.GetHashCode());
			num = (num * 397 ^ this.m_StencilState.GetHashCode());
			num = (num * 397 ^ this.m_StencilReference);
			return num * 397 ^ (int)this.m_Mask;
		}

		// Token: 0x06002625 RID: 9765 RVA: 0x000417A8 File Offset: 0x0003F9A8
		public static bool operator ==(RenderStateBlock left, RenderStateBlock right)
		{
			return left.Equals(right);
		}

		// Token: 0x06002626 RID: 9766 RVA: 0x000417C4 File Offset: 0x0003F9C4
		public static bool operator !=(RenderStateBlock left, RenderStateBlock right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000E74 RID: 3700
		private BlendState m_BlendState;

		// Token: 0x04000E75 RID: 3701
		private RasterState m_RasterState;

		// Token: 0x04000E76 RID: 3702
		private DepthState m_DepthState;

		// Token: 0x04000E77 RID: 3703
		private StencilState m_StencilState;

		// Token: 0x04000E78 RID: 3704
		private int m_StencilReference;

		// Token: 0x04000E79 RID: 3705
		private RenderStateMask m_Mask;
	}
}
