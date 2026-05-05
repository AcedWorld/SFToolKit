using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000091 RID: 145
	[AddComponentMenu("")]
	public sealed class UnityOnMouseDragMessageListener : MessageListener
	{
		// Token: 0x060003F1 RID: 1009 RVA: 0x000097B1 File Offset: 0x000079B1
		private void OnMouseDrag()
		{
			EventBus.Trigger("OnMouseDrag", base.gameObject);
		}
	}
}
