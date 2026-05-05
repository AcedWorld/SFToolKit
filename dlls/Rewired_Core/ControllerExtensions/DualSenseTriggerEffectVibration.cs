using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003B1 RID: 945
	[Preserve]
	[Serializable]
	public struct DualSenseTriggerEffectVibration : IDualSenseTriggerEffect
	{
		// Token: 0x170008DF RID: 2271
		// (get) Token: 0x060025F3 RID: 9715 RVA: 0x0001BE9F File Offset: 0x0001A09F
		// (set) Token: 0x060025F4 RID: 9716 RVA: 0x0001BEA7 File Offset: 0x0001A0A7
		public byte position
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = DualSenseTriggerEffect.Clamp(value, 0, 9);
			}
		}

		// Token: 0x170008E0 RID: 2272
		// (get) Token: 0x060025F5 RID: 9717 RVA: 0x0001BEB8 File Offset: 0x0001A0B8
		// (set) Token: 0x060025F6 RID: 9718 RVA: 0x0001BEC0 File Offset: 0x0001A0C0
		public byte amplitude
		{
			get
			{
				return this._amplitude;
			}
			set
			{
				this._amplitude = DualSenseTriggerEffect.Clamp(value, 0, 8);
			}
		}

		// Token: 0x170008E1 RID: 2273
		// (get) Token: 0x060025F7 RID: 9719 RVA: 0x0001BED0 File Offset: 0x0001A0D0
		// (set) Token: 0x060025F8 RID: 9720 RVA: 0x0001BED8 File Offset: 0x0001A0D8
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

		// Token: 0x170008E2 RID: 2274
		// (get) Token: 0x060025F9 RID: 9721 RVA: 0x00018AC0 File Offset: 0x00016CC0
		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType
		{
			get
			{
				return DualSenseTriggerEffectType.Vibration;
			}
		}

		// Token: 0x040015C6 RID: 5574
		[SerializeField]
		private byte _position;

		// Token: 0x040015C7 RID: 5575
		[SerializeField]
		private byte _amplitude;

		// Token: 0x040015C8 RID: 5576
		[SerializeField]
		private byte _frequency;
	}
}
