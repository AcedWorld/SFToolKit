using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000037 RID: 55
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int4x3 : IEquatable<int4x3>, IFormattable
	{
		// Token: 0x06001D48 RID: 7496 RVA: 0x0004F0AD File Offset: 0x0004D2AD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(int4 c0, int4 c1, int4 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x06001D49 RID: 7497 RVA: 0x0004F0C4 File Offset: 0x0004D2C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(int m00, int m01, int m02, int m10, int m11, int m12, int m20, int m21, int m22, int m30, int m31, int m32)
		{
			this.c0 = new int4(m00, m10, m20, m30);
			this.c1 = new int4(m01, m11, m21, m31);
			this.c2 = new int4(m02, m12, m22, m32);
		}

		// Token: 0x06001D4A RID: 7498 RVA: 0x0004F0FC File Offset: 0x0004D2FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(int v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06001D4B RID: 7499 RVA: 0x0004F124 File Offset: 0x0004D324
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(bool v)
		{
			this.c0 = math.select(new int4(0), new int4(1), v);
			this.c1 = math.select(new int4(0), new int4(1), v);
			this.c2 = math.select(new int4(0), new int4(1), v);
		}

		// Token: 0x06001D4C RID: 7500 RVA: 0x0004F17C File Offset: 0x0004D37C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(bool4x3 v)
		{
			this.c0 = math.select(new int4(0), new int4(1), v.c0);
			this.c1 = math.select(new int4(0), new int4(1), v.c1);
			this.c2 = math.select(new int4(0), new int4(1), v.c2);
		}

		// Token: 0x06001D4D RID: 7501 RVA: 0x0004F1E0 File Offset: 0x0004D3E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(uint v)
		{
			this.c0 = (int4)v;
			this.c1 = (int4)v;
			this.c2 = (int4)v;
		}

		// Token: 0x06001D4E RID: 7502 RVA: 0x0004F206 File Offset: 0x0004D406
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(uint4x3 v)
		{
			this.c0 = (int4)v.c0;
			this.c1 = (int4)v.c1;
			this.c2 = (int4)v.c2;
		}

		// Token: 0x06001D4F RID: 7503 RVA: 0x0004F23B File Offset: 0x0004D43B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(float v)
		{
			this.c0 = (int4)v;
			this.c1 = (int4)v;
			this.c2 = (int4)v;
		}

		// Token: 0x06001D50 RID: 7504 RVA: 0x0004F261 File Offset: 0x0004D461
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(float4x3 v)
		{
			this.c0 = (int4)v.c0;
			this.c1 = (int4)v.c1;
			this.c2 = (int4)v.c2;
		}

		// Token: 0x06001D51 RID: 7505 RVA: 0x0004F296 File Offset: 0x0004D496
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(double v)
		{
			this.c0 = (int4)v;
			this.c1 = (int4)v;
			this.c2 = (int4)v;
		}

		// Token: 0x06001D52 RID: 7506 RVA: 0x0004F2BC File Offset: 0x0004D4BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int4x3(double4x3 v)
		{
			this.c0 = (int4)v.c0;
			this.c1 = (int4)v.c1;
			this.c2 = (int4)v.c2;
		}

		// Token: 0x06001D53 RID: 7507 RVA: 0x0004F2F1 File Offset: 0x0004D4F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int4x3(int v)
		{
			return new int4x3(v);
		}

		// Token: 0x06001D54 RID: 7508 RVA: 0x0004F2F9 File Offset: 0x0004D4F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x3(bool v)
		{
			return new int4x3(v);
		}

		// Token: 0x06001D55 RID: 7509 RVA: 0x0004F301 File Offset: 0x0004D501
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x3(bool4x3 v)
		{
			return new int4x3(v);
		}

		// Token: 0x06001D56 RID: 7510 RVA: 0x0004F309 File Offset: 0x0004D509
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x3(uint v)
		{
			return new int4x3(v);
		}

		// Token: 0x06001D57 RID: 7511 RVA: 0x0004F311 File Offset: 0x0004D511
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x3(uint4x3 v)
		{
			return new int4x3(v);
		}

		// Token: 0x06001D58 RID: 7512 RVA: 0x0004F319 File Offset: 0x0004D519
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x3(float v)
		{
			return new int4x3(v);
		}

		// Token: 0x06001D59 RID: 7513 RVA: 0x0004F321 File Offset: 0x0004D521
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x3(float4x3 v)
		{
			return new int4x3(v);
		}

		// Token: 0x06001D5A RID: 7514 RVA: 0x0004F329 File Offset: 0x0004D529
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x3(double v)
		{
			return new int4x3(v);
		}

		// Token: 0x06001D5B RID: 7515 RVA: 0x0004F331 File Offset: 0x0004D531
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int4x3(double4x3 v)
		{
			return new int4x3(v);
		}

		// Token: 0x06001D5C RID: 7516 RVA: 0x0004F339 File Offset: 0x0004D539
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator *(int4x3 lhs, int4x3 rhs)
		{
			return new int4x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x06001D5D RID: 7517 RVA: 0x0004F373 File Offset: 0x0004D573
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator *(int4x3 lhs, int rhs)
		{
			return new int4x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x06001D5E RID: 7518 RVA: 0x0004F39E File Offset: 0x0004D59E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator *(int lhs, int4x3 rhs)
		{
			return new int4x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x06001D5F RID: 7519 RVA: 0x0004F3C9 File Offset: 0x0004D5C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator +(int4x3 lhs, int4x3 rhs)
		{
			return new int4x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x06001D60 RID: 7520 RVA: 0x0004F403 File Offset: 0x0004D603
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator +(int4x3 lhs, int rhs)
		{
			return new int4x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x06001D61 RID: 7521 RVA: 0x0004F42E File Offset: 0x0004D62E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator +(int lhs, int4x3 rhs)
		{
			return new int4x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x06001D62 RID: 7522 RVA: 0x0004F459 File Offset: 0x0004D659
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator -(int4x3 lhs, int4x3 rhs)
		{
			return new int4x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x06001D63 RID: 7523 RVA: 0x0004F493 File Offset: 0x0004D693
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator -(int4x3 lhs, int rhs)
		{
			return new int4x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x06001D64 RID: 7524 RVA: 0x0004F4BE File Offset: 0x0004D6BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator -(int lhs, int4x3 rhs)
		{
			return new int4x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x06001D65 RID: 7525 RVA: 0x0004F4E9 File Offset: 0x0004D6E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator /(int4x3 lhs, int4x3 rhs)
		{
			return new int4x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x06001D66 RID: 7526 RVA: 0x0004F523 File Offset: 0x0004D723
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator /(int4x3 lhs, int rhs)
		{
			return new int4x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x06001D67 RID: 7527 RVA: 0x0004F54E File Offset: 0x0004D74E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator /(int lhs, int4x3 rhs)
		{
			return new int4x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x06001D68 RID: 7528 RVA: 0x0004F579 File Offset: 0x0004D779
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator %(int4x3 lhs, int4x3 rhs)
		{
			return new int4x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x06001D69 RID: 7529 RVA: 0x0004F5B3 File Offset: 0x0004D7B3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator %(int4x3 lhs, int rhs)
		{
			return new int4x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x06001D6A RID: 7530 RVA: 0x0004F5DE File Offset: 0x0004D7DE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator %(int lhs, int4x3 rhs)
		{
			return new int4x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x06001D6B RID: 7531 RVA: 0x0004F60C File Offset: 0x0004D80C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator ++(int4x3 val)
		{
			int4 @int = ++val.c0;
			val.c0 = @int;
			int4 int2 = @int;
			@int = ++val.c1;
			val.c1 = @int;
			int4 int3 = @int;
			@int = ++val.c2;
			val.c2 = @int;
			return new int4x3(int2, int3, @int);
		}

		// Token: 0x06001D6C RID: 7532 RVA: 0x0004F66C File Offset: 0x0004D86C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator --(int4x3 val)
		{
			int4 @int = --val.c0;
			val.c0 = @int;
			int4 int2 = @int;
			@int = --val.c1;
			val.c1 = @int;
			int4 int3 = @int;
			@int = --val.c2;
			val.c2 = @int;
			return new int4x3(int2, int3, @int);
		}

		// Token: 0x06001D6D RID: 7533 RVA: 0x0004F6CC File Offset: 0x0004D8CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(int4x3 lhs, int4x3 rhs)
		{
			return new bool4x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x06001D6E RID: 7534 RVA: 0x0004F706 File Offset: 0x0004D906
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(int4x3 lhs, int rhs)
		{
			return new bool4x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x06001D6F RID: 7535 RVA: 0x0004F731 File Offset: 0x0004D931
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <(int lhs, int4x3 rhs)
		{
			return new bool4x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x06001D70 RID: 7536 RVA: 0x0004F75C File Offset: 0x0004D95C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(int4x3 lhs, int4x3 rhs)
		{
			return new bool4x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x06001D71 RID: 7537 RVA: 0x0004F796 File Offset: 0x0004D996
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(int4x3 lhs, int rhs)
		{
			return new bool4x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x06001D72 RID: 7538 RVA: 0x0004F7C1 File Offset: 0x0004D9C1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator <=(int lhs, int4x3 rhs)
		{
			return new bool4x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x06001D73 RID: 7539 RVA: 0x0004F7EC File Offset: 0x0004D9EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(int4x3 lhs, int4x3 rhs)
		{
			return new bool4x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x06001D74 RID: 7540 RVA: 0x0004F826 File Offset: 0x0004DA26
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(int4x3 lhs, int rhs)
		{
			return new bool4x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x06001D75 RID: 7541 RVA: 0x0004F851 File Offset: 0x0004DA51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >(int lhs, int4x3 rhs)
		{
			return new bool4x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x06001D76 RID: 7542 RVA: 0x0004F87C File Offset: 0x0004DA7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(int4x3 lhs, int4x3 rhs)
		{
			return new bool4x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x06001D77 RID: 7543 RVA: 0x0004F8B6 File Offset: 0x0004DAB6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(int4x3 lhs, int rhs)
		{
			return new bool4x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x06001D78 RID: 7544 RVA: 0x0004F8E1 File Offset: 0x0004DAE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator >=(int lhs, int4x3 rhs)
		{
			return new bool4x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x06001D79 RID: 7545 RVA: 0x0004F90C File Offset: 0x0004DB0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator -(int4x3 val)
		{
			return new int4x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x06001D7A RID: 7546 RVA: 0x0004F934 File Offset: 0x0004DB34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator +(int4x3 val)
		{
			return new int4x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x06001D7B RID: 7547 RVA: 0x0004F95C File Offset: 0x0004DB5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator <<(int4x3 x, int n)
		{
			return new int4x3(x.c0 << n, x.c1 << n, x.c2 << n);
		}

		// Token: 0x06001D7C RID: 7548 RVA: 0x0004F987 File Offset: 0x0004DB87
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator >>(int4x3 x, int n)
		{
			return new int4x3(x.c0 >> n, x.c1 >> n, x.c2 >> n);
		}

		// Token: 0x06001D7D RID: 7549 RVA: 0x0004F9B2 File Offset: 0x0004DBB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(int4x3 lhs, int4x3 rhs)
		{
			return new bool4x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x06001D7E RID: 7550 RVA: 0x0004F9EC File Offset: 0x0004DBEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(int4x3 lhs, int rhs)
		{
			return new bool4x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x06001D7F RID: 7551 RVA: 0x0004FA17 File Offset: 0x0004DC17
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator ==(int lhs, int4x3 rhs)
		{
			return new bool4x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x0004FA42 File Offset: 0x0004DC42
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(int4x3 lhs, int4x3 rhs)
		{
			return new bool4x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x06001D81 RID: 7553 RVA: 0x0004FA7C File Offset: 0x0004DC7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(int4x3 lhs, int rhs)
		{
			return new bool4x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x06001D82 RID: 7554 RVA: 0x0004FAA7 File Offset: 0x0004DCA7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x3 operator !=(int lhs, int4x3 rhs)
		{
			return new bool4x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x06001D83 RID: 7555 RVA: 0x0004FAD2 File Offset: 0x0004DCD2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator ~(int4x3 val)
		{
			return new int4x3(~val.c0, ~val.c1, ~val.c2);
		}

		// Token: 0x06001D84 RID: 7556 RVA: 0x0004FAFA File Offset: 0x0004DCFA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator &(int4x3 lhs, int4x3 rhs)
		{
			return new int4x3(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);
		}

		// Token: 0x06001D85 RID: 7557 RVA: 0x0004FB34 File Offset: 0x0004DD34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator &(int4x3 lhs, int rhs)
		{
			return new int4x3(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs);
		}

		// Token: 0x06001D86 RID: 7558 RVA: 0x0004FB5F File Offset: 0x0004DD5F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator &(int lhs, int4x3 rhs)
		{
			return new int4x3(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2);
		}

		// Token: 0x06001D87 RID: 7559 RVA: 0x0004FB8A File Offset: 0x0004DD8A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator |(int4x3 lhs, int4x3 rhs)
		{
			return new int4x3(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);
		}

		// Token: 0x06001D88 RID: 7560 RVA: 0x0004FBC4 File Offset: 0x0004DDC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator |(int4x3 lhs, int rhs)
		{
			return new int4x3(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs);
		}

		// Token: 0x06001D89 RID: 7561 RVA: 0x0004FBEF File Offset: 0x0004DDEF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator |(int lhs, int4x3 rhs)
		{
			return new int4x3(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2);
		}

		// Token: 0x06001D8A RID: 7562 RVA: 0x0004FC1A File Offset: 0x0004DE1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator ^(int4x3 lhs, int4x3 rhs)
		{
			return new int4x3(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);
		}

		// Token: 0x06001D8B RID: 7563 RVA: 0x0004FC54 File Offset: 0x0004DE54
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator ^(int4x3 lhs, int rhs)
		{
			return new int4x3(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs);
		}

		// Token: 0x06001D8C RID: 7564 RVA: 0x0004FC7F File Offset: 0x0004DE7F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4x3 operator ^(int lhs, int4x3 rhs)
		{
			return new int4x3(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2);
		}

		// Token: 0x1700099B RID: 2459
		public unsafe int4 this[int index]
		{
			get
			{
				fixed (int4x3* ptr = &this)
				{
					return ref *(int4*)(ptr + (IntPtr)index * (IntPtr)sizeof(int4) / (IntPtr)sizeof(int4x3));
				}
			}
		}

		// Token: 0x06001D8E RID: 7566 RVA: 0x0004FCC7 File Offset: 0x0004DEC7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int4x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x06001D8F RID: 7567 RVA: 0x0004FD04 File Offset: 0x0004DF04
		public override bool Equals(object o)
		{
			if (o is int4x3)
			{
				int4x3 rhs = (int4x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001D90 RID: 7568 RVA: 0x0004FD29 File Offset: 0x0004DF29
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001D91 RID: 7569 RVA: 0x0004FD38 File Offset: 0x0004DF38
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int4x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8},  {9}, {10}, {11})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c0.z,
				this.c1.z,
				this.c2.z,
				this.c0.w,
				this.c1.w,
				this.c2.w
			});
		}

		// Token: 0x06001D92 RID: 7570 RVA: 0x0004FE40 File Offset: 0x0004E040
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int4x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8},  {9}, {10}, {11})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider),
				this.c2.z.ToString(format, formatProvider),
				this.c0.w.ToString(format, formatProvider),
				this.c1.w.ToString(format, formatProvider),
				this.c2.w.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000D8 RID: 216
		public int4 c0;

		// Token: 0x040000D9 RID: 217
		public int4 c1;

		// Token: 0x040000DA RID: 218
		public int4 c2;

		// Token: 0x040000DB RID: 219
		public static readonly int4x3 zero;
	}
}
