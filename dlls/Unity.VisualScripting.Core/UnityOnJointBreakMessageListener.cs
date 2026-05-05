using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200008F RID: 143
	[AddComponentMenu("")]
	public sealed class UnityOnJointBreakMessageListener : MessageListener
	{
		// Token: 0x060003ED RID: 1005 RVA: 0x0000977C File Offset: 0x0000797C
		private void OnJointBreak(float breakForce)
		{
			EventBus.Trigger<float>("OnJointBreak", base.gameObject, breakForce);
		}
	}
}
