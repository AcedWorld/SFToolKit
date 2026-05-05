using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000D6 RID: 214
	[UnitOrder(105)]
	public abstract class Modulo<T> : Unit
	{
		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x0000CC0E File Offset: 0x0000AE0E
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x0000CC16 File Offset: 0x0000AE16
		[DoNotSerialize]
		[PortLabel("A")]
		public ValueInput dividend { get; private set; }

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x0000CC1F File Offset: 0x0000AE1F
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x0000CC27 File Offset: 0x0000AE27
		[DoNotSerialize]
		[PortLabel("B")]
		public ValueInput divisor { get; private set; }

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x0000CC30 File Offset: 0x0000AE30
		// (set) Token: 0x06000667 RID: 1639 RVA: 0x0000CC38 File Offset: 0x0000AE38
		[DoNotSerialize]
		[PortLabel("A % B")]
		public ValueOutput remainder { get; private set; }

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x0000CC44 File Offset: 0x0000AE44
		[DoNotSerialize]
		protected virtual T defaultDivisor
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		[DoNotSerialize]
		protected virtual T defaultDividend
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0000CC74 File Offset: 0x0000AE74
		protected override void Definition()
		{
			this.dividend = base.ValueInput<T>("dividend", this.defaultDividend);
			this.divisor = base.ValueInput<T>("divisor", this.defaultDivisor);
			this.remainder = base.ValueOutput<T>("remainder", new Func<Flow, T>(this.Operation)).Predictable();
			base.Requirement(this.dividend, this.remainder);
			base.Requirement(this.divisor, this.remainder);
		}

		// Token: 0x0600066B RID: 1643
		public abstract T Operation(T divident, T divisor);

		// Token: 0x0600066C RID: 1644 RVA: 0x0000CCF5 File Offset: 0x0000AEF5
		public T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.dividend), flow.GetValue<T>(this.divisor));
		}
	}
}
