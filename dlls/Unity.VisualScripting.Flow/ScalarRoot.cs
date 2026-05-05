using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000EA RID: 234
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Root")]
	[UnitOrder(106)]
	public sealed class ScalarRoot : Unit
	{
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x0000D487 File Offset: 0x0000B687
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x0000D48F File Offset: 0x0000B68F
		[DoNotSerialize]
		[PortLabel("x")]
		public ValueInput radicand { get; private set; }

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x0000D498 File Offset: 0x0000B698
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x0000D4A0 File Offset: 0x0000B6A0
		[DoNotSerialize]
		[PortLabel("n")]
		public ValueInput degree { get; private set; }

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x0000D4A9 File Offset: 0x0000B6A9
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x0000D4B1 File Offset: 0x0000B6B1
		[DoNotSerialize]
		[PortLabel("ⁿ√x")]
		public ValueOutput root { get; private set; }

		// Token: 0x060006E3 RID: 1763 RVA: 0x0000D4BC File Offset: 0x0000B6BC
		protected override void Definition()
		{
			this.radicand = base.ValueInput<float>("radicand", 1f);
			this.degree = base.ValueInput<float>("degree", 2f);
			this.root = base.ValueOutput<float>("root", new Func<Flow, float>(this.Root));
			base.Requirement(this.radicand, this.root);
			base.Requirement(this.degree, this.root);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0000D538 File Offset: 0x0000B738
		public float Root(Flow flow)
		{
			float value = flow.GetValue<float>(this.degree);
			float value2 = flow.GetValue<float>(this.radicand);
			if (value == 2f)
			{
				return Mathf.Sqrt(value2);
			}
			return Mathf.Pow(value2, 1f / value);
		}
	}
}
