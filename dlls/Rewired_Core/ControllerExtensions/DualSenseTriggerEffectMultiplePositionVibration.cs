using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003B4 RID: 948
	[Preserve]
	[Serializable]
	public struct DualSenseTriggerEffectMultiplePositionVibration : IDualSenseTriggerEffect
	{
		// Token: 0x170008EA RID: 2282
		// (get) Token: 0x06002606 RID: 9734 RVA: 0x0001BF68 File Offset: 0x0001A168
		// (set) Token: 0x06002607 RID: 9735 RVA: 0x0001BF70 File Offset: 0x0001A170
		public byte frequency
		{
			get
			{
				return this._frequency;
			}
			set
			{
				this._frequency = DualSenseTriggerEffect.Clamp(value, 0, byte.MaxValue);
			}
		}

		// Token: 0x170008EB RID: 2283
		// (get) Token: 0x06002608 RID: 9736 RVA: 0x0001BF84 File Offset: 0x0001A184
		// (set) Token: 0x06002609 RID: 9737 RVA: 0x0001BF8C File Offset: 0x0001A18C
		public DualSenseTriggerEffectPositionValueSet amplitude
		{
			get
			{
				return this._amplitude;
			}
			set
			{
				value.nlhOrEBemyyCocIWqDinCxCLQCiZ(0, 8);
				this._amplitude = value;
			}
		}

		// Token: 0x170008EC RID: 2284
		// (get) Token: 0x0600260A RID: 9738 RVA: 0x0001BF9E File Offset: 0x0001A19E
		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType
		{
			get
			{
				return DualSenseTriggerEffectType.MultiplePositionVibration;
			}
		}

		// Token: 0x040015CE RID: 5582
		[SerializeField]
		private byte _frequency;

		// Token: 0x040015CF RID: 5583
		[SerializeField]
		private DualSenseTriggerEffectPositionValueSet _amplitude;
	}
}
