using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.UIElements
{
	// Token: 0x02000307 RID: 775
	public struct StyleList<T> : IStyleValue<List<T>>, IEquatable<StyleList<T>>
	{
		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x06001AA9 RID: 6825 RVA: 0x00069874 File Offset: 0x00067A74
		// (set) Token: 0x06001AAA RID: 6826 RVA: 0x00069897 File Offset: 0x00067A97
		public List<T> value
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

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x06001AAB RID: 6827 RVA: 0x000698A8 File Offset: 0x00067AA8
		// (set) Token: 0x06001AAC RID: 6828 RVA: 0x000698C0 File Offset: 0x00067AC0
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

		// Token: 0x06001AAD RID: 6829 RVA: 0x000698CA File Offset: 0x00067ACA
		public StyleList(List<T> v)
		{
			this = new StyleList<T>(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001AAE RID: 6830 RVA: 0x000698D6 File Offset: 0x00067AD6
		public StyleList(StyleKeyword keyword)
		{
			this = new StyleList<T>(null, keyword);
		}

		// Token: 0x06001AAF RID: 6831 RVA: 0x000698E2 File Offset: 0x00067AE2
		internal StyleList(List<T> v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001AB0 RID: 6832 RVA: 0x000698F4 File Offset: 0x00067AF4
		public static bool operator ==(StyleList<T> lhs, StyleList<T> rhs)
		{
			bool flag = lhs.m_Keyword != rhs.m_Keyword;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				List<T> value = lhs.m_Value;
				List<T> value2 = rhs.m_Value;
				bool flag2 = value == value2;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = value == null || value2 == null;
					result = (!flag3 && value.Count == value2.Count && value.SequenceEqual(value2));
				}
			}
			return result;
		}

		// Token: 0x06001AB1 RID: 6833 RVA: 0x00069968 File Offset: 0x00067B68
		public static bool operator !=(StyleList<T> lhs, StyleList<T> rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001AB2 RID: 6834 RVA: 0x00069984 File Offset: 0x00067B84
		public static implicit operator StyleList<T>(StyleKeyword keyword)
		{
			return new StyleList<T>(keyword);
		}

		// Token: 0x06001AB3 RID: 6835 RVA: 0x0006999C File Offset: 0x00067B9C
		public static implicit operator StyleList<T>(List<T> v)
		{
			return new StyleList<T>(v);
		}

		// Token: 0x06001AB4 RID: 6836 RVA: 0x000699B4 File Offset: 0x00067BB4
		public bool Equals(StyleList<T> other)
		{
			return other == this;
		}

		// Token: 0x06001AB5 RID: 6837 RVA: 0x000699D4 File Offset: 0x00067BD4
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleList<T>)
			{
				StyleList<T> other = (StyleList<T>)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001AB6 RID: 6838 RVA: 0x00069A00 File Offset: 0x00067C00
		public override int GetHashCode()
		{
			int num = 0;
			bool flag = this.m_Value != null && this.m_Value.Count > 0;
			if (flag)
			{
				num = EqualityComparer<T>.Default.GetHashCode(this.m_Value[0]);
				for (int i = 1; i < this.m_Value.Count; i++)
				{
					num = (num * 397 ^ EqualityComparer<T>.Default.GetHashCode(this.m_Value[i]));
				}
			}
			return num * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001AB7 RID: 6839 RVA: 0x00069A98 File Offset: 0x00067C98
		public override string ToString()
		{
			return this.DebugString<List<T>>();
		}

		// Token: 0x04000AF0 RID: 2800
		private StyleKeyword m_Keyword;

		// Token: 0x04000AF1 RID: 2801
		private List<T> m_Value;
	}
}
