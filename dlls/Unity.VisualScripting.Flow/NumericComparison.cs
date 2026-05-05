using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000C3 RID: 195
	[UnitCategory("Logic")]
	[UnitTitle("Numeric Comparison")]
	[UnitSurtitle("Numeric")]
	[UnitShortTitle("Comparison")]
	[UnitOrder(99)]
	[Obsolete("Use the Comparison node with Numeric enabled instead.")]
	public sealed class NumericComparison : Unit
	{
		// Token: 0x1700022C RID: 556
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0000BDB7 File Offset: 0x00009FB7
		// (set) Token: 0x060005CE RID: 1486 RVA: 0x0000BDBF File Offset: 0x00009FBF
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x0000BDC8 File Offset: 0x00009FC8
		// (set) Token: 0x060005D0 RID: 1488 RVA: 0x0000BDD0 File Offset: 0x00009FD0
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x0000BDD9 File Offset: 0x00009FD9
		// (set) Token: 0x060005D2 RID: 1490 RVA: 0x0000BDE1 File Offset: 0x00009FE1
		[DoNotSerialize]
		[PortLabel("A < B")]
		public ValueOutput aLessThanB { get; private set; }

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0000BDEA File Offset: 0x00009FEA
		// (set) Token: 0x060005D4 RID: 1492 RVA: 0x0000BDF2 File Offset: 0x00009FF2
		[DoNotSerialize]
		[PortLabel("A ≤ B")]
		public ValueOutput aLessThanOrEqualToB { get; private set; }

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x0000BDFB File Offset: 0x00009FFB
		// (set) Token: 0x060005D6 RID: 1494 RVA: 0x0000BE03 File Offset: 0x0000A003
		[DoNotSerialize]
		[PortLabel("A = B")]
		public ValueOutput aEqualToB { get; private set; }

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x0000BE0C File Offset: 0x0000A00C
		// (set) Token: 0x060005D8 RID: 1496 RVA: 0x0000BE14 File Offset: 0x0000A014
		[DoNotSerialize]
		[PortLabel("A ≥ B")]
		public ValueOutput aGreaterThanOrEqualToB { get; private set; }

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x0000BE1D File Offset: 0x0000A01D
		// (set) Token: 0x060005DA RID: 1498 RVA: 0x0000BE25 File Offset: 0x0000A025
		[DoNotSerialize]
		[PortLabel("A > B")]
		public ValueOutput aGreatherThanB { get; private set; }

		// Token: 0x060005DB RID: 1499 RVA: 0x0000BE30 File Offset: 0x0000A030
		protected override void Definition()
		{
			this.a = base.ValueInput<float>("a");
			this.b = base.ValueInput<float>("b", 0f);
			this.aLessThanB = base.ValueOutput<bool>("aLessThanB", new Func<Flow, bool>(this.Less)).Predictable();
			this.aLessThanOrEqualToB = base.ValueOutput<bool>("aLessThanOrEqualToB", new Func<Flow, bool>(this.LessOrEqual)).Predictable();
			this.aEqualToB = base.ValueOutput<bool>("aEqualToB", new Func<Flow, bool>(this.Equal)).Predictable();
			this.aGreaterThanOrEqualToB = base.ValueOutput<bool>("aGreaterThanOrEqualToB", new Func<Flow, bool>(this.GreaterOrEqual)).Predictable();
			this.aGreatherThanB = base.ValueOutput<bool>("aGreatherThanB", new Func<Flow, bool>(this.Greater)).Predictable();
			base.Requirement(this.a, this.aLessThanB);
			base.Requirement(this.b, this.aLessThanB);
			base.Requirement(this.a, this.aLessThanOrEqualToB);
			base.Requirement(this.b, this.aLessThanOrEqualToB);
			base.Requirement(this.a, this.aEqualToB);
			base.Requirement(this.b, this.aEqualToB);
			base.Requirement(this.a, this.aGreaterThanOrEqualToB);
			base.Requirement(this.b, this.aGreaterThanOrEqualToB);
			base.Requirement(this.a, this.aGreatherThanB);
			base.Requirement(this.b, this.aGreatherThanB);
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0000BFC2 File Offset: 0x0000A1C2
		private bool Less(Flow flow)
		{
			return flow.GetValue<float>(this.a) < flow.GetValue<float>(this.b);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0000BFE0 File Offset: 0x0000A1E0
		private bool LessOrEqual(Flow flow)
		{
			float value = flow.GetValue<float>(this.a);
			float value2 = flow.GetValue<float>(this.b);
			return value < value2 || Mathf.Approximately(value, value2);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0000C014 File Offset: 0x0000A214
		private bool Equal(Flow flow)
		{
			return Mathf.Approximately(flow.GetValue<float>(this.a), flow.GetValue<float>(this.b));
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0000C034 File Offset: 0x0000A234
		private bool GreaterOrEqual(Flow flow)
		{
			float value = flow.GetValue<float>(this.a);
			float value2 = flow.GetValue<float>(this.b);
			return value > value2 || Mathf.Approximately(value, value2);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0000C068 File Offset: 0x0000A268
		private bool Greater(Flow flow)
		{
			return flow.GetValue<float>(this.a) < flow.GetValue<float>(this.b);
		}
	}
}
