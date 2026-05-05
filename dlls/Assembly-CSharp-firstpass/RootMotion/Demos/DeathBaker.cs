using System;
using System.Collections;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000197 RID: 407
	public class DeathBaker : MonoBehaviour
	{
		// Token: 0x06000B4F RID: 2895 RVA: 0x000475D1 File Offset: 0x000457D1
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
			this.defaultPosition = base.transform.position;
			this.defaultRotation = base.transform.rotation;
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x00047604 File Offset: 0x00045804
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.D) && !this.isDead)
			{
				this.animator.CrossFadeInFixedTime("Die Backwards", 0.2f);
				if (this.puppetMaster != null)
				{
					base.StopAllCoroutines();
					base.StartCoroutine(this.FadeOutPinWeight());
					base.StartCoroutine(this.FadeOutMuscleWeight());
					base.StartCoroutine(this.Bake());
				}
				this.isDead = true;
			}
			if (Input.GetKeyDown(KeyCode.R) && this.isDead)
			{
				base.transform.position = this.defaultPosition;
				base.transform.rotation = this.defaultRotation;
				this.animator.Play("Idle", 0, 0f);
				if (this.puppetMaster != null)
				{
					if (this.baker.isBaking)
					{
						this.baker.StopBaking();
					}
					base.StopAllCoroutines();
					this.puppetMaster.pinWeight = 1f;
					this.puppetMaster.muscleWeight = 1f;
				}
				this.isDead = false;
			}
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0004771B File Offset: 0x0004591B
		private IEnumerator Bake()
		{
			this.baker.StartBaking();
			yield return new WaitForSeconds(this.bakeTime);
			this.baker.StopBaking();
			yield break;
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0004772A File Offset: 0x0004592A
		private IEnumerator FadeOutPinWeight()
		{
			while (this.puppetMaster.pinWeight > 0f)
			{
				this.puppetMaster.pinWeight = Mathf.MoveTowards(this.puppetMaster.pinWeight, 0f, Time.deltaTime * this.fadeOutPinWeightSpeed);
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x00047739 File Offset: 0x00045939
		private IEnumerator FadeOutMuscleWeight()
		{
			while (this.puppetMaster.muscleWeight > 0f)
			{
				this.puppetMaster.muscleWeight = Mathf.MoveTowards(this.puppetMaster.muscleWeight, this.deadMuscleWeight, Time.deltaTime * this.fadeOutMuscleWeightSpeed);
				yield return null;
			}
			yield break;
		}

		// Token: 0x04000B4F RID: 2895
		[Tooltip("Reference to the HumanoidBaker to bake PuppetMaster phsycics to AnimationClips.")]
		public HumanoidBaker baker;

		// Token: 0x04000B50 RID: 2896
		[Tooltip("The duration of baking in seconds.")]
		public float bakeTime = 3f;

		// Token: 0x04000B51 RID: 2897
		[Tooltip("Reference to the PuppetMaster component.")]
		public PuppetMaster puppetMaster;

		// Token: 0x04000B52 RID: 2898
		[Tooltip("The speed of fading out PuppetMaster.pinWeight.")]
		public float fadeOutPinWeightSpeed = 5f;

		// Token: 0x04000B53 RID: 2899
		[Tooltip("The speed of fading out PuppetMaster.muscleWeight.")]
		public float fadeOutMuscleWeightSpeed = 5f;

		// Token: 0x04000B54 RID: 2900
		[Tooltip("The muscle weight to fade out to.")]
		public float deadMuscleWeight = 0.3f;

		// Token: 0x04000B55 RID: 2901
		private Animator animator;

		// Token: 0x04000B56 RID: 2902
		private Vector3 defaultPosition;

		// Token: 0x04000B57 RID: 2903
		private Quaternion defaultRotation = Quaternion.identity;

		// Token: 0x04000B58 RID: 2904
		private bool isDead;
	}
}
