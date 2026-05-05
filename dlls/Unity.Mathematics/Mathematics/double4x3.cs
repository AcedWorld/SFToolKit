using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200001B RID: 27
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct double4x3 : IEquatable<double4x3>, IFormattable
	{
		// Token: 0x06000F94 RID: 3988 RVA: 0x0002D585 File Offset: 0x0002B785
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(double4 c0, double4 c1, double4 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x0002D59C File Offset: 0x0002B79C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22, double m30, double m31, double m32)
		{
			this.c0 = new double4(m00, m10, m20, m30);
			this.c1 = new double4(m01, m11, m21, m31);
			this.c2 = new double4(m02, m12, m22, m32);
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x0002D5D4 File Offset: 0x0002B7D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(double v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x0002D5FC File Offset: 0x0002B7FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(bool v)
		{
			this.c0 = math.select(new double4(0.0), new double4(1.0), v);
			this.c1 = math.select(new double4(0.0), new double4(1.0), v);
			this.c2 = math.select(new double4(0.0), new double4(1.0), v);
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x0002D684 File Offset: 0x0002B884
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(bool4x3 v)
		{
			this.c0 = math.select(new double4(0.0), new double4(1.0), v.c0);
			this.c1 = math.select(new double4(0.0), new double4(1.0), v.c1);
			this.c2 = math.select(new double4(0.0), new double4(1.0), v.c2);
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x0002D718 File Offset: 0x0002B918
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x0002D73E File Offset: 0x0002B93E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(int4x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x0002D773 File Offset: 0x0002B973
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x0002D799 File Offset: 0x0002B999
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(uint4x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x0002D7CE File Offset: 0x0002B9CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(float v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x0002D7F4 File Offset: 0x0002B9F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double4x3(float4x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x0002D829 File Offset: 0x0002BA29
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x3(double v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x0002D831 File Offset: 0x0002BA31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double4x3(bool v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x0002D839 File Offset: 0x0002BA39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double4x3(bool4x3 v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x0002D841 File Offset: 0x0002BA41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x3(int v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x0002D849 File Offset: 0x0002BA49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x3(int4x3 v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x0002D851 File Offset: 0x0002BA51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x3(uint v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x0002D859 File Offset: 0x0002BA59
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x3(uint4x3 v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x0002D861 File Offset: 0x0002BA61
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x3(float v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x0002D869 File Offset: 0x0002BA69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double4x3(float4x3 v)
		{
			return new double4x3(v);
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x0002D871 File Offset: 0x0002BA71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator *(double4x3 lhs, double4x3 rhs)
		{
			return new double4x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x0002D8AB File Offset: 0x0002BAAB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator *(double4x3 lhs, double rhs)
		{
			return new double4x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x0002D8D6 File Offset: 0x0002BAD6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator *(double lhs, double4x3 rhs)
		{
			return new double4x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x0002D901 File Offset: 0x0002BB01
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator +(double4x3 lhs, double4x3 rhs)
		{
			return new double4x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x0002D93B File Offset: 0x0002BB3B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator +(double4x3 lhs, double rhs)
		{
			return new double4x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x0002D966 File Offset: 0x0002BB66
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator +(double lhs, double4x3 rhs)
		{
			return new double4x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x0002D991 File Offset: 0x0002BB91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator -(double4x3 lhs, double4x3 rhs)
		{
			return new double4x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x0002D9CB File Offset: 0x0002BBCB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator -(double4x3 lhs, double rhs)
		{
			return new double4x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x0002D9F6 File Offset: 0x0002BBF6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator -(double lhs, double4x3 rhs)
		{
			return new double4x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x0002DA21 File Offset: 0x0002BC21
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator /(double4x3 lhs, double4x3 rhs)
		{
			return new double4x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x0002DA5B File Offset: 0x0002BC5B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator /(double4x3 lhs, double rhs)
		{
			return new double4x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x0002DA86 File Offset: 0x0002BC86
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator /(double lhs, double4x3 rhs)
		{
			return new double4x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x0002DAB1 File Offset: 0x0002BCB1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator %(double4x3 lhs, double4x3 rhs)
		{
			return new double4x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x0002DAEB File Offset: 0x0002BCEB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator %(double4x3 lhs, double rhs)
		{
			return new double4x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x0002DB16 File Offset: 0x0002BD16
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator %(double lhs, double4x3 rhs)
		{
			return new double4x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x0002DB44 File Offset: 0x0002BD44
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator ++(double4x3 val)
		{
			double4 @double = ++val.c0;
			val.c0 = @double;
			double4 double2 = @double;
			@double = ++val.c1;
			val.c1 = @double;
			double4 double3 = @double;
			@double = ++val.c2;
			val.c2 = @double;
			return new double4x3(double2, double3, @double);
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x0002DBA4 File Offset: 0x0002BDA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator --(double4x3 val)
		{
			double4 @double = --val.c0;
			val.c0 = @double;
			double4 double2 = @double;
			@double = --val.c1;
			val.c1 = @double;
			double4 double3 = @double;
			@double = --val.c2;
			val.c2 = @double;
			return new double4x3(double2, double3, @double);
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x0002DC04 File Offset: 0x0002BE04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(double4x3 lhs, double4x3 rhs)
		{
			return new bool4x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x0002DC3E File Offset: 0x0002BE3E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(double4x3 lhs, double rhs)
		{
			return new bool4x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x0002DC69 File Offset: 0x0002BE69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(double lhs, double4x3 rhs)
		{
			return new bool4x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x0002DC94 File Offset: 0x0002BE94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(double4x3 lhs, double4x3 rhs)
		{
			return new bool4x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x0002DCCE File Offset: 0x0002BECE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(double4x3 lhs, double rhs)
		{
			return new bool4x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x0002DCF9 File Offset: 0x0002BEF9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(double lhs, double4x3 rhs)
		{
			return new bool4x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x0002DD24 File Offset: 0x0002BF24
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(double4x3 lhs, double4x3 rhs)
		{
			return new bool4x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x0002DD5E File Offset: 0x0002BF5E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(double4x3 lhs, double rhs)
		{
			return new bool4x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x0002DD89 File Offset: 0x0002BF89
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(double lhs, double4x3 rhs)
		{
			return new bool4x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x0002DDB4 File Offset: 0x0002BFB4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(double4x3 lhs, double4x3 rhs)
		{
			return new bool4x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x0002DDEE File Offset: 0x0002BFEE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(double4x3 lhs, double rhs)
		{
			return new bool4x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x06000FC4 RID: 4036 RVA: 0x0002DE19 File Offset: 0x0002C019
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(double lhs, double4x3 rhs)
		{
			return new bool4x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x06000FC5 RID: 4037 RVA: 0x0002DE44 File Offset: 0x0002C044
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator -(double4x3 val)
		{
			return new double4x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x0002DE6C File Offset: 0x0002C06C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4x3 operator +(double4x3 val)
		{
			return new double4x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x0002DE94 File Offset: 0x0002C094
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(double4x3 lhs, double4x3 rhs)
		{
			return new bool4x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x0002DECE File Offset: 0x0002C0CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(double4x3 lhs, double rhs)
		{
			return new bool4x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x0002DEF9 File Offset: 0x0002C0F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(double lhs, double4x3 rhs)
		{
			return new bool4x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x0002DF24 File Offset: 0x0002C124
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(double4x3 lhs, double4x3 rhs)
		{
			return new bool4x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x0002DF5E File Offset: 0x0002C15E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(double4x3 lhs, double rhs)
		{
			return new bool4x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x0002DF89 File Offset: 0x0002C189
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(double lhs, double4x3 rhs)
		{
			return new bool4x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x170003D9 RID: 985
		public unsafe double4 this[int index]
		{
			get
			{
				fixed (double4x3* ptr = &this)
				{
					return ref *(double4*)(ptr + (IntPtr)index * (IntPtr)sizeof(double4) / (IntPtr)sizeof(double4x3));
				}
			}
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x0002DFCF File Offset: 0x0002C1CF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(double4x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x0002E00C File Offset: 0x0002C20C
		public override bool Equals(object o)
		{
			if (o is double4x3)
			{
				double4x3 rhs = (double4x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x0002E031 File Offset: 0x0002C231
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x0002E040 File Offset: 0x0002C240
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("double4x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8},  {9}, {10}, {11})", new object[]
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

		// Token: 0x06000FD2 RID: 4050 RVA: 0x0002E148 File Offset: 0x0002C348
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("double4x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8},  {9}, {10}, {11})", new object[]
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

		// Token: 0x04000064 RID: 100
		public double4 c0;

		// Token: 0x04000065 RID: 101
		public double4 c1;

		// Token: 0x04000066 RID: 102
		public double4 c2;

		// Token: 0x04000067 RID: 103
		public static readonly double4x3 zero;
	}
}
