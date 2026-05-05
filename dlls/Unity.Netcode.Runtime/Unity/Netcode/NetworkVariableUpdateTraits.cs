using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x020000B9 RID: 185
	public struct NetworkVariableUpdateTraits
	{
		// Token: 0x04000251 RID: 593
		[Tooltip("The minimum amount of time that must pass between sending updates. If this amount of time has not passed since the last update, dirtiness will be ignored.")]
		public float MinSecondsBetweenUpdates;

		// Token: 0x04000252 RID: 594
		[Tooltip("The maximum amount of time that a variable can be dirty without sending an update. If this amount of time has passed since the last update, an update will be sent even if the dirtiness threshold has not been met.")]
		public float MaxSecondsBetweenUpdates;
	}
}
