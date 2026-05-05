using System;
using Unity.Mathematics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000031 RID: 49
	internal static class GeometryUtils
	{
		// Token: 0x06000088 RID: 136 RVA: 0x0000593C File Offset: 0x00003B3C
		public unsafe static bool Overlap(OrientedBBox obb, Frustum frustum, int numPlanes, int numCorners)
		{
			bool flag = true;
			int num = 0;
			while (flag && num < numPlanes)
			{
				Vector3 normal = frustum.planes[num].normal;
				float distance = frustum.planes[num].distance;
				float num2 = obb.extentX * Mathf.Abs(Vector3.Dot(normal, obb.right)) + obb.extentY * Mathf.Abs(Vector3.Dot(normal, obb.up)) + obb.extentZ * Mathf.Abs(Vector3.Dot(normal, obb.forward));
				float num3 = Vector3.Dot(normal, obb.center) + distance;
				flag = (flag && num2 + num3 >= 0f);
				num++;
			}
			if (numCorners == 0)
			{
				return flag;
			}
			Plane* ptr = stackalloc Plane[checked(unchecked((UIntPtr)3) * (UIntPtr)sizeof(Plane))];
			ptr->normal = obb.right;
			ptr->distance = obb.extentX;
			ptr[1].normal = obb.up;
			ptr[1].distance = obb.extentY;
			ptr[2].normal = obb.forward;
			ptr[2].distance = obb.extentZ;
			int num4 = 0;
			while (flag && num4 < 3)
			{
				Plane plane = ptr[num4];
				bool flag2 = true;
				bool flag3 = true;
				for (int i = 0; i < numCorners; i++)
				{
					float num5 = Vector3.Dot(plane.normal, frustum.corners[i] - obb.center);
					flag2 = (flag2 && num5 > plane.distance);
					flag3 = (flag3 && -num5 > plane.distance);
				}
				flag = (flag && (!flag2 && !flag3));
				num4++;
			}
			return flag;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005B18 File Offset: 0x00003D18
		public static Vector4 Plane(Vector3 position, Vector3 normal)
		{
			float w = -Vector3.Dot(normal, position);
			return new Vector4(normal.x, normal.y, normal.z, w);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00005B48 File Offset: 0x00003D48
		public static Vector4 CameraSpacePlane(Matrix4x4 worldToCamera, Vector3 positionWS, Vector3 normalWS, float sideSign = 1f, float clipPlaneOffset = 0f)
		{
			Vector3 point = positionWS + normalWS * clipPlaneOffset;
			Vector3 lhs = worldToCamera.MultiplyPoint(point);
			Vector3 vector = worldToCamera.MultiplyVector(normalWS).normalized * sideSign;
			return new Vector4(vector.x, vector.y, vector.z, -Vector3.Dot(lhs, vector));
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005BA4 File Offset: 0x00003DA4
		public static Matrix4x4 CalculateWorldToCameraMatrixRHS(Vector3 position, Quaternion rotation)
		{
			return Matrix4x4.Scale(new Vector3(1f, 1f, -1f)) * Matrix4x4.TRS(position, rotation, Vector3.one).inverse;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00005BE4 File Offset: 0x00003DE4
		public static Matrix4x4 CalculateWorldToCameraMatrixRHS(Transform transform)
		{
			return Matrix4x4.Scale(new Vector3(1f, 1f, -1f)) * transform.localToWorldMatrix.inverse;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005C20 File Offset: 0x00003E20
		public static Matrix4x4 CalculateObliqueMatrix(Matrix4x4 sourceProjection, Vector4 clipPlane)
		{
			Matrix4x4 result = sourceProjection;
			Matrix4x4 inverse = sourceProjection.inverse;
			Vector4 vector = new Vector4(Mathf.Sign(clipPlane.x), Mathf.Sign(clipPlane.y), 1f, 1f);
			Vector4 b = inverse * vector;
			Vector4 vector2 = new Vector4(result[3], result[7], result[11], result[15]);
			Vector4 vector3 = clipPlane * (2f * Vector4.Dot(vector2, b) / Vector4.Dot(clipPlane, b));
			result[2] = vector3.x - vector2.x;
			result[6] = vector3.y - vector2.y;
			result[10] = vector3.z - vector2.z;
			result[14] = vector3.w - vector2.w;
			return result;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00005D05 File Offset: 0x00003F05
		public static Matrix4x4 CalculateReflectionMatrix(Vector3 position, Vector3 normal)
		{
			return GeometryUtils.CalculateReflectionMatrix(GeometryUtils.Plane(position, normal.normalized));
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00005D1C File Offset: 0x00003F1C
		public static Matrix4x4 CalculateReflectionMatrix(Vector4 plane)
		{
			return new Matrix4x4
			{
				m00 = 1f - 2f * plane[0] * plane[0],
				m01 = -2f * plane[0] * plane[1],
				m02 = -2f * plane[0] * plane[2],
				m03 = -2f * plane[3] * plane[0],
				m10 = -2f * plane[1] * plane[0],
				m11 = 1f - 2f * plane[1] * plane[1],
				m12 = -2f * plane[1] * plane[2],
				m13 = -2f * plane[3] * plane[1],
				m20 = -2f * plane[2] * plane[0],
				m21 = -2f * plane[2] * plane[1],
				m22 = 1f - 2f * plane[2] * plane[2],
				m23 = -2f * plane[3] * plane[2],
				m30 = 0f,
				m31 = 0f,
				m32 = 0f,
				m33 = 1f
			};
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00005EDC File Offset: 0x000040DC
		public static bool IsProjectionMatrixOblique(Matrix4x4 projectionMatrix)
		{
			return projectionMatrix[2] != 0f || projectionMatrix[6] != 0f;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00005F04 File Offset: 0x00004104
		public static Matrix4x4 CalculateProjectionMatrix(Camera camera)
		{
			if (camera.orthographic)
			{
				float orthographicSize = camera.orthographicSize;
				float num = camera.orthographicSize * camera.aspect;
				return Matrix4x4.Ortho(-num, num, -orthographicSize, orthographicSize, camera.nearClipPlane, camera.farClipPlane);
			}
			return Matrix4x4.Perspective(camera.GetGateFittedFieldOfView(), camera.aspect, camera.nearClipPlane, camera.farClipPlane);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00005F64 File Offset: 0x00004164
		private static float DistanceToOriginAABB(Vector3 point, Vector3 aabbSize)
		{
			float3 @float = math.abs(point) - math.float3(aabbSize);
			return math.length(math.max(@float, 0f)) + math.min(math.max(@float.x, math.max(@float.y, @float.z)), 0f);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00005FCC File Offset: 0x000041CC
		public static float DistanceToOBB(OrientedBBox obb, Vector3 point)
		{
			float3 x = point - obb.center;
			float3 y = math.normalize(math.cross(obb.right, obb.up));
			return GeometryUtils.DistanceToOriginAABB(math.float3(math.dot(x, math.normalize(obb.right)), math.dot(x, math.normalize(obb.up)), math.dot(x, y)), math.float3(obb.extentX, obb.extentY, obb.extentZ));
		}
	}
}
