using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000B7 RID: 183
	[HelpURL("http://www.root-motion.com/finalikdox/html/page15.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/Trigonometric IK")]
	public class TrigonometricIK : IK
	{
		// Token: 0x060005A2 RID: 1442 RVA: 0x00020BAA File Offset: 0x0001EDAA
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page15.html");
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00020BB6 File Offset: 0x0001EDB6
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_trigonometric_i_k.html");
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x00020BC2 File Offset: 0x0001EDC2
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x040004CA RID: 1226
		public IKSolverTrigonometric solver = new IKSolverTrigonometric();
	}
}
