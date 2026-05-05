using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000AD RID: 173
	[AddComponentMenu("")]
	public sealed class UnityOnEndDragMessageListener : MessageListener, IEndDragHandler, IEventSystemHandler
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x00009BDC File Offset: 0x00007DDC
		public void OnEndDrag(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnEndDrag", base.gameObject, eventData);
		}
	}
}
