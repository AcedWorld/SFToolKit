using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000B4 RID: 180
	[AddComponentMenu("")]
	public sealed class UnityOnScrollMessageListener : MessageListener, IScrollHandler, IEventSystemHandler
	{
		// Token: 0x0600043F RID: 1087 RVA: 0x00009C99 File Offset: 0x00007E99
		public void OnScroll(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnScroll", base.gameObject, eventData);
		}
	}
}
