using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000126 RID: 294
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public sealed class RenamedFromAttribute : Attribute
	{
		// Token: 0x060007B1 RID: 1969 RVA: 0x00022895 File Offset: 0x00020A95
		public RenamedFromAttribute(string previousName)
		{
			this.previousName = previousName;
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060007B2 RID: 1970 RVA: 0x000228A4 File Offset: 0x00020AA4
		public string previousName { get; }
	}
}
