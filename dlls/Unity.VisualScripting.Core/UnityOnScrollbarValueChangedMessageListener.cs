using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x020000A4 RID: 164
	[AddComponentMenu("")]
	public sealed class UnityOnScrollbarValueChangedMessageListener : MessageListener
	{
		// Token: 0x0600041B RID: 1051 RVA: 0x00009A49 File Offset: 0x00007C49
		private void Start()
		{
			Scrollbar component = base.GetComponent<Scrollbar>();
			if (component == null)
			{
				return;
			}
			Scrollbar.ScrollEvent onValueChanged = component.onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.AddListener(delegate(float value)
			{
				EventBus.Trigger<float>("OnScrollbarValueChanged", base.gameObject, value);
			});
		}
	}
}
