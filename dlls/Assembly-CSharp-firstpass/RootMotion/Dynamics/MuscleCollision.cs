using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000058 RID: 88
	public struct MuscleCollision
	{
		// Token: 0x06000287 RID: 647 RVA: 0x0000E5B6 File Offset: 0x0000C7B6
		public MuscleCollision(int muscleIndex, Collision collision, bool isStay = false)
		{
			this.muscleIndex = muscleIndex;
			this.collision = collision;
			this.isStay = isStay;
		}

		// Token: 0x04000268 RID: 616
		public int muscleIndex;

		// Token: 0x04000269 RID: 617
		public Collision collision;

		// Token: 0x0400026A RID: 618
		public bool isStay;
	}
}
