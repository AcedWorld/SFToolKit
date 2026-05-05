using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x020003A2 RID: 930
	public class UxmlAttributeOverridesTraits : UxmlTraits
	{
		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x06001F32 RID: 7986 RVA: 0x000775D4 File Offset: 0x000757D4
		public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
		{
			get
			{
				yield break;
			}
		}

		// Token: 0x04000CE5 RID: 3301
		internal const string k_ElementNameAttributeName = "element-name";

		// Token: 0x04000CE6 RID: 3302
		private UxmlStringAttributeDescription m_ElementName = new UxmlStringAttributeDescription
		{
			name = "element-name",
			use = UxmlAttributeDescription.Use.Required
		};
	}
}
