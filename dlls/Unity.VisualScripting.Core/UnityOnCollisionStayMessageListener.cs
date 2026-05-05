using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200008C RID: 140
	[AddComponentMenu("")]
	public sealed class UnityOnCollisionStayMessageListener : MessageListener
	{
		// Token: 0x060003E7 RID: 999 RVA: 0x0000972B File Offset: 0x0000792B
		private void OnCollisionStay(Collision collision)
		{
			EventBus.Trigger<Collision>("OnCollisionStay", base.gameObject, collision);
		}
	}
}
