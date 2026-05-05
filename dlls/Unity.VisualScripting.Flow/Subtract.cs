using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000EE RID: 238
	[UnitOrder(102)]
	public abstract class Subtract<T> : Unit
	{
		// Token: 0x17000283 RID: 643
		// (get) Token: 0x060006F2 RID: 1778 RVA: 0x0000D5DA File Offset: 0x0000B7DA
		// (set) Token: 0x060006F3 RID: 1779 RVA: 0x0000D5E2 File Offset: 0x0000B7E2
		[DoNotSerialize]
		[PortLabel("A")]
		public ValueInput minuend { get; private set; }

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x060006F4 RID: 1780 RVA: 0x0000D5EB File Offset: 0x0000B7EB
		// (set) Token: 0x060006F5 RID: 1781 RVA: 0x0000D5F3 File Offset: 0x0000B7F3
		[DoNotSerialize]
		[PortLabel("B")]
		public ValueInput subtrahend { get; private set; }

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x060006F6 RID: 1782 RVA: 0x0000D5FC File Offset: 0x0000B7FC
		// (set) Token: 0x060006F7 RID: 1783 RVA: 0x0000D604 File Offset: 0x0000B804
		[DoNotSerialize]
		[PortLabel("A − B")]
		public ValueOutput difference { get; private set; }

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x060006F8 RID: 1784 RVA: 0x0000D610 File Offset: 0x0000B810
		[DoNotSerialize]
		protected virtual T defaultMinuend
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x0000D628 File Offset: 0x0000B828
		[DoNotSerialize]
		protected virtual T defaultSubtrahend
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0000D640 File Offset: 0x0000B840
		protected override void Definition()
		{
			this.minuend = base.ValueInput<T>("minuend", this.defaultMinuend);
			this.subtrahend = base.ValueInput<T>("subtrahend", this.defaultSubtrahend);
			this.difference = base.ValueOutput<T>("difference", new Func<Flow, T>(this.Operation)).Predictable();
			base.Requirement(this.minuend, this.difference);
			base.Requirement(this.subtrahend, this.difference);
		}

		// Token: 0x060006FB RID: 1787
		public abstract T Operation(T a, T b);

		// Token: 0x060006FC RID: 1788 RVA: 0x0000D6C1 File Offset: 0x0000B8C1
		public T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.minuend), flow.GetValue<T>(this.subtrahend));
		}
	}
}
