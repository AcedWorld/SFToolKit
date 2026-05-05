using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002FC RID: 764
	public struct StyleBackgroundSize : IStyleValue<BackgroundSize>, IEquatable<StyleBackgroundSize>
	{
		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x06001A02 RID: 6658 RVA: 0x0006845C File Offset: 0x0006665C
		// (set) Token: 0x06001A03 RID: 6659 RVA: 0x00068487 File Offset: 0x00066687
		public BackgroundSize value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : default(BackgroundSize);
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x06001A04 RID: 6660 RVA: 0x00068498 File Offset: 0x00066698
		// (set) Token: 0x06001A05 RID: 6661 RVA: 0x000684B0 File Offset: 0x000666B0
		public StyleKeyword keyword
		{
			get
			{
				return this.m_Keyword;
			}
			set
			{
				this.m_Keyword = value;
			}
		}

		// Token: 0x06001A06 RID: 6662 RVA: 0x000684BA File Offset: 0x000666BA
		public StyleBackgroundSize(BackgroundSize v)
		{
			this = new StyleBackgroundSize(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001A07 RID: 6663 RVA: 0x000684C8 File Offset: 0x000666C8
		public StyleBackgroundSize(StyleKeyword keyword)
		{
			this = new StyleBackgroundSize(default(BackgroundSize), keyword);
		}

		// Token: 0x06001A08 RID: 6664 RVA: 0x000684E7 File Offset: 0x000666E7
		internal StyleBackgroundSize(BackgroundSize v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001A09 RID: 6665 RVA: 0x000684F8 File Offset: 0x000666F8
		public static bool operator ==(StyleBackgroundSize lhs, StyleBackgroundSize rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x0006852C File Offset: 0x0006672C
		public static bool operator !=(StyleBackgroundSize lhs, StyleBackgroundSize rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001A0B RID: 6667 RVA: 0x00068548 File Offset: 0x00066748
		public static implicit operator StyleBackgroundSize(StyleKeyword keyword)
		{
			return new StyleBackgroundSize(keyword);
		}

		// Token: 0x06001A0C RID: 6668 RVA: 0x00068560 File Offset: 0x00066760
		public static implicit operator StyleBackgroundSize(BackgroundSize v)
		{
			return new StyleBackgroundSize(v);
		}

		// Token: 0x06001A0D RID: 6669 RVA: 0x00068578 File Offset: 0x00066778
		public bool Equals(StyleBackgroundSize other)
		{
			return other == this;
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x00068598 File Offset: 0x00066798
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleBackgroundSize)
			{
				StyleBackgroundSize other = (StyleBackgroundSize)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x000685C4 File Offset: 0x000667C4
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x000685F8 File Offset: 0x000667F8
		public override string ToString()
		{
			return this.DebugString<BackgroundSize>();
		}

		// Token: 0x04000AD9 RID: 2777
		private BackgroundSize m_Value;

		// Token: 0x04000ADA RID: 2778
		private StyleKeyword m_Keyword;
	}
}
