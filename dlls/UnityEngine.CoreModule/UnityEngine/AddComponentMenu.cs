using System;

namespace UnityEngine
{
	// Token: 0x0200022B RID: 555
	public sealed class AddComponentMenu : Attribute
	{
		// Token: 0x06001844 RID: 6212 RVA: 0x000284BE File Offset: 0x000266BE
		public AddComponentMenu(string menuName)
		{
			this.m_AddComponentMenu = menuName;
			this.m_Ordering = 0;
		}

		// Token: 0x06001845 RID: 6213 RVA: 0x000284D6 File Offset: 0x000266D6
		public AddComponentMenu(string menuName, int order)
		{
			this.m_AddComponentMenu = menuName;
			this.m_Ordering = order;
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06001846 RID: 6214 RVA: 0x000284F0 File Offset: 0x000266F0
		public string componentMenu
		{
			get
			{
				return this.m_AddComponentMenu;
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06001847 RID: 6215 RVA: 0x00028508 File Offset: 0x00026708
		public int componentOrder
		{
			get
			{
				return this.m_Ordering;
			}
		}

		// Token: 0x0400088E RID: 2190
		private string m_AddComponentMenu;

		// Token: 0x0400088F RID: 2191
		private int m_Ordering;
	}
}
