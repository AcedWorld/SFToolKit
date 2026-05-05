using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.VisualScripting
{
	// Token: 0x020000A0 RID: 160
	[AddComponentMenu("")]
	public sealed class UnityOnButtonClickMessageListener : MessageListener
	{
		// Token: 0x0600040F RID: 1039 RVA: 0x0000993E File Offset: 0x00007B3E
		private void Start()
		{
			Button component = base.GetComponent<Button>();
			if (component == null)
			{
				return;
			}
			Button.ButtonClickedEvent onClick = component.onClick;
			if (onClick == null)
			{
				return;
			}
			onClick.AddListener(delegate()
			{
				EventBus.Trigger("OnButtonClick", base.gameObject);
			});
		}
	}
}
