using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000B3 RID: 179
	[AddComponentMenu("")]
	public sealed class UnityOnPointerUpMessageListener : MessageListener, IPointerUpHandler, IEventSystemHandler
	{
		// Token: 0x0600043D RID: 1085 RVA: 0x00009C7E File Offset: 0x00007E7E
		public void OnPointerUp(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnPointerUp", base.gameObject, eventData);
		}
	}
}
