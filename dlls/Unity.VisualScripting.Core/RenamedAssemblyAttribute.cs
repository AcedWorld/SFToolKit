using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000125 RID: 293
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public sealed class RenamedAssemblyAttribute : Attribute
	{
		// Token: 0x060007AE RID: 1966 RVA: 0x0002286F File Offset: 0x00020A6F
		public RenamedAssemblyAttribute(string previousName, string newName)
		{
			this.previousName = previousName;
			this.newName = newName;
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060007AF RID: 1967 RVA: 0x00022885 File Offset: 0x00020A85
		public string previousName { get; }

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0002288D File Offset: 0x00020A8D
		public string newName { get; }
	}
}
