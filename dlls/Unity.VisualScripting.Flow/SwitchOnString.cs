using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000047 RID: 71
	[UnitCategory("Control")]
	[UnitTitle("Switch On String")]
	[UnitShortTitle("Switch")]
	[UnitSubtitle("On String")]
	[UnitOrder(4)]
	public class SwitchOnString : SwitchUnit<string>
	{
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00007A39 File Offset: 0x00005C39
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x00007A41 File Offset: 0x00005C41
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable("Ignore Case")]
		[InspectorToggleLeft]
		public bool ignoreCase { get; set; }

		// Token: 0x060002B2 RID: 690 RVA: 0x00007A4A File Offset: 0x00005C4A
		protected override bool Matches(string a, string b)
		{
			return (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b)) || string.Equals(a, b, this.ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		}
	}
}
