using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000059 RID: 89
	public struct MuscleHit
	{
		// Token: 0x06000288 RID: 648 RVA: 0x0000E5CD File Offset: 0x0000C7CD
		public MuscleHit(int muscleIndex, float unPin, Vector3 force, Vector3 position)
		{
			this.muscleIndex = muscleIndex;
			this.unPin = unPin;
			this.force = force;
			this.position = position;
		}

		// Token: 0x0400026B RID: 619
		public int muscleIndex;

		// Token: 0x0400026C RID: 620
		public float unPin;

		// Token: 0x0400026D RID: 621
		public Vector3 force;

		// Token: 0x0400026E RID: 622
		public Vector3 position;
	}
}
