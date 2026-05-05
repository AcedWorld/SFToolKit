using System;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering
{
	// Token: 0x02000448 RID: 1096
	public struct AttachmentDescriptor : IEquatable<AttachmentDescriptor>
	{
		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x0600249E RID: 9374 RVA: 0x0003D62C File Offset: 0x0003B82C
		// (set) Token: 0x0600249F RID: 9375 RVA: 0x0003D644 File Offset: 0x0003B844
		public RenderBufferLoadAction loadAction
		{
			get
			{
				return this.m_LoadAction;
			}
			set
			{
				this.m_LoadAction = value;
			}
		}

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x060024A0 RID: 9376 RVA: 0x0003D650 File Offset: 0x0003B850
		// (set) Token: 0x060024A1 RID: 9377 RVA: 0x0003D668 File Offset: 0x0003B868
		public RenderBufferStoreAction storeAction
		{
			get
			{
				return this.m_StoreAction;
			}
			set
			{
				this.m_StoreAction = value;
			}
		}

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x060024A2 RID: 9378 RVA: 0x0003D674 File Offset: 0x0003B874
		// (set) Token: 0x060024A3 RID: 9379 RVA: 0x0003D68C File Offset: 0x0003B88C
		public GraphicsFormat graphicsFormat
		{
			get
			{
				return this.m_Format;
			}
			set
			{
				this.m_Format = value;
			}
		}

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x060024A4 RID: 9380 RVA: 0x0003D698 File Offset: 0x0003B898
		// (set) Token: 0x060024A5 RID: 9381 RVA: 0x0003D6DE File Offset: 0x0003B8DE
		public RenderTextureFormat format
		{
			get
			{
				bool flag = GraphicsFormatUtility.IsDepthStencilFormat(this.m_Format) && this.m_Format != GraphicsFormat.ShadowAuto;
				RenderTextureFormat result;
				if (flag)
				{
					result = RenderTextureFormat.Depth;
				}
				else
				{
					result = GraphicsFormatUtility.GetRenderTextureFormat(this.m_Format);
				}
				return result;
			}
			set
			{
				this.m_Format = GraphicsFormatUtility.GetGraphicsFormat(value, RenderTextureReadWrite.Default);
			}
		}

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x060024A6 RID: 9382 RVA: 0x0003D6F0 File Offset: 0x0003B8F0
		// (set) Token: 0x060024A7 RID: 9383 RVA: 0x0003D708 File Offset: 0x0003B908
		public RenderTargetIdentifier loadStoreTarget
		{
			get
			{
				return this.m_LoadStoreTarget;
			}
			set
			{
				this.m_LoadStoreTarget = value;
			}
		}

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x060024A8 RID: 9384 RVA: 0x0003D714 File Offset: 0x0003B914
		// (set) Token: 0x060024A9 RID: 9385 RVA: 0x0003D72C File Offset: 0x0003B92C
		public RenderTargetIdentifier resolveTarget
		{
			get
			{
				return this.m_ResolveTarget;
			}
			set
			{
				this.m_ResolveTarget = value;
			}
		}

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x060024AA RID: 9386 RVA: 0x0003D738 File Offset: 0x0003B938
		// (set) Token: 0x060024AB RID: 9387 RVA: 0x0003D750 File Offset: 0x0003B950
		public Color clearColor
		{
			get
			{
				return this.m_ClearColor;
			}
			set
			{
				this.m_ClearColor = value;
			}
		}

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x060024AC RID: 9388 RVA: 0x0003D75C File Offset: 0x0003B95C
		// (set) Token: 0x060024AD RID: 9389 RVA: 0x0003D774 File Offset: 0x0003B974
		public float clearDepth
		{
			get
			{
				return this.m_ClearDepth;
			}
			set
			{
				this.m_ClearDepth = value;
			}
		}

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x060024AE RID: 9390 RVA: 0x0003D780 File Offset: 0x0003B980
		// (set) Token: 0x060024AF RID: 9391 RVA: 0x0003D798 File Offset: 0x0003B998
		public uint clearStencil
		{
			get
			{
				return this.m_ClearStencil;
			}
			set
			{
				this.m_ClearStencil = value;
			}
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x0003D7A4 File Offset: 0x0003B9A4
		public void ConfigureTarget(RenderTargetIdentifier target, bool loadExistingContents, bool storeResults)
		{
			this.m_LoadStoreTarget = target;
			bool flag = loadExistingContents && this.m_LoadAction != RenderBufferLoadAction.Clear;
			if (flag)
			{
				this.m_LoadAction = RenderBufferLoadAction.Load;
			}
			if (storeResults)
			{
				bool flag2 = this.m_StoreAction == RenderBufferStoreAction.StoreAndResolve || this.m_StoreAction == RenderBufferStoreAction.Resolve;
				if (flag2)
				{
					this.m_StoreAction = RenderBufferStoreAction.StoreAndResolve;
				}
				else
				{
					this.m_StoreAction = RenderBufferStoreAction.Store;
				}
			}
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x0003D808 File Offset: 0x0003BA08
		public void ConfigureResolveTarget(RenderTargetIdentifier target)
		{
			this.m_ResolveTarget = target;
			bool flag = this.m_StoreAction == RenderBufferStoreAction.StoreAndResolve || this.m_StoreAction == RenderBufferStoreAction.Store;
			if (flag)
			{
				this.m_StoreAction = RenderBufferStoreAction.StoreAndResolve;
			}
			else
			{
				this.m_StoreAction = RenderBufferStoreAction.Resolve;
			}
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x0003D846 File Offset: 0x0003BA46
		public void ConfigureClear(Color clearColor, float clearDepth = 1f, uint clearStencil = 0U)
		{
			this.m_ClearColor = clearColor;
			this.m_ClearDepth = clearDepth;
			this.m_ClearStencil = clearStencil;
			this.m_LoadAction = RenderBufferLoadAction.Clear;
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x0003D868 File Offset: 0x0003BA68
		public AttachmentDescriptor(GraphicsFormat format)
		{
			this = default(AttachmentDescriptor);
			this.m_LoadAction = RenderBufferLoadAction.DontCare;
			this.m_StoreAction = RenderBufferStoreAction.DontCare;
			this.m_Format = format;
			this.m_LoadStoreTarget = new RenderTargetIdentifier(BuiltinRenderTextureType.None);
			this.m_ResolveTarget = new RenderTargetIdentifier(BuiltinRenderTextureType.None);
			this.m_ClearColor = new Color(0f, 0f, 0f, 0f);
			this.m_ClearDepth = 1f;
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x0003D8D4 File Offset: 0x0003BAD4
		public AttachmentDescriptor(RenderTextureFormat format)
		{
			this = new AttachmentDescriptor(GraphicsFormatUtility.GetGraphicsFormat(format, RenderTextureReadWrite.Default));
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x0003D8D4 File Offset: 0x0003BAD4
		public AttachmentDescriptor(RenderTextureFormat format, RenderTargetIdentifier target, bool loadExistingContents = false, bool storeResults = false, bool resolve = false)
		{
			this = new AttachmentDescriptor(GraphicsFormatUtility.GetGraphicsFormat(format, RenderTextureReadWrite.Default));
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x0003D8E8 File Offset: 0x0003BAE8
		public bool Equals(AttachmentDescriptor other)
		{
			return this.m_LoadAction == other.m_LoadAction && this.m_StoreAction == other.m_StoreAction && this.m_Format == other.m_Format && this.m_LoadStoreTarget.Equals(other.m_LoadStoreTarget) && this.m_ResolveTarget.Equals(other.m_ResolveTarget) && this.m_ClearColor.Equals(other.m_ClearColor) && this.m_ClearDepth.Equals(other.m_ClearDepth) && this.m_ClearStencil == other.m_ClearStencil;
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x0003D984 File Offset: 0x0003BB84
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is AttachmentDescriptor && this.Equals((AttachmentDescriptor)obj);
		}

		// Token: 0x060024B8 RID: 9400 RVA: 0x0003D9BC File Offset: 0x0003BBBC
		public override int GetHashCode()
		{
			int num = (int)this.m_LoadAction;
			num = (num * 397 ^ (int)this.m_StoreAction);
			num = (num * 397 ^ (int)this.m_Format);
			num = (num * 397 ^ this.m_LoadStoreTarget.GetHashCode());
			num = (num * 397 ^ this.m_ResolveTarget.GetHashCode());
			num = (num * 397 ^ this.m_ClearColor.GetHashCode());
			num = (num * 397 ^ this.m_ClearDepth.GetHashCode());
			return num * 397 ^ (int)this.m_ClearStencil;
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x0003DA68 File Offset: 0x0003BC68
		public static bool operator ==(AttachmentDescriptor left, AttachmentDescriptor right)
		{
			return left.Equals(right);
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x0003DA84 File Offset: 0x0003BC84
		public static bool operator !=(AttachmentDescriptor left, AttachmentDescriptor right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000D9B RID: 3483
		private RenderBufferLoadAction m_LoadAction;

		// Token: 0x04000D9C RID: 3484
		private RenderBufferStoreAction m_StoreAction;

		// Token: 0x04000D9D RID: 3485
		private GraphicsFormat m_Format;

		// Token: 0x04000D9E RID: 3486
		private RenderTargetIdentifier m_LoadStoreTarget;

		// Token: 0x04000D9F RID: 3487
		private RenderTargetIdentifier m_ResolveTarget;

		// Token: 0x04000DA0 RID: 3488
		private Color m_ClearColor;

		// Token: 0x04000DA1 RID: 3489
		private float m_ClearDepth;

		// Token: 0x04000DA2 RID: 3490
		private uint m_ClearStencil;
	}
}
