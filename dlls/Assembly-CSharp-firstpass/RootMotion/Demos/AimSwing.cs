using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000149 RID: 329
	public class AimSwing : MonoBehaviour
	{
		// Token: 0x06000A29 RID: 2601 RVA: 0x00040484 File Offset: 0x0003E684
		private void LateUpdate()
		{
			this.ik.solver.axis = this.ik.solver.transform.InverseTransformVector(this.ik.transform.rotation * this.animatedAimDirection);
		}

		// Token: 0x04000983 RID: 2435
		public AimIK ik;

		// Token: 0x04000984 RID: 2436
		[Tooltip("The direction in which the weapon is aimed in animation (in character space). Tweak this value to adjust the aiming.")]
		public Vector3 animatedAimDirection = Vector3.forward;
	}
}
