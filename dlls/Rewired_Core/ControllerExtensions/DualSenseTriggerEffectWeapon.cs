using System;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	// Token: 0x020003B0 RID: 944
	[Preserve]
	[Serializable]
	public struct DualSenseTriggerEffectWeapon : IDualSenseTriggerEffect
	{
		// Token: 0x170008DB RID: 2267
		// (get) Token: 0x060025EC RID: 9708 RVA: 0x0001BE56 File Offset: 0x0001A056
		// (set) Token: 0x060025ED RID: 9709 RVA: 0x0001BE5E File Offset: 0x0001A05E
		public byte startPosition
		{
			get
			{
				return this._startPosition;
			}
			set
			{
				this._startPosition = DualSenseTriggerEffect.Clamp(value, 2, 7);
			}
		}

		// Token: 0x170008DC RID: 2268
		// (get) Token: 0x060025EE RID: 9710 RVA: 0x0001BE6E File Offset: 0x0001A06E
		// (set) Token: 0x060025EF RID: 9711 RVA: 0x0001BE76 File Offset: 0x0001A076
		public byte endPosition
		{
			get
			{
				return this._endPosition;
			}
			set
			{
				this._endPosition = DualSenseTriggerEffect.Clamp(value, 1, 9);
			}
		}

		// Token: 0x170008DD RID: 2269
		// (get) Token: 0x060025F0 RID: 9712 RVA: 0x0001BE87 File Offset: 0x0001A087
		// (set) Token: 0x060025F1 RID: 9713 RVA: 0x0001BE8F File Offset: 0x0001A08F
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

		// Token: 0x170008DE RID: 2270
		// (get) Token: 0x060025F2 RID: 9714 RVA: 0x0000550E File Offset: 0x0000370E
		DualSenseTriggerEffectType IDualSenseTriggerEffect.triggerEffectType
		{
			get
			{
				return DualSenseTriggerEffectType.Weapon;
			}
		}

		// Token: 0x040015C3 RID: 5571
		[SerializeField]
		private byte _startPosition;

		// Token: 0x040015C4 RID: 5572
		[SerializeField]
		private byte _endPosition;

		// Token: 0x040015C5 RID: 5573
		[SerializeField]
		private byte _strength;
	}
}
