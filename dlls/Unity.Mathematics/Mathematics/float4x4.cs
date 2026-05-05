using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Unity.Mathematics
{
	// Token: 0x02000028 RID: 40
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float4x4 : IEquatable<float4x4>, IFormattable
	{
		// Token: 0x06001530 RID: 5424 RVA: 0x0003BF2D File Offset: 0x0003A12D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(float4 c0, float4 c1, float4 c2, float4 c3)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
			this.c3 = c3;
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x0003BF4C File Offset: 0x0003A14C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
		{
			this.c0 = new float4(m00, m10, m20, m30);
			this.c1 = new float4(m01, m11, m21, m31);
			this.c2 = new float4(m02, m12, m22, m32);
			this.c3 = new float4(m03, m13, m23, m33);
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x0003BFA2 File Offset: 0x0003A1A2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(float v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x0003BFD4 File Offset: 0x0003A1D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(bool v)
		{
			this.c0 = math.select(new float4(0f), new float4(1f), v);
			this.c1 = math.select(new float4(0f), new float4(1f), v);
			this.c2 = math.select(new float4(0f), new float4(1f), v);
			this.c3 = math.select(new float4(0f), new float4(1f), v);
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x0003C064 File Offset: 0x0003A264
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(bool4x4 v)
		{
			this.c0 = math.select(new float4(0f), new float4(1f), v.c0);
			this.c1 = math.select(new float4(0f), new float4(1f), v.c1);
			this.c2 = math.select(new float4(0f), new float4(1f), v.c2);
			this.c3 = math.select(new float4(0f), new float4(1f), v.c3);
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x0003C105 File Offset: 0x0003A305
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06001536 RID: 5430 RVA: 0x0003C138 File Offset: 0x0003A338
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(int4x4 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
			this.c3 = v.c3;
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x0003C189 File Offset: 0x0003A389
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x0003C1BC File Offset: 0x0003A3BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(uint4x4 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
			this.c3 = v.c3;
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x0003C20D File Offset: 0x0003A40D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(double v)
		{
			this.c0 = (float4)v;
			this.c1 = (float4)v;
			this.c2 = (float4)v;
			this.c3 = (float4)v;
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x0003C240 File Offset: 0x0003A440
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x4(double4x4 v)
		{
			this.c0 = (float4)v.c0;
			this.c1 = (float4)v.c1;
			this.c2 = (float4)v.c2;
			this.c3 = (float4)v.c3;
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x0003C291 File Offset: 0x0003A491
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x4(float v)
		{
			return new float4x4(v);
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x0003C299 File Offset: 0x0003A499
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x4(bool v)
		{
			return new float4x4(v);
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x0003C2A1 File Offset: 0x0003A4A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x4(bool4x4 v)
		{
			return new float4x4(v);
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0003C2A9 File Offset: 0x0003A4A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x4(int v)
		{
			return new float4x4(v);
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x0003C2B1 File Offset: 0x0003A4B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x4(int4x4 v)
		{
			return new float4x4(v);
		}

		// Token: 0x06001540 RID: 5440 RVA: 0x0003C2B9 File Offset: 0x0003A4B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x4(uint v)
		{
			return new float4x4(v);
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x0003C2C1 File Offset: 0x0003A4C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x4(uint4x4 v)
		{
			return new float4x4(v);
		}

		// Token: 0x06001542 RID: 5442 RVA: 0x0003C2C9 File Offset: 0x0003A4C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x4(double v)
		{
			return new float4x4(v);
		}

		// Token: 0x06001543 RID: 5443 RVA: 0x0003C2D1 File Offset: 0x0003A4D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x4(double4x4 v)
		{
			return new float4x4(v);
		}

		// Token: 0x06001544 RID: 5444 RVA: 0x0003C2DC File Offset: 0x0003A4DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator *(float4x4 lhs, float4x4 rhs)
		{
			return new float4x4(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3);
		}

		// Token: 0x06001545 RID: 5445 RVA: 0x0003C332 File Offset: 0x0003A532
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator *(float4x4 lhs, float rhs)
		{
			return new float4x4(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs, lhs.c3 * rhs);
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x0003C369 File Offset: 0x0003A569
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator *(float lhs, float4x4 rhs)
		{
			return new float4x4(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3);
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x0003C3A0 File Offset: 0x0003A5A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator +(float4x4 lhs, float4x4 rhs)
		{
			return new float4x4(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3);
		}

		// Token: 0x06001548 RID: 5448 RVA: 0x0003C3F6 File Offset: 0x0003A5F6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator +(float4x4 lhs, float rhs)
		{
			return new float4x4(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs, lhs.c3 + rhs);
		}

		// Token: 0x06001549 RID: 5449 RVA: 0x0003C42D File Offset: 0x0003A62D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator +(float lhs, float4x4 rhs)
		{
			return new float4x4(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2, lhs + rhs.c3);
		}

		// Token: 0x0600154A RID: 5450 RVA: 0x0003C464 File Offset: 0x0003A664
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator -(float4x4 lhs, float4x4 rhs)
		{
			return new float4x4(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3);
		}

		// Token: 0x0600154B RID: 5451 RVA: 0x0003C4BA File Offset: 0x0003A6BA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator -(float4x4 lhs, float rhs)
		{
			return new float4x4(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs, lhs.c3 - rhs);
		}

		// Token: 0x0600154C RID: 5452 RVA: 0x0003C4F1 File Offset: 0x0003A6F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator -(float lhs, float4x4 rhs)
		{
			return new float4x4(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2, lhs - rhs.c3);
		}

		// Token: 0x0600154D RID: 5453 RVA: 0x0003C528 File Offset: 0x0003A728
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator /(float4x4 lhs, float4x4 rhs)
		{
			return new float4x4(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3);
		}

		// Token: 0x0600154E RID: 5454 RVA: 0x0003C57E File Offset: 0x0003A77E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator /(float4x4 lhs, float rhs)
		{
			return new float4x4(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs);
		}

		// Token: 0x0600154F RID: 5455 RVA: 0x0003C5B5 File Offset: 0x0003A7B5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator /(float lhs, float4x4 rhs)
		{
			return new float4x4(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2, lhs / rhs.c3);
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x0003C5EC File Offset: 0x0003A7EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator %(float4x4 lhs, float4x4 rhs)
		{
			return new float4x4(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3);
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x0003C642 File Offset: 0x0003A842
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator %(float4x4 lhs, float rhs)
		{
			return new float4x4(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs);
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x0003C679 File Offset: 0x0003A879
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator %(float lhs, float4x4 rhs)
		{
			return new float4x4(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2, lhs % rhs.c3);
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x0003C6B0 File Offset: 0x0003A8B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator ++(float4x4 val)
		{
			float4 @float = ++val.c0;
			val.c0 = @float;
			float4 float2 = @float;
			@float = ++val.c1;
			val.c1 = @float;
			float4 float3 = @float;
			@float = ++val.c2;
			val.c2 = @float;
			float4 float4 = @float;
			@float = ++val.c3;
			val.c3 = @float;
			return new float4x4(float2, float3, float4, @float);
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x0003C72C File Offset: 0x0003A92C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator --(float4x4 val)
		{
			float4 @float = --val.c0;
			val.c0 = @float;
			float4 float2 = @float;
			@float = --val.c1;
			val.c1 = @float;
			float4 float3 = @float;
			@float = --val.c2;
			val.c2 = @float;
			float4 float4 = @float;
			@float = --val.c3;
			val.c3 = @float;
			return new float4x4(float2, float3, float4, @float);
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x0003C7A8 File Offset: 0x0003A9A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <(float4x4 lhs, float4x4 rhs)
		{
			return new bool4x4(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3);
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x0003C7FE File Offset: 0x0003A9FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <(float4x4 lhs, float rhs)
		{
			return new bool4x4(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs, lhs.c3 < rhs);
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x0003C835 File Offset: 0x0003AA35
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <(float lhs, float4x4 rhs)
		{
			return new bool4x4(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2, lhs < rhs.c3);
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x0003C86C File Offset: 0x0003AA6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <=(float4x4 lhs, float4x4 rhs)
		{
			return new bool4x4(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3);
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x0003C8C2 File Offset: 0x0003AAC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <=(float4x4 lhs, float rhs)
		{
			return new bool4x4(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs, lhs.c3 <= rhs);
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x0003C8F9 File Offset: 0x0003AAF9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <=(float lhs, float4x4 rhs)
		{
			return new bool4x4(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2, lhs <= rhs.c3);
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x0003C930 File Offset: 0x0003AB30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >(float4x4 lhs, float4x4 rhs)
		{
			return new bool4x4(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3);
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x0003C986 File Offset: 0x0003AB86
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >(float4x4 lhs, float rhs)
		{
			return new bool4x4(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs, lhs.c3 > rhs);
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x0003C9BD File Offset: 0x0003ABBD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >(float lhs, float4x4 rhs)
		{
			return new bool4x4(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2, lhs > rhs.c3);
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x0003C9F4 File Offset: 0x0003ABF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >=(float4x4 lhs, float4x4 rhs)
		{
			return new bool4x4(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3);
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x0003CA4A File Offset: 0x0003AC4A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >=(float4x4 lhs, float rhs)
		{
			return new bool4x4(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs, lhs.c3 >= rhs);
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x0003CA81 File Offset: 0x0003AC81
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >=(float lhs, float4x4 rhs)
		{
			return new bool4x4(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2, lhs >= rhs.c3);
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x0003CAB8 File Offset: 0x0003ACB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator -(float4x4 val)
		{
			return new float4x4(-val.c0, -val.c1, -val.c2, -val.c3);
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x0003CAEB File Offset: 0x0003ACEB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 operator +(float4x4 val)
		{
			return new float4x4(+val.c0, +val.c1, +val.c2, +val.c3);
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x0003CB20 File Offset: 0x0003AD20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator ==(float4x4 lhs, float4x4 rhs)
		{
			return new bool4x4(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);
		}

		// Token: 0x06001564 RID: 5476 RVA: 0x0003CB76 File Offset: 0x0003AD76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator ==(float4x4 lhs, float rhs)
		{
			return new bool4x4(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs);
		}

		// Token: 0x06001565 RID: 5477 RVA: 0x0003CBAD File Offset: 0x0003ADAD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator ==(float lhs, float4x4 rhs)
		{
			return new bool4x4(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3);
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x0003CBE4 File Offset: 0x0003ADE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator !=(float4x4 lhs, float4x4 rhs)
		{
			return new bool4x4(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x0003CC3A File Offset: 0x0003AE3A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator !=(float4x4 lhs, float rhs)
		{
			return new bool4x4(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs);
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x0003CC71 File Offset: 0x0003AE71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator !=(float lhs, float4x4 rhs)
		{
			return new bool4x4(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3);
		}

		// Token: 0x170005C7 RID: 1479
		public unsafe float4 this[int index]
		{
			get
			{
				fixed (float4x4* ptr = &this)
				{
					return ref *(float4*)(ptr + (IntPtr)index * (IntPtr)sizeof(float4) / (IntPtr)sizeof(float4x4));
				}
			}
		}

		// Token: 0x0600156A RID: 5482 RVA: 0x0003CCC4 File Offset: 0x0003AEC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float4x4 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2) && this.c3.Equals(rhs.c3);
		}

		// Token: 0x0600156B RID: 5483 RVA: 0x0003CD20 File Offset: 0x0003AF20
		public override bool Equals(object o)
		{
			if (o is float4x4)
			{
				float4x4 rhs = (float4x4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x0600156C RID: 5484 RVA: 0x0003CD45 File Offset: 0x0003AF45
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x0600156D RID: 5485 RVA: 0x0003CD54 File Offset: 0x0003AF54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float4x4({0}f, {1}f, {2}f, {3}f,  {4}f, {5}f, {6}f, {7}f,  {8}f, {9}f, {10}f, {11}f,  {12}f, {13}f, {14}f, {15}f)", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c3.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c3.y,
				this.c0.z,
				this.c1.z,
				this.c2.z,
				this.c3.z,
				this.c0.w,
				this.c1.w,
				this.c2.w,
				this.c3.w
			});
		}

		// Token: 0x0600156E RID: 5486 RVA: 0x0003CEAC File Offset: 0x0003B0AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float4x4({0}f, {1}f, {2}f, {3}f,  {4}f, {5}f, {6}f, {7}f,  {8}f, {9}f, {10}f, {11}f,  {12}f, {13}f, {14}f, {15}f)", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c3.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider),
				this.c3.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c2.z.ToString(format, formatProvider),
				this.c3.z.ToString(format, formatProvider),
				this.c0.w.ToString(format, formatProvider),
				this.c1.w.ToString(format, formatProvider),
				this.c2.w.ToString(format, formatProvider),
				this.c3.w.ToString(format, formatProvider)
			});
		}

		// Token: 0x0600156F RID: 5487 RVA: 0x0003D021 File Offset: 0x0003B221
		public static implicit operator float4x4(Matrix4x4 m)
		{
			return new float4x4(m.GetColumn(0), m.GetColumn(1), m.GetColumn(2), m.GetColumn(3));
		}

		// Token: 0x06001570 RID: 5488 RVA: 0x0003D05C File Offset: 0x0003B25C
		public static implicit operator Matrix4x4(float4x4 m)
		{
			return new Matrix4x4(m.c0, m.c1, m.c2, m.c3);
		}

		// Token: 0x06001571 RID: 5489 RVA: 0x0003D090 File Offset: 0x0003B290
		public float4x4(float3x3 rotation, float3 translation)
		{
			this.c0 = math.float4(rotation.c0, 0f);
			this.c1 = math.float4(rotation.c1, 0f);
			this.c2 = math.float4(rotation.c2, 0f);
			this.c3 = math.float4(translation, 1f);
		}

		// Token: 0x06001572 RID: 5490 RVA: 0x0003D0F0 File Offset: 0x0003B2F0
		public float4x4(quaternion rotation, float3 translation)
		{
			float3x3 float3x = math.float3x3(rotation);
			this.c0 = math.float4(float3x.c0, 0f);
			this.c1 = math.float4(float3x.c1, 0f);
			this.c2 = math.float4(float3x.c2, 0f);
			this.c3 = math.float4(translation, 1f);
		}

		// Token: 0x06001573 RID: 5491 RVA: 0x0003D158 File Offset: 0x0003B358
		public float4x4(RigidTransform transform)
		{
			float3x3 float3x = math.float3x3(transform.rot);
			this.c0 = math.float4(float3x.c0, 0f);
			this.c1 = math.float4(float3x.c1, 0f);
			this.c2 = math.float4(float3x.c2, 0f);
			this.c3 = math.float4(transform.pos, 1f);
		}

		// Token: 0x06001574 RID: 5492 RVA: 0x0003D1CC File Offset: 0x0003B3CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 AxisAngle(float3 axis, float angle)
		{
			float rhs;
			float num;
			math.sincos(angle, out rhs, out num);
			float4 @float = math.float4(axis, 0f);
			float4 yzxx = @float.yzxx;
			float4 zxyx = @float.zxyx;
			float4 rhs2 = @float - @float * num;
			float4 float2 = math.float4(@float.xyz * rhs, num);
			uint4 rhs3 = math.uint4(0U, 0U, 2147483648U, 0U);
			uint4 rhs4 = math.uint4(2147483648U, 0U, 0U, 0U);
			uint4 rhs5 = math.uint4(0U, 2147483648U, 0U, 0U);
			uint4 rhs6 = math.uint4(uint.MaxValue, uint.MaxValue, uint.MaxValue, 0U);
			return math.float4x4(@float.x * rhs2 + math.asfloat((math.asuint(float2.wzyx) ^ rhs3) & rhs6), @float.y * rhs2 + math.asfloat((math.asuint(float2.zwxx) ^ rhs4) & rhs6), @float.z * rhs2 + math.asfloat((math.asuint(float2.yxwx) ^ rhs5) & rhs6), math.float4(0f, 0f, 0f, 1f));
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x0003D308 File Offset: 0x0003B508
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerXYZ(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float4x4(float2.y * float2.z, float2.z * @float.x * @float.y - float2.x * @float.z, float2.x * float2.z * @float.y + @float.x * @float.z, 0f, float2.y * @float.z, float2.x * float2.z + @float.x * @float.y * @float.z, float2.x * @float.y * @float.z - float2.z * @float.x, 0f, -@float.y, float2.y * @float.x, float2.x * float2.y, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06001576 RID: 5494 RVA: 0x0003D40C File Offset: 0x0003B60C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerXZY(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float4x4(float2.y * float2.z, @float.x * @float.y - float2.x * float2.y * @float.z, float2.x * @float.y + float2.y * @float.x * @float.z, 0f, @float.z, float2.x * float2.z, -float2.z * @float.x, 0f, -float2.z * @float.y, float2.y * @float.x + float2.x * @float.y * @float.z, float2.x * float2.y - @float.x * @float.y * @float.z, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06001577 RID: 5495 RVA: 0x0003D510 File Offset: 0x0003B710
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerYXZ(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float4x4(float2.y * float2.z - @float.x * @float.y * @float.z, -float2.x * @float.z, float2.z * @float.y + float2.y * @float.x * @float.z, 0f, float2.z * @float.x * @float.y + float2.y * @float.z, float2.x * float2.z, @float.y * @float.z - float2.y * float2.z * @float.x, 0f, -float2.x * @float.y, @float.x, float2.x * float2.y, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06001578 RID: 5496 RVA: 0x0003D614 File Offset: 0x0003B814
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerYZX(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float4x4(float2.y * float2.z, -@float.z, float2.z * @float.y, 0f, @float.x * @float.y + float2.x * float2.y * @float.z, float2.x * float2.z, float2.x * @float.y * @float.z - float2.y * @float.x, 0f, float2.y * @float.x * @float.z - float2.x * @float.y, float2.z * @float.x, float2.x * float2.y + @float.x * @float.y * @float.z, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06001579 RID: 5497 RVA: 0x0003D718 File Offset: 0x0003B918
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerZXY(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float4x4(float2.y * float2.z + @float.x * @float.y * @float.z, float2.z * @float.x * @float.y - float2.y * @float.z, float2.x * @float.y, 0f, float2.x * @float.z, float2.x * float2.z, -@float.x, 0f, float2.y * @float.x * @float.z - float2.z * @float.y, float2.y * float2.z * @float.x + @float.y * @float.z, float2.x * float2.y, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x0600157A RID: 5498 RVA: 0x0003D81C File Offset: 0x0003BA1C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerZYX(float3 xyz)
		{
			float3 @float;
			float3 float2;
			math.sincos(xyz, out @float, out float2);
			return math.float4x4(float2.y * float2.z, -float2.y * @float.z, @float.y, 0f, float2.z * @float.x * @float.y + float2.x * @float.z, float2.x * float2.z - @float.x * @float.y * @float.z, -float2.y * @float.x, 0f, @float.x * @float.z - float2.x * float2.z * @float.y, float2.z * @float.x + float2.x * @float.y * @float.z, float2.x * float2.y, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x0600157B RID: 5499 RVA: 0x0003D91F File Offset: 0x0003BB1F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerXYZ(float x, float y, float z)
		{
			return float4x4.EulerXYZ(math.float3(x, y, z));
		}

		// Token: 0x0600157C RID: 5500 RVA: 0x0003D92E File Offset: 0x0003BB2E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerXZY(float x, float y, float z)
		{
			return float4x4.EulerXZY(math.float3(x, y, z));
		}

		// Token: 0x0600157D RID: 5501 RVA: 0x0003D93D File Offset: 0x0003BB3D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerYXZ(float x, float y, float z)
		{
			return float4x4.EulerYXZ(math.float3(x, y, z));
		}

		// Token: 0x0600157E RID: 5502 RVA: 0x0003D94C File Offset: 0x0003BB4C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerYZX(float x, float y, float z)
		{
			return float4x4.EulerYZX(math.float3(x, y, z));
		}

		// Token: 0x0600157F RID: 5503 RVA: 0x0003D95B File Offset: 0x0003BB5B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerZXY(float x, float y, float z)
		{
			return float4x4.EulerZXY(math.float3(x, y, z));
		}

		// Token: 0x06001580 RID: 5504 RVA: 0x0003D96A File Offset: 0x0003BB6A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 EulerZYX(float x, float y, float z)
		{
			return float4x4.EulerZYX(math.float3(x, y, z));
		}

		// Token: 0x06001581 RID: 5505 RVA: 0x0003D97C File Offset: 0x0003BB7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 Euler(float3 xyz, math.RotationOrder order = math.RotationOrder.ZXY)
		{
			switch (order)
			{
			case math.RotationOrder.XYZ:
				return float4x4.EulerXYZ(xyz);
			case math.RotationOrder.XZY:
				return float4x4.EulerXZY(xyz);
			case math.RotationOrder.YXZ:
				return float4x4.EulerYXZ(xyz);
			case math.RotationOrder.YZX:
				return float4x4.EulerYZX(xyz);
			case math.RotationOrder.ZXY:
				return float4x4.EulerZXY(xyz);
			case math.RotationOrder.ZYX:
				return float4x4.EulerZYX(xyz);
			default:
				return float4x4.identity;
			}
		}

		// Token: 0x06001582 RID: 5506 RVA: 0x0003D9D8 File Offset: 0x0003BBD8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 Euler(float x, float y, float z, math.RotationOrder order = math.RotationOrder.ZXY)
		{
			return float4x4.Euler(math.float3(x, y, z), order);
		}

		// Token: 0x06001583 RID: 5507 RVA: 0x0003D9E8 File Offset: 0x0003BBE8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 RotateX(float angle)
		{
			float num;
			float num2;
			math.sincos(angle, out num, out num2);
			return math.float4x4(1f, 0f, 0f, 0f, 0f, num2, -num, 0f, 0f, num, num2, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x0003DA48 File Offset: 0x0003BC48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 RotateY(float angle)
		{
			float num;
			float num2;
			math.sincos(angle, out num, out num2);
			return math.float4x4(num2, 0f, num, 0f, 0f, 1f, 0f, 0f, -num, 0f, num2, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06001585 RID: 5509 RVA: 0x0003DAA8 File Offset: 0x0003BCA8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 RotateZ(float angle)
		{
			float num;
			float num2;
			math.sincos(angle, out num, out num2);
			return math.float4x4(num2, -num, 0f, 0f, num, num2, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06001586 RID: 5510 RVA: 0x0003DB08 File Offset: 0x0003BD08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 Scale(float s)
		{
			return math.float4x4(s, 0f, 0f, 0f, 0f, s, 0f, 0f, 0f, 0f, s, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06001587 RID: 5511 RVA: 0x0003DB60 File Offset: 0x0003BD60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 Scale(float x, float y, float z)
		{
			return math.float4x4(x, 0f, 0f, 0f, 0f, y, 0f, 0f, 0f, 0f, z, 0f, 0f, 0f, 0f, 1f);
		}

		// Token: 0x06001588 RID: 5512 RVA: 0x0003DBB6 File Offset: 0x0003BDB6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 Scale(float3 scales)
		{
			return float4x4.Scale(scales.x, scales.y, scales.z);
		}

		// Token: 0x06001589 RID: 5513 RVA: 0x0003DBD0 File Offset: 0x0003BDD0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 Translate(float3 vector)
		{
			return math.float4x4(math.float4(1f, 0f, 0f, 0f), math.float4(0f, 1f, 0f, 0f), math.float4(0f, 0f, 1f, 0f), math.float4(vector.x, vector.y, vector.z, 1f));
		}

		// Token: 0x0600158A RID: 5514 RVA: 0x0003DC4C File Offset: 0x0003BE4C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 LookAt(float3 eye, float3 target, float3 up)
		{
			float3x3 float3x = float3x3.LookRotation(math.normalize(target - eye), up);
			float4x4 result;
			result.c0 = math.float4(float3x.c0, 0f);
			result.c1 = math.float4(float3x.c1, 0f);
			result.c2 = math.float4(float3x.c2, 0f);
			result.c3 = math.float4(eye, 1f);
			return result;
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x0003DCC4 File Offset: 0x0003BEC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 Ortho(float width, float height, float near, float far)
		{
			float num = 1f / width;
			float num2 = 1f / height;
			float num3 = 1f / (far - near);
			return math.float4x4(2f * num, 0f, 0f, 0f, 0f, 2f * num2, 0f, 0f, 0f, 0f, -2f * num3, -(far + near) * num3, 0f, 0f, 0f, 1f);
		}

		// Token: 0x0600158C RID: 5516 RVA: 0x0003DD48 File Offset: 0x0003BF48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 OrthoOffCenter(float left, float right, float bottom, float top, float near, float far)
		{
			float num = 1f / (right - left);
			float num2 = 1f / (top - bottom);
			float num3 = 1f / (far - near);
			return math.float4x4(2f * num, 0f, 0f, -(right + left) * num, 0f, 2f * num2, 0f, -(top + bottom) * num2, 0f, 0f, -2f * num3, -(far + near) * num3, 0f, 0f, 0f, 1f);
		}

		// Token: 0x0600158D RID: 5517 RVA: 0x0003DDD8 File Offset: 0x0003BFD8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 PerspectiveFov(float verticalFov, float aspect, float near, float far)
		{
			float num = 1f / math.tan(verticalFov * 0.5f);
			float num2 = 1f / (near - far);
			return math.float4x4(num / aspect, 0f, 0f, 0f, 0f, num, 0f, 0f, 0f, 0f, (far + near) * num2, 2f * near * far * num2, 0f, 0f, -1f, 0f);
		}

		// Token: 0x0600158E RID: 5518 RVA: 0x0003DE58 File Offset: 0x0003C058
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far)
		{
			float num = 1f / (near - far);
			float num2 = 1f / (right - left);
			float num3 = 1f / (top - bottom);
			return math.float4x4(2f * near * num2, 0f, (left + right) * num2, 0f, 0f, 2f * near * num3, (bottom + top) * num3, 0f, 0f, 0f, (far + near) * num, 2f * near * far * num, 0f, 0f, -1f, 0f);
		}

		// Token: 0x0600158F RID: 5519 RVA: 0x0003DEF0 File Offset: 0x0003C0F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 TRS(float3 translation, quaternion rotation, float3 scale)
		{
			float3x3 float3x = math.float3x3(rotation);
			return math.float4x4(math.float4(float3x.c0 * scale.x, 0f), math.float4(float3x.c1 * scale.y, 0f), math.float4(float3x.c2 * scale.z, 0f), math.float4(translation, 1f));
		}

		// Token: 0x0400009B RID: 155
		public float4 c0;

		// Token: 0x0400009C RID: 156
		public float4 c1;

		// Token: 0x0400009D RID: 157
		public float4 c2;

		// Token: 0x0400009E RID: 158
		public float4 c3;

		// Token: 0x0400009F RID: 159
		public static readonly float4x4 identity = new float4x4(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);

		// Token: 0x040000A0 RID: 160
		public static readonly float4x4 zero;
	}
}
