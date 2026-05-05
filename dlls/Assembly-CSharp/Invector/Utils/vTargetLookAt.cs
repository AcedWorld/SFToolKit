using System;
using UnityEngine;

namespace Invector.Utils
{
	// Token: 0x020003C2 RID: 962
	public class vTargetLookAt : MonoBehaviour
	{
		// Token: 0x06001331 RID: 4913 RVA: 0x00064BE8 File Offset: 0x00062DE8
		private void Update()
		{
			if (!this.target)
			{
				return;
			}
			Vector3 vector = this.target.position + Vector3.up * this.offsetHeight - base.transform.position;
			Quaternion b = Quaternion.LookRotation(vector.normalized, Vector3.up);
			if (!this.limitDistance || vector.magnitude > this.minDistanceToLook)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, this.smooth * Time.deltaTime);
			}
		}

		// Token: 0x040018EB RID: 6379
		public Transform target;

		// Token: 0x040018EC RID: 6380
		public float smooth;

		// Token: 0x040018ED RID: 6381
		public float offsetHeight;

		// Token: 0x040018EE RID: 6382
		public bool limitDistance;

		// Token: 0x040018EF RID: 6383
		public float minDistanceToLook;
	}
}
