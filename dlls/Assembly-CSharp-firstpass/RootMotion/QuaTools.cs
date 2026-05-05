using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x0200002F RID: 47
	public static class QuaTools
	{
		// Token: 0x0600010C RID: 268 RVA: 0x00007528 File Offset: 0x00005728
		public static float GetYaw(Quaternion space, Vector3 forward)
		{
			Vector3 vector = Quaternion.Inverse(space) * forward;
			if (vector.x == 0f && vector.z == 0f)
			{
				return 0f;
			}
			if (float.IsInfinity(vector.x) || float.IsInfinity(vector.z))
			{
				return 0f;
			}
			return Mathf.Atan2(vector.x, vector.z) * 57.29578f;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000759C File Offset: 0x0000579C
		public static float GetPitch(Quaternion space, Vector3 forward)
		{
			forward = forward.normalized;
			Vector3 vector = Quaternion.Inverse(space) * forward;
			if (Mathf.Abs(vector.y) > 1f)
			{
				vector.Normalize();
			}
			return -Mathf.Asin(vector.y) * 57.29578f;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000075EC File Offset: 0x000057EC
		public static float GetBank(Quaternion space, Vector3 forward, Vector3 up)
		{
			Vector3 forward2 = space * Vector3.up;
			Quaternion rotation = Quaternion.Inverse(space);
			forward = rotation * forward;
			up = rotation * up;
			up = Quaternion.Inverse(Quaternion.LookRotation(forward2, forward)) * up;
			return Mathf.Clamp(Mathf.Atan2(up.x, up.z) * 57.29578f, -180f, 180f);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00007654 File Offset: 0x00005854
		public static float GetYaw(Quaternion space, Quaternion rotation)
		{
			Vector3 vector = Quaternion.Inverse(space) * (rotation * Vector3.forward);
			if (vector.x == 0f && vector.z == 0f)
			{
				return 0f;
			}
			if (float.IsInfinity(vector.x) || float.IsInfinity(vector.z))
			{
				return 0f;
			}
			return Mathf.Atan2(vector.x, vector.z) * 57.29578f;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000076D0 File Offset: 0x000058D0
		public static float GetPitch(Quaternion space, Quaternion rotation)
		{
			Vector3 vector = Quaternion.Inverse(space) * (rotation * Vector3.forward);
			if (Mathf.Abs(vector.y) > 1f)
			{
				vector.Normalize();
			}
			return -Mathf.Asin(vector.y) * 57.29578f;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00007720 File Offset: 0x00005920
		public static float GetBank(Quaternion space, Quaternion rotation)
		{
			Vector3 forward = space * Vector3.up;
			Quaternion rotation2 = Quaternion.Inverse(space);
			Vector3 upwards = rotation2 * (rotation * Vector3.forward);
			Vector3 vector = rotation2 * (rotation * Vector3.up);
			vector = Quaternion.Inverse(Quaternion.LookRotation(forward, upwards)) * vector;
			return Mathf.Clamp(Mathf.Atan2(vector.x, vector.z) * 57.29578f, -180f, 180f);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00007799 File Offset: 0x00005999
		public static Quaternion Lerp(Quaternion fromRotation, Quaternion toRotation, float weight)
		{
			if (weight <= 0f)
			{
				return fromRotation;
			}
			if (weight >= 1f)
			{
				return toRotation;
			}
			return Quaternion.Lerp(fromRotation, toRotation, weight);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000077B7 File Offset: 0x000059B7
		public static Quaternion Slerp(Quaternion fromRotation, Quaternion toRotation, float weight)
		{
			if (weight <= 0f)
			{
				return fromRotation;
			}
			if (weight >= 1f)
			{
				return toRotation;
			}
			return Quaternion.Slerp(fromRotation, toRotation, weight);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000077D5 File Offset: 0x000059D5
		public static Quaternion LinearBlend(Quaternion q, float weight)
		{
			if (weight <= 0f)
			{
				return Quaternion.identity;
			}
			if (weight >= 1f)
			{
				return q;
			}
			return Quaternion.Lerp(Quaternion.identity, q, weight);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000077FB File Offset: 0x000059FB
		public static Quaternion SphericalBlend(Quaternion q, float weight)
		{
			if (weight <= 0f)
			{
				return Quaternion.identity;
			}
			if (weight >= 1f)
			{
				return q;
			}
			return Quaternion.Slerp(Quaternion.identity, q, weight);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00007824 File Offset: 0x00005A24
		public static Quaternion FromToAroundAxis(Vector3 fromDirection, Vector3 toDirection, Vector3 axis)
		{
			Quaternion quaternion = Quaternion.FromToRotation(fromDirection, toDirection);
			float num = 0f;
			Vector3 zero = Vector3.zero;
			quaternion.ToAngleAxis(out num, out zero);
			if (Vector3.Dot(zero, axis) < 0f)
			{
				num = -num;
			}
			return Quaternion.AngleAxis(num, axis);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00007868 File Offset: 0x00005A68
		public static Quaternion RotationToLocalSpace(Quaternion space, Quaternion rotation)
		{
			return Quaternion.Inverse(Quaternion.Inverse(space) * rotation);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000787B File Offset: 0x00005A7B
		public static Quaternion FromToRotation(Quaternion from, Quaternion to)
		{
			if (to == from)
			{
				return Quaternion.identity;
			}
			return to * Quaternion.Inverse(from);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00007898 File Offset: 0x00005A98
		public static Vector3 GetAxis(Vector3 v)
		{
			Vector3 vector = Vector3.right;
			bool flag = false;
			float num = Vector3.Dot(v, Vector3.right);
			float num2 = Mathf.Abs(num);
			if (num < 0f)
			{
				flag = true;
			}
			float num3 = Vector3.Dot(v, Vector3.up);
			float num4 = Mathf.Abs(num3);
			if (num4 > num2)
			{
				num2 = num4;
				vector = Vector3.up;
				flag = (num3 < 0f);
			}
			float num5 = Vector3.Dot(v, Vector3.forward);
			num4 = Mathf.Abs(num5);
			if (num4 > num2)
			{
				vector = Vector3.forward;
				flag = (num5 < 0f);
			}
			if (flag)
			{
				vector = -vector;
			}
			return vector;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000792C File Offset: 0x00005B2C
		public static Quaternion ClampRotation(Quaternion rotation, float clampWeight, int clampSmoothing)
		{
			if (clampWeight >= 1f)
			{
				return Quaternion.identity;
			}
			if (clampWeight <= 0f)
			{
				return rotation;
			}
			float num = Quaternion.Angle(Quaternion.identity, rotation);
			float num2 = 1f - num / 180f;
			float num3 = Mathf.Clamp(1f - (clampWeight - num2) / (1f - num2), 0f, 1f);
			float num4 = Mathf.Clamp(num2 / clampWeight, 0f, 1f);
			for (int i = 0; i < clampSmoothing; i++)
			{
				num4 = Mathf.Sin(num4 * 3.1415927f * 0.5f);
			}
			return Quaternion.Slerp(Quaternion.identity, rotation, num4 * num3);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000079D0 File Offset: 0x00005BD0
		public static float ClampAngle(float angle, float clampWeight, int clampSmoothing)
		{
			if (clampWeight >= 1f)
			{
				return 0f;
			}
			if (clampWeight <= 0f)
			{
				return angle;
			}
			float num = 1f - Mathf.Abs(angle) / 180f;
			float num2 = Mathf.Clamp(1f - (clampWeight - num) / (1f - num), 0f, 1f);
			float num3 = Mathf.Clamp(num / clampWeight, 0f, 1f);
			for (int i = 0; i < clampSmoothing; i++)
			{
				num3 = Mathf.Sin(num3 * 3.1415927f * 0.5f);
			}
			return Mathf.Lerp(0f, angle, num3 * num2);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00007A6C File Offset: 0x00005C6C
		public static Quaternion MatchRotation(Quaternion targetRotation, Vector3 targetAxis1, Vector3 targetAxis2, Vector3 axis1, Vector3 axis2)
		{
			Quaternion rotation = Quaternion.LookRotation(axis1, axis2);
			Quaternion rhs = Quaternion.LookRotation(targetAxis1, targetAxis2);
			return targetRotation * rhs * Quaternion.Inverse(rotation);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00007A9C File Offset: 0x00005C9C
		public static Vector3 ToBiPolar(Vector3 euler)
		{
			return new Vector3(QuaTools.ToBiPolar(euler.x), QuaTools.ToBiPolar(euler.y), QuaTools.ToBiPolar(euler.z));
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00007AC4 File Offset: 0x00005CC4
		public static float ToBiPolar(float angle)
		{
			angle %= 360f;
			if (angle >= 180f)
			{
				return angle - 360f;
			}
			if (angle <= -180f)
			{
				return angle + 360f;
			}
			return angle;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00007AF0 File Offset: 0x00005CF0
		public static Quaternion MirrorYZ(Quaternion r, Quaternion space)
		{
			r = Quaternion.Inverse(space) * r;
			Vector3 forward = r * Vector3.forward;
			Vector3 upwards = r * Vector3.up;
			forward.x *= -1f;
			upwards.x *= -1f;
			return space * Quaternion.LookRotation(forward, upwards);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00007B50 File Offset: 0x00005D50
		public static Quaternion MirrorYZ(Quaternion r)
		{
			Vector3 forward = r * Vector3.forward;
			Vector3 upwards = r * Vector3.up;
			forward.x *= -1f;
			upwards.x *= -1f;
			return Quaternion.LookRotation(forward, upwards);
		}
	}
}
