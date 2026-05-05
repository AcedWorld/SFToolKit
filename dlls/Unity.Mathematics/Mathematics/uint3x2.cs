using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000044 RID: 68
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct uint3x2 : IEquatable<uint3x2>, IFormattable
	{
		// Token: 0x060020A3 RID: 8355 RVA: 0x0005D7BE File Offset: 0x0005B9BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(uint3 c0, uint3 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x060020A4 RID: 8356 RVA: 0x0005D7CE File Offset: 0x0005B9CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(uint m00, uint m01, uint m10, uint m11, uint m20, uint m21)
		{
			this.c0 = new uint3(m00, m10, m20);
			this.c1 = new uint3(m01, m11, m21);
		}

		// Token: 0x060020A5 RID: 8357 RVA: 0x0005D7EF File Offset: 0x0005B9EF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(uint v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x060020A6 RID: 8358 RVA: 0x0005D809 File Offset: 0x0005BA09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(bool v)
		{
			this.c0 = math.select(new uint3(0U), new uint3(1U), v);
			this.c1 = math.select(new uint3(0U), new uint3(1U), v);
		}

		// Token: 0x060020A7 RID: 8359 RVA: 0x0005D83B File Offset: 0x0005BA3B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(bool3x2 v)
		{
			this.c0 = math.select(new uint3(0U), new uint3(1U), v.c0);
			this.c1 = math.select(new uint3(0U), new uint3(1U), v.c1);
		}

		// Token: 0x060020A8 RID: 8360 RVA: 0x0005D877 File Offset: 0x0005BA77
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(int v)
		{
			this.c0 = (uint3)v;
			this.c1 = (uint3)v;
		}

		// Token: 0x060020A9 RID: 8361 RVA: 0x0005D891 File Offset: 0x0005BA91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(int3x2 v)
		{
			this.c0 = (uint3)v.c0;
			this.c1 = (uint3)v.c1;
		}

		// Token: 0x060020AA RID: 8362 RVA: 0x0005D8B5 File Offset: 0x0005BAB5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(float v)
		{
			this.c0 = (uint3)v;
			this.c1 = (uint3)v;
		}

		// Token: 0x060020AB RID: 8363 RVA: 0x0005D8CF File Offset: 0x0005BACF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(float3x2 v)
		{
			this.c0 = (uint3)v.c0;
			this.c1 = (uint3)v.c1;
		}

		// Token: 0x060020AC RID: 8364 RVA: 0x0005D8F3 File Offset: 0x0005BAF3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(double v)
		{
			this.c0 = (uint3)v;
			this.c1 = (uint3)v;
		}

		// Token: 0x060020AD RID: 8365 RVA: 0x0005D90D File Offset: 0x0005BB0D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint3x2(double3x2 v)
		{
			this.c0 = (uint3)v.c0;
			this.c1 = (uint3)v.c1;
		}

		// Token: 0x060020AE RID: 8366 RVA: 0x0005D931 File Offset: 0x0005BB31
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator uint3x2(uint v)
		{
			return new uint3x2(v);
		}

		// Token: 0x060020AF RID: 8367 RVA: 0x0005D939 File Offset: 0x0005BB39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x2(bool v)
		{
			return new uint3x2(v);
		}

		// Token: 0x060020B0 RID: 8368 RVA: 0x0005D941 File Offset: 0x0005BB41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x2(bool3x2 v)
		{
			return new uint3x2(v);
		}

		// Token: 0x060020B1 RID: 8369 RVA: 0x0005D949 File Offset: 0x0005BB49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x2(int v)
		{
			return new uint3x2(v);
		}

		// Token: 0x060020B2 RID: 8370 RVA: 0x0005D951 File Offset: 0x0005BB51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x2(int3x2 v)
		{
			return new uint3x2(v);
		}

		// Token: 0x060020B3 RID: 8371 RVA: 0x0005D959 File Offset: 0x0005BB59
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x2(float v)
		{
			return new uint3x2(v);
		}

		// Token: 0x060020B4 RID: 8372 RVA: 0x0005D961 File Offset: 0x0005BB61
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x2(float3x2 v)
		{
			return new uint3x2(v);
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x0005D969 File Offset: 0x0005BB69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x2(double v)
		{
			return new uint3x2(v);
		}

		// Token: 0x060020B6 RID: 8374 RVA: 0x0005D971 File Offset: 0x0005BB71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint3x2(double3x2 v)
		{
			return new uint3x2(v);
		}

		// Token: 0x060020B7 RID: 8375 RVA: 0x0005D979 File Offset: 0x0005BB79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator *(uint3x2 lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);
		}

		// Token: 0x060020B8 RID: 8376 RVA: 0x0005D9A2 File Offset: 0x0005BBA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator *(uint3x2 lhs, uint rhs)
		{
			return new uint3x2(lhs.c0 * rhs, lhs.c1 * rhs);
		}

		// Token: 0x060020B9 RID: 8377 RVA: 0x0005D9C1 File Offset: 0x0005BBC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator *(uint lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs * rhs.c0, lhs * rhs.c1);
		}

		// Token: 0x060020BA RID: 8378 RVA: 0x0005D9E0 File Offset: 0x0005BBE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator +(uint3x2 lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);
		}

		// Token: 0x060020BB RID: 8379 RVA: 0x0005DA09 File Offset: 0x0005BC09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator +(uint3x2 lhs, uint rhs)
		{
			return new uint3x2(lhs.c0 + rhs, lhs.c1 + rhs);
		}

		// Token: 0x060020BC RID: 8380 RVA: 0x0005DA28 File Offset: 0x0005BC28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator +(uint lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs + rhs.c0, lhs + rhs.c1);
		}

		// Token: 0x060020BD RID: 8381 RVA: 0x0005DA47 File Offset: 0x0005BC47
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator -(uint3x2 lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);
		}

		// Token: 0x060020BE RID: 8382 RVA: 0x0005DA70 File Offset: 0x0005BC70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator -(uint3x2 lhs, uint rhs)
		{
			return new uint3x2(lhs.c0 - rhs, lhs.c1 - rhs);
		}

		// Token: 0x060020BF RID: 8383 RVA: 0x0005DA8F File Offset: 0x0005BC8F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator -(uint lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs - rhs.c0, lhs - rhs.c1);
		}

		// Token: 0x060020C0 RID: 8384 RVA: 0x0005DAAE File Offset: 0x0005BCAE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator /(uint3x2 lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);
		}

		// Token: 0x060020C1 RID: 8385 RVA: 0x0005DAD7 File Offset: 0x0005BCD7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator /(uint3x2 lhs, uint rhs)
		{
			return new uint3x2(lhs.c0 / rhs, lhs.c1 / rhs);
		}

		// Token: 0x060020C2 RID: 8386 RVA: 0x0005DAF6 File Offset: 0x0005BCF6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator /(uint lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs / rhs.c0, lhs / rhs.c1);
		}

		// Token: 0x060020C3 RID: 8387 RVA: 0x0005DB15 File Offset: 0x0005BD15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator %(uint3x2 lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);
		}

		// Token: 0x060020C4 RID: 8388 RVA: 0x0005DB3E File Offset: 0x0005BD3E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator %(uint3x2 lhs, uint rhs)
		{
			return new uint3x2(lhs.c0 % rhs, lhs.c1 % rhs);
		}

		// Token: 0x060020C5 RID: 8389 RVA: 0x0005DB5D File Offset: 0x0005BD5D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator %(uint lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs % rhs.c0, lhs % rhs.c1);
		}

		// Token: 0x060020C6 RID: 8390 RVA: 0x0005DB7C File Offset: 0x0005BD7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator ++(uint3x2 val)
		{
			uint3 @uint = ++val.c0;
			val.c0 = @uint;
			uint3 uint2 = @uint;
			@uint = ++val.c1;
			val.c1 = @uint;
			return new uint3x2(uint2, @uint);
		}

		// Token: 0x060020C7 RID: 8391 RVA: 0x0005DBC4 File Offset: 0x0005BDC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator --(uint3x2 val)
		{
			uint3 @uint = --val.c0;
			val.c0 = @uint;
			uint3 uint2 = @uint;
			@uint = --val.c1;
			val.c1 = @uint;
			return new uint3x2(uint2, @uint);
		}

		// Token: 0x060020C8 RID: 8392 RVA: 0x0005DC0A File Offset: 0x0005BE0A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(uint3x2 lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);
		}

		// Token: 0x060020C9 RID: 8393 RVA: 0x0005DC33 File Offset: 0x0005BE33
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(uint3x2 lhs, uint rhs)
		{
			return new bool3x2(lhs.c0 < rhs, lhs.c1 < rhs);
		}

		// Token: 0x060020CA RID: 8394 RVA: 0x0005DC52 File Offset: 0x0005BE52
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(uint lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs < rhs.c0, lhs < rhs.c1);
		}

		// Token: 0x060020CB RID: 8395 RVA: 0x0005DC71 File Offset: 0x0005BE71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(uint3x2 lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);
		}

		// Token: 0x060020CC RID: 8396 RVA: 0x0005DC9A File Offset: 0x0005BE9A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(uint3x2 lhs, uint rhs)
		{
			return new bool3x2(lhs.c0 <= rhs, lhs.c1 <= rhs);
		}

		// Token: 0x060020CD RID: 8397 RVA: 0x0005DCB9 File Offset: 0x0005BEB9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(uint lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs <= rhs.c0, lhs <= rhs.c1);
		}

		// Token: 0x060020CE RID: 8398 RVA: 0x0005DCD8 File Offset: 0x0005BED8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(uint3x2 lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);
		}

		// Token: 0x060020CF RID: 8399 RVA: 0x0005DD01 File Offset: 0x0005BF01
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(uint3x2 lhs, uint rhs)
		{
			return new bool3x2(lhs.c0 > rhs, lhs.c1 > rhs);
		}

		// Token: 0x060020D0 RID: 8400 RVA: 0x0005DD20 File Offset: 0x0005BF20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(uint lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs > rhs.c0, lhs > rhs.c1);
		}

		// Token: 0x060020D1 RID: 8401 RVA: 0x0005DD3F File Offset: 0x0005BF3F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(uint3x2 lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);
		}

		// Token: 0x060020D2 RID: 8402 RVA: 0x0005DD68 File Offset: 0x0005BF68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(uint3x2 lhs, uint rhs)
		{
			return new bool3x2(lhs.c0 >= rhs, lhs.c1 >= rhs);
		}

		// Token: 0x060020D3 RID: 8403 RVA: 0x0005DD87 File Offset: 0x0005BF87
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(uint lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs >= rhs.c0, lhs >= rhs.c1);
		}

		// Token: 0x060020D4 RID: 8404 RVA: 0x0005DDA6 File Offset: 0x0005BFA6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator -(uint3x2 val)
		{
			return new uint3x2(-val.c0, -val.c1);
		}

		// Token: 0x060020D5 RID: 8405 RVA: 0x0005DDC3 File Offset: 0x0005BFC3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator +(uint3x2 val)
		{
			return new uint3x2(+val.c0, +val.c1);
		}

		// Token: 0x060020D6 RID: 8406 RVA: 0x0005DDE0 File Offset: 0x0005BFE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator <<(uint3x2 x, int n)
		{
			return new uint3x2(x.c0 << n, x.c1 << n);
		}

		// Token: 0x060020D7 RID: 8407 RVA: 0x0005DDFF File Offset: 0x0005BFFF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator >>(uint3x2 x, int n)
		{
			return new uint3x2(x.c0 >> n, x.c1 >> n);
		}

		// Token: 0x060020D8 RID: 8408 RVA: 0x0005DE1E File Offset: 0x0005C01E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(uint3x2 lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x060020D9 RID: 8409 RVA: 0x0005DE47 File Offset: 0x0005C047
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(uint3x2 lhs, uint rhs)
		{
			return new bool3x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x060020DA RID: 8410 RVA: 0x0005DE66 File Offset: 0x0005C066
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(uint lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x060020DB RID: 8411 RVA: 0x0005DE85 File Offset: 0x0005C085
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(uint3x2 lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x060020DC RID: 8412 RVA: 0x0005DEAE File Offset: 0x0005C0AE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(uint3x2 lhs, uint rhs)
		{
			return new bool3x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x060020DD RID: 8413 RVA: 0x0005DECD File Offset: 0x0005C0CD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(uint lhs, uint3x2 rhs)
		{
			return new bool3x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x060020DE RID: 8414 RVA: 0x0005DEEC File Offset: 0x0005C0EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator ~(uint3x2 val)
		{
			return new uint3x2(~val.c0, ~val.c1);
		}

		// Token: 0x060020DF RID: 8415 RVA: 0x0005DF09 File Offset: 0x0005C109
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator &(uint3x2 lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);
		}

		// Token: 0x060020E0 RID: 8416 RVA: 0x0005DF32 File Offset: 0x0005C132
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator &(uint3x2 lhs, uint rhs)
		{
			return new uint3x2(lhs.c0 & rhs, lhs.c1 & rhs);
		}

		// Token: 0x060020E1 RID: 8417 RVA: 0x0005DF51 File Offset: 0x0005C151
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator &(uint lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs & rhs.c0, lhs & rhs.c1);
		}

		// Token: 0x060020E2 RID: 8418 RVA: 0x0005DF70 File Offset: 0x0005C170
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator |(uint3x2 lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);
		}

		// Token: 0x060020E3 RID: 8419 RVA: 0x0005DF99 File Offset: 0x0005C199
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator |(uint3x2 lhs, uint rhs)
		{
			return new uint3x2(lhs.c0 | rhs, lhs.c1 | rhs);
		}

		// Token: 0x060020E4 RID: 8420 RVA: 0x0005DFB8 File Offset: 0x0005C1B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator |(uint lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs | rhs.c0, lhs | rhs.c1);
		}

		// Token: 0x060020E5 RID: 8421 RVA: 0x0005DFD7 File Offset: 0x0005C1D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator ^(uint3x2 lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);
		}

		// Token: 0x060020E6 RID: 8422 RVA: 0x0005E000 File Offset: 0x0005C200
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator ^(uint3x2 lhs, uint rhs)
		{
			return new uint3x2(lhs.c0 ^ rhs, lhs.c1 ^ rhs);
		}

		// Token: 0x060020E7 RID: 8423 RVA: 0x0005E01F File Offset: 0x0005C21F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3x2 operator ^(uint lhs, uint3x2 rhs)
		{
			return new uint3x2(lhs ^ rhs.c0, lhs ^ rhs.c1);
		}

		// Token: 0x17000A33 RID: 2611
		public unsafe uint3 this[int index]
		{
			get
			{
				fixed (uint3x2* ptr = &this)
				{
					return ref *(uint3*)(ptr + (IntPtr)index * (IntPtr)sizeof(uint3) / (IntPtr)sizeof(uint3x2));
				}
			}
		}

		// Token: 0x060020E9 RID: 8425 RVA: 0x0005E05B File Offset: 0x0005C25B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(uint3x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x060020EA RID: 8426 RVA: 0x0005E084 File Offset: 0x0005C284
		public override bool Equals(object o)
		{
			if (o is uint3x2)
			{
				uint3x2 rhs = (uint3x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060020EB RID: 8427 RVA: 0x0005E0A9 File Offset: 0x0005C2A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060020EC RID: 8428 RVA: 0x0005E0B8 File Offset: 0x0005C2B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("uint3x2({0}, {1},  {2}, {3},  {4}, {5})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y,
				this.c0.z,
				this.c1.z
			});
		}

		// Token: 0x060020ED RID: 8429 RVA: 0x0005E148 File Offset: 0x0005C348
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("uint3x2({0}, {1},  {2}, {3},  {4}, {5})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000FC RID: 252
		public uint3 c0;

		// Token: 0x040000FD RID: 253
		public uint3 c1;

		// Token: 0x040000FE RID: 254
		public static readonly uint3x2 zero;
	}
}
