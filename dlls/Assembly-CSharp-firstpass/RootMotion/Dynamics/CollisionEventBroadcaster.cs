using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000074 RID: 116
	public class CollisionEventBroadcaster : MonoBehaviour
	{
		// Token: 0x060003AD RID: 941 RVA: 0x0001665B File Offset: 0x0001485B
		private void OnCollisionEnter(Collision collision)
		{
			if (this.listener == null)
			{
				return;
			}
			this.listener.OnCollisionEnterEvent(collision, this);
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00016673 File Offset: 0x00014873
		private void OnCollisionStay(Collision collision)
		{
			if (this.listener == null)
			{
				return;
			}
			this.listener.OnCollisionStayEvent(collision, this);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0001668B File Offset: 0x0001488B
		private void OnCollisionExit(Collision collision)
		{
			if (this.listener == null)
			{
				return;
			}
			this.listener.OnCollisionExitEvent(collision, this);
		}

		// Token: 0x0400033A RID: 826
		public ICollisionEventListener listener;

		// Token: 0x0400033B RID: 827
		public MuscleLite muscle;
	}
}
