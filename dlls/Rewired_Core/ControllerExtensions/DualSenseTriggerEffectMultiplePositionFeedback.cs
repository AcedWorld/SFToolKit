using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003B2 RID: 946
	[Preserve]
	[Serializable]
	public struct DualSenseTriggerEffectMultiplePositionFeedback : IDualSenseTriggerEffect
	{
		// Token: 0x170008E3 RID: 2275
		// (get) Token: 0x060025FA RID: 9722 RVA: 0x0001BEEC File Offset: 0x0001A0EC
		// (set) Token: 0x060025FB RID: 9723 RVA: 0x0001BEF4 File Offset: 0x0001A0F4
		public DualSenseTriggerEffectPositionValueSet strength
		{
			get
			{
				return this._strength;
			}
			set
			{
				value.nlhOrEBemyyCocIWqDinCxCLQCiZ(0, 8);
				this._strength = value;
			}
		}

		// Token: 0x170008E4 RID: 2276
		// (get) Token: 0x060025FC RID: 9724 RVA: 0x000057C4 File Offset: 0x000039C4
		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType
		{
			get
			{
				return DualSenseTriggerEffectType.MultiplePositionFeedback;
			}
		}

		// Token: 0x040015C9 RID: 5577
		[SerializeField]
		private DualSenseTriggerEffectPositionValueSet _strength;
	}
}
