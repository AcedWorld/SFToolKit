using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000399 RID: 921
	public class UxmlRootElementTraits : UxmlTraits
	{
		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x06001EFF RID: 7935 RVA: 0x000771A0 File Offset: 0x000753A0
		public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
		{
			get
			{
				yield return new UxmlChildElementDescription(typeof(VisualElement));
				yield break;
			}
		}

		// Token: 0x04000CCE RID: 3278
		protected UxmlStringAttributeDescription m_Name = new UxmlStringAttributeDescription
		{
			name = "name"
		};

		// Token: 0x04000CCF RID: 3279
		private UxmlStringAttributeDescription m_Class = new UxmlStringAttributeDescription
		{
			name = "class"
		};
	}
}
