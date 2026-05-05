using System;
using System.Collections.Generic;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000376 RID: 886
	public class vDestroyOnTrigger : MonoBehaviour
	{
		// Token: 0x060011F5 RID: 4597 RVA: 0x0005FC48 File Offset: 0x0005DE48
		private void OnTriggerEnter(Collider other)
		{
			if (this.targsToDestroy.Contains(other.gameObject.tag))
			{
				Object.Destroy(other.gameObject, this.destroyDelayTime);
			}
		}

		// Token: 0x040017E9 RID: 6121
		public List<string> targsToDestroy;

		// Token: 0x040017EA RID: 6122
		public float destroyDelayTime;
	}
}
