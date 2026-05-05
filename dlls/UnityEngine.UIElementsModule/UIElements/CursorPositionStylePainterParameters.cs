using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000327 RID: 807
	internal struct CursorPositionStylePainterParameters
	{
		// Token: 0x06001B45 RID: 6981 RVA: 0x0006ACE4 File Offset: 0x00068EE4
		public unsafe static CursorPositionStylePainterParameters GetDefault(VisualElement ve, string text)
		{
			ComputedStyle computedStyle = *ve.computedStyle;
			return new CursorPositionStylePainterParameters
			{
				rect = ve.contentRect,
				text = text,
				font = TextUtilities.GetFont(ve),
				fontSize = (int)computedStyle.fontSize.value,
				fontStyle = computedStyle.unityFontStyleAndWeight,
				anchor = computedStyle.unityTextAlign,
				wordWrapWidth = ((computedStyle.whiteSpace == WhiteSpace.Normal) ? ve.contentRect.width : 0f),
				richText = false,
				cursorIndex = 0
			};
		}

		// Token: 0x06001B46 RID: 6982 RVA: 0x0006AD9C File Offset: 0x00068F9C
		internal TextNativeSettings GetTextNativeSettings(float scaling)
		{
			return new TextNativeSettings
			{
				text = this.text,
				font = this.font,
				size = this.fontSize,
				scaling = scaling,
				style = this.fontStyle,
				color = Color.white,
				anchor = this.anchor,
				wordWrap = true,
				wordWrapWidth = this.wordWrapWidth,
				richText = this.richText
			};
		}

		// Token: 0x04000B58 RID: 2904
		public Rect rect;

		// Token: 0x04000B59 RID: 2905
		public string text;

		// Token: 0x04000B5A RID: 2906
		public Font font;

		// Token: 0x04000B5B RID: 2907
		public int fontSize;

		// Token: 0x04000B5C RID: 2908
		public FontStyle fontStyle;

		// Token: 0x04000B5D RID: 2909
		public TextAnchor anchor;

		// Token: 0x04000B5E RID: 2910
		public float wordWrapWidth;

		// Token: 0x04000B5F RID: 2911
		public bool richText;

		// Token: 0x04000B60 RID: 2912
		public int cursorIndex;
	}
}
