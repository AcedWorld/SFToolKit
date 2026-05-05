using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001BC RID: 444
	public abstract class CharacterBase : MonoBehaviour
	{
		// Token: 0x06000BE9 RID: 3049
		public abstract void Move(Vector3 deltaPosition, Quaternion deltaRotation);

		// Token: 0x06000BEA RID: 3050 RVA: 0x00049CF4 File Offset: 0x00047EF4
		protected Vector3 GetGravity()
		{
			if (this.gravityTarget != null)
			{
				return (this.gravityTarget.position - base.transform.position).normalized * Physics.gravity.magnitude;
			}
			return Physics.gravity;
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x00049D4C File Offset: 0x00047F4C
		protected virtual void Start()
		{
			this.capsule = (base.GetComponent<Collider>() as CapsuleCollider);
			this.r = base.GetComponent<Rigidbody>();
			this.originalHeight = this.capsule.height;
			this.originalCenter = this.capsule.center;
			this.zeroFrictionMaterial = new PhysicMaterial();
			this.zeroFrictionMaterial.dynamicFriction = 0f;
			this.zeroFrictionMaterial.staticFriction = 0f;
			this.zeroFrictionMaterial.frictionCombine = PhysicMaterialCombine.Minimum;
			this.zeroFrictionMaterial.bounciness = 0f;
			this.zeroFrictionMaterial.bounceCombine = PhysicMaterialCombine.Minimum;
			this.highFrictionMaterial = new PhysicMaterial();
			this.r.constraints = RigidbodyConstraints.FreezeRotation;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x00049E04 File Offset: 0x00048004
		protected virtual RaycastHit GetSpherecastHit()
		{
			Vector3 up = base.transform.up;
			Ray ray = new Ray(this.r.position + up * this.airborneThreshold, -up);
			RaycastHit result = default(RaycastHit);
			result.point = base.transform.position - base.transform.transform.up * this.airborneThreshold;
			result.normal = base.transform.up;
			Physics.SphereCast(ray, this.spherecastRadius, out result, this.airborneThreshold * 2f, this.groundLayers);
			return result;
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x00049EB8 File Offset: 0x000480B8
		public float GetAngleFromForward(Vector3 worldDirection)
		{
			Vector3 vector = base.transform.InverseTransformDirection(worldDirection);
			return Mathf.Atan2(vector.x, vector.z) * 57.29578f;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x00049EEC File Offset: 0x000480EC
		protected void RigidbodyRotateAround(Vector3 point, Vector3 axis, float angle)
		{
			Quaternion quaternion = Quaternion.AngleAxis(angle, axis);
			Vector3 point2 = base.transform.position - point;
			this.r.MovePosition(point + quaternion * point2);
			this.r.MoveRotation(quaternion * base.transform.rotation);
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x00049F48 File Offset: 0x00048148
		protected void ScaleCapsule(float mlp)
		{
			if (this.capsule.height != this.originalHeight * mlp)
			{
				this.capsule.height = Mathf.MoveTowards(this.capsule.height, this.originalHeight * mlp, Time.deltaTime * 4f);
				this.capsule.center = Vector3.MoveTowards(this.capsule.center, this.originalCenter * mlp, Time.deltaTime * 2f);
			}
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x00049FCA File Offset: 0x000481CA
		protected void HighFriction()
		{
			this.capsule.material = this.highFrictionMaterial;
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x00049FDD File Offset: 0x000481DD
		protected void ZeroFriction()
		{
			this.capsule.material = this.zeroFrictionMaterial;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x00049FF0 File Offset: 0x000481F0
		protected float GetSlopeDamper(Vector3 velocity, Vector3 groundNormal)
		{
			float num = 90f - Vector3.Angle(velocity, groundNormal);
			num -= this.slopeStartAngle;
			float num2 = this.slopeEndAngle - this.slopeStartAngle;
			return 1f - Mathf.Clamp(num / num2, 0f, 1f);
		}

		// Token: 0x04000C0A RID: 3082
		[Header("Base Parameters")]
		[Tooltip("If specified, will use the direction from the character to this Transform as the gravity vector instead of Physics.gravity. Physics.gravity.magnitude will be used as the magnitude of the gravity vector.")]
		public Transform gravityTarget;

		// Token: 0x04000C0B RID: 3083
		[Tooltip("Multiplies gravity applied to the character even if 'Individual Gravity' is unchecked.")]
		public float gravityMultiplier = 2f;

		// Token: 0x04000C0C RID: 3084
		public float airborneThreshold = 0.6f;

		// Token: 0x04000C0D RID: 3085
		public float slopeStartAngle = 50f;

		// Token: 0x04000C0E RID: 3086
		public float slopeEndAngle = 85f;

		// Token: 0x04000C0F RID: 3087
		public float spherecastRadius = 0.1f;

		// Token: 0x04000C10 RID: 3088
		public LayerMask groundLayers;

		// Token: 0x04000C11 RID: 3089
		private PhysicMaterial zeroFrictionMaterial;

		// Token: 0x04000C12 RID: 3090
		private PhysicMaterial highFrictionMaterial;

		// Token: 0x04000C13 RID: 3091
		protected Rigidbody r;

		// Token: 0x04000C14 RID: 3092
		protected const float half = 0.5f;

		// Token: 0x04000C15 RID: 3093
		protected float originalHeight;

		// Token: 0x04000C16 RID: 3094
		protected Vector3 originalCenter;

		// Token: 0x04000C17 RID: 3095
		protected CapsuleCollider capsule;
	}
}
