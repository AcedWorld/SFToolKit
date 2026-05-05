using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000003 RID: 3
	public sealed class AnyState : State
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		[DoNotSerialize]
		public override bool canBeDestination
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020C3 File Offset: 0x000002C3
		public AnyState()
		{
			base.isStart = true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020D2 File Offset: 0x000002D2
		public override void OnExit(Flow flow, StateExitReason reason)
		{
			if (reason == StateExitReason.Branch)
			{
				return;
			}
			base.OnExit(flow, reason);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020E4 File Offset: 0x000002E4
		public override void OnBranchTo(Flow flow, IState destination)
		{
			foreach (IStateTransition stateTransition in base.outgoingTransitionsNoAlloc)
			{
				if (stateTransition.destination != destination)
				{
					stateTransition.destination.OnExit(flow, StateExitReason.AnyBranch);
				}
			}
		}
	}
}
