using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000016 RID: 22
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct double3x2 : IEquatable<double3x2>, IFormattable
	{
		// Token: 0x06000CC1 RID: 3265 RVA: 0x0002686A File Offset: 0x00024A6A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(double3 c0, double3 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x0002687A File Offset: 0x00024A7A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(double m00, double m01, double m10, double m11, double m20, double m21)
		{
			this.c0 = new double3(m00, m10, m20);
			this.c1 = new double3(m01, m11, m21);
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x0002689B File Offset: 0x00024A9B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(double v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x000268B8 File Offset: 0x00024AB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(bool v)
		{
			this.c0 = math.select(new double3(0.0), new double3(1.0), v);
			this.c1 = math.select(new double3(0.0), new double3(1.0), v);
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x00026918 File Offset: 0x00024B18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(bool3x2 v)
		{
			this.c0 = math.select(new double3(0.0), new double3(1.0), v.c0);
			this.c1 = math.select(new double3(0.0), new double3(1.0), v.c1);
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x0002697F File Offset: 0x00024B7F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(int v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x00026999 File Offset: 0x00024B99
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(int3x2 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x000269BD File Offset: 0x00024BBD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(uint v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x000269D7 File Offset: 0x00024BD7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(uint3x2 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x000269FB File Offset: 0x00024BFB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(float v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x00026A15 File Offset: 0x00024C15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3x2(float3x2 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x00026A39 File Offset: 0x00024C39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x2(double v)
		{
			return new double3x2(v);
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x00026A41 File Offset: 0x00024C41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double3x2(bool v)
		{
			return new double3x2(v);
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x00026A49 File Offset: 0x00024C49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double3x2(bool3x2 v)
		{
			return new double3x2(v);
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x00026A51 File Offset: 0x00024C51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x2(int v)
		{
			return new double3x2(v);
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x00026A59 File Offset: 0x00024C59
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x2(int3x2 v)
		{
			return new double3x2(v);
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x00026A61 File Offset: 0x00024C61
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x2(uint v)
		{
			return new double3x2(v);
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x00026A69 File Offset: 0x00024C69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x2(uint3x2 v)
		{
			return new double3x2(v);
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x00026A71 File Offset: 0x00024C71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x2(float v)
		{
			return new double3x2(v);
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x00026A79 File Offset: 0x00024C79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3x2(float3x2 v)
		{
			return new double3x2(v);
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x00026A81 File Offset: 0x00024C81
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator *(double3x2 lhs, double3x2 rhs)
		{
			return new double3x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x00026AAA File Offset: 0x00024CAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator *(double3x2 lhs, double rhs)
		{
			return new double3x2(lhs.c0 * rhs, lhs.c1 * rhs);
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x00026AC9 File Offset: 0x00024CC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator *(double lhs, double3x2 rhs)
		{
			return new double3x2(lhs * rhs.c0, lhs * rhs.c1);
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x00026AE8 File Offset: 0x00024CE8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator +(double3x2 lhs, double3x2 rhs)
		{
			return new double3x2(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x00026B11 File Offset: 0x00024D11
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator +(double3x2 lhs, double rhs)
		{
			return new double3x2(lhs.c0 + rhs, lhs.c1 + rhs);
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x00026B30 File Offset: 0x00024D30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator +(double lhs, double3x2 rhs)
		{
			return new double3x2(lhs + rhs.c0, lhs + rhs.c1);
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x00026B4F File Offset: 0x00024D4F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator -(double3x2 lhs, double3x2 rhs)
		{
			return new double3x2(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x00026B78 File Offset: 0x00024D78
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator -(double3x2 lhs, double rhs)
		{
			return new double3x2(lhs.c0 - rhs, lhs.c1 - rhs);
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x00026B97 File Offset: 0x00024D97
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator -(double lhs, double3x2 rhs)
		{
			return new double3x2(lhs - rhs.c0, lhs - rhs.c1);
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x00026BB6 File Offset: 0x00024DB6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator /(double3x2 lhs, double3x2 rhs)
		{
			return new double3x2(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x00026BDF File Offset: 0x00024DDF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator /(double3x2 lhs, double rhs)
		{
			return new double3x2(lhs.c0 / rhs, lhs.c1 / rhs);
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x00026BFE File Offset: 0x00024DFE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator /(double lhs, double3x2 rhs)
		{
			return new double3x2(lhs / rhs.c0, lhs / rhs.c1);
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x00026C1D File Offset: 0x00024E1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator %(double3x2 lhs, double3x2 rhs)
		{
			return new double3x2(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x00026C46 File Offset: 0x00024E46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator %(double3x2 lhs, double rhs)
		{
			return new double3x2(lhs.c0 % rhs, lhs.c1 % rhs);
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x00026C65 File Offset: 0x00024E65
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator %(double lhs, double3x2 rhs)
		{
			return new double3x2(lhs % rhs.c0, lhs % rhs.c1);
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x00026C84 File Offset: 0x00024E84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator ++(double3x2 val)
		{
			double3 @double = ++val.c0;
			val.c0 = @double;
			double3 double2 = @double;
			@double = ++val.c1;
			val.c1 = @double;
			return new double3x2(double2, @double);
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x00026CCC File Offset: 0x00024ECC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator --(double3x2 val)
		{
			double3 @double = --val.c0;
			val.c0 = @double;
			double3 double2 = @double;
			@double = --val.c1;
			val.c1 = @double;
			return new double3x2(double2, @double);
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x00026D12 File Offset: 0x00024F12
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(double3x2 lhs, double3x2 rhs)
		{
			return new bool3x2(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00026D3B File Offset: 0x00024F3B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(double3x2 lhs, double rhs)
		{
			return new bool3x2(lhs.c0 < rhs, lhs.c1 < rhs);
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00026D5A File Offset: 0x00024F5A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(double lhs, double3x2 rhs)
		{
			return new bool3x2(lhs < rhs.c0, lhs < rhs.c1);
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x00026D79 File Offset: 0x00024F79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(double3x2 lhs, double3x2 rhs)
		{
			return new bool3x2(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x00026DA2 File Offset: 0x00024FA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(double3x2 lhs, double rhs)
		{
			return new bool3x2(lhs.c0 <= rhs, lhs.c1 <= rhs);
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x00026DC1 File Offset: 0x00024FC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(double lhs, double3x2 rhs)
		{
			return new bool3x2(lhs <= rhs.c0, lhs <= rhs.c1);
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x00026DE0 File Offset: 0x00024FE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(double3x2 lhs, double3x2 rhs)
		{
			return new bool3x2(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x00026E09 File Offset: 0x00025009
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(double3x2 lhs, double rhs)
		{
			return new bool3x2(lhs.c0 > rhs, lhs.c1 > rhs);
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x00026E28 File Offset: 0x00025028
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(double lhs, double3x2 rhs)
		{
			return new bool3x2(lhs > rhs.c0, lhs > rhs.c1);
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x00026E47 File Offset: 0x00025047
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(double3x2 lhs, double3x2 rhs)
		{
			return new bool3x2(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x00026E70 File Offset: 0x00025070
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(double3x2 lhs, double rhs)
		{
			return new bool3x2(lhs.c0 >= rhs, lhs.c1 >= rhs);
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x00026E8F File Offset: 0x0002508F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(double lhs, double3x2 rhs)
		{
			return new bool3x2(lhs >= rhs.c0, lhs >= rhs.c1);
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x00026EAE File Offset: 0x000250AE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator -(double3x2 val)
		{
			return new double3x2(-val.c0, -val.c1);
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x00026ECB File Offset: 0x000250CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3x2 operator +(double3x2 val)
		{
			return new double3x2(+val.c0, +val.c1);
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x00026EE8 File Offset: 0x000250E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(double3x2 lhs, double3x2 rhs)
		{
			return new bool3x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x00026F11 File Offset: 0x00025111
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(double3x2 lhs, double rhs)
		{
			return new bool3x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x00026F30 File Offset: 0x00025130
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(double lhs, double3x2 rhs)
		{
			return new bool3x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x00026F4F File Offset: 0x0002514F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(double3x2 lhs, double3x2 rhs)
		{
			return new bool3x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x00026F78 File Offset: 0x00025178
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(double3x2 lhs, double rhs)
		{
			return new bool3x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x00026F97 File Offset: 0x00025197
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(double lhs, double3x2 rhs)
		{
			return new bool3x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x17000284 RID: 644
		public unsafe double3 this[int index]
		{
			get
			{
				fixed (double3x2* ptr = &this)
				{
					return ref *(double3*)(ptr + (IntPtr)index * (IntPtr)sizeof(double3) / (IntPtr)sizeof(double3x2));
				}
			}
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x00026FD3 File Offset: 0x000251D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(double3x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x00026FFC File Offset: 0x000251FC
		public override bool Equals(object o)
		{
			if (o is double3x2)
			{
				double3x2 rhs = (double3x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x00027021 File Offset: 0x00025221
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x00027030 File Offset: 0x00025230
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("double3x2({0}, {1},  {2}, {3},  {4}, {5})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y,
				this.c0.z,
				this.c1.z
			});
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x000270C0 File Offset: 0x000252C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("double3x2({0}, {1},  {2}, {3},  {4}, {5})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider)
			});
		}

		// Token: 0x0400004F RID: 79
		public double3 c0;

		// Token: 0x04000050 RID: 80
		public double3 c1;

		// Token: 0x04000051 RID: 81
		public static readonly double3x2 zero;
	}
}
