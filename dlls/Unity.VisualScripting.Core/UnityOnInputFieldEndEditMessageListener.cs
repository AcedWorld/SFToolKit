using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x020000A2 RID: 162
	[AddComponentMenu("")]
	public sealed class UnityOnInputFieldEndEditMessageListener : MessageListener
	{
		// Token: 0x06000415 RID: 1045 RVA: 0x000099C3 File Offset: 0x00007BC3
		private void Start()
		{
			InputField component = base.GetComponent<InputField>();
			if (component == null)
			{
				return;
			}
			InputField.EndEditEvent onEndEdit = component.onEndEdit;
			if (onEndEdit == null)
			{
				return;
			}
			onEndEdit.AddListener(delegate(string value)
			{
				EventBus.Trigger<string>("OnInputFieldEndEdit", base.gameObject, value);
			});
		}
	}
}
