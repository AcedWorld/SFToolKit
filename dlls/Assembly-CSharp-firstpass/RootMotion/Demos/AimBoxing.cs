using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000148 RID: 328
	public class AimBoxing : MonoBehaviour
	{
		// Token: 0x06000A27 RID: 2599 RVA: 0x00040445 File Offset: 0x0003E645
		private void LateUpdate()
		{
			this.aimIK.solver.transform.LookAt(this.pin.position);
			this.aimIK.solver.IKPosition = base.transform.position;
		}

		// Token: 0x04000981 RID: 2433
		public AimIK aimIK;

		// Token: 0x04000982 RID: 2434
		public Transform pin;
	}
}
