using System;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine
{
	// Token: 0x02000204 RID: 516
	[MovedFrom("UnityEditor")]
	internal class NumericFieldDraggerUtility
	{
		// Token: 0x0600175F RID: 5983 RVA: 0x00027064 File Offset: 0x00025264
		internal static float Acceleration(bool shiftPressed, bool altPressed)
		{
			return (float)(shiftPressed ? 4 : 1) * (altPressed ? 0.25f : 1f);
		}

		// Token: 0x06001760 RID: 5984 RVA: 0x00027090 File Offset: 0x00025290
		internal static float NiceDelta(Vector2 deviceDelta, float acceleration)
		{
			deviceDelta.y = -deviceDelta.y;
			bool flag = Mathf.Abs(Mathf.Abs(deviceDelta.x) - Mathf.Abs(deviceDelta.y)) / Mathf.Max(Mathf.Abs(deviceDelta.x), Mathf.Abs(deviceDelta.y)) > 0.1f;
			if (flag)
			{
				bool flag2 = Mathf.Abs(deviceDelta.x) > Mathf.Abs(deviceDelta.y);
				if (flag2)
				{
					NumericFieldDraggerUtility.s_UseYSign = false;
				}
				else
				{
					NumericFieldDraggerUtility.s_UseYSign = true;
				}
			}
			bool flag3 = NumericFieldDraggerUtility.s_UseYSign;
			float result;
			if (flag3)
			{
				result = Mathf.Sign(deviceDelta.y) * deviceDelta.magnitude * acceleration;
			}
			else
			{
				result = Mathf.Sign(deviceDelta.x) * deviceDelta.magnitude * acceleration;
			}
			return result;
		}

		// Token: 0x06001761 RID: 5985 RVA: 0x00027158 File Offset: 0x00025358
		internal static double CalculateFloatDragSensitivity(double value)
		{
			bool flag = double.IsInfinity(value) || double.IsNaN(value);
			double result;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				result = Math.Max(1.0, Math.Pow(Math.Abs(value), 0.5)) * 0.029999999329447746;
			}
			return result;
		}

		// Token: 0x06001762 RID: 5986 RVA: 0x000271B8 File Offset: 0x000253B8
		internal static double CalculateFloatDragSensitivity(double value, double minValue, double maxValue)
		{
			bool flag = double.IsInfinity(value) || double.IsNaN(value);
			double result;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				double num = Math.Abs(maxValue - minValue);
				result = num / 100.0 * 0.029999999329447746;
			}
			return result;
		}

		// Token: 0x06001763 RID: 5987 RVA: 0x0002720C File Offset: 0x0002540C
		internal static long CalculateIntDragSensitivity(long value)
		{
			return (long)NumericFieldDraggerUtility.CalculateIntDragSensitivity((double)value);
		}

		// Token: 0x06001764 RID: 5988 RVA: 0x00027228 File Offset: 0x00025428
		internal static ulong CalculateIntDragSensitivity(ulong value)
		{
			return (ulong)NumericFieldDraggerUtility.CalculateIntDragSensitivity(value);
		}

		// Token: 0x06001765 RID: 5989 RVA: 0x00027244 File Offset: 0x00025444
		private static double CalculateIntDragSensitivity(double value)
		{
			return Math.Max(1.0, Math.Pow(Math.Abs(value), 0.5) * 0.029999999329447746);
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x00027284 File Offset: 0x00025484
		internal static long CalculateIntDragSensitivity(long value, long minValue, long maxValue)
		{
			long num = Math.Abs(maxValue - minValue);
			return Math.Max(1L, (long)(0.03f * (float)num / 100f));
		}

		// Token: 0x04000860 RID: 2144
		private static bool s_UseYSign;

		// Token: 0x04000861 RID: 2145
		private const float kDragSensitivity = 0.03f;
	}
}
