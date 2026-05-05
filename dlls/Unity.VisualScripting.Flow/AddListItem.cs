using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x0200002B RID: 43
	[UnitCategory("Collections/Lists")]
	[UnitSurtitle("List")]
	[UnitShortTitle("Add Item")]
	[UnitOrder(2)]
	public sealed class AddListItem : Unit
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00005AF5 File Offset: 0x00003CF5
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00005AFD File Offset: 0x00003CFD
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00005B06 File Offset: 0x00003D06
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00005B0E File Offset: 0x00003D0E
		[DoNotSerialize]
		[PortLabel("List")]
		[PortLabelHidden]
		public ValueInput listInput { get; private set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00005B17 File Offset: 0x00003D17
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x00005B1F File Offset: 0x00003D1F
		[DoNotSerialize]
		[PortLabel("List")]
		[PortLabelHidden]
		public ValueOutput listOutput { get; private set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00005B28 File Offset: 0x00003D28
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x00005B30 File Offset: 0x00003D30
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput item { get; private set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00005B39 File Offset: 0x00003D39
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x00005B41 File Offset: 0x00003D41
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x060001A5 RID: 421 RVA: 0x00005B4C File Offset: 0x00003D4C
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Add));
			this.listInput = base.ValueInput<IList>("listInput");
			this.item = base.ValueInput<object>("item");
			this.listOutput = base.ValueOutput<IList>("listOutput");
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.listInput, this.enter);
			base.Requirement(this.item, this.enter);
			base.Assignment(this.enter, this.listOutput);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00005C04 File Offset: 0x00003E04
		public ControlOutput Add(Flow flow)
		{
			IList value = flow.GetValue<IList>(this.listInput);
			object value2 = flow.GetValue<object>(this.item);
			if (value is Array)
			{
				ArrayList arrayList = new ArrayList(value);
				arrayList.Add(value2);
				flow.SetValue(this.listOutput, arrayList.ToArray(value.GetType().GetElementType()));
			}
			else
			{
				value.Add(value2);
				flow.SetValue(this.listOutput, value);
			}
			return this.exit;
		}
	}
}
