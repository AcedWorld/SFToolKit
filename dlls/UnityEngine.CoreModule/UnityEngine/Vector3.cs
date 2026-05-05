using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020001F1 RID: 497
	[NativeHeader("Runtime/Math/MathScripting.h")]
	[NativeHeader("Runtime/Math/Vector3.h")]
	[NativeClass("Vector3f")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	[Il2CppEagerStaticClassConstruction]
	[NativeType(Header = "Runtime/Math/Vector3.h")]
	public struct Vector3 : IEquatable<Vector3>, IFormattable
	{
		// Token: 0x06001581 RID: 5505 RVA: 0x00021450 File Offset: 0x0001F650
		[FreeFunction("VectorScripting::Slerp", IsThreadSafe = true)]
		public static Vector3 Slerp(Vector3 a, Vector3 b, float t)
		{
			Vector3 result;
			Vector3.Slerp_Injected(ref a, ref b, t, out result);
			return result;
		}

		// Token: 0x06001582 RID: 5506 RVA: 0x0002146C File Offset: 0x0001F66C
		[FreeFunction("VectorScripting::SlerpUnclamped", IsThreadSafe = true)]
		public static Vector3 SlerpUnclamped(Vector3 a, Vector3 b, float t)
		{
			Vector3 result;
			Vector3.SlerpUnclamped_Injected(ref a, ref b, t, out result);
			return result;
		}

		// Token: 0x06001583 RID: 5507
		[FreeFunction("VectorScripting::OrthoNormalize", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void OrthoNormalize2(ref Vector3 a, ref Vector3 b);

		// Token: 0x06001584 RID: 5508 RVA: 0x00021486 File Offset: 0x0001F686
		public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent)
		{
			Vector3.OrthoNormalize2(ref normal, ref tangent);
		}

		// Token: 0x06001585 RID: 5509
		[FreeFunction("VectorScripting::OrthoNormalize", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void OrthoNormalize3(ref Vector3 a, ref Vector3 b, ref Vector3 c);

		// Token: 0x06001586 RID: 5510 RVA: 0x00021491 File Offset: 0x0001F691
		public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent, ref Vector3 binormal)
		{
			Vector3.OrthoNormalize3(ref normal, ref tangent, ref binormal);
		}

		// Token: 0x06001587 RID: 5511 RVA: 0x000214A0 File Offset: 0x0001F6A0
		[FreeFunction(IsThreadSafe = true)]
		public static Vector3 RotateTowards(Vector3 current, Vector3 target, float maxRadiansDelta, float maxMagnitudeDelta)
		{
			Vector3 result;
			Vector3.RotateTowards_Injected(ref current, ref target, maxRadiansDelta, maxMagnitudeDelta, out result);
			return result;
		}

		// Token: 0x06001588 RID: 5512 RVA: 0x000214BC File Offset: 0x0001F6BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
		{
			t = Mathf.Clamp01(t);
			return new Vector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
		}

		// Token: 0x06001589 RID: 5513 RVA: 0x00021520 File Offset: 0x0001F720
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, float t)
		{
			return new Vector3(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t, a.z + (b.z - a.z) * t);
		}

		// Token: 0x0600158A RID: 5514 RVA: 0x0002157C File Offset: 0x0001F77C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta)
		{
			float num = target.x - current.x;
			float num2 = target.y - current.y;
			float num3 = target.z - current.z;
			float num4 = num * num + num2 * num2 + num3 * num3;
			bool flag = num4 == 0f || (maxDistanceDelta >= 0f && num4 <= maxDistanceDelta * maxDistanceDelta);
			Vector3 result;
			if (flag)
			{
				result = target;
			}
			else
			{
				float num5 = (float)Math.Sqrt((double)num4);
				result = new Vector3(current.x + num / num5 * maxDistanceDelta, current.y + num2 / num5 * maxDistanceDelta, current.z + num3 / num5 * maxDistanceDelta);
			}
			return result;
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x00021628 File Offset: 0x0001F828
		[ExcludeFromDocs]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed)
		{
			float deltaTime = Time.deltaTime;
			return Vector3.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
		}

		// Token: 0x0600158C RID: 5516 RVA: 0x0002164C File Offset: 0x0001F84C
		[ExcludeFromDocs]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime)
		{
			float deltaTime = Time.deltaTime;
			float positiveInfinity = float.PositiveInfinity;
			return Vector3.SmoothDamp(current, target, ref currentVelocity, smoothTime, positiveInfinity, deltaTime);
		}

		// Token: 0x0600158D RID: 5517 RVA: 0x00021678 File Offset: 0x0001F878
		public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime)
		{
			smoothTime = Mathf.Max(0.0001f, smoothTime);
			float num = 2f / smoothTime;
			float num2 = num * deltaTime;
			float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
			float num4 = current.x - target.x;
			float num5 = current.y - target.y;
			float num6 = current.z - target.z;
			Vector3 vector = target;
			float num7 = maxSpeed * smoothTime;
			float num8 = num7 * num7;
			float num9 = num4 * num4 + num5 * num5 + num6 * num6;
			bool flag = num9 > num8;
			if (flag)
			{
				float num10 = (float)Math.Sqrt((double)num9);
				num4 = num4 / num10 * num7;
				num5 = num5 / num10 * num7;
				num6 = num6 / num10 * num7;
			}
			target.x = current.x - num4;
			target.y = current.y - num5;
			target.z = current.z - num6;
			float num11 = (currentVelocity.x + num * num4) * deltaTime;
			float num12 = (currentVelocity.y + num * num5) * deltaTime;
			float num13 = (currentVelocity.z + num * num6) * deltaTime;
			currentVelocity.x = (currentVelocity.x - num * num11) * num3;
			currentVelocity.y = (currentVelocity.y - num * num12) * num3;
			currentVelocity.z = (currentVelocity.z - num * num13) * num3;
			float num14 = target.x + (num4 + num11) * num3;
			float num15 = target.y + (num5 + num12) * num3;
			float num16 = target.z + (num6 + num13) * num3;
			float num17 = vector.x - current.x;
			float num18 = vector.y - current.y;
			float num19 = vector.z - current.z;
			float num20 = num14 - vector.x;
			float num21 = num15 - vector.y;
			float num22 = num16 - vector.z;
			bool flag2 = num17 * num20 + num18 * num21 + num19 * num22 > 0f;
			if (flag2)
			{
				num14 = vector.x;
				num15 = vector.y;
				num16 = vector.z;
				currentVelocity.x = (num14 - vector.x) / deltaTime;
				currentVelocity.y = (num15 - vector.y) / deltaTime;
				currentVelocity.z = (num16 - vector.z) / deltaTime;
			}
			return new Vector3(num14, num15, num16);
		}

		// Token: 0x1700045C RID: 1116
		public float this[int index]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				float result;
				switch (index)
				{
				case 0:
					result = this.x;
					break;
				case 1:
					result = this.y;
					break;
				case 2:
					result = this.z;
					break;
				default:
					throw new IndexOutOfRangeException("Invalid Vector3 index!");
				}
				return result;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				switch (index)
				{
				case 0:
					this.x = value;
					break;
				case 1:
					this.y = value;
					break;
				case 2:
					this.z = value;
					break;
				default:
					throw new IndexOutOfRangeException("Invalid Vector3 index!");
				}
			}
		}

		// Token: 0x06001590 RID: 5520 RVA: 0x0002199C File Offset: 0x0001FB9C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		// Token: 0x06001591 RID: 5521 RVA: 0x000219B4 File Offset: 0x0001FBB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3(float x, float y)
		{
			this.x = x;
			this.y = y;
			this.z = 0f;
		}

		// Token: 0x06001592 RID: 5522 RVA: 0x0002199C File Offset: 0x0001FB9C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(float newX, float newY, float newZ)
		{
			this.x = newX;
			this.y = newY;
			this.z = newZ;
		}

		// Token: 0x06001593 RID: 5523 RVA: 0x000219D0 File Offset: 0x0001FBD0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Scale(Vector3 a, Vector3 b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		// Token: 0x06001594 RID: 5524 RVA: 0x00021A0E File Offset: 0x0001FC0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Scale(Vector3 scale)
		{
			this.x *= scale.x;
			this.y *= scale.y;
			this.z *= scale.z;
		}

		// Token: 0x06001595 RID: 5525 RVA: 0x00021A4C File Offset: 0x0001FC4C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
		{
			return new Vector3(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
		}

		// Token: 0x06001596 RID: 5526 RVA: 0x00021AB4 File Offset: 0x0001FCB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2;
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x00021AF0 File Offset: 0x0001FCF0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object other)
		{
			bool flag = !(other is Vector3);
			return !flag && this.Equals((Vector3)other);
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x00021B24 File Offset: 0x0001FD24
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Vector3 other)
		{
			return this.x == other.x && this.y == other.y && this.z == other.z;
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x00021B64 File Offset: 0x0001FD64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal)
		{
			float num = -2f * Vector3.Dot(inNormal, inDirection);
			return new Vector3(num * inNormal.x + inDirection.x, num * inNormal.y + inDirection.y, num * inNormal.z + inDirection.z);
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x00021BB8 File Offset: 0x0001FDB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Normalize(Vector3 value)
		{
			float num = Vector3.Magnitude(value);
			bool flag = num > 1E-05f;
			Vector3 result;
			if (flag)
			{
				result = value / num;
			}
			else
			{
				result = Vector3.zero;
			}
			return result;
		}

		// Token: 0x0600159B RID: 5531 RVA: 0x00021BEC File Offset: 0x0001FDEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Normalize()
		{
			float num = Vector3.Magnitude(this);
			bool flag = num > 1E-05f;
			if (flag)
			{
				this /= num;
			}
			else
			{
				this = Vector3.zero;
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x0600159C RID: 5532 RVA: 0x00021C34 File Offset: 0x0001FE34
		public Vector3 normalized
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.Normalize(this);
			}
		}

		// Token: 0x0600159D RID: 5533 RVA: 0x00021C54 File Offset: 0x0001FE54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Dot(Vector3 lhs, Vector3 rhs)
		{
			return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
		}

		// Token: 0x0600159E RID: 5534 RVA: 0x00021C90 File Offset: 0x0001FE90
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Project(Vector3 vector, Vector3 onNormal)
		{
			float num = Vector3.Dot(onNormal, onNormal);
			bool flag = num < Mathf.Epsilon;
			Vector3 result;
			if (flag)
			{
				result = Vector3.zero;
			}
			else
			{
				float num2 = Vector3.Dot(vector, onNormal);
				result = new Vector3(onNormal.x * num2 / num, onNormal.y * num2 / num, onNormal.z * num2 / num);
			}
			return result;
		}

		// Token: 0x0600159F RID: 5535 RVA: 0x00021CEC File Offset: 0x0001FEEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal)
		{
			float num = Vector3.Dot(planeNormal, planeNormal);
			bool flag = num < Mathf.Epsilon;
			Vector3 result;
			if (flag)
			{
				result = vector;
			}
			else
			{
				float num2 = Vector3.Dot(vector, planeNormal);
				result = new Vector3(vector.x - planeNormal.x * num2 / num, vector.y - planeNormal.y * num2 / num, vector.z - planeNormal.z * num2 / num);
			}
			return result;
		}

		// Token: 0x060015A0 RID: 5536 RVA: 0x00021D58 File Offset: 0x0001FF58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Angle(Vector3 from, Vector3 to)
		{
			float num = (float)Math.Sqrt((double)(from.sqrMagnitude * to.sqrMagnitude));
			bool flag = num < 1E-15f;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num2 = Mathf.Clamp(Vector3.Dot(from, to) / num, -1f, 1f);
				result = (float)Math.Acos((double)num2) * 57.29578f;
			}
			return result;
		}

		// Token: 0x060015A1 RID: 5537 RVA: 0x00021DBC File Offset: 0x0001FFBC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
		{
			float num = Vector3.Angle(from, to);
			float num2 = from.y * to.z - from.z * to.y;
			float num3 = from.z * to.x - from.x * to.z;
			float num4 = from.x * to.y - from.y * to.x;
			float num5 = Mathf.Sign(axis.x * num2 + axis.y * num3 + axis.z * num4);
			return num * num5;
		}

		// Token: 0x060015A2 RID: 5538 RVA: 0x00021E54 File Offset: 0x00020054
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Distance(Vector3 a, Vector3 b)
		{
			float num = a.x - b.x;
			float num2 = a.y - b.y;
			float num3 = a.z - b.z;
			return (float)Math.Sqrt((double)(num * num + num2 * num2 + num3 * num3));
		}

		// Token: 0x060015A3 RID: 5539 RVA: 0x00021EA4 File Offset: 0x000200A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ClampMagnitude(Vector3 vector, float maxLength)
		{
			float sqrMagnitude = vector.sqrMagnitude;
			bool flag = sqrMagnitude > maxLength * maxLength;
			Vector3 result;
			if (flag)
			{
				float num = (float)Math.Sqrt((double)sqrMagnitude);
				float num2 = vector.x / num;
				float num3 = vector.y / num;
				float num4 = vector.z / num;
				result = new Vector3(num2 * maxLength, num3 * maxLength, num4 * maxLength);
			}
			else
			{
				result = vector;
			}
			return result;
		}

		// Token: 0x060015A4 RID: 5540 RVA: 0x00021F08 File Offset: 0x00020108
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Magnitude(Vector3 vector)
		{
			return (float)Math.Sqrt((double)(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z));
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x060015A5 RID: 5541 RVA: 0x00021F4C File Offset: 0x0002014C
		public float magnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (float)Math.Sqrt((double)(this.x * this.x + this.y * this.y + this.z * this.z));
			}
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x00021F90 File Offset: 0x00020190
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SqrMagnitude(Vector3 vector)
		{
			return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x060015A7 RID: 5543 RVA: 0x00021FCC File Offset: 0x000201CC
		public float sqrMagnitude
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return this.x * this.x + this.y * this.y + this.z * this.z;
			}
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x00022008 File Offset: 0x00020208
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Min(Vector3 lhs, Vector3 rhs)
		{
			return new Vector3(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y), Mathf.Min(lhs.z, rhs.z));
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x00022054 File Offset: 0x00020254
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Max(Vector3 lhs, Vector3 rhs)
		{
			return new Vector3(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y), Mathf.Max(lhs.z, rhs.z));
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x060015AA RID: 5546 RVA: 0x000220A0 File Offset: 0x000202A0
		public static Vector3 zero
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.zeroVector;
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x060015AB RID: 5547 RVA: 0x000220B8 File Offset: 0x000202B8
		public static Vector3 one
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.oneVector;
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x060015AC RID: 5548 RVA: 0x000220D0 File Offset: 0x000202D0
		public static Vector3 forward
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.forwardVector;
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x060015AD RID: 5549 RVA: 0x000220E8 File Offset: 0x000202E8
		public static Vector3 back
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.backVector;
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x060015AE RID: 5550 RVA: 0x00022100 File Offset: 0x00020300
		public static Vector3 up
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.upVector;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x060015AF RID: 5551 RVA: 0x00022118 File Offset: 0x00020318
		public static Vector3 down
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.downVector;
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x060015B0 RID: 5552 RVA: 0x00022130 File Offset: 0x00020330
		public static Vector3 left
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.leftVector;
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x060015B1 RID: 5553 RVA: 0x00022148 File Offset: 0x00020348
		public static Vector3 right
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.rightVector;
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x060015B2 RID: 5554 RVA: 0x00022160 File Offset: 0x00020360
		public static Vector3 positiveInfinity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.positiveInfinityVector;
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x060015B3 RID: 5555 RVA: 0x00022178 File Offset: 0x00020378
		public static Vector3 negativeInfinity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Vector3.negativeInfinityVector;
			}
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x00022190 File Offset: 0x00020390
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator +(Vector3 a, Vector3 b)
		{
			return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x000221D0 File Offset: 0x000203D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator -(Vector3 a, Vector3 b)
		{
			return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		// Token: 0x060015B6 RID: 5558 RVA: 0x00022210 File Offset: 0x00020410
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator -(Vector3 a)
		{
			return new Vector3(-a.x, -a.y, -a.z);
		}

		// Token: 0x060015B7 RID: 5559 RVA: 0x0002223C File Offset: 0x0002043C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator *(Vector3 a, float d)
		{
			return new Vector3(a.x * d, a.y * d, a.z * d);
		}

		// Token: 0x060015B8 RID: 5560 RVA: 0x0002226C File Offset: 0x0002046C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator *(float d, Vector3 a)
		{
			return new Vector3(a.x * d, a.y * d, a.z * d);
		}

		// Token: 0x060015B9 RID: 5561 RVA: 0x0002229C File Offset: 0x0002049C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 operator /(Vector3 a, float d)
		{
			return new Vector3(a.x / d, a.y / d, a.z / d);
		}

		// Token: 0x060015BA RID: 5562 RVA: 0x000222CC File Offset: 0x000204CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Vector3 lhs, Vector3 rhs)
		{
			float num = lhs.x - rhs.x;
			float num2 = lhs.y - rhs.y;
			float num3 = lhs.z - rhs.z;
			float num4 = num * num + num2 * num2 + num3 * num3;
			return num4 < 9.9999994E-11f;
		}

		// Token: 0x060015BB RID: 5563 RVA: 0x00022320 File Offset: 0x00020520
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Vector3 lhs, Vector3 rhs)
		{
			return !(lhs == rhs);
		}

		// Token: 0x060015BC RID: 5564 RVA: 0x0002233C File Offset: 0x0002053C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return this.ToString(null, null);
		}

		// Token: 0x060015BD RID: 5565 RVA: 0x00022358 File Offset: 0x00020558
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format)
		{
			return this.ToString(format, null);
		}

		// Token: 0x060015BE RID: 5566 RVA: 0x00022374 File Offset: 0x00020574
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			bool flag = string.IsNullOrEmpty(format);
			if (flag)
			{
				format = "F2";
			}
			bool flag2 = formatProvider == null;
			if (flag2)
			{
				formatProvider = CultureInfo.InvariantCulture.NumberFormat;
			}
			return UnityString.Format("({0}, {1}, {2})", new object[]
			{
				this.x.ToString(format, formatProvider),
				this.y.ToString(format, formatProvider),
				this.z.ToString(format, formatProvider)
			});
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x060015BF RID: 5567 RVA: 0x000223EC File Offset: 0x000205EC
		[Obsolete("Use Vector3.forward instead.")]
		public static Vector3 fwd
		{
			get
			{
				return new Vector3(0f, 0f, 1f);
			}
		}

		// Token: 0x060015C0 RID: 5568 RVA: 0x00022414 File Offset: 0x00020614
		[Obsolete("Use Vector3.Angle instead. AngleBetween uses radians instead of degrees and was deprecated for this reason")]
		public static float AngleBetween(Vector3 from, Vector3 to)
		{
			return (float)Math.Acos((double)Mathf.Clamp(Vector3.Dot(from.normalized, to.normalized), -1f, 1f));
		}

		// Token: 0x060015C1 RID: 5569 RVA: 0x00022450 File Offset: 0x00020650
		[Obsolete("Use Vector3.ProjectOnPlane instead.")]
		public static Vector3 Exclude(Vector3 excludeThis, Vector3 fromThat)
		{
			return Vector3.ProjectOnPlane(fromThat, excludeThis);
		}

		// Token: 0x060015C3 RID: 5571
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Slerp_Injected(ref Vector3 a, ref Vector3 b, float t, out Vector3 ret);

		// Token: 0x060015C4 RID: 5572
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SlerpUnclamped_Injected(ref Vector3 a, ref Vector3 b, float t, out Vector3 ret);

		// Token: 0x060015C5 RID: 5573
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RotateTowards_Injected(ref Vector3 current, ref Vector3 target, float maxRadiansDelta, float maxMagnitudeDelta, out Vector3 ret);

		// Token: 0x040007FC RID: 2044
		public const float kEpsilon = 1E-05f;

		// Token: 0x040007FD RID: 2045
		public const float kEpsilonNormalSqrt = 1E-15f;

		// Token: 0x040007FE RID: 2046
		public float x;

		// Token: 0x040007FF RID: 2047
		public float y;

		// Token: 0x04000800 RID: 2048
		public float z;

		// Token: 0x04000801 RID: 2049
		private static readonly Vector3 zeroVector = new Vector3(0f, 0f, 0f);

		// Token: 0x04000802 RID: 2050
		private static readonly Vector3 oneVector = new Vector3(1f, 1f, 1f);

		// Token: 0x04000803 RID: 2051
		private static readonly Vector3 upVector = new Vector3(0f, 1f, 0f);

		// Token: 0x04000804 RID: 2052
		private static readonly Vector3 downVector = new Vector3(0f, -1f, 0f);

		// Token: 0x04000805 RID: 2053
		private static readonly Vector3 leftVector = new Vector3(-1f, 0f, 0f);

		// Token: 0x04000806 RID: 2054
		private static readonly Vector3 rightVector = new Vector3(1f, 0f, 0f);

		// Token: 0x04000807 RID: 2055
		private static readonly Vector3 forwardVector = new Vector3(0f, 0f, 1f);

		// Token: 0x04000808 RID: 2056
		private static readonly Vector3 backVector = new Vector3(0f, 0f, -1f);

		// Token: 0x04000809 RID: 2057
		private static readonly Vector3 positiveInfinityVector = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

		// Token: 0x0400080A RID: 2058
		private static readonly Vector3 negativeInfinityVector = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
	}
}
