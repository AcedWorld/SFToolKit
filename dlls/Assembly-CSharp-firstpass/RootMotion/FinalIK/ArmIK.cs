using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000AD RID: 173
	[HelpURL("http://www.root-motion.com/finalikdox/html/page2.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/Arm IK")]
	public class ArmIK : IK
	{
		// Token: 0x0600055D RID: 1373 RVA: 0x00020629 File Offset: 0x0001E829
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page2.html");
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00020635 File Offset: 0x0001E835
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_arm_i_k.html");
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x00020641 File Offset: 0x0001E841
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x040004BE RID: 1214
		public IKSolverArm solver = new IKSolverArm();
	}
}
