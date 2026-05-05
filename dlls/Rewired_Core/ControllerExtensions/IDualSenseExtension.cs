using System;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003A0 RID: 928
	public interface IDualSenseExtension : IDualShock4Extension, IControllerVibrator
	{
		// Token: 0x0600258F RID: 9615
		bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect);

		// Token: 0x06002590 RID: 9616
		DualSenseTriggerEffectStates GetTriggerEffectStates();
	}
}
