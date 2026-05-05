using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000C6 RID: 198
	[UnitOrder(101)]
	public abstract class Add<T> : Unit
	{
		// Token: 0x17000238 RID: 568
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x0000C1EE File Offset: 0x0000A3EE
		// (set) Token: 0x060005F4 RID: 1524 RVA: 0x0000C1F6 File Offset: 0x0000A3F6
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0000C1FF File Offset: 0x0000A3FF
		// (set) Token: 0x060005F6 RID: 1526 RVA: 0x0000C207 File Offset: 0x0000A407
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x0000C210 File Offset: 0x0000A410
		// (set) Token: 0x060005F8 RID: 1528 RVA: 0x0000C218 File Offset: 0x0000A418
		[DoNotSerialize]
		[PortLabel("A + B")]
		public ValueOutput sum { get; private set; }

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x0000C224 File Offset: 0x0000A424
		[DoNotSerialize]
		protected virtual T defaultB
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0000C23C File Offset: 0x0000A43C
		protected override void Definition()
		{
			this.a = base.ValueInput<T>("a");
			this.b = base.ValueInput<T>("b", this.defaultB);
			this.sum = base.ValueOutput<T>("sum", new Func<Flow, T>(this.Operation)).Predictable();
			base.Requirement(this.a, this.sum);
			base.Requirement(this.b, this.sum);
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0000C2B7 File Offset: 0x0000A4B7
		private T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.a), flow.GetValue<T>(this.b));
		}

		// Token: 0x060005FC RID: 1532
		public abstract T Operation(T a, T b);
	}
}
