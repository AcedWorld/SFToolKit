using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200011B RID: 283
	public class BodyTilt : OffsetModifier
	{
		// Token: 0x0600095B RID: 2395 RVA: 0x0003B5ED File Offset: 0x000397ED
		protected override void Start()
		{
			base.Start();
			this.lastForward = base.transform.forward;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0003B608 File Offset: 0x00039808
		protected override void OnModifyOffset()
		{
			Quaternion quaternion = Quaternion.FromToRotation(this.lastForward, base.transform.forward);
			float num = 0f;
			Vector3 zero = Vector3.zero;
			quaternion.ToAngleAxis(out num, out zero);
			if (zero.y > 0f)
			{
				num = -num;
			}
			num *= this.tiltSensitivity * 0.01f;
			num /= base.deltaTime;
			num = Mathf.Clamp(num, -1f, 1f);
			this.tiltAngle = Mathf.Lerp(this.tiltAngle, num, base.deltaTime * this.tiltSpeed);
			float weight = Mathf.Abs(this.tiltAngle) / 1f;
			if (this.tiltAngle < 0f)
			{
				this.poseRight.Apply(this.ik.solver, weight);
			}
			else
			{
				this.poseLeft.Apply(this.ik.solver, weight);
			}
			this.lastForward = base.transform.forward;
		}

		// Token: 0x04000899 RID: 2201
		[Tooltip("Speed of tilting")]
		public float tiltSpeed = 6f;

		// Token: 0x0400089A RID: 2202
		[Tooltip("Sensitivity of tilting")]
		public float tiltSensitivity = 0.07f;

		// Token: 0x0400089B RID: 2203
		[Tooltip("The OffsetPose components")]
		public OffsetPose poseLeft;

		// Token: 0x0400089C RID: 2204
		[Tooltip("The OffsetPose components")]
		public OffsetPose poseRight;

		// Token: 0x0400089D RID: 2205
		private float tiltAngle;

		// Token: 0x0400089E RID: 2206
		private Vector3 lastForward;
	}
}
