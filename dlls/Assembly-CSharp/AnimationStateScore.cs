using System;
using UnityEngine;

// Token: 0x02000119 RID: 281
public class AnimationStateScore : StateMachineBehaviour
{
	// Token: 0x06000492 RID: 1170 RVA: 0x0001FDD0 File Offset: 0x0001DFD0
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		PlayerScoring component = animator.GetComponent<PlayerScoring>();
		if (component != null)
		{
			component.AddScore(this.trickName, this.points);
		}
	}

	// Token: 0x040006ED RID: 1773
	public string trickName;

	// Token: 0x040006EE RID: 1774
	public int points;
}
