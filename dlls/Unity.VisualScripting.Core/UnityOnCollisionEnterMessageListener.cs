using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000088 RID: 136
	[AddComponentMenu("")]
	public sealed class UnityOnCollisionEnterMessageListener : MessageListener
	{
		// Token: 0x060003DF RID: 991 RVA: 0x000096BF File Offset: 0x000078BF
		private void OnCollisionEnter(Collision collision)
		{
			EventBus.Trigger<Collision>("OnCollisionEnter", base.gameObject, collision);
		}
	}
}
