using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200009E RID: 158
	[AddComponentMenu("")]
	public sealed class UnityOnTriggerStay2DMessageListener : MessageListener
	{
		// Token: 0x0600040B RID: 1035 RVA: 0x00009908 File Offset: 0x00007B08
		private void OnTriggerStay2D(Collider2D other)
		{
			EventBus.Trigger<Collider2D>("OnTriggerStay2D", base.gameObject, other);
		}
	}
}
