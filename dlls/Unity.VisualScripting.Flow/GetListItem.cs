using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x0200002E RID: 46
	[UnitCategory("Collections/Lists")]
	[UnitSurtitle("List")]
	[UnitShortTitle("Get Item")]
	[UnitOrder(0)]
	[TypeIcon(typeof(IList))]
	public sealed class GetListItem : Unit
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00005EA6 File Offset: 0x000040A6
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00005EAE File Offset: 0x000040AE
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput list { get; private set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00005EB7 File Offset: 0x000040B7
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00005EBF File Offset: 0x000040BF
		[DoNotSerialize]
		public ValueInput index { get; private set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00005EC8 File Offset: 0x000040C8
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00005ED0 File Offset: 0x000040D0
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput item { get; private set; }

		// Token: 0x060001C1 RID: 449 RVA: 0x00005EDC File Offset: 0x000040DC
		protected override void Definition()
		{
			this.list = base.ValueInput<IList>("list");
			this.index = base.ValueInput<int>("index", 0);
			this.item = base.ValueOutput<object>("item", new Func<Flow, object>(this.Get));
			base.Requirement(this.list, this.item);
			base.Requirement(this.index, this.item);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00005F50 File Offset: 0x00004150
		public object Get(Flow flow)
		{
			IList value = flow.GetValue<IList>(this.list);
			int value2 = flow.GetValue<int>(this.index);
			return value[value2];
		}
	}
}
