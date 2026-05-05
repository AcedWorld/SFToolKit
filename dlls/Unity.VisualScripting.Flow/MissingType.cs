using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000128 RID: 296
	[SpecialUnit]
	[UnitTitle("Node script is missing!")]
	[UnitShortTitle("Missing Script!")]
	public sealed class MissingType : Unit
	{
		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x060007AE RID: 1966 RVA: 0x0000E484 File Offset: 0x0000C684
		// (set) Token: 0x060007AF RID: 1967 RVA: 0x0000E48C File Offset: 0x0000C68C
		[Serialize]
		public string formerType { get; private set; }

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0000E495 File Offset: 0x0000C695
		// (set) Token: 0x060007B1 RID: 1969 RVA: 0x0000E49D File Offset: 0x0000C69D
		[Serialize]
		public string formerValue { get; private set; }

		// Token: 0x060007B2 RID: 1970 RVA: 0x0000E4A6 File Offset: 0x0000C6A6
		protected override void Definition()
		{
		}
	}
}
