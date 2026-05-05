using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000AC RID: 172
	[HelpURL("https://www.youtube.com/watch?v=wT8fViZpLmQ&index=3&list=PLVxSIA1OaTOu8Nos3CalXbJ2DrKnntMv6")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/Aim IK")]
	public class AimIK : IK
	{
		// Token: 0x06000556 RID: 1366 RVA: 0x000205EA File Offset: 0x0001E7EA
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page1.html");
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x000205F6 File Offset: 0x0001E7F6
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_aim_i_k.html");
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00020602 File Offset: 0x0001E802
		[ContextMenu("TUTORIAL VIDEO")]
		private void OpenSetupTutorial()
		{
			Application.OpenURL("https://www.youtube.com/watch?v=wT8fViZpLmQ");
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0002060E File Offset: 0x0001E80E
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x040004BD RID: 1213
		public IKSolverAim solver = new IKSolverAim();
	}
}
