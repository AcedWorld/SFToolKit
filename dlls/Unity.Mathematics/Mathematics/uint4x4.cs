using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200004A RID: 74
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct uint4x4 : IEquatable<uint4x4>, IFormattable
	{
		// Token: 0x060023F9 RID: 9209 RVA: 0x00065AA9 File Offset: 0x00063CA9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(uint4 c0, uint4 c1, uint4 c2, uint4 c3)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
			this.c3 = c3;
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x00065AC8 File Offset: 0x00063CC8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(uint m00, uint m01, uint m02, uint m03, uint m10, uint m11, uint m12, uint m13, uint m20, uint m21, uint m22, uint m23, uint m30, uint m31, uint m32, uint m33)
		{
			this.c0 = new uint4(m00, m10, m20, m30);
			this.c1 = new uint4(m01, m11, m21, m31);
			this.c2 = new uint4(m02, m12, m22, m32);
			this.c3 = new uint4(m03, m13, m23, m33);
		}

		// Token: 0x060023FB RID: 9211 RVA: 0x00065B1E File Offset: 0x00063D1E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x060023FC RID: 9212 RVA: 0x00065B50 File Offset: 0x00063D50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(bool v)
		{
			this.c0 = math.select(new uint4(0U), new uint4(1U), v);
			this.c1 = math.select(new uint4(0U), new uint4(1U), v);
			this.c2 = math.select(new uint4(0U), new uint4(1U), v);
			this.c3 = math.select(new uint4(0U), new uint4(1U), v);
		}

		// Token: 0x060023FD RID: 9213 RVA: 0x00065BC0 File Offset: 0x00063DC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(bool4x4 v)
		{
			this.c0 = math.select(new uint4(0U), new uint4(1U), v.c0);
			this.c1 = math.select(new uint4(0U), new uint4(1U), v.c1);
			this.c2 = math.select(new uint4(0U), new uint4(1U), v.c2);
			this.c3 = math.select(new uint4(0U), new uint4(1U), v.c3);
		}

		// Token: 0x060023FE RID: 9214 RVA: 0x00065C41 File Offset: 0x00063E41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(int v)
		{
			this.c0 = (uint4)v;
			this.c1 = (uint4)v;
			this.c2 = (uint4)v;
			this.c3 = (uint4)v;
		}

		// Token: 0x060023FF RID: 9215 RVA: 0x00065C74 File Offset: 0x00063E74
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(int4x4 v)
		{
			this.c0 = (uint4)v.c0;
			this.c1 = (uint4)v.c1;
			this.c2 = (uint4)v.c2;
			this.c3 = (uint4)v.c3;
		}

		// Token: 0x06002400 RID: 9216 RVA: 0x00065CC5 File Offset: 0x00063EC5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(float v)
		{
			this.c0 = (uint4)v;
			this.c1 = (uint4)v;
			this.c2 = (uint4)v;
			this.c3 = (uint4)v;
		}

		// Token: 0x06002401 RID: 9217 RVA: 0x00065CF8 File Offset: 0x00063EF8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(float4x4 v)
		{
			this.c0 = (uint4)v.c0;
			this.c1 = (uint4)v.c1;
			this.c2 = (uint4)v.c2;
			this.c3 = (uint4)v.c3;
		}

		// Token: 0x06002402 RID: 9218 RVA: 0x00065D49 File Offset: 0x00063F49
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(double v)
		{
			this.c0 = (uint4)v;
			this.c1 = (uint4)v;
			this.c2 = (uint4)v;
			this.c3 = (uint4)v;
		}

		// Token: 0x06002403 RID: 9219 RVA: 0x00065D7C File Offset: 0x00063F7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint4x4(double4x4 v)
		{
			this.c0 = (uint4)v.c0;
			this.c1 = (uint4)v.c1;
			this.c2 = (uint4)v.c2;
			this.c3 = (uint4)v.c3;
		}

		// Token: 0x06002404 RID: 9220 RVA: 0x00065DCD File Offset: 0x00063FCD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator uint4x4(uint v)
		{
			return new uint4x4(v);
		}

		// Token: 0x06002405 RID: 9221 RVA: 0x00065DD5 File Offset: 0x00063FD5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x4(bool v)
		{
			return new uint4x4(v);
		}

		// Token: 0x06002406 RID: 9222 RVA: 0x00065DDD File Offset: 0x00063FDD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x4(bool4x4 v)
		{
			return new uint4x4(v);
		}

		// Token: 0x06002407 RID: 9223 RVA: 0x00065DE5 File Offset: 0x00063FE5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x4(int v)
		{
			return new uint4x4(v);
		}

		// Token: 0x06002408 RID: 9224 RVA: 0x00065DED File Offset: 0x00063FED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x4(int4x4 v)
		{
			return new uint4x4(v);
		}

		// Token: 0x06002409 RID: 9225 RVA: 0x00065DF5 File Offset: 0x00063FF5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x4(float v)
		{
			return new uint4x4(v);
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x00065DFD File Offset: 0x00063FFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x4(float4x4 v)
		{
			return new uint4x4(v);
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x00065E05 File Offset: 0x00064005
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x4(double v)
		{
			return new uint4x4(v);
		}

		// Token: 0x0600240C RID: 9228 RVA: 0x00065E0D File Offset: 0x0006400D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4x4(double4x4 v)
		{
			return new uint4x4(v);
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x00065E18 File Offset: 0x00064018
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator *(uint4x4 lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3);
		}

		// Token: 0x0600240E RID: 9230 RVA: 0x00065E6E File Offset: 0x0006406E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator *(uint4x4 lhs, uint rhs)
		{
			return new uint4x4(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs, lhs.c3 * rhs);
		}

		// Token: 0x0600240F RID: 9231 RVA: 0x00065EA5 File Offset: 0x000640A5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator *(uint lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3);
		}

		// Token: 0x06002410 RID: 9232 RVA: 0x00065EDC File Offset: 0x000640DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator +(uint4x4 lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3);
		}

		// Token: 0x06002411 RID: 9233 RVA: 0x00065F32 File Offset: 0x00064132
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator +(uint4x4 lhs, uint rhs)
		{
			return new uint4x4(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs, lhs.c3 + rhs);
		}

		// Token: 0x06002412 RID: 9234 RVA: 0x00065F69 File Offset: 0x00064169
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator +(uint lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2, lhs + rhs.c3);
		}

		// Token: 0x06002413 RID: 9235 RVA: 0x00065FA0 File Offset: 0x000641A0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator -(uint4x4 lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3);
		}

		// Token: 0x06002414 RID: 9236 RVA: 0x00065FF6 File Offset: 0x000641F6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator -(uint4x4 lhs, uint rhs)
		{
			return new uint4x4(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs, lhs.c3 - rhs);
		}

		// Token: 0x06002415 RID: 9237 RVA: 0x0006602D File Offset: 0x0006422D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator -(uint lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2, lhs - rhs.c3);
		}

		// Token: 0x06002416 RID: 9238 RVA: 0x00066064 File Offset: 0x00064264
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator /(uint4x4 lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3);
		}

		// Token: 0x06002417 RID: 9239 RVA: 0x000660BA File Offset: 0x000642BA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator /(uint4x4 lhs, uint rhs)
		{
			return new uint4x4(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs);
		}

		// Token: 0x06002418 RID: 9240 RVA: 0x000660F1 File Offset: 0x000642F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator /(uint lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2, lhs / rhs.c3);
		}

		// Token: 0x06002419 RID: 9241 RVA: 0x00066128 File Offset: 0x00064328
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator %(uint4x4 lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3);
		}

		// Token: 0x0600241A RID: 9242 RVA: 0x0006617E File Offset: 0x0006437E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator %(uint4x4 lhs, uint rhs)
		{
			return new uint4x4(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs);
		}

		// Token: 0x0600241B RID: 9243 RVA: 0x000661B5 File Offset: 0x000643B5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator %(uint lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2, lhs % rhs.c3);
		}

		// Token: 0x0600241C RID: 9244 RVA: 0x000661EC File Offset: 0x000643EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator ++(uint4x4 val)
		{
			uint4 @uint = ++val.c0;
			val.c0 = @uint;
			uint4 uint2 = @uint;
			@uint = ++val.c1;
			val.c1 = @uint;
			uint4 uint3 = @uint;
			@uint = ++val.c2;
			val.c2 = @uint;
			uint4 uint4 = @uint;
			@uint = ++val.c3;
			val.c3 = @uint;
			return new uint4x4(uint2, uint3, uint4, @uint);
		}

		// Token: 0x0600241D RID: 9245 RVA: 0x00066268 File Offset: 0x00064468
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator --(uint4x4 val)
		{
			uint4 @uint = --val.c0;
			val.c0 = @uint;
			uint4 uint2 = @uint;
			@uint = --val.c1;
			val.c1 = @uint;
			uint4 uint3 = @uint;
			@uint = --val.c2;
			val.c2 = @uint;
			uint4 uint4 = @uint;
			@uint = --val.c3;
			val.c3 = @uint;
			return new uint4x4(uint2, uint3, uint4, @uint);
		}

		// Token: 0x0600241E RID: 9246 RVA: 0x000662E4 File Offset: 0x000644E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <(uint4x4 lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3);
		}

		// Token: 0x0600241F RID: 9247 RVA: 0x0006633A File Offset: 0x0006453A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <(uint4x4 lhs, uint rhs)
		{
			return new bool4x4(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs, lhs.c3 < rhs);
		}

		// Token: 0x06002420 RID: 9248 RVA: 0x00066371 File Offset: 0x00064571
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <(uint lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2, lhs < rhs.c3);
		}

		// Token: 0x06002421 RID: 9249 RVA: 0x000663A8 File Offset: 0x000645A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <=(uint4x4 lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3);
		}

		// Token: 0x06002422 RID: 9250 RVA: 0x000663FE File Offset: 0x000645FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <=(uint4x4 lhs, uint rhs)
		{
			return new bool4x4(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs, lhs.c3 <= rhs);
		}

		// Token: 0x06002423 RID: 9251 RVA: 0x00066435 File Offset: 0x00064635
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator <=(uint lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2, lhs <= rhs.c3);
		}

		// Token: 0x06002424 RID: 9252 RVA: 0x0006646C File Offset: 0x0006466C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >(uint4x4 lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3);
		}

		// Token: 0x06002425 RID: 9253 RVA: 0x000664C2 File Offset: 0x000646C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >(uint4x4 lhs, uint rhs)
		{
			return new bool4x4(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs, lhs.c3 > rhs);
		}

		// Token: 0x06002426 RID: 9254 RVA: 0x000664F9 File Offset: 0x000646F9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >(uint lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2, lhs > rhs.c3);
		}

		// Token: 0x06002427 RID: 9255 RVA: 0x00066530 File Offset: 0x00064730
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >=(uint4x4 lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3);
		}

		// Token: 0x06002428 RID: 9256 RVA: 0x00066586 File Offset: 0x00064786
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >=(uint4x4 lhs, uint rhs)
		{
			return new bool4x4(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs, lhs.c3 >= rhs);
		}

		// Token: 0x06002429 RID: 9257 RVA: 0x000665BD File Offset: 0x000647BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator >=(uint lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2, lhs >= rhs.c3);
		}

		// Token: 0x0600242A RID: 9258 RVA: 0x000665F4 File Offset: 0x000647F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator -(uint4x4 val)
		{
			return new uint4x4(-val.c0, -val.c1, -val.c2, -val.c3);
		}

		// Token: 0x0600242B RID: 9259 RVA: 0x00066627 File Offset: 0x00064827
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator +(uint4x4 val)
		{
			return new uint4x4(+val.c0, +val.c1, +val.c2, +val.c3);
		}

		// Token: 0x0600242C RID: 9260 RVA: 0x0006665A File Offset: 0x0006485A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator <<(uint4x4 x, int n)
		{
			return new uint4x4(x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n);
		}

		// Token: 0x0600242D RID: 9261 RVA: 0x00066691 File Offset: 0x00064891
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator >>(uint4x4 x, int n)
		{
			return new uint4x4(x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n);
		}

		// Token: 0x0600242E RID: 9262 RVA: 0x000666C8 File Offset: 0x000648C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator ==(uint4x4 lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);
		}

		// Token: 0x0600242F RID: 9263 RVA: 0x0006671E File Offset: 0x0006491E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator ==(uint4x4 lhs, uint rhs)
		{
			return new bool4x4(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs);
		}

		// Token: 0x06002430 RID: 9264 RVA: 0x00066755 File Offset: 0x00064955
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator ==(uint lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3);
		}

		// Token: 0x06002431 RID: 9265 RVA: 0x0006678C File Offset: 0x0006498C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator !=(uint4x4 lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);
		}

		// Token: 0x06002432 RID: 9266 RVA: 0x000667E2 File Offset: 0x000649E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator !=(uint4x4 lhs, uint rhs)
		{
			return new bool4x4(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs);
		}

		// Token: 0x06002433 RID: 9267 RVA: 0x00066819 File Offset: 0x00064A19
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x4 operator !=(uint lhs, uint4x4 rhs)
		{
			return new bool4x4(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3);
		}

		// Token: 0x06002434 RID: 9268 RVA: 0x00066850 File Offset: 0x00064A50
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator ~(uint4x4 val)
		{
			return new uint4x4(~val.c0, ~val.c1, ~val.c2, ~val.c3);
		}

		// Token: 0x06002435 RID: 9269 RVA: 0x00066884 File Offset: 0x00064A84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator &(uint4x4 lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2, lhs.c3 & rhs.c3);
		}

		// Token: 0x06002436 RID: 9270 RVA: 0x000668DA File Offset: 0x00064ADA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator &(uint4x4 lhs, uint rhs)
		{
			return new uint4x4(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs, lhs.c3 & rhs);
		}

		// Token: 0x06002437 RID: 9271 RVA: 0x00066911 File Offset: 0x00064B11
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator &(uint lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2, lhs & rhs.c3);
		}

		// Token: 0x06002438 RID: 9272 RVA: 0x00066948 File Offset: 0x00064B48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator |(uint4x4 lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2, lhs.c3 | rhs.c3);
		}

		// Token: 0x06002439 RID: 9273 RVA: 0x0006699E File Offset: 0x00064B9E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator |(uint4x4 lhs, uint rhs)
		{
			return new uint4x4(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs, lhs.c3 | rhs);
		}

		// Token: 0x0600243A RID: 9274 RVA: 0x000669D5 File Offset: 0x00064BD5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator |(uint lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2, lhs | rhs.c3);
		}

		// Token: 0x0600243B RID: 9275 RVA: 0x00066A0C File Offset: 0x00064C0C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator ^(uint4x4 lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2, lhs.c3 ^ rhs.c3);
		}

		// Token: 0x0600243C RID: 9276 RVA: 0x00066A62 File Offset: 0x00064C62
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator ^(uint4x4 lhs, uint rhs)
		{
			return new uint4x4(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs, lhs.c3 ^ rhs);
		}

		// Token: 0x0600243D RID: 9277 RVA: 0x00066A99 File Offset: 0x00064C99
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4x4 operator ^(uint lhs, uint4x4 rhs)
		{
			return new uint4x4(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2, lhs ^ rhs.c3);
		}

		// Token: 0x17000B89 RID: 2953
		public unsafe uint4 this[int index]
		{
			get
			{
				fixed (uint4x4* ptr = &this)
				{
					return ref *(uint4*)(ptr + (IntPtr)index * (IntPtr)sizeof(uint4) / (IntPtr)sizeof(uint4x4));
				}
			}
		}

		// Token: 0x0600243F RID: 9279 RVA: 0x00066AEC File Offset: 0x00064CEC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(uint4x4 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2) && this.c3.Equals(rhs.c3);
		}

		// Token: 0x06002440 RID: 9280 RVA: 0x00066B48 File Offset: 0x00064D48
		public override bool Equals(object o)
		{
			if (o is uint4x4)
			{
				uint4x4 rhs = (uint4x4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x00066B6D File Offset: 0x00064D6D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06002442 RID: 9282 RVA: 0x00066B7C File Offset: 0x00064D7C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("uint4x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7},  {8}, {9}, {10}, {11},  {12}, {13}, {14}, {15})", new object[]
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

		// Token: 0x06002443 RID: 9283 RVA: 0x00066CD4 File Offset: 0x00064ED4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("uint4x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7},  {8}, {9}, {10}, {11},  {12}, {13}, {14}, {15})", new object[]
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

		// Token: 0x04000115 RID: 277
		public uint4 c0;

		// Token: 0x04000116 RID: 278
		public uint4 c1;

		// Token: 0x04000117 RID: 279
		public uint4 c2;

		// Token: 0x04000118 RID: 280
		public uint4 c3;

		// Token: 0x04000119 RID: 281
		public static readonly uint4x4 identity = new uint4x4(1U, 0U, 0U, 0U, 0U, 1U, 0U, 0U, 0U, 0U, 1U, 0U, 0U, 0U, 0U, 1U);

		// Token: 0x0400011A RID: 282
		public static readonly uint4x4 zero;
	}
}
