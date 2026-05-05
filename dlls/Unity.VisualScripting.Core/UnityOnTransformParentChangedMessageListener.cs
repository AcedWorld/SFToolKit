using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000099 RID: 153
	[AddComponentMenu("")]
	public sealed class UnityOnTransformParentChangedMessageListener : MessageListener
	{
		// Token: 0x06000401 RID: 1025 RVA: 0x00009882 File Offset: 0x00007A82
		private void OnTransformParentChanged()
		{
			EventBus.Trigger("OnTransformParentChanged", base.gameObject);
		}
	}
}
