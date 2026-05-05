using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000048 RID: 72
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct uint4x2 : IEquatable<uint4x2>, IFormattable
	{
		// Token: 0x06002363 RID: 9059 RVA: 0x0006417D File Offset: 0x0006237D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(uint4 c0, uint4 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x06002364 RID: 9060 RVA: 0x0006418D File Offset: 0x0006238D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(uint m00, uint m01, uint m10, uint m11, uint m20, uint m21, uint m30, uint m31)
		{
			this.c0 = new uint4(m00, m10, m20, m30);
			this.c1 = new uint4(m01, m11, m21, m31);
		}

		// Token: 0x06002365 RID: 9061 RVA: 0x000641B2 File Offset: 0x000623B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(uint v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06002366 RID: 9062 RVA: 0x000641CC File Offset: 0x000623CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(bool v)
		{
			this.c0 = math.select(new uint4(0U), new uint4(1U), v);
			this.c1 = math.select(new uint4(0U), new uint4(1U), v);
		}

		// Token: 0x06002367 RID: 9063 RVA: 0x000641FE File Offset: 0x000623FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(bool4x2 v)
		{
			this.c0 = math.select(new uint4(0U), new uint4(1U), v.c0);
			this.c1 = math.select(new uint4(0U), new uint4(1U), v.c1);
		}

		// Token: 0x06002368 RID: 9064 RVA: 0x0006423A File Offset: 0x0006243A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(int v)
		{
			this.c0 = (uint4)v;
			this.c1 = (uint4)v;
		}

		// Token: 0x06002369 RID: 9065 RVA: 0x00064254 File Offset: 0x00062454
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(int4x2 v)
		{
			this.c0 = (uint4)v.c0;
			this.c1 = (uint4)v.c1;
		}

		// Token: 0x0600236A RID: 9066 RVA: 0x00064278 File Offset: 0x00062478
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(float v)
		{
			this.c0 = (uint4)v;
			this.c1 = (uint4)v;
		}

		// Token: 0x0600236B RID: 9067 RVA: 0x00064292 File Offset: 0x00062492
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(float4x2 v)
		{
			this.c0 = (uint4)v.c0;
			this.c1 = (uint4)v.c1;
		}

		// Token: 0x0600236C RID: 9068 RVA: 0x000642B6 File Offset: 0x000624B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(double v)
		{
			this.c0 = (uint4)v;
			this.c1 = (uint4)v;
		}

		// Token: 0x0600236D RID: 9069 RVA: 0x000642D0 File Offset: 0x000624D0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x2(double4x2 v)
		{
			this.c0 = (uint4)v.c0;
			this.c1 = (uint4)v.c1;
		}

		// Token: 0x0600236E RID: 9070 RVA: 0x000642F4 File Offset: 0x000624F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator uint4x2(uint v)
		{
			return new uint4x2(v);
		}

		// Token: 0x0600236F RID: 9071 RVA: 0x000642FC File Offset: 0x000624FC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x2(bool v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06002370 RID: 9072 RVA: 0x00064304 File Offset: 0x00062504
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x2(bool4x2 v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06002371 RID: 9073 RVA: 0x0006430C File Offset: 0x0006250C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x2(int v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06002372 RID: 9074 RVA: 0x00064314 File Offset: 0x00062514
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x2(int4x2 v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06002373 RID: 9075 RVA: 0x0006431C File Offset: 0x0006251C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x2(float v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06002374 RID: 9076 RVA: 0x00064324 File Offset: 0x00062524
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x2(float4x2 v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06002375 RID: 9077 RVA: 0x0006432C File Offset: 0x0006252C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x2(double v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06002376 RID: 9078 RVA: 0x00064334 File Offset: 0x00062534
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x2(double4x2 v)
		{
			return new uint4x2(v);
		}

		// Token: 0x06002377 RID: 9079 RVA: 0x0006433C File Offset: 0x0006253C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator *(uint4x2 lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);
		}

		// Token: 0x06002378 RID: 9080 RVA: 0x00064365 File Offset: 0x00062565
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator *(uint4x2 lhs, uint rhs)
		{
			return new uint4x2(lhs.c0 * rhs, lhs.c1 * rhs);
		}

		// Token: 0x06002379 RID: 9081 RVA: 0x00064384 File Offset: 0x00062584
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator *(uint lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs * rhs.c0, lhs * rhs.c1);
		}

		// Token: 0x0600237A RID: 9082 RVA: 0x000643A3 File Offset: 0x000625A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator +(uint4x2 lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);
		}

		// Token: 0x0600237B RID: 9083 RVA: 0x000643CC File Offset: 0x000625CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator +(uint4x2 lhs, uint rhs)
		{
			return new uint4x2(lhs.c0 + rhs, lhs.c1 + rhs);
		}

		// Token: 0x0600237C RID: 9084 RVA: 0x000643EB File Offset: 0x000625EB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator +(uint lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs + rhs.c0, lhs + rhs.c1);
		}

		// Token: 0x0600237D RID: 9085 RVA: 0x0006440A File Offset: 0x0006260A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator -(uint4x2 lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);
		}

		// Token: 0x0600237E RID: 9086 RVA: 0x00064433 File Offset: 0x00062633
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator -(uint4x2 lhs, uint rhs)
		{
			return new uint4x2(lhs.c0 - rhs, lhs.c1 - rhs);
		}

		// Token: 0x0600237F RID: 9087 RVA: 0x00064452 File Offset: 0x00062652
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator -(uint lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs - rhs.c0, lhs - rhs.c1);
		}

		// Token: 0x06002380 RID: 9088 RVA: 0x00064471 File Offset: 0x00062671
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator /(uint4x2 lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);
		}

		// Token: 0x06002381 RID: 9089 RVA: 0x0006449A File Offset: 0x0006269A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator /(uint4x2 lhs, uint rhs)
		{
			return new uint4x2(lhs.c0 / rhs, lhs.c1 / rhs);
		}

		// Token: 0x06002382 RID: 9090 RVA: 0x000644B9 File Offset: 0x000626B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator /(uint lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs / rhs.c0, lhs / rhs.c1);
		}

		// Token: 0x06002383 RID: 9091 RVA: 0x000644D8 File Offset: 0x000626D8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator %(uint4x2 lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);
		}

		// Token: 0x06002384 RID: 9092 RVA: 0x00064501 File Offset: 0x00062701
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator %(uint4x2 lhs, uint rhs)
		{
			return new uint4x2(lhs.c0 % rhs, lhs.c1 % rhs);
		}

		// Token: 0x06002385 RID: 9093 RVA: 0x00064520 File Offset: 0x00062720
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator %(uint lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs % rhs.c0, lhs % rhs.c1);
		}

		// Token: 0x06002386 RID: 9094 RVA: 0x00064540 File Offset: 0x00062740
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator ++(uint4x2 val)
		{
			uint4 @uint = ++val.c0;
			val.c0 = @uint;
			uint4 uint2 = @uint;
			@uint = ++val.c1;
			val.c1 = @uint;
			return new uint4x2(uint2, @uint);
		}

		// Token: 0x06002387 RID: 9095 RVA: 0x00064588 File Offset: 0x00062788
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator --(uint4x2 val)
		{
			uint4 @uint = --val.c0;
			val.c0 = @uint;
			uint4 uint2 = @uint;
			@uint = --val.c1;
			val.c1 = @uint;
			return new uint4x2(uint2, @uint);
		}

		// Token: 0x06002388 RID: 9096 RVA: 0x000645CE File Offset: 0x000627CE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(uint4x2 lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);
		}

		// Token: 0x06002389 RID: 9097 RVA: 0x000645F7 File Offset: 0x000627F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(uint4x2 lhs, uint rhs)
		{
			return new bool4x2(lhs.c0 < rhs, lhs.c1 < rhs);
		}

		// Token: 0x0600238A RID: 9098 RVA: 0x00064616 File Offset: 0x00062816
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <(uint lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs < rhs.c0, lhs < rhs.c1);
		}

		// Token: 0x0600238B RID: 9099 RVA: 0x00064635 File Offset: 0x00062835
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(uint4x2 lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);
		}

		// Token: 0x0600238C RID: 9100 RVA: 0x0006465E File Offset: 0x0006285E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(uint4x2 lhs, uint rhs)
		{
			return new bool4x2(lhs.c0 <= rhs, lhs.c1 <= rhs);
		}

		// Token: 0x0600238D RID: 9101 RVA: 0x0006467D File Offset: 0x0006287D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator <=(uint lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs <= rhs.c0, lhs <= rhs.c1);
		}

		// Token: 0x0600238E RID: 9102 RVA: 0x0006469C File Offset: 0x0006289C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(uint4x2 lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);
		}

		// Token: 0x0600238F RID: 9103 RVA: 0x000646C5 File Offset: 0x000628C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(uint4x2 lhs, uint rhs)
		{
			return new bool4x2(lhs.c0 > rhs, lhs.c1 > rhs);
		}

		// Token: 0x06002390 RID: 9104 RVA: 0x000646E4 File Offset: 0x000628E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >(uint lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs > rhs.c0, lhs > rhs.c1);
		}

		// Token: 0x06002391 RID: 9105 RVA: 0x00064703 File Offset: 0x00062903
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(uint4x2 lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);
		}

		// Token: 0x06002392 RID: 9106 RVA: 0x0006472C File Offset: 0x0006292C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(uint4x2 lhs, uint rhs)
		{
			return new bool4x2(lhs.c0 >= rhs, lhs.c1 >= rhs);
		}

		// Token: 0x06002393 RID: 9107 RVA: 0x0006474B File Offset: 0x0006294B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator >=(uint lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs >= rhs.c0, lhs >= rhs.c1);
		}

		// Token: 0x06002394 RID: 9108 RVA: 0x0006476A File Offset: 0x0006296A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator -(uint4x2 val)
		{
			return new uint4x2(-val.c0, -val.c1);
		}

		// Token: 0x06002395 RID: 9109 RVA: 0x00064787 File Offset: 0x00062987
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator +(uint4x2 val)
		{
			return new uint4x2(+val.c0, +val.c1);
		}

		// Token: 0x06002396 RID: 9110 RVA: 0x000647A4 File Offset: 0x000629A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator <<(uint4x2 x, int n)
		{
			return new uint4x2(x.c0 << n, x.c1 << n);
		}

		// Token: 0x06002397 RID: 9111 RVA: 0x000647C3 File Offset: 0x000629C3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator >>(uint4x2 x, int n)
		{
			return new uint4x2(x.c0 >> n, x.c1 >> n);
		}

		// Token: 0x06002398 RID: 9112 RVA: 0x000647E2 File Offset: 0x000629E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(uint4x2 lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x06002399 RID: 9113 RVA: 0x0006480B File Offset: 0x00062A0B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(uint4x2 lhs, uint rhs)
		{
			return new bool4x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x0600239A RID: 9114 RVA: 0x0006482A File Offset: 0x00062A2A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(uint lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x0600239B RID: 9115 RVA: 0x00064849 File Offset: 0x00062A49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(uint4x2 lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x0600239C RID: 9116 RVA: 0x00064872 File Offset: 0x00062A72
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(uint4x2 lhs, uint rhs)
		{
			return new bool4x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x0600239D RID: 9117 RVA: 0x00064891 File Offset: 0x00062A91
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(uint lhs, uint4x2 rhs)
		{
			return new bool4x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x0600239E RID: 9118 RVA: 0x000648B0 File Offset: 0x00062AB0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator ~(uint4x2 val)
		{
			return new uint4x2(~val.c0, ~val.c1);
		}

		// Token: 0x0600239F RID: 9119 RVA: 0x000648CD File Offset: 0x00062ACD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator &(uint4x2 lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);
		}

		// Token: 0x060023A0 RID: 9120 RVA: 0x000648F6 File Offset: 0x00062AF6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator &(uint4x2 lhs, uint rhs)
		{
			return new uint4x2(lhs.c0 & rhs, lhs.c1 & rhs);
		}

		// Token: 0x060023A1 RID: 9121 RVA: 0x00064915 File Offset: 0x00062B15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator &(uint lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs & rhs.c0, lhs & rhs.c1);
		}

		// Token: 0x060023A2 RID: 9122 RVA: 0x00064934 File Offset: 0x00062B34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator |(uint4x2 lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);
		}

		// Token: 0x060023A3 RID: 9123 RVA: 0x0006495D File Offset: 0x00062B5D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator |(uint4x2 lhs, uint rhs)
		{
			return new uint4x2(lhs.c0 | rhs, lhs.c1 | rhs);
		}

		// Token: 0x060023A4 RID: 9124 RVA: 0x0006497C File Offset: 0x00062B7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator |(uint lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs | rhs.c0, lhs | rhs.c1);
		}

		// Token: 0x060023A5 RID: 9125 RVA: 0x0006499B File Offset: 0x00062B9B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator ^(uint4x2 lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);
		}

		// Token: 0x060023A6 RID: 9126 RVA: 0x000649C4 File Offset: 0x00062BC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator ^(uint4x2 lhs, uint rhs)
		{
			return new uint4x2(lhs.c0 ^ rhs, lhs.c1 ^ rhs);
		}

		// Token: 0x060023A7 RID: 9127 RVA: 0x000649E3 File Offset: 0x00062BE3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x2 operator ^(uint lhs, uint4x2 rhs)
		{
			return new uint4x2(lhs ^ rhs.c0, lhs ^ rhs.c1);
		}

		// Token: 0x17000B87 RID: 2951
		public unsafe uint4 this[int index]
		{
			get
			{
				fixed (uint4x2* ptr = &this)
				{
					return ref *(uint4*)(ptr + (IntPtr)index * (IntPtr)sizeof(uint4) / (IntPtr)sizeof(uint4x2));
				}
			}
		}

		// Token: 0x060023A9 RID: 9129 RVA: 0x00064A1F File Offset: 0x00062C1F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(uint4x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x060023AA RID: 9130 RVA: 0x00064A48 File Offset: 0x00062C48
		public override bool Equals(object o)
		{
			if (o is uint4x2)
			{
				uint4x2 rhs = (uint4x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060023AB RID: 9131 RVA: 0x00064A6D File Offset: 0x00062C6D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060023AC RID: 9132 RVA: 0x00064A7C File Offset: 0x00062C7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("uint4x2({0}, {1},  {2}, {3},  {4}, {5},  {6}, {7})", new object[]
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

		// Token: 0x060023AD RID: 9133 RVA: 0x00064B34 File Offset: 0x00062D34
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("uint4x2({0}, {1},  {2}, {3},  {4}, {5},  {6}, {7})", new object[]
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

		// Token: 0x0400010E RID: 270
		public uint4 c0;

		// Token: 0x0400010F RID: 271
		public uint4 c1;

		// Token: 0x04000110 RID: 272
		public static readonly uint4x2 zero;
	}
}
