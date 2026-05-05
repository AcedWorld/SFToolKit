using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000AC RID: 172
	[AddComponentMenu("")]
	public sealed class UnityOnDropMessageListener : MessageListener, IDropHandler, IEventSystemHandler
	{
		// Token: 0x0600042F RID: 1071 RVA: 0x00009BC1 File Offset: 0x00007DC1
		public void OnDrop(PointerEventData eventData)
		{
			EventBus.Trigger<PointerEventData>("OnDrop", base.gameObject, eventData);
		}
	}
}
