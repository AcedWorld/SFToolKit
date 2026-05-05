using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200018B RID: 395
	public class VRIKPlatform : MonoBehaviour
	{
		// Token: 0x06000B28 RID: 2856 RVA: 0x00046BE0 File Offset: 0x00044DE0
		private void OnEnable()
		{
			this.lastPosition = base.transform.position;
			this.lastRotation = base.transform.rotation;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x00046C04 File Offset: 0x00044E04
		private void LateUpdate()
		{
			this.ik.solver.AddPlatformMotion(base.transform.position - this.lastPosition, base.transform.rotation * Quaternion.Inverse(this.lastRotation), base.transform.position);
			this.lastRotation = base.transform.rotation;
			this.lastPosition = base.transform.position;
		}

		// Token: 0x04000B21 RID: 2849
		public VRIK ik;

		// Token: 0x04000B22 RID: 2850
		private Vector3 lastPosition;

		// Token: 0x04000B23 RID: 2851
		private Quaternion lastRotation = Quaternion.identity;
	}
}
