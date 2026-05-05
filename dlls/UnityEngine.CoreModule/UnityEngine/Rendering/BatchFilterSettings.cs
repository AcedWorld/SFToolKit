using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200043D RID: 1085
	public struct BatchFilterSettings
	{
		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x06002459 RID: 9305 RVA: 0x0003D1E4 File Offset: 0x0003B3E4
		// (set) Token: 0x0600245A RID: 9306 RVA: 0x0003D1EC File Offset: 0x0003B3EC
		public MotionVectorGenerationMode motionMode
		{
			get
			{
				return (MotionVectorGenerationMode)this.m_motionMode;
			}
			set
			{
				this.m_motionMode = (byte)value;
			}
		}

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x0600245B RID: 9307 RVA: 0x0003D1F6 File Offset: 0x0003B3F6
		// (set) Token: 0x0600245C RID: 9308 RVA: 0x0003D1FE File Offset: 0x0003B3FE
		public ShadowCastingMode shadowCastingMode
		{
			get
			{
				return (ShadowCastingMode)this.m_shadowMode;
			}
			set
			{
				this.m_shadowMode = (byte)value;
			}
		}

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x0600245D RID: 9309 RVA: 0x0003D208 File Offset: 0x0003B408
		// (set) Token: 0x0600245E RID: 9310 RVA: 0x0003D213 File Offset: 0x0003B413
		public bool receiveShadows
		{
			get
			{
				return this.m_receiveShadows > 0;
			}
			set
			{
				this.m_receiveShadows = (value ? 1 : 0);
			}
		}

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x0600245F RID: 9311 RVA: 0x0003D223 File Offset: 0x0003B423
		// (set) Token: 0x06002460 RID: 9312 RVA: 0x0003D22E File Offset: 0x0003B42E
		public bool staticShadowCaster
		{
			get
			{
				return this.m_staticShadowCaster > 0;
			}
			set
			{
				this.m_staticShadowCaster = (value ? 1 : 0);
			}
		}

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x06002461 RID: 9313 RVA: 0x0003D23E File Offset: 0x0003B43E
		// (set) Token: 0x06002462 RID: 9314 RVA: 0x0003D249 File Offset: 0x0003B449
		public bool allDepthSorted
		{
			get
			{
				return this.m_allDepthSorted > 0;
			}
			set
			{
				this.m_allDepthSorted = (value ? 1 : 0);
			}
		}

		// Token: 0x04000D5F RID: 3423
		public uint renderingLayerMask;

		// Token: 0x04000D60 RID: 3424
		public byte layer;

		// Token: 0x04000D61 RID: 3425
		private byte m_motionMode;

		// Token: 0x04000D62 RID: 3426
		private byte m_shadowMode;

		// Token: 0x04000D63 RID: 3427
		private byte m_receiveShadows;

		// Token: 0x04000D64 RID: 3428
		private byte m_staticShadowCaster;

		// Token: 0x04000D65 RID: 3429
		private byte m_allDepthSorted;
	}
}
