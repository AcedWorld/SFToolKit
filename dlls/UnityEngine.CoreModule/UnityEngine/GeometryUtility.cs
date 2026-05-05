using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine
{
	// Token: 0x0200012D RID: 301
	[StaticAccessor("GeometryUtilityScripting", StaticAccessorType.DoubleColon)]
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	public sealed class GeometryUtility
	{
		// Token: 0x060007A3 RID: 1955 RVA: 0x0000BF40 File Offset: 0x0000A140
		public static Plane[] CalculateFrustumPlanes(Camera camera)
		{
			Plane[] array = new Plane[6];
			GeometryUtility.CalculateFrustumPlanes(camera, array);
			return array;
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0000BF64 File Offset: 0x0000A164
		public static Plane[] CalculateFrustumPlanes(Matrix4x4 worldToProjectionMatrix)
		{
			Plane[] array = new Plane[6];
			GeometryUtility.CalculateFrustumPlanes(worldToProjectionMatrix, array);
			return array;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0000BF86 File Offset: 0x0000A186
		public static void CalculateFrustumPlanes(Camera camera, Plane[] planes)
		{
			GeometryUtility.CalculateFrustumPlanes(camera.projectionMatrix * camera.worldToCameraMatrix, planes);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0000BFA4 File Offset: 0x0000A1A4
		public static void CalculateFrustumPlanes(Matrix4x4 worldToProjectionMatrix, Plane[] planes)
		{
			bool flag = planes == null;
			if (flag)
			{
				throw new ArgumentNullException("planes");
			}
			bool flag2 = planes.Length != 6;
			if (flag2)
			{
				throw new ArgumentException("Planes array must be of length 6.", "planes");
			}
			GeometryUtility.Internal_ExtractPlanes(planes, worldToProjectionMatrix);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0000BFEC File Offset: 0x0000A1EC
		public static Bounds CalculateBounds(Vector3[] positions, Matrix4x4 transform)
		{
			bool flag = positions == null;
			if (flag)
			{
				throw new ArgumentNullException("positions");
			}
			bool flag2 = positions.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("Zero-sized array is not allowed.", "positions");
			}
			return GeometryUtility.Internal_CalculateBounds(positions, transform);
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0000C034 File Offset: 0x0000A234
		public static bool TryCreatePlaneFromPolygon(Vector3[] vertices, out Plane plane)
		{
			bool flag = vertices == null || vertices.Length < 3;
			bool result;
			if (flag)
			{
				plane = new Plane(Vector3.up, 0f);
				result = false;
			}
			else
			{
				bool flag2 = vertices.Length == 3;
				if (flag2)
				{
					Vector3 a = vertices[0];
					Vector3 b = vertices[1];
					Vector3 c = vertices[2];
					plane = new Plane(a, b, c);
					result = (plane.normal.sqrMagnitude > 0f);
				}
				else
				{
					Vector3 zero = Vector3.zero;
					int num = vertices.Length - 1;
					Vector3 vector = vertices[num];
					foreach (Vector3 vector2 in vertices)
					{
						zero.x += (vector.y - vector2.y) * (vector.z + vector2.z);
						zero.y += (vector.z - vector2.z) * (vector.x + vector2.x);
						zero.z += (vector.x - vector2.x) * (vector.y + vector2.y);
						vector = vector2;
					}
					zero.Normalize();
					float num2 = 0f;
					foreach (Vector3 rhs in vertices)
					{
						num2 -= Vector3.Dot(zero, rhs);
					}
					num2 /= (float)vertices.Length;
					plane = new Plane(zero, num2);
					result = (plane.normal.sqrMagnitude > 0f);
				}
			}
			return result;
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0000C1F7 File Offset: 0x0000A3F7
		public static bool TestPlanesAABB(Plane[] planes, Bounds bounds)
		{
			return GeometryUtility.TestPlanesAABB_Injected(planes, ref bounds);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0000C201 File Offset: 0x0000A401
		[NativeName("ExtractPlanes")]
		private static void Internal_ExtractPlanes([Out] Plane[] planes, Matrix4x4 worldToProjectionMatrix)
		{
			GeometryUtility.Internal_ExtractPlanes_Injected(planes, ref worldToProjectionMatrix);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0000C20C File Offset: 0x0000A40C
		[NativeName("CalculateBounds")]
		private static Bounds Internal_CalculateBounds(Vector3[] positions, Matrix4x4 transform)
		{
			Bounds result;
			GeometryUtility.Internal_CalculateBounds_Injected(positions, ref transform, out result);
			return result;
		}

		// Token: 0x060007AD RID: 1965
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool TestPlanesAABB_Injected(Plane[] planes, ref Bounds bounds);

		// Token: 0x060007AE RID: 1966
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_ExtractPlanes_Injected([Out] Plane[] planes, ref Matrix4x4 worldToProjectionMatrix);

		// Token: 0x060007AF RID: 1967
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_CalculateBounds_Injected(Vector3[] positions, ref Matrix4x4 transform, out Bounds ret);
	}
}
