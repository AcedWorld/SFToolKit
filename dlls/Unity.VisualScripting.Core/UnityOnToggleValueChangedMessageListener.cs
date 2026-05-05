using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x020000A7 RID: 167
	[AddComponentMenu("")]
	public sealed class UnityOnToggleValueChangedMessageListener : MessageListener
	{
		// Token: 0x06000424 RID: 1060 RVA: 0x00009B12 File Offset: 0x00007D12
		private void Start()
		{
			Toggle component = base.GetComponent<Toggle>();
			if (component == null)
			{
				return;
			}
			Toggle.ToggleEvent onValueChanged = component.onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.AddListener(delegate(bool value)
			{
				EventBus.Trigger<bool>("OnToggleValueChanged", base.gameObject, value);
			});
		}
	}
}
