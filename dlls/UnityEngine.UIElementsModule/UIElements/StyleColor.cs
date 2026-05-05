using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002FD RID: 765
	public struct StyleColor : IStyleValue<Color>, IEquatable<StyleColor>
	{
		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x06001A11 RID: 6673 RVA: 0x0006861C File Offset: 0x0006681C
		// (set) Token: 0x06001A12 RID: 6674 RVA: 0x00068643 File Offset: 0x00066843
		public Color value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : Color.clear;
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x06001A13 RID: 6675 RVA: 0x00068654 File Offset: 0x00066854
		// (set) Token: 0x06001A14 RID: 6676 RVA: 0x0006866C File Offset: 0x0006686C
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

		// Token: 0x06001A15 RID: 6677 RVA: 0x00068676 File Offset: 0x00066876
		public StyleColor(Color v)
		{
			this = new StyleColor(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001A16 RID: 6678 RVA: 0x00068682 File Offset: 0x00066882
		public StyleColor(StyleKeyword keyword)
		{
			this = new StyleColor(Color.clear, keyword);
		}

		// Token: 0x06001A17 RID: 6679 RVA: 0x00068692 File Offset: 0x00066892
		internal StyleColor(Color v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001A18 RID: 6680 RVA: 0x000686A4 File Offset: 0x000668A4
		public static bool operator ==(StyleColor lhs, StyleColor rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001A19 RID: 6681 RVA: 0x000686D8 File Offset: 0x000668D8
		public static bool operator !=(StyleColor lhs, StyleColor rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001A1A RID: 6682 RVA: 0x000686F4 File Offset: 0x000668F4
		public static bool operator ==(StyleColor lhs, Color rhs)
		{
			StyleColor rhs2 = new StyleColor(rhs);
			return lhs == rhs2;
		}

		// Token: 0x06001A1B RID: 6683 RVA: 0x00068718 File Offset: 0x00066918
		public static bool operator !=(StyleColor lhs, Color rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001A1C RID: 6684 RVA: 0x00068734 File Offset: 0x00066934
		public static implicit operator StyleColor(StyleKeyword keyword)
		{
			return new StyleColor(keyword);
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x0006874C File Offset: 0x0006694C
		public static implicit operator StyleColor(Color v)
		{
			return new StyleColor(v);
		}

		// Token: 0x06001A1E RID: 6686 RVA: 0x00068764 File Offset: 0x00066964
		public bool Equals(StyleColor other)
		{
			return other == this;
		}

		// Token: 0x06001A1F RID: 6687 RVA: 0x00068784 File Offset: 0x00066984
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleColor)
			{
				StyleColor other = (StyleColor)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x000687B0 File Offset: 0x000669B0
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001A21 RID: 6689 RVA: 0x000687E4 File Offset: 0x000669E4
		public override string ToString()
		{
			return this.DebugString<Color>();
		}

		// Token: 0x04000ADB RID: 2779
		private Color m_Value;

		// Token: 0x04000ADC RID: 2780
		private StyleKeyword m_Keyword;
	}
}
