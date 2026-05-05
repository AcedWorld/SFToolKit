using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000B6 RID: 182
	[AddComponentMenu("")]
	public sealed class UnityOnSubmitMessageListener : MessageListener, ISubmitHandler, IEventSystemHandler
	{
		// Token: 0x06000443 RID: 1091 RVA: 0x00009CCF File Offset: 0x00007ECF
		public void OnSubmit(BaseEventData eventData)
		{
			EventBus.Trigger<BaseEventData>("OnSubmit", base.gameObject, eventData);
		}
	}
}
