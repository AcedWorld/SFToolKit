using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000031 RID: 49
	[DebuggerTypeProxy(typeof(int3.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int3 : IEquatable<int3>, IFormattable
	{
		// Token: 0x0600196E RID: 6510 RVA: 0x00046351 File Offset: 0x00044551
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		// Token: 0x0600196F RID: 6511 RVA: 0x00046368 File Offset: 0x00044568
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(int x, int2 yz)
		{
			this.x = x;
			this.y = yz.x;
			this.z = yz.y;
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x00046389 File Offset: 0x00044589
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(int2 xy, int z)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = z;
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x000463AA File Offset: 0x000445AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(int3 xyz)
		{
			this.x = xyz.x;
			this.y = xyz.y;
			this.z = xyz.z;
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x000463D0 File Offset: 0x000445D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(int v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
		}

		// Token: 0x06001973 RID: 6515 RVA: 0x000463E7 File Offset: 0x000445E7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(bool v)
		{
			this.x = (v ? 1 : 0);
			this.y = (v ? 1 : 0);
			this.z = (v ? 1 : 0);
		}

		// Token: 0x06001974 RID: 6516 RVA: 0x00046410 File Offset: 0x00044610
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(bool3 v)
		{
			this.x = (v.x ? 1 : 0);
			this.y = (v.y ? 1 : 0);
			this.z = (v.z ? 1 : 0);
		}

		// Token: 0x06001975 RID: 6517 RVA: 0x00046448 File Offset: 0x00044648
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(uint v)
		{
			this.x = (int)v;
			this.y = (int)v;
			this.z = (int)v;
		}

		// Token: 0x06001976 RID: 6518 RVA: 0x0004645F File Offset: 0x0004465F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(uint3 v)
		{
			this.x = (int)v.x;
			this.y = (int)v.y;
			this.z = (int)v.z;
		}

		// Token: 0x06001977 RID: 6519 RVA: 0x00046485 File Offset: 0x00044685
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(float v)
		{
			this.x = (int)v;
			this.y = (int)v;
			this.z = (int)v;
		}

		// Token: 0x06001978 RID: 6520 RVA: 0x0004649F File Offset: 0x0004469F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(float3 v)
		{
			this.x = (int)v.x;
			this.y = (int)v.y;
			this.z = (int)v.z;
		}

		// Token: 0x06001979 RID: 6521 RVA: 0x000464C8 File Offset: 0x000446C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(double v)
		{
			this.x = (int)v;
			this.y = (int)v;
			this.z = (int)v;
		}

		// Token: 0x0600197A RID: 6522 RVA: 0x000464E2 File Offset: 0x000446E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3(double3 v)
		{
			this.x = (int)v.x;
			this.y = (int)v.y;
			this.z = (int)v.z;
		}

		// Token: 0x0600197B RID: 6523 RVA: 0x0004650B File Offset: 0x0004470B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int3(int v)
		{
			return new int3(v);
		}

		// Token: 0x0600197C RID: 6524 RVA: 0x00046513 File Offset: 0x00044713
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3(bool v)
		{
			return new int3(v);
		}

		// Token: 0x0600197D RID: 6525 RVA: 0x0004651B File Offset: 0x0004471B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3(bool3 v)
		{
			return new int3(v);
		}

		// Token: 0x0600197E RID: 6526 RVA: 0x00046523 File Offset: 0x00044723
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3(uint v)
		{
			return new int3(v);
		}

		// Token: 0x0600197F RID: 6527 RVA: 0x0004652B File Offset: 0x0004472B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3(uint3 v)
		{
			return new int3(v);
		}

		// Token: 0x06001980 RID: 6528 RVA: 0x00046533 File Offset: 0x00044733
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3(float v)
		{
			return new int3(v);
		}

		// Token: 0x06001981 RID: 6529 RVA: 0x0004653B File Offset: 0x0004473B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3(float3 v)
		{
			return new int3(v);
		}

		// Token: 0x06001982 RID: 6530 RVA: 0x00046543 File Offset: 0x00044743
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3(double v)
		{
			return new int3(v);
		}

		// Token: 0x06001983 RID: 6531 RVA: 0x0004654B File Offset: 0x0004474B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3(double3 v)
		{
			return new int3(v);
		}

		// Token: 0x06001984 RID: 6532 RVA: 0x00046553 File Offset: 0x00044753
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator *(int3 lhs, int3 rhs)
		{
			return new int3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);
		}

		// Token: 0x06001985 RID: 6533 RVA: 0x00046581 File Offset: 0x00044781
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator *(int3 lhs, int rhs)
		{
			return new int3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
		}

		// Token: 0x06001986 RID: 6534 RVA: 0x000465A0 File Offset: 0x000447A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator *(int lhs, int3 rhs)
		{
			return new int3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x000465BF File Offset: 0x000447BF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator +(int3 lhs, int3 rhs)
		{
			return new int3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
		}

		// Token: 0x06001988 RID: 6536 RVA: 0x000465ED File Offset: 0x000447ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator +(int3 lhs, int rhs)
		{
			return new int3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
		}

		// Token: 0x06001989 RID: 6537 RVA: 0x0004660C File Offset: 0x0004480C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator +(int lhs, int3 rhs)
		{
			return new int3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);
		}

		// Token: 0x0600198A RID: 6538 RVA: 0x0004662B File Offset: 0x0004482B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator -(int3 lhs, int3 rhs)
		{
			return new int3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
		}

		// Token: 0x0600198B RID: 6539 RVA: 0x00046659 File Offset: 0x00044859
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator -(int3 lhs, int rhs)
		{
			return new int3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
		}

		// Token: 0x0600198C RID: 6540 RVA: 0x00046678 File Offset: 0x00044878
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator -(int lhs, int3 rhs)
		{
			return new int3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);
		}

		// Token: 0x0600198D RID: 6541 RVA: 0x00046697 File Offset: 0x00044897
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator /(int3 lhs, int3 rhs)
		{
			return new int3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
		}

		// Token: 0x0600198E RID: 6542 RVA: 0x000466C5 File Offset: 0x000448C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator /(int3 lhs, int rhs)
		{
			return new int3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
		}

		// Token: 0x0600198F RID: 6543 RVA: 0x000466E4 File Offset: 0x000448E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator /(int lhs, int3 rhs)
		{
			return new int3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
		}

		// Token: 0x06001990 RID: 6544 RVA: 0x00046703 File Offset: 0x00044903
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator %(int3 lhs, int3 rhs)
		{
			return new int3(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z);
		}

		// Token: 0x06001991 RID: 6545 RVA: 0x00046731 File Offset: 0x00044931
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator %(int3 lhs, int rhs)
		{
			return new int3(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs);
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x00046750 File Offset: 0x00044950
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator %(int lhs, int3 rhs)
		{
			return new int3(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z);
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x00046770 File Offset: 0x00044970
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator ++(int3 val)
		{
			int num = val.x + 1;
			val.x = num;
			int num2 = num;
			num = val.y + 1;
			val.y = num;
			int num3 = num;
			num = val.z + 1;
			val.z = num;
			return new int3(num2, num3, num);
		}

		// Token: 0x06001994 RID: 6548 RVA: 0x000467B0 File Offset: 0x000449B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator --(int3 val)
		{
			int num = val.x - 1;
			val.x = num;
			int num2 = num;
			num = val.y - 1;
			val.y = num;
			int num3 = num;
			num = val.z - 1;
			val.z = num;
			return new int3(num2, num3, num);
		}

		// Token: 0x06001995 RID: 6549 RVA: 0x000467EF File Offset: 0x000449EF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <(int3 lhs, int3 rhs)
		{
			return new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
		}

		// Token: 0x06001996 RID: 6550 RVA: 0x00046820 File Offset: 0x00044A20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <(int3 lhs, int rhs)
		{
			return new bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);
		}

		// Token: 0x06001997 RID: 6551 RVA: 0x00046842 File Offset: 0x00044A42
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <(int lhs, int3 rhs)
		{
			return new bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);
		}

		// Token: 0x06001998 RID: 6552 RVA: 0x00046864 File Offset: 0x00044A64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <=(int3 lhs, int3 rhs)
		{
			return new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
		}

		// Token: 0x06001999 RID: 6553 RVA: 0x0004689E File Offset: 0x00044A9E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <=(int3 lhs, int rhs)
		{
			return new bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);
		}

		// Token: 0x0600199A RID: 6554 RVA: 0x000468C9 File Offset: 0x00044AC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator <=(int lhs, int3 rhs)
		{
			return new bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);
		}

		// Token: 0x0600199B RID: 6555 RVA: 0x000468F4 File Offset: 0x00044AF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >(int3 lhs, int3 rhs)
		{
			return new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
		}

		// Token: 0x0600199C RID: 6556 RVA: 0x00046925 File Offset: 0x00044B25
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >(int3 lhs, int rhs)
		{
			return new bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);
		}

		// Token: 0x0600199D RID: 6557 RVA: 0x00046947 File Offset: 0x00044B47
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >(int lhs, int3 rhs)
		{
			return new bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);
		}

		// Token: 0x0600199E RID: 6558 RVA: 0x00046969 File Offset: 0x00044B69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >=(int3 lhs, int3 rhs)
		{
			return new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
		}

		// Token: 0x0600199F RID: 6559 RVA: 0x000469A3 File Offset: 0x00044BA3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >=(int3 lhs, int rhs)
		{
			return new bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);
		}

		// Token: 0x060019A0 RID: 6560 RVA: 0x000469CE File Offset: 0x00044BCE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator >=(int lhs, int3 rhs)
		{
			return new bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);
		}

		// Token: 0x060019A1 RID: 6561 RVA: 0x000469F9 File Offset: 0x00044BF9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator -(int3 val)
		{
			return new int3(-val.x, -val.y, -val.z);
		}

		// Token: 0x060019A2 RID: 6562 RVA: 0x00046A15 File Offset: 0x00044C15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator +(int3 val)
		{
			return new int3(val.x, val.y, val.z);
		}

		// Token: 0x060019A3 RID: 6563 RVA: 0x00046A2E File Offset: 0x00044C2E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator <<(int3 x, int n)
		{
			return new int3(x.x << n, x.y << n, x.z << n);
		}

		// Token: 0x060019A4 RID: 6564 RVA: 0x00046A56 File Offset: 0x00044C56
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator >>(int3 x, int n)
		{
			return new int3(x.x >> n, x.y >> n, x.z >> n);
		}

		// Token: 0x060019A5 RID: 6565 RVA: 0x00046A7E File Offset: 0x00044C7E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(int3 lhs, int3 rhs)
		{
			return new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
		}

		// Token: 0x060019A6 RID: 6566 RVA: 0x00046AAF File Offset: 0x00044CAF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(int3 lhs, int rhs)
		{
			return new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);
		}

		// Token: 0x060019A7 RID: 6567 RVA: 0x00046AD1 File Offset: 0x00044CD1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(int lhs, int3 rhs)
		{
			return new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);
		}

		// Token: 0x060019A8 RID: 6568 RVA: 0x00046AF3 File Offset: 0x00044CF3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(int3 lhs, int3 rhs)
		{
			return new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
		}

		// Token: 0x060019A9 RID: 6569 RVA: 0x00046B2D File Offset: 0x00044D2D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(int3 lhs, int rhs)
		{
			return new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);
		}

		// Token: 0x060019AA RID: 6570 RVA: 0x00046B58 File Offset: 0x00044D58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(int lhs, int3 rhs)
		{
			return new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);
		}

		// Token: 0x060019AB RID: 6571 RVA: 0x00046B83 File Offset: 0x00044D83
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator ~(int3 val)
		{
			return new int3(~val.x, ~val.y, ~val.z);
		}

		// Token: 0x060019AC RID: 6572 RVA: 0x00046B9F File Offset: 0x00044D9F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator &(int3 lhs, int3 rhs)
		{
			return new int3(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z);
		}

		// Token: 0x060019AD RID: 6573 RVA: 0x00046BCD File Offset: 0x00044DCD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator &(int3 lhs, int rhs)
		{
			return new int3(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs);
		}

		// Token: 0x060019AE RID: 6574 RVA: 0x00046BEC File Offset: 0x00044DEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator &(int lhs, int3 rhs)
		{
			return new int3(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z);
		}

		// Token: 0x060019AF RID: 6575 RVA: 0x00046C0B File Offset: 0x00044E0B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator |(int3 lhs, int3 rhs)
		{
			return new int3(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z);
		}

		// Token: 0x060019B0 RID: 6576 RVA: 0x00046C39 File Offset: 0x00044E39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator |(int3 lhs, int rhs)
		{
			return new int3(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs);
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x00046C58 File Offset: 0x00044E58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator |(int lhs, int3 rhs)
		{
			return new int3(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z);
		}

		// Token: 0x060019B2 RID: 6578 RVA: 0x00046C77 File Offset: 0x00044E77
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator ^(int3 lhs, int3 rhs)
		{
			return new int3(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z);
		}

		// Token: 0x060019B3 RID: 6579 RVA: 0x00046CA5 File Offset: 0x00044EA5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator ^(int3 lhs, int rhs)
		{
			return new int3(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs);
		}

		// Token: 0x060019B4 RID: 6580 RVA: 0x00046CC4 File Offset: 0x00044EC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 operator ^(int lhs, int3 rhs)
		{
			return new int3(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z);
		}

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x060019B5 RID: 6581 RVA: 0x00046CE3 File Offset: 0x00044EE3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x060019B6 RID: 6582 RVA: 0x00046D02 File Offset: 0x00044F02
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x060019B7 RID: 6583 RVA: 0x00046D21 File Offset: 0x00044F21
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.x, this.z);
			}
		}

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x060019B8 RID: 6584 RVA: 0x00046D40 File Offset: 0x00044F40
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x060019B9 RID: 6585 RVA: 0x00046D5F File Offset: 0x00044F5F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x060019BA RID: 6586 RVA: 0x00046D7E File Offset: 0x00044F7E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.y, this.z);
			}
		}

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x060019BB RID: 6587 RVA: 0x00046D9D File Offset: 0x00044F9D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.z, this.x);
			}
		}

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x060019BC RID: 6588 RVA: 0x00046DBC File Offset: 0x00044FBC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.z, this.y);
			}
		}

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x060019BD RID: 6589 RVA: 0x00046DDB File Offset: 0x00044FDB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.z, this.z);
			}
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x060019BE RID: 6590 RVA: 0x00046DFA File Offset: 0x00044FFA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x060019BF RID: 6591 RVA: 0x00046E19 File Offset: 0x00045019
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x060019C0 RID: 6592 RVA: 0x00046E38 File Offset: 0x00045038
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.x, this.z);
			}
		}

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x060019C1 RID: 6593 RVA: 0x00046E57 File Offset: 0x00045057
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x060019C2 RID: 6594 RVA: 0x00046E76 File Offset: 0x00045076
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x060019C3 RID: 6595 RVA: 0x00046E95 File Offset: 0x00045095
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.y, this.z);
			}
		}

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x060019C4 RID: 6596 RVA: 0x00046EB4 File Offset: 0x000450B4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.z, this.x);
			}
		}

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x060019C5 RID: 6597 RVA: 0x00046ED3 File Offset: 0x000450D3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.z, this.y);
			}
		}

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x060019C6 RID: 6598 RVA: 0x00046EF2 File Offset: 0x000450F2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.z, this.z);
			}
		}

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x060019C7 RID: 6599 RVA: 0x00046F11 File Offset: 0x00045111
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.z, this.x, this.x);
			}
		}

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x060019C8 RID: 6600 RVA: 0x00046F30 File Offset: 0x00045130
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.z, this.x, this.y);
			}
		}

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x060019C9 RID: 6601 RVA: 0x00046F4F File Offset: 0x0004514F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.z, this.x, this.z);
			}
		}

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x060019CA RID: 6602 RVA: 0x00046F6E File Offset: 0x0004516E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.z, this.y, this.x);
			}
		}

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x060019CB RID: 6603 RVA: 0x00046F8D File Offset: 0x0004518D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.z, this.y, this.y);
			}
		}

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x060019CC RID: 6604 RVA: 0x00046FAC File Offset: 0x000451AC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.z, this.y, this.z);
			}
		}

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x060019CD RID: 6605 RVA: 0x00046FCB File Offset: 0x000451CB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.z, this.z, this.x);
			}
		}

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x060019CE RID: 6606 RVA: 0x00046FEA File Offset: 0x000451EA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.z, this.z, this.y);
			}
		}

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x060019CF RID: 6607 RVA: 0x00047009 File Offset: 0x00045209
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.z, this.z, this.z);
			}
		}

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x060019D0 RID: 6608 RVA: 0x00047028 File Offset: 0x00045228
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x060019D1 RID: 6609 RVA: 0x00047047 File Offset: 0x00045247
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x060019D2 RID: 6610 RVA: 0x00047066 File Offset: 0x00045266
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.x, this.z);
			}
		}

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x060019D3 RID: 6611 RVA: 0x00047085 File Offset: 0x00045285
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x060019D4 RID: 6612 RVA: 0x000470A4 File Offset: 0x000452A4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x060019D5 RID: 6613 RVA: 0x000470C3 File Offset: 0x000452C3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.y, this.z);
			}
		}

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x060019D6 RID: 6614 RVA: 0x000470E2 File Offset: 0x000452E2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.z, this.x);
			}
		}

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x060019D7 RID: 6615 RVA: 0x00047101 File Offset: 0x00045301
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.z, this.y);
			}
		}

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x060019D8 RID: 6616 RVA: 0x00047120 File Offset: 0x00045320
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.z, this.z);
			}
		}

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x060019D9 RID: 6617 RVA: 0x0004713F File Offset: 0x0004533F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x060019DA RID: 6618 RVA: 0x0004715E File Offset: 0x0004535E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x060019DB RID: 6619 RVA: 0x0004717D File Offset: 0x0004537D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.x, this.z);
			}
		}

		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x060019DC RID: 6620 RVA: 0x0004719C File Offset: 0x0004539C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x060019DD RID: 6621 RVA: 0x000471BB File Offset: 0x000453BB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x060019DE RID: 6622 RVA: 0x000471DA File Offset: 0x000453DA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.y, this.z);
			}
		}

		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x060019DF RID: 6623 RVA: 0x000471F9 File Offset: 0x000453F9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.z, this.x);
			}
		}

		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x060019E0 RID: 6624 RVA: 0x00047218 File Offset: 0x00045418
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.z, this.y);
			}
		}

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x060019E1 RID: 6625 RVA: 0x00047237 File Offset: 0x00045437
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.z, this.z);
			}
		}

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x060019E2 RID: 6626 RVA: 0x00047256 File Offset: 0x00045456
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.z, this.x, this.x);
			}
		}

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x060019E3 RID: 6627 RVA: 0x00047275 File Offset: 0x00045475
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.z, this.x, this.y);
			}
		}

		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x060019E4 RID: 6628 RVA: 0x00047294 File Offset: 0x00045494
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x060019E5 RID: 6629 RVA: 0x000472B3 File Offset: 0x000454B3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x060019E6 RID: 6630 RVA: 0x000472D2 File Offset: 0x000454D2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x060019E7 RID: 6631 RVA: 0x000472F1 File Offset: 0x000454F1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x060019E8 RID: 6632 RVA: 0x00047310 File Offset: 0x00045510
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x060019E9 RID: 6633 RVA: 0x0004732F File Offset: 0x0004552F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x060019EA RID: 6634 RVA: 0x0004734E File Offset: 0x0004554E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x060019EB RID: 6635 RVA: 0x0004736D File Offset: 0x0004556D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x060019EC RID: 6636 RVA: 0x0004738C File Offset: 0x0004558C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x060019ED RID: 6637 RVA: 0x000473AB File Offset: 0x000455AB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x060019EE RID: 6638 RVA: 0x000473CA File Offset: 0x000455CA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x060019EF RID: 6639 RVA: 0x000473E9 File Offset: 0x000455E9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.x, this.y, this.y);
			}
		}

		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x060019F0 RID: 6640 RVA: 0x00047408 File Offset: 0x00045608
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.x, this.y, this.z);
			}
		}

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x060019F1 RID: 6641 RVA: 0x00047427 File Offset: 0x00045627
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.x, this.z, this.x);
			}
		}

		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x060019F2 RID: 6642 RVA: 0x00047446 File Offset: 0x00045646
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.x, this.z, this.y);
			}
		}

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x060019F3 RID: 6643 RVA: 0x00047465 File Offset: 0x00045665
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.x, this.z, this.z);
			}
		}

		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x060019F4 RID: 6644 RVA: 0x00047484 File Offset: 0x00045684
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x060019F5 RID: 6645 RVA: 0x000474A3 File Offset: 0x000456A3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x060019F6 RID: 6646 RVA: 0x000474C2 File Offset: 0x000456C2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x060019F7 RID: 6647 RVA: 0x000474E1 File Offset: 0x000456E1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x060019F8 RID: 6648 RVA: 0x00047500 File Offset: 0x00045700
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x060019F9 RID: 6649 RVA: 0x0004751F File Offset: 0x0004571F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x060019FA RID: 6650 RVA: 0x0004753E File Offset: 0x0004573E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x060019FB RID: 6651 RVA: 0x0004755D File Offset: 0x0004575D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x060019FC RID: 6652 RVA: 0x0004757C File Offset: 0x0004577C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x060019FD RID: 6653 RVA: 0x0004759B File Offset: 0x0004579B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x060019FE RID: 6654 RVA: 0x000475BA File Offset: 0x000457BA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.z, this.x, this.y);
			}
		}

		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x060019FF RID: 6655 RVA: 0x000475D9 File Offset: 0x000457D9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.z, this.x, this.z);
			}
		}

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x06001A00 RID: 6656 RVA: 0x000475F8 File Offset: 0x000457F8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.z, this.y, this.x);
			}
		}

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x06001A01 RID: 6657 RVA: 0x00047617 File Offset: 0x00045817
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.z, this.y, this.y);
			}
		}

		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x06001A02 RID: 6658 RVA: 0x00047636 File Offset: 0x00045836
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.z, this.y, this.z);
			}
		}

		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x06001A03 RID: 6659 RVA: 0x00047655 File Offset: 0x00045855
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.z, this.z, this.x);
			}
		}

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x06001A04 RID: 6660 RVA: 0x00047674 File Offset: 0x00045874
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x06001A05 RID: 6661 RVA: 0x00047693 File Offset: 0x00045893
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.z, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x06001A06 RID: 6662 RVA: 0x000476B2 File Offset: 0x000458B2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.x, this.x);
			}
		}

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x06001A07 RID: 6663 RVA: 0x000476CB File Offset: 0x000458CB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.x, this.y);
			}
		}

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x06001A08 RID: 6664 RVA: 0x000476E4 File Offset: 0x000458E4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.x, this.z);
			}
		}

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x06001A09 RID: 6665 RVA: 0x000476FD File Offset: 0x000458FD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.y, this.x);
			}
		}

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x06001A0A RID: 6666 RVA: 0x00047716 File Offset: 0x00045916
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.y, this.y);
			}
		}

		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x06001A0B RID: 6667 RVA: 0x0004772F File Offset: 0x0004592F
		// (set) Token: 0x06001A0C RID: 6668 RVA: 0x00047748 File Offset: 0x00045948
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x06001A0D RID: 6669 RVA: 0x0004776E File Offset: 0x0004596E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.z, this.x);
			}
		}

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x06001A0E RID: 6670 RVA: 0x00047787 File Offset: 0x00045987
		// (set) Token: 0x06001A0F RID: 6671 RVA: 0x000477A0 File Offset: 0x000459A0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x06001A10 RID: 6672 RVA: 0x000477C6 File Offset: 0x000459C6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.z, this.z);
			}
		}

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x06001A11 RID: 6673 RVA: 0x000477DF File Offset: 0x000459DF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.x, this.x);
			}
		}

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x06001A12 RID: 6674 RVA: 0x000477F8 File Offset: 0x000459F8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.x, this.y);
			}
		}

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x06001A13 RID: 6675 RVA: 0x00047811 File Offset: 0x00045A11
		// (set) Token: 0x06001A14 RID: 6676 RVA: 0x0004782A File Offset: 0x00045A2A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x06001A15 RID: 6677 RVA: 0x00047850 File Offset: 0x00045A50
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.y, this.x);
			}
		}

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x06001A16 RID: 6678 RVA: 0x00047869 File Offset: 0x00045A69
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.y, this.y);
			}
		}

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x06001A17 RID: 6679 RVA: 0x00047882 File Offset: 0x00045A82
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.y, this.z);
			}
		}

		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x06001A18 RID: 6680 RVA: 0x0004789B File Offset: 0x00045A9B
		// (set) Token: 0x06001A19 RID: 6681 RVA: 0x000478B4 File Offset: 0x00045AB4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x06001A1A RID: 6682 RVA: 0x000478DA File Offset: 0x00045ADA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.z, this.y);
			}
		}

		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x06001A1B RID: 6683 RVA: 0x000478F3 File Offset: 0x00045AF3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.z, this.z);
			}
		}

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x06001A1C RID: 6684 RVA: 0x0004790C File Offset: 0x00045B0C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.z, this.x, this.x);
			}
		}

		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x06001A1D RID: 6685 RVA: 0x00047925 File Offset: 0x00045B25
		// (set) Token: 0x06001A1E RID: 6686 RVA: 0x0004793E File Offset: 0x00045B3E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 zxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.z, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x06001A1F RID: 6687 RVA: 0x00047964 File Offset: 0x00045B64
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.z, this.x, this.z);
			}
		}

		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x06001A20 RID: 6688 RVA: 0x0004797D File Offset: 0x00045B7D
		// (set) Token: 0x06001A21 RID: 6689 RVA: 0x00047996 File Offset: 0x00045B96
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 zyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.z, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x06001A22 RID: 6690 RVA: 0x000479BC File Offset: 0x00045BBC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.z, this.y, this.y);
			}
		}

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x06001A23 RID: 6691 RVA: 0x000479D5 File Offset: 0x00045BD5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.z, this.y, this.z);
			}
		}

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x06001A24 RID: 6692 RVA: 0x000479EE File Offset: 0x00045BEE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.z, this.z, this.x);
			}
		}

		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x06001A25 RID: 6693 RVA: 0x00047A07 File Offset: 0x00045C07
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.z, this.z, this.y);
			}
		}

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x06001A26 RID: 6694 RVA: 0x00047A20 File Offset: 0x00045C20
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.z, this.z, this.z);
			}
		}

		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x06001A27 RID: 6695 RVA: 0x00047A39 File Offset: 0x00045C39
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.x, this.x);
			}
		}

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x06001A28 RID: 6696 RVA: 0x00047A4C File Offset: 0x00045C4C
		// (set) Token: 0x06001A29 RID: 6697 RVA: 0x00047A5F File Offset: 0x00045C5F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x06001A2A RID: 6698 RVA: 0x00047A79 File Offset: 0x00045C79
		// (set) Token: 0x06001A2B RID: 6699 RVA: 0x00047A8C File Offset: 0x00045C8C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 xz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x06001A2C RID: 6700 RVA: 0x00047AA6 File Offset: 0x00045CA6
		// (set) Token: 0x06001A2D RID: 6701 RVA: 0x00047AB9 File Offset: 0x00045CB9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x06001A2E RID: 6702 RVA: 0x00047AD3 File Offset: 0x00045CD3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.y, this.y);
			}
		}

		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x06001A2F RID: 6703 RVA: 0x00047AE6 File Offset: 0x00045CE6
		// (set) Token: 0x06001A30 RID: 6704 RVA: 0x00047AF9 File Offset: 0x00045CF9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 yz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x06001A31 RID: 6705 RVA: 0x00047B13 File Offset: 0x00045D13
		// (set) Token: 0x06001A32 RID: 6706 RVA: 0x00047B26 File Offset: 0x00045D26
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 zx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x06001A33 RID: 6707 RVA: 0x00047B40 File Offset: 0x00045D40
		// (set) Token: 0x06001A34 RID: 6708 RVA: 0x00047B53 File Offset: 0x00045D53
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 zy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x17000844 RID: 2116
		// (get) Token: 0x06001A35 RID: 6709 RVA: 0x00047B6D File Offset: 0x00045D6D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.z, this.z);
			}
		}

		// Token: 0x17000845 RID: 2117
		public unsafe int this[int index]
		{
			get
			{
				fixed (int3* ptr = &this)
				{
					return ((int*)ptr)[index];
				}
			}
			set
			{
				fixed (int* ptr = &this.x)
				{
					ptr[index] = value;
				}
			}
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x00047BB8 File Offset: 0x00045DB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int3 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y && this.z == rhs.z;
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x00047BE8 File Offset: 0x00045DE8
		public override bool Equals(object o)
		{
			if (o is int3)
			{
				int3 rhs = (int3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001A3A RID: 6714 RVA: 0x00047C0D File Offset: 0x00045E0D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001A3B RID: 6715 RVA: 0x00047C1A File Offset: 0x00045E1A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int3({0}, {1}, {2})", this.x, this.y, this.z);
		}

		// Token: 0x06001A3C RID: 6716 RVA: 0x00047C47 File Offset: 0x00045E47
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int3({0}, {1}, {2})", this.x.ToString(format, formatProvider), this.y.ToString(format, formatProvider), this.z.ToString(format, formatProvider));
		}

		// Token: 0x040000BF RID: 191
		public int x;

		// Token: 0x040000C0 RID: 192
		public int y;

		// Token: 0x040000C1 RID: 193
		public int z;

		// Token: 0x040000C2 RID: 194
		public static readonly int3 zero;

		// Token: 0x02000061 RID: 97
		internal sealed class DebuggerProxy
		{
			// Token: 0x06002476 RID: 9334 RVA: 0x00067728 File Offset: 0x00065928
			public DebuggerProxy(int3 v)
			{
				this.x = v.x;
				this.y = v.y;
				this.z = v.z;
			}

			// Token: 0x04000160 RID: 352
			public int x;

			// Token: 0x04000161 RID: 353
			public int y;

			// Token: 0x04000162 RID: 354
			public int z;
		}
	}
}
