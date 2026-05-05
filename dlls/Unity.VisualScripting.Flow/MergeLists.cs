using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000031 RID: 49
	[UnitCategory("Collections/Lists")]
	[UnitOrder(7)]
	public sealed class MergeLists : MultiInputUnit<IEnumerable>
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060001DC RID: 476 RVA: 0x0000622C File Offset: 0x0000442C
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00006234 File Offset: 0x00004434
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput list { get; private set; }

		// Token: 0x060001DE RID: 478 RVA: 0x00006240 File Offset: 0x00004440
		protected override void Definition()
		{
			this.list = base.ValueOutput<IList>("list", new Func<Flow, IList>(this.Merge));
			base.Definition();
			foreach (ValueInput source in base.multiInputs)
			{
				base.Requirement(source, this.list);
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000062B8 File Offset: 0x000044B8
		public IList Merge(Flow flow)
		{
			AotList aotList = new AotList();
			for (int i = 0; i < this.inputCount; i++)
			{
				aotList.AddRange(flow.GetValue<IEnumerable>(base.multiInputs[i]));
			}
			return aotList;
		}
	}
}
