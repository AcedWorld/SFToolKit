using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200009C RID: 156
	[AddComponentMenu("")]
	public sealed class UnityOnTriggerExit2DMessageListener : MessageListener
	{
		// Token: 0x06000407 RID: 1031 RVA: 0x000098D2 File Offset: 0x00007AD2
		private void OnTriggerExit2D(Collider2D other)
		{
			EventBus.Trigger<Collider2D>("OnTriggerExit2D", base.gameObject, other);
		}
	}
}
