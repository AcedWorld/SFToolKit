using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x020000A5 RID: 165
	[AddComponentMenu("")]
	public sealed class UnityOnScrollRectValueChangedMessageListener : MessageListener
	{
		// Token: 0x0600041E RID: 1054 RVA: 0x00009A8C File Offset: 0x00007C8C
		private void Start()
		{
			ScrollRect component = base.GetComponent<ScrollRect>();
			if (component == null)
			{
				return;
			}
			ScrollRect.ScrollRectEvent onValueChanged = component.onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.AddListener(delegate(Vector2 value)
			{
				EventBus.Trigger<Vector2>("OnScrollRectValueChanged", base.gameObject, value);
			});
		}
	}
}
