using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000D3 RID: 211
	[UnitOrder(501)]
	public abstract class Lerp<T> : Unit
	{
		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000646 RID: 1606 RVA: 0x0000C8D4 File Offset: 0x0000AAD4
		// (set) Token: 0x06000647 RID: 1607 RVA: 0x0000C8DC File Offset: 0x0000AADC
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000648 RID: 1608 RVA: 0x0000C8E5 File Offset: 0x0000AAE5
		// (set) Token: 0x06000649 RID: 1609 RVA: 0x0000C8ED File Offset: 0x0000AAED
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x0000C8F6 File Offset: 0x0000AAF6
		// (set) Token: 0x0600064B RID: 1611 RVA: 0x0000C8FE File Offset: 0x0000AAFE
		[DoNotSerialize]
		public ValueInput t { get; private set; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x0000C907 File Offset: 0x0000AB07
		// (set) Token: 0x0600064D RID: 1613 RVA: 0x0000C90F File Offset: 0x0000AB0F
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput interpolation { get; private set; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x0000C918 File Offset: 0x0000AB18
		[DoNotSerialize]
		protected virtual T defaultA
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x0000C930 File Offset: 0x0000AB30
		[DoNotSerialize]
		protected virtual T defaultB
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0000C948 File Offset: 0x0000AB48
		protected override void Definition()
		{
			this.a = base.ValueInput<T>("a", this.defaultA);
			this.b = base.ValueInput<T>("b", this.defaultB);
			this.t = base.ValueInput<float>("t", 0f);
			this.interpolation = base.ValueOutput<T>("interpolation", new Func<Flow, T>(this.Operation)).Predictable();
			base.Requirement(this.a, this.interpolation);
			base.Requirement(this.b, this.interpolation);
			base.Requirement(this.t, this.interpolation);
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0000C9F1 File Offset: 0x0000ABF1
		private T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.a), flow.GetValue<T>(this.b), flow.GetValue<float>(this.t));
		}

		// Token: 0x06000652 RID: 1618
		public abstract T Operation(T a, T b, float t);
	}
}
