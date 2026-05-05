using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200040D RID: 1037
	internal static class VisualElementUtils
	{
		// Token: 0x06002122 RID: 8482 RVA: 0x0007D494 File Offset: 0x0007B694
		public static string GetUniqueName(string nameBase)
		{
			string text = nameBase;
			int num = 2;
			while (VisualElementUtils.s_usedNames.Contains(text))
			{
				text = nameBase + num.ToString();
				num++;
			}
			VisualElementUtils.s_usedNames.Add(text);
			return text;
		}

		// Token: 0x06002123 RID: 8483 RVA: 0x0007D4DC File Offset: 0x0007B6DC
		internal static int GetFoldoutDepth(this VisualElement element)
		{
			int num = 0;
			bool flag = element.parent != null;
			if (flag)
			{
				for (VisualElement parent = element.parent; parent != null; parent = parent.parent)
				{
					bool flag2 = VisualElementUtils.s_FoldoutType.IsAssignableFrom(parent.GetType());
					if (flag2)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06002124 RID: 8484 RVA: 0x0007D538 File Offset: 0x0007B738
		internal static void AssignInspectorStyleIfNecessary(this VisualElement element, string classNameToEnable)
		{
			VisualElement firstAncestorWhere = element.GetFirstAncestorWhere((VisualElement i) => i.ClassListContains(VisualElementUtils.s_InspectorElementUssClassName));
			element.EnableInClassList(classNameToEnable, firstAncestorWhere != null);
		}

		// Token: 0x04000DFD RID: 3581
		private static readonly HashSet<string> s_usedNames = new HashSet<string>();

		// Token: 0x04000DFE RID: 3582
		private static readonly Type s_FoldoutType = typeof(Foldout);

		// Token: 0x04000DFF RID: 3583
		private static readonly string s_InspectorElementUssClassName = "unity-inspector-element";
	}
}
