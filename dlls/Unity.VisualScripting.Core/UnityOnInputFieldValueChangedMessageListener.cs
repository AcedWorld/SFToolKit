using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x020000A3 RID: 163
	[AddComponentMenu("")]
	public sealed class UnityOnInputFieldValueChangedMessageListener : MessageListener
	{
		// Token: 0x06000418 RID: 1048 RVA: 0x00009A06 File Offset: 0x00007C06
		private void Start()
		{
			InputField component = base.GetComponent<InputField>();
			if (component == null)
			{
				return;
			}
			InputField.OnChangeEvent onValueChanged = component.onValueChanged;
			if (onValueChanged == null)
			{
				return;
			}
			onValueChanged.AddListener(delegate(string value)
			{
				EventBus.Trigger<string>("OnInputFieldValueChanged", base.gameObject, value);
			});
		}
	}
}
