using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000051 RID: 81
	public class JointBreakBroadcaster : MonoBehaviour
	{
		// Token: 0x06000238 RID: 568 RVA: 0x0000C6C5 File Offset: 0x0000A8C5
		private void OnJointBreak()
		{
			if (!base.enabled)
			{
				return;
			}
			this.puppetMaster.RemoveMuscleRecursive(this.puppetMaster.muscles[this.muscleIndex].joint, true, true, MuscleRemoveMode.Numb);
		}

		// Token: 0x040001F6 RID: 502
		[HideInInspector]
		public PuppetMaster puppetMaster;

		// Token: 0x040001F7 RID: 503
		[HideInInspector]
		public int muscleIndex;
	}
}
