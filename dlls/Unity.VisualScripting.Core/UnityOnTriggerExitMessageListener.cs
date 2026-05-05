using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200009D RID: 157
	[AddComponentMenu("")]
	public sealed class UnityOnTriggerExitMessageListener : MessageListener
	{
		// Token: 0x06000409 RID: 1033 RVA: 0x000098ED File Offset: 0x00007AED
		private void OnTriggerExit(Collider other)
		{
			EventBus.Trigger<Collider>("OnTriggerExit", base.gameObject, other);
		}
	}
}
