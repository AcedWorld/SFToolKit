using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000037 RID: 55
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
	public sealed class IncludeInSettingsAttribute : Attribute
	{
		// Token: 0x060001BA RID: 442 RVA: 0x00004D83 File Offset: 0x00002F83
		public IncludeInSettingsAttribute(bool include)
		{
			this.include = include;
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00004D92 File Offset: 0x00002F92
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00004D9A File Offset: 0x00002F9A
		public bool include { get; private set; }
	}
}
