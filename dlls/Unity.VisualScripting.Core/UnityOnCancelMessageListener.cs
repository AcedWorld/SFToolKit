using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000A9 RID: 169
	[AddComponentMenu("")]
	public sealed class UnityOnCancelMessageListener : MessageListener, ICancelHandler, IEventSystemHandler
	{
		// Token: 0x06000429 RID: 1065 RVA: 0x00009B70 File Offset: 0x00007D70
		public void OnCancel(BaseEventData eventData)
		{
			EventBus.Trigger<BaseEventData>("OnCancel", base.gameObject, eventData);
		}
	}
}
