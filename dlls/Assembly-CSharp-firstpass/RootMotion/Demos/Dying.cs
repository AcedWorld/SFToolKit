using System;
using System.Collections;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200019D RID: 413
	public class Dying : MonoBehaviour
	{
		// Token: 0x06000B70 RID: 2928 RVA: 0x000479DC File Offset: 0x00045BDC
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
			this.defaultPosition = base.transform.position;
			this.defaultRotation = base.transform.rotation;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x00047A0C File Offset: 0x00045C0C
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
					base.StopAllCoroutines();
					this.puppetMaster.pinWeight = 1f;
					this.puppetMaster.muscleWeight = 1f;
				}
				this.isDead = false;
			}
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x00047AF8 File Offset: 0x00045CF8
		private IEnumerator FadeOutPinWeight()
		{
			while (this.puppetMaster.pinWeight > 0f)
			{
				this.puppetMaster.pinWeight = Mathf.MoveTowards(this.puppetMaster.pinWeight, 0f, Time.deltaTime * this.fadeOutPinWeightSpeed);
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x00047B07 File Offset: 0x00045D07
		private IEnumerator FadeOutMuscleWeight()
		{
			while (this.puppetMaster.muscleWeight > 0f)
			{
				this.puppetMaster.muscleWeight = Mathf.MoveTowards(this.puppetMaster.muscleWeight, this.deadMuscleWeight, Time.deltaTime * this.fadeOutMuscleWeightSpeed);
				yield return null;
			}
			yield break;
		}

		// Token: 0x04000B66 RID: 2918
		[Tooltip("Reference to the PuppetMaster component.")]
		public PuppetMaster puppetMaster;

		// Token: 0x04000B67 RID: 2919
		[Tooltip("The speed of fading out PuppetMaster.pinWeight.")]
		public float fadeOutPinWeightSpeed = 5f;

		// Token: 0x04000B68 RID: 2920
		[Tooltip("The speed of fading out PuppetMaster.muscleWeight.")]
		public float fadeOutMuscleWeightSpeed = 5f;

		// Token: 0x04000B69 RID: 2921
		[Tooltip("The muscle weight to fade out to.")]
		public float deadMuscleWeight = 0.3f;

		// Token: 0x04000B6A RID: 2922
		private Animator animator;

		// Token: 0x04000B6B RID: 2923
		private Vector3 defaultPosition;

		// Token: 0x04000B6C RID: 2924
		private Quaternion defaultRotation = Quaternion.identity;

		// Token: 0x04000B6D RID: 2925
		private bool isDead;
	}
}
