using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200009A RID: 154
	[AddComponentMenu("")]
	public sealed class UnityOnTriggerEnter2DMessageListener : MessageListener
	{
		// Token: 0x06000403 RID: 1027 RVA: 0x0000989C File Offset: 0x00007A9C
		private void OnTriggerEnter2D(Collider2D other)
		{
			EventBus.Trigger<Collider2D>("OnTriggerEnter2D", base.gameObject, other);
		}
	}
}
