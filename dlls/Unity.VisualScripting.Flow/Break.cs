using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000035 RID: 53
	[UnitTitle("Break Loop")]
	[UnitCategory("Control")]
	[UnitOrder(13)]
	public class Break : Unit
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0000676C File Offset: 0x0000496C
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00006774 File Offset: 0x00004974
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x0600020A RID: 522 RVA: 0x0000677D File Offset: 0x0000497D
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Operation));
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000679C File Offset: 0x0000499C
		public ControlOutput Operation(Flow flow)
		{
			flow.BreakLoop();
			return null;
		}
	}
}
