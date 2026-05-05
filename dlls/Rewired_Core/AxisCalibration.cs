using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000114 RID: 276
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	public sealed class AxisCalibration
	{
		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000A17 RID: 2583 RVA: 0x0000A31E File Offset: 0x0000851E
		// (set) Token: 0x06000A18 RID: 2584 RVA: 0x0000A326 File Offset: 0x00008526
		public bool enabled
		{
			get
			{
				return this._enabled;
			}
			set
			{
				this._enabled = value;
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000A19 RID: 2585 RVA: 0x0000A32F File Offset: 0x0000852F
		// (set) Token: 0x06000A1A RID: 2586 RVA: 0x0000A337 File Offset: 0x00008537
		public float deadZone
		{
			get
			{
				return this._deadZone;
			}
			set
			{
				this._deadZone = MathTools.Abs(value);
			}
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000A1B RID: 2587 RVA: 0x0000A345 File Offset: 0x00008545
		// (set) Token: 0x06000A1C RID: 2588 RVA: 0x0000A34D File Offset: 0x0000854D
		public float calibratedZero
		{
			get
			{
				return this._calibratedZero;
			}
			set
			{
				this._calibratedZero = value;
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000A1D RID: 2589 RVA: 0x0000A356 File Offset: 0x00008556
		// (set) Token: 0x06000A1E RID: 2590 RVA: 0x0000A35E File Offset: 0x0000855E
		public float calibratedMin
		{
			get
			{
				return this._calibratedMin;
			}
			set
			{
				this._calibratedMin = value;
			}
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000A1F RID: 2591 RVA: 0x0000A367 File Offset: 0x00008567
		// (set) Token: 0x06000A20 RID: 2592 RVA: 0x0000A36F File Offset: 0x0000856F
		public float calibratedMax
		{
			get
			{
				return this._calibratedMax;
			}
			set
			{
				this._calibratedMax = value;
			}
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000A21 RID: 2593 RVA: 0x0000A378 File Offset: 0x00008578
		// (set) Token: 0x06000A22 RID: 2594 RVA: 0x0000A380 File Offset: 0x00008580
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

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000A23 RID: 2595 RVA: 0x0000A389 File Offset: 0x00008589
		// (set) Token: 0x06000A24 RID: 2596 RVA: 0x0000A391 File Offset: 0x00008591
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

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000A25 RID: 2597 RVA: 0x0000A39A File Offset: 0x0000859A
		// (set) Token: 0x06000A26 RID: 2598 RVA: 0x0000A3A2 File Offset: 0x000085A2
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

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000A27 RID: 2599 RVA: 0x0000A3AB File Offset: 0x000085AB
		// (set) Token: 0x06000A28 RID: 2600 RVA: 0x0000A3B3 File Offset: 0x000085B3
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

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000A29 RID: 2601 RVA: 0x0000A3BC File Offset: 0x000085BC
		// (set) Token: 0x06000A2A RID: 2602 RVA: 0x0000A3C4 File Offset: 0x000085C4
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

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000A2B RID: 2603 RVA: 0x0000A3CD File Offset: 0x000085CD
		// (set) Token: 0x06000A2C RID: 2604 RVA: 0x0000A3D5 File Offset: 0x000085D5
		internal AlternateAxisCalibrationType calibrationMode
		{
			get
			{
				return this._calibrationMode;
			}
			set
			{
				if (value == this._calibrationMode)
				{
					return;
				}
				this._calibrationMode = value;
				this.Reset();
			}
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00047190 File Offset: 0x00045390
		internal AxisCalibration()
		{
			this.CreateDefaultHardwareCalibration(this.GetData());
			this.Reset();
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x000471E0 File Offset: 0x000453E0
		internal AxisCalibration(bool A_1, Dictionary<int, AxisCalibrationInfo> A_2, float A_3, float A_4, float A_5, float A_6, bool A_7, bool A_8, AxisSensitivityType A_9, float A_10, AnimationCurve A_11)
		{
			this._enabled = A_1;
			this._deadZone = A_3;
			this._calibratedZero = A_4;
			this._calibratedMin = A_5;
			this._calibratedMax = A_6;
			this._invert = A_7;
			this._sensitivityType = A_9;
			this._sensitivity = A_10;
			this._sensitivityCurve = A_11;
			this._applyRangeCalibration = A_8;
			this.InitHardwareCalibrations(A_2, this.GetData());
			this.Reset();
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00047280 File Offset: 0x00045480
		internal AxisCalibration(AxisCalibrationData A_1)
		{
			this._enabled = A_1.enabled;
			this.InitHardwareCalibrations(A_1.calibrations, A_1);
			this.Reset();
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x000472DC File Offset: 0x000454DC
		internal void CopyFrom(AxisCalibration data, bool copyHardwareData)
		{
			if (data == null)
			{
				return;
			}
			if (copyHardwareData)
			{
				this._hardwareCalibrations = MiscTools.DeepClone<int, AxisCalibrationInfo>(data._hardwareCalibrations);
			}
			this._enabled = data._enabled;
			this._deadZone = MathTools.Abs(data._deadZone);
			this._calibratedZero = data._calibratedZero;
			this._calibratedMin = data._calibratedMin;
			this._calibratedMax = data._calibratedMax;
			this._invert = data._invert;
			this._applyRangeCalibration = data._applyRangeCalibration;
			this._sensitivityType = data._sensitivityType;
			this._sensitivity = data._sensitivity;
			this._sensitivityCurve = UnityTools.Copy(data._sensitivityCurve);
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0000A3EE File Offset: 0x000085EE
		public float GetCalibratedValue(float value)
		{
			return this.GetCalibratedValue(value, this._deadZone, true, true);
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00047384 File Offset: 0x00045584
		internal float GetCalibratedValue(float value, float customDeadzone, bool applySensitivity, bool applyInversion)
		{
			if (!this._enabled)
			{
				return 0f;
			}
			if (this._applyRangeCalibration)
			{
				return InputTools.GetCalibratedAxisValueClamped(value, this._calibratedZero, this._calibratedMin, this._calibratedMax, customDeadzone, applyInversion && this._invert, applySensitivity, this._sensitivityType, this._sensitivity, this._sensitivityCurve);
			}
			return InputTools.GetCalibratedAxisValue(value, customDeadzone, applyInversion && this._invert, applySensitivity, this._sensitivityType, this._sensitivity, this._sensitivityCurve);
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x0000A3FF File Offset: 0x000085FF
		public float GetCalibratedValue(float value, AxisRange axisRange)
		{
			return this.GetCalibratedValue(value, axisRange, this._deadZone, true, true);
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00047408 File Offset: 0x00045608
		internal float GetCalibratedValue(float value, AxisRange axisRange, float customDeadzone, bool applySensitivity, bool applyInversion)
		{
			if (!this._enabled)
			{
				return 0f;
			}
			if (this._applyRangeCalibration)
			{
				value = InputTools.GetCalibratedAxisValueClamped(value, this._calibratedZero, this._calibratedMin, this._calibratedMax, customDeadzone, false, applySensitivity, this._sensitivityType, this._sensitivity, this._sensitivityCurve);
			}
			else
			{
				value = InputTools.GetCalibratedAxisValue(value, customDeadzone, false, applySensitivity, this._sensitivityType, this._sensitivity, this._sensitivityCurve);
			}
			if (axisRange != AxisRange.Positive)
			{
				if (axisRange == AxisRange.Negative)
				{
					if (value > 0f)
					{
						return 0f;
					}
				}
			}
			else if (value < 0f)
			{
				return 0f;
			}
			if (MathTools.Approximately(value, 0f))
			{
				return 0f;
			}
			if (applyInversion && this._invert)
			{
				value *= -1f;
			}
			return value;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x000474CC File Offset: 0x000456CC
		public AxisCalibrationData GetData()
		{
			return new AxisCalibrationData(this._enabled, this._deadZone, this._calibratedZero, this._calibratedMin, this._calibratedMax, this._invert, this._applyRangeCalibration, this._sensitivityType, this._sensitivity, this._sensitivityCurve)
			{
				calibrations = MiscTools.DeepClone<int, AxisCalibrationInfo>(this._hardwareCalibrations)
			};
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00047530 File Offset: 0x00045730
		public void SetData(AxisCalibrationData data)
		{
			this._enabled = data.enabled;
			this._deadZone = MathTools.Abs(data.deadZone);
			this._calibratedZero = data.zero;
			this._calibratedMin = data.min;
			this._calibratedMax = data.max;
			this._invert = data.invert;
			this._applyRangeCalibration = data.applyRangeCalibration;
			this._sensitivityType = data.sensitivityType;
			this._sensitivity = data.sensitivity;
			this._sensitivityCurve = data.sensitivityCurve;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x000475BC File Offset: 0x000457BC
		public void Reset()
		{
			this._enabled = true;
			AxisCalibrationInfo hardwareDefault = this.GetHardwareDefault();
			if (hardwareDefault == null)
			{
				Logger.LogError("Hardware default calibration info was not found.");
				return;
			}
			this._deadZone = hardwareDefault.deadZone;
			this._calibratedZero = hardwareDefault.zero;
			this._calibratedMin = hardwareDefault.min;
			this._calibratedMax = hardwareDefault.max;
			this._invert = hardwareDefault.invert;
			this._applyRangeCalibration = hardwareDefault.applyRangeCalibration;
			this._sensitivityType = hardwareDefault.sensitivityType;
			this._sensitivity = hardwareDefault.sensitivity;
			this._sensitivityCurve = UnityTools.Copy(hardwareDefault.sensitivityCurve);
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00047658 File Offset: 0x00045858
		internal SerializedObject ExportData()
		{
			return new SerializedObject(base.GetType(), SerializedObject.ObjectType.Object)
			{
				{
					"enabled",
					this._enabled,
					SerializedObject.FieldOptions.None
				},
				{
					"deadZone",
					this._deadZone,
					SerializedObject.FieldOptions.None
				},
				{
					"calibratedZero",
					this._calibratedZero,
					SerializedObject.FieldOptions.None
				},
				{
					"calibratedMin",
					this._calibratedMin,
					SerializedObject.FieldOptions.None
				},
				{
					"calibratedMax",
					this._calibratedMax,
					SerializedObject.FieldOptions.None
				},
				{
					"invert",
					this._invert,
					SerializedObject.FieldOptions.None
				},
				{
					"sensitivity",
					this._sensitivity,
					SerializedObject.FieldOptions.None
				},
				{
					"applyRangeCalibration",
					this._applyRangeCalibration,
					SerializedObject.FieldOptions.None
				},
				{
					"sensitivityType",
					this._sensitivityType,
					SerializedObject.FieldOptions.None
				},
				{
					"sensitivityCurve",
					this._sensitivityCurve,
					SerializedObject.FieldOptions.None
				}
			};
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00047728 File Offset: 0x00045928
		internal void Import(SerializedObject serializedObject)
		{
			if (serializedObject == null)
			{
				return;
			}
			this.Reset();
			serializedObject.TryGetDeserializedValueByRef<bool>("enabled", ref this._enabled);
			serializedObject.TryGetDeserializedValueByRef<float>("deadZone", ref this._deadZone);
			serializedObject.TryGetDeserializedValueByRef<float>("calibratedZero", ref this._calibratedZero);
			serializedObject.TryGetDeserializedValueByRef<float>("calibratedMin", ref this._calibratedMin);
			serializedObject.TryGetDeserializedValueByRef<float>("calibratedMax", ref this._calibratedMax);
			serializedObject.TryGetDeserializedValueByRef<bool>("invert", ref this._invert);
			serializedObject.TryGetDeserializedValueByRef<float>("sensitivity", ref this._sensitivity);
			serializedObject.TryGetDeserializedValueByRef<bool>("applyRangeCalibration", ref this._applyRangeCalibration);
			serializedObject.TryGetDeserializedValueByRef<AxisSensitivityType>("sensitivityType", ref this._sensitivityType);
			serializedObject.TryGetDeserializedValueByRef<AnimationCurve>("sensitivityCurve", ref this._sensitivityCurve);
			this._deadZone = MathTools.Abs(this._deadZone);
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00047804 File Offset: 0x00045A04
		private void InitHardwareCalibrations(Dictionary<int, AxisCalibrationInfo> hardwareCalibrations, AxisCalibrationData defaultData)
		{
			this._hardwareCalibrations.Clear();
			if (hardwareCalibrations != null)
			{
				foreach (KeyValuePair<int, AxisCalibrationInfo> keyValuePair in hardwareCalibrations)
				{
					this._hardwareCalibrations.Add(keyValuePair.Key, MiscTools.DeepClone<AxisCalibrationInfo>(keyValuePair.Value));
				}
			}
			this.CreateDefaultHardwareCalibration(defaultData);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00047880 File Offset: 0x00045A80
		private void CreateDefaultHardwareCalibration(AxisCalibrationData defaultData)
		{
			if (!this._hardwareCalibrations.ContainsKey(0))
			{
				AxisCalibrationInfo value = AxisCalibrationInfo.aVwgIHhtnlEwDGutxHNJiDQjeDbhc(defaultData);
				this._hardwareCalibrations.Add(0, value);
			}
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x000478B0 File Offset: 0x00045AB0
		private AxisCalibrationInfo GetHardwareDefault()
		{
			AxisCalibrationInfo result = null;
			if (this._calibrationMode == AlternateAxisCalibrationType.ThrottleZeroCenter && ReInput.configVars.throttleCalibrationMode == ThrottleCalibrationMode.NegativeOneToOne && this._hardwareCalibrations.TryGetValue(1, out result))
			{
				return result;
			}
			this._hardwareCalibrations.TryGetValue(0, out result);
			return result;
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x000478F8 File Offset: 0x00045AF8
		internal static AxisCalibration CreateRelative()
		{
			AxisSensitivityType axisSensitivityType = ReInput.isReady ? ReInput.configVars.defaultAxisSensitivityType : AxisSensitivityType.Multiplier;
			return new AxisCalibration(true, new Dictionary<int, AxisCalibrationInfo>
			{
				{
					0,
					new AxisCalibrationInfo(0f, 0f, -1f, 1f, false, false, axisSensitivityType, 1f, AnimationCurve.Linear(0f, 1f, 1f, 1f))
				}
			}, 0f, 0f, -1f, 1f, false, false, axisSensitivityType, 1f, AnimationCurve.Linear(0f, 1f, 1f, 1f));
		}

		// Token: 0x04000756 RID: 1878
		private AlternateAxisCalibrationType _calibrationMode;

		// Token: 0x04000757 RID: 1879
		private Dictionary<int, AxisCalibrationInfo> _hardwareCalibrations = new Dictionary<int, AxisCalibrationInfo>
		{
			{
				0,
				AxisCalibrationInfo.aVwgIHhtnlEwDGutxHNJiDQjeDbhc(AxisCalibrationData.Default)
			}
		};

		// Token: 0x04000758 RID: 1880
		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _enabled = true;

		// Token: 0x04000759 RID: 1881
		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _deadZone;

		// Token: 0x0400075A RID: 1882
		[Tooltip("Enables or disables the Axis. A disabled Axis always returns a value of 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _calibratedZero;

		// Token: 0x0400075B RID: 1883
		[Tooltip("Gets or sets the minimum value. This can be used to transform the value to a new range.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _calibratedMin;

		// Token: 0x0400075C RID: 1884
		[Tooltip("Gets or sets the maximum value. This can be used to transform the value to a new range.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _calibratedMax;

		// Token: 0x0400075D RID: 1885
		[Tooltip("If true, the final value will be multiplied by -1. This can be used to correct an inverted Axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _invert;

		// Token: 0x0400075E RID: 1886
		[Tooltip("Determines how sensitivity will be calculated.\nIf sensitivityType is set to Multiplier or Power, the sensitivity property is used to calculate the value.\nIf sensitivityType is set to Curve, the sensitivityCurve property is used to calculate the value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisSensitivityType _sensitivityType;

		// Token: 0x0400075F RID: 1887
		[Tooltip("Gets or sets the sensitivity value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _sensitivity;

		// Token: 0x04000760 RID: 1888
		[Tooltip("Gets or sets the sensitivity curve. The curve has no effect unless sensitivityType is set to Curve.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AnimationCurve _sensitivityCurve;

		// Token: 0x04000761 RID: 1889
		[Tooltip("If enabled, calibratedMin, calibratedMax, and calibratedZero will be used to convert the value to a new range.\nIf disabled, calibratedMin, calibratedMax, and calibratedZero will have no effect on the final value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _applyRangeCalibration = true;
	}
}
