using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x0200002D RID: 45
	[UnitCategory("Collections/Lists")]
	[UnitOrder(-1)]
	[TypeIcon(typeof(IList))]
	public sealed class CreateList : MultiInputUnit<object>
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00005DBE File Offset: 0x00003FBE
		[DoNotSerialize]
		protected override int minInputCount
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x00005DC1 File Offset: 0x00003FC1
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00005DC9 File Offset: 0x00003FC9
		[InspectorLabel("Elements")]
		[UnitHeaderInspectable("Elements")]
		[Inspectable]
		public override int inputCount
		{
			get
			{
				return base.inputCount;
			}
			set
			{
				base.inputCount = value;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x00005DD2 File Offset: 0x00003FD2
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x00005DDA File Offset: 0x00003FDA
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput list { get; private set; }

		// Token: 0x060001B8 RID: 440 RVA: 0x00005DE4 File Offset: 0x00003FE4
		protected override void Definition()
		{
			this.list = base.ValueOutput<IList>("list", new Func<Flow, IList>(this.Create));
			base.Definition();
			foreach (ValueInput source in base.multiInputs)
			{
				base.Requirement(source, this.list);
			}
			base.InputsAllowNull();
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00005E60 File Offset: 0x00004060
		public IList Create(Flow flow)
		{
			AotList aotList = new AotList();
			for (int i = 0; i < this.inputCount; i++)
			{
				aotList.Add(flow.GetValue<object>(base.multiInputs[i]));
			}
			return aotList;
		}
	}
}
