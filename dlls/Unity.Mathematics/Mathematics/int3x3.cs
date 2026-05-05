using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000033 RID: 51
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int3x3 : IEquatable<int3x3>, IFormattable
	{
		// Token: 0x06001A88 RID: 6792 RVA: 0x0004869F File Offset: 0x0004689F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(int3 c0, int3 c1, int3 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x06001A89 RID: 6793 RVA: 0x000486B6 File Offset: 0x000468B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(int m00, int m01, int m02, int m10, int m11, int m12, int m20, int m21, int m22)
		{
			this.c0 = new int3(m00, m10, m20);
			this.c1 = new int3(m01, m11, m21);
			this.c2 = new int3(m02, m12, m22);
		}

		// Token: 0x06001A8A RID: 6794 RVA: 0x000486E8 File Offset: 0x000468E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06001A8B RID: 6795 RVA: 0x00048710 File Offset: 0x00046910
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(bool v)
		{
			this.c0 = math.select(new int3(0), new int3(1), v);
			this.c1 = math.select(new int3(0), new int3(1), v);
			this.c2 = math.select(new int3(0), new int3(1), v);
		}

		// Token: 0x06001A8C RID: 6796 RVA: 0x00048768 File Offset: 0x00046968
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(bool3x3 v)
		{
			this.c0 = math.select(new int3(0), new int3(1), v.c0);
			this.c1 = math.select(new int3(0), new int3(1), v.c1);
			this.c2 = math.select(new int3(0), new int3(1), v.c2);
		}

		// Token: 0x06001A8D RID: 6797 RVA: 0x000487CC File Offset: 0x000469CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(uint v)
		{
			this.c0 = (int3)v;
			this.c1 = (int3)v;
			this.c2 = (int3)v;
		}

		// Token: 0x06001A8E RID: 6798 RVA: 0x000487F2 File Offset: 0x000469F2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(uint3x3 v)
		{
			this.c0 = (int3)v.c0;
			this.c1 = (int3)v.c1;
			this.c2 = (int3)v.c2;
		}

		// Token: 0x06001A8F RID: 6799 RVA: 0x00048827 File Offset: 0x00046A27
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(float v)
		{
			this.c0 = (int3)v;
			this.c1 = (int3)v;
			this.c2 = (int3)v;
		}

		// Token: 0x06001A90 RID: 6800 RVA: 0x0004884D File Offset: 0x00046A4D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(float3x3 v)
		{
			this.c0 = (int3)v.c0;
			this.c1 = (int3)v.c1;
			this.c2 = (int3)v.c2;
		}

		// Token: 0x06001A91 RID: 6801 RVA: 0x00048882 File Offset: 0x00046A82
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(double v)
		{
			this.c0 = (int3)v;
			this.c1 = (int3)v;
			this.c2 = (int3)v;
		}

		// Token: 0x06001A92 RID: 6802 RVA: 0x000488A8 File Offset: 0x00046AA8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x3(double3x3 v)
		{
			this.c0 = (int3)v.c0;
			this.c1 = (int3)v.c1;
			this.c2 = (int3)v.c2;
		}

		// Token: 0x06001A93 RID: 6803 RVA: 0x000488DD File Offset: 0x00046ADD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int3x3(int v)
		{
			return new int3x3(v);
		}

		// Token: 0x06001A94 RID: 6804 RVA: 0x000488E5 File Offset: 0x00046AE5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x3(bool v)
		{
			return new int3x3(v);
		}

		// Token: 0x06001A95 RID: 6805 RVA: 0x000488ED File Offset: 0x00046AED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x3(bool3x3 v)
		{
			return new int3x3(v);
		}

		// Token: 0x06001A96 RID: 6806 RVA: 0x000488F5 File Offset: 0x00046AF5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x3(uint v)
		{
			return new int3x3(v);
		}

		// Token: 0x06001A97 RID: 6807 RVA: 0x000488FD File Offset: 0x00046AFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x3(uint3x3 v)
		{
			return new int3x3(v);
		}

		// Token: 0x06001A98 RID: 6808 RVA: 0x00048905 File Offset: 0x00046B05
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x3(float v)
		{
			return new int3x3(v);
		}

		// Token: 0x06001A99 RID: 6809 RVA: 0x0004890D File Offset: 0x00046B0D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x3(float3x3 v)
		{
			return new int3x3(v);
		}

		// Token: 0x06001A9A RID: 6810 RVA: 0x00048915 File Offset: 0x00046B15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x3(double v)
		{
			return new int3x3(v);
		}

		// Token: 0x06001A9B RID: 6811 RVA: 0x0004891D File Offset: 0x00046B1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x3(double3x3 v)
		{
			return new int3x3(v);
		}

		// Token: 0x06001A9C RID: 6812 RVA: 0x00048925 File Offset: 0x00046B25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator *(int3x3 lhs, int3x3 rhs)
		{
			return new int3x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x06001A9D RID: 6813 RVA: 0x0004895F File Offset: 0x00046B5F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator *(int3x3 lhs, int rhs)
		{
			return new int3x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x06001A9E RID: 6814 RVA: 0x0004898A File Offset: 0x00046B8A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator *(int lhs, int3x3 rhs)
		{
			return new int3x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x06001A9F RID: 6815 RVA: 0x000489B5 File Offset: 0x00046BB5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator +(int3x3 lhs, int3x3 rhs)
		{
			return new int3x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x06001AA0 RID: 6816 RVA: 0x000489EF File Offset: 0x00046BEF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator +(int3x3 lhs, int rhs)
		{
			return new int3x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x06001AA1 RID: 6817 RVA: 0x00048A1A File Offset: 0x00046C1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator +(int lhs, int3x3 rhs)
		{
			return new int3x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x06001AA2 RID: 6818 RVA: 0x00048A45 File Offset: 0x00046C45
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator -(int3x3 lhs, int3x3 rhs)
		{
			return new int3x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x06001AA3 RID: 6819 RVA: 0x00048A7F File Offset: 0x00046C7F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator -(int3x3 lhs, int rhs)
		{
			return new int3x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x06001AA4 RID: 6820 RVA: 0x00048AAA File Offset: 0x00046CAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator -(int lhs, int3x3 rhs)
		{
			return new int3x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x06001AA5 RID: 6821 RVA: 0x00048AD5 File Offset: 0x00046CD5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator /(int3x3 lhs, int3x3 rhs)
		{
			return new int3x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x06001AA6 RID: 6822 RVA: 0x00048B0F File Offset: 0x00046D0F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator /(int3x3 lhs, int rhs)
		{
			return new int3x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x00048B3A File Offset: 0x00046D3A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator /(int lhs, int3x3 rhs)
		{
			return new int3x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x00048B65 File Offset: 0x00046D65
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator %(int3x3 lhs, int3x3 rhs)
		{
			return new int3x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x06001AA9 RID: 6825 RVA: 0x00048B9F File Offset: 0x00046D9F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator %(int3x3 lhs, int rhs)
		{
			return new int3x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x06001AAA RID: 6826 RVA: 0x00048BCA File Offset: 0x00046DCA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator %(int lhs, int3x3 rhs)
		{
			return new int3x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x06001AAB RID: 6827 RVA: 0x00048BF8 File Offset: 0x00046DF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator ++(int3x3 val)
		{
			int3 @int = ++val.c0;
			val.c0 = @int;
			int3 int2 = @int;
			@int = ++val.c1;
			val.c1 = @int;
			int3 int3 = @int;
			@int = ++val.c2;
			val.c2 = @int;
			return new int3x3(int2, int3, @int);
		}

		// Token: 0x06001AAC RID: 6828 RVA: 0x00048C58 File Offset: 0x00046E58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator --(int3x3 val)
		{
			int3 @int = --val.c0;
			val.c0 = @int;
			int3 int2 = @int;
			@int = --val.c1;
			val.c1 = @int;
			int3 int3 = @int;
			@int = --val.c2;
			val.c2 = @int;
			return new int3x3(int2, int3, @int);
		}

		// Token: 0x06001AAD RID: 6829 RVA: 0x00048CB8 File Offset: 0x00046EB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(int3x3 lhs, int3x3 rhs)
		{
			return new bool3x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x06001AAE RID: 6830 RVA: 0x00048CF2 File Offset: 0x00046EF2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(int3x3 lhs, int rhs)
		{
			return new bool3x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x06001AAF RID: 6831 RVA: 0x00048D1D File Offset: 0x00046F1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(int lhs, int3x3 rhs)
		{
			return new bool3x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x06001AB0 RID: 6832 RVA: 0x00048D48 File Offset: 0x00046F48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(int3x3 lhs, int3x3 rhs)
		{
			return new bool3x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x06001AB1 RID: 6833 RVA: 0x00048D82 File Offset: 0x00046F82
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(int3x3 lhs, int rhs)
		{
			return new bool3x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x06001AB2 RID: 6834 RVA: 0x00048DAD File Offset: 0x00046FAD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(int lhs, int3x3 rhs)
		{
			return new bool3x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x06001AB3 RID: 6835 RVA: 0x00048DD8 File Offset: 0x00046FD8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(int3x3 lhs, int3x3 rhs)
		{
			return new bool3x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x06001AB4 RID: 6836 RVA: 0x00048E12 File Offset: 0x00047012
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(int3x3 lhs, int rhs)
		{
			return new bool3x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x06001AB5 RID: 6837 RVA: 0x00048E3D File Offset: 0x0004703D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(int lhs, int3x3 rhs)
		{
			return new bool3x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x06001AB6 RID: 6838 RVA: 0x00048E68 File Offset: 0x00047068
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(int3x3 lhs, int3x3 rhs)
		{
			return new bool3x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x06001AB7 RID: 6839 RVA: 0x00048EA2 File Offset: 0x000470A2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(int3x3 lhs, int rhs)
		{
			return new bool3x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x06001AB8 RID: 6840 RVA: 0x00048ECD File Offset: 0x000470CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(int lhs, int3x3 rhs)
		{
			return new bool3x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x06001AB9 RID: 6841 RVA: 0x00048EF8 File Offset: 0x000470F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator -(int3x3 val)
		{
			return new int3x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x06001ABA RID: 6842 RVA: 0x00048F20 File Offset: 0x00047120
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator +(int3x3 val)
		{
			return new int3x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x06001ABB RID: 6843 RVA: 0x00048F48 File Offset: 0x00047148
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator <<(int3x3 x, int n)
		{
			return new int3x3(x.c0 << n, x.c1 << n, x.c2 << n);
		}

		// Token: 0x06001ABC RID: 6844 RVA: 0x00048F73 File Offset: 0x00047173
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator >>(int3x3 x, int n)
		{
			return new int3x3(x.c0 >> n, x.c1 >> n, x.c2 >> n);
		}

		// Token: 0x06001ABD RID: 6845 RVA: 0x00048F9E File Offset: 0x0004719E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(int3x3 lhs, int3x3 rhs)
		{
			return new bool3x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x06001ABE RID: 6846 RVA: 0x00048FD8 File Offset: 0x000471D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(int3x3 lhs, int rhs)
		{
			return new bool3x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x06001ABF RID: 6847 RVA: 0x00049003 File Offset: 0x00047203
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(int lhs, int3x3 rhs)
		{
			return new bool3x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x06001AC0 RID: 6848 RVA: 0x0004902E File Offset: 0x0004722E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(int3x3 lhs, int3x3 rhs)
		{
			return new bool3x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x06001AC1 RID: 6849 RVA: 0x00049068 File Offset: 0x00047268
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(int3x3 lhs, int rhs)
		{
			return new bool3x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x06001AC2 RID: 6850 RVA: 0x00049093 File Offset: 0x00047293
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(int lhs, int3x3 rhs)
		{
			return new bool3x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x06001AC3 RID: 6851 RVA: 0x000490BE File Offset: 0x000472BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator ~(int3x3 val)
		{
			return new int3x3(~val.c0, ~val.c1, ~val.c2);
		}

		// Token: 0x06001AC4 RID: 6852 RVA: 0x000490E6 File Offset: 0x000472E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator &(int3x3 lhs, int3x3 rhs)
		{
			return new int3x3(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);
		}

		// Token: 0x06001AC5 RID: 6853 RVA: 0x00049120 File Offset: 0x00047320
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator &(int3x3 lhs, int rhs)
		{
			return new int3x3(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs);
		}

		// Token: 0x06001AC6 RID: 6854 RVA: 0x0004914B File Offset: 0x0004734B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator &(int lhs, int3x3 rhs)
		{
			return new int3x3(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2);
		}

		// Token: 0x06001AC7 RID: 6855 RVA: 0x00049176 File Offset: 0x00047376
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator |(int3x3 lhs, int3x3 rhs)
		{
			return new int3x3(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);
		}

		// Token: 0x06001AC8 RID: 6856 RVA: 0x000491B0 File Offset: 0x000473B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator |(int3x3 lhs, int rhs)
		{
			return new int3x3(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs);
		}

		// Token: 0x06001AC9 RID: 6857 RVA: 0x000491DB File Offset: 0x000473DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator |(int lhs, int3x3 rhs)
		{
			return new int3x3(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2);
		}

		// Token: 0x06001ACA RID: 6858 RVA: 0x00049206 File Offset: 0x00047406
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator ^(int3x3 lhs, int3x3 rhs)
		{
			return new int3x3(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);
		}

		// Token: 0x06001ACB RID: 6859 RVA: 0x00049240 File Offset: 0x00047440
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator ^(int3x3 lhs, int rhs)
		{
			return new int3x3(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs);
		}

		// Token: 0x06001ACC RID: 6860 RVA: 0x0004926B File Offset: 0x0004746B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x3 operator ^(int lhs, int3x3 rhs)
		{
			return new int3x3(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2);
		}

		// Token: 0x17000847 RID: 2119
		public unsafe int3 this[int index]
		{
			get
			{
				fixed (int3x3* ptr = &this)
				{
					return ref *(int3*)(ptr + (IntPtr)index * (IntPtr)sizeof(int3) / (IntPtr)sizeof(int3x3));
				}
			}
		}

		// Token: 0x06001ACE RID: 6862 RVA: 0x000492B3 File Offset: 0x000474B3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int3x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x06001ACF RID: 6863 RVA: 0x000492F0 File Offset: 0x000474F0
		public override bool Equals(object o)
		{
			if (o is int3x3)
			{
				int3x3 rhs = (int3x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001AD0 RID: 6864 RVA: 0x00049315 File Offset: 0x00047515
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001AD1 RID: 6865 RVA: 0x00049324 File Offset: 0x00047524
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", new object[]
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

		// Token: 0x06001AD2 RID: 6866 RVA: 0x000493F0 File Offset: 0x000475F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", new object[]
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

		// Token: 0x040000C6 RID: 198
		public int3 c0;

		// Token: 0x040000C7 RID: 199
		public int3 c1;

		// Token: 0x040000C8 RID: 200
		public int3 c2;

		// Token: 0x040000C9 RID: 201
		public static readonly int3x3 identity = new int3x3(1, 0, 0, 0, 1, 0, 0, 0, 1);

		// Token: 0x040000CA RID: 202
		public static readonly int3x3 zero;
	}
}
