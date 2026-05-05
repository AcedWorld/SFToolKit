using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000034 RID: 52
	[UnitCategory("Collections/Lists")]
	[UnitSurtitle("List")]
	[UnitShortTitle("Set Item")]
	[UnitOrder(1)]
	[TypeIcon(typeof(IList))]
	public sealed class SetListItem : Unit
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00006616 File Offset: 0x00004816
		// (set) Token: 0x060001FC RID: 508 RVA: 0x0000661E File Offset: 0x0000481E
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00006627 File Offset: 0x00004827
		// (set) Token: 0x060001FE RID: 510 RVA: 0x0000662F File Offset: 0x0000482F
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput list { get; private set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00006638 File Offset: 0x00004838
		// (set) Token: 0x06000200 RID: 512 RVA: 0x00006640 File Offset: 0x00004840
		[DoNotSerialize]
		public ValueInput index { get; private set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00006649 File Offset: 0x00004849
		// (set) Token: 0x06000202 RID: 514 RVA: 0x00006651 File Offset: 0x00004851
		[DoNotSerialize]
		public ValueInput item { get; private set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000203 RID: 515 RVA: 0x0000665A File Offset: 0x0000485A
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00006662 File Offset: 0x00004862
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x06000205 RID: 517 RVA: 0x0000666C File Offset: 0x0000486C
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Set));
			this.list = base.ValueInput<IList>("list");
			this.index = base.ValueInput<int>("index", 0);
			this.item = base.ValueInput<object>("item");
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.list, this.enter);
			base.Requirement(this.index, this.enter);
			base.Requirement(this.item, this.enter);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00006724 File Offset: 0x00004924
		public ControlOutput Set(Flow flow)
		{
			IList value = flow.GetValue<IList>(this.list);
			int value2 = flow.GetValue<int>(this.index);
			object value3 = flow.GetValue<object>(this.item);
			value[value2] = value3;
			return this.exit;
		}
	}
}
