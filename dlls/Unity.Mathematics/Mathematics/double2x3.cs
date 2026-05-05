using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000013 RID: 19
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct double2x3 : IEquatable<double2x3>, IFormattable
	{
		// Token: 0x06000B7C RID: 2940 RVA: 0x0002342D File Offset: 0x0002162D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(double2 c0, double2 c1, double2 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x00023444 File Offset: 0x00021644
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(double m00, double m01, double m02, double m10, double m11, double m12)
		{
			this.c0 = new double2(m00, m10);
			this.c1 = new double2(m01, m11);
			this.c2 = new double2(m02, m12);
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x00023470 File Offset: 0x00021670
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(double v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x00023498 File Offset: 0x00021698
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(bool v)
		{
			this.c0 = math.select(new double2(0.0), new double2(1.0), v);
			this.c1 = math.select(new double2(0.0), new double2(1.0), v);
			this.c2 = math.select(new double2(0.0), new double2(1.0), v);
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x00023520 File Offset: 0x00021720
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(bool2x3 v)
		{
			this.c0 = math.select(new double2(0.0), new double2(1.0), v.c0);
			this.c1 = math.select(new double2(0.0), new double2(1.0), v.c1);
			this.c2 = math.select(new double2(0.0), new double2(1.0), v.c2);
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x000235B4 File Offset: 0x000217B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x000235DA File Offset: 0x000217DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(int2x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0002360F File Offset: 0x0002180F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x00023635 File Offset: 0x00021835
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(uint2x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0002366A File Offset: 0x0002186A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(float v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x00023690 File Offset: 0x00021890
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2x3(float2x3 v)
		{
			this.c0 = v.c0;
			this.c1 = v.c1;
			this.c2 = v.c2;
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x000236C5 File Offset: 0x000218C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x3(double v)
		{
			return new double2x3(v);
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x000236CD File Offset: 0x000218CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double2x3(bool v)
		{
			return new double2x3(v);
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x000236D5 File Offset: 0x000218D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double2x3(bool2x3 v)
		{
			return new double2x3(v);
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x000236DD File Offset: 0x000218DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x3(int v)
		{
			return new double2x3(v);
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x000236E5 File Offset: 0x000218E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x3(int2x3 v)
		{
			return new double2x3(v);
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x000236ED File Offset: 0x000218ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x3(uint v)
		{
			return new double2x3(v);
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x000236F5 File Offset: 0x000218F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x3(uint2x3 v)
		{
			return new double2x3(v);
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x000236FD File Offset: 0x000218FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x3(float v)
		{
			return new double2x3(v);
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x00023705 File Offset: 0x00021905
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2x3(float2x3 v)
		{
			return new double2x3(v);
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0002370D File Offset: 0x0002190D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator *(double2x3 lhs, double2x3 rhs)
		{
			return new double2x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x00023747 File Offset: 0x00021947
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator *(double2x3 lhs, double rhs)
		{
			return new double2x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x00023772 File Offset: 0x00021972
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator *(double lhs, double2x3 rhs)
		{
			return new double2x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0002379D File Offset: 0x0002199D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator +(double2x3 lhs, double2x3 rhs)
		{
			return new double2x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x000237D7 File Offset: 0x000219D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator +(double2x3 lhs, double rhs)
		{
			return new double2x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x00023802 File Offset: 0x00021A02
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator +(double lhs, double2x3 rhs)
		{
			return new double2x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0002382D File Offset: 0x00021A2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator -(double2x3 lhs, double2x3 rhs)
		{
			return new double2x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00023867 File Offset: 0x00021A67
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator -(double2x3 lhs, double rhs)
		{
			return new double2x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x00023892 File Offset: 0x00021A92
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator -(double lhs, double2x3 rhs)
		{
			return new double2x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x000238BD File Offset: 0x00021ABD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator /(double2x3 lhs, double2x3 rhs)
		{
			return new double2x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x000238F7 File Offset: 0x00021AF7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator /(double2x3 lhs, double rhs)
		{
			return new double2x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x00023922 File Offset: 0x00021B22
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator /(double lhs, double2x3 rhs)
		{
			return new double2x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0002394D File Offset: 0x00021B4D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator %(double2x3 lhs, double2x3 rhs)
		{
			return new double2x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x00023987 File Offset: 0x00021B87
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator %(double2x3 lhs, double rhs)
		{
			return new double2x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x000239B2 File Offset: 0x00021BB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator %(double lhs, double2x3 rhs)
		{
			return new double2x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x000239E0 File Offset: 0x00021BE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator ++(double2x3 val)
		{
			double2 @double = ++val.c0;
			val.c0 = @double;
			double2 double2 = @double;
			@double = ++val.c1;
			val.c1 = @double;
			double2 double3 = @double;
			@double = ++val.c2;
			val.c2 = @double;
			return new double2x3(double2, double3, @double);
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x00023A40 File Offset: 0x00021C40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator --(double2x3 val)
		{
			double2 @double = --val.c0;
			val.c0 = @double;
			double2 double2 = @double;
			@double = --val.c1;
			val.c1 = @double;
			double2 double3 = @double;
			@double = --val.c2;
			val.c2 = @double;
			return new double2x3(double2, double3, @double);
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x00023AA0 File Offset: 0x00021CA0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(double2x3 lhs, double2x3 rhs)
		{
			return new bool2x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x00023ADA File Offset: 0x00021CDA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(double2x3 lhs, double rhs)
		{
			return new bool2x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x00023B05 File Offset: 0x00021D05
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(double lhs, double2x3 rhs)
		{
			return new bool2x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x00023B30 File Offset: 0x00021D30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(double2x3 lhs, double2x3 rhs)
		{
			return new bool2x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x00023B6A File Offset: 0x00021D6A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(double2x3 lhs, double rhs)
		{
			return new bool2x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x00023B95 File Offset: 0x00021D95
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(double lhs, double2x3 rhs)
		{
			return new bool2x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x00023BC0 File Offset: 0x00021DC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(double2x3 lhs, double2x3 rhs)
		{
			return new bool2x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x00023BFA File Offset: 0x00021DFA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(double2x3 lhs, double rhs)
		{
			return new bool2x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x00023C25 File Offset: 0x00021E25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(double lhs, double2x3 rhs)
		{
			return new bool2x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x00023C50 File Offset: 0x00021E50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(double2x3 lhs, double2x3 rhs)
		{
			return new bool2x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x00023C8A File Offset: 0x00021E8A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(double2x3 lhs, double rhs)
		{
			return new bool2x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x00023CB5 File Offset: 0x00021EB5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(double lhs, double2x3 rhs)
		{
			return new bool2x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x00023CE0 File Offset: 0x00021EE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator -(double2x3 val)
		{
			return new double2x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x00023D08 File Offset: 0x00021F08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2x3 operator +(double2x3 val)
		{
			return new double2x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x00023D30 File Offset: 0x00021F30
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(double2x3 lhs, double2x3 rhs)
		{
			return new bool2x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x00023D6A File Offset: 0x00021F6A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(double2x3 lhs, double rhs)
		{
			return new bool2x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x00023D95 File Offset: 0x00021F95
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(double lhs, double2x3 rhs)
		{
			return new bool2x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x00023DC0 File Offset: 0x00021FC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(double2x3 lhs, double2x3 rhs)
		{
			return new bool2x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x00023DFA File Offset: 0x00021FFA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(double2x3 lhs, double rhs)
		{
			return new bool2x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x00023E25 File Offset: 0x00022025
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(double lhs, double2x3 rhs)
		{
			return new bool2x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x1700020C RID: 524
		public unsafe double2 this[int index]
		{
			get
			{
				fixed (double2x3* ptr = &this)
				{
					return ref *(double2*)(ptr + (IntPtr)index * (IntPtr)sizeof(double2) / (IntPtr)sizeof(double2x3));
				}
			}
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x00023E6B File Offset: 0x0002206B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(double2x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x00023EA8 File Offset: 0x000220A8
		public override bool Equals(object o)
		{
			if (o is double2x3)
			{
				double2x3 rhs = (double2x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x00023ECD File Offset: 0x000220CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x00023EDC File Offset: 0x000220DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("double2x3({0}, {1}, {2},  {3}, {4}, {5})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y
			});
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x00023F6C File Offset: 0x0002216C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("double2x3({0}, {1}, {2},  {3}, {4}, {5})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider)
			});
		}

		// Token: 0x04000042 RID: 66
		public double2 c0;

		// Token: 0x04000043 RID: 67
		public double2 c1;

		// Token: 0x04000044 RID: 68
		public double2 c2;

		// Token: 0x04000045 RID: 69
		public static readonly double2x3 zero;
	}
}
