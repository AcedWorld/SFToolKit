using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200040B RID: 1035
	public struct RenderTargetBinding
	{
		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x060021DD RID: 8669 RVA: 0x0003882C File Offset: 0x00036A2C
		// (set) Token: 0x060021DE RID: 8670 RVA: 0x00038844 File Offset: 0x00036A44
		public RenderTargetIdentifier[] colorRenderTargets
		{
			get
			{
				return this.m_ColorRenderTargets;
			}
			set
			{
				this.m_ColorRenderTargets = value;
			}
		}

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x060021DF RID: 8671 RVA: 0x00038850 File Offset: 0x00036A50
		// (set) Token: 0x060021E0 RID: 8672 RVA: 0x00038868 File Offset: 0x00036A68
		public RenderTargetIdentifier depthRenderTarget
		{
			get
			{
				return this.m_DepthRenderTarget;
			}
			set
			{
				this.m_DepthRenderTarget = value;
			}
		}

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x060021E1 RID: 8673 RVA: 0x00038874 File Offset: 0x00036A74
		// (set) Token: 0x060021E2 RID: 8674 RVA: 0x0003888C File Offset: 0x00036A8C
		public RenderBufferLoadAction[] colorLoadActions
		{
			get
			{
				return this.m_ColorLoadActions;
			}
			set
			{
				this.m_ColorLoadActions = value;
			}
		}

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x060021E3 RID: 8675 RVA: 0x00038898 File Offset: 0x00036A98
		// (set) Token: 0x060021E4 RID: 8676 RVA: 0x000388B0 File Offset: 0x00036AB0
		public RenderBufferStoreAction[] colorStoreActions
		{
			get
			{
				return this.m_ColorStoreActions;
			}
			set
			{
				this.m_ColorStoreActions = value;
			}
		}

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x060021E5 RID: 8677 RVA: 0x000388BC File Offset: 0x00036ABC
		// (set) Token: 0x060021E6 RID: 8678 RVA: 0x000388D4 File Offset: 0x00036AD4
		public RenderBufferLoadAction depthLoadAction
		{
			get
			{
				return this.m_DepthLoadAction;
			}
			set
			{
				this.m_DepthLoadAction = value;
			}
		}

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x060021E7 RID: 8679 RVA: 0x000388E0 File Offset: 0x00036AE0
		// (set) Token: 0x060021E8 RID: 8680 RVA: 0x000388F8 File Offset: 0x00036AF8
		public RenderBufferStoreAction depthStoreAction
		{
			get
			{
				return this.m_DepthStoreAction;
			}
			set
			{
				this.m_DepthStoreAction = value;
			}
		}

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x060021E9 RID: 8681 RVA: 0x00038904 File Offset: 0x00036B04
		// (set) Token: 0x060021EA RID: 8682 RVA: 0x0003891C File Offset: 0x00036B1C
		public RenderTargetFlags flags
		{
			get
			{
				return this.m_Flags;
			}
			set
			{
				this.m_Flags = value;
			}
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x00038926 File Offset: 0x00036B26
		public RenderTargetBinding(RenderTargetIdentifier[] colorRenderTargets, RenderBufferLoadAction[] colorLoadActions, RenderBufferStoreAction[] colorStoreActions, RenderTargetIdentifier depthRenderTarget, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction)
		{
			this.m_ColorRenderTargets = colorRenderTargets;
			this.m_DepthRenderTarget = depthRenderTarget;
			this.m_ColorLoadActions = colorLoadActions;
			this.m_ColorStoreActions = colorStoreActions;
			this.m_DepthLoadAction = depthLoadAction;
			this.m_DepthStoreAction = depthStoreAction;
			this.m_Flags = RenderTargetFlags.None;
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x0003895D File Offset: 0x00036B5D
		public RenderTargetBinding(RenderTargetIdentifier colorRenderTarget, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RenderTargetIdentifier depthRenderTarget, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction)
		{
			this = new RenderTargetBinding(new RenderTargetIdentifier[]
			{
				colorRenderTarget
			}, new RenderBufferLoadAction[]
			{
				colorLoadAction
			}, new RenderBufferStoreAction[]
			{
				colorStoreAction
			}, depthRenderTarget, depthLoadAction, depthStoreAction);
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x00038990 File Offset: 0x00036B90
		public RenderTargetBinding(RenderTargetSetup setup)
		{
			this.m_ColorRenderTargets = new RenderTargetIdentifier[setup.color.Length];
			for (int i = 0; i < this.m_ColorRenderTargets.Length; i++)
			{
				this.m_ColorRenderTargets[i] = new RenderTargetIdentifier(setup.color[i], setup.mipLevel, setup.cubemapFace, setup.depthSlice);
			}
			this.m_DepthRenderTarget = setup.depth;
			this.m_ColorLoadActions = (RenderBufferLoadAction[])setup.colorLoad.Clone();
			this.m_ColorStoreActions = (RenderBufferStoreAction[])setup.colorStore.Clone();
			this.m_DepthLoadAction = setup.depthLoad;
			this.m_DepthStoreAction = setup.depthStore;
			this.m_Flags = RenderTargetFlags.None;
		}

		// Token: 0x04000C5A RID: 3162
		private RenderTargetIdentifier[] m_ColorRenderTargets;

		// Token: 0x04000C5B RID: 3163
		private RenderTargetIdentifier m_DepthRenderTarget;

		// Token: 0x04000C5C RID: 3164
		private RenderBufferLoadAction[] m_ColorLoadActions;

		// Token: 0x04000C5D RID: 3165
		private RenderBufferStoreAction[] m_ColorStoreActions;

		// Token: 0x04000C5E RID: 3166
		private RenderBufferLoadAction m_DepthLoadAction;

		// Token: 0x04000C5F RID: 3167
		private RenderBufferStoreAction m_DepthStoreAction;

		// Token: 0x04000C60 RID: 3168
		private RenderTargetFlags m_Flags;
	}
}
