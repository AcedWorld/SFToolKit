using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000B1 RID: 177
	[AddComponentMenu("")]
	public sealed class UnityOnPointerEnterMessageListener : MessageListener, IPointerEnterHandler, IEventSystemHandler
	{
		// Token: 0x06000439 RID: 1081 RVA: 0x00009C48 File Offset: 0x00007E48
		public void OnPointerEnter(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnPointerEnter", base.gameObject, eventData);
		}
	}
}
