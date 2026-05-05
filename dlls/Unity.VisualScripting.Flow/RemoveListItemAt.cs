using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000033 RID: 51
	[UnitCategory("Collections/Lists")]
	[UnitSurtitle("List")]
	[UnitShortTitle("Remove Item At Index")]
	[UnitOrder(5)]
	[TypeIcon(typeof(RemoveListItem))]
	public sealed class RemoveListItemAt : Unit
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060001EE RID: 494 RVA: 0x0000648A File Offset: 0x0000468A
		// (set) Token: 0x060001EF RID: 495 RVA: 0x00006492 File Offset: 0x00004692
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x0000649B File Offset: 0x0000469B
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x000064A3 File Offset: 0x000046A3
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput listInput { get; private set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x000064AC File Offset: 0x000046AC
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x000064B4 File Offset: 0x000046B4
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput listOutput { get; private set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x000064BD File Offset: 0x000046BD
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x000064C5 File Offset: 0x000046C5
		[DoNotSerialize]
		public ValueInput index { get; private set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x000064CE File Offset: 0x000046CE
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x000064D6 File Offset: 0x000046D6
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x060001F8 RID: 504 RVA: 0x000064E0 File Offset: 0x000046E0
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.RemoveAt));
			this.listInput = base.ValueInput<IList>("listInput");
			this.listOutput = base.ValueOutput<IList>("listOutput");
			this.index = base.ValueInput<int>("index", 0);
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.listInput, this.enter);
			base.Requirement(this.index, this.enter);
			base.Assignment(this.enter, this.listOutput);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00006598 File Offset: 0x00004798
		public ControlOutput RemoveAt(Flow flow)
		{
			IList value = flow.GetValue<IList>(this.listInput);
			int value2 = flow.GetValue<int>(this.index);
			if (value is Array)
			{
				ArrayList arrayList = new ArrayList(value);
				arrayList.RemoveAt(value2);
				flow.SetValue(this.listOutput, arrayList.ToArray(value.GetType().GetElementType()));
			}
			else
			{
				value.RemoveAt(value2);
				flow.SetValue(this.listOutput, value);
			}
			return this.exit;
		}
	}
}
