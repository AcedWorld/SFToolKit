using System;
using UnityEngine;

namespace Invector.Utils
{
	// Token: 0x020003AD RID: 941
	public class vResetTrigger : StateMachineBehaviour
	{
		// Token: 0x060012DB RID: 4827 RVA: 0x0006409A File Offset: 0x0006229A
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (this.resetOnEnter)
			{
				animator.ResetTrigger(this.trigger);
			}
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x000640B0 File Offset: 0x000622B0
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (this.resetOnExit)
			{
				animator.ResetTrigger(this.trigger);
			}
		}

		// Token: 0x040018B4 RID: 6324
		public bool resetOnEnter;

		// Token: 0x040018B5 RID: 6325
		public bool resetOnExit;

		// Token: 0x040018B6 RID: 6326
		public string trigger;
	}
}
