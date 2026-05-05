using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000AA RID: 170
	[AddComponentMenu("")]
	public sealed class UnityOnDeselectMessageListener : MessageListener, IDeselectHandler, IEventSystemHandler
	{
		// Token: 0x0600042B RID: 1067 RVA: 0x00009B8B File Offset: 0x00007D8B
		public void OnDeselect(BaseEventData eventData)
		{
			EventBus.Trigger<BaseEventData>("OnDeselect", base.gameObject, eventData);
		}
	}
}
