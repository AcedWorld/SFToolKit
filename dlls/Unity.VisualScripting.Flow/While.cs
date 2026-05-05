using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x0200004D RID: 77
	[UnitTitle("While Loop")]
	[UnitCategory("Control")]
	[UnitOrder(11)]
	public class While : LoopUnit
	{
		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000318 RID: 792 RVA: 0x0000856C File Offset: 0x0000676C
		// (set) Token: 0x06000319 RID: 793 RVA: 0x00008574 File Offset: 0x00006774
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput condition { get; private set; }

		// Token: 0x0600031A RID: 794 RVA: 0x0000857D File Offset: 0x0000677D
		protected override void Definition()
		{
			base.Definition();
			this.condition = base.ValueInput<bool>("condition");
			base.Requirement(this.condition, base.enter);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000085A8 File Offset: 0x000067A8
		private int Start(Flow flow)
		{
			return flow.EnterLoop();
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000085B0 File Offset: 0x000067B0
		private bool CanMoveNext(Flow flow)
		{
			return flow.GetValue<bool>(this.condition);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x000085C0 File Offset: 0x000067C0
		protected override ControlOutput Loop(Flow flow)
		{
			int loop = this.Start(flow);
			GraphStack stack = flow.PreserveStack();
			while (flow.LoopIsNotBroken(loop) && this.CanMoveNext(flow))
			{
				flow.Invoke(base.body);
				flow.RestoreStack(stack);
			}
			flow.DisposePreservedStack(stack);
			flow.ExitLoop(loop);
			return base.exit;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00008617 File Offset: 0x00006817
		protected override IEnumerator LoopCoroutine(Flow flow)
		{
			int loop = this.Start(flow);
			GraphStack stack = flow.PreserveStack();
			while (flow.LoopIsNotBroken(loop) && this.CanMoveNext(flow))
			{
				yield return base.body;
				flow.RestoreStack(stack);
			}
			flow.DisposePreservedStack(stack);
			flow.ExitLoop(loop);
			yield return base.exit;
			yield break;
		}
	}
}
