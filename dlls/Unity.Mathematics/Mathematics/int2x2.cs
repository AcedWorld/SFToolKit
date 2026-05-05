using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200002E RID: 46
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int2x2 : IEquatable<int2x2>, IFormattable
	{
		// Token: 0x0600188C RID: 6284 RVA: 0x0004398E File Offset: 0x00041B8E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(int2 c0, int2 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x0004399E File Offset: 0x00041B9E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(int m00, int m01, int m10, int m11)
		{
			this.c0 = new int2(m00, m10);
			this.c1 = new int2(m01, m11);
		}

		// Token: 0x0600188E RID: 6286 RVA: 0x000439BB File Offset: 0x00041BBB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(int v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x0600188F RID: 6287 RVA: 0x000439D5 File Offset: 0x00041BD5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(bool v)
		{
			this.c0 = math.select(new int2(0), new int2(1), v);
			this.c1 = math.select(new int2(0), new int2(1), v);
		}

		// Token: 0x06001890 RID: 6288 RVA: 0x00043A07 File Offset: 0x00041C07
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(bool2x2 v)
		{
			this.c0 = math.select(new int2(0), new int2(1), v.c0);
			this.c1 = math.select(new int2(0), new int2(1), v.c1);
		}

		// Token: 0x06001891 RID: 6289 RVA: 0x00043A43 File Offset: 0x00041C43
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(uint v)
		{
			this.c0 = (int2)v;
			this.c1 = (int2)v;
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x00043A5D File Offset: 0x00041C5D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(uint2x2 v)
		{
			this.c0 = (int2)v.c0;
			this.c1 = (int2)v.c1;
		}

		// Token: 0x06001893 RID: 6291 RVA: 0x00043A81 File Offset: 0x00041C81
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(float v)
		{
			this.c0 = (int2)v;
			this.c1 = (int2)v;
		}

		// Token: 0x06001894 RID: 6292 RVA: 0x00043A9B File Offset: 0x00041C9B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(float2x2 v)
		{
			this.c0 = (int2)v.c0;
			this.c1 = (int2)v.c1;
		}

		// Token: 0x06001895 RID: 6293 RVA: 0x00043ABF File Offset: 0x00041CBF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(double v)
		{
			this.c0 = (int2)v;
			this.c1 = (int2)v;
		}

		// Token: 0x06001896 RID: 6294 RVA: 0x00043AD9 File Offset: 0x00041CD9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x2(double2x2 v)
		{
			this.c0 = (int2)v.c0;
			this.c1 = (int2)v.c1;
		}

		// Token: 0x06001897 RID: 6295 RVA: 0x00043AFD File Offset: 0x00041CFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int2x2(int v)
		{
			return new int2x2(v);
		}

		// Token: 0x06001898 RID: 6296 RVA: 0x00043B05 File Offset: 0x00041D05
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x2(bool v)
		{
			return new int2x2(v);
		}

		// Token: 0x06001899 RID: 6297 RVA: 0x00043B0D File Offset: 0x00041D0D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x2(bool2x2 v)
		{
			return new int2x2(v);
		}

		// Token: 0x0600189A RID: 6298 RVA: 0x00043B15 File Offset: 0x00041D15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x2(uint v)
		{
			return new int2x2(v);
		}

		// Token: 0x0600189B RID: 6299 RVA: 0x00043B1D File Offset: 0x00041D1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x2(uint2x2 v)
		{
			return new int2x2(v);
		}

		// Token: 0x0600189C RID: 6300 RVA: 0x00043B25 File Offset: 0x00041D25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x2(float v)
		{
			return new int2x2(v);
		}

		// Token: 0x0600189D RID: 6301 RVA: 0x00043B2D File Offset: 0x00041D2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x2(float2x2 v)
		{
			return new int2x2(v);
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x00043B35 File Offset: 0x00041D35
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x2(double v)
		{
			return new int2x2(v);
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x00043B3D File Offset: 0x00041D3D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x2(double2x2 v)
		{
			return new int2x2(v);
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x00043B45 File Offset: 0x00041D45
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator *(int2x2 lhs, int2x2 rhs)
		{
			return new int2x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x00043B6E File Offset: 0x00041D6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator *(int2x2 lhs, int rhs)
		{
			return new int2x2(lhs.c0 * rhs, lhs.c1 * rhs);
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x00043B8D File Offset: 0x00041D8D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator *(int lhs, int2x2 rhs)
		{
			return new int2x2(lhs * rhs.c0, lhs * rhs.c1);
		}

		// Token: 0x060018A3 RID: 6307 RVA: 0x00043BAC File Offset: 0x00041DAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator +(int2x2 lhs, int2x2 rhs)
		{
			return new int2x2(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x00043BD5 File Offset: 0x00041DD5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator +(int2x2 lhs, int rhs)
		{
			return new int2x2(lhs.c0 + rhs, lhs.c1 + rhs);
		}

		// Token: 0x060018A5 RID: 6309 RVA: 0x00043BF4 File Offset: 0x00041DF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator +(int lhs, int2x2 rhs)
		{
			return new int2x2(lhs + rhs.c0, lhs + rhs.c1);
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x00043C13 File Offset: 0x00041E13
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator -(int2x2 lhs, int2x2 rhs)
		{
			return new int2x2(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);
		}

		// Token: 0x060018A7 RID: 6311 RVA: 0x00043C3C File Offset: 0x00041E3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator -(int2x2 lhs, int rhs)
		{
			return new int2x2(lhs.c0 - rhs, lhs.c1 - rhs);
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x00043C5B File Offset: 0x00041E5B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator -(int lhs, int2x2 rhs)
		{
			return new int2x2(lhs - rhs.c0, lhs - rhs.c1);
		}

		// Token: 0x060018A9 RID: 6313 RVA: 0x00043C7A File Offset: 0x00041E7A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator /(int2x2 lhs, int2x2 rhs)
		{
			return new int2x2(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);
		}

		// Token: 0x060018AA RID: 6314 RVA: 0x00043CA3 File Offset: 0x00041EA3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator /(int2x2 lhs, int rhs)
		{
			return new int2x2(lhs.c0 / rhs, lhs.c1 / rhs);
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x00043CC2 File Offset: 0x00041EC2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator /(int lhs, int2x2 rhs)
		{
			return new int2x2(lhs / rhs.c0, lhs / rhs.c1);
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x00043CE1 File Offset: 0x00041EE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator %(int2x2 lhs, int2x2 rhs)
		{
			return new int2x2(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);
		}

		// Token: 0x060018AD RID: 6317 RVA: 0x00043D0A File Offset: 0x00041F0A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator %(int2x2 lhs, int rhs)
		{
			return new int2x2(lhs.c0 % rhs, lhs.c1 % rhs);
		}

		// Token: 0x060018AE RID: 6318 RVA: 0x00043D29 File Offset: 0x00041F29
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator %(int lhs, int2x2 rhs)
		{
			return new int2x2(lhs % rhs.c0, lhs % rhs.c1);
		}

		// Token: 0x060018AF RID: 6319 RVA: 0x00043D48 File Offset: 0x00041F48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator ++(int2x2 val)
		{
			int2 @int = ++val.c0;
			val.c0 = @int;
			int2 int2 = @int;
			@int = ++val.c1;
			val.c1 = @int;
			return new int2x2(int2, @int);
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x00043D90 File Offset: 0x00041F90
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator --(int2x2 val)
		{
			int2 @int = --val.c0;
			val.c0 = @int;
			int2 int2 = @int;
			@int = --val.c1;
			val.c1 = @int;
			return new int2x2(int2, @int);
		}

		// Token: 0x060018B1 RID: 6321 RVA: 0x00043DD6 File Offset: 0x00041FD6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <(int2x2 lhs, int2x2 rhs)
		{
			return new bool2x2(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);
		}

		// Token: 0x060018B2 RID: 6322 RVA: 0x00043DFF File Offset: 0x00041FFF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <(int2x2 lhs, int rhs)
		{
			return new bool2x2(lhs.c0 < rhs, lhs.c1 < rhs);
		}

		// Token: 0x060018B3 RID: 6323 RVA: 0x00043E1E File Offset: 0x0004201E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <(int lhs, int2x2 rhs)
		{
			return new bool2x2(lhs < rhs.c0, lhs < rhs.c1);
		}

		// Token: 0x060018B4 RID: 6324 RVA: 0x00043E3D File Offset: 0x0004203D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <=(int2x2 lhs, int2x2 rhs)
		{
			return new bool2x2(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);
		}

		// Token: 0x060018B5 RID: 6325 RVA: 0x00043E66 File Offset: 0x00042066
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <=(int2x2 lhs, int rhs)
		{
			return new bool2x2(lhs.c0 <= rhs, lhs.c1 <= rhs);
		}

		// Token: 0x060018B6 RID: 6326 RVA: 0x00043E85 File Offset: 0x00042085
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <=(int lhs, int2x2 rhs)
		{
			return new bool2x2(lhs <= rhs.c0, lhs <= rhs.c1);
		}

		// Token: 0x060018B7 RID: 6327 RVA: 0x00043EA4 File Offset: 0x000420A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >(int2x2 lhs, int2x2 rhs)
		{
			return new bool2x2(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);
		}

		// Token: 0x060018B8 RID: 6328 RVA: 0x00043ECD File Offset: 0x000420CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >(int2x2 lhs, int rhs)
		{
			return new bool2x2(lhs.c0 > rhs, lhs.c1 > rhs);
		}

		// Token: 0x060018B9 RID: 6329 RVA: 0x00043EEC File Offset: 0x000420EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >(int lhs, int2x2 rhs)
		{
			return new bool2x2(lhs > rhs.c0, lhs > rhs.c1);
		}

		// Token: 0x060018BA RID: 6330 RVA: 0x00043F0B File Offset: 0x0004210B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >=(int2x2 lhs, int2x2 rhs)
		{
			return new bool2x2(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);
		}

		// Token: 0x060018BB RID: 6331 RVA: 0x00043F34 File Offset: 0x00042134
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >=(int2x2 lhs, int rhs)
		{
			return new bool2x2(lhs.c0 >= rhs, lhs.c1 >= rhs);
		}

		// Token: 0x060018BC RID: 6332 RVA: 0x00043F53 File Offset: 0x00042153
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >=(int lhs, int2x2 rhs)
		{
			return new bool2x2(lhs >= rhs.c0, lhs >= rhs.c1);
		}

		// Token: 0x060018BD RID: 6333 RVA: 0x00043F72 File Offset: 0x00042172
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator -(int2x2 val)
		{
			return new int2x2(-val.c0, -val.c1);
		}

		// Token: 0x060018BE RID: 6334 RVA: 0x00043F8F File Offset: 0x0004218F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator +(int2x2 val)
		{
			return new int2x2(+val.c0, +val.c1);
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x00043FAC File Offset: 0x000421AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator <<(int2x2 x, int n)
		{
			return new int2x2(x.c0 << n, x.c1 << n);
		}

		// Token: 0x060018C0 RID: 6336 RVA: 0x00043FCB File Offset: 0x000421CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator >>(int2x2 x, int n)
		{
			return new int2x2(x.c0 >> n, x.c1 >> n);
		}

		// Token: 0x060018C1 RID: 6337 RVA: 0x00043FEA File Offset: 0x000421EA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ==(int2x2 lhs, int2x2 rhs)
		{
			return new bool2x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x060018C2 RID: 6338 RVA: 0x00044013 File Offset: 0x00042213
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ==(int2x2 lhs, int rhs)
		{
			return new bool2x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x060018C3 RID: 6339 RVA: 0x00044032 File Offset: 0x00042232
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ==(int lhs, int2x2 rhs)
		{
			return new bool2x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x00044051 File Offset: 0x00042251
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator !=(int2x2 lhs, int2x2 rhs)
		{
			return new bool2x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x0004407A File Offset: 0x0004227A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator !=(int2x2 lhs, int rhs)
		{
			return new bool2x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x060018C6 RID: 6342 RVA: 0x00044099 File Offset: 0x00042299
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator !=(int lhs, int2x2 rhs)
		{
			return new bool2x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x060018C7 RID: 6343 RVA: 0x000440B8 File Offset: 0x000422B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator ~(int2x2 val)
		{
			return new int2x2(~val.c0, ~val.c1);
		}

		// Token: 0x060018C8 RID: 6344 RVA: 0x000440D5 File Offset: 0x000422D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator &(int2x2 lhs, int2x2 rhs)
		{
			return new int2x2(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);
		}

		// Token: 0x060018C9 RID: 6345 RVA: 0x000440FE File Offset: 0x000422FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator &(int2x2 lhs, int rhs)
		{
			return new int2x2(lhs.c0 & rhs, lhs.c1 & rhs);
		}

		// Token: 0x060018CA RID: 6346 RVA: 0x0004411D File Offset: 0x0004231D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator &(int lhs, int2x2 rhs)
		{
			return new int2x2(lhs & rhs.c0, lhs & rhs.c1);
		}

		// Token: 0x060018CB RID: 6347 RVA: 0x0004413C File Offset: 0x0004233C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator |(int2x2 lhs, int2x2 rhs)
		{
			return new int2x2(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);
		}

		// Token: 0x060018CC RID: 6348 RVA: 0x00044165 File Offset: 0x00042365
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator |(int2x2 lhs, int rhs)
		{
			return new int2x2(lhs.c0 | rhs, lhs.c1 | rhs);
		}

		// Token: 0x060018CD RID: 6349 RVA: 0x00044184 File Offset: 0x00042384
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator |(int lhs, int2x2 rhs)
		{
			return new int2x2(lhs | rhs.c0, lhs | rhs.c1);
		}

		// Token: 0x060018CE RID: 6350 RVA: 0x000441A3 File Offset: 0x000423A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator ^(int2x2 lhs, int2x2 rhs)
		{
			return new int2x2(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x000441CC File Offset: 0x000423CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator ^(int2x2 lhs, int rhs)
		{
			return new int2x2(lhs.c0 ^ rhs, lhs.c1 ^ rhs);
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x000441EB File Offset: 0x000423EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x2 operator ^(int lhs, int2x2 rhs)
		{
			return new int2x2(lhs ^ rhs.c0, lhs ^ rhs.c1);
		}

		// Token: 0x170007CD RID: 1997
		public unsafe int2 this[int index]
		{
			get
			{
				fixed (int2x2* ptr = &this)
				{
					return ref *(int2*)(ptr + (IntPtr)index * (IntPtr)sizeof(int2) / (IntPtr)sizeof(int2x2));
				}
			}
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x00044227 File Offset: 0x00042427
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int2x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x00044250 File Offset: 0x00042450
		public override bool Equals(object o)
		{
			if (o is int2x2)
			{
				int2x2 rhs = (int2x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x00044275 File Offset: 0x00042475
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060018D5 RID: 6357 RVA: 0x00044284 File Offset: 0x00042484
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int2x2({0}, {1},  {2}, {3})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y
			});
		}

		// Token: 0x060018D6 RID: 6358 RVA: 0x000442F0 File Offset: 0x000424F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int2x2({0}, {1},  {2}, {3})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000B2 RID: 178
		public int2 c0;

		// Token: 0x040000B3 RID: 179
		public int2 c1;

		// Token: 0x040000B4 RID: 180
		public static readonly int2x2 identity = new int2x2(1, 0, 0, 1);

		// Token: 0x040000B5 RID: 181
		public static readonly int2x2 zero;
	}
}
