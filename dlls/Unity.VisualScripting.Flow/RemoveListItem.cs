using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000032 RID: 50
	[UnitCategory("Collections/Lists")]
	[UnitSurtitle("List")]
	[UnitShortTitle("Remove Item")]
	[UnitOrder(4)]
	public sealed class RemoveListItem : Unit
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x000062FD File Offset: 0x000044FD
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00006305 File Offset: 0x00004505
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000630E File Offset: 0x0000450E
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00006316 File Offset: 0x00004516
		[DoNotSerialize]
		[PortLabel("List")]
		[PortLabelHidden]
		public ValueInput listInput { get; private set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x0000631F File Offset: 0x0000451F
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x00006327 File Offset: 0x00004527
		[DoNotSerialize]
		[PortLabel("List")]
		[PortLabelHidden]
		public ValueOutput listOutput { get; private set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00006330 File Offset: 0x00004530
		// (set) Token: 0x060001E8 RID: 488 RVA: 0x00006338 File Offset: 0x00004538
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput item { get; private set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00006341 File Offset: 0x00004541
		// (set) Token: 0x060001EA RID: 490 RVA: 0x00006349 File Offset: 0x00004549
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x060001EB RID: 491 RVA: 0x00006354 File Offset: 0x00004554
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Remove));
			this.listInput = base.ValueInput<IList>("listInput");
			this.listOutput = base.ValueOutput<IList>("listOutput");
			this.item = base.ValueInput<object>("item");
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.listInput, this.enter);
			base.Requirement(this.item, this.enter);
			base.Assignment(this.enter, this.listOutput);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000640C File Offset: 0x0000460C
		public ControlOutput Remove(Flow flow)
		{
			IList value = flow.GetValue<IList>(this.listInput);
			object value2 = flow.GetValue<object>(this.item);
			if (value is Array)
			{
				ArrayList arrayList = new ArrayList(value);
				arrayList.Remove(value2);
				flow.SetValue(this.listOutput, arrayList.ToArray(value.GetType().GetElementType()));
			}
			else
			{
				value.Remove(value2);
				flow.SetValue(this.listOutput, value);
			}
			return this.exit;
		}
	}
}
