using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine.TextCore.LowLevel;

namespace UnityEngine.TextCore.Text
{
	// Token: 0x02000026 RID: 38
	internal class TextGenerator
	{
		// Token: 0x06000133 RID: 307 RVA: 0x00009AAC File Offset: 0x00007CAC
		private static TextGenerator GetTextGenerator()
		{
			bool flag = TextGenerator.s_TextGenerator == null;
			if (flag)
			{
				TextGenerator.s_TextGenerator = new TextGenerator();
			}
			return TextGenerator.s_TextGenerator;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00009ADC File Offset: 0x00007CDC
		public static void GenerateText(TextGenerationSettings settings, TextInfo textInfo)
		{
			bool flag = settings.fontAsset == null || settings.fontAsset.characterLookupTable == null;
			if (flag)
			{
				Debug.LogWarning("Can't Generate Mesh, No Font Asset has been assigned.");
			}
			else
			{
				bool flag2 = textInfo == null;
				if (flag2)
				{
					Debug.LogError("Null TextInfo provided to TextGenerator. Cannot update its content.");
				}
				else
				{
					TextGenerator textGenerator = TextGenerator.GetTextGenerator();
					textGenerator.Prepare(settings, textInfo);
					FontAsset.UpdateFontAssetsInUpdateQueue();
					textGenerator.GenerateTextMesh(settings, textInfo);
				}
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00009B50 File Offset: 0x00007D50
		public static Vector2 GetCursorPosition(TextGenerationSettings settings, int index)
		{
			bool flag = settings.fontAsset == null || settings.fontAsset.characterLookupTable == null;
			Vector2 result;
			if (flag)
			{
				Debug.LogWarning("Can't Generate Mesh, No Font Asset has been assigned.");
				result = Vector2.zero;
			}
			else
			{
				TextInfo textInfo = new TextInfo();
				TextGenerator.GenerateText(settings, textInfo);
				result = TextGenerator.GetCursorPosition(textInfo, settings.screenRect, index, true);
			}
			return result;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00009BB8 File Offset: 0x00007DB8
		public static Vector2 GetCursorPosition(TextInfo textInfo, Rect screenRect, int index, bool inverseYAxis = true)
		{
			Vector2 vector = screenRect.position;
			bool flag = textInfo.characterCount == 0;
			Vector2 result;
			if (flag)
			{
				result = vector;
			}
			else
			{
				TextElementInfo textElementInfo = textInfo.textElementInfo[textInfo.characterCount - 1];
				LineInfo lineInfo = textInfo.lineInfo[textElementInfo.lineNumber];
				float num = lineInfo.lineHeight - (lineInfo.ascender - lineInfo.descender);
				bool flag2 = index >= textInfo.characterCount;
				if (flag2)
				{
					vector += (inverseYAxis ? new Vector2(textElementInfo.xAdvance, screenRect.height - lineInfo.ascender - num) : new Vector2(textElementInfo.xAdvance, lineInfo.descender));
					result = vector;
				}
				else
				{
					textElementInfo = textInfo.textElementInfo[index];
					lineInfo = textInfo.lineInfo[textElementInfo.lineNumber];
					num = lineInfo.lineHeight - (lineInfo.ascender - lineInfo.descender);
					vector += (inverseYAxis ? new Vector2(textElementInfo.origin, screenRect.height - lineInfo.ascender - num) : new Vector2(textElementInfo.origin, lineInfo.descender));
					result = vector;
				}
			}
			return result;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00009CE4 File Offset: 0x00007EE4
		public static float GetPreferredWidth(TextGenerationSettings settings, TextInfo textInfo)
		{
			bool flag = settings.fontAsset == null || settings.fontAsset.characterLookupTable == null;
			float result;
			if (flag)
			{
				Debug.LogWarning("Can't Generate Mesh, No Font Asset has been assigned.");
				result = 0f;
			}
			else
			{
				TextGenerator textGenerator = TextGenerator.GetTextGenerator();
				textGenerator.Prepare(settings, textInfo);
				result = textGenerator.GetPreferredWidthInternal(settings, textInfo);
			}
			return result;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00009D44 File Offset: 0x00007F44
		public static float GetPreferredHeight(TextGenerationSettings settings, TextInfo textInfo)
		{
			bool flag = settings.fontAsset == null || settings.fontAsset.characterLookupTable == null;
			float result;
			if (flag)
			{
				Debug.LogWarning("Can't Generate Mesh, No Font Asset has been assigned.");
				result = 0f;
			}
			else
			{
				TextGenerator textGenerator = TextGenerator.GetTextGenerator();
				textGenerator.Prepare(settings, textInfo);
				result = textGenerator.GetPreferredHeightInternal(settings, textInfo);
			}
			return result;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00009DA4 File Offset: 0x00007FA4
		public static Vector2 GetPreferredValues(TextGenerationSettings settings, TextInfo textInfo)
		{
			bool flag = settings.fontAsset == null || settings.fontAsset.characterLookupTable == null;
			Vector2 result;
			if (flag)
			{
				Debug.LogWarning("Can't Generate Mesh, No Font Asset has been assigned.");
				result = Vector2.zero;
			}
			else
			{
				TextGenerator textGenerator = TextGenerator.GetTextGenerator();
				textGenerator.Prepare(settings, textInfo);
				result = textGenerator.GetPreferredValuesInternal(settings, textInfo);
			}
			return result;
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00009E04 File Offset: 0x00008004
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00009E1C File Offset: 0x0000801C
		private bool vertexBufferAutoSizeReduction
		{
			get
			{
				return this.m_VertexBufferAutoSizeReduction;
			}
			set
			{
				this.m_VertexBufferAutoSizeReduction = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00009E28 File Offset: 0x00008028
		public static bool isTextTruncated
		{
			get
			{
				return TextGenerator.m_IsTextTruncated;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600013D RID: 317 RVA: 0x00009E40 File Offset: 0x00008040
		// (remove) Token: 0x0600013E RID: 318 RVA: 0x00009E74 File Offset: 0x00008074
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event TextGenerator.MissingCharacterEventCallback OnMissingCharacter;

		// Token: 0x0600013F RID: 319 RVA: 0x00009EA8 File Offset: 0x000080A8
		private void Prepare(TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			this.m_Padding = generationSettings.extraPadding;
			this.m_FontStyleInternal = generationSettings.fontStyle;
			this.m_FontWeightInternal = (((this.m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold) ? TextFontWeight.Bold : generationSettings.fontWeight);
			this.GetSpecialCharacters(generationSettings);
			this.ComputeMarginSize(generationSettings.screenRect, generationSettings.margins);
			this.PopulateTextBackingArray(generationSettings.text);
			this.PopulateTextProcessingArray(generationSettings);
			this.SetArraySizes(this.m_TextProcessingArray, generationSettings, textInfo);
			bool autoSize = generationSettings.autoSize;
			if (autoSize)
			{
				this.m_FontSize = Mathf.Clamp(generationSettings.fontSize, generationSettings.fontSizeMin, generationSettings.fontSizeMax);
			}
			else
			{
				this.m_FontSize = generationSettings.fontSize;
			}
			this.m_MaxFontSize = generationSettings.fontSizeMax;
			this.m_MinFontSize = generationSettings.fontSizeMin;
			this.m_LineSpacingDelta = 0f;
			this.m_CharWidthAdjDelta = 0f;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00009F90 File Offset: 0x00008190
		private void GenerateTextMesh(TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			bool flag = generationSettings.fontAsset == null || generationSettings.fontAsset.characterLookupTable == null;
			if (flag)
			{
				Debug.LogWarning("Can't Generate Mesh! No Font Asset has been assigned.");
				this.m_IsAutoSizePointSizeSet = true;
			}
			else
			{
				bool flag2 = textInfo != null;
				if (flag2)
				{
					textInfo.Clear();
				}
				bool flag3 = this.m_TextProcessingArray == null || this.m_TextProcessingArray.Length == 0 || this.m_TextProcessingArray[0].unicode == 0U;
				if (flag3)
				{
					TextGenerator.ClearMesh(true, textInfo);
					this.m_PreferredWidth = 0f;
					this.m_PreferredHeight = 0f;
					this.m_IsAutoSizePointSizeSet = true;
				}
				else
				{
					this.m_CurrentFontAsset = generationSettings.fontAsset;
					this.m_CurrentMaterial = generationSettings.material;
					this.m_CurrentMaterialIndex = 0;
					this.m_MaterialReferenceStack.SetDefault(new MaterialReference(this.m_CurrentMaterialIndex, this.m_CurrentFontAsset, null, this.m_CurrentMaterial, this.m_Padding));
					this.m_CurrentSpriteAsset = generationSettings.spriteAsset;
					int totalCharacterCount = this.m_TotalCharacterCount;
					float num = this.m_FontSize / (float)generationSettings.fontAsset.m_FaceInfo.pointSize * generationSettings.fontAsset.m_FaceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
					float num2 = num;
					float num3 = this.m_FontSize * 0.01f * (generationSettings.isOrthographic ? 1f : 0.1f);
					this.m_FontScaleMultiplier = 1f;
					this.m_CurrentFontSize = this.m_FontSize;
					this.m_SizeStack.SetDefault(this.m_CurrentFontSize);
					uint num4 = 0U;
					this.m_FontStyleInternal = generationSettings.fontStyle;
					this.m_FontWeightInternal = (((this.m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold) ? TextFontWeight.Bold : generationSettings.fontWeight);
					this.m_FontWeightStack.SetDefault(this.m_FontWeightInternal);
					this.m_FontStyleStack.Clear();
					this.m_LineJustification = generationSettings.textAlignment;
					this.m_LineJustificationStack.SetDefault(this.m_LineJustification);
					float num5 = 0f;
					this.m_BaselineOffset = 0f;
					this.m_BaselineOffsetStack.Clear();
					bool flag4 = false;
					Vector3 zero = Vector3.zero;
					Vector3 zero2 = Vector3.zero;
					bool flag5 = false;
					Vector3 zero3 = Vector3.zero;
					Vector3 zero4 = Vector3.zero;
					bool flag6 = false;
					Vector3 vector = Vector3.zero;
					Vector3 vector2 = Vector3.zero;
					this.m_FontColor32 = generationSettings.color;
					this.m_HtmlColor = this.m_FontColor32;
					this.m_UnderlineColor = this.m_HtmlColor;
					this.m_StrikethroughColor = this.m_HtmlColor;
					this.m_ColorStack.SetDefault(this.m_HtmlColor);
					this.m_UnderlineColorStack.SetDefault(this.m_HtmlColor);
					this.m_StrikethroughColorStack.SetDefault(this.m_HtmlColor);
					this.m_HighlightStateStack.SetDefault(new HighlightState(this.m_HtmlColor, Offset.zero));
					this.m_ColorGradientPreset = null;
					this.m_ColorGradientStack.SetDefault(null);
					this.m_ItalicAngle = (int)this.m_CurrentFontAsset.italicStyleSlant;
					this.m_ItalicAngleStack.SetDefault(this.m_ItalicAngle);
					this.m_ActionStack.Clear();
					this.m_FXScale = Vector3.one;
					this.m_FXRotation = Quaternion.identity;
					this.m_LineOffset = 0f;
					this.m_LineHeight = -32767f;
					float num6 = this.m_CurrentFontAsset.faceInfo.lineHeight - (this.m_CurrentFontAsset.m_FaceInfo.ascentLine - this.m_CurrentFontAsset.m_FaceInfo.descentLine);
					this.m_CSpacing = 0f;
					this.m_MonoSpacing = 0f;
					this.m_XAdvance = 0f;
					this.m_TagLineIndent = 0f;
					this.m_TagIndent = 0f;
					this.m_IndentStack.SetDefault(0f);
					this.m_TagNoParsing = false;
					this.m_CharacterCount = 0;
					this.m_FirstCharacterOfLine = 0;
					this.m_LastCharacterOfLine = 0;
					this.m_FirstVisibleCharacterOfLine = 0;
					this.m_LastVisibleCharacterOfLine = 0;
					this.m_MaxLineAscender = -32767f;
					this.m_MaxLineDescender = 32767f;
					this.m_LineNumber = 0;
					this.m_StartOfLineAscender = 0f;
					this.m_LineVisibleCharacterCount = 0;
					this.m_LineVisibleSpaceCount = 0;
					bool flag7 = true;
					this.m_IsDrivenLineSpacing = false;
					this.m_FirstOverflowCharacterIndex = -1;
					this.m_LastBaseGlyphIndex = int.MinValue;
					this.m_PageNumber = 0;
					int num7 = Mathf.Clamp(generationSettings.pageToDisplay - 1, 0, textInfo.pageInfo.Length - 1);
					textInfo.ClearPageInfo();
					Vector4 margins = generationSettings.margins;
					float num8 = (this.m_MarginWidth > 0f) ? this.m_MarginWidth : 0f;
					float num9 = (this.m_MarginHeight > 0f) ? this.m_MarginHeight : 0f;
					this.m_MarginLeft = 0f;
					this.m_MarginRight = 0f;
					this.m_Width = -1f;
					float num10 = num8 + 0.0001f - this.m_MarginLeft - this.m_MarginRight;
					this.m_MeshExtents.min = TextGeneratorUtilities.largePositiveVector2;
					this.m_MeshExtents.max = TextGeneratorUtilities.largeNegativeVector2;
					textInfo.ClearLineInfo();
					this.m_MaxCapHeight = 0f;
					this.m_MaxAscender = 0f;
					this.m_MaxDescender = 0f;
					this.m_PageAscender = 0f;
					float num11 = 0f;
					bool flag8 = false;
					this.m_IsNewPage = false;
					bool flag9 = true;
					this.m_IsNonBreakingSpace = false;
					bool flag10 = false;
					int num12 = 0;
					CharacterSubstitution characterSubstitution = new CharacterSubstitution(-1, 0U);
					bool flag11 = false;
					TextWrappingMode textWrappingMode = generationSettings.wordWrap ? TextWrappingMode.Normal : TextWrappingMode.NoWrap;
					this.SaveWordWrappingState(ref this.m_SavedWordWrapState, -1, -1, textInfo);
					this.SaveWordWrappingState(ref this.m_SavedLineState, -1, -1, textInfo);
					this.SaveWordWrappingState(ref this.m_SavedEllipsisState, -1, -1, textInfo);
					this.SaveWordWrappingState(ref this.m_SavedLastValidState, -1, -1, textInfo);
					this.SaveWordWrappingState(ref this.m_SavedSoftLineBreakState, -1, -1, textInfo);
					this.m_EllipsisInsertionCandidateStack.Clear();
					TextGenerator.m_IsTextTruncated = false;
					TextSettings textSettings = generationSettings.textSettings;
					int num13 = 0;
					int num14 = 0;
					while (num14 < this.m_TextProcessingArray.Length && this.m_TextProcessingArray[num14].unicode > 0U)
					{
						num4 = this.m_TextProcessingArray[num14].unicode;
						bool flag12 = num13 > 5;
						if (flag12)
						{
							Debug.LogError("Line breaking recursion max threshold hit... Character [" + num4.ToString() + "] index: " + num14.ToString());
							characterSubstitution.index = this.m_CharacterCount;
							characterSubstitution.unicode = 3U;
						}
						bool flag13 = num4 == 26U;
						int num34;
						if (!flag13)
						{
							bool flag14 = generationSettings.richText && num4 == 60U;
							if (flag14)
							{
								this.m_isTextLayoutPhase = true;
								this.m_TextElementType = TextElementType.Character;
								int num15;
								bool flag15 = this.ValidateHtmlTag(this.m_TextProcessingArray, num14 + 1, out num15, generationSettings, textInfo);
								if (flag15)
								{
									num14 = num15;
									bool flag16 = this.m_TextElementType == TextElementType.Character;
									if (flag16)
									{
										goto IL_43D7;
									}
								}
							}
							else
							{
								this.m_TextElementType = textInfo.textElementInfo[this.m_CharacterCount].elementType;
								this.m_CurrentMaterialIndex = textInfo.textElementInfo[this.m_CharacterCount].materialReferenceIndex;
								this.m_CurrentFontAsset = textInfo.textElementInfo[this.m_CharacterCount].fontAsset;
							}
							int currentMaterialIndex = this.m_CurrentMaterialIndex;
							bool isUsingAlternateTypeface = textInfo.textElementInfo[this.m_CharacterCount].isUsingAlternateTypeface;
							this.m_isTextLayoutPhase = false;
							bool flag17 = false;
							bool flag18 = characterSubstitution.index == this.m_CharacterCount;
							if (flag18)
							{
								num4 = characterSubstitution.unicode;
								this.m_TextElementType = TextElementType.Character;
								flag17 = true;
								uint num16 = num4;
								uint num17 = num16;
								if (num17 != 3U)
								{
									if (num17 != 45U)
									{
										if (num17 == 8230U)
										{
											textInfo.textElementInfo[this.m_CharacterCount].textElement = this.m_Ellipsis.character;
											textInfo.textElementInfo[this.m_CharacterCount].elementType = TextElementType.Character;
											textInfo.textElementInfo[this.m_CharacterCount].fontAsset = this.m_Ellipsis.fontAsset;
											textInfo.textElementInfo[this.m_CharacterCount].material = this.m_Ellipsis.material;
											textInfo.textElementInfo[this.m_CharacterCount].materialReferenceIndex = this.m_Ellipsis.materialIndex;
											TextGenerator.m_IsTextTruncated = true;
											characterSubstitution.index = this.m_CharacterCount + 1;
											characterSubstitution.unicode = 3U;
										}
									}
								}
								else
								{
									textInfo.textElementInfo[this.m_CharacterCount].textElement = this.m_CurrentFontAsset.characterLookupTable[3U];
									TextGenerator.m_IsTextTruncated = true;
								}
							}
							bool flag19 = this.m_CharacterCount < generationSettings.firstVisibleCharacter && num4 != 3U;
							if (flag19)
							{
								textInfo.textElementInfo[this.m_CharacterCount].isVisible = false;
								textInfo.textElementInfo[this.m_CharacterCount].character = '​';
								textInfo.textElementInfo[this.m_CharacterCount].lineNumber = 0;
								this.m_CharacterCount++;
							}
							else
							{
								float num18 = 1f;
								bool flag20 = this.m_TextElementType == TextElementType.Character;
								if (flag20)
								{
									bool flag21 = (this.m_FontStyleInternal & FontStyles.UpperCase) == FontStyles.UpperCase;
									if (flag21)
									{
										bool flag22 = char.IsLower((char)num4);
										if (flag22)
										{
											num4 = (uint)char.ToUpper((char)num4);
										}
									}
									else
									{
										bool flag23 = (this.m_FontStyleInternal & FontStyles.LowerCase) == FontStyles.LowerCase;
										if (flag23)
										{
											bool flag24 = char.IsUpper((char)num4);
											if (flag24)
											{
												num4 = (uint)char.ToLower((char)num4);
											}
										}
										else
										{
											bool flag25 = (this.m_FontStyleInternal & FontStyles.SmallCaps) == FontStyles.SmallCaps;
											if (flag25)
											{
												bool flag26 = char.IsLower((char)num4);
												if (flag26)
												{
													num18 = 0.8f;
													num4 = (uint)char.ToUpper((char)num4);
												}
											}
										}
									}
								}
								float num19 = 0f;
								float num20 = 0f;
								float num21 = 0f;
								bool flag27 = this.m_TextElementType == TextElementType.Sprite;
								if (flag27)
								{
									SpriteCharacter spriteCharacter = (SpriteCharacter)textInfo.textElementInfo[this.m_CharacterCount].textElement;
									this.m_CurrentSpriteAsset = (spriteCharacter.textAsset as SpriteAsset);
									this.m_SpriteIndex = (int)spriteCharacter.glyphIndex;
									bool flag28 = spriteCharacter == null;
									if (flag28)
									{
										goto IL_43D7;
									}
									bool flag29 = num4 == 60U;
									if (flag29)
									{
										num4 = (uint)(57344 + this.m_SpriteIndex);
									}
									else
									{
										this.m_SpriteColor = Color.white;
									}
									float num22 = this.m_CurrentFontSize / (float)this.m_CurrentFontAsset.faceInfo.pointSize * this.m_CurrentFontAsset.faceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
									bool flag30 = this.m_CurrentSpriteAsset.m_FaceInfo.pointSize > 0;
									if (flag30)
									{
										float num23 = this.m_CurrentFontSize / (float)this.m_CurrentSpriteAsset.m_FaceInfo.pointSize * this.m_CurrentSpriteAsset.m_FaceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
										num2 = spriteCharacter.m_Scale * spriteCharacter.m_Glyph.scale * num23;
										num20 = this.m_CurrentSpriteAsset.m_FaceInfo.ascentLine;
										num19 = this.m_CurrentSpriteAsset.m_FaceInfo.baseline * num22 * this.m_FontScaleMultiplier * this.m_CurrentSpriteAsset.m_FaceInfo.scale;
										num21 = this.m_CurrentSpriteAsset.m_FaceInfo.descentLine;
									}
									else
									{
										float num24 = this.m_CurrentFontSize / (float)this.m_CurrentFontAsset.m_FaceInfo.pointSize * this.m_CurrentFontAsset.m_FaceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
										num2 = this.m_CurrentFontAsset.m_FaceInfo.ascentLine / spriteCharacter.m_Glyph.metrics.height * spriteCharacter.m_Scale * spriteCharacter.m_Glyph.scale * num24;
										float num25 = num24 / num2;
										num20 = this.m_CurrentFontAsset.m_FaceInfo.ascentLine * num25;
										num19 = this.m_CurrentFontAsset.m_FaceInfo.baseline * num22 * this.m_FontScaleMultiplier * this.m_CurrentFontAsset.m_FaceInfo.scale;
										num21 = this.m_CurrentFontAsset.m_FaceInfo.descentLine * num25;
									}
									this.m_CachedTextElement = spriteCharacter;
									textInfo.textElementInfo[this.m_CharacterCount].elementType = TextElementType.Sprite;
									textInfo.textElementInfo[this.m_CharacterCount].scale = num2;
									textInfo.textElementInfo[this.m_CharacterCount].spriteAsset = this.m_CurrentSpriteAsset;
									textInfo.textElementInfo[this.m_CharacterCount].fontAsset = this.m_CurrentFontAsset;
									textInfo.textElementInfo[this.m_CharacterCount].materialReferenceIndex = this.m_CurrentMaterialIndex;
									this.m_CurrentMaterialIndex = currentMaterialIndex;
									num5 = 0f;
								}
								else
								{
									bool flag31 = this.m_TextElementType == TextElementType.Character;
									if (flag31)
									{
										this.m_CachedTextElement = textInfo.textElementInfo[this.m_CharacterCount].textElement;
										bool flag32 = this.m_CachedTextElement == null;
										if (flag32)
										{
											goto IL_43D7;
										}
										this.m_CurrentFontAsset = textInfo.textElementInfo[this.m_CharacterCount].fontAsset;
										this.m_CurrentMaterial = textInfo.textElementInfo[this.m_CharacterCount].material;
										this.m_CurrentMaterialIndex = textInfo.textElementInfo[this.m_CharacterCount].materialReferenceIndex;
										bool flag33 = flag17 && this.m_TextProcessingArray[num14].unicode == 10U && this.m_CharacterCount != this.m_FirstCharacterOfLine;
										float num26;
										if (flag33)
										{
											num26 = textInfo.textElementInfo[this.m_CharacterCount - 1].pointSize * num18 / (float)this.m_CurrentFontAsset.m_FaceInfo.pointSize * this.m_CurrentFontAsset.m_FaceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
										}
										else
										{
											num26 = this.m_CurrentFontSize * num18 / (float)this.m_CurrentFontAsset.m_FaceInfo.pointSize * this.m_CurrentFontAsset.m_FaceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
										}
										bool flag34 = flag17 && num4 == 8230U;
										if (flag34)
										{
											num20 = 0f;
											num21 = 0f;
										}
										else
										{
											num20 = this.m_CurrentFontAsset.m_FaceInfo.ascentLine;
											num21 = this.m_CurrentFontAsset.m_FaceInfo.descentLine;
										}
										num2 = num26 * this.m_FontScaleMultiplier * this.m_CachedTextElement.m_Scale * this.m_CachedTextElement.m_Glyph.scale;
										num19 = this.m_CurrentFontAsset.m_FaceInfo.baseline * num26 * this.m_FontScaleMultiplier * this.m_CurrentFontAsset.m_FaceInfo.scale;
										textInfo.textElementInfo[this.m_CharacterCount].elementType = TextElementType.Character;
										textInfo.textElementInfo[this.m_CharacterCount].scale = num2;
										num5 = this.m_Padding;
									}
								}
								float num27 = num2;
								bool flag35 = num4 == 173U || num4 == 3U;
								if (flag35)
								{
									num2 = 0f;
								}
								textInfo.textElementInfo[this.m_CharacterCount].character = (char)num4;
								textInfo.textElementInfo[this.m_CharacterCount].pointSize = this.m_CurrentFontSize;
								textInfo.textElementInfo[this.m_CharacterCount].color = this.m_HtmlColor;
								textInfo.textElementInfo[this.m_CharacterCount].underlineColor = this.m_UnderlineColor;
								textInfo.textElementInfo[this.m_CharacterCount].strikethroughColor = this.m_StrikethroughColor;
								textInfo.textElementInfo[this.m_CharacterCount].highlightState = this.m_HighlightState;
								textInfo.textElementInfo[this.m_CharacterCount].style = this.m_FontStyleInternal;
								Glyph alternativeGlyph = textInfo.textElementInfo[this.m_CharacterCount].alternativeGlyph;
								GlyphMetrics glyphMetrics = (alternativeGlyph == null) ? this.m_CachedTextElement.m_Glyph.metrics : alternativeGlyph.metrics;
								bool flag36 = num4 <= 65535U && char.IsWhiteSpace((char)num4);
								GlyphValueRecord a = default(GlyphValueRecord);
								float num28 = generationSettings.characterSpacing;
								bool enableKerning = generationSettings.enableKerning;
								if (enableKerning)
								{
									uint glyphIndex = this.m_CachedTextElement.m_GlyphIndex;
									bool flag37 = this.m_CharacterCount < totalCharacterCount - 1;
									if (flag37)
									{
										uint glyphIndex2 = textInfo.textElementInfo[this.m_CharacterCount + 1].textElement.m_GlyphIndex;
										uint key = glyphIndex2 << 16 | glyphIndex;
										GlyphPairAdjustmentRecord glyphPairAdjustmentRecord;
										bool flag38 = this.m_CurrentFontAsset.m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup.TryGetValue(key, out glyphPairAdjustmentRecord);
										if (flag38)
										{
											a = glyphPairAdjustmentRecord.firstAdjustmentRecord.glyphValueRecord;
											num28 = (((glyphPairAdjustmentRecord.featureLookupFlags & FontFeatureLookupFlags.IgnoreSpacingAdjustments) == FontFeatureLookupFlags.IgnoreSpacingAdjustments) ? 0f : num28);
										}
									}
									bool flag39 = this.m_CharacterCount >= 1;
									if (flag39)
									{
										uint glyphIndex3 = textInfo.textElementInfo[this.m_CharacterCount - 1].textElement.m_GlyphIndex;
										uint key2 = glyphIndex << 16 | glyphIndex3;
										GlyphPairAdjustmentRecord glyphPairAdjustmentRecord;
										bool flag40 = this.m_CurrentFontAsset.m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup.TryGetValue(key2, out glyphPairAdjustmentRecord);
										if (flag40)
										{
											a += glyphPairAdjustmentRecord.secondAdjustmentRecord.glyphValueRecord;
											num28 = (((glyphPairAdjustmentRecord.featureLookupFlags & FontFeatureLookupFlags.IgnoreSpacingAdjustments) == FontFeatureLookupFlags.IgnoreSpacingAdjustments) ? 0f : num28);
										}
									}
								}
								textInfo.textElementInfo[this.m_CharacterCount].adjustedHorizontalAdvance = a.xAdvance;
								bool flag41 = TextGeneratorUtilities.IsBaseGlyph(num4);
								bool flag42 = flag41;
								if (flag42)
								{
									this.m_LastBaseGlyphIndex = this.m_CharacterCount;
								}
								bool flag43 = this.m_CharacterCount > 0 && !flag41;
								if (flag43)
								{
									bool flag44 = this.m_LastBaseGlyphIndex != int.MinValue && this.m_LastBaseGlyphIndex == this.m_CharacterCount - 1;
									if (flag44)
									{
										Glyph glyph = textInfo.textElementInfo[this.m_LastBaseGlyphIndex].textElement.glyph;
										uint index = glyph.index;
										uint glyphIndex4 = this.m_CachedTextElement.glyphIndex;
										uint key3 = glyphIndex4 << 16 | index;
										MarkToBaseAdjustmentRecord markToBaseAdjustmentRecord;
										bool flag45 = this.m_CurrentFontAsset.fontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.TryGetValue(key3, out markToBaseAdjustmentRecord);
										if (flag45)
										{
											float num29 = (textInfo.textElementInfo[this.m_LastBaseGlyphIndex].origin - this.m_XAdvance) / num2;
											a.xPlacement = num29 + markToBaseAdjustmentRecord.baseGlyphAnchorPoint.xCoordinate - markToBaseAdjustmentRecord.markPositionAdjustment.xPositionAdjustment;
											a.yPlacement = markToBaseAdjustmentRecord.baseGlyphAnchorPoint.yCoordinate - markToBaseAdjustmentRecord.markPositionAdjustment.yPositionAdjustment;
											num28 = 0f;
										}
									}
									else
									{
										bool flag46 = false;
										int num30 = this.m_CharacterCount - 1;
										while (num30 >= 0 && num30 != this.m_LastBaseGlyphIndex)
										{
											Glyph glyph2 = textInfo.textElementInfo[num30].textElement.glyph;
											uint index2 = glyph2.index;
											uint glyphIndex5 = this.m_CachedTextElement.glyphIndex;
											uint key4 = glyphIndex5 << 16 | index2;
											MarkToMarkAdjustmentRecord markToMarkAdjustmentRecord;
											bool flag47 = this.m_CurrentFontAsset.fontFeatureTable.m_MarkToMarkAdjustmentRecordLookup.TryGetValue(key4, out markToMarkAdjustmentRecord);
											if (flag47)
											{
												float num31 = (textInfo.textElementInfo[num30].origin - this.m_XAdvance) / num2;
												float num32 = num19 - this.m_LineOffset + this.m_BaselineOffset;
												float num33 = (textInfo.textElementInfo[num30].baseLine - num32) / num2;
												a.xPlacement = num31 + markToMarkAdjustmentRecord.baseMarkGlyphAnchorPoint.xCoordinate - markToMarkAdjustmentRecord.combiningMarkPositionAdjustment.xPositionAdjustment;
												a.yPlacement = num33 + markToMarkAdjustmentRecord.baseMarkGlyphAnchorPoint.yCoordinate - markToMarkAdjustmentRecord.combiningMarkPositionAdjustment.yPositionAdjustment;
												num28 = 0f;
												flag46 = true;
												break;
											}
											num34 = num30;
											num30 = num34 - 1;
										}
										bool flag48 = this.m_LastBaseGlyphIndex != int.MinValue && !flag46;
										if (flag48)
										{
											Glyph glyph3 = textInfo.textElementInfo[this.m_LastBaseGlyphIndex].textElement.glyph;
											uint index3 = glyph3.index;
											uint glyphIndex6 = this.m_CachedTextElement.glyphIndex;
											uint key5 = glyphIndex6 << 16 | index3;
											MarkToBaseAdjustmentRecord markToBaseAdjustmentRecord2;
											bool flag49 = this.m_CurrentFontAsset.fontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.TryGetValue(key5, out markToBaseAdjustmentRecord2);
											if (flag49)
											{
												float num35 = (textInfo.textElementInfo[this.m_LastBaseGlyphIndex].origin - this.m_XAdvance) / num2;
												a.xPlacement = num35 + markToBaseAdjustmentRecord2.baseGlyphAnchorPoint.xCoordinate - markToBaseAdjustmentRecord2.markPositionAdjustment.xPositionAdjustment;
												a.yPlacement = markToBaseAdjustmentRecord2.baseGlyphAnchorPoint.yCoordinate - markToBaseAdjustmentRecord2.markPositionAdjustment.yPositionAdjustment;
												num28 = 0f;
											}
										}
									}
								}
								num20 += a.yPlacement;
								num21 += a.yPlacement;
								bool isRightToLeft = generationSettings.isRightToLeft;
								if (isRightToLeft)
								{
									this.m_XAdvance -= glyphMetrics.horizontalAdvance * (1f - this.m_CharWidthAdjDelta) * num2;
									bool flag50 = flag36 || num4 == 8203U;
									if (flag50)
									{
										this.m_XAdvance -= generationSettings.wordSpacing * num3;
									}
								}
								float num36 = 0f;
								bool flag51 = this.m_MonoSpacing != 0f;
								if (flag51)
								{
									num36 = (this.m_MonoSpacing / 2f - (glyphMetrics.width / 2f + glyphMetrics.horizontalBearingX) * num2) * (1f - this.m_CharWidthAdjDelta);
									this.m_XAdvance += num36;
								}
								bool flag52 = this.m_TextElementType == TextElementType.Character && !isUsingAlternateTypeface && (this.m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold;
								float num37;
								float num38;
								if (flag52)
								{
									bool flag53 = this.m_CurrentMaterial != null && this.m_CurrentMaterial.HasProperty(TextShaderUtilities.ID_GradientScale);
									if (flag53)
									{
										float @float = this.m_CurrentMaterial.GetFloat(TextShaderUtilities.ID_GradientScale);
										num37 = this.m_CurrentFontAsset.boldStyleWeight / 4f * @float * this.m_CurrentMaterial.GetFloat(TextShaderUtilities.ID_ScaleRatio_A);
										bool flag54 = num37 + num5 > @float;
										if (flag54)
										{
											num5 = @float - num37;
										}
									}
									else
									{
										num37 = 0f;
									}
									num38 = this.m_CurrentFontAsset.boldStyleSpacing;
								}
								else
								{
									bool flag55 = this.m_CurrentMaterial != null && this.m_CurrentMaterial.HasProperty(TextShaderUtilities.ID_GradientScale) && this.m_CurrentMaterial.HasProperty(TextShaderUtilities.ID_ScaleRatio_A);
									if (flag55)
									{
										float float2 = this.m_CurrentMaterial.GetFloat(TextShaderUtilities.ID_GradientScale);
										num37 = this.m_CurrentFontAsset.m_RegularStyleWeight / 4f * float2 * this.m_CurrentMaterial.GetFloat(TextShaderUtilities.ID_ScaleRatio_A);
										bool flag56 = num37 + num5 > float2;
										if (flag56)
										{
											num5 = float2 - num37;
										}
									}
									else
									{
										num37 = 0f;
									}
									num38 = 0f;
								}
								Vector3 vector3;
								vector3.x = this.m_XAdvance + (glyphMetrics.horizontalBearingX * this.m_FXScale.x - num5 - num37 + a.xPlacement) * num2 * (1f - this.m_CharWidthAdjDelta);
								vector3.y = num19 + (glyphMetrics.horizontalBearingY + num5 + a.yPlacement) * num2 - this.m_LineOffset + this.m_BaselineOffset;
								vector3.z = 0f;
								Vector3 vector4;
								vector4.x = vector3.x;
								vector4.y = vector3.y - (glyphMetrics.height + num5 * 2f) * num2;
								vector4.z = 0f;
								Vector3 vector5;
								vector5.x = vector4.x + (glyphMetrics.width * this.m_FXScale.x + num5 * 2f + num37 * 2f) * num2 * (1f - this.m_CharWidthAdjDelta);
								vector5.y = vector3.y;
								vector5.z = 0f;
								Vector3 vector6;
								vector6.x = vector5.x;
								vector6.y = vector4.y;
								vector6.z = 0f;
								bool flag57 = this.m_TextElementType == TextElementType.Character && !isUsingAlternateTypeface && (this.m_FontStyleInternal & FontStyles.Italic) == FontStyles.Italic;
								if (flag57)
								{
									float num39 = (float)this.m_ItalicAngle * 0.01f;
									float num40 = (this.m_CurrentFontAsset.m_FaceInfo.capLine - (this.m_CurrentFontAsset.m_FaceInfo.baseline + this.m_BaselineOffset)) / 2f * this.m_FontScaleMultiplier * this.m_CurrentFontAsset.m_FaceInfo.scale;
									Vector3 b = new Vector3(num39 * ((glyphMetrics.horizontalBearingY + num5 + num37 - num40) * num2), 0f, 0f);
									Vector3 b2 = new Vector3(num39 * ((glyphMetrics.horizontalBearingY - glyphMetrics.height - num5 - num37 - num40) * num2), 0f, 0f);
									vector3 += b;
									vector4 += b2;
									vector5 += b;
									vector6 += b2;
								}
								bool flag58 = this.m_FXRotation != Quaternion.identity;
								if (flag58)
								{
									Matrix4x4 matrix4x = Matrix4x4.Rotate(this.m_FXRotation);
									Vector3 b3 = (vector5 + vector4) / 2f;
									vector3 = matrix4x.MultiplyPoint3x4(vector3 - b3) + b3;
									vector4 = matrix4x.MultiplyPoint3x4(vector4 - b3) + b3;
									vector5 = matrix4x.MultiplyPoint3x4(vector5 - b3) + b3;
									vector6 = matrix4x.MultiplyPoint3x4(vector6 - b3) + b3;
								}
								textInfo.textElementInfo[this.m_CharacterCount].bottomLeft = vector4;
								textInfo.textElementInfo[this.m_CharacterCount].topLeft = vector3;
								textInfo.textElementInfo[this.m_CharacterCount].topRight = vector5;
								textInfo.textElementInfo[this.m_CharacterCount].bottomRight = vector6;
								textInfo.textElementInfo[this.m_CharacterCount].origin = this.m_XAdvance + a.xPlacement * num2;
								textInfo.textElementInfo[this.m_CharacterCount].baseLine = num19 - this.m_LineOffset + this.m_BaselineOffset + a.yPlacement * num2;
								textInfo.textElementInfo[this.m_CharacterCount].aspectRatio = (vector5.x - vector4.x) / (vector3.y - vector4.y);
								float num41 = (this.m_TextElementType == TextElementType.Character) ? (num20 * num2 / num18 + this.m_BaselineOffset) : (num20 * num2 + this.m_BaselineOffset);
								float num42 = (this.m_TextElementType == TextElementType.Character) ? (num21 * num2 / num18 + this.m_BaselineOffset) : (num21 * num2 + this.m_BaselineOffset);
								float num43 = num41;
								float num44 = num42;
								bool flag59 = this.m_CharacterCount == this.m_FirstCharacterOfLine;
								bool flag60 = flag59 || !flag36;
								if (flag60)
								{
									bool flag61 = this.m_BaselineOffset != 0f;
									if (flag61)
									{
										num43 = Mathf.Max((num41 - this.m_BaselineOffset) / this.m_FontScaleMultiplier, num43);
										num44 = Mathf.Min((num42 - this.m_BaselineOffset) / this.m_FontScaleMultiplier, num44);
									}
									this.m_MaxLineAscender = Mathf.Max(num43, this.m_MaxLineAscender);
									this.m_MaxLineDescender = Mathf.Min(num44, this.m_MaxLineDescender);
								}
								bool flag62 = flag59 || !flag36;
								if (flag62)
								{
									textInfo.textElementInfo[this.m_CharacterCount].adjustedAscender = num43;
									textInfo.textElementInfo[this.m_CharacterCount].adjustedDescender = num44;
									textInfo.textElementInfo[this.m_CharacterCount].ascender = num41 - this.m_LineOffset;
									this.m_MaxDescender = (textInfo.textElementInfo[this.m_CharacterCount].descender = num42 - this.m_LineOffset);
								}
								else
								{
									textInfo.textElementInfo[this.m_CharacterCount].adjustedAscender = this.m_MaxLineAscender;
									textInfo.textElementInfo[this.m_CharacterCount].adjustedDescender = this.m_MaxLineDescender;
									textInfo.textElementInfo[this.m_CharacterCount].ascender = this.m_MaxLineAscender - this.m_LineOffset;
									this.m_MaxDescender = (textInfo.textElementInfo[this.m_CharacterCount].descender = this.m_MaxLineDescender - this.m_LineOffset);
								}
								bool flag63 = this.m_LineNumber == 0 || this.m_IsNewPage;
								if (flag63)
								{
									bool flag64 = flag59 || !flag36;
									if (flag64)
									{
										this.m_MaxAscender = this.m_MaxLineAscender;
										this.m_MaxCapHeight = Mathf.Max(this.m_MaxCapHeight, this.m_CurrentFontAsset.m_FaceInfo.capLine * num2 / num18);
									}
								}
								bool flag65 = this.m_LineOffset == 0f;
								if (flag65)
								{
									bool flag66 = flag59 || !flag36;
									if (flag66)
									{
										this.m_PageAscender = ((this.m_PageAscender > num41) ? this.m_PageAscender : num41);
									}
								}
								textInfo.textElementInfo[this.m_CharacterCount].isVisible = false;
								bool flag67 = (this.m_LineJustification & (TextAlignment)16) == (TextAlignment)16 || (this.m_LineJustification & (TextAlignment)8) == (TextAlignment)8;
								bool flag68 = num4 == 9U || ((textWrappingMode == TextWrappingMode.PreserveWhitespace || textWrappingMode == TextWrappingMode.PreserveWhitespaceNoWrap) && (flag36 || num4 == 8203U)) || (!flag36 && num4 != 8203U && num4 != 173U && num4 != 3U) || (num4 == 173U && !flag11) || this.m_TextElementType == TextElementType.Sprite;
								if (flag68)
								{
									textInfo.textElementInfo[this.m_CharacterCount].isVisible = true;
									float marginLeft = this.m_MarginLeft;
									float marginRight = this.m_MarginRight;
									bool flag69 = flag17;
									if (flag69)
									{
										marginLeft = textInfo.lineInfo[this.m_LineNumber].marginLeft;
										marginRight = textInfo.lineInfo[this.m_LineNumber].marginRight;
									}
									num10 = ((this.m_Width != -1f) ? Mathf.Min(num8 + 0.0001f - marginLeft - marginRight, this.m_Width) : (num8 + 0.0001f - marginLeft - marginRight));
									float num45 = Mathf.Abs(this.m_XAdvance) + ((!generationSettings.isRightToLeft) ? glyphMetrics.horizontalAdvance : 0f) * (1f - this.m_CharWidthAdjDelta) * ((num4 == 173U) ? num27 : num2);
									float num46 = this.m_MaxAscender - (this.m_MaxLineDescender - this.m_LineOffset) + ((this.m_LineOffset > 0f && !this.m_IsDrivenLineSpacing) ? (this.m_MaxLineAscender - this.m_StartOfLineAscender) : 0f);
									int characterCount = this.m_CharacterCount;
									bool flag70 = num46 > num9 + 0.0001f;
									if (flag70)
									{
										bool flag71 = this.m_FirstOverflowCharacterIndex == -1;
										if (flag71)
										{
											this.m_FirstOverflowCharacterIndex = this.m_CharacterCount;
										}
										bool autoSize = generationSettings.autoSize;
										if (autoSize)
										{
											bool flag72 = this.m_LineSpacingDelta > generationSettings.lineSpacingMax && this.m_LineOffset > 0f && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
											if (flag72)
											{
												float num47 = (num9 - num46) / (float)this.m_LineNumber;
												this.m_LineSpacingDelta = Mathf.Max(this.m_LineSpacingDelta + num47 / num, generationSettings.lineSpacingMax);
												return;
											}
											bool flag73 = this.m_FontSize > generationSettings.fontSizeMin && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
											if (flag73)
											{
												this.m_MaxFontSize = this.m_FontSize;
												float num48 = Mathf.Max((this.m_FontSize - this.m_MinFontSize) / 2f, 0.05f);
												this.m_FontSize -= num48;
												this.m_FontSize = Mathf.Max((float)((int)(this.m_FontSize * 20f + 0.5f)) / 20f, generationSettings.fontSizeMin);
												return;
											}
										}
										switch (generationSettings.overflowMode)
										{
										case TextOverflowMode.Ellipsis:
										{
											bool flag74 = this.m_LineNumber > 0;
											if (flag74)
											{
												bool flag75 = this.m_EllipsisInsertionCandidateStack.Count == 0;
												if (flag75)
												{
													num14 = -1;
													this.m_CharacterCount = 0;
													characterSubstitution.index = 0;
													characterSubstitution.unicode = 3U;
													this.m_FirstCharacterOfLine = 0;
													goto IL_43D7;
												}
												WordWrapState wordWrapState = this.m_EllipsisInsertionCandidateStack.Pop();
												num14 = this.RestoreWordWrappingState(ref wordWrapState, textInfo);
												num14--;
												this.m_CharacterCount--;
												characterSubstitution.index = this.m_CharacterCount;
												characterSubstitution.unicode = 8230U;
												num13++;
												goto IL_43D7;
											}
											break;
										}
										case TextOverflowMode.Truncate:
											num14 = this.RestoreWordWrappingState(ref this.m_SavedLastValidState, textInfo);
											characterSubstitution.index = characterCount;
											goto IL_43D7;
										case TextOverflowMode.Page:
										{
											bool flag76 = num14 < 0 || characterCount == 0;
											if (flag76)
											{
												num14 = -1;
												this.m_CharacterCount = 0;
												characterSubstitution.index = 0;
												characterSubstitution.unicode = 3U;
												goto IL_43D7;
											}
											bool flag77 = this.m_MaxLineAscender - this.m_MaxLineDescender > num9 + 0.0001f;
											if (flag77)
											{
												num14 = this.RestoreWordWrappingState(ref this.m_SavedLineState, textInfo);
												characterSubstitution.index = characterCount;
												characterSubstitution.unicode = 3U;
												goto IL_43D7;
											}
											num14 = this.RestoreWordWrappingState(ref this.m_SavedLineState, textInfo);
											this.m_IsNewPage = true;
											this.m_FirstCharacterOfLine = this.m_CharacterCount;
											this.m_MaxLineAscender = -32767f;
											this.m_MaxLineDescender = 32767f;
											this.m_StartOfLineAscender = 0f;
											this.m_XAdvance = 0f + this.m_TagIndent;
											this.m_LineOffset = 0f;
											this.m_MaxAscender = 0f;
											this.m_PageAscender = 0f;
											this.m_LineNumber++;
											this.m_PageNumber++;
											goto IL_43D7;
										}
										case TextOverflowMode.Linked:
											num14 = this.RestoreWordWrappingState(ref this.m_SavedLastValidState, textInfo);
											characterSubstitution.index = characterCount;
											characterSubstitution.unicode = 3U;
											goto IL_43D7;
										}
									}
									bool flag78 = flag41 && num45 > num10 * (flag67 ? 1.05f : 1f);
									if (flag78)
									{
										bool flag79 = textWrappingMode != TextWrappingMode.NoWrap && textWrappingMode != TextWrappingMode.PreserveWhitespaceNoWrap && this.m_CharacterCount != this.m_FirstCharacterOfLine;
										if (flag79)
										{
											num14 = this.RestoreWordWrappingState(ref this.m_SavedWordWrapState, textInfo);
											bool flag80 = this.m_LineHeight == -32767f;
											float num49;
											if (flag80)
											{
												float adjustedAscender = textInfo.textElementInfo[this.m_CharacterCount].adjustedAscender;
												num49 = ((this.m_LineOffset > 0f && !this.m_IsDrivenLineSpacing) ? (this.m_MaxLineAscender - this.m_StartOfLineAscender) : 0f) - this.m_MaxLineDescender + adjustedAscender + (num6 + this.m_LineSpacingDelta) * num + generationSettings.lineSpacing * num3;
											}
											else
											{
												num49 = this.m_LineHeight + generationSettings.lineSpacing * num3;
												this.m_IsDrivenLineSpacing = true;
											}
											float num50 = this.m_MaxAscender + num49 + this.m_LineOffset - textInfo.textElementInfo[this.m_CharacterCount].adjustedDescender;
											bool flag81 = textInfo.textElementInfo[this.m_CharacterCount - 1].character == '­' && !flag11;
											if (flag81)
											{
												bool flag82 = generationSettings.overflowMode == TextOverflowMode.Overflow || num50 < num9 + 0.0001f;
												if (flag82)
												{
													characterSubstitution.index = this.m_CharacterCount - 1;
													characterSubstitution.unicode = 45U;
													num14--;
													this.m_CharacterCount--;
													goto IL_43D7;
												}
											}
											flag11 = false;
											bool flag83 = textInfo.textElementInfo[this.m_CharacterCount].character == '­';
											if (flag83)
											{
												flag11 = true;
												goto IL_43D7;
											}
											bool flag84 = generationSettings.autoSize && flag9;
											if (flag84)
											{
												bool flag85 = this.m_CharWidthAdjDelta < generationSettings.charWidthMaxAdj / 100f && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
												if (flag85)
												{
													float num51 = num45;
													bool flag86 = this.m_CharWidthAdjDelta > 0f;
													if (flag86)
													{
														num51 /= 1f - this.m_CharWidthAdjDelta;
													}
													float num52 = num45 - (num10 - 0.0001f) * (flag67 ? 1.05f : 1f);
													this.m_CharWidthAdjDelta += num52 / num51;
													this.m_CharWidthAdjDelta = Mathf.Min(this.m_CharWidthAdjDelta, generationSettings.charWidthMaxAdj / 100f);
													return;
												}
												bool flag87 = this.m_FontSize > generationSettings.fontSizeMin && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
												if (flag87)
												{
													this.m_MaxFontSize = this.m_FontSize;
													float num53 = Mathf.Max((this.m_FontSize - this.m_MinFontSize) / 2f, 0.05f);
													this.m_FontSize -= num53;
													this.m_FontSize = Mathf.Max((float)((int)(this.m_FontSize * 20f + 0.5f)) / 20f, generationSettings.fontSizeMin);
													return;
												}
											}
											int previousWordBreak = this.m_SavedSoftLineBreakState.previousWordBreak;
											bool flag88 = flag9 && previousWordBreak != -1;
											if (flag88)
											{
												bool flag89 = previousWordBreak != num12;
												if (flag89)
												{
													num14 = this.RestoreWordWrappingState(ref this.m_SavedSoftLineBreakState, textInfo);
													num12 = previousWordBreak;
													bool flag90 = textInfo.textElementInfo[this.m_CharacterCount - 1].character == '­';
													if (flag90)
													{
														characterSubstitution.index = this.m_CharacterCount - 1;
														characterSubstitution.unicode = 45U;
														num14--;
														this.m_CharacterCount--;
														goto IL_43D7;
													}
												}
											}
											bool flag91 = num50 > num9 + 0.0001f;
											if (!flag91)
											{
												this.InsertNewLine(num14, num, num2, num3, num38, num28, num10, num6, ref flag8, ref num11, generationSettings, textInfo);
												flag7 = true;
												flag9 = true;
												goto IL_43D7;
											}
											bool flag92 = this.m_FirstOverflowCharacterIndex == -1;
											if (flag92)
											{
												this.m_FirstOverflowCharacterIndex = this.m_CharacterCount;
											}
											bool autoSize2 = generationSettings.autoSize;
											if (autoSize2)
											{
												bool flag93 = this.m_LineSpacingDelta > generationSettings.lineSpacingMax && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
												if (flag93)
												{
													float num54 = (num9 - num50) / (float)(this.m_LineNumber + 1);
													this.m_LineSpacingDelta = Mathf.Max(this.m_LineSpacingDelta + num54 / num, generationSettings.lineSpacingMax);
													return;
												}
												bool flag94 = this.m_CharWidthAdjDelta < generationSettings.charWidthMaxAdj / 100f && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
												if (flag94)
												{
													float num55 = num45;
													bool flag95 = this.m_CharWidthAdjDelta > 0f;
													if (flag95)
													{
														num55 /= 1f - this.m_CharWidthAdjDelta;
													}
													float num56 = num45 - (num10 - 0.0001f) * (flag67 ? 1.05f : 1f);
													this.m_CharWidthAdjDelta += num56 / num55;
													this.m_CharWidthAdjDelta = Mathf.Min(this.m_CharWidthAdjDelta, generationSettings.charWidthMaxAdj / 100f);
													return;
												}
												bool flag96 = this.m_FontSize > generationSettings.fontSizeMin && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
												if (flag96)
												{
													this.m_MaxFontSize = this.m_FontSize;
													float num57 = Mathf.Max((this.m_FontSize - this.m_MinFontSize) / 2f, 0.05f);
													this.m_FontSize -= num57;
													this.m_FontSize = Mathf.Max((float)((int)(this.m_FontSize * 20f + 0.5f)) / 20f, generationSettings.fontSizeMin);
													return;
												}
											}
											switch (generationSettings.overflowMode)
											{
											case TextOverflowMode.Overflow:
											case TextOverflowMode.Masking:
											case TextOverflowMode.ScrollRect:
												this.InsertNewLine(num14, num, num2, num3, num38, num28, num10, num6, ref flag8, ref num11, generationSettings, textInfo);
												flag7 = true;
												flag9 = true;
												goto IL_43D7;
											case TextOverflowMode.Ellipsis:
											{
												bool flag97 = this.m_EllipsisInsertionCandidateStack.Count == 0;
												if (flag97)
												{
													num14 = -1;
													this.m_CharacterCount = 0;
													characterSubstitution.index = 0;
													characterSubstitution.unicode = 3U;
													this.m_FirstCharacterOfLine = 0;
													goto IL_43D7;
												}
												WordWrapState wordWrapState2 = this.m_EllipsisInsertionCandidateStack.Pop();
												num14 = this.RestoreWordWrappingState(ref wordWrapState2, textInfo);
												num14--;
												this.m_CharacterCount--;
												characterSubstitution.index = this.m_CharacterCount;
												characterSubstitution.unicode = 8230U;
												num13++;
												goto IL_43D7;
											}
											case TextOverflowMode.Truncate:
												num14 = this.RestoreWordWrappingState(ref this.m_SavedLastValidState, textInfo);
												characterSubstitution.index = characterCount;
												characterSubstitution.unicode = 3U;
												goto IL_43D7;
											case TextOverflowMode.Page:
												this.m_IsNewPage = true;
												this.InsertNewLine(num14, num, num2, num3, num38, num28, num10, num6, ref flag8, ref num11, generationSettings, textInfo);
												this.m_StartOfLineAscender = 0f;
												this.m_LineOffset = 0f;
												this.m_MaxAscender = 0f;
												this.m_PageAscender = 0f;
												this.m_PageNumber++;
												flag7 = true;
												flag9 = true;
												goto IL_43D7;
											case TextOverflowMode.Linked:
												characterSubstitution.index = this.m_CharacterCount;
												characterSubstitution.unicode = 3U;
												goto IL_43D7;
											}
										}
										else
										{
											bool flag98 = generationSettings.autoSize && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
											if (flag98)
											{
												bool flag99 = this.m_CharWidthAdjDelta < generationSettings.charWidthMaxAdj / 100f;
												if (flag99)
												{
													float num58 = num45;
													bool flag100 = this.m_CharWidthAdjDelta > 0f;
													if (flag100)
													{
														num58 /= 1f - this.m_CharWidthAdjDelta;
													}
													float num59 = num45 - (num10 - 0.0001f) * (flag67 ? 1.05f : 1f);
													this.m_CharWidthAdjDelta += num59 / num58;
													this.m_CharWidthAdjDelta = Mathf.Min(this.m_CharWidthAdjDelta, generationSettings.charWidthMaxAdj / 100f);
													return;
												}
												bool flag101 = this.m_FontSize > generationSettings.fontSizeMin;
												if (flag101)
												{
													this.m_MaxFontSize = this.m_FontSize;
													float num60 = Mathf.Max((this.m_FontSize - this.m_MinFontSize) / 2f, 0.05f);
													this.m_FontSize -= num60;
													this.m_FontSize = Mathf.Max((float)((int)(this.m_FontSize * 20f + 0.5f)) / 20f, generationSettings.fontSizeMin);
													return;
												}
											}
											switch (generationSettings.overflowMode)
											{
											case TextOverflowMode.Ellipsis:
											{
												bool flag102 = this.m_EllipsisInsertionCandidateStack.Count == 0;
												if (flag102)
												{
													num14 = -1;
													this.m_CharacterCount = 0;
													characterSubstitution.index = 0;
													characterSubstitution.unicode = 3U;
													this.m_FirstCharacterOfLine = 0;
													goto IL_43D7;
												}
												WordWrapState wordWrapState3 = this.m_EllipsisInsertionCandidateStack.Pop();
												num14 = this.RestoreWordWrappingState(ref wordWrapState3, textInfo);
												num14--;
												this.m_CharacterCount--;
												characterSubstitution.index = this.m_CharacterCount;
												characterSubstitution.unicode = 8230U;
												num13++;
												goto IL_43D7;
											}
											case TextOverflowMode.Truncate:
												num14 = this.RestoreWordWrappingState(ref this.m_SavedWordWrapState, textInfo);
												characterSubstitution.index = characterCount;
												characterSubstitution.unicode = 3U;
												goto IL_43D7;
											case TextOverflowMode.Linked:
												num14 = this.RestoreWordWrappingState(ref this.m_SavedWordWrapState, textInfo);
												characterSubstitution.index = this.m_CharacterCount;
												characterSubstitution.unicode = 3U;
												goto IL_43D7;
											}
										}
									}
									bool flag103 = flag36;
									if (flag103)
									{
										textInfo.textElementInfo[this.m_CharacterCount].isVisible = false;
										this.m_LastVisibleCharacterOfLine = this.m_CharacterCount;
										ref int ptr = ref textInfo.lineInfo[this.m_LineNumber].spaceCount;
										this.m_LineVisibleSpaceCount = ++ptr;
										textInfo.lineInfo[this.m_LineNumber].marginLeft = marginLeft;
										textInfo.lineInfo[this.m_LineNumber].marginRight = marginRight;
										textInfo.spaceCount++;
									}
									else
									{
										bool flag104 = num4 == 173U;
										if (flag104)
										{
											textInfo.textElementInfo[this.m_CharacterCount].isVisible = false;
										}
										else
										{
											bool overrideRichTextColors = generationSettings.overrideRichTextColors;
											Color32 vertexColor;
											if (overrideRichTextColors)
											{
												vertexColor = this.m_FontColor32;
											}
											else
											{
												vertexColor = this.m_HtmlColor;
											}
											bool flag105 = this.m_TextElementType == TextElementType.Character;
											if (flag105)
											{
												this.SaveGlyphVertexInfo(num5, num37, vertexColor, generationSettings, textInfo);
											}
											else
											{
												bool flag106 = this.m_TextElementType == TextElementType.Sprite;
												if (flag106)
												{
													this.SaveSpriteVertexInfo(vertexColor, generationSettings, textInfo);
												}
											}
											bool flag107 = flag7;
											if (flag107)
											{
												flag7 = false;
												this.m_FirstVisibleCharacterOfLine = this.m_CharacterCount;
											}
											this.m_LineVisibleCharacterCount++;
											this.m_LastVisibleCharacterOfLine = this.m_CharacterCount;
											textInfo.lineInfo[this.m_LineNumber].marginLeft = marginLeft;
											textInfo.lineInfo[this.m_LineNumber].marginRight = marginRight;
										}
									}
								}
								else
								{
									bool flag108 = generationSettings.overflowMode == TextOverflowMode.Linked && (num4 == 10U || num4 == 11U);
									if (flag108)
									{
										float num61 = this.m_MaxAscender - (this.m_MaxLineDescender - this.m_LineOffset) + ((this.m_LineOffset > 0f && !this.m_IsDrivenLineSpacing) ? (this.m_MaxLineAscender - this.m_StartOfLineAscender) : 0f);
										int characterCount2 = this.m_CharacterCount;
										bool flag109 = num61 > num9 + 0.0001f;
										if (flag109)
										{
											bool flag110 = this.m_FirstOverflowCharacterIndex == -1;
											if (flag110)
											{
												this.m_FirstOverflowCharacterIndex = this.m_CharacterCount;
											}
											num14 = this.RestoreWordWrappingState(ref this.m_SavedLastValidState, textInfo);
											characterSubstitution.index = characterCount2;
											characterSubstitution.unicode = 3U;
											goto IL_43D7;
										}
									}
									bool flag111 = (num4 == 10U || num4 == 11U || num4 == 160U || num4 == 8199U || num4 == 8232U || num4 == 8233U || char.IsSeparator((char)num4)) && num4 != 173U && num4 != 8203U && num4 != 8288U;
									if (flag111)
									{
										ref int ptr = ref textInfo.lineInfo[this.m_LineNumber].spaceCount;
										ptr++;
										textInfo.spaceCount++;
									}
									bool flag112 = num4 == 160U;
									if (flag112)
									{
										ref int ptr = ref textInfo.lineInfo[this.m_LineNumber].controlCharacterCount;
										ptr++;
									}
								}
								bool flag113 = generationSettings.overflowMode == TextOverflowMode.Ellipsis && (!flag17 || num4 == 45U);
								if (flag113)
								{
									float num62 = this.m_CurrentFontSize / (float)this.m_Ellipsis.fontAsset.m_FaceInfo.pointSize * this.m_Ellipsis.fontAsset.m_FaceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
									float num63 = num62 * this.m_FontScaleMultiplier * this.m_Ellipsis.character.m_Scale * this.m_Ellipsis.character.m_Glyph.scale;
									float marginLeft2 = this.m_MarginLeft;
									float marginRight2 = this.m_MarginRight;
									bool flag114 = num4 == 10U && this.m_CharacterCount != this.m_FirstCharacterOfLine;
									if (flag114)
									{
										num62 = textInfo.textElementInfo[this.m_CharacterCount - 1].pointSize / (float)this.m_Ellipsis.fontAsset.m_FaceInfo.pointSize * this.m_Ellipsis.fontAsset.m_FaceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
										num63 = num62 * this.m_FontScaleMultiplier * this.m_Ellipsis.character.m_Scale * this.m_Ellipsis.character.m_Glyph.scale;
										marginLeft2 = textInfo.lineInfo[this.m_LineNumber].marginLeft;
										marginRight2 = textInfo.lineInfo[this.m_LineNumber].marginRight;
									}
									float num64 = this.m_MaxAscender - (this.m_MaxLineDescender - this.m_LineOffset) + ((this.m_LineOffset > 0f && !this.m_IsDrivenLineSpacing) ? (this.m_MaxLineAscender - this.m_StartOfLineAscender) : 0f);
									float num65 = Mathf.Abs(this.m_XAdvance) + ((!generationSettings.isRightToLeft) ? this.m_Ellipsis.character.m_Glyph.metrics.horizontalAdvance : 0f) * (1f - this.m_CharWidthAdjDelta) * num63;
									float num66 = (this.m_Width != -1f) ? Mathf.Min(num8 + 0.0001f - marginLeft2 - marginRight2, this.m_Width) : (num8 + 0.0001f - marginLeft2 - marginRight2);
									bool flag115 = num65 < num66 * (flag67 ? 1.05f : 1f);
									if (flag115)
									{
										this.SaveWordWrappingState(ref this.m_SavedEllipsisState, num14, this.m_CharacterCount, textInfo);
										this.m_EllipsisInsertionCandidateStack.Push(this.m_SavedEllipsisState);
									}
								}
								textInfo.textElementInfo[this.m_CharacterCount].lineNumber = this.m_LineNumber;
								textInfo.textElementInfo[this.m_CharacterCount].pageNumber = this.m_PageNumber;
								bool flag116 = (num4 != 10U && num4 != 11U && num4 != 13U && !flag17) || textInfo.lineInfo[this.m_LineNumber].characterCount == 1;
								if (flag116)
								{
									textInfo.lineInfo[this.m_LineNumber].alignment = this.m_LineJustification;
								}
								bool flag117 = num4 != 8203U;
								if (flag117)
								{
									bool flag118 = num4 == 9U;
									if (flag118)
									{
										float num67 = this.m_CurrentFontAsset.m_FaceInfo.tabWidth * (float)this.m_CurrentFontAsset.tabMultiple * num2;
										float num68 = Mathf.Ceil(this.m_XAdvance / num67) * num67;
										this.m_XAdvance = ((num68 > this.m_XAdvance) ? num68 : (this.m_XAdvance + num67));
									}
									else
									{
										bool flag119 = this.m_MonoSpacing != 0f;
										if (flag119)
										{
											this.m_XAdvance += (this.m_MonoSpacing - num36 + (this.m_CurrentFontAsset.regularStyleSpacing + num28) * num3 + this.m_CSpacing) * (1f - this.m_CharWidthAdjDelta);
											bool flag120 = flag36 || num4 == 8203U;
											if (flag120)
											{
												this.m_XAdvance += generationSettings.wordSpacing * num3;
											}
										}
										else
										{
											bool isRightToLeft2 = generationSettings.isRightToLeft;
											if (isRightToLeft2)
											{
												this.m_XAdvance -= (a.xAdvance * num2 + (this.m_CurrentFontAsset.regularStyleSpacing + num28 + num38) * num3 + this.m_CSpacing) * (1f - this.m_CharWidthAdjDelta);
												bool flag121 = flag36 || num4 == 8203U;
												if (flag121)
												{
													this.m_XAdvance -= generationSettings.wordSpacing * num3;
												}
											}
											else
											{
												this.m_XAdvance += ((glyphMetrics.horizontalAdvance * this.m_FXScale.x + a.xAdvance) * num2 + (this.m_CurrentFontAsset.regularStyleSpacing + num28 + num38) * num3 + this.m_CSpacing) * (1f - this.m_CharWidthAdjDelta);
												bool flag122 = flag36 || num4 == 8203U;
												if (flag122)
												{
													this.m_XAdvance += generationSettings.wordSpacing * num3;
												}
											}
										}
									}
								}
								textInfo.textElementInfo[this.m_CharacterCount].xAdvance = this.m_XAdvance;
								bool flag123 = num4 == 13U;
								if (flag123)
								{
									this.m_XAdvance = 0f + this.m_TagIndent;
								}
								bool flag124 = generationSettings.overflowMode == TextOverflowMode.Page && num4 != 10U && num4 != 11U && num4 != 13U && num4 != 8232U && num4 != 8233U;
								if (flag124)
								{
									bool flag125 = this.m_PageNumber + 1 > textInfo.pageInfo.Length;
									if (flag125)
									{
										TextInfo.Resize<PageInfo>(ref textInfo.pageInfo, this.m_PageNumber + 1, true);
									}
									textInfo.pageInfo[this.m_PageNumber].ascender = this.m_PageAscender;
									textInfo.pageInfo[this.m_PageNumber].descender = ((this.m_MaxDescender < textInfo.pageInfo[this.m_PageNumber].descender) ? this.m_MaxDescender : textInfo.pageInfo[this.m_PageNumber].descender);
									bool isNewPage = this.m_IsNewPage;
									if (isNewPage)
									{
										this.m_IsNewPage = false;
										textInfo.pageInfo[this.m_PageNumber].firstCharacterIndex = this.m_CharacterCount;
									}
									textInfo.pageInfo[this.m_PageNumber].lastCharacterIndex = this.m_CharacterCount;
								}
								bool flag126 = num4 == 10U || num4 == 11U || num4 == 3U || num4 == 8232U || num4 == 8233U || (num4 == 45U && flag17) || this.m_CharacterCount == totalCharacterCount - 1;
								if (flag126)
								{
									float num69 = this.m_MaxLineAscender - this.m_StartOfLineAscender;
									bool flag127 = this.m_LineOffset > 0f && Math.Abs(num69) > 0.01f && !this.m_IsDrivenLineSpacing && !this.m_IsNewPage;
									if (flag127)
									{
										TextGeneratorUtilities.AdjustLineOffset(this.m_FirstCharacterOfLine, this.m_CharacterCount, num69, textInfo);
										this.m_MaxDescender -= num69;
										this.m_LineOffset += num69;
										bool flag128 = this.m_SavedEllipsisState.lineNumber == this.m_LineNumber;
										if (flag128)
										{
											this.m_SavedEllipsisState = this.m_EllipsisInsertionCandidateStack.Pop();
											ref float ptr2 = ref this.m_SavedEllipsisState.startOfLineAscender;
											ptr2 += num69;
											ptr2 = ref this.m_SavedEllipsisState.lineOffset;
											ptr2 += num69;
											this.m_EllipsisInsertionCandidateStack.Push(this.m_SavedEllipsisState);
										}
									}
									this.m_IsNewPage = false;
									float num70 = this.m_MaxLineAscender - this.m_LineOffset;
									float num71 = this.m_MaxLineDescender - this.m_LineOffset;
									this.m_MaxDescender = ((this.m_MaxDescender < num71) ? this.m_MaxDescender : num71);
									bool flag129 = !flag8;
									if (flag129)
									{
										num11 = this.m_MaxDescender;
									}
									bool flag130 = generationSettings.useMaxVisibleDescender && (this.m_CharacterCount >= generationSettings.maxVisibleCharacters || this.m_LineNumber >= generationSettings.maxVisibleLines);
									if (flag130)
									{
										flag8 = true;
									}
									textInfo.lineInfo[this.m_LineNumber].firstCharacterIndex = this.m_FirstCharacterOfLine;
									textInfo.lineInfo[this.m_LineNumber].firstVisibleCharacterIndex = (this.m_FirstVisibleCharacterOfLine = ((this.m_FirstCharacterOfLine > this.m_FirstVisibleCharacterOfLine) ? this.m_FirstCharacterOfLine : this.m_FirstVisibleCharacterOfLine));
									textInfo.lineInfo[this.m_LineNumber].lastCharacterIndex = (this.m_LastCharacterOfLine = this.m_CharacterCount);
									textInfo.lineInfo[this.m_LineNumber].lastVisibleCharacterIndex = (this.m_LastVisibleCharacterOfLine = ((this.m_LastVisibleCharacterOfLine < this.m_FirstVisibleCharacterOfLine) ? this.m_FirstVisibleCharacterOfLine : this.m_LastVisibleCharacterOfLine));
									textInfo.lineInfo[this.m_LineNumber].characterCount = textInfo.lineInfo[this.m_LineNumber].lastCharacterIndex - textInfo.lineInfo[this.m_LineNumber].firstCharacterIndex + 1;
									textInfo.lineInfo[this.m_LineNumber].visibleCharacterCount = this.m_LineVisibleCharacterCount;
									textInfo.lineInfo[this.m_LineNumber].visibleSpaceCount = this.m_LineVisibleSpaceCount;
									textInfo.lineInfo[this.m_LineNumber].lineExtents.min = new Vector2(textInfo.textElementInfo[this.m_FirstVisibleCharacterOfLine].bottomLeft.x, num71);
									textInfo.lineInfo[this.m_LineNumber].lineExtents.max = new Vector2(textInfo.textElementInfo[this.m_LastVisibleCharacterOfLine].topRight.x, num70);
									textInfo.lineInfo[this.m_LineNumber].length = textInfo.lineInfo[this.m_LineNumber].lineExtents.max.x - num5 * num2;
									textInfo.lineInfo[this.m_LineNumber].width = num10;
									bool flag131 = textInfo.lineInfo[this.m_LineNumber].characterCount == 1;
									if (flag131)
									{
										textInfo.lineInfo[this.m_LineNumber].alignment = this.m_LineJustification;
									}
									float num72 = ((this.m_CurrentFontAsset.regularStyleSpacing + num28 + num38) * num3 + this.m_CSpacing) * (1f - this.m_CharWidthAdjDelta);
									bool isVisible = textInfo.textElementInfo[this.m_LastVisibleCharacterOfLine].isVisible;
									if (isVisible)
									{
										textInfo.lineInfo[this.m_LineNumber].maxAdvance = textInfo.textElementInfo[this.m_LastVisibleCharacterOfLine].xAdvance + (generationSettings.isRightToLeft ? num72 : (-num72));
									}
									else
									{
										textInfo.lineInfo[this.m_LineNumber].maxAdvance = textInfo.textElementInfo[this.m_LastCharacterOfLine].xAdvance + (generationSettings.isRightToLeft ? num72 : (-num72));
									}
									textInfo.lineInfo[this.m_LineNumber].baseline = 0f - this.m_LineOffset;
									textInfo.lineInfo[this.m_LineNumber].ascender = num70;
									textInfo.lineInfo[this.m_LineNumber].descender = num71;
									textInfo.lineInfo[this.m_LineNumber].lineHeight = num70 - num71 + num6 * num;
									bool flag132 = num4 == 10U || num4 == 11U || num4 == 45U || num4 == 8232U || num4 == 8233U;
									if (flag132)
									{
										this.SaveWordWrappingState(ref this.m_SavedLineState, num14, this.m_CharacterCount, textInfo);
										this.m_LineNumber++;
										flag7 = true;
										flag10 = false;
										flag9 = true;
										this.m_FirstCharacterOfLine = this.m_CharacterCount + 1;
										this.m_LineVisibleCharacterCount = 0;
										this.m_LineVisibleSpaceCount = 0;
										bool flag133 = this.m_LineNumber >= textInfo.lineInfo.Length;
										if (flag133)
										{
											TextGeneratorUtilities.ResizeLineExtents(this.m_LineNumber, textInfo);
										}
										float adjustedAscender2 = textInfo.textElementInfo[this.m_CharacterCount].adjustedAscender;
										bool flag134 = this.m_LineHeight == -32767f;
										if (flag134)
										{
											float num73 = 0f - this.m_MaxLineDescender + adjustedAscender2 + (num6 + this.m_LineSpacingDelta) * num + (generationSettings.lineSpacing + ((num4 == 10U || num4 == 8233U) ? generationSettings.paragraphSpacing : 0f)) * num3;
											this.m_LineOffset += num73;
											this.m_IsDrivenLineSpacing = false;
										}
										else
										{
											this.m_LineOffset += this.m_LineHeight + (generationSettings.lineSpacing + ((num4 == 10U || num4 == 8233U) ? generationSettings.paragraphSpacing : 0f)) * num3;
											this.m_IsDrivenLineSpacing = true;
										}
										this.m_MaxLineAscender = -32767f;
										this.m_MaxLineDescender = 32767f;
										this.m_StartOfLineAscender = adjustedAscender2;
										this.m_XAdvance = 0f + this.m_TagLineIndent + this.m_TagIndent;
										this.SaveWordWrappingState(ref this.m_SavedWordWrapState, num14, this.m_CharacterCount, textInfo);
										this.SaveWordWrappingState(ref this.m_SavedLastValidState, num14, this.m_CharacterCount, textInfo);
										this.m_CharacterCount++;
										goto IL_43D7;
									}
									bool flag135 = num4 == 3U;
									if (flag135)
									{
										num14 = this.m_TextProcessingArray.Length;
									}
								}
								bool isVisible2 = textInfo.textElementInfo[this.m_CharacterCount].isVisible;
								if (isVisible2)
								{
									this.m_MeshExtents.min.x = Mathf.Min(this.m_MeshExtents.min.x, textInfo.textElementInfo[this.m_CharacterCount].bottomLeft.x);
									this.m_MeshExtents.min.y = Mathf.Min(this.m_MeshExtents.min.y, textInfo.textElementInfo[this.m_CharacterCount].bottomLeft.y);
									this.m_MeshExtents.max.x = Mathf.Max(this.m_MeshExtents.max.x, textInfo.textElementInfo[this.m_CharacterCount].topRight.x);
									this.m_MeshExtents.max.y = Mathf.Max(this.m_MeshExtents.max.y, textInfo.textElementInfo[this.m_CharacterCount].topRight.y);
								}
								bool flag136 = (textWrappingMode != TextWrappingMode.NoWrap && textWrappingMode != TextWrappingMode.PreserveWhitespaceNoWrap) || generationSettings.overflowMode == TextOverflowMode.Truncate || generationSettings.overflowMode == TextOverflowMode.Ellipsis || generationSettings.overflowMode == TextOverflowMode.Linked;
								if (flag136)
								{
									bool flag137 = (flag36 || num4 == 8203U || num4 == 45U || num4 == 173U) && (!this.m_IsNonBreakingSpace || flag10) && num4 != 160U && num4 != 8199U && num4 != 8209U && num4 != 8239U && num4 != 8288U;
									if (flag137)
									{
										this.SaveWordWrappingState(ref this.m_SavedWordWrapState, num14, this.m_CharacterCount, textInfo);
										flag9 = false;
										this.m_SavedSoftLineBreakState.previousWordBreak = -1;
									}
									else
									{
										bool flag138 = !this.m_IsNonBreakingSpace && ((TextGeneratorUtilities.IsHangul(num4) && !textSettings.lineBreakingRules.useModernHangulLineBreakingRules) || TextGeneratorUtilities.IsCJK(num4));
										if (flag138)
										{
											bool flag139 = textSettings.lineBreakingRules.leadingCharactersLookup.Contains(num4);
											bool flag140 = this.m_CharacterCount < totalCharacterCount - 1 && textSettings.lineBreakingRules.followingCharactersLookup.Contains((uint)textInfo.textElementInfo[this.m_CharacterCount + 1].character);
											bool flag141 = !flag139;
											if (flag141)
											{
												bool flag142 = !flag140;
												if (flag142)
												{
													this.SaveWordWrappingState(ref this.m_SavedWordWrapState, num14, this.m_CharacterCount, textInfo);
													flag9 = false;
												}
												bool flag143 = flag9;
												if (flag143)
												{
													bool flag144 = flag36;
													if (flag144)
													{
														this.SaveWordWrappingState(ref this.m_SavedSoftLineBreakState, num14, this.m_CharacterCount, textInfo);
													}
													this.SaveWordWrappingState(ref this.m_SavedWordWrapState, num14, this.m_CharacterCount, textInfo);
												}
											}
											else
											{
												bool flag145 = flag9 && flag59;
												if (flag145)
												{
													bool flag146 = flag36;
													if (flag146)
													{
														this.SaveWordWrappingState(ref this.m_SavedSoftLineBreakState, num14, this.m_CharacterCount, textInfo);
													}
													this.SaveWordWrappingState(ref this.m_SavedWordWrapState, num14, this.m_CharacterCount, textInfo);
												}
											}
										}
										else
										{
											bool flag147 = flag9;
											if (flag147)
											{
												bool flag148 = (flag36 && num4 != 160U) || (num4 == 173U && !flag11);
												if (flag148)
												{
													this.SaveWordWrappingState(ref this.m_SavedSoftLineBreakState, num14, this.m_CharacterCount, textInfo);
												}
												this.SaveWordWrappingState(ref this.m_SavedWordWrapState, num14, this.m_CharacterCount, textInfo);
											}
										}
									}
								}
								this.SaveWordWrappingState(ref this.m_SavedLastValidState, num14, this.m_CharacterCount, textInfo);
								this.m_CharacterCount++;
							}
						}
						IL_43D7:
						num34 = num14;
						num14 = num34 + 1;
					}
					float num74 = this.m_MaxFontSize - this.m_MinFontSize;
					bool flag149 = generationSettings.autoSize && num74 > 0.051f && this.m_FontSize < generationSettings.fontSizeMax && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
					if (flag149)
					{
						bool flag150 = this.m_CharWidthAdjDelta < generationSettings.charWidthMaxAdj / 100f;
						if (flag150)
						{
							this.m_CharWidthAdjDelta = 0f;
						}
						this.m_MinFontSize = this.m_FontSize;
						float num75 = Mathf.Max((this.m_MaxFontSize - this.m_FontSize) / 2f, 0.05f);
						this.m_FontSize += num75;
						this.m_FontSize = Mathf.Min((float)((int)(this.m_FontSize * 20f + 0.5f)) / 20f, generationSettings.charWidthMaxAdj);
					}
					else
					{
						this.m_IsAutoSizePointSizeSet = true;
						bool flag151 = this.m_AutoSizeIterationCount >= this.m_AutoSizeMaxIterationCount;
						if (flag151)
						{
							Debug.Log("Auto Size Iteration Count: " + this.m_AutoSizeIterationCount.ToString() + ". Final Point Size: " + this.m_FontSize.ToString());
						}
						bool flag152 = this.m_CharacterCount == 0 || (this.m_CharacterCount == 1 && num4 == 3U);
						if (flag152)
						{
							TextGenerator.ClearMesh(true, textInfo);
						}
						else
						{
							textInfo.meshInfo[this.m_CurrentMaterialIndex].Clear(false);
							Vector3 a2 = Vector3.zero;
							Vector3[] rectTransformCorners = this.m_RectTransformCorners;
							TextAlignment textAlignment = generationSettings.textAlignment;
							TextAlignment textAlignment2 = textAlignment;
							if (textAlignment2 <= TextAlignment.BottomGeoAligned)
							{
								if (textAlignment2 <= TextAlignment.MiddleRight)
								{
									if (textAlignment2 <= TextAlignment.TopJustified)
									{
										if (textAlignment2 - TextAlignment.TopLeft > 1 && textAlignment2 != TextAlignment.TopRight && textAlignment2 != TextAlignment.TopJustified)
										{
											goto IL_4C35;
										}
									}
									else if (textAlignment2 <= TextAlignment.TopGeoAligned)
									{
										if (textAlignment2 != TextAlignment.TopFlush && textAlignment2 != TextAlignment.TopGeoAligned)
										{
											goto IL_4C35;
										}
									}
									else
									{
										if (textAlignment2 - TextAlignment.MiddleLeft > 1 && textAlignment2 != TextAlignment.MiddleRight)
										{
											goto IL_4C35;
										}
										goto IL_4973;
									}
									bool flag153 = generationSettings.overflowMode != TextOverflowMode.Page;
									if (flag153)
									{
										a2 = rectTransformCorners[1] + new Vector3(0f + margins.x, 0f - this.m_MaxAscender - margins.y, 0f);
									}
									else
									{
										a2 = rectTransformCorners[1] + new Vector3(0f + margins.x, 0f - textInfo.pageInfo[num7].ascender - margins.y, 0f);
									}
									goto IL_4C35;
								}
								if (textAlignment2 <= TextAlignment.BottomCenter)
								{
									if (textAlignment2 <= TextAlignment.MiddleFlush)
									{
										if (textAlignment2 != TextAlignment.MiddleJustified && textAlignment2 != TextAlignment.MiddleFlush)
										{
											goto IL_4C35;
										}
										goto IL_4973;
									}
									else
									{
										if (textAlignment2 == TextAlignment.MiddleGeoAligned)
										{
											goto IL_4973;
										}
										if (textAlignment2 - TextAlignment.BottomLeft > 1)
										{
											goto IL_4C35;
										}
									}
								}
								else if (textAlignment2 <= TextAlignment.BottomJustified)
								{
									if (textAlignment2 != TextAlignment.BottomRight && textAlignment2 != TextAlignment.BottomJustified)
									{
										goto IL_4C35;
									}
								}
								else if (textAlignment2 != TextAlignment.BottomFlush && textAlignment2 != TextAlignment.BottomGeoAligned)
								{
									goto IL_4C35;
								}
								bool flag154 = generationSettings.overflowMode != TextOverflowMode.Page;
								if (flag154)
								{
									a2 = rectTransformCorners[0] + new Vector3(0f + margins.x, 0f - num11 + margins.w, 0f);
								}
								else
								{
									a2 = rectTransformCorners[0] + new Vector3(0f + margins.x, 0f - textInfo.pageInfo[num7].descender + margins.w, 0f);
								}
								goto IL_4C35;
								IL_4973:
								bool flag155 = generationSettings.overflowMode != TextOverflowMode.Page;
								if (flag155)
								{
									a2 = (rectTransformCorners[0] + rectTransformCorners[1]) / 2f + new Vector3(0f + margins.x, 0f - (this.m_MaxAscender + margins.y + num11 - margins.w) / 2f, 0f);
								}
								else
								{
									a2 = (rectTransformCorners[0] + rectTransformCorners[1]) / 2f + new Vector3(0f + margins.x, 0f - (textInfo.pageInfo[num7].ascender + margins.y + textInfo.pageInfo[num7].descender - margins.w) / 2f, 0f);
								}
							}
							else
							{
								if (textAlignment2 <= TextAlignment.MidlineRight)
								{
									if (textAlignment2 <= TextAlignment.BaselineJustified)
									{
										if (textAlignment2 - TextAlignment.BaselineLeft > 1 && textAlignment2 != TextAlignment.BaselineRight && textAlignment2 != TextAlignment.BaselineJustified)
										{
											goto IL_4C35;
										}
									}
									else if (textAlignment2 <= TextAlignment.BaselineGeoAligned)
									{
										if (textAlignment2 != TextAlignment.BaselineFlush && textAlignment2 != TextAlignment.BaselineGeoAligned)
										{
											goto IL_4C35;
										}
									}
									else
									{
										if (textAlignment2 - TextAlignment.MidlineLeft > 1 && textAlignment2 != TextAlignment.MidlineRight)
										{
											goto IL_4C35;
										}
										goto IL_4B58;
									}
									a2 = (rectTransformCorners[0] + rectTransformCorners[1]) / 2f + new Vector3(0f + margins.x, 0f, 0f);
									goto IL_4C35;
								}
								if (textAlignment2 <= TextAlignment.CaplineCenter)
								{
									if (textAlignment2 <= TextAlignment.MidlineFlush)
									{
										if (textAlignment2 != TextAlignment.MidlineJustified && textAlignment2 != TextAlignment.MidlineFlush)
										{
											goto IL_4C35;
										}
										goto IL_4B58;
									}
									else
									{
										if (textAlignment2 == TextAlignment.MidlineGeoAligned)
										{
											goto IL_4B58;
										}
										if (textAlignment2 - TextAlignment.CaplineLeft > 1)
										{
											goto IL_4C35;
										}
									}
								}
								else if (textAlignment2 <= TextAlignment.CaplineJustified)
								{
									if (textAlignment2 != TextAlignment.CaplineRight && textAlignment2 != TextAlignment.CaplineJustified)
									{
										goto IL_4C35;
									}
								}
								else if (textAlignment2 != TextAlignment.CaplineFlush && textAlignment2 != TextAlignment.CaplineGeoAligned)
								{
									goto IL_4C35;
								}
								a2 = (rectTransformCorners[0] + rectTransformCorners[1]) / 2f + new Vector3(0f + margins.x, 0f - (this.m_MaxCapHeight - margins.y - margins.w) / 2f, 0f);
								goto IL_4C35;
								IL_4B58:
								a2 = (rectTransformCorners[0] + rectTransformCorners[1]) / 2f + new Vector3(0f + margins.x, 0f - (this.m_MeshExtents.max.y + margins.y + this.m_MeshExtents.min.y - margins.w) / 2f, 0f);
							}
							IL_4C35:
							Vector3 vector7 = Vector3.zero;
							Vector3 vector8 = Vector3.zero;
							int num76 = 0;
							int lineCount = 0;
							int num77 = 0;
							bool flag156 = false;
							bool flag157 = false;
							int num78 = 0;
							Color32 color = Color.white;
							Color32 underlineColor = Color.white;
							HighlightState highlightState = new HighlightState(new Color32(byte.MaxValue, byte.MaxValue, 0, 64), Offset.zero);
							float num79 = 0f;
							float num80 = 0f;
							float num81 = 0f;
							float num82 = 0f;
							float num83 = 32767f;
							int num84 = 0;
							float num85 = 0f;
							float num86 = 0f;
							float b4 = 0f;
							TextElementInfo[] textElementInfo = textInfo.textElementInfo;
							int i = 0;
							int num34;
							while (i < this.m_CharacterCount)
							{
								FontAsset fontAsset = textElementInfo[i].fontAsset;
								char character = textElementInfo[i].character;
								bool flag158 = char.IsWhiteSpace(character);
								int lineNumber = textElementInfo[i].lineNumber;
								LineInfo lineInfo = textInfo.lineInfo[lineNumber];
								lineCount = lineNumber + 1;
								TextAlignment alignment = lineInfo.alignment;
								TextAlignment textAlignment3 = alignment;
								TextAlignment textAlignment4 = textAlignment3;
								if (textAlignment4 <= TextAlignment.BottomGeoAligned)
								{
									if (textAlignment4 <= TextAlignment.MiddleJustified)
									{
										if (textAlignment4 <= TextAlignment.TopFlush)
										{
											switch (textAlignment4)
											{
											case TextAlignment.TopLeft:
												goto IL_501A;
											case TextAlignment.TopCenter:
												goto IL_507C;
											case (TextAlignment)259:
												break;
											case TextAlignment.TopRight:
												goto IL_5126;
											default:
												if (textAlignment4 == TextAlignment.TopJustified || textAlignment4 == TextAlignment.TopFlush)
												{
													goto IL_51A0;
												}
												break;
											}
										}
										else
										{
											if (textAlignment4 == TextAlignment.TopGeoAligned)
											{
												goto IL_50C1;
											}
											switch (textAlignment4)
											{
											case TextAlignment.MiddleLeft:
												goto IL_501A;
											case TextAlignment.MiddleCenter:
												goto IL_507C;
											case (TextAlignment)515:
												break;
											case TextAlignment.MiddleRight:
												goto IL_5126;
											default:
												if (textAlignment4 == TextAlignment.MiddleJustified)
												{
													goto IL_51A0;
												}
												break;
											}
										}
									}
									else if (textAlignment4 <= TextAlignment.BottomRight)
									{
										if (textAlignment4 == TextAlignment.MiddleFlush)
										{
											goto IL_51A0;
										}
										if (textAlignment4 == TextAlignment.MiddleGeoAligned)
										{
											goto IL_50C1;
										}
										switch (textAlignment4)
										{
										case TextAlignment.BottomLeft:
											goto IL_501A;
										case TextAlignment.BottomCenter:
											goto IL_507C;
										case TextAlignment.BottomRight:
											goto IL_5126;
										}
									}
									else
									{
										if (textAlignment4 == TextAlignment.BottomJustified || textAlignment4 == TextAlignment.BottomFlush)
										{
											goto IL_51A0;
										}
										if (textAlignment4 == TextAlignment.BottomGeoAligned)
										{
											goto IL_50C1;
										}
									}
								}
								else if (textAlignment4 <= TextAlignment.MidlineJustified)
								{
									if (textAlignment4 <= TextAlignment.BaselineFlush)
									{
										switch (textAlignment4)
										{
										case TextAlignment.BaselineLeft:
											goto IL_501A;
										case TextAlignment.BaselineCenter:
											goto IL_507C;
										case (TextAlignment)2051:
											break;
										case TextAlignment.BaselineRight:
											goto IL_5126;
										default:
											if (textAlignment4 == TextAlignment.BaselineJustified || textAlignment4 == TextAlignment.BaselineFlush)
											{
												goto IL_51A0;
											}
											break;
										}
									}
									else
									{
										if (textAlignment4 == TextAlignment.BaselineGeoAligned)
										{
											goto IL_50C1;
										}
										switch (textAlignment4)
										{
										case TextAlignment.MidlineLeft:
											goto IL_501A;
										case TextAlignment.MidlineCenter:
											goto IL_507C;
										case (TextAlignment)4099:
											break;
										case TextAlignment.MidlineRight:
											goto IL_5126;
										default:
											if (textAlignment4 == TextAlignment.MidlineJustified)
											{
												goto IL_51A0;
											}
											break;
										}
									}
								}
								else if (textAlignment4 <= TextAlignment.CaplineRight)
								{
									if (textAlignment4 == TextAlignment.MidlineFlush)
									{
										goto IL_51A0;
									}
									if (textAlignment4 == TextAlignment.MidlineGeoAligned)
									{
										goto IL_50C1;
									}
									switch (textAlignment4)
									{
									case TextAlignment.CaplineLeft:
										goto IL_501A;
									case TextAlignment.CaplineCenter:
										goto IL_507C;
									case TextAlignment.CaplineRight:
										goto IL_5126;
									}
								}
								else
								{
									if (textAlignment4 == TextAlignment.CaplineJustified || textAlignment4 == TextAlignment.CaplineFlush)
									{
										goto IL_51A0;
									}
									if (textAlignment4 == TextAlignment.CaplineGeoAligned)
									{
										goto IL_50C1;
									}
								}
								IL_55B9:
								vector8 = a2 + vector7;
								bool isVisible3 = textElementInfo[i].isVisible;
								bool flag159 = isVisible3;
								Vector3 ptr3;
								if (flag159)
								{
									TextElementType elementType = textElementInfo[i].elementType;
									TextElementType textElementType = elementType;
									TextElementType textElementType2 = textElementType;
									if (textElementType2 != TextElementType.Character)
									{
										if (textElementType2 != TextElementType.Sprite)
										{
										}
									}
									else
									{
										Extents lineExtents = lineInfo.lineExtents;
										float num87 = generationSettings.uvLineOffset * (float)lineNumber % 1f;
										switch (generationSettings.horizontalMapping)
										{
										case TextureMapping.Character:
											textElementInfo[i].vertexBottomLeft.uv2.x = 0f;
											textElementInfo[i].vertexTopLeft.uv2.x = 0f;
											textElementInfo[i].vertexTopRight.uv2.x = 1f;
											textElementInfo[i].vertexBottomRight.uv2.x = 1f;
											break;
										case TextureMapping.Line:
										{
											bool flag160 = generationSettings.textAlignment != TextAlignment.MiddleJustified;
											if (flag160)
											{
												textElementInfo[i].vertexBottomLeft.uv2.x = (textElementInfo[i].vertexBottomLeft.position.x - lineExtents.min.x) / (lineExtents.max.x - lineExtents.min.x) + num87;
												textElementInfo[i].vertexTopLeft.uv2.x = (textElementInfo[i].vertexTopLeft.position.x - lineExtents.min.x) / (lineExtents.max.x - lineExtents.min.x) + num87;
												textElementInfo[i].vertexTopRight.uv2.x = (textElementInfo[i].vertexTopRight.position.x - lineExtents.min.x) / (lineExtents.max.x - lineExtents.min.x) + num87;
												textElementInfo[i].vertexBottomRight.uv2.x = (textElementInfo[i].vertexBottomRight.position.x - lineExtents.min.x) / (lineExtents.max.x - lineExtents.min.x) + num87;
											}
											else
											{
												textElementInfo[i].vertexBottomLeft.uv2.x = (textElementInfo[i].vertexBottomLeft.position.x + vector7.x - this.m_MeshExtents.min.x) / (this.m_MeshExtents.max.x - this.m_MeshExtents.min.x) + num87;
												textElementInfo[i].vertexTopLeft.uv2.x = (textElementInfo[i].vertexTopLeft.position.x + vector7.x - this.m_MeshExtents.min.x) / (this.m_MeshExtents.max.x - this.m_MeshExtents.min.x) + num87;
												textElementInfo[i].vertexTopRight.uv2.x = (textElementInfo[i].vertexTopRight.position.x + vector7.x - this.m_MeshExtents.min.x) / (this.m_MeshExtents.max.x - this.m_MeshExtents.min.x) + num87;
												textElementInfo[i].vertexBottomRight.uv2.x = (textElementInfo[i].vertexBottomRight.position.x + vector7.x - this.m_MeshExtents.min.x) / (this.m_MeshExtents.max.x - this.m_MeshExtents.min.x) + num87;
											}
											break;
										}
										case TextureMapping.Paragraph:
											textElementInfo[i].vertexBottomLeft.uv2.x = (textElementInfo[i].vertexBottomLeft.position.x + vector7.x - this.m_MeshExtents.min.x) / (this.m_MeshExtents.max.x - this.m_MeshExtents.min.x) + num87;
											textElementInfo[i].vertexTopLeft.uv2.x = (textElementInfo[i].vertexTopLeft.position.x + vector7.x - this.m_MeshExtents.min.x) / (this.m_MeshExtents.max.x - this.m_MeshExtents.min.x) + num87;
											textElementInfo[i].vertexTopRight.uv2.x = (textElementInfo[i].vertexTopRight.position.x + vector7.x - this.m_MeshExtents.min.x) / (this.m_MeshExtents.max.x - this.m_MeshExtents.min.x) + num87;
											textElementInfo[i].vertexBottomRight.uv2.x = (textElementInfo[i].vertexBottomRight.position.x + vector7.x - this.m_MeshExtents.min.x) / (this.m_MeshExtents.max.x - this.m_MeshExtents.min.x) + num87;
											break;
										case TextureMapping.MatchAspect:
										{
											switch (generationSettings.verticalMapping)
											{
											case TextureMapping.Character:
												textElementInfo[i].vertexBottomLeft.uv2.y = 0f;
												textElementInfo[i].vertexTopLeft.uv2.y = 1f;
												textElementInfo[i].vertexTopRight.uv2.y = 0f;
												textElementInfo[i].vertexBottomRight.uv2.y = 1f;
												break;
											case TextureMapping.Line:
												textElementInfo[i].vertexBottomLeft.uv2.y = (textElementInfo[i].vertexBottomLeft.position.y - lineExtents.min.y) / (lineExtents.max.y - lineExtents.min.y) + num87;
												textElementInfo[i].vertexTopLeft.uv2.y = (textElementInfo[i].vertexTopLeft.position.y - lineExtents.min.y) / (lineExtents.max.y - lineExtents.min.y) + num87;
												textElementInfo[i].vertexTopRight.uv2.y = textElementInfo[i].vertexBottomLeft.uv2.y;
												textElementInfo[i].vertexBottomRight.uv2.y = textElementInfo[i].vertexTopLeft.uv2.y;
												break;
											case TextureMapping.Paragraph:
												textElementInfo[i].vertexBottomLeft.uv2.y = (textElementInfo[i].vertexBottomLeft.position.y - this.m_MeshExtents.min.y) / (this.m_MeshExtents.max.y - this.m_MeshExtents.min.y) + num87;
												textElementInfo[i].vertexTopLeft.uv2.y = (textElementInfo[i].vertexTopLeft.position.y - this.m_MeshExtents.min.y) / (this.m_MeshExtents.max.y - this.m_MeshExtents.min.y) + num87;
												textElementInfo[i].vertexTopRight.uv2.y = textElementInfo[i].vertexBottomLeft.uv2.y;
												textElementInfo[i].vertexBottomRight.uv2.y = textElementInfo[i].vertexTopLeft.uv2.y;
												break;
											case TextureMapping.MatchAspect:
												Debug.Log("ERROR: Cannot Match both Vertical & Horizontal.");
												break;
											}
											float num88 = (1f - (textElementInfo[i].vertexBottomLeft.uv2.y + textElementInfo[i].vertexTopLeft.uv2.y) * textElementInfo[i].aspectRatio) / 2f;
											textElementInfo[i].vertexBottomLeft.uv2.x = textElementInfo[i].vertexBottomLeft.uv2.y * textElementInfo[i].aspectRatio + num88 + num87;
											textElementInfo[i].vertexTopLeft.uv2.x = textElementInfo[i].vertexBottomLeft.uv2.x;
											textElementInfo[i].vertexTopRight.uv2.x = textElementInfo[i].vertexTopLeft.uv2.y * textElementInfo[i].aspectRatio + num88 + num87;
											textElementInfo[i].vertexBottomRight.uv2.x = textElementInfo[i].vertexTopRight.uv2.x;
											break;
										}
										}
										switch (generationSettings.verticalMapping)
										{
										case TextureMapping.Character:
											textElementInfo[i].vertexBottomLeft.uv2.y = 0f;
											textElementInfo[i].vertexTopLeft.uv2.y = 1f;
											textElementInfo[i].vertexTopRight.uv2.y = 1f;
											textElementInfo[i].vertexBottomRight.uv2.y = 0f;
											break;
										case TextureMapping.Line:
											textElementInfo[i].vertexBottomLeft.uv2.y = (textElementInfo[i].vertexBottomLeft.position.y - lineInfo.descender) / (lineInfo.ascender - lineInfo.descender);
											textElementInfo[i].vertexTopLeft.uv2.y = (textElementInfo[i].vertexTopLeft.position.y - lineInfo.descender) / (lineInfo.ascender - lineInfo.descender);
											textElementInfo[i].vertexTopRight.uv2.y = textElementInfo[i].vertexTopLeft.uv2.y;
											textElementInfo[i].vertexBottomRight.uv2.y = textElementInfo[i].vertexBottomLeft.uv2.y;
											break;
										case TextureMapping.Paragraph:
											textElementInfo[i].vertexBottomLeft.uv2.y = (textElementInfo[i].vertexBottomLeft.position.y - this.m_MeshExtents.min.y) / (this.m_MeshExtents.max.y - this.m_MeshExtents.min.y);
											textElementInfo[i].vertexTopLeft.uv2.y = (textElementInfo[i].vertexTopLeft.position.y - this.m_MeshExtents.min.y) / (this.m_MeshExtents.max.y - this.m_MeshExtents.min.y);
											textElementInfo[i].vertexTopRight.uv2.y = textElementInfo[i].vertexTopLeft.uv2.y;
											textElementInfo[i].vertexBottomRight.uv2.y = textElementInfo[i].vertexBottomLeft.uv2.y;
											break;
										case TextureMapping.MatchAspect:
										{
											float num89 = (1f - (textElementInfo[i].vertexBottomLeft.uv2.x + textElementInfo[i].vertexTopRight.uv2.x) / textElementInfo[i].aspectRatio) / 2f;
											textElementInfo[i].vertexBottomLeft.uv2.y = num89 + textElementInfo[i].vertexBottomLeft.uv2.x / textElementInfo[i].aspectRatio;
											textElementInfo[i].vertexTopLeft.uv2.y = num89 + textElementInfo[i].vertexTopRight.uv2.x / textElementInfo[i].aspectRatio;
											textElementInfo[i].vertexBottomRight.uv2.y = textElementInfo[i].vertexBottomLeft.uv2.y;
											textElementInfo[i].vertexTopRight.uv2.y = textElementInfo[i].vertexTopLeft.uv2.y;
											break;
										}
										}
										num79 = textElementInfo[i].scale * (1f - this.m_CharWidthAdjDelta) * 1f;
										bool flag161 = !textElementInfo[i].isUsingAlternateTypeface && (textElementInfo[i].style & FontStyles.Bold) == FontStyles.Bold;
										if (flag161)
										{
											num79 *= -1f;
										}
										textElementInfo[i].vertexBottomLeft.uv.w = num79;
										textElementInfo[i].vertexTopLeft.uv.w = num79;
										textElementInfo[i].vertexTopRight.uv.w = num79;
										textElementInfo[i].vertexBottomRight.uv.w = num79;
										textElementInfo[i].vertexBottomLeft.uv2.x = 1f;
										textElementInfo[i].vertexBottomLeft.uv2.y = num79;
										textElementInfo[i].vertexTopLeft.uv2.x = 1f;
										textElementInfo[i].vertexTopLeft.uv2.y = num79;
										textElementInfo[i].vertexTopRight.uv2.x = 1f;
										textElementInfo[i].vertexTopRight.uv2.y = num79;
										textElementInfo[i].vertexBottomRight.uv2.x = 1f;
										textElementInfo[i].vertexBottomRight.uv2.y = num79;
									}
									bool flag162 = i < generationSettings.maxVisibleCharacters && num76 < generationSettings.maxVisibleWords && lineNumber < generationSettings.maxVisibleLines && generationSettings.overflowMode != TextOverflowMode.Page;
									if (flag162)
									{
										ptr3 = ref textElementInfo[i].vertexBottomLeft.position;
										ptr3 += vector8;
										ptr3 = ref textElementInfo[i].vertexTopLeft.position;
										ptr3 += vector8;
										ptr3 = ref textElementInfo[i].vertexTopRight.position;
										ptr3 += vector8;
										ptr3 = ref textElementInfo[i].vertexBottomRight.position;
										ptr3 += vector8;
									}
									else
									{
										bool flag163 = i < generationSettings.maxVisibleCharacters && num76 < generationSettings.maxVisibleWords && lineNumber < generationSettings.maxVisibleLines && generationSettings.overflowMode == TextOverflowMode.Page && textElementInfo[i].pageNumber == num7;
										if (flag163)
										{
											ptr3 = ref textElementInfo[i].vertexBottomLeft.position;
											ptr3 += vector8;
											ptr3 = ref textElementInfo[i].vertexTopLeft.position;
											ptr3 += vector8;
											ptr3 = ref textElementInfo[i].vertexTopRight.position;
											ptr3 += vector8;
											ptr3 = ref textElementInfo[i].vertexBottomRight.position;
											ptr3 += vector8;
										}
										else
										{
											textElementInfo[i].vertexBottomLeft.position = Vector3.zero;
											textElementInfo[i].vertexTopLeft.position = Vector3.zero;
											textElementInfo[i].vertexTopRight.position = Vector3.zero;
											textElementInfo[i].vertexBottomRight.position = Vector3.zero;
											textElementInfo[i].isVisible = false;
										}
									}
									bool convertToLinearSpace = QualitySettings.activeColorSpace == ColorSpace.Linear && generationSettings.shouldConvertToLinearSpace;
									bool flag164 = elementType == TextElementType.Character;
									if (flag164)
									{
										TextGeneratorUtilities.FillCharacterVertexBuffers(i, convertToLinearSpace, generationSettings, textInfo);
									}
									else
									{
										bool flag165 = elementType == TextElementType.Sprite;
										if (flag165)
										{
											TextGeneratorUtilities.FillSpriteVertexBuffers(i, convertToLinearSpace, generationSettings, textInfo);
										}
									}
								}
								ptr3 = ref textInfo.textElementInfo[i].bottomLeft;
								ptr3 += vector8;
								ptr3 = ref textInfo.textElementInfo[i].topLeft;
								ptr3 += vector8;
								ptr3 = ref textInfo.textElementInfo[i].topRight;
								ptr3 += vector8;
								ptr3 = ref textInfo.textElementInfo[i].bottomRight;
								ptr3 += vector8;
								ref float ptr2 = ref textInfo.textElementInfo[i].origin;
								ptr2 += vector8.x;
								ptr2 = ref textInfo.textElementInfo[i].xAdvance;
								ptr2 += vector8.x;
								ptr2 = ref textInfo.textElementInfo[i].ascender;
								ptr2 += vector8.y;
								ptr2 = ref textInfo.textElementInfo[i].descender;
								ptr2 += vector8.y;
								ptr2 = ref textInfo.textElementInfo[i].baseLine;
								ptr2 += vector8.y;
								bool flag166 = isVisible3;
								if (flag166)
								{
								}
								bool flag167 = lineNumber != num77 || i == this.m_CharacterCount - 1;
								if (flag167)
								{
									bool flag168 = lineNumber != num77;
									if (flag168)
									{
										ptr2 = ref textInfo.lineInfo[num77].baseline;
										ptr2 += vector8.y;
										ptr2 = ref textInfo.lineInfo[num77].ascender;
										ptr2 += vector8.y;
										ptr2 = ref textInfo.lineInfo[num77].descender;
										ptr2 += vector8.y;
										ptr2 = ref textInfo.lineInfo[num77].maxAdvance;
										ptr2 += vector8.x;
										textInfo.lineInfo[num77].lineExtents.min = new Vector2(textInfo.textElementInfo[textInfo.lineInfo[num77].firstCharacterIndex].bottomLeft.x, textInfo.lineInfo[num77].descender);
										textInfo.lineInfo[num77].lineExtents.max = new Vector2(textInfo.textElementInfo[textInfo.lineInfo[num77].lastVisibleCharacterIndex].topRight.x, textInfo.lineInfo[num77].ascender);
									}
									bool flag169 = i == this.m_CharacterCount - 1;
									if (flag169)
									{
										ptr2 = ref textInfo.lineInfo[lineNumber].baseline;
										ptr2 += vector8.y;
										ptr2 = ref textInfo.lineInfo[lineNumber].ascender;
										ptr2 += vector8.y;
										ptr2 = ref textInfo.lineInfo[lineNumber].descender;
										ptr2 += vector8.y;
										ptr2 = ref textInfo.lineInfo[lineNumber].maxAdvance;
										ptr2 += vector8.x;
										textInfo.lineInfo[lineNumber].lineExtents.min = new Vector2(textInfo.textElementInfo[textInfo.lineInfo[lineNumber].firstCharacterIndex].bottomLeft.x, textInfo.lineInfo[lineNumber].descender);
										textInfo.lineInfo[lineNumber].lineExtents.max = new Vector2(textInfo.textElementInfo[textInfo.lineInfo[lineNumber].lastVisibleCharacterIndex].topRight.x, textInfo.lineInfo[lineNumber].ascender);
									}
								}
								bool flag170 = char.IsLetterOrDigit(character) || character == '-' || character == '­' || character == '‐' || character == '‑';
								if (flag170)
								{
									bool flag171 = !flag157;
									if (flag171)
									{
										flag157 = true;
										num78 = i;
									}
									bool flag172 = flag157 && i == this.m_CharacterCount - 1;
									if (flag172)
									{
										int num90 = textInfo.wordInfo.Length;
										int wordCount = textInfo.wordCount;
										bool flag173 = textInfo.wordCount + 1 > num90;
										if (flag173)
										{
											TextInfo.Resize<WordInfo>(ref textInfo.wordInfo, num90 + 1);
										}
										int num91 = i;
										textInfo.wordInfo[wordCount].firstCharacterIndex = num78;
										textInfo.wordInfo[wordCount].lastCharacterIndex = num91;
										textInfo.wordInfo[wordCount].characterCount = num91 - num78 + 1;
										num76++;
										textInfo.wordCount++;
										ref int ptr = ref textInfo.lineInfo[lineNumber].wordCount;
										ptr++;
									}
								}
								else
								{
									bool flag174 = flag157 || (i == 0 && (!char.IsPunctuation(character) || flag158 || character == '​' || i == this.m_CharacterCount - 1));
									if (flag174)
									{
										bool flag175 = i > 0 && i < textElementInfo.Length - 1 && i < this.m_CharacterCount && (character == '\'' || character == '’') && char.IsLetterOrDigit(textElementInfo[i - 1].character) && char.IsLetterOrDigit(textElementInfo[i + 1].character);
										if (!flag175)
										{
											int num91 = (i == this.m_CharacterCount - 1 && char.IsLetterOrDigit(character)) ? i : (i - 1);
											flag157 = false;
											int num92 = textInfo.wordInfo.Length;
											int wordCount2 = textInfo.wordCount;
											bool flag176 = textInfo.wordCount + 1 > num92;
											if (flag176)
											{
												TextInfo.Resize<WordInfo>(ref textInfo.wordInfo, num92 + 1);
											}
											textInfo.wordInfo[wordCount2].firstCharacterIndex = num78;
											textInfo.wordInfo[wordCount2].lastCharacterIndex = num91;
											textInfo.wordInfo[wordCount2].characterCount = num91 - num78 + 1;
											num76++;
											textInfo.wordCount++;
											ref int ptr = ref textInfo.lineInfo[lineNumber].wordCount;
											ptr++;
										}
									}
								}
								bool flag177 = (textInfo.textElementInfo[i].style & FontStyles.Underline) == FontStyles.Underline;
								bool flag178 = flag177;
								if (flag178)
								{
									bool flag179 = true;
									int pageNumber = textInfo.textElementInfo[i].pageNumber;
									textInfo.textElementInfo[i].underlineVertexIndex = this.m_MaterialReferences[this.m_Underline.materialIndex].referenceCount * 4;
									bool flag180 = i > generationSettings.maxVisibleCharacters || lineNumber > generationSettings.maxVisibleLines || (generationSettings.overflowMode == TextOverflowMode.Page && pageNumber + 1 != generationSettings.pageToDisplay);
									if (flag180)
									{
										flag179 = false;
									}
									bool flag181 = !flag158 && character != '​';
									if (flag181)
									{
										num82 = Mathf.Max(num82, textInfo.textElementInfo[i].scale);
										num80 = Mathf.Max(num80, Mathf.Abs(num79));
										num83 = Mathf.Min((pageNumber == num84) ? num83 : 32767f, textInfo.textElementInfo[i].baseLine + fontAsset.faceInfo.underlineOffset * num82);
										num84 = pageNumber;
									}
									bool flag182 = !flag4 && flag179 && i <= lineInfo.lastVisibleCharacterIndex && character != '\n' && character != '\v' && character != '\r';
									if (flag182)
									{
										bool flag183 = i == lineInfo.lastVisibleCharacterIndex && char.IsSeparator(character);
										if (!flag183)
										{
											flag4 = true;
											num81 = textInfo.textElementInfo[i].scale;
											bool flag184 = num82 == 0f;
											if (flag184)
											{
												num82 = num81;
												num80 = num79;
											}
											zero = new Vector3(textInfo.textElementInfo[i].bottomLeft.x, num83, 0f);
											color = textInfo.textElementInfo[i].underlineColor;
										}
									}
									bool flag185 = flag4 && this.m_CharacterCount == 1;
									if (flag185)
									{
										flag4 = false;
										zero2 = new Vector3(textInfo.textElementInfo[i].topRight.x, num83, 0f);
										float scale = textInfo.textElementInfo[i].scale;
										this.DrawUnderlineMesh(zero, zero2, num81, scale, num82, num80, color, generationSettings, textInfo);
										num82 = 0f;
										num80 = 0f;
										num83 = 32767f;
									}
									else
									{
										bool flag186 = flag4 && (i == lineInfo.lastCharacterIndex || i >= lineInfo.lastVisibleCharacterIndex);
										if (flag186)
										{
											bool flag187 = flag158 || character == '​';
											float scale;
											if (flag187)
											{
												int lastVisibleCharacterIndex = lineInfo.lastVisibleCharacterIndex;
												zero2 = new Vector3(textInfo.textElementInfo[lastVisibleCharacterIndex].topRight.x, num83, 0f);
												scale = textInfo.textElementInfo[lastVisibleCharacterIndex].scale;
											}
											else
											{
												zero2 = new Vector3(textInfo.textElementInfo[i].topRight.x, num83, 0f);
												scale = textInfo.textElementInfo[i].scale;
											}
											flag4 = false;
											this.DrawUnderlineMesh(zero, zero2, num81, scale, num82, num80, color, generationSettings, textInfo);
											num82 = 0f;
											num80 = 0f;
											num83 = 32767f;
										}
										else
										{
											bool flag188 = flag4 && !flag179;
											if (flag188)
											{
												flag4 = false;
												zero2 = new Vector3(textInfo.textElementInfo[i - 1].topRight.x, num83, 0f);
												float scale = textInfo.textElementInfo[i - 1].scale;
												this.DrawUnderlineMesh(zero, zero2, num81, scale, num82, num80, color, generationSettings, textInfo);
												num82 = 0f;
												num80 = 0f;
												num83 = 32767f;
											}
											else
											{
												bool flag189 = flag4 && i < this.m_CharacterCount - 1 && !ColorUtilities.CompareColors(color, textInfo.textElementInfo[i + 1].underlineColor);
												if (flag189)
												{
													flag4 = false;
													zero2 = new Vector3(textInfo.textElementInfo[i].topRight.x, num83, 0f);
													float scale = textInfo.textElementInfo[i].scale;
													this.DrawUnderlineMesh(zero, zero2, num81, scale, num82, num80, color, generationSettings, textInfo);
													num82 = 0f;
													num80 = 0f;
													num83 = 32767f;
												}
											}
										}
									}
								}
								else
								{
									bool flag190 = flag4;
									if (flag190)
									{
										flag4 = false;
										zero2 = new Vector3(textInfo.textElementInfo[i - 1].topRight.x, num83, 0f);
										float scale = textInfo.textElementInfo[i - 1].scale;
										this.DrawUnderlineMesh(zero, zero2, num81, scale, num82, num80, color, generationSettings, textInfo);
										num82 = 0f;
										num80 = 0f;
										num83 = 32767f;
									}
								}
								bool flag191 = (textInfo.textElementInfo[i].style & FontStyles.Strikethrough) == FontStyles.Strikethrough;
								float strikethroughOffset = fontAsset.faceInfo.strikethroughOffset;
								bool flag192 = flag191;
								if (flag192)
								{
									bool flag193 = true;
									textInfo.textElementInfo[i].strikethroughVertexIndex = this.m_MaterialReferences[this.m_Underline.materialIndex].referenceCount * 4;
									bool flag194 = i > generationSettings.maxVisibleCharacters || lineNumber > generationSettings.maxVisibleLines || (generationSettings.overflowMode == TextOverflowMode.Page && textInfo.textElementInfo[i].pageNumber + 1 != generationSettings.pageToDisplay);
									if (flag194)
									{
										flag193 = false;
									}
									bool flag195 = !flag5 && flag193 && i <= lineInfo.lastVisibleCharacterIndex && character != '\n' && character != '\v' && character != '\r';
									if (flag195)
									{
										bool flag196 = i == lineInfo.lastVisibleCharacterIndex && char.IsSeparator(character);
										if (!flag196)
										{
											flag5 = true;
											num85 = textInfo.textElementInfo[i].pointSize;
											num86 = textInfo.textElementInfo[i].scale;
											zero3 = new Vector3(textInfo.textElementInfo[i].bottomLeft.x, textInfo.textElementInfo[i].baseLine + strikethroughOffset * num86, 0f);
											underlineColor = textInfo.textElementInfo[i].strikethroughColor;
											b4 = textInfo.textElementInfo[i].baseLine;
										}
									}
									bool flag197 = flag5 && this.m_CharacterCount == 1;
									if (flag197)
									{
										flag5 = false;
										zero4 = new Vector3(textInfo.textElementInfo[i].topRight.x, textInfo.textElementInfo[i].baseLine + strikethroughOffset * num86, 0f);
										this.DrawUnderlineMesh(zero3, zero4, num86, num86, num86, num79, underlineColor, generationSettings, textInfo);
									}
									else
									{
										bool flag198 = flag5 && i == lineInfo.lastCharacterIndex;
										if (flag198)
										{
											bool flag199 = flag158 || character == '​';
											if (flag199)
											{
												int lastVisibleCharacterIndex2 = lineInfo.lastVisibleCharacterIndex;
												zero4 = new Vector3(textInfo.textElementInfo[lastVisibleCharacterIndex2].topRight.x, textInfo.textElementInfo[lastVisibleCharacterIndex2].baseLine + strikethroughOffset * num86, 0f);
											}
											else
											{
												zero4 = new Vector3(textInfo.textElementInfo[i].topRight.x, textInfo.textElementInfo[i].baseLine + strikethroughOffset * num86, 0f);
											}
											flag5 = false;
											this.DrawUnderlineMesh(zero3, zero4, num86, num86, num86, num79, underlineColor, generationSettings, textInfo);
										}
										else
										{
											bool flag200 = flag5 && i < this.m_CharacterCount && (textInfo.textElementInfo[i + 1].pointSize != num85 || !TextGeneratorUtilities.Approximately(textInfo.textElementInfo[i + 1].baseLine + vector8.y, b4));
											if (flag200)
											{
												flag5 = false;
												int lastVisibleCharacterIndex3 = lineInfo.lastVisibleCharacterIndex;
												bool flag201 = i > lastVisibleCharacterIndex3;
												if (flag201)
												{
													zero4 = new Vector3(textInfo.textElementInfo[lastVisibleCharacterIndex3].topRight.x, textInfo.textElementInfo[lastVisibleCharacterIndex3].baseLine + strikethroughOffset * num86, 0f);
												}
												else
												{
													zero4 = new Vector3(textInfo.textElementInfo[i].topRight.x, textInfo.textElementInfo[i].baseLine + strikethroughOffset * num86, 0f);
												}
												this.DrawUnderlineMesh(zero3, zero4, num86, num86, num86, num79, underlineColor, generationSettings, textInfo);
											}
											else
											{
												bool flag202 = flag5 && i < this.m_CharacterCount && fontAsset.GetInstanceID() != textElementInfo[i + 1].fontAsset.GetInstanceID();
												if (flag202)
												{
													flag5 = false;
													zero4 = new Vector3(textInfo.textElementInfo[i].topRight.x, textInfo.textElementInfo[i].baseLine + strikethroughOffset * num86, 0f);
													this.DrawUnderlineMesh(zero3, zero4, num86, num86, num86, num79, underlineColor, generationSettings, textInfo);
												}
												else
												{
													bool flag203 = flag5 && !flag193;
													if (flag203)
													{
														flag5 = false;
														zero4 = new Vector3(textInfo.textElementInfo[i - 1].topRight.x, textInfo.textElementInfo[i - 1].baseLine + strikethroughOffset * num86, 0f);
														this.DrawUnderlineMesh(zero3, zero4, num86, num86, num86, num79, underlineColor, generationSettings, textInfo);
													}
												}
											}
										}
									}
								}
								else
								{
									bool flag204 = flag5;
									if (flag204)
									{
										flag5 = false;
										zero4 = new Vector3(textInfo.textElementInfo[i - 1].topRight.x, textInfo.textElementInfo[i - 1].baseLine + strikethroughOffset * num86, 0f);
										this.DrawUnderlineMesh(zero3, zero4, num86, num86, num86, num79, underlineColor, generationSettings, textInfo);
									}
								}
								bool flag205 = (textInfo.textElementInfo[i].style & FontStyles.Highlight) == FontStyles.Highlight;
								bool flag206 = flag205;
								if (flag206)
								{
									bool flag207 = true;
									int pageNumber2 = textInfo.textElementInfo[i].pageNumber;
									bool flag208 = i > generationSettings.maxVisibleCharacters || lineNumber > generationSettings.maxVisibleLines || (generationSettings.overflowMode == TextOverflowMode.Page && pageNumber2 + 1 != generationSettings.pageToDisplay);
									if (flag208)
									{
										flag207 = false;
									}
									bool flag209 = !flag6 && flag207 && i <= lineInfo.lastVisibleCharacterIndex && character != '\n' && character != '\v' && character != '\r';
									if (flag209)
									{
										bool flag210 = i == lineInfo.lastVisibleCharacterIndex && char.IsSeparator(character);
										if (!flag210)
										{
											flag6 = true;
											vector = TextGeneratorUtilities.largePositiveVector2;
											vector2 = TextGeneratorUtilities.largeNegativeVector2;
											highlightState = textInfo.textElementInfo[i].highlightState;
										}
									}
									bool flag211 = flag6;
									if (flag211)
									{
										TextElementInfo textElementInfo2 = textInfo.textElementInfo[i];
										HighlightState highlightState2 = textElementInfo2.highlightState;
										bool flag212 = false;
										bool flag213 = highlightState != highlightState2;
										if (flag213)
										{
											bool flag214 = flag158;
											if (flag214)
											{
												vector2.x = (vector2.x - highlightState.padding.right + textElementInfo2.origin) / 2f;
											}
											else
											{
												vector2.x = (vector2.x - highlightState.padding.right + textElementInfo2.bottomLeft.x) / 2f;
											}
											vector.y = Mathf.Min(vector.y, textElementInfo2.descender);
											vector2.y = Mathf.Max(vector2.y, textElementInfo2.ascender);
											this.DrawTextHighlight(vector, vector2, highlightState.color, generationSettings, textInfo);
											flag6 = true;
											vector = new Vector2(vector2.x, textElementInfo2.descender - highlightState2.padding.bottom);
											bool flag215 = flag158;
											if (flag215)
											{
												vector2 = new Vector2(textElementInfo2.xAdvance + highlightState2.padding.right, textElementInfo2.ascender + highlightState2.padding.top);
											}
											else
											{
												vector2 = new Vector2(textElementInfo2.topRight.x + highlightState2.padding.right, textElementInfo2.ascender + highlightState2.padding.top);
											}
											highlightState = highlightState2;
											flag212 = true;
										}
										bool flag216 = !flag212;
										if (flag216)
										{
											bool flag217 = flag158;
											if (flag217)
											{
												vector.x = Mathf.Min(vector.x, textElementInfo2.origin - highlightState.padding.left);
												vector2.x = Mathf.Max(vector2.x, textElementInfo2.xAdvance + highlightState.padding.right);
											}
											else
											{
												vector.x = Mathf.Min(vector.x, textElementInfo2.bottomLeft.x - highlightState.padding.left);
												vector2.x = Mathf.Max(vector2.x, textElementInfo2.topRight.x + highlightState.padding.right);
											}
											vector.y = Mathf.Min(vector.y, textElementInfo2.descender - highlightState.padding.bottom);
											vector2.y = Mathf.Max(vector2.y, textElementInfo2.ascender + highlightState.padding.top);
										}
									}
									bool flag218 = flag6 && this.m_CharacterCount == 1;
									if (flag218)
									{
										flag6 = false;
										this.DrawTextHighlight(vector, vector2, highlightState.color, generationSettings, textInfo);
									}
									else
									{
										bool flag219 = flag6 && (i == lineInfo.lastCharacterIndex || i >= lineInfo.lastVisibleCharacterIndex);
										if (flag219)
										{
											flag6 = false;
											this.DrawTextHighlight(vector, vector2, highlightState.color, generationSettings, textInfo);
										}
										else
										{
											bool flag220 = flag6 && !flag207;
											if (flag220)
											{
												flag6 = false;
												this.DrawTextHighlight(vector, vector2, highlightState.color, generationSettings, textInfo);
											}
										}
									}
								}
								else
								{
									bool flag221 = flag6;
									if (flag221)
									{
										flag6 = false;
										this.DrawTextHighlight(vector, vector2, highlightState.color, generationSettings, textInfo);
									}
								}
								num77 = lineNumber;
								num34 = i;
								i = num34 + 1;
								continue;
								IL_501A:
								bool flag222 = !generationSettings.isRightToLeft;
								if (flag222)
								{
									vector7 = new Vector3(0f + lineInfo.marginLeft, 0f, 0f);
								}
								else
								{
									vector7 = new Vector3(0f - lineInfo.maxAdvance, 0f, 0f);
								}
								goto IL_55B9;
								IL_507C:
								vector7 = new Vector3(lineInfo.marginLeft + lineInfo.width / 2f - lineInfo.maxAdvance / 2f, 0f, 0f);
								goto IL_55B9;
								IL_50C1:
								vector7 = new Vector3(lineInfo.marginLeft + lineInfo.width / 2f - (lineInfo.lineExtents.min.x + lineInfo.lineExtents.max.x) / 2f, 0f, 0f);
								goto IL_55B9;
								IL_5126:
								bool flag223 = !generationSettings.isRightToLeft;
								if (flag223)
								{
									vector7 = new Vector3(lineInfo.marginLeft + lineInfo.width - lineInfo.maxAdvance, 0f, 0f);
								}
								else
								{
									vector7 = new Vector3(lineInfo.marginLeft + lineInfo.width, 0f, 0f);
								}
								goto IL_55B9;
								IL_51A0:
								bool flag224 = i > lineInfo.lastVisibleCharacterIndex || character == '\n' || character == '­' || character == '​' || character == '⁠' || character == '\u0003';
								if (flag224)
								{
									goto IL_55B9;
								}
								char character2 = textElementInfo[lineInfo.lastCharacterIndex].character;
								bool flag225 = (alignment & (TextAlignment)16) == (TextAlignment)16;
								bool flag226 = (!char.IsControl(character2) && lineNumber < this.m_LineNumber) || flag225 || lineInfo.maxAdvance > lineInfo.width;
								if (flag226)
								{
									bool flag227 = lineNumber != num77 || i == 0 || i == generationSettings.firstVisibleCharacter;
									if (flag227)
									{
										bool flag228 = !generationSettings.isRightToLeft;
										if (flag228)
										{
											vector7 = new Vector3(lineInfo.marginLeft, 0f, 0f);
										}
										else
										{
											vector7 = new Vector3(lineInfo.marginLeft + lineInfo.width, 0f, 0f);
										}
										bool flag229 = char.IsSeparator(character);
										flag156 = flag229;
									}
									else
									{
										float num93 = (!generationSettings.isRightToLeft) ? (lineInfo.width - lineInfo.maxAdvance) : (lineInfo.width + lineInfo.maxAdvance);
										int num94 = lineInfo.visibleCharacterCount - 1 + lineInfo.controlCharacterCount;
										int num95 = lineInfo.spaceCount - lineInfo.controlCharacterCount;
										bool flag230 = flag156;
										if (flag230)
										{
											num95--;
											num94++;
										}
										float num96 = (num95 > 0) ? generationSettings.wordWrappingRatio : 1f;
										bool flag231 = num95 < 1;
										if (flag231)
										{
											num95 = 1;
										}
										bool flag232 = character != '\u00a0' && (character == '\t' || char.IsSeparator(character));
										if (flag232)
										{
											bool flag233 = !generationSettings.isRightToLeft;
											if (flag233)
											{
												vector7 += new Vector3(num93 * (1f - num96) / (float)num95, 0f, 0f);
											}
											else
											{
												vector7 -= new Vector3(num93 * (1f - num96) / (float)num95, 0f, 0f);
											}
										}
										else
										{
											bool flag234 = !generationSettings.isRightToLeft;
											if (flag234)
											{
												vector7 += new Vector3(num93 * num96 / (float)num94, 0f, 0f);
											}
											else
											{
												vector7 -= new Vector3(num93 * num96 / (float)num94, 0f, 0f);
											}
										}
									}
								}
								else
								{
									bool flag235 = !generationSettings.isRightToLeft;
									if (flag235)
									{
										vector7 = new Vector3(lineInfo.marginLeft, 0f, 0f);
									}
									else
									{
										vector7 = new Vector3(lineInfo.marginLeft + lineInfo.width, 0f, 0f);
									}
								}
								goto IL_55B9;
							}
							textInfo.characterCount = this.m_CharacterCount;
							textInfo.spriteCount = this.m_SpriteCount;
							textInfo.lineCount = lineCount;
							textInfo.wordCount = ((num76 != 0 && this.m_CharacterCount > 0) ? num76 : 1);
							textInfo.pageCount = this.m_PageNumber + 1;
							for (int j = 1; j < textInfo.materialCount; j = num34 + 1)
							{
								textInfo.meshInfo[j].ClearUnusedVertices();
								bool flag236 = generationSettings.geometrySortingOrder > VertexSortingOrder.Normal;
								if (flag236)
								{
									textInfo.meshInfo[j].SortGeometry(VertexSortingOrder.Reverse);
								}
								num34 = j;
							}
						}
					}
				}
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00012854 File Offset: 0x00010A54
		private void SaveWordWrappingState(ref WordWrapState state, int index, int count, TextInfo textInfo)
		{
			state.currentFontAsset = this.m_CurrentFontAsset;
			state.currentSpriteAsset = this.m_CurrentSpriteAsset;
			state.currentMaterial = this.m_CurrentMaterial;
			state.currentMaterialIndex = this.m_CurrentMaterialIndex;
			state.previousWordBreak = index;
			state.totalCharacterCount = count;
			state.visibleCharacterCount = this.m_LineVisibleCharacterCount;
			state.visibleSpaceCount = this.m_LineVisibleSpaceCount;
			state.visibleLinkCount = textInfo.linkCount;
			state.firstCharacterIndex = this.m_FirstCharacterOfLine;
			state.firstVisibleCharacterIndex = this.m_FirstVisibleCharacterOfLine;
			state.lastVisibleCharIndex = this.m_LastVisibleCharacterOfLine;
			state.fontStyle = this.m_FontStyleInternal;
			state.italicAngle = this.m_ItalicAngle;
			state.fontScaleMultiplier = this.m_FontScaleMultiplier;
			state.currentFontSize = this.m_CurrentFontSize;
			state.xAdvance = this.m_XAdvance;
			state.maxCapHeight = this.m_MaxCapHeight;
			state.maxAscender = this.m_MaxAscender;
			state.maxDescender = this.m_MaxDescender;
			state.maxLineAscender = this.m_MaxLineAscender;
			state.maxLineDescender = this.m_MaxLineDescender;
			state.startOfLineAscender = this.m_StartOfLineAscender;
			state.preferredWidth = this.m_PreferredWidth;
			state.preferredHeight = this.m_PreferredHeight;
			state.meshExtents = this.m_MeshExtents;
			state.pageAscender = this.m_PageAscender;
			state.lineNumber = this.m_LineNumber;
			state.lineOffset = this.m_LineOffset;
			state.baselineOffset = this.m_BaselineOffset;
			state.isDrivenLineSpacing = this.m_IsDrivenLineSpacing;
			state.vertexColor = this.m_HtmlColor;
			state.underlineColor = this.m_UnderlineColor;
			state.strikethroughColor = this.m_StrikethroughColor;
			state.highlightColor = this.m_HighlightColor;
			state.highlightState = this.m_HighlightState;
			state.isNonBreakingSpace = this.m_IsNonBreakingSpace;
			state.tagNoParsing = this.m_TagNoParsing;
			state.fxScale = this.m_FXScale;
			state.fxRotation = this.m_FXRotation;
			state.basicStyleStack = this.m_FontStyleStack;
			state.italicAngleStack = this.m_ItalicAngleStack;
			state.colorStack = this.m_ColorStack;
			state.underlineColorStack = this.m_UnderlineColorStack;
			state.strikethroughColorStack = this.m_StrikethroughColorStack;
			state.highlightColorStack = this.m_HighlightColorStack;
			state.colorGradientStack = this.m_ColorGradientStack;
			state.highlightStateStack = this.m_HighlightStateStack;
			state.sizeStack = this.m_SizeStack;
			state.indentStack = this.m_IndentStack;
			state.fontWeightStack = this.m_FontWeightStack;
			state.styleStack = this.m_StyleStack;
			state.baselineStack = this.m_BaselineOffsetStack;
			state.actionStack = this.m_ActionStack;
			state.materialReferenceStack = this.m_MaterialReferenceStack;
			state.lineJustificationStack = this.m_LineJustificationStack;
			state.lastBaseGlyphIndex = this.m_LastBaseGlyphIndex;
			state.spriteAnimationId = this.m_SpriteAnimationId;
			bool flag = this.m_LineNumber < textInfo.lineInfo.Length;
			if (flag)
			{
				state.lineInfo = textInfo.lineInfo[this.m_LineNumber];
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00012B40 File Offset: 0x00010D40
		protected int RestoreWordWrappingState(ref WordWrapState state, TextInfo textInfo)
		{
			int previousWordBreak = state.previousWordBreak;
			this.m_CurrentFontAsset = state.currentFontAsset;
			this.m_CurrentSpriteAsset = state.currentSpriteAsset;
			this.m_CurrentMaterial = state.currentMaterial;
			this.m_CurrentMaterialIndex = state.currentMaterialIndex;
			this.m_CharacterCount = state.totalCharacterCount + 1;
			this.m_LineVisibleCharacterCount = state.visibleCharacterCount;
			this.m_LineVisibleSpaceCount = state.visibleSpaceCount;
			textInfo.linkCount = state.visibleLinkCount;
			this.m_FirstCharacterOfLine = state.firstCharacterIndex;
			this.m_FirstVisibleCharacterOfLine = state.firstVisibleCharacterIndex;
			this.m_LastVisibleCharacterOfLine = state.lastVisibleCharIndex;
			this.m_FontStyleInternal = state.fontStyle;
			this.m_ItalicAngle = state.italicAngle;
			this.m_FontScaleMultiplier = state.fontScaleMultiplier;
			this.m_CurrentFontSize = state.currentFontSize;
			this.m_XAdvance = state.xAdvance;
			this.m_MaxCapHeight = state.maxCapHeight;
			this.m_MaxAscender = state.maxAscender;
			this.m_MaxDescender = state.maxDescender;
			this.m_MaxLineAscender = state.maxLineAscender;
			this.m_MaxLineDescender = state.maxLineDescender;
			this.m_StartOfLineAscender = state.startOfLineAscender;
			this.m_PreferredWidth = state.preferredWidth;
			this.m_PreferredHeight = state.preferredHeight;
			this.m_MeshExtents = state.meshExtents;
			this.m_PageAscender = state.pageAscender;
			this.m_LineNumber = state.lineNumber;
			this.m_LineOffset = state.lineOffset;
			this.m_BaselineOffset = state.baselineOffset;
			this.m_IsDrivenLineSpacing = state.isDrivenLineSpacing;
			this.m_HtmlColor = state.vertexColor;
			this.m_UnderlineColor = state.underlineColor;
			this.m_StrikethroughColor = state.strikethroughColor;
			this.m_HighlightColor = state.highlightColor;
			this.m_HighlightState = state.highlightState;
			this.m_IsNonBreakingSpace = state.isNonBreakingSpace;
			this.m_TagNoParsing = state.tagNoParsing;
			this.m_FXScale = state.fxScale;
			this.m_FXRotation = state.fxRotation;
			this.m_FontStyleStack = state.basicStyleStack;
			this.m_ItalicAngleStack = state.italicAngleStack;
			this.m_ColorStack = state.colorStack;
			this.m_UnderlineColorStack = state.underlineColorStack;
			this.m_StrikethroughColorStack = state.strikethroughColorStack;
			this.m_HighlightColorStack = state.highlightColorStack;
			this.m_ColorGradientStack = state.colorGradientStack;
			this.m_HighlightStateStack = state.highlightStateStack;
			this.m_SizeStack = state.sizeStack;
			this.m_IndentStack = state.indentStack;
			this.m_FontWeightStack = state.fontWeightStack;
			this.m_StyleStack = state.styleStack;
			this.m_BaselineOffsetStack = state.baselineStack;
			this.m_ActionStack = state.actionStack;
			this.m_MaterialReferenceStack = state.materialReferenceStack;
			this.m_LineJustificationStack = state.lineJustificationStack;
			this.m_LastBaseGlyphIndex = state.lastBaseGlyphIndex;
			this.m_SpriteAnimationId = state.spriteAnimationId;
			bool flag = this.m_LineNumber < textInfo.lineInfo.Length;
			if (flag)
			{
				textInfo.lineInfo[this.m_LineNumber] = state.lineInfo;
			}
			return previousWordBreak;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00012E34 File Offset: 0x00011034
		protected bool ValidateHtmlTag(TextProcessingElement[] chars, int startIndex, out int endIndex, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			TextSettings textSettings = generationSettings.textSettings;
			int num = 0;
			byte b = 0;
			int num2 = 0;
			this.ClearMarkupTagAttributes();
			TagValueType tagValueType = TagValueType.None;
			TagUnitType tagUnitType = TagUnitType.Pixels;
			endIndex = startIndex;
			bool flag = false;
			bool flag2 = false;
			int num3 = startIndex;
			while (num3 < chars.Length && chars[num3].unicode != 0U && num < this.m_HtmlTag.Length && chars[num3].unicode != 60U)
			{
				uint unicode = chars[num3].unicode;
				bool flag3 = unicode == 62U;
				if (flag3)
				{
					flag2 = true;
					endIndex = num3;
					this.m_HtmlTag[num] = '\0';
					break;
				}
				this.m_HtmlTag[num] = (char)unicode;
				num++;
				bool flag4 = b == 1;
				if (flag4)
				{
					bool flag5 = tagValueType == TagValueType.None;
					if (flag5)
					{
						bool flag6 = unicode == 43U || unicode == 45U || unicode == 46U || (unicode >= 48U && unicode <= 57U);
						if (flag6)
						{
							tagUnitType = TagUnitType.Pixels;
							tagValueType = (this.m_XmlAttribute[num2].valueType = TagValueType.NumericalValue);
							this.m_XmlAttribute[num2].valueStartIndex = num - 1;
							RichTextTagAttribute[] xmlAttribute = this.m_XmlAttribute;
							int num4 = num2;
							xmlAttribute[num4].valueLength = xmlAttribute[num4].valueLength + 1;
						}
						else
						{
							bool flag7 = unicode == 35U;
							if (flag7)
							{
								tagUnitType = TagUnitType.Pixels;
								tagValueType = (this.m_XmlAttribute[num2].valueType = TagValueType.ColorValue);
								this.m_XmlAttribute[num2].valueStartIndex = num - 1;
								RichTextTagAttribute[] xmlAttribute2 = this.m_XmlAttribute;
								int num5 = num2;
								xmlAttribute2[num5].valueLength = xmlAttribute2[num5].valueLength + 1;
							}
							else
							{
								bool flag8 = unicode == 34U;
								if (flag8)
								{
									tagUnitType = TagUnitType.Pixels;
									tagValueType = (this.m_XmlAttribute[num2].valueType = TagValueType.StringValue);
									this.m_XmlAttribute[num2].valueStartIndex = num;
								}
								else
								{
									tagUnitType = TagUnitType.Pixels;
									tagValueType = (this.m_XmlAttribute[num2].valueType = TagValueType.StringValue);
									this.m_XmlAttribute[num2].valueStartIndex = num - 1;
									this.m_XmlAttribute[num2].valueHashCode = ((this.m_XmlAttribute[num2].valueHashCode << 5) + this.m_XmlAttribute[num2].valueHashCode ^ (int)TextGeneratorUtilities.ToUpperFast((char)unicode));
									RichTextTagAttribute[] xmlAttribute3 = this.m_XmlAttribute;
									int num6 = num2;
									xmlAttribute3[num6].valueLength = xmlAttribute3[num6].valueLength + 1;
								}
							}
						}
					}
					else
					{
						bool flag9 = tagValueType == TagValueType.NumericalValue;
						if (flag9)
						{
							bool flag10 = unicode == 112U || unicode == 101U || unicode == 37U || unicode == 32U;
							if (flag10)
							{
								b = 2;
								tagValueType = TagValueType.None;
								uint num7 = unicode;
								uint num8 = num7;
								if (num8 != 37U)
								{
									if (num8 != 101U)
									{
										tagUnitType = (this.m_XmlAttribute[num2].unitType = TagUnitType.Pixels);
									}
									else
									{
										tagUnitType = (this.m_XmlAttribute[num2].unitType = TagUnitType.FontUnits);
									}
								}
								else
								{
									tagUnitType = (this.m_XmlAttribute[num2].unitType = TagUnitType.Percentage);
								}
								num2++;
								this.m_XmlAttribute[num2].nameHashCode = 0;
								this.m_XmlAttribute[num2].valueHashCode = 0;
								this.m_XmlAttribute[num2].valueType = TagValueType.None;
								this.m_XmlAttribute[num2].unitType = TagUnitType.Pixels;
								this.m_XmlAttribute[num2].valueStartIndex = 0;
								this.m_XmlAttribute[num2].valueLength = 0;
							}
							else
							{
								RichTextTagAttribute[] xmlAttribute4 = this.m_XmlAttribute;
								int num9 = num2;
								xmlAttribute4[num9].valueLength = xmlAttribute4[num9].valueLength + 1;
							}
						}
						else
						{
							bool flag11 = tagValueType == TagValueType.ColorValue;
							if (flag11)
							{
								bool flag12 = unicode != 32U;
								if (flag12)
								{
									RichTextTagAttribute[] xmlAttribute5 = this.m_XmlAttribute;
									int num10 = num2;
									xmlAttribute5[num10].valueLength = xmlAttribute5[num10].valueLength + 1;
								}
								else
								{
									b = 2;
									tagValueType = TagValueType.None;
									tagUnitType = TagUnitType.Pixels;
									num2++;
									this.m_XmlAttribute[num2].nameHashCode = 0;
									this.m_XmlAttribute[num2].valueType = TagValueType.None;
									this.m_XmlAttribute[num2].unitType = TagUnitType.Pixels;
									this.m_XmlAttribute[num2].valueHashCode = 0;
									this.m_XmlAttribute[num2].valueStartIndex = 0;
									this.m_XmlAttribute[num2].valueLength = 0;
								}
							}
							else
							{
								bool flag13 = tagValueType == TagValueType.StringValue;
								if (flag13)
								{
									bool flag14 = unicode != 34U;
									if (flag14)
									{
										this.m_XmlAttribute[num2].valueHashCode = ((this.m_XmlAttribute[num2].valueHashCode << 5) + this.m_XmlAttribute[num2].valueHashCode ^ (int)TextGeneratorUtilities.ToUpperFast((char)unicode));
										RichTextTagAttribute[] xmlAttribute6 = this.m_XmlAttribute;
										int num11 = num2;
										xmlAttribute6[num11].valueLength = xmlAttribute6[num11].valueLength + 1;
									}
									else
									{
										b = 2;
										tagValueType = TagValueType.None;
										tagUnitType = TagUnitType.Pixels;
										num2++;
										this.m_XmlAttribute[num2].nameHashCode = 0;
										this.m_XmlAttribute[num2].valueType = TagValueType.None;
										this.m_XmlAttribute[num2].unitType = TagUnitType.Pixels;
										this.m_XmlAttribute[num2].valueHashCode = 0;
										this.m_XmlAttribute[num2].valueStartIndex = 0;
										this.m_XmlAttribute[num2].valueLength = 0;
									}
								}
							}
						}
					}
				}
				bool flag15 = unicode == 61U;
				if (flag15)
				{
					b = 1;
				}
				bool flag16 = b == 0 && unicode == 32U;
				if (flag16)
				{
					bool flag17 = flag;
					if (flag17)
					{
						return false;
					}
					flag = true;
					b = 2;
					tagValueType = TagValueType.None;
					tagUnitType = TagUnitType.Pixels;
					num2++;
					this.m_XmlAttribute[num2].nameHashCode = 0;
					this.m_XmlAttribute[num2].valueType = TagValueType.None;
					this.m_XmlAttribute[num2].unitType = TagUnitType.Pixels;
					this.m_XmlAttribute[num2].valueHashCode = 0;
					this.m_XmlAttribute[num2].valueStartIndex = 0;
					this.m_XmlAttribute[num2].valueLength = 0;
				}
				bool flag18 = b == 0;
				if (flag18)
				{
					this.m_XmlAttribute[num2].nameHashCode = ((this.m_XmlAttribute[num2].nameHashCode << 5) + this.m_XmlAttribute[num2].nameHashCode ^ (int)TextGeneratorUtilities.ToUpperFast((char)unicode));
				}
				bool flag19 = b == 2 && unicode == 32U;
				if (flag19)
				{
					b = 0;
				}
				num3++;
			}
			bool flag20 = !flag2;
			if (flag20)
			{
				return false;
			}
			bool flag21 = this.m_TagNoParsing && this.m_XmlAttribute[0].nameHashCode != -294095813;
			if (flag21)
			{
				return false;
			}
			bool flag22 = this.m_XmlAttribute[0].nameHashCode == -294095813;
			if (flag22)
			{
				this.m_TagNoParsing = false;
				return true;
			}
			bool flag23 = this.m_HtmlTag[0] == '#' && num == 4;
			if (flag23)
			{
				this.m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, num);
				this.m_ColorStack.Add(this.m_HtmlColor);
				return true;
			}
			bool flag24 = this.m_HtmlTag[0] == '#' && num == 5;
			if (flag24)
			{
				this.m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, num);
				this.m_ColorStack.Add(this.m_HtmlColor);
				return true;
			}
			bool flag25 = this.m_HtmlTag[0] == '#' && num == 7;
			if (flag25)
			{
				this.m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, num);
				this.m_ColorStack.Add(this.m_HtmlColor);
				return true;
			}
			bool flag26 = this.m_HtmlTag[0] == '#' && num == 9;
			if (flag26)
			{
				this.m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, num);
				this.m_ColorStack.Add(this.m_HtmlColor);
				return true;
			}
			MarkupTag nameHashCode = (MarkupTag)this.m_XmlAttribute[0].nameHashCode;
			MarkupTag markupTag = nameHashCode;
			if (markupTag <= MarkupTag.SLASH_STRIKETHROUGH)
			{
				if (markupTag <= MarkupTag.LINE_INDENT)
				{
					if (markupTag <= MarkupTag.SLASH_INDENT)
					{
						if (markupTag <= MarkupTag.SLASH_MARGIN)
						{
							if (markupTag <= MarkupTag.FONT_WEIGHT)
							{
								if (markupTag == MarkupTag.GRADIENT)
								{
									int valueHashCode = this.m_XmlAttribute[0].valueHashCode;
									TextColorGradient textColorGradient;
									bool flag27 = MaterialReferenceManager.TryGetColorGradientPreset(valueHashCode, out textColorGradient);
									if (flag27)
									{
										this.m_ColorGradientPreset = textColorGradient;
									}
									else
									{
										bool flag28 = textColorGradient == null;
										if (flag28)
										{
											textColorGradient = Resources.Load<TextColorGradient>(textSettings.defaultColorGradientPresetsPath + new string(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength));
										}
										bool flag29 = textColorGradient == null;
										if (flag29)
										{
											return false;
										}
										MaterialReferenceManager.AddColorGradientPreset(valueHashCode, textColorGradient);
										this.m_ColorGradientPreset = textColorGradient;
									}
									this.m_ColorGradientPresetIsTinted = false;
									int num12 = 1;
									while (num12 < this.m_XmlAttribute.Length && this.m_XmlAttribute[num12].nameHashCode != 0)
									{
										int nameHashCode2 = this.m_XmlAttribute[num12].nameHashCode;
										MarkupTag markupTag2 = (MarkupTag)nameHashCode2;
										MarkupTag markupTag3 = markupTag2;
										if (markupTag3 == MarkupTag.TINT)
										{
											this.m_ColorGradientPresetIsTinted = (TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[num12].valueStartIndex, this.m_XmlAttribute[num12].valueLength) != 0f);
										}
										num12++;
									}
									this.m_ColorGradientStack.Add(this.m_ColorGradientPreset);
									return true;
								}
								if (markupTag != MarkupTag.FONT_WEIGHT)
								{
									goto IL_40F4;
								}
								float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
								bool flag30 = num13 == -32768f;
								if (flag30)
								{
									return false;
								}
								int num14 = (int)num13;
								int num15 = num14;
								if (num15 <= 400)
								{
									if (num15 <= 200)
									{
										if (num15 != 100)
										{
											if (num15 == 200)
											{
												this.m_FontWeightInternal = TextFontWeight.ExtraLight;
											}
										}
										else
										{
											this.m_FontWeightInternal = TextFontWeight.Thin;
										}
									}
									else if (num15 != 300)
									{
										if (num15 == 400)
										{
											this.m_FontWeightInternal = TextFontWeight.Regular;
										}
									}
									else
									{
										this.m_FontWeightInternal = TextFontWeight.Light;
									}
								}
								else if (num15 <= 600)
								{
									if (num15 != 500)
									{
										if (num15 == 600)
										{
											this.m_FontWeightInternal = TextFontWeight.SemiBold;
										}
									}
									else
									{
										this.m_FontWeightInternal = TextFontWeight.Medium;
									}
								}
								else if (num15 != 700)
								{
									if (num15 != 800)
									{
										if (num15 == 900)
										{
											this.m_FontWeightInternal = TextFontWeight.Black;
										}
									}
									else
									{
										this.m_FontWeightInternal = TextFontWeight.Heavy;
									}
								}
								else
								{
									this.m_FontWeightInternal = TextFontWeight.Bold;
								}
								this.m_FontWeightStack.Add(this.m_FontWeightInternal);
								return true;
							}
							else
							{
								if (markupTag == MarkupTag.SLASH_GRADIENT)
								{
									this.m_ColorGradientPreset = this.m_ColorGradientStack.Remove();
									return true;
								}
								if (markupTag == MarkupTag.ACTION)
								{
									int valueHashCode2 = this.m_XmlAttribute[0].valueHashCode;
									bool isTextLayoutPhase = this.m_isTextLayoutPhase;
									if (isTextLayoutPhase)
									{
										this.m_ActionStack.Add(valueHashCode2);
										Debug.Log("Action ID: [" + valueHashCode2.ToString() + "] First character index: " + this.m_CharacterCount.ToString());
									}
									return true;
								}
								if (markupTag != MarkupTag.SLASH_MARGIN)
								{
									goto IL_40F4;
								}
								this.m_MarginLeft = 0f;
								this.m_MarginRight = 0f;
								return true;
							}
						}
						else if (markupTag <= MarkupTag.CHARACTER_SPACE)
						{
							if (markupTag == MarkupTag.SLASH_MONOSPACE)
							{
								this.m_MonoSpacing = 0f;
								return true;
							}
							if (markupTag != MarkupTag.CHARACTER_SPACE)
							{
								goto IL_40F4;
							}
							float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
							bool flag31 = num13 == -32768f;
							if (flag31)
							{
								return false;
							}
							switch (tagUnitType)
							{
							case TagUnitType.Pixels:
								this.m_CSpacing = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
								break;
							case TagUnitType.FontUnits:
								this.m_CSpacing = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
								break;
							case TagUnitType.Percentage:
								return false;
							}
							return true;
						}
						else if (markupTag != MarkupTag.INDENT)
						{
							if (markupTag == MarkupTag.LOWERCASE)
							{
								this.m_FontStyleInternal |= FontStyles.LowerCase;
								this.m_FontStyleStack.Add(FontStyles.LowerCase);
								return true;
							}
							if (markupTag != MarkupTag.SLASH_INDENT)
							{
								goto IL_40F4;
							}
							this.m_TagIndent = this.m_IndentStack.Remove();
							return true;
						}
						else
						{
							float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
							bool flag32 = num13 == -32768f;
							if (flag32)
							{
								return false;
							}
							switch (tagUnitType)
							{
							case TagUnitType.Pixels:
								this.m_TagIndent = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
								break;
							case TagUnitType.FontUnits:
								this.m_TagIndent = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
								break;
							case TagUnitType.Percentage:
								this.m_TagIndent = this.m_MarginWidth * num13 / 100f;
								break;
							}
							this.m_IndentStack.Add(this.m_TagIndent);
							this.m_XAdvance = this.m_TagIndent;
							return true;
						}
					}
					else if (markupTag <= MarkupTag.SLASH_ACTION)
					{
						if (markupTag <= MarkupTag.SLASH_CHARACTER_SPACE)
						{
							if (markupTag == MarkupTag.SLASH_LOWERCASE)
							{
								bool flag33 = (generationSettings.fontStyle & FontStyles.LowerCase) != FontStyles.LowerCase;
								if (flag33)
								{
									bool flag34 = this.m_FontStyleStack.Remove(FontStyles.LowerCase) == 0;
									if (flag34)
									{
										this.m_FontStyleInternal &= ~FontStyles.LowerCase;
									}
								}
								return true;
							}
							if (markupTag != MarkupTag.SLASH_CHARACTER_SPACE)
							{
								goto IL_40F4;
							}
							bool flag35 = !this.m_isTextLayoutPhase;
							if (flag35)
							{
								return true;
							}
							bool flag36 = this.m_CharacterCount > 0;
							if (flag36)
							{
								this.m_XAdvance -= this.m_CSpacing;
								textInfo.textElementInfo[this.m_CharacterCount - 1].xAdvance = this.m_XAdvance;
							}
							this.m_CSpacing = 0f;
							return true;
						}
						else if (markupTag != MarkupTag.MARGIN)
						{
							if (markupTag != MarkupTag.MONOSPACE)
							{
								if (markupTag != MarkupTag.SLASH_ACTION)
								{
									goto IL_40F4;
								}
								bool isTextLayoutPhase2 = this.m_isTextLayoutPhase;
								if (isTextLayoutPhase2)
								{
									Debug.Log("Action ID: [" + this.m_ActionStack.CurrentItem().ToString() + "] Last character index: " + (this.m_CharacterCount - 1).ToString());
								}
								this.m_ActionStack.Remove();
								return true;
							}
							else
							{
								float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
								bool flag37 = num13 == -32768f;
								if (flag37)
								{
									return false;
								}
								switch (tagUnitType)
								{
								case TagUnitType.Pixels:
									this.m_MonoSpacing = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
									break;
								case TagUnitType.FontUnits:
									this.m_MonoSpacing = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
									break;
								case TagUnitType.Percentage:
									return false;
								}
								return true;
							}
						}
						else
						{
							TagValueType valueType = this.m_XmlAttribute[0].valueType;
							TagValueType tagValueType2 = valueType;
							float num13;
							if (tagValueType2 == TagValueType.None)
							{
								int num16 = 1;
								while (num16 < this.m_XmlAttribute.Length && this.m_XmlAttribute[num16].nameHashCode != 0)
								{
									int nameHashCode3 = this.m_XmlAttribute[num16].nameHashCode;
									MarkupTag markupTag4 = (MarkupTag)nameHashCode3;
									MarkupTag markupTag5 = markupTag4;
									if (markupTag5 != MarkupTag.LEFT)
									{
										if (markupTag5 == MarkupTag.RIGHT)
										{
											num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[num16].valueStartIndex, this.m_XmlAttribute[num16].valueLength);
											bool flag38 = num13 == -32768f;
											if (flag38)
											{
												return false;
											}
											switch (this.m_XmlAttribute[num16].unitType)
											{
											case TagUnitType.Pixels:
												this.m_MarginRight = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
												break;
											case TagUnitType.FontUnits:
												this.m_MarginRight = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
												break;
											case TagUnitType.Percentage:
												this.m_MarginRight = (this.m_MarginWidth - ((this.m_Width != -1f) ? this.m_Width : 0f)) * num13 / 100f;
												break;
											}
											this.m_MarginRight = ((this.m_MarginRight >= 0f) ? this.m_MarginRight : 0f);
										}
									}
									else
									{
										num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[num16].valueStartIndex, this.m_XmlAttribute[num16].valueLength);
										bool flag39 = num13 == -32768f;
										if (flag39)
										{
											return false;
										}
										switch (this.m_XmlAttribute[num16].unitType)
										{
										case TagUnitType.Pixels:
											this.m_MarginLeft = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
											break;
										case TagUnitType.FontUnits:
											this.m_MarginLeft = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
											break;
										case TagUnitType.Percentage:
											this.m_MarginLeft = (this.m_MarginWidth - ((this.m_Width != -1f) ? this.m_Width : 0f)) * num13 / 100f;
											break;
										}
										this.m_MarginLeft = ((this.m_MarginLeft >= 0f) ? this.m_MarginLeft : 0f);
									}
									num16++;
								}
								return true;
							}
							if (tagValueType2 != TagValueType.NumericalValue)
							{
								return false;
							}
							num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
							bool flag40 = num13 == -32768f;
							if (flag40)
							{
								return false;
							}
							switch (tagUnitType)
							{
							case TagUnitType.Pixels:
								this.m_MarginLeft = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
								break;
							case TagUnitType.FontUnits:
								this.m_MarginLeft = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
								break;
							case TagUnitType.Percentage:
								this.m_MarginLeft = (this.m_MarginWidth - ((this.m_Width != -1f) ? this.m_Width : 0f)) * num13 / 100f;
								break;
							}
							this.m_MarginLeft = ((this.m_MarginLeft >= 0f) ? this.m_MarginLeft : 0f);
							this.m_MarginRight = this.m_MarginLeft;
							return true;
						}
					}
					else if (markupTag <= MarkupTag.ROTATE)
					{
						if (markupTag == MarkupTag.SLASH_MATERIAL)
						{
							MaterialReference materialReference = this.m_MaterialReferenceStack.Remove();
							this.m_CurrentMaterial = materialReference.material;
							this.m_CurrentMaterialIndex = materialReference.index;
							return true;
						}
						if (markupTag != MarkupTag.ROTATE)
						{
							goto IL_40F4;
						}
						float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
						bool flag41 = num13 == -32768f;
						if (flag41)
						{
							return false;
						}
						this.m_FXRotation = Quaternion.Euler(0f, 0f, num13);
						return true;
					}
					else if (markupTag != MarkupTag.SPRITE)
					{
						if (markupTag == MarkupTag.SLASH_TABLE)
						{
							return false;
						}
						if (markupTag != MarkupTag.LINE_INDENT)
						{
							goto IL_40F4;
						}
						float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
						bool flag42 = num13 == -32768f;
						if (flag42)
						{
							return false;
						}
						switch (tagUnitType)
						{
						case TagUnitType.Pixels:
							this.m_TagLineIndent = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
							break;
						case TagUnitType.FontUnits:
							this.m_TagLineIndent = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
							break;
						case TagUnitType.Percentage:
							this.m_TagLineIndent = this.m_MarginWidth * num13 / 100f;
							break;
						}
						this.m_XAdvance += this.m_TagLineIndent;
						return true;
					}
					else
					{
						int valueHashCode3 = this.m_XmlAttribute[0].valueHashCode;
						this.m_SpriteIndex = -1;
						bool flag43 = this.m_XmlAttribute[0].valueType == TagValueType.None || this.m_XmlAttribute[0].valueType == TagValueType.NumericalValue;
						if (flag43)
						{
							bool flag44 = generationSettings.spriteAsset != null;
							if (flag44)
							{
								this.m_CurrentSpriteAsset = generationSettings.spriteAsset;
							}
							else
							{
								bool flag45 = textSettings.defaultSpriteAsset != null;
								if (flag45)
								{
									this.m_CurrentSpriteAsset = textSettings.defaultSpriteAsset;
								}
								else
								{
									bool flag46 = this.m_DefaultSpriteAsset != null;
									if (flag46)
									{
										this.m_CurrentSpriteAsset = this.m_DefaultSpriteAsset;
									}
									else
									{
										bool flag47 = this.m_DefaultSpriteAsset == null;
										if (flag47)
										{
											this.m_DefaultSpriteAsset = Resources.Load<SpriteAsset>("Sprite Assets/Default Sprite Asset");
											this.m_CurrentSpriteAsset = this.m_DefaultSpriteAsset;
										}
									}
								}
							}
							bool flag48 = this.m_CurrentSpriteAsset == null;
							if (flag48)
							{
								return false;
							}
						}
						else
						{
							SpriteAsset spriteAsset;
							bool flag49 = MaterialReferenceManager.TryGetSpriteAsset(valueHashCode3, out spriteAsset);
							if (flag49)
							{
								this.m_CurrentSpriteAsset = spriteAsset;
							}
							else
							{
								bool flag50 = spriteAsset == null;
								if (flag50)
								{
									bool flag51 = spriteAsset == null;
									if (flag51)
									{
										spriteAsset = Resources.Load<SpriteAsset>(textSettings.defaultSpriteAssetPath + new string(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength));
									}
								}
								bool flag52 = spriteAsset == null;
								if (flag52)
								{
									return false;
								}
								MaterialReferenceManager.AddSpriteAsset(valueHashCode3, spriteAsset);
								this.m_CurrentSpriteAsset = spriteAsset;
							}
						}
						bool flag53 = this.m_XmlAttribute[0].valueType == TagValueType.NumericalValue;
						if (flag53)
						{
							int num17 = (int)TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
							bool flag54 = num17 == -32768;
							if (flag54)
							{
								return false;
							}
							bool flag55 = num17 > this.m_CurrentSpriteAsset.spriteCharacterTable.Count - 1;
							if (flag55)
							{
								return false;
							}
							this.m_SpriteIndex = num17;
						}
						this.m_SpriteColor = Color.white;
						this.m_TintSprite = false;
						int num18 = 0;
						while (num18 < this.m_XmlAttribute.Length && this.m_XmlAttribute[num18].nameHashCode != 0)
						{
							int nameHashCode4 = this.m_XmlAttribute[num18].nameHashCode;
							int num19 = 0;
							MarkupTag markupTag6 = (MarkupTag)nameHashCode4;
							MarkupTag markupTag7 = markupTag6;
							if (markupTag7 <= MarkupTag.NAME)
							{
								if (markupTag7 != MarkupTag.ANIM)
								{
									if (markupTag7 != MarkupTag.NAME)
									{
										goto IL_35FD;
									}
									this.m_CurrentSpriteAsset = SpriteAsset.SearchForSpriteByHashCode(this.m_CurrentSpriteAsset, this.m_XmlAttribute[num18].valueHashCode, true, out num19, null);
									bool flag56 = num19 == -1;
									if (flag56)
									{
										return false;
									}
									this.m_SpriteIndex = num19;
								}
								else
								{
									int attributeParameters = TextGeneratorUtilities.GetAttributeParameters(this.m_HtmlTag, this.m_XmlAttribute[num18].valueStartIndex, this.m_XmlAttribute[num18].valueLength, ref this.m_AttributeParameterValues);
									bool flag57 = attributeParameters != 3;
									if (flag57)
									{
										return false;
									}
									this.m_SpriteIndex = (int)this.m_AttributeParameterValues[0];
									bool isTextLayoutPhase3 = this.m_isTextLayoutPhase;
									if (isTextLayoutPhase3)
									{
									}
								}
							}
							else if (markupTag7 != MarkupTag.TINT)
							{
								if (markupTag7 != MarkupTag.COLOR)
								{
									if (markupTag7 != MarkupTag.INDEX)
									{
										goto IL_35FD;
									}
									num19 = (int)TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[1].valueStartIndex, this.m_XmlAttribute[1].valueLength);
									bool flag58 = num19 == -32768;
									if (flag58)
									{
										return false;
									}
									bool flag59 = num19 > this.m_CurrentSpriteAsset.spriteCharacterTable.Count - 1;
									if (flag59)
									{
										return false;
									}
									this.m_SpriteIndex = num19;
								}
								else
								{
									this.m_SpriteColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, this.m_XmlAttribute[num18].valueStartIndex, this.m_XmlAttribute[num18].valueLength);
								}
							}
							else
							{
								this.m_TintSprite = (TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[num18].valueStartIndex, this.m_XmlAttribute[num18].valueLength) != 0f);
							}
							IL_3619:
							num18++;
							continue;
							IL_35FD:
							bool flag60 = nameHashCode4 != -991527447;
							if (flag60)
							{
								return false;
							}
							goto IL_3619;
						}
						bool flag61 = this.m_SpriteIndex == -1;
						if (flag61)
						{
							return false;
						}
						this.m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(this.m_CurrentSpriteAsset.material, this.m_CurrentSpriteAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
						this.m_TextElementType = TextElementType.Sprite;
						return true;
					}
				}
				else
				{
					if (markupTag <= MarkupTag.MARGIN_LEFT)
					{
						if (markupTag <= MarkupTag.SLASH_FONT_WEIGHT)
						{
							if (markupTag <= MarkupTag.SLASH_ALLCAPS)
							{
								if (markupTag != MarkupTag.LINE_HEIGHT)
								{
									if (markupTag != MarkupTag.SLASH_ALLCAPS)
									{
										goto IL_40F4;
									}
								}
								else
								{
									float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
									bool flag62 = num13 == -32768f;
									if (flag62)
									{
										return false;
									}
									switch (tagUnitType)
									{
									case TagUnitType.Pixels:
										this.m_LineHeight = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
										break;
									case TagUnitType.FontUnits:
										this.m_LineHeight = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
										break;
									case TagUnitType.Percentage:
									{
										float num20 = this.m_CurrentFontSize / (float)this.m_CurrentFontAsset.faceInfo.pointSize * this.m_CurrentFontAsset.faceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
										this.m_LineHeight = generationSettings.fontAsset.faceInfo.lineHeight * num13 / 100f * num20;
										break;
									}
									}
									return true;
								}
							}
							else
							{
								if (markupTag == MarkupTag.SMALLCAPS)
								{
									this.m_FontStyleInternal |= FontStyles.SmallCaps;
									this.m_FontStyleStack.Add(FontStyles.SmallCaps);
									return true;
								}
								if (markupTag == MarkupTag.SLASH_ROTATE)
								{
									this.m_FXRotation = Quaternion.identity;
									return true;
								}
								if (markupTag != MarkupTag.SLASH_FONT_WEIGHT)
								{
									goto IL_40F4;
								}
								this.m_FontWeightStack.Remove();
								bool flag63 = this.m_FontStyleInternal == FontStyles.Bold;
								if (flag63)
								{
									this.m_FontWeightInternal = TextFontWeight.Bold;
								}
								else
								{
									this.m_FontWeightInternal = this.m_FontWeightStack.Peek();
								}
								return true;
							}
						}
						else if (markupTag <= MarkupTag.MARGIN_RIGHT)
						{
							if (markupTag != MarkupTag.SLASH_UPPERCASE)
							{
								if (markupTag != MarkupTag.MARGIN_RIGHT)
								{
									goto IL_40F4;
								}
								float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
								bool flag64 = num13 == -32768f;
								if (flag64)
								{
									return false;
								}
								switch (tagUnitType)
								{
								case TagUnitType.Pixels:
									this.m_MarginRight = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
									break;
								case TagUnitType.FontUnits:
									this.m_MarginRight = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
									break;
								case TagUnitType.Percentage:
									this.m_MarginRight = (this.m_MarginWidth - ((this.m_Width != -1f) ? this.m_Width : 0f)) * num13 / 100f;
									break;
								}
								this.m_MarginRight = ((this.m_MarginRight >= 0f) ? this.m_MarginRight : 0f);
								return true;
							}
						}
						else
						{
							if (markupTag == MarkupTag.NO_PARSE)
							{
								this.m_TagNoParsing = true;
								return true;
							}
							if (markupTag == MarkupTag.UPPERCASE)
							{
								goto IL_3701;
							}
							if (markupTag != MarkupTag.MARGIN_LEFT)
							{
								goto IL_40F4;
							}
							float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
							bool flag65 = num13 == -32768f;
							if (flag65)
							{
								return false;
							}
							switch (tagUnitType)
							{
							case TagUnitType.Pixels:
								this.m_MarginLeft = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
								break;
							case TagUnitType.FontUnits:
								this.m_MarginLeft = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
								break;
							case TagUnitType.Percentage:
								this.m_MarginLeft = (this.m_MarginWidth - ((this.m_Width != -1f) ? this.m_Width : 0f)) * num13 / 100f;
								break;
							}
							this.m_MarginLeft = ((this.m_MarginLeft >= 0f) ? this.m_MarginLeft : 0f);
							return true;
						}
						bool flag66 = (generationSettings.fontStyle & FontStyles.UpperCase) != FontStyles.UpperCase;
						if (flag66)
						{
							bool flag67 = this.m_FontStyleStack.Remove(FontStyles.UpperCase) == 0;
							if (flag67)
							{
								this.m_FontStyleInternal &= ~FontStyles.UpperCase;
							}
						}
						return true;
					}
					if (markupTag <= MarkupTag.STRIKETHROUGH)
					{
						if (markupTag <= MarkupTag.A)
						{
							if (markupTag == MarkupTag.SLASH_VERTICAL_OFFSET)
							{
								this.m_BaselineOffset = 0f;
								return true;
							}
							if (markupTag != MarkupTag.A)
							{
								goto IL_40F4;
							}
							bool flag68 = this.m_isTextLayoutPhase && !this.m_IsCalculatingPreferredValues;
							if (flag68)
							{
								bool flag69 = this.m_XmlAttribute[1].nameHashCode == 2535353;
								if (flag69)
								{
									int linkCount = textInfo.linkCount;
									bool flag70 = linkCount + 1 > textInfo.linkInfo.Length;
									if (flag70)
									{
										TextInfo.Resize<LinkInfo>(ref textInfo.linkInfo, linkCount + 1);
									}
									textInfo.linkInfo[linkCount].hashCode = 2535353;
									textInfo.linkInfo[linkCount].linkTextfirstCharacterIndex = this.m_CharacterCount;
									textInfo.linkInfo[linkCount].linkIdFirstCharacterIndex = startIndex + this.m_XmlAttribute[1].valueStartIndex;
									textInfo.linkInfo[linkCount].SetLinkId(this.m_HtmlTag, this.m_XmlAttribute[1].valueStartIndex, this.m_XmlAttribute[1].valueLength);
								}
								textInfo.linkCount++;
							}
							return true;
						}
						else
						{
							if (markupTag == MarkupTag.BOLD)
							{
								this.m_FontStyleInternal |= FontStyles.Bold;
								this.m_FontStyleStack.Add(FontStyles.Bold);
								this.m_FontWeightInternal = TextFontWeight.Bold;
								return true;
							}
							if (markupTag == MarkupTag.ITALIC)
							{
								this.m_FontStyleInternal |= FontStyles.Italic;
								this.m_FontStyleStack.Add(FontStyles.Italic);
								bool flag71 = this.m_XmlAttribute[1].nameHashCode == 75347905;
								if (flag71)
								{
									this.m_ItalicAngle = (int)TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[1].valueStartIndex, this.m_XmlAttribute[1].valueLength);
									bool flag72 = this.m_ItalicAngle < -180 || this.m_ItalicAngle > 180;
									if (flag72)
									{
										return false;
									}
								}
								else
								{
									this.m_ItalicAngle = (int)this.m_CurrentFontAsset.italicStyleSlant;
								}
								this.m_ItalicAngleStack.Add(this.m_ItalicAngle);
								return true;
							}
							if (markupTag != MarkupTag.STRIKETHROUGH)
							{
								goto IL_40F4;
							}
							this.m_FontStyleInternal |= FontStyles.Strikethrough;
							this.m_FontStyleStack.Add(FontStyles.Strikethrough);
							bool flag73 = this.m_XmlAttribute[1].nameHashCode == 81999901;
							if (flag73)
							{
								this.m_StrikethroughColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, this.m_XmlAttribute[1].valueStartIndex, this.m_XmlAttribute[1].valueLength);
								this.m_StrikethroughColor.a = ((this.m_HtmlColor.a < this.m_StrikethroughColor.a) ? this.m_HtmlColor.a : this.m_StrikethroughColor.a);
								textInfo.hasMultipleColors = true;
							}
							else
							{
								this.m_StrikethroughColor = this.m_HtmlColor;
							}
							this.m_StrikethroughColorStack.Add(this.m_StrikethroughColor);
							return true;
						}
					}
					else if (markupTag <= MarkupTag.SLASH_BOLD)
					{
						if (markupTag == MarkupTag.UNDERLINE)
						{
							this.m_FontStyleInternal |= FontStyles.Underline;
							this.m_FontStyleStack.Add(FontStyles.Underline);
							bool flag74 = this.m_XmlAttribute[1].nameHashCode == 81999901;
							if (flag74)
							{
								this.m_UnderlineColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, this.m_XmlAttribute[1].valueStartIndex, this.m_XmlAttribute[1].valueLength);
								this.m_UnderlineColor.a = ((this.m_HtmlColor.a < this.m_UnderlineColor.a) ? this.m_HtmlColor.a : this.m_UnderlineColor.a);
								textInfo.hasMultipleColors = true;
							}
							else
							{
								this.m_UnderlineColor = this.m_HtmlColor;
							}
							this.m_UnderlineColorStack.Add(this.m_UnderlineColor);
							return true;
						}
						if (markupTag == MarkupTag.SLASH_ITALIC)
						{
							bool flag75 = (generationSettings.fontStyle & FontStyles.Italic) != FontStyles.Italic;
							if (flag75)
							{
								this.m_ItalicAngle = this.m_ItalicAngleStack.Remove();
								bool flag76 = this.m_FontStyleStack.Remove(FontStyles.Italic) == 0;
								if (flag76)
								{
									this.m_FontStyleInternal &= ~FontStyles.Italic;
								}
							}
							return true;
						}
						if (markupTag != MarkupTag.SLASH_BOLD)
						{
							goto IL_40F4;
						}
						bool flag77 = (generationSettings.fontStyle & FontStyles.Bold) != FontStyles.Bold;
						if (flag77)
						{
							bool flag78 = this.m_FontStyleStack.Remove(FontStyles.Bold) == 0;
							if (flag78)
							{
								this.m_FontStyleInternal &= ~FontStyles.Bold;
								this.m_FontWeightInternal = this.m_FontWeightStack.Peek();
							}
						}
						return true;
					}
					else
					{
						if (markupTag == MarkupTag.SLASH_A)
						{
							bool flag79 = this.m_isTextLayoutPhase && !this.m_IsCalculatingPreferredValues;
							if (flag79)
							{
								bool flag80 = textInfo.linkInfo.Length == 0 || textInfo.linkCount <= 0;
								if (flag80)
								{
									bool displayWarnings = generationSettings.textSettings.displayWarnings;
									if (displayWarnings)
									{
										Debug.LogWarning("There seems to be an issue with the formatting of the <a> tag. Possible issues include: missing or misplaced closing '>', missing or incorrect attribute, or unclosed quotes for attribute values. Please review the tag syntax.");
									}
								}
								else
								{
									int num21 = textInfo.linkCount - 1;
									textInfo.linkInfo[num21].linkTextLength = this.m_CharacterCount - textInfo.linkInfo[num21].linkTextfirstCharacterIndex;
								}
							}
							return true;
						}
						if (markupTag == MarkupTag.SLASH_UNDERLINE)
						{
							bool flag81 = (generationSettings.fontStyle & FontStyles.Underline) != FontStyles.Underline;
							if (flag81)
							{
								bool flag82 = this.m_FontStyleStack.Remove(FontStyles.Underline) == 0;
								if (flag82)
								{
									this.m_FontStyleInternal &= ~FontStyles.Underline;
								}
							}
							this.m_UnderlineColor = this.m_UnderlineColorStack.Remove();
							return true;
						}
						if (markupTag != MarkupTag.SLASH_STRIKETHROUGH)
						{
							goto IL_40F4;
						}
						bool flag83 = (generationSettings.fontStyle & FontStyles.Strikethrough) != FontStyles.Strikethrough;
						if (flag83)
						{
							bool flag84 = this.m_FontStyleStack.Remove(FontStyles.Strikethrough) == 0;
							if (flag84)
							{
								this.m_FontStyleInternal &= ~FontStyles.Strikethrough;
							}
						}
						this.m_StrikethroughColor = this.m_StrikethroughColorStack.Remove();
						return true;
					}
				}
			}
			else if (markupTag <= MarkupTag.SLASH_SIZE)
			{
				if (markupTag <= MarkupTag.PAGE)
				{
					if (markupTag <= MarkupTag.SLASH_SUPERSCRIPT)
					{
						if (markupTag <= MarkupTag.SUBSCRIPT)
						{
							if (markupTag != MarkupTag.POSITION)
							{
								if (markupTag != MarkupTag.SUBSCRIPT)
								{
									goto IL_40F4;
								}
								this.m_FontScaleMultiplier *= ((this.m_CurrentFontAsset.faceInfo.subscriptSize > 0f) ? this.m_CurrentFontAsset.faceInfo.subscriptSize : 1f);
								this.m_BaselineOffsetStack.Push(this.m_BaselineOffset);
								float num20 = this.m_CurrentFontSize / (float)this.m_CurrentFontAsset.faceInfo.pointSize * this.m_CurrentFontAsset.faceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
								this.m_BaselineOffset += this.m_CurrentFontAsset.faceInfo.subscriptOffset * num20 * this.m_FontScaleMultiplier;
								this.m_FontStyleStack.Add(FontStyles.Subscript);
								this.m_FontStyleInternal |= FontStyles.Subscript;
								return true;
							}
							else
							{
								float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
								bool flag85 = num13 == -32768f;
								if (flag85)
								{
									return false;
								}
								switch (tagUnitType)
								{
								case TagUnitType.Pixels:
									this.m_XAdvance = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
									return true;
								case TagUnitType.FontUnits:
									this.m_XAdvance = num13 * this.m_CurrentFontSize * (generationSettings.isOrthographic ? 1f : 0.1f);
									return true;
								case TagUnitType.Percentage:
									this.m_XAdvance = this.m_MarginWidth * num13 / 100f;
									return true;
								default:
									return false;
								}
							}
						}
						else
						{
							if (markupTag == MarkupTag.SUPERSCRIPT)
							{
								this.m_FontScaleMultiplier *= ((this.m_CurrentFontAsset.faceInfo.superscriptSize > 0f) ? this.m_CurrentFontAsset.faceInfo.superscriptSize : 1f);
								this.m_BaselineOffsetStack.Push(this.m_BaselineOffset);
								float num20 = this.m_CurrentFontSize / (float)this.m_CurrentFontAsset.faceInfo.pointSize * this.m_CurrentFontAsset.faceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
								this.m_BaselineOffset += this.m_CurrentFontAsset.faceInfo.superscriptOffset * num20 * this.m_FontScaleMultiplier;
								this.m_FontStyleStack.Add(FontStyles.Superscript);
								this.m_FontStyleInternal |= FontStyles.Superscript;
								return true;
							}
							if (markupTag == MarkupTag.SLASH_SUBSCRIPT)
							{
								bool flag86 = (this.m_FontStyleInternal & FontStyles.Subscript) == FontStyles.Subscript;
								if (flag86)
								{
									bool flag87 = this.m_FontScaleMultiplier < 1f;
									if (flag87)
									{
										this.m_BaselineOffset = this.m_BaselineOffsetStack.Pop();
										this.m_FontScaleMultiplier /= ((this.m_CurrentFontAsset.faceInfo.subscriptSize > 0f) ? this.m_CurrentFontAsset.faceInfo.subscriptSize : 1f);
									}
									bool flag88 = this.m_FontStyleStack.Remove(FontStyles.Subscript) == 0;
									if (flag88)
									{
										this.m_FontStyleInternal &= ~FontStyles.Subscript;
									}
								}
								return true;
							}
							if (markupTag != MarkupTag.SLASH_SUPERSCRIPT)
							{
								goto IL_40F4;
							}
							bool flag89 = (this.m_FontStyleInternal & FontStyles.Superscript) == FontStyles.Superscript;
							if (flag89)
							{
								bool flag90 = this.m_FontScaleMultiplier < 1f;
								if (flag90)
								{
									this.m_BaselineOffset = this.m_BaselineOffsetStack.Pop();
									this.m_FontScaleMultiplier /= ((this.m_CurrentFontAsset.faceInfo.superscriptSize > 0f) ? this.m_CurrentFontAsset.faceInfo.superscriptSize : 1f);
								}
								bool flag91 = this.m_FontStyleStack.Remove(FontStyles.Superscript) == 0;
								if (flag91)
								{
									this.m_FontStyleInternal &= ~FontStyles.Superscript;
								}
							}
							return true;
						}
					}
					else if (markupTag <= MarkupTag.FONT)
					{
						if (markupTag == MarkupTag.SLASH_POSITION)
						{
							this.m_IsIgnoringAlignment = false;
							return true;
						}
						if (markupTag != MarkupTag.FONT)
						{
							goto IL_40F4;
						}
						int valueHashCode4 = this.m_XmlAttribute[0].valueHashCode;
						int nameHashCode5 = this.m_XmlAttribute[1].nameHashCode;
						int valueHashCode5 = this.m_XmlAttribute[1].valueHashCode;
						bool flag92 = valueHashCode4 == -620974005;
						if (flag92)
						{
							this.m_CurrentFontAsset = this.m_MaterialReferences[0].fontAsset;
							this.m_CurrentMaterial = this.m_MaterialReferences[0].material;
							this.m_CurrentMaterialIndex = 0;
							this.m_MaterialReferenceStack.Add(this.m_MaterialReferences[0]);
							return true;
						}
						FontAsset fontAsset;
						MaterialReferenceManager.TryGetFontAsset(valueHashCode4, out fontAsset);
						bool flag93 = fontAsset == null;
						if (flag93)
						{
							bool flag94 = fontAsset == null;
							if (flag94)
							{
								fontAsset = Resources.Load<FontAsset>(textSettings.defaultFontAssetPath + new string(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength));
							}
							bool flag95 = fontAsset == null;
							if (flag95)
							{
								return false;
							}
							MaterialReferenceManager.AddFontAsset(fontAsset);
						}
						bool flag96 = nameHashCode5 == 0 && valueHashCode5 == 0;
						if (flag96)
						{
							this.m_CurrentMaterial = fontAsset.material;
							this.m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(this.m_CurrentMaterial, fontAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
							this.m_MaterialReferenceStack.Add(this.m_MaterialReferences[this.m_CurrentMaterialIndex]);
						}
						else
						{
							bool flag97 = nameHashCode5 == 825491659;
							if (!flag97)
							{
								return false;
							}
							Material material;
							bool flag98 = MaterialReferenceManager.TryGetMaterial(valueHashCode5, out material);
							if (flag98)
							{
								this.m_CurrentMaterial = material;
								this.m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(this.m_CurrentMaterial, fontAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
								this.m_MaterialReferenceStack.Add(this.m_MaterialReferences[this.m_CurrentMaterialIndex]);
							}
							else
							{
								material = Resources.Load<Material>(textSettings.defaultFontAssetPath + new string(this.m_HtmlTag, this.m_XmlAttribute[1].valueStartIndex, this.m_XmlAttribute[1].valueLength));
								bool flag99 = material == null;
								if (flag99)
								{
									return false;
								}
								MaterialReferenceManager.AddFontMaterial(valueHashCode5, material);
								this.m_CurrentMaterial = material;
								this.m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(this.m_CurrentMaterial, fontAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
								this.m_MaterialReferenceStack.Add(this.m_MaterialReferences[this.m_CurrentMaterialIndex]);
							}
						}
						this.m_CurrentFontAsset = fontAsset;
						return true;
					}
					else
					{
						if (markupTag == MarkupTag.LINK)
						{
							bool flag100 = this.m_isTextLayoutPhase && !this.m_IsCalculatingPreferredValues;
							if (flag100)
							{
								int linkCount2 = textInfo.linkCount;
								bool flag101 = linkCount2 + 1 > textInfo.linkInfo.Length;
								if (flag101)
								{
									TextInfo.Resize<LinkInfo>(ref textInfo.linkInfo, linkCount2 + 1);
								}
								textInfo.linkInfo[linkCount2].hashCode = this.m_XmlAttribute[0].valueHashCode;
								textInfo.linkInfo[linkCount2].linkTextfirstCharacterIndex = this.m_CharacterCount;
								textInfo.linkInfo[linkCount2].linkIdFirstCharacterIndex = startIndex + this.m_XmlAttribute[0].valueStartIndex;
								textInfo.linkInfo[linkCount2].SetLinkId(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
							}
							return true;
						}
						if (markupTag == MarkupTag.MARK)
						{
							this.m_FontStyleInternal |= FontStyles.Highlight;
							this.m_FontStyleStack.Add(FontStyles.Highlight);
							Color32 color = new Color32(byte.MaxValue, byte.MaxValue, 0, 64);
							Offset offset = Offset.zero;
							int num22 = 0;
							while (num22 < this.m_XmlAttribute.Length && this.m_XmlAttribute[num22].nameHashCode != 0)
							{
								MarkupTag nameHashCode6 = (MarkupTag)this.m_XmlAttribute[num22].nameHashCode;
								MarkupTag markupTag8 = nameHashCode6;
								if (markupTag8 != MarkupTag.PADDING)
								{
									if (markupTag8 != MarkupTag.MARK)
									{
										if (markupTag8 == MarkupTag.COLOR)
										{
											color = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, this.m_XmlAttribute[num22].valueStartIndex, this.m_XmlAttribute[num22].valueLength);
										}
									}
									else
									{
										bool flag102 = this.m_XmlAttribute[num22].valueType == TagValueType.ColorValue;
										if (flag102)
										{
											color = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
										}
									}
								}
								else
								{
									int attributeParameters2 = TextGeneratorUtilities.GetAttributeParameters(this.m_HtmlTag, this.m_XmlAttribute[num22].valueStartIndex, this.m_XmlAttribute[num22].valueLength, ref this.m_AttributeParameterValues);
									bool flag103 = attributeParameters2 != 4;
									if (flag103)
									{
										return false;
									}
									offset = new Offset(this.m_AttributeParameterValues[0], this.m_AttributeParameterValues[1], this.m_AttributeParameterValues[2], this.m_AttributeParameterValues[3]);
									offset *= this.m_FontSize * 0.01f * (generationSettings.isOrthographic ? 1f : 0.1f);
								}
								num22++;
							}
							color.a = ((this.m_HtmlColor.a < color.a) ? this.m_HtmlColor.a : color.a);
							this.m_HighlightState = new HighlightState(color, offset);
							this.m_HighlightStateStack.Push(this.m_HighlightState);
							textInfo.hasMultipleColors = true;
							return true;
						}
						if (markupTag != MarkupTag.PAGE)
						{
							goto IL_40F4;
						}
						bool flag104 = generationSettings.overflowMode == TextOverflowMode.Page;
						if (flag104)
						{
							this.m_XAdvance = 0f + this.m_TagLineIndent + this.m_TagIndent;
							this.m_LineOffset = 0f;
							this.m_PageNumber++;
							this.m_IsNewPage = true;
						}
						return true;
					}
				}
				else if (markupTag <= MarkupTag.TH)
				{
					if (markupTag <= MarkupTag.SIZE)
					{
						if (markupTag == MarkupTag.NO_BREAK)
						{
							this.m_IsNonBreakingSpace = true;
							return true;
						}
						if (markupTag != MarkupTag.SIZE)
						{
							goto IL_40F4;
						}
						float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
						bool flag105 = num13 == -32768f;
						if (flag105)
						{
							return false;
						}
						switch (tagUnitType)
						{
						case TagUnitType.Pixels:
						{
							bool flag106 = this.m_HtmlTag[5] == '+';
							if (flag106)
							{
								this.m_CurrentFontSize = this.m_FontSize + num13;
								this.m_SizeStack.Add(this.m_CurrentFontSize);
								return true;
							}
							bool flag107 = this.m_HtmlTag[5] == '-';
							if (flag107)
							{
								this.m_CurrentFontSize = this.m_FontSize + num13;
								this.m_SizeStack.Add(this.m_CurrentFontSize);
								return true;
							}
							this.m_CurrentFontSize = num13;
							this.m_SizeStack.Add(this.m_CurrentFontSize);
							return true;
						}
						case TagUnitType.FontUnits:
							this.m_CurrentFontSize = this.m_FontSize * num13;
							this.m_SizeStack.Add(this.m_CurrentFontSize);
							return true;
						case TagUnitType.Percentage:
							this.m_CurrentFontSize = this.m_FontSize * num13 / 100f;
							this.m_SizeStack.Add(this.m_CurrentFontSize);
							return true;
						default:
							return false;
						}
					}
					else
					{
						if (markupTag == MarkupTag.TR)
						{
							return false;
						}
						if (markupTag == MarkupTag.TD)
						{
							return false;
						}
						if (markupTag != MarkupTag.TH)
						{
							goto IL_40F4;
						}
						return false;
					}
				}
				else if (markupTag <= MarkupTag.SLASH_MARK)
				{
					if (markupTag == MarkupTag.SLASH_NO_BREAK)
					{
						this.m_IsNonBreakingSpace = false;
						return true;
					}
					if (markupTag != MarkupTag.SLASH_MARK)
					{
						goto IL_40F4;
					}
					bool flag108 = (generationSettings.fontStyle & FontStyles.Highlight) != FontStyles.Highlight;
					if (flag108)
					{
						this.m_HighlightStateStack.Remove();
						this.m_HighlightState = this.m_HighlightStateStack.current;
						bool flag109 = this.m_FontStyleStack.Remove(FontStyles.Highlight) == 0;
						if (flag109)
						{
							this.m_FontStyleInternal &= ~FontStyles.Highlight;
						}
					}
					return true;
				}
				else
				{
					if (markupTag == MarkupTag.SLASH_LINK)
					{
						bool flag110 = this.m_isTextLayoutPhase && !this.m_IsCalculatingPreferredValues;
						if (flag110)
						{
							bool flag111 = textInfo.linkCount < textInfo.linkInfo.Length;
							if (flag111)
							{
								textInfo.linkInfo[textInfo.linkCount].linkTextLength = this.m_CharacterCount - textInfo.linkInfo[textInfo.linkCount].linkTextfirstCharacterIndex;
								textInfo.linkCount++;
							}
						}
						return true;
					}
					if (markupTag == MarkupTag.SLASH_FONT)
					{
						MaterialReference materialReference2 = this.m_MaterialReferenceStack.Remove();
						this.m_CurrentFontAsset = materialReference2.fontAsset;
						this.m_CurrentMaterial = materialReference2.material;
						this.m_CurrentMaterialIndex = materialReference2.index;
						return true;
					}
					if (markupTag != MarkupTag.SLASH_SIZE)
					{
						goto IL_40F4;
					}
					this.m_CurrentFontSize = this.m_SizeStack.Remove();
					return true;
				}
			}
			else if (markupTag <= MarkupTag.SLASH_TH)
			{
				if (markupTag <= MarkupTag.SLASH_LINE_INDENT)
				{
					if (markupTag <= MarkupTag.ALPHA)
					{
						if (markupTag == MarkupTag.ALIGN)
						{
							MarkupTag valueHashCode6 = (MarkupTag)this.m_XmlAttribute[0].valueHashCode;
							MarkupTag markupTag9 = valueHashCode6;
							if (markupTag9 <= MarkupTag.LEFT)
							{
								if (markupTag9 == MarkupTag.CENTER)
								{
									this.m_LineJustification = TextAlignment.MiddleCenter;
									this.m_LineJustificationStack.Add(this.m_LineJustification);
									return true;
								}
								if (markupTag9 == MarkupTag.LEFT)
								{
									this.m_LineJustification = TextAlignment.MiddleLeft;
									this.m_LineJustificationStack.Add(this.m_LineJustification);
									return true;
								}
							}
							else
							{
								if (markupTag9 == MarkupTag.FLUSH)
								{
									this.m_LineJustification = TextAlignment.MiddleFlush;
									this.m_LineJustificationStack.Add(this.m_LineJustification);
									return true;
								}
								if (markupTag9 == MarkupTag.RIGHT)
								{
									this.m_LineJustification = TextAlignment.MiddleRight;
									this.m_LineJustificationStack.Add(this.m_LineJustification);
									return true;
								}
								if (markupTag9 == MarkupTag.JUSTIFIED)
								{
									this.m_LineJustification = TextAlignment.MiddleJustified;
									this.m_LineJustificationStack.Add(this.m_LineJustification);
									return true;
								}
							}
							return false;
						}
						if (markupTag != MarkupTag.ALPHA)
						{
							goto IL_40F4;
						}
						bool flag112 = this.m_XmlAttribute[0].valueLength != 3;
						if (flag112)
						{
							return false;
						}
						this.m_HtmlColor.a = (byte)(TextGeneratorUtilities.HexToInt(this.m_HtmlTag[7]) * 16U + TextGeneratorUtilities.HexToInt(this.m_HtmlTag[8]));
						return true;
					}
					else if (markupTag != MarkupTag.COLOR)
					{
						if (markupTag == MarkupTag.CLASS)
						{
							return false;
						}
						if (markupTag != MarkupTag.SLASH_LINE_INDENT)
						{
							goto IL_40F4;
						}
						this.m_TagLineIndent = 0f;
						return true;
					}
					else
					{
						textInfo.hasMultipleColors = true;
						bool flag113 = this.m_HtmlTag[6] == '#' && num == 10;
						if (flag113)
						{
							this.m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, num);
							this.m_ColorStack.Add(this.m_HtmlColor);
							return true;
						}
						bool flag114 = this.m_HtmlTag[6] == '#' && num == 11;
						if (flag114)
						{
							this.m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, num);
							this.m_ColorStack.Add(this.m_HtmlColor);
							return true;
						}
						bool flag115 = this.m_HtmlTag[6] == '#' && num == 13;
						if (flag115)
						{
							this.m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, num);
							this.m_ColorStack.Add(this.m_HtmlColor);
							return true;
						}
						bool flag116 = this.m_HtmlTag[6] == '#' && num == 15;
						if (flag116)
						{
							this.m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(this.m_HtmlTag, num);
							this.m_ColorStack.Add(this.m_HtmlColor);
							return true;
						}
						int valueHashCode7 = this.m_XmlAttribute[0].valueHashCode;
						int num23 = valueHashCode7;
						if (num23 <= 91635)
						{
							if (num23 <= -1108587920)
							{
								if (num23 == -1250222130)
								{
									this.m_HtmlColor = new Color32(160, 32, 240, byte.MaxValue);
									this.m_ColorStack.Add(this.m_HtmlColor);
									return true;
								}
								if (num23 == -1108587920)
								{
									this.m_HtmlColor = new Color32(byte.MaxValue, 128, 0, byte.MaxValue);
									this.m_ColorStack.Add(this.m_HtmlColor);
									return true;
								}
							}
							else
							{
								if (num23 == -992792864)
								{
									this.m_HtmlColor = new Color32(173, 216, 230, byte.MaxValue);
									this.m_ColorStack.Add(this.m_HtmlColor);
									return true;
								}
								if (num23 == -882444668)
								{
									this.m_HtmlColor = Color.yellow;
									this.m_ColorStack.Add(this.m_HtmlColor);
									return true;
								}
								if (num23 == 91635)
								{
									this.m_HtmlColor = Color.red;
									this.m_ColorStack.Add(this.m_HtmlColor);
									return true;
								}
							}
						}
						else if (num23 <= 3680713)
						{
							if (num23 == 2457214)
							{
								this.m_HtmlColor = Color.blue;
								this.m_ColorStack.Add(this.m_HtmlColor);
								return true;
							}
							if (num23 == 3680713)
							{
								this.m_HtmlColor = new Color32(128, 128, 128, byte.MaxValue);
								this.m_ColorStack.Add(this.m_HtmlColor);
								return true;
							}
						}
						else
						{
							if (num23 == 81074727)
							{
								this.m_HtmlColor = Color.black;
								this.m_ColorStack.Add(this.m_HtmlColor);
								return true;
							}
							if (num23 == 87065851)
							{
								this.m_HtmlColor = Color.green;
								this.m_ColorStack.Add(this.m_HtmlColor);
								return true;
							}
							if (num23 == 105680263)
							{
								this.m_HtmlColor = Color.white;
								this.m_ColorStack.Add(this.m_HtmlColor);
								return true;
							}
						}
						return false;
					}
				}
				else if (markupTag <= MarkupTag.SCALE)
				{
					if (markupTag != MarkupTag.SPACE)
					{
						if (markupTag != MarkupTag.SCALE)
						{
							goto IL_40F4;
						}
						float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
						bool flag117 = num13 == -32768f;
						if (flag117)
						{
							return false;
						}
						this.m_FXScale = new Vector3(num13, 1f, 1f);
						return true;
					}
					else
					{
						float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
						bool flag118 = num13 == -32768f;
						if (flag118)
						{
							return false;
						}
						switch (tagUnitType)
						{
						case TagUnitType.Pixels:
							this.m_XAdvance += num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
							return true;
						case TagUnitType.FontUnits:
							this.m_XAdvance += num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
							return true;
						case TagUnitType.Percentage:
							return false;
						default:
							return false;
						}
					}
				}
				else if (markupTag != MarkupTag.WIDTH)
				{
					if (markupTag == MarkupTag.SLASH_TR)
					{
						return false;
					}
					if (markupTag != MarkupTag.SLASH_TH)
					{
						goto IL_40F4;
					}
					return false;
				}
				else
				{
					float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
					bool flag119 = num13 == -32768f;
					if (flag119)
					{
						return false;
					}
					switch (tagUnitType)
					{
					case TagUnitType.Pixels:
						this.m_Width = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
						break;
					case TagUnitType.FontUnits:
						return false;
					case TagUnitType.Percentage:
						this.m_Width = this.m_MarginWidth * num13 / 100f;
						break;
					}
					return true;
				}
			}
			else if (markupTag <= MarkupTag.TABLE)
			{
				if (markupTag <= MarkupTag.SLASH_SMALLCAPS)
				{
					if (markupTag == MarkupTag.SLASH_TD)
					{
						return false;
					}
					if (markupTag != MarkupTag.SLASH_SMALLCAPS)
					{
						goto IL_40F4;
					}
					bool flag120 = (generationSettings.fontStyle & FontStyles.SmallCaps) != FontStyles.SmallCaps;
					if (flag120)
					{
						bool flag121 = this.m_FontStyleStack.Remove(FontStyles.SmallCaps) == 0;
						if (flag121)
						{
							this.m_FontStyleInternal &= ~FontStyles.SmallCaps;
						}
					}
					return true;
				}
				else
				{
					if (markupTag == MarkupTag.SLASH_LINE_HEIGHT)
					{
						this.m_LineHeight = -32767f;
						return true;
					}
					if (markupTag != MarkupTag.ALLCAPS)
					{
						if (markupTag != MarkupTag.TABLE)
						{
							goto IL_40F4;
						}
						return false;
					}
				}
			}
			else if (markupTag <= MarkupTag.SLASH_ALIGN)
			{
				if (markupTag != MarkupTag.MATERIAL)
				{
					if (markupTag == MarkupTag.SLASH_COLOR)
					{
						this.m_HtmlColor = this.m_ColorStack.Remove();
						return true;
					}
					if (markupTag != MarkupTag.SLASH_ALIGN)
					{
						goto IL_40F4;
					}
					this.m_LineJustification = this.m_LineJustificationStack.Remove();
					return true;
				}
				else
				{
					int valueHashCode5 = this.m_XmlAttribute[0].valueHashCode;
					bool flag122 = valueHashCode5 == -620974005;
					if (flag122)
					{
						this.m_CurrentMaterial = this.m_MaterialReferences[0].material;
						this.m_CurrentMaterialIndex = 0;
						this.m_MaterialReferenceStack.Add(this.m_MaterialReferences[0]);
						return true;
					}
					Material material;
					bool flag123 = MaterialReferenceManager.TryGetMaterial(valueHashCode5, out material);
					if (flag123)
					{
						this.m_CurrentMaterial = material;
						this.m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(this.m_CurrentMaterial, this.m_CurrentFontAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
						this.m_MaterialReferenceStack.Add(this.m_MaterialReferences[this.m_CurrentMaterialIndex]);
					}
					else
					{
						material = Resources.Load<Material>(textSettings.defaultFontAssetPath + new string(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength));
						bool flag124 = material == null;
						if (flag124)
						{
							return false;
						}
						MaterialReferenceManager.AddFontMaterial(valueHashCode5, material);
						this.m_CurrentMaterial = material;
						this.m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(this.m_CurrentMaterial, this.m_CurrentFontAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
						this.m_MaterialReferenceStack.Add(this.m_MaterialReferences[this.m_CurrentMaterialIndex]);
					}
					return true;
				}
			}
			else
			{
				if (markupTag == MarkupTag.SLASH_WIDTH)
				{
					this.m_Width = -1f;
					return true;
				}
				if (markupTag == MarkupTag.SLASH_SCALE)
				{
					this.m_FXScale = Vector3.one;
					return true;
				}
				if (markupTag != MarkupTag.VERTICAL_OFFSET)
				{
					goto IL_40F4;
				}
				float num13 = TextGeneratorUtilities.ConvertToFloat(this.m_HtmlTag, this.m_XmlAttribute[0].valueStartIndex, this.m_XmlAttribute[0].valueLength);
				bool flag125 = num13 == -32768f;
				if (flag125)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					this.m_BaselineOffset = num13 * (generationSettings.isOrthographic ? 1f : 0.1f);
					return true;
				case TagUnitType.FontUnits:
					this.m_BaselineOffset = num13 * (generationSettings.isOrthographic ? 1f : 0.1f) * this.m_CurrentFontSize;
					return true;
				case TagUnitType.Percentage:
					return false;
				default:
					return false;
				}
			}
			IL_3701:
			this.m_FontStyleInternal |= FontStyles.UpperCase;
			this.m_FontStyleStack.Add(FontStyles.UpperCase);
			return true;
			IL_40F4:
			return false;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00016F40 File Offset: 0x00015140
		private void SaveGlyphVertexInfo(float padding, float stylePadding, Color32 vertexColor, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			textInfo.textElementInfo[this.m_CharacterCount].vertexBottomLeft.position = textInfo.textElementInfo[this.m_CharacterCount].bottomLeft;
			textInfo.textElementInfo[this.m_CharacterCount].vertexTopLeft.position = textInfo.textElementInfo[this.m_CharacterCount].topLeft;
			textInfo.textElementInfo[this.m_CharacterCount].vertexTopRight.position = textInfo.textElementInfo[this.m_CharacterCount].topRight;
			textInfo.textElementInfo[this.m_CharacterCount].vertexBottomRight.position = textInfo.textElementInfo[this.m_CharacterCount].bottomRight;
			vertexColor.a = ((this.m_FontColor32.a < vertexColor.a) ? this.m_FontColor32.a : vertexColor.a);
			bool flag = false;
			bool flag2 = generationSettings.fontColorGradient == null || flag;
			if (flag2)
			{
				vertexColor = (flag ? new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, vertexColor.a) : vertexColor);
				textInfo.textElementInfo[this.m_CharacterCount].vertexBottomLeft.color = vertexColor;
				textInfo.textElementInfo[this.m_CharacterCount].vertexTopLeft.color = vertexColor;
				textInfo.textElementInfo[this.m_CharacterCount].vertexTopRight.color = vertexColor;
				textInfo.textElementInfo[this.m_CharacterCount].vertexBottomRight.color = vertexColor;
			}
			else
			{
				bool flag3 = !generationSettings.overrideRichTextColors && this.m_ColorStack.index > 1;
				if (flag3)
				{
					textInfo.textElementInfo[this.m_CharacterCount].vertexBottomLeft.color = vertexColor;
					textInfo.textElementInfo[this.m_CharacterCount].vertexTopLeft.color = vertexColor;
					textInfo.textElementInfo[this.m_CharacterCount].vertexTopRight.color = vertexColor;
					textInfo.textElementInfo[this.m_CharacterCount].vertexBottomRight.color = vertexColor;
				}
				else
				{
					bool flag4 = generationSettings.fontColorGradientPreset != null;
					if (flag4)
					{
						textInfo.textElementInfo[this.m_CharacterCount].vertexBottomLeft.color = generationSettings.fontColorGradientPreset.bottomLeft * vertexColor;
						textInfo.textElementInfo[this.m_CharacterCount].vertexTopLeft.color = generationSettings.fontColorGradientPreset.topLeft * vertexColor;
						textInfo.textElementInfo[this.m_CharacterCount].vertexTopRight.color = generationSettings.fontColorGradientPreset.topRight * vertexColor;
						textInfo.textElementInfo[this.m_CharacterCount].vertexBottomRight.color = generationSettings.fontColorGradientPreset.bottomRight * vertexColor;
					}
					else
					{
						textInfo.textElementInfo[this.m_CharacterCount].vertexBottomLeft.color = generationSettings.fontColorGradient.bottomLeft * vertexColor;
						textInfo.textElementInfo[this.m_CharacterCount].vertexTopLeft.color = generationSettings.fontColorGradient.topLeft * vertexColor;
						textInfo.textElementInfo[this.m_CharacterCount].vertexTopRight.color = generationSettings.fontColorGradient.topRight * vertexColor;
						textInfo.textElementInfo[this.m_CharacterCount].vertexBottomRight.color = generationSettings.fontColorGradient.bottomRight * vertexColor;
					}
				}
			}
			bool flag5 = this.m_ColorGradientPreset != null && !flag;
			if (flag5)
			{
				bool colorGradientPresetIsTinted = this.m_ColorGradientPresetIsTinted;
				if (colorGradientPresetIsTinted)
				{
					TextElementInfo[] textElementInfo = textInfo.textElementInfo;
					int characterCount = this.m_CharacterCount;
					textElementInfo[characterCount].vertexBottomLeft.color = textElementInfo[characterCount].vertexBottomLeft.color * this.m_ColorGradientPreset.bottomLeft;
					TextElementInfo[] textElementInfo2 = textInfo.textElementInfo;
					int characterCount2 = this.m_CharacterCount;
					textElementInfo2[characterCount2].vertexTopLeft.color = textElementInfo2[characterCount2].vertexTopLeft.color * this.m_ColorGradientPreset.topLeft;
					TextElementInfo[] textElementInfo3 = textInfo.textElementInfo;
					int characterCount3 = this.m_CharacterCount;
					textElementInfo3[characterCount3].vertexTopRight.color = textElementInfo3[characterCount3].vertexTopRight.color * this.m_ColorGradientPreset.topRight;
					TextElementInfo[] textElementInfo4 = textInfo.textElementInfo;
					int characterCount4 = this.m_CharacterCount;
					textElementInfo4[characterCount4].vertexBottomRight.color = textElementInfo4[characterCount4].vertexBottomRight.color * this.m_ColorGradientPreset.bottomRight;
				}
				else
				{
					textInfo.textElementInfo[this.m_CharacterCount].vertexBottomLeft.color = this.m_ColorGradientPreset.bottomLeft.MinAlpha(vertexColor);
					textInfo.textElementInfo[this.m_CharacterCount].vertexTopLeft.color = this.m_ColorGradientPreset.topLeft.MinAlpha(vertexColor);
					textInfo.textElementInfo[this.m_CharacterCount].vertexTopRight.color = this.m_ColorGradientPreset.topRight.MinAlpha(vertexColor);
					textInfo.textElementInfo[this.m_CharacterCount].vertexBottomRight.color = this.m_ColorGradientPreset.bottomRight.MinAlpha(vertexColor);
				}
			}
			stylePadding = 0f;
			Glyph alternativeGlyph = textInfo.textElementInfo[this.m_CharacterCount].alternativeGlyph;
			GlyphRect glyphRect = (alternativeGlyph == null) ? this.m_CachedTextElement.m_Glyph.glyphRect : alternativeGlyph.glyphRect;
			Vector2 vector;
			vector.x = ((float)glyphRect.x - padding - stylePadding) / (float)this.m_CurrentFontAsset.atlasWidth;
			vector.y = ((float)glyphRect.y - padding - stylePadding) / (float)this.m_CurrentFontAsset.atlasHeight;
			Vector2 vector2;
			vector2.x = vector.x;
			vector2.y = ((float)glyphRect.y + padding + stylePadding + (float)glyphRect.height) / (float)this.m_CurrentFontAsset.atlasHeight;
			Vector2 vector3;
			vector3.x = ((float)glyphRect.x + padding + stylePadding + (float)glyphRect.width) / (float)this.m_CurrentFontAsset.atlasWidth;
			vector3.y = vector2.y;
			Vector2 v;
			v.x = vector3.x;
			v.y = vector.y;
			textInfo.textElementInfo[this.m_CharacterCount].vertexBottomLeft.uv = vector;
			textInfo.textElementInfo[this.m_CharacterCount].vertexTopLeft.uv = vector2;
			textInfo.textElementInfo[this.m_CharacterCount].vertexTopRight.uv = vector3;
			textInfo.textElementInfo[this.m_CharacterCount].vertexBottomRight.uv = v;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00017724 File Offset: 0x00015924
		private void SaveSpriteVertexInfo(Color32 vertexColor, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			textInfo.textElementInfo[this.m_CharacterCount].vertexBottomLeft.position = textInfo.textElementInfo[this.m_CharacterCount].bottomLeft;
			textInfo.textElementInfo[this.m_CharacterCount].vertexTopLeft.position = textInfo.textElementInfo[this.m_CharacterCount].topLeft;
			textInfo.textElementInfo[this.m_CharacterCount].vertexTopRight.position = textInfo.textElementInfo[this.m_CharacterCount].topRight;
			textInfo.textElementInfo[this.m_CharacterCount].vertexBottomRight.position = textInfo.textElementInfo[this.m_CharacterCount].bottomRight;
			bool tintSprites = generationSettings.tintSprites;
			if (tintSprites)
			{
				this.m_TintSprite = true;
			}
			Color32 color = this.m_TintSprite ? ColorUtilities.MultiplyColors(this.m_SpriteColor, vertexColor) : this.m_SpriteColor;
			color.a = ((color.a < this.m_FontColor32.a) ? ((color.a < vertexColor.a) ? color.a : vertexColor.a) : this.m_FontColor32.a);
			Color32 color2 = color;
			Color32 color3 = color;
			Color32 color4 = color;
			Color32 color5 = color;
			bool flag = generationSettings.fontColorGradient != null;
			if (flag)
			{
				bool flag2 = generationSettings.fontColorGradientPreset != null;
				if (flag2)
				{
					color2 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color2, generationSettings.fontColorGradientPreset.bottomLeft) : color2);
					color3 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color3, generationSettings.fontColorGradientPreset.topLeft) : color3);
					color4 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color4, generationSettings.fontColorGradientPreset.topRight) : color4);
					color5 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color5, generationSettings.fontColorGradientPreset.bottomRight) : color5);
				}
				else
				{
					color2 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color2, generationSettings.fontColorGradient.bottomLeft) : color2);
					color3 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color3, generationSettings.fontColorGradient.topLeft) : color3);
					color4 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color4, generationSettings.fontColorGradient.topRight) : color4);
					color5 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color5, generationSettings.fontColorGradient.bottomRight) : color5);
				}
			}
			bool flag3 = this.m_ColorGradientPreset != null;
			if (flag3)
			{
				color2 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color2, this.m_ColorGradientPreset.bottomLeft) : color2);
				color3 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color3, this.m_ColorGradientPreset.topLeft) : color3);
				color4 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color4, this.m_ColorGradientPreset.topRight) : color4);
				color5 = (this.m_TintSprite ? ColorUtilities.MultiplyColors(color5, this.m_ColorGradientPreset.bottomRight) : color5);
			}
			this.m_TintSprite = false;
			textInfo.textElementInfo[this.m_CharacterCount].vertexBottomLeft.color = color2;
			textInfo.textElementInfo[this.m_CharacterCount].vertexTopLeft.color = color3;
			textInfo.textElementInfo[this.m_CharacterCount].vertexTopRight.color = color4;
			textInfo.textElementInfo[this.m_CharacterCount].vertexBottomRight.color = color5;
			Vector2 vector = new Vector2((float)this.m_CachedTextElement.glyph.glyphRect.x / (float)this.m_CurrentSpriteAsset.spriteSheet.width, (float)this.m_CachedTextElement.glyph.glyphRect.y / (float)this.m_CurrentSpriteAsset.spriteSheet.height);
			Vector2 vector2 = new Vector2(vector.x, (float)(this.m_CachedTextElement.glyph.glyphRect.y + this.m_CachedTextElement.glyph.glyphRect.height) / (float)this.m_CurrentSpriteAsset.spriteSheet.height);
			Vector2 vector3 = new Vector2((float)(this.m_CachedTextElement.glyph.glyphRect.x + this.m_CachedTextElement.glyph.glyphRect.width) / (float)this.m_CurrentSpriteAsset.spriteSheet.width, vector2.y);
			Vector2 v = new Vector2(vector3.x, vector.y);
			textInfo.textElementInfo[this.m_CharacterCount].vertexBottomLeft.uv = vector;
			textInfo.textElementInfo[this.m_CharacterCount].vertexTopLeft.uv = vector2;
			textInfo.textElementInfo[this.m_CharacterCount].vertexTopRight.uv = vector3;
			textInfo.textElementInfo[this.m_CharacterCount].vertexBottomRight.uv = v;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00017C7C File Offset: 0x00015E7C
		private void DrawUnderlineMesh(Vector3 start, Vector3 end, float startScale, float endScale, float maxScale, float sdfScale, Color32 underlineColor, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			this.GetUnderlineSpecialCharacter(generationSettings);
			bool flag = this.m_Underline.character == null;
			if (flag)
			{
				bool displayWarnings = generationSettings.textSettings.displayWarnings;
				if (displayWarnings)
				{
					Debug.LogWarning("Unable to add underline or strikethrough since the character [0x5F] used by these features is not present in the Font Asset assigned to this text object.");
				}
			}
			else
			{
				int vertexCount = textInfo.meshInfo[this.m_CurrentMaterialIndex].vertexCount;
				int num = vertexCount + 12;
				bool flag2 = num > textInfo.meshInfo[this.m_CurrentMaterialIndex].vertices.Length;
				if (flag2)
				{
					textInfo.meshInfo[this.m_CurrentMaterialIndex].ResizeMeshInfo(num / 4);
				}
				start.y = Mathf.Min(start.y, end.y);
				end.y = Mathf.Min(start.y, end.y);
				GlyphMetrics metrics = this.m_Underline.character.glyph.metrics;
				GlyphRect glyphRect = this.m_Underline.character.glyph.glyphRect;
				start.x += (startScale - maxScale) * this.m_Padding;
				end.x += (maxScale - endScale) * this.m_Padding;
				float num2 = (metrics.width * 0.5f + this.m_Padding) * maxScale;
				float num3 = 1f;
				float num4 = 2f * num2;
				float num5 = end.x - start.x;
				bool flag3 = num5 < num4;
				if (flag3)
				{
					num3 = num5 / num4;
					num2 *= num3;
				}
				float underlineThickness = this.m_Underline.fontAsset.faceInfo.underlineThickness;
				float x = start.x;
				float x2 = start.x + num2;
				float x3 = end.x - num2;
				float x4 = end.x;
				float y = start.y - (underlineThickness + this.m_Padding) * maxScale;
				float y2 = start.y + this.m_Padding * maxScale;
				Vector3[] vertices = textInfo.meshInfo[this.m_CurrentMaterialIndex].vertices;
				vertices[vertexCount] = new Vector3(x, y);
				vertices[vertexCount + 1] = new Vector3(x, y2);
				vertices[vertexCount + 2] = new Vector3(x2, y2);
				vertices[vertexCount + 3] = new Vector3(x2, y);
				vertices[vertexCount + 4] = new Vector3(x2, y);
				vertices[vertexCount + 5] = new Vector3(x2, y2);
				vertices[vertexCount + 6] = new Vector3(x3, y2);
				vertices[vertexCount + 7] = new Vector3(x3, y);
				vertices[vertexCount + 8] = new Vector3(x3, y);
				vertices[vertexCount + 9] = new Vector3(x3, y2);
				vertices[vertexCount + 10] = new Vector3(x4, y2);
				vertices[vertexCount + 11] = new Vector3(x4, y);
				bool inverseYAxis = generationSettings.inverseYAxis;
				if (inverseYAxis)
				{
					Vector3 vector;
					vector.x = 0f;
					vector.y = generationSettings.screenRect.y + generationSettings.screenRect.height;
					vector.z = 0f;
					for (int i = 0; i < 12; i++)
					{
						vertices[vertexCount + i].y = vertices[vertexCount + i].y * -1f + vector.y;
					}
				}
				float num6 = 1f / (float)this.m_Underline.fontAsset.atlasWidth;
				float num7 = 1f / (float)this.m_Underline.fontAsset.atlasHeight;
				float num8 = ((float)glyphRect.width * 0.5f + this.m_Padding) * num3 * num6;
				float num9 = ((float)glyphRect.x - this.m_Padding) * num6;
				float x5 = num9 + num8;
				float x6 = ((float)glyphRect.x + (float)glyphRect.width * 0.5f) * num6;
				float num10 = ((float)(glyphRect.x + glyphRect.width) + this.m_Padding) * num6;
				float x7 = num10 - num8;
				float y3 = ((float)glyphRect.y - this.m_Padding) * num7;
				float y4 = ((float)(glyphRect.y + glyphRect.height) + this.m_Padding) * num7;
				float num11 = Mathf.Abs(sdfScale);
				Vector4[] uvs = textInfo.meshInfo[this.m_CurrentMaterialIndex].uvs0;
				uvs[vertexCount] = new Vector4(num9, y3, 0f, num11);
				uvs[1 + vertexCount] = new Vector4(num9, y4, 0f, num11);
				uvs[2 + vertexCount] = new Vector4(x5, y4, 0f, num11);
				uvs[3 + vertexCount] = new Vector4(x5, y3, 0f, num11);
				uvs[4 + vertexCount] = new Vector4(x6, y3, 0f, num11);
				uvs[5 + vertexCount] = new Vector4(x6, y4, 0f, num11);
				uvs[6 + vertexCount] = new Vector4(x6, y4, 0f, num11);
				uvs[7 + vertexCount] = new Vector4(x6, y3, 0f, num11);
				uvs[8 + vertexCount] = new Vector4(x7, y3, 0f, num11);
				uvs[9 + vertexCount] = new Vector4(x7, y4, 0f, num11);
				uvs[10 + vertexCount] = new Vector4(num10, y4, 0f, num11);
				uvs[11 + vertexCount] = new Vector4(num10, y3, 0f, num11);
				float num12 = 1f / num5;
				float x8 = (vertices[vertexCount + 2].x - start.x) * num12;
				Vector2[] uvs2 = textInfo.meshInfo[this.m_CurrentMaterialIndex].uvs2;
				uvs2[vertexCount] = TextGeneratorUtilities.PackUV(0f, 0f, num11);
				uvs2[1 + vertexCount] = TextGeneratorUtilities.PackUV(0f, 1f, num11);
				uvs2[2 + vertexCount] = TextGeneratorUtilities.PackUV(x8, 1f, num11);
				uvs2[3 + vertexCount] = TextGeneratorUtilities.PackUV(x8, 0f, num11);
				float x9 = (vertices[vertexCount + 4].x - start.x) * num12;
				x8 = (vertices[vertexCount + 6].x - start.x) * num12;
				uvs2[4 + vertexCount] = TextGeneratorUtilities.PackUV(x9, 0f, num11);
				uvs2[5 + vertexCount] = TextGeneratorUtilities.PackUV(x9, 1f, num11);
				uvs2[6 + vertexCount] = TextGeneratorUtilities.PackUV(x8, 1f, num11);
				uvs2[7 + vertexCount] = TextGeneratorUtilities.PackUV(x8, 0f, num11);
				x9 = (vertices[vertexCount + 8].x - start.x) * num12;
				uvs2[8 + vertexCount] = TextGeneratorUtilities.PackUV(x9, 0f, num11);
				uvs2[9 + vertexCount] = TextGeneratorUtilities.PackUV(x9, 1f, num11);
				uvs2[10 + vertexCount] = TextGeneratorUtilities.PackUV(1f, 1f, num11);
				uvs2[11 + vertexCount] = TextGeneratorUtilities.PackUV(1f, 0f, num11);
				underlineColor.a = ((this.m_FontColor32.a < underlineColor.a) ? this.m_FontColor32.a : underlineColor.a);
				Color32[] colors = textInfo.meshInfo[this.m_CurrentMaterialIndex].colors32;
				for (int j = 0; j < 12; j++)
				{
					colors[j + vertexCount] = underlineColor;
				}
				MeshInfo[] meshInfo = textInfo.meshInfo;
				int currentMaterialIndex = this.m_CurrentMaterialIndex;
				meshInfo[currentMaterialIndex].vertexCount = meshInfo[currentMaterialIndex].vertexCount + 12;
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00018480 File Offset: 0x00016680
		private void DrawTextHighlight(Vector3 start, Vector3 end, Color32 highlightColor, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			this.GetUnderlineSpecialCharacter(generationSettings);
			bool flag = this.m_Underline.character == null;
			if (flag)
			{
				bool displayWarnings = generationSettings.textSettings.displayWarnings;
				if (displayWarnings)
				{
					Debug.LogWarning("Unable to add highlight since the primary Font Asset doesn't contain the underline character.");
				}
			}
			else
			{
				int vertexCount = textInfo.meshInfo[this.m_CurrentMaterialIndex].vertexCount;
				int num = vertexCount + 4;
				bool flag2 = num > textInfo.meshInfo[this.m_CurrentMaterialIndex].vertices.Length;
				if (flag2)
				{
					textInfo.meshInfo[this.m_CurrentMaterialIndex].ResizeMeshInfo(num / 4);
				}
				Vector3[] vertices = textInfo.meshInfo[this.m_CurrentMaterialIndex].vertices;
				vertices[vertexCount] = start;
				vertices[vertexCount + 1] = new Vector3(start.x, end.y, 0f);
				vertices[vertexCount + 2] = end;
				vertices[vertexCount + 3] = new Vector3(end.x, start.y, 0f);
				bool inverseYAxis = generationSettings.inverseYAxis;
				if (inverseYAxis)
				{
					Vector3 vector;
					vector.x = 0f;
					vector.y = generationSettings.screenRect.y + generationSettings.screenRect.height;
					vector.z = 0f;
					vertices[vertexCount].y = vertices[vertexCount].y * -1f + vector.y;
					vertices[vertexCount + 1].y = vertices[vertexCount + 1].y * -1f + vector.y;
					vertices[vertexCount + 2].y = vertices[vertexCount + 2].y * -1f + vector.y;
					vertices[vertexCount + 3].y = vertices[vertexCount + 3].y * -1f + vector.y;
				}
				Vector4[] uvs = textInfo.meshInfo[this.m_CurrentMaterialIndex].uvs0;
				int atlasWidth = this.m_Underline.fontAsset.atlasWidth;
				int atlasHeight = this.m_Underline.fontAsset.atlasHeight;
				GlyphRect glyphRect = this.m_Underline.character.glyph.glyphRect;
				Vector2 a = new Vector2(((float)glyphRect.x + (float)glyphRect.width / 2f) / (float)atlasWidth, ((float)glyphRect.y + (float)glyphRect.height / 2f) / (float)atlasHeight);
				Vector2 vector2 = new Vector2(1f / (float)atlasWidth, 1f / (float)atlasHeight);
				uvs[vertexCount] = a - vector2;
				uvs[1 + vertexCount] = a + new Vector2(-vector2.x, vector2.y);
				uvs[2 + vertexCount] = a + vector2;
				uvs[3 + vertexCount] = a + new Vector2(vector2.x, -vector2.y);
				Vector2[] uvs2 = textInfo.meshInfo[this.m_CurrentMaterialIndex].uvs2;
				Vector2 vector3 = new Vector2(0f, 1f);
				uvs2[vertexCount] = vector3;
				uvs2[1 + vertexCount] = vector3;
				uvs2[2 + vertexCount] = vector3;
				uvs2[3 + vertexCount] = vector3;
				highlightColor.a = ((this.m_FontColor32.a < highlightColor.a) ? this.m_FontColor32.a : highlightColor.a);
				Color32[] colors = textInfo.meshInfo[this.m_CurrentMaterialIndex].colors32;
				colors[vertexCount] = highlightColor;
				colors[1 + vertexCount] = highlightColor;
				colors[2 + vertexCount] = highlightColor;
				colors[3 + vertexCount] = highlightColor;
				MeshInfo[] meshInfo = textInfo.meshInfo;
				int currentMaterialIndex = this.m_CurrentMaterialIndex;
				meshInfo[currentMaterialIndex].vertexCount = meshInfo[currentMaterialIndex].vertexCount + 4;
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0001888A File Offset: 0x00016A8A
		private static void ClearMesh(bool updateMesh, TextInfo textInfo)
		{
			textInfo.ClearMeshInfo(updateMesh);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00018898 File Offset: 0x00016A98
		internal int SetArraySizes(TextProcessingElement[] textProcessingArray, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			TextSettings textSettings = generationSettings.textSettings;
			int num = 0;
			this.m_TotalCharacterCount = 0;
			this.m_isTextLayoutPhase = false;
			this.m_TagNoParsing = false;
			this.m_FontStyleInternal = generationSettings.fontStyle;
			this.m_FontStyleStack.Clear();
			this.m_FontWeightInternal = (((this.m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold) ? TextFontWeight.Bold : generationSettings.fontWeight);
			this.m_FontWeightStack.SetDefault(this.m_FontWeightInternal);
			this.m_CurrentFontAsset = generationSettings.fontAsset;
			this.m_CurrentMaterial = generationSettings.material;
			this.m_CurrentMaterialIndex = 0;
			this.m_MaterialReferenceStack.SetDefault(new MaterialReference(this.m_CurrentMaterialIndex, this.m_CurrentFontAsset, null, this.m_CurrentMaterial, this.m_Padding));
			this.m_MaterialReferenceIndexLookup.Clear();
			MaterialReference.AddMaterialReference(this.m_CurrentMaterial, this.m_CurrentFontAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
			bool flag = textInfo == null;
			if (flag)
			{
				textInfo = new TextInfo();
			}
			else
			{
				bool flag2 = textInfo.textElementInfo.Length < this.m_InternalTextProcessingArraySize;
				if (flag2)
				{
					TextInfo.Resize<TextElementInfo>(ref textInfo.textElementInfo, this.m_InternalTextProcessingArraySize, false);
				}
			}
			this.m_TextElementType = TextElementType.Character;
			bool flag3 = generationSettings.overflowMode == TextOverflowMode.Ellipsis;
			if (flag3)
			{
				this.GetEllipsisSpecialCharacter(generationSettings);
				bool flag4 = this.m_Ellipsis.character != null;
				if (flag4)
				{
					bool flag5 = this.m_Ellipsis.fontAsset.GetInstanceID() != this.m_CurrentFontAsset.GetInstanceID();
					if (flag5)
					{
						bool flag6 = textSettings.matchMaterialPreset && this.m_CurrentMaterial.GetInstanceID() != this.m_Ellipsis.fontAsset.material.GetInstanceID();
						if (flag6)
						{
							this.m_Ellipsis.material = MaterialManager.GetFallbackMaterial(this.m_CurrentMaterial, this.m_Ellipsis.fontAsset.material);
						}
						else
						{
							this.m_Ellipsis.material = this.m_Ellipsis.fontAsset.material;
						}
						this.m_Ellipsis.materialIndex = MaterialReference.AddMaterialReference(this.m_Ellipsis.material, this.m_Ellipsis.fontAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
						this.m_MaterialReferences[this.m_Ellipsis.materialIndex].referenceCount = 0;
					}
				}
				else
				{
					generationSettings.overflowMode = TextOverflowMode.Truncate;
					bool displayWarnings = textSettings.displayWarnings;
					if (displayWarnings)
					{
						Debug.LogWarning("The character used for Ellipsis is not available in font asset [" + this.m_CurrentFontAsset.name + "] or any potential fallbacks. Switching Text Overflow mode to Truncate.");
					}
				}
			}
			int num2 = 0;
			while (num2 < textProcessingArray.Length && textProcessingArray[num2].unicode > 0U)
			{
				bool flag7 = textInfo.textElementInfo == null || this.m_TotalCharacterCount >= textInfo.textElementInfo.Length;
				if (flag7)
				{
					TextInfo.Resize<TextElementInfo>(ref textInfo.textElementInfo, this.m_TotalCharacterCount + 1, true);
				}
				uint num3 = textProcessingArray[num2].unicode;
				int currentMaterialIndex = this.m_CurrentMaterialIndex;
				bool flag8 = generationSettings.richText && num3 == 60U;
				if (!flag8)
				{
					goto IL_45A;
				}
				currentMaterialIndex = this.m_CurrentMaterialIndex;
				int num4;
				bool flag9 = this.ValidateHtmlTag(textProcessingArray, num2 + 1, out num4, generationSettings, textInfo);
				if (!flag9)
				{
					goto IL_45A;
				}
				int stringIndex = textProcessingArray[num2].stringIndex;
				num2 = num4;
				bool flag10 = this.m_TextElementType == TextElementType.Sprite;
				if (flag10)
				{
					MaterialReference[] materialReferences = this.m_MaterialReferences;
					int currentMaterialIndex2 = this.m_CurrentMaterialIndex;
					materialReferences[currentMaterialIndex2].referenceCount = materialReferences[currentMaterialIndex2].referenceCount + 1;
					textInfo.textElementInfo[this.m_TotalCharacterCount].character = (char)(57344 + this.m_SpriteIndex);
					textInfo.textElementInfo[this.m_TotalCharacterCount].fontAsset = this.m_CurrentFontAsset;
					textInfo.textElementInfo[this.m_TotalCharacterCount].materialReferenceIndex = this.m_CurrentMaterialIndex;
					textInfo.textElementInfo[this.m_TotalCharacterCount].textElement = this.m_CurrentSpriteAsset.spriteCharacterTable[this.m_SpriteIndex];
					textInfo.textElementInfo[this.m_TotalCharacterCount].elementType = this.m_TextElementType;
					textInfo.textElementInfo[this.m_TotalCharacterCount].index = stringIndex;
					textInfo.textElementInfo[this.m_TotalCharacterCount].stringLength = textProcessingArray[num2].stringIndex - stringIndex + 1;
					this.m_TextElementType = TextElementType.Character;
					this.m_CurrentMaterialIndex = currentMaterialIndex;
					num++;
					this.m_TotalCharacterCount++;
				}
				IL_C98:
				num2++;
				continue;
				IL_45A:
				bool flag11 = false;
				FontAsset currentFontAsset = this.m_CurrentFontAsset;
				Material currentMaterial = this.m_CurrentMaterial;
				currentMaterialIndex = this.m_CurrentMaterialIndex;
				bool flag12 = this.m_TextElementType == TextElementType.Character;
				if (flag12)
				{
					bool flag13 = (this.m_FontStyleInternal & FontStyles.UpperCase) == FontStyles.UpperCase;
					if (flag13)
					{
						bool flag14 = char.IsLower((char)num3);
						if (flag14)
						{
							num3 = (uint)char.ToUpper((char)num3);
						}
					}
					else
					{
						bool flag15 = (this.m_FontStyleInternal & FontStyles.LowerCase) == FontStyles.LowerCase;
						if (flag15)
						{
							bool flag16 = char.IsUpper((char)num3);
							if (flag16)
							{
								num3 = (uint)char.ToLower((char)num3);
							}
						}
						else
						{
							bool flag17 = (this.m_FontStyleInternal & FontStyles.SmallCaps) == FontStyles.SmallCaps;
							if (flag17)
							{
								bool flag18 = char.IsLower((char)num3);
								if (flag18)
								{
									num3 = (uint)char.ToUpper((char)num3);
								}
							}
						}
					}
				}
				bool isUsingAlternateTypeface;
				TextElement textElement = this.GetTextElement(generationSettings, num3, this.m_CurrentFontAsset, this.m_FontStyleInternal, this.m_FontWeightInternal, out isUsingAlternateTypeface);
				bool flag19 = textElement == null;
				if (flag19)
				{
					this.DoMissingGlyphCallback(num3, textProcessingArray[num2].stringIndex, this.m_CurrentFontAsset, textInfo);
					uint num5 = num3;
					num3 = (textProcessingArray[num2].unicode = (uint)((textSettings.missingCharacterUnicode == 0) ? 9633 : textSettings.missingCharacterUnicode));
					textElement = FontAssetUtilities.GetCharacterFromFontAsset(num3, this.m_CurrentFontAsset, true, this.m_FontStyleInternal, this.m_FontWeightInternal, out isUsingAlternateTypeface);
					bool flag20 = textElement == null;
					if (flag20)
					{
						bool flag21 = textSettings.fallbackFontAssets != null && textSettings.fallbackFontAssets.Count > 0;
						if (flag21)
						{
							textElement = FontAssetUtilities.GetCharacterFromFontAssets(num3, this.m_CurrentFontAsset, textSettings.fallbackFontAssets, true, this.m_FontStyleInternal, this.m_FontWeightInternal, out isUsingAlternateTypeface);
						}
					}
					bool flag22 = textElement == null;
					if (flag22)
					{
						bool flag23 = textSettings.defaultFontAsset != null;
						if (flag23)
						{
							textElement = FontAssetUtilities.GetCharacterFromFontAsset(num3, textSettings.defaultFontAsset, true, this.m_FontStyleInternal, this.m_FontWeightInternal, out isUsingAlternateTypeface);
						}
					}
					bool flag24 = textElement == null;
					if (flag24)
					{
						num3 = (textProcessingArray[num2].unicode = 32U);
						textElement = FontAssetUtilities.GetCharacterFromFontAsset(num3, this.m_CurrentFontAsset, true, this.m_FontStyleInternal, this.m_FontWeightInternal, out isUsingAlternateTypeface);
					}
					bool flag25 = textElement == null;
					if (flag25)
					{
						num3 = (textProcessingArray[num2].unicode = 3U);
						textElement = FontAssetUtilities.GetCharacterFromFontAsset(num3, this.m_CurrentFontAsset, true, this.m_FontStyleInternal, this.m_FontWeightInternal, out isUsingAlternateTypeface);
					}
					bool displayWarnings2 = textSettings.displayWarnings;
					if (displayWarnings2)
					{
						string message = (num5 > 65535U) ? string.Format("The character with Unicode value \\U{0:X8} was not found in the [{1}] font asset or any potential fallbacks. It was replaced by Unicode character \\u{2:X4}.", num5, generationSettings.fontAsset.name, textElement.unicode) : string.Format("The character with Unicode value \\u{0:X4} was not found in the [{1}] font asset or any potential fallbacks. It was replaced by Unicode character \\u{2:X4}.", num5, generationSettings.fontAsset.name, textElement.unicode);
						Debug.LogWarning(message);
					}
				}
				textInfo.textElementInfo[this.m_TotalCharacterCount].alternativeGlyph = null;
				bool flag26 = textElement.elementType == TextElementType.Character;
				if (flag26)
				{
					bool flag27 = textElement.textAsset.instanceID != this.m_CurrentFontAsset.instanceID;
					if (flag27)
					{
						flag11 = true;
						this.m_CurrentFontAsset = (textElement.textAsset as FontAsset);
					}
					List<LigatureSubstitutionRecord> list;
					bool flag28 = this.m_CurrentFontAsset.fontFeatureTable.m_LigatureSubstitutionRecordLookup.TryGetValue(textElement.glyphIndex, out list);
					if (flag28)
					{
						bool flag29 = list == null;
						if (flag29)
						{
							break;
						}
						for (int i = 0; i < list.Count; i++)
						{
							LigatureSubstitutionRecord ligatureSubstitutionRecord = list[i];
							int num6 = ligatureSubstitutionRecord.componentGlyphIDs.Length;
							uint num7 = ligatureSubstitutionRecord.ligatureGlyphID;
							for (int j = 1; j < num6; j++)
							{
								uint glyphIndex = this.m_CurrentFontAsset.GetGlyphIndex(textProcessingArray[num2 + j].unicode);
								bool flag30 = glyphIndex == ligatureSubstitutionRecord.componentGlyphIDs[j];
								if (!flag30)
								{
									num7 = 0U;
									break;
								}
							}
							bool flag31 = num7 > 0U;
							if (flag31)
							{
								Glyph alternativeGlyph;
								bool flag32 = this.m_CurrentFontAsset.TryAddGlyphInternal(num7, out alternativeGlyph);
								if (flag32)
								{
									textInfo.textElementInfo[this.m_TotalCharacterCount].alternativeGlyph = alternativeGlyph;
									for (int k = 0; k < num6; k++)
									{
										bool flag33 = k == 0;
										if (flag33)
										{
											textProcessingArray[num2 + k].length = num6;
										}
										else
										{
											textProcessingArray[num2 + k].unicode = 26U;
										}
									}
									num2 += num6 - 1;
									break;
								}
							}
						}
					}
				}
				textInfo.textElementInfo[this.m_TotalCharacterCount].elementType = TextElementType.Character;
				textInfo.textElementInfo[this.m_TotalCharacterCount].textElement = textElement;
				textInfo.textElementInfo[this.m_TotalCharacterCount].isUsingAlternateTypeface = isUsingAlternateTypeface;
				textInfo.textElementInfo[this.m_TotalCharacterCount].character = (char)num3;
				textInfo.textElementInfo[this.m_TotalCharacterCount].index = textProcessingArray[num2].stringIndex;
				textInfo.textElementInfo[this.m_TotalCharacterCount].stringLength = textProcessingArray[num2].length;
				textInfo.textElementInfo[this.m_TotalCharacterCount].fontAsset = this.m_CurrentFontAsset;
				bool flag34 = textElement.elementType == TextElementType.Sprite;
				if (flag34)
				{
					SpriteAsset spriteAsset = textElement.textAsset as SpriteAsset;
					this.m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(spriteAsset.material, spriteAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
					MaterialReference[] materialReferences2 = this.m_MaterialReferences;
					int currentMaterialIndex3 = this.m_CurrentMaterialIndex;
					materialReferences2[currentMaterialIndex3].referenceCount = materialReferences2[currentMaterialIndex3].referenceCount + 1;
					textInfo.textElementInfo[this.m_TotalCharacterCount].elementType = TextElementType.Sprite;
					textInfo.textElementInfo[this.m_TotalCharacterCount].materialReferenceIndex = this.m_CurrentMaterialIndex;
					this.m_TextElementType = TextElementType.Character;
					this.m_CurrentMaterialIndex = currentMaterialIndex;
					num++;
					this.m_TotalCharacterCount++;
					goto IL_C98;
				}
				bool flag35 = flag11 && this.m_CurrentFontAsset.instanceID != generationSettings.fontAsset.instanceID;
				if (flag35)
				{
					bool matchMaterialPreset = textSettings.matchMaterialPreset;
					if (matchMaterialPreset)
					{
						this.m_CurrentMaterial = MaterialManager.GetFallbackMaterial(this.m_CurrentMaterial, this.m_CurrentFontAsset.material);
					}
					else
					{
						this.m_CurrentMaterial = this.m_CurrentFontAsset.material;
					}
					this.m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(this.m_CurrentMaterial, this.m_CurrentFontAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
				}
				bool flag36 = textElement != null && textElement.glyph.atlasIndex > 0;
				if (flag36)
				{
					this.m_CurrentMaterial = MaterialManager.GetFallbackMaterial(this.m_CurrentFontAsset, this.m_CurrentMaterial, textElement.glyph.atlasIndex);
					this.m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(this.m_CurrentMaterial, this.m_CurrentFontAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
					flag11 = true;
				}
				bool flag37 = !char.IsWhiteSpace((char)num3) && num3 != 8203U;
				if (flag37)
				{
					bool flag38 = this.m_MaterialReferences[this.m_CurrentMaterialIndex].referenceCount < 16383;
					if (flag38)
					{
						MaterialReference[] materialReferences3 = this.m_MaterialReferences;
						int currentMaterialIndex4 = this.m_CurrentMaterialIndex;
						materialReferences3[currentMaterialIndex4].referenceCount = materialReferences3[currentMaterialIndex4].referenceCount + 1;
					}
					else
					{
						this.m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(new Material(this.m_CurrentMaterial), this.m_CurrentFontAsset, ref this.m_MaterialReferences, this.m_MaterialReferenceIndexLookup);
						MaterialReference[] materialReferences4 = this.m_MaterialReferences;
						int currentMaterialIndex5 = this.m_CurrentMaterialIndex;
						materialReferences4[currentMaterialIndex5].referenceCount = materialReferences4[currentMaterialIndex5].referenceCount + 1;
					}
				}
				textInfo.textElementInfo[this.m_TotalCharacterCount].material = this.m_CurrentMaterial;
				textInfo.textElementInfo[this.m_TotalCharacterCount].materialReferenceIndex = this.m_CurrentMaterialIndex;
				this.m_MaterialReferences[this.m_CurrentMaterialIndex].isFallbackMaterial = flag11;
				bool flag39 = flag11;
				if (flag39)
				{
					this.m_MaterialReferences[this.m_CurrentMaterialIndex].fallbackMaterial = currentMaterial;
					this.m_CurrentFontAsset = currentFontAsset;
					this.m_CurrentMaterial = currentMaterial;
					this.m_CurrentMaterialIndex = currentMaterialIndex;
				}
				this.m_TotalCharacterCount++;
				goto IL_C98;
			}
			bool isCalculatingPreferredValues = this.m_IsCalculatingPreferredValues;
			int totalCharacterCount;
			if (isCalculatingPreferredValues)
			{
				this.m_IsCalculatingPreferredValues = false;
				totalCharacterCount = this.m_TotalCharacterCount;
			}
			else
			{
				textInfo.spriteCount = num;
				int num8 = textInfo.materialCount = this.m_MaterialReferenceIndexLookup.Count;
				bool flag40 = num8 > textInfo.meshInfo.Length;
				if (flag40)
				{
					TextInfo.Resize<MeshInfo>(ref textInfo.meshInfo, num8, false);
				}
				bool flag41 = this.m_VertexBufferAutoSizeReduction && textInfo.textElementInfo.Length - this.m_TotalCharacterCount > 256;
				if (flag41)
				{
					TextInfo.Resize<TextElementInfo>(ref textInfo.textElementInfo, Mathf.Max(this.m_TotalCharacterCount + 1, 256), true);
				}
				for (int l = 0; l < num8; l++)
				{
					int referenceCount = this.m_MaterialReferences[l].referenceCount;
					bool flag42 = textInfo.meshInfo[l].vertices == null || textInfo.meshInfo[l].vertices.Length < referenceCount * 4;
					if (flag42)
					{
						bool flag43 = textInfo.meshInfo[l].vertices == null;
						if (flag43)
						{
							textInfo.meshInfo[l] = new MeshInfo(referenceCount + 1);
						}
						else
						{
							textInfo.meshInfo[l].ResizeMeshInfo((referenceCount > 1024) ? (referenceCount + 256) : Mathf.NextPowerOfTwo(referenceCount));
						}
					}
					else
					{
						bool flag44 = textInfo.meshInfo[l].vertices.Length - referenceCount * 4 > 1024;
						if (flag44)
						{
							textInfo.meshInfo[l].ResizeMeshInfo((referenceCount > 1024) ? (referenceCount + 256) : Mathf.Max(Mathf.NextPowerOfTwo(referenceCount), 256));
						}
					}
					textInfo.meshInfo[l].material = this.m_MaterialReferences[l].material;
					textInfo.meshInfo[l].glyphRenderMode = this.m_MaterialReferences[l].fontAsset.atlasRenderMode;
				}
				totalCharacterCount = this.m_TotalCharacterCount;
			}
			return totalCharacterCount;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00019794 File Offset: 0x00017994
		internal TextElement GetTextElement(TextGenerationSettings generationSettings, uint unicode, FontAsset fontAsset, FontStyles fontStyle, TextFontWeight fontWeight, out bool isUsingAlternativeTypeface)
		{
			TextSettings textSettings = generationSettings.textSettings;
			Character character = FontAssetUtilities.GetCharacterFromFontAsset(unicode, fontAsset, false, fontStyle, fontWeight, out isUsingAlternativeTypeface);
			bool flag = character != null;
			TextElement result;
			if (flag)
			{
				result = character;
			}
			else
			{
				bool flag2 = fontAsset.m_FallbackFontAssetTable != null && fontAsset.m_FallbackFontAssetTable.Count > 0;
				if (flag2)
				{
					character = FontAssetUtilities.GetCharacterFromFontAssets(unicode, fontAsset, fontAsset.m_FallbackFontAssetTable, true, fontStyle, fontWeight, out isUsingAlternativeTypeface);
				}
				bool flag3 = character != null;
				if (flag3)
				{
					fontAsset.AddCharacterToLookupCache(unicode, character);
					result = character;
				}
				else
				{
					bool flag4 = fontAsset.instanceID != generationSettings.fontAsset.instanceID;
					if (flag4)
					{
						character = FontAssetUtilities.GetCharacterFromFontAsset(unicode, generationSettings.fontAsset, false, fontStyle, fontWeight, out isUsingAlternativeTypeface);
						bool flag5 = character != null;
						if (flag5)
						{
							this.m_CurrentMaterialIndex = 0;
							this.m_CurrentMaterial = this.m_MaterialReferences[0].material;
							fontAsset.AddCharacterToLookupCache(unicode, character);
							return character;
						}
						bool flag6 = generationSettings.fontAsset.m_FallbackFontAssetTable != null && generationSettings.fontAsset.m_FallbackFontAssetTable.Count > 0;
						if (flag6)
						{
							character = FontAssetUtilities.GetCharacterFromFontAssets(unicode, fontAsset, generationSettings.fontAsset.m_FallbackFontAssetTable, true, fontStyle, fontWeight, out isUsingAlternativeTypeface);
						}
						bool flag7 = character != null;
						if (flag7)
						{
							fontAsset.AddCharacterToLookupCache(unicode, character);
							return character;
						}
					}
					bool flag8 = generationSettings.spriteAsset != null;
					if (flag8)
					{
						SpriteCharacter spriteCharacterFromSpriteAsset = FontAssetUtilities.GetSpriteCharacterFromSpriteAsset(unicode, generationSettings.spriteAsset, true);
						bool flag9 = spriteCharacterFromSpriteAsset != null;
						if (flag9)
						{
							return spriteCharacterFromSpriteAsset;
						}
					}
					bool flag10 = textSettings.fallbackFontAssets != null && textSettings.fallbackFontAssets.Count > 0;
					if (flag10)
					{
						character = FontAssetUtilities.GetCharacterFromFontAssets(unicode, fontAsset, textSettings.fallbackFontAssets, true, fontStyle, fontWeight, out isUsingAlternativeTypeface);
					}
					bool flag11 = character != null;
					if (flag11)
					{
						fontAsset.AddCharacterToLookupCache(unicode, character);
						result = character;
					}
					else
					{
						bool flag12 = textSettings.defaultFontAsset != null;
						if (flag12)
						{
							character = FontAssetUtilities.GetCharacterFromFontAsset(unicode, textSettings.defaultFontAsset, true, fontStyle, fontWeight, out isUsingAlternativeTypeface);
						}
						bool flag13 = character != null;
						if (flag13)
						{
							fontAsset.AddCharacterToLookupCache(unicode, character);
							result = character;
						}
						else
						{
							bool flag14 = textSettings.defaultSpriteAsset != null;
							if (flag14)
							{
								SpriteCharacter spriteCharacterFromSpriteAsset2 = FontAssetUtilities.GetSpriteCharacterFromSpriteAsset(unicode, textSettings.defaultSpriteAsset, true);
								bool flag15 = spriteCharacterFromSpriteAsset2 != null;
								if (flag15)
								{
									return spriteCharacterFromSpriteAsset2;
								}
							}
							result = null;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000199DC File Offset: 0x00017BDC
		private void ComputeMarginSize(Rect rect, Vector4 margins)
		{
			this.m_MarginWidth = rect.width - margins.x - margins.z;
			this.m_MarginHeight = rect.height - margins.y - margins.w;
			this.m_RectTransformCorners[0].x = 0f;
			this.m_RectTransformCorners[0].y = 0f;
			this.m_RectTransformCorners[1].x = 0f;
			this.m_RectTransformCorners[1].y = rect.height;
			this.m_RectTransformCorners[2].x = rect.width;
			this.m_RectTransformCorners[2].y = rect.height;
			this.m_RectTransformCorners[3].x = rect.width;
			this.m_RectTransformCorners[3].y = 0f;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00019AD8 File Offset: 0x00017CD8
		protected void GetSpecialCharacters(TextGenerationSettings generationSettings)
		{
			this.GetEllipsisSpecialCharacter(generationSettings);
			this.GetUnderlineSpecialCharacter(generationSettings);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00019AEC File Offset: 0x00017CEC
		protected void GetEllipsisSpecialCharacter(TextGenerationSettings generationSettings)
		{
			FontAsset fontAsset = this.m_CurrentFontAsset ?? generationSettings.fontAsset;
			TextSettings textSettings = generationSettings.textSettings;
			bool flag;
			Character character = FontAssetUtilities.GetCharacterFromFontAsset(8230U, fontAsset, false, this.m_FontStyleInternal, this.m_FontWeightInternal, out flag);
			bool flag2 = character == null;
			if (flag2)
			{
				bool flag3 = fontAsset.m_FallbackFontAssetTable != null && fontAsset.m_FallbackFontAssetTable.Count > 0;
				if (flag3)
				{
					character = FontAssetUtilities.GetCharacterFromFontAssets(8230U, fontAsset, fontAsset.m_FallbackFontAssetTable, true, this.m_FontStyleInternal, this.m_FontWeightInternal, out flag);
				}
			}
			bool flag4 = character == null;
			if (flag4)
			{
				bool flag5 = textSettings.fallbackFontAssets != null && textSettings.fallbackFontAssets.Count > 0;
				if (flag5)
				{
					character = FontAssetUtilities.GetCharacterFromFontAssets(8230U, fontAsset, textSettings.fallbackFontAssets, true, this.m_FontStyleInternal, this.m_FontWeightInternal, out flag);
				}
			}
			bool flag6 = character == null;
			if (flag6)
			{
				bool flag7 = textSettings.defaultFontAsset != null;
				if (flag7)
				{
					character = FontAssetUtilities.GetCharacterFromFontAsset(8230U, textSettings.defaultFontAsset, true, this.m_FontStyleInternal, this.m_FontWeightInternal, out flag);
				}
			}
			bool flag8 = character != null;
			if (flag8)
			{
				this.m_Ellipsis = new TextGenerator.SpecialCharacter(character, 0);
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00019C1C File Offset: 0x00017E1C
		protected void GetUnderlineSpecialCharacter(TextGenerationSettings generationSettings)
		{
			FontAsset sourceFontAsset = this.m_CurrentFontAsset ?? generationSettings.fontAsset;
			TextSettings textSettings = generationSettings.textSettings;
			bool flag;
			Character characterFromFontAsset = FontAssetUtilities.GetCharacterFromFontAsset(95U, sourceFontAsset, false, this.m_FontStyleInternal, this.m_FontWeightInternal, out flag);
			bool flag2 = characterFromFontAsset != null;
			if (flag2)
			{
				this.m_Underline = new TextGenerator.SpecialCharacter(characterFromFontAsset, this.m_CurrentMaterialIndex);
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00019C78 File Offset: 0x00017E78
		private float GetPreferredWidthInternal(TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			bool flag = generationSettings.textSettings == null;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num = generationSettings.autoSize ? generationSettings.fontSizeMax : this.m_FontSize;
				this.m_MinFontSize = generationSettings.fontSizeMin;
				this.m_MaxFontSize = generationSettings.fontSizeMax;
				this.m_CharWidthAdjDelta = 0f;
				Vector2 largePositiveVector = TextGeneratorUtilities.largePositiveVector2;
				TextWrappingMode textWrapMode = generationSettings.wordWrap ? TextWrappingMode.NoWrap : TextWrappingMode.PreserveWhitespaceNoWrap;
				this.m_AutoSizeIterationCount = 0;
				float x = this.CalculatePreferredValues(ref num, largePositiveVector, true, textWrapMode, generationSettings, textInfo).x;
				result = x;
			}
			return result;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00019D10 File Offset: 0x00017F10
		private float GetPreferredHeightInternal(TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			bool flag = generationSettings.textSettings == null;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num = generationSettings.autoSize ? generationSettings.fontSizeMax : this.m_FontSize;
				this.m_MinFontSize = generationSettings.fontSizeMin;
				this.m_MaxFontSize = generationSettings.fontSizeMax;
				this.m_CharWidthAdjDelta = 0f;
				Vector2 marginSize = new Vector2((this.m_MarginWidth != 0f) ? this.m_MarginWidth : 32767f, 32767f);
				this.m_IsAutoSizePointSizeSet = false;
				this.m_AutoSizeIterationCount = 0;
				float num2 = 0f;
				TextWrappingMode textWrapMode = generationSettings.wordWrap ? TextWrappingMode.Normal : TextWrappingMode.NoWrap;
				while (!this.m_IsAutoSizePointSizeSet)
				{
					num2 = this.CalculatePreferredValues(ref num, marginSize, generationSettings.autoSize, textWrapMode, generationSettings, textInfo).y;
					this.m_AutoSizeIterationCount++;
				}
				result = num2;
			}
			return result;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00019E00 File Offset: 0x00018000
		private Vector2 GetPreferredValuesInternal(TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			bool flag = generationSettings.textSettings == null;
			Vector2 result;
			if (flag)
			{
				result = Vector2.zero;
			}
			else
			{
				float num = generationSettings.autoSize ? generationSettings.fontSizeMax : this.m_FontSize;
				this.m_MinFontSize = generationSettings.fontSizeMin;
				this.m_MaxFontSize = generationSettings.fontSizeMax;
				this.m_CharWidthAdjDelta = 0f;
				Vector2 marginSize = new Vector2((this.m_MarginWidth != 0f) ? this.m_MarginWidth : 32767f, (this.m_MarginHeight != 0f) ? this.m_MarginHeight : 32767f);
				TextWrappingMode textWrapMode = generationSettings.wordWrap ? TextWrappingMode.Normal : TextWrappingMode.NoWrap;
				this.m_AutoSizeIterationCount = 0;
				result = this.CalculatePreferredValues(ref num, marginSize, generationSettings.autoSize, textWrapMode, generationSettings, textInfo);
			}
			return result;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00019ECC File Offset: 0x000180CC
		protected virtual Vector2 CalculatePreferredValues(ref float fontSize, Vector2 marginSize, bool isTextAutoSizingEnabled, TextWrappingMode textWrapMode, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			bool flag = generationSettings.fontAsset == null || generationSettings.fontAsset.characterLookupTable == null;
			Vector2 result;
			if (flag)
			{
				Debug.LogWarning("Can't Generate Mesh! No Font Asset has been assigned.");
				this.m_IsAutoSizePointSizeSet = true;
				result = Vector2.zero;
			}
			else
			{
				bool flag2 = this.m_TextProcessingArray == null || this.m_TextProcessingArray.Length == 0 || this.m_TextProcessingArray[0].unicode == 0U;
				if (flag2)
				{
					this.m_IsAutoSizePointSizeSet = true;
					result = Vector2.zero;
				}
				else
				{
					this.m_CurrentFontAsset = generationSettings.fontAsset;
					this.m_CurrentMaterial = generationSettings.material;
					this.m_CurrentMaterialIndex = 0;
					this.m_MaterialReferenceStack.SetDefault(new MaterialReference(0, this.m_CurrentFontAsset, null, this.m_CurrentMaterial, this.m_Padding));
					int totalCharacterCount = this.m_TotalCharacterCount;
					bool flag3 = this.m_InternalTextElementInfo == null || totalCharacterCount > this.m_InternalTextElementInfo.Length;
					if (flag3)
					{
						this.m_InternalTextElementInfo = new TextElementInfo[(totalCharacterCount > 1024) ? (totalCharacterCount + 256) : Mathf.NextPowerOfTwo(totalCharacterCount)];
					}
					float num = fontSize / (float)generationSettings.fontAsset.faceInfo.pointSize * generationSettings.fontAsset.faceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
					float num2 = num;
					float num3 = fontSize * 0.01f * (generationSettings.isOrthographic ? 1f : 0.1f);
					this.m_FontScaleMultiplier = 1f;
					this.m_CurrentFontSize = fontSize;
					this.m_SizeStack.SetDefault(this.m_CurrentFontSize);
					this.m_FontStyleInternal = generationSettings.fontStyle;
					this.m_LineJustification = generationSettings.textAlignment;
					this.m_LineJustificationStack.SetDefault(this.m_LineJustification);
					this.m_BaselineOffset = 0f;
					this.m_BaselineOffsetStack.Clear();
					this.m_FXScale = Vector3.one;
					this.m_LineOffset = 0f;
					this.m_LineHeight = -32767f;
					float num4 = this.m_CurrentFontAsset.faceInfo.lineHeight - (this.m_CurrentFontAsset.faceInfo.ascentLine - this.m_CurrentFontAsset.faceInfo.descentLine);
					this.m_CSpacing = 0f;
					this.m_MonoSpacing = 0f;
					this.m_XAdvance = 0f;
					this.m_TagLineIndent = 0f;
					this.m_TagIndent = 0f;
					this.m_IndentStack.SetDefault(0f);
					this.m_TagNoParsing = false;
					this.m_CharacterCount = 0;
					this.m_FirstCharacterOfLine = 0;
					this.m_MaxLineAscender = -32767f;
					this.m_MaxLineDescender = 32767f;
					this.m_LineNumber = 0;
					this.m_StartOfLineAscender = 0f;
					this.m_IsDrivenLineSpacing = false;
					this.m_LastBaseGlyphIndex = int.MinValue;
					TextSettings textSettings = generationSettings.textSettings;
					float x = marginSize.x;
					float y = marginSize.y;
					this.m_MarginLeft = 0f;
					this.m_MarginRight = 0f;
					this.m_Width = -1f;
					float num5 = x + 0.0001f - this.m_MarginLeft - this.m_MarginRight;
					float num6 = 0f;
					float num7 = 0f;
					this.m_IsCalculatingPreferredValues = true;
					this.m_MaxCapHeight = 0f;
					this.m_MaxAscender = 0f;
					this.m_MaxDescender = 0f;
					bool flag4 = false;
					bool flag5 = true;
					this.m_IsNonBreakingSpace = false;
					bool flag6 = false;
					CharacterSubstitution characterSubstitution = new CharacterSubstitution(-1, 0U);
					bool flag7 = false;
					WordWrapState wordWrapState = default(WordWrapState);
					WordWrapState wordWrapState2 = default(WordWrapState);
					WordWrapState wordWrapState3 = default(WordWrapState);
					TextGenerator.m_IsTextTruncated = false;
					this.m_AutoSizeIterationCount++;
					int num8 = 0;
					while (num8 < this.m_TextProcessingArray.Length && this.m_TextProcessingArray[num8].unicode > 0U)
					{
						uint num9 = this.m_TextProcessingArray[num8].unicode;
						bool flag8 = num9 == 26U;
						if (!flag8)
						{
							bool flag9 = generationSettings.richText && num9 == 60U;
							if (flag9)
							{
								this.m_isTextLayoutPhase = true;
								this.m_TextElementType = TextElementType.Character;
								int num10;
								bool flag10 = this.ValidateHtmlTag(this.m_TextProcessingArray, num8 + 1, out num10, generationSettings, textInfo);
								if (flag10)
								{
									num8 = num10;
									bool flag11 = this.m_TextElementType == TextElementType.Character;
									if (flag11)
									{
										goto IL_20EB;
									}
								}
							}
							else
							{
								this.m_TextElementType = textInfo.textElementInfo[this.m_CharacterCount].elementType;
								this.m_CurrentMaterialIndex = textInfo.textElementInfo[this.m_CharacterCount].materialReferenceIndex;
								this.m_CurrentFontAsset = textInfo.textElementInfo[this.m_CharacterCount].fontAsset;
							}
							int currentMaterialIndex = this.m_CurrentMaterialIndex;
							bool isUsingAlternateTypeface = textInfo.textElementInfo[this.m_CharacterCount].isUsingAlternateTypeface;
							this.m_isTextLayoutPhase = false;
							bool flag12 = false;
							bool flag13 = characterSubstitution.index == this.m_CharacterCount;
							if (flag13)
							{
								num9 = characterSubstitution.unicode;
								this.m_TextElementType = TextElementType.Character;
								flag12 = true;
								uint num11 = num9;
								uint num12 = num11;
								if (num12 != 3U)
								{
									if (num12 != 45U)
									{
										if (num12 == 8230U)
										{
											this.m_InternalTextElementInfo[this.m_CharacterCount].textElement = this.m_Ellipsis.character;
											this.m_InternalTextElementInfo[this.m_CharacterCount].elementType = TextElementType.Character;
											this.m_InternalTextElementInfo[this.m_CharacterCount].fontAsset = this.m_Ellipsis.fontAsset;
											this.m_InternalTextElementInfo[this.m_CharacterCount].material = this.m_Ellipsis.material;
											this.m_InternalTextElementInfo[this.m_CharacterCount].materialReferenceIndex = this.m_Ellipsis.materialIndex;
											TextGenerator.m_IsTextTruncated = true;
											characterSubstitution.index = this.m_CharacterCount + 1;
											characterSubstitution.unicode = 3U;
										}
									}
								}
								else
								{
									this.m_InternalTextElementInfo[this.m_CharacterCount].textElement = this.m_CurrentFontAsset.characterLookupTable[3U];
									TextGenerator.m_IsTextTruncated = true;
								}
							}
							bool flag14 = this.m_CharacterCount < generationSettings.firstVisibleCharacter && num9 != 3U;
							if (flag14)
							{
								this.m_InternalTextElementInfo[this.m_CharacterCount].isVisible = false;
								this.m_InternalTextElementInfo[this.m_CharacterCount].character = '​';
								this.m_InternalTextElementInfo[this.m_CharacterCount].lineNumber = 0;
								this.m_CharacterCount++;
							}
							else
							{
								float num13 = 1f;
								bool flag15 = this.m_TextElementType == TextElementType.Character;
								if (flag15)
								{
									bool flag16 = (this.m_FontStyleInternal & FontStyles.UpperCase) == FontStyles.UpperCase;
									if (flag16)
									{
										bool flag17 = char.IsLower((char)num9);
										if (flag17)
										{
											num9 = (uint)char.ToUpper((char)num9);
										}
									}
									else
									{
										bool flag18 = (this.m_FontStyleInternal & FontStyles.LowerCase) == FontStyles.LowerCase;
										if (flag18)
										{
											bool flag19 = char.IsUpper((char)num9);
											if (flag19)
											{
												num9 = (uint)char.ToLower((char)num9);
											}
										}
										else
										{
											bool flag20 = (this.m_FontStyleInternal & FontStyles.SmallCaps) == FontStyles.SmallCaps;
											if (flag20)
											{
												bool flag21 = char.IsLower((char)num9);
												if (flag21)
												{
													num13 = 0.8f;
													num9 = (uint)char.ToUpper((char)num9);
												}
											}
										}
									}
								}
								float num14 = 0f;
								float num15 = 0f;
								float num16 = 0f;
								bool flag22 = this.m_TextElementType == TextElementType.Sprite;
								if (flag22)
								{
									SpriteCharacter spriteCharacter = (SpriteCharacter)textInfo.textElementInfo[this.m_CharacterCount].textElement;
									this.m_CurrentSpriteAsset = (spriteCharacter.textAsset as SpriteAsset);
									this.m_SpriteIndex = (int)spriteCharacter.glyphIndex;
									bool flag23 = spriteCharacter == null;
									if (flag23)
									{
										goto IL_20EB;
									}
									bool flag24 = num9 == 60U;
									if (flag24)
									{
										num9 = (uint)(57344 + this.m_SpriteIndex);
									}
									bool flag25 = this.m_CurrentSpriteAsset.faceInfo.pointSize > 0;
									if (flag25)
									{
										float num17 = this.m_CurrentFontSize / (float)this.m_CurrentSpriteAsset.faceInfo.pointSize * this.m_CurrentSpriteAsset.faceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
										num2 = spriteCharacter.scale * spriteCharacter.glyph.scale * num17;
										num15 = this.m_CurrentSpriteAsset.faceInfo.ascentLine;
										num16 = this.m_CurrentSpriteAsset.faceInfo.descentLine;
									}
									else
									{
										float num18 = this.m_CurrentFontSize / (float)this.m_CurrentFontAsset.faceInfo.pointSize * this.m_CurrentFontAsset.faceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
										num2 = this.m_CurrentFontAsset.faceInfo.ascentLine / spriteCharacter.glyph.metrics.height * spriteCharacter.scale * spriteCharacter.glyph.scale * num18;
										float num19 = num18 / num2;
										num15 = this.m_CurrentFontAsset.faceInfo.ascentLine * num19;
										num16 = this.m_CurrentFontAsset.faceInfo.descentLine * num19;
									}
									this.m_CachedTextElement = spriteCharacter;
									this.m_InternalTextElementInfo[this.m_CharacterCount].elementType = TextElementType.Sprite;
									this.m_InternalTextElementInfo[this.m_CharacterCount].scale = num2;
									this.m_CurrentMaterialIndex = currentMaterialIndex;
								}
								else
								{
									bool flag26 = this.m_TextElementType == TextElementType.Character;
									if (flag26)
									{
										this.m_CachedTextElement = textInfo.textElementInfo[this.m_CharacterCount].textElement;
										bool flag27 = this.m_CachedTextElement == null;
										if (flag27)
										{
											goto IL_20EB;
										}
										this.m_CurrentFontAsset = textInfo.textElementInfo[this.m_CharacterCount].fontAsset;
										this.m_CurrentMaterial = textInfo.textElementInfo[this.m_CharacterCount].material;
										this.m_CurrentMaterialIndex = textInfo.textElementInfo[this.m_CharacterCount].materialReferenceIndex;
										bool flag28 = flag12 && this.m_TextProcessingArray[num8].unicode == 10U && this.m_CharacterCount != this.m_FirstCharacterOfLine;
										float num20;
										if (flag28)
										{
											num20 = textInfo.textElementInfo[this.m_CharacterCount - 1].pointSize * num13 / (float)this.m_CurrentFontAsset.m_FaceInfo.pointSize * this.m_CurrentFontAsset.m_FaceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
										}
										else
										{
											num20 = this.m_CurrentFontSize * num13 / (float)this.m_CurrentFontAsset.m_FaceInfo.pointSize * this.m_CurrentFontAsset.m_FaceInfo.scale * (generationSettings.isOrthographic ? 1f : 0.1f);
										}
										bool flag29 = flag12 && num9 == 8230U;
										if (flag29)
										{
											num15 = 0f;
											num16 = 0f;
										}
										else
										{
											num15 = this.m_CurrentFontAsset.m_FaceInfo.ascentLine;
											num16 = this.m_CurrentFontAsset.m_FaceInfo.descentLine;
										}
										num2 = num20 * this.m_FontScaleMultiplier * this.m_CachedTextElement.scale;
										this.m_InternalTextElementInfo[this.m_CharacterCount].elementType = TextElementType.Character;
									}
								}
								float num21 = num2;
								bool flag30 = num9 == 173U || num9 == 3U;
								if (flag30)
								{
									num2 = 0f;
								}
								this.m_InternalTextElementInfo[this.m_CharacterCount].character = (char)num9;
								Glyph alternativeGlyph = textInfo.textElementInfo[this.m_CharacterCount].alternativeGlyph;
								GlyphMetrics glyphMetrics = (alternativeGlyph == null) ? this.m_CachedTextElement.m_Glyph.metrics : alternativeGlyph.metrics;
								bool flag31 = num9 <= 65535U && char.IsWhiteSpace((char)num9);
								GlyphValueRecord a = default(GlyphValueRecord);
								float num22 = generationSettings.characterSpacing;
								bool enableKerning = generationSettings.enableKerning;
								if (enableKerning)
								{
									uint glyphIndex = this.m_CachedTextElement.m_GlyphIndex;
									bool flag32 = this.m_CharacterCount < totalCharacterCount - 1;
									if (flag32)
									{
										uint glyphIndex2 = textInfo.textElementInfo[this.m_CharacterCount + 1].textElement.m_GlyphIndex;
										uint key = glyphIndex2 << 16 | glyphIndex;
										GlyphPairAdjustmentRecord glyphPairAdjustmentRecord;
										bool flag33 = this.m_CurrentFontAsset.m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup.TryGetValue(key, out glyphPairAdjustmentRecord);
										if (flag33)
										{
											a = glyphPairAdjustmentRecord.firstAdjustmentRecord.glyphValueRecord;
											num22 = (((glyphPairAdjustmentRecord.featureLookupFlags & FontFeatureLookupFlags.IgnoreSpacingAdjustments) == FontFeatureLookupFlags.IgnoreSpacingAdjustments) ? 0f : num22);
										}
									}
									bool flag34 = this.m_CharacterCount >= 1;
									if (flag34)
									{
										uint glyphIndex3 = textInfo.textElementInfo[this.m_CharacterCount - 1].textElement.m_GlyphIndex;
										uint key2 = glyphIndex << 16 | glyphIndex3;
										GlyphPairAdjustmentRecord glyphPairAdjustmentRecord;
										bool flag35 = this.m_CurrentFontAsset.m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup.TryGetValue(key2, out glyphPairAdjustmentRecord);
										if (flag35)
										{
											a += glyphPairAdjustmentRecord.secondAdjustmentRecord.glyphValueRecord;
											num22 = (((glyphPairAdjustmentRecord.featureLookupFlags & FontFeatureLookupFlags.IgnoreSpacingAdjustments) == FontFeatureLookupFlags.IgnoreSpacingAdjustments) ? 0f : num22);
										}
									}
									this.m_InternalTextElementInfo[this.m_CharacterCount].adjustedHorizontalAdvance = a.xAdvance;
								}
								bool flag36 = TextGeneratorUtilities.IsBaseGlyph(num9);
								bool flag37 = flag36;
								if (flag37)
								{
									this.m_LastBaseGlyphIndex = this.m_CharacterCount;
								}
								bool flag38 = this.m_CharacterCount > 0 && !flag36;
								if (flag38)
								{
									bool flag39 = this.m_LastBaseGlyphIndex != int.MinValue && this.m_LastBaseGlyphIndex == this.m_CharacterCount - 1;
									if (flag39)
									{
										Glyph glyph = textInfo.textElementInfo[this.m_LastBaseGlyphIndex].textElement.glyph;
										uint index = glyph.index;
										uint glyphIndex4 = this.m_CachedTextElement.glyphIndex;
										uint key3 = glyphIndex4 << 16 | index;
										MarkToBaseAdjustmentRecord markToBaseAdjustmentRecord;
										bool flag40 = this.m_CurrentFontAsset.fontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.TryGetValue(key3, out markToBaseAdjustmentRecord);
										if (flag40)
										{
											float num23 = (this.m_InternalTextElementInfo[this.m_LastBaseGlyphIndex].origin - this.m_XAdvance) / num2;
											a.xPlacement = num23 + markToBaseAdjustmentRecord.baseGlyphAnchorPoint.xCoordinate - markToBaseAdjustmentRecord.markPositionAdjustment.xPositionAdjustment;
											a.yPlacement = markToBaseAdjustmentRecord.baseGlyphAnchorPoint.yCoordinate - markToBaseAdjustmentRecord.markPositionAdjustment.yPositionAdjustment;
											num22 = 0f;
										}
									}
									else
									{
										bool flag41 = false;
										int num24 = this.m_CharacterCount - 1;
										while (num24 >= 0 && num24 != this.m_LastBaseGlyphIndex)
										{
											Glyph glyph2 = textInfo.textElementInfo[num24].textElement.glyph;
											uint index2 = glyph2.index;
											uint glyphIndex5 = this.m_CachedTextElement.glyphIndex;
											uint key4 = glyphIndex5 << 16 | index2;
											MarkToMarkAdjustmentRecord markToMarkAdjustmentRecord;
											bool flag42 = this.m_CurrentFontAsset.fontFeatureTable.m_MarkToMarkAdjustmentRecordLookup.TryGetValue(key4, out markToMarkAdjustmentRecord);
											if (flag42)
											{
												float num25 = (textInfo.textElementInfo[num24].origin - this.m_XAdvance) / num2;
												float num26 = num14 - this.m_LineOffset + this.m_BaselineOffset;
												float num27 = (this.m_InternalTextElementInfo[num24].baseLine - num26) / num2;
												a.xPlacement = num25 + markToMarkAdjustmentRecord.baseMarkGlyphAnchorPoint.xCoordinate - markToMarkAdjustmentRecord.combiningMarkPositionAdjustment.xPositionAdjustment;
												a.yPlacement = num27 + markToMarkAdjustmentRecord.baseMarkGlyphAnchorPoint.yCoordinate - markToMarkAdjustmentRecord.combiningMarkPositionAdjustment.yPositionAdjustment;
												num22 = 0f;
												flag41 = true;
												break;
											}
											num24--;
										}
										bool flag43 = this.m_LastBaseGlyphIndex != int.MinValue && !flag41;
										if (flag43)
										{
											Glyph glyph3 = textInfo.textElementInfo[this.m_LastBaseGlyphIndex].textElement.glyph;
											uint index3 = glyph3.index;
											uint glyphIndex6 = this.m_CachedTextElement.glyphIndex;
											uint key5 = glyphIndex6 << 16 | index3;
											MarkToBaseAdjustmentRecord markToBaseAdjustmentRecord2;
											bool flag44 = this.m_CurrentFontAsset.fontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.TryGetValue(key5, out markToBaseAdjustmentRecord2);
											if (flag44)
											{
												float num28 = (this.m_InternalTextElementInfo[this.m_LastBaseGlyphIndex].origin - this.m_XAdvance) / num2;
												a.xPlacement = num28 + markToBaseAdjustmentRecord2.baseGlyphAnchorPoint.xCoordinate - markToBaseAdjustmentRecord2.markPositionAdjustment.xPositionAdjustment;
												a.yPlacement = markToBaseAdjustmentRecord2.baseGlyphAnchorPoint.yCoordinate - markToBaseAdjustmentRecord2.markPositionAdjustment.yPositionAdjustment;
												num22 = 0f;
											}
										}
									}
								}
								num15 += a.yPlacement;
								num16 += a.yPlacement;
								float num29 = 0f;
								bool flag45 = this.m_MonoSpacing != 0f;
								if (flag45)
								{
									num29 = (this.m_MonoSpacing / 2f - (this.m_CachedTextElement.glyph.metrics.width / 2f + this.m_CachedTextElement.glyph.metrics.horizontalBearingX) * num2) * (1f - this.m_CharWidthAdjDelta);
									this.m_XAdvance += num29;
								}
								float num30 = 0f;
								bool flag46 = this.m_TextElementType == TextElementType.Character && !isUsingAlternateTypeface && (this.m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold;
								if (flag46)
								{
									num30 = this.m_CurrentFontAsset.boldStyleSpacing;
								}
								this.m_InternalTextElementInfo[this.m_CharacterCount].origin = this.m_XAdvance + a.xPlacement * num2;
								this.m_InternalTextElementInfo[this.m_CharacterCount].baseLine = num14 - this.m_LineOffset + this.m_BaselineOffset + a.yPlacement * num2;
								float num31 = (this.m_TextElementType == TextElementType.Character) ? (num15 * num2 / num13 + this.m_BaselineOffset) : (num15 * num2 + this.m_BaselineOffset);
								float num32 = (this.m_TextElementType == TextElementType.Character) ? (num16 * num2 / num13 + this.m_BaselineOffset) : (num16 * num2 + this.m_BaselineOffset);
								float num33 = num31;
								float num34 = num32;
								bool flag47 = this.m_CharacterCount == this.m_FirstCharacterOfLine;
								bool flag48 = flag47 || !flag31;
								if (flag48)
								{
									bool flag49 = this.m_BaselineOffset != 0f;
									if (flag49)
									{
										num33 = Mathf.Max((num31 - this.m_BaselineOffset) / this.m_FontScaleMultiplier, num33);
										num34 = Mathf.Min((num32 - this.m_BaselineOffset) / this.m_FontScaleMultiplier, num34);
									}
									this.m_MaxLineAscender = Mathf.Max(num33, this.m_MaxLineAscender);
									this.m_MaxLineDescender = Mathf.Min(num34, this.m_MaxLineDescender);
								}
								bool flag50 = flag47 || !flag31;
								if (flag50)
								{
									this.m_InternalTextElementInfo[this.m_CharacterCount].adjustedAscender = num33;
									this.m_InternalTextElementInfo[this.m_CharacterCount].adjustedDescender = num34;
									this.m_InternalTextElementInfo[this.m_CharacterCount].ascender = num31 - this.m_LineOffset;
									this.m_MaxDescender = (this.m_InternalTextElementInfo[this.m_CharacterCount].descender = num32 - this.m_LineOffset);
								}
								else
								{
									this.m_InternalTextElementInfo[this.m_CharacterCount].adjustedAscender = this.m_MaxLineAscender;
									this.m_InternalTextElementInfo[this.m_CharacterCount].adjustedDescender = this.m_MaxLineDescender;
									this.m_InternalTextElementInfo[this.m_CharacterCount].ascender = this.m_MaxLineAscender - this.m_LineOffset;
									this.m_MaxDescender = (this.m_InternalTextElementInfo[this.m_CharacterCount].descender = this.m_MaxLineDescender - this.m_LineOffset);
								}
								bool flag51 = this.m_LineNumber == 0 || this.m_IsNewPage;
								if (flag51)
								{
									bool flag52 = flag47 || !flag31;
									if (flag52)
									{
										this.m_MaxAscender = this.m_MaxLineAscender;
										this.m_MaxCapHeight = Mathf.Max(this.m_MaxCapHeight, this.m_CurrentFontAsset.m_FaceInfo.capLine * num2 / num13);
									}
								}
								bool flag53 = this.m_LineOffset == 0f;
								if (flag53)
								{
									bool flag54 = !flag31 || this.m_CharacterCount == this.m_FirstCharacterOfLine;
									if (flag54)
									{
										this.m_PageAscender = ((this.m_PageAscender > num31) ? this.m_PageAscender : num31);
									}
								}
								bool flag55 = (this.m_LineJustification & (TextAlignment)16) == (TextAlignment)16 || (this.m_LineJustification & (TextAlignment)8) == (TextAlignment)8;
								bool flag56 = num9 == 9U || num9 == 8203U || ((textWrapMode == TextWrappingMode.PreserveWhitespace || textWrapMode == TextWrappingMode.PreserveWhitespaceNoWrap) && (flag31 || num9 == 8203U)) || (!flag31 && num9 != 8203U && num9 != 173U && num9 != 3U) || (num9 == 173U && !flag7) || this.m_TextElementType == TextElementType.Sprite;
								if (flag56)
								{
									num5 = ((this.m_Width != -1f) ? Mathf.Min(x + 0.0001f - this.m_MarginLeft - this.m_MarginRight, this.m_Width) : (x + 0.0001f - this.m_MarginLeft - this.m_MarginRight));
									float num35 = Mathf.Abs(this.m_XAdvance) + glyphMetrics.horizontalAdvance * (1f - this.m_CharWidthAdjDelta) * ((num9 == 173U) ? num21 : num2);
									int characterCount = this.m_CharacterCount;
									bool flag57 = flag36 && num35 > num5 * (flag55 ? 1.05f : 1f);
									if (flag57)
									{
										bool flag58 = textWrapMode != TextWrappingMode.NoWrap && textWrapMode != TextWrappingMode.PreserveWhitespaceNoWrap && this.m_CharacterCount != this.m_FirstCharacterOfLine;
										if (flag58)
										{
											num8 = this.RestoreWordWrappingState(ref wordWrapState, textInfo);
											bool flag59 = this.m_InternalTextElementInfo[this.m_CharacterCount - 1].character == '­' && !flag7 && generationSettings.overflowMode == TextOverflowMode.Overflow;
											if (flag59)
											{
												characterSubstitution.index = this.m_CharacterCount - 1;
												characterSubstitution.unicode = 45U;
												num8--;
												this.m_CharacterCount--;
												goto IL_20EB;
											}
											flag7 = false;
											bool flag60 = this.m_InternalTextElementInfo[this.m_CharacterCount].character == '­';
											if (flag60)
											{
												flag7 = true;
												goto IL_20EB;
											}
											bool flag61 = isTextAutoSizingEnabled && flag5;
											if (flag61)
											{
												bool flag62 = this.m_CharWidthAdjDelta < generationSettings.charWidthMaxAdj / 100f && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
												if (flag62)
												{
													float num36 = num35;
													bool flag63 = this.m_CharWidthAdjDelta > 0f;
													if (flag63)
													{
														num36 /= 1f - this.m_CharWidthAdjDelta;
													}
													float num37 = num35 - (num5 - 0.0001f) * (flag55 ? 1.05f : 1f);
													this.m_CharWidthAdjDelta += num37 / num36;
													this.m_CharWidthAdjDelta = Mathf.Min(this.m_CharWidthAdjDelta, generationSettings.charWidthMaxAdj / 100f);
													return Vector2.zero;
												}
												bool flag64 = fontSize > generationSettings.fontSizeMin && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
												if (flag64)
												{
													this.m_MaxFontSize = fontSize;
													float num38 = Mathf.Max((fontSize - this.m_MinFontSize) / 2f, 0.05f);
													fontSize -= num38;
													fontSize = Mathf.Max((float)((int)(fontSize * 20f + 0.5f)) / 20f, generationSettings.fontSizeMin);
												}
											}
											float num39 = this.m_MaxLineAscender - this.m_StartOfLineAscender;
											bool flag65 = this.m_LineOffset > 0f && Math.Abs(num39) > 0.01f && !this.m_IsDrivenLineSpacing && !this.m_IsNewPage;
											if (flag65)
											{
												this.m_MaxDescender -= num39;
												this.m_LineOffset += num39;
											}
											float num40 = this.m_MaxLineAscender - this.m_LineOffset;
											float num41 = this.m_MaxLineDescender - this.m_LineOffset;
											this.m_MaxDescender = ((this.m_MaxDescender < num41) ? this.m_MaxDescender : num41);
											bool flag66 = !flag4;
											if (flag66)
											{
												float maxDescender = this.m_MaxDescender;
											}
											bool flag67 = generationSettings.useMaxVisibleDescender && (this.m_CharacterCount >= generationSettings.maxVisibleCharacters || this.m_LineNumber >= generationSettings.maxVisibleLines);
											if (flag67)
											{
												flag4 = true;
											}
											this.m_FirstCharacterOfLine = this.m_CharacterCount;
											this.m_LineVisibleCharacterCount = 0;
											this.SaveWordWrappingState(ref wordWrapState2, num8, this.m_CharacterCount - 1, textInfo);
											this.m_LineNumber++;
											float adjustedAscender = this.m_InternalTextElementInfo[this.m_CharacterCount].adjustedAscender;
											bool flag68 = this.m_LineHeight == -32767f;
											if (flag68)
											{
												this.m_LineOffset += 0f - this.m_MaxLineDescender + adjustedAscender + (num4 + this.m_LineSpacingDelta) * num + generationSettings.lineSpacing * num3;
												this.m_IsDrivenLineSpacing = false;
											}
											else
											{
												this.m_LineOffset += this.m_LineHeight + generationSettings.lineSpacing * num3;
												this.m_IsDrivenLineSpacing = true;
											}
											this.m_MaxLineAscender = -32767f;
											this.m_MaxLineDescender = 32767f;
											this.m_StartOfLineAscender = adjustedAscender;
											this.m_XAdvance = 0f + this.m_TagIndent;
											flag5 = true;
											goto IL_20EB;
										}
									}
									num6 = Mathf.Max(num6, num35 + this.m_MarginLeft + this.m_MarginRight);
									num7 = Mathf.Max(num7, this.m_MaxAscender - this.m_MaxDescender);
								}
								bool flag69 = this.m_LineOffset > 0f && !TextGeneratorUtilities.Approximately(this.m_MaxLineAscender, this.m_StartOfLineAscender) && !this.m_IsDrivenLineSpacing && !this.m_IsNewPage;
								if (flag69)
								{
									float num42 = this.m_MaxLineAscender - this.m_StartOfLineAscender;
									this.m_MaxDescender -= num42;
									this.m_LineOffset += num42;
									this.m_StartOfLineAscender += num42;
									wordWrapState.lineOffset = this.m_LineOffset;
									wordWrapState.startOfLineAscender = this.m_StartOfLineAscender;
								}
								bool flag70 = num9 != 8203U;
								if (flag70)
								{
									bool flag71 = num9 == 9U;
									if (flag71)
									{
										float num43 = this.m_CurrentFontAsset.faceInfo.tabWidth * (float)this.m_CurrentFontAsset.tabMultiple * num2;
										float num44 = Mathf.Ceil(this.m_XAdvance / num43) * num43;
										this.m_XAdvance = ((num44 > this.m_XAdvance) ? num44 : (this.m_XAdvance + num43));
									}
									else
									{
										bool flag72 = this.m_MonoSpacing != 0f;
										if (flag72)
										{
											this.m_XAdvance += (this.m_MonoSpacing - num29 + (this.m_CurrentFontAsset.regularStyleSpacing + num22) * num3 + this.m_CSpacing) * (1f - this.m_CharWidthAdjDelta);
											bool flag73 = flag31 || num9 == 8203U;
											if (flag73)
											{
												this.m_XAdvance += generationSettings.wordSpacing * num3;
											}
										}
										else
										{
											this.m_XAdvance += ((glyphMetrics.horizontalAdvance * this.m_FXScale.x + a.xAdvance) * num2 + (this.m_CurrentFontAsset.regularStyleSpacing + num22 + num30) * num3 + this.m_CSpacing) * (1f - this.m_CharWidthAdjDelta);
											bool flag74 = flag31 || num9 == 8203U;
											if (flag74)
											{
												this.m_XAdvance += generationSettings.wordSpacing * num3;
											}
										}
									}
								}
								bool flag75 = num9 == 13U;
								if (flag75)
								{
									this.m_XAdvance = 0f + this.m_TagIndent;
								}
								bool flag76 = num9 == 10U || num9 == 11U || num9 == 3U || num9 == 8232U || num9 == 8233U || this.m_CharacterCount == totalCharacterCount - 1;
								if (flag76)
								{
									float num45 = this.m_MaxLineAscender - this.m_StartOfLineAscender;
									bool flag77 = this.m_LineOffset > 0f && Math.Abs(num45) > 0.01f && !this.m_IsDrivenLineSpacing && !this.m_IsNewPage;
									if (flag77)
									{
										this.m_MaxDescender -= num45;
										this.m_LineOffset += num45;
									}
									this.m_IsNewPage = false;
									float num46 = this.m_MaxLineDescender - this.m_LineOffset;
									this.m_MaxDescender = ((this.m_MaxDescender < num46) ? this.m_MaxDescender : num46);
									bool flag78 = num9 == 10U || num9 == 11U || num9 == 45U || num9 == 8232U || num9 == 8233U;
									if (flag78)
									{
										this.SaveWordWrappingState(ref wordWrapState2, num8, this.m_CharacterCount, textInfo);
										this.SaveWordWrappingState(ref wordWrapState, num8, this.m_CharacterCount, textInfo);
										this.m_LineNumber++;
										this.m_FirstCharacterOfLine = this.m_CharacterCount + 1;
										float adjustedAscender2 = this.m_InternalTextElementInfo[this.m_CharacterCount].adjustedAscender;
										bool flag79 = this.m_LineHeight == -32767f;
										if (flag79)
										{
											float num47 = 0f - this.m_MaxLineDescender + adjustedAscender2 + (num4 + this.m_LineSpacingDelta) * num + (generationSettings.lineSpacing + ((num9 == 10U || num9 == 8233U) ? generationSettings.paragraphSpacing : 0f)) * num3;
											this.m_LineOffset += num47;
											this.m_IsDrivenLineSpacing = false;
										}
										else
										{
											this.m_LineOffset += this.m_LineHeight + (generationSettings.lineSpacing + ((num9 == 10U || num9 == 8233U) ? generationSettings.paragraphSpacing : 0f)) * num3;
											this.m_IsDrivenLineSpacing = true;
										}
										this.m_MaxLineAscender = -32767f;
										this.m_MaxLineDescender = 32767f;
										this.m_StartOfLineAscender = adjustedAscender2;
										this.m_XAdvance = 0f + this.m_TagLineIndent + this.m_TagIndent;
										this.m_CharacterCount++;
										goto IL_20EB;
									}
									bool flag80 = num9 == 3U;
									if (flag80)
									{
										num8 = this.m_TextProcessingArray.Length;
									}
								}
								bool flag81 = (textWrapMode != TextWrappingMode.NoWrap && textWrapMode != TextWrappingMode.PreserveWhitespaceNoWrap) || generationSettings.overflowMode == TextOverflowMode.Truncate || generationSettings.overflowMode == TextOverflowMode.Ellipsis;
								if (flag81)
								{
									bool flag82 = false;
									bool flag83 = false;
									bool flag84 = (flag31 || num9 == 8203U || num9 == 45U || num9 == 173U) && (!this.m_IsNonBreakingSpace || flag6) && num9 != 160U && num9 != 8199U && num9 != 8209U && num9 != 8239U && num9 != 8288U;
									if (flag84)
									{
										bool flag85 = num9 != 45U || this.m_CharacterCount <= 0 || !char.IsWhiteSpace(textInfo.textElementInfo[this.m_CharacterCount - 1].character);
										if (flag85)
										{
											flag5 = false;
											flag82 = true;
											wordWrapState3.previousWordBreak = -1;
										}
									}
									else
									{
										bool flag86 = !this.m_IsNonBreakingSpace && ((TextGeneratorUtilities.IsHangul(num9) && !textSettings.useModernHangulLineBreakingRules) || TextGeneratorUtilities.IsCJK(num9));
										if (flag86)
										{
											bool flag87 = textSettings.lineBreakingRules.leadingCharactersLookup.Contains(num9);
											bool flag88 = this.m_CharacterCount < totalCharacterCount - 1 && textSettings.lineBreakingRules.leadingCharactersLookup.Contains((uint)this.m_InternalTextElementInfo[this.m_CharacterCount + 1].character);
											bool flag89 = !flag87;
											if (flag89)
											{
												bool flag90 = !flag88;
												if (flag90)
												{
													flag5 = false;
													flag82 = true;
												}
												bool flag91 = flag5;
												if (flag91)
												{
													bool flag92 = flag31;
													if (flag92)
													{
														flag83 = true;
													}
													flag82 = true;
												}
											}
											else
											{
												bool flag93 = flag5 && flag47;
												if (flag93)
												{
													bool flag94 = flag31;
													if (flag94)
													{
														flag83 = true;
													}
													flag82 = true;
												}
											}
										}
										else
										{
											bool flag95 = flag5;
											if (flag95)
											{
												bool flag96 = (flag31 && num9 != 160U) || (num9 == 173U && !flag7);
												if (flag96)
												{
													flag83 = true;
												}
												flag82 = true;
											}
										}
									}
									bool flag97 = flag82;
									if (flag97)
									{
										this.SaveWordWrappingState(ref wordWrapState, num8, this.m_CharacterCount, textInfo);
									}
									bool flag98 = flag83;
									if (flag98)
									{
										this.SaveWordWrappingState(ref wordWrapState3, num8, this.m_CharacterCount, textInfo);
									}
								}
								this.m_CharacterCount++;
							}
						}
						IL_20EB:
						num8++;
					}
					float num48 = this.m_MaxFontSize - this.m_MinFontSize;
					bool flag99 = isTextAutoSizingEnabled && num48 > 0.051f && fontSize < generationSettings.fontSizeMax && this.m_AutoSizeIterationCount < this.m_AutoSizeMaxIterationCount;
					if (flag99)
					{
						bool flag100 = this.m_CharWidthAdjDelta < generationSettings.charWidthMaxAdj / 100f;
						if (flag100)
						{
							this.m_CharWidthAdjDelta = 0f;
						}
						this.m_MinFontSize = fontSize;
						float num49 = Mathf.Max((this.m_MaxFontSize - fontSize) / 2f, 0.05f);
						fontSize += num49;
						fontSize = Mathf.Min((float)((int)(fontSize * 20f + 0.5f)) / 20f, generationSettings.fontSizeMax);
						result = Vector2.zero;
					}
					else
					{
						this.m_IsAutoSizePointSizeSet = true;
						this.m_IsCalculatingPreferredValues = false;
						num6 += ((generationSettings.margins.x > 0f) ? generationSettings.margins.x : 0f);
						num6 += ((generationSettings.margins.z > 0f) ? generationSettings.margins.z : 0f);
						num7 += ((generationSettings.margins.y > 0f) ? generationSettings.margins.y : 0f);
						num7 += ((generationSettings.margins.w > 0f) ? generationSettings.margins.w : 0f);
						num6 = (float)((int)(num6 * 100f + 1f)) / 100f;
						num7 = (float)((int)(num7 * 100f + 1f)) / 100f;
						result = new Vector2(num6, num7);
					}
				}
			}
			return result;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0001C1B4 File Offset: 0x0001A3B4
		private void PopulateTextBackingArray(string sourceText)
		{
			int length = (sourceText == null) ? 0 : sourceText.Length;
			this.PopulateTextBackingArray(sourceText, 0, length);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0001C1DC File Offset: 0x0001A3DC
		private void PopulateTextBackingArray(string sourceText, int start, int length)
		{
			int num = 0;
			bool flag = sourceText == null;
			int i;
			if (flag)
			{
				i = 0;
				length = 0;
			}
			else
			{
				i = Mathf.Clamp(start, 0, sourceText.Length);
				length = Mathf.Clamp(length, 0, (start + length < sourceText.Length) ? length : (sourceText.Length - start));
			}
			bool flag2 = length >= this.m_TextBackingArray.Capacity;
			if (flag2)
			{
				this.m_TextBackingArray.Resize(length);
			}
			int num2 = i + length;
			while (i < num2)
			{
				this.m_TextBackingArray[num] = (uint)sourceText[i];
				num++;
				i++;
			}
			this.m_TextBackingArray[num] = 0U;
			this.m_TextBackingArray.Count = num;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0001C29C File Offset: 0x0001A49C
		private void PopulateTextBackingArray(StringBuilder sourceText, int start, int length)
		{
			int num = 0;
			bool flag = sourceText == null;
			int i;
			if (flag)
			{
				i = 0;
				length = 0;
			}
			else
			{
				i = Mathf.Clamp(start, 0, sourceText.Length);
				length = Mathf.Clamp(length, 0, (start + length < sourceText.Length) ? length : (sourceText.Length - start));
			}
			bool flag2 = length >= this.m_TextBackingArray.Capacity;
			if (flag2)
			{
				this.m_TextBackingArray.Resize(length);
			}
			int num2 = i + length;
			while (i < num2)
			{
				this.m_TextBackingArray[num] = (uint)sourceText[i];
				num++;
				i++;
			}
			this.m_TextBackingArray[num] = 0U;
			this.m_TextBackingArray.Count = num;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0001C35C File Offset: 0x0001A55C
		private void PopulateTextBackingArray(char[] sourceText, int start, int length)
		{
			int num = 0;
			bool flag = sourceText == null;
			int i;
			if (flag)
			{
				i = 0;
				length = 0;
			}
			else
			{
				i = Mathf.Clamp(start, 0, sourceText.Length);
				length = Mathf.Clamp(length, 0, (start + length < sourceText.Length) ? length : (sourceText.Length - start));
			}
			bool flag2 = length >= this.m_TextBackingArray.Capacity;
			if (flag2)
			{
				this.m_TextBackingArray.Resize(length);
			}
			int num2 = i + length;
			while (i < num2)
			{
				this.m_TextBackingArray[num] = (uint)sourceText[i];
				num++;
				i++;
			}
			this.m_TextBackingArray[num] = 0U;
			this.m_TextBackingArray.Count = num;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0001C40C File Offset: 0x0001A60C
		private void PopulateTextProcessingArray(TextGenerationSettings generationSettings)
		{
			int count = this.m_TextBackingArray.Count;
			bool flag = this.m_TextProcessingArray.Length < count;
			if (flag)
			{
				TextGeneratorUtilities.ResizeInternalArray<TextProcessingElement>(ref this.m_TextProcessingArray, count);
			}
			TextProcessingStack<int>.SetDefault(this.m_TextStyleStacks, 0);
			this.m_TextStyleStackDepth = 0;
			int num = 0;
			int hashCode = this.m_TextStyleStacks[0].Pop();
			TextStyle style = TextGeneratorUtilities.GetStyle(generationSettings, hashCode);
			bool flag2 = style != null && style.hashCode != -1183493901;
			if (flag2)
			{
				TextGeneratorUtilities.InsertOpeningStyleTag(style, ref this.m_TextProcessingArray, ref num, ref this.m_TextStyleStackDepth, ref this.m_TextStyleStacks, ref generationSettings);
			}
			bool flag3 = generationSettings.tagNoParsing;
			int i = 0;
			while (i < count)
			{
				uint num2 = this.m_TextBackingArray[i];
				bool flag4 = num2 == 0U;
				if (flag4)
				{
					break;
				}
				bool flag5 = num2 == 92U && i < count - 1;
				if (flag5)
				{
					uint num3 = this.m_TextBackingArray[i + 1];
					uint num4 = num3;
					if (num4 != 85U)
					{
						if (num4 != 92U)
						{
							switch (num4)
							{
							case 110U:
							{
								bool flag6 = !generationSettings.parseControlCharacters;
								if (!flag6)
								{
									this.m_TextProcessingArray[num] = new TextProcessingElement
									{
										elementType = TextProcessingElementType.TextCharacterElement,
										stringIndex = i,
										length = 1,
										unicode = 10U
									};
									i++;
									num++;
									goto IL_A01;
								}
								break;
							}
							case 114U:
							{
								bool flag7 = !generationSettings.parseControlCharacters;
								if (!flag7)
								{
									this.m_TextProcessingArray[num] = new TextProcessingElement
									{
										elementType = TextProcessingElementType.TextCharacterElement,
										stringIndex = i,
										length = 1,
										unicode = 13U
									};
									i++;
									num++;
									goto IL_A01;
								}
								break;
							}
							case 116U:
							{
								bool flag8 = !generationSettings.parseControlCharacters;
								if (!flag8)
								{
									this.m_TextProcessingArray[num] = new TextProcessingElement
									{
										elementType = TextProcessingElementType.TextCharacterElement,
										stringIndex = i,
										length = 1,
										unicode = 9U
									};
									i++;
									num++;
									goto IL_A01;
								}
								break;
							}
							case 117U:
							{
								bool flag9 = count > i + 5 && TextGeneratorUtilities.IsValidUTF16(this.m_TextBackingArray, i + 2);
								if (flag9)
								{
									this.m_TextProcessingArray[num] = new TextProcessingElement
									{
										elementType = TextProcessingElementType.TextCharacterElement,
										stringIndex = i,
										length = 6,
										unicode = TextGeneratorUtilities.GetUTF16(this.m_TextBackingArray, i + 2)
									};
									i += 5;
									num++;
									goto IL_A01;
								}
								break;
							}
							case 118U:
							{
								bool flag10 = !generationSettings.parseControlCharacters;
								if (!flag10)
								{
									this.m_TextProcessingArray[num] = new TextProcessingElement
									{
										elementType = TextProcessingElementType.TextCharacterElement,
										stringIndex = i,
										length = 1,
										unicode = 11U
									};
									i++;
									num++;
									goto IL_A01;
								}
								break;
							}
							}
						}
						else
						{
							bool flag11 = !generationSettings.parseControlCharacters;
							if (!flag11)
							{
								i++;
							}
						}
					}
					else
					{
						bool flag12 = count > i + 9 && TextGeneratorUtilities.IsValidUTF32(this.m_TextBackingArray, i + 2);
						if (flag12)
						{
							this.m_TextProcessingArray[num] = new TextProcessingElement
							{
								elementType = TextProcessingElementType.TextCharacterElement,
								stringIndex = i,
								length = 10,
								unicode = TextGeneratorUtilities.GetUTF32(this.m_TextBackingArray, i + 2)
							};
							i += 9;
							num++;
							goto IL_A01;
						}
					}
					goto IL_3B4;
				}
				goto IL_3B4;
				IL_A01:
				i++;
				continue;
				IL_3B4:
				bool flag13 = num2 >= 55296U && num2 <= 56319U && count > i + 1 && this.m_TextBackingArray[i + 1] >= 56320U && this.m_TextBackingArray[i + 1] <= 57343U;
				if (flag13)
				{
					this.m_TextProcessingArray[num] = new TextProcessingElement
					{
						elementType = TextProcessingElementType.TextCharacterElement,
						stringIndex = i,
						length = 2,
						unicode = TextGeneratorUtilities.ConvertToUTF32(num2, this.m_TextBackingArray[i + 1])
					};
					i++;
					num++;
					goto IL_A01;
				}
				bool flag14 = num2 == 60U && generationSettings.richText;
				if (flag14)
				{
					int markupTagHashCode = TextGeneratorUtilities.GetMarkupTagHashCode(this.m_TextBackingArray, i + 1);
					MarkupTag markupTag = (MarkupTag)markupTagHashCode;
					MarkupTag markupTag2 = markupTag;
					if (markupTag2 <= MarkupTag.CR)
					{
						if (markupTag2 <= MarkupTag.A)
						{
							if (markupTag2 != MarkupTag.NO_PARSE)
							{
								if (markupTag2 != MarkupTag.SLASH_NO_PARSE)
								{
									if (markupTag2 == MarkupTag.A)
									{
										bool flag15 = this.m_TextBackingArray.Count > i + 4 && this.m_TextBackingArray[i + 3] == 104U && this.m_TextBackingArray[i + 4] == 114U;
										if (flag15)
										{
											TextGeneratorUtilities.InsertOpeningTextStyle(TextGeneratorUtilities.GetStyle(generationSettings, 65), ref this.m_TextProcessingArray, ref num, ref this.m_TextStyleStackDepth, ref this.m_TextStyleStacks, ref generationSettings);
										}
									}
								}
								else
								{
									flag3 = false;
								}
							}
							else
							{
								flag3 = true;
							}
						}
						else if (markupTag2 != MarkupTag.SLASH_A)
						{
							if (markupTag2 != MarkupTag.BR)
							{
								if (markupTag2 == MarkupTag.CR)
								{
									bool flag16 = flag3;
									if (!flag16)
									{
										bool flag17 = num == this.m_TextProcessingArray.Length;
										if (flag17)
										{
											TextGeneratorUtilities.ResizeInternalArray<TextProcessingElement>(ref this.m_TextProcessingArray);
										}
										this.m_TextProcessingArray[num] = new TextProcessingElement
										{
											elementType = TextProcessingElementType.TextCharacterElement,
											stringIndex = i,
											length = 4,
											unicode = 13U
										};
										num++;
										i += 3;
										goto IL_A01;
									}
								}
							}
							else
							{
								bool flag18 = flag3;
								if (!flag18)
								{
									bool flag19 = num == this.m_TextProcessingArray.Length;
									if (flag19)
									{
										TextGeneratorUtilities.ResizeInternalArray<TextProcessingElement>(ref this.m_TextProcessingArray);
									}
									this.m_TextProcessingArray[num] = new TextProcessingElement
									{
										elementType = TextProcessingElementType.TextCharacterElement,
										stringIndex = i,
										length = 4,
										unicode = 10U
									};
									num++;
									i += 3;
									goto IL_A01;
								}
							}
						}
						else
						{
							TextGeneratorUtilities.InsertClosingTextStyle(TextGeneratorUtilities.GetStyle(generationSettings, 65), ref this.m_TextProcessingArray, ref num, ref this.m_TextStyleStackDepth, ref this.m_TextStyleStacks, ref generationSettings);
						}
					}
					else if (markupTag2 <= MarkupTag.NBSP)
					{
						if (markupTag2 != MarkupTag.SHY)
						{
							if (markupTag2 != MarkupTag.ZWJ)
							{
								if (markupTag2 == MarkupTag.NBSP)
								{
									bool flag20 = flag3;
									if (!flag20)
									{
										bool flag21 = num == this.m_TextProcessingArray.Length;
										if (flag21)
										{
											TextGeneratorUtilities.ResizeInternalArray<TextProcessingElement>(ref this.m_TextProcessingArray);
										}
										this.m_TextProcessingArray[num] = new TextProcessingElement
										{
											elementType = TextProcessingElementType.TextCharacterElement,
											stringIndex = i,
											length = 6,
											unicode = 160U
										};
										num++;
										i += 5;
										goto IL_A01;
									}
								}
							}
							else
							{
								bool flag22 = flag3;
								if (!flag22)
								{
									bool flag23 = num == this.m_TextProcessingArray.Length;
									if (flag23)
									{
										TextGeneratorUtilities.ResizeInternalArray<TextProcessingElement>(ref this.m_TextProcessingArray);
									}
									this.m_TextProcessingArray[num] = new TextProcessingElement
									{
										elementType = TextProcessingElementType.TextCharacterElement,
										stringIndex = i,
										length = 5,
										unicode = 8205U
									};
									num++;
									i += 4;
									goto IL_A01;
								}
							}
						}
						else
						{
							bool flag24 = flag3;
							if (!flag24)
							{
								bool flag25 = num == this.m_TextProcessingArray.Length;
								if (flag25)
								{
									TextGeneratorUtilities.ResizeInternalArray<TextProcessingElement>(ref this.m_TextProcessingArray);
								}
								this.m_TextProcessingArray[num] = new TextProcessingElement
								{
									elementType = TextProcessingElementType.TextCharacterElement,
									stringIndex = i,
									length = 5,
									unicode = 173U
								};
								num++;
								i += 4;
								goto IL_A01;
							}
						}
					}
					else if (markupTag2 != MarkupTag.ZWSP)
					{
						if (markupTag2 != MarkupTag.STYLE)
						{
							if (markupTag2 == MarkupTag.SLASH_STYLE)
							{
								bool flag26 = flag3;
								if (!flag26)
								{
									int j = num;
									TextGeneratorUtilities.ReplaceClosingStyleTag(ref this.m_TextProcessingArray, ref num, ref this.m_TextStyleStackDepth, ref this.m_TextStyleStacks, ref generationSettings);
									while (j < num)
									{
										this.m_TextProcessingArray[j].stringIndex = i;
										this.m_TextProcessingArray[j].length = 8;
										j++;
									}
									i += 7;
									goto IL_A01;
								}
							}
						}
						else
						{
							bool flag27 = flag3;
							if (!flag27)
							{
								int k = num;
								int num5;
								bool flag28 = TextGeneratorUtilities.ReplaceOpeningStyleTag(ref this.m_TextBackingArray, i, out num5, ref this.m_TextProcessingArray, ref num, ref this.m_TextStyleStackDepth, ref this.m_TextStyleStacks, ref generationSettings);
								if (flag28)
								{
									while (k < num)
									{
										this.m_TextProcessingArray[k].stringIndex = i;
										this.m_TextProcessingArray[k].length = num5 - i + 1;
										k++;
									}
									i = num5;
									goto IL_A01;
								}
							}
						}
					}
					else
					{
						bool flag29 = flag3;
						if (!flag29)
						{
							bool flag30 = num == this.m_TextProcessingArray.Length;
							if (flag30)
							{
								TextGeneratorUtilities.ResizeInternalArray<TextProcessingElement>(ref this.m_TextProcessingArray);
							}
							this.m_TextProcessingArray[num] = new TextProcessingElement
							{
								elementType = TextProcessingElementType.TextCharacterElement,
								stringIndex = i,
								length = 6,
								unicode = 8203U
							};
							num++;
							i += 5;
							goto IL_A01;
						}
					}
				}
				bool flag31 = num == this.m_TextProcessingArray.Length;
				if (flag31)
				{
					TextGeneratorUtilities.ResizeInternalArray<TextProcessingElement>(ref this.m_TextProcessingArray);
				}
				this.m_TextProcessingArray[num] = new TextProcessingElement
				{
					elementType = TextProcessingElementType.TextCharacterElement,
					stringIndex = i,
					length = 1,
					unicode = num2
				};
				num++;
				goto IL_A01;
			}
			this.m_TextStyleStackDepth = 0;
			bool flag32 = style != null && style.hashCode != -1183493901;
			if (flag32)
			{
				TextGeneratorUtilities.InsertClosingStyleTag(ref this.m_TextProcessingArray, ref num, ref this.m_TextStyleStackDepth, ref this.m_TextStyleStacks, ref generationSettings);
			}
			bool flag33 = num == this.m_TextProcessingArray.Length;
			if (flag33)
			{
				TextGeneratorUtilities.ResizeInternalArray<TextProcessingElement>(ref this.m_TextProcessingArray);
			}
			this.m_TextProcessingArray[num].unicode = 0U;
			this.m_InternalTextProcessingArraySize = num;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0001CEA4 File Offset: 0x0001B0A4
		private void InsertNewLine(int i, float baseScale, float currentElementScale, float currentEmScale, float boldSpacingAdjustment, float characterSpacingAdjustment, float width, float lineGap, ref bool isMaxVisibleDescenderSet, ref float maxVisibleDescender, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			float num = this.m_MaxLineAscender - this.m_StartOfLineAscender;
			bool flag = this.m_LineOffset > 0f && Math.Abs(num) > 0.01f && !this.m_IsDrivenLineSpacing && !this.m_IsNewPage;
			if (flag)
			{
				TextGeneratorUtilities.AdjustLineOffset(this.m_FirstCharacterOfLine, this.m_CharacterCount, num, textInfo);
				this.m_MaxDescender -= num;
				this.m_LineOffset += num;
			}
			float num2 = this.m_MaxLineAscender - this.m_LineOffset;
			float num3 = this.m_MaxLineDescender - this.m_LineOffset;
			this.m_MaxDescender = ((this.m_MaxDescender < num3) ? this.m_MaxDescender : num3);
			bool flag2 = !isMaxVisibleDescenderSet;
			if (flag2)
			{
				maxVisibleDescender = this.m_MaxDescender;
			}
			bool flag3 = generationSettings.useMaxVisibleDescender && (this.m_CharacterCount >= generationSettings.maxVisibleCharacters || this.m_LineNumber >= generationSettings.maxVisibleLines);
			if (flag3)
			{
				isMaxVisibleDescenderSet = true;
			}
			textInfo.lineInfo[this.m_LineNumber].firstCharacterIndex = this.m_FirstCharacterOfLine;
			textInfo.lineInfo[this.m_LineNumber].firstVisibleCharacterIndex = (this.m_FirstVisibleCharacterOfLine = ((this.m_FirstCharacterOfLine > this.m_FirstVisibleCharacterOfLine) ? this.m_FirstCharacterOfLine : this.m_FirstVisibleCharacterOfLine));
			textInfo.lineInfo[this.m_LineNumber].lastCharacterIndex = (this.m_LastCharacterOfLine = ((this.m_CharacterCount - 1 > 0) ? (this.m_CharacterCount - 1) : 0));
			textInfo.lineInfo[this.m_LineNumber].lastVisibleCharacterIndex = (this.m_LastVisibleCharacterOfLine = ((this.m_LastVisibleCharacterOfLine < this.m_FirstVisibleCharacterOfLine) ? this.m_FirstVisibleCharacterOfLine : this.m_LastVisibleCharacterOfLine));
			textInfo.lineInfo[this.m_LineNumber].characterCount = textInfo.lineInfo[this.m_LineNumber].lastCharacterIndex - textInfo.lineInfo[this.m_LineNumber].firstCharacterIndex + 1;
			textInfo.lineInfo[this.m_LineNumber].visibleCharacterCount = this.m_LineVisibleCharacterCount;
			textInfo.lineInfo[this.m_LineNumber].visibleSpaceCount = this.m_LineVisibleSpaceCount;
			textInfo.lineInfo[this.m_LineNumber].lineExtents.min = new Vector2(textInfo.textElementInfo[this.m_FirstVisibleCharacterOfLine].bottomLeft.x, num3);
			textInfo.lineInfo[this.m_LineNumber].lineExtents.max = new Vector2(textInfo.textElementInfo[this.m_LastVisibleCharacterOfLine].topRight.x, num2);
			textInfo.lineInfo[this.m_LineNumber].length = textInfo.lineInfo[this.m_LineNumber].lineExtents.max.x;
			textInfo.lineInfo[this.m_LineNumber].width = width;
			float adjustedHorizontalAdvance = textInfo.textElementInfo[this.m_LastVisibleCharacterOfLine].adjustedHorizontalAdvance;
			float num4 = (adjustedHorizontalAdvance * currentElementScale + (this.m_CurrentFontAsset.regularStyleSpacing + characterSpacingAdjustment + boldSpacingAdjustment) * currentEmScale + this.m_CSpacing) * (1f - generationSettings.charWidthMaxAdj);
			float xAdvance = textInfo.lineInfo[this.m_LineNumber].maxAdvance = textInfo.textElementInfo[this.m_LastVisibleCharacterOfLine].xAdvance + (generationSettings.isRightToLeft ? num4 : (-num4));
			textInfo.textElementInfo[this.m_LastVisibleCharacterOfLine].xAdvance = xAdvance;
			textInfo.lineInfo[this.m_LineNumber].baseline = 0f - this.m_LineOffset;
			textInfo.lineInfo[this.m_LineNumber].ascender = num2;
			textInfo.lineInfo[this.m_LineNumber].descender = num3;
			textInfo.lineInfo[this.m_LineNumber].lineHeight = num2 - num3 + lineGap * baseScale;
			this.m_FirstCharacterOfLine = this.m_CharacterCount;
			this.m_LineVisibleCharacterCount = 0;
			this.m_LineVisibleSpaceCount = 0;
			this.SaveWordWrappingState(ref this.m_SavedLineState, i, this.m_CharacterCount - 1, textInfo);
			this.m_LineNumber++;
			bool flag4 = this.m_LineNumber >= textInfo.lineInfo.Length;
			if (flag4)
			{
				TextGeneratorUtilities.ResizeLineExtents(this.m_LineNumber, textInfo);
			}
			bool flag5 = this.m_LineHeight == -32767f;
			if (flag5)
			{
				float adjustedAscender = textInfo.textElementInfo[this.m_CharacterCount].adjustedAscender;
				float num5 = 0f - this.m_MaxLineDescender + adjustedAscender + (lineGap + this.m_LineSpacingDelta) * baseScale + generationSettings.lineSpacing * currentEmScale;
				this.m_LineOffset += num5;
				this.m_StartOfLineAscender = adjustedAscender;
			}
			else
			{
				this.m_LineOffset += this.m_LineHeight + generationSettings.lineSpacing * currentEmScale;
			}
			this.m_MaxLineAscender = -32767f;
			this.m_MaxLineDescender = 32767f;
			this.m_XAdvance = 0f + this.m_TagIndent;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0001D401 File Offset: 0x0001B601
		protected void DoMissingGlyphCallback(uint unicode, int stringIndex, FontAsset fontAsset, TextInfo textInfo)
		{
			TextGenerator.MissingCharacterEventCallback onMissingCharacter = TextGenerator.OnMissingCharacter;
			if (onMissingCharacter != null)
			{
				onMissingCharacter(unicode, stringIndex, textInfo, fontAsset);
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0001D41C File Offset: 0x0001B61C
		private void ClearMarkupTagAttributes()
		{
			int num = this.m_XmlAttribute.Length;
			for (int i = 0; i < num; i++)
			{
				this.m_XmlAttribute[i] = default(RichTextTagAttribute);
			}
		}

		// Token: 0x04000150 RID: 336
		private const int k_Tab = 9;

		// Token: 0x04000151 RID: 337
		private const int k_LineFeed = 10;

		// Token: 0x04000152 RID: 338
		private const int k_CarriageReturn = 13;

		// Token: 0x04000153 RID: 339
		private const int k_Space = 32;

		// Token: 0x04000154 RID: 340
		private const int k_DoubleQuotes = 34;

		// Token: 0x04000155 RID: 341
		private const int k_NumberSign = 35;

		// Token: 0x04000156 RID: 342
		private const int k_PercentSign = 37;

		// Token: 0x04000157 RID: 343
		private const int k_SingleQuote = 39;

		// Token: 0x04000158 RID: 344
		private const int k_Plus = 43;

		// Token: 0x04000159 RID: 345
		private const int k_Minus = 45;

		// Token: 0x0400015A RID: 346
		private const int k_Period = 46;

		// Token: 0x0400015B RID: 347
		private const int k_LesserThan = 60;

		// Token: 0x0400015C RID: 348
		private const int k_Equal = 61;

		// Token: 0x0400015D RID: 349
		private const int k_GreaterThan = 62;

		// Token: 0x0400015E RID: 350
		private const int k_Underline = 95;

		// Token: 0x0400015F RID: 351
		private const int k_NoBreakSpace = 160;

		// Token: 0x04000160 RID: 352
		private const int k_SoftHyphen = 173;

		// Token: 0x04000161 RID: 353
		private const int k_HyphenMinus = 45;

		// Token: 0x04000162 RID: 354
		private const int k_FigureSpace = 8199;

		// Token: 0x04000163 RID: 355
		private const int k_Hyphen = 8208;

		// Token: 0x04000164 RID: 356
		private const int k_NonBreakingHyphen = 8209;

		// Token: 0x04000165 RID: 357
		private const int k_ZeroWidthSpace = 8203;

		// Token: 0x04000166 RID: 358
		private const int k_NarrowNoBreakSpace = 8239;

		// Token: 0x04000167 RID: 359
		private const int k_WordJoiner = 8288;

		// Token: 0x04000168 RID: 360
		private const int k_HorizontalEllipsis = 8230;

		// Token: 0x04000169 RID: 361
		private const int k_RightSingleQuote = 8217;

		// Token: 0x0400016A RID: 362
		private const int k_Square = 9633;

		// Token: 0x0400016B RID: 363
		private const int k_HangulJamoStart = 4352;

		// Token: 0x0400016C RID: 364
		private const int k_HangulJamoEnd = 4607;

		// Token: 0x0400016D RID: 365
		private const int k_CjkStart = 11904;

		// Token: 0x0400016E RID: 366
		private const int k_CjkEnd = 40959;

		// Token: 0x0400016F RID: 367
		private const int k_HangulJameExtendedStart = 43360;

		// Token: 0x04000170 RID: 368
		private const int k_HangulJameExtendedEnd = 43391;

		// Token: 0x04000171 RID: 369
		private const int k_HangulSyllablesStart = 44032;

		// Token: 0x04000172 RID: 370
		private const int k_HangulSyllablesEnd = 55295;

		// Token: 0x04000173 RID: 371
		private const int k_CjkIdeographsStart = 63744;

		// Token: 0x04000174 RID: 372
		private const int k_CjkIdeographsEnd = 64255;

		// Token: 0x04000175 RID: 373
		private const int k_CjkFormsStart = 65072;

		// Token: 0x04000176 RID: 374
		private const int k_CjkFormsEnd = 65103;

		// Token: 0x04000177 RID: 375
		private const int k_CjkHalfwidthStart = 65280;

		// Token: 0x04000178 RID: 376
		private const int k_CjkHalfwidthEnd = 65519;

		// Token: 0x04000179 RID: 377
		private const int k_EndOfText = 3;

		// Token: 0x0400017A RID: 378
		private const float k_FloatUnset = -32767f;

		// Token: 0x0400017B RID: 379
		private const int k_MaxCharacters = 8;

		// Token: 0x0400017C RID: 380
		private static TextGenerator s_TextGenerator;

		// Token: 0x0400017D RID: 381
		private TextBackingContainer m_TextBackingArray = new TextBackingContainer(4);

		// Token: 0x0400017E RID: 382
		internal TextProcessingElement[] m_TextProcessingArray = new TextProcessingElement[8];

		// Token: 0x0400017F RID: 383
		internal int m_InternalTextProcessingArraySize;

		// Token: 0x04000180 RID: 384
		[SerializeField]
		protected bool m_VertexBufferAutoSizeReduction = false;

		// Token: 0x04000181 RID: 385
		private char[] m_HtmlTag = new char[128];

		// Token: 0x04000182 RID: 386
		internal HighlightState m_HighlightState = new HighlightState(Color.white, Offset.zero);

		// Token: 0x04000183 RID: 387
		protected bool m_IsIgnoringAlignment;

		// Token: 0x04000184 RID: 388
		protected static bool m_IsTextTruncated;

		// Token: 0x04000186 RID: 390
		private Vector3[] m_RectTransformCorners = new Vector3[4];

		// Token: 0x04000187 RID: 391
		private float m_MarginWidth;

		// Token: 0x04000188 RID: 392
		private float m_MarginHeight;

		// Token: 0x04000189 RID: 393
		private float m_PreferredWidth;

		// Token: 0x0400018A RID: 394
		private float m_PreferredHeight;

		// Token: 0x0400018B RID: 395
		private FontAsset m_CurrentFontAsset;

		// Token: 0x0400018C RID: 396
		private Material m_CurrentMaterial;

		// Token: 0x0400018D RID: 397
		private int m_CurrentMaterialIndex;

		// Token: 0x0400018E RID: 398
		private TextProcessingStack<MaterialReference> m_MaterialReferenceStack = new TextProcessingStack<MaterialReference>(new MaterialReference[16]);

		// Token: 0x0400018F RID: 399
		private float m_Padding;

		// Token: 0x04000190 RID: 400
		private SpriteAsset m_CurrentSpriteAsset;

		// Token: 0x04000191 RID: 401
		private int m_TotalCharacterCount;

		// Token: 0x04000192 RID: 402
		private float m_FontSize;

		// Token: 0x04000193 RID: 403
		private float m_FontScaleMultiplier;

		// Token: 0x04000194 RID: 404
		private float m_CurrentFontSize;

		// Token: 0x04000195 RID: 405
		private TextProcessingStack<float> m_SizeStack = new TextProcessingStack<float>(16);

		// Token: 0x04000196 RID: 406
		protected TextProcessingStack<int>[] m_TextStyleStacks = new TextProcessingStack<int>[8];

		// Token: 0x04000197 RID: 407
		protected int m_TextStyleStackDepth = 0;

		// Token: 0x04000198 RID: 408
		private FontStyles m_FontStyleInternal = FontStyles.Normal;

		// Token: 0x04000199 RID: 409
		private FontStyleStack m_FontStyleStack;

		// Token: 0x0400019A RID: 410
		private TextFontWeight m_FontWeightInternal = TextFontWeight.Regular;

		// Token: 0x0400019B RID: 411
		private TextProcessingStack<TextFontWeight> m_FontWeightStack = new TextProcessingStack<TextFontWeight>(8);

		// Token: 0x0400019C RID: 412
		private TextAlignment m_LineJustification;

		// Token: 0x0400019D RID: 413
		private TextProcessingStack<TextAlignment> m_LineJustificationStack = new TextProcessingStack<TextAlignment>(16);

		// Token: 0x0400019E RID: 414
		private float m_BaselineOffset;

		// Token: 0x0400019F RID: 415
		private TextProcessingStack<float> m_BaselineOffsetStack = new TextProcessingStack<float>(new float[16]);

		// Token: 0x040001A0 RID: 416
		private Color32 m_FontColor32;

		// Token: 0x040001A1 RID: 417
		private Color32 m_HtmlColor;

		// Token: 0x040001A2 RID: 418
		private Color32 m_UnderlineColor;

		// Token: 0x040001A3 RID: 419
		private Color32 m_StrikethroughColor;

		// Token: 0x040001A4 RID: 420
		private TextProcessingStack<Color32> m_ColorStack = new TextProcessingStack<Color32>(new Color32[16]);

		// Token: 0x040001A5 RID: 421
		private TextProcessingStack<Color32> m_UnderlineColorStack = new TextProcessingStack<Color32>(new Color32[16]);

		// Token: 0x040001A6 RID: 422
		private TextProcessingStack<Color32> m_StrikethroughColorStack = new TextProcessingStack<Color32>(new Color32[16]);

		// Token: 0x040001A7 RID: 423
		private TextProcessingStack<Color32> m_HighlightColorStack = new TextProcessingStack<Color32>(new Color32[16]);

		// Token: 0x040001A8 RID: 424
		private TextProcessingStack<HighlightState> m_HighlightStateStack = new TextProcessingStack<HighlightState>(new HighlightState[16]);

		// Token: 0x040001A9 RID: 425
		private TextProcessingStack<int> m_ItalicAngleStack = new TextProcessingStack<int>(new int[16]);

		// Token: 0x040001AA RID: 426
		private TextColorGradient m_ColorGradientPreset;

		// Token: 0x040001AB RID: 427
		private TextProcessingStack<TextColorGradient> m_ColorGradientStack = new TextProcessingStack<TextColorGradient>(new TextColorGradient[16]);

		// Token: 0x040001AC RID: 428
		private bool m_ColorGradientPresetIsTinted;

		// Token: 0x040001AD RID: 429
		private TextProcessingStack<int> m_ActionStack = new TextProcessingStack<int>(new int[16]);

		// Token: 0x040001AE RID: 430
		private float m_LineOffset;

		// Token: 0x040001AF RID: 431
		private float m_LineHeight;

		// Token: 0x040001B0 RID: 432
		private bool m_IsDrivenLineSpacing;

		// Token: 0x040001B1 RID: 433
		private float m_CSpacing;

		// Token: 0x040001B2 RID: 434
		private float m_MonoSpacing;

		// Token: 0x040001B3 RID: 435
		private float m_XAdvance;

		// Token: 0x040001B4 RID: 436
		private float m_TagLineIndent;

		// Token: 0x040001B5 RID: 437
		private float m_TagIndent;

		// Token: 0x040001B6 RID: 438
		private TextProcessingStack<float> m_IndentStack = new TextProcessingStack<float>(new float[16]);

		// Token: 0x040001B7 RID: 439
		private bool m_TagNoParsing;

		// Token: 0x040001B8 RID: 440
		private int m_CharacterCount;

		// Token: 0x040001B9 RID: 441
		private int m_FirstCharacterOfLine;

		// Token: 0x040001BA RID: 442
		private int m_LastCharacterOfLine;

		// Token: 0x040001BB RID: 443
		private int m_FirstVisibleCharacterOfLine;

		// Token: 0x040001BC RID: 444
		private int m_LastVisibleCharacterOfLine;

		// Token: 0x040001BD RID: 445
		private float m_MaxLineAscender;

		// Token: 0x040001BE RID: 446
		private float m_MaxLineDescender;

		// Token: 0x040001BF RID: 447
		private int m_LineNumber;

		// Token: 0x040001C0 RID: 448
		private int m_LineVisibleCharacterCount;

		// Token: 0x040001C1 RID: 449
		private int m_LineVisibleSpaceCount;

		// Token: 0x040001C2 RID: 450
		private int m_FirstOverflowCharacterIndex;

		// Token: 0x040001C3 RID: 451
		private int m_PageNumber;

		// Token: 0x040001C4 RID: 452
		private float m_MarginLeft;

		// Token: 0x040001C5 RID: 453
		private float m_MarginRight;

		// Token: 0x040001C6 RID: 454
		private float m_Width;

		// Token: 0x040001C7 RID: 455
		private Extents m_MeshExtents;

		// Token: 0x040001C8 RID: 456
		private float m_MaxCapHeight;

		// Token: 0x040001C9 RID: 457
		private float m_MaxAscender;

		// Token: 0x040001CA RID: 458
		private float m_MaxDescender;

		// Token: 0x040001CB RID: 459
		private bool m_IsNewPage;

		// Token: 0x040001CC RID: 460
		private bool m_IsNonBreakingSpace;

		// Token: 0x040001CD RID: 461
		private WordWrapState m_SavedWordWrapState;

		// Token: 0x040001CE RID: 462
		private WordWrapState m_SavedLineState;

		// Token: 0x040001CF RID: 463
		private WordWrapState m_SavedEllipsisState = default(WordWrapState);

		// Token: 0x040001D0 RID: 464
		private WordWrapState m_SavedLastValidState = default(WordWrapState);

		// Token: 0x040001D1 RID: 465
		private WordWrapState m_SavedSoftLineBreakState = default(WordWrapState);

		// Token: 0x040001D2 RID: 466
		private TextElementType m_TextElementType;

		// Token: 0x040001D3 RID: 467
		private bool m_isTextLayoutPhase;

		// Token: 0x040001D4 RID: 468
		private int m_SpriteIndex;

		// Token: 0x040001D5 RID: 469
		private Color32 m_SpriteColor;

		// Token: 0x040001D6 RID: 470
		private TextElement m_CachedTextElement;

		// Token: 0x040001D7 RID: 471
		private Color32 m_HighlightColor;

		// Token: 0x040001D8 RID: 472
		private float m_CharWidthAdjDelta;

		// Token: 0x040001D9 RID: 473
		private float m_MaxFontSize;

		// Token: 0x040001DA RID: 474
		private float m_MinFontSize;

		// Token: 0x040001DB RID: 475
		private int m_AutoSizeIterationCount;

		// Token: 0x040001DC RID: 476
		private int m_AutoSizeMaxIterationCount = 100;

		// Token: 0x040001DD RID: 477
		private bool m_IsAutoSizePointSizeSet;

		// Token: 0x040001DE RID: 478
		private float m_StartOfLineAscender;

		// Token: 0x040001DF RID: 479
		private float m_LineSpacingDelta;

		// Token: 0x040001E0 RID: 480
		private MaterialReference[] m_MaterialReferences = new MaterialReference[8];

		// Token: 0x040001E1 RID: 481
		private int m_SpriteCount = 0;

		// Token: 0x040001E2 RID: 482
		private TextProcessingStack<int> m_StyleStack = new TextProcessingStack<int>(new int[16]);

		// Token: 0x040001E3 RID: 483
		private TextProcessingStack<WordWrapState> m_EllipsisInsertionCandidateStack = new TextProcessingStack<WordWrapState>(8, 8);

		// Token: 0x040001E4 RID: 484
		private int m_SpriteAnimationId;

		// Token: 0x040001E5 RID: 485
		private int m_ItalicAngle;

		// Token: 0x040001E6 RID: 486
		private Vector3 m_FXScale;

		// Token: 0x040001E7 RID: 487
		private Quaternion m_FXRotation;

		// Token: 0x040001E8 RID: 488
		private int m_LastBaseGlyphIndex;

		// Token: 0x040001E9 RID: 489
		private float m_PageAscender;

		// Token: 0x040001EA RID: 490
		private RichTextTagAttribute[] m_XmlAttribute = new RichTextTagAttribute[8];

		// Token: 0x040001EB RID: 491
		private float[] m_AttributeParameterValues = new float[16];

		// Token: 0x040001EC RID: 492
		private Dictionary<int, int> m_MaterialReferenceIndexLookup = new Dictionary<int, int>();

		// Token: 0x040001ED RID: 493
		private bool m_IsCalculatingPreferredValues;

		// Token: 0x040001EE RID: 494
		private SpriteAsset m_DefaultSpriteAsset;

		// Token: 0x040001EF RID: 495
		private bool m_TintSprite;

		// Token: 0x040001F0 RID: 496
		protected TextGenerator.SpecialCharacter m_Ellipsis;

		// Token: 0x040001F1 RID: 497
		protected TextGenerator.SpecialCharacter m_Underline;

		// Token: 0x040001F2 RID: 498
		private TextElementInfo[] m_InternalTextElementInfo;

		// Token: 0x02000027 RID: 39
		// (Invoke) Token: 0x0600015D RID: 349
		public delegate void MissingCharacterEventCallback(uint unicode, int stringIndex, TextInfo text, FontAsset fontAsset);

		// Token: 0x02000028 RID: 40
		protected struct SpecialCharacter
		{
			// Token: 0x06000160 RID: 352 RVA: 0x0001D654 File Offset: 0x0001B854
			public SpecialCharacter(Character character, int materialIndex)
			{
				this.character = character;
				this.fontAsset = (character.textAsset as FontAsset);
				this.material = ((this.fontAsset != null) ? this.fontAsset.material : null);
				this.materialIndex = materialIndex;
			}

			// Token: 0x040001F3 RID: 499
			public Character character;

			// Token: 0x040001F4 RID: 500
			public FontAsset fontAsset;

			// Token: 0x040001F5 RID: 501
			public Material material;

			// Token: 0x040001F6 RID: 502
			public int materialIndex;
		}
	}
}
