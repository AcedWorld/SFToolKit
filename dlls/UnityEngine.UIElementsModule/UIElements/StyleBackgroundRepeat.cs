using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020002FB RID: 763
	public struct StyleBackgroundRepeat : IStyleValue<BackgroundRepeat>, IEquatable<StyleBackgroundRepeat>
	{
		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x060019F3 RID: 6643 RVA: 0x0006829C File Offset: 0x0006649C
		// (set) Token: 0x060019F4 RID: 6644 RVA: 0x000682C7 File Offset: 0x000664C7
		public BackgroundRepeat value
		{
			get
			{
				return (this.m_Keyword == StyleKeyword.Undefined) ? this.m_Value : default(BackgroundRepeat);
			}
			set
			{
				this.m_Value = value;
				this.m_Keyword = StyleKeyword.Undefined;
			}
		}

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x060019F5 RID: 6645 RVA: 0x000682D8 File Offset: 0x000664D8
		// (set) Token: 0x060019F6 RID: 6646 RVA: 0x000682F0 File Offset: 0x000664F0
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

		// Token: 0x060019F7 RID: 6647 RVA: 0x000682FA File Offset: 0x000664FA
		public StyleBackgroundRepeat(BackgroundRepeat v)
		{
			this = new StyleBackgroundRepeat(v, StyleKeyword.Undefined);
		}

		// Token: 0x060019F8 RID: 6648 RVA: 0x00068308 File Offset: 0x00066508
		public StyleBackgroundRepeat(StyleKeyword keyword)
		{
			this = new StyleBackgroundRepeat(default(BackgroundRepeat), keyword);
		}

		// Token: 0x060019F9 RID: 6649 RVA: 0x00068327 File Offset: 0x00066527
		internal StyleBackgroundRepeat(BackgroundRepeat v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x060019FA RID: 6650 RVA: 0x00068338 File Offset: 0x00066538
		public static bool operator ==(StyleBackgroundRepeat lhs, StyleBackgroundRepeat rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x060019FB RID: 6651 RVA: 0x0006836C File Offset: 0x0006656C
		public static bool operator !=(StyleBackgroundRepeat lhs, StyleBackgroundRepeat rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060019FC RID: 6652 RVA: 0x00068388 File Offset: 0x00066588
		public static implicit operator StyleBackgroundRepeat(StyleKeyword keyword)
		{
			return new StyleBackgroundRepeat(keyword);
		}

		// Token: 0x060019FD RID: 6653 RVA: 0x000683A0 File Offset: 0x000665A0
		public static implicit operator StyleBackgroundRepeat(BackgroundRepeat v)
		{
			return new StyleBackgroundRepeat(v);
		}

		// Token: 0x060019FE RID: 6654 RVA: 0x000683B8 File Offset: 0x000665B8
		public bool Equals(StyleBackgroundRepeat other)
		{
			return other == this;
		}

		// Token: 0x060019FF RID: 6655 RVA: 0x000683D8 File Offset: 0x000665D8
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleBackgroundRepeat)
			{
				StyleBackgroundRepeat other = (StyleBackgroundRepeat)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x00068404 File Offset: 0x00066604
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001A01 RID: 6657 RVA: 0x00068438 File Offset: 0x00066638
		public override string ToString()
		{
			return this.DebugString<BackgroundRepeat>();
		}

		// Token: 0x04000AD7 RID: 2775
		private BackgroundRepeat m_Value;

		// Token: 0x04000AD8 RID: 2776
		private StyleKeyword m_Keyword;
	}
}
