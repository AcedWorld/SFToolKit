using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unity.VisualScripting
{
	// Token: 0x020000AE RID: 174
	[AddComponentMenu("")]
	public sealed class UnityOnMoveMessageListener : MessageListener, IMoveHandler, IEventSystemHandler
	{
		// Token: 0x06000433 RID: 1075 RVA: 0x00009BF7 File Offset: 0x00007DF7
		public void OnMove(AxisEventData eventData)
		{
			EventBus.Trigger<AxisEventData>("OnMove", base.gameObject, eventData);
		}
	}
}
