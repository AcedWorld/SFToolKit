using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x02000497 RID: 1175
	internal static class StyleSheetCache
	{
		// Token: 0x060024C0 RID: 9408 RVA: 0x0009A299 File Offset: 0x00098499
		internal static void ClearCaches()
		{
			StyleSheetCache.s_RulePropertyIdsCache.Clear();
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x0009A2A8 File Offset: 0x000984A8
		internal static StylePropertyId[] GetPropertyIds(StyleSheet sheet, int ruleIndex)
		{
			StyleSheetCache.SheetHandleKey key = new StyleSheetCache.SheetHandleKey(sheet, ruleIndex);
			StylePropertyId[] array;
			bool flag = !StyleSheetCache.s_RulePropertyIdsCache.TryGetValue(key, out array);
			if (flag)
			{
				StyleRule styleRule = sheet.rules[ruleIndex];
				array = new StylePropertyId[styleRule.properties.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = StyleSheetCache.GetPropertyId(styleRule, i);
				}
				StyleSheetCache.s_RulePropertyIdsCache.Add(key, array);
			}
			return array;
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x0009A328 File Offset: 0x00098528
		internal static StylePropertyId[] GetPropertyIds(StyleRule rule)
		{
			StylePropertyId[] array = new StylePropertyId[rule.properties.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = StyleSheetCache.GetPropertyId(rule, i);
			}
			return array;
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x0009A368 File Offset: 0x00098568
		private static StylePropertyId GetPropertyId(StyleRule rule, int index)
		{
			StyleProperty styleProperty = rule.properties[index];
			string name = styleProperty.name;
			StylePropertyId result;
			bool flag = !StylePropertyUtil.s_NameToId.TryGetValue(name, out result);
			if (flag)
			{
				result = (styleProperty.isCustomProperty ? StylePropertyId.Custom : StylePropertyId.Unknown);
			}
			return result;
		}

		// Token: 0x040011AA RID: 4522
		private static StyleSheetCache.SheetHandleKeyComparer s_Comparer = new StyleSheetCache.SheetHandleKeyComparer();

		// Token: 0x040011AB RID: 4523
		private static Dictionary<StyleSheetCache.SheetHandleKey, StylePropertyId[]> s_RulePropertyIdsCache = new Dictionary<StyleSheetCache.SheetHandleKey, StylePropertyId[]>(StyleSheetCache.s_Comparer);

		// Token: 0x02000498 RID: 1176
		private struct SheetHandleKey
		{
			// Token: 0x060024C5 RID: 9413 RVA: 0x0009A3CB File Offset: 0x000985CB
			public SheetHandleKey(StyleSheet sheet, int index)
			{
				this.sheetInstanceID = sheet.GetInstanceID();
				this.index = index;
			}

			// Token: 0x040011AC RID: 4524
			public readonly int sheetInstanceID;

			// Token: 0x040011AD RID: 4525
			public readonly int index;
		}

		// Token: 0x02000499 RID: 1177
		private class SheetHandleKeyComparer : IEqualityComparer<StyleSheetCache.SheetHandleKey>
		{
			// Token: 0x060024C6 RID: 9414 RVA: 0x0009A3E4 File Offset: 0x000985E4
			public bool Equals(StyleSheetCache.SheetHandleKey x, StyleSheetCache.SheetHandleKey y)
			{
				return x.sheetInstanceID == y.sheetInstanceID && x.index == y.index;
			}

			// Token: 0x060024C7 RID: 9415 RVA: 0x0009A418 File Offset: 0x00098618
			public int GetHashCode(StyleSheetCache.SheetHandleKey key)
			{
				return key.sheetInstanceID.GetHashCode() ^ key.index.GetHashCode();
			}
		}
	}
}
