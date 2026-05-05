using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000113 RID: 275
	[HelpURL("http://www.root-motion.com/finalikdox/html/page14.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Rotation Limits/Rotation Limit Spline")]
	public class RotationLimitSpline : RotationLimit
	{
		// Token: 0x0600093A RID: 2362 RVA: 0x00039EC7 File Offset: 0x000380C7
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page14.html");
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0003A93F File Offset: 0x00038B3F
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_rotation_limit_spline.html");
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0003A94B File Offset: 0x00038B4B
		public void SetSpline(Keyframe[] keyframes)
		{
			this.spline.keys = keyframes;
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0003A959 File Offset: 0x00038B59
		protected override Quaternion LimitRotation(Quaternion rotation)
		{
			return RotationLimit.LimitTwist(this.LimitSwing(rotation), this.axis, base.secondaryAxis, this.twistLimit);
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x0003A97C File Offset: 0x00038B7C
		public Quaternion LimitSwing(Quaternion rotation)
		{
			if (this.axis == Vector3.zero)
			{
				return rotation;
			}
			if (rotation == Quaternion.identity)
			{
				return rotation;
			}
			Vector3 vector = rotation * this.axis;
			float num = RotationLimit.GetOrthogonalAngle(vector, base.secondaryAxis, this.axis);
			if (Vector3.Dot(vector, base.crossAxis) < 0f)
			{
				num = 180f + (180f - num);
			}
			float maxDegreesDelta = this.spline.Evaluate(num);
			Quaternion to = Quaternion.FromToRotation(this.axis, vector);
			Quaternion rotation2 = Quaternion.RotateTowards(Quaternion.identity, to, maxDegreesDelta);
			return Quaternion.FromToRotation(vector, rotation2 * this.axis) * rotation;
		}

		// Token: 0x04000861 RID: 2145
		[Range(0f, 180f)]
		public float twistLimit = 180f;

		// Token: 0x04000862 RID: 2146
		[HideInInspector]
		public AnimationCurve spline;
	}
}
