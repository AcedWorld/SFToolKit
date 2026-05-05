using System;
using UnityEngine;

namespace Cinemachine.Utility
{
	// Token: 0x02000068 RID: 104
	public static class UnityVectorExtensions
	{
		// Token: 0x060003EB RID: 1003 RVA: 0x00018043 File Offset: 0x00016243
		public static bool IsNaN(this Vector2 v)
		{
			return float.IsNaN(v.x) || float.IsNaN(v.y);
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0001805F File Offset: 0x0001625F
		public static bool IsNaN(this Vector3 v)
		{
			return float.IsNaN(v.x) || float.IsNaN(v.y) || float.IsNaN(v.z);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00018088 File Offset: 0x00016288
		public static float ClosestPointOnSegment(this Vector3 p, Vector3 s0, Vector3 s1)
		{
			Vector3 vector = s1 - s0;
			float num = Vector3.SqrMagnitude(vector);
			if (num < 0.0001f)
			{
				return 0f;
			}
			return Mathf.Clamp01(Vector3.Dot(p - s0, vector) / num);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x000180C8 File Offset: 0x000162C8
		public static float ClosestPointOnSegment(this Vector2 p, Vector2 s0, Vector2 s1)
		{
			Vector2 vector = s1 - s0;
			float num = Vector2.SqrMagnitude(vector);
			if (num < 0.0001f)
			{
				return 0f;
			}
			return Mathf.Clamp01(Vector2.Dot(p - s0, vector) / num);
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00018106 File Offset: 0x00016306
		public static Vector3 ProjectOntoPlane(this Vector3 vector, Vector3 planeNormal)
		{
			return vector - Vector3.Dot(vector, planeNormal) * planeNormal;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0001811C File Offset: 0x0001631C
		public static Vector2 SquareNormalize(this Vector2 v)
		{
			float num = Mathf.Max(Mathf.Abs(v.x), Mathf.Abs(v.y));
			if (num >= 0.0001f)
			{
				return v / num;
			}
			return Vector2.zero;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0001815C File Offset: 0x0001635C
		public static int FindIntersection(in Vector2 p1, in Vector2 p2, in Vector2 q1, in Vector2 q2, out Vector2 intersection)
		{
			Vector2 vector = p2 - p1;
			Vector2 vector2 = q2 - q1;
			Vector2 vector3 = q1 - p1;
			float num = vector.Cross(vector2);
			if (Mathf.Abs(num) < 1E-05f)
			{
				intersection = Vector2.positiveInfinity;
				if (Mathf.Abs(vector3.Cross(vector)) >= 1E-05f)
				{
					return 0;
				}
				float num2 = Vector2.Dot(vector2, vector);
				if (num2 > 0f && (p1 - q2).sqrMagnitude < 0.001f)
				{
					intersection = q2;
					return 4;
				}
				if (num2 < 0f && (p2 - q2).sqrMagnitude < 0.001f)
				{
					intersection = p2;
					return 4;
				}
				float num3 = Vector2.Dot(vector3, vector);
				if (0f <= num3 && num3 <= Vector2.Dot(vector, vector))
				{
					if (num3 < 0.0001f)
					{
						if (num2 <= 0f && (p1 - q1).sqrMagnitude < 0.001f)
						{
							intersection = p1;
						}
					}
					else if (num2 > 0f && (p2 - q1).sqrMagnitude < 0.001f)
					{
						intersection = p2;
					}
					return 4;
				}
				num3 = Vector2.Dot(p1 - q1, vector2);
				if (0f <= num3 && num3 <= Vector2.Dot(vector2, vector2))
				{
					return 4;
				}
				return 3;
			}
			else
			{
				float num4 = vector3.Cross(vector2) / num;
				intersection = p1 + num4 * vector;
				float num5 = vector3.Cross(vector) / num;
				if (0f <= num4 && num4 <= 1f && 0f <= num5 && num5 <= 1f)
				{
					return 2;
				}
				return 1;
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00018379 File Offset: 0x00016579
		private static float Cross(this Vector2 v1, Vector2 v2)
		{
			return v1.x * v2.y - v1.y * v2.x;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00018396 File Offset: 0x00016596
		public static Vector2 Abs(this Vector2 v)
		{
			return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x000183B3 File Offset: 0x000165B3
		public static Vector3 Abs(this Vector3 v)
		{
			return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x000183DB File Offset: 0x000165DB
		public static bool IsUniform(this Vector2 v)
		{
			return Math.Abs(v.x - v.y) < 0.0001f;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x000183F6 File Offset: 0x000165F6
		public static bool IsUniform(this Vector3 v)
		{
			return Math.Abs(v.x - v.y) < 0.0001f && Math.Abs(v.x - v.z) < 0.0001f;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0001842C File Offset: 0x0001662C
		public static bool AlmostZero(this Vector3 v)
		{
			return v.sqrMagnitude < 9.999999E-09f;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0001843C File Offset: 0x0001663C
		internal static void ConservativeSetPositionAndRotation(this Transform t, Vector3 pos, Quaternion rot)
		{
			if (t.position.Equals(pos) && t.rotation.Equals(rot))
			{
				return;
			}
			t.SetPositionAndRotation(pos, rot);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00018474 File Offset: 0x00016674
		public static float Angle(Vector3 v1, Vector3 v2)
		{
			v1.Normalize();
			v2.Normalize();
			return Mathf.Atan2((v1 - v2).magnitude, (v1 + v2).magnitude) * 57.29578f * 2f;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000184C0 File Offset: 0x000166C0
		public static float SignedAngle(Vector3 v1, Vector3 v2, Vector3 up)
		{
			float num = UnityVectorExtensions.Angle(v1, v2);
			if (Mathf.Sign(Vector3.Dot(up, Vector3.Cross(v1, v2))) < 0f)
			{
				return -num;
			}
			return num;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x000184F4 File Offset: 0x000166F4
		public static Quaternion SafeFromToRotation(Vector3 v1, Vector3 v2, Vector3 up)
		{
			Vector3 vector = Vector3.Cross(v1, v2);
			if (vector.AlmostZero())
			{
				vector = up;
			}
			return Quaternion.AngleAxis(UnityVectorExtensions.Angle(v1, v2), vector);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00018520 File Offset: 0x00016720
		public static Vector3 SlerpWithReferenceUp(Vector3 vA, Vector3 vB, float t, Vector3 up)
		{
			float magnitude = vA.magnitude;
			float magnitude2 = vB.magnitude;
			if (magnitude < 0.0001f || magnitude2 < 0.0001f)
			{
				return Vector3.Lerp(vA, vB, t);
			}
			Vector3 forward = vA / magnitude;
			Vector3 forward2 = vB / magnitude2;
			Quaternion qA = Quaternion.LookRotation(forward, up);
			Quaternion qB = Quaternion.LookRotation(forward2, up);
			return UnityQuaternionExtensions.SlerpWithReferenceUp(qA, qB, t, up) * Vector3.forward * Mathf.Lerp(magnitude, magnitude2, t);
		}

		// Token: 0x040002A4 RID: 676
		public const float Epsilon = 0.0001f;
	}
}
