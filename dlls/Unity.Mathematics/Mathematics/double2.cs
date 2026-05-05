using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000011 RID: 17
	[DebuggerTypeProxy(typeof(double2.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct double2 : IEquatable<double2>, IFormattable
	{
		// Token: 0x06000ADA RID: 2778 RVA: 0x00022101 File Offset: 0x00020301
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x00022111 File Offset: 0x00020311
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(double2 xy)
		{
			this.x = xy.x;
			this.y = xy.y;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x0002212B File Offset: 0x0002032B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(double v)
		{
			this.x = v;
			this.y = v;
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0002213B File Offset: 0x0002033B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(bool v)
		{
			this.x = (v ? 1.0 : 0.0);
			this.y = (v ? 1.0 : 0.0);
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x00022178 File Offset: 0x00020378
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(bool2 v)
		{
			this.x = (v.x ? 1.0 : 0.0);
			this.y = (v.y ? 1.0 : 0.0);
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x000221C9 File Offset: 0x000203C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(int v)
		{
			this.x = (double)v;
			this.y = (double)v;
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x000221DB File Offset: 0x000203DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(int2 v)
		{
			this.x = (double)v.x;
			this.y = (double)v.y;
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x000221F7 File Offset: 0x000203F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(uint v)
		{
			this.x = v;
			this.y = v;
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0002220B File Offset: 0x0002040B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(uint2 v)
		{
			this.x = v.x;
			this.y = v.y;
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00022229 File Offset: 0x00020429
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(half v)
		{
			this.x = v;
			this.y = v;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x00022243 File Offset: 0x00020443
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(half2 v)
		{
			this.x = v.x;
			this.y = v.y;
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x00022267 File Offset: 0x00020467
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(float v)
		{
			this.x = (double)v;
			this.y = (double)v;
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00022279 File Offset: 0x00020479
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double2(float2 v)
		{
			this.x = (double)v.x;
			this.y = (double)v.y;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x00022295 File Offset: 0x00020495
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2(double v)
		{
			return new double2(v);
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0002229D File Offset: 0x0002049D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double2(bool v)
		{
			return new double2(v);
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x000222A5 File Offset: 0x000204A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator double2(bool2 v)
		{
			return new double2(v);
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x000222AD File Offset: 0x000204AD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2(int v)
		{
			return new double2(v);
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x000222B5 File Offset: 0x000204B5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2(int2 v)
		{
			return new double2(v);
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x000222BD File Offset: 0x000204BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2(uint v)
		{
			return new double2(v);
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x000222C5 File Offset: 0x000204C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2(uint2 v)
		{
			return new double2(v);
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x000222CD File Offset: 0x000204CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2(half v)
		{
			return new double2(v);
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x000222D5 File Offset: 0x000204D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2(half2 v)
		{
			return new double2(v);
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x000222DD File Offset: 0x000204DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2(float v)
		{
			return new double2(v);
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x000222E5 File Offset: 0x000204E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2(float2 v)
		{
			return new double2(v);
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x000222ED File Offset: 0x000204ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator *(double2 lhs, double2 rhs)
		{
			return new double2(lhs.x * rhs.x, lhs.y * rhs.y);
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0002230E File Offset: 0x0002050E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator *(double2 lhs, double rhs)
		{
			return new double2(lhs.x * rhs, lhs.y * rhs);
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x00022325 File Offset: 0x00020525
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator *(double lhs, double2 rhs)
		{
			return new double2(lhs * rhs.x, lhs * rhs.y);
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0002233C File Offset: 0x0002053C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator +(double2 lhs, double2 rhs)
		{
			return new double2(lhs.x + rhs.x, lhs.y + rhs.y);
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0002235D File Offset: 0x0002055D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator +(double2 lhs, double rhs)
		{
			return new double2(lhs.x + rhs, lhs.y + rhs);
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x00022374 File Offset: 0x00020574
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator +(double lhs, double2 rhs)
		{
			return new double2(lhs + rhs.x, lhs + rhs.y);
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0002238B File Offset: 0x0002058B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator -(double2 lhs, double2 rhs)
		{
			return new double2(lhs.x - rhs.x, lhs.y - rhs.y);
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x000223AC File Offset: 0x000205AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator -(double2 lhs, double rhs)
		{
			return new double2(lhs.x - rhs, lhs.y - rhs);
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x000223C3 File Offset: 0x000205C3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator -(double lhs, double2 rhs)
		{
			return new double2(lhs - rhs.x, lhs - rhs.y);
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x000223DA File Offset: 0x000205DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator /(double2 lhs, double2 rhs)
		{
			return new double2(lhs.x / rhs.x, lhs.y / rhs.y);
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x000223FB File Offset: 0x000205FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator /(double2 lhs, double rhs)
		{
			return new double2(lhs.x / rhs, lhs.y / rhs);
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x00022412 File Offset: 0x00020612
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator /(double lhs, double2 rhs)
		{
			return new double2(lhs / rhs.x, lhs / rhs.y);
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00022429 File Offset: 0x00020629
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator %(double2 lhs, double2 rhs)
		{
			return new double2(lhs.x % rhs.x, lhs.y % rhs.y);
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0002244A File Offset: 0x0002064A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator %(double2 lhs, double rhs)
		{
			return new double2(lhs.x % rhs, lhs.y % rhs);
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x00022461 File Offset: 0x00020661
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator %(double lhs, double2 rhs)
		{
			return new double2(lhs % rhs.x, lhs % rhs.y);
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x00022478 File Offset: 0x00020678
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator ++(double2 val)
		{
			double num = val.x + 1.0;
			val.x = num;
			double num2 = num;
			num = val.y + 1.0;
			val.y = num;
			return new double2(num2, num);
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x000224B8 File Offset: 0x000206B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator --(double2 val)
		{
			double num = val.x - 1.0;
			val.x = num;
			double num2 = num;
			num = val.y - 1.0;
			val.y = num;
			return new double2(num2, num);
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x000224F8 File Offset: 0x000206F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(double2 lhs, double2 rhs)
		{
			return new bool2(lhs.x < rhs.x, lhs.y < rhs.y);
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x0002251B File Offset: 0x0002071B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(double2 lhs, double rhs)
		{
			return new bool2(lhs.x < rhs, lhs.y < rhs);
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x00022534 File Offset: 0x00020734
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(double lhs, double2 rhs)
		{
			return new bool2(lhs < rhs.x, lhs < rhs.y);
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0002254D File Offset: 0x0002074D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(double2 lhs, double2 rhs)
		{
			return new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00022576 File Offset: 0x00020776
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(double2 lhs, double rhs)
		{
			return new bool2(lhs.x <= rhs, lhs.y <= rhs);
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00022595 File Offset: 0x00020795
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(double lhs, double2 rhs)
		{
			return new bool2(lhs <= rhs.x, lhs <= rhs.y);
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x000225B4 File Offset: 0x000207B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(double2 lhs, double2 rhs)
		{
			return new bool2(lhs.x > rhs.x, lhs.y > rhs.y);
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x000225D7 File Offset: 0x000207D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(double2 lhs, double rhs)
		{
			return new bool2(lhs.x > rhs, lhs.y > rhs);
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x000225F0 File Offset: 0x000207F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(double lhs, double2 rhs)
		{
			return new bool2(lhs > rhs.x, lhs > rhs.y);
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x00022609 File Offset: 0x00020809
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(double2 lhs, double2 rhs)
		{
			return new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x00022632 File Offset: 0x00020832
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(double2 lhs, double rhs)
		{
			return new bool2(lhs.x >= rhs, lhs.y >= rhs);
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x00022651 File Offset: 0x00020851
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(double lhs, double2 rhs)
		{
			return new bool2(lhs >= rhs.x, lhs >= rhs.y);
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x00022670 File Offset: 0x00020870
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator -(double2 val)
		{
			return new double2(-val.x, -val.y);
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x00022685 File Offset: 0x00020885
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 operator +(double2 val)
		{
			return new double2(val.x, val.y);
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x00022698 File Offset: 0x00020898
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(double2 lhs, double2 rhs)
		{
			return new bool2(lhs.x == rhs.x, lhs.y == rhs.y);
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x000226BB File Offset: 0x000208BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(double2 lhs, double rhs)
		{
			return new bool2(lhs.x == rhs, lhs.y == rhs);
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x000226D4 File Offset: 0x000208D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(double lhs, double2 rhs)
		{
			return new bool2(lhs == rhs.x, lhs == rhs.y);
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x000226ED File Offset: 0x000208ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(double2 lhs, double2 rhs)
		{
			return new bool2(lhs.x != rhs.x, lhs.y != rhs.y);
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x00022716 File Offset: 0x00020916
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(double2 lhs, double rhs)
		{
			return new bool2(lhs.x != rhs, lhs.y != rhs);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x00022735 File Offset: 0x00020935
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(double lhs, double2 rhs)
		{
			return new bool2(lhs != rhs.x, lhs != rhs.y);
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000B17 RID: 2839 RVA: 0x00022754 File Offset: 0x00020954
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000B18 RID: 2840 RVA: 0x00022773 File Offset: 0x00020973
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000B19 RID: 2841 RVA: 0x00022792 File Offset: 0x00020992
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000B1A RID: 2842 RVA: 0x000227B1 File Offset: 0x000209B1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x000227D0 File Offset: 0x000209D0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000B1C RID: 2844 RVA: 0x000227EF File Offset: 0x000209EF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000B1D RID: 2845 RVA: 0x0002280E File Offset: 0x00020A0E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000B1E RID: 2846 RVA: 0x0002282D File Offset: 0x00020A2D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000B1F RID: 2847 RVA: 0x0002284C File Offset: 0x00020A4C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000B20 RID: 2848 RVA: 0x0002286B File Offset: 0x00020A6B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000B21 RID: 2849 RVA: 0x0002288A File Offset: 0x00020A8A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000B22 RID: 2850 RVA: 0x000228A9 File Offset: 0x00020AA9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000B23 RID: 2851 RVA: 0x000228C8 File Offset: 0x00020AC8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000B24 RID: 2852 RVA: 0x000228E7 File Offset: 0x00020AE7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000B25 RID: 2853 RVA: 0x00022906 File Offset: 0x00020B06
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000B26 RID: 2854 RVA: 0x00022925 File Offset: 0x00020B25
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000B27 RID: 2855 RVA: 0x00022944 File Offset: 0x00020B44
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.x, this.x);
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000B28 RID: 2856 RVA: 0x0002295D File Offset: 0x00020B5D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.x, this.y);
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000B29 RID: 2857 RVA: 0x00022976 File Offset: 0x00020B76
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.y, this.x);
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000B2A RID: 2858 RVA: 0x0002298F File Offset: 0x00020B8F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.x, this.y, this.y);
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000B2B RID: 2859 RVA: 0x000229A8 File Offset: 0x00020BA8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.x, this.x);
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000B2C RID: 2860 RVA: 0x000229C1 File Offset: 0x00020BC1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.x, this.y);
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000B2D RID: 2861 RVA: 0x000229DA File Offset: 0x00020BDA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.y, this.x);
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000B2E RID: 2862 RVA: 0x000229F3 File Offset: 0x00020BF3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double3(this.y, this.y, this.y);
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000B2F RID: 2863 RVA: 0x00022A0C File Offset: 0x00020C0C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.x, this.x);
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000B30 RID: 2864 RVA: 0x00022A1F File Offset: 0x00020C1F
		// (set) Token: 0x06000B31 RID: 2865 RVA: 0x00022A32 File Offset: 0x00020C32
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

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000B32 RID: 2866 RVA: 0x00022A4C File Offset: 0x00020C4C
		// (set) Token: 0x06000B33 RID: 2867 RVA: 0x00022A5F File Offset: 0x00020C5F
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

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000B34 RID: 2868 RVA: 0x00022A79 File Offset: 0x00020C79
		[EditorBrowsable(EditorBrowsableState.Never)]
		public double2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new double2(this.y, this.y);
			}
		}

		// Token: 0x1700020A RID: 522
		public unsafe double this[int index]
		{
			get
			{
				fixed (double2* ptr = &this)
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

		// Token: 0x06000B37 RID: 2871 RVA: 0x00022AC4 File Offset: 0x00020CC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(double2 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x00022AE4 File Offset: 0x00020CE4
		public override bool Equals(object o)
		{
			if (o is double2)
			{
				double2 rhs = (double2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x00022B09 File Offset: 0x00020D09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x00022B16 File Offset: 0x00020D16
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("double2({0}, {1})", this.x, this.y);
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x00022B38 File Offset: 0x00020D38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("double2({0}, {1})", this.x.ToString(format, formatProvider), this.y.ToString(format, formatProvider));
		}

		// Token: 0x0400003B RID: 59
		public double x;

		// Token: 0x0400003C RID: 60
		public double y;

		// Token: 0x0400003D RID: 61
		public static readonly double2 zero;

		// Token: 0x02000057 RID: 87
		internal sealed class DebuggerProxy
		{
			// Token: 0x0600246C RID: 9324 RVA: 0x0006757C File Offset: 0x0006577C
			public DebuggerProxy(double2 v)
			{
				this.x = v.x;
				this.y = v.y;
			}

			// Token: 0x04000143 RID: 323
			public double x;

			// Token: 0x04000144 RID: 324
			public double y;
		}
	}
}
