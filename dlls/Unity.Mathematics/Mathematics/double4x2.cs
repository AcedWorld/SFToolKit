using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200001A RID: 26
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct double4x2 : IEquatable<double4x2>, IFormattable
	{
		// Token: 0x06000F55 RID: 3925 RVA: 0x0002CC41 File Offset: 0x0002AE41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(double4 c0, double4 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x0002CC51 File Offset: 0x0002AE51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(double m00, double m01, double m10, double m11, double m20, double m21, double m30, double m31)
		{
			this.c0 = new double4(m00, m10, m20, m30);
			this.c1 = new double4(m01, m11, m21, m31);
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x0002CC76 File Offset: 0x0002AE76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(double v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x0002CC90 File Offset: 0x0002AE90
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(bool v)
		{
			this.c0 = math.select(new double4(0.0), new double4(1.0), v);
			this.c1 = math.select(new double4(0.0), new double4(1.0), v);
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x0002CCF0 File Offset: 0x0002AEF0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(bool4x2 v)
		{
			this.c0 = math.select(new double4(0.0), new double4(1.0), v.c0);
			this.c1 = math.select(new double4(0.0), new double4(1.0), v.c1);
		}

		// Token: 0x06000F5A RID: 3930 RVA: 0x0002CD57 File Offset: 0x0002AF57
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(int v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x0002CD71 File Offset: 0x0002AF71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(int4x2 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x0002CD95 File Offset: 0x0002AF95
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(uint v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x0002CDAF File Offset: 0x0002AFAF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(uint4x2 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
		}

		// Token: 0x06000F5E RID: 3934 RVA: 0x0002CDD3 File Offset: 0x0002AFD3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(float v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x0002CDED File Offset: 0x0002AFED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x2(float4x2 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x0002CE11 File Offset: 0x0002B011
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x2(double v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x0002CE19 File Offset: 0x0002B019
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double4x2(bool v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x0002CE21 File Offset: 0x0002B021
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double4x2(bool4x2 v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000F63 RID: 3939 RVA: 0x0002CE29 File Offset: 0x0002B029
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x2(int v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x0002CE31 File Offset: 0x0002B031
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x2(int4x2 v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x0002CE39 File Offset: 0x0002B039
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x2(uint v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x0002CE41 File Offset: 0x0002B041
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x2(uint4x2 v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x0002CE49 File Offset: 0x0002B049
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x2(float v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x0002CE51 File Offset: 0x0002B051
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x2(float4x2 v)
		{
			return new double4x2(v);
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x0002CE59 File Offset: 0x0002B059
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator *(double4x2 lhs, double4x2 rhs)
		{
			return new double4x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x0002CE82 File Offset: 0x0002B082
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator *(double4x2 lhs, double rhs)
		{
			return new double4x2(lhs.c0 * rhs, lhs.c1 * rhs);
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x0002CEA1 File Offset: 0x0002B0A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator *(double lhs, double4x2 rhs)
		{
			return new double4x2(lhs * rhs.c0, lhs * rhs.c1);
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x0002CEC0 File Offset: 0x0002B0C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator +(double4x2 lhs, double4x2 rhs)
		{
			return new double4x2(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x0002CEE9 File Offset: 0x0002B0E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator +(double4x2 lhs, double rhs)
		{
			return new double4x2(lhs.c0 + rhs, lhs.c1 + rhs);
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x0002CF08 File Offset: 0x0002B108
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator +(double lhs, double4x2 rhs)
		{
			return new double4x2(lhs + rhs.c0, lhs + rhs.c1);
		}

		// Token: 0x06000F6F RID: 3951 RVA: 0x0002CF27 File Offset: 0x0002B127
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator -(double4x2 lhs, double4x2 rhs)
		{
			return new double4x2(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x0002CF50 File Offset: 0x0002B150
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator -(double4x2 lhs, double rhs)
		{
			return new double4x2(lhs.c0 - rhs, lhs.c1 - rhs);
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x0002CF6F File Offset: 0x0002B16F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator -(double lhs, double4x2 rhs)
		{
			return new double4x2(lhs - rhs.c0, lhs - rhs.c1);
		}

		// Token: 0x06000F72 RID: 3954 RVA: 0x0002CF8E File Offset: 0x0002B18E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator /(double4x2 lhs, double4x2 rhs)
		{
			return new double4x2(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);
		}

		// Token: 0x06000F73 RID: 3955 RVA: 0x0002CFB7 File Offset: 0x0002B1B7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator /(double4x2 lhs, double rhs)
		{
			return new double4x2(lhs.c0 / rhs, lhs.c1 / rhs);
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x0002CFD6 File Offset: 0x0002B1D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator /(double lhs, double4x2 rhs)
		{
			return new double4x2(lhs / rhs.c0, lhs / rhs.c1);
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x0002CFF5 File Offset: 0x0002B1F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator %(double4x2 lhs, double4x2 rhs)
		{
			return new double4x2(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x0002D01E File Offset: 0x0002B21E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator %(double4x2 lhs, double rhs)
		{
			return new double4x2(lhs.c0 % rhs, lhs.c1 % rhs);
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x0002D03D File Offset: 0x0002B23D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator %(double lhs, double4x2 rhs)
		{
			return new double4x2(lhs % rhs.c0, lhs % rhs.c1);
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x0002D05C File Offset: 0x0002B25C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator ++(double4x2 val)
		{
			double4 @double = ++val.c0;
			val.c0 = @double;
			double4 double2 = @double;
			@double = ++val.c1;
			val.c1 = @double;
			return new double4x2(double2, @double);
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x0002D0A4 File Offset: 0x0002B2A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator --(double4x2 val)
		{
			double4 @double = --val.c0;
			val.c0 = @double;
			double4 double2 = @double;
			@double = --val.c1;
			val.c1 = @double;
			return new double4x2(double2, @double);
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x0002D0EA File Offset: 0x0002B2EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(double4x2 lhs, double4x2 rhs)
		{
			return new bool4x2(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x0002D113 File Offset: 0x0002B313
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(double4x2 lhs, double rhs)
		{
			return new bool4x2(lhs.c0 < rhs, lhs.c1 < rhs);
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x0002D132 File Offset: 0x0002B332
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(double lhs, double4x2 rhs)
		{
			return new bool4x2(lhs < rhs.c0, lhs < rhs.c1);
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x0002D151 File Offset: 0x0002B351
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(double4x2 lhs, double4x2 rhs)
		{
			return new bool4x2(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x0002D17A File Offset: 0x0002B37A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(double4x2 lhs, double rhs)
		{
			return new bool4x2(lhs.c0 <= rhs, lhs.c1 <= rhs);
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x0002D199 File Offset: 0x0002B399
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(double lhs, double4x2 rhs)
		{
			return new bool4x2(lhs <= rhs.c0, lhs <= rhs.c1);
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x0002D1B8 File Offset: 0x0002B3B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(double4x2 lhs, double4x2 rhs)
		{
			return new bool4x2(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);
		}

		// Token: 0x06000F81 RID: 3969 RVA: 0x0002D1E1 File Offset: 0x0002B3E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(double4x2 lhs, double rhs)
		{
			return new bool4x2(lhs.c0 > rhs, lhs.c1 > rhs);
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x0002D200 File Offset: 0x0002B400
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(double lhs, double4x2 rhs)
		{
			return new bool4x2(lhs > rhs.c0, lhs > rhs.c1);
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x0002D21F File Offset: 0x0002B41F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(double4x2 lhs, double4x2 rhs)
		{
			return new bool4x2(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x0002D248 File Offset: 0x0002B448
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(double4x2 lhs, double rhs)
		{
			return new bool4x2(lhs.c0 >= rhs, lhs.c1 >= rhs);
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x0002D267 File Offset: 0x0002B467
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(double lhs, double4x2 rhs)
		{
			return new bool4x2(lhs >= rhs.c0, lhs >= rhs.c1);
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x0002D286 File Offset: 0x0002B486
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator -(double4x2 val)
		{
			return new double4x2(-val.c0, -val.c1);
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x0002D2A3 File Offset: 0x0002B4A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x2 operator +(double4x2 val)
		{
			return new double4x2(+val.c0, +val.c1);
		}

		// Token: 0x06000F88 RID: 3976 RVA: 0x0002D2C0 File Offset: 0x0002B4C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(double4x2 lhs, double4x2 rhs)
		{
			return new bool4x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x0002D2E9 File Offset: 0x0002B4E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(double4x2 lhs, double rhs)
		{
			return new bool4x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x06000F8A RID: 3978 RVA: 0x0002D308 File Offset: 0x0002B508
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(double lhs, double4x2 rhs)
		{
			return new bool4x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x0002D327 File Offset: 0x0002B527
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(double4x2 lhs, double4x2 rhs)
		{
			return new bool4x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x0002D350 File Offset: 0x0002B550
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(double4x2 lhs, double rhs)
		{
			return new bool4x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x0002D36F File Offset: 0x0002B56F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(double lhs, double4x2 rhs)
		{
			return new bool4x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x170003D8 RID: 984
		public unsafe double4 this[int index]
		{
			get
			{
				fixed (double4x2* ptr = &this)
				{
					return ref *(double4*)(ptr + (IntPtr)index * (IntPtr)sizeof(double4) / (IntPtr)sizeof(double4x2));
				}
			}
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x0002D3AB File Offset: 0x0002B5AB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(double4x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x06000F90 RID: 3984 RVA: 0x0002D3D4 File Offset: 0x0002B5D4
		public override bool Equals(object o)
		{
			if (o is double4x2)
			{
				double4x2 rhs = (double4x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x0002D3F9 File Offset: 0x0002B5F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x0002D408 File Offset: 0x0002B608
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("double4x2({0}, {1},  {2}, {3},  {4}, {5},  {6}, {7})", new object[]
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

		// Token: 0x06000F93 RID: 3987 RVA: 0x0002D4C0 File Offset: 0x0002B6C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("double4x2({0}, {1},  {2}, {3},  {4}, {5},  {6}, {7})", new object[]
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

		// Token: 0x04000061 RID: 97
		public double4 c0;

		// Token: 0x04000062 RID: 98
		public double4 c1;

		// Token: 0x04000063 RID: 99
		public static readonly double4x2 zero;
	}
}
