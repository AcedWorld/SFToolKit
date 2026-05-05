using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000302 RID: 770
	public struct StyleFloat : IStyleValue<float>, IEquatable<StyleFloat>
	{
		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x06001A55 RID: 6741 RVA: 0x00068E74 File Offset: 0x00067074
		// (set) Token: 0x06001A56 RID: 6742 RVA: 0x00068E9B File Offset: 0x0006709B
		public float value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : 0f;
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06001A57 RID: 6743 RVA: 0x00068EAC File Offset: 0x000670AC
		// (set) Token: 0x06001A58 RID: 6744 RVA: 0x00068EC4 File Offset: 0x000670C4
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

		// Token: 0x06001A59 RID: 6745 RVA: 0x00068ECE File Offset: 0x000670CE
		public StyleFloat(float v)
		{
			this = new StyleFloat(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x00068EDA File Offset: 0x000670DA
		public StyleFloat(StyleKeyword keyword)
		{
			this = new StyleFloat(0f, keyword);
		}

		// Token: 0x06001A5B RID: 6747 RVA: 0x00068EEA File Offset: 0x000670EA
		internal StyleFloat(float v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001A5C RID: 6748 RVA: 0x00068EFC File Offset: 0x000670FC
		public static bool operator ==(StyleFloat lhs, StyleFloat rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001A5D RID: 6749 RVA: 0x00068F30 File Offset: 0x00067130
		public static bool operator !=(StyleFloat lhs, StyleFloat rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001A5E RID: 6750 RVA: 0x00068F4C File Offset: 0x0006714C
		public static implicit operator StyleFloat(StyleKeyword keyword)
		{
			return new StyleFloat(keyword);
		}

		// Token: 0x06001A5F RID: 6751 RVA: 0x00068F64 File Offset: 0x00067164
		public static implicit operator StyleFloat(float v)
		{
			return new StyleFloat(v);
		}

		// Token: 0x06001A60 RID: 6752 RVA: 0x00068F7C File Offset: 0x0006717C
		public bool Equals(StyleFloat other)
		{
			return other == this;
		}

		// Token: 0x06001A61 RID: 6753 RVA: 0x00068F9C File Offset: 0x0006719C
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleFloat)
			{
				StyleFloat other = (StyleFloat)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001A62 RID: 6754 RVA: 0x00068FC8 File Offset: 0x000671C8
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x00068FF4 File Offset: 0x000671F4
		public override string ToString()
		{
			return this.DebugString<float>();
		}

		// Token: 0x04000AE6 RID: 2790
		private float m_Value;

		// Token: 0x04000AE7 RID: 2791
		private StyleKeyword m_Keyword;
	}
}
