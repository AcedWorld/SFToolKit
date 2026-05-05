using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000FB RID: 251
	[HelpURL("https://www.youtube.com/watch?v=r5jiZnsDH3M")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/Interaction System/Interaction Target")]
	public class InteractionTarget : MonoBehaviour
	{
		// Token: 0x060008A0 RID: 2208 RVA: 0x00036379 File Offset: 0x00034579
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page10.html");
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00038301 File Offset: 0x00036501
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_interaction_target.html");
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x00036391 File Offset: 0x00034591
		[ContextMenu("TUTORIAL VIDEO (PART 1: BASICS)")]
		private void OpenTutorial1()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=r5jiZnsDH3M");
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0003639D File Offset: 0x0003459D
		[ContextMenu("TUTORIAL VIDEO (PART 2: PICKING UP...)")]
		private void OpenTutorial2()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=eP9-zycoHLk");
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x000363A9 File Offset: 0x000345A9
		[ContextMenu("TUTORIAL VIDEO (PART 3: ANIMATION)")]
		private void OpenTutorial3()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=sQfB2RcT1T4&index=14&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6");
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x000363B5 File Offset: 0x000345B5
		[ContextMenu("TUTORIAL VIDEO (PART 4: TRIGGERS)")]
		private void OpenTutorial4()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=-TDZpNjt2mk&index=15&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6");
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x00038310 File Offset: 0x00036510
		public float GetValue(InteractionObject.WeightCurve.Type curveType)
		{
			for (int i = 0; i < this.multipliers.Length; i++)
			{
				if (this.multipliers[i].curve == curveType)
				{
					return this.multipliers[i].multiplier;
				}
			}
			return 1f;
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00038353 File Offset: 0x00036553
		public void ResetRotation()
		{
			if (this.pivot != null)
			{
				this.pivot.localRotation = this.defaultLocalRotation;
			}
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x00038374 File Offset: 0x00036574
		public void RotateTo(Transform bone)
		{
			if (this.pivot == null)
			{
				return;
			}
			if (this.pivot != this.lastPivot)
			{
				this.defaultLocalRotation = this.pivot.localRotation;
				this.lastPivot = this.pivot;
			}
			this.pivot.localRotation = this.defaultLocalRotation;
			InteractionTarget.RotationMode rotationMode = this.rotationMode;
			if (rotationMode != InteractionTarget.RotationMode.TwoDOF)
			{
				if (rotationMode != InteractionTarget.RotationMode.ThreeDOF)
				{
					return;
				}
				if (this.threeDOFWeight > 0f)
				{
					Quaternion quaternion = QuaTools.FromToRotation(base.transform.rotation, bone.rotation);
					if (this.threeDOFWeight >= 1f)
					{
						this.pivot.rotation = quaternion * this.pivot.rotation;
						return;
					}
					this.pivot.rotation = Quaternion.Slerp(Quaternion.identity, quaternion, this.threeDOFWeight) * this.pivot.rotation;
				}
			}
			else
			{
				if (this.twistWeight > 0f)
				{
					Vector3 fromDirection = base.transform.position - this.pivot.position;
					Vector3 vector = this.pivot.rotation * this.twistAxis;
					Vector3 vector2 = vector;
					Vector3.OrthoNormalize(ref vector2, ref fromDirection);
					vector2 = vector;
					Vector3 toDirection = bone.position - this.pivot.position;
					Vector3.OrthoNormalize(ref vector2, ref toDirection);
					Quaternion b = QuaTools.FromToAroundAxis(fromDirection, toDirection, vector);
					this.pivot.rotation = Quaternion.Lerp(Quaternion.identity, b, this.twistWeight) * this.pivot.rotation;
				}
				if (this.swingWeight > 0f)
				{
					Quaternion b2 = Quaternion.FromToRotation(base.transform.position - this.pivot.position, bone.position - this.pivot.position);
					this.pivot.rotation = Quaternion.Lerp(Quaternion.identity, b2, this.swingWeight) * this.pivot.rotation;
					return;
				}
			}
		}

		// Token: 0x040007E8 RID: 2024
		[Tooltip("The type of the FBBIK effector.")]
		public FullBodyBipedEffector effectorType;

		// Token: 0x040007E9 RID: 2025
		[Tooltip("InteractionObject weight curve multipliers for this effector target.")]
		public InteractionTarget.Multiplier[] multipliers;

		// Token: 0x040007EA RID: 2026
		[Tooltip("The interaction speed multiplier for this effector. This can be used to make interactions faster/slower for specific effectors.")]
		public float interactionSpeedMlp = 1f;

		// Token: 0x040007EB RID: 2027
		[Tooltip("The pivot to twist/swing this interaction target about. For symmetric objects that can be interacted with from a certain angular range.")]
		public Transform pivot;

		// Token: 0x040007EC RID: 2028
		[Tooltip("2 or 3 degrees of freedom to match this InteractionTarget's rotation to the effector bone rotation.")]
		public InteractionTarget.RotationMode rotationMode;

		// Token: 0x040007ED RID: 2029
		[Tooltip("The axis of twisting the interaction target (blue line).")]
		public Vector3 twistAxis = Vector3.up;

		// Token: 0x040007EE RID: 2030
		[Tooltip("The weight of twisting the interaction target towards the effector bone in the start of the interaction.")]
		public float twistWeight = 1f;

		// Token: 0x040007EF RID: 2031
		[Tooltip("The weight of swinging the interaction target towards the effector bone in the start of the interaction. Swing is defined as a 3-DOF rotation around any axis, while twist is only around the twist axis.")]
		public float swingWeight;

		// Token: 0x040007F0 RID: 2032
		[Tooltip("The weight of rotating this InteractionTarget to the effector bone in the start of the interaction (and during if 'Rotate Once' is disabled")]
		[Range(0f, 1f)]
		public float threeDOFWeight = 1f;

		// Token: 0x040007F1 RID: 2033
		[Tooltip("If true, will twist/swing around the pivot only once at the start of the interaction. If false, will continue rotating throuout the whole interaction.")]
		public bool rotateOnce = true;

		// Token: 0x040007F2 RID: 2034
		[Tooltip("Will not set HandPoser's pose target and allows you to use a pose target from a previous interaction if disabled.")]
		public bool usePoser = true;

		// Token: 0x040007F3 RID: 2035
		[Tooltip("Used only together with UniversalPoser. List of bones must match UniversalPoser's list of bones in both array size and hierarchy.")]
		public Transform[] bones = new Transform[0];

		// Token: 0x040007F4 RID: 2036
		private Quaternion defaultLocalRotation;

		// Token: 0x040007F5 RID: 2037
		private Transform lastPivot;

		// Token: 0x020000FC RID: 252
		[Serializable]
		public enum RotationMode
		{
			// Token: 0x040007F7 RID: 2039
			TwoDOF,
			// Token: 0x040007F8 RID: 2040
			ThreeDOF
		}

		// Token: 0x020000FD RID: 253
		[Serializable]
		public class Multiplier
		{
			// Token: 0x040007F9 RID: 2041
			[Tooltip("The curve type (InteractionObject.WeightCurve.Type).")]
			public InteractionObject.WeightCurve.Type curve;

			// Token: 0x040007FA RID: 2042
			[Tooltip("Multiplier of the curve's value.")]
			public float multiplier;
		}
	}
}
