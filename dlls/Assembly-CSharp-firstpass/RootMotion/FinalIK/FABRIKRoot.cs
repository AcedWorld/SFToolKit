using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000B0 RID: 176
	[HelpURL("http://www.root-motion.com/finalikdox/html/page7.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/FABRIK Root")]
	public class FABRIKRoot : IK
	{
		// Token: 0x0600056F RID: 1391 RVA: 0x000206C2 File Offset: 0x0001E8C2
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page7.html");
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x000206CE File Offset: 0x0001E8CE
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_f_a_b_r_i_k_root.html");
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x000206DA File Offset: 0x0001E8DA
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x040004C1 RID: 1217
		public IKSolverFABRIKRoot solver = new IKSolverFABRIKRoot();
	}
}
