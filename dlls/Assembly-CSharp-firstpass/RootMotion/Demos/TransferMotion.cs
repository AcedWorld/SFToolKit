using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200017C RID: 380
	public class TransferMotion : MonoBehaviour
	{
		// Token: 0x06000AF8 RID: 2808 RVA: 0x00045D08 File Offset: 0x00043F08
		private void OnEnable()
		{
			this.lastPosition = base.transform.position;
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x00045D1C File Offset: 0x00043F1C
		private void Update()
		{
			Vector3 a = base.transform.position - this.lastPosition;
			this.to.position += a * this.transferMotion;
			this.lastPosition = base.transform.position;
		}

		// Token: 0x04000AD8 RID: 2776
		[Tooltip("The Transform to transfer motion to.")]
		public Transform to;

		// Token: 0x04000AD9 RID: 2777
		[Tooltip("The amount of motion to transfer.")]
		[Range(0f, 1f)]
		public float transferMotion = 0.9f;

		// Token: 0x04000ADA RID: 2778
		private Vector3 lastPosition;
	}
}
