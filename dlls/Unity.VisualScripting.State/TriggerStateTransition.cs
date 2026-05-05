using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200001C RID: 28
	[UnitSurtitle("State")]
	[UnitCategory("Nesting")]
	[UnitShortTitle("Trigger Transition")]
	[TypeIcon(typeof(IStateTransition))]
	public sealed class TriggerStateTransition : Unit
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000BA RID: 186 RVA: 0x000034FD File Offset: 0x000016FD
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00003505 File Offset: 0x00001705
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput trigger { get; private set; }

		// Token: 0x060000BC RID: 188 RVA: 0x0000350E File Offset: 0x0000170E
		protected override void Definition()
		{
			this.trigger = base.ControlInput("trigger", new Func<Flow, ControlOutput>(this.Trigger));
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000352D File Offset: 0x0000172D
		private ControlOutput Trigger(Flow flow)
		{
			IStateTransition parent = flow.stack.GetParent<INesterStateTransition>();
			flow.stack.ExitParentElement();
			parent.Branch(flow);
			return null;
		}
	}
}
