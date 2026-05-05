using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000127 RID: 295
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public sealed class RenamedNamespaceAttribute : Attribute
	{
		// Token: 0x060007B3 RID: 1971 RVA: 0x000228AC File Offset: 0x00020AAC
		public RenamedNamespaceAttribute(string previousName, string newName)
		{
			this.previousName = previousName;
			this.newName = newName;
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060007B4 RID: 1972 RVA: 0x000228C2 File Offset: 0x00020AC2
		public string previousName { get; }

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x000228CA File Offset: 0x00020ACA
		public string newName { get; }
	}
}
