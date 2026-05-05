using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000449 RID: 1097
	public struct BlendState : IEquatable<BlendState>
	{
		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x060024BB RID: 9403 RVA: 0x0003DAA4 File Offset: 0x0003BCA4
		public static BlendState defaultValue
		{
			get
			{
				return new BlendState(false, false);
			}
		}

		// Token: 0x060024BC RID: 9404 RVA: 0x0003DAC0 File Offset: 0x0003BCC0
		public BlendState(bool separateMRTBlend = false, bool alphaToMask = false)
		{
			this.m_BlendState0 = RenderTargetBlendState.defaultValue;
			this.m_BlendState1 = RenderTargetBlendState.defaultValue;
			this.m_BlendState2 = RenderTargetBlendState.defaultValue;
			this.m_BlendState3 = RenderTargetBlendState.defaultValue;
			this.m_BlendState4 = RenderTargetBlendState.defaultValue;
			this.m_BlendState5 = RenderTargetBlendState.defaultValue;
			this.m_BlendState6 = RenderTargetBlendState.defaultValue;
			this.m_BlendState7 = RenderTargetBlendState.defaultValue;
			this.m_SeparateMRTBlendStates = Convert.ToByte(separateMRTBlend);
			this.m_AlphaToMask = Convert.ToByte(alphaToMask);
			this.m_Padding = 0;
		}

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x060024BD RID: 9405 RVA: 0x0003DB48 File Offset: 0x0003BD48
		// (set) Token: 0x060024BE RID: 9406 RVA: 0x0003DB65 File Offset: 0x0003BD65
		public bool separateMRTBlendStates
		{
			get
			{
				return Convert.ToBoolean(this.m_SeparateMRTBlendStates);
			}
			set
			{
				this.m_SeparateMRTBlendStates = Convert.ToByte(value);
			}
		}

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x060024BF RID: 9407 RVA: 0x0003DB74 File Offset: 0x0003BD74
		// (set) Token: 0x060024C0 RID: 9408 RVA: 0x0003DB91 File Offset: 0x0003BD91
		public bool alphaToMask
		{
			get
			{
				return Convert.ToBoolean(this.m_AlphaToMask);
			}
			set
			{
				this.m_AlphaToMask = Convert.ToByte(value);
			}
		}

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x060024C1 RID: 9409 RVA: 0x0003DBA0 File Offset: 0x0003BDA0
		// (set) Token: 0x060024C2 RID: 9410 RVA: 0x0003DBB8 File Offset: 0x0003BDB8
		public RenderTargetBlendState blendState0
		{
			get
			{
				return this.m_BlendState0;
			}
			set
			{
				this.m_BlendState0 = value;
			}
		}

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x060024C3 RID: 9411 RVA: 0x0003DBC4 File Offset: 0x0003BDC4
		// (set) Token: 0x060024C4 RID: 9412 RVA: 0x0003DBDC File Offset: 0x0003BDDC
		public RenderTargetBlendState blendState1
		{
			get
			{
				return this.m_BlendState1;
			}
			set
			{
				this.m_BlendState1 = value;
			}
		}

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x060024C5 RID: 9413 RVA: 0x0003DBE8 File Offset: 0x0003BDE8
		// (set) Token: 0x060024C6 RID: 9414 RVA: 0x0003DC00 File Offset: 0x0003BE00
		public RenderTargetBlendState blendState2
		{
			get
			{
				return this.m_BlendState2;
			}
			set
			{
				this.m_BlendState2 = value;
			}
		}

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x060024C7 RID: 9415 RVA: 0x0003DC0C File Offset: 0x0003BE0C
		// (set) Token: 0x060024C8 RID: 9416 RVA: 0x0003DC24 File Offset: 0x0003BE24
		public RenderTargetBlendState blendState3
		{
			get
			{
				return this.m_BlendState3;
			}
			set
			{
				this.m_BlendState3 = value;
			}
		}

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x060024C9 RID: 9417 RVA: 0x0003DC30 File Offset: 0x0003BE30
		// (set) Token: 0x060024CA RID: 9418 RVA: 0x0003DC48 File Offset: 0x0003BE48
		public RenderTargetBlendState blendState4
		{
			get
			{
				return this.m_BlendState4;
			}
			set
			{
				this.m_BlendState4 = value;
			}
		}

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x060024CB RID: 9419 RVA: 0x0003DC54 File Offset: 0x0003BE54
		// (set) Token: 0x060024CC RID: 9420 RVA: 0x0003DC6C File Offset: 0x0003BE6C
		public RenderTargetBlendState blendState5
		{
			get
			{
				return this.m_BlendState5;
			}
			set
			{
				this.m_BlendState5 = value;
			}
		}

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x060024CD RID: 9421 RVA: 0x0003DC78 File Offset: 0x0003BE78
		// (set) Token: 0x060024CE RID: 9422 RVA: 0x0003DC90 File Offset: 0x0003BE90
		public RenderTargetBlendState blendState6
		{
			get
			{
				return this.m_BlendState6;
			}
			set
			{
				this.m_BlendState6 = value;
			}
		}

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x060024CF RID: 9423 RVA: 0x0003DC9C File Offset: 0x0003BE9C
		// (set) Token: 0x060024D0 RID: 9424 RVA: 0x0003DCB4 File Offset: 0x0003BEB4
		public RenderTargetBlendState blendState7
		{
			get
			{
				return this.m_BlendState7;
			}
			set
			{
				this.m_BlendState7 = value;
			}
		}

		// Token: 0x060024D1 RID: 9425 RVA: 0x0003DCC0 File Offset: 0x0003BEC0
		public bool Equals(BlendState other)
		{
			return this.m_BlendState0.Equals(other.m_BlendState0) && this.m_BlendState1.Equals(other.m_BlendState1) && this.m_BlendState2.Equals(other.m_BlendState2) && this.m_BlendState3.Equals(other.m_BlendState3) && this.m_BlendState4.Equals(other.m_BlendState4) && this.m_BlendState5.Equals(other.m_BlendState5) && this.m_BlendState6.Equals(other.m_BlendState6) && this.m_BlendState7.Equals(other.m_BlendState7) && this.m_SeparateMRTBlendStates == other.m_SeparateMRTBlendStates && this.m_AlphaToMask == other.m_AlphaToMask;
		}

		// Token: 0x060024D2 RID: 9426 RVA: 0x0003DD90 File Offset: 0x0003BF90
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is BlendState && this.Equals((BlendState)obj);
		}

		// Token: 0x060024D3 RID: 9427 RVA: 0x0003DDC8 File Offset: 0x0003BFC8
		public override int GetHashCode()
		{
			int num = this.m_BlendState0.GetHashCode();
			num = (num * 397 ^ this.m_BlendState1.GetHashCode());
			num = (num * 397 ^ this.m_BlendState2.GetHashCode());
			num = (num * 397 ^ this.m_BlendState3.GetHashCode());
			num = (num * 397 ^ this.m_BlendState4.GetHashCode());
			num = (num * 397 ^ this.m_BlendState5.GetHashCode());
			num = (num * 397 ^ this.m_BlendState6.GetHashCode());
			num = (num * 397 ^ this.m_BlendState7.GetHashCode());
			num = (num * 397 ^ this.m_SeparateMRTBlendStates.GetHashCode());
			return num * 397 ^ this.m_AlphaToMask.GetHashCode();
		}

		// Token: 0x060024D4 RID: 9428 RVA: 0x0003DECC File Offset: 0x0003C0CC
		public static bool operator ==(BlendState left, BlendState right)
		{
			return left.Equals(right);
		}

		// Token: 0x060024D5 RID: 9429 RVA: 0x0003DEE8 File Offset: 0x0003C0E8
		public static bool operator !=(BlendState left, BlendState right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000DA3 RID: 3491
		private RenderTargetBlendState m_BlendState0;

		// Token: 0x04000DA4 RID: 3492
		private RenderTargetBlendState m_BlendState1;

		// Token: 0x04000DA5 RID: 3493
		private RenderTargetBlendState m_BlendState2;

		// Token: 0x04000DA6 RID: 3494
		private RenderTargetBlendState m_BlendState3;

		// Token: 0x04000DA7 RID: 3495
		private RenderTargetBlendState m_BlendState4;

		// Token: 0x04000DA8 RID: 3496
		private RenderTargetBlendState m_BlendState5;

		// Token: 0x04000DA9 RID: 3497
		private RenderTargetBlendState m_BlendState6;

		// Token: 0x04000DAA RID: 3498
		private RenderTargetBlendState m_BlendState7;

		// Token: 0x04000DAB RID: 3499
		private byte m_SeparateMRTBlendStates;

		// Token: 0x04000DAC RID: 3500
		private byte m_AlphaToMask;

		// Token: 0x04000DAD RID: 3501
		private short m_Padding;
	}
}
