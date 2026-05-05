using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200008A RID: 138
	[AddComponentMenu("")]
	public sealed class UnityOnCollisionExitMessageListener : MessageListener
	{
		// Token: 0x060003E3 RID: 995 RVA: 0x000096F5 File Offset: 0x000078F5
		private void OnCollisionExit(Collision collision)
		{
			EventBus.Trigger<Collision>("OnCollisionExit", base.gameObject, collision);
		}
	}
}
