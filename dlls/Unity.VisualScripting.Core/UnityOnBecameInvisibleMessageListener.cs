using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000085 RID: 133
	[AddComponentMenu("")]
	public sealed class UnityOnBecameInvisibleMessageListener : MessageListener
	{
		// Token: 0x060003D9 RID: 985 RVA: 0x00009670 File Offset: 0x00007870
		private void OnBecameInvisible()
		{
			EventBus.Trigger("OnBecameInvisible", base.gameObject);
		}
	}
}
