using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector
{
	// Token: 0x0200034D RID: 845
	public class vTriggerSoundByState : StateMachineBehaviour
	{
		// Token: 0x0600114E RID: 4430 RVA: 0x0005DB8E File Offset: 0x0005BD8E
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			this.isTrigger = false;
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x0005DB98 File Offset: 0x0005BD98
		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (stateInfo.normalizedTime % 1f >= this.triggerTime && !this.isTrigger)
			{
				this.TriggerSound(animator, stateInfo, layerIndex);
				return;
			}
			if (stateInfo.normalizedTime % 1f < this.triggerTime && this.isTrigger)
			{
				this.isTrigger = false;
			}
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x000020BE File Offset: 0x000002BE
		private void TriggerSound(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		// Token: 0x0400173D RID: 5949
		public GameObject audioSource;

		// Token: 0x0400173E RID: 5950
		public List<AudioClip> sounds;

		// Token: 0x0400173F RID: 5951
		public float triggerTime;

		// Token: 0x04001740 RID: 5952
		private vFisherYatesRandom _random;

		// Token: 0x04001741 RID: 5953
		private bool isTrigger;
	}
}
