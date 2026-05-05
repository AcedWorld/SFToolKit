using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x0200039C RID: 924
	public class UxmlStyleTraits : UxmlTraits
	{
		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x06001F10 RID: 7952 RVA: 0x00077334 File Offset: 0x00075534
		public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
		{
			get
			{
				yield break;
			}
		}

		// Token: 0x04000CD5 RID: 3285
		private UxmlStringAttributeDescription m_Name = new UxmlStringAttributeDescription
		{
			name = "name"
		};

		// Token: 0x04000CD6 RID: 3286
		private UxmlStringAttributeDescription m_Path = new UxmlStringAttributeDescription
		{
			name = "path"
		};

		// Token: 0x04000CD7 RID: 3287
		private UxmlStringAttributeDescription m_Src = new UxmlStringAttributeDescription
		{
			name = "src"
		};
	}
}
