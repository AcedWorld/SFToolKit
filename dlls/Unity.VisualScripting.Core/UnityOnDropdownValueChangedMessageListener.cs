using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x020000A1 RID: 161
	[AddComponentMenu("")]
	public sealed class UnityOnDropdownValueChangedMessageListener : MessageListener
	{
		// Token: 0x06000412 RID: 1042 RVA: 0x00009980 File Offset: 0x00007B80
		private void Start()
		{
			Dropdown component = base.GetComponent<Dropdown>();
			if (component == null)
			{
				return;
			}
			Dropdown.DropdownEvent onValueChanged = component.onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.AddListener(delegate(int value)
			{
				EventBus.Trigger<int>("OnDropdownValueChanged", base.gameObject, value);
			});
		}
	}
}
