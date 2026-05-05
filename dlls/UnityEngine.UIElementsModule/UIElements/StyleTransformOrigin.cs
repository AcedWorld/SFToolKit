using System;

namespace UnityEngine.UIElements
{
	// Token: 0x0200030C RID: 780
	public struct StyleTransformOrigin : IStyleValue<TransformOrigin>, IEquatable<StyleTransformOrigin>
	{
		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x06001AF6 RID: 6902 RVA: 0x0006A2CC File Offset: 0x000684CC
		// (set) Token: 0x06001AF7 RID: 6903 RVA: 0x0006A331 File Offset: 0x00068531
		public TransformOrigin value
		{
			get
			{
				StyleKeyword keyword = this.m_Keyword;
				if (!true)
				{
				}
				TransformOrigin result;
				switch (keyword)
				{
				case StyleKeyword.Undefined:
					result = this.m_Value;
					goto IL_4F;
				case StyleKeyword.Null:
					result = TransformOrigin.Initial();
					goto IL_4F;
				case StyleKeyword.None:
					result = TransformOrigin.Initial();
					goto IL_4F;
				case StyleKeyword.Initial:
					result = TransformOrigin.Initial();
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

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x06001AF8 RID: 6904 RVA: 0x0006A344 File Offset: 0x00068544
		// (set) Token: 0x06001AF9 RID: 6905 RVA: 0x0006A35C File Offset: 0x0006855C
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

		// Token: 0x06001AFA RID: 6906 RVA: 0x0006A366 File Offset: 0x00068566
		public StyleTransformOrigin(TransformOrigin v)
		{
			this = new StyleTransformOrigin(v, StyleKeyword.Undefined);
		}

		// Token: 0x06001AFB RID: 6907 RVA: 0x0006A374 File Offset: 0x00068574
		public StyleTransformOrigin(StyleKeyword keyword)
		{
			this = new StyleTransformOrigin(default(TransformOrigin), keyword);
		}

		// Token: 0x06001AFC RID: 6908 RVA: 0x0006A393 File Offset: 0x00068593
		internal StyleTransformOrigin(TransformOrigin v, StyleKeyword keyword)
		{
			this.m_Keyword = keyword;
			this.m_Value = v;
		}

		// Token: 0x06001AFD RID: 6909 RVA: 0x0006A3A4 File Offset: 0x000685A4
		public static bool operator ==(StyleTransformOrigin lhs, StyleTransformOrigin rhs)
		{
			return lhs.m_Keyword == rhs.m_Keyword && lhs.m_Value == rhs.m_Value;
		}

		// Token: 0x06001AFE RID: 6910 RVA: 0x0006A3D8 File Offset: 0x000685D8
		public static bool operator !=(StyleTransformOrigin lhs, StyleTransformOrigin rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001AFF RID: 6911 RVA: 0x0006A3F4 File Offset: 0x000685F4
		public static implicit operator StyleTransformOrigin(StyleKeyword keyword)
		{
			return new StyleTransformOrigin(keyword);
		}

		// Token: 0x06001B00 RID: 6912 RVA: 0x0006A40C File Offset: 0x0006860C
		public static implicit operator StyleTransformOrigin(TransformOrigin v)
		{
			return new StyleTransformOrigin(v);
		}

		// Token: 0x06001B01 RID: 6913 RVA: 0x0006A424 File Offset: 0x00068624
		public bool Equals(StyleTransformOrigin other)
		{
			return other == this;
		}

		// Token: 0x06001B02 RID: 6914 RVA: 0x0006A444 File Offset: 0x00068644
		public override bool Equals(object obj)
		{
			bool result;
			if (obj is StyleTransformOrigin)
			{
				StyleTransformOrigin other = (StyleTransformOrigin)obj;
				result = this.Equals(other);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001B03 RID: 6915 RVA: 0x0006A470 File Offset: 0x00068670
		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode() * 397 ^ (int)this.m_Keyword;
		}

		// Token: 0x06001B04 RID: 6916 RVA: 0x0006A4A4 File Offset: 0x000686A4
		public override string ToString()
		{
			return this.DebugString<TransformOrigin>();
		}

		// Token: 0x04000AFA RID: 2810
		private TransformOrigin m_Value;

		// Token: 0x04000AFB RID: 2811
		private StyleKeyword m_Keyword;
	}
}
