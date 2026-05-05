using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001B4 RID: 436
	public class RotateShoulderToTarget : MonoBehaviour
	{
		// Token: 0x06000BCB RID: 3019 RVA: 0x000490D2 File Offset: 0x000472D2
		private void OnPuppetMasterRead()
		{
			this.shoulder.rotation = Quaternion.Euler(this.euler) * this.shoulder.rotation;
		}

		// Token: 0x04000BDB RID: 3035
		public Transform shoulder;

		// Token: 0x04000BDC RID: 3036
		public Vector3 euler;
	}
}
