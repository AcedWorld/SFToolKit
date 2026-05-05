using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000AE RID: 174
	[HelpURL("http://www.root-motion.com/finalikdox/html/page5.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/CCD IK")]
	public class CCDIK : IK
	{
		// Token: 0x06000563 RID: 1379 RVA: 0x0002065C File Offset: 0x0001E85C
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page5.html");
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00020668 File Offset: 0x0001E868
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_c_c_d_i_k.html");
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00020674 File Offset: 0x0001E874
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x040004BF RID: 1215
		public IKSolverCCD solver = new IKSolverCCD();
	}
}
