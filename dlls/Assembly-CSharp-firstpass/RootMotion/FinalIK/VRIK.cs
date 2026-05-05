using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000B8 RID: 184
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/VR IK")]
	public class VRIK : IK
	{
		// Token: 0x060005A8 RID: 1448 RVA: 0x00020BDD File Offset: 0x0001EDDD
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page16.html");
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x00020BE9 File Offset: 0x0001EDE9
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_v_r_i_k.html");
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x00020BF5 File Offset: 0x0001EDF5
		[ContextMenu("TUTORIAL VIDEO (STEAMVR SETUP)")]
		private void OpenSetupTutorial()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=6Pfx7lYQiIA&feature=youtu.be");
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x00020C01 File Offset: 0x0001EE01
		[ContextMenu("Auto-detect References")]
		public void AutoDetectReferences()
		{
			VRIK.References.AutoDetectReferences(base.transform, out this.references);
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x00020C15 File Offset: 0x0001EE15
		[ContextMenu("Guess Hand Orientations")]
		public void GuessHandOrientations()
		{
			this.solver.GuessHandOrientations(this.references, false);
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x00020C29 File Offset: 0x0001EE29
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00020C31 File Offset: 0x0001EE31
		protected override void InitiateSolver()
		{
			if (this.references.isEmpty)
			{
				this.AutoDetectReferences();
			}
			if (this.references.isFilled)
			{
				this.solver.SetToReferences(this.references);
			}
			base.InitiateSolver();
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00020C6C File Offset: 0x0001EE6C
		protected override void UpdateSolver()
		{
			if (this.references.root != null && this.references.root.localScale == Vector3.zero)
			{
				Debug.LogError("VRIK Root Transform's scale is zero, can not update VRIK. Make sure you have not calibrated the character to a zero scale.", base.transform);
				base.enabled = false;
				return;
			}
			base.UpdateSolver();
		}

		// Token: 0x040004CB RID: 1227
		[ContextMenuItem("Auto-detect References", "AutoDetectReferences")]
		[Tooltip("Bone mapping. Right-click on the component header and select 'Auto-detect References' of fill in manually if not a Humanoid character. Chest, neck, shoulder and toe bones are optional. VRIK also supports legless characters. If you do not wish to use legs, leave all leg references empty.")]
		public VRIK.References references = new VRIK.References();

		// Token: 0x040004CC RID: 1228
		[Tooltip("The VRIK solver.")]
		public IKSolverVR solver = new IKSolverVR();

		// Token: 0x020000B9 RID: 185
		[Serializable]
		public class References
		{
			// Token: 0x060005B1 RID: 1457 RVA: 0x00002226 File Offset: 0x00000426
			public References()
			{
			}

			// Token: 0x060005B2 RID: 1458 RVA: 0x00020CE4 File Offset: 0x0001EEE4
			public References(BipedReferences b)
			{
				this.root = b.root;
				this.pelvis = b.pelvis;
				this.spine = b.spine[0];
				this.chest = ((b.spine.Length > 1) ? b.spine[1] : null);
				this.head = b.head;
				this.leftShoulder = b.leftUpperArm.parent;
				this.leftUpperArm = b.leftUpperArm;
				this.leftForearm = b.leftForearm;
				this.leftHand = b.leftHand;
				this.rightShoulder = b.rightUpperArm.parent;
				this.rightUpperArm = b.rightUpperArm;
				this.rightForearm = b.rightForearm;
				this.rightHand = b.rightHand;
				this.leftThigh = b.leftThigh;
				this.leftCalf = b.leftCalf;
				this.leftFoot = b.leftFoot;
				this.leftToes = b.leftFoot.GetChild(0);
				this.rightThigh = b.rightThigh;
				this.rightCalf = b.rightCalf;
				this.rightFoot = b.rightFoot;
				this.rightToes = b.rightFoot.GetChild(0);
			}

			// Token: 0x060005B3 RID: 1459 RVA: 0x00020E1C File Offset: 0x0001F01C
			public Transform[] GetTransforms()
			{
				return new Transform[]
				{
					this.root,
					this.pelvis,
					this.spine,
					this.chest,
					this.neck,
					this.head,
					this.leftShoulder,
					this.leftUpperArm,
					this.leftForearm,
					this.leftHand,
					this.rightShoulder,
					this.rightUpperArm,
					this.rightForearm,
					this.rightHand,
					this.leftThigh,
					this.leftCalf,
					this.leftFoot,
					this.leftToes,
					this.rightThigh,
					this.rightCalf,
					this.rightFoot,
					this.rightToes
				};
			}

			// Token: 0x1700009D RID: 157
			// (get) Token: 0x060005B4 RID: 1460 RVA: 0x00020F04 File Offset: 0x0001F104
			public bool isFilled
			{
				get
				{
					if (this.root == null || this.pelvis == null || this.spine == null || this.head == null)
					{
						return false;
					}
					bool flag = this.leftUpperArm == null && this.leftForearm == null && this.leftHand == null && this.rightUpperArm == null && this.rightForearm == null && this.rightHand == null;
					bool flag2 = this.leftUpperArm == null || this.leftForearm == null || this.leftHand == null || this.rightUpperArm == null || this.rightForearm == null || this.rightHand == null;
					bool flag3 = this.leftThigh == null && this.leftCalf == null && this.leftFoot == null && this.rightThigh == null && this.rightCalf == null && this.rightFoot == null;
					return ((!(this.leftThigh == null) && !(this.leftCalf == null) && !(this.leftFoot == null) && !(this.rightThigh == null) && !(this.rightCalf == null) && !(this.rightFoot == null)) || flag3) && (!flag2 || flag);
				}
			}

			// Token: 0x1700009E RID: 158
			// (get) Token: 0x060005B5 RID: 1461 RVA: 0x000210B4 File Offset: 0x0001F2B4
			public bool isEmpty
			{
				get
				{
					return !(this.root != null) && !(this.pelvis != null) && !(this.spine != null) && !(this.chest != null) && !(this.neck != null) && !(this.head != null) && !(this.leftShoulder != null) && !(this.leftUpperArm != null) && !(this.leftForearm != null) && !(this.leftHand != null) && !(this.rightShoulder != null) && !(this.rightUpperArm != null) && !(this.rightForearm != null) && !(this.rightHand != null) && !(this.leftThigh != null) && !(this.leftCalf != null) && !(this.leftFoot != null) && !(this.leftToes != null) && !(this.rightThigh != null) && !(this.rightCalf != null) && !(this.rightFoot != null) && !(this.rightToes != null);
				}
			}

			// Token: 0x060005B6 RID: 1462 RVA: 0x0002121C File Offset: 0x0001F41C
			public static bool AutoDetectReferences(Transform root, out VRIK.References references)
			{
				references = new VRIK.References();
				Animator componentInChildren = root.GetComponentInChildren<Animator>();
				if (componentInChildren == null || !componentInChildren.isHuman)
				{
					Debug.LogWarning("VRIK needs a Humanoid Animator to auto-detect biped references. Please assign references manually.");
					return false;
				}
				references.root = root;
				references.pelvis = componentInChildren.GetBoneTransform(HumanBodyBones.Hips);
				references.spine = componentInChildren.GetBoneTransform(HumanBodyBones.Spine);
				references.chest = componentInChildren.GetBoneTransform(HumanBodyBones.Chest);
				references.neck = componentInChildren.GetBoneTransform(HumanBodyBones.Neck);
				references.head = componentInChildren.GetBoneTransform(HumanBodyBones.Head);
				references.leftShoulder = componentInChildren.GetBoneTransform(HumanBodyBones.LeftShoulder);
				references.leftUpperArm = componentInChildren.GetBoneTransform(HumanBodyBones.LeftUpperArm);
				references.leftForearm = componentInChildren.GetBoneTransform(HumanBodyBones.LeftLowerArm);
				references.leftHand = componentInChildren.GetBoneTransform(HumanBodyBones.LeftHand);
				references.rightShoulder = componentInChildren.GetBoneTransform(HumanBodyBones.RightShoulder);
				references.rightUpperArm = componentInChildren.GetBoneTransform(HumanBodyBones.RightUpperArm);
				references.rightForearm = componentInChildren.GetBoneTransform(HumanBodyBones.RightLowerArm);
				references.rightHand = componentInChildren.GetBoneTransform(HumanBodyBones.RightHand);
				references.leftThigh = componentInChildren.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
				references.leftCalf = componentInChildren.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
				references.leftFoot = componentInChildren.GetBoneTransform(HumanBodyBones.LeftFoot);
				references.leftToes = componentInChildren.GetBoneTransform(HumanBodyBones.LeftToes);
				references.rightThigh = componentInChildren.GetBoneTransform(HumanBodyBones.RightUpperLeg);
				references.rightCalf = componentInChildren.GetBoneTransform(HumanBodyBones.RightLowerLeg);
				references.rightFoot = componentInChildren.GetBoneTransform(HumanBodyBones.RightFoot);
				references.rightToes = componentInChildren.GetBoneTransform(HumanBodyBones.RightToes);
				return true;
			}

			// Token: 0x040004CD RID: 1229
			public Transform root;

			// Token: 0x040004CE RID: 1230
			[LargeHeader("Spine")]
			public Transform pelvis;

			// Token: 0x040004CF RID: 1231
			public Transform spine;

			// Token: 0x040004D0 RID: 1232
			[Tooltip("Optional")]
			public Transform chest;

			// Token: 0x040004D1 RID: 1233
			[Tooltip("Optional")]
			public Transform neck;

			// Token: 0x040004D2 RID: 1234
			public Transform head;

			// Token: 0x040004D3 RID: 1235
			[LargeHeader("Left Arm")]
			[Tooltip("Optional")]
			public Transform leftShoulder;

			// Token: 0x040004D4 RID: 1236
			[Tooltip("VRIK also supports armless characters.If you do not wish to use arms, leave all arm references empty.")]
			public Transform leftUpperArm;

			// Token: 0x040004D5 RID: 1237
			[Tooltip("VRIK also supports armless characters.If you do not wish to use arms, leave all arm references empty.")]
			public Transform leftForearm;

			// Token: 0x040004D6 RID: 1238
			[Tooltip("VRIK also supports armless characters.If you do not wish to use arms, leave all arm references empty.")]
			public Transform leftHand;

			// Token: 0x040004D7 RID: 1239
			[LargeHeader("Right Arm")]
			[Tooltip("Optional")]
			public Transform rightShoulder;

			// Token: 0x040004D8 RID: 1240
			[Tooltip("VRIK also supports armless characters.If you do not wish to use arms, leave all arm references empty.")]
			public Transform rightUpperArm;

			// Token: 0x040004D9 RID: 1241
			[Tooltip("VRIK also supports armless characters.If you do not wish to use arms, leave all arm references empty.")]
			public Transform rightForearm;

			// Token: 0x040004DA RID: 1242
			[Tooltip("VRIK also supports armless characters.If you do not wish to use arms, leave all arm references empty.")]
			public Transform rightHand;

			// Token: 0x040004DB RID: 1243
			[LargeHeader("Left Leg")]
			[Tooltip("VRIK also supports legless characters.If you do not wish to use legs, leave all leg references empty.")]
			public Transform leftThigh;

			// Token: 0x040004DC RID: 1244
			[Tooltip("VRIK also supports legless characters.If you do not wish to use legs, leave all leg references empty.")]
			public Transform leftCalf;

			// Token: 0x040004DD RID: 1245
			[Tooltip("VRIK also supports legless characters.If you do not wish to use legs, leave all leg references empty.")]
			public Transform leftFoot;

			// Token: 0x040004DE RID: 1246
			[Tooltip("Optional")]
			public Transform leftToes;

			// Token: 0x040004DF RID: 1247
			[LargeHeader("Right Leg")]
			[Tooltip("VRIK also supports legless characters.If you do not wish to use legs, leave all leg references empty.")]
			public Transform rightThigh;

			// Token: 0x040004E0 RID: 1248
			[Tooltip("VRIK also supports legless characters.If you do not wish to use legs, leave all leg references empty.")]
			public Transform rightCalf;

			// Token: 0x040004E1 RID: 1249
			[Tooltip("VRIK also supports legless characters.If you do not wish to use legs, leave all leg references empty.")]
			public Transform rightFoot;

			// Token: 0x040004E2 RID: 1250
			[Tooltip("Optional")]
			public Transform rightToes;
		}
	}
}
