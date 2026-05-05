using System;
using UnityEngine;

namespace Cinemachine.Utility
{
	// Token: 0x02000069 RID: 105
	public static class UnityQuaternionExtensions
	{
		// Token: 0x060003FD RID: 1021 RVA: 0x00018594 File Offset: 0x00016794
		public static Quaternion SlerpWithReferenceUp(Quaternion qA, Quaternion qB, float t, Vector3 up)
		{
			Vector3 vector = (qA * Vector3.forward).ProjectOntoPlane(up);
			Vector3 v = (qB * Vector3.forward).ProjectOntoPlane(up);
			if (vector.AlmostZero() || v.AlmostZero())
			{
				return Quaternion.Slerp(qA, qB, t);
			}
			Quaternion quaternion = Quaternion.LookRotation(vector, up);
			Quaternion lhs = Quaternion.Inverse(quaternion);
			Quaternion quaternion2 = lhs * qA;
			Quaternion quaternion3 = lhs * qB;
			Vector3 eulerAngles = quaternion2.eulerAngles;
			Vector3 eulerAngles2 = quaternion3.eulerAngles;
			return quaternion * Quaternion.Euler(Mathf.LerpAngle(eulerAngles.x, eulerAngles2.x, t), Mathf.LerpAngle(eulerAngles.y, eulerAngles2.y, t), Mathf.LerpAngle(eulerAngles.z, eulerAngles2.z, t));
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00018654 File Offset: 0x00016854
		public static Quaternion Normalized(this Quaternion q)
		{
			Vector4 normalized = new Vector4(q.x, q.y, q.z, q.w).normalized;
			return new Quaternion(normalized.x, normalized.y, normalized.z, normalized.w);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x000186A4 File Offset: 0x000168A4
		public static Vector2 GetCameraRotationToTarget(this Quaternion orient, Vector3 lookAtDir, Vector3 worldUp)
		{
			if (lookAtDir.AlmostZero())
			{
				return Vector2.zero;
			}
			Quaternion rotation = Quaternion.Inverse(orient);
			Vector3 vector = rotation * worldUp;
			lookAtDir = rotation * lookAtDir;
			float num = 0f;
			Vector3 vector2 = lookAtDir.ProjectOntoPlane(vector);
			if (!vector2.AlmostZero())
			{
				Vector3 vector3 = Vector3.forward.ProjectOntoPlane(vector);
				if (vector3.AlmostZero())
				{
					if (Vector3.Dot(vector3, vector) > 0f)
					{
						vector3 = Vector3.down.ProjectOntoPlane(vector);
					}
					else
					{
						vector3 = Vector3.up.ProjectOntoPlane(vector);
					}
				}
				num = UnityVectorExtensions.SignedAngle(vector3, vector2, vector);
			}
			Quaternion rotation2 = Quaternion.AngleAxis(num, vector);
			return new Vector2(UnityVectorExtensions.SignedAngle(rotation2 * Vector3.forward, lookAtDir, rotation2 * Vector3.right), num);
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00018760 File Offset: 0x00016960
		public static Quaternion ApplyCameraRotation(this Quaternion orient, Vector2 rot, Vector3 worldUp)
		{
			if (rot.sqrMagnitude < 0.0001f)
			{
				return orient;
			}
			Quaternion rhs = Quaternion.AngleAxis(rot.x, Vector3.right);
			return Quaternion.AngleAxis(rot.y, worldUp) * orient * rhs;
		}
	}
}
