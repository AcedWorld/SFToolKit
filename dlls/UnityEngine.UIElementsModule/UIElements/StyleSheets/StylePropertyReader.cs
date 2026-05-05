using System;
using System.Collections.Generic;
using UnityEngine.TextCore.Text;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x0200048F RID: 1167
	internal class StylePropertyReader
	{
		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x06002464 RID: 9316 RVA: 0x00097353 File Offset: 0x00095553
		// (set) Token: 0x06002465 RID: 9317 RVA: 0x0009735B File Offset: 0x0009555B
		public StyleProperty property { get; private set; }

		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x06002466 RID: 9318 RVA: 0x00097364 File Offset: 0x00095564
		// (set) Token: 0x06002467 RID: 9319 RVA: 0x0009736C File Offset: 0x0009556C
		public StylePropertyId propertyId { get; private set; }

		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x06002468 RID: 9320 RVA: 0x00097375 File Offset: 0x00095575
		// (set) Token: 0x06002469 RID: 9321 RVA: 0x0009737D File Offset: 0x0009557D
		public int valueCount { get; private set; }

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x0600246A RID: 9322 RVA: 0x00097386 File Offset: 0x00095586
		// (set) Token: 0x0600246B RID: 9323 RVA: 0x0009738E File Offset: 0x0009558E
		public float dpiScaling { get; private set; }

		// Token: 0x0600246C RID: 9324 RVA: 0x00097398 File Offset: 0x00095598
		public void SetContext(StyleSheet sheet, StyleComplexSelector selector, StyleVariableContext varContext, float dpiScaling = 1f)
		{
			this.m_Sheet = sheet;
			this.m_Properties = selector.rule.properties;
			this.m_PropertyIds = StyleSheetCache.GetPropertyIds(sheet, selector.ruleIndex);
			this.m_Resolver.variableContext = varContext;
			this.dpiScaling = dpiScaling;
			this.LoadProperties();
		}

		// Token: 0x0600246D RID: 9325 RVA: 0x000973ED File Offset: 0x000955ED
		public void SetInlineContext(StyleSheet sheet, StyleProperty[] properties, StylePropertyId[] propertyIds, float dpiScaling = 1f)
		{
			this.m_Sheet = sheet;
			this.m_Properties = properties;
			this.m_PropertyIds = propertyIds;
			this.dpiScaling = dpiScaling;
			this.LoadProperties();
		}

		// Token: 0x0600246E RID: 9326 RVA: 0x00097418 File Offset: 0x00095618
		public StylePropertyId MoveNextProperty()
		{
			this.m_CurrentPropertyIndex++;
			this.m_CurrentValueIndex += this.valueCount;
			this.SetCurrentProperty();
			return this.propertyId;
		}

		// Token: 0x0600246F RID: 9327 RVA: 0x00097458 File Offset: 0x00095658
		public StylePropertyValue GetValue(int index)
		{
			return this.m_Values[this.m_CurrentValueIndex + index];
		}

		// Token: 0x06002470 RID: 9328 RVA: 0x00097480 File Offset: 0x00095680
		public StyleValueType GetValueType(int index)
		{
			return this.m_Values[this.m_CurrentValueIndex + index].handle.valueType;
		}

		// Token: 0x06002471 RID: 9329 RVA: 0x000974B4 File Offset: 0x000956B4
		public bool IsValueType(int index, StyleValueType type)
		{
			return this.m_Values[this.m_CurrentValueIndex + index].handle.valueType == type;
		}

		// Token: 0x06002472 RID: 9330 RVA: 0x000974EC File Offset: 0x000956EC
		public bool IsKeyword(int index, StyleValueKeyword keyword)
		{
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			return stylePropertyValue.handle.valueType == StyleValueType.Keyword && stylePropertyValue.handle.valueIndex == (int)keyword;
		}

		// Token: 0x06002473 RID: 9331 RVA: 0x00097534 File Offset: 0x00095734
		public string ReadAsString(int index)
		{
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			return stylePropertyValue.sheet.ReadAsString(stylePropertyValue.handle);
		}

		// Token: 0x06002474 RID: 9332 RVA: 0x0009756C File Offset: 0x0009576C
		public Length ReadLength(int index)
		{
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			bool flag = stylePropertyValue.handle.valueType == StyleValueType.Keyword;
			Length result;
			if (flag)
			{
				StyleValueKeyword valueIndex = (StyleValueKeyword)stylePropertyValue.handle.valueIndex;
				StyleValueKeyword styleValueKeyword = valueIndex;
				StyleValueKeyword styleValueKeyword2 = styleValueKeyword;
				if (styleValueKeyword2 != StyleValueKeyword.Auto)
				{
					if (styleValueKeyword2 != StyleValueKeyword.None)
					{
						result = default(Length);
					}
					else
					{
						result = Length.None();
					}
				}
				else
				{
					result = Length.Auto();
				}
			}
			else
			{
				result = stylePropertyValue.sheet.ReadDimension(stylePropertyValue.handle).ToLength();
			}
			return result;
		}

		// Token: 0x06002475 RID: 9333 RVA: 0x00097604 File Offset: 0x00095804
		public TimeValue ReadTimeValue(int index)
		{
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			return stylePropertyValue.sheet.ReadDimension(stylePropertyValue.handle).ToTime();
		}

		// Token: 0x06002476 RID: 9334 RVA: 0x00097644 File Offset: 0x00095844
		public Translate ReadTranslate(int index)
		{
			StylePropertyValue val = this.m_Values[this.m_CurrentValueIndex + index];
			StylePropertyValue val2 = (this.valueCount > 1) ? this.m_Values[this.m_CurrentValueIndex + index + 1] : default(StylePropertyValue);
			StylePropertyValue val3 = (this.valueCount > 2) ? this.m_Values[this.m_CurrentValueIndex + index + 2] : default(StylePropertyValue);
			return StylePropertyReader.ReadTranslate(this.valueCount, val, val2, val3);
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x000976D0 File Offset: 0x000958D0
		public TransformOrigin ReadTransformOrigin(int index)
		{
			StylePropertyValue val = this.m_Values[this.m_CurrentValueIndex + index];
			StylePropertyValue val2 = (this.valueCount > 1) ? this.m_Values[this.m_CurrentValueIndex + index + 1] : default(StylePropertyValue);
			StylePropertyValue zVvalue = (this.valueCount > 2) ? this.m_Values[this.m_CurrentValueIndex + index + 2] : default(StylePropertyValue);
			return StylePropertyReader.ReadTransformOrigin(this.valueCount, val, val2, zVvalue);
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x0009775C File Offset: 0x0009595C
		public Rotate ReadRotate(int index)
		{
			StylePropertyValue val = this.m_Values[this.m_CurrentValueIndex + index];
			StylePropertyValue val2 = (this.valueCount > 1) ? this.m_Values[this.m_CurrentValueIndex + index + 1] : default(StylePropertyValue);
			StylePropertyValue val3 = (this.valueCount > 2) ? this.m_Values[this.m_CurrentValueIndex + index + 2] : default(StylePropertyValue);
			StylePropertyValue val4 = (this.valueCount > 3) ? this.m_Values[this.m_CurrentValueIndex + index + 3] : default(StylePropertyValue);
			return StylePropertyReader.ReadRotate(this.valueCount, val, val2, val3, val4);
		}

		// Token: 0x06002479 RID: 9337 RVA: 0x00097814 File Offset: 0x00095A14
		public Scale ReadScale(int index)
		{
			StylePropertyValue val = this.m_Values[this.m_CurrentValueIndex + index];
			StylePropertyValue val2 = (this.valueCount > 1) ? this.m_Values[this.m_CurrentValueIndex + index + 1] : default(StylePropertyValue);
			StylePropertyValue val3 = (this.valueCount > 2) ? this.m_Values[this.m_CurrentValueIndex + index + 2] : default(StylePropertyValue);
			return StylePropertyReader.ReadScale(this.valueCount, val, val2, val3);
		}

		// Token: 0x0600247A RID: 9338 RVA: 0x000978A0 File Offset: 0x00095AA0
		public float ReadFloat(int index)
		{
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			return stylePropertyValue.sheet.ReadFloat(stylePropertyValue.handle);
		}

		// Token: 0x0600247B RID: 9339 RVA: 0x000978D8 File Offset: 0x00095AD8
		public int ReadInt(int index)
		{
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			return (int)stylePropertyValue.sheet.ReadFloat(stylePropertyValue.handle);
		}

		// Token: 0x0600247C RID: 9340 RVA: 0x00097910 File Offset: 0x00095B10
		public Color ReadColor(int index)
		{
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			Color result = Color.clear;
			bool flag = stylePropertyValue.handle.valueType == StyleValueType.Enum;
			if (flag)
			{
				string text = stylePropertyValue.sheet.ReadAsString(stylePropertyValue.handle);
				StyleSheetColor.TryGetColor(text.ToLowerInvariant(), out result);
			}
			else
			{
				result = stylePropertyValue.sheet.ReadColor(stylePropertyValue.handle);
			}
			return result;
		}

		// Token: 0x0600247D RID: 9341 RVA: 0x0009798C File Offset: 0x00095B8C
		public int ReadEnum(StyleEnumType enumType, int index)
		{
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			StyleValueHandle handle = stylePropertyValue.handle;
			bool flag = handle.valueType == StyleValueType.Keyword;
			string value;
			if (flag)
			{
				StyleValueKeyword svk = stylePropertyValue.sheet.ReadKeyword(handle);
				value = svk.ToUssString();
			}
			else
			{
				value = stylePropertyValue.sheet.ReadEnum(handle);
			}
			int result;
			StylePropertyUtil.TryGetEnumIntValue(enumType, value, out result);
			return result;
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x00097A04 File Offset: 0x00095C04
		public FontDefinition ReadFontDefinition(int index)
		{
			FontAsset fontAsset = null;
			Font font = null;
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			StyleValueType valueType = stylePropertyValue.handle.valueType;
			StyleValueType styleValueType = valueType;
			if (styleValueType != StyleValueType.Keyword)
			{
				if (styleValueType != StyleValueType.ResourcePath)
				{
					if (styleValueType != StyleValueType.AssetReference)
					{
						Debug.LogWarning("Invalid value for font " + stylePropertyValue.handle.valueType.ToString());
					}
					else
					{
						font = (stylePropertyValue.sheet.ReadAssetReference(stylePropertyValue.handle) as Font);
						bool flag = font == null;
						if (flag)
						{
							fontAsset = (stylePropertyValue.sheet.ReadAssetReference(stylePropertyValue.handle) as FontAsset);
						}
					}
				}
				else
				{
					string text = stylePropertyValue.sheet.ReadResourcePath(stylePropertyValue.handle);
					bool flag2 = !string.IsNullOrEmpty(text);
					if (flag2)
					{
						font = (Panel.LoadResource(text, typeof(Font), this.dpiScaling) as Font);
						bool flag3 = font == null;
						if (flag3)
						{
							fontAsset = (Panel.LoadResource(text, typeof(FontAsset), this.dpiScaling) as FontAsset);
						}
					}
					bool flag4 = fontAsset == null && font == null;
					if (flag4)
					{
						Debug.LogWarning(string.Format("Font not found for path: {0}", text));
					}
				}
			}
			else
			{
				bool flag5 = stylePropertyValue.handle.valueIndex != 6;
				if (flag5)
				{
					string str = "Invalid keyword for font ";
					StyleValueKeyword valueIndex = (StyleValueKeyword)stylePropertyValue.handle.valueIndex;
					Debug.LogWarning(str + valueIndex.ToString());
				}
			}
			bool flag6 = font != null;
			FontDefinition result;
			if (flag6)
			{
				result = FontDefinition.FromFont(font);
			}
			else
			{
				bool flag7 = fontAsset != null;
				if (flag7)
				{
					result = FontDefinition.FromSDFFont(fontAsset);
				}
				else
				{
					result = default(FontDefinition);
				}
			}
			return result;
		}

		// Token: 0x0600247F RID: 9343 RVA: 0x00097BE4 File Offset: 0x00095DE4
		public Font ReadFont(int index)
		{
			Font font = null;
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			StyleValueType valueType = stylePropertyValue.handle.valueType;
			StyleValueType styleValueType = valueType;
			if (styleValueType != StyleValueType.Keyword)
			{
				if (styleValueType != StyleValueType.ResourcePath)
				{
					if (styleValueType != StyleValueType.AssetReference)
					{
						Debug.LogWarning("Invalid value for font " + stylePropertyValue.handle.valueType.ToString());
					}
					else
					{
						font = (stylePropertyValue.sheet.ReadAssetReference(stylePropertyValue.handle) as Font);
					}
				}
				else
				{
					string text = stylePropertyValue.sheet.ReadResourcePath(stylePropertyValue.handle);
					bool flag = !string.IsNullOrEmpty(text);
					if (flag)
					{
						font = (Panel.LoadResource(text, typeof(Font), this.dpiScaling) as Font);
					}
					bool flag2 = font == null;
					if (flag2)
					{
						Debug.LogWarning(string.Format("Font not found for path: {0}", text));
					}
				}
			}
			else
			{
				bool flag3 = stylePropertyValue.handle.valueIndex != 6;
				if (flag3)
				{
					string str = "Invalid keyword for font ";
					StyleValueKeyword valueIndex = (StyleValueKeyword)stylePropertyValue.handle.valueIndex;
					Debug.LogWarning(str + valueIndex.ToString());
				}
			}
			return font;
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x00097D28 File Offset: 0x00095F28
		public Background ReadBackground(int index)
		{
			ImageSource imageSource = default(ImageSource);
			StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
			bool flag = stylePropertyValue.handle.valueType == StyleValueType.Keyword;
			if (flag)
			{
				bool flag2 = stylePropertyValue.handle.valueIndex != 6;
				if (flag2)
				{
					string str = "Invalid keyword for image source ";
					StyleValueKeyword valueIndex = (StyleValueKeyword)stylePropertyValue.handle.valueIndex;
					Debug.LogWarning(str + valueIndex.ToString());
				}
			}
			else
			{
				bool flag3 = !StylePropertyReader.TryGetImageSourceFromValue(stylePropertyValue, this.dpiScaling, out imageSource);
				if (flag3)
				{
				}
			}
			bool flag4 = imageSource.texture != null;
			Background result;
			if (flag4)
			{
				result = Background.FromTexture2D(imageSource.texture);
			}
			else
			{
				bool flag5 = imageSource.sprite != null;
				if (flag5)
				{
					result = Background.FromSprite(imageSource.sprite);
				}
				else
				{
					bool flag6 = imageSource.vectorImage != null;
					if (flag6)
					{
						result = Background.FromVectorImage(imageSource.vectorImage);
					}
					else
					{
						bool flag7 = imageSource.renderTexture != null;
						if (flag7)
						{
							result = Background.FromRenderTexture(imageSource.renderTexture);
						}
						else
						{
							result = default(Background);
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x00097E58 File Offset: 0x00096058
		public Cursor ReadCursor(int index)
		{
			float x = 0f;
			float y = 0f;
			int defaultCursorId = 0;
			Texture2D texture = null;
			StyleValueType valueType = this.GetValueType(index);
			bool flag = valueType == StyleValueType.ResourcePath || valueType == StyleValueType.AssetReference || valueType == StyleValueType.ScalableImage || valueType == StyleValueType.MissingAssetReference;
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = this.valueCount < 1;
				if (flag3)
				{
					Debug.LogWarning(string.Format("USS 'cursor' has invalid value at {0}.", index));
				}
				else
				{
					ImageSource imageSource = default(ImageSource);
					StylePropertyValue value = this.GetValue(index);
					bool flag4 = StylePropertyReader.TryGetImageSourceFromValue(value, this.dpiScaling, out imageSource);
					if (flag4)
					{
						texture = imageSource.texture;
						bool flag5 = this.valueCount >= 3;
						if (flag5)
						{
							StylePropertyValue value2 = this.GetValue(index + 1);
							StylePropertyValue value3 = this.GetValue(index + 2);
							bool flag6 = value2.handle.valueType != StyleValueType.Float || value3.handle.valueType != StyleValueType.Float;
							if (flag6)
							{
								Debug.LogWarning("USS 'cursor' property requires two integers for the hot spot value.");
							}
							else
							{
								x = value2.sheet.ReadFloat(value2.handle);
								y = value3.sheet.ReadFloat(value3.handle);
							}
						}
					}
				}
			}
			else
			{
				bool flag7 = StylePropertyReader.getCursorIdFunc != null;
				if (flag7)
				{
					StylePropertyValue value4 = this.GetValue(index);
					defaultCursorId = StylePropertyReader.getCursorIdFunc(value4.sheet, value4.handle);
				}
			}
			return new Cursor
			{
				texture = texture,
				hotspot = new Vector2(x, y),
				defaultCursorId = defaultCursorId
			};
		}

		// Token: 0x06002482 RID: 9346 RVA: 0x00097FFC File Offset: 0x000961FC
		public TextShadow ReadTextShadow(int index)
		{
			float x = 0f;
			float y = 0f;
			float blurRadius = 0f;
			Color color = Color.clear;
			bool flag = this.valueCount >= 2;
			if (flag)
			{
				int num = index;
				StyleValueType valueType = this.GetValueType(num);
				bool flag2 = false;
				bool flag3 = valueType == StyleValueType.Color || valueType == StyleValueType.Enum;
				if (flag3)
				{
					color = this.ReadColor(num++);
					flag2 = true;
				}
				bool flag4 = num + 1 < this.valueCount;
				if (flag4)
				{
					valueType = this.GetValueType(num);
					StyleValueType valueType2 = this.GetValueType(num + 1);
					bool flag5 = (valueType == StyleValueType.Dimension || valueType == StyleValueType.Float) && (valueType2 == StyleValueType.Dimension || valueType2 == StyleValueType.Float);
					if (flag5)
					{
						StylePropertyValue value = this.GetValue(num++);
						StylePropertyValue value2 = this.GetValue(num++);
						x = value.sheet.ReadDimension(value.handle).value;
						y = value2.sheet.ReadDimension(value2.handle).value;
					}
				}
				bool flag6 = num < this.valueCount;
				if (flag6)
				{
					valueType = this.GetValueType(num);
					bool flag7 = valueType == StyleValueType.Dimension || valueType == StyleValueType.Float;
					if (flag7)
					{
						StylePropertyValue value3 = this.GetValue(num++);
						blurRadius = value3.sheet.ReadDimension(value3.handle).value;
					}
					else
					{
						bool flag8 = valueType == StyleValueType.Color || valueType == StyleValueType.Enum;
						if (flag8)
						{
							bool flag9 = !flag2;
							if (flag9)
							{
								color = this.ReadColor(num);
							}
						}
					}
				}
				bool flag10 = num < this.valueCount;
				if (flag10)
				{
					valueType = this.GetValueType(num);
					bool flag11 = valueType == StyleValueType.Color || valueType == StyleValueType.Enum;
					if (flag11)
					{
						bool flag12 = !flag2;
						if (flag12)
						{
							color = this.ReadColor(num);
						}
					}
				}
			}
			return new TextShadow
			{
				offset = new Vector2(x, y),
				blurRadius = blurRadius,
				color = color
			};
		}

		// Token: 0x06002483 RID: 9347 RVA: 0x0009820C File Offset: 0x0009640C
		public BackgroundPosition ReadBackgroundPositionX(int index)
		{
			return this.ReadBackgroundPosition(index, BackgroundPositionKeyword.Left);
		}

		// Token: 0x06002484 RID: 9348 RVA: 0x00098228 File Offset: 0x00096428
		public BackgroundPosition ReadBackgroundPositionY(int index)
		{
			return this.ReadBackgroundPosition(index, BackgroundPositionKeyword.Top);
		}

		// Token: 0x06002485 RID: 9349 RVA: 0x00098244 File Offset: 0x00096444
		private BackgroundPosition ReadBackgroundPosition(int index, BackgroundPositionKeyword keyword)
		{
			StylePropertyValue val = this.m_Values[this.m_CurrentValueIndex + index];
			StylePropertyValue val2 = (this.valueCount > 1) ? this.m_Values[this.m_CurrentValueIndex + index + 1] : default(StylePropertyValue);
			return StylePropertyReader.ReadBackgroundPosition(this.valueCount, val, val2, keyword);
		}

		// Token: 0x06002486 RID: 9350 RVA: 0x000982A4 File Offset: 0x000964A4
		public BackgroundRepeat ReadBackgroundRepeat(int index)
		{
			StylePropertyValue val = this.m_Values[this.m_CurrentValueIndex + index];
			StylePropertyValue val2 = (this.valueCount > 1) ? this.m_Values[this.m_CurrentValueIndex + index + 1] : default(StylePropertyValue);
			return StylePropertyReader.ReadBackgroundRepeat(this.valueCount, val, val2);
		}

		// Token: 0x06002487 RID: 9351 RVA: 0x00098304 File Offset: 0x00096504
		public BackgroundSize ReadBackgroundSize(int index)
		{
			StylePropertyValue val = this.m_Values[this.m_CurrentValueIndex + index];
			StylePropertyValue val2 = (this.valueCount > 1) ? this.m_Values[this.m_CurrentValueIndex + index + 1] : default(StylePropertyValue);
			return StylePropertyReader.ReadBackgroundSize(this.valueCount, val, val2);
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x00098364 File Offset: 0x00096564
		public void ReadListEasingFunction(List<EasingFunction> list, int index)
		{
			list.Clear();
			do
			{
				StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
				StyleValueHandle handle = stylePropertyValue.handle;
				bool flag = handle.valueType == StyleValueType.Enum;
				if (flag)
				{
					string value = stylePropertyValue.sheet.ReadEnum(handle);
					int mode;
					StylePropertyUtil.TryGetEnumIntValue(StyleEnumType.EasingMode, value, out mode);
					list.Add(new EasingFunction((EasingMode)mode));
					index++;
				}
				bool flag2 = index < this.valueCount;
				if (flag2)
				{
					bool flag3 = this.m_Values[this.m_CurrentValueIndex + index].handle.valueType == StyleValueType.CommaSeparator;
					if (flag3)
					{
						index++;
					}
				}
			}
			while (index < this.valueCount);
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x00098424 File Offset: 0x00096624
		public void ReadListTimeValue(List<TimeValue> list, int index)
		{
			list.Clear();
			do
			{
				StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
				TimeValue item = stylePropertyValue.sheet.ReadDimension(stylePropertyValue.handle).ToTime();
				list.Add(item);
				index++;
				bool flag = index < this.valueCount;
				if (flag)
				{
					bool flag2 = this.m_Values[this.m_CurrentValueIndex + index].handle.valueType == StyleValueType.CommaSeparator;
					if (flag2)
					{
						index++;
					}
				}
			}
			while (index < this.valueCount);
		}

		// Token: 0x0600248A RID: 9354 RVA: 0x000984C8 File Offset: 0x000966C8
		public void ReadListStylePropertyName(List<StylePropertyName> list, int index)
		{
			list.Clear();
			do
			{
				StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
				string name = stylePropertyValue.sheet.ReadAsString(stylePropertyValue.handle);
				list.Add(new StylePropertyName(name));
				index++;
				bool flag = index < this.valueCount;
				if (flag)
				{
					bool flag2 = this.m_Values[this.m_CurrentValueIndex + index].handle.valueType == StyleValueType.CommaSeparator;
					if (flag2)
					{
						index++;
					}
				}
			}
			while (index < this.valueCount);
		}

		// Token: 0x0600248B RID: 9355 RVA: 0x00098568 File Offset: 0x00096768
		public void ReadListString(List<string> list, int index)
		{
			list.Clear();
			do
			{
				StylePropertyValue stylePropertyValue = this.m_Values[this.m_CurrentValueIndex + index];
				string item = stylePropertyValue.sheet.ReadAsString(stylePropertyValue.handle);
				list.Add(item);
				index++;
				bool flag = index < this.valueCount;
				if (flag)
				{
					bool flag2 = this.m_Values[this.m_CurrentValueIndex + index].handle.valueType == StyleValueType.CommaSeparator;
					if (flag2)
					{
						index++;
					}
				}
			}
			while (index < this.valueCount);
		}

		// Token: 0x0600248C RID: 9356 RVA: 0x00098604 File Offset: 0x00096804
		private void LoadProperties()
		{
			this.m_CurrentPropertyIndex = 0;
			this.m_CurrentValueIndex = 0;
			this.m_Values.Clear();
			this.m_ValueCount.Clear();
			foreach (StyleProperty styleProperty in this.m_Properties)
			{
				int num = 0;
				bool flag = true;
				bool requireVariableResolve = styleProperty.requireVariableResolve;
				if (requireVariableResolve)
				{
					this.m_Resolver.Init(styleProperty, this.m_Sheet, styleProperty.values);
					int num2 = 0;
					while (num2 < styleProperty.values.Length && flag)
					{
						StyleValueHandle handle = styleProperty.values[num2];
						bool flag2 = handle.IsVarFunction();
						if (flag2)
						{
							flag = this.m_Resolver.ResolveVarFunction(ref num2);
						}
						else
						{
							this.m_Resolver.AddValue(handle);
						}
						num2++;
					}
					bool flag3 = flag && this.m_Resolver.ValidateResolvedValues();
					if (flag3)
					{
						this.m_Values.AddRange(this.m_Resolver.resolvedValues);
						num += this.m_Resolver.resolvedValues.Count;
					}
					else
					{
						StyleValueHandle handle2 = new StyleValueHandle
						{
							valueType = StyleValueType.Keyword,
							valueIndex = 3
						};
						this.m_Values.Add(new StylePropertyValue
						{
							sheet = this.m_Sheet,
							handle = handle2
						});
						num++;
					}
				}
				else
				{
					num = styleProperty.values.Length;
					for (int j = 0; j < num; j++)
					{
						this.m_Values.Add(new StylePropertyValue
						{
							sheet = this.m_Sheet,
							handle = styleProperty.values[j]
						});
					}
				}
				this.m_ValueCount.Add(num);
			}
			this.SetCurrentProperty();
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x000987F0 File Offset: 0x000969F0
		private void SetCurrentProperty()
		{
			bool flag = this.m_CurrentPropertyIndex < this.m_PropertyIds.Length;
			if (flag)
			{
				this.property = this.m_Properties[this.m_CurrentPropertyIndex];
				this.propertyId = this.m_PropertyIds[this.m_CurrentPropertyIndex];
				this.valueCount = this.m_ValueCount[this.m_CurrentPropertyIndex];
			}
			else
			{
				this.property = null;
				this.propertyId = StylePropertyId.Unknown;
				this.valueCount = 0;
			}
		}

		// Token: 0x0600248E RID: 9358 RVA: 0x00098870 File Offset: 0x00096A70
		public static TransformOrigin ReadTransformOrigin(int valCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue zVvalue)
		{
			Length x = Length.Percent(50f);
			Length y = Length.Percent(50f);
			float z = 0f;
			switch (valCount)
			{
			case 1:
			{
				bool flag;
				bool flag2;
				Length length = StylePropertyReader.ReadTransformOriginEnum(val1, out flag, out flag2);
				bool flag3 = flag2;
				if (flag3)
				{
					x = length;
				}
				else
				{
					y = length;
				}
				goto IL_F3;
			}
			case 2:
				break;
			case 3:
			{
				bool flag4 = zVvalue.handle.valueType == StyleValueType.Dimension || zVvalue.handle.valueType == StyleValueType.Float;
				if (flag4)
				{
					Dimension dimension = zVvalue.sheet.ReadDimension(zVvalue.handle);
					z = dimension.value;
				}
				break;
			}
			default:
				goto IL_F3;
			}
			bool flag5;
			bool flag6;
			Length length2 = StylePropertyReader.ReadTransformOriginEnum(val1, out flag5, out flag6);
			bool flag7;
			bool flag8;
			Length length3 = StylePropertyReader.ReadTransformOriginEnum(val2, out flag7, out flag8);
			bool flag9 = !flag6 || !flag7;
			if (flag9)
			{
				bool flag10 = flag8 && flag5;
				if (flag10)
				{
					x = length3;
					y = length2;
				}
			}
			else
			{
				x = length2;
				y = length3;
			}
			IL_F3:
			return new TransformOrigin(x, y, z);
		}

		// Token: 0x0600248F RID: 9359 RVA: 0x00098980 File Offset: 0x00096B80
		private static Length ReadTransformOriginEnum(StylePropertyValue value, out bool isVertical, out bool isHorizontal)
		{
			bool flag = value.handle.valueType == StyleValueType.Enum;
			if (flag)
			{
				switch (StylePropertyReader.ReadEnum(StyleEnumType.TransformOriginOffset, value))
				{
				case 1:
					isVertical = false;
					isHorizontal = true;
					return Length.Percent(0f);
				case 2:
					isVertical = false;
					isHorizontal = true;
					return Length.Percent(100f);
				case 3:
					isVertical = true;
					isHorizontal = false;
					return Length.Percent(0f);
				case 4:
					isVertical = true;
					isHorizontal = false;
					return Length.Percent(100f);
				case 5:
					isVertical = true;
					isHorizontal = true;
					return Length.Percent(50f);
				}
			}
			else
			{
				bool flag2 = value.handle.valueType == StyleValueType.Dimension || value.handle.valueType == StyleValueType.Float;
				if (flag2)
				{
					isVertical = true;
					isHorizontal = true;
					return value.sheet.ReadDimension(value.handle).ToLength();
				}
			}
			isVertical = false;
			isHorizontal = false;
			return Length.Percent(50f);
		}

		// Token: 0x06002490 RID: 9360 RVA: 0x00098AA4 File Offset: 0x00096CA4
		public static Translate ReadTranslate(int valCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue val3)
		{
			bool flag = val1.handle.valueType == StyleValueType.Keyword && val1.handle.valueIndex == 6;
			Translate result;
			if (flag)
			{
				result = Translate.None();
			}
			else
			{
				Length x = 0f;
				Length y = 0f;
				float z = 0f;
				switch (valCount)
				{
				case 1:
				{
					bool flag2 = val1.handle.valueType == StyleValueType.Dimension || val1.handle.valueType == StyleValueType.Float;
					if (flag2)
					{
						x = val1.sheet.ReadDimension(val1.handle).ToLength();
						y = val1.sheet.ReadDimension(val1.handle).ToLength();
					}
					goto IL_1C3;
				}
				case 2:
					break;
				case 3:
				{
					bool flag3 = val3.handle.valueType == StyleValueType.Dimension || val3.handle.valueType == StyleValueType.Float;
					if (flag3)
					{
						Dimension dimension = val3.sheet.ReadDimension(val3.handle);
						bool flag4 = dimension.unit != Dimension.Unit.Pixel && dimension.unit > Dimension.Unit.Unitless;
						if (flag4)
						{
							z = dimension.value;
						}
					}
					break;
				}
				default:
					goto IL_1C3;
				}
				bool flag5 = val1.handle.valueType == StyleValueType.Dimension || val1.handle.valueType == StyleValueType.Float;
				if (flag5)
				{
					x = val1.sheet.ReadDimension(val1.handle).ToLength();
				}
				bool flag6 = val2.handle.valueType == StyleValueType.Dimension || val2.handle.valueType == StyleValueType.Float;
				if (flag6)
				{
					y = val2.sheet.ReadDimension(val2.handle).ToLength();
				}
				IL_1C3:
				result = new Translate(x, y, z);
			}
			return result;
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x00098C84 File Offset: 0x00096E84
		public static Scale ReadScale(int valCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue val3)
		{
			bool flag = val1.handle.valueType == StyleValueType.Keyword && val1.handle.valueIndex == 6;
			Scale result;
			if (flag)
			{
				result = Scale.None();
			}
			else
			{
				Vector3 one = Vector3.one;
				switch (valCount)
				{
				case 1:
				{
					bool flag2 = val1.handle.valueType == StyleValueType.Dimension || val1.handle.valueType == StyleValueType.Float;
					if (flag2)
					{
						one.x = val1.sheet.ReadFloat(val1.handle);
						one.y = one.x;
					}
					goto IL_173;
				}
				case 2:
					break;
				case 3:
				{
					bool flag3 = val3.handle.valueType == StyleValueType.Dimension || val3.handle.valueType == StyleValueType.Float;
					if (flag3)
					{
						one.z = val3.sheet.ReadFloat(val3.handle);
					}
					break;
				}
				default:
					goto IL_173;
				}
				bool flag4 = val1.handle.valueType == StyleValueType.Dimension || val1.handle.valueType == StyleValueType.Float;
				if (flag4)
				{
					one.x = val1.sheet.ReadFloat(val1.handle);
				}
				bool flag5 = val2.handle.valueType == StyleValueType.Dimension || val2.handle.valueType == StyleValueType.Float;
				if (flag5)
				{
					one.y = val2.sheet.ReadFloat(val2.handle);
				}
				IL_173:
				result = new Scale(one);
			}
			return result;
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x00098E10 File Offset: 0x00097010
		public static Rotate ReadRotate(int valCount, StylePropertyValue val1, StylePropertyValue val2, StylePropertyValue val3, StylePropertyValue val4)
		{
			bool flag = val1.handle.valueType == StyleValueType.Keyword && val1.handle.valueIndex == 6;
			Rotate result;
			if (flag)
			{
				result = Rotate.None();
			}
			else
			{
				Rotate rotate = Rotate.Initial();
				if (valCount == 1)
				{
					bool flag2 = val1.handle.valueType == StyleValueType.Dimension;
					if (flag2)
					{
						rotate.angle = StylePropertyReader.ReadAngle(val1);
					}
				}
				result = rotate;
			}
			return result;
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x00098E8C File Offset: 0x0009708C
		private static bool TryReadEnum(StyleEnumType enumType, StylePropertyValue value, out int intValue)
		{
			StyleValueHandle handle = value.handle;
			bool flag = handle.valueType == StyleValueType.Keyword;
			string value2;
			if (flag)
			{
				StyleValueKeyword svk = value.sheet.ReadKeyword(handle);
				value2 = svk.ToUssString();
			}
			else
			{
				value2 = value.sheet.ReadEnum(handle);
			}
			return StylePropertyUtil.TryGetEnumIntValue(enumType, value2, out intValue);
		}

		// Token: 0x06002494 RID: 9364 RVA: 0x00098EE8 File Offset: 0x000970E8
		private static int ReadEnum(StyleEnumType enumType, StylePropertyValue value)
		{
			StyleValueHandle handle = value.handle;
			bool flag = handle.valueType == StyleValueType.Keyword;
			string value2;
			if (flag)
			{
				StyleValueKeyword svk = value.sheet.ReadKeyword(handle);
				value2 = svk.ToUssString();
			}
			else
			{
				value2 = value.sheet.ReadEnum(handle);
			}
			int result;
			StylePropertyUtil.TryGetEnumIntValue(enumType, value2, out result);
			return result;
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x00098F48 File Offset: 0x00097148
		public static Angle ReadAngle(StylePropertyValue value)
		{
			bool flag = value.handle.valueType == StyleValueType.Keyword;
			Angle result;
			if (flag)
			{
				StyleValueKeyword valueIndex = (StyleValueKeyword)value.handle.valueIndex;
				StyleValueKeyword styleValueKeyword = valueIndex;
				StyleValueKeyword styleValueKeyword2 = styleValueKeyword;
				if (styleValueKeyword2 != StyleValueKeyword.None)
				{
					result = default(Angle);
				}
				else
				{
					result = Angle.None();
				}
			}
			else
			{
				result = value.sheet.ReadDimension(value.handle).ToAngle();
			}
			return result;
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x00098FB8 File Offset: 0x000971B8
		public static BackgroundPosition ReadBackgroundPosition(int valCount, StylePropertyValue val1, StylePropertyValue val2, BackgroundPositionKeyword keyword)
		{
			bool flag = valCount == 1;
			if (flag)
			{
				bool flag2 = val1.handle.valueType == StyleValueType.Enum;
				if (flag2)
				{
					return new BackgroundPosition((BackgroundPositionKeyword)StylePropertyReader.ReadEnum(StyleEnumType.BackgroundPositionKeyword, val1));
				}
				bool flag3 = val1.handle.valueType == StyleValueType.Dimension || val1.handle.valueType == StyleValueType.Float;
				if (flag3)
				{
					return new BackgroundPosition(keyword, val1.sheet.ReadDimension(val1.handle).ToLength());
				}
			}
			else
			{
				bool flag4 = valCount == 2;
				if (flag4)
				{
					bool flag5 = val1.handle.valueType == StyleValueType.Enum && (val2.handle.valueType == StyleValueType.Dimension || val2.handle.valueType == StyleValueType.Float);
					if (flag5)
					{
						return new BackgroundPosition((BackgroundPositionKeyword)StylePropertyReader.ReadEnum(StyleEnumType.BackgroundPositionKeyword, val1), val1.sheet.ReadDimension(val2.handle).ToLength());
					}
				}
			}
			return default(BackgroundPosition);
		}

		// Token: 0x06002497 RID: 9367 RVA: 0x000990C0 File Offset: 0x000972C0
		public static BackgroundRepeat ReadBackgroundRepeat(int valCount, StylePropertyValue val1, StylePropertyValue val2)
		{
			BackgroundRepeat backgroundRepeat = default(BackgroundRepeat);
			bool flag = valCount == 1;
			if (flag)
			{
				int num;
				bool flag2 = StylePropertyReader.TryReadEnum(StyleEnumType.RepeatXY, val1, out num);
				if (flag2)
				{
					bool flag3 = num == 0;
					if (flag3)
					{
						backgroundRepeat.x = Repeat.Repeat;
						backgroundRepeat.y = Repeat.NoRepeat;
					}
					else
					{
						bool flag4 = num == 1;
						if (flag4)
						{
							backgroundRepeat.x = Repeat.NoRepeat;
							backgroundRepeat.y = Repeat.Repeat;
						}
					}
				}
				else
				{
					backgroundRepeat.x = (Repeat)StylePropertyReader.ReadEnum(StyleEnumType.Repeat, val1);
					backgroundRepeat.y = backgroundRepeat.x;
				}
			}
			else
			{
				backgroundRepeat.x = (Repeat)StylePropertyReader.ReadEnum(StyleEnumType.Repeat, val1);
				backgroundRepeat.y = (Repeat)StylePropertyReader.ReadEnum(StyleEnumType.Repeat, val2);
			}
			return backgroundRepeat;
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x00099174 File Offset: 0x00097374
		public static BackgroundSize ReadBackgroundSize(int valCount, StylePropertyValue val1, StylePropertyValue val2)
		{
			BackgroundSize result = default(BackgroundSize);
			bool flag = valCount == 1;
			if (flag)
			{
				bool flag2 = val1.handle.valueType == StyleValueType.Keyword;
				if (flag2)
				{
					bool flag3 = val1.handle.valueIndex == 2;
					if (flag3)
					{
						result.x = Length.Auto();
						result.y = Length.Auto();
					}
				}
				else
				{
					bool flag4 = val1.handle.valueType == StyleValueType.Enum;
					if (flag4)
					{
						result.sizeType = (BackgroundSizeType)StylePropertyReader.ReadEnum(StyleEnumType.BackgroundSizeType, val1);
					}
					else
					{
						bool flag5 = val1.handle.valueType == StyleValueType.Dimension;
						if (flag5)
						{
							result.x = val1.sheet.ReadDimension(val1.handle).ToLength();
							result.y = Length.Auto();
						}
					}
				}
			}
			else
			{
				bool flag6 = valCount == 2;
				if (flag6)
				{
					bool flag7 = val1.handle.valueType == StyleValueType.Keyword;
					if (flag7)
					{
						bool flag8 = val1.handle.valueIndex == 2;
						if (flag8)
						{
							result.x = Length.Auto();
						}
					}
					else
					{
						bool flag9 = val1.handle.valueType == StyleValueType.Dimension;
						if (flag9)
						{
							result.x = val1.sheet.ReadDimension(val1.handle).ToLength();
						}
					}
					bool flag10 = val2.handle.valueType == StyleValueType.Keyword;
					if (flag10)
					{
						bool flag11 = val2.handle.valueIndex == 2;
						if (flag11)
						{
							result.y = Length.Auto();
						}
					}
					else
					{
						bool flag12 = val2.handle.valueType == StyleValueType.Dimension;
						if (flag12)
						{
							result.y = val2.sheet.ReadDimension(val2.handle).ToLength();
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06002499 RID: 9369 RVA: 0x00099350 File Offset: 0x00097550
		internal static bool TryGetImageSourceFromValue(StylePropertyValue propertyValue, float dpiScaling, out ImageSource source)
		{
			source = default(ImageSource);
			StyleValueType valueType = propertyValue.handle.valueType;
			StyleValueType styleValueType = valueType;
			if (styleValueType <= StyleValueType.AssetReference)
			{
				if (styleValueType != StyleValueType.ResourcePath)
				{
					if (styleValueType == StyleValueType.AssetReference)
					{
						Object @object = propertyValue.sheet.ReadAssetReference(propertyValue.handle);
						source.texture = (@object as Texture2D);
						source.sprite = (@object as Sprite);
						source.vectorImage = (@object as VectorImage);
						source.renderTexture = (@object as RenderTexture);
						bool flag = source.IsNull();
						if (flag)
						{
							Debug.LogWarning("Invalid image specified");
							return false;
						}
						goto IL_254;
					}
				}
				else
				{
					string text = propertyValue.sheet.ReadResourcePath(propertyValue.handle);
					bool flag2 = !string.IsNullOrEmpty(text);
					if (flag2)
					{
						source.sprite = (Panel.LoadResource(text, typeof(Sprite), dpiScaling) as Sprite);
						bool flag3 = source.IsNull();
						if (flag3)
						{
							source.texture = (Panel.LoadResource(text, typeof(Texture2D), dpiScaling) as Texture2D);
						}
						bool flag4 = source.IsNull();
						if (flag4)
						{
							source.vectorImage = (Panel.LoadResource(text, typeof(VectorImage), dpiScaling) as VectorImage);
						}
						bool flag5 = source.IsNull();
						if (flag5)
						{
							source.renderTexture = (Panel.LoadResource(text, typeof(RenderTexture), dpiScaling) as RenderTexture);
						}
					}
					bool flag6 = source.IsNull();
					if (flag6)
					{
						Debug.LogWarning(string.Format("Image not found for path: {0}", text));
						return false;
					}
					goto IL_254;
				}
			}
			else if (styleValueType != StyleValueType.ScalableImage)
			{
				if (styleValueType == StyleValueType.MissingAssetReference)
				{
					return false;
				}
			}
			else
			{
				ScalableImage scalableImage = propertyValue.sheet.ReadScalableImage(propertyValue.handle);
				bool flag7 = scalableImage.normalImage == null && scalableImage.highResolutionImage == null;
				if (flag7)
				{
					Debug.LogWarning("Invalid scalable image specified");
					return false;
				}
				source.texture = scalableImage.normalImage;
				bool flag8 = !Mathf.Approximately(dpiScaling % 1f, 0f);
				if (flag8)
				{
					source.texture.filterMode = FilterMode.Bilinear;
				}
				goto IL_254;
			}
			Debug.LogWarning("Invalid value for image texture " + propertyValue.handle.valueType.ToString());
			return false;
			IL_254:
			return true;
		}

		// Token: 0x04001181 RID: 4481
		internal static StylePropertyReader.GetCursorIdFunction getCursorIdFunc;

		// Token: 0x04001182 RID: 4482
		private List<StylePropertyValue> m_Values = new List<StylePropertyValue>();

		// Token: 0x04001183 RID: 4483
		private List<int> m_ValueCount = new List<int>();

		// Token: 0x04001184 RID: 4484
		private StyleVariableResolver m_Resolver = new StyleVariableResolver();

		// Token: 0x04001185 RID: 4485
		private StyleSheet m_Sheet;

		// Token: 0x04001186 RID: 4486
		private StyleProperty[] m_Properties;

		// Token: 0x04001187 RID: 4487
		private StylePropertyId[] m_PropertyIds;

		// Token: 0x04001188 RID: 4488
		private int m_CurrentValueIndex;

		// Token: 0x04001189 RID: 4489
		private int m_CurrentPropertyIndex;

		// Token: 0x02000490 RID: 1168
		// (Invoke) Token: 0x0600249C RID: 9372
		internal delegate int GetCursorIdFunction(StyleSheet sheet, StyleValueHandle handle);
	}
}
