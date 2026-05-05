using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000182 RID: 386
	public class BendGoal : MonoBehaviour
	{
		// Token: 0x06000B12 RID: 2834 RVA: 0x000464AB File Offset: 0x000446AB
		private void Start()
		{
			Debug.Log("BendGoal is deprecated, you can now a bend goal from the custom inspector of the LimbIK component.");
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x000464B7 File Offset: 0x000446B7
		private void LateUpdate()
		{
			if (this.limbIK == null)
			{
				return;
			}
			this.limbIK.solver.SetBendGoalPosition(base.transform.position, this.weight);
		}

		// Token: 0x04000AF6 RID: 2806
		public LimbIK limbIK;

		// Token: 0x04000AF7 RID: 2807
		[Range(0f, 1f)]
		public float weight = 1f;
	}
}
