using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000308 RID: 776
	public struct StyleRotate : IStyleValue<Rotate>, IEquatable<StyleRotate>
	{
		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x06001AB8 RID: 6840 RVA: 0x00069ABC File Offset: 0x00067CBC
		// (set) Token: 0x06001AB9 RID: 6841 RVA: 0x00069B21 File Offset: 0x00067D21
		public Rotate value
		{
			get
			{
				StyleKeyword keyword = this.m_Keyword;
				if (!true)
				{
				}
				Rotate result;
				switch (keyword)
				{
				case StyleKeyword.Undefined:
					result = this.m_Value;
					goto IL_4F;
				case StyleKeyword.Null:
					result = Rotate.None();
					goto IL_4F;
				case StyleKeyword.None:
					result = Rotate.None();
					goto IL_4F;
				case StyleKeyword.Initial:
					result = Rotate.Initial();
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

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x06001ABA RID: 6842 RVA: 0x00069B34 File Offset: 0x00067D34
		// (set) Token: 0x06001ABB RID: 6843 RVA: 0x00069B4C File Offset: 0x00067D4C
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

		// Token: 0x06001ABC RID: 6844 RVA: 0x00069B56 File Offset: 0x00067D56
		public StyleRotate(Rotate v)
		{
			this = new StyleRotate(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001ABD RID: 6845 RVA: 0x00069B64 File Offset: 0x00067D64
		public StyleRotate(StyleKeyword keyword)
		{
			this = new StyleRotate(default(Rotate), keyword);
		}

		// Token: 0x06001ABE RID: 6846 RVA: 0x00069B83 File Offset: 0x00067D83
		internal StyleRotate(Rotate v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x00069B94 File Offset: 0x00067D94
		public static bool operator ==(StyleRotate lhs, StyleRotate rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001AC0 RID: 6848 RVA: 0x00069BC8 File Offset: 0x00067DC8
		public static bool operator !=(StyleRotate lhs, StyleRotate rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001AC1 RID: 6849 RVA: 0x00069BE4 File Offset: 0x00067DE4
		public static implicit operator StyleRotate(StyleKeyword keyword)
		{
			return new StyleRotate(keyword);
		}

		// Token: 0x06001AC2 RID: 6850 RVA: 0x00069BFC File Offset: 0x00067DFC
		public static implicit operator StyleRotate(Rotate v)
		{
			return new StyleRotate(v);
		}

		// Token: 0x06001AC3 RID: 6851 RVA: 0x00069C14 File Offset: 0x00067E14
		public bool Equals(StyleRotate other)
		{
			return other == this;
		}

		// Token: 0x06001AC4 RID: 6852 RVA: 0x00069C34 File Offset: 0x00067E34
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleRotate)
			{
				StyleRotate other = (StyleRotate)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001AC5 RID: 6853 RVA: 0x00069C60 File Offset: 0x00067E60
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001AC6 RID: 6854 RVA: 0x00069C94 File Offset: 0x00067E94
		public override string ToString()
		{
			return this.DebugString<Rotate>();
		}

		// Token: 0x04000AF2 RID: 2802
		private Rotate m_Value;

		// Token: 0x04000AF3 RID: 2803
		private StyleKeyword m_Keyword;
	}
}
