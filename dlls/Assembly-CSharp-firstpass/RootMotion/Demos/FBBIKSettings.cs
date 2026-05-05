using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200015C RID: 348
	public class FBBIKSettings : MonoBehaviour
	{
		// Token: 0x06000A78 RID: 2680 RVA: 0x00042B40 File Offset: 0x00040D40
		public void UpdateSettings()
		{
			if (this.ik == null)
			{
				return;
			}
			this.leftArm.Apply(FullBodyBipedChain.LeftArm, this.ik.solver);
			this.rightArm.Apply(FullBodyBipedChain.RightArm, this.ik.solver);
			this.leftLeg.Apply(FullBodyBipedChain.LeftLeg, this.ik.solver);
			this.rightLeg.Apply(FullBodyBipedChain.RightLeg, this.ik.solver);
			this.ik.solver.chain[0].pin = this.rootPin;
			this.ik.solver.bodyEffector.effectChildNodes = this.bodyEffectChildNodes;
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00042BF0 File Offset: 0x00040DF0
		private void Start()
		{
			Debug.Log("FBBIKSettings is deprecated, you can now edit all the settings from the custom inspector of the FullBodyBipedIK component.");
			this.UpdateSettings();
			if (this.disableAfterStart)
			{
				base.enabled = false;
			}
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00042C11 File Offset: 0x00040E11
		private void Update()
		{
			this.UpdateSettings();
		}

		// Token: 0x04000A1D RID: 2589
		public FullBodyBipedIK ik;

		// Token: 0x04000A1E RID: 2590
		public bool disableAfterStart;

		// Token: 0x04000A1F RID: 2591
		public FBBIKSettings.Limb leftArm;

		// Token: 0x04000A20 RID: 2592
		public FBBIKSettings.Limb rightArm;

		// Token: 0x04000A21 RID: 2593
		public FBBIKSettings.Limb leftLeg;

		// Token: 0x04000A22 RID: 2594
		public FBBIKSettings.Limb rightLeg;

		// Token: 0x04000A23 RID: 2595
		public float rootPin;

		// Token: 0x04000A24 RID: 2596
		public bool bodyEffectChildNodes = true;

		// Token: 0x0200015D RID: 349
		[Serializable]
		public class Limb
		{
			// Token: 0x06000A7C RID: 2684 RVA: 0x00042C28 File Offset: 0x00040E28
			public void Apply(FullBodyBipedChain chain, IKSolverFullBodyBiped solver)
			{
				solver.GetChain(chain).reachSmoothing = this.reachSmoothing;
				solver.GetEndEffector(chain).maintainRelativePositionWeight = this.maintainRelativePositionWeight;
				solver.GetLimbMapping(chain).weight = this.mappingWeight;
			}

			// Token: 0x04000A25 RID: 2597
			public FBIKChain.Smoothing reachSmoothing;

			// Token: 0x04000A26 RID: 2598
			public float maintainRelativePositionWeight;

			// Token: 0x04000A27 RID: 2599
			public float mappingWeight = 1f;
		}
	}
}
