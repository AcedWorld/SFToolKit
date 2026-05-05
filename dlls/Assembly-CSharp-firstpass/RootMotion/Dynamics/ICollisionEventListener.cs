using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000073 RID: 115
	public interface ICollisionEventListener
	{
		// Token: 0x060003AA RID: 938
		void OnCollisionEnterEvent(Collision collision, CollisionEventBroadcaster broadcaster);

		// Token: 0x060003AB RID: 939
		void OnCollisionStayEvent(Collision collision, CollisionEventBroadcaster broadcaster);

		// Token: 0x060003AC RID: 940
		void OnCollisionExitEvent(Collision collision, CollisionEventBroadcaster broadcaster);
	}
}
