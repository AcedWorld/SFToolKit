using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000030 RID: 48
	[UnitCategory("Collections/Lists")]
	[UnitSurtitle("List")]
	[UnitShortTitle("Contains Item")]
	[TypeIcon(typeof(IList))]
	public sealed class ListContainsItem : Unit
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00006155 File Offset: 0x00004355
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x0000615D File Offset: 0x0000435D
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput list { get; private set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00006166 File Offset: 0x00004366
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x0000616E File Offset: 0x0000436E
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput item { get; private set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00006177 File Offset: 0x00004377
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x0000617F File Offset: 0x0000437F
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput contains { get; private set; }

		// Token: 0x060001D9 RID: 473 RVA: 0x00006188 File Offset: 0x00004388
		protected override void Definition()
		{
			this.list = base.ValueInput<IList>("list");
			this.item = base.ValueInput<object>("item");
			this.contains = base.ValueOutput<bool>("contains", new Func<Flow, bool>(this.Contains));
			base.Requirement(this.list, this.contains);
			base.Requirement(this.item, this.contains);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000061F8 File Offset: 0x000043F8
		public bool Contains(Flow flow)
		{
			IList value = flow.GetValue<IList>(this.list);
			object value2 = flow.GetValue<object>(this.item);
			return value.Contains(value2);
		}
	}
}
