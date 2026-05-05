using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000B2 RID: 178
	[AddComponentMenu("")]
	public sealed class UnityOnPointerExitMessageListener : MessageListener, IPointerExitHandler, IEventSystemHandler
	{
		// Token: 0x0600043B RID: 1083 RVA: 0x00009C63 File Offset: 0x00007E63
		public void OnPointerExit(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnPointerExit", base.gameObject, eventData);
		}
	}
}
