using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000017 RID: 23
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct double3x3 : IEquatable<double3x3>, IFormattable
	{
		// Token: 0x06000D00 RID: 3328 RVA: 0x0002715B File Offset: 0x0002535B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(double3 c0, double3 c1, double3 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x00027172 File Offset: 0x00025372
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22)
		{
			this.c0 = new double3(m00, m10, m20);
			this.c1 = new double3(m01, m11, m21);
			this.c2 = new double3(m02, m12, m22);
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x000271A4 File Offset: 0x000253A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(double v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x000271CC File Offset: 0x000253CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(bool v)
		{
			this.c0 = math.select(new double3(0.0), new double3(1.0), v);
			this.c1 = math.select(new double3(0.0), new double3(1.0), v);
			this.c2 = math.select(new double3(0.0), new double3(1.0), v);
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x00027254 File Offset: 0x00025454
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(bool3x3 v)
		{
			this.c0 = math.select(new double3(0.0), new double3(1.0), v.c0);
			this.c1 = math.select(new double3(0.0), new double3(1.0), v.c1);
			this.c2 = math.select(new double3(0.0), new double3(1.0), v.c2);
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x000272E8 File Offset: 0x000254E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x0002730E File Offset: 0x0002550E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(int3x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x00027343 File Offset: 0x00025543
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x00027369 File Offset: 0x00025569
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(uint3x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x0002739E File Offset: 0x0002559E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(float v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x000273C4 File Offset: 0x000255C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x3(float3x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x000273F9 File Offset: 0x000255F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x3(double v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x00027401 File Offset: 0x00025601
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double3x3(bool v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x00027409 File Offset: 0x00025609
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double3x3(bool3x3 v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x00027411 File Offset: 0x00025611
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x3(int v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x00027419 File Offset: 0x00025619
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x3(int3x3 v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x00027421 File Offset: 0x00025621
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x3(uint v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x00027429 File Offset: 0x00025629
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x3(uint3x3 v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x00027431 File Offset: 0x00025631
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x3(float v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x00027439 File Offset: 0x00025639
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x3(float3x3 v)
		{
			return new double3x3(v);
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x00027441 File Offset: 0x00025641
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator *(double3x3 lhs, double3x3 rhs)
		{
			return new double3x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x0002747B File Offset: 0x0002567B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator *(double3x3 lhs, double rhs)
		{
			return new double3x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x000274A6 File Offset: 0x000256A6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator *(double lhs, double3x3 rhs)
		{
			return new double3x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x000274D1 File Offset: 0x000256D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator +(double3x3 lhs, double3x3 rhs)
		{
			return new double3x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x0002750B File Offset: 0x0002570B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator +(double3x3 lhs, double rhs)
		{
			return new double3x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x00027536 File Offset: 0x00025736
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator +(double lhs, double3x3 rhs)
		{
			return new double3x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x00027561 File Offset: 0x00025761
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator -(double3x3 lhs, double3x3 rhs)
		{
			return new double3x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x0002759B File Offset: 0x0002579B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator -(double3x3 lhs, double rhs)
		{
			return new double3x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x000275C6 File Offset: 0x000257C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator -(double lhs, double3x3 rhs)
		{
			return new double3x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x000275F1 File Offset: 0x000257F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator /(double3x3 lhs, double3x3 rhs)
		{
			return new double3x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x0002762B File Offset: 0x0002582B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator /(double3x3 lhs, double rhs)
		{
			return new double3x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x00027656 File Offset: 0x00025856
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator /(double lhs, double3x3 rhs)
		{
			return new double3x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x00027681 File Offset: 0x00025881
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator %(double3x3 lhs, double3x3 rhs)
		{
			return new double3x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x000276BB File Offset: 0x000258BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator %(double3x3 lhs, double rhs)
		{
			return new double3x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x000276E6 File Offset: 0x000258E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator %(double lhs, double3x3 rhs)
		{
			return new double3x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x00027714 File Offset: 0x00025914
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator ++(double3x3 val)
		{
			double3 @double = ++val.c0;
			val.c0 = @double;
			double3 double2 = @double;
			@double = ++val.c1;
			val.c1 = @double;
			double3 double3 = @double;
			@double = ++val.c2;
			val.c2 = @double;
			return new double3x3(double2, double3, @double);
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x00027774 File Offset: 0x00025974
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator --(double3x3 val)
		{
			double3 @double = --val.c0;
			val.c0 = @double;
			double3 double2 = @double;
			@double = --val.c1;
			val.c1 = @double;
			double3 double3 = @double;
			@double = --val.c2;
			val.c2 = @double;
			return new double3x3(double2, double3, @double);
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x000277D4 File Offset: 0x000259D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(double3x3 lhs, double3x3 rhs)
		{
			return new bool3x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x0002780E File Offset: 0x00025A0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(double3x3 lhs, double rhs)
		{
			return new bool3x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x00027839 File Offset: 0x00025A39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(double lhs, double3x3 rhs)
		{
			return new bool3x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x00027864 File Offset: 0x00025A64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(double3x3 lhs, double3x3 rhs)
		{
			return new bool3x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x0002789E File Offset: 0x00025A9E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(double3x3 lhs, double rhs)
		{
			return new bool3x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x000278C9 File Offset: 0x00025AC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(double lhs, double3x3 rhs)
		{
			return new bool3x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x000278F4 File Offset: 0x00025AF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(double3x3 lhs, double3x3 rhs)
		{
			return new bool3x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x0002792E File Offset: 0x00025B2E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(double3x3 lhs, double rhs)
		{
			return new bool3x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x00027959 File Offset: 0x00025B59
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(double lhs, double3x3 rhs)
		{
			return new bool3x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x00027984 File Offset: 0x00025B84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(double3x3 lhs, double3x3 rhs)
		{
			return new bool3x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x000279BE File Offset: 0x00025BBE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(double3x3 lhs, double rhs)
		{
			return new bool3x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x000279E9 File Offset: 0x00025BE9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(double lhs, double3x3 rhs)
		{
			return new bool3x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x00027A14 File Offset: 0x00025C14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator -(double3x3 val)
		{
			return new double3x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00027A3C File Offset: 0x00025C3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x3 operator +(double3x3 val)
		{
			return new double3x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00027A64 File Offset: 0x00025C64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(double3x3 lhs, double3x3 rhs)
		{
			return new bool3x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x00027A9E File Offset: 0x00025C9E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(double3x3 lhs, double rhs)
		{
			return new bool3x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x00027AC9 File Offset: 0x00025CC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(double lhs, double3x3 rhs)
		{
			return new bool3x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x00027AF4 File Offset: 0x00025CF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(double3x3 lhs, double3x3 rhs)
		{
			return new bool3x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x00027B2E File Offset: 0x00025D2E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(double3x3 lhs, double rhs)
		{
			return new bool3x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x00027B59 File Offset: 0x00025D59
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(double lhs, double3x3 rhs)
		{
			return new bool3x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x17000285 RID: 645
		public unsafe double3 this[int index]
		{
			get
			{
				fixed (double3x3* ptr = &this)
				{
					return ref *(double3*)(ptr + (IntPtr)index * (IntPtr)sizeof(double3) / (IntPtr)sizeof(double3x3));
				}
			}
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x00027B9F File Offset: 0x00025D9F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(double3x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x00027BDC File Offset: 0x00025DDC
		public override bool Equals(object o)
		{
			if (o is double3x3)
			{
				double3x3 rhs = (double3x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x00027C01 File Offset: 0x00025E01
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x00027C10 File Offset: 0x00025E10
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("double3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c0.z,
				this.c1.z,
				this.c2.z
			});
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x00027CDC File Offset: 0x00025EDC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("double3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c2.z.ToString(format, formatProvider)
			});
		}

		// Token: 0x04000052 RID: 82
		public double3 c0;

		// Token: 0x04000053 RID: 83
		public double3 c1;

		// Token: 0x04000054 RID: 84
		public double3 c2;

		// Token: 0x04000055 RID: 85
		public static readonly double3x3 identity = new double3x3(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0);

		// Token: 0x04000056 RID: 86
		public static readonly double3x3 zero;
	}
}
