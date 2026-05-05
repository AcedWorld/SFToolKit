using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Unity.Mathematics
{
	// Token: 0x02000021 RID: 33
	[DebuggerTypeProxy(typeof(float3.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float3 : IEquatable<float3>, IFormattable
	{
		// Token: 0x06001139 RID: 4409 RVA: 0x000322B9 File Offset: 0x000304B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x000322D0 File Offset: 0x000304D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(float x, float2 yz)
		{
			this.x = x;
			this.y = yz.x;
			this.z = yz.y;
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x000322F1 File Offset: 0x000304F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(float2 xy, float z)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = z;
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x00032312 File Offset: 0x00030512
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(float3 xyz)
		{
			this.x = xyz.x;
			this.y = xyz.y;
			this.z = xyz.z;
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x00032338 File Offset: 0x00030538
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(float v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
		}

		// Token: 0x0600113E RID: 4414 RVA: 0x00032350 File Offset: 0x00030550
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(bool v)
		{
			this.x = (v ? 1f : 0f);
			this.y = (v ? 1f : 0f);
			this.z = (v ? 1f : 0f);
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x0003239C File Offset: 0x0003059C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(bool3 v)
		{
			this.x = (v.x ? 1f : 0f);
			this.y = (v.y ? 1f : 0f);
			this.z = (v.z ? 1f : 0f);
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x000323F7 File Offset: 0x000305F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(int v)
		{
			this.x = (float)v;
			this.y = (float)v;
			this.z = (float)v;
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x00032411 File Offset: 0x00030611
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(int3 v)
		{
			this.x = (float)v.x;
			this.y = (float)v.y;
			this.z = (float)v.z;
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x0003243A File Offset: 0x0003063A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(uint v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x00032457 File Offset: 0x00030657
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(uint3 v)
		{
			this.x = v.x;
			this.y = v.y;
			this.z = v.z;
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x00032483 File Offset: 0x00030683
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(half v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x000324A9 File Offset: 0x000306A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(half3 v)
		{
			this.x = v.x;
			this.y = v.y;
			this.z = v.z;
		}

		// Token: 0x06001146 RID: 4422 RVA: 0x000324DE File Offset: 0x000306DE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(double v)
		{
			this.x = (float)v;
			this.y = (float)v;
			this.z = (float)v;
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x000324F8 File Offset: 0x000306F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float3(double3 v)
		{
			this.x = (float)v.x;
			this.y = (float)v.y;
			this.z = (float)v.z;
		}

		// Token: 0x06001148 RID: 4424 RVA: 0x00032521 File Offset: 0x00030721
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3(float v)
		{
			return new float3(v);
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x00032529 File Offset: 0x00030729
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3(bool v)
		{
			return new float3(v);
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x00032531 File Offset: 0x00030731
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3(bool3 v)
		{
			return new float3(v);
		}

		// Token: 0x0600114B RID: 4427 RVA: 0x00032539 File Offset: 0x00030739
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3(int v)
		{
			return new float3(v);
		}

		// Token: 0x0600114C RID: 4428 RVA: 0x00032541 File Offset: 0x00030741
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3(int3 v)
		{
			return new float3(v);
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x00032549 File Offset: 0x00030749
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3(uint v)
		{
			return new float3(v);
		}

		// Token: 0x0600114E RID: 4430 RVA: 0x00032551 File Offset: 0x00030751
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3(uint3 v)
		{
			return new float3(v);
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x00032559 File Offset: 0x00030759
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3(half v)
		{
			return new float3(v);
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x00032561 File Offset: 0x00030761
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float3(half3 v)
		{
			return new float3(v);
		}

		// Token: 0x06001151 RID: 4433 RVA: 0x00032569 File Offset: 0x00030769
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3(double v)
		{
			return new float3(v);
		}

		// Token: 0x06001152 RID: 4434 RVA: 0x00032571 File Offset: 0x00030771
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float3(double3 v)
		{
			return new float3(v);
		}

		// Token: 0x06001153 RID: 4435 RVA: 0x00032579 File Offset: 0x00030779
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator *(float3 lhs, float3 rhs)
		{
			return new float3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);
		}

		// Token: 0x06001154 RID: 4436 RVA: 0x000325A7 File Offset: 0x000307A7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator *(float3 lhs, float rhs)
		{
			return new float3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
		}

		// Token: 0x06001155 RID: 4437 RVA: 0x000325C6 File Offset: 0x000307C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator *(float lhs, float3 rhs)
		{
			return new float3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
		}

		// Token: 0x06001156 RID: 4438 RVA: 0x000325E5 File Offset: 0x000307E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator +(float3 lhs, float3 rhs)
		{
			return new float3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
		}

		// Token: 0x06001157 RID: 4439 RVA: 0x00032613 File Offset: 0x00030813
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator +(float3 lhs, float rhs)
		{
			return new float3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
		}

		// Token: 0x06001158 RID: 4440 RVA: 0x00032632 File Offset: 0x00030832
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator +(float lhs, float3 rhs)
		{
			return new float3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);
		}

		// Token: 0x06001159 RID: 4441 RVA: 0x00032651 File Offset: 0x00030851
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator -(float3 lhs, float3 rhs)
		{
			return new float3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x0003267F File Offset: 0x0003087F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator -(float3 lhs, float rhs)
		{
			return new float3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x0003269E File Offset: 0x0003089E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator -(float lhs, float3 rhs)
		{
			return new float3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x000326BD File Offset: 0x000308BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator /(float3 lhs, float3 rhs)
		{
			return new float3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
		}

		// Token: 0x0600115D RID: 4445 RVA: 0x000326EB File Offset: 0x000308EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator /(float3 lhs, float rhs)
		{
			return new float3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
		}

		// Token: 0x0600115E RID: 4446 RVA: 0x0003270A File Offset: 0x0003090A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator /(float lhs, float3 rhs)
		{
			return new float3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x00032729 File Offset: 0x00030929
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator %(float3 lhs, float3 rhs)
		{
			return new float3(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z);
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x00032757 File Offset: 0x00030957
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator %(float3 lhs, float rhs)
		{
			return new float3(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs);
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x00032776 File Offset: 0x00030976
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator %(float lhs, float3 rhs)
		{
			return new float3(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z);
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x00032798 File Offset: 0x00030998
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator ++(float3 val)
		{
			float num = val.x + 1f;
			val.x = num;
			float num2 = num;
			num = val.y + 1f;
			val.y = num;
			float num3 = num;
			num = val.z + 1f;
			val.z = num;
			return new float3(num2, num3, num);
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x000327E4 File Offset: 0x000309E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator --(float3 val)
		{
			float num = val.x - 1f;
			val.x = num;
			float num2 = num;
			num = val.y - 1f;
			val.y = num;
			float num3 = num;
			num = val.z - 1f;
			val.z = num;
			return new float3(num2, num3, num);
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x0003282F File Offset: 0x00030A2F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <(float3 lhs, float3 rhs)
		{
			return new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
		}

		// Token: 0x06001165 RID: 4453 RVA: 0x00032860 File Offset: 0x00030A60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <(float3 lhs, float rhs)
		{
			return new bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x00032882 File Offset: 0x00030A82
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <(float lhs, float3 rhs)
		{
			return new bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);
		}

		// Token: 0x06001167 RID: 4455 RVA: 0x000328A4 File Offset: 0x00030AA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <=(float3 lhs, float3 rhs)
		{
			return new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
		}

		// Token: 0x06001168 RID: 4456 RVA: 0x000328DE File Offset: 0x00030ADE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <=(float3 lhs, float rhs)
		{
			return new bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);
		}

		// Token: 0x06001169 RID: 4457 RVA: 0x00032909 File Offset: 0x00030B09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <=(float lhs, float3 rhs)
		{
			return new bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);
		}

		// Token: 0x0600116A RID: 4458 RVA: 0x00032934 File Offset: 0x00030B34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >(float3 lhs, float3 rhs)
		{
			return new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
		}

		// Token: 0x0600116B RID: 4459 RVA: 0x00032965 File Offset: 0x00030B65
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >(float3 lhs, float rhs)
		{
			return new bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x00032987 File Offset: 0x00030B87
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >(float lhs, float3 rhs)
		{
			return new bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);
		}

		// Token: 0x0600116D RID: 4461 RVA: 0x000329A9 File Offset: 0x00030BA9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >=(float3 lhs, float3 rhs)
		{
			return new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
		}

		// Token: 0x0600116E RID: 4462 RVA: 0x000329E3 File Offset: 0x00030BE3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >=(float3 lhs, float rhs)
		{
			return new bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);
		}

		// Token: 0x0600116F RID: 4463 RVA: 0x00032A0E File Offset: 0x00030C0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >=(float lhs, float3 rhs)
		{
			return new bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);
		}

		// Token: 0x06001170 RID: 4464 RVA: 0x00032A39 File Offset: 0x00030C39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator -(float3 val)
		{
			return new float3(-val.x, -val.y, -val.z);
		}

		// Token: 0x06001171 RID: 4465 RVA: 0x00032A55 File Offset: 0x00030C55
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 operator +(float3 val)
		{
			return new float3(val.x, val.y, val.z);
		}

		// Token: 0x06001172 RID: 4466 RVA: 0x00032A6E File Offset: 0x00030C6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(float3 lhs, float3 rhs)
		{
			return new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
		}

		// Token: 0x06001173 RID: 4467 RVA: 0x00032A9F File Offset: 0x00030C9F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(float3 lhs, float rhs)
		{
			return new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);
		}

		// Token: 0x06001174 RID: 4468 RVA: 0x00032AC1 File Offset: 0x00030CC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(float lhs, float3 rhs)
		{
			return new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x00032AE3 File Offset: 0x00030CE3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(float3 lhs, float3 rhs)
		{
			return new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x00032B1D File Offset: 0x00030D1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(float3 lhs, float rhs)
		{
			return new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);
		}

		// Token: 0x06001177 RID: 4471 RVA: 0x00032B48 File Offset: 0x00030D48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(float lhs, float3 rhs)
		{
			return new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06001178 RID: 4472 RVA: 0x00032B73 File Offset: 0x00030D73
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06001179 RID: 4473 RVA: 0x00032B92 File Offset: 0x00030D92
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x0600117A RID: 4474 RVA: 0x00032BB1 File Offset: 0x00030DB1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.x, this.z);
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x0600117B RID: 4475 RVA: 0x00032BD0 File Offset: 0x00030DD0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x0600117C RID: 4476 RVA: 0x00032BEF File Offset: 0x00030DEF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x0600117D RID: 4477 RVA: 0x00032C0E File Offset: 0x00030E0E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.y, this.z);
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x0600117E RID: 4478 RVA: 0x00032C2D File Offset: 0x00030E2D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x0600117F RID: 4479 RVA: 0x00032C4C File Offset: 0x00030E4C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06001180 RID: 4480 RVA: 0x00032C6B File Offset: 0x00030E6B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06001181 RID: 4481 RVA: 0x00032C8A File Offset: 0x00030E8A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06001182 RID: 4482 RVA: 0x00032CA9 File Offset: 0x00030EA9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06001183 RID: 4483 RVA: 0x00032CC8 File Offset: 0x00030EC8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06001184 RID: 4484 RVA: 0x00032CE7 File Offset: 0x00030EE7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06001185 RID: 4485 RVA: 0x00032D06 File Offset: 0x00030F06
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06001186 RID: 4486 RVA: 0x00032D25 File Offset: 0x00030F25
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.y, this.z);
			}
		}

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06001187 RID: 4487 RVA: 0x00032D44 File Offset: 0x00030F44
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.z, this.x);
			}
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06001188 RID: 4488 RVA: 0x00032D63 File Offset: 0x00030F63
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.z, this.y);
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06001189 RID: 4489 RVA: 0x00032D82 File Offset: 0x00030F82
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.y, this.z, this.z);
			}
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x0600118A RID: 4490 RVA: 0x00032DA1 File Offset: 0x00030FA1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.x, this.x);
			}
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x0600118B RID: 4491 RVA: 0x00032DC0 File Offset: 0x00030FC0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.x, this.y);
			}
		}

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x0600118C RID: 4492 RVA: 0x00032DDF File Offset: 0x00030FDF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x0600118D RID: 4493 RVA: 0x00032DFE File Offset: 0x00030FFE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x0600118E RID: 4494 RVA: 0x00032E1D File Offset: 0x0003101D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x0600118F RID: 4495 RVA: 0x00032E3C File Offset: 0x0003103C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06001190 RID: 4496 RVA: 0x00032E5B File Offset: 0x0003105B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06001191 RID: 4497 RVA: 0x00032E7A File Offset: 0x0003107A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06001192 RID: 4498 RVA: 0x00032E99 File Offset: 0x00031099
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.x, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06001193 RID: 4499 RVA: 0x00032EB8 File Offset: 0x000310B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06001194 RID: 4500 RVA: 0x00032ED7 File Offset: 0x000310D7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06001195 RID: 4501 RVA: 0x00032EF6 File Offset: 0x000310F6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06001196 RID: 4502 RVA: 0x00032F15 File Offset: 0x00031115
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06001197 RID: 4503 RVA: 0x00032F34 File Offset: 0x00031134
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06001198 RID: 4504 RVA: 0x00032F53 File Offset: 0x00031153
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.y, this.z);
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06001199 RID: 4505 RVA: 0x00032F72 File Offset: 0x00031172
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.z, this.x);
			}
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x0600119A RID: 4506 RVA: 0x00032F91 File Offset: 0x00031191
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.z, this.y);
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x0600119B RID: 4507 RVA: 0x00032FB0 File Offset: 0x000311B0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.x, this.z, this.z);
			}
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x0600119C RID: 4508 RVA: 0x00032FCF File Offset: 0x000311CF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x0600119D RID: 4509 RVA: 0x00032FEE File Offset: 0x000311EE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x0600119E RID: 4510 RVA: 0x0003300D File Offset: 0x0003120D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x0600119F RID: 4511 RVA: 0x0003302C File Offset: 0x0003122C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x060011A0 RID: 4512 RVA: 0x0003304B File Offset: 0x0003124B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x060011A1 RID: 4513 RVA: 0x0003306A File Offset: 0x0003126A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x060011A2 RID: 4514 RVA: 0x00033089 File Offset: 0x00031289
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x060011A3 RID: 4515 RVA: 0x000330A8 File Offset: 0x000312A8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x060011A4 RID: 4516 RVA: 0x000330C7 File Offset: 0x000312C7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x060011A5 RID: 4517 RVA: 0x000330E6 File Offset: 0x000312E6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x060011A6 RID: 4518 RVA: 0x00033105 File Offset: 0x00031305
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.x, this.y);
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x060011A7 RID: 4519 RVA: 0x00033124 File Offset: 0x00031324
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.x, this.z);
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x060011A8 RID: 4520 RVA: 0x00033143 File Offset: 0x00031343
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.y, this.x);
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x060011A9 RID: 4521 RVA: 0x00033162 File Offset: 0x00031362
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.y, this.y);
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x060011AA RID: 4522 RVA: 0x00033181 File Offset: 0x00031381
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.y, this.z);
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x060011AB RID: 4523 RVA: 0x000331A0 File Offset: 0x000313A0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.z, this.x);
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x060011AC RID: 4524 RVA: 0x000331BF File Offset: 0x000313BF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x060011AD RID: 4525 RVA: 0x000331DE File Offset: 0x000313DE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.y, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x060011AE RID: 4526 RVA: 0x000331FD File Offset: 0x000313FD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x060011AF RID: 4527 RVA: 0x0003321C File Offset: 0x0003141C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x060011B0 RID: 4528 RVA: 0x0003323B File Offset: 0x0003143B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x060011B1 RID: 4529 RVA: 0x0003325A File Offset: 0x0003145A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x060011B2 RID: 4530 RVA: 0x00033279 File Offset: 0x00031479
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x060011B3 RID: 4531 RVA: 0x00033298 File Offset: 0x00031498
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.y, this.z);
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x060011B4 RID: 4532 RVA: 0x000332B7 File Offset: 0x000314B7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x060011B5 RID: 4533 RVA: 0x000332D6 File Offset: 0x000314D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x060011B6 RID: 4534 RVA: 0x000332F5 File Offset: 0x000314F5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.x, this.z, this.z);
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x060011B7 RID: 4535 RVA: 0x00033314 File Offset: 0x00031514
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.x, this.x);
			}
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x060011B8 RID: 4536 RVA: 0x00033333 File Offset: 0x00031533
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.x, this.y);
			}
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x060011B9 RID: 4537 RVA: 0x00033352 File Offset: 0x00031552
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.x, this.z);
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x060011BA RID: 4538 RVA: 0x00033371 File Offset: 0x00031571
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.y, this.x);
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x060011BB RID: 4539 RVA: 0x00033390 File Offset: 0x00031590
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x060011BC RID: 4540 RVA: 0x000333AF File Offset: 0x000315AF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x060011BD RID: 4541 RVA: 0x000333CE File Offset: 0x000315CE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x060011BE RID: 4542 RVA: 0x000333ED File Offset: 0x000315ED
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x060011BF RID: 4543 RVA: 0x0003340C File Offset: 0x0003160C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x060011C0 RID: 4544 RVA: 0x0003342B File Offset: 0x0003162B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x060011C1 RID: 4545 RVA: 0x0003344A File Offset: 0x0003164A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x060011C2 RID: 4546 RVA: 0x00033469 File Offset: 0x00031669
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x060011C3 RID: 4547 RVA: 0x00033488 File Offset: 0x00031688
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x060011C4 RID: 4548 RVA: 0x000334A7 File Offset: 0x000316A7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x060011C5 RID: 4549 RVA: 0x000334C6 File Offset: 0x000316C6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x060011C6 RID: 4550 RVA: 0x000334E5 File Offset: 0x000316E5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.z, this.x);
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x060011C7 RID: 4551 RVA: 0x00033504 File Offset: 0x00031704
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.z, this.y);
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x060011C8 RID: 4552 RVA: 0x00033523 File Offset: 0x00031723
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float4(this.z, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x060011C9 RID: 4553 RVA: 0x00033542 File Offset: 0x00031742
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.x, this.x);
			}
		}

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x060011CA RID: 4554 RVA: 0x0003355B File Offset: 0x0003175B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.x, this.y);
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x060011CB RID: 4555 RVA: 0x00033574 File Offset: 0x00031774
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.x, this.z);
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x060011CC RID: 4556 RVA: 0x0003358D File Offset: 0x0003178D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.y, this.x);
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x060011CD RID: 4557 RVA: 0x000335A6 File Offset: 0x000317A6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.y, this.y);
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x060011CE RID: 4558 RVA: 0x000335BF File Offset: 0x000317BF
		// (set) Token: 0x060011CF RID: 4559 RVA: 0x000335D8 File Offset: 0x000317D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x060011D0 RID: 4560 RVA: 0x000335FE File Offset: 0x000317FE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.z, this.x);
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x060011D1 RID: 4561 RVA: 0x00033617 File Offset: 0x00031817
		// (set) Token: 0x060011D2 RID: 4562 RVA: 0x00033630 File Offset: 0x00031830
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x060011D3 RID: 4563 RVA: 0x00033656 File Offset: 0x00031856
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.x, this.z, this.z);
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x060011D4 RID: 4564 RVA: 0x0003366F File Offset: 0x0003186F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.x, this.x);
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x060011D5 RID: 4565 RVA: 0x00033688 File Offset: 0x00031888
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.x, this.y);
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x060011D6 RID: 4566 RVA: 0x000336A1 File Offset: 0x000318A1
		// (set) Token: 0x060011D7 RID: 4567 RVA: 0x000336BA File Offset: 0x000318BA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x060011D8 RID: 4568 RVA: 0x000336E0 File Offset: 0x000318E0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.y, this.x);
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x060011D9 RID: 4569 RVA: 0x000336F9 File Offset: 0x000318F9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.y, this.y);
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x060011DA RID: 4570 RVA: 0x00033712 File Offset: 0x00031912
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.y, this.z);
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x060011DB RID: 4571 RVA: 0x0003372B File Offset: 0x0003192B
		// (set) Token: 0x060011DC RID: 4572 RVA: 0x00033744 File Offset: 0x00031944
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x060011DD RID: 4573 RVA: 0x0003376A File Offset: 0x0003196A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.z, this.y);
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x060011DE RID: 4574 RVA: 0x00033783 File Offset: 0x00031983
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.y, this.z, this.z);
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x060011DF RID: 4575 RVA: 0x0003379C File Offset: 0x0003199C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.x, this.x);
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x060011E0 RID: 4576 RVA: 0x000337B5 File Offset: 0x000319B5
		// (set) Token: 0x060011E1 RID: 4577 RVA: 0x000337CE File Offset: 0x000319CE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x060011E2 RID: 4578 RVA: 0x000337F4 File Offset: 0x000319F4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.x, this.z);
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x060011E3 RID: 4579 RVA: 0x0003380D File Offset: 0x00031A0D
		// (set) Token: 0x060011E4 RID: 4580 RVA: 0x00033826 File Offset: 0x00031A26
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x060011E5 RID: 4581 RVA: 0x0003384C File Offset: 0x00031A4C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.y, this.y);
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x060011E6 RID: 4582 RVA: 0x00033865 File Offset: 0x00031A65
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.y, this.z);
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x060011E7 RID: 4583 RVA: 0x0003387E File Offset: 0x00031A7E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.z, this.x);
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x060011E8 RID: 4584 RVA: 0x00033897 File Offset: 0x00031A97
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.z, this.y);
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x060011E9 RID: 4585 RVA: 0x000338B0 File Offset: 0x00031AB0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float3(this.z, this.z, this.z);
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x060011EA RID: 4586 RVA: 0x000338C9 File Offset: 0x00031AC9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.x, this.x);
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x060011EB RID: 4587 RVA: 0x000338DC File Offset: 0x00031ADC
		// (set) Token: 0x060011EC RID: 4588 RVA: 0x000338EF File Offset: 0x00031AEF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x060011ED RID: 4589 RVA: 0x00033909 File Offset: 0x00031B09
		// (set) Token: 0x060011EE RID: 4590 RVA: 0x0003391C File Offset: 0x00031B1C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 xz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x060011EF RID: 4591 RVA: 0x00033936 File Offset: 0x00031B36
		// (set) Token: 0x060011F0 RID: 4592 RVA: 0x00033949 File Offset: 0x00031B49
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x060011F1 RID: 4593 RVA: 0x00033963 File Offset: 0x00031B63
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.y, this.y);
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x060011F2 RID: 4594 RVA: 0x00033976 File Offset: 0x00031B76
		// (set) Token: 0x060011F3 RID: 4595 RVA: 0x00033989 File Offset: 0x00031B89
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 yz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x060011F4 RID: 4596 RVA: 0x000339A3 File Offset: 0x00031BA3
		// (set) Token: 0x060011F5 RID: 4597 RVA: 0x000339B6 File Offset: 0x00031BB6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 zx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x060011F6 RID: 4598 RVA: 0x000339D0 File Offset: 0x00031BD0
		// (set) Token: 0x060011F7 RID: 4599 RVA: 0x000339E3 File Offset: 0x00031BE3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 zy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x060011F8 RID: 4600 RVA: 0x000339FD File Offset: 0x00031BFD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new float2(this.z, this.z);
			}
		}

		// Token: 0x17000470 RID: 1136
		public unsafe float this[int index]
		{
			get
			{
				fixed (float3* ptr = &this)
				{
					return ((float*)ptr)[index];
				}
			}
			set
			{
				fixed (float* ptr = &this.x)
				{
					ptr[index] = value;
				}
			}
		}

		// Token: 0x060011FB RID: 4603 RVA: 0x00033A48 File Offset: 0x00031C48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float3 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y && this.z == rhs.z;
		}

		// Token: 0x060011FC RID: 4604 RVA: 0x00033A78 File Offset: 0x00031C78
		public override bool Equals(object o)
		{
			if (o is float3)
			{
				float3 rhs = (float3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060011FD RID: 4605 RVA: 0x00033A9D File Offset: 0x00031C9D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060011FE RID: 4606 RVA: 0x00033AAA File Offset: 0x00031CAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float3({0}f, {1}f, {2}f)", this.x, this.y, this.z);
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x00033AD7 File Offset: 0x00031CD7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float3({0}f, {1}f, {2}f)", this.x.ToString(format, formatProvider), this.y.ToString(format, formatProvider), this.z.ToString(format, formatProvider));
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x00033B0A File Offset: 0x00031D0A
		public static implicit operator Vector3(float3 v)
		{
			return new Vector3(v.x, v.y, v.z);
		}

		// Token: 0x06001201 RID: 4609 RVA: 0x00033B23 File Offset: 0x00031D23
		public static implicit operator float3(Vector3 v)
		{
			return new float3(v.x, v.y, v.z);
		}

		// Token: 0x0400007E RID: 126
		public float x;

		// Token: 0x0400007F RID: 127
		public float y;

		// Token: 0x04000080 RID: 128
		public float z;

		// Token: 0x04000081 RID: 129
		public static readonly float3 zero;

		// Token: 0x0200005B RID: 91
		internal sealed class DebuggerProxy
		{
			// Token: 0x06002470 RID: 9328 RVA: 0x00067620 File Offset: 0x00065820
			public DebuggerProxy(float3 v)
			{
				this.x = v.x;
				this.y = v.y;
				this.z = v.z;
			}

			// Token: 0x0400014E RID: 334
			public float x;

			// Token: 0x0400014F RID: 335
			public float y;

			// Token: 0x04000150 RID: 336
			public float z;
		}
	}
}
