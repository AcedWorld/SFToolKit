using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200008D RID: 141
	[AddComponentMenu("")]
	public sealed class UnityOnControllerColliderHitMessageListener : MessageListener
	{
		// Token: 0x060003E9 RID: 1001 RVA: 0x00009746 File Offset: 0x00007946
		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			EventBus.Trigger<ControllerColliderHit>("OnControllerColliderHit", base.gameObject, hit);
		}
	}
}
