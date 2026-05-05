using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000041 RID: 65
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct uint2x3 : IEquatable<uint2x3>, IFormattable
	{
		// Token: 0x06001F3E RID: 7998 RVA: 0x00059EAD File Offset: 0x000580AD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(uint2 c0, uint2 c1, uint2 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x06001F3F RID: 7999 RVA: 0x00059EC4 File Offset: 0x000580C4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(uint m00, uint m01, uint m02, uint m10, uint m11, uint m12)
		{
			this.c0 = new uint2(m00, m10);
			this.c1 = new uint2(m01, m11);
			this.c2 = new uint2(m02, m12);
		}

		// Token: 0x06001F40 RID: 8000 RVA: 0x00059EF0 File Offset: 0x000580F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(uint v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x06001F41 RID: 8001 RVA: 0x00059F18 File Offset: 0x00058118
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(bool v)
		{
			this.c0 = math.select(new uint2(0U), new uint2(1U), v);
			this.c1 = math.select(new uint2(0U), new uint2(1U), v);
			this.c2 = math.select(new uint2(0U), new uint2(1U), v);
		}

		// Token: 0x06001F42 RID: 8002 RVA: 0x00059F70 File Offset: 0x00058170
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(bool2x3 v)
		{
			this.c0 = math.select(new uint2(0U), new uint2(1U), v.c0);
			this.c1 = math.select(new uint2(0U), new uint2(1U), v.c1);
			this.c2 = math.select(new uint2(0U), new uint2(1U), v.c2);
		}

		// Token: 0x06001F43 RID: 8003 RVA: 0x00059FD4 File Offset: 0x000581D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(int v)
		{
			this.c0 = (uint2)v;
			this.c1 = (uint2)v;
			this.c2 = (uint2)v;
		}

		// Token: 0x06001F44 RID: 8004 RVA: 0x00059FFA File Offset: 0x000581FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(int2x3 v)
		{
			this.c0 = (uint2)v.c0;
			this.c1 = (uint2)v.c1;
			this.c2 = (uint2)v.c2;
		}

		// Token: 0x06001F45 RID: 8005 RVA: 0x0005A02F File Offset: 0x0005822F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(float v)
		{
			this.c0 = (uint2)v;
			this.c1 = (uint2)v;
			this.c2 = (uint2)v;
		}

		// Token: 0x06001F46 RID: 8006 RVA: 0x0005A055 File Offset: 0x00058255
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(float2x3 v)
		{
			this.c0 = (uint2)v.c0;
			this.c1 = (uint2)v.c1;
			this.c2 = (uint2)v.c2;
		}

		// Token: 0x06001F47 RID: 8007 RVA: 0x0005A08A File Offset: 0x0005828A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(double v)
		{
			this.c0 = (uint2)v;
			this.c1 = (uint2)v;
			this.c2 = (uint2)v;
		}

		// Token: 0x06001F48 RID: 8008 RVA: 0x0005A0B0 File Offset: 0x000582B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x3(double2x3 v)
		{
			this.c0 = (uint2)v.c0;
			this.c1 = (uint2)v.c1;
			this.c2 = (uint2)v.c2;
		}

		// Token: 0x06001F49 RID: 8009 RVA: 0x0005A0E5 File Offset: 0x000582E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator uint2x3(uint v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06001F4A RID: 8010 RVA: 0x0005A0ED File Offset: 0x000582ED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x3(bool v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06001F4B RID: 8011 RVA: 0x0005A0F5 File Offset: 0x000582F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x3(bool2x3 v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06001F4C RID: 8012 RVA: 0x0005A0FD File Offset: 0x000582FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x3(int v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06001F4D RID: 8013 RVA: 0x0005A105 File Offset: 0x00058305
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x3(int2x3 v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06001F4E RID: 8014 RVA: 0x0005A10D File Offset: 0x0005830D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x3(float v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06001F4F RID: 8015 RVA: 0x0005A115 File Offset: 0x00058315
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x3(float2x3 v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06001F50 RID: 8016 RVA: 0x0005A11D File Offset: 0x0005831D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x3(double v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06001F51 RID: 8017 RVA: 0x0005A125 File Offset: 0x00058325
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x3(double2x3 v)
		{
			return new uint2x3(v);
		}

		// Token: 0x06001F52 RID: 8018 RVA: 0x0005A12D File Offset: 0x0005832D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator *(uint2x3 lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);
		}

		// Token: 0x06001F53 RID: 8019 RVA: 0x0005A167 File Offset: 0x00058367
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator *(uint2x3 lhs, uint rhs)
		{
			return new uint2x3(lhs.c0 * rhs, lhs.c1 * rhs, lhs.c2 * rhs);
		}

		// Token: 0x06001F54 RID: 8020 RVA: 0x0005A192 File Offset: 0x00058392
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator *(uint lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);
		}

		// Token: 0x06001F55 RID: 8021 RVA: 0x0005A1BD File Offset: 0x000583BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator +(uint2x3 lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);
		}

		// Token: 0x06001F56 RID: 8022 RVA: 0x0005A1F7 File Offset: 0x000583F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator +(uint2x3 lhs, uint rhs)
		{
			return new uint2x3(lhs.c0 + rhs, lhs.c1 + rhs, lhs.c2 + rhs);
		}

		// Token: 0x06001F57 RID: 8023 RVA: 0x0005A222 File Offset: 0x00058422
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator +(uint lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs + rhs.c0, lhs + rhs.c1, lhs + rhs.c2);
		}

		// Token: 0x06001F58 RID: 8024 RVA: 0x0005A24D File Offset: 0x0005844D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator -(uint2x3 lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);
		}

		// Token: 0x06001F59 RID: 8025 RVA: 0x0005A287 File Offset: 0x00058487
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator -(uint2x3 lhs, uint rhs)
		{
			return new uint2x3(lhs.c0 - rhs, lhs.c1 - rhs, lhs.c2 - rhs);
		}

		// Token: 0x06001F5A RID: 8026 RVA: 0x0005A2B2 File Offset: 0x000584B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator -(uint lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs - rhs.c0, lhs - rhs.c1, lhs - rhs.c2);
		}

		// Token: 0x06001F5B RID: 8027 RVA: 0x0005A2DD File Offset: 0x000584DD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator /(uint2x3 lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);
		}

		// Token: 0x06001F5C RID: 8028 RVA: 0x0005A317 File Offset: 0x00058517
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator /(uint2x3 lhs, uint rhs)
		{
			return new uint2x3(lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);
		}

		// Token: 0x06001F5D RID: 8029 RVA: 0x0005A342 File Offset: 0x00058542
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator /(uint lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs / rhs.c0, lhs / rhs.c1, lhs / rhs.c2);
		}

		// Token: 0x06001F5E RID: 8030 RVA: 0x0005A36D File Offset: 0x0005856D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator %(uint2x3 lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);
		}

		// Token: 0x06001F5F RID: 8031 RVA: 0x0005A3A7 File Offset: 0x000585A7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator %(uint2x3 lhs, uint rhs)
		{
			return new uint2x3(lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);
		}

		// Token: 0x06001F60 RID: 8032 RVA: 0x0005A3D2 File Offset: 0x000585D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator %(uint lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs % rhs.c0, lhs % rhs.c1, lhs % rhs.c2);
		}

		// Token: 0x06001F61 RID: 8033 RVA: 0x0005A400 File Offset: 0x00058600
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator ++(uint2x3 val)
		{
			uint2 @uint = ++val.c0;
			val.c0 = @uint;
			uint2 uint2 = @uint;
			@uint = ++val.c1;
			val.c1 = @uint;
			uint2 uint3 = @uint;
			@uint = ++val.c2;
			val.c2 = @uint;
			return new uint2x3(uint2, uint3, @uint);
		}

		// Token: 0x06001F62 RID: 8034 RVA: 0x0005A460 File Offset: 0x00058660
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator --(uint2x3 val)
		{
			uint2 @uint = --val.c0;
			val.c0 = @uint;
			uint2 uint2 = @uint;
			@uint = --val.c1;
			val.c1 = @uint;
			uint2 uint3 = @uint;
			@uint = --val.c2;
			val.c2 = @uint;
			return new uint2x3(uint2, uint3, @uint);
		}

		// Token: 0x06001F63 RID: 8035 RVA: 0x0005A4C0 File Offset: 0x000586C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(uint2x3 lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);
		}

		// Token: 0x06001F64 RID: 8036 RVA: 0x0005A4FA File Offset: 0x000586FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(uint2x3 lhs, uint rhs)
		{
			return new bool2x3(lhs.c0 < rhs, lhs.c1 < rhs, lhs.c2 < rhs);
		}

		// Token: 0x06001F65 RID: 8037 RVA: 0x0005A525 File Offset: 0x00058725
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <(uint lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs < rhs.c0, lhs < rhs.c1, lhs < rhs.c2);
		}

		// Token: 0x06001F66 RID: 8038 RVA: 0x0005A550 File Offset: 0x00058750
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(uint2x3 lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);
		}

		// Token: 0x06001F67 RID: 8039 RVA: 0x0005A58A File Offset: 0x0005878A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(uint2x3 lhs, uint rhs)
		{
			return new bool2x3(lhs.c0 <= rhs, lhs.c1 <= rhs, lhs.c2 <= rhs);
		}

		// Token: 0x06001F68 RID: 8040 RVA: 0x0005A5B5 File Offset: 0x000587B5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator <=(uint lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs <= rhs.c0, lhs <= rhs.c1, lhs <= rhs.c2);
		}

		// Token: 0x06001F69 RID: 8041 RVA: 0x0005A5E0 File Offset: 0x000587E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(uint2x3 lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);
		}

		// Token: 0x06001F6A RID: 8042 RVA: 0x0005A61A File Offset: 0x0005881A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(uint2x3 lhs, uint rhs)
		{
			return new bool2x3(lhs.c0 > rhs, lhs.c1 > rhs, lhs.c2 > rhs);
		}

		// Token: 0x06001F6B RID: 8043 RVA: 0x0005A645 File Offset: 0x00058845
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >(uint lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs > rhs.c0, lhs > rhs.c1, lhs > rhs.c2);
		}

		// Token: 0x06001F6C RID: 8044 RVA: 0x0005A670 File Offset: 0x00058870
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(uint2x3 lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);
		}

		// Token: 0x06001F6D RID: 8045 RVA: 0x0005A6AA File Offset: 0x000588AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(uint2x3 lhs, uint rhs)
		{
			return new bool2x3(lhs.c0 >= rhs, lhs.c1 >= rhs, lhs.c2 >= rhs);
		}

		// Token: 0x06001F6E RID: 8046 RVA: 0x0005A6D5 File Offset: 0x000588D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator >=(uint lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs >= rhs.c0, lhs >= rhs.c1, lhs >= rhs.c2);
		}

		// Token: 0x06001F6F RID: 8047 RVA: 0x0005A700 File Offset: 0x00058900
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator -(uint2x3 val)
		{
			return new uint2x3(-val.c0, -val.c1, -val.c2);
		}

		// Token: 0x06001F70 RID: 8048 RVA: 0x0005A728 File Offset: 0x00058928
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator +(uint2x3 val)
		{
			return new uint2x3(+val.c0, +val.c1, +val.c2);
		}

		// Token: 0x06001F71 RID: 8049 RVA: 0x0005A750 File Offset: 0x00058950
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator <<(uint2x3 x, int n)
		{
			return new uint2x3(x.c0 << n, x.c1 << n, x.c2 << n);
		}

		// Token: 0x06001F72 RID: 8050 RVA: 0x0005A77B File Offset: 0x0005897B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator >>(uint2x3 x, int n)
		{
			return new uint2x3(x.c0 >> n, x.c1 >> n, x.c2 >> n);
		}

		// Token: 0x06001F73 RID: 8051 RVA: 0x0005A7A6 File Offset: 0x000589A6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(uint2x3 lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x06001F74 RID: 8052 RVA: 0x0005A7E0 File Offset: 0x000589E0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(uint2x3 lhs, uint rhs)
		{
			return new bool2x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x06001F75 RID: 8053 RVA: 0x0005A80B File Offset: 0x00058A0B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(uint lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x06001F76 RID: 8054 RVA: 0x0005A836 File Offset: 0x00058A36
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(uint2x3 lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x06001F77 RID: 8055 RVA: 0x0005A870 File Offset: 0x00058A70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(uint2x3 lhs, uint rhs)
		{
			return new bool2x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x06001F78 RID: 8056 RVA: 0x0005A89B File Offset: 0x00058A9B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(uint lhs, uint2x3 rhs)
		{
			return new bool2x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x06001F79 RID: 8057 RVA: 0x0005A8C6 File Offset: 0x00058AC6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator ~(uint2x3 val)
		{
			return new uint2x3(~val.c0, ~val.c1, ~val.c2);
		}

		// Token: 0x06001F7A RID: 8058 RVA: 0x0005A8EE File Offset: 0x00058AEE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator &(uint2x3 lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);
		}

		// Token: 0x06001F7B RID: 8059 RVA: 0x0005A928 File Offset: 0x00058B28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator &(uint2x3 lhs, uint rhs)
		{
			return new uint2x3(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs);
		}

		// Token: 0x06001F7C RID: 8060 RVA: 0x0005A953 File Offset: 0x00058B53
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator &(uint lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2);
		}

		// Token: 0x06001F7D RID: 8061 RVA: 0x0005A97E File Offset: 0x00058B7E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator |(uint2x3 lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);
		}

		// Token: 0x06001F7E RID: 8062 RVA: 0x0005A9B8 File Offset: 0x00058BB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator |(uint2x3 lhs, uint rhs)
		{
			return new uint2x3(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs);
		}

		// Token: 0x06001F7F RID: 8063 RVA: 0x0005A9E3 File Offset: 0x00058BE3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator |(uint lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2);
		}

		// Token: 0x06001F80 RID: 8064 RVA: 0x0005AA0E File Offset: 0x00058C0E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator ^(uint2x3 lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);
		}

		// Token: 0x06001F81 RID: 8065 RVA: 0x0005AA48 File Offset: 0x00058C48
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator ^(uint2x3 lhs, uint rhs)
		{
			return new uint2x3(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs);
		}

		// Token: 0x06001F82 RID: 8066 RVA: 0x0005AA73 File Offset: 0x00058C73
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x3 operator ^(uint lhs, uint2x3 rhs)
		{
			return new uint2x3(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2);
		}

		// Token: 0x170009BB RID: 2491
		public unsafe uint2 this[int index]
		{
			get
			{
				fixed (uint2x3* ptr = &this)
				{
					return ref *(uint2*)(ptr + (IntPtr)index * (IntPtr)sizeof(uint2) / (IntPtr)sizeof(uint2x3));
				}
			}
		}

		// Token: 0x06001F84 RID: 8068 RVA: 0x0005AABB File Offset: 0x00058CBB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(uint2x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x06001F85 RID: 8069 RVA: 0x0005AAF8 File Offset: 0x00058CF8
		public override bool Equals(object o)
		{
			if (o is uint2x3)
			{
				uint2x3 rhs = (uint2x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001F86 RID: 8070 RVA: 0x0005AB1D File Offset: 0x00058D1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001F87 RID: 8071 RVA: 0x0005AB2C File Offset: 0x00058D2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("uint2x3({0}, {1}, {2},  {3}, {4}, {5})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y
			});
		}

		// Token: 0x06001F88 RID: 8072 RVA: 0x0005ABBC File Offset: 0x00058DBC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("uint2x3({0}, {1}, {2},  {3}, {4}, {5})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c2.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c2.y.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000EF RID: 239
		public uint2 c0;

		// Token: 0x040000F0 RID: 240
		public uint2 c1;

		// Token: 0x040000F1 RID: 241
		public uint2 c2;

		// Token: 0x040000F2 RID: 242
		public static readonly uint2x3 zero;
	}
}
