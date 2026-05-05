using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200030B RID: 779
	public struct StyleTextShadow : IStyleValue<TextShadow>, IEquatable<StyleTextShadow>
	{
		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x06001AE7 RID: 6887 RVA: 0x0006A0E0 File Offset: 0x000682E0
		// (set) Token: 0x06001AE8 RID: 6888 RVA: 0x0006A10B File Offset: 0x0006830B
		public TextShadow value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : default(TextShadow);
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x06001AE9 RID: 6889 RVA: 0x0006A11C File Offset: 0x0006831C
		// (set) Token: 0x06001AEA RID: 6890 RVA: 0x0006A134 File Offset: 0x00068334
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

		// Token: 0x06001AEB RID: 6891 RVA: 0x0006A13E File Offset: 0x0006833E
		public StyleTextShadow(TextShadow v)
		{
			this = new StyleTextShadow(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001AEC RID: 6892 RVA: 0x0006A14C File Offset: 0x0006834C
		public StyleTextShadow(StyleKeyword keyword)
		{
			this = new StyleTextShadow(default(TextShadow), keyword);
		}

		// Token: 0x06001AED RID: 6893 RVA: 0x0006A16B File Offset: 0x0006836B
		internal StyleTextShadow(TextShadow v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001AEE RID: 6894 RVA: 0x0006A17C File Offset: 0x0006837C
		public static bool operator ==(StyleTextShadow lhs, StyleTextShadow rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001AEF RID: 6895 RVA: 0x0006A1B0 File Offset: 0x000683B0
		public static bool operator !=(StyleTextShadow lhs, StyleTextShadow rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001AF0 RID: 6896 RVA: 0x0006A1CC File Offset: 0x000683CC
		public static implicit operator StyleTextShadow(StyleKeyword keyword)
		{
			return new StyleTextShadow(keyword);
		}

		// Token: 0x06001AF1 RID: 6897 RVA: 0x0006A1E4 File Offset: 0x000683E4
		public static implicit operator StyleTextShadow(TextShadow v)
		{
			return new StyleTextShadow(v);
		}

		// Token: 0x06001AF2 RID: 6898 RVA: 0x0006A1FC File Offset: 0x000683FC
		public bool Equals(StyleTextShadow other)
		{
			return other == this;
		}

		// Token: 0x06001AF3 RID: 6899 RVA: 0x0006A21C File Offset: 0x0006841C
		public override bool Equals(object obj)
		{
			bool flag = !(obj is StyleTextShadow);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				StyleTextShadow lhs = (StyleTextShadow)obj;
				result = (lhs == this);
			}
			return result;
		}

		// Token: 0x06001AF4 RID: 6900 RVA: 0x0006A258 File Offset: 0x00068458
		public override int GetHashCode()
		{
			int num = 917506989;
			num = num * -1521134295 + this.m_Keyword.GetHashCode();
			return num * -1521134295 + this.m_Value.GetHashCode();
		}

		// Token: 0x06001AF5 RID: 6901 RVA: 0x0006A2A8 File Offset: 0x000684A8
		public override string ToString()
		{
			return this.DebugString<TextShadow>();
		}

		// Token: 0x04000AF8 RID: 2808
		private StyleKeyword m_Keyword;

		// Token: 0x04000AF9 RID: 2809
		private TextShadow m_Value;
	}
}
