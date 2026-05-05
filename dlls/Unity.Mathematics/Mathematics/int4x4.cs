using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000038 RID: 56
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int4x4 : IEquatable<int4x4>, IFormattable
	{
		// Token: 0x06001D93 RID: 7571 RVA: 0x0004FF5D File Offset: 0x0004E15D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(int4 c0, int4 c1, int4 c2, int4 c3)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
			this.c3 = c3;
		}

		// Token: 0x06001D94 RID: 7572 RVA: 0x0004FF7C File Offset: 0x0004E17C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(int m00, int m01, int m02, int m03, int m10, int m11, int m12, int m13, int m20, int m21, int m22, int m23, int m30, int m31, int m32, int m33)
		{
			this.c0 = new int4(m00, m10, m20, m30);
			this.c1 = new int4(m01, m11, m21, m31);
			this.c2 = new int4(m02, m12, m22, m32);
			this.c3 = new int4(m03, m13, m23, m33);
		}

		// Token: 0x06001D95 RID: 7573 RVA: 0x0004FFD2 File Offset: 0x0004E1D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06001D96 RID: 7574 RVA: 0x00050004 File Offset: 0x0004E204
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(bool v)
		{
			this.c0 = math.select(new int4(0), new int4(1), v);
			this.c1 = math.select(new int4(0), new int4(1), v);
			this.c2 = math.select(new int4(0), new int4(1), v);
			this.c3 = math.select(new int4(0), new int4(1), v);
		}

		// Token: 0x06001D97 RID: 7575 RVA: 0x00050074 File Offset: 0x0004E274
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(bool4x4 v)
		{
			this.c0 = math.select(new int4(0), new int4(1), v.c0);
			this.c1 = math.select(new int4(0), new int4(1), v.c1);
			this.c2 = math.select(new int4(0), new int4(1), v.c2);
			this.c3 = math.select(new int4(0), new int4(1), v.c3);
		}

		// Token: 0x06001D98 RID: 7576 RVA: 0x000500F5 File Offset: 0x0004E2F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(uint v)
		{
			this.c0 = (int4)v;
			this.c1 = (int4)v;
			this.c2 = (int4)v;
			this.c3 = (int4)v;
		}

		// Token: 0x06001D99 RID: 7577 RVA: 0x00050128 File Offset: 0x0004E328
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(uint4x4 v)
		{
			this.c0 = (int4)v.c0;
			this.c1 = (int4)v.c1;
			this.c2 = (int4)v.c2;
			this.c3 = (int4)v.c3;
		}

		// Token: 0x06001D9A RID: 7578 RVA: 0x00050179 File Offset: 0x0004E379
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(float v)
		{
			this.c0 = (int4)v;
			this.c1 = (int4)v;
			this.c2 = (int4)v;
			this.c3 = (int4)v;
		}

		// Token: 0x06001D9B RID: 7579 RVA: 0x000501AC File Offset: 0x0004E3AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(float4x4 v)
		{
			this.c0 = (int4)v.c0;
			this.c1 = (int4)v.c1;
			this.c2 = (int4)v.c2;
			this.c3 = (int4)v.c3;
		}

		// Token: 0x06001D9C RID: 7580 RVA: 0x000501FD File Offset: 0x0004E3FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(double v)
		{
			this.c0 = (int4)v;
			this.c1 = (int4)v;
			this.c2 = (int4)v;
			this.c3 = (int4)v;
		}

		// Token: 0x06001D9D RID: 7581 RVA: 0x00050230 File Offset: 0x0004E430
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x4(double4x4 v)
		{
			this.c0 = (int4)v.c0;
			this.c1 = (int4)v.c1;
			this.c2 = (int4)v.c2;
			this.c3 = (int4)v.c3;
		}

		// Token: 0x06001D9E RID: 7582 RVA: 0x00050281 File Offset: 0x0004E481
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int4x4(int v)
		{
			return new int4x4(v);
		}

		// Token: 0x06001D9F RID: 7583 RVA: 0x00050289 File Offset: 0x0004E489
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x4(bool v)
		{
			return new int4x4(v);
		}

		// Token: 0x06001DA0 RID: 7584 RVA: 0x00050291 File Offset: 0x0004E491
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x4(bool4x4 v)
		{
			return new int4x4(v);
		}

		// Token: 0x06001DA1 RID: 7585 RVA: 0x00050299 File Offset: 0x0004E499
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x4(uint v)
		{
			return new int4x4(v);
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x000502A1 File Offset: 0x0004E4A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x4(uint4x4 v)
		{
			return new int4x4(v);
		}

		// Token: 0x06001DA3 RID: 7587 RVA: 0x000502A9 File Offset: 0x0004E4A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x4(float v)
		{
			return new int4x4(v);
		}

		// Token: 0x06001DA4 RID: 7588 RVA: 0x000502B1 File Offset: 0x0004E4B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x4(float4x4 v)
		{
			return new int4x4(v);
		}

		// Token: 0x06001DA5 RID: 7589 RVA: 0x000502B9 File Offset: 0x0004E4B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x4(double v)
		{
			return new int4x4(v);
		}

		// Token: 0x06001DA6 RID: 7590 RVA: 0x000502C1 File Offset: 0x0004E4C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x4(double4x4 v)
		{
			return new int4x4(v);
		}

		// Token: 0x06001DA7 RID: 7591 RVA: 0x000502CC File Offset: 0x0004E4CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator *(int4x4 lhs, int4x4 rhs)
		{
			return new int4x4(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3);
		}

		// Token: 0x06001DA8 RID: 7592 RVA: 0x00050322 File Offset: 0x0004E522
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator *(int4x4 lhs, int rhs)
		{
			return new int4x4(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs, lhs.c3 * rhs);
		}

		// Token: 0x06001DA9 RID: 7593 RVA: 0x00050359 File Offset: 0x0004E559
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator *(int lhs, int4x4 rhs)
		{
			return new int4x4(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3);
		}

		// Token: 0x06001DAA RID: 7594 RVA: 0x00050390 File Offset: 0x0004E590
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator +(int4x4 lhs, int4x4 rhs)
		{
			return new int4x4(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3);
		}

		// Token: 0x06001DAB RID: 7595 RVA: 0x000503E6 File Offset: 0x0004E5E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator +(int4x4 lhs, int rhs)
		{
			return new int4x4(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs, lhs.c3 + rhs);
		}

		// Token: 0x06001DAC RID: 7596 RVA: 0x0005041D File Offset: 0x0004E61D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator +(int lhs, int4x4 rhs)
		{
			return new int4x4(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2, lhs + rhs.c3);
		}

		// Token: 0x06001DAD RID: 7597 RVA: 0x00050454 File Offset: 0x0004E654
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator -(int4x4 lhs, int4x4 rhs)
		{
			return new int4x4(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3);
		}

		// Token: 0x06001DAE RID: 7598 RVA: 0x000504AA File Offset: 0x0004E6AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator -(int4x4 lhs, int rhs)
		{
			return new int4x4(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs, lhs.c3 - rhs);
		}

		// Token: 0x06001DAF RID: 7599 RVA: 0x000504E1 File Offset: 0x0004E6E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator -(int lhs, int4x4 rhs)
		{
			return new int4x4(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2, lhs - rhs.c3);
		}

		// Token: 0x06001DB0 RID: 7600 RVA: 0x00050518 File Offset: 0x0004E718
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator /(int4x4 lhs, int4x4 rhs)
		{
			return new int4x4(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3);
		}

		// Token: 0x06001DB1 RID: 7601 RVA: 0x0005056E File Offset: 0x0004E76E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator /(int4x4 lhs, int rhs)
		{
			return new int4x4(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs);
		}

		// Token: 0x06001DB2 RID: 7602 RVA: 0x000505A5 File Offset: 0x0004E7A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator /(int lhs, int4x4 rhs)
		{
			return new int4x4(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2, lhs / rhs.c3);
		}

		// Token: 0x06001DB3 RID: 7603 RVA: 0x000505DC File Offset: 0x0004E7DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator %(int4x4 lhs, int4x4 rhs)
		{
			return new int4x4(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3);
		}

		// Token: 0x06001DB4 RID: 7604 RVA: 0x00050632 File Offset: 0x0004E832
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator %(int4x4 lhs, int rhs)
		{
			return new int4x4(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs);
		}

		// Token: 0x06001DB5 RID: 7605 RVA: 0x00050669 File Offset: 0x0004E869
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator %(int lhs, int4x4 rhs)
		{
			return new int4x4(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2, lhs % rhs.c3);
		}

		// Token: 0x06001DB6 RID: 7606 RVA: 0x000506A0 File Offset: 0x0004E8A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator ++(int4x4 val)
		{
			int4 @int = ++val.c0;
			val.c0 = @int;
			int4 int2 = @int;
			@int = ++val.c1;
			val.c1 = @int;
			int4 int3 = @int;
			@int = ++val.c2;
			val.c2 = @int;
			int4 int4 = @int;
			@int = ++val.c3;
			val.c3 = @int;
			return new int4x4(int2, int3, int4, @int);
		}

		// Token: 0x06001DB7 RID: 7607 RVA: 0x0005071C File Offset: 0x0004E91C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator --(int4x4 val)
		{
			int4 @int = --val.c0;
			val.c0 = @int;
			int4 int2 = @int;
			@int = --val.c1;
			val.c1 = @int;
			int4 int3 = @int;
			@int = --val.c2;
			val.c2 = @int;
			int4 int4 = @int;
			@int = --val.c3;
			val.c3 = @int;
			return new int4x4(int2, int3, int4, @int);
		}

		// Token: 0x06001DB8 RID: 7608 RVA: 0x00050798 File Offset: 0x0004E998
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <(int4x4 lhs, int4x4 rhs)
		{
			return new bool4x4(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3);
		}

		// Token: 0x06001DB9 RID: 7609 RVA: 0x000507EE File Offset: 0x0004E9EE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <(int4x4 lhs, int rhs)
		{
			return new bool4x4(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs, lhs.c3 < rhs);
		}

		// Token: 0x06001DBA RID: 7610 RVA: 0x00050825 File Offset: 0x0004EA25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <(int lhs, int4x4 rhs)
		{
			return new bool4x4(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2, lhs < rhs.c3);
		}

		// Token: 0x06001DBB RID: 7611 RVA: 0x0005085C File Offset: 0x0004EA5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <=(int4x4 lhs, int4x4 rhs)
		{
			return new bool4x4(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3);
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x000508B2 File Offset: 0x0004EAB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <=(int4x4 lhs, int rhs)
		{
			return new bool4x4(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs, lhs.c3 <= rhs);
		}

		// Token: 0x06001DBD RID: 7613 RVA: 0x000508E9 File Offset: 0x0004EAE9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <=(int lhs, int4x4 rhs)
		{
			return new bool4x4(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2, lhs <= rhs.c3);
		}

		// Token: 0x06001DBE RID: 7614 RVA: 0x00050920 File Offset: 0x0004EB20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >(int4x4 lhs, int4x4 rhs)
		{
			return new bool4x4(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3);
		}

		// Token: 0x06001DBF RID: 7615 RVA: 0x00050976 File Offset: 0x0004EB76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >(int4x4 lhs, int rhs)
		{
			return new bool4x4(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs, lhs.c3 > rhs);
		}

		// Token: 0x06001DC0 RID: 7616 RVA: 0x000509AD File Offset: 0x0004EBAD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >(int lhs, int4x4 rhs)
		{
			return new bool4x4(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2, lhs > rhs.c3);
		}

		// Token: 0x06001DC1 RID: 7617 RVA: 0x000509E4 File Offset: 0x0004EBE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >=(int4x4 lhs, int4x4 rhs)
		{
			return new bool4x4(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3);
		}

		// Token: 0x06001DC2 RID: 7618 RVA: 0x00050A3A File Offset: 0x0004EC3A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >=(int4x4 lhs, int rhs)
		{
			return new bool4x4(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs, lhs.c3 >= rhs);
		}

		// Token: 0x06001DC3 RID: 7619 RVA: 0x00050A71 File Offset: 0x0004EC71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >=(int lhs, int4x4 rhs)
		{
			return new bool4x4(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2, lhs >= rhs.c3);
		}

		// Token: 0x06001DC4 RID: 7620 RVA: 0x00050AA8 File Offset: 0x0004ECA8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator -(int4x4 val)
		{
			return new int4x4(-val.c0, -val.c1, -val.c2, -val.c3);
		}

		// Token: 0x06001DC5 RID: 7621 RVA: 0x00050ADB File Offset: 0x0004ECDB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator +(int4x4 val)
		{
			return new int4x4(+val.c0, +val.c1, +val.c2, +val.c3);
		}

		// Token: 0x06001DC6 RID: 7622 RVA: 0x00050B0E File Offset: 0x0004ED0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator <<(int4x4 x, int n)
		{
			return new int4x4(x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n);
		}

		// Token: 0x06001DC7 RID: 7623 RVA: 0x00050B45 File Offset: 0x0004ED45
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator >>(int4x4 x, int n)
		{
			return new int4x4(x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n);
		}

		// Token: 0x06001DC8 RID: 7624 RVA: 0x00050B7C File Offset: 0x0004ED7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator ==(int4x4 lhs, int4x4 rhs)
		{
			return new bool4x4(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);
		}

		// Token: 0x06001DC9 RID: 7625 RVA: 0x00050BD2 File Offset: 0x0004EDD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator ==(int4x4 lhs, int rhs)
		{
			return new bool4x4(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs);
		}

		// Token: 0x06001DCA RID: 7626 RVA: 0x00050C09 File Offset: 0x0004EE09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator ==(int lhs, int4x4 rhs)
		{
			return new bool4x4(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3);
		}

		// Token: 0x06001DCB RID: 7627 RVA: 0x00050C40 File Offset: 0x0004EE40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator !=(int4x4 lhs, int4x4 rhs)
		{
			return new bool4x4(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);
		}

		// Token: 0x06001DCC RID: 7628 RVA: 0x00050C96 File Offset: 0x0004EE96
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator !=(int4x4 lhs, int rhs)
		{
			return new bool4x4(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs);
		}

		// Token: 0x06001DCD RID: 7629 RVA: 0x00050CCD File Offset: 0x0004EECD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator !=(int lhs, int4x4 rhs)
		{
			return new bool4x4(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3);
		}

		// Token: 0x06001DCE RID: 7630 RVA: 0x00050D04 File Offset: 0x0004EF04
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator ~(int4x4 val)
		{
			return new int4x4(~val.c0, ~val.c1, ~val.c2, ~val.c3);
		}

		// Token: 0x06001DCF RID: 7631 RVA: 0x00050D38 File Offset: 0x0004EF38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator &(int4x4 lhs, int4x4 rhs)
		{
			return new int4x4(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2, lhs.c3 & rhs.c3);
		}

		// Token: 0x06001DD0 RID: 7632 RVA: 0x00050D8E File Offset: 0x0004EF8E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator &(int4x4 lhs, int rhs)
		{
			return new int4x4(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs, lhs.c3 & rhs);
		}

		// Token: 0x06001DD1 RID: 7633 RVA: 0x00050DC5 File Offset: 0x0004EFC5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator &(int lhs, int4x4 rhs)
		{
			return new int4x4(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2, lhs & rhs.c3);
		}

		// Token: 0x06001DD2 RID: 7634 RVA: 0x00050DFC File Offset: 0x0004EFFC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator |(int4x4 lhs, int4x4 rhs)
		{
			return new int4x4(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2, lhs.c3 | rhs.c3);
		}

		// Token: 0x06001DD3 RID: 7635 RVA: 0x00050E52 File Offset: 0x0004F052
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator |(int4x4 lhs, int rhs)
		{
			return new int4x4(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs, lhs.c3 | rhs);
		}

		// Token: 0x06001DD4 RID: 7636 RVA: 0x00050E89 File Offset: 0x0004F089
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator |(int lhs, int4x4 rhs)
		{
			return new int4x4(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2, lhs | rhs.c3);
		}

		// Token: 0x06001DD5 RID: 7637 RVA: 0x00050EC0 File Offset: 0x0004F0C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator ^(int4x4 lhs, int4x4 rhs)
		{
			return new int4x4(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2, lhs.c3 ^ rhs.c3);
		}

		// Token: 0x06001DD6 RID: 7638 RVA: 0x00050F16 File Offset: 0x0004F116
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator ^(int4x4 lhs, int rhs)
		{
			return new int4x4(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs, lhs.c3 ^ rhs);
		}

		// Token: 0x06001DD7 RID: 7639 RVA: 0x00050F4D File Offset: 0x0004F14D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x4 operator ^(int lhs, int4x4 rhs)
		{
			return new int4x4(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2, lhs ^ rhs.c3);
		}

		// Token: 0x1700099C RID: 2460
		public unsafe int4 this[int index]
		{
			get
			{
				fixed (int4x4* ptr = &this)
				{
					return ref *(int4*)(ptr + (IntPtr)index * (IntPtr)sizeof(int4) / (IntPtr)sizeof(int4x4));
				}
			}
		}

		// Token: 0x06001DD9 RID: 7641 RVA: 0x00050FA0 File Offset: 0x0004F1A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int4x4 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2) && this.c3.Equals(rhs.c3);
		}

		// Token: 0x06001DDA RID: 7642 RVA: 0x00050FFC File Offset: 0x0004F1FC
		public override bool Equals(object o)
		{
			if (o is int4x4)
			{
				int4x4 rhs = (int4x4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001DDB RID: 7643 RVA: 0x00051021 File Offset: 0x0004F221
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001DDC RID: 7644 RVA: 0x00051030 File Offset: 0x0004F230
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int4x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7},  {8}, {9}, {10}, {11},  {12}, {13}, {14}, {15})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c3.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c3.y,
				this.c0.z,
				this.c1.z,
				this.c2.z,
				this.c3.z,
				this.c0.w,
				this.c1.w,
				this.c2.w,
				this.c3.w
			});
		}

		// Token: 0x06001DDD RID: 7645 RVA: 0x00051188 File Offset: 0x0004F388
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int4x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7},  {8}, {9}, {10}, {11},  {12}, {13}, {14}, {15})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c3.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider),
				this.c3.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c2.z.ToString(format, formatProvider),
				this.c3.z.ToString(format, formatProvider),
				this.c0.w.ToString(format, formatProvider),
				this.c1.w.ToString(format, formatProvider),
				this.c2.w.ToString(format, formatProvider),
				this.c3.w.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000DC RID: 220
		public int4 c0;

		// Token: 0x040000DD RID: 221
		public int4 c1;

		// Token: 0x040000DE RID: 222
		public int4 c2;

		// Token: 0x040000DF RID: 223
		public int4 c3;

		// Token: 0x040000E0 RID: 224
		public static readonly int4x4 identity = new int4x4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

		// Token: 0x040000E1 RID: 225
		public static readonly int4x4 zero;
	}
}
