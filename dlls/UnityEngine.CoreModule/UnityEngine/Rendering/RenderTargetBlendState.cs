using System;

namespace UnityEngine.Rendering
{
	// Token: 0x0200046C RID: 1132
	public struct RenderTargetBlendState : IEquatable<RenderTargetBlendState>
	{
		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x06002627 RID: 9767 RVA: 0x000417E4 File Offset: 0x0003F9E4
		public static RenderTargetBlendState defaultValue
		{
			get
			{
				return new RenderTargetBlendState(ColorWriteMask.All, BlendMode.One, BlendMode.Zero, BlendMode.One, BlendMode.Zero, BlendOp.Add, BlendOp.Add);
			}
		}

		// Token: 0x06002628 RID: 9768 RVA: 0x00041804 File Offset: 0x0003FA04
		public RenderTargetBlendState(ColorWriteMask writeMask = ColorWriteMask.All, BlendMode sourceColorBlendMode = BlendMode.One, BlendMode destinationColorBlendMode = BlendMode.Zero, BlendMode sourceAlphaBlendMode = BlendMode.One, BlendMode destinationAlphaBlendMode = BlendMode.Zero, BlendOp colorBlendOperation = BlendOp.Add, BlendOp alphaBlendOperation = BlendOp.Add)
		{
			this.m_WriteMask = (byte)writeMask;
			this.m_SourceColorBlendMode = (byte)sourceColorBlendMode;
			this.m_DestinationColorBlendMode = (byte)destinationColorBlendMode;
			this.m_SourceAlphaBlendMode = (byte)sourceAlphaBlendMode;
			this.m_DestinationAlphaBlendMode = (byte)destinationAlphaBlendMode;
			this.m_ColorBlendOperation = (byte)colorBlendOperation;
			this.m_AlphaBlendOperation = (byte)alphaBlendOperation;
			this.m_Padding = 0;
		}

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x06002629 RID: 9769 RVA: 0x00041858 File Offset: 0x0003FA58
		// (set) Token: 0x0600262A RID: 9770 RVA: 0x00041870 File Offset: 0x0003FA70
		public ColorWriteMask writeMask
		{
			get
			{
				return (ColorWriteMask)this.m_WriteMask;
			}
			set
			{
				this.m_WriteMask = (byte)value;
			}
		}

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x0600262B RID: 9771 RVA: 0x0004187C File Offset: 0x0003FA7C
		// (set) Token: 0x0600262C RID: 9772 RVA: 0x00041894 File Offset: 0x0003FA94
		public BlendMode sourceColorBlendMode
		{
			get
			{
				return (BlendMode)this.m_SourceColorBlendMode;
			}
			set
			{
				this.m_SourceColorBlendMode = (byte)value;
			}
		}

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x0600262D RID: 9773 RVA: 0x000418A0 File Offset: 0x0003FAA0
		// (set) Token: 0x0600262E RID: 9774 RVA: 0x000418B8 File Offset: 0x0003FAB8
		public BlendMode destinationColorBlendMode
		{
			get
			{
				return (BlendMode)this.m_DestinationColorBlendMode;
			}
			set
			{
				this.m_DestinationColorBlendMode = (byte)value;
			}
		}

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x0600262F RID: 9775 RVA: 0x000418C4 File Offset: 0x0003FAC4
		// (set) Token: 0x06002630 RID: 9776 RVA: 0x000418DC File Offset: 0x0003FADC
		public BlendMode sourceAlphaBlendMode
		{
			get
			{
				return (BlendMode)this.m_SourceAlphaBlendMode;
			}
			set
			{
				this.m_SourceAlphaBlendMode = (byte)value;
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x06002631 RID: 9777 RVA: 0x000418E8 File Offset: 0x0003FAE8
		// (set) Token: 0x06002632 RID: 9778 RVA: 0x00041900 File Offset: 0x0003FB00
		public BlendMode destinationAlphaBlendMode
		{
			get
			{
				return (BlendMode)this.m_DestinationAlphaBlendMode;
			}
			set
			{
				this.m_DestinationAlphaBlendMode = (byte)value;
			}
		}

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x06002633 RID: 9779 RVA: 0x0004190C File Offset: 0x0003FB0C
		// (set) Token: 0x06002634 RID: 9780 RVA: 0x00041924 File Offset: 0x0003FB24
		public BlendOp colorBlendOperation
		{
			get
			{
				return (BlendOp)this.m_ColorBlendOperation;
			}
			set
			{
				this.m_ColorBlendOperation = (byte)value;
			}
		}

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x06002635 RID: 9781 RVA: 0x00041930 File Offset: 0x0003FB30
		// (set) Token: 0x06002636 RID: 9782 RVA: 0x00041948 File Offset: 0x0003FB48
		public BlendOp alphaBlendOperation
		{
			get
			{
				return (BlendOp)this.m_AlphaBlendOperation;
			}
			set
			{
				this.m_AlphaBlendOperation = (byte)value;
			}
		}

		// Token: 0x06002637 RID: 9783 RVA: 0x00041954 File Offset: 0x0003FB54
		public bool Equals(RenderTargetBlendState other)
		{
			return this.m_WriteMask == other.m_WriteMask && this.m_SourceColorBlendMode == other.m_SourceColorBlendMode && this.m_DestinationColorBlendMode == other.m_DestinationColorBlendMode && this.m_SourceAlphaBlendMode == other.m_SourceAlphaBlendMode && this.m_DestinationAlphaBlendMode == other.m_DestinationAlphaBlendMode && this.m_ColorBlendOperation == other.m_ColorBlendOperation && this.m_AlphaBlendOperation == other.m_AlphaBlendOperation;
		}

		// Token: 0x06002638 RID: 9784 RVA: 0x000419CC File Offset: 0x0003FBCC
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is RenderTargetBlendState && this.Equals((RenderTargetBlendState)obj);
		}

		// Token: 0x06002639 RID: 9785 RVA: 0x00041A04 File Offset: 0x0003FC04
		public override int GetHashCode()
		{
			int num = this.m_WriteMask.GetHashCode();
			num = (num * 397 ^ this.m_SourceColorBlendMode.GetHashCode());
			num = (num * 397 ^ this.m_DestinationColorBlendMode.GetHashCode());
			num = (num * 397 ^ this.m_SourceAlphaBlendMode.GetHashCode());
			num = (num * 397 ^ this.m_DestinationAlphaBlendMode.GetHashCode());
			num = (num * 397 ^ this.m_ColorBlendOperation.GetHashCode());
			return num * 397 ^ this.m_AlphaBlendOperation.GetHashCode();
		}

		// Token: 0x0600263A RID: 9786 RVA: 0x00041A9C File Offset: 0x0003FC9C
		public static bool operator ==(RenderTargetBlendState left, RenderTargetBlendState right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600263B RID: 9787 RVA: 0x00041AB8 File Offset: 0x0003FCB8
		public static bool operator !=(RenderTargetBlendState left, RenderTargetBlendState right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000E81 RID: 3713
		private byte m_WriteMask;

		// Token: 0x04000E82 RID: 3714
		private byte m_SourceColorBlendMode;

		// Token: 0x04000E83 RID: 3715
		private byte m_DestinationColorBlendMode;

		// Token: 0x04000E84 RID: 3716
		private byte m_SourceAlphaBlendMode;

		// Token: 0x04000E85 RID: 3717
		private byte m_DestinationAlphaBlendMode;

		// Token: 0x04000E86 RID: 3718
		private byte m_ColorBlendOperation;

		// Token: 0x04000E87 RID: 3719
		private byte m_AlphaBlendOperation;

		// Token: 0x04000E88 RID: 3720
		private byte m_Padding;
	}
}
