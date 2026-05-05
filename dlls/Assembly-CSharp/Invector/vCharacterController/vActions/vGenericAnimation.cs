using System;
using UnityEngine;
using UnityEngine.Events;

namespace Invector.vCharacterController.vActions
{
	// Token: 0x02000419 RID: 1049
	[vClassHeader("Generic Animation", "Use this script to trigger a simple animation.")]
	public class vGenericAnimation : vMonoBehaviour
	{
		// Token: 0x060015C2 RID: 5570 RVA: 0x000719D3 File Offset: 0x0006FBD3
		protected virtual void Start()
		{
			this.tpInput = base.GetComponent<vThirdPersonInput>();
		}

		// Token: 0x060015C3 RID: 5571 RVA: 0x000719E1 File Offset: 0x0006FBE1
		protected virtual void LateUpdate()
		{
			this.TriggerAnimation();
			this.AnimationBehaviour();
		}

		// Token: 0x060015C4 RID: 5572 RVA: 0x000719F0 File Offset: 0x0006FBF0
		protected virtual void TriggerAnimation()
		{
			bool flag = !this.isPlaying && !this.tpInput.cc.customAction && !string.IsNullOrEmpty(this.animationClip);
			if (this.actionInput.GetButtonDown() && flag)
			{
				this.PlayAnimation();
			}
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x00071A3E File Offset: 0x0006FC3E
		public virtual void PlayAnimation()
		{
			this.triggerOnce = true;
			this.OnPlayAnimation.Invoke();
			this.tpInput.cc.animator.CrossFadeInFixedTime(this.animationClip, 0.1f);
		}

		// Token: 0x060015C6 RID: 5574 RVA: 0x00071A74 File Offset: 0x0006FC74
		protected virtual void AnimationBehaviour()
		{
			this.isPlaying = this.tpInput.cc.baseLayerInfo.IsName(this.animationClip);
			if (this.isPlaying && this.tpInput.cc.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= this.animationEnd && this.triggerOnce)
			{
				this.triggerOnce = false;
				this.OnEndAnimation.Invoke();
			}
		}

		// Token: 0x04001B72 RID: 7026
		[Tooltip("Input to trigger the custom animation")]
		public GenericInput actionInput = new GenericInput("L", "A", "A");

		// Token: 0x04001B73 RID: 7027
		[Tooltip("Name of the animation clip")]
		public string animationClip;

		// Token: 0x04001B74 RID: 7028
		[Tooltip("Where in the end of the animation will trigger the event OnEndAnimation")]
		public float animationEnd = 0.8f;

		// Token: 0x04001B75 RID: 7029
		public UnityEvent OnPlayAnimation;

		// Token: 0x04001B76 RID: 7030
		public UnityEvent OnEndAnimation;

		// Token: 0x04001B77 RID: 7031
		protected bool isPlaying;

		// Token: 0x04001B78 RID: 7032
		protected bool triggerOnce;

		// Token: 0x04001B79 RID: 7033
		protected vThirdPersonInput tpInput;
	}
}
