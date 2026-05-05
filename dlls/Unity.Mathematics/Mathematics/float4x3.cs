using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000027 RID: 39
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float4x3 : IEquatable<float4x3>, IFormattable
	{
		// Token: 0x060014F1 RID: 5361 RVA: 0x0003B27D File Offset: 0x0003947D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(float4 c0, float4 c1, float4 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x060014F2 RID: 5362 RVA: 0x0003B294 File Offset: 0x00039494
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22, float m30, float m31, float m32)
		{
			this.c0 = new float4(m00, m10, m20, m30);
			this.c1 = new float4(m01, m11, m21, m31);
			this.c2 = new float4(m02, m12, m22, m32);
		}

		// Token: 0x060014F3 RID: 5363 RVA: 0x0003B2CC File Offset: 0x000394CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(float v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x0003B2F4 File Offset: 0x000394F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(bool v)
		{
			this.c0 = math.select(new float4(0f), new float4(1f), v);
			this.c1 = math.select(new float4(0f), new float4(1f), v);
			this.c2 = math.select(new float4(0f), new float4(1f), v);
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x0003B364 File Offset: 0x00039564
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(bool4x3 v)
		{
			this.c0 = math.select(new float4(0f), new float4(1f), v.c0);
			this.c1 = math.select(new float4(0f), new float4(1f), v.c1);
			this.c2 = math.select(new float4(0f), new float4(1f), v.c2);
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x0003B3E0 File Offset: 0x000395E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x0003B406 File Offset: 0x00039606
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(int4x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x0003B43B File Offset: 0x0003963B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x0003B461 File Offset: 0x00039661
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(uint4x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x060014FA RID: 5370 RVA: 0x0003B496 File Offset: 0x00039696
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(double v)
		{
			this.c0 = (float4)v;
			this.c1 = (float4)v;
			this.c2 = (float4)v;
		}

		// Token: 0x060014FB RID: 5371 RVA: 0x0003B4BC File Offset: 0x000396BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x3(double4x3 v)
		{
			this.c0 = (float4)v.c0;
			this.c1 = (float4)v.c1;
			this.c2 = (float4)v.c2;
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x0003B4F1 File Offset: 0x000396F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x3(float v)
		{
			return new float4x3(v);
		}

		// Token: 0x060014FD RID: 5373 RVA: 0x0003B4F9 File Offset: 0x000396F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x3(bool v)
		{
			return new float4x3(v);
		}

		// Token: 0x060014FE RID: 5374 RVA: 0x0003B501 File Offset: 0x00039701
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x3(bool4x3 v)
		{
			return new float4x3(v);
		}

		// Token: 0x060014FF RID: 5375 RVA: 0x0003B509 File Offset: 0x00039709
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x3(int v)
		{
			return new float4x3(v);
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x0003B511 File Offset: 0x00039711
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x3(int4x3 v)
		{
			return new float4x3(v);
		}

		// Token: 0x06001501 RID: 5377 RVA: 0x0003B519 File Offset: 0x00039719
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x3(uint v)
		{
			return new float4x3(v);
		}

		// Token: 0x06001502 RID: 5378 RVA: 0x0003B521 File Offset: 0x00039721
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x3(uint4x3 v)
		{
			return new float4x3(v);
		}

		// Token: 0x06001503 RID: 5379 RVA: 0x0003B529 File Offset: 0x00039729
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x3(double v)
		{
			return new float4x3(v);
		}

		// Token: 0x06001504 RID: 5380 RVA: 0x0003B531 File Offset: 0x00039731
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x3(double4x3 v)
		{
			return new float4x3(v);
		}

		// Token: 0x06001505 RID: 5381 RVA: 0x0003B539 File Offset: 0x00039739
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator *(float4x3 lhs, float4x3 rhs)
		{
			return new float4x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x06001506 RID: 5382 RVA: 0x0003B573 File Offset: 0x00039773
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator *(float4x3 lhs, float rhs)
		{
			return new float4x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x06001507 RID: 5383 RVA: 0x0003B59E File Offset: 0x0003979E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator *(float lhs, float4x3 rhs)
		{
			return new float4x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x06001508 RID: 5384 RVA: 0x0003B5C9 File Offset: 0x000397C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator +(float4x3 lhs, float4x3 rhs)
		{
			return new float4x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x06001509 RID: 5385 RVA: 0x0003B603 File Offset: 0x00039803
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator +(float4x3 lhs, float rhs)
		{
			return new float4x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x0003B62E File Offset: 0x0003982E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator +(float lhs, float4x3 rhs)
		{
			return new float4x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x0600150B RID: 5387 RVA: 0x0003B659 File Offset: 0x00039859
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator -(float4x3 lhs, float4x3 rhs)
		{
			return new float4x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x0003B693 File Offset: 0x00039893
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator -(float4x3 lhs, float rhs)
		{
			return new float4x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x0600150D RID: 5389 RVA: 0x0003B6BE File Offset: 0x000398BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator -(float lhs, float4x3 rhs)
		{
			return new float4x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x0003B6E9 File Offset: 0x000398E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator /(float4x3 lhs, float4x3 rhs)
		{
			return new float4x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x0003B723 File Offset: 0x00039923
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator /(float4x3 lhs, float rhs)
		{
			return new float4x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x0003B74E File Offset: 0x0003994E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator /(float lhs, float4x3 rhs)
		{
			return new float4x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x06001511 RID: 5393 RVA: 0x0003B779 File Offset: 0x00039979
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator %(float4x3 lhs, float4x3 rhs)
		{
			return new float4x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x0003B7B3 File Offset: 0x000399B3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator %(float4x3 lhs, float rhs)
		{
			return new float4x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x0003B7DE File Offset: 0x000399DE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator %(float lhs, float4x3 rhs)
		{
			return new float4x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x0003B80C File Offset: 0x00039A0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator ++(float4x3 val)
		{
			float4 @float = ++val.c0;
			val.c0 = @float;
			float4 float2 = @float;
			@float = ++val.c1;
			val.c1 = @float;
			float4 float3 = @float;
			@float = ++val.c2;
			val.c2 = @float;
			return new float4x3(float2, float3, @float);
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x0003B86C File Offset: 0x00039A6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator --(float4x3 val)
		{
			float4 @float = --val.c0;
			val.c0 = @float;
			float4 float2 = @float;
			@float = --val.c1;
			val.c1 = @float;
			float4 float3 = @float;
			@float = --val.c2;
			val.c2 = @float;
			return new float4x3(float2, float3, @float);
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x0003B8CC File Offset: 0x00039ACC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(float4x3 lhs, float4x3 rhs)
		{
			return new bool4x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x0003B906 File Offset: 0x00039B06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(float4x3 lhs, float rhs)
		{
			return new bool4x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x0003B931 File Offset: 0x00039B31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(float lhs, float4x3 rhs)
		{
			return new bool4x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x0003B95C File Offset: 0x00039B5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(float4x3 lhs, float4x3 rhs)
		{
			return new bool4x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x0003B996 File Offset: 0x00039B96
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(float4x3 lhs, float rhs)
		{
			return new bool4x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x0003B9C1 File Offset: 0x00039BC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(float lhs, float4x3 rhs)
		{
			return new bool4x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x0003B9EC File Offset: 0x00039BEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(float4x3 lhs, float4x3 rhs)
		{
			return new bool4x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x0003BA26 File Offset: 0x00039C26
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(float4x3 lhs, float rhs)
		{
			return new bool4x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x0003BA51 File Offset: 0x00039C51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(float lhs, float4x3 rhs)
		{
			return new bool4x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x0003BA7C File Offset: 0x00039C7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(float4x3 lhs, float4x3 rhs)
		{
			return new bool4x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x0003BAB6 File Offset: 0x00039CB6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(float4x3 lhs, float rhs)
		{
			return new bool4x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x0003BAE1 File Offset: 0x00039CE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(float lhs, float4x3 rhs)
		{
			return new bool4x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x0003BB0C File Offset: 0x00039D0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator -(float4x3 val)
		{
			return new float4x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x0003BB34 File Offset: 0x00039D34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x3 operator +(float4x3 val)
		{
			return new float4x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x0003BB5C File Offset: 0x00039D5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(float4x3 lhs, float4x3 rhs)
		{
			return new bool4x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x0003BB96 File Offset: 0x00039D96
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(float4x3 lhs, float rhs)
		{
			return new bool4x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x0003BBC1 File Offset: 0x00039DC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(float lhs, float4x3 rhs)
		{
			return new bool4x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x0003BBEC File Offset: 0x00039DEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(float4x3 lhs, float4x3 rhs)
		{
			return new bool4x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x0003BC26 File Offset: 0x00039E26
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(float4x3 lhs, float rhs)
		{
			return new bool4x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x0003BC51 File Offset: 0x00039E51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(float lhs, float4x3 rhs)
		{
			return new bool4x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x170005C6 RID: 1478
		public unsafe float4 this[int index]
		{
			get
			{
				fixed (float4x3* ptr = &this)
				{
					return ref *(float4*)(ptr + (IntPtr)index * (IntPtr)sizeof(float4) / (IntPtr)sizeof(float4x3));
				}
			}
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x0003BC97 File Offset: 0x00039E97
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float4x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x0003BCD4 File Offset: 0x00039ED4
		public override bool Equals(object o)
		{
			if (o is float4x3)
			{
				float4x3 rhs = (float4x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x0003BCF9 File Offset: 0x00039EF9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x0600152E RID: 5422 RVA: 0x0003BD08 File Offset: 0x00039F08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float4x3({0}f, {1}f, {2}f,  {3}f, {4}f, {5}f,  {6}f, {7}f, {8}f,  {9}f, {10}f, {11}f)", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c0.z,
				this.c1.z,
				this.c2.z,
				this.c0.w,
				this.c1.w,
				this.c2.w
			});
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x0003BE10 File Offset: 0x0003A010
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float4x3({0}f, {1}f, {2}f,  {3}f, {4}f, {5}f,  {6}f, {7}f, {8}f,  {9}f, {10}f, {11}f)", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c2.z.ToString(format, formatProvider),
				this.c0.w.ToString(format, formatProvider),
				this.c1.w.ToString(format, formatProvider),
				this.c2.w.ToString(format, formatProvider)
			});
		}

		// Token: 0x04000097 RID: 151
		public float4 c0;

		// Token: 0x04000098 RID: 152
		public float4 c1;

		// Token: 0x04000099 RID: 153
		public float4 c2;

		// Token: 0x0400009A RID: 154
		public static readonly float4x3 zero;
	}
}
