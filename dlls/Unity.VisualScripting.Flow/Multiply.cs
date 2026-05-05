using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000D8 RID: 216
	[UnitOrder(103)]
	public abstract class Multiply<T> : Unit
	{
		// Token: 0x17000262 RID: 610
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x0000CE9C File Offset: 0x0000B09C
		// (set) Token: 0x0600067F RID: 1663 RVA: 0x0000CEA4 File Offset: 0x0000B0A4
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x0000CEAD File Offset: 0x0000B0AD
		// (set) Token: 0x06000681 RID: 1665 RVA: 0x0000CEB5 File Offset: 0x0000B0B5
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x0000CEBE File Offset: 0x0000B0BE
		// (set) Token: 0x06000683 RID: 1667 RVA: 0x0000CEC6 File Offset: 0x0000B0C6
		[DoNotSerialize]
		[PortLabel("A × B")]
		public ValueOutput product { get; private set; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x0000CED0 File Offset: 0x0000B0D0
		[DoNotSerialize]
		protected virtual T defaultB
		{
			get
			{
				return default(T);
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0000CEE8 File Offset: 0x0000B0E8
		protected override void Definition()
		{
			this.a = base.ValueInput<T>("a");
			this.b = base.ValueInput<T>("b", this.defaultB);
			this.product = base.ValueOutput<T>("product", new Func<Flow, T>(this.Operation)).Predictable();
			base.Requirement(this.a, this.product);
			base.Requirement(this.b, this.product);
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0000CF63 File Offset: 0x0000B163
		private T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.a), flow.GetValue<T>(this.b));
		}

		// Token: 0x06000687 RID: 1671
		public abstract T Operation(T a, T b);
	}
}
