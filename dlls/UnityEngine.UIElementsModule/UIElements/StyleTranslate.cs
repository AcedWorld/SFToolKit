using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200030A RID: 778
	public struct StyleTranslate : IStyleValue<Translate>, IEquatable<StyleTranslate>
	{
		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x06001AD8 RID: 6872 RVA: 0x00069EE4 File Offset: 0x000680E4
		// (set) Token: 0x06001AD9 RID: 6873 RVA: 0x00069F49 File Offset: 0x00068149
		public Translate value
		{
			get
			{
				StyleKeyword keyword = this.m_Keyword;
				if (!true)
				{
				}
				Translate result;
				switch (keyword)
				{
				case StyleKeyword.Undefined:
					result = this.m_Value;
					goto IL_4F;
				case StyleKeyword.Null:
					result = Translate.None();
					goto IL_4F;
				case StyleKeyword.None:
					result = Translate.None();
					goto IL_4F;
				case StyleKeyword.Initial:
					result = Translate.None();
					goto IL_4F;
				}
				throw new NotImplementedException();
				IL_4F:
				if (!true)
				{
				}
				return result;
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x06001ADA RID: 6874 RVA: 0x00069F5C File Offset: 0x0006815C
		// (set) Token: 0x06001ADB RID: 6875 RVA: 0x00069F74 File Offset: 0x00068174
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

		// Token: 0x06001ADC RID: 6876 RVA: 0x00069F7E File Offset: 0x0006817E
		public StyleTranslate(Translate v)
		{
			this = new StyleTranslate(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001ADD RID: 6877 RVA: 0x00069F8C File Offset: 0x0006818C
		public StyleTranslate(StyleKeyword keyword)
		{
			this = new StyleTranslate(default(Translate), keyword);
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x00069FAB File Offset: 0x000681AB
		internal StyleTranslate(Translate v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001ADF RID: 6879 RVA: 0x00069FBC File Offset: 0x000681BC
		public static bool operator ==(StyleTranslate lhs, StyleTranslate rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001AE0 RID: 6880 RVA: 0x00069FF0 File Offset: 0x000681F0
		public static bool operator !=(StyleTranslate lhs, StyleTranslate rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001AE1 RID: 6881 RVA: 0x0006A00C File Offset: 0x0006820C
		public static implicit operator StyleTranslate(StyleKeyword keyword)
		{
			return new StyleTranslate(keyword);
		}

		// Token: 0x06001AE2 RID: 6882 RVA: 0x0006A024 File Offset: 0x00068224
		public static implicit operator StyleTranslate(Translate v)
		{
			return new StyleTranslate(v);
		}

		// Token: 0x06001AE3 RID: 6883 RVA: 0x0006A03C File Offset: 0x0006823C
		public bool Equals(StyleTranslate other)
		{
			return other == this;
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x0006A05C File Offset: 0x0006825C
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleTranslate)
			{
				StyleTranslate other = (StyleTranslate)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x0006A088 File Offset: 0x00068288
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001AE6 RID: 6886 RVA: 0x0006A0BC File Offset: 0x000682BC
		public override string ToString()
		{
			return this.DebugString<Translate>();
		}

		// Token: 0x04000AF6 RID: 2806
		private Translate m_Value;

		// Token: 0x04000AF7 RID: 2807
		private StyleKeyword m_Keyword;
	}
}
