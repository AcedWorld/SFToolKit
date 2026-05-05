using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000086 RID: 134
	[AddComponentMenu("")]
	public sealed class UnityOnBecameVisibleMessageListener : MessageListener
	{
		// Token: 0x060003DB RID: 987 RVA: 0x0000968A File Offset: 0x0000788A
		private void OnBecameVisible()
		{
			EventBus.Trigger("OnBecameVisible", base.gameObject);
		}
	}
}
