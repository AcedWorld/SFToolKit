using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000026 RID: 38
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct float4x2 : IEquatable<float4x2>, IFormattable
	{
		// Token: 0x060014B2 RID: 5298 RVA: 0x0003A957 File Offset: 0x00038B57
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(float4 c0, float4 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x0003A967 File Offset: 0x00038B67
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(float m00, float m01, float m10, float m11, float m20, float m21, float m30, float m31)
		{
			this.c0 = new float4(m00, m10, m20, m30);
			this.c1 = new float4(m01, m11, m21, m31);
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x0003A98C File Offset: 0x00038B8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(float v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x060014B5 RID: 5301 RVA: 0x0003A9A8 File Offset: 0x00038BA8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(bool v)
		{
			this.c0 = math.select(new float4(0f), new float4(1f), v);
			this.c1 = math.select(new float4(0f), new float4(1f), v);
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x0003A9F8 File Offset: 0x00038BF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(bool4x2 v)
		{
			this.c0 = math.select(new float4(0f), new float4(1f), v.c0);
			this.c1 = math.select(new float4(0f), new float4(1f), v.c1);
		}

		// Token: 0x060014B7 RID: 5303 RVA: 0x0003AA4F File Offset: 0x00038C4F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(int v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x0003AA69 File Offset: 0x00038C69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(int4x2 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x0003AA8D File Offset: 0x00038C8D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(uint v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x0003AAA7 File Offset: 0x00038CA7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(uint4x2 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x0003AACB File Offset: 0x00038CCB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(double v)
		{
			this.c0 = (float4)v;
			this.c1 = (float4)v;
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x0003AAE5 File Offset: 0x00038CE5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float4x2(double4x2 v)
		{
			this.c0 = (float4)v.c0;
			this.c1 = (float4)v.c1;
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x0003AB09 File Offset: 0x00038D09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x2(float v)
		{
			return new float4x2(v);
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x0003AB11 File Offset: 0x00038D11
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x2(bool v)
		{
			return new float4x2(v);
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x0003AB19 File Offset: 0x00038D19
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x2(bool4x2 v)
		{
			return new float4x2(v);
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x0003AB21 File Offset: 0x00038D21
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x2(int v)
		{
			return new float4x2(v);
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x0003AB29 File Offset: 0x00038D29
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x2(int4x2 v)
		{
			return new float4x2(v);
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x0003AB31 File Offset: 0x00038D31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x2(uint v)
		{
			return new float4x2(v);
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x0003AB39 File Offset: 0x00038D39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4x2(uint4x2 v)
		{
			return new float4x2(v);
		}

		// Token: 0x060014C4 RID: 5316 RVA: 0x0003AB41 File Offset: 0x00038D41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x2(double v)
		{
			return new float4x2(v);
		}

		// Token: 0x060014C5 RID: 5317 RVA: 0x0003AB49 File Offset: 0x00038D49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float4x2(double4x2 v)
		{
			return new float4x2(v);
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x0003AB51 File Offset: 0x00038D51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator *(float4x2 lhs, float4x2 rhs)
		{
			return new float4x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x0003AB7A File Offset: 0x00038D7A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator *(float4x2 lhs, float rhs)
		{
			return new float4x2(lhs.c0 * rhs, lhs.c1 * rhs);
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x0003AB99 File Offset: 0x00038D99
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator *(float lhs, float4x2 rhs)
		{
			return new float4x2(lhs * rhs.c0, lhs * rhs.c1);
		}

		// Token: 0x060014C9 RID: 5321 RVA: 0x0003ABB8 File Offset: 0x00038DB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator +(float4x2 lhs, float4x2 rhs)
		{
			return new float4x2(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x0003ABE1 File Offset: 0x00038DE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator +(float4x2 lhs, float rhs)
		{
			return new float4x2(lhs.c0 + rhs, lhs.c1 + rhs);
		}

		// Token: 0x060014CB RID: 5323 RVA: 0x0003AC00 File Offset: 0x00038E00
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator +(float lhs, float4x2 rhs)
		{
			return new float4x2(lhs + rhs.c0, lhs + rhs.c1);
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x0003AC1F File Offset: 0x00038E1F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator -(float4x2 lhs, float4x2 rhs)
		{
			return new float4x2(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x0003AC48 File Offset: 0x00038E48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator -(float4x2 lhs, float rhs)
		{
			return new float4x2(lhs.c0 - rhs, lhs.c1 - rhs);
		}

		// Token: 0x060014CE RID: 5326 RVA: 0x0003AC67 File Offset: 0x00038E67
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator -(float lhs, float4x2 rhs)
		{
			return new float4x2(lhs - rhs.c0, lhs - rhs.c1);
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x0003AC86 File Offset: 0x00038E86
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator /(float4x2 lhs, float4x2 rhs)
		{
			return new float4x2(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x0003ACAF File Offset: 0x00038EAF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator /(float4x2 lhs, float rhs)
		{
			return new float4x2(lhs.c0 / rhs, lhs.c1 / rhs);
		}

		// Token: 0x060014D1 RID: 5329 RVA: 0x0003ACCE File Offset: 0x00038ECE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator /(float lhs, float4x2 rhs)
		{
			return new float4x2(lhs / rhs.c0, lhs / rhs.c1);
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x0003ACED File Offset: 0x00038EED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator %(float4x2 lhs, float4x2 rhs)
		{
			return new float4x2(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x0003AD16 File Offset: 0x00038F16
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator %(float4x2 lhs, float rhs)
		{
			return new float4x2(lhs.c0 % rhs, lhs.c1 % rhs);
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x0003AD35 File Offset: 0x00038F35
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator %(float lhs, float4x2 rhs)
		{
			return new float4x2(lhs % rhs.c0, lhs % rhs.c1);
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x0003AD54 File Offset: 0x00038F54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator ++(float4x2 val)
		{
			float4 @float = ++val.c0;
			val.c0 = @float;
			float4 float2 = @float;
			@float = ++val.c1;
			val.c1 = @float;
			return new float4x2(float2, @float);
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x0003AD9C File Offset: 0x00038F9C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator --(float4x2 val)
		{
			float4 @float = --val.c0;
			val.c0 = @float;
			float4 float2 = @float;
			@float = --val.c1;
			val.c1 = @float;
			return new float4x2(float2, @float);
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x0003ADE2 File Offset: 0x00038FE2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(float4x2 lhs, float4x2 rhs)
		{
			return new bool4x2(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x0003AE0B File Offset: 0x0003900B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(float4x2 lhs, float rhs)
		{
			return new bool4x2(lhs.c0 < rhs, lhs.c1 < rhs);
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x0003AE2A File Offset: 0x0003902A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(float lhs, float4x2 rhs)
		{
			return new bool4x2(lhs < rhs.c0, lhs < rhs.c1);
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x0003AE49 File Offset: 0x00039049
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(float4x2 lhs, float4x2 rhs)
		{
			return new bool4x2(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x0003AE72 File Offset: 0x00039072
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(float4x2 lhs, float rhs)
		{
			return new bool4x2(lhs.c0 <= rhs, lhs.c1 <= rhs);
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x0003AE91 File Offset: 0x00039091
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(float lhs, float4x2 rhs)
		{
			return new bool4x2(lhs <= rhs.c0, lhs <= rhs.c1);
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x0003AEB0 File Offset: 0x000390B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(float4x2 lhs, float4x2 rhs)
		{
			return new bool4x2(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x0003AED9 File Offset: 0x000390D9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(float4x2 lhs, float rhs)
		{
			return new bool4x2(lhs.c0 > rhs, lhs.c1 > rhs);
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x0003AEF8 File Offset: 0x000390F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(float lhs, float4x2 rhs)
		{
			return new bool4x2(lhs > rhs.c0, lhs > rhs.c1);
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x0003AF17 File Offset: 0x00039117
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(float4x2 lhs, float4x2 rhs)
		{
			return new bool4x2(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x0003AF40 File Offset: 0x00039140
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(float4x2 lhs, float rhs)
		{
			return new bool4x2(lhs.c0 >= rhs, lhs.c1 >= rhs);
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x0003AF5F File Offset: 0x0003915F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(float lhs, float4x2 rhs)
		{
			return new bool4x2(lhs >= rhs.c0, lhs >= rhs.c1);
		}

		// Token: 0x060014E3 RID: 5347 RVA: 0x0003AF7E File Offset: 0x0003917E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator -(float4x2 val)
		{
			return new float4x2(-val.c0, -val.c1);
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x0003AF9B File Offset: 0x0003919B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x2 operator +(float4x2 val)
		{
			return new float4x2(+val.c0, +val.c1);
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x0003AFB8 File Offset: 0x000391B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(float4x2 lhs, float4x2 rhs)
		{
			return new bool4x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x0003AFE1 File Offset: 0x000391E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(float4x2 lhs, float rhs)
		{
			return new bool4x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x0003B000 File Offset: 0x00039200
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(float lhs, float4x2 rhs)
		{
			return new bool4x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x0003B01F File Offset: 0x0003921F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(float4x2 lhs, float4x2 rhs)
		{
			return new bool4x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x0003B048 File Offset: 0x00039248
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(float4x2 lhs, float rhs)
		{
			return new bool4x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x0003B067 File Offset: 0x00039267
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(float lhs, float4x2 rhs)
		{
			return new bool4x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x170005C5 RID: 1477
		public unsafe float4 this[int index]
		{
			get
			{
				fixed (float4x2* ptr = &this)
				{
					return ref *(float4*)(ptr + (IntPtr)index * (IntPtr)sizeof(float4) / (IntPtr)sizeof(float4x2));
				}
			}
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x0003B0A3 File Offset: 0x000392A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(float4x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x0003B0CC File Offset: 0x000392CC
		public override bool Equals(object o)
		{
			if (o is float4x2)
			{
				float4x2 rhs = (float4x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060014EE RID: 5358 RVA: 0x0003B0F1 File Offset: 0x000392F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060014EF RID: 5359 RVA: 0x0003B100 File Offset: 0x00039300
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("float4x2({0}f, {1}f,  {2}f, {3}f,  {4}f, {5}f,  {6}f, {7}f)", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y,
				this.c0.z,
				this.c1.z,
				this.c0.w,
				this.c1.w
			});
		}

		// Token: 0x060014F0 RID: 5360 RVA: 0x0003B1B8 File Offset: 0x000393B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("float4x2({0}f, {1}f,  {2}f, {3}f,  {4}f, {5}f,  {6}f, {7}f)", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c0.w.ToString(format, formatProvider),
				this.c1.w.ToString(format, formatProvider)
			});
		}

		// Token: 0x04000094 RID: 148
		public float4 c0;

		// Token: 0x04000095 RID: 149
		public float4 c1;

		// Token: 0x04000096 RID: 150
		public static readonly float4x2 zero;
	}
}
