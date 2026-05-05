using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000AB RID: 171
	[AddComponentMenu("")]
	public sealed class UnityOnDragMessageListener : MessageListener, IDragHandler, IEventSystemHandler
	{
		// Token: 0x0600042D RID: 1069 RVA: 0x00009BA6 File Offset: 0x00007DA6
		public void OnDrag(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnDrag", base.gameObject, eventData);
		}
	}
}
