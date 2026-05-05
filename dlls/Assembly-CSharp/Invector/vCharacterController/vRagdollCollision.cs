using System;
using UnityEngine;

namespace Invector.vCharacterController
{
	// Token: 0x0200040B RID: 1035
	public class vRagdollCollision
	{
		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06001552 RID: 5458 RVA: 0x0006FCB4 File Offset: 0x0006DEB4
		public GameObject Sender
		{
			get
			{
				return this.sender;
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06001553 RID: 5459 RVA: 0x0006FCBC File Offset: 0x0006DEBC
		public Collision Collision
		{
			get
			{
				return this.collision;
			}
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06001554 RID: 5460 RVA: 0x0006FCC4 File Offset: 0x0006DEC4
		public float ImpactForce
		{
			get
			{
				return this.impactForce;
			}
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x0006FCCC File Offset: 0x0006DECC
		public vRagdollCollision(GameObject sender, Collision collision)
		{
			this.sender = sender;
			this.collision = collision;
			this.impactForce = collision.relativeVelocity.magnitude;
		}

		// Token: 0x04001B39 RID: 6969
		private GameObject sender;

		// Token: 0x04001B3A RID: 6970
		private Collision collision;

		// Token: 0x04001B3B RID: 6971
		private float impactForce;
	}
}
