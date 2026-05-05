using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000B6 RID: 182
	[HelpURL("http://www.root-motion.com/finalikdox/html/page13.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/Look At IK")]
	public class LookAtIK : IK
	{
		// Token: 0x0600059C RID: 1436 RVA: 0x00020B77 File Offset: 0x0001ED77
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page13.html");
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00020B83 File Offset: 0x0001ED83
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_look_at_i_k.html");
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x00020B8F File Offset: 0x0001ED8F
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x040004C9 RID: 1225
		public IKSolverLookAt solver = new IKSolverLookAt();
	}
}
