using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200039F RID: 927
	public class UxmlTemplateTraits : UxmlTraits
	{
		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x06001F21 RID: 7969 RVA: 0x00077480 File Offset: 0x00075680
		public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
		{
			get
			{
				yield break;
			}
		}

		// Token: 0x04000CDD RID: 3293
		private UxmlStringAttributeDescription m_Name = new UxmlStringAttributeDescription
		{
			name = "name",
			use = UxmlAttributeDescription.Use.Required
		};

		// Token: 0x04000CDE RID: 3294
		private UxmlStringAttributeDescription m_Path = new UxmlStringAttributeDescription
		{
			name = "path"
		};

		// Token: 0x04000CDF RID: 3295
		private UxmlStringAttributeDescription m_Src = new UxmlStringAttributeDescription
		{
			name = "src"
		};
	}
}
