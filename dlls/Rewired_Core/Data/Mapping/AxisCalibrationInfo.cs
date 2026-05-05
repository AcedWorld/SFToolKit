using System;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	// Token: 0x02000396 RID: 918
	[Serializable]
	public class AxisCalibrationInfo : IDeepCloneable
	{
		// Token: 0x170008AE RID: 2222
		// (get) Token: 0x0600253E RID: 9534 RVA: 0x0001B5A5 File Offset: 0x000197A5
		// (set) Token: 0x0600253F RID: 9535 RVA: 0x0001B5AD File Offset: 0x000197AD
		public bool applyRangeCalibration
		{
			get
			{
				return this._applyRangeCalibration;
			}
			set
			{
				this._applyRangeCalibration = value;
			}
		}

		// Token: 0x170008AF RID: 2223
		// (get) Token: 0x06002540 RID: 9536 RVA: 0x0001B5B6 File Offset: 0x000197B6
		// (set) Token: 0x06002541 RID: 9537 RVA: 0x0001B5BE File Offset: 0x000197BE
		public bool invert
		{
			get
			{
				return this._invert;
			}
			set
			{
				this._invert = value;
			}
		}

		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x06002542 RID: 9538 RVA: 0x0001B5C7 File Offset: 0x000197C7
		// (set) Token: 0x06002543 RID: 9539 RVA: 0x0001B5CF File Offset: 0x000197CF
		public float deadZone
		{
			get
			{
				return this._deadZone;
			}
			set
			{
				this._deadZone = value;
			}
		}

		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x06002544 RID: 9540 RVA: 0x0001B5D8 File Offset: 0x000197D8
		// (set) Token: 0x06002545 RID: 9541 RVA: 0x0001B5E0 File Offset: 0x000197E0
		public float zero
		{
			get
			{
				return this._zero;
			}
			set
			{
				this._zero = value;
			}
		}

		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x06002546 RID: 9542 RVA: 0x0001B5E9 File Offset: 0x000197E9
		// (set) Token: 0x06002547 RID: 9543 RVA: 0x0001B5F1 File Offset: 0x000197F1
		public float min
		{
			get
			{
				return this._min;
			}
			set
			{
				this._min = value;
			}
		}

		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x06002548 RID: 9544 RVA: 0x0001B5FA File Offset: 0x000197FA
		// (set) Token: 0x06002549 RID: 9545 RVA: 0x0001B602 File Offset: 0x00019802
		public float max
		{
			get
			{
				return this._max;
			}
			set
			{
				this._max = value;
			}
		}

		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x0600254A RID: 9546 RVA: 0x0001B60B File Offset: 0x0001980B
		// (set) Token: 0x0600254B RID: 9547 RVA: 0x0001B613 File Offset: 0x00019813
		public AxisSensitivityType sensitivityType
		{
			get
			{
				return this._sensitivityType;
			}
			set
			{
				this._sensitivityType = value;
			}
		}

		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x0600254C RID: 9548 RVA: 0x0001B61C File Offset: 0x0001981C
		// (set) Token: 0x0600254D RID: 9549 RVA: 0x0001B624 File Offset: 0x00019824
		public float sensitivity
		{
			get
			{
				return this._sensitivity;
			}
			set
			{
				this._sensitivity = value;
			}
		}

		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x0600254E RID: 9550 RVA: 0x0001B62D File Offset: 0x0001982D
		// (set) Token: 0x0600254F RID: 9551 RVA: 0x0001B635 File Offset: 0x00019835
		public AnimationCurve sensitivityCurve
		{
			get
			{
				return this._sensitivityCurve;
			}
			set
			{
				this._sensitivityCurve = value;
			}
		}

		// Token: 0x06002550 RID: 9552 RVA: 0x0001B63E File Offset: 0x0001983E
		public AxisCalibrationInfo()
		{
		}

		// Token: 0x06002551 RID: 9553 RVA: 0x00092138 File Offset: 0x00090338
		[CustomObfuscation(rename = false)]
		internal AxisCalibrationInfo(float A_1, float A_2, float A_3, float A_4, bool A_5, bool A_6, AxisSensitivityType A_7, float A_8, AnimationCurve A_9)
		{
			this._deadZone = A_1;
			this._zero = A_2;
			this._min = A_3;
			this._max = A_4;
			this._invert = A_5;
			this._applyRangeCalibration = A_6;
			this._sensitivityType = A_7;
			this._sensitivity = A_8;
			this._sensitivityCurve = A_9;
		}

		// Token: 0x06002552 RID: 9554 RVA: 0x0009219C File Offset: 0x0009039C
		public object DeepClone()
		{
			return new AxisCalibrationInfo(this._deadZone, this._zero, this._min, this._max, this._invert, this._applyRangeCalibration, this._sensitivityType, this._sensitivity, UnityTools.Copy(this._sensitivityCurve));
		}

		// Token: 0x06002553 RID: 9555 RVA: 0x000921EC File Offset: 0x000903EC
		internal static AxisCalibrationData mCTqCDvjBNdSChvliiSTfRhpEStJ(AxisCalibrationInfo A_0)
		{
			if (A_0 == null)
			{
				return AxisCalibrationData.Default;
			}
			return new AxisCalibrationData(true, A_0._deadZone, A_0._zero, A_0._min, A_0._max, A_0._invert, A_0._applyRangeCalibration, A_0._sensitivityType, A_0._sensitivity, UnityTools.Copy(A_0._sensitivityCurve));
		}

		// Token: 0x06002554 RID: 9556 RVA: 0x00092244 File Offset: 0x00090444
		internal static AxisCalibrationInfo aVwgIHhtnlEwDGutxHNJiDQjeDbhc(AxisCalibrationData A_0)
		{
			return new AxisCalibrationInfo(A_0.deadZone, A_0.zero, A_0.min, A_0.max, A_0.invert, A_0.applyRangeCalibration, A_0.sensitivityType, A_0.sensitivity, A_0.sensitivityCurve);
		}

		// Token: 0x04001567 RID: 5479
		[SerializeField]
		private bool _applyRangeCalibration;

		// Token: 0x04001568 RID: 5480
		[SerializeField]
		private bool _invert;

		// Token: 0x04001569 RID: 5481
		[SerializeField]
		private float _deadZone;

		// Token: 0x0400156A RID: 5482
		[SerializeField]
		private float _zero;

		// Token: 0x0400156B RID: 5483
		[SerializeField]
		private float _min;

		// Token: 0x0400156C RID: 5484
		[SerializeField]
		private float _max;

		// Token: 0x0400156D RID: 5485
		[SerializeField]
		private AxisSensitivityType _sensitivityType;

		// Token: 0x0400156E RID: 5486
		[SerializeField]
		private float _sensitivity = 1f;

		// Token: 0x0400156F RID: 5487
		[SerializeField]
		private AnimationCurve _sensitivityCurve;
	}
}
