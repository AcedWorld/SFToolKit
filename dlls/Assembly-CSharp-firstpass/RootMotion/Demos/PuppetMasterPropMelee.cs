using System;
using System.Collections;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001AF RID: 431
	public class PuppetMasterPropMelee : PuppetMasterProp
	{
		// Token: 0x06000BB4 RID: 2996 RVA: 0x00048A37 File Offset: 0x00046C37
		public void StartAction(float duration)
		{
			base.StopAllCoroutines();
			base.StartCoroutine(this.Action(duration));
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x00048A4D File Offset: 0x00046C4D
		public IEnumerator Action(float duration)
		{
			this.capsuleCollider.radius = this.defaultColliderRadius * this.actionColliderRadiusMlp;
			this.mass = this.defaultMass * this.actionMassMlp;
			this.additionalPinWeight = this.actionAdditionalPinWeight;
			yield return new WaitForSeconds(duration);
			this.capsuleCollider.radius = this.defaultColliderRadius;
			this.mass = this.defaultMass;
			this.additionalPinWeight = this.defaultAdditionalPinWeight;
			yield break;
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x00048A64 File Offset: 0x00046C64
		protected override void Start()
		{
			base.Start();
			this.defaultColliderRadius = this.capsuleCollider.radius;
			this.defaultAdditionalPinWeight = this.additionalPinWeight;
			this.defaultMass = this.mass;
			this.capsuleCollider.enabled = false;
			this.boxCollider.enabled = true;
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x00048AB8 File Offset: 0x00046CB8
		protected override void OnPickUp(PuppetMaster puppetMaster, int propMuscleIndex)
		{
			this.capsuleCollider.radius = this.defaultColliderRadius;
			base.propMuscle.rigidbody.centerOfMass += this.COMOffset;
			this.mass = this.defaultMass;
			this.capsuleCollider.enabled = true;
			this.boxCollider.enabled = false;
			base.StopAllCoroutines();
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x00048B21 File Offset: 0x00046D21
		protected override void OnDrop(PuppetMaster puppetMaster, int propMuscleIndex)
		{
			this.capsuleCollider.radius = this.defaultColliderRadius;
			this.capsuleCollider.enabled = false;
			this.boxCollider.enabled = true;
			base.StopAllCoroutines();
		}

		// Token: 0x04000BC1 RID: 3009
		[LargeHeader("Melee")]
		[Tooltip("Switch to a CapsuleCollider when the prop is picked up so it behaves more smoothly when colliding with objects.")]
		public CapsuleCollider capsuleCollider;

		// Token: 0x04000BC2 RID: 3010
		[Tooltip("The default BoxCollider used when this prop is not picked up.")]
		public BoxCollider boxCollider;

		// Token: 0x04000BC3 RID: 3011
		[Tooltip("Temporarily increase the radius of the capsule collider when a hitting action is triggered, so it would not pass colliders too easily.")]
		public float actionColliderRadiusMlp = 1f;

		// Token: 0x04000BC4 RID: 3012
		[Tooltip("Temporarily set (increase) the pin weight of the additional pin when a hitting action is triggered.")]
		[Range(0f, 1f)]
		public float actionAdditionalPinWeight = 1f;

		// Token: 0x04000BC5 RID: 3013
		[Tooltip("Temporarily increase the mass of the Rigidbody when a hitting action is triggered.")]
		[Range(1f, 10f)]
		public float actionMassMlp = 1f;

		// Token: 0x04000BC6 RID: 3014
		[Tooltip("Offset to the default center of mass of the Rigidbody (might improve prop handling).")]
		public Vector3 COMOffset;

		// Token: 0x04000BC7 RID: 3015
		private float defaultColliderRadius;

		// Token: 0x04000BC8 RID: 3016
		private float defaultMass;

		// Token: 0x04000BC9 RID: 3017
		private float defaultAdditionalPinWeight;
	}
}
