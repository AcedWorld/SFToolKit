using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x02000092 RID: 146
	[HelpURL("http://www.root-motion.com/finalikdox/html/page4.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/Biped IK")]
	public class BipedIK : SolverManager
	{
		// Token: 0x0600046F RID: 1135 RVA: 0x0001BAFB File Offset: 0x00019CFB
		[ContextMenu("User Manual")]
		private void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page4.html");
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0001BB07 File Offset: 0x00019D07
		[ContextMenu("Scrpt Reference")]
		private void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_biped_i_k.html");
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0001BB13 File Offset: 0x00019D13
		public float GetIKPositionWeight(AvatarIKGoal goal)
		{
			return this.GetGoalIK(goal).GetIKPositionWeight();
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0001BB21 File Offset: 0x00019D21
		public float GetIKRotationWeight(AvatarIKGoal goal)
		{
			return this.GetGoalIK(goal).GetIKRotationWeight();
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0001BB2F File Offset: 0x00019D2F
		public void SetIKPositionWeight(AvatarIKGoal goal, float weight)
		{
			this.GetGoalIK(goal).SetIKPositionWeight(weight);
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0001BB3E File Offset: 0x00019D3E
		public void SetIKRotationWeight(AvatarIKGoal goal, float weight)
		{
			this.GetGoalIK(goal).SetIKRotationWeight(weight);
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0001BB4D File Offset: 0x00019D4D
		public void SetIKPosition(AvatarIKGoal goal, Vector3 IKPosition)
		{
			this.GetGoalIK(goal).SetIKPosition(IKPosition);
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0001BB5C File Offset: 0x00019D5C
		public void SetIKRotation(AvatarIKGoal goal, Quaternion IKRotation)
		{
			this.GetGoalIK(goal).SetIKRotation(IKRotation);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0001BB6B File Offset: 0x00019D6B
		public Vector3 GetIKPosition(AvatarIKGoal goal)
		{
			return this.GetGoalIK(goal).GetIKPosition();
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0001BB79 File Offset: 0x00019D79
		public Quaternion GetIKRotation(AvatarIKGoal goal)
		{
			return this.GetGoalIK(goal).GetIKRotation();
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0001BB87 File Offset: 0x00019D87
		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight, float clampWeightHead, float clampWeightEyes)
		{
			this.solvers.lookAt.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight, clampWeight, clampWeightHead, clampWeightEyes);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0001BBA4 File Offset: 0x00019DA4
		public void SetLookAtPosition(Vector3 lookAtPosition)
		{
			this.solvers.lookAt.SetIKPosition(lookAtPosition);
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0001BBB7 File Offset: 0x00019DB7
		public void SetSpinePosition(Vector3 spinePosition)
		{
			this.solvers.spine.SetIKPosition(spinePosition);
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0001BBCA File Offset: 0x00019DCA
		public void SetSpineWeight(float weight)
		{
			this.solvers.spine.SetIKPositionWeight(weight);
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0001BBE0 File Offset: 0x00019DE0
		public IKSolverLimb GetGoalIK(AvatarIKGoal goal)
		{
			switch (goal)
			{
			case AvatarIKGoal.LeftFoot:
				return this.solvers.leftFoot;
			case AvatarIKGoal.RightFoot:
				return this.solvers.rightFoot;
			case AvatarIKGoal.LeftHand:
				return this.solvers.leftHand;
			case AvatarIKGoal.RightHand:
				return this.solvers.rightHand;
			default:
				return null;
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0001BC36 File Offset: 0x00019E36
		public void InitiateBipedIK()
		{
			this.InitiateSolver();
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0001BC3E File Offset: 0x00019E3E
		public void UpdateBipedIK()
		{
			this.UpdateSolver();
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0001BC48 File Offset: 0x00019E48
		public void SetToDefaults()
		{
			foreach (IKSolverLimb iksolverLimb in this.solvers.limbs)
			{
				iksolverLimb.SetIKPositionWeight(0f);
				iksolverLimb.SetIKRotationWeight(0f);
				iksolverLimb.bendModifier = IKSolverLimb.BendModifier.Animation;
				iksolverLimb.bendModifierWeight = 1f;
			}
			this.solvers.leftHand.maintainRotationWeight = 0f;
			this.solvers.rightHand.maintainRotationWeight = 0f;
			this.solvers.spine.SetIKPositionWeight(0f);
			this.solvers.spine.tolerance = 0f;
			this.solvers.spine.maxIterations = 2;
			this.solvers.spine.useRotationLimits = false;
			this.solvers.aim.SetIKPositionWeight(0f);
			this.solvers.aim.tolerance = 0f;
			this.solvers.aim.maxIterations = 2;
			this.SetLookAtWeight(0f, 0.5f, 1f, 1f, 0.5f, 0.7f, 0.5f);
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0001BD73 File Offset: 0x00019F73
		protected override void FixTransforms()
		{
			if (!this.TRANSFORMSFIXED)
			{
				this.TRANSFORMSFIXED = true;
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0001BD84 File Offset: 0x00019F84
		protected override void InitiateSolver()
		{
			string message = "";
			if (BipedReferences.SetupError(this.references, ref message))
			{
				Warning.Log(message, this.references.root, false);
				return;
			}
			this.solvers.AssignReferences(this.references);
			if (this.solvers.spine.bones.Length > 1)
			{
				this.solvers.spine.Initiate(base.transform);
			}
			this.solvers.lookAt.Initiate(base.transform);
			this.solvers.aim.Initiate(base.transform);
			IKSolverLimb[] limbs = this.solvers.limbs;
			for (int i = 0; i < limbs.Length; i++)
			{
				limbs[i].Initiate(base.transform);
			}
			this.solvers.pelvis.Initiate(this.references.pelvis);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0001BE64 File Offset: 0x0001A064
		protected override void UpdateSolver()
		{
			this.solvers.lookAt.FixTransforms();
			for (int i = 0; i < this.solvers.limbs.Length; i++)
			{
				this.solvers.limbs[i].FixTransforms();
				this.solvers.limbs[i].MaintainBend();
				this.solvers.limbs[i].MaintainRotation();
			}
			this.solvers.pelvis.Update();
			if (this.solvers.spine.bones.Length > 1)
			{
				this.solvers.spine.Update();
			}
			this.solvers.aim.Update();
			this.solvers.lookAt.Update();
			for (int j = 0; j < this.solvers.limbs.Length; j++)
			{
				this.solvers.limbs[j].Update();
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0001BF4E File Offset: 0x0001A14E
		public void LogWarning(string message)
		{
			Warning.Log(message, base.transform, false);
		}

		// Token: 0x040003FD RID: 1021
		public bool TRANSFORMSFIXED;

		// Token: 0x040003FE RID: 1022
		public BipedReferences references = new BipedReferences();

		// Token: 0x040003FF RID: 1023
		public BipedIKSolvers solvers = new BipedIKSolvers();
	}
}
