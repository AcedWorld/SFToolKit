using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000015 RID: 21
	[DebuggerTypeProxy(typeof(double3.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct double3 : IEquatable<double3>, IFormattable
	{
		// Token: 0x06000BFA RID: 3066 RVA: 0x00024FD1 File Offset: 0x000231D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x00024FE8 File Offset: 0x000231E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(double x, double2 yz)
		{
			this.x = x;
			this.y = yz.x;
			this.z = yz.y;
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x00025009 File Offset: 0x00023209
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(double2 xy, double z)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = z;
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x0002502A File Offset: 0x0002322A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(double3 xyz)
		{
			this.x = xyz.x;
			this.y = xyz.y;
			this.z = xyz.z;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x00025050 File Offset: 0x00023250
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(double v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x00025068 File Offset: 0x00023268
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(bool v)
		{
			this.x = (v ? 1.0 : 0.0);
			this.y = (v ? 1.0 : 0.0);
			this.z = (v ? 1.0 : 0.0);
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x000250CC File Offset: 0x000232CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(bool3 v)
		{
			this.x = (v.x ? 1.0 : 0.0);
			this.y = (v.y ? 1.0 : 0.0);
			this.z = (v.z ? 1.0 : 0.0);
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x0002513F File Offset: 0x0002333F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(int v)
		{
			this.x = (double)v;
			this.y = (double)v;
			this.z = (double)v;
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x00025159 File Offset: 0x00023359
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(int3 v)
		{
			this.x = (double)v.x;
			this.y = (double)v.y;
			this.z = (double)v.z;
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x00025182 File Offset: 0x00023382
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(uint v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0002519F File Offset: 0x0002339F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(uint3 v)
		{
			this.x = v.x;
			this.y = v.y;
			this.z = v.z;
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x000251CB File Offset: 0x000233CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(half v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x000251F1 File Offset: 0x000233F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(half3 v)
		{
			this.x = v.x;
			this.y = v.y;
			this.z = v.z;
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x00025226 File Offset: 0x00023426
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(float v)
		{
			this.x = (double)v;
			this.y = (double)v;
			this.z = (double)v;
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x00025240 File Offset: 0x00023440
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double3(float3 v)
		{
			this.x = (double)v.x;
			this.y = (double)v.y;
			this.z = (double)v.z;
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x00025269 File Offset: 0x00023469
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3(double v)
		{
			return new double3(v);
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x00025271 File Offset: 0x00023471
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double3(bool v)
		{
			return new double3(v);
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x00025279 File Offset: 0x00023479
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double3(bool3 v)
		{
			return new double3(v);
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x00025281 File Offset: 0x00023481
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3(int v)
		{
			return new double3(v);
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x00025289 File Offset: 0x00023489
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3(int3 v)
		{
			return new double3(v);
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x00025291 File Offset: 0x00023491
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3(uint v)
		{
			return new double3(v);
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x00025299 File Offset: 0x00023499
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3(uint3 v)
		{
			return new double3(v);
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x000252A1 File Offset: 0x000234A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3(half v)
		{
			return new double3(v);
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x000252A9 File Offset: 0x000234A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3(half3 v)
		{
			return new double3(v);
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x000252B1 File Offset: 0x000234B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3(float v)
		{
			return new double3(v);
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x000252B9 File Offset: 0x000234B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double3(float3 v)
		{
			return new double3(v);
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x000252C1 File Offset: 0x000234C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator *(double3 lhs, double3 rhs)
		{
			return new double3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x000252EF File Offset: 0x000234EF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator *(double3 lhs, double rhs)
		{
			return new double3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x0002530E File Offset: 0x0002350E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator *(double lhs, double3 rhs)
		{
			return new double3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x0002532D File Offset: 0x0002352D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator +(double3 lhs, double3 rhs)
		{
			return new double3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x0002535B File Offset: 0x0002355B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator +(double3 lhs, double rhs)
		{
			return new double3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x0002537A File Offset: 0x0002357A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator +(double lhs, double3 rhs)
		{
			return new double3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00025399 File Offset: 0x00023599
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator -(double3 lhs, double3 rhs)
		{
			return new double3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x000253C7 File Offset: 0x000235C7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator -(double3 lhs, double rhs)
		{
			return new double3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x000253E6 File Offset: 0x000235E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator -(double lhs, double3 rhs)
		{
			return new double3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x00025405 File Offset: 0x00023605
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator /(double3 lhs, double3 rhs)
		{
			return new double3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x00025433 File Offset: 0x00023633
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator /(double3 lhs, double rhs)
		{
			return new double3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x00025452 File Offset: 0x00023652
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator /(double lhs, double3 rhs)
		{
			return new double3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x00025471 File Offset: 0x00023671
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator %(double3 lhs, double3 rhs)
		{
			return new double3(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z);
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x0002549F File Offset: 0x0002369F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator %(double3 lhs, double rhs)
		{
			return new double3(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs);
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x000254BE File Offset: 0x000236BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator %(double lhs, double3 rhs)
		{
			return new double3(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z);
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x000254E0 File Offset: 0x000236E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator ++(double3 val)
		{
			double num = val.x + 1.0;
			val.x = num;
			double num2 = num;
			num = val.y + 1.0;
			val.y = num;
			double num3 = num;
			num = val.z + 1.0;
			val.z = num;
			return new double3(num2, num3, num);
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x00025538 File Offset: 0x00023738
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator --(double3 val)
		{
			double num = val.x - 1.0;
			val.x = num;
			double num2 = num;
			num = val.y - 1.0;
			val.y = num;
			double num3 = num;
			num = val.z - 1.0;
			val.z = num;
			return new double3(num2, num3, num);
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x0002558F File Offset: 0x0002378F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <(double3 lhs, double3 rhs)
		{
			return new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x000255C0 File Offset: 0x000237C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <(double3 lhs, double rhs)
		{
			return new bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x000255E2 File Offset: 0x000237E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <(double lhs, double3 rhs)
		{
			return new bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x00025604 File Offset: 0x00023804
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <=(double3 lhs, double3 rhs)
		{
			return new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x0002563E File Offset: 0x0002383E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <=(double3 lhs, double rhs)
		{
			return new bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x00025669 File Offset: 0x00023869
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <=(double lhs, double3 rhs)
		{
			return new bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x00025694 File Offset: 0x00023894
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >(double3 lhs, double3 rhs)
		{
			return new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x000256C5 File Offset: 0x000238C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >(double3 lhs, double rhs)
		{
			return new bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x000256E7 File Offset: 0x000238E7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >(double lhs, double3 rhs)
		{
			return new bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00025709 File Offset: 0x00023909
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >=(double3 lhs, double3 rhs)
		{
			return new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x00025743 File Offset: 0x00023943
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >=(double3 lhs, double rhs)
		{
			return new bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x0002576E File Offset: 0x0002396E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >=(double lhs, double3 rhs)
		{
			return new bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x00025799 File Offset: 0x00023999
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator -(double3 val)
		{
			return new double3(-val.x, -val.y, -val.z);
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x000257B5 File Offset: 0x000239B5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 operator +(double3 val)
		{
			return new double3(val.x, val.y, val.z);
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x000257CE File Offset: 0x000239CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(double3 lhs, double3 rhs)
		{
			return new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x000257FF File Offset: 0x000239FF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(double3 lhs, double rhs)
		{
			return new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x00025821 File Offset: 0x00023A21
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(double lhs, double3 rhs)
		{
			return new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x00025843 File Offset: 0x00023A43
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(double3 lhs, double3 rhs)
		{
			return new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x0002587D File Offset: 0x00023A7D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(double3 lhs, double rhs)
		{
			return new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x000258A8 File Offset: 0x00023AA8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(double lhs, double3 rhs)
		{
			return new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000C39 RID: 3129 RVA: 0x000258D3 File Offset: 0x00023AD3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000C3A RID: 3130 RVA: 0x000258F2 File Offset: 0x00023AF2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000C3B RID: 3131 RVA: 0x00025911 File Offset: 0x00023B11
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000C3C RID: 3132 RVA: 0x00025930 File Offset: 0x00023B30
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000C3D RID: 3133 RVA: 0x0002594F File Offset: 0x00023B4F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x0002596E File Offset: 0x00023B6E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.y, this.z);
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000C3F RID: 3135 RVA: 0x0002598D File Offset: 0x00023B8D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x000259AC File Offset: 0x00023BAC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000C41 RID: 3137 RVA: 0x000259CB File Offset: 0x00023BCB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x000259EA File Offset: 0x00023BEA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000C43 RID: 3139 RVA: 0x00025A09 File Offset: 0x00023C09
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x00025A28 File Offset: 0x00023C28
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.x, this.z);
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000C45 RID: 3141 RVA: 0x00025A47 File Offset: 0x00023C47
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x00025A66 File Offset: 0x00023C66
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000C47 RID: 3143 RVA: 0x00025A85 File Offset: 0x00023C85
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.y, this.z);
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000C48 RID: 3144 RVA: 0x00025AA4 File Offset: 0x00023CA4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.z, this.x);
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000C49 RID: 3145 RVA: 0x00025AC3 File Offset: 0x00023CC3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.z, this.y);
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000C4A RID: 3146 RVA: 0x00025AE2 File Offset: 0x00023CE2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000C4B RID: 3147 RVA: 0x00025B01 File Offset: 0x00023D01
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000C4C RID: 3148 RVA: 0x00025B20 File Offset: 0x00023D20
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000C4D RID: 3149 RVA: 0x00025B3F File Offset: 0x00023D3F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000C4E RID: 3150 RVA: 0x00025B5E File Offset: 0x00023D5E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000C4F RID: 3151 RVA: 0x00025B7D File Offset: 0x00023D7D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000C50 RID: 3152 RVA: 0x00025B9C File Offset: 0x00023D9C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000C51 RID: 3153 RVA: 0x00025BBB File Offset: 0x00023DBB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000C52 RID: 3154 RVA: 0x00025BDA File Offset: 0x00023DDA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000C53 RID: 3155 RVA: 0x00025BF9 File Offset: 0x00023DF9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000C54 RID: 3156 RVA: 0x00025C18 File Offset: 0x00023E18
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000C55 RID: 3157 RVA: 0x00025C37 File Offset: 0x00023E37
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000C56 RID: 3158 RVA: 0x00025C56 File Offset: 0x00023E56
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.x, this.z);
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000C57 RID: 3159 RVA: 0x00025C75 File Offset: 0x00023E75
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000C58 RID: 3160 RVA: 0x00025C94 File Offset: 0x00023E94
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000C59 RID: 3161 RVA: 0x00025CB3 File Offset: 0x00023EB3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.y, this.z);
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000C5A RID: 3162 RVA: 0x00025CD2 File Offset: 0x00023ED2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000C5B RID: 3163 RVA: 0x00025CF1 File Offset: 0x00023EF1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000C5C RID: 3164 RVA: 0x00025D10 File Offset: 0x00023F10
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000C5D RID: 3165 RVA: 0x00025D2F File Offset: 0x00023F2F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000C5E RID: 3166 RVA: 0x00025D4E File Offset: 0x00023F4E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000C5F RID: 3167 RVA: 0x00025D6D File Offset: 0x00023F6D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000C60 RID: 3168 RVA: 0x00025D8C File Offset: 0x00023F8C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000C61 RID: 3169 RVA: 0x00025DAB File Offset: 0x00023FAB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000C62 RID: 3170 RVA: 0x00025DCA File Offset: 0x00023FCA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000C63 RID: 3171 RVA: 0x00025DE9 File Offset: 0x00023FE9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000C64 RID: 3172 RVA: 0x00025E08 File Offset: 0x00024008
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.z, this.y);
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000C65 RID: 3173 RVA: 0x00025E27 File Offset: 0x00024027
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.z, this.z);
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000C66 RID: 3174 RVA: 0x00025E46 File Offset: 0x00024046
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.x, this.x);
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000C67 RID: 3175 RVA: 0x00025E65 File Offset: 0x00024065
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.x, this.y);
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000C68 RID: 3176 RVA: 0x00025E84 File Offset: 0x00024084
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.x, this.z);
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000C69 RID: 3177 RVA: 0x00025EA3 File Offset: 0x000240A3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.y, this.x);
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000C6A RID: 3178 RVA: 0x00025EC2 File Offset: 0x000240C2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000C6B RID: 3179 RVA: 0x00025EE1 File Offset: 0x000240E1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000C6C RID: 3180 RVA: 0x00025F00 File Offset: 0x00024100
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000C6D RID: 3181 RVA: 0x00025F1F File Offset: 0x0002411F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000C6E RID: 3182 RVA: 0x00025F3E File Offset: 0x0002413E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000C6F RID: 3183 RVA: 0x00025F5D File Offset: 0x0002415D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000C70 RID: 3184 RVA: 0x00025F7C File Offset: 0x0002417C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000C71 RID: 3185 RVA: 0x00025F9B File Offset: 0x0002419B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000C72 RID: 3186 RVA: 0x00025FBA File Offset: 0x000241BA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000C73 RID: 3187 RVA: 0x00025FD9 File Offset: 0x000241D9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000C74 RID: 3188 RVA: 0x00025FF8 File Offset: 0x000241F8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.y, this.z);
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000C75 RID: 3189 RVA: 0x00026017 File Offset: 0x00024217
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.z, this.x);
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000C76 RID: 3190 RVA: 0x00026036 File Offset: 0x00024236
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.z, this.y);
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000C77 RID: 3191 RVA: 0x00026055 File Offset: 0x00024255
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.x, this.z, this.z);
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000C78 RID: 3192 RVA: 0x00026074 File Offset: 0x00024274
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.x, this.x);
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x00026093 File Offset: 0x00024293
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.x, this.y);
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000C7A RID: 3194 RVA: 0x000260B2 File Offset: 0x000242B2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000C7B RID: 3195 RVA: 0x000260D1 File Offset: 0x000242D1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000C7C RID: 3196 RVA: 0x000260F0 File Offset: 0x000242F0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000C7D RID: 3197 RVA: 0x0002610F File Offset: 0x0002430F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000C7E RID: 3198 RVA: 0x0002612E File Offset: 0x0002432E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000C7F RID: 3199 RVA: 0x0002614D File Offset: 0x0002434D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000C80 RID: 3200 RVA: 0x0002616C File Offset: 0x0002436C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x0002618B File Offset: 0x0002438B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000C82 RID: 3202 RVA: 0x000261AA File Offset: 0x000243AA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000C83 RID: 3203 RVA: 0x000261C9 File Offset: 0x000243C9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000C84 RID: 3204 RVA: 0x000261E8 File Offset: 0x000243E8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.y, this.x);
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x00026207 File Offset: 0x00024407
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.y, this.y);
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000C86 RID: 3206 RVA: 0x00026226 File Offset: 0x00024426
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.y, this.z);
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x00026245 File Offset: 0x00024445
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.z, this.x);
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000C88 RID: 3208 RVA: 0x00026264 File Offset: 0x00024464
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.z, this.y);
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000C89 RID: 3209 RVA: 0x00026283 File Offset: 0x00024483
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.z, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000C8A RID: 3210 RVA: 0x000262A2 File Offset: 0x000244A2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.x, this.x);
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000C8B RID: 3211 RVA: 0x000262BB File Offset: 0x000244BB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.x, this.y);
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000C8C RID: 3212 RVA: 0x000262D4 File Offset: 0x000244D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.x, this.z);
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000C8D RID: 3213 RVA: 0x000262ED File Offset: 0x000244ED
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.y, this.x);
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000C8E RID: 3214 RVA: 0x00026306 File Offset: 0x00024506
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.y, this.y);
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000C8F RID: 3215 RVA: 0x0002631F File Offset: 0x0002451F
		// (set) Token: 0x06000C90 RID: 3216 RVA: 0x00026338 File Offset: 0x00024538
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000C91 RID: 3217 RVA: 0x0002635E File Offset: 0x0002455E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.z, this.x);
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000C92 RID: 3218 RVA: 0x00026377 File Offset: 0x00024577
		// (set) Token: 0x06000C93 RID: 3219 RVA: 0x00026390 File Offset: 0x00024590
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000C94 RID: 3220 RVA: 0x000263B6 File Offset: 0x000245B6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.z, this.z);
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000C95 RID: 3221 RVA: 0x000263CF File Offset: 0x000245CF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.x, this.x);
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000C96 RID: 3222 RVA: 0x000263E8 File Offset: 0x000245E8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.x, this.y);
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000C97 RID: 3223 RVA: 0x00026401 File Offset: 0x00024601
		// (set) Token: 0x06000C98 RID: 3224 RVA: 0x0002641A File Offset: 0x0002461A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000C99 RID: 3225 RVA: 0x00026440 File Offset: 0x00024640
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.y, this.x);
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000C9A RID: 3226 RVA: 0x00026459 File Offset: 0x00024659
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.y, this.y);
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x00026472 File Offset: 0x00024672
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.y, this.z);
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000C9C RID: 3228 RVA: 0x0002648B File Offset: 0x0002468B
		// (set) Token: 0x06000C9D RID: 3229 RVA: 0x000264A4 File Offset: 0x000246A4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000C9E RID: 3230 RVA: 0x000264CA File Offset: 0x000246CA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.z, this.y);
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x000264E3 File Offset: 0x000246E3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.z, this.z);
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000CA0 RID: 3232 RVA: 0x000264FC File Offset: 0x000246FC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.x, this.x);
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x00026515 File Offset: 0x00024715
		// (set) Token: 0x06000CA2 RID: 3234 RVA: 0x0002652E File Offset: 0x0002472E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x00026554 File Offset: 0x00024754
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.x, this.z);
			}
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000CA4 RID: 3236 RVA: 0x0002656D File Offset: 0x0002476D
		// (set) Token: 0x06000CA5 RID: 3237 RVA: 0x00026586 File Offset: 0x00024786
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000CA6 RID: 3238 RVA: 0x000265AC File Offset: 0x000247AC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.y, this.y);
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x000265C5 File Offset: 0x000247C5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.y, this.z);
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000CA8 RID: 3240 RVA: 0x000265DE File Offset: 0x000247DE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.z, this.x);
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x000265F7 File Offset: 0x000247F7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.z, this.y);
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000CAA RID: 3242 RVA: 0x00026610 File Offset: 0x00024810
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.z, this.z, this.z);
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x00026629 File Offset: 0x00024829
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.x, this.x);
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x0002663C File Offset: 0x0002483C
		// (set) Token: 0x06000CAD RID: 3245 RVA: 0x0002664F File Offset: 0x0002484F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x00026669 File Offset: 0x00024869
		// (set) Token: 0x06000CAF RID: 3247 RVA: 0x0002667C File Offset: 0x0002487C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 xz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000CB0 RID: 3248 RVA: 0x00026696 File Offset: 0x00024896
		// (set) Token: 0x06000CB1 RID: 3249 RVA: 0x000266A9 File Offset: 0x000248A9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000CB2 RID: 3250 RVA: 0x000266C3 File Offset: 0x000248C3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.y, this.y);
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x000266D6 File Offset: 0x000248D6
		// (set) Token: 0x06000CB4 RID: 3252 RVA: 0x000266E9 File Offset: 0x000248E9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 yz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x00026703 File Offset: 0x00024903
		// (set) Token: 0x06000CB6 RID: 3254 RVA: 0x00026716 File Offset: 0x00024916
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 zx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000CB7 RID: 3255 RVA: 0x00026730 File Offset: 0x00024930
		// (set) Token: 0x06000CB8 RID: 3256 RVA: 0x00026743 File Offset: 0x00024943
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 zy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000CB9 RID: 3257 RVA: 0x0002675D File Offset: 0x0002495D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.z, this.z);
			}
		}

		// Token: 0x17000283 RID: 643
		public unsafe double this[int index]
		{
			get
			{
				fixed (double3* ptr = &this)
				{
					return ((double*)ptr)[index];
				}
			}
			set
			{
				fixed (double* ptr = &this.x)
				{
					ptr[index] = value;
				}
			}
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x000267A8 File Offset: 0x000249A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(double3 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y && this.z == rhs.z;
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x000267D8 File Offset: 0x000249D8
		public override bool Equals(object o)
		{
			if (o is double3)
			{
				double3 rhs = (double3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x000267FD File Offset: 0x000249FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x0002680A File Offset: 0x00024A0A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("double3({0}, {1}, {2})", this.x, this.y, this.z);
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x00026837 File Offset: 0x00024A37
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("double3({0}, {1}, {2})", this.x.ToString(format, formatProvider), this.y.ToString(format, formatProvider), this.z.ToString(format, formatProvider));
		}

		// Token: 0x0400004B RID: 75
		public double x;

		// Token: 0x0400004C RID: 76
		public double y;

		// Token: 0x0400004D RID: 77
		public double z;

		// Token: 0x0400004E RID: 78
		public static readonly double3 zero;

		// Token: 0x02000058 RID: 88
		internal sealed class DebuggerProxy
		{
			// Token: 0x0600246D RID: 9325 RVA: 0x0006759C File Offset: 0x0006579C
			public DebuggerProxy(double3 v)
			{
				this.x = v.x;
				this.y = v.y;
				this.z = v.z;
			}

			// Token: 0x04000145 RID: 325
			public double x;

			// Token: 0x04000146 RID: 326
			public double y;

			// Token: 0x04000147 RID: 327
			public double z;
		}
	}
}
