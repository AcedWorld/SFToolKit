using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000B5 RID: 181
	[AddComponentMenu("")]
	public sealed class UnityOnSelectMessageListener : MessageListener, ISelectHandler, IEventSystemHandler
	{
		// Token: 0x06000441 RID: 1089 RVA: 0x00009CB4 File Offset: 0x00007EB4
		public void OnSelect(BaseEventData eventData)
		{
			EventBus.Trigger<BaseEventData>("OnSelect", base.gameObject, eventData);
		}
	}
}
