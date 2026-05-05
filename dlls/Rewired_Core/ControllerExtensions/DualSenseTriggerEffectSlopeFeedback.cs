using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003B3 RID: 947
	[Preserve]
	[Serializable]
	public struct DualSenseTriggerEffectSlopeFeedback : IDualSenseTriggerEffect
	{
		// Token: 0x170008E5 RID: 2277
		// (get) Token: 0x060025FD RID: 9725 RVA: 0x0001BF06 File Offset: 0x0001A106
		// (set) Token: 0x060025FE RID: 9726 RVA: 0x0001BF0E File Offset: 0x0001A10E
		public byte startPosition
		{
			get
			{
				return this._startPosition;
			}
			set
			{
				this._startPosition = DualSenseTriggerEffect.Clamp(value, 0, 9);
			}
		}

		// Token: 0x170008E6 RID: 2278
		// (get) Token: 0x060025FF RID: 9727 RVA: 0x0001BF1F File Offset: 0x0001A11F
		// (set) Token: 0x06002600 RID: 9728 RVA: 0x0001BF27 File Offset: 0x0001A127
		public byte endPosition
		{
			get
			{
				return this._endPosition;
			}
			set
			{
				this._endPosition = DualSenseTriggerEffect.Clamp(value, 0, 9);
			}
		}

		// Token: 0x170008E7 RID: 2279
		// (get) Token: 0x06002601 RID: 9729 RVA: 0x0001BF38 File Offset: 0x0001A138
		// (set) Token: 0x06002602 RID: 9730 RVA: 0x0001BF40 File Offset: 0x0001A140
		public byte startStrength
		{
			get
			{
				return this._startStrength;
			}
			set
			{
				this._startStrength = DualSenseTriggerEffect.Clamp(value, 1, 8);
			}
		}

		// Token: 0x170008E8 RID: 2280
		// (get) Token: 0x06002603 RID: 9731 RVA: 0x0001BF50 File Offset: 0x0001A150
		// (set) Token: 0x06002604 RID: 9732 RVA: 0x0001BF58 File Offset: 0x0001A158
		public byte endStrength
		{
			get
			{
				return this._endStrength;
			}
			set
			{
				this._endStrength = DualSenseTriggerEffect.Clamp(value, 1, 8);
			}
		}

		// Token: 0x170008E9 RID: 2281
		// (get) Token: 0x06002605 RID: 9733 RVA: 0x0001938C File Offset: 0x0001758C
		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType
		{
			get
			{
				return DualSenseTriggerEffectType.SlopeFeedback;
			}
		}

		// Token: 0x040015CA RID: 5578
		[SerializeField]
		private byte _startPosition;

		// Token: 0x040015CB RID: 5579
		[SerializeField]
		private byte _endPosition;

		// Token: 0x040015CC RID: 5580
		[SerializeField]
		private byte _startStrength;

		// Token: 0x040015CD RID: 5581
		[SerializeField]
		private byte _endStrength;
	}
}
