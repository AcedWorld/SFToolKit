using System;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements.Experimental
{
	// Token: 0x020004BF RID: 1215
	internal static class Lerp
	{
		// Token: 0x060025EA RID: 9706 RVA: 0x0009EDC8 File Offset: 0x0009CFC8
		public static float Interpolate(float start, float end, float ratio)
		{
			return Mathf.LerpUnclamped(start, end, ratio);
		}

		// Token: 0x060025EB RID: 9707 RVA: 0x0009EDE4 File Offset: 0x0009CFE4
		public static int Interpolate(int start, int end, float ratio)
		{
			return Mathf.RoundToInt(Mathf.LerpUnclamped((float)start, (float)end, ratio));
		}

		// Token: 0x060025EC RID: 9708 RVA: 0x0009EE08 File Offset: 0x0009D008
		public static Rect Interpolate(Rect r1, Rect r2, float ratio)
		{
			return new Rect(Mathf.LerpUnclamped(r1.x, r2.x, ratio), Mathf.LerpUnclamped(r1.y, r2.y, ratio), Mathf.LerpUnclamped(r1.width, r2.width, ratio), Mathf.LerpUnclamped(r1.height, r2.height, ratio));
		}

		// Token: 0x060025ED RID: 9709 RVA: 0x0009EE70 File Offset: 0x0009D070
		public static Color Interpolate(Color start, Color end, float ratio)
		{
			return Color.LerpUnclamped(start, end, ratio);
		}

		// Token: 0x060025EE RID: 9710 RVA: 0x0009EE8C File Offset: 0x0009D08C
		public static Vector2 Interpolate(Vector2 start, Vector2 end, float ratio)
		{
			return Vector2.LerpUnclamped(start, end, ratio);
		}

		// Token: 0x060025EF RID: 9711 RVA: 0x0009EEA8 File Offset: 0x0009D0A8
		public static Vector3 Interpolate(Vector3 start, Vector3 end, float ratio)
		{
			return Vector3.LerpUnclamped(start, end, ratio);
		}

		// Token: 0x060025F0 RID: 9712 RVA: 0x0009EEC4 File Offset: 0x0009D0C4
		public static Quaternion Interpolate(Quaternion start, Quaternion end, float ratio)
		{
			return Quaternion.SlerpUnclamped(start, end, ratio);
		}

		// Token: 0x060025F1 RID: 9713 RVA: 0x0009EEE0 File Offset: 0x0009D0E0
		internal static StyleValues Interpolate(StyleValues start, StyleValues end, float ratio)
		{
			StyleValues result = default(StyleValues);
			bool flag = end.m_StyleValues != null;
			if (flag)
			{
				foreach (StyleValue styleValue in end.m_StyleValues.m_Values)
				{
					StyleValue styleValue2 = default(StyleValue);
					bool flag2 = !start.m_StyleValues.TryGetStyleValue(styleValue.id, ref styleValue2);
					if (flag2)
					{
						throw new ArgumentException("Start StyleValues must contain the same values as end values. Missing property:" + styleValue.id.ToString());
					}
					StylePropertyId id = styleValue.id;
					StylePropertyId stylePropertyId = id;
					if (stylePropertyId <= StylePropertyId.Width)
					{
						if (stylePropertyId - StylePropertyId.Custom <= 1)
						{
							goto IL_281;
						}
						switch (stylePropertyId)
						{
						case StylePropertyId.Color:
							goto IL_25C;
						case StylePropertyId.FontSize:
							goto IL_237;
						case StylePropertyId.LetterSpacing:
						case StylePropertyId.TextShadow:
						case StylePropertyId.UnityFont:
						case StylePropertyId.UnityFontDefinition:
						case StylePropertyId.UnityFontStyleAndWeight:
						case StylePropertyId.UnityParagraphSpacing:
						case StylePropertyId.UnityTextAlign:
						case StylePropertyId.UnityTextOutlineColor:
						case StylePropertyId.UnityTextOutlineWidth:
						case StylePropertyId.Visibility:
						case StylePropertyId.WhiteSpace:
							goto IL_281;
						default:
							switch (stylePropertyId)
							{
							case StylePropertyId.AlignContent:
							case StylePropertyId.AlignItems:
							case StylePropertyId.AlignSelf:
							case StylePropertyId.Display:
							case StylePropertyId.FlexDirection:
							case StylePropertyId.FlexWrap:
							case StylePropertyId.JustifyContent:
							case StylePropertyId.Position:
								goto IL_281;
							case StylePropertyId.BorderBottomWidth:
							case StylePropertyId.BorderLeftWidth:
							case StylePropertyId.BorderRightWidth:
							case StylePropertyId.BorderTopWidth:
							case StylePropertyId.Bottom:
							case StylePropertyId.FlexBasis:
							case StylePropertyId.FlexGrow:
							case StylePropertyId.FlexShrink:
							case StylePropertyId.Height:
							case StylePropertyId.Left:
							case StylePropertyId.MarginBottom:
							case StylePropertyId.MarginLeft:
							case StylePropertyId.MarginRight:
							case StylePropertyId.MarginTop:
							case StylePropertyId.MaxHeight:
							case StylePropertyId.MaxWidth:
							case StylePropertyId.MinHeight:
							case StylePropertyId.MinWidth:
							case StylePropertyId.PaddingBottom:
							case StylePropertyId.PaddingLeft:
							case StylePropertyId.PaddingRight:
							case StylePropertyId.PaddingTop:
							case StylePropertyId.Right:
							case StylePropertyId.Top:
							case StylePropertyId.Width:
								goto IL_237;
							default:
								goto IL_281;
							}
							break;
						}
					}
					else
					{
						switch (stylePropertyId)
						{
						case StylePropertyId.Cursor:
						case StylePropertyId.TextOverflow:
						case StylePropertyId.UnityOverflowClipBox:
						case StylePropertyId.UnitySliceBottom:
						case StylePropertyId.UnitySliceLeft:
						case StylePropertyId.UnitySliceRight:
						case StylePropertyId.UnitySliceScale:
						case StylePropertyId.UnitySliceTop:
						case StylePropertyId.UnityTextOverflowPosition:
							goto IL_281;
						case StylePropertyId.UnityBackgroundImageTintColor:
							goto IL_25C;
						default:
							switch (stylePropertyId)
							{
							case StylePropertyId.BackgroundPosition:
							case StylePropertyId.BorderRadius:
							case StylePropertyId.BorderWidth:
							case StylePropertyId.Flex:
							case StylePropertyId.Margin:
							case StylePropertyId.Padding:
							case StylePropertyId.Transition:
							case StylePropertyId.UnityBackgroundScaleMode:
								goto IL_281;
							case StylePropertyId.BorderColor:
								goto IL_25C;
							default:
								switch (stylePropertyId)
								{
								case StylePropertyId.BackgroundColor:
									goto IL_25C;
								case StylePropertyId.BackgroundImage:
								case StylePropertyId.BackgroundPositionX:
								case StylePropertyId.BackgroundPositionY:
								case StylePropertyId.BackgroundRepeat:
								case StylePropertyId.BackgroundSize:
								case StylePropertyId.BorderBottomColor:
								case StylePropertyId.BorderLeftColor:
								case StylePropertyId.BorderRightColor:
								case StylePropertyId.BorderTopColor:
								case StylePropertyId.Overflow:
									goto IL_281;
								case StylePropertyId.BorderBottomLeftRadius:
								case StylePropertyId.BorderBottomRightRadius:
								case StylePropertyId.BorderTopLeftRadius:
								case StylePropertyId.BorderTopRightRadius:
								case StylePropertyId.Opacity:
									goto IL_237;
								default:
									goto IL_281;
								}
								break;
							}
							break;
						}
					}
					continue;
					IL_237:
					result.SetValue(styleValue.id, Lerp.Interpolate(styleValue2.number, styleValue.number, ratio));
					continue;
					IL_25C:
					result.SetValue(styleValue.id, Lerp.Interpolate(styleValue2.color, styleValue.color, ratio));
					continue;
					IL_281:
					throw new ArgumentException("Style Value can't be animated");
				}
			}
			return result;
		}
	}
}
