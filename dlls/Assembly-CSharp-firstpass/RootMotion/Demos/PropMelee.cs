using System;
using System.Collections;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001AB RID: 427
	public class PropMelee : Prop
	{
		// Token: 0x06000BA3 RID: 2979 RVA: 0x00048623 File Offset: 0x00046823
		public void StartAction(float duration)
		{
			base.StopAllCoroutines();
			base.StartCoroutine(this.Action(duration));
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x00048639 File Offset: 0x00046839
		public IEnumerator Action(float duration)
		{
			this.capsuleCollider.radius = this.defaultColliderRadius * this.actionColliderRadiusMlp;
			this.r.mass = this.defaultMass * this.actionMassMlp;
			int additionalPinMuscleIndex = (this.additionalPinTarget != null) ? base.propRoot.puppetMaster.GetMuscleIndex(this.additionalPinTarget) : -1;
			if (additionalPinMuscleIndex != -1)
			{
				base.propRoot.puppetMaster.muscles[additionalPinMuscleIndex].props.pinWeight = this.actionAdditionalPinWeight;
			}
			yield return new WaitForSeconds(duration);
			this.capsuleCollider.radius = this.defaultColliderRadius;
			this.r.mass = this.defaultMass;
			if (additionalPinMuscleIndex != -1)
			{
				base.propRoot.puppetMaster.muscles[additionalPinMuscleIndex].props.pinWeight = this.additionalPinWeight;
			}
			yield break;
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x00048650 File Offset: 0x00046850
		protected override void OnStart()
		{
			this.defaultColliderRadius = this.capsuleCollider.radius;
			this.r = this.muscle.GetComponent<Rigidbody>();
			this.r.centerOfMass += this.COMOffset;
			this.defaultMass = this.r.mass;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x000486AC File Offset: 0x000468AC
		protected override void OnPickUp(PropRoot propRoot)
		{
			this.capsuleCollider.radius = this.defaultColliderRadius;
			this.r.mass = this.defaultMass;
			this.capsuleCollider.enabled = true;
			this.boxCollider.enabled = false;
			base.StopAllCoroutines();
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x000486FC File Offset: 0x000468FC
		protected override void OnDrop()
		{
			this.capsuleCollider.radius = this.defaultColliderRadius;
			this.r.mass = this.defaultMass;
			this.capsuleCollider.enabled = false;
			this.boxCollider.enabled = true;
			base.StopAllCoroutines();
		}

		// Token: 0x04000BAB RID: 2987
		[LargeHeader("Melee")]
		[Tooltip("Switch to a CapsuleCollider when the prop is picked up so it behaves more smoothly when colliding with objects.")]
		public CapsuleCollider capsuleCollider;

		// Token: 0x04000BAC RID: 2988
		[Tooltip("The default BoxCollider used when this prop is not picked up.")]
		public BoxCollider boxCollider;

		// Token: 0x04000BAD RID: 2989
		[Tooltip("Temporarily increase the radius of the capsule collider when a hitting action is triggered, so it would not pass colliders too easily.")]
		public float actionColliderRadiusMlp = 1f;

		// Token: 0x04000BAE RID: 2990
		[Tooltip("Temporarily set (increase) the pin weight of the additional pin when a hitting action is triggered.")]
		[Range(0f, 1f)]
		public float actionAdditionalPinWeight = 1f;

		// Token: 0x04000BAF RID: 2991
		[Tooltip("Temporarily increase the mass of the Rigidbody when a hitting action is triggered.")]
		[Range(0.1f, 10f)]
		public float actionMassMlp = 1f;

		// Token: 0x04000BB0 RID: 2992
		[Tooltip("Offset to the default center of mass of the Rigidbody (might improve prop handling).")]
		public Vector3 COMOffset;

		// Token: 0x04000BB1 RID: 2993
		private float defaultColliderRadius;

		// Token: 0x04000BB2 RID: 2994
		private float defaultMass;

		// Token: 0x04000BB3 RID: 2995
		private float defaultAddMass;

		// Token: 0x04000BB4 RID: 2996
		private Rigidbody r;
	}
}
