using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000089 RID: 137
	[AddComponentMenu("")]
	public sealed class UnityOnCollisionExit2DMessageListener : MessageListener
	{
		// Token: 0x060003E1 RID: 993 RVA: 0x000096DA File Offset: 0x000078DA
		private void OnCollisionExit2D(Collision2D collision)
		{
			EventBus.Trigger<Collision2D>("OnCollisionExit2D", base.gameObject, collision);
		}
	}
}
