using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200015E RID: 350
	public class FBIKBendGoal : MonoBehaviour
	{
		// Token: 0x06000A7E RID: 2686 RVA: 0x00042C73 File Offset: 0x00040E73
		private void Start()
		{
			Debug.Log("FBIKBendGoal is deprecated, you can now a bend goal from the custom inspector of the FullBodyBipedIK component.");
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x00042C80 File Offset: 0x00040E80
		private void Update()
		{
			if (this.ik == null)
			{
				return;
			}
			this.ik.solver.GetBendConstraint(this.chain).bendGoal = base.transform;
			this.ik.solver.GetBendConstraint(this.chain).weight = this.weight;
		}

		// Token: 0x04000A28 RID: 2600
		public FullBodyBipedIK ik;

		// Token: 0x04000A29 RID: 2601
		public FullBodyBipedChain chain;

		// Token: 0x04000A2A RID: 2602
		public float weight;
	}
}
