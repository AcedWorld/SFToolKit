using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000030 RID: 48
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int2x4 : IEquatable<int2x4>, IFormattable
	{
		// Token: 0x06001923 RID: 6435 RVA: 0x0004511B File Offset: 0x0004331B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(int2 c0, int2 c1, int2 c2, int2 c3)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
			this.c3 = c3;
		}

		// Token: 0x06001924 RID: 6436 RVA: 0x0004513A File Offset: 0x0004333A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(int m00, int m01, int m02, int m03, int m10, int m11, int m12, int m13)
		{
			this.c0 = new int2(m00, m10);
			this.c1 = new int2(m01, m11);
			this.c2 = new int2(m02, m12);
			this.c3 = new int2(m03, m13);
		}

		// Token: 0x06001925 RID: 6437 RVA: 0x00045175 File Offset: 0x00043375
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x06001926 RID: 6438 RVA: 0x000451A8 File Offset: 0x000433A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(bool v)
		{
			this.c0 = math.select(new int2(0), new int2(1), v);
			this.c1 = math.select(new int2(0), new int2(1), v);
			this.c2 = math.select(new int2(0), new int2(1), v);
			this.c3 = math.select(new int2(0), new int2(1), v);
		}

		// Token: 0x06001927 RID: 6439 RVA: 0x00045218 File Offset: 0x00043418
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(bool2x4 v)
		{
			this.c0 = math.select(new int2(0), new int2(1), v.c0);
			this.c1 = math.select(new int2(0), new int2(1), v.c1);
			this.c2 = math.select(new int2(0), new int2(1), v.c2);
			this.c3 = math.select(new int2(0), new int2(1), v.c3);
		}

		// Token: 0x06001928 RID: 6440 RVA: 0x00045299 File Offset: 0x00043499
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(uint v)
		{
			this.c0 = (int2)v;
			this.c1 = (int2)v;
			this.c2 = (int2)v;
			this.c3 = (int2)v;
		}

		// Token: 0x06001929 RID: 6441 RVA: 0x000452CC File Offset: 0x000434CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(uint2x4 v)
		{
			this.c0 = (int2)v.c0;
			this.c1 = (int2)v.c1;
			this.c2 = (int2)v.c2;
			this.c3 = (int2)v.c3;
		}

		// Token: 0x0600192A RID: 6442 RVA: 0x0004531D File Offset: 0x0004351D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(float v)
		{
			this.c0 = (int2)v;
			this.c1 = (int2)v;
			this.c2 = (int2)v;
			this.c3 = (int2)v;
		}

		// Token: 0x0600192B RID: 6443 RVA: 0x00045350 File Offset: 0x00043550
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(float2x4 v)
		{
			this.c0 = (int2)v.c0;
			this.c1 = (int2)v.c1;
			this.c2 = (int2)v.c2;
			this.c3 = (int2)v.c3;
		}

		// Token: 0x0600192C RID: 6444 RVA: 0x000453A1 File Offset: 0x000435A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(double v)
		{
			this.c0 = (int2)v;
			this.c1 = (int2)v;
			this.c2 = (int2)v;
			this.c3 = (int2)v;
		}

		// Token: 0x0600192D RID: 6445 RVA: 0x000453D4 File Offset: 0x000435D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2x4(double2x4 v)
		{
			this.c0 = (int2)v.c0;
			this.c1 = (int2)v.c1;
			this.c2 = (int2)v.c2;
			this.c3 = (int2)v.c3;
		}

		// Token: 0x0600192E RID: 6446 RVA: 0x00045425 File Offset: 0x00043625
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int2x4(int v)
		{
			return new int2x4(v);
		}

		// Token: 0x0600192F RID: 6447 RVA: 0x0004542D File Offset: 0x0004362D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x4(bool v)
		{
			return new int2x4(v);
		}

		// Token: 0x06001930 RID: 6448 RVA: 0x00045435 File Offset: 0x00043635
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x4(bool2x4 v)
		{
			return new int2x4(v);
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x0004543D File Offset: 0x0004363D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x4(uint v)
		{
			return new int2x4(v);
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x00045445 File Offset: 0x00043645
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x4(uint2x4 v)
		{
			return new int2x4(v);
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x0004544D File Offset: 0x0004364D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x4(float v)
		{
			return new int2x4(v);
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x00045455 File Offset: 0x00043655
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x4(float2x4 v)
		{
			return new int2x4(v);
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x0004545D File Offset: 0x0004365D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x4(double v)
		{
			return new int2x4(v);
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x00045465 File Offset: 0x00043665
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2x4(double2x4 v)
		{
			return new int2x4(v);
		}

		// Token: 0x06001937 RID: 6455 RVA: 0x00045470 File Offset: 0x00043670
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator *(int2x4 lhs, int2x4 rhs)
		{
			return new int2x4(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3);
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x000454C6 File Offset: 0x000436C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator *(int2x4 lhs, int rhs)
		{
			return new int2x4(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs, lhs.c3 * rhs);
		}

		// Token: 0x06001939 RID: 6457 RVA: 0x000454FD File Offset: 0x000436FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator *(int lhs, int2x4 rhs)
		{
			return new int2x4(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3);
		}

		// Token: 0x0600193A RID: 6458 RVA: 0x00045534 File Offset: 0x00043734
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator +(int2x4 lhs, int2x4 rhs)
		{
			return new int2x4(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3);
		}

		// Token: 0x0600193B RID: 6459 RVA: 0x0004558A File Offset: 0x0004378A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator +(int2x4 lhs, int rhs)
		{
			return new int2x4(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs, lhs.c3 + rhs);
		}

		// Token: 0x0600193C RID: 6460 RVA: 0x000455C1 File Offset: 0x000437C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator +(int lhs, int2x4 rhs)
		{
			return new int2x4(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2, lhs + rhs.c3);
		}

		// Token: 0x0600193D RID: 6461 RVA: 0x000455F8 File Offset: 0x000437F8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator -(int2x4 lhs, int2x4 rhs)
		{
			return new int2x4(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3);
		}

		// Token: 0x0600193E RID: 6462 RVA: 0x0004564E File Offset: 0x0004384E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator -(int2x4 lhs, int rhs)
		{
			return new int2x4(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs, lhs.c3 - rhs);
		}

		// Token: 0x0600193F RID: 6463 RVA: 0x00045685 File Offset: 0x00043885
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator -(int lhs, int2x4 rhs)
		{
			return new int2x4(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2, lhs - rhs.c3);
		}

		// Token: 0x06001940 RID: 6464 RVA: 0x000456BC File Offset: 0x000438BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator /(int2x4 lhs, int2x4 rhs)
		{
			return new int2x4(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3);
		}

		// Token: 0x06001941 RID: 6465 RVA: 0x00045712 File Offset: 0x00043912
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator /(int2x4 lhs, int rhs)
		{
			return new int2x4(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs);
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x00045749 File Offset: 0x00043949
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator /(int lhs, int2x4 rhs)
		{
			return new int2x4(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2, lhs / rhs.c3);
		}

		// Token: 0x06001943 RID: 6467 RVA: 0x00045780 File Offset: 0x00043980
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator %(int2x4 lhs, int2x4 rhs)
		{
			return new int2x4(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3);
		}

		// Token: 0x06001944 RID: 6468 RVA: 0x000457D6 File Offset: 0x000439D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator %(int2x4 lhs, int rhs)
		{
			return new int2x4(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs);
		}

		// Token: 0x06001945 RID: 6469 RVA: 0x0004580D File Offset: 0x00043A0D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator %(int lhs, int2x4 rhs)
		{
			return new int2x4(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2, lhs % rhs.c3);
		}

		// Token: 0x06001946 RID: 6470 RVA: 0x00045844 File Offset: 0x00043A44
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator ++(int2x4 val)
		{
			int2 @int = ++val.c0;
			val.c0 = @int;
			int2 int2 = @int;
			@int = ++val.c1;
			val.c1 = @int;
			int2 int3 = @int;
			@int = ++val.c2;
			val.c2 = @int;
			int2 int4 = @int;
			@int = ++val.c3;
			val.c3 = @int;
			return new int2x4(int2, int3, int4, @int);
		}

		// Token: 0x06001947 RID: 6471 RVA: 0x000458C0 File Offset: 0x00043AC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator --(int2x4 val)
		{
			int2 @int = --val.c0;
			val.c0 = @int;
			int2 int2 = @int;
			@int = --val.c1;
			val.c1 = @int;
			int2 int3 = @int;
			@int = --val.c2;
			val.c2 = @int;
			int2 int4 = @int;
			@int = --val.c3;
			val.c3 = @int;
			return new int2x4(int2, int3, int4, @int);
		}

		// Token: 0x06001948 RID: 6472 RVA: 0x0004593C File Offset: 0x00043B3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <(int2x4 lhs, int2x4 rhs)
		{
			return new bool2x4(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3);
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x00045992 File Offset: 0x00043B92
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <(int2x4 lhs, int rhs)
		{
			return new bool2x4(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs, lhs.c3 < rhs);
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x000459C9 File Offset: 0x00043BC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <(int lhs, int2x4 rhs)
		{
			return new bool2x4(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2, lhs < rhs.c3);
		}

		// Token: 0x0600194B RID: 6475 RVA: 0x00045A00 File Offset: 0x00043C00
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <=(int2x4 lhs, int2x4 rhs)
		{
			return new bool2x4(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3);
		}

		// Token: 0x0600194C RID: 6476 RVA: 0x00045A56 File Offset: 0x00043C56
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <=(int2x4 lhs, int rhs)
		{
			return new bool2x4(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs, lhs.c3 <= rhs);
		}

		// Token: 0x0600194D RID: 6477 RVA: 0x00045A8D File Offset: 0x00043C8D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator <=(int lhs, int2x4 rhs)
		{
			return new bool2x4(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2, lhs <= rhs.c3);
		}

		// Token: 0x0600194E RID: 6478 RVA: 0x00045AC4 File Offset: 0x00043CC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >(int2x4 lhs, int2x4 rhs)
		{
			return new bool2x4(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3);
		}

		// Token: 0x0600194F RID: 6479 RVA: 0x00045B1A File Offset: 0x00043D1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >(int2x4 lhs, int rhs)
		{
			return new bool2x4(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs, lhs.c3 > rhs);
		}

		// Token: 0x06001950 RID: 6480 RVA: 0x00045B51 File Offset: 0x00043D51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >(int lhs, int2x4 rhs)
		{
			return new bool2x4(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2, lhs > rhs.c3);
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x00045B88 File Offset: 0x00043D88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >=(int2x4 lhs, int2x4 rhs)
		{
			return new bool2x4(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3);
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x00045BDE File Offset: 0x00043DDE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >=(int2x4 lhs, int rhs)
		{
			return new bool2x4(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs, lhs.c3 >= rhs);
		}

		// Token: 0x06001953 RID: 6483 RVA: 0x00045C15 File Offset: 0x00043E15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator >=(int lhs, int2x4 rhs)
		{
			return new bool2x4(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2, lhs >= rhs.c3);
		}

		// Token: 0x06001954 RID: 6484 RVA: 0x00045C4C File Offset: 0x00043E4C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator -(int2x4 val)
		{
			return new int2x4(-val.c0, -val.c1, -val.c2, -val.c3);
		}

		// Token: 0x06001955 RID: 6485 RVA: 0x00045C7F File Offset: 0x00043E7F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator +(int2x4 val)
		{
			return new int2x4(+val.c0, +val.c1, +val.c2, +val.c3);
		}

		// Token: 0x06001956 RID: 6486 RVA: 0x00045CB2 File Offset: 0x00043EB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator <<(int2x4 x, int n)
		{
			return new int2x4(x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n);
		}

		// Token: 0x06001957 RID: 6487 RVA: 0x00045CE9 File Offset: 0x00043EE9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator >>(int2x4 x, int n)
		{
			return new int2x4(x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n);
		}

		// Token: 0x06001958 RID: 6488 RVA: 0x00045D20 File Offset: 0x00043F20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(int2x4 lhs, int2x4 rhs)
		{
			return new bool2x4(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);
		}

		// Token: 0x06001959 RID: 6489 RVA: 0x00045D76 File Offset: 0x00043F76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(int2x4 lhs, int rhs)
		{
			return new bool2x4(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs);
		}

		// Token: 0x0600195A RID: 6490 RVA: 0x00045DAD File Offset: 0x00043FAD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(int lhs, int2x4 rhs)
		{
			return new bool2x4(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3);
		}

		// Token: 0x0600195B RID: 6491 RVA: 0x00045DE4 File Offset: 0x00043FE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(int2x4 lhs, int2x4 rhs)
		{
			return new bool2x4(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);
		}

		// Token: 0x0600195C RID: 6492 RVA: 0x00045E3A File Offset: 0x0004403A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(int2x4 lhs, int rhs)
		{
			return new bool2x4(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs);
		}

		// Token: 0x0600195D RID: 6493 RVA: 0x00045E71 File Offset: 0x00044071
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(int lhs, int2x4 rhs)
		{
			return new bool2x4(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3);
		}

		// Token: 0x0600195E RID: 6494 RVA: 0x00045EA8 File Offset: 0x000440A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator ~(int2x4 val)
		{
			return new int2x4(~val.c0, ~val.c1, ~val.c2, ~val.c3);
		}

		// Token: 0x0600195F RID: 6495 RVA: 0x00045EDC File Offset: 0x000440DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator &(int2x4 lhs, int2x4 rhs)
		{
			return new int2x4(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2, lhs.c3 & rhs.c3);
		}

		// Token: 0x06001960 RID: 6496 RVA: 0x00045F32 File Offset: 0x00044132
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator &(int2x4 lhs, int rhs)
		{
			return new int2x4(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs, lhs.c3 & rhs);
		}

		// Token: 0x06001961 RID: 6497 RVA: 0x00045F69 File Offset: 0x00044169
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator &(int lhs, int2x4 rhs)
		{
			return new int2x4(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2, lhs & rhs.c3);
		}

		// Token: 0x06001962 RID: 6498 RVA: 0x00045FA0 File Offset: 0x000441A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator |(int2x4 lhs, int2x4 rhs)
		{
			return new int2x4(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2, lhs.c3 | rhs.c3);
		}

		// Token: 0x06001963 RID: 6499 RVA: 0x00045FF6 File Offset: 0x000441F6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator |(int2x4 lhs, int rhs)
		{
			return new int2x4(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs, lhs.c3 | rhs);
		}

		// Token: 0x06001964 RID: 6500 RVA: 0x0004602D File Offset: 0x0004422D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator |(int lhs, int2x4 rhs)
		{
			return new int2x4(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2, lhs | rhs.c3);
		}

		// Token: 0x06001965 RID: 6501 RVA: 0x00046064 File Offset: 0x00044264
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator ^(int2x4 lhs, int2x4 rhs)
		{
			return new int2x4(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2, lhs.c3 ^ rhs.c3);
		}

		// Token: 0x06001966 RID: 6502 RVA: 0x000460BA File Offset: 0x000442BA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator ^(int2x4 lhs, int rhs)
		{
			return new int2x4(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs, lhs.c3 ^ rhs);
		}

		// Token: 0x06001967 RID: 6503 RVA: 0x000460F1 File Offset: 0x000442F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2x4 operator ^(int lhs, int2x4 rhs)
		{
			return new int2x4(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2, lhs ^ rhs.c3);
		}

		// Token: 0x170007CF RID: 1999
		public unsafe int2 this[int index]
		{
			get
			{
				fixed (int2x4* ptr = &this)
				{
					return ref *(int2*)(ptr + (IntPtr)index * (IntPtr)sizeof(int2) / (IntPtr)sizeof(int2x4));
				}
			}
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x00046144 File Offset: 0x00044344
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int2x4 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2) && this.c3.Equals(rhs.c3);
		}

		// Token: 0x0600196A RID: 6506 RVA: 0x000461A0 File Offset: 0x000443A0
		public override bool Equals(object o)
		{
			if (o is int2x4)
			{
				int2x4 rhs = (int2x4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x0600196B RID: 6507 RVA: 0x000461C5 File Offset: 0x000443C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x0600196C RID: 6508 RVA: 0x000461D4 File Offset: 0x000443D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int2x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7})", new object[]
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

		// Token: 0x0600196D RID: 6509 RVA: 0x0004628C File Offset: 0x0004448C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int2x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7})", new object[]
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

		// Token: 0x040000BA RID: 186
		public int2 c0;

		// Token: 0x040000BB RID: 187
		public int2 c1;

		// Token: 0x040000BC RID: 188
		public int2 c2;

		// Token: 0x040000BD RID: 189
		public int2 c3;

		// Token: 0x040000BE RID: 190
		public static readonly int2x4 zero;
	}
}
