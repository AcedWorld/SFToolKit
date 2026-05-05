using System;
using System.Text.RegularExpressions;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x02000489 RID: 1161
	internal static class CSSSpec
	{
		// Token: 0x06002454 RID: 9300 RVA: 0x00096D54 File Offset: 0x00094F54
		public static int GetSelectorSpecificity(string selector)
		{
			int result = 0;
			StyleSelectorPart[] parts;
			bool flag = CSSSpec.ParseSelector(selector, out parts);
			if (flag)
			{
				result = CSSSpec.GetSelectorSpecificity(parts);
			}
			return result;
		}

		// Token: 0x06002455 RID: 9301 RVA: 0x00096D80 File Offset: 0x00094F80
		public static int GetSelectorSpecificity(StyleSelectorPart[] parts)
		{
			int num = 1;
			for (int i = 0; i < parts.Length; i++)
			{
				switch (parts[i].type)
				{
				case StyleSelectorType.Type:
					num++;
					break;
				case StyleSelectorType.Class:
				case StyleSelectorType.PseudoClass:
					num += 10;
					break;
				case StyleSelectorType.RecursivePseudoClass:
					throw new ArgumentException("Recursive pseudo classes are not supported");
				case StyleSelectorType.ID:
					num += 100;
					break;
				}
			}
			return num;
		}

		// Token: 0x06002456 RID: 9302 RVA: 0x00096DFC File Offset: 0x00094FFC
		public static bool ParseSelector(string selector, out StyleSelectorPart[] parts)
		{
			MatchCollection matchCollection = CSSSpec.rgx.Matches(selector);
			int count = matchCollection.Count;
			bool flag = count < 1;
			bool result;
			if (flag)
			{
				parts = null;
				result = false;
			}
			else
			{
				parts = new StyleSelectorPart[count];
				for (int i = 0; i < count; i++)
				{
					Match match = matchCollection[i];
					StyleSelectorType type = StyleSelectorType.Unknown;
					string value = string.Empty;
					bool flag2 = !string.IsNullOrEmpty(match.Groups["wildcard"].Value);
					if (flag2)
					{
						value = "*";
						type = StyleSelectorType.Wildcard;
					}
					else
					{
						bool flag3 = !string.IsNullOrEmpty(match.Groups["id"].Value);
						if (flag3)
						{
							value = match.Groups["id"].Value.Substring(1);
							type = StyleSelectorType.ID;
						}
						else
						{
							bool flag4 = !string.IsNullOrEmpty(match.Groups["class"].Value);
							if (flag4)
							{
								value = match.Groups["class"].Value.Substring(1);
								type = StyleSelectorType.Class;
							}
							else
							{
								bool flag5 = !string.IsNullOrEmpty(match.Groups["pseudoclass"].Value);
								if (flag5)
								{
									string value2 = match.Groups["param"].Value;
									bool flag6 = !string.IsNullOrEmpty(value2);
									if (flag6)
									{
										value = value2;
										type = StyleSelectorType.RecursivePseudoClass;
									}
									else
									{
										value = match.Groups["pseudoclass"].Value.Substring(1);
										type = StyleSelectorType.PseudoClass;
									}
								}
								else
								{
									bool flag7 = !string.IsNullOrEmpty(match.Groups["type"].Value);
									if (flag7)
									{
										value = match.Groups["type"].Value;
										type = StyleSelectorType.Type;
									}
								}
							}
						}
					}
					parts[i] = new StyleSelectorPart
					{
						type = type,
						value = value
					};
				}
				result = true;
			}
			return result;
		}

		// Token: 0x04001169 RID: 4457
		private static readonly Regex rgx = new Regex("(?<id>#[-]?\\w[\\w-]*)|(?<class>\\.[\\w-]+)|(?<pseudoclass>:[\\w-]+(\\((?<param>.+)\\))?)|(?<type>([^\\-]\\w+|\\w+))|(?<wildcard>\\*)|\\s+", RegexOptions.IgnoreCase | RegexOptions.Compiled);

		// Token: 0x0400116A RID: 4458
		private const int typeSelectorWeight = 1;

		// Token: 0x0400116B RID: 4459
		private const int classSelectorWeight = 10;

		// Token: 0x0400116C RID: 4460
		private const int idSelectorWeight = 100;
	}
}
