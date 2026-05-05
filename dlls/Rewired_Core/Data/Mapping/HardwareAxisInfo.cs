using System;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	// Token: 0x02000394 RID: 916
	[Serializable]
	public class HardwareAxisInfo : IDeepCloneable
	{
		// Token: 0x170008A7 RID: 2215
		// (get) Token: 0x06002531 RID: 9521 RVA: 0x0001B4B0 File Offset: 0x000196B0
		public AxisCoordinateMode dataFormat
		{
			get
			{
				return this._dataFormat;
			}
		}

		// Token: 0x170008A8 RID: 2216
		// (get) Token: 0x06002532 RID: 9522 RVA: 0x0001B4B8 File Offset: 0x000196B8
		public bool excludeFromPolling
		{
			get
			{
				return this._excludeFromPolling;
			}
		}

		// Token: 0x170008A9 RID: 2217
		// (get) Token: 0x06002533 RID: 9523 RVA: 0x0001B4C0 File Offset: 0x000196C0
		public SpecialAxisType specialAxisType
		{
			get
			{
				return this._specialAxisType;
			}
		}

		// Token: 0x170008AA RID: 2218
		// (get) Token: 0x06002534 RID: 9524 RVA: 0x0001B4C8 File Offset: 0x000196C8
		public float pollingDeadZone
		{
			get
			{
				return this._pollingDeadZone;
			}
		}

		// Token: 0x06002535 RID: 9525 RVA: 0x0001B4D0 File Offset: 0x000196D0
		public HardwareAxisInfo()
		{
			this._dataFormat = AxisCoordinateMode.Absolute;
			this._excludeFromPolling = false;
			this._specialAxisType = SpecialAxisType.None;
		}

		// Token: 0x06002536 RID: 9526 RVA: 0x0001B4F8 File Offset: 0x000196F8
		[CustomObfuscation(rename = false)]
		internal HardwareAxisInfo(AxisCoordinateMode A_1, bool A_2, float A_3, SpecialAxisType A_4)
		{
			this._dataFormat = A_1;
			this._excludeFromPolling = A_2;
			this._pollingDeadZone = A_3;
			this._specialAxisType = A_4;
		}

		// Token: 0x170008AB RID: 2219
		// (get) Token: 0x06002537 RID: 9527 RVA: 0x0001B528 File Offset: 0x00019728
		[CustomObfuscation(rename = false)]
		internal static HardwareAxisInfo Default
		{
			get
			{
				return new HardwareAxisInfo(AxisCoordinateMode.Absolute, false, -1f, SpecialAxisType.None);
			}
		}

		// Token: 0x06002538 RID: 9528 RVA: 0x0001B537 File Offset: 0x00019737
		public object DeepClone()
		{
			return new HardwareAxisInfo(this._dataFormat, this._excludeFromPolling, this._pollingDeadZone, this._specialAxisType);
		}

		// Token: 0x04001561 RID: 5473
		[SerializeField]
		internal AxisCoordinateMode _dataFormat;

		// Token: 0x04001562 RID: 5474
		[SerializeField]
		internal bool _excludeFromPolling;

		// Token: 0x04001563 RID: 5475
		[SerializeField]
		internal SpecialAxisType _specialAxisType;

		// Token: 0x04001564 RID: 5476
		[SerializeField]
		internal float _pollingDeadZone = -1f;
	}
}
