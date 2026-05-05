using System;
using UnityEngine;

namespace RootMotion
{
	// Token: 0x0200001A RID: 26
	public class AxisTools
	{
		// Token: 0x0600007B RID: 123 RVA: 0x00004A42 File Offset: 0x00002C42
		public static Vector3 ToVector3(Axis axis)
		{
			if (axis == Axis.X)
			{
				return Vector3.right;
			}
			if (axis == Axis.Y)
			{
				return Vector3.up;
			}
			return Vector3.forward;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00004A5C File Offset: 0x00002C5C
		public static Axis ToAxis(Vector3 v)
		{
			float num = Mathf.Abs(v.x);
			float num2 = Mathf.Abs(v.y);
			float num3 = Mathf.Abs(v.z);
			Axis result = Axis.X;
			if (num2 > num && num2 > num3)
			{
				result = Axis.Y;
			}
			if (num3 > num && num3 > num2)
			{
				result = Axis.Z;
			}
			return result;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00004AA4 File Offset: 0x00002CA4
		public static Axis GetAxisToPoint(Transform t, Vector3 worldPosition)
		{
			Vector3 axisVectorToPoint = AxisTools.GetAxisVectorToPoint(t, worldPosition);
			if (axisVectorToPoint == Vector3.right)
			{
				return Axis.X;
			}
			if (axisVectorToPoint == Vector3.up)
			{
				return Axis.Y;
			}
			return Axis.Z;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00004AD8 File Offset: 0x00002CD8
		public static Axis GetAxisToDirection(Transform t, Vector3 direction)
		{
			Vector3 axisVectorToDirection = AxisTools.GetAxisVectorToDirection(t, direction);
			if (axisVectorToDirection == Vector3.right)
			{
				return Axis.X;
			}
			if (axisVectorToDirection == Vector3.up)
			{
				return Axis.Y;
			}
			return Axis.Z;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00004B0C File Offset: 0x00002D0C
		public static Vector3 GetAxisVectorToPoint(Transform t, Vector3 worldPosition)
		{
			return AxisTools.GetAxisVectorToDirection(t, worldPosition - t.position);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00004B20 File Offset: 0x00002D20
		public static Vector3 GetAxisVectorToDirection(Transform t, Vector3 direction)
		{
			return AxisTools.GetAxisVectorToDirection(t.rotation, direction);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00004B30 File Offset: 0x00002D30
		public static Vector3 GetAxisVectorToDirection(Quaternion r, Vector3 direction)
		{
			direction = direction.normalized;
			Vector3 result = Vector3.right;
			float num = Mathf.Abs(Vector3.Dot(r * Vector3.right, direction));
			float num2 = Mathf.Abs(Vector3.Dot(r * Vector3.up, direction));
			if (num2 > num)
			{
				result = Vector3.up;
			}
			float num3 = Mathf.Abs(Vector3.Dot(r * Vector3.forward, direction));
			if (num3 > num && num3 > num2)
			{
				result = Vector3.forward;
			}
			return result;
		}
	}
}
