using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000B1 RID: 177
	[HelpURL("https://www.youtube.com/watch?v=7__IafZGwvI&index=1&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/Full Body Biped IK")]
	public class FullBodyBipedIK : IK
	{
		// Token: 0x06000575 RID: 1397 RVA: 0x000206F5 File Offset: 0x0001E8F5
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page8.html");
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00020701 File Offset: 0x0001E901
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_full_body_biped_i_k.html");
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0002070D File Offset: 0x0001E90D
		[ContextMenu("TUTORIAL VIDEO (SETUP)")]
		private void OpenSetupTutorial()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=7__IafZGwvI");
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00020719 File Offset: 0x0001E919
		[ContextMenu("TUTORIAL VIDEO (INSPECTOR)")]
		private void OpenInspectorTutorial()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=tgRMsTphjJo");
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x00020725 File Offset: 0x0001E925
		public void SetReferences(BipedReferences references, Transform rootNode)
		{
			this.references = references;
			this.solver.SetToReferences(this.references, rootNode);
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00020740 File Offset: 0x0001E940
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00020748 File Offset: 0x0001E948
		public bool ReferencesError(ref string errorMessage)
		{
			if (BipedReferences.SetupError(this.references, ref errorMessage))
			{
				return true;
			}
			if (this.references.spine.Length == 0)
			{
				errorMessage = "References has no spine bones assigned, can not initiate the solver.";
				return true;
			}
			if (this.solver.rootNode == null)
			{
				errorMessage = "Root Node bone is null, can not initiate the solver.";
				return true;
			}
			if (this.solver.rootNode != this.references.pelvis)
			{
				bool flag = false;
				for (int i = 0; i < this.references.spine.Length; i++)
				{
					if (this.solver.rootNode == this.references.spine[i])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					errorMessage = "The Root Node has to be one of the bones in the Spine or the Pelvis, can not initiate the solver.";
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00020800 File Offset: 0x0001EA00
		public bool ReferencesWarning(ref string warningMessage)
		{
			if (BipedReferences.SetupWarning(this.references, ref warningMessage))
			{
				return true;
			}
			Vector3 vector = this.references.rightUpperArm.position - this.references.leftUpperArm.position;
			Vector3 vector2 = this.solver.rootNode.position - this.references.leftUpperArm.position;
			if (Vector3.Dot(vector.normalized, vector2.normalized) > 0.95f)
			{
				warningMessage = "The root node, the left upper arm and the right upper arm bones should ideally form a triangle that is as close to equilateral as possible. Currently the root node bone seems to be very close to the line between the left upper arm and the right upper arm bones. This might cause unwanted behaviour like the spine turning upside down when pulled by a hand effector.Please set the root node bone to be one of the lower bones in the spine.";
				return true;
			}
			Vector3 vector3 = this.references.rightThigh.position - this.references.leftThigh.position;
			Vector3 vector4 = this.solver.rootNode.position - this.references.leftThigh.position;
			if (Vector3.Dot(vector3.normalized, vector4.normalized) > 0.95f)
			{
				warningMessage = "The root node, the left thigh and the right thigh bones should ideally form a triangle that is as close to equilateral as possible. Currently the root node bone seems to be very close to the line between the left thigh and the right thigh bones. This might cause unwanted behaviour like the hip turning upside down when pulled by an effector.Please set the root node bone to be one of the higher bones in the spine.";
				return true;
			}
			return false;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x000208FC File Offset: 0x0001EAFC
		[ContextMenu("Reinitiate")]
		private void Reinitiate()
		{
			this.SetReferences(this.references, this.solver.rootNode);
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00020918 File Offset: 0x0001EB18
		[ContextMenu("Auto-detect References")]
		private void AutoDetectReferences()
		{
			this.references = new BipedReferences();
			BipedReferences.AutoDetectReferences(ref this.references, base.transform, new BipedReferences.AutoDetectParams(true, false));
			this.solver.rootNode = IKSolverFullBodyBiped.DetectRootNodeBone(this.references);
			this.solver.SetToReferences(this.references, this.solver.rootNode);
		}

		// Token: 0x040004C2 RID: 1218
		public BipedReferences references = new BipedReferences();

		// Token: 0x040004C3 RID: 1219
		public IKSolverFullBodyBiped solver = new IKSolverFullBodyBiped();
	}
}
