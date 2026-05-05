using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000087 RID: 135
	[AddComponentMenu("")]
	public sealed class UnityOnCollisionEnter2DMessageListener : MessageListener
	{
		// Token: 0x060003DD RID: 989 RVA: 0x000096A4 File Offset: 0x000078A4
		private void OnCollisionEnter2D(Collision2D collision)
		{
			EventBus.Trigger<Collision2D>("OnCollisionEnter2D", base.gameObject, collision);
		}
	}
}
