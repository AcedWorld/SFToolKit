using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000045 RID: 69
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct uint3x3 : IEquatable<uint3x3>, IFormattable
	{
		// Token: 0x060020EE RID: 8430 RVA: 0x0005E1E3 File Offset: 0x0005C3E3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(uint3 c0, uint3 c1, uint3 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x060020EF RID: 8431 RVA: 0x0005E1FA File Offset: 0x0005C3FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(uint m00, uint m01, uint m02, uint m10, uint m11, uint m12, uint m20, uint m21, uint m22)
		{
			this.c0 = new uint3(m00, m10, m20);
			this.c1 = new uint3(m01, m11, m21);
			this.c2 = new uint3(m02, m12, m22);
		}

		// Token: 0x060020F0 RID: 8432 RVA: 0x0005E22C File Offset: 0x0005C42C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060020F1 RID: 8433 RVA: 0x0005E254 File Offset: 0x0005C454
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(bool v)
		{
			this.c0 = math.select(new uint3(0U), new uint3(1U), v);
			this.c1 = math.select(new uint3(0U), new uint3(1U), v);
			this.c2 = math.select(new uint3(0U), new uint3(1U), v);
		}

		// Token: 0x060020F2 RID: 8434 RVA: 0x0005E2AC File Offset: 0x0005C4AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(bool3x3 v)
		{
			this.c0 = math.select(new uint3(0U), new uint3(1U), v.c0);
			this.c1 = math.select(new uint3(0U), new uint3(1U), v.c1);
			this.c2 = math.select(new uint3(0U), new uint3(1U), v.c2);
		}

		// Token: 0x060020F3 RID: 8435 RVA: 0x0005E310 File Offset: 0x0005C510
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(int v)
		{
			this.c0 = (uint3)v;
			this.c1 = (uint3)v;
			this.c2 = (uint3)v;
		}

		// Token: 0x060020F4 RID: 8436 RVA: 0x0005E336 File Offset: 0x0005C536
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(int3x3 v)
		{
			this.c0 = (uint3)v.c0;
			this.c1 = (uint3)v.c1;
			this.c2 = (uint3)v.c2;
		}

		// Token: 0x060020F5 RID: 8437 RVA: 0x0005E36B File Offset: 0x0005C56B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(float v)
		{
			this.c0 = (uint3)v;
			this.c1 = (uint3)v;
			this.c2 = (uint3)v;
		}

		// Token: 0x060020F6 RID: 8438 RVA: 0x0005E391 File Offset: 0x0005C591
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(float3x3 v)
		{
			this.c0 = (uint3)v.c0;
			this.c1 = (uint3)v.c1;
			this.c2 = (uint3)v.c2;
		}

		// Token: 0x060020F7 RID: 8439 RVA: 0x0005E3C6 File Offset: 0x0005C5C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(double v)
		{
			this.c0 = (uint3)v;
			this.c1 = (uint3)v;
			this.c2 = (uint3)v;
		}

		// Token: 0x060020F8 RID: 8440 RVA: 0x0005E3EC File Offset: 0x0005C5EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x3(double3x3 v)
		{
			this.c0 = (uint3)v.c0;
			this.c1 = (uint3)v.c1;
			this.c2 = (uint3)v.c2;
		}

		// Token: 0x060020F9 RID: 8441 RVA: 0x0005E421 File Offset: 0x0005C621
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator uint3x3(uint v)
		{
			return new uint3x3(v);
		}

		// Token: 0x060020FA RID: 8442 RVA: 0x0005E429 File Offset: 0x0005C629
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x3(bool v)
		{
			return new uint3x3(v);
		}

		// Token: 0x060020FB RID: 8443 RVA: 0x0005E431 File Offset: 0x0005C631
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x3(bool3x3 v)
		{
			return new uint3x3(v);
		}

		// Token: 0x060020FC RID: 8444 RVA: 0x0005E439 File Offset: 0x0005C639
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x3(int v)
		{
			return new uint3x3(v);
		}

		// Token: 0x060020FD RID: 8445 RVA: 0x0005E441 File Offset: 0x0005C641
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x3(int3x3 v)
		{
			return new uint3x3(v);
		}

		// Token: 0x060020FE RID: 8446 RVA: 0x0005E449 File Offset: 0x0005C649
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x3(float v)
		{
			return new uint3x3(v);
		}

		// Token: 0x060020FF RID: 8447 RVA: 0x0005E451 File Offset: 0x0005C651
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x3(float3x3 v)
		{
			return new uint3x3(v);
		}

		// Token: 0x06002100 RID: 8448 RVA: 0x0005E459 File Offset: 0x0005C659
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x3(double v)
		{
			return new uint3x3(v);
		}

		// Token: 0x06002101 RID: 8449 RVA: 0x0005E461 File Offset: 0x0005C661
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x3(double3x3 v)
		{
			return new uint3x3(v);
		}

		// Token: 0x06002102 RID: 8450 RVA: 0x0005E469 File Offset: 0x0005C669
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator *(uint3x3 lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x06002103 RID: 8451 RVA: 0x0005E4A3 File Offset: 0x0005C6A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator *(uint3x3 lhs, uint rhs)
		{
			return new uint3x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x06002104 RID: 8452 RVA: 0x0005E4CE File Offset: 0x0005C6CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator *(uint lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x06002105 RID: 8453 RVA: 0x0005E4F9 File Offset: 0x0005C6F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator +(uint3x3 lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x06002106 RID: 8454 RVA: 0x0005E533 File Offset: 0x0005C733
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator +(uint3x3 lhs, uint rhs)
		{
			return new uint3x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x06002107 RID: 8455 RVA: 0x0005E55E File Offset: 0x0005C75E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator +(uint lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x06002108 RID: 8456 RVA: 0x0005E589 File Offset: 0x0005C789
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator -(uint3x3 lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x06002109 RID: 8457 RVA: 0x0005E5C3 File Offset: 0x0005C7C3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator -(uint3x3 lhs, uint rhs)
		{
			return new uint3x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x0600210A RID: 8458 RVA: 0x0005E5EE File Offset: 0x0005C7EE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator -(uint lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x0600210B RID: 8459 RVA: 0x0005E619 File Offset: 0x0005C819
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator /(uint3x3 lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x0600210C RID: 8460 RVA: 0x0005E653 File Offset: 0x0005C853
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator /(uint3x3 lhs, uint rhs)
		{
			return new uint3x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x0600210D RID: 8461 RVA: 0x0005E67E File Offset: 0x0005C87E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator /(uint lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x0600210E RID: 8462 RVA: 0x0005E6A9 File Offset: 0x0005C8A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator %(uint3x3 lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x0600210F RID: 8463 RVA: 0x0005E6E3 File Offset: 0x0005C8E3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator %(uint3x3 lhs, uint rhs)
		{
			return new uint3x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x06002110 RID: 8464 RVA: 0x0005E70E File Offset: 0x0005C90E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator %(uint lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x06002111 RID: 8465 RVA: 0x0005E73C File Offset: 0x0005C93C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator ++(uint3x3 val)
		{
			uint3 @uint = ++val.c0;
			val.c0 = @uint;
			uint3 uint2 = @uint;
			@uint = ++val.c1;
			val.c1 = @uint;
			uint3 uint3 = @uint;
			@uint = ++val.c2;
			val.c2 = @uint;
			return new uint3x3(uint2, uint3, @uint);
		}

		// Token: 0x06002112 RID: 8466 RVA: 0x0005E79C File Offset: 0x0005C99C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator --(uint3x3 val)
		{
			uint3 @uint = --val.c0;
			val.c0 = @uint;
			uint3 uint2 = @uint;
			@uint = --val.c1;
			val.c1 = @uint;
			uint3 uint3 = @uint;
			@uint = --val.c2;
			val.c2 = @uint;
			return new uint3x3(uint2, uint3, @uint);
		}

		// Token: 0x06002113 RID: 8467 RVA: 0x0005E7FC File Offset: 0x0005C9FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(uint3x3 lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x06002114 RID: 8468 RVA: 0x0005E836 File Offset: 0x0005CA36
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(uint3x3 lhs, uint rhs)
		{
			return new bool3x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x06002115 RID: 8469 RVA: 0x0005E861 File Offset: 0x0005CA61
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <(uint lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x06002116 RID: 8470 RVA: 0x0005E88C File Offset: 0x0005CA8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(uint3x3 lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x06002117 RID: 8471 RVA: 0x0005E8C6 File Offset: 0x0005CAC6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(uint3x3 lhs, uint rhs)
		{
			return new bool3x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x06002118 RID: 8472 RVA: 0x0005E8F1 File Offset: 0x0005CAF1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator <=(uint lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x06002119 RID: 8473 RVA: 0x0005E91C File Offset: 0x0005CB1C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(uint3x3 lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x0600211A RID: 8474 RVA: 0x0005E956 File Offset: 0x0005CB56
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(uint3x3 lhs, uint rhs)
		{
			return new bool3x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x0600211B RID: 8475 RVA: 0x0005E981 File Offset: 0x0005CB81
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >(uint lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x0600211C RID: 8476 RVA: 0x0005E9AC File Offset: 0x0005CBAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(uint3x3 lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x0600211D RID: 8477 RVA: 0x0005E9E6 File Offset: 0x0005CBE6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(uint3x3 lhs, uint rhs)
		{
			return new bool3x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x0600211E RID: 8478 RVA: 0x0005EA11 File Offset: 0x0005CC11
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator >=(uint lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x0600211F RID: 8479 RVA: 0x0005EA3C File Offset: 0x0005CC3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator -(uint3x3 val)
		{
			return new uint3x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x06002120 RID: 8480 RVA: 0x0005EA64 File Offset: 0x0005CC64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator +(uint3x3 val)
		{
			return new uint3x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x06002121 RID: 8481 RVA: 0x0005EA8C File Offset: 0x0005CC8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator <<(uint3x3 x, int n)
		{
			return new uint3x3(x.c0 << n, x.c1 << n, x.c2 << n);
		}

		// Token: 0x06002122 RID: 8482 RVA: 0x0005EAB7 File Offset: 0x0005CCB7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator >>(uint3x3 x, int n)
		{
			return new uint3x3(x.c0 >> n, x.c1 >> n, x.c2 >> n);
		}

		// Token: 0x06002123 RID: 8483 RVA: 0x0005EAE2 File Offset: 0x0005CCE2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(uint3x3 lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x06002124 RID: 8484 RVA: 0x0005EB1C File Offset: 0x0005CD1C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(uint3x3 lhs, uint rhs)
		{
			return new bool3x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x06002125 RID: 8485 RVA: 0x0005EB47 File Offset: 0x0005CD47
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(uint lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x06002126 RID: 8486 RVA: 0x0005EB72 File Offset: 0x0005CD72
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(uint3x3 lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x06002127 RID: 8487 RVA: 0x0005EBAC File Offset: 0x0005CDAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(uint3x3 lhs, uint rhs)
		{
			return new bool3x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x06002128 RID: 8488 RVA: 0x0005EBD7 File Offset: 0x0005CDD7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(uint lhs, uint3x3 rhs)
		{
			return new bool3x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x06002129 RID: 8489 RVA: 0x0005EC02 File Offset: 0x0005CE02
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator ~(uint3x3 val)
		{
			return new uint3x3(~val.c0, ~val.c1, ~val.c2);
		}

		// Token: 0x0600212A RID: 8490 RVA: 0x0005EC2A File Offset: 0x0005CE2A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator &(uint3x3 lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);
		}

		// Token: 0x0600212B RID: 8491 RVA: 0x0005EC64 File Offset: 0x0005CE64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator &(uint3x3 lhs, uint rhs)
		{
			return new uint3x3(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs);
		}

		// Token: 0x0600212C RID: 8492 RVA: 0x0005EC8F File Offset: 0x0005CE8F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator &(uint lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2);
		}

		// Token: 0x0600212D RID: 8493 RVA: 0x0005ECBA File Offset: 0x0005CEBA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator |(uint3x3 lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);
		}

		// Token: 0x0600212E RID: 8494 RVA: 0x0005ECF4 File Offset: 0x0005CEF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator |(uint3x3 lhs, uint rhs)
		{
			return new uint3x3(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs);
		}

		// Token: 0x0600212F RID: 8495 RVA: 0x0005ED1F File Offset: 0x0005CF1F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator |(uint lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2);
		}

		// Token: 0x06002130 RID: 8496 RVA: 0x0005ED4A File Offset: 0x0005CF4A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator ^(uint3x3 lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);
		}

		// Token: 0x06002131 RID: 8497 RVA: 0x0005ED84 File Offset: 0x0005CF84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator ^(uint3x3 lhs, uint rhs)
		{
			return new uint3x3(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs);
		}

		// Token: 0x06002132 RID: 8498 RVA: 0x0005EDAF File Offset: 0x0005CFAF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x3 operator ^(uint lhs, uint3x3 rhs)
		{
			return new uint3x3(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2);
		}

		// Token: 0x17000A34 RID: 2612
		public unsafe uint3 this[int index]
		{
			get
			{
				fixed (uint3x3* ptr = &this)
				{
					return ref *(uint3*)(ptr + (IntPtr)index * (IntPtr)sizeof(uint3) / (IntPtr)sizeof(uint3x3));
				}
			}
		}

		// Token: 0x06002134 RID: 8500 RVA: 0x0005EDF7 File Offset: 0x0005CFF7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(uint3x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x06002135 RID: 8501 RVA: 0x0005EE34 File Offset: 0x0005D034
		public override bool Equals(object o)
		{
			if (o is uint3x3)
			{
				uint3x3 rhs = (uint3x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06002136 RID: 8502 RVA: 0x0005EE59 File Offset: 0x0005D059
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06002137 RID: 8503 RVA: 0x0005EE68 File Offset: 0x0005D068
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("uint3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", new object[]
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

		// Token: 0x06002138 RID: 8504 RVA: 0x0005EF34 File Offset: 0x0005D134
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("uint3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", new object[]
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

		// Token: 0x040000FF RID: 255
		public uint3 c0;

		// Token: 0x04000100 RID: 256
		public uint3 c1;

		// Token: 0x04000101 RID: 257
		public uint3 c2;

		// Token: 0x04000102 RID: 258
		public static readonly uint3x3 identity = new uint3x3(1U, 0U, 0U, 0U, 1U, 0U, 0U, 0U, 1U);

		// Token: 0x04000103 RID: 259
		public static readonly uint3x3 zero;
	}
}
