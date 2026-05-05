using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000C1 RID: 193
	[UnitCategory("Logic")]
	[UnitShortTitle("Not Equal")]
	[UnitSubtitle("(Approximately)")]
	[UnitOrder(8)]
	[Obsolete("Use the Not Equal node with Numeric enabled instead.")]
	public sealed class NotApproximatelyEqual : Unit
	{
		// Token: 0x17000227 RID: 551
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x0000BCAB File Offset: 0x00009EAB
		// (set) Token: 0x060005C0 RID: 1472 RVA: 0x0000BCB3 File Offset: 0x00009EB3
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x0000BCBC File Offset: 0x00009EBC
		// (set) Token: 0x060005C2 RID: 1474 RVA: 0x0000BCC4 File Offset: 0x00009EC4
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x0000BCCD File Offset: 0x00009ECD
		// (set) Token: 0x060005C4 RID: 1476 RVA: 0x0000BCD5 File Offset: 0x00009ED5
		[DoNotSerialize]
		[PortLabel("A ≉ B")]
		public ValueOutput notEqual { get; private set; }

		// Token: 0x060005C5 RID: 1477 RVA: 0x0000BCE0 File Offset: 0x00009EE0
		protected override void Definition()
		{
			this.a = base.ValueInput<float>("a");
			this.b = base.ValueInput<float>("b", 0f);
			this.notEqual = base.ValueOutput<bool>("notEqual", new Func<Flow, bool>(this.Comparison)).Predictable();
			base.Requirement(this.a, this.notEqual);
			base.Requirement(this.b, this.notEqual);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0000BD5A File Offset: 0x00009F5A
		public bool Comparison(Flow flow)
		{
			return !Mathf.Approximately(flow.GetValue<float>(this.a), flow.GetValue<float>(this.b));
		}
	}
}
