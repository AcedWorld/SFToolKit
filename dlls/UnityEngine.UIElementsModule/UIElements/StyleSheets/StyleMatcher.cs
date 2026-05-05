using System;
using System.Text.RegularExpressions;
using UnityEngine.UIElements.StyleSheets.Syntax;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x020004A2 RID: 1186
	internal class StyleMatcher : BaseStyleMatcher
	{
		// Token: 0x17000865 RID: 2149
		// (get) Token: 0x060024F5 RID: 9461 RVA: 0x0009BA82 File Offset: 0x00099C82
		private string current
		{
			get
			{
				return base.hasCurrent ? this.m_PropertyParts[base.currentIndex] : null;
			}
		}

		// Token: 0x17000866 RID: 2150
		// (get) Token: 0x060024F6 RID: 9462 RVA: 0x0009BA9C File Offset: 0x00099C9C
		public override int valueCount
		{
			get
			{
				return this.m_PropertyParts.Length;
			}
		}

		// Token: 0x17000867 RID: 2151
		// (get) Token: 0x060024F7 RID: 9463 RVA: 0x0009BAA6 File Offset: 0x00099CA6
		public override bool isCurrentVariable
		{
			get
			{
				return base.hasCurrent && this.current.StartsWith("var(");
			}
		}

		// Token: 0x17000868 RID: 2152
		// (get) Token: 0x060024F8 RID: 9464 RVA: 0x0009BAC3 File Offset: 0x00099CC3
		public override bool isCurrentComma
		{
			get
			{
				return base.hasCurrent && this.current == ",";
			}
		}

		// Token: 0x060024F9 RID: 9465 RVA: 0x0009BAE0 File Offset: 0x00099CE0
		private void Initialize(string propertyValue)
		{
			base.Initialize();
			this.m_PropertyParts = this.m_Parser.Parse(propertyValue);
		}

		// Token: 0x060024FA RID: 9466 RVA: 0x0009BAFC File Offset: 0x00099CFC
		public MatchResult Match(Expression exp, string propertyValue)
		{
			MatchResult matchResult = new MatchResult
			{
				errorCode = MatchResultErrorCode.None
			};
			bool flag = string.IsNullOrEmpty(propertyValue);
			MatchResult result;
			if (flag)
			{
				matchResult.errorCode = MatchResultErrorCode.EmptyValue;
				result = matchResult;
			}
			else
			{
				this.Initialize(propertyValue);
				string current = this.current;
				bool flag2 = current == "initial" || current.StartsWith("env(");
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
					matchResult.errorCode = MatchResultErrorCode.Syntax;
					matchResult.errorValue = this.current;
				}
				else
				{
					bool hasCurrent = base.hasCurrent;
					if (hasCurrent)
					{
						matchResult.errorCode = MatchResultErrorCode.ExpectedEndOfValue;
						matchResult.errorValue = this.current;
					}
				}
				result = matchResult;
			}
			return result;
		}

		// Token: 0x060024FB RID: 9467 RVA: 0x0009BBD0 File Offset: 0x00099DD0
		protected override bool MatchKeyword(string keyword)
		{
			return string.Compare(this.current, keyword, StringComparison.OrdinalIgnoreCase) == 0;
		}

		// Token: 0x060024FC RID: 9468 RVA: 0x0009BBF4 File Offset: 0x00099DF4
		protected override bool MatchNumber()
		{
			string current = this.current;
			Match match = StyleMatcher.s_NumberRegex.Match(current);
			return match.Success;
		}

		// Token: 0x060024FD RID: 9469 RVA: 0x0009BC20 File Offset: 0x00099E20
		protected override bool MatchInteger()
		{
			string current = this.current;
			Match match = StyleMatcher.s_IntegerRegex.Match(current);
			return match.Success;
		}

		// Token: 0x060024FE RID: 9470 RVA: 0x0009BC4C File Offset: 0x00099E4C
		protected override bool MatchLength()
		{
			string current = this.current;
			Match match = StyleMatcher.s_LengthRegex.Match(current);
			bool success = match.Success;
			bool result;
			if (success)
			{
				result = true;
			}
			else
			{
				match = StyleMatcher.s_ZeroRegex.Match(current);
				result = match.Success;
			}
			return result;
		}

		// Token: 0x060024FF RID: 9471 RVA: 0x0009BC94 File Offset: 0x00099E94
		protected override bool MatchPercentage()
		{
			string current = this.current;
			Match match = StyleMatcher.s_PercentRegex.Match(current);
			bool success = match.Success;
			bool result;
			if (success)
			{
				result = true;
			}
			else
			{
				match = StyleMatcher.s_ZeroRegex.Match(current);
				result = match.Success;
			}
			return result;
		}

		// Token: 0x06002500 RID: 9472 RVA: 0x0009BCDC File Offset: 0x00099EDC
		protected override bool MatchColor()
		{
			string current = this.current;
			Match match = StyleMatcher.s_HexColorRegex.Match(current);
			bool success = match.Success;
			bool result;
			if (success)
			{
				result = true;
			}
			else
			{
				match = StyleMatcher.s_RgbRegex.Match(current);
				bool success2 = match.Success;
				if (success2)
				{
					result = true;
				}
				else
				{
					match = StyleMatcher.s_RgbaRegex.Match(current);
					bool success3 = match.Success;
					if (success3)
					{
						result = true;
					}
					else
					{
						Color clear = Color.clear;
						bool flag = StyleSheetColor.TryGetColor(current, out clear);
						result = flag;
					}
				}
			}
			return result;
		}

		// Token: 0x06002501 RID: 9473 RVA: 0x0009BD68 File Offset: 0x00099F68
		protected override bool MatchResource()
		{
			string current = this.current;
			Match match = StyleMatcher.s_ResourceRegex.Match(current);
			bool flag = !match.Success;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				string input = match.Groups[1].Value.Trim();
				match = StyleMatcher.s_VarFunctionRegex.Match(input);
				result = !match.Success;
			}
			return result;
		}

		// Token: 0x06002502 RID: 9474 RVA: 0x0009BDD0 File Offset: 0x00099FD0
		protected override bool MatchUrl()
		{
			string current = this.current;
			Match match = StyleMatcher.s_UrlRegex.Match(current);
			bool flag = !match.Success;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				string input = match.Groups[1].Value.Trim();
				match = StyleMatcher.s_VarFunctionRegex.Match(input);
				result = !match.Success;
			}
			return result;
		}

		// Token: 0x06002503 RID: 9475 RVA: 0x0009BE38 File Offset: 0x0009A038
		protected override bool MatchTime()
		{
			string current = this.current;
			Match match = StyleMatcher.s_TimeRegex.Match(current);
			return match.Success;
		}

		// Token: 0x06002504 RID: 9476 RVA: 0x0009BE64 File Offset: 0x0009A064
		protected override bool MatchAngle()
		{
			string current = this.current;
			Match match = StyleMatcher.s_AngleRegex.Match(current);
			bool success = match.Success;
			bool result;
			if (success)
			{
				result = true;
			}
			else
			{
				match = StyleMatcher.s_ZeroRegex.Match(current);
				result = match.Success;
			}
			return result;
		}

		// Token: 0x06002505 RID: 9477 RVA: 0x0009BEAC File Offset: 0x0009A0AC
		protected override bool MatchCustomIdent()
		{
			string current = this.current;
			Match match = BaseStyleMatcher.s_CustomIdentRegex.Match(current);
			return match.Success && match.Length == current.Length;
		}

		// Token: 0x040011C6 RID: 4550
		private StylePropertyValueParser m_Parser = new StylePropertyValueParser();

		// Token: 0x040011C7 RID: 4551
		private string[] m_PropertyParts;

		// Token: 0x040011C8 RID: 4552
		private static readonly Regex s_NumberRegex = new Regex("^[+-]?\\d+(?:\\.\\d+)?$", RegexOptions.Compiled);

		// Token: 0x040011C9 RID: 4553
		private static readonly Regex s_IntegerRegex = new Regex("^[+-]?\\d+$", RegexOptions.Compiled);

		// Token: 0x040011CA RID: 4554
		private static readonly Regex s_ZeroRegex = new Regex("^0(?:\\.0+)?$", RegexOptions.Compiled);

		// Token: 0x040011CB RID: 4555
		private static readonly Regex s_LengthRegex = new Regex("^[+-]?\\d+(?:\\.\\d+)?(?:px)$", RegexOptions.Compiled);

		// Token: 0x040011CC RID: 4556
		private static readonly Regex s_PercentRegex = new Regex("^[+-]?\\d+(?:\\.\\d+)?(?:%)$", RegexOptions.Compiled);

		// Token: 0x040011CD RID: 4557
		private static readonly Regex s_HexColorRegex = new Regex("^#[a-fA-F0-9]{3}(?:[a-fA-F0-9]{3})?$", RegexOptions.Compiled);

		// Token: 0x040011CE RID: 4558
		private static readonly Regex s_RgbRegex = new Regex("^rgb\\(\\s*(\\d+)\\s*,\\s*(\\d+)\\s*,\\s*(\\d+)\\s*\\)$", RegexOptions.Compiled);

		// Token: 0x040011CF RID: 4559
		private static readonly Regex s_RgbaRegex = new Regex("rgba\\(\\s*(\\d+)\\s*,\\s*(\\d+)\\s*,\\s*(\\d+)\\s*,\\s*([\\d.]+)\\s*\\)$", RegexOptions.Compiled);

		// Token: 0x040011D0 RID: 4560
		private static readonly Regex s_VarFunctionRegex = new Regex("^var\\(.+\\)$", RegexOptions.Compiled);

		// Token: 0x040011D1 RID: 4561
		private static readonly Regex s_ResourceRegex = new Regex("^resource\\((.+)\\)$", RegexOptions.Compiled);

		// Token: 0x040011D2 RID: 4562
		private static readonly Regex s_UrlRegex = new Regex("^url\\((.+)\\)$", RegexOptions.Compiled);

		// Token: 0x040011D3 RID: 4563
		private static readonly Regex s_TimeRegex = new Regex("^[+-]?\\.?\\d+(?:\\.\\d+)?(?:s|ms)$", RegexOptions.Compiled);

		// Token: 0x040011D4 RID: 4564
		private static readonly Regex s_AngleRegex = new Regex("^[+-]?\\d+(?:\\.\\d+)?(?:deg|grad|rad|turn)$", RegexOptions.Compiled);
	}
}
