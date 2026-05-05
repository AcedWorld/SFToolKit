using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000DC RID: 220
	[UnitOrder(202)]
	public abstract class Round<TInput, TOutput> : Unit
	{
		// Token: 0x1700026D RID: 621
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x0000D185 File Offset: 0x0000B385
		// (set) Token: 0x060006A4 RID: 1700 RVA: 0x0000D18D File Offset: 0x0000B38D
		[Inspectable]
		[UnitHeaderInspectable]
		[Serialize]
		public Round<TInput, TOutput>.Rounding rounding { get; set; } = Round<TInput, TOutput>.Rounding.AwayFromZero;

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x0000D196 File Offset: 0x0000B396
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x0000D19E File Offset: 0x0000B39E
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput input { get; private set; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x0000D1A7 File Offset: 0x0000B3A7
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x0000D1AF File Offset: 0x0000B3AF
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput output { get; private set; }

		// Token: 0x060006A9 RID: 1705 RVA: 0x0000D1B8 File Offset: 0x0000B3B8
		protected override void Definition()
		{
			this.input = base.ValueInput<TInput>("input");
			this.output = base.ValueOutput<TOutput>("output", new Func<Flow, TOutput>(this.Operation)).Predictable();
			base.Requirement(this.input, this.output);
		}

		// Token: 0x060006AA RID: 1706
		protected abstract TOutput Floor(TInput input);

		// Token: 0x060006AB RID: 1707
		protected abstract TOutput AwayFromZero(TInput input);

		// Token: 0x060006AC RID: 1708
		protected abstract TOutput Ceiling(TInput input);

		// Token: 0x060006AD RID: 1709 RVA: 0x0000D20C File Offset: 0x0000B40C
		public TOutput Operation(Flow flow)
		{
			switch (this.rounding)
			{
			case Round<TInput, TOutput>.Rounding.Floor:
				return this.Floor(flow.GetValue<TInput>(this.input));
			case Round<TInput, TOutput>.Rounding.Ceiling:
				return this.Ceiling(flow.GetValue<TInput>(this.input));
			case Round<TInput, TOutput>.Rounding.AwayFromZero:
				return this.AwayFromZero(flow.GetValue<TInput>(this.input));
			default:
				throw new UnexpectedEnumValueException<Round<TInput, TOutput>.Rounding>(this.rounding);
			}
		}

		// Token: 0x020001B8 RID: 440
		public enum Rounding
		{
			// Token: 0x040003AC RID: 940
			Floor,
			// Token: 0x040003AD RID: 941
			Ceiling,
			// Token: 0x040003AE RID: 942
			AwayFromZero
		}
	}
}
