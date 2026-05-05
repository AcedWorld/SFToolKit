using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000414 RID: 1044
	internal static class StyleCache
	{
		// Token: 0x06002142 RID: 8514 RVA: 0x0007DBF4 File Offset: 0x0007BDF4
		public static bool TryGetValue(long hash, out ComputedStyle data)
		{
			return StyleCache.s_ComputedStyleCache.TryGetValue(hash, out data);
		}

		// Token: 0x06002143 RID: 8515 RVA: 0x0007DC12 File Offset: 0x0007BE12
		public static void SetValue(long hash, ref ComputedStyle data)
		{
			StyleCache.s_ComputedStyleCache[hash] = data;
		}

		// Token: 0x06002144 RID: 8516 RVA: 0x0007DC28 File Offset: 0x0007BE28
		public static bool TryGetValue(int hash, out StyleVariableContext data)
		{
			return StyleCache.s_StyleVariableContextCache.TryGetValue(hash, out data);
		}

		// Token: 0x06002145 RID: 8517 RVA: 0x0007DC46 File Offset: 0x0007BE46
		public static void SetValue(int hash, StyleVariableContext data)
		{
			StyleCache.s_StyleVariableContextCache[hash] = data;
		}

		// Token: 0x06002146 RID: 8518 RVA: 0x0007DC58 File Offset: 0x0007BE58
		public static bool TryGetValue(int hash, out ComputedTransitionProperty[] data)
		{
			return StyleCache.s_ComputedTransitionsCache.TryGetValue(hash, out data);
		}

		// Token: 0x06002147 RID: 8519 RVA: 0x0007DC76 File Offset: 0x0007BE76
		public static void SetValue(int hash, ComputedTransitionProperty[] data)
		{
			StyleCache.s_ComputedTransitionsCache[hash] = data;
		}

		// Token: 0x06002148 RID: 8520 RVA: 0x0007DC88 File Offset: 0x0007BE88
		public static void ClearStyleCache()
		{
			foreach (KeyValuePair<long, ComputedStyle> keyValuePair in StyleCache.s_ComputedStyleCache)
			{
				keyValuePair.Value.Release();
			}
			StyleCache.s_ComputedStyleCache.Clear();
			StyleCache.s_StyleVariableContextCache.Clear();
			StyleCache.s_ComputedTransitionsCache.Clear();
		}

		// Token: 0x04000E1A RID: 3610
		private static Dictionary<long, ComputedStyle> s_ComputedStyleCache = new Dictionary<long, ComputedStyle>();

		// Token: 0x04000E1B RID: 3611
		private static Dictionary<int, StyleVariableContext> s_StyleVariableContextCache = new Dictionary<int, StyleVariableContext>();

		// Token: 0x04000E1C RID: 3612
		private static Dictionary<int, ComputedTransitionProperty[]> s_ComputedTransitionsCache = new Dictionary<int, ComputedTransitionProperty[]>();
	}
}
