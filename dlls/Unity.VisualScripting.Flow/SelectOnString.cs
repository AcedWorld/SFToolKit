using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000041 RID: 65
	[UnitCategory("Control")]
	[UnitTitle("Select On String")]
	[UnitShortTitle("Select")]
	[UnitSubtitle("On String")]
	[UnitOrder(7)]
	public class SelectOnString : SelectUnit<string>
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000277 RID: 631 RVA: 0x0000739E File Offset: 0x0000559E
		// (set) Token: 0x06000278 RID: 632 RVA: 0x000073A6 File Offset: 0x000055A6
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable("Ignore Case")]
		[InspectorToggleLeft]
		public bool ignoreCase { get; set; }

		// Token: 0x06000279 RID: 633 RVA: 0x000073AF File Offset: 0x000055AF
		protected override bool Matches(string a, string b)
		{
			return (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b)) || string.Equals(a, b, this.ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		}
	}
}
