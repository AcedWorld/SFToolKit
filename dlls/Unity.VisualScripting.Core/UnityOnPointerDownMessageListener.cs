using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000B0 RID: 176
	[AddComponentMenu("")]
	public sealed class UnityOnPointerDownMessageListener : MessageListener, IPointerDownHandler, IEventSystemHandler
	{
		// Token: 0x06000437 RID: 1079 RVA: 0x00009C2D File Offset: 0x00007E2D
		public void OnPointerDown(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnPointerDown", base.gameObject, eventData);
		}
	}
}
