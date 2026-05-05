using System;
using Rewired.Utils.Attributes;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003AE RID: 942
	[Preserve]
	[Serializable]
	public struct DualSenseTriggerEffectOff : IDualSenseTriggerEffect
	{
		// Token: 0x170008D7 RID: 2263
		// (get) Token: 0x060025E6 RID: 9702 RVA: 0x00003E2B File Offset: 0x0000202B
		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType
		{
			get
			{
				return DualSenseTriggerEffectType.Off;
			}
		}
	}
}
