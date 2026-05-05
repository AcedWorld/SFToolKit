using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x0200002F RID: 47
	[UnitCategory("Collections/Lists")]
	[UnitSurtitle("List")]
	[UnitShortTitle("Insert Item")]
	[UnitOrder(3)]
	[TypeIcon(typeof(AddListItem))]
	public sealed class InsertListItem : Unit
	{
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00005F84 File Offset: 0x00004184
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x00005F8C File Offset: 0x0000418C
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00005F95 File Offset: 0x00004195
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x00005F9D File Offset: 0x0000419D
		[DoNotSerialize]
		[PortLabel("List")]
		[PortLabelHidden]
		public ValueInput listInput { get; private set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00005FA6 File Offset: 0x000041A6
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x00005FAE File Offset: 0x000041AE
		[DoNotSerialize]
		[PortLabel("List")]
		[PortLabelHidden]
		public ValueOutput listOutput { get; private set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060001CA RID: 458 RVA: 0x00005FB7 File Offset: 0x000041B7
		// (set) Token: 0x060001CB RID: 459 RVA: 0x00005FBF File Offset: 0x000041BF
		[DoNotSerialize]
		public ValueInput index { get; private set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001CC RID: 460 RVA: 0x00005FC8 File Offset: 0x000041C8
		// (set) Token: 0x060001CD RID: 461 RVA: 0x00005FD0 File Offset: 0x000041D0
		[DoNotSerialize]
		public ValueInput item { get; private set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001CE RID: 462 RVA: 0x00005FD9 File Offset: 0x000041D9
		// (set) Token: 0x060001CF RID: 463 RVA: 0x00005FE1 File Offset: 0x000041E1
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x060001D0 RID: 464 RVA: 0x00005FEC File Offset: 0x000041EC
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Insert));
			this.listInput = base.ValueInput<IList>("listInput");
			this.item = base.ValueInput<object>("item");
			this.index = base.ValueInput<int>("index", 0);
			this.listOutput = base.ValueOutput<IList>("listOutput");
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.listInput, this.enter);
			base.Requirement(this.item, this.enter);
			base.Requirement(this.index, this.enter);
			base.Assignment(this.enter, this.listOutput);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x000060C8 File Offset: 0x000042C8
		public ControlOutput Insert(Flow flow)
		{
			IList value = flow.GetValue<IList>(this.listInput);
			int value2 = flow.GetValue<int>(this.index);
			object value3 = flow.GetValue<object>(this.item);
			if (value is Array)
			{
				ArrayList arrayList = new ArrayList(value);
				arrayList.Insert(value2, value3);
				flow.SetValue(this.listOutput, arrayList.ToArray(value.GetType().GetElementType()));
			}
			else
			{
				value.Insert(value2, value3);
				flow.SetValue(this.listOutput, value);
			}
			return this.exit;
		}
	}
}
