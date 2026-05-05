using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000115 RID: 277
	public struct AxisCalibrationData
	{
		// Token: 0x06000A3E RID: 2622 RVA: 0x0004799C File Offset: 0x00045B9C
		public AxisCalibrationData(bool A_1, float A_2, float A_3, float A_4, float A_5, bool A_6, bool A_7)
		{
			this.enabled = A_1;
			this.deadZone = A_2;
			this.zero = A_3;
			this.min = A_4;
			this.max = A_5;
			this.invert = A_6;
			this.applyRangeCalibration = A_7;
			this.sensitivity = 1f;
			this.sensitivityType = (ReInput.isReady ? ReInput.configVars.defaultAxisSensitivityType : AxisSensitivityType.Multiplier);
			this.sensitivityCurve = ((this.sensitivityType == AxisSensitivityType.Curve) ? AnimationCurve.Linear(-1f, 1f, 1f, 1f) : null);
			this.calibrations = null;
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00047A38 File Offset: 0x00045C38
		public AxisCalibrationData(bool A_1, float A_2, float A_3, float A_4, float A_5, bool A_6, bool A_7, float A_8)
		{
			this.enabled = A_1;
			this.deadZone = A_2;
			this.zero = A_3;
			this.min = A_4;
			this.max = A_5;
			this.invert = A_6;
			this.applyRangeCalibration = A_7;
			this.sensitivity = A_8;
			this.sensitivityType = (ReInput.isReady ? ReInput.configVars.defaultAxisSensitivityType : AxisSensitivityType.Multiplier);
			this.sensitivityCurve = ((this.sensitivityType == AxisSensitivityType.Curve) ? AnimationCurve.Linear(-1f, 1f, 1f, 1f) : null);
			this.calibrations = null;
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00047AD0 File Offset: 0x00045CD0
		public AxisCalibrationData(bool A_1, float A_2, float A_3, float A_4, float A_5, bool A_6, bool A_7, AxisSensitivityType A_8, float A_9, AnimationCurve A_10)
		{
			this.enabled = A_1;
			this.deadZone = A_2;
			this.zero = A_3;
			this.min = A_4;
			this.max = A_5;
			this.invert = A_6;
			this.applyRangeCalibration = A_7;
			this.sensitivityType = A_8;
			this.sensitivity = A_9;
			this.sensitivityCurve = A_10;
			this.calibrations = null;
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x00047B34 File Offset: 0x00045D34
		public static AxisCalibrationData Default
		{
			get
			{
				AxisSensitivityType axisSensitivityType = ReInput.isReady ? ReInput.configVars.defaultAxisSensitivityType : AxisSensitivityType.Multiplier;
				return new AxisCalibrationData(true, 0f, 0f, -1f, 1f, false, true, axisSensitivityType, 1f, (axisSensitivityType == AxisSensitivityType.Curve) ? AnimationCurve.Linear(-1f, 1f, 1f, 1f) : null);
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000A42 RID: 2626 RVA: 0x00047B98 File Offset: 0x00045D98
		[CustomObfuscation(rename = false)]
		internal static AxisCalibrationData Raw
		{
			get
			{
				AxisSensitivityType axisSensitivityType = ReInput.isReady ? ReInput.configVars.defaultAxisSensitivityType : AxisSensitivityType.Multiplier;
				return new AxisCalibrationData(true, 0f, 0f, -1f, 1f, false, false, axisSensitivityType, 1f, (axisSensitivityType == AxisSensitivityType.Curve) ? AnimationCurve.Linear(-1f, 1f, 1f, 1f) : null);
			}
		}

		// Token: 0x04000762 RID: 1890
		public bool enabled;

		// Token: 0x04000763 RID: 1891
		public float deadZone;

		// Token: 0x04000764 RID: 1892
		public float zero;

		// Token: 0x04000765 RID: 1893
		public float min;

		// Token: 0x04000766 RID: 1894
		public float max;

		// Token: 0x04000767 RID: 1895
		public bool invert;

		// Token: 0x04000768 RID: 1896
		public AxisSensitivityType sensitivityType;

		// Token: 0x04000769 RID: 1897
		public float sensitivity;

		// Token: 0x0400076A RID: 1898
		public AnimationCurve sensitivityCurve;

		// Token: 0x0400076B RID: 1899
		public bool applyRangeCalibration;

		// Token: 0x0400076C RID: 1900
		[CustomObfuscation(rename = false)]
		internal Dictionary<int, AxisCalibrationInfo> calibrations;
	}
}
