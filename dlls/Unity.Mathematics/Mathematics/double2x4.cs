using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000014 RID: 20
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct double2x4 : IEquatable<double2x4>, IFormattable
	{
		// Token: 0x06000BBB RID: 3003 RVA: 0x00024007 File Offset: 0x00022207
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(double2 c0, double2 c1, double2 c2, double2 c3)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
			this.c3 = c3;
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x00024026 File Offset: 0x00022226
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13)
		{
			this.c0 = new double2(m00, m10);
			this.c1 = new double2(m01, m11);
			this.c2 = new double2(m02, m12);
			this.c3 = new double2(m03, m13);
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x00024061 File Offset: 0x00022261
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(double v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x00024094 File Offset: 0x00022294
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(bool v)
		{
			this.c0 = math.select(new double2(0.0), new double2(1.0), v);
			this.c1 = math.select(new double2(0.0), new double2(1.0), v);
			this.c2 = math.select(new double2(0.0), new double2(1.0), v);
			this.c3 = math.select(new double2(0.0), new double2(1.0), v);
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x00024144 File Offset: 0x00022344
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(bool2x4 v)
		{
			this.c0 = math.select(new double2(0.0), new double2(1.0), v.c0);
			this.c1 = math.select(new double2(0.0), new double2(1.0), v.c1);
			this.c2 = math.select(new double2(0.0), new double2(1.0), v.c2);
			this.c3 = math.select(new double2(0.0), new double2(1.0), v.c3);
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x00024205 File Offset: 0x00022405
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x00024238 File Offset: 0x00022438
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(int2x4 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
			this.c3 = v.c3;
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x00024289 File Offset: 0x00022489
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x000242BC File Offset: 0x000224BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(uint2x4 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
			this.c3 = v.c3;
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x0002430D File Offset: 0x0002250D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(float v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x00024340 File Offset: 0x00022540
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x4(float2x4 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
			this.c3 = v.c3;
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x00024391 File Offset: 0x00022591
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x4(double v)
		{
			return new double2x4(v);
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x00024399 File Offset: 0x00022599
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double2x4(bool v)
		{
			return new double2x4(v);
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x000243A1 File Offset: 0x000225A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double2x4(bool2x4 v)
		{
			return new double2x4(v);
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x000243A9 File Offset: 0x000225A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x4(int v)
		{
			return new double2x4(v);
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x000243B1 File Offset: 0x000225B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x4(int2x4 v)
		{
			return new double2x4(v);
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x000243B9 File Offset: 0x000225B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x4(uint v)
		{
			return new double2x4(v);
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x000243C1 File Offset: 0x000225C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x4(uint2x4 v)
		{
			return new double2x4(v);
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x000243C9 File Offset: 0x000225C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x4(float v)
		{
			return new double2x4(v);
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x000243D1 File Offset: 0x000225D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x4(float2x4 v)
		{
			return new double2x4(v);
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x000243DC File Offset: 0x000225DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator *(double2x4 lhs, double2x4 rhs)
		{
			return new double2x4(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3);
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x00024432 File Offset: 0x00022632
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator *(double2x4 lhs, double rhs)
		{
			return new double2x4(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs, lhs.c3 * rhs);
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x00024469 File Offset: 0x00022669
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator *(double lhs, double2x4 rhs)
		{
			return new double2x4(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3);
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x000244A0 File Offset: 0x000226A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator +(double2x4 lhs, double2x4 rhs)
		{
			return new double2x4(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3);
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x000244F6 File Offset: 0x000226F6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator +(double2x4 lhs, double rhs)
		{
			return new double2x4(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs, lhs.c3 + rhs);
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x0002452D File Offset: 0x0002272D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator +(double lhs, double2x4 rhs)
		{
			return new double2x4(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2, lhs + rhs.c3);
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x00024564 File Offset: 0x00022764
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator -(double2x4 lhs, double2x4 rhs)
		{
			return new double2x4(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3);
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x000245BA File Offset: 0x000227BA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator -(double2x4 lhs, double rhs)
		{
			return new double2x4(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs, lhs.c3 - rhs);
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x000245F1 File Offset: 0x000227F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator -(double lhs, double2x4 rhs)
		{
			return new double2x4(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2, lhs - rhs.c3);
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x00024628 File Offset: 0x00022828
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator /(double2x4 lhs, double2x4 rhs)
		{
			return new double2x4(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3);
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0002467E File Offset: 0x0002287E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator /(double2x4 lhs, double rhs)
		{
			return new double2x4(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs);
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x000246B5 File Offset: 0x000228B5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator /(double lhs, double2x4 rhs)
		{
			return new double2x4(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2, lhs / rhs.c3);
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x000246EC File Offset: 0x000228EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator %(double2x4 lhs, double2x4 rhs)
		{
			return new double2x4(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3);
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x00024742 File Offset: 0x00022942
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator %(double2x4 lhs, double rhs)
		{
			return new double2x4(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs);
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x00024779 File Offset: 0x00022979
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator %(double lhs, double2x4 rhs)
		{
			return new double2x4(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2, lhs % rhs.c3);
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x000247B0 File Offset: 0x000229B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator ++(double2x4 val)
		{
			double2 @double = ++val.c0;
			val.c0 = @double;
			double2 double2 = @double;
			@double = ++val.c1;
			val.c1 = @double;
			double2 double3 = @double;
			@double = ++val.c2;
			val.c2 = @double;
			double2 double4 = @double;
			@double = ++val.c3;
			val.c3 = @double;
			return new double2x4(double2, double3, double4, @double);
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x0002482C File Offset: 0x00022A2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator --(double2x4 val)
		{
			double2 @double = --val.c0;
			val.c0 = @double;
			double2 double2 = @double;
			@double = --val.c1;
			val.c1 = @double;
			double2 double3 = @double;
			@double = --val.c2;
			val.c2 = @double;
			double2 double4 = @double;
			@double = --val.c3;
			val.c3 = @double;
			return new double2x4(double2, double3, double4, @double);
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x000248A8 File Offset: 0x00022AA8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <(double2x4 lhs, double2x4 rhs)
		{
			return new bool2x4(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3);
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x000248FE File Offset: 0x00022AFE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <(double2x4 lhs, double rhs)
		{
			return new bool2x4(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs, lhs.c3 < rhs);
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x00024935 File Offset: 0x00022B35
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <(double lhs, double2x4 rhs)
		{
			return new bool2x4(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2, lhs < rhs.c3);
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0002496C File Offset: 0x00022B6C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <=(double2x4 lhs, double2x4 rhs)
		{
			return new bool2x4(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3);
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x000249C2 File Offset: 0x00022BC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <=(double2x4 lhs, double rhs)
		{
			return new bool2x4(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs, lhs.c3 <= rhs);
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x000249F9 File Offset: 0x00022BF9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <=(double lhs, double2x4 rhs)
		{
			return new bool2x4(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2, lhs <= rhs.c3);
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x00024A30 File Offset: 0x00022C30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >(double2x4 lhs, double2x4 rhs)
		{
			return new bool2x4(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3);
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x00024A86 File Offset: 0x00022C86
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >(double2x4 lhs, double rhs)
		{
			return new bool2x4(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs, lhs.c3 > rhs);
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x00024ABD File Offset: 0x00022CBD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >(double lhs, double2x4 rhs)
		{
			return new bool2x4(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2, lhs > rhs.c3);
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x00024AF4 File Offset: 0x00022CF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >=(double2x4 lhs, double2x4 rhs)
		{
			return new bool2x4(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3);
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x00024B4A File Offset: 0x00022D4A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >=(double2x4 lhs, double rhs)
		{
			return new bool2x4(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs, lhs.c3 >= rhs);
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x00024B81 File Offset: 0x00022D81
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >=(double lhs, double2x4 rhs)
		{
			return new bool2x4(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2, lhs >= rhs.c3);
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x00024BB8 File Offset: 0x00022DB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator -(double2x4 val)
		{
			return new double2x4(-val.c0, -val.c1, -val.c2, -val.c3);
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x00024BEB File Offset: 0x00022DEB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x4 operator +(double2x4 val)
		{
			return new double2x4(+val.c0, +val.c1, +val.c2, +val.c3);
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x00024C20 File Offset: 0x00022E20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(double2x4 lhs, double2x4 rhs)
		{
			return new bool2x4(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x00024C76 File Offset: 0x00022E76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(double2x4 lhs, double rhs)
		{
			return new bool2x4(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs);
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x00024CAD File Offset: 0x00022EAD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(double lhs, double2x4 rhs)
		{
			return new bool2x4(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3);
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x00024CE4 File Offset: 0x00022EE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(double2x4 lhs, double2x4 rhs)
		{
			return new bool2x4(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x00024D3A File Offset: 0x00022F3A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(double2x4 lhs, double rhs)
		{
			return new bool2x4(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs);
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x00024D71 File Offset: 0x00022F71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(double lhs, double2x4 rhs)
		{
			return new bool2x4(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3);
		}

		// Token: 0x1700020D RID: 525
		public unsafe double2 this[int index]
		{
			get
			{
				fixed (double2x4* ptr = &this)
				{
					return ref *(double2*)(ptr + (IntPtr)index * (IntPtr)sizeof(double2) / (IntPtr)sizeof(double2x4));
				}
			}
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x00024DC4 File Offset: 0x00022FC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(double2x4 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2) && this.c3.Equals(rhs.c3);
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x00024E20 File Offset: 0x00023020
		public override bool Equals(object o)
		{
			if (o is double2x4)
			{
				double2x4 rhs = (double2x4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x00024E45 File Offset: 0x00023045
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x00024E54 File Offset: 0x00023054
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("double2x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7})", new object[]
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

		// Token: 0x06000BF9 RID: 3065 RVA: 0x00024F0C File Offset: 0x0002310C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("double2x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7})", new object[]
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

		// Token: 0x04000046 RID: 70
		public double2 c0;

		// Token: 0x04000047 RID: 71
		public double2 c1;

		// Token: 0x04000048 RID: 72
		public double2 c2;

		// Token: 0x04000049 RID: 73
		public double2 c3;

		// Token: 0x0400004A RID: 74
		public static readonly double2x4 zero;
	}
}
