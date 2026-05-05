using System;
using System.Collections.Generic;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x020002F3 RID: 755
	internal class StyleValueCollection
	{
		// Token: 0x06001991 RID: 6545 RVA: 0x00067434 File Offset: 0x00065634
		public StyleLength GetStyleLength(StylePropertyId id)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = this.TryGetStyleValue(id, ref styleValue);
			StyleLength result;
			if (flag)
			{
				result = new StyleLength(styleValue.length, styleValue.keyword);
			}
			else
			{
				result = StyleKeyword.Null;
			}
			return result;
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x00067478 File Offset: 0x00065678
		public StyleFloat GetStyleFloat(StylePropertyId id)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = this.TryGetStyleValue(id, ref styleValue);
			StyleFloat result;
			if (flag)
			{
				result = new StyleFloat(styleValue.number, styleValue.keyword);
			}
			else
			{
				result = StyleKeyword.Null;
			}
			return result;
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x000674BC File Offset: 0x000656BC
		public StyleInt GetStyleInt(StylePropertyId id)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = this.TryGetStyleValue(id, ref styleValue);
			StyleInt result;
			if (flag)
			{
				result = new StyleInt((int)styleValue.number, styleValue.keyword);
			}
			else
			{
				result = StyleKeyword.Null;
			}
			return result;
		}

		// Token: 0x06001994 RID: 6548 RVA: 0x00067500 File Offset: 0x00065700
		public StyleColor GetStyleColor(StylePropertyId id)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = this.TryGetStyleValue(id, ref styleValue);
			StyleColor result;
			if (flag)
			{
				result = new StyleColor(styleValue.color, styleValue.keyword);
			}
			else
			{
				result = StyleKeyword.Null;
			}
			return result;
		}

		// Token: 0x06001995 RID: 6549 RVA: 0x00067544 File Offset: 0x00065744
		public StyleBackground GetStyleBackground(StylePropertyId id)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = this.TryGetStyleValue(id, ref styleValue);
			if (flag)
			{
				Texture2D texture2D = styleValue.resource.IsAllocated ? (styleValue.resource.Target as Texture2D) : null;
				bool flag2 = texture2D != null;
				if (flag2)
				{
					return new StyleBackground(texture2D, styleValue.keyword);
				}
				Sprite sprite = styleValue.resource.IsAllocated ? (styleValue.resource.Target as Sprite) : null;
				bool flag3 = sprite != null;
				if (flag3)
				{
					return new StyleBackground(sprite, styleValue.keyword);
				}
				VectorImage vectorImage = styleValue.resource.IsAllocated ? (styleValue.resource.Target as VectorImage) : null;
				bool flag4 = vectorImage != null;
				if (flag4)
				{
					return new StyleBackground(vectorImage, styleValue.keyword);
				}
			}
			return StyleKeyword.Null;
		}

		// Token: 0x06001996 RID: 6550 RVA: 0x00067640 File Offset: 0x00065840
		public StyleBackgroundPosition GetStyleBackgroundPosition(StylePropertyId id)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = this.TryGetStyleValue(id, ref styleValue);
			StyleBackgroundPosition result;
			if (flag)
			{
				result = new StyleBackgroundPosition(styleValue.position);
			}
			else
			{
				result = StyleKeyword.Null;
			}
			return result;
		}

		// Token: 0x06001997 RID: 6551 RVA: 0x0006767C File Offset: 0x0006587C
		public StyleBackgroundRepeat GetStyleBackgroundRepeat(StylePropertyId id)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = this.TryGetStyleValue(id, ref styleValue);
			StyleBackgroundRepeat result;
			if (flag)
			{
				result = new StyleBackgroundRepeat(styleValue.repeat);
			}
			else
			{
				result = StyleKeyword.Null;
			}
			return result;
		}

		// Token: 0x06001998 RID: 6552 RVA: 0x000676B8 File Offset: 0x000658B8
		public StyleFont GetStyleFont(StylePropertyId id)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = this.TryGetStyleValue(id, ref styleValue);
			StyleFont result;
			if (flag)
			{
				Font v = styleValue.resource.IsAllocated ? (styleValue.resource.Target as Font) : null;
				result = new StyleFont(v, styleValue.keyword);
			}
			else
			{
				result = StyleKeyword.Null;
			}
			return result;
		}

		// Token: 0x06001999 RID: 6553 RVA: 0x00067718 File Offset: 0x00065918
		public StyleFontDefinition GetStyleFontDefinition(StylePropertyId id)
		{
			StyleValue styleValue = default(StyleValue);
			bool flag = this.TryGetStyleValue(id, ref styleValue);
			StyleFontDefinition result;
			if (flag)
			{
				object obj = styleValue.resource.IsAllocated ? styleValue.resource.Target : null;
				result = new StyleFontDefinition(obj, styleValue.keyword);
			}
			else
			{
				result = StyleKeyword.Null;
			}
			return result;
		}

		// Token: 0x0600199A RID: 6554 RVA: 0x00067774 File Offset: 0x00065974
		public bool TryGetStyleValue(StylePropertyId id, ref StyleValue value)
		{
			value.id = StylePropertyId.Unknown;
			foreach (StyleValue styleValue in this.m_Values)
			{
				bool flag = styleValue.id == id;
				if (flag)
				{
					value = styleValue;
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600199B RID: 6555 RVA: 0x000677EC File Offset: 0x000659EC
		public void SetStyleValue(StyleValue value)
		{
			for (int i = 0; i < this.m_Values.Count; i++)
			{
				bool flag = this.m_Values[i].id == value.id;
				if (flag)
				{
					bool flag2 = value.keyword == StyleKeyword.Null;
					if (flag2)
					{
						this.m_Values.RemoveAt(i);
					}
					else
					{
						this.m_Values[i] = value;
					}
					return;
				}
			}
			this.m_Values.Add(value);
		}

		// Token: 0x04000AC2 RID: 2754
		internal List<StyleValue> m_Values = new List<StyleValue>();
	}
}
