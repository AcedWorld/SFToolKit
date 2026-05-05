using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200009B RID: 155
	[AddComponentMenu("")]
	public sealed class UnityOnTriggerEnterMessageListener : MessageListener
	{
		// Token: 0x06000405 RID: 1029 RVA: 0x000098B7 File Offset: 0x00007AB7
		private void OnTriggerEnter(Collider other)
		{
			EventBus.Trigger<Collider>("OnTriggerEnter", base.gameObject, other);
		}
	}
}
