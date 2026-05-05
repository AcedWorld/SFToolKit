using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000084 RID: 132
	public class InitialVelocity : MonoBehaviour
	{
		// Token: 0x06000429 RID: 1065 RVA: 0x00018C48 File Offset: 0x00016E48
		private void Start()
		{
			base.GetComponent<Rigidbody>().velocity = this.initialVelocity;
		}

		// Token: 0x040003BB RID: 955
		public Vector3 initialVelocity;
	}
}
