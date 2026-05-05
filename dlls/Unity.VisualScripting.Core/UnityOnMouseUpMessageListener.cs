using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000096 RID: 150
	[AddComponentMenu("")]
	public sealed class UnityOnMouseUpMessageListener : MessageListener
	{
		// Token: 0x060003FB RID: 1019 RVA: 0x00009833 File Offset: 0x00007A33
		private void OnMouseUp()
		{
			EventBus.Trigger("OnMouseUp", base.gameObject);
		}
	}
}
