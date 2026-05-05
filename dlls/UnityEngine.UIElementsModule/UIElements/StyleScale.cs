using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000309 RID: 777
	public struct StyleScale : IStyleValue<Scale>, IEquatable<StyleScale>
	{
		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x06001AC7 RID: 6855 RVA: 0x00069CB8 File Offset: 0x00067EB8
		// (set) Token: 0x06001AC8 RID: 6856 RVA: 0x00069D1D File Offset: 0x00067F1D
		public Scale value
		{
			get
			{
				StyleKeyword keyword = this.m_Keyword;
				if (!true)
				{
				}
				Scale result;
				switch (keyword)
				{
				case StyleKeyword.Undefined:
					result = this.m_Value;
					goto IL_4F;
				case StyleKeyword.Null:
					result = Scale.None();
					goto IL_4F;
				case StyleKeyword.None:
					result = Scale.None();
					goto IL_4F;
				case StyleKeyword.Initial:
					result = Scale.Initial();
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

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x06001AC9 RID: 6857 RVA: 0x00069D30 File Offset: 0x00067F30
		// (set) Token: 0x06001ACA RID: 6858 RVA: 0x00069D48 File Offset: 0x00067F48
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

		// Token: 0x06001ACB RID: 6859 RVA: 0x00069D52 File Offset: 0x00067F52
		public StyleScale(Scale v)
		{
			this = new StyleScale(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x00069D60 File Offset: 0x00067F60
		public StyleScale(StyleKeyword keyword)
		{
			this = new StyleScale(default(Scale), keyword);
		}

		// Token: 0x06001ACD RID: 6861 RVA: 0x00069D7F File Offset: 0x00067F7F
		public StyleScale(Vector2 scale)
		{
			this = new StyleScale(new Scale(scale));
		}

		// Token: 0x06001ACE RID: 6862 RVA: 0x00069D8F File Offset: 0x00067F8F
		internal StyleScale(Scale v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001ACF RID: 6863 RVA: 0x00069DA0 File Offset: 0x00067FA0
		public static implicit operator StyleScale(Vector2 scale)
		{
			return new Scale(scale);
		}

		// Token: 0x06001AD0 RID: 6864 RVA: 0x00069DC0 File Offset: 0x00067FC0
		public static bool operator ==(StyleScale lhs, StyleScale rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001AD1 RID: 6865 RVA: 0x00069DF4 File Offset: 0x00067FF4
		public static bool operator !=(StyleScale lhs, StyleScale rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001AD2 RID: 6866 RVA: 0x00069E10 File Offset: 0x00068010
		public static implicit operator StyleScale(StyleKeyword keyword)
		{
			return new StyleScale(keyword);
		}

		// Token: 0x06001AD3 RID: 6867 RVA: 0x00069E28 File Offset: 0x00068028
		public static implicit operator StyleScale(Scale v)
		{
			return new StyleScale(v);
		}

		// Token: 0x06001AD4 RID: 6868 RVA: 0x00069E40 File Offset: 0x00068040
		public bool Equals(StyleScale other)
		{
			return other == this;
		}

		// Token: 0x06001AD5 RID: 6869 RVA: 0x00069E60 File Offset: 0x00068060
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleScale)
			{
				StyleScale other = (StyleScale)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001AD6 RID: 6870 RVA: 0x00069E8C File Offset: 0x0006808C
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001AD7 RID: 6871 RVA: 0x00069EC0 File Offset: 0x000680C0
		public override string ToString()
		{
			return this.DebugString<Scale>();
		}

		// Token: 0x04000AF4 RID: 2804
		private Scale m_Value;

		// Token: 0x04000AF5 RID: 2805
		private StyleKeyword m_Keyword;
	}
}
