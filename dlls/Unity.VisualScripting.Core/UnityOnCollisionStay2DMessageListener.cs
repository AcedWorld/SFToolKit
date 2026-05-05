using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200008B RID: 139
	[AddComponentMenu("")]
	public sealed class UnityOnCollisionStay2DMessageListener : MessageListener
	{
		// Token: 0x060003E5 RID: 997 RVA: 0x00009710 File Offset: 0x00007910
		private void OnCollisionStay2D(Collision2D collision)
		{
			EventBus.Trigger<Collision2D>("OnCollisionStay2D", base.gameObject, collision);
		}
	}
}
