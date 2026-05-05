using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	// Token: 0x020000B5 RID: 181
	[HelpURL("http://www.root-motion.com/finalikdox/html/page12.html")]
	[AddComponentMenu("Scripts/RootMotion.FinalIK/IK/Limb IK")]
	public class LimbIK : IK
	{
		// Token: 0x06000596 RID: 1430 RVA: 0x00020B44 File Offset: 0x0001ED44
		[ContextMenu("User Manual")]
		protected override void OpenUserManual()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/page12.html");
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00020B50 File Offset: 0x0001ED50
		[ContextMenu("Scrpt Reference")]
		protected override void OpenScriptReference()
		{
			Application.OpenURL("http://www.root-motion.com/finalikdox/html/class_root_motion_1_1_final_i_k_1_1_limb_i_k.html");
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00002403 File Offset: 0x00000603
		[ContextMenu("Support Group")]
		private void SupportGroup()
		{
			Application.OpenURL("https://groups.google.com/forum/#!forum/final-ik");
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x0000240F File Offset: 0x0000060F
		[ContextMenu("Asset Store Thread")]
		private void ASThread()
		{
			Application.OpenURL("http://forum.unity3d.com/threads/final-ik-full-body-ik-aim-look-at-fabrik-ccd-ik-1-0-released.222685/");
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00020B5C File Offset: 0x0001ED5C
		public override IKSolver GetIKSolver()
		{
			return this.solver;
		}

		// Token: 0x040004C8 RID: 1224
		public IKSolverLimb solver = new IKSolverLimb();
	}
}
