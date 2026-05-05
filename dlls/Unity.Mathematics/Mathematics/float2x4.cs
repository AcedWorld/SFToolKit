using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000020 RID: 32
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float2x4 : IEquatable<float2x4>, IFormattable
	{
		// Token: 0x060010FA RID: 4346 RVA: 0x0003132F File Offset: 0x0002F52F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(float2 c0, float2 c1, float2 c2, float2 c3)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
			this.c3 = c3;
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x0003134E File Offset: 0x0002F54E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13)
		{
			this.c0 = new float2(m00, m10);
			this.c1 = new float2(m01, m11);
			this.c2 = new float2(m02, m12);
			this.c3 = new float2(m03, m13);
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x00031389 File Offset: 0x0002F589
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(float v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x060010FD RID: 4349 RVA: 0x000313BC File Offset: 0x0002F5BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(bool v)
		{
			this.c0 = math.select(new float2(0f), new float2(1f), v);
			this.c1 = math.select(new float2(0f), new float2(1f), v);
			this.c2 = math.select(new float2(0f), new float2(1f), v);
			this.c3 = math.select(new float2(0f), new float2(1f), v);
		}

		// Token: 0x060010FE RID: 4350 RVA: 0x0003144C File Offset: 0x0002F64C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(bool2x4 v)
		{
			this.c0 = math.select(new float2(0f), new float2(1f), v.c0);
			this.c1 = math.select(new float2(0f), new float2(1f), v.c1);
			this.c2 = math.select(new float2(0f), new float2(1f), v.c2);
			this.c3 = math.select(new float2(0f), new float2(1f), v.c3);
		}

		// Token: 0x060010FF RID: 4351 RVA: 0x000314ED File Offset: 0x0002F6ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x00031520 File Offset: 0x0002F720
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(int2x4 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
			this.c3 = v.c3;
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x00031571 File Offset: 0x0002F771
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x000315A4 File Offset: 0x0002F7A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(uint2x4 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
			this.c3 = v.c3;
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x000315F5 File Offset: 0x0002F7F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(double v)
		{
			this.c0 = (float2)v;
			this.c1 = (float2)v;
			this.c2 = (float2)v;
			this.c3 = (float2)v;
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x00031628 File Offset: 0x0002F828
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float2x4(double2x4 v)
		{
			this.c0 = (float2)v.c0;
			this.c1 = (float2)v.c1;
			this.c2 = (float2)v.c2;
			this.c3 = (float2)v.c3;
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x00031679 File Offset: 0x0002F879
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2x4(float v)
		{
			return new float2x4(v);
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x00031681 File Offset: 0x0002F881
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2x4(bool v)
		{
			return new float2x4(v);
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x00031689 File Offset: 0x0002F889
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2x4(bool2x4 v)
		{
			return new float2x4(v);
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x00031691 File Offset: 0x0002F891
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2x4(int v)
		{
			return new float2x4(v);
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x00031699 File Offset: 0x0002F899
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2x4(int2x4 v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x000316A1 File Offset: 0x0002F8A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2x4(uint v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x000316A9 File Offset: 0x0002F8A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2x4(uint2x4 v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x000316B1 File Offset: 0x0002F8B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2x4(double v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x000316B9 File Offset: 0x0002F8B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float2x4(double2x4 v)
		{
			return new float2x4(v);
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x000316C4 File Offset: 0x0002F8C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator *(float2x4 lhs, float2x4 rhs)
		{
			return new float2x4(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3);
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x0003171A File Offset: 0x0002F91A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator *(float2x4 lhs, float rhs)
		{
			return new float2x4(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs, lhs.c3 * rhs);
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x00031751 File Offset: 0x0002F951
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator *(float lhs, float2x4 rhs)
		{
			return new float2x4(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3);
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x00031788 File Offset: 0x0002F988
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator +(float2x4 lhs, float2x4 rhs)
		{
			return new float2x4(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3);
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x000317DE File Offset: 0x0002F9DE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator +(float2x4 lhs, float rhs)
		{
			return new float2x4(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs, lhs.c3 + rhs);
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x00031815 File Offset: 0x0002FA15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator +(float lhs, float2x4 rhs)
		{
			return new float2x4(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2, lhs + rhs.c3);
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x0003184C File Offset: 0x0002FA4C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator -(float2x4 lhs, float2x4 rhs)
		{
			return new float2x4(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3);
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x000318A2 File Offset: 0x0002FAA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator -(float2x4 lhs, float rhs)
		{
			return new float2x4(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs, lhs.c3 - rhs);
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x000318D9 File Offset: 0x0002FAD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator -(float lhs, float2x4 rhs)
		{
			return new float2x4(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2, lhs - rhs.c3);
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x00031910 File Offset: 0x0002FB10
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator /(float2x4 lhs, float2x4 rhs)
		{
			return new float2x4(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3);
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x00031966 File Offset: 0x0002FB66
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator /(float2x4 lhs, float rhs)
		{
			return new float2x4(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs);
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x0003199D File Offset: 0x0002FB9D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator /(float lhs, float2x4 rhs)
		{
			return new float2x4(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2, lhs / rhs.c3);
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x000319D4 File Offset: 0x0002FBD4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator %(float2x4 lhs, float2x4 rhs)
		{
			return new float2x4(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3);
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x00031A2A File Offset: 0x0002FC2A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator %(float2x4 lhs, float rhs)
		{
			return new float2x4(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs);
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x00031A61 File Offset: 0x0002FC61
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator %(float lhs, float2x4 rhs)
		{
			return new float2x4(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2, lhs % rhs.c3);
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x00031A98 File Offset: 0x0002FC98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator ++(float2x4 val)
		{
			float2 @float = ++val.c0;
			val.c0 = @float;
			float2 float2 = @float;
			@float = ++val.c1;
			val.c1 = @float;
			float2 float3 = @float;
			@float = ++val.c2;
			val.c2 = @float;
			float2 float4 = @float;
			@float = ++val.c3;
			val.c3 = @float;
			return new float2x4(float2, float3, float4, @float);
		}

		// Token: 0x0600111E RID: 4382 RVA: 0x00031B14 File Offset: 0x0002FD14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator --(float2x4 val)
		{
			float2 @float = --val.c0;
			val.c0 = @float;
			float2 float2 = @float;
			@float = --val.c1;
			val.c1 = @float;
			float2 float3 = @float;
			@float = --val.c2;
			val.c2 = @float;
			float2 float4 = @float;
			@float = --val.c3;
			val.c3 = @float;
			return new float2x4(float2, float3, float4, @float);
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x00031B90 File Offset: 0x0002FD90
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <(float2x4 lhs, float2x4 rhs)
		{
			return new bool2x4(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3);
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x00031BE6 File Offset: 0x0002FDE6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <(float2x4 lhs, float rhs)
		{
			return new bool2x4(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs, lhs.c3 < rhs);
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x00031C1D File Offset: 0x0002FE1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <(float lhs, float2x4 rhs)
		{
			return new bool2x4(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2, lhs < rhs.c3);
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x00031C54 File Offset: 0x0002FE54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <=(float2x4 lhs, float2x4 rhs)
		{
			return new bool2x4(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3);
		}

		// Token: 0x06001123 RID: 4387 RVA: 0x00031CAA File Offset: 0x0002FEAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <=(float2x4 lhs, float rhs)
		{
			return new bool2x4(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs, lhs.c3 <= rhs);
		}

		// Token: 0x06001124 RID: 4388 RVA: 0x00031CE1 File Offset: 0x0002FEE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <=(float lhs, float2x4 rhs)
		{
			return new bool2x4(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2, lhs <= rhs.c3);
		}

		// Token: 0x06001125 RID: 4389 RVA: 0x00031D18 File Offset: 0x0002FF18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >(float2x4 lhs, float2x4 rhs)
		{
			return new bool2x4(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3);
		}

		// Token: 0x06001126 RID: 4390 RVA: 0x00031D6E File Offset: 0x0002FF6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >(float2x4 lhs, float rhs)
		{
			return new bool2x4(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs, lhs.c3 > rhs);
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x00031DA5 File Offset: 0x0002FFA5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >(float lhs, float2x4 rhs)
		{
			return new bool2x4(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2, lhs > rhs.c3);
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x00031DDC File Offset: 0x0002FFDC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >=(float2x4 lhs, float2x4 rhs)
		{
			return new bool2x4(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3);
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x00031E32 File Offset: 0x00030032
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >=(float2x4 lhs, float rhs)
		{
			return new bool2x4(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs, lhs.c3 >= rhs);
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x00031E69 File Offset: 0x00030069
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >=(float lhs, float2x4 rhs)
		{
			return new bool2x4(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2, lhs >= rhs.c3);
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x00031EA0 File Offset: 0x000300A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator -(float2x4 val)
		{
			return new float2x4(-val.c0, -val.c1, -val.c2, -val.c3);
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x00031ED3 File Offset: 0x000300D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2x4 operator +(float2x4 val)
		{
			return new float2x4(+val.c0, +val.c1, +val.c2, +val.c3);
		}

		// Token: 0x0600112D RID: 4397 RVA: 0x00031F08 File Offset: 0x00030108
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(float2x4 lhs, float2x4 rhs)
		{
			return new bool2x4(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);
		}

		// Token: 0x0600112E RID: 4398 RVA: 0x00031F5E File Offset: 0x0003015E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(float2x4 lhs, float rhs)
		{
			return new bool2x4(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs);
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x00031F95 File Offset: 0x00030195
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(float lhs, float2x4 rhs)
		{
			return new bool2x4(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3);
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x00031FCC File Offset: 0x000301CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(float2x4 lhs, float2x4 rhs)
		{
			return new bool2x4(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);
		}

		// Token: 0x06001131 RID: 4401 RVA: 0x00032022 File Offset: 0x00030222
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(float2x4 lhs, float rhs)
		{
			return new bool2x4(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs);
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x00032059 File Offset: 0x00030259
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(float lhs, float2x4 rhs)
		{
			return new bool2x4(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3);
		}

		// Token: 0x170003FA RID: 1018
		public unsafe float2 this[int index]
		{
			get
			{
				fixed (float2x4* ptr = &this)
				{
					return ref *(float2*)(ptr + (IntPtr)index * (IntPtr)sizeof(float2) / (IntPtr)sizeof(float2x4));
				}
			}
		}

		// Token: 0x06001134 RID: 4404 RVA: 0x000320AC File Offset: 0x000302AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float2x4 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2) && this.c3.Equals(rhs.c3);
		}

		// Token: 0x06001135 RID: 4405 RVA: 0x00032108 File Offset: 0x00030308
		public override bool Equals(object o)
		{
			if (o is float2x4)
			{
				float2x4 rhs = (float2x4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x0003212D File Offset: 0x0003032D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x0003213C File Offset: 0x0003033C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float2x4({0}f, {1}f, {2}f, {3}f,  {4}f, {5}f, {6}f, {7}f)", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c3.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c3.y
			});
		}

		// Token: 0x06001138 RID: 4408 RVA: 0x000321F4 File Offset: 0x000303F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float2x4({0}f, {1}f, {2}f, {3}f,  {4}f, {5}f, {6}f, {7}f)", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c3.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider),
				this.c3.y.ToString(format, formatProvider)
			});
		}

		// Token: 0x04000079 RID: 121
		public float2 c0;

		// Token: 0x0400007A RID: 122
		public float2 c1;

		// Token: 0x0400007B RID: 123
		public float2 c2;

		// Token: 0x0400007C RID: 124
		public float2 c3;

		// Token: 0x0400007D RID: 125
		public static readonly float2x4 zero;
	}
}
