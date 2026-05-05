using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000006 RID: 6
	public class AnimationModifierStack : MonoBehaviour
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002240 File Offset: 0x00000440
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
			this.baker = base.GetComponent<Baker>();
			Baker baker = this.baker;
			baker.OnStartClip = (Baker.BakerDelegate)Delegate.Combine(baker.OnStartClip, new Baker.BakerDelegate(this.OnBakerStartClip));
			Baker baker2 = this.baker;
			baker2.OnUpdateClip = (Baker.BakerDelegate)Delegate.Combine(baker2.OnUpdateClip, new Baker.BakerDelegate(this.OnBakerUpdateClip));
			AnimationModifier[] array = this.modifiers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnInitiate(this.baker, this.animator);
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000022DC File Offset: 0x000004DC
		private void OnBakerStartClip(AnimationClip clip, float normalizedTime)
		{
			AnimationModifier[] array = this.modifiers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnStartClip(clip);
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002308 File Offset: 0x00000508
		private void OnBakerUpdateClip(AnimationClip clip, float normalizedTime)
		{
			foreach (AnimationModifier animationModifier in this.modifiers)
			{
				if (animationModifier.enabled)
				{
					animationModifier.OnBakerUpdate(normalizedTime);
				}
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002340 File Offset: 0x00000540
		private void LateUpdate()
		{
			if (!this.animator.enabled && !this.baker.isBaking)
			{
				return;
			}
			if (this.baker.isBaking && this.baker.mode == Baker.Mode.AnimationClips)
			{
				return;
			}
			if (this.animator.runtimeAnimatorController == null)
			{
				return;
			}
			float normalizedTime = this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
			foreach (AnimationModifier animationModifier in this.modifiers)
			{
				if (animationModifier.enabled)
				{
					animationModifier.OnBakerUpdate(normalizedTime);
				}
			}
		}

		// Token: 0x0400000E RID: 14
		public AnimationModifier[] modifiers = new AnimationModifier[0];

		// Token: 0x0400000F RID: 15
		private Animator animator;

		// Token: 0x04000010 RID: 16
		private Baker baker;
	}
}
