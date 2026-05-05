using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000A8 RID: 168
	[AddComponentMenu("")]
	public sealed class UnityOnBeginDragMessageListener : MessageListener, IBeginDragHandler, IEventSystemHandler
	{
		// Token: 0x06000427 RID: 1063 RVA: 0x00009B55 File Offset: 0x00007D55
		public void OnBeginDrag(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnBeginDrag", base.gameObject, eventData);
		}
	}
}
