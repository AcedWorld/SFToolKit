using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x0200010F RID: 271
	[HelpURL("http://www.root-motion.com/finalikdox/html/page14.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Rotation Limits/Rotation Limit Hinge")]
	public class RotationLimitHinge : RotationLimit
	{
		// Token: 0x0600091B RID: 2331 RVA: 0x00039EC7 File Offset: 0x000380C7
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page14.html");
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00039FA1 File Offset: 0x000381A1
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_rotation_limit_hinge.html");
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00039FAD File Offset: 0x000381AD
		protected override Quaternion LimitRotation(Quaternion rotation)
		{
			return this.LimitHinge(rotation);
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00039FB8 File Offset: 0x000381B8
		private Quaternion LimitHinge(Quaternion rotation)
		{
			if (this.min == 0f && this.max == 0f && this.useLimits)
			{
				return Quaternion.AngleAxis(0f, this.axis);
			}
			Quaternion quaternion = RotationLimit.Limit1DOF(rotation, this.axis);
			if (!this.useLimits)
			{
				return quaternion;
			}
			Vector3 vector = Quaternion.Inverse(Quaternion.AngleAxis(this.lastAngle, this.axis) * Quaternion.LookRotation(base.secondaryAxis, this.axis)) * quaternion * base.secondaryAxis;
			float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
			this.lastAngle = Mathf.Clamp(this.lastAngle + num, this.min, this.max);
			return Quaternion.AngleAxis(this.lastAngle, this.axis);
		}

		// Token: 0x04000851 RID: 2129
		public bool useLimits = true;

		// Token: 0x04000852 RID: 2130
		public float min = -45f;

		// Token: 0x04000853 RID: 2131
		public float max = 90f;

		// Token: 0x04000854 RID: 2132
		[HideInInspector]
		public float zeroAxisDisplayOffset;

		// Token: 0x04000855 RID: 2133
		private float lastAngle;
	}
}
