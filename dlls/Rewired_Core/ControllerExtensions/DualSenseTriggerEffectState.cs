using System;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003A9 RID: 937
	public enum DualSenseTriggerEffectState
	{
		// Token: 0x040015A2 RID: 5538
		Unknown = -1,
		// Token: 0x040015A3 RID: 5539
		Off,
		// Token: 0x040015A4 RID: 5540
		FeedbackIdle,
		// Token: 0x040015A5 RID: 5541
		FeedbackApplyingForce,
		// Token: 0x040015A6 RID: 5542
		WeaponIdle,
		// Token: 0x040015A7 RID: 5543
		WeaponFiring,
		// Token: 0x040015A8 RID: 5544
		WeaponFired,
		// Token: 0x040015A9 RID: 5545
		VibrationIdle,
		// Token: 0x040015AA RID: 5546
		VibrationVibrating
	}
}
