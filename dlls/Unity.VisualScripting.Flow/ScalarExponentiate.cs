using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000E1 RID: 225
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Exponentiate")]
	[UnitOrder(105)]
	public sealed class ScalarExponentiate : Unit
	{
		// Token: 0x17000273 RID: 627
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x0000D2E1 File Offset: 0x0000B4E1
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x0000D2E9 File Offset: 0x0000B4E9
		[DoNotSerialize]
		[PortLabel("x")]
		public ValueInput @base { get; private set; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x0000D2F2 File Offset: 0x0000B4F2
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x0000D2FA File Offset: 0x0000B4FA
		[DoNotSerialize]
		[PortLabel("n")]
		public ValueInput exponent { get; private set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x0000D303 File Offset: 0x0000B503
		// (set) Token: 0x060006C0 RID: 1728 RVA: 0x0000D30B File Offset: 0x0000B50B
		[DoNotSerialize]
		[PortLabel("xⁿ")]
		public ValueOutput power { get; private set; }

		// Token: 0x060006C1 RID: 1729 RVA: 0x0000D314 File Offset: 0x0000B514
		protected override void Definition()
		{
			this.@base = base.ValueInput<float>("base", 1f);
			this.exponent = base.ValueInput<float>("exponent", 2f);
			this.power = base.ValueOutput<float>("power", new Func<Flow, float>(this.Exponentiate));
			base.Requirement(this.@base, this.power);
			base.Requirement(this.exponent, this.power);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0000D38E File Offset: 0x0000B58E
		public float Exponentiate(Flow flow)
		{
			return Mathf.Pow(flow.GetValue<float>(this.@base), flow.GetValue<float>(this.exponent));
		}
	}
}
