using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000161 RID: 353
	public class FPSAiming : MonoBehaviour
	{
		// Token: 0x06000A89 RID: 2697 RVA: 0x00043040 File Offset: 0x00041240
		private void Start()
		{
			this.gunTargetDefaultLocalPosition = this.gunTarget.localPosition;
			this.gunTargetDefaultLocalRotation = this.gunTarget.localEulerAngles;
			this.camDefaultLocalPosition = this.cam.transform.localPosition;
			this.cam.enabled = false;
			this.gunAim.enabled = false;
			if (this.headAim != null)
			{
				this.headAim.enabled = false;
			}
			this.ik.enabled = false;
			if (this.recoil != null && this.ik.solver.iterations == 0)
			{
				Debug.LogWarning("FPSAiming with Recoil needs FBBIK solver iteration count to be at least 1 to maintain accuracy.");
			}
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x000430ED File Offset: 0x000412ED
		private void FixedUpdate()
		{
			this.updateFrame = true;
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x000430F8 File Offset: 0x000412F8
		private void LateUpdate()
		{
			if (!this.animatePhysics)
			{
				this.updateFrame = true;
			}
			if (!this.updateFrame)
			{
				return;
			}
			this.updateFrame = false;
			this.cam.transform.localPosition = this.camDefaultLocalPosition;
			this.camRelativeToGunTarget = this.gunTarget.InverseTransformPoint(this.cam.transform.position);
			this.cam.LateUpdate();
			this.RotateCharacter();
			this.Aiming();
			this.LookDownTheSight();
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x00043178 File Offset: 0x00041378
		private void Aiming()
		{
			if (this.aimWeight <= 0f)
			{
				return;
			}
			Quaternion rotation = this.cam.transform.rotation;
			if (this.headAim != null)
			{
				this.headAim.solver.IKPosition = this.cam.transform.position + this.cam.transform.forward * 10f;
				this.headAim.solver.IKPositionWeight = 1f - this.aimWeight;
				this.headAim.solver.Update();
			}
			this.gunAim.solver.IKPosition = this.cam.transform.position + this.cam.transform.forward * 10f + this.cam.transform.rotation * this.aimOffset;
			this.gunAim.solver.IKPositionWeight = this.aimWeight;
			this.gunAim.solver.Update();
			this.cam.transform.rotation = rotation;
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x000432B4 File Offset: 0x000414B4
		private void LookDownTheSight()
		{
			float t = this.aimWeight * this.sightWeight;
			this.gunTarget.position = Vector3.Lerp(this.gun.position, this.gunTarget.parent.TransformPoint(this.gunTargetDefaultLocalPosition), t);
			this.gunTarget.rotation = Quaternion.Lerp(this.gun.rotation, this.gunTarget.parent.rotation * Quaternion.Euler(this.gunTargetDefaultLocalRotation), t);
			Vector3 position = this.gun.InverseTransformPoint(this.ik.solver.leftHandEffector.bone.position);
			Vector3 position2 = this.gun.InverseTransformPoint(this.ik.solver.rightHandEffector.bone.position);
			Quaternion rhs = Quaternion.Inverse(this.gun.rotation) * this.ik.solver.leftHandEffector.bone.rotation;
			Quaternion rhs2 = Quaternion.Inverse(this.gun.rotation) * this.ik.solver.rightHandEffector.bone.rotation;
			float d = 1f;
			this.ik.solver.leftHandEffector.positionOffset += (this.gunTarget.TransformPoint(position) - (this.ik.solver.leftHandEffector.bone.position + this.ik.solver.leftHandEffector.positionOffset)) * d;
			this.ik.solver.rightHandEffector.positionOffset += (this.gunTarget.TransformPoint(position2) - (this.ik.solver.rightHandEffector.bone.position + this.ik.solver.rightHandEffector.positionOffset)) * d;
			this.ik.solver.headMapping.maintainRotationWeight = 1f;
			if (this.recoil != null)
			{
				this.recoil.SetHandRotations(this.gunTarget.rotation * rhs, this.gunTarget.rotation * rhs2);
			}
			this.ik.solver.Update();
			if (this.recoil != null)
			{
				this.ik.references.leftHand.rotation = this.recoil.rotationOffset * (this.gunTarget.rotation * rhs);
				this.ik.references.rightHand.rotation = this.recoil.rotationOffset * (this.gunTarget.rotation * rhs2);
			}
			else
			{
				this.ik.references.leftHand.rotation = this.gunTarget.rotation * rhs;
				this.ik.references.rightHand.rotation = this.gunTarget.rotation * rhs2;
			}
			this.cam.transform.position = Vector3.Lerp(this.cam.transform.position, Vector3.Lerp(this.gunTarget.TransformPoint(this.camRelativeToGunTarget), this.gun.transform.TransformPoint(this.camRelativeToGunTarget), this.cameraRecoilWeight), t);
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00043654 File Offset: 0x00041854
		private void RotateCharacter()
		{
			if (this.maxAngle >= 180f)
			{
				return;
			}
			if (this.maxAngle <= 0f)
			{
				base.transform.rotation = Quaternion.LookRotation(new Vector3(this.cam.transform.forward.x, 0f, this.cam.transform.forward.z));
				return;
			}
			Vector3 vector = base.transform.InverseTransformDirection(this.cam.transform.forward);
			float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
			if (Mathf.Abs(num) > Mathf.Abs(this.maxAngle))
			{
				float angle = num - this.maxAngle;
				if (num < 0f)
				{
					angle = num + this.maxAngle;
				}
				base.transform.rotation = Quaternion.AngleAxis(angle, base.transform.up) * base.transform.rotation;
			}
		}

		// Token: 0x04000A35 RID: 2613
		[Range(0f, 1f)]
		public float aimWeight = 1f;

		// Token: 0x04000A36 RID: 2614
		[Range(0f, 1f)]
		public float sightWeight = 1f;

		// Token: 0x04000A37 RID: 2615
		[Range(0f, 180f)]
		public float maxAngle = 80f;

		// Token: 0x04000A38 RID: 2616
		public Vector3 aimOffset;

		// Token: 0x04000A39 RID: 2617
		public bool animatePhysics;

		// Token: 0x04000A3A RID: 2618
		public Transform gun;

		// Token: 0x04000A3B RID: 2619
		public Transform gunTarget;

		// Token: 0x04000A3C RID: 2620
		public FullBodyBipedIK ik;

		// Token: 0x04000A3D RID: 2621
		public AimIK gunAim;

		// Token: 0x04000A3E RID: 2622
		public AimIK headAim;

		// Token: 0x04000A3F RID: 2623
		public CameraControllerFPS cam;

		// Token: 0x04000A40 RID: 2624
		public Recoil recoil;

		// Token: 0x04000A41 RID: 2625
		[Range(0f, 1f)]
		public float cameraRecoilWeight = 0.5f;

		// Token: 0x04000A42 RID: 2626
		private Vector3 gunTargetDefaultLocalPosition;

		// Token: 0x04000A43 RID: 2627
		private Vector3 gunTargetDefaultLocalRotation;

		// Token: 0x04000A44 RID: 2628
		private Vector3 camDefaultLocalPosition;

		// Token: 0x04000A45 RID: 2629
		private Vector3 camRelativeToGunTarget;

		// Token: 0x04000A46 RID: 2630
		private bool updateFrame;
	}
}
