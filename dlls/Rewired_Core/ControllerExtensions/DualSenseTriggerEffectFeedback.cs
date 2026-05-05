using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003AF RID: 943
	[Preserve]
	[Serializable]
	public struct DualSenseTriggerEffectFeedback : IDualSenseTriggerEffect
	{
		// Token: 0x170008D8 RID: 2264
		// (get) Token: 0x060025E7 RID: 9703 RVA: 0x0001BE25 File Offset: 0x0001A025
		// (set) Token: 0x060025E8 RID: 9704 RVA: 0x0001BE2D File Offset: 0x0001A02D
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

		// Token: 0x170008D9 RID: 2265
		// (get) Token: 0x060025E9 RID: 9705 RVA: 0x0001BE3E File Offset: 0x0001A03E
		// (set) Token: 0x060025EA RID: 9706 RVA: 0x0001BE46 File Offset: 0x0001A046
		public byte strength
		{
			get
			{
				return this._strength;
			}
			set
			{
				this._strength = DualSenseTriggerEffect.Clamp(value, 0, 8);
			}
		}

		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x060025EB RID: 9707 RVA: 0x000042E2 File Offset: 0x000024E2
		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType
		{
			get
			{
				return DualSenseTriggerEffectType.Feedback;
			}
		}

		// Token: 0x040015C1 RID: 5569
		[SerializeField]
		private byte _position;

		// Token: 0x040015C2 RID: 5570
		[SerializeField]
		private byte _strength;
	}
}
