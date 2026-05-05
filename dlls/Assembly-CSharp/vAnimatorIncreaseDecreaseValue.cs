using System;
using UnityEngine;

// Token: 0x02000022 RID: 34
public class vAnimatorIncreaseDecreaseValue : StateMachineBehaviour
{
	// Token: 0x0600008D RID: 141 RVA: 0x00007BAC File Offset: 0x00005DAC
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (!this.decrease)
		{
			this.time += Time.deltaTime * this.speed;
		}
		else
		{
			this.time -= Time.deltaTime * this.speed;
		}
		animator.SetFloat(this.targetFloat, this.time);
	}

	// Token: 0x040000CC RID: 204
	public string targetFloat;

	// Token: 0x040000CD RID: 205
	public bool decrease;

	// Token: 0x040000CE RID: 206
	private float time;

	// Token: 0x040000CF RID: 207
	public float speed = 1f;
}
