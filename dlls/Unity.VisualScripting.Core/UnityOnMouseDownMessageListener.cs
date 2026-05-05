using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000090 RID: 144
	[AddComponentMenu("")]
	public sealed class UnityOnMouseDownMessageListener : MessageListener
	{
		// Token: 0x060003EF RID: 1007 RVA: 0x00009797 File Offset: 0x00007997
		private void OnMouseDown()
		{
			EventBus.Trigger("OnMouseDown", base.gameObject);
		}
	}
}
