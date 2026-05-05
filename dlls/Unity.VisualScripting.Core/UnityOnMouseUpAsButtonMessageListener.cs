using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000095 RID: 149
	[AddComponentMenu("")]
	public sealed class UnityOnMouseUpAsButtonMessageListener : MessageListener
	{
		// Token: 0x060003F9 RID: 1017 RVA: 0x00009819 File Offset: 0x00007A19
		private void OnMouseUpAsButton()
		{
			EventBus.Trigger("OnMouseUpAsButton", base.gameObject);
		}
	}
}
