using System;

namespace UnityEngine.UIElements
{
	// Token: 0x020003C4 RID: 964
	public class UxmlChildElementDescription
	{
		// Token: 0x06001FD0 RID: 8144 RVA: 0x00078C80 File Offset: 0x00076E80
		public UxmlChildElementDescription(Type t)
		{
			bool flag = t == null;
			if (flag)
			{
				throw new ArgumentNullException("t");
			}
			this.elementName = t.Name;
			this.elementNamespace = t.Namespace;
		}

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x06001FD1 RID: 8145 RVA: 0x00078CC6 File Offset: 0x00076EC6
		// (set) Token: 0x06001FD2 RID: 8146 RVA: 0x00078CCE File Offset: 0x00076ECE
		public string elementName { get; protected set; }

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x06001FD3 RID: 8147 RVA: 0x00078CD7 File Offset: 0x00076ED7
		// (set) Token: 0x06001FD4 RID: 8148 RVA: 0x00078CDF File Offset: 0x00076EDF
		public string elementNamespace { get; protected set; }
	}
}
