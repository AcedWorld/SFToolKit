using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000032 RID: 50
	[AttributeUsage(AttributeTargets.Class)]
	public class DisableAnnotationAttribute : Attribute
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00004CC3 File Offset: 0x00002EC3
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x00004CCB File Offset: 0x00002ECB
		public bool disableIcon { get; set; } = true;

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00004CD4 File Offset: 0x00002ED4
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x00004CDC File Offset: 0x00002EDC
		public bool disableGizmo { get; set; }
	}
}
