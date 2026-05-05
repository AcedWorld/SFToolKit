using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000093 RID: 147
	[AddComponentMenu("")]
	public sealed class UnityOnMouseExitMessageListener : MessageListener
	{
		// Token: 0x060003F5 RID: 1013 RVA: 0x000097E5 File Offset: 0x000079E5
		private void OnMouseExit()
		{
			EventBus.Trigger("OnMouseExit", base.gameObject);
		}
	}
}
