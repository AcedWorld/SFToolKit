using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002F9 RID: 761
	public struct StyleBackground : IStyleValue<Background>, IEquatable<StyleBackground>
	{
		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x060019CE RID: 6606 RVA: 0x00067EAC File Offset: 0x000660AC
		// (set) Token: 0x060019CF RID: 6607 RVA: 0x00067ED7 File Offset: 0x000660D7
		public Background value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : default(Background);
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x060019D0 RID: 6608 RVA: 0x00067EE8 File Offset: 0x000660E8
		// (set) Token: 0x060019D1 RID: 6609 RVA: 0x00067F00 File Offset: 0x00066100
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

		// Token: 0x060019D2 RID: 6610 RVA: 0x00067F0A File Offset: 0x0006610A
		public StyleBackground(Background v)
		{
			this = new StyleBackground(v, StyleKeyword.Undefined);
		}

		// Token: 0x060019D3 RID: 6611 RVA: 0x00067F16 File Offset: 0x00066116
		public StyleBackground(Texture2D v)
		{
			this = new StyleBackground(v, StyleKeyword.Undefined);
		}

		// Token: 0x060019D4 RID: 6612 RVA: 0x00067F22 File Offset: 0x00066122
		public StyleBackground(Sprite v)
		{
			this = new StyleBackground(v, StyleKeyword.Undefined);
		}

		// Token: 0x060019D5 RID: 6613 RVA: 0x00067F2E File Offset: 0x0006612E
		public StyleBackground(VectorImage v)
		{
			this = new StyleBackground(v, StyleKeyword.Undefined);
		}

		// Token: 0x060019D6 RID: 6614 RVA: 0x00067F3C File Offset: 0x0006613C
		public StyleBackground(StyleKeyword keyword)
		{
			this = new StyleBackground(default(Background), keyword);
		}

		// Token: 0x060019D7 RID: 6615 RVA: 0x00067F5B File Offset: 0x0006615B
		internal StyleBackground(Texture2D v, StyleKeyword keyword)
		{
			this = new StyleBackground(Background.FromTexture2D(v), keyword);
		}

		// Token: 0x060019D8 RID: 6616 RVA: 0x00067F6C File Offset: 0x0006616C
		internal StyleBackground(Sprite v, StyleKeyword keyword)
		{
			this = new StyleBackground(Background.FromSprite(v), keyword);
		}

		// Token: 0x060019D9 RID: 6617 RVA: 0x00067F7D File Offset: 0x0006617D
		internal StyleBackground(VectorImage v, StyleKeyword keyword)
		{
			this = new StyleBackground(Background.FromVectorImage(v), keyword);
		}

		// Token: 0x060019DA RID: 6618 RVA: 0x00067F8E File Offset: 0x0006618E
		internal StyleBackground(Background v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x060019DB RID: 6619 RVA: 0x00067FA0 File Offset: 0x000661A0
		public static bool operator ==(StyleBackground lhs, StyleBackground rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x060019DC RID: 6620 RVA: 0x00067FD4 File Offset: 0x000661D4
		public static bool operator !=(StyleBackground lhs, StyleBackground rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060019DD RID: 6621 RVA: 0x00067FF0 File Offset: 0x000661F0
		public static implicit operator StyleBackground(StyleKeyword keyword)
		{
			return new StyleBackground(keyword);
		}

		// Token: 0x060019DE RID: 6622 RVA: 0x00068008 File Offset: 0x00066208
		public static implicit operator StyleBackground(Background v)
		{
			return new StyleBackground(v);
		}

		// Token: 0x060019DF RID: 6623 RVA: 0x00068020 File Offset: 0x00066220
		public static implicit operator StyleBackground(Texture2D v)
		{
			return new StyleBackground(v);
		}

		// Token: 0x060019E0 RID: 6624 RVA: 0x00068038 File Offset: 0x00066238
		public bool Equals(StyleBackground other)
		{
			return other == this;
		}

		// Token: 0x060019E1 RID: 6625 RVA: 0x00068058 File Offset: 0x00066258
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleBackground)
			{
				StyleBackground other = (StyleBackground)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060019E2 RID: 6626 RVA: 0x00068084 File Offset: 0x00066284
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x060019E3 RID: 6627 RVA: 0x000680B8 File Offset: 0x000662B8
		public override string ToString()
		{
			return this.DebugString<Background>();
		}

		// Token: 0x04000AD3 RID: 2771
		private Background m_Value;

		// Token: 0x04000AD4 RID: 2772
		private StyleKeyword m_Keyword;
	}
}
