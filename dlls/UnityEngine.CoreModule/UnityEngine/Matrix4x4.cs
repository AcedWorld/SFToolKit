using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001F0 RID: 496
	[NativeType(Header = "Runtime/Math/Matrix4x4.h")]
	[NativeHeader("Runtime/Math/MathScripting.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	[NativeClass("Matrix4x4f")]
	[Il2CppEagerStaticClassConstruction]
	public struct Matrix4x4 : IEquatable<Matrix4x4>, IFormattable
	{
		// Token: 0x0600153B RID: 5435 RVA: 0x0001FCF8 File Offset: 0x0001DEF8
		[ThreadSafe]
		private Quaternion GetRotation()
		{
			Quaternion result;
			Matrix4x4.GetRotation_Injected(ref this, out result);
			return result;
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x0001FD10 File Offset: 0x0001DF10
		[ThreadSafe]
		private Vector3 GetLossyScale()
		{
			Vector3 result;
			Matrix4x4.GetLossyScale_Injected(ref this, out result);
			return result;
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x0001FD26 File Offset: 0x0001DF26
		[ThreadSafe]
		private bool IsIdentity()
		{
			return Matrix4x4.IsIdentity_Injected(ref this);
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0001FD2E File Offset: 0x0001DF2E
		[ThreadSafe]
		private float GetDeterminant()
		{
			return Matrix4x4.GetDeterminant_Injected(ref this);
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x0001FD38 File Offset: 0x0001DF38
		[ThreadSafe]
		private FrustumPlanes DecomposeProjection()
		{
			FrustumPlanes result;
			Matrix4x4.DecomposeProjection_Injected(ref this, out result);
			return result;
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06001540 RID: 5440 RVA: 0x0001FD50 File Offset: 0x0001DF50
		public Quaternion rotation
		{
			get
			{
				return this.GetRotation();
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06001541 RID: 5441 RVA: 0x0001FD68 File Offset: 0x0001DF68
		public Vector3 lossyScale
		{
			get
			{
				return this.GetLossyScale();
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06001542 RID: 5442 RVA: 0x0001FD80 File Offset: 0x0001DF80
		public bool isIdentity
		{
			get
			{
				return this.IsIdentity();
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06001543 RID: 5443 RVA: 0x0001FD98 File Offset: 0x0001DF98
		public float determinant
		{
			get
			{
				return this.GetDeterminant();
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06001544 RID: 5444 RVA: 0x0001FDB0 File Offset: 0x0001DFB0
		public FrustumPlanes decomposeProjection
		{
			get
			{
				return this.DecomposeProjection();
			}
		}

		// Token: 0x06001545 RID: 5445 RVA: 0x0001FDC8 File Offset: 0x0001DFC8
		[ThreadSafe]
		public bool ValidTRS()
		{
			return Matrix4x4.ValidTRS_Injected(ref this);
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x0001FDD0 File Offset: 0x0001DFD0
		public static float Determinant(Matrix4x4 m)
		{
			return m.determinant;
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x0001FDEC File Offset: 0x0001DFEC
		[FreeFunction("MatrixScripting::TRS", IsThreadSafe = true)]
		public static Matrix4x4 TRS(Vector3 pos, Quaternion q, Vector3 s)
		{
			Matrix4x4 result;
			Matrix4x4.TRS_Injected(ref pos, ref q, ref s, out result);
			return result;
		}

		// Token: 0x06001548 RID: 5448 RVA: 0x0001FE07 File Offset: 0x0001E007
		public void SetTRS(Vector3 pos, Quaternion q, Vector3 s)
		{
			this = Matrix4x4.TRS(pos, q, s);
		}

		// Token: 0x06001549 RID: 5449 RVA: 0x0001FE18 File Offset: 0x0001E018
		[FreeFunction("MatrixScripting::Inverse3DAffine", IsThreadSafe = true)]
		public static bool Inverse3DAffine(Matrix4x4 input, ref Matrix4x4 result)
		{
			return Matrix4x4.Inverse3DAffine_Injected(ref input, ref result);
		}

		// Token: 0x0600154A RID: 5450 RVA: 0x0001FE24 File Offset: 0x0001E024
		[FreeFunction("MatrixScripting::Inverse", IsThreadSafe = true)]
		public static Matrix4x4 Inverse(Matrix4x4 m)
		{
			Matrix4x4 result;
			Matrix4x4.Inverse_Injected(ref m, out result);
			return result;
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x0600154B RID: 5451 RVA: 0x0001FE3C File Offset: 0x0001E03C
		public Matrix4x4 inverse
		{
			get
			{
				return Matrix4x4.Inverse(this);
			}
		}

		// Token: 0x0600154C RID: 5452 RVA: 0x0001FE5C File Offset: 0x0001E05C
		[FreeFunction("MatrixScripting::Transpose", IsThreadSafe = true)]
		public static Matrix4x4 Transpose(Matrix4x4 m)
		{
			Matrix4x4 result;
			Matrix4x4.Transpose_Injected(ref m, out result);
			return result;
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x0600154D RID: 5453 RVA: 0x0001FE74 File Offset: 0x0001E074
		public Matrix4x4 transpose
		{
			get
			{
				return Matrix4x4.Transpose(this);
			}
		}

		// Token: 0x0600154E RID: 5454 RVA: 0x0001FE94 File Offset: 0x0001E094
		[FreeFunction("MatrixScripting::Ortho", IsThreadSafe = true)]
		public static Matrix4x4 Ortho(float left, float right, float bottom, float top, float zNear, float zFar)
		{
			Matrix4x4 result;
			Matrix4x4.Ortho_Injected(left, right, bottom, top, zNear, zFar, out result);
			return result;
		}

		// Token: 0x0600154F RID: 5455 RVA: 0x0001FEB4 File Offset: 0x0001E0B4
		[FreeFunction("MatrixScripting::Perspective", IsThreadSafe = true)]
		public static Matrix4x4 Perspective(float fov, float aspect, float zNear, float zFar)
		{
			Matrix4x4 result;
			Matrix4x4.Perspective_Injected(fov, aspect, zNear, zFar, out result);
			return result;
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x0001FED0 File Offset: 0x0001E0D0
		[FreeFunction("MatrixScripting::LookAt", IsThreadSafe = true)]
		public static Matrix4x4 LookAt(Vector3 from, Vector3 to, Vector3 up)
		{
			Matrix4x4 result;
			Matrix4x4.LookAt_Injected(ref from, ref to, ref up, out result);
			return result;
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x0001FEEC File Offset: 0x0001E0EC
		[FreeFunction("MatrixScripting::Frustum", IsThreadSafe = true)]
		public static Matrix4x4 Frustum(float left, float right, float bottom, float top, float zNear, float zFar)
		{
			Matrix4x4 result;
			Matrix4x4.Frustum_Injected(left, right, bottom, top, zNear, zFar, out result);
			return result;
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x0001FF0C File Offset: 0x0001E10C
		public static Matrix4x4 Frustum(FrustumPlanes fp)
		{
			return Matrix4x4.Frustum(fp.left, fp.right, fp.bottom, fp.top, fp.zNear, fp.zFar);
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x0001FF47 File Offset: 0x0001E147
		[FreeFunction("MatrixScripting::Internal_CompareApproximately", IsThreadSafe = true)]
		internal static bool CompareApproximately(Matrix4x4 a, Matrix4x4 b, float threshold)
		{
			return Matrix4x4.CompareApproximately_Injected(ref a, ref b, threshold);
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x0001FF54 File Offset: 0x0001E154
		public Matrix4x4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
		{
			this.m00 = column0.x;
			this.m01 = column1.x;
			this.m02 = column2.x;
			this.m03 = column3.x;
			this.m10 = column0.y;
			this.m11 = column1.y;
			this.m12 = column2.y;
			this.m13 = column3.y;
			this.m20 = column0.z;
			this.m21 = column1.z;
			this.m22 = column2.z;
			this.m23 = column3.z;
			this.m30 = column0.w;
			this.m31 = column1.w;
			this.m32 = column2.w;
			this.m33 = column3.w;
		}

		// Token: 0x17000458 RID: 1112
		public float this[int row, int column]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this[row + column * 4];
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this[row + column * 4] = value;
			}
		}

		// Token: 0x17000459 RID: 1113
		public float this[int index]
		{
			get
			{
				float result;
				switch (index)
				{
				case 0:
					result = this.m00;
					break;
				case 1:
					result = this.m10;
					break;
				case 2:
					result = this.m20;
					break;
				case 3:
					result = this.m30;
					break;
				case 4:
					result = this.m01;
					break;
				case 5:
					result = this.m11;
					break;
				case 6:
					result = this.m21;
					break;
				case 7:
					result = this.m31;
					break;
				case 8:
					result = this.m02;
					break;
				case 9:
					result = this.m12;
					break;
				case 10:
					result = this.m22;
					break;
				case 11:
					result = this.m32;
					break;
				case 12:
					result = this.m03;
					break;
				case 13:
					result = this.m13;
					break;
				case 14:
					result = this.m23;
					break;
				case 15:
					result = this.m33;
					break;
				default:
					throw new IndexOutOfRangeException("Invalid matrix index!");
				}
				return result;
			}
			set
			{
				switch (index)
				{
				case 0:
					this.m00 = value;
					break;
				case 1:
					this.m10 = value;
					break;
				case 2:
					this.m20 = value;
					break;
				case 3:
					this.m30 = value;
					break;
				case 4:
					this.m01 = value;
					break;
				case 5:
					this.m11 = value;
					break;
				case 6:
					this.m21 = value;
					break;
				case 7:
					this.m31 = value;
					break;
				case 8:
					this.m02 = value;
					break;
				case 9:
					this.m12 = value;
					break;
				case 10:
					this.m22 = value;
					break;
				case 11:
					this.m32 = value;
					break;
				case 12:
					this.m03 = value;
					break;
				case 13:
					this.m13 = value;
					break;
				case 14:
					this.m23 = value;
					break;
				case 15:
					this.m33 = value;
					break;
				default:
					throw new IndexOutOfRangeException("Invalid matrix index!");
				}
			}
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x00020260 File Offset: 0x0001E460
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return this.GetColumn(0).GetHashCode() ^ this.GetColumn(1).GetHashCode() << 2 ^ this.GetColumn(2).GetHashCode() >> 2 ^ this.GetColumn(3).GetHashCode() >> 1;
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x000202D0 File Offset: 0x0001E4D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object other)
		{
			bool flag = !(other is Matrix4x4);
			return !flag && this.Equals((Matrix4x4)other);
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x00020304 File Offset: 0x0001E504
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Matrix4x4 other)
		{
			return this.GetColumn(0).Equals(other.GetColumn(0)) && this.GetColumn(1).Equals(other.GetColumn(1)) && this.GetColumn(2).Equals(other.GetColumn(2)) && this.GetColumn(3).Equals(other.GetColumn(3));
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x0002037C File Offset: 0x0001E57C
		public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
		{
			Matrix4x4 result;
			result.m00 = lhs.m00 * rhs.m00 + lhs.m01 * rhs.m10 + lhs.m02 * rhs.m20 + lhs.m03 * rhs.m30;
			result.m01 = lhs.m00 * rhs.m01 + lhs.m01 * rhs.m11 + lhs.m02 * rhs.m21 + lhs.m03 * rhs.m31;
			result.m02 = lhs.m00 * rhs.m02 + lhs.m01 * rhs.m12 + lhs.m02 * rhs.m22 + lhs.m03 * rhs.m32;
			result.m03 = lhs.m00 * rhs.m03 + lhs.m01 * rhs.m13 + lhs.m02 * rhs.m23 + lhs.m03 * rhs.m33;
			result.m10 = lhs.m10 * rhs.m00 + lhs.m11 * rhs.m10 + lhs.m12 * rhs.m20 + lhs.m13 * rhs.m30;
			result.m11 = lhs.m10 * rhs.m01 + lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31;
			result.m12 = lhs.m10 * rhs.m02 + lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32;
			result.m13 = lhs.m10 * rhs.m03 + lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33;
			result.m20 = lhs.m20 * rhs.m00 + lhs.m21 * rhs.m10 + lhs.m22 * rhs.m20 + lhs.m23 * rhs.m30;
			result.m21 = lhs.m20 * rhs.m01 + lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31;
			result.m22 = lhs.m20 * rhs.m02 + lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32;
			result.m23 = lhs.m20 * rhs.m03 + lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33;
			result.m30 = lhs.m30 * rhs.m00 + lhs.m31 * rhs.m10 + lhs.m32 * rhs.m20 + lhs.m33 * rhs.m30;
			result.m31 = lhs.m30 * rhs.m01 + lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31;
			result.m32 = lhs.m30 * rhs.m02 + lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32;
			result.m33 = lhs.m30 * rhs.m03 + lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33;
			return result;
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x00020770 File Offset: 0x0001E970
		public static Vector4 operator *(Matrix4x4 lhs, Vector4 vector)
		{
			Vector4 result;
			result.x = lhs.m00 * vector.x + lhs.m01 * vector.y + lhs.m02 * vector.z + lhs.m03 * vector.w;
			result.y = lhs.m10 * vector.x + lhs.m11 * vector.y + lhs.m12 * vector.z + lhs.m13 * vector.w;
			result.z = lhs.m20 * vector.x + lhs.m21 * vector.y + lhs.m22 * vector.z + lhs.m23 * vector.w;
			result.w = lhs.m30 * vector.x + lhs.m31 * vector.y + lhs.m32 * vector.z + lhs.m33 * vector.w;
			return result;
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x0002087C File Offset: 0x0001EA7C
		public static bool operator ==(Matrix4x4 lhs, Matrix4x4 rhs)
		{
			return lhs.GetColumn(0) == rhs.GetColumn(0) && lhs.GetColumn(1) == rhs.GetColumn(1) && lhs.GetColumn(2) == rhs.GetColumn(2) && lhs.GetColumn(3) == rhs.GetColumn(3);
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x000208EC File Offset: 0x0001EAEC
		public static bool operator !=(Matrix4x4 lhs, Matrix4x4 rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x00020908 File Offset: 0x0001EB08
		public Vector4 GetColumn(int index)
		{
			Vector4 result;
			switch (index)
			{
			case 0:
				result = new Vector4(this.m00, this.m10, this.m20, this.m30);
				break;
			case 1:
				result = new Vector4(this.m01, this.m11, this.m21, this.m31);
				break;
			case 2:
				result = new Vector4(this.m02, this.m12, this.m22, this.m32);
				break;
			case 3:
				result = new Vector4(this.m03, this.m13, this.m23, this.m33);
				break;
			default:
				throw new IndexOutOfRangeException("Invalid column index!");
			}
			return result;
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x000209C4 File Offset: 0x0001EBC4
		public Vector4 GetRow(int index)
		{
			Vector4 result;
			switch (index)
			{
			case 0:
				result = new Vector4(this.m00, this.m01, this.m02, this.m03);
				break;
			case 1:
				result = new Vector4(this.m10, this.m11, this.m12, this.m13);
				break;
			case 2:
				result = new Vector4(this.m20, this.m21, this.m22, this.m23);
				break;
			case 3:
				result = new Vector4(this.m30, this.m31, this.m32, this.m33);
				break;
			default:
				throw new IndexOutOfRangeException("Invalid row index!");
			}
			return result;
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x00020A80 File Offset: 0x0001EC80
		public Vector3 GetPosition()
		{
			return new Vector3(this.m03, this.m13, this.m23);
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x00020AA9 File Offset: 0x0001ECA9
		public void SetColumn(int index, Vector4 column)
		{
			this[0, index] = column.x;
			this[1, index] = column.y;
			this[2, index] = column.z;
			this[3, index] = column.w;
		}

		// Token: 0x06001564 RID: 5476 RVA: 0x00020AE8 File Offset: 0x0001ECE8
		public void SetRow(int index, Vector4 row)
		{
			this[index, 0] = row.x;
			this[index, 1] = row.y;
			this[index, 2] = row.z;
			this[index, 3] = row.w;
		}

		// Token: 0x06001565 RID: 5477 RVA: 0x00020B28 File Offset: 0x0001ED28
		public Vector3 MultiplyPoint(Vector3 point)
		{
			Vector3 result;
			result.x = this.m00 * point.x + this.m01 * point.y + this.m02 * point.z + this.m03;
			result.y = this.m10 * point.x + this.m11 * point.y + this.m12 * point.z + this.m13;
			result.z = this.m20 * point.x + this.m21 * point.y + this.m22 * point.z + this.m23;
			float num = this.m30 * point.x + this.m31 * point.y + this.m32 * point.z + this.m33;
			num = 1f / num;
			result.x *= num;
			result.y *= num;
			result.z *= num;
			return result;
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x00020C40 File Offset: 0x0001EE40
		public Vector3 MultiplyPoint3x4(Vector3 point)
		{
			Vector3 result;
			result.x = this.m00 * point.x + this.m01 * point.y + this.m02 * point.z + this.m03;
			result.y = this.m10 * point.x + this.m11 * point.y + this.m12 * point.z + this.m13;
			result.z = this.m20 * point.x + this.m21 * point.y + this.m22 * point.z + this.m23;
			return result;
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x00020CF8 File Offset: 0x0001EEF8
		public Vector3 MultiplyVector(Vector3 vector)
		{
			Vector3 result;
			result.x = this.m00 * vector.x + this.m01 * vector.y + this.m02 * vector.z;
			result.y = this.m10 * vector.x + this.m11 * vector.y + this.m12 * vector.z;
			result.z = this.m20 * vector.x + this.m21 * vector.y + this.m22 * vector.z;
			return result;
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x00020D9C File Offset: 0x0001EF9C
		public Plane TransformPlane(Plane plane)
		{
			Matrix4x4 inverse = this.inverse;
			float x = plane.normal.x;
			float y = plane.normal.y;
			float z = plane.normal.z;
			float distance = plane.distance;
			float x2 = inverse.m00 * x + inverse.m10 * y + inverse.m20 * z + inverse.m30 * distance;
			float y2 = inverse.m01 * x + inverse.m11 * y + inverse.m21 * z + inverse.m31 * distance;
			float z2 = inverse.m02 * x + inverse.m12 * y + inverse.m22 * z + inverse.m32 * distance;
			float d = inverse.m03 * x + inverse.m13 * y + inverse.m23 * z + inverse.m33 * distance;
			return new Plane(new Vector3(x2, y2, z2), d);
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x00020E94 File Offset: 0x0001F094
		public static Matrix4x4 Scale(Vector3 vector)
		{
			Matrix4x4 result;
			result.m00 = vector.x;
			result.m01 = 0f;
			result.m02 = 0f;
			result.m03 = 0f;
			result.m10 = 0f;
			result.m11 = vector.y;
			result.m12 = 0f;
			result.m13 = 0f;
			result.m20 = 0f;
			result.m21 = 0f;
			result.m22 = vector.z;
			result.m23 = 0f;
			result.m30 = 0f;
			result.m31 = 0f;
			result.m32 = 0f;
			result.m33 = 1f;
			return result;
		}

		// Token: 0x0600156A RID: 5482 RVA: 0x00020F6C File Offset: 0x0001F16C
		public static Matrix4x4 Translate(Vector3 vector)
		{
			Matrix4x4 result;
			result.m00 = 1f;
			result.m01 = 0f;
			result.m02 = 0f;
			result.m03 = vector.x;
			result.m10 = 0f;
			result.m11 = 1f;
			result.m12 = 0f;
			result.m13 = vector.y;
			result.m20 = 0f;
			result.m21 = 0f;
			result.m22 = 1f;
			result.m23 = vector.z;
			result.m30 = 0f;
			result.m31 = 0f;
			result.m32 = 0f;
			result.m33 = 1f;
			return result;
		}

		// Token: 0x0600156B RID: 5483 RVA: 0x00021044 File Offset: 0x0001F244
		public static Matrix4x4 Rotate(Quaternion q)
		{
			float num = q.x * 2f;
			float num2 = q.y * 2f;
			float num3 = q.z * 2f;
			float num4 = q.x * num;
			float num5 = q.y * num2;
			float num6 = q.z * num3;
			float num7 = q.x * num2;
			float num8 = q.x * num3;
			float num9 = q.y * num3;
			float num10 = q.w * num;
			float num11 = q.w * num2;
			float num12 = q.w * num3;
			Matrix4x4 result;
			result.m00 = 1f - (num5 + num6);
			result.m10 = num7 + num12;
			result.m20 = num8 - num11;
			result.m30 = 0f;
			result.m01 = num7 - num12;
			result.m11 = 1f - (num4 + num6);
			result.m21 = num9 + num10;
			result.m31 = 0f;
			result.m02 = num8 + num11;
			result.m12 = num9 - num10;
			result.m22 = 1f - (num4 + num5);
			result.m32 = 0f;
			result.m03 = 0f;
			result.m13 = 0f;
			result.m23 = 0f;
			result.m33 = 1f;
			return result;
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x0600156C RID: 5484 RVA: 0x000211AC File Offset: 0x0001F3AC
		public static Matrix4x4 zero
		{
			get
			{
				return Matrix4x4.zeroMatrix;
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x0600156D RID: 5485 RVA: 0x000211C4 File Offset: 0x0001F3C4
		public static Matrix4x4 identity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Matrix4x4.identityMatrix;
			}
		}

		// Token: 0x0600156E RID: 5486 RVA: 0x000211DC File Offset: 0x0001F3DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return this.ToString(null, null);
		}

		// Token: 0x0600156F RID: 5487 RVA: 0x000211F8 File Offset: 0x0001F3F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format)
		{
			return this.ToString(format, null);
		}

		// Token: 0x06001570 RID: 5488 RVA: 0x00021214 File Offset: 0x0001F414
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			bool flag = string.IsNullOrEmpty(format);
			if (flag)
			{
				format = "F5";
			}
			bool flag2 = formatProvider == null;
			if (flag2)
			{
				formatProvider = CultureInfo.InvariantCulture.NumberFormat;
			}
			return UnityString.Format("{0}\t{1}\t{2}\t{3}\n{4}\t{5}\t{6}\t{7}\n{8}\t{9}\t{10}\t{11}\n{12}\t{13}\t{14}\t{15}\n", new object[]
			{
				this.m00.ToString(format, formatProvider),
				this.m01.ToString(format, formatProvider),
				this.m02.ToString(format, formatProvider),
				this.m03.ToString(format, formatProvider),
				this.m10.ToString(format, formatProvider),
				this.m11.ToString(format, formatProvider),
				this.m12.ToString(format, formatProvider),
				this.m13.ToString(format, formatProvider),
				this.m20.ToString(format, formatProvider),
				this.m21.ToString(format, formatProvider),
				this.m22.ToString(format, formatProvider),
				this.m23.ToString(format, formatProvider),
				this.m30.ToString(format, formatProvider),
				this.m31.ToString(format, formatProvider),
				this.m32.ToString(format, formatProvider),
				this.m33.ToString(format, formatProvider)
			});
		}

		// Token: 0x06001572 RID: 5490
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRotation_Injected(ref Matrix4x4 _unity_self, out Quaternion ret);

		// Token: 0x06001573 RID: 5491
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLossyScale_Injected(ref Matrix4x4 _unity_self, out Vector3 ret);

		// Token: 0x06001574 RID: 5492
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsIdentity_Injected(ref Matrix4x4 _unity_self);

		// Token: 0x06001575 RID: 5493
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetDeterminant_Injected(ref Matrix4x4 _unity_self);

		// Token: 0x06001576 RID: 5494
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DecomposeProjection_Injected(ref Matrix4x4 _unity_self, out FrustumPlanes ret);

		// Token: 0x06001577 RID: 5495
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ValidTRS_Injected(ref Matrix4x4 _unity_self);

		// Token: 0x06001578 RID: 5496
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void TRS_Injected(ref Vector3 pos, ref Quaternion q, ref Vector3 s, out Matrix4x4 ret);

		// Token: 0x06001579 RID: 5497
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Inverse3DAffine_Injected(ref Matrix4x4 input, ref Matrix4x4 result);

		// Token: 0x0600157A RID: 5498
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Inverse_Injected(ref Matrix4x4 m, out Matrix4x4 ret);

		// Token: 0x0600157B RID: 5499
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Transpose_Injected(ref Matrix4x4 m, out Matrix4x4 ret);

		// Token: 0x0600157C RID: 5500
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Ortho_Injected(float left, float right, float bottom, float top, float zNear, float zFar, out Matrix4x4 ret);

		// Token: 0x0600157D RID: 5501
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Perspective_Injected(float fov, float aspect, float zNear, float zFar, out Matrix4x4 ret);

		// Token: 0x0600157E RID: 5502
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void LookAt_Injected(ref Vector3 from, ref Vector3 to, ref Vector3 up, out Matrix4x4 ret);

		// Token: 0x0600157F RID: 5503
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Frustum_Injected(float left, float right, float bottom, float top, float zNear, float zFar, out Matrix4x4 ret);

		// Token: 0x06001580 RID: 5504
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CompareApproximately_Injected(ref Matrix4x4 a, ref Matrix4x4 b, float threshold);

		// Token: 0x040007EA RID: 2026
		[NativeName("m_Data[0]")]
		public float m00;

		// Token: 0x040007EB RID: 2027
		[NativeName("m_Data[1]")]
		public float m10;

		// Token: 0x040007EC RID: 2028
		[NativeName("m_Data[2]")]
		public float m20;

		// Token: 0x040007ED RID: 2029
		[NativeName("m_Data[3]")]
		public float m30;

		// Token: 0x040007EE RID: 2030
		[NativeName("m_Data[4]")]
		public float m01;

		// Token: 0x040007EF RID: 2031
		[NativeName("m_Data[5]")]
		public float m11;

		// Token: 0x040007F0 RID: 2032
		[NativeName("m_Data[6]")]
		public float m21;

		// Token: 0x040007F1 RID: 2033
		[NativeName("m_Data[7]")]
		public float m31;

		// Token: 0x040007F2 RID: 2034
		[NativeName("m_Data[8]")]
		public float m02;

		// Token: 0x040007F3 RID: 2035
		[NativeName("m_Data[9]")]
		public float m12;

		// Token: 0x040007F4 RID: 2036
		[NativeName("m_Data[10]")]
		public float m22;

		// Token: 0x040007F5 RID: 2037
		[NativeName("m_Data[11]")]
		public float m32;

		// Token: 0x040007F6 RID: 2038
		[NativeName("m_Data[12]")]
		public float m03;

		// Token: 0x040007F7 RID: 2039
		[NativeName("m_Data[13]")]
		public float m13;

		// Token: 0x040007F8 RID: 2040
		[NativeName("m_Data[14]")]
		public float m23;

		// Token: 0x040007F9 RID: 2041
		[NativeName("m_Data[15]")]
		public float m33;

		// Token: 0x040007FA RID: 2042
		private static readonly Matrix4x4 zeroMatrix = new Matrix4x4(new Vector4(0f, 0f, 0f, 0f), new Vector4(0f, 0f, 0f, 0f), new Vector4(0f, 0f, 0f, 0f), new Vector4(0f, 0f, 0f, 0f));

		// Token: 0x040007FB RID: 2043
		private static readonly Matrix4x4 identityMatrix = new Matrix4x4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
	}
}
