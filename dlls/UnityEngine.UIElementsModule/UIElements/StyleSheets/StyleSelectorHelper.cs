using System;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x02000493 RID: 1171
	internal static class StyleSelectorHelper
	{
		// Token: 0x060024A2 RID: 9378 RVA: 0x000996C0 File Offset: 0x000978C0
		public static MatchResultInfo MatchesSelector(VisualElement element, StyleSelector selector)
		{
			bool flag = true;
			StyleSelectorPart[] parts = selector.parts;
			int num = parts.Length;
			int num2 = 0;
			while (num2 < num && flag)
			{
				switch (parts[num2].type)
				{
				case StyleSelectorType.Wildcard:
					break;
				case StyleSelectorType.Type:
					flag = string.Equals(element.typeName, parts[num2].value, StringComparison.Ordinal);
					break;
				case StyleSelectorType.Class:
					flag = element.ClassListContains(parts[num2].value);
					break;
				case StyleSelectorType.PseudoClass:
					break;
				case StyleSelectorType.RecursivePseudoClass:
					goto IL_C9;
				case StyleSelectorType.ID:
					flag = string.Equals(element.name, parts[num2].value, StringComparison.Ordinal);
					break;
				case StyleSelectorType.Predicate:
				{
					UQuery.IVisualPredicateWrapper visualPredicateWrapper = parts[num2].tempData as UQuery.IVisualPredicateWrapper;
					flag = (visualPredicateWrapper != null && visualPredicateWrapper.Predicate(element));
					break;
				}
				default:
					goto IL_C9;
				}
				IL_CD:
				num2++;
				continue;
				IL_C9:
				flag = false;
				goto IL_CD;
			}
			int num3 = 0;
			int num4 = 0;
			bool flag2 = flag;
			bool flag3 = flag2 && selector.pseudoStateMask != 0;
			if (flag3)
			{
				flag = ((selector.pseudoStateMask & (int)element.pseudoStates) == selector.pseudoStateMask);
				bool flag4 = flag;
				if (flag4)
				{
					num4 = selector.pseudoStateMask;
				}
				else
				{
					num3 = selector.pseudoStateMask;
				}
			}
			bool flag5 = flag2 && selector.negatedPseudoStateMask != 0;
			if (flag5)
			{
				flag &= ((selector.negatedPseudoStateMask & (int)(~(int)element.pseudoStates)) == selector.negatedPseudoStateMask);
				bool flag6 = flag;
				if (flag6)
				{
					num3 |= selector.negatedPseudoStateMask;
				}
				else
				{
					num4 |= selector.negatedPseudoStateMask;
				}
			}
			return new MatchResultInfo(flag, (PseudoStates)num3, (PseudoStates)num4);
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x00099864 File Offset: 0x00097A64
		public static bool MatchRightToLeft(VisualElement element, StyleComplexSelector complexSelector, Action<VisualElement, MatchResultInfo> processResult)
		{
			VisualElement visualElement = element;
			int i = complexSelector.selectors.Length - 1;
			VisualElement visualElement2 = null;
			int num = -1;
			while (i >= 0)
			{
				bool flag = visualElement == null;
				if (flag)
				{
					break;
				}
				MatchResultInfo matchResultInfo = StyleSelectorHelper.MatchesSelector(visualElement, complexSelector.selectors[i]);
				processResult(visualElement, matchResultInfo);
				bool flag2 = !matchResultInfo.success;
				if (flag2)
				{
					bool flag3 = i < complexSelector.selectors.Length - 1 && complexSelector.selectors[i + 1].previousRelationship == StyleSelectorRelationship.Descendent;
					if (flag3)
					{
						visualElement = visualElement.parent;
					}
					else
					{
						bool flag4 = visualElement2 != null;
						if (!flag4)
						{
							break;
						}
						visualElement = visualElement2;
						i = num;
					}
				}
				else
				{
					bool flag5 = i < complexSelector.selectors.Length - 1 && complexSelector.selectors[i + 1].previousRelationship == StyleSelectorRelationship.Descendent;
					if (flag5)
					{
						visualElement2 = visualElement.parent;
						num = i;
					}
					bool flag6 = --i < 0;
					if (flag6)
					{
						return true;
					}
					visualElement = visualElement.parent;
				}
			}
			return false;
		}

		// Token: 0x060024A4 RID: 9380 RVA: 0x00099970 File Offset: 0x00097B70
		private static void FastLookup(IDictionary<string, StyleComplexSelector> table, List<SelectorMatchRecord> matchedSelectors, StyleMatchingContext context, string input, ref SelectorMatchRecord record)
		{
			StyleComplexSelector nextInTable;
			bool flag = table.TryGetValue(input, out nextInTable);
			if (flag)
			{
				while (nextInTable != null)
				{
					bool flag2 = true;
					bool flag3 = false;
					bool flag4 = !nextInTable.isSimple;
					if (flag4)
					{
						flag2 = context.ancestorFilter.IsCandidate(nextInTable);
					}
					bool flag5 = flag2;
					if (flag5)
					{
						flag3 = StyleSelectorHelper.MatchRightToLeft(context.currentElement, nextInTable, context.processResult);
					}
					bool flag6 = flag3;
					if (flag6)
					{
						record.complexSelector = nextInTable;
						matchedSelectors.Add(record);
					}
					nextInTable = nextInTable.nextInTable;
				}
			}
		}

		// Token: 0x060024A5 RID: 9381 RVA: 0x00099A00 File Offset: 0x00097C00
		public static void FindMatches(StyleMatchingContext context, List<SelectorMatchRecord> matchedSelectors)
		{
			VisualElement currentElement = context.currentElement;
			int num = context.styleSheetCount - 1;
			bool flag = currentElement.styleSheetList != null;
			if (flag)
			{
				int num2 = currentElement.styleSheetList.Count;
				for (int i = 0; i < currentElement.styleSheetList.Count; i++)
				{
					StyleSheet styleSheet = currentElement.styleSheetList[i];
					bool flag2 = styleSheet.flattenedRecursiveImports != null;
					if (flag2)
					{
						num2 += styleSheet.flattenedRecursiveImports.Count;
					}
				}
				num -= num2;
			}
			StyleSelectorHelper.FindMatches(context, matchedSelectors, num);
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x00099A98 File Offset: 0x00097C98
		public static void FindMatches(StyleMatchingContext context, List<SelectorMatchRecord> matchedSelectors, int parentSheetIndex)
		{
			Debug.Assert(matchedSelectors.Count == 0);
			Debug.Assert(context.currentElement != null, "context.currentElement != null");
			bool flag = false;
			HashSet<StyleSheet> hashSet = CollectionPool<HashSet<StyleSheet>, StyleSheet>.Get();
			try
			{
				VisualElement currentElement = context.currentElement;
				for (int i = context.styleSheetCount - 1; i >= 0; i--)
				{
					StyleSheet styleSheetAt = context.GetStyleSheetAt(i);
					bool flag2 = !hashSet.Add(styleSheetAt);
					if (!flag2)
					{
						bool flag3 = i > parentSheetIndex;
						if (flag3)
						{
							currentElement.pseudoStates |= PseudoStates.Root;
							flag = true;
						}
						else
						{
							currentElement.pseudoStates &= ~PseudoStates.Root;
						}
						SelectorMatchRecord selectorMatchRecord = new SelectorMatchRecord(styleSheetAt, i);
						StyleSelectorHelper.FastLookup(styleSheetAt.orderedTypeSelectors, matchedSelectors, context, currentElement.typeName, ref selectorMatchRecord);
						StyleSelectorHelper.FastLookup(styleSheetAt.orderedTypeSelectors, matchedSelectors, context, "*", ref selectorMatchRecord);
						bool flag4 = !string.IsNullOrEmpty(currentElement.name);
						if (flag4)
						{
							StyleSelectorHelper.FastLookup(styleSheetAt.orderedNameSelectors, matchedSelectors, context, currentElement.name, ref selectorMatchRecord);
						}
						foreach (string input in currentElement.GetClassesForIteration())
						{
							StyleSelectorHelper.FastLookup(styleSheetAt.orderedClassSelectors, matchedSelectors, context, input, ref selectorMatchRecord);
						}
					}
				}
				bool flag5 = flag;
				if (flag5)
				{
					currentElement.pseudoStates &= ~PseudoStates.Root;
				}
			}
			finally
			{
				CollectionPool<HashSet<StyleSheet>, StyleSheet>.Release(hashSet);
			}
		}
	}
}
