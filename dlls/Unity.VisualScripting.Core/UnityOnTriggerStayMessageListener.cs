using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200009F RID: 159
	[AddComponentMenu("")]
	public sealed class UnityOnTriggerStayMessageListener : MessageListener
	{
		// Token: 0x0600040D RID: 1037 RVA: 0x00009923 File Offset: 0x00007B23
		private void OnTriggerStay(Collider other)
		{
			EventBus.Trigger<Collider>("OnTriggerStay", base.gameObject, other);
		}
	}
}
