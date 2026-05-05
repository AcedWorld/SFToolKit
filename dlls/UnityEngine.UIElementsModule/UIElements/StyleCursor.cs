using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002FE RID: 766
	public struct StyleCursor : IStyleValue<Cursor>, IEquatable<StyleCursor>
	{
		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x06001A22 RID: 6690 RVA: 0x00068808 File Offset: 0x00066A08
		// (set) Token: 0x06001A23 RID: 6691 RVA: 0x00068833 File Offset: 0x00066A33
		public Cursor value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : default(Cursor);
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x06001A24 RID: 6692 RVA: 0x00068844 File Offset: 0x00066A44
		// (set) Token: 0x06001A25 RID: 6693 RVA: 0x0006885C File Offset: 0x00066A5C
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

		// Token: 0x06001A26 RID: 6694 RVA: 0x00068866 File Offset: 0x00066A66
		public StyleCursor(Cursor v)
		{
			this = new StyleCursor(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001A27 RID: 6695 RVA: 0x00068874 File Offset: 0x00066A74
		public StyleCursor(StyleKeyword keyword)
		{
			this = new StyleCursor(default(Cursor), keyword);
		}

		// Token: 0x06001A28 RID: 6696 RVA: 0x00068893 File Offset: 0x00066A93
		internal StyleCursor(Cursor v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001A29 RID: 6697 RVA: 0x000688A4 File Offset: 0x00066AA4
		public static bool operator ==(StyleCursor lhs, StyleCursor rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001A2A RID: 6698 RVA: 0x000688D8 File Offset: 0x00066AD8
		public static bool operator !=(StyleCursor lhs, StyleCursor rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001A2B RID: 6699 RVA: 0x000688F4 File Offset: 0x00066AF4
		public static implicit operator StyleCursor(StyleKeyword keyword)
		{
			return new StyleCursor(keyword);
		}

		// Token: 0x06001A2C RID: 6700 RVA: 0x0006890C File Offset: 0x00066B0C
		public static implicit operator StyleCursor(Cursor v)
		{
			return new StyleCursor(v);
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x00068924 File Offset: 0x00066B24
		public bool Equals(StyleCursor other)
		{
			return other == this;
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x00068944 File Offset: 0x00066B44
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleCursor)
			{
				StyleCursor other = (StyleCursor)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x00068970 File Offset: 0x00066B70
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x000689A4 File Offset: 0x00066BA4
		public override string ToString()
		{
			return this.DebugString<Cursor>();
		}

		// Token: 0x04000ADD RID: 2781
		private Cursor m_Value;

		// Token: 0x04000ADE RID: 2782
		private StyleKeyword m_Keyword;
	}
}
