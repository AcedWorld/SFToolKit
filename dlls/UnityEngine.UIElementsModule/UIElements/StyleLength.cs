using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000306 RID: 774
	public struct StyleLength : IStyleValue<Length>, IEquatable<StyleLength>
	{
		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x06001A98 RID: 6808 RVA: 0x000695A8 File Offset: 0x000677A8
		// (set) Token: 0x06001A99 RID: 6809 RVA: 0x000695F0 File Offset: 0x000677F0
		public Length value
		{
			get
			{
				bool flag = this.m_Keyword == StyleKeyword.Auto || this.m_Keyword == StyleKeyword.None || this.m_Keyword == StyleKeyword.Undefined;
				Length result;
				if (flag)
				{
					result = this.m_Value;
				}
				else
				{
					result = default(Length);
				}
				return result;
			}
			set
			{
				bool flag = value.IsAuto();
				if (flag)
				{
					this.m_Keyword = StyleKeyword.Auto;
				}
				else
				{
					bool flag2 = value.IsNone();
					if (flag2)
					{
						this.m_Keyword = StyleKeyword.None;
					}
					else
					{
						this.m_Keyword = StyleKeyword.Undefined;
					}
				}
				this.m_Value = value;
			}
		}

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x06001A9A RID: 6810 RVA: 0x00069634 File Offset: 0x00067834
		// (set) Token: 0x06001A9B RID: 6811 RVA: 0x0006964C File Offset: 0x0006784C
		public StyleKeyword keyword
		{
			get
			{
				return this.m_Keyword;
			}
			set
			{
				this.m_Keyword = value;
				bool flag = this.m_Keyword == StyleKeyword.Auto;
				if (flag)
				{
					this.m_Value = Length.Auto();
				}
				else
				{
					bool flag2 = this.m_Keyword == StyleKeyword.None;
					if (flag2)
					{
						this.m_Value = Length.None();
					}
					else
					{
						bool flag3 = this.m_Keyword > StyleKeyword.Undefined;
						if (flag3)
						{
							this.m_Value = default(Length);
						}
					}
				}
			}
		}

		// Token: 0x06001A9C RID: 6812 RVA: 0x000696B4 File Offset: 0x000678B4
		public StyleLength(float v)
		{
			this = new StyleLength(new Length(v, LengthUnit.Pixel), StyleKeyword.Undefined);
		}

		// Token: 0x06001A9D RID: 6813 RVA: 0x000696C6 File Offset: 0x000678C6
		public StyleLength(Length v)
		{
			this = new StyleLength(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001A9E RID: 6814 RVA: 0x000696D4 File Offset: 0x000678D4
		public StyleLength(StyleKeyword keyword)
		{
			this = new StyleLength(default(Length), keyword);
		}

		// Token: 0x06001A9F RID: 6815 RVA: 0x000696F4 File Offset: 0x000678F4
		internal StyleLength(Length v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
			bool flag = v.IsAuto();
			if (flag)
			{
				this.m_Keyword = StyleKeyword.Auto;
			}
			else
			{
				bool flag2 = v.IsNone();
				if (flag2)
				{
					this.m_Keyword = StyleKeyword.None;
				}
			}
		}

		// Token: 0x06001AA0 RID: 6816 RVA: 0x00069738 File Offset: 0x00067938
		public static bool operator ==(StyleLength lhs, StyleLength rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001AA1 RID: 6817 RVA: 0x0006976C File Offset: 0x0006796C
		public static bool operator !=(StyleLength lhs, StyleLength rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001AA2 RID: 6818 RVA: 0x00069788 File Offset: 0x00067988
		public static implicit operator StyleLength(StyleKeyword keyword)
		{
			return new StyleLength(keyword);
		}

		// Token: 0x06001AA3 RID: 6819 RVA: 0x000697A0 File Offset: 0x000679A0
		public static implicit operator StyleLength(float v)
		{
			return new StyleLength(v);
		}

		// Token: 0x06001AA4 RID: 6820 RVA: 0x000697B8 File Offset: 0x000679B8
		public static implicit operator StyleLength(Length v)
		{
			return new StyleLength(v);
		}

		// Token: 0x06001AA5 RID: 6821 RVA: 0x000697D0 File Offset: 0x000679D0
		public bool Equals(StyleLength other)
		{
			return other == this;
		}

		// Token: 0x06001AA6 RID: 6822 RVA: 0x000697F0 File Offset: 0x000679F0
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleLength)
			{
				StyleLength other = (StyleLength)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x0006981C File Offset: 0x00067A1C
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x00069850 File Offset: 0x00067A50
		public override string ToString()
		{
			return this.DebugString<Length>();
		}

		// Token: 0x04000AEE RID: 2798
		private Length m_Value;

		// Token: 0x04000AEF RID: 2799
		private StyleKeyword m_Keyword;
	}
}
