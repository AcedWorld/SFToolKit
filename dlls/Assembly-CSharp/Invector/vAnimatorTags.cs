using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x0200034C RID: 844
	public static class vAnimatorTags
	{
		// Token: 0x04001737 RID: 5943
		[Tooltip("Use to lock the controller movement to use the root movement instead")]
		public const string LockMovement = "LockMovement";

		// Token: 0x04001738 RID: 5944
		[Tooltip("Use to lock the controller rotation to use the root rotation instead")]
		public const string LockRotation = "LockRotation";

		// Token: 0x04001739 RID: 5945
		[Tooltip("Use for Generic Actions like push lever, it will lock the players input, movement and rotation and use the animation root motion")]
		public const string CustomAction = "CustomAction";

		// Token: 0x0400173A RID: 5946
		[Tooltip("Use to identify if this is a Airborne animation")]
		public const string Airborne = "Airborne";

		// Token: 0x0400173B RID: 5947
		[Tooltip("Use to Ignore the Headtrack")]
		public const string IgnoreHeadtrack = "IgnoreHeadtrack";

		// Token: 0x0400173C RID: 5948
		[Tooltip("Use to identify a Death animation")]
		public const string Dead = "Dead";
	}
}
