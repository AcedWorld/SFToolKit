using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000092 RID: 146
	[AddComponentMenu("")]
	public sealed class UnityOnMouseEnterMessageListener : MessageListener
	{
		// Token: 0x060003F3 RID: 1011 RVA: 0x000097CB File Offset: 0x000079CB
		private void OnMouseEnter()
		{
			EventBus.Trigger("OnMouseEnter", base.gameObject);
		}
	}
}
