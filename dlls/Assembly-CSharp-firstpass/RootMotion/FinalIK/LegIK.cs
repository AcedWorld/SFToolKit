using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000B4 RID: 180
	[HelpURL("http://www.root-motion.com/finalikdox/html/page11.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/Leg IK")]
	public class LegIK : IK
	{
		// Token: 0x06000590 RID: 1424 RVA: 0x00020B11 File Offset: 0x0001ED11
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page11.html");
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00020B1D File Offset: 0x0001ED1D
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_leg_i_k.html");
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00020B29 File Offset: 0x0001ED29
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x040004C7 RID: 1223
		public IKSolverLeg solver = new IKSolverLeg();
	}
}
