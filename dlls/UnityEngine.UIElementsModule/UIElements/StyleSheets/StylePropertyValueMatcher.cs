using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.UIElements.StyleSheets.Syntax;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x020004A3 RID: 1187
	internal class StylePropertyValueMatcher : BaseStyleMatcher
	{
		// Token: 0x17000869 RID: 2153
		// (get) Token: 0x06002508 RID: 9480 RVA: 0x0009BFE0 File Offset: 0x0009A1E0
		private StylePropertyValue current
		{
			get
			{
				return base.hasCurrent ? this.m_Values[base.currentIndex] : default(StylePropertyValue);
			}
		}

		// Token: 0x1700086A RID: 2154
		// (get) Token: 0x06002509 RID: 9481 RVA: 0x0009C011 File Offset: 0x0009A211
		public override int valueCount
		{
			get
			{
				return this.m_Values.Count;
			}
		}

		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x0600250A RID: 9482 RVA: 0x0000960A File Offset: 0x0000780A
		public override bool isCurrentVariable
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x0600250B RID: 9483 RVA: 0x0009C020 File Offset: 0x0009A220
		public override bool isCurrentComma
		{
			get
			{
				return base.hasCurrent && this.m_Values[base.currentIndex].handle.valueType == StyleValueType.CommaSeparator;
			}
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x0009C05C File Offset: 0x0009A25C
		public MatchResult Match(Expression exp, List<StylePropertyValue> values)
		{
			MatchResult matchResult = new MatchResult
			{
				errorCode = MatchResultErrorCode.None
			};
			bool flag = values == null || values.Count == 0;
			MatchResult result;
			if (flag)
			{
				matchResult.errorCode = MatchResultErrorCode.EmptyValue;
				result = matchResult;
			}
			else
			{
				base.Initialize();
				this.m_Values = values;
				StyleValueHandle handle = this.m_Values[0].handle;
				bool flag2 = handle.valueType == StyleValueType.Keyword && handle.valueIndex == 1;
				bool flag3;
				if (flag2)
				{
					base.MoveNext();
					flag3 = true;
				}
				else
				{
					flag3 = base.Match(exp);
				}
				bool flag4 = !flag3;
				if (flag4)
				{
					StyleSheet sheet = this.current.sheet;
					matchResult.errorCode = MatchResultErrorCode.Syntax;
					matchResult.errorValue = sheet.ReadAsString(this.current.handle);
				}
				else
				{
					bool hasCurrent = base.hasCurrent;
					if (hasCurrent)
					{
						StyleSheet sheet2 = this.current.sheet;
						matchResult.errorCode = MatchResultErrorCode.ExpectedEndOfValue;
						matchResult.errorValue = sheet2.ReadAsString(this.current.handle);
					}
				}
				result = matchResult;
			}
			return result;
		}

		// Token: 0x0600250D RID: 9485 RVA: 0x0009C178 File Offset: 0x0009A378
		protected override bool MatchKeyword(string keyword)
		{
			StylePropertyValue current = this.current;
			bool flag = current.handle.valueType == StyleValueType.Keyword;
			bool result;
			if (flag)
			{
				StyleValueKeyword valueIndex = (StyleValueKeyword)current.handle.valueIndex;
				result = (valueIndex.ToUssString() == keyword.ToLowerInvariant());
			}
			else
			{
				bool flag2 = current.handle.valueType == StyleValueType.Enum;
				if (flag2)
				{
					string a = current.sheet.ReadEnum(current.handle);
					result = (a == keyword.ToLowerInvariant());
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600250E RID: 9486 RVA: 0x0009C200 File Offset: 0x0009A400
		protected override bool MatchNumber()
		{
			return this.current.handle.valueType == StyleValueType.Float;
		}

		// Token: 0x0600250F RID: 9487 RVA: 0x0009C228 File Offset: 0x0009A428
		protected override bool MatchInteger()
		{
			return this.current.handle.valueType == StyleValueType.Float;
		}

		// Token: 0x06002510 RID: 9488 RVA: 0x0009C250 File Offset: 0x0009A450
		protected override bool MatchLength()
		{
			StylePropertyValue current = this.current;
			bool flag = current.handle.valueType == StyleValueType.Dimension;
			bool result;
			if (flag)
			{
				Dimension dimension = current.sheet.ReadDimension(current.handle);
				result = (dimension.unit == Dimension.Unit.Pixel);
			}
			else
			{
				bool flag2 = current.handle.valueType == StyleValueType.Float;
				if (flag2)
				{
					float b = current.sheet.ReadFloat(current.handle);
					result = Mathf.Approximately(0f, b);
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06002511 RID: 9489 RVA: 0x0009C2D4 File Offset: 0x0009A4D4
		protected override bool MatchPercentage()
		{
			StylePropertyValue current = this.current;
			bool flag = current.handle.valueType == StyleValueType.Dimension;
			bool result;
			if (flag)
			{
				Dimension dimension = current.sheet.ReadDimension(current.handle);
				result = (dimension.unit == Dimension.Unit.Percent);
			}
			else
			{
				bool flag2 = current.handle.valueType == StyleValueType.Float;
				if (flag2)
				{
					float b = current.sheet.ReadFloat(current.handle);
					result = Mathf.Approximately(0f, b);
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06002512 RID: 9490 RVA: 0x0009C358 File Offset: 0x0009A558
		protected override bool MatchColor()
		{
			StylePropertyValue current = this.current;
			bool flag = current.handle.valueType == StyleValueType.Color;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = current.handle.valueType == StyleValueType.Enum;
				if (flag2)
				{
					Color clear = Color.clear;
					string text = current.sheet.ReadAsString(current.handle);
					bool flag3 = StyleSheetColor.TryGetColor(text.ToLowerInvariant(), out clear);
					if (flag3)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06002513 RID: 9491 RVA: 0x0009C3D0 File Offset: 0x0009A5D0
		protected override bool MatchResource()
		{
			return this.current.handle.valueType == StyleValueType.ResourcePath;
		}

		// Token: 0x06002514 RID: 9492 RVA: 0x0009C3F8 File Offset: 0x0009A5F8
		protected override bool MatchUrl()
		{
			StyleValueType valueType = this.current.handle.valueType;
			return valueType == StyleValueType.AssetReference || valueType == StyleValueType.ScalableImage;
		}

		// Token: 0x06002515 RID: 9493 RVA: 0x0009C430 File Offset: 0x0009A630
		protected override bool MatchTime()
		{
			StylePropertyValue current = this.current;
			bool flag = current.handle.valueType == StyleValueType.Dimension;
			bool result;
			if (flag)
			{
				Dimension dimension = current.sheet.ReadDimension(current.handle);
				result = (dimension.unit == Dimension.Unit.Second || dimension.unit == Dimension.Unit.Millisecond);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06002516 RID: 9494 RVA: 0x0009C488 File Offset: 0x0009A688
		protected override bool MatchCustomIdent()
		{
			StylePropertyValue current = this.current;
			bool flag = current.handle.valueType == StyleValueType.Enum;
			bool result;
			if (flag)
			{
				string text = current.sheet.ReadAsString(current.handle);
				Match match = BaseStyleMatcher.s_CustomIdentRegex.Match(text);
				result = (match.Success && match.Length == text.Length);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06002517 RID: 9495 RVA: 0x0009C4F4 File Offset: 0x0009A6F4
		protected override bool MatchAngle()
		{
			StylePropertyValue current = this.current;
			bool flag = current.handle.valueType == StyleValueType.Dimension;
			if (flag)
			{
				Dimension dimension = current.sheet.ReadDimension(current.handle);
				Dimension.Unit unit = dimension.unit;
				Dimension.Unit unit2 = unit;
				if (unit2 - Dimension.Unit.Degree <= 3)
				{
					return true;
				}
			}
			bool flag2 = current.handle.valueType == StyleValueType.Float;
			bool result;
			if (flag2)
			{
				float b = current.sheet.ReadFloat(current.handle);
				result = Mathf.Approximately(0f, b);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x040011D5 RID: 4565
		private List<StylePropertyValue> m_Values;
	}
}
