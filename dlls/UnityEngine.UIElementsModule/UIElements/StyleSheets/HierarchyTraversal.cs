using System;

namespace UnityEngine.UIElements.StyleSheets
{
	// Token: 0x02000481 RID: 1153
	internal abstract class HierarchyTraversal
	{
		// Token: 0x060023DD RID: 9181 RVA: 0x00092697 File Offset: 0x00090897
		public virtual void Traverse(VisualElement element)
		{
			this.TraverseRecursive(element, 0);
		}

		// Token: 0x060023DE RID: 9182
		public abstract void TraverseRecursive(VisualElement element, int depth);

		// Token: 0x060023DF RID: 9183 RVA: 0x000926A4 File Offset: 0x000908A4
		protected void Recurse(VisualElement element, int depth)
		{
			int i = 0;
			while (i < element.hierarchy.childCount)
			{
				VisualElement visualElement = element.hierarchy[i];
				this.TraverseRecursive(visualElement, depth + 1);
				bool flag = visualElement.hierarchy.parent != element;
				if (!flag)
				{
					i++;
				}
			}
		}
	}
}
