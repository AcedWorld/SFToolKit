using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	// Token: 0x02000116 RID: 278
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	public sealed class Axis2DCalibration
	{
		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x0000A411 File Offset: 0x00008611
		// (set) Token: 0x06000A44 RID: 2628 RVA: 0x0000A419 File Offset: 0x00008619
		public DeadZone2DType deadZoneType
		{
			get
			{
				return this._deadZoneType;
			}
			set
			{
				this._deadZoneType = value;
			}
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x0000A422 File Offset: 0x00008622
		// (set) Token: 0x06000A46 RID: 2630 RVA: 0x0000A42A File Offset: 0x0000862A
		public AxisSensitivity2DType sensitivityType
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

		// Token: 0x06000A47 RID: 2631 RVA: 0x0000A433 File Offset: 0x00008633
		internal Axis2DCalibration()
		{
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x0000A442 File Offset: 0x00008642
		internal Vector2 GetCalibrated2DValue(float valueRawX, float valueRawY, AxisCalibration xAxis, AxisCalibration yAxis)
		{
			return Axis2DCalibration.GetCalibrated2DValue(valueRawX, valueRawY, xAxis, yAxis, this._deadZoneType, this._sensitivityType);
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x00047BFC File Offset: 0x00045DFC
		internal static Vector2 GetCalibrated2DValue(float valueRawX, float valueRawY, AxisCalibration xAxis, AxisCalibration yAxis, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			Vector2 vector = default(Vector2);
			bool flag = xAxis != null;
			bool flag2 = yAxis != null;
			if (deadZoneType != DeadZone2DType.Radial)
			{
				if (deadZoneType != DeadZone2DType.Axial)
				{
					throw new NotImplementedException();
				}
				vector.x = (flag ? xAxis.GetCalibratedValue(valueRawX, xAxis.deadZone, false, false) : valueRawX);
				vector.y = (flag2 ? yAxis.GetCalibratedValue(valueRawY, yAxis.deadZone, false, false) : valueRawY);
			}
			else
			{
				float num = flag ? xAxis.deadZone : (flag2 ? yAxis.deadZone : 0f);
				if (MathTools.ApproximatelyZero(num))
				{
					vector.x = (flag ? xAxis.GetCalibratedValue(valueRawX, xAxis.deadZone, false, false) : valueRawX);
					vector.y = (flag2 ? yAxis.GetCalibratedValue(valueRawY, yAxis.deadZone, false, false) : valueRawY);
				}
				else
				{
					vector.x = (flag ? InputTools.TransformAxis2DComponentValue(valueRawX, xAxis.calibratedZero, xAxis.calibratedMin, xAxis.calibratedMax) : valueRawX);
					vector.y = (flag2 ? InputTools.TransformAxis2DComponentValue(valueRawY, yAxis.calibratedZero, yAxis.calibratedMin, yAxis.calibratedMax) : valueRawY);
					vector = InputTools.ApplyRadialDeadZone(vector.x, vector.y, num);
				}
			}
			if (sensitivityType != AxisSensitivity2DType.Radial)
			{
				if (sensitivityType != AxisSensitivity2DType.Axial)
				{
					throw new NotImplementedException();
				}
				if (flag)
				{
					vector.x = InputTools.ApplySensitivity(vector.x, xAxis.sensitivityType, xAxis.sensitivity, xAxis.sensitivityCurve);
				}
				if (flag2)
				{
					vector.y = InputTools.ApplySensitivity(vector.y, yAxis.sensitivityType, yAxis.sensitivity, yAxis.sensitivityCurve);
				}
			}
			else
			{
				AxisCalibration axisCalibration = flag ? xAxis : yAxis;
				if (axisCalibration != null)
				{
					InputTools.ApplyRadialSensitivity(ref vector, axisCalibration.sensitivityType, axisCalibration.sensitivity, axisCalibration.sensitivityCurve);
				}
			}
			if (flag && xAxis.applyRangeCalibration)
			{
				if (vector.x > 0f)
				{
					if (vector.x > 1f || 1f - vector.x <= 0.001f)
					{
						vector.x = 1f;
					}
				}
				else if (vector.x < 0f && (vector.x < -1f || vector.x + 1f <= 0.001f))
				{
					vector.x = -1f;
				}
			}
			if (flag2 && yAxis.applyRangeCalibration)
			{
				if (vector.y > 0f)
				{
					if (vector.y > 1f || 1f - vector.y <= 0.001f)
					{
						vector.y = 1f;
					}
				}
				else if (vector.y < 0f && (vector.y < -1f || vector.y + 1f <= 0.001f))
				{
					vector.y = -1f;
				}
			}
			if (flag && xAxis.invert)
			{
				vector.x *= -1f;
			}
			if (flag2 && yAxis.invert)
			{
				vector.y *= -1f;
			}
			return vector;
		}

		// Token: 0x0400076D RID: 1901
		[Tooltip("The calculation type for the dead zone.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private DeadZone2DType _deadZoneType = DeadZone2DType.Radial;

		// Token: 0x0400076E RID: 1902
		[Tooltip("Calculation type for sensitivity on 2D axes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisSensitivity2DType _sensitivityType;
	}
}
