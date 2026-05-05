using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000049 RID: 73
	[UnitCategory("Control")]
	[UnitOrder(16)]
	public sealed class Throw : Unit
	{
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00007C9F File Offset: 0x00005E9F
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00007CA7 File Offset: 0x00005EA7
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable("Custom")]
		[InspectorToggleLeft]
		public bool custom { get; set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00007CB0 File Offset: 0x00005EB0
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00007CB8 File Offset: 0x00005EB8
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00007CC1 File Offset: 0x00005EC1
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00007CC9 File Offset: 0x00005EC9
		[DoNotSerialize]
		public ValueInput message { get; private set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00007CD2 File Offset: 0x00005ED2
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00007CDA File Offset: 0x00005EDA
		[DoNotSerialize]
		public ValueInput exception { get; private set; }

		// Token: 0x060002CC RID: 716 RVA: 0x00007CE4 File Offset: 0x00005EE4
		protected override void Definition()
		{
			if (this.custom)
			{
				this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.ThrowCustom));
				this.exception = base.ValueInput<Exception>("exception");
				base.Requirement(this.exception, this.enter);
				return;
			}
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.ThrowMessage));
			this.message = base.ValueInput<string>("message", string.Empty);
			base.Requirement(this.message, this.enter);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00007D7F File Offset: 0x00005F7F
		private ControlOutput ThrowCustom(Flow flow)
		{
			throw flow.GetValue<Exception>(this.exception);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00007D8D File Offset: 0x00005F8D
		private ControlOutput ThrowMessage(Flow flow)
		{
			throw new Exception(flow.GetValue<string>(this.message));
		}
	}
}
