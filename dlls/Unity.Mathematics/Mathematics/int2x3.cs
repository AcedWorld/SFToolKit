using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200002F RID: 47
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int2x3 : IEquatable<int2x3>, IFormattable
	{
		// Token: 0x060018D8 RID: 6360 RVA: 0x00044371 File Offset: 0x00042571
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(int2 c0, int2 c1, int2 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x060018D9 RID: 6361 RVA: 0x00044388 File Offset: 0x00042588
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(int m00, int m01, int m02, int m10, int m11, int m12)
		{
			this.c0 = new int2(m00, m10);
			this.c1 = new int2(m01, m11);
			this.c2 = new int2(m02, m12);
		}

		// Token: 0x060018DA RID: 6362 RVA: 0x000443B4 File Offset: 0x000425B4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060018DB RID: 6363 RVA: 0x000443DC File Offset: 0x000425DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(bool v)
		{
			this.c0 = math.select(new int2(0), new int2(1), v);
			this.c1 = math.select(new int2(0), new int2(1), v);
			this.c2 = math.select(new int2(0), new int2(1), v);
		}

		// Token: 0x060018DC RID: 6364 RVA: 0x00044434 File Offset: 0x00042634
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(bool2x3 v)
		{
			this.c0 = math.select(new int2(0), new int2(1), v.c0);
			this.c1 = math.select(new int2(0), new int2(1), v.c1);
			this.c2 = math.select(new int2(0), new int2(1), v.c2);
		}

		// Token: 0x060018DD RID: 6365 RVA: 0x00044498 File Offset: 0x00042698
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(uint v)
		{
			this.c0 = (int2)v;
			this.c1 = (int2)v;
			this.c2 = (int2)v;
		}

		// Token: 0x060018DE RID: 6366 RVA: 0x000444BE File Offset: 0x000426BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(uint2x3 v)
		{
			this.c0 = (int2)v.c0;
			this.c1 = (int2)v.c1;
			this.c2 = (int2)v.c2;
		}

		// Token: 0x060018DF RID: 6367 RVA: 0x000444F3 File Offset: 0x000426F3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(float v)
		{
			this.c0 = (int2)v;
			this.c1 = (int2)v;
			this.c2 = (int2)v;
		}

		// Token: 0x060018E0 RID: 6368 RVA: 0x00044519 File Offset: 0x00042719
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(float2x3 v)
		{
			this.c0 = (int2)v.c0;
			this.c1 = (int2)v.c1;
			this.c2 = (int2)v.c2;
		}

		// Token: 0x060018E1 RID: 6369 RVA: 0x0004454E File Offset: 0x0004274E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(double v)
		{
			this.c0 = (int2)v;
			this.c1 = (int2)v;
			this.c2 = (int2)v;
		}

		// Token: 0x060018E2 RID: 6370 RVA: 0x00044574 File Offset: 0x00042774
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x3(double2x3 v)
		{
			this.c0 = (int2)v.c0;
			this.c1 = (int2)v.c1;
			this.c2 = (int2)v.c2;
		}

		// Token: 0x060018E3 RID: 6371 RVA: 0x000445A9 File Offset: 0x000427A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int2x3(int v)
		{
			return new int2x3(v);
		}

		// Token: 0x060018E4 RID: 6372 RVA: 0x000445B1 File Offset: 0x000427B1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x3(bool v)
		{
			return new int2x3(v);
		}

		// Token: 0x060018E5 RID: 6373 RVA: 0x000445B9 File Offset: 0x000427B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x3(bool2x3 v)
		{
			return new int2x3(v);
		}

		// Token: 0x060018E6 RID: 6374 RVA: 0x000445C1 File Offset: 0x000427C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x3(uint v)
		{
			return new int2x3(v);
		}

		// Token: 0x060018E7 RID: 6375 RVA: 0x000445C9 File Offset: 0x000427C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x3(uint2x3 v)
		{
			return new int2x3(v);
		}

		// Token: 0x060018E8 RID: 6376 RVA: 0x000445D1 File Offset: 0x000427D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x3(float v)
		{
			return new int2x3(v);
		}

		// Token: 0x060018E9 RID: 6377 RVA: 0x000445D9 File Offset: 0x000427D9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x3(float2x3 v)
		{
			return new int2x3(v);
		}

		// Token: 0x060018EA RID: 6378 RVA: 0x000445E1 File Offset: 0x000427E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x3(double v)
		{
			return new int2x3(v);
		}

		// Token: 0x060018EB RID: 6379 RVA: 0x000445E9 File Offset: 0x000427E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x3(double2x3 v)
		{
			return new int2x3(v);
		}

		// Token: 0x060018EC RID: 6380 RVA: 0x000445F1 File Offset: 0x000427F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator *(int2x3 lhs, int2x3 rhs)
		{
			return new int2x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x060018ED RID: 6381 RVA: 0x0004462B File Offset: 0x0004282B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator *(int2x3 lhs, int rhs)
		{
			return new int2x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x060018EE RID: 6382 RVA: 0x00044656 File Offset: 0x00042856
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator *(int lhs, int2x3 rhs)
		{
			return new int2x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x060018EF RID: 6383 RVA: 0x00044681 File Offset: 0x00042881
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator +(int2x3 lhs, int2x3 rhs)
		{
			return new int2x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x060018F0 RID: 6384 RVA: 0x000446BB File Offset: 0x000428BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator +(int2x3 lhs, int rhs)
		{
			return new int2x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x060018F1 RID: 6385 RVA: 0x000446E6 File Offset: 0x000428E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator +(int lhs, int2x3 rhs)
		{
			return new int2x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x060018F2 RID: 6386 RVA: 0x00044711 File Offset: 0x00042911
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator -(int2x3 lhs, int2x3 rhs)
		{
			return new int2x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x060018F3 RID: 6387 RVA: 0x0004474B File Offset: 0x0004294B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator -(int2x3 lhs, int rhs)
		{
			return new int2x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x060018F4 RID: 6388 RVA: 0x00044776 File Offset: 0x00042976
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator -(int lhs, int2x3 rhs)
		{
			return new int2x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x060018F5 RID: 6389 RVA: 0x000447A1 File Offset: 0x000429A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator /(int2x3 lhs, int2x3 rhs)
		{
			return new int2x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x060018F6 RID: 6390 RVA: 0x000447DB File Offset: 0x000429DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator /(int2x3 lhs, int rhs)
		{
			return new int2x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x060018F7 RID: 6391 RVA: 0x00044806 File Offset: 0x00042A06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator /(int lhs, int2x3 rhs)
		{
			return new int2x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x060018F8 RID: 6392 RVA: 0x00044831 File Offset: 0x00042A31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator %(int2x3 lhs, int2x3 rhs)
		{
			return new int2x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x060018F9 RID: 6393 RVA: 0x0004486B File Offset: 0x00042A6B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator %(int2x3 lhs, int rhs)
		{
			return new int2x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x060018FA RID: 6394 RVA: 0x00044896 File Offset: 0x00042A96
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator %(int lhs, int2x3 rhs)
		{
			return new int2x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x060018FB RID: 6395 RVA: 0x000448C4 File Offset: 0x00042AC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator ++(int2x3 val)
		{
			int2 @int = ++val.c0;
			val.c0 = @int;
			int2 int2 = @int;
			@int = ++val.c1;
			val.c1 = @int;
			int2 int3 = @int;
			@int = ++val.c2;
			val.c2 = @int;
			return new int2x3(int2, int3, @int);
		}

		// Token: 0x060018FC RID: 6396 RVA: 0x00044924 File Offset: 0x00042B24
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator --(int2x3 val)
		{
			int2 @int = --val.c0;
			val.c0 = @int;
			int2 int2 = @int;
			@int = --val.c1;
			val.c1 = @int;
			int2 int3 = @int;
			@int = --val.c2;
			val.c2 = @int;
			return new int2x3(int2, int3, @int);
		}

		// Token: 0x060018FD RID: 6397 RVA: 0x00044984 File Offset: 0x00042B84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(int2x3 lhs, int2x3 rhs)
		{
			return new bool2x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x060018FE RID: 6398 RVA: 0x000449BE File Offset: 0x00042BBE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(int2x3 lhs, int rhs)
		{
			return new bool2x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x060018FF RID: 6399 RVA: 0x000449E9 File Offset: 0x00042BE9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(int lhs, int2x3 rhs)
		{
			return new bool2x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x06001900 RID: 6400 RVA: 0x00044A14 File Offset: 0x00042C14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(int2x3 lhs, int2x3 rhs)
		{
			return new bool2x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x06001901 RID: 6401 RVA: 0x00044A4E File Offset: 0x00042C4E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(int2x3 lhs, int rhs)
		{
			return new bool2x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x06001902 RID: 6402 RVA: 0x00044A79 File Offset: 0x00042C79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(int lhs, int2x3 rhs)
		{
			return new bool2x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x06001903 RID: 6403 RVA: 0x00044AA4 File Offset: 0x00042CA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(int2x3 lhs, int2x3 rhs)
		{
			return new bool2x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x06001904 RID: 6404 RVA: 0x00044ADE File Offset: 0x00042CDE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(int2x3 lhs, int rhs)
		{
			return new bool2x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x06001905 RID: 6405 RVA: 0x00044B09 File Offset: 0x00042D09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(int lhs, int2x3 rhs)
		{
			return new bool2x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x06001906 RID: 6406 RVA: 0x00044B34 File Offset: 0x00042D34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(int2x3 lhs, int2x3 rhs)
		{
			return new bool2x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x06001907 RID: 6407 RVA: 0x00044B6E File Offset: 0x00042D6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(int2x3 lhs, int rhs)
		{
			return new bool2x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x06001908 RID: 6408 RVA: 0x00044B99 File Offset: 0x00042D99
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(int lhs, int2x3 rhs)
		{
			return new bool2x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x06001909 RID: 6409 RVA: 0x00044BC4 File Offset: 0x00042DC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator -(int2x3 val)
		{
			return new int2x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x0600190A RID: 6410 RVA: 0x00044BEC File Offset: 0x00042DEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator +(int2x3 val)
		{
			return new int2x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x0600190B RID: 6411 RVA: 0x00044C14 File Offset: 0x00042E14
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator <<(int2x3 x, int n)
		{
			return new int2x3(x.c0 << n, x.c1 << n, x.c2 << n);
		}

		// Token: 0x0600190C RID: 6412 RVA: 0x00044C3F File Offset: 0x00042E3F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator >>(int2x3 x, int n)
		{
			return new int2x3(x.c0 >> n, x.c1 >> n, x.c2 >> n);
		}

		// Token: 0x0600190D RID: 6413 RVA: 0x00044C6A File Offset: 0x00042E6A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(int2x3 lhs, int2x3 rhs)
		{
			return new bool2x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x0600190E RID: 6414 RVA: 0x00044CA4 File Offset: 0x00042EA4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(int2x3 lhs, int rhs)
		{
			return new bool2x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x0600190F RID: 6415 RVA: 0x00044CCF File Offset: 0x00042ECF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(int lhs, int2x3 rhs)
		{
			return new bool2x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x06001910 RID: 6416 RVA: 0x00044CFA File Offset: 0x00042EFA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(int2x3 lhs, int2x3 rhs)
		{
			return new bool2x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x06001911 RID: 6417 RVA: 0x00044D34 File Offset: 0x00042F34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(int2x3 lhs, int rhs)
		{
			return new bool2x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x06001912 RID: 6418 RVA: 0x00044D5F File Offset: 0x00042F5F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(int lhs, int2x3 rhs)
		{
			return new bool2x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x06001913 RID: 6419 RVA: 0x00044D8A File Offset: 0x00042F8A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator ~(int2x3 val)
		{
			return new int2x3(~val.c0, ~val.c1, ~val.c2);
		}

		// Token: 0x06001914 RID: 6420 RVA: 0x00044DB2 File Offset: 0x00042FB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator &(int2x3 lhs, int2x3 rhs)
		{
			return new int2x3(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);
		}

		// Token: 0x06001915 RID: 6421 RVA: 0x00044DEC File Offset: 0x00042FEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator &(int2x3 lhs, int rhs)
		{
			return new int2x3(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs);
		}

		// Token: 0x06001916 RID: 6422 RVA: 0x00044E17 File Offset: 0x00043017
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator &(int lhs, int2x3 rhs)
		{
			return new int2x3(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2);
		}

		// Token: 0x06001917 RID: 6423 RVA: 0x00044E42 File Offset: 0x00043042
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator |(int2x3 lhs, int2x3 rhs)
		{
			return new int2x3(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);
		}

		// Token: 0x06001918 RID: 6424 RVA: 0x00044E7C File Offset: 0x0004307C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator |(int2x3 lhs, int rhs)
		{
			return new int2x3(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs);
		}

		// Token: 0x06001919 RID: 6425 RVA: 0x00044EA7 File Offset: 0x000430A7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator |(int lhs, int2x3 rhs)
		{
			return new int2x3(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2);
		}

		// Token: 0x0600191A RID: 6426 RVA: 0x00044ED2 File Offset: 0x000430D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator ^(int2x3 lhs, int2x3 rhs)
		{
			return new int2x3(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);
		}

		// Token: 0x0600191B RID: 6427 RVA: 0x00044F0C File Offset: 0x0004310C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator ^(int2x3 lhs, int rhs)
		{
			return new int2x3(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs);
		}

		// Token: 0x0600191C RID: 6428 RVA: 0x00044F37 File Offset: 0x00043137
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x3 operator ^(int lhs, int2x3 rhs)
		{
			return new int2x3(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2);
		}

		// Token: 0x170007CE RID: 1998
		public unsafe int2 this[int index]
		{
			get
			{
				fixed (int2x3* ptr = &this)
				{
					return ref *(int2*)(ptr + (IntPtr)index * (IntPtr)sizeof(int2) / (IntPtr)sizeof(int2x3));
				}
			}
		}

		// Token: 0x0600191E RID: 6430 RVA: 0x00044F7F File Offset: 0x0004317F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int2x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x0600191F RID: 6431 RVA: 0x00044FBC File Offset: 0x000431BC
		public override bool Equals(object o)
		{
			if (o is int2x3)
			{
				int2x3 rhs = (int2x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001920 RID: 6432 RVA: 0x00044FE1 File Offset: 0x000431E1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001921 RID: 6433 RVA: 0x00044FF0 File Offset: 0x000431F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int2x3({0}, {1}, {2},  {3}, {4}, {5})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y
			});
		}

		// Token: 0x06001922 RID: 6434 RVA: 0x00045080 File Offset: 0x00043280
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int2x3({0}, {1}, {2},  {3}, {4}, {5})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000B6 RID: 182
		public int2 c0;

		// Token: 0x040000B7 RID: 183
		public int2 c1;

		// Token: 0x040000B8 RID: 184
		public int2 c2;

		// Token: 0x040000B9 RID: 185
		public static readonly int2x3 zero;
	}
}
