using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000164 RID: 356
	public class HoldingHands : MonoBehaviour
	{
		// Token: 0x06000A97 RID: 2711 RVA: 0x00043948 File Offset: 0x00041B48
		private void Start()
		{
			this.rightHandRotation = Quaternion.Inverse(this.rightHandChar.solver.rightHandEffector.bone.rotation) * base.transform.rotation;
			this.leftHandRotation = Quaternion.Inverse(this.leftHandChar.solver.leftHandEffector.bone.rotation) * base.transform.rotation;
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x000439C0 File Offset: 0x00041BC0
		private void LateUpdate()
		{
			Vector3 b = Vector3.Lerp(this.rightHandChar.solver.rightHandEffector.bone.position, this.leftHandChar.solver.leftHandEffector.bone.position, this.crossFade);
			base.transform.position = Vector3.Lerp(base.transform.position, b, Time.deltaTime * this.speed);
			base.transform.rotation = Quaternion.Slerp(this.rightHandChar.solver.rightHandEffector.bone.rotation * this.rightHandRotation, this.leftHandChar.solver.leftHandEffector.bone.rotation * this.leftHandRotation, this.crossFade);
			this.rightHandChar.solver.rightHandEffector.position = this.rightHandTarget.position;
			this.rightHandChar.solver.rightHandEffector.rotation = this.rightHandTarget.rotation;
			this.leftHandChar.solver.leftHandEffector.position = this.leftHandTarget.position;
			this.leftHandChar.solver.leftHandEffector.rotation = this.leftHandTarget.rotation;
		}

		// Token: 0x04000A4E RID: 2638
		public FullBodyBipedIK rightHandChar;

		// Token: 0x04000A4F RID: 2639
		public FullBodyBipedIK leftHandChar;

		// Token: 0x04000A50 RID: 2640
		public Transform rightHandTarget;

		// Token: 0x04000A51 RID: 2641
		public Transform leftHandTarget;

		// Token: 0x04000A52 RID: 2642
		public float crossFade;

		// Token: 0x04000A53 RID: 2643
		public float speed = 10f;

		// Token: 0x04000A54 RID: 2644
		private Quaternion rightHandRotation;

		// Token: 0x04000A55 RID: 2645
		private Quaternion leftHandRotation;
	}
}
