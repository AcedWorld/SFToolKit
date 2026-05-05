using System;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements.Experimental
{
	// Token: 0x020004BD RID: 1213
	public struct StyleValues
	{
		// Token: 0x17000878 RID: 2168
		// (get) Token: 0x06002599 RID: 9625 RVA: 0x0009E670 File Offset: 0x0009C870
		// (set) Token: 0x0600259A RID: 9626 RVA: 0x0009E69A File Offset: 0x0009C89A
		public float top
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.Top).value;
			}
			set
			{
				this.SetValue(StylePropertyId.Top, value);
			}
		}

		// Token: 0x17000879 RID: 2169
		// (get) Token: 0x0600259B RID: 9627 RVA: 0x0009E6AC File Offset: 0x0009C8AC
		// (set) Token: 0x0600259C RID: 9628 RVA: 0x0009E6D6 File Offset: 0x0009C8D6
		public float left
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.Left).value;
			}
			set
			{
				this.SetValue(StylePropertyId.Left, value);
			}
		}

		// Token: 0x1700087A RID: 2170
		// (get) Token: 0x0600259D RID: 9629 RVA: 0x0009E6E8 File Offset: 0x0009C8E8
		// (set) Token: 0x0600259E RID: 9630 RVA: 0x0009E712 File Offset: 0x0009C912
		public float width
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.Width).value;
			}
			set
			{
				this.SetValue(StylePropertyId.Width, value);
			}
		}

		// Token: 0x1700087B RID: 2171
		// (get) Token: 0x0600259F RID: 9631 RVA: 0x0009E724 File Offset: 0x0009C924
		// (set) Token: 0x060025A0 RID: 9632 RVA: 0x0009E74E File Offset: 0x0009C94E
		public float height
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.Height).value;
			}
			set
			{
				this.SetValue(StylePropertyId.Height, value);
			}
		}

		// Token: 0x1700087C RID: 2172
		// (get) Token: 0x060025A1 RID: 9633 RVA: 0x0009E760 File Offset: 0x0009C960
		// (set) Token: 0x060025A2 RID: 9634 RVA: 0x0009E78A File Offset: 0x0009C98A
		public float right
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.Right).value;
			}
			set
			{
				this.SetValue(StylePropertyId.Right, value);
			}
		}

		// Token: 0x1700087D RID: 2173
		// (get) Token: 0x060025A3 RID: 9635 RVA: 0x0009E79C File Offset: 0x0009C99C
		// (set) Token: 0x060025A4 RID: 9636 RVA: 0x0009E7C6 File Offset: 0x0009C9C6
		public float bottom
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.Bottom).value;
			}
			set
			{
				this.SetValue(StylePropertyId.Bottom, value);
			}
		}

		// Token: 0x1700087E RID: 2174
		// (get) Token: 0x060025A5 RID: 9637 RVA: 0x0009E7D8 File Offset: 0x0009C9D8
		// (set) Token: 0x060025A6 RID: 9638 RVA: 0x0009E802 File Offset: 0x0009CA02
		public Color color
		{
			get
			{
				return this.Values().GetStyleColor(StylePropertyId.Color).value;
			}
			set
			{
				this.SetValue(StylePropertyId.Color, value);
			}
		}

		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x060025A7 RID: 9639 RVA: 0x0009E814 File Offset: 0x0009CA14
		// (set) Token: 0x060025A8 RID: 9640 RVA: 0x0009E83E File Offset: 0x0009CA3E
		public Color backgroundColor
		{
			get
			{
				return this.Values().GetStyleColor(StylePropertyId.BackgroundColor).value;
			}
			set
			{
				this.SetValue(StylePropertyId.BackgroundColor, value);
			}
		}

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x060025A9 RID: 9641 RVA: 0x0009E850 File Offset: 0x0009CA50
		// (set) Token: 0x060025AA RID: 9642 RVA: 0x0009E87A File Offset: 0x0009CA7A
		public Color unityBackgroundImageTintColor
		{
			get
			{
				return this.Values().GetStyleColor(StylePropertyId.UnityBackgroundImageTintColor).value;
			}
			set
			{
				this.SetValue(StylePropertyId.UnityBackgroundImageTintColor, value);
			}
		}

		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x060025AB RID: 9643 RVA: 0x0009E88C File Offset: 0x0009CA8C
		// (set) Token: 0x060025AC RID: 9644 RVA: 0x0009E8B6 File Offset: 0x0009CAB6
		public Color borderColor
		{
			get
			{
				return this.Values().GetStyleColor(StylePropertyId.BorderColor).value;
			}
			set
			{
				this.SetValue(StylePropertyId.BorderColor, value);
			}
		}

		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x060025AD RID: 9645 RVA: 0x0009E8C8 File Offset: 0x0009CAC8
		// (set) Token: 0x060025AE RID: 9646 RVA: 0x0009E8F2 File Offset: 0x0009CAF2
		public float marginLeft
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.MarginLeft).value;
			}
			set
			{
				this.SetValue(StylePropertyId.MarginLeft, value);
			}
		}

		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x060025AF RID: 9647 RVA: 0x0009E904 File Offset: 0x0009CB04
		// (set) Token: 0x060025B0 RID: 9648 RVA: 0x0009E92E File Offset: 0x0009CB2E
		public float marginTop
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.MarginTop).value;
			}
			set
			{
				this.SetValue(StylePropertyId.MarginTop, value);
			}
		}

		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x060025B1 RID: 9649 RVA: 0x0009E940 File Offset: 0x0009CB40
		// (set) Token: 0x060025B2 RID: 9650 RVA: 0x0009E96A File Offset: 0x0009CB6A
		public float marginRight
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.MarginRight).value;
			}
			set
			{
				this.SetValue(StylePropertyId.MarginRight, value);
			}
		}

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x060025B3 RID: 9651 RVA: 0x0009E97C File Offset: 0x0009CB7C
		// (set) Token: 0x060025B4 RID: 9652 RVA: 0x0009E9A6 File Offset: 0x0009CBA6
		public float marginBottom
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.MarginBottom).value;
			}
			set
			{
				this.SetValue(StylePropertyId.MarginBottom, value);
			}
		}

		// Token: 0x17000886 RID: 2182
		// (get) Token: 0x060025B5 RID: 9653 RVA: 0x0009E9B8 File Offset: 0x0009CBB8
		// (set) Token: 0x060025B6 RID: 9654 RVA: 0x0009E9E2 File Offset: 0x0009CBE2
		public float paddingLeft
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.PaddingLeft).value;
			}
			set
			{
				this.SetValue(StylePropertyId.PaddingLeft, value);
			}
		}

		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x060025B7 RID: 9655 RVA: 0x0009E9F4 File Offset: 0x0009CBF4
		// (set) Token: 0x060025B8 RID: 9656 RVA: 0x0009EA1E File Offset: 0x0009CC1E
		public float paddingTop
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.PaddingTop).value;
			}
			set
			{
				this.SetValue(StylePropertyId.PaddingTop, value);
			}
		}

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x060025B9 RID: 9657 RVA: 0x0009EA30 File Offset: 0x0009CC30
		// (set) Token: 0x060025BA RID: 9658 RVA: 0x0009EA5A File Offset: 0x0009CC5A
		public float paddingRight
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.PaddingRight).value;
			}
			set
			{
				this.SetValue(StylePropertyId.PaddingRight, value);
			}
		}

		// Token: 0x17000889 RID: 2185
		// (get) Token: 0x060025BB RID: 9659 RVA: 0x0009EA6C File Offset: 0x0009CC6C
		// (set) Token: 0x060025BC RID: 9660 RVA: 0x0009EA96 File Offset: 0x0009CC96
		public float paddingBottom
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.PaddingBottom).value;
			}
			set
			{
				this.SetValue(StylePropertyId.PaddingBottom, value);
			}
		}

		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x060025BD RID: 9661 RVA: 0x0009EAA8 File Offset: 0x0009CCA8
		// (set) Token: 0x060025BE RID: 9662 RVA: 0x0009EAD2 File Offset: 0x0009CCD2
		public float borderLeftWidth
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.BorderLeftWidth).value;
			}
			set
			{
				this.SetValue(StylePropertyId.BorderLeftWidth, value);
			}
		}

		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x060025BF RID: 9663 RVA: 0x0009EAE4 File Offset: 0x0009CCE4
		// (set) Token: 0x060025C0 RID: 9664 RVA: 0x0009EB0E File Offset: 0x0009CD0E
		public float borderRightWidth
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.BorderRightWidth).value;
			}
			set
			{
				this.SetValue(StylePropertyId.BorderRightWidth, value);
			}
		}

		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x060025C1 RID: 9665 RVA: 0x0009EB20 File Offset: 0x0009CD20
		// (set) Token: 0x060025C2 RID: 9666 RVA: 0x0009EB4A File Offset: 0x0009CD4A
		public float borderTopWidth
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.BorderTopWidth).value;
			}
			set
			{
				this.SetValue(StylePropertyId.BorderTopWidth, value);
			}
		}

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x060025C3 RID: 9667 RVA: 0x0009EB5C File Offset: 0x0009CD5C
		// (set) Token: 0x060025C4 RID: 9668 RVA: 0x0009EB86 File Offset: 0x0009CD86
		public float borderBottomWidth
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.BorderBottomWidth).value;
			}
			set
			{
				this.SetValue(StylePropertyId.BorderBottomWidth, value);
			}
		}

		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x060025C5 RID: 9669 RVA: 0x0009EB98 File Offset: 0x0009CD98
		// (set) Token: 0x060025C6 RID: 9670 RVA: 0x0009EBC2 File Offset: 0x0009CDC2
		public float borderTopLeftRadius
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.BorderTopLeftRadius).value;
			}
			set
			{
				this.SetValue(StylePropertyId.BorderTopLeftRadius, value);
			}
		}

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x060025C7 RID: 9671 RVA: 0x0009EBD4 File Offset: 0x0009CDD4
		// (set) Token: 0x060025C8 RID: 9672 RVA: 0x0009EBFE File Offset: 0x0009CDFE
		public float borderTopRightRadius
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.BorderTopRightRadius).value;
			}
			set
			{
				this.SetValue(StylePropertyId.BorderTopRightRadius, value);
			}
		}

		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x060025C9 RID: 9673 RVA: 0x0009EC10 File Offset: 0x0009CE10
		// (set) Token: 0x060025CA RID: 9674 RVA: 0x0009EC3A File Offset: 0x0009CE3A
		public float borderBottomLeftRadius
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.BorderBottomLeftRadius).value;
			}
			set
			{
				this.SetValue(StylePropertyId.BorderBottomLeftRadius, value);
			}
		}

		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x060025CB RID: 9675 RVA: 0x0009EC4C File Offset: 0x0009CE4C
		// (set) Token: 0x060025CC RID: 9676 RVA: 0x0009EC76 File Offset: 0x0009CE76
		public float borderBottomRightRadius
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.BorderBottomRightRadius).value;
			}
			set
			{
				this.SetValue(StylePropertyId.BorderBottomRightRadius, value);
			}
		}

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x060025CD RID: 9677 RVA: 0x0009EC88 File Offset: 0x0009CE88
		// (set) Token: 0x060025CE RID: 9678 RVA: 0x0009ECB2 File Offset: 0x0009CEB2
		public float opacity
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.Opacity).value;
			}
			set
			{
				this.SetValue(StylePropertyId.Opacity, value);
			}
		}

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x060025CF RID: 9679 RVA: 0x0009ECC4 File Offset: 0x0009CEC4
		// (set) Token: 0x060025D0 RID: 9680 RVA: 0x0009ECEE File Offset: 0x0009CEEE
		public float flexGrow
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.FlexGrow).value;
			}
			set
			{
				this.SetValue(StylePropertyId.FlexGrow, value);
			}
		}

		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x060025D1 RID: 9681 RVA: 0x0009ED00 File Offset: 0x0009CF00
		// (set) Token: 0x060025D2 RID: 9682 RVA: 0x0009ECEE File Offset: 0x0009CEEE
		public float flexShrink
		{
			get
			{
				return this.Values().GetStyleFloat(StylePropertyId.FlexShrink).value;
			}
			set
			{
				this.SetValue(StylePropertyId.FlexGrow, value);
			}
		}

		// Token: 0x060025D3 RID: 9683 RVA: 0x0009ED2C File Offset: 0x0009CF2C
		internal void SetValue(StylePropertyId id, float value)
		{
			StyleValue styleValue = default(StyleValue);
			styleValue.id = id;
			styleValue.number = value;
			this.Values().SetStyleValue(styleValue);
		}

		// Token: 0x060025D4 RID: 9684 RVA: 0x0009ED60 File Offset: 0x0009CF60
		internal void SetValue(StylePropertyId id, Color value)
		{
			StyleValue styleValue = default(StyleValue);
			styleValue.id = id;
			styleValue.color = value;
			this.Values().SetStyleValue(styleValue);
		}

		// Token: 0x060025D5 RID: 9685 RVA: 0x0009ED94 File Offset: 0x0009CF94
		internal StyleValueCollection Values()
		{
			bool flag = this.m_StyleValues == null;
			if (flag)
			{
				this.m_StyleValues = new StyleValueCollection();
			}
			return this.m_StyleValues;
		}

		// Token: 0x0400123B RID: 4667
		internal StyleValueCollection m_StyleValues;
	}
}
