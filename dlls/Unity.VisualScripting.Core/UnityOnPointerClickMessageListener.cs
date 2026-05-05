using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000AF RID: 175
	[AddComponentMenu("")]
	public sealed class UnityOnPointerClickMessageListener : MessageListener, IPointerClickHandler, IEventSystemHandler
	{
		// Token: 0x06000435 RID: 1077 RVA: 0x00009C12 File Offset: 0x00007E12
		public void OnPointerClick(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnPointerClick", base.gameObject, eventData);
		}
	}
}
