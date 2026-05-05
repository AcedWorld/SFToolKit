using System;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class vAnimatorSetTrigger : StateMachineBehaviour
{
	// Token: 0x0600008F RID: 143 RVA: 0x00007C1A File Offset: 0x00005E1A
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (this.setOnEnter)
		{
			animator.SetTrigger(this.trigger);
		}
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00007C30 File Offset: 0x00005E30
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (this.setOnExit)
		{
			animator.SetTrigger(this.trigger);
		}
	}

	// Token: 0x040000D0 RID: 208
	public bool setOnEnter;

	// Token: 0x040000D1 RID: 209
	public bool setOnExit;

	// Token: 0x040000D2 RID: 210
	public string trigger;
}
