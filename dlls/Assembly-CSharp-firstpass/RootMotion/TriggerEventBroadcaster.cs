using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x02000032 RID: 50
	public class TriggerEventBroadcaster : MonoBehaviour
	{
		// Token: 0x06000134 RID: 308 RVA: 0x00007DCD File Offset: 0x00005FCD
		private void OnTriggerEnter(Collider collider)
		{
			if (this.target != null)
			{
				this.target.SendMessage("OnTriggerEnter", collider, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00007DEF File Offset: 0x00005FEF
		private void OnTriggerStay(Collider collider)
		{
			if (this.target != null)
			{
				this.target.SendMessage("OnTriggerStay", collider, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00007E11 File Offset: 0x00006011
		private void OnTriggerExit(Collider collider)
		{
			if (this.target != null)
			{
				this.target.SendMessage("OnTriggerExit", collider, SendMessageOptions.DontRequireReceiver);
			}
		}

		// Token: 0x0400011D RID: 285
		public GameObject target;
	}
}
