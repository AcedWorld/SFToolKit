using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000094 RID: 148
	[AddComponentMenu("")]
	public sealed class UnityOnMouseOverMessageListener : MessageListener
	{
		// Token: 0x060003F7 RID: 1015 RVA: 0x000097FF File Offset: 0x000079FF
		private void OnMouseOver()
		{
			EventBus.Trigger("OnMouseOver", base.gameObject);
		}
	}
}
