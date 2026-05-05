using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000098 RID: 152
	[AddComponentMenu("")]
	public sealed class UnityOnTransformChildrenChangedMessageListener : MessageListener
	{
		// Token: 0x060003FF RID: 1023 RVA: 0x00009868 File Offset: 0x00007A68
		private void OnTransformChildrenChanged()
		{
			EventBus.Trigger("OnTransformChildrenChanged", base.gameObject);
		}
	}
}
