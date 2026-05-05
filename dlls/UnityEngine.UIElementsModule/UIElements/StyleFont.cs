using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000303 RID: 771
	public struct StyleFont : IStyleValue<Font>, IEquatable<StyleFont>
	{
		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x06001A64 RID: 6756 RVA: 0x00069018 File Offset: 0x00067218
		// (set) Token: 0x06001A65 RID: 6757 RVA: 0x0006903B File Offset: 0x0006723B
		public Font value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : null;
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x06001A66 RID: 6758 RVA: 0x0006904C File Offset: 0x0006724C
		// (set) Token: 0x06001A67 RID: 6759 RVA: 0x00069064 File Offset: 0x00067264
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

		// Token: 0x06001A68 RID: 6760 RVA: 0x0006906E File Offset: 0x0006726E
		public StyleFont(Font v)
		{
			this = new StyleFont(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001A69 RID: 6761 RVA: 0x0006907A File Offset: 0x0006727A
		public StyleFont(StyleKeyword keyword)
		{
			this = new StyleFont(null, keyword);
		}

		// Token: 0x06001A6A RID: 6762 RVA: 0x00069086 File Offset: 0x00067286
		internal StyleFont(Font v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001A6B RID: 6763 RVA: 0x00069098 File Offset: 0x00067298
		public static bool operator ==(StyleFont lhs, StyleFont rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001A6C RID: 6764 RVA: 0x000690CC File Offset: 0x000672CC
		public static bool operator !=(StyleFont lhs, StyleFont rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001A6D RID: 6765 RVA: 0x000690E8 File Offset: 0x000672E8
		public static implicit operator StyleFont(StyleKeyword keyword)
		{
			return new StyleFont(keyword);
		}

		// Token: 0x06001A6E RID: 6766 RVA: 0x00069100 File Offset: 0x00067300
		public static implicit operator StyleFont(Font v)
		{
			return new StyleFont(v);
		}

		// Token: 0x06001A6F RID: 6767 RVA: 0x00069118 File Offset: 0x00067318
		public bool Equals(StyleFont other)
		{
			return other == this;
		}

		// Token: 0x06001A70 RID: 6768 RVA: 0x00069138 File Offset: 0x00067338
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleFont)
			{
				StyleFont other = (StyleFont)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001A71 RID: 6769 RVA: 0x00069164 File Offset: 0x00067364
		public override int GetHashCode()
		{
			return ((this.m_Value != null) ? this.m_Value.GetHashCode() : 0) * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001A72 RID: 6770 RVA: 0x000691A0 File Offset: 0x000673A0
		public override string ToString()
		{
			return this.DebugString<Font>();
		}

		// Token: 0x04000AE8 RID: 2792
		private Font m_Value;

		// Token: 0x04000AE9 RID: 2793
		private StyleKeyword m_Keyword;
	}
}
