using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000305 RID: 773
	public struct StyleInt : IStyleValue<int>, IEquatable<StyleInt>
	{
		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x06001A89 RID: 6793 RVA: 0x00069410 File Offset: 0x00067610
		// (set) Token: 0x06001A8A RID: 6794 RVA: 0x00069433 File Offset: 0x00067633
		public int value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : 0;
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x06001A8B RID: 6795 RVA: 0x00069444 File Offset: 0x00067644
		// (set) Token: 0x06001A8C RID: 6796 RVA: 0x0006945C File Offset: 0x0006765C
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

		// Token: 0x06001A8D RID: 6797 RVA: 0x00069466 File Offset: 0x00067666
		public StyleInt(int v)
		{
			this = new StyleInt(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001A8E RID: 6798 RVA: 0x00069472 File Offset: 0x00067672
		public StyleInt(StyleKeyword keyword)
		{
			this = new StyleInt(0, keyword);
		}

		// Token: 0x06001A8F RID: 6799 RVA: 0x0006947E File Offset: 0x0006767E
		internal StyleInt(int v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001A90 RID: 6800 RVA: 0x00069490 File Offset: 0x00067690
		public static bool operator ==(StyleInt lhs, StyleInt rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001A91 RID: 6801 RVA: 0x000694C4 File Offset: 0x000676C4
		public static bool operator !=(StyleInt lhs, StyleInt rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001A92 RID: 6802 RVA: 0x000694E0 File Offset: 0x000676E0
		public static implicit operator StyleInt(StyleKeyword keyword)
		{
			return new StyleInt(keyword);
		}

		// Token: 0x06001A93 RID: 6803 RVA: 0x000694F8 File Offset: 0x000676F8
		public static implicit operator StyleInt(int v)
		{
			return new StyleInt(v);
		}

		// Token: 0x06001A94 RID: 6804 RVA: 0x00069510 File Offset: 0x00067710
		public bool Equals(StyleInt other)
		{
			return other == this;
		}

		// Token: 0x06001A95 RID: 6805 RVA: 0x00069530 File Offset: 0x00067730
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleInt)
			{
				StyleInt other = (StyleInt)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001A96 RID: 6806 RVA: 0x0006955C File Offset: 0x0006775C
		public override int GetHashCode()
		{
			return this.m_Value * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001A97 RID: 6807 RVA: 0x00069584 File Offset: 0x00067784
		public override string ToString()
		{
			return this.DebugString<int>();
		}

		// Token: 0x04000AEC RID: 2796
		private int m_Value;

		// Token: 0x04000AED RID: 2797
		private StyleKeyword m_Keyword;
	}
}
