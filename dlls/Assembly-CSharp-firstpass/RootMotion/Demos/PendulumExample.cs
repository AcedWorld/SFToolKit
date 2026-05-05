using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000170 RID: 368
	public class PendulumExample : MonoBehaviour
	{
		// Token: 0x06000ABE RID: 2750 RVA: 0x00044968 File Offset: 0x00042B68
		private void Start()
		{
			this.ik = base.GetComponent<FullBodyBipedIK>();
			Quaternion rotation = this.target.rotation;
			this.target.rotation = this.leftHandTarget.rotation;
			this.target.gameObject.AddComponent<FixedJoint>().connectedBody = this.leftHandTarget.GetComponent<Rigidbody>();
			this.target.GetComponent<Rigidbody>().MoveRotation(rotation);
			this.rootRelativeToPelvis = Quaternion.Inverse(this.pelvisTarget.rotation) * base.transform.rotation;
			this.pelvisToRoot = Quaternion.Inverse(this.ik.references.pelvis.rotation) * (base.transform.position - this.ik.references.pelvis.position);
			this.rootTargetPosition = base.transform.position;
			this.rootTargetRotation = base.transform.rotation;
			this.lastWeight = this.weight;
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x00044A74 File Offset: 0x00042C74
		private void LateUpdate()
		{
			if (this.weight > 0f)
			{
				this.ik.solver.leftHandEffector.positionWeight = this.weight;
				this.ik.solver.leftHandEffector.rotationWeight = this.weight;
			}
			else
			{
				this.rootTargetPosition = base.transform.position;
				this.rootTargetRotation = base.transform.rotation;
				if (this.lastWeight > 0f)
				{
					this.ik.solver.leftHandEffector.positionWeight = 0f;
					this.ik.solver.leftHandEffector.rotationWeight = 0f;
				}
			}
			this.lastWeight = this.weight;
			if (this.weight <= 0f)
			{
				return;
			}
			base.transform.position = Vector3.Lerp(this.rootTargetPosition, this.pelvisTarget.position + this.pelvisTarget.rotation * this.pelvisToRoot * this.hangingDistanceMlp, this.weight);
			base.transform.rotation = Quaternion.Lerp(this.rootTargetRotation, this.pelvisTarget.rotation * this.rootRelativeToPelvis, this.weight);
			this.ik.solver.leftHandEffector.position = this.leftHandTarget.position;
			this.ik.solver.leftHandEffector.rotation = this.leftHandTarget.rotation;
			Vector3 fromDirection = this.ik.references.pelvis.rotation * this.pelvisDownAxis;
			Quaternion b = Quaternion.FromToRotation(fromDirection, this.rightHandTarget.position - this.headTarget.position);
			this.ik.references.rightUpperArm.rotation = Quaternion.Lerp(Quaternion.identity, b, this.weight) * this.ik.references.rightUpperArm.rotation;
			Quaternion b2 = Quaternion.FromToRotation(fromDirection, this.leftFootTarget.position - this.bodyTarget.position);
			this.ik.references.leftThigh.rotation = Quaternion.Lerp(Quaternion.identity, b2, this.weight) * this.ik.references.leftThigh.rotation;
			Quaternion b3 = Quaternion.FromToRotation(fromDirection, this.rightFootTarget.position - this.bodyTarget.position);
			this.ik.references.rightThigh.rotation = Quaternion.Lerp(Quaternion.identity, b3, this.weight) * this.ik.references.rightThigh.rotation;
		}

		// Token: 0x04000A92 RID: 2706
		[Tooltip("The master weight of this script.")]
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x04000A93 RID: 2707
		[Tooltip("Multiplier for the distance of the root to the target.")]
		public float hangingDistanceMlp = 1.3f;

		// Token: 0x04000A94 RID: 2708
		[Tooltip("Where does the root of the character land when weight is blended out?")]
		[HideInInspector]
		public Vector3 rootTargetPosition;

		// Token: 0x04000A95 RID: 2709
		[Tooltip("How is the root of the character rotated when weight is blended out?")]
		[HideInInspector]
		public Quaternion rootTargetRotation;

		// Token: 0x04000A96 RID: 2710
		public Transform target;

		// Token: 0x04000A97 RID: 2711
		public Transform leftHandTarget;

		// Token: 0x04000A98 RID: 2712
		public Transform rightHandTarget;

		// Token: 0x04000A99 RID: 2713
		public Transform leftFootTarget;

		// Token: 0x04000A9A RID: 2714
		public Transform rightFootTarget;

		// Token: 0x04000A9B RID: 2715
		public Transform pelvisTarget;

		// Token: 0x04000A9C RID: 2716
		public Transform bodyTarget;

		// Token: 0x04000A9D RID: 2717
		public Transform headTarget;

		// Token: 0x04000A9E RID: 2718
		public Vector3 pelvisDownAxis = Vector3.right;

		// Token: 0x04000A9F RID: 2719
		private FullBodyBipedIK ik;

		// Token: 0x04000AA0 RID: 2720
		private Quaternion rootRelativeToPelvis;

		// Token: 0x04000AA1 RID: 2721
		private Vector3 pelvisToRoot;

		// Token: 0x04000AA2 RID: 2722
		private float lastWeight;
	}
}
