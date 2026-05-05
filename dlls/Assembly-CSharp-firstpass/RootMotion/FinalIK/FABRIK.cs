using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000AF RID: 175
	[HelpURL("http://www.root-motion.com/finalikdox/html/page6.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/FABRIK")]
	public class FABRIK : IK
	{
		// Token: 0x06000569 RID: 1385 RVA: 0x0002068F File Offset: 0x0001E88F
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page6.html");
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0002069B File Offset: 0x0001E89B
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_f_a_b_r_i_k.html");
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x000206A7 File Offset: 0x0001E8A7
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x040004C0 RID: 1216
		public IKSolverFABRIK solver = new IKSolverFABRIK();
	}
}
