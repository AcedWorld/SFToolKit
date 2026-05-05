using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000B7 RID: 183
	[UnitCategory("Logic")]
	public abstract class BinaryComparisonUnit : Unit
	{
		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x0000B275 File Offset: 0x00009475
		// (set) Token: 0x06000554 RID: 1364 RVA: 0x0000B27D File Offset: 0x0000947D
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x0000B286 File Offset: 0x00009486
		// (set) Token: 0x06000556 RID: 1366 RVA: 0x0000B28E File Offset: 0x0000948E
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x0000B297 File Offset: 0x00009497
		// (set) Token: 0x06000558 RID: 1368 RVA: 0x0000B29F File Offset: 0x0000949F
		[DoNotSerialize]
		public virtual ValueOutput comparison { get; private set; }

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x0000B2A8 File Offset: 0x000094A8
		// (set) Token: 0x0600055A RID: 1370 RVA: 0x0000B2B0 File Offset: 0x000094B0
		[Serialize]
		[Inspectable]
		[InspectorToggleLeft]
		public bool numeric { get; set; } = true;

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0000B2B9 File Offset: 0x000094B9
		protected virtual string outputKey
		{
			get
			{
				return "comparison";
			}
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0000B2C0 File Offset: 0x000094C0
		protected override void Definition()
		{
			if (this.numeric)
			{
				this.a = base.ValueInput<float>("a");
				this.b = base.ValueInput<float>("b", 0f);
				this.comparison = base.ValueOutput<bool>(this.outputKey, new Func<Flow, bool>(this.NumericComparison)).Predictable();
			}
			else
			{
				this.a = base.ValueInput<object>("a").AllowsNull();
				this.b = base.ValueInput<object>("b").AllowsNull();
				this.comparison = base.ValueOutput<bool>(this.outputKey, new Func<Flow, bool>(this.GenericComparison)).Predictable();
			}
			base.Requirement(this.a, this.comparison);
			base.Requirement(this.b, this.comparison);
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0000B394 File Offset: 0x00009594
		private bool NumericComparison(Flow flow)
		{
			return this.NumericComparison(flow.GetValue<float>(this.a), flow.GetValue<float>(this.b));
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0000B3B4 File Offset: 0x000095B4
		private bool GenericComparison(Flow flow)
		{
			return this.GenericComparison(flow.GetValue(this.a), flow.GetValue(this.b));
		}

		// Token: 0x0600055F RID: 1375
		protected abstract bool NumericComparison(float a, float b);

		// Token: 0x06000560 RID: 1376
		protected abstract bool GenericComparison(object a, object b);
	}
}
