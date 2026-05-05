using System;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements
{
	// Token: 0x0200036D RID: 877
	internal static class TextUtilities
	{
		// Token: 0x06001D2D RID: 7469 RVA: 0x00071E74 File Offset: 0x00070074
		internal static Vector2 MeasureVisualElementTextSize(TextElement te, string textToMeasure, float width, VisualElement.MeasureMode widthMode, float height, VisualElement.MeasureMode heightMode)
		{
			float num = float.NaN;
			float num2 = float.NaN;
			bool flag = textToMeasure == null || !TextUtilities.IsFontAssigned(te);
			Vector2 result;
			if (flag)
			{
				result = new Vector2(num, num2);
			}
			else
			{
				float scaledPixelsPerPoint = te.scaledPixelsPerPoint;
				bool flag2 = scaledPixelsPerPoint <= 0f;
				if (flag2)
				{
					result = Vector2.zero;
				}
				else
				{
					bool flag3 = widthMode == VisualElement.MeasureMode.Exactly;
					if (flag3)
					{
						num = width;
					}
					else
					{
						num = te.uitkTextHandle.ComputeTextWidth(textToMeasure, false, width, height);
						bool flag4 = widthMode == VisualElement.MeasureMode.AtMost;
						if (flag4)
						{
							num = Mathf.Min(num, width);
						}
					}
					bool flag5 = heightMode == VisualElement.MeasureMode.Exactly;
					if (flag5)
					{
						num2 = height;
					}
					else
					{
						num2 = te.uitkTextHandle.ComputeTextHeight(textToMeasure, width, height);
						bool flag6 = heightMode == VisualElement.MeasureMode.AtMost;
						if (flag6)
						{
							num2 = Mathf.Min(num2, height);
						}
					}
					float x = AlignmentUtils.CeilToPixelGrid(num, scaledPixelsPerPoint, 0f);
					float y = AlignmentUtils.CeilToPixelGrid(num2, scaledPixelsPerPoint, 0f);
					Vector2 vector = new Vector2(x, y);
					te.uitkTextHandle.MeasuredSizes = new Vector2(num, num2);
					te.uitkTextHandle.RoundedSizes = vector;
					result = vector;
				}
			}
			return result;
		}

		// Token: 0x06001D2E RID: 7470 RVA: 0x00071F94 File Offset: 0x00070194
		internal static FontAsset GetFontAsset(VisualElement ve)
		{
			bool flag = ve.computedStyle.unityFontDefinition.fontAsset != null;
			FontAsset result;
			if (flag)
			{
				result = ve.computedStyle.unityFontDefinition.fontAsset;
			}
			else
			{
				PanelTextSettings textSettingsFrom = TextUtilities.GetTextSettingsFrom(ve);
				bool flag2 = ve.computedStyle.unityFontDefinition.font != null;
				if (flag2)
				{
					result = textSettingsFrom.GetCachedFontAsset(ve.computedStyle.unityFontDefinition.font);
				}
				else
				{
					bool flag3 = ve.computedStyle.unityFont != null;
					if (flag3)
					{
						result = textSettingsFrom.GetCachedFontAsset(ve.computedStyle.unityFont);
					}
					else
					{
						result = null;
					}
				}
			}
			return result;
		}

		// Token: 0x06001D2F RID: 7471 RVA: 0x00072048 File Offset: 0x00070248
		internal unsafe static Font GetFont(VisualElement ve)
		{
			ComputedStyle computedStyle = *ve.computedStyle;
			bool flag = computedStyle.unityFontDefinition.font != null;
			Font result;
			if (flag)
			{
				result = computedStyle.unityFontDefinition.font;
			}
			else
			{
				bool flag2 = computedStyle.unityFont != null;
				if (flag2)
				{
					result = computedStyle.unityFont;
				}
				else
				{
					FontAsset fontAsset = computedStyle.unityFontDefinition.fontAsset;
					result = ((fontAsset != null) ? fontAsset.sourceFontFile : null);
				}
			}
			return result;
		}

		// Token: 0x06001D30 RID: 7472 RVA: 0x000720CC File Offset: 0x000702CC
		internal static bool IsFontAssigned(VisualElement ve)
		{
			return ve.computedStyle.unityFont != null || !ve.computedStyle.unityFontDefinition.IsEmpty();
		}

		// Token: 0x06001D31 RID: 7473 RVA: 0x0007210C File Offset: 0x0007030C
		internal static PanelTextSettings GetTextSettingsFrom(VisualElement ve)
		{
			RuntimePanel runtimePanel = ve.panel as RuntimePanel;
			bool flag = runtimePanel != null;
			PanelTextSettings result;
			if (flag)
			{
				result = (runtimePanel.panelSettings.textSettings ?? PanelTextSettings.defaultPanelTextSettings);
			}
			else
			{
				result = PanelTextSettings.defaultPanelTextSettings;
			}
			return result;
		}

		// Token: 0x06001D32 RID: 7474 RVA: 0x00072150 File Offset: 0x00070350
		internal static float ConvertPixelUnitsToTextCoreRelativeUnits(VisualElement ve, FontAsset fontAsset)
		{
			float num = 1f / (float)fontAsset.atlasPadding;
			float num2 = (float)fontAsset.faceInfo.pointSize / ve.computedStyle.fontSize.value;
			return num * num2;
		}

		// Token: 0x06001D33 RID: 7475 RVA: 0x0007219C File Offset: 0x0007039C
		internal unsafe static TextCoreSettings GetTextCoreSettingsForElement(VisualElement ve)
		{
			FontAsset fontAsset = TextUtilities.GetFontAsset(ve);
			bool flag = fontAsset == null;
			TextCoreSettings result;
			if (flag)
			{
				result = default(TextCoreSettings);
			}
			else
			{
				IResolvedStyle resolvedStyle = ve.resolvedStyle;
				ComputedStyle computedStyle = *ve.computedStyle;
				float num = TextUtilities.ConvertPixelUnitsToTextCoreRelativeUnits(ve, fontAsset);
				float num2 = Mathf.Clamp(resolvedStyle.unityTextOutlineWidth * num, 0f, 1f);
				float underlaySoftness = Mathf.Clamp(computedStyle.textShadow.blurRadius * num, 0f, 1f);
				float x = (computedStyle.textShadow.offset.x < 0f) ? Mathf.Max(computedStyle.textShadow.offset.x * num, -1f) : Mathf.Min(computedStyle.textShadow.offset.x * num, 1f);
				float y = (computedStyle.textShadow.offset.y < 0f) ? Mathf.Max(computedStyle.textShadow.offset.y * num, -1f) : Mathf.Min(computedStyle.textShadow.offset.y * num, 1f);
				Vector2 underlayOffset = new Vector2(x, y);
				Color color = resolvedStyle.color;
				Color unityTextOutlineColor = resolvedStyle.unityTextOutlineColor;
				bool flag2 = num2 < 1E-30f;
				if (flag2)
				{
					unityTextOutlineColor.a = 0f;
				}
				result = new TextCoreSettings
				{
					faceColor = color,
					outlineColor = unityTextOutlineColor,
					outlineWidth = num2,
					underlayColor = computedStyle.textShadow.color,
					underlayOffset = underlayOffset,
					underlaySoftness = underlaySoftness
				};
			}
			return result;
		}
	}
}
