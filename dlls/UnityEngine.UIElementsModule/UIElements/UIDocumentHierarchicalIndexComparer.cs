using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200025A RID: 602
	internal class UIDocumentHierarchicalIndexComparer : IComparer<UIDocumentHierarchicalIndex>
	{
		// Token: 0x06001145 RID: 4421 RVA: 0x0003E8B8 File Offset: 0x0003CAB8
		public int Compare(UIDocumentHierarchicalIndex x, UIDocumentHierarchicalIndex y)
		{
			return x.CompareTo(y);
		}
	}
}
