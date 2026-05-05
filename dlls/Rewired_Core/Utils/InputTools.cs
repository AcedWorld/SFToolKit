using System;
using System.Text.RegularExpressions;
using Rewired.Data.Mapping;
using UnityEngine;

namespace Rewired.Utils
{
	// Token: 0x02000492 RID: 1170
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class InputTools
	{
		// Token: 0x06002E54 RID: 11860 RVA: 0x000A24CC File Offset: 0x000A06CC
		public static float TransformAxis2DComponentValue(float value, float zero, float min, float max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				value = max;
			}
			if (MathTools.Approximately(value, zero))
			{
				return 0f;
			}
			if (value > zero)
			{
				value = MathTools.ValueInNewRange(value, zero, max, 0f, 1f);
			}
			else
			{
				value = MathTools.ValueInNewRange(value, min, zero, -1f, 0f);
			}
			return value;
		}

		// Token: 0x06002E55 RID: 11861 RVA: 0x000A2528 File Offset: 0x000A0728
		public static float GetCalibratedAxisValueClamped(float value, float zero, float min, float max, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				value = max;
			}
			if (MathTools.Approximately(value, zero))
			{
				return 0f;
			}
			if ((value > zero && value <= zero + deadZone) || (value < zero && value >= zero - deadZone))
			{
				return 0f;
			}
			if (value > zero)
			{
				value = MathTools.ValueInNewRange(value, zero + deadZone, max, 0f, 1f);
			}
			else
			{
				value = MathTools.ValueInNewRange(value, min, zero - deadZone, -1f, 0f);
			}
			if (applySensitivity)
			{
				value = InputTools.ApplySensitivity(value, sensitivityType, sensitivity, sensitivityCurve);
			}
			if (value > 0f)
			{
				if (value > 1f || 1f - value <= 0.001f)
				{
					value = 1f;
				}
			}
			else if (value < 0f && (value < -1f || value + 1f <= 0.001f))
			{
				value = -1f;
			}
			if (invert)
			{
				value *= -1f;
			}
			return value;
		}

		// Token: 0x06002E56 RID: 11862 RVA: 0x000A2610 File Offset: 0x000A0810
		public static float GetCalibratedAxisValue(float value, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (MathTools.Approximately(value, 0f))
			{
				return 0f;
			}
			if ((value > 0f && value <= 0f + deadZone) || (value < 0f && value >= 0f - deadZone))
			{
				return 0f;
			}
			value -= deadZone * MathTools.Sign(value);
			if (applySensitivity)
			{
				value = InputTools.ApplySensitivity(value, sensitivityType, sensitivity, sensitivityCurve);
			}
			if (invert)
			{
				value *= -1f;
			}
			return value;
		}

		// Token: 0x06002E57 RID: 11863 RVA: 0x000A2684 File Offset: 0x000A0884
		public static Vector2 ApplyRadialDeadZone(float xValue, float yValue, float deadzone)
		{
			Vector2 vector = new Vector2(xValue, yValue);
			if (vector.magnitude < deadzone)
			{
				return Vector2.zero;
			}
			float num = (vector.magnitude - deadzone) / (1f - deadzone);
			vector.Normalize();
			vector.x = MathTools.Clamp(vector.x * num, -1f, 1f);
			vector.y = MathTools.Clamp(vector.y * num, -1f, 1f);
			return vector;
		}

		// Token: 0x06002E58 RID: 11864 RVA: 0x000A2700 File Offset: 0x000A0900
		public static float ApplySensitivity(float value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (value == 0f)
			{
				return 0f;
			}
			switch (sensitivityType)
			{
			case AxisSensitivityType.Multiplier:
				return value * sensitivity;
			case AxisSensitivityType.Power:
				if (sensitivity < 0f)
				{
					return 0f;
				}
				if (value > 0f)
				{
					return MathTools.Pow(value, sensitivity);
				}
				return MathTools.Pow(value * -1f, sensitivity) * -1f;
			case AxisSensitivityType.Curve:
			{
				if (sensitivityCurve == null)
				{
					return value;
				}
				float num = MathTools.Clamp(value, -1f, 1f);
				if (!InputTools.nfFxEhJPdTrieVXYFYaEFQGFTbgg(sensitivityCurve))
				{
					num = MathTools.Abs(num);
				}
				return value * sensitivityCurve.Evaluate(num);
			}
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06002E59 RID: 11865 RVA: 0x000A279C File Offset: 0x000A099C
		private static bool nfFxEhJPdTrieVXYFYaEFQGFTbgg(AnimationCurve A_0)
		{
			if (A_0 == null)
			{
				return false;
			}
			int length = A_0.length;
			for (int i = 0; i < length; i++)
			{
				if (A_0[i].time < -0.2f)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002E5A RID: 11866 RVA: 0x000A27DC File Offset: 0x000A09DC
		public static void ApplyRadialSensitivity(ref Vector2 value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			switch (sensitivityType)
			{
			case AxisSensitivityType.Multiplier:
				value.x *= sensitivity;
				value.y *= sensitivity;
				return;
			case AxisSensitivityType.Power:
			{
				if (sensitivity < 0f)
				{
					value.x = 0f;
					value.y = 0f;
					return;
				}
				float num = MathTools.Pow(value.magnitude, sensitivity);
				value.Normalize();
				value.x *= num;
				value.y *= num;
				return;
			}
			case AxisSensitivityType.Curve:
			{
				if (sensitivityCurve == null)
				{
					return;
				}
				float time = MathTools.Clamp01(value.magnitude);
				float num2 = sensitivityCurve.Evaluate(time);
				value.x *= num2;
				value.y *= num2;
				return;
			}
			default:
				throw new NotImplementedException();
			}
		}

		// Token: 0x06002E5B RID: 11867 RVA: 0x00023803 File Offset: 0x00021A03
		public static string FormatHardwareIdentifierString(string str)
		{
			if (str == null)
			{
				str = string.Empty;
			}
			str = Regex.Replace(str, "\\s*", string.Empty);
			return str;
		}

		// Token: 0x06002E5C RID: 11868 RVA: 0x00023822 File Offset: 0x00021A22
		public static AxisRange InvertAxisRange(AxisRange axisRange)
		{
			if (axisRange == AxisRange.Full)
			{
				return AxisRange.Full;
			}
			if (axisRange == AxisRange.Positive)
			{
				return AxisRange.Negative;
			}
			if (axisRange == AxisRange.Negative)
			{
				return AxisRange.Positive;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06002E5D RID: 11869 RVA: 0x000A2894 File Offset: 0x000A0A94
		public static void CompareLastActiveController(Controller controller, ref Controller lastController, ref double lastTime)
		{
			if (controller == null)
			{
				return;
			}
			double lastTimeAnyElementChanged = controller.GetLastTimeAnyElementChanged();
			if (lastTimeAnyElementChanged == 0.0)
			{
				return;
			}
			if (lastController != null && lastTimeAnyElementChanged <= lastTime)
			{
				return;
			}
			lastController = controller;
			lastTime = lastTimeAnyElementChanged;
		}

		// Token: 0x06002E5E RID: 11870 RVA: 0x000A28CC File Offset: 0x000A0ACC
		public static bool IsMappableControllerElementType(object type)
		{
			if (type == null)
			{
				return false;
			}
			Type type2 = type.GetType();
			if (type2 == typeof(ControllerElementType))
			{
				return InputTools.IsMappableType((ControllerElementType)type);
			}
			if (type2 == typeof(ControllerTemplateElementType))
			{
				return InputTools.IsMappableType((ControllerTemplateElementType)type);
			}
			throw new NotImplementedException();
		}

		// Token: 0x06002E5F RID: 11871 RVA: 0x0002383A File Offset: 0x00021A3A
		public static bool IsMappableType(ControllerElementType type)
		{
			return type < ControllerElementType.CompoundElement;
		}

		// Token: 0x06002E60 RID: 11872 RVA: 0x00023841 File Offset: 0x00021A41
		public static bool IsMappableType(ControllerTemplateElementType type)
		{
			return type == ControllerTemplateElementType.Axis || type == ControllerTemplateElementType.Button;
		}

		// Token: 0x06002E61 RID: 11873 RVA: 0x0002384C File Offset: 0x00021A4C
		public static bool HandleForced4WayHatsOnUnknownControllers(int direction, ref HatType hatType)
		{
			if (hatType != HatType.EightWay)
			{
				return true;
			}
			if (!ReInput.configVars.force4WayHats)
			{
				return true;
			}
			if (direction % 2 != 0)
			{
				return false;
			}
			hatType = HatType.FourWay;
			return true;
		}

		// Token: 0x06002E62 RID: 11874 RVA: 0x0002386E File Offset: 0x00021A6E
		public static float AxisToDigitalValue(float value)
		{
			if (MathTools.ApproximatelyZero(value))
			{
				return 0f;
			}
			if (value > 0f)
			{
				return 1f;
			}
			return -1f;
		}

		// Token: 0x06002E63 RID: 11875 RVA: 0x00023891 File Offset: 0x00021A91
		public static float AxisToDigitalValue(float value, float threshold)
		{
			if (MathTools.IsNearZero(value, threshold))
			{
				return 0f;
			}
			if (value > 0f)
			{
				return 1f;
			}
			return -1f;
		}
	}
}
