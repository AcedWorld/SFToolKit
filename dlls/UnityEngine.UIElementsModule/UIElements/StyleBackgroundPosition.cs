using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002FA RID: 762
	public struct StyleBackgroundPosition : IStyleValue<BackgroundPosition>, IEquatable<StyleBackgroundPosition>
	{
		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x060019E4 RID: 6628 RVA: 0x000680DC File Offset: 0x000662DC
		// (set) Token: 0x060019E5 RID: 6629 RVA: 0x00068107 File Offset: 0x00066307
		public BackgroundPosition value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : default(BackgroundPosition);
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x060019E6 RID: 6630 RVA: 0x00068118 File Offset: 0x00066318
		// (set) Token: 0x060019E7 RID: 6631 RVA: 0x00068130 File Offset: 0x00066330
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

		// Token: 0x060019E8 RID: 6632 RVA: 0x0006813A File Offset: 0x0006633A
		public StyleBackgroundPosition(BackgroundPosition v)
		{
			this = new StyleBackgroundPosition(v, StyleKeyword.Undefined);
		}

		// Token: 0x060019E9 RID: 6633 RVA: 0x00068148 File Offset: 0x00066348
		public StyleBackgroundPosition(StyleKeyword keyword)
		{
			this = new StyleBackgroundPosition(default(BackgroundPosition), keyword);
		}

		// Token: 0x060019EA RID: 6634 RVA: 0x00068167 File Offset: 0x00066367
		internal StyleBackgroundPosition(BackgroundPosition v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x060019EB RID: 6635 RVA: 0x00068178 File Offset: 0x00066378
		public static bool operator ==(StyleBackgroundPosition lhs, StyleBackgroundPosition rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x000681AC File Offset: 0x000663AC
		public static bool operator !=(StyleBackgroundPosition lhs, StyleBackgroundPosition rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x000681C8 File Offset: 0x000663C8
		public static implicit operator StyleBackgroundPosition(StyleKeyword keyword)
		{
			return new StyleBackgroundPosition(keyword);
		}

		// Token: 0x060019EE RID: 6638 RVA: 0x000681E0 File Offset: 0x000663E0
		public static implicit operator StyleBackgroundPosition(BackgroundPosition v)
		{
			return new StyleBackgroundPosition(v);
		}

		// Token: 0x060019EF RID: 6639 RVA: 0x000681F8 File Offset: 0x000663F8
		public bool Equals(StyleBackgroundPosition other)
		{
			return other == this;
		}

		// Token: 0x060019F0 RID: 6640 RVA: 0x00068218 File Offset: 0x00066418
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleBackgroundPosition)
			{
				StyleBackgroundPosition other = (StyleBackgroundPosition)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060019F1 RID: 6641 RVA: 0x00068244 File Offset: 0x00066444
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x060019F2 RID: 6642 RVA: 0x00068278 File Offset: 0x00066478
		public override string ToString()
		{
			return this.DebugString<BackgroundPosition>();
		}

		// Token: 0x04000AD5 RID: 2773
		private BackgroundPosition m_Value;

		// Token: 0x04000AD6 RID: 2774
		private StyleKeyword m_Keyword;
	}
}
