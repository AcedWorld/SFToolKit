using System;
using System.Collections.Generic;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements
{
	// Token: 0x02000416 RID: 1046
	internal class StyleMatchingContext
	{
		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x06002155 RID: 8533 RVA: 0x0007E00B File Offset: 0x0007C20B
		public int styleSheetCount
		{
			get
			{
				return this.m_StyleSheetStack.Count;
			}
		}

		// Token: 0x06002156 RID: 8534 RVA: 0x0007E018 File Offset: 0x0007C218
		public StyleMatchingContext(Action<VisualElement, MatchResultInfo> processResult)
		{
			this.m_StyleSheetStack = new List<StyleSheet>();
			this.variableContext = StyleVariableContext.none;
			this.currentElement = null;
			this.processResult = processResult;
		}

		// Token: 0x06002157 RID: 8535 RVA: 0x0007E054 File Offset: 0x0007C254
		public void AddStyleSheet(StyleSheet sheet)
		{
			bool flag = sheet == null;
			if (!flag)
			{
				this.m_StyleSheetStack.Add(sheet);
			}
		}

		// Token: 0x06002158 RID: 8536 RVA: 0x0007E07C File Offset: 0x0007C27C
		public void RemoveStyleSheetRange(int index, int count)
		{
			this.m_StyleSheetStack.RemoveRange(index, count);
		}

		// Token: 0x06002159 RID: 8537 RVA: 0x0007E090 File Offset: 0x0007C290
		public StyleSheet GetStyleSheetAt(int index)
		{
			return this.m_StyleSheetStack[index];
		}

		// Token: 0x04000E26 RID: 3622
		private List<StyleSheet> m_StyleSheetStack;

		// Token: 0x04000E27 RID: 3623
		public StyleVariableContext variableContext;

		// Token: 0x04000E28 RID: 3624
		public VisualElement currentElement;

		// Token: 0x04000E29 RID: 3625
		public Action<VisualElement, MatchResultInfo> processResult;

		// Token: 0x04000E2A RID: 3626
		public AncestorFilter ancestorFilter = new AncestorFilter();
	}
}
