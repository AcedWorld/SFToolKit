using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000036 RID: 54
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int4x2 : IEquatable<int4x2>, IFormattable
	{
		// Token: 0x06001CFD RID: 7421 RVA: 0x0004E631 File Offset: 0x0004C831
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(int4 c0, int4 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x06001CFE RID: 7422 RVA: 0x0004E641 File Offset: 0x0004C841
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(int m00, int m01, int m10, int m11, int m20, int m21, int m30, int m31)
		{
			this.c0 = new int4(m00, m10, m20, m30);
			this.c1 = new int4(m01, m11, m21, m31);
		}

		// Token: 0x06001CFF RID: 7423 RVA: 0x0004E666 File Offset: 0x0004C866
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(int v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06001D00 RID: 7424 RVA: 0x0004E680 File Offset: 0x0004C880
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(bool v)
		{
			this.c0 = math.select(new int4(0), new int4(1), v);
			this.c1 = math.select(new int4(0), new int4(1), v);
		}

		// Token: 0x06001D01 RID: 7425 RVA: 0x0004E6B2 File Offset: 0x0004C8B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(bool4x2 v)
		{
			this.c0 = math.select(new int4(0), new int4(1), v.c0);
			this.c1 = math.select(new int4(0), new int4(1), v.c1);
		}

		// Token: 0x06001D02 RID: 7426 RVA: 0x0004E6EE File Offset: 0x0004C8EE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(uint v)
		{
			this.c0 = (int4)v;
			this.c1 = (int4)v;
		}

		// Token: 0x06001D03 RID: 7427 RVA: 0x0004E708 File Offset: 0x0004C908
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(uint4x2 v)
		{
			this.c0 = (int4)v.c0;
			this.c1 = (int4)v.c1;
		}

		// Token: 0x06001D04 RID: 7428 RVA: 0x0004E72C File Offset: 0x0004C92C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(float v)
		{
			this.c0 = (int4)v;
			this.c1 = (int4)v;
		}

		// Token: 0x06001D05 RID: 7429 RVA: 0x0004E746 File Offset: 0x0004C946
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(float4x2 v)
		{
			this.c0 = (int4)v.c0;
			this.c1 = (int4)v.c1;
		}

		// Token: 0x06001D06 RID: 7430 RVA: 0x0004E76A File Offset: 0x0004C96A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(double v)
		{
			this.c0 = (int4)v;
			this.c1 = (int4)v;
		}

		// Token: 0x06001D07 RID: 7431 RVA: 0x0004E784 File Offset: 0x0004C984
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x2(double4x2 v)
		{
			this.c0 = (int4)v.c0;
			this.c1 = (int4)v.c1;
		}

		// Token: 0x06001D08 RID: 7432 RVA: 0x0004E7A8 File Offset: 0x0004C9A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int4x2(int v)
		{
			return new int4x2(v);
		}

		// Token: 0x06001D09 RID: 7433 RVA: 0x0004E7B0 File Offset: 0x0004C9B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x2(bool v)
		{
			return new int4x2(v);
		}

		// Token: 0x06001D0A RID: 7434 RVA: 0x0004E7B8 File Offset: 0x0004C9B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x2(bool4x2 v)
		{
			return new int4x2(v);
		}

		// Token: 0x06001D0B RID: 7435 RVA: 0x0004E7C0 File Offset: 0x0004C9C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x2(uint v)
		{
			return new int4x2(v);
		}

		// Token: 0x06001D0C RID: 7436 RVA: 0x0004E7C8 File Offset: 0x0004C9C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x2(uint4x2 v)
		{
			return new int4x2(v);
		}

		// Token: 0x06001D0D RID: 7437 RVA: 0x0004E7D0 File Offset: 0x0004C9D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x2(float v)
		{
			return new int4x2(v);
		}

		// Token: 0x06001D0E RID: 7438 RVA: 0x0004E7D8 File Offset: 0x0004C9D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x2(float4x2 v)
		{
			return new int4x2(v);
		}

		// Token: 0x06001D0F RID: 7439 RVA: 0x0004E7E0 File Offset: 0x0004C9E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x2(double v)
		{
			return new int4x2(v);
		}

		// Token: 0x06001D10 RID: 7440 RVA: 0x0004E7E8 File Offset: 0x0004C9E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x2(double4x2 v)
		{
			return new int4x2(v);
		}

		// Token: 0x06001D11 RID: 7441 RVA: 0x0004E7F0 File Offset: 0x0004C9F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator *(int4x2 lhs, int4x2 rhs)
		{
			return new int4x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);
		}

		// Token: 0x06001D12 RID: 7442 RVA: 0x0004E819 File Offset: 0x0004CA19
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator *(int4x2 lhs, int rhs)
		{
			return new int4x2(lhs.c0 * rhs, lhs.c1 * rhs);
		}

		// Token: 0x06001D13 RID: 7443 RVA: 0x0004E838 File Offset: 0x0004CA38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator *(int lhs, int4x2 rhs)
		{
			return new int4x2(lhs * rhs.c0, lhs * rhs.c1);
		}

		// Token: 0x06001D14 RID: 7444 RVA: 0x0004E857 File Offset: 0x0004CA57
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator +(int4x2 lhs, int4x2 rhs)
		{
			return new int4x2(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);
		}

		// Token: 0x06001D15 RID: 7445 RVA: 0x0004E880 File Offset: 0x0004CA80
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator +(int4x2 lhs, int rhs)
		{
			return new int4x2(lhs.c0 + rhs, lhs.c1 + rhs);
		}

		// Token: 0x06001D16 RID: 7446 RVA: 0x0004E89F File Offset: 0x0004CA9F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator +(int lhs, int4x2 rhs)
		{
			return new int4x2(lhs + rhs.c0, lhs + rhs.c1);
		}

		// Token: 0x06001D17 RID: 7447 RVA: 0x0004E8BE File Offset: 0x0004CABE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator -(int4x2 lhs, int4x2 rhs)
		{
			return new int4x2(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);
		}

		// Token: 0x06001D18 RID: 7448 RVA: 0x0004E8E7 File Offset: 0x0004CAE7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator -(int4x2 lhs, int rhs)
		{
			return new int4x2(lhs.c0 - rhs, lhs.c1 - rhs);
		}

		// Token: 0x06001D19 RID: 7449 RVA: 0x0004E906 File Offset: 0x0004CB06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator -(int lhs, int4x2 rhs)
		{
			return new int4x2(lhs - rhs.c0, lhs - rhs.c1);
		}

		// Token: 0x06001D1A RID: 7450 RVA: 0x0004E925 File Offset: 0x0004CB25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator /(int4x2 lhs, int4x2 rhs)
		{
			return new int4x2(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);
		}

		// Token: 0x06001D1B RID: 7451 RVA: 0x0004E94E File Offset: 0x0004CB4E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator /(int4x2 lhs, int rhs)
		{
			return new int4x2(lhs.c0 / rhs, lhs.c1 / rhs);
		}

		// Token: 0x06001D1C RID: 7452 RVA: 0x0004E96D File Offset: 0x0004CB6D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator /(int lhs, int4x2 rhs)
		{
			return new int4x2(lhs / rhs.c0, lhs / rhs.c1);
		}

		// Token: 0x06001D1D RID: 7453 RVA: 0x0004E98C File Offset: 0x0004CB8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator %(int4x2 lhs, int4x2 rhs)
		{
			return new int4x2(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);
		}

		// Token: 0x06001D1E RID: 7454 RVA: 0x0004E9B5 File Offset: 0x0004CBB5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator %(int4x2 lhs, int rhs)
		{
			return new int4x2(lhs.c0 % rhs, lhs.c1 % rhs);
		}

		// Token: 0x06001D1F RID: 7455 RVA: 0x0004E9D4 File Offset: 0x0004CBD4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator %(int lhs, int4x2 rhs)
		{
			return new int4x2(lhs % rhs.c0, lhs % rhs.c1);
		}

		// Token: 0x06001D20 RID: 7456 RVA: 0x0004E9F4 File Offset: 0x0004CBF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator ++(int4x2 val)
		{
			int4 @int = ++val.c0;
			val.c0 = @int;
			int4 int2 = @int;
			@int = ++val.c1;
			val.c1 = @int;
			return new int4x2(int2, @int);
		}

		// Token: 0x06001D21 RID: 7457 RVA: 0x0004EA3C File Offset: 0x0004CC3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator --(int4x2 val)
		{
			int4 @int = --val.c0;
			val.c0 = @int;
			int4 int2 = @int;
			@int = --val.c1;
			val.c1 = @int;
			return new int4x2(int2, @int);
		}

		// Token: 0x06001D22 RID: 7458 RVA: 0x0004EA82 File Offset: 0x0004CC82
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(int4x2 lhs, int4x2 rhs)
		{
			return new bool4x2(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);
		}

		// Token: 0x06001D23 RID: 7459 RVA: 0x0004EAAB File Offset: 0x0004CCAB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(int4x2 lhs, int rhs)
		{
			return new bool4x2(lhs.c0 < rhs, lhs.c1 < rhs);
		}

		// Token: 0x06001D24 RID: 7460 RVA: 0x0004EACA File Offset: 0x0004CCCA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(int lhs, int4x2 rhs)
		{
			return new bool4x2(lhs < rhs.c0, lhs < rhs.c1);
		}

		// Token: 0x06001D25 RID: 7461 RVA: 0x0004EAE9 File Offset: 0x0004CCE9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(int4x2 lhs, int4x2 rhs)
		{
			return new bool4x2(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);
		}

		// Token: 0x06001D26 RID: 7462 RVA: 0x0004EB12 File Offset: 0x0004CD12
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(int4x2 lhs, int rhs)
		{
			return new bool4x2(lhs.c0 <= rhs, lhs.c1 <= rhs);
		}

		// Token: 0x06001D27 RID: 7463 RVA: 0x0004EB31 File Offset: 0x0004CD31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(int lhs, int4x2 rhs)
		{
			return new bool4x2(lhs <= rhs.c0, lhs <= rhs.c1);
		}

		// Token: 0x06001D28 RID: 7464 RVA: 0x0004EB50 File Offset: 0x0004CD50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(int4x2 lhs, int4x2 rhs)
		{
			return new bool4x2(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);
		}

		// Token: 0x06001D29 RID: 7465 RVA: 0x0004EB79 File Offset: 0x0004CD79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(int4x2 lhs, int rhs)
		{
			return new bool4x2(lhs.c0 > rhs, lhs.c1 > rhs);
		}

		// Token: 0x06001D2A RID: 7466 RVA: 0x0004EB98 File Offset: 0x0004CD98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(int lhs, int4x2 rhs)
		{
			return new bool4x2(lhs > rhs.c0, lhs > rhs.c1);
		}

		// Token: 0x06001D2B RID: 7467 RVA: 0x0004EBB7 File Offset: 0x0004CDB7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(int4x2 lhs, int4x2 rhs)
		{
			return new bool4x2(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);
		}

		// Token: 0x06001D2C RID: 7468 RVA: 0x0004EBE0 File Offset: 0x0004CDE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(int4x2 lhs, int rhs)
		{
			return new bool4x2(lhs.c0 >= rhs, lhs.c1 >= rhs);
		}

		// Token: 0x06001D2D RID: 7469 RVA: 0x0004EBFF File Offset: 0x0004CDFF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(int lhs, int4x2 rhs)
		{
			return new bool4x2(lhs >= rhs.c0, lhs >= rhs.c1);
		}

		// Token: 0x06001D2E RID: 7470 RVA: 0x0004EC1E File Offset: 0x0004CE1E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator -(int4x2 val)
		{
			return new int4x2(-val.c0, -val.c1);
		}

		// Token: 0x06001D2F RID: 7471 RVA: 0x0004EC3B File Offset: 0x0004CE3B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator +(int4x2 val)
		{
			return new int4x2(+val.c0, +val.c1);
		}

		// Token: 0x06001D30 RID: 7472 RVA: 0x0004EC58 File Offset: 0x0004CE58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator <<(int4x2 x, int n)
		{
			return new int4x2(x.c0 << n, x.c1 << n);
		}

		// Token: 0x06001D31 RID: 7473 RVA: 0x0004EC77 File Offset: 0x0004CE77
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator >>(int4x2 x, int n)
		{
			return new int4x2(x.c0 >> n, x.c1 >> n);
		}

		// Token: 0x06001D32 RID: 7474 RVA: 0x0004EC96 File Offset: 0x0004CE96
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(int4x2 lhs, int4x2 rhs)
		{
			return new bool4x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x06001D33 RID: 7475 RVA: 0x0004ECBF File Offset: 0x0004CEBF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(int4x2 lhs, int rhs)
		{
			return new bool4x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x06001D34 RID: 7476 RVA: 0x0004ECDE File Offset: 0x0004CEDE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(int lhs, int4x2 rhs)
		{
			return new bool4x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x06001D35 RID: 7477 RVA: 0x0004ECFD File Offset: 0x0004CEFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(int4x2 lhs, int4x2 rhs)
		{
			return new bool4x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x06001D36 RID: 7478 RVA: 0x0004ED26 File Offset: 0x0004CF26
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(int4x2 lhs, int rhs)
		{
			return new bool4x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x06001D37 RID: 7479 RVA: 0x0004ED45 File Offset: 0x0004CF45
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(int lhs, int4x2 rhs)
		{
			return new bool4x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x06001D38 RID: 7480 RVA: 0x0004ED64 File Offset: 0x0004CF64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator ~(int4x2 val)
		{
			return new int4x2(~val.c0, ~val.c1);
		}

		// Token: 0x06001D39 RID: 7481 RVA: 0x0004ED81 File Offset: 0x0004CF81
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator &(int4x2 lhs, int4x2 rhs)
		{
			return new int4x2(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);
		}

		// Token: 0x06001D3A RID: 7482 RVA: 0x0004EDAA File Offset: 0x0004CFAA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator &(int4x2 lhs, int rhs)
		{
			return new int4x2(lhs.c0 & rhs, lhs.c1 & rhs);
		}

		// Token: 0x06001D3B RID: 7483 RVA: 0x0004EDC9 File Offset: 0x0004CFC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator &(int lhs, int4x2 rhs)
		{
			return new int4x2(lhs & rhs.c0, lhs & rhs.c1);
		}

		// Token: 0x06001D3C RID: 7484 RVA: 0x0004EDE8 File Offset: 0x0004CFE8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator |(int4x2 lhs, int4x2 rhs)
		{
			return new int4x2(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);
		}

		// Token: 0x06001D3D RID: 7485 RVA: 0x0004EE11 File Offset: 0x0004D011
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator |(int4x2 lhs, int rhs)
		{
			return new int4x2(lhs.c0 | rhs, lhs.c1 | rhs);
		}

		// Token: 0x06001D3E RID: 7486 RVA: 0x0004EE30 File Offset: 0x0004D030
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator |(int lhs, int4x2 rhs)
		{
			return new int4x2(lhs | rhs.c0, lhs | rhs.c1);
		}

		// Token: 0x06001D3F RID: 7487 RVA: 0x0004EE4F File Offset: 0x0004D04F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator ^(int4x2 lhs, int4x2 rhs)
		{
			return new int4x2(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);
		}

		// Token: 0x06001D40 RID: 7488 RVA: 0x0004EE78 File Offset: 0x0004D078
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator ^(int4x2 lhs, int rhs)
		{
			return new int4x2(lhs.c0 ^ rhs, lhs.c1 ^ rhs);
		}

		// Token: 0x06001D41 RID: 7489 RVA: 0x0004EE97 File Offset: 0x0004D097
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x2 operator ^(int lhs, int4x2 rhs)
		{
			return new int4x2(lhs ^ rhs.c0, lhs ^ rhs.c1);
		}

		// Token: 0x1700099A RID: 2458
		public unsafe int4 this[int index]
		{
			get
			{
				fixed (int4x2* ptr = &this)
				{
					return ref *(int4*)(ptr + (IntPtr)index * (IntPtr)sizeof(int4) / (IntPtr)sizeof(int4x2));
				}
			}
		}

		// Token: 0x06001D43 RID: 7491 RVA: 0x0004EED3 File Offset: 0x0004D0D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int4x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x06001D44 RID: 7492 RVA: 0x0004EEFC File Offset: 0x0004D0FC
		public override bool Equals(object o)
		{
			if (o is int4x2)
			{
				int4x2 rhs = (int4x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001D45 RID: 7493 RVA: 0x0004EF21 File Offset: 0x0004D121
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001D46 RID: 7494 RVA: 0x0004EF30 File Offset: 0x0004D130
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int4x2({0}, {1},  {2}, {3},  {4}, {5},  {6}, {7})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y,
				this.c0.z,
				this.c1.z,
				this.c0.w,
				this.c1.w
			});
		}

		// Token: 0x06001D47 RID: 7495 RVA: 0x0004EFE8 File Offset: 0x0004D1E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int4x2({0}, {1},  {2}, {3},  {4}, {5},  {6}, {7})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c0.w.ToString(format, formatProvider),
				this.c1.w.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000D5 RID: 213
		public int4 c0;

		// Token: 0x040000D6 RID: 214
		public int4 c1;

		// Token: 0x040000D7 RID: 215
		public static readonly int4x2 zero;
	}
}
