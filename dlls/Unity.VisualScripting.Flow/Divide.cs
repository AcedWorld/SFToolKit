using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000CB RID: 203
	[UnitOrder(104)]
	public abstract class Divide<T> : Unit
	{
		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x0000C649 File Offset: 0x0000A849
		// (set) Token: 0x06000624 RID: 1572 RVA: 0x0000C651 File Offset: 0x0000A851
		[DoNotSerialize]
		[PortLabel("A")]
		public ValueInput dividend { get; private set; }

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x0000C65A File Offset: 0x0000A85A
		// (set) Token: 0x06000626 RID: 1574 RVA: 0x0000C662 File Offset: 0x0000A862
		[DoNotSerialize]
		[PortLabel("B")]
		public ValueInput divisor { get; private set; }

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x0000C66B File Offset: 0x0000A86B
		// (set) Token: 0x06000628 RID: 1576 RVA: 0x0000C673 File Offset: 0x0000A873
		[DoNotSerialize]
		[PortLabel("A ÷ B")]
		public ValueOutput quotient { get; private set; }

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x0000C67C File Offset: 0x0000A87C
		[DoNotSerialize]
		protected virtual T defaultDivisor
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x0000C694 File Offset: 0x0000A894
		[DoNotSerialize]
		protected virtual T defaultDividend
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0000C6AC File Offset: 0x0000A8AC
		protected override void Definition()
		{
			this.dividend = base.ValueInput<T>("dividend", this.defaultDividend);
			this.divisor = base.ValueInput<T>("divisor", this.defaultDivisor);
			this.quotient = base.ValueOutput<T>("quotient", new Func<Flow, T>(this.Operation)).Predictable();
			base.Requirement(this.dividend, this.quotient);
			base.Requirement(this.divisor, this.quotient);
		}

		// Token: 0x0600062C RID: 1580
		public abstract T Operation(T divident, T divisor);

		// Token: 0x0600062D RID: 1581 RVA: 0x0000C72D File Offset: 0x0000A92D
		public T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.dividend), flow.GetValue<T>(this.divisor));
		}
	}
}
