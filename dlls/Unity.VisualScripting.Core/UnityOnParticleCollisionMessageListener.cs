using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000097 RID: 151
	[AddComponentMenu("")]
	public sealed class UnityOnParticleCollisionMessageListener : MessageListener
	{
		// Token: 0x060003FD RID: 1021 RVA: 0x0000984D File Offset: 0x00007A4D
		private void OnParticleCollision(GameObject other)
		{
			EventBus.Trigger<GameObject>("OnParticleCollision", base.gameObject, other);
		}
	}
}
