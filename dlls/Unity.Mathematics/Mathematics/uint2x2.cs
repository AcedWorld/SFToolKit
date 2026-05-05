using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000040 RID: 64
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct uint2x2 : IEquatable<uint2x2>, IFormattable
	{
		// Token: 0x06001EF2 RID: 7922 RVA: 0x000594CA File Offset: 0x000576CA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(uint2 c0, uint2 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x06001EF3 RID: 7923 RVA: 0x000594DA File Offset: 0x000576DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(uint m00, uint m01, uint m10, uint m11)
		{
			this.c0 = new uint2(m00, m10);
			this.c1 = new uint2(m01, m11);
		}

		// Token: 0x06001EF4 RID: 7924 RVA: 0x000594F7 File Offset: 0x000576F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(uint v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06001EF5 RID: 7925 RVA: 0x00059511 File Offset: 0x00057711
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(bool v)
		{
			this.c0 = math.select(new uint2(0U), new uint2(1U), v);
			this.c1 = math.select(new uint2(0U), new uint2(1U), v);
		}

		// Token: 0x06001EF6 RID: 7926 RVA: 0x00059543 File Offset: 0x00057743
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(bool2x2 v)
		{
			this.c0 = math.select(new uint2(0U), new uint2(1U), v.c0);
			this.c1 = math.select(new uint2(0U), new uint2(1U), v.c1);
		}

		// Token: 0x06001EF7 RID: 7927 RVA: 0x0005957F File Offset: 0x0005777F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(int v)
		{
			this.c0 = (uint2)v;
			this.c1 = (uint2)v;
		}

		// Token: 0x06001EF8 RID: 7928 RVA: 0x00059599 File Offset: 0x00057799
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(int2x2 v)
		{
			this.c0 = (uint2)v.c0;
			this.c1 = (uint2)v.c1;
		}

		// Token: 0x06001EF9 RID: 7929 RVA: 0x000595BD File Offset: 0x000577BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(float v)
		{
			this.c0 = (uint2)v;
			this.c1 = (uint2)v;
		}

		// Token: 0x06001EFA RID: 7930 RVA: 0x000595D7 File Offset: 0x000577D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(float2x2 v)
		{
			this.c0 = (uint2)v.c0;
			this.c1 = (uint2)v.c1;
		}

		// Token: 0x06001EFB RID: 7931 RVA: 0x000595FB File Offset: 0x000577FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(double v)
		{
			this.c0 = (uint2)v;
			this.c1 = (uint2)v;
		}

		// Token: 0x06001EFC RID: 7932 RVA: 0x00059615 File Offset: 0x00057815
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2x2(double2x2 v)
		{
			this.c0 = (uint2)v.c0;
			this.c1 = (uint2)v.c1;
		}

		// Token: 0x06001EFD RID: 7933 RVA: 0x00059639 File Offset: 0x00057839
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator uint2x2(uint v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06001EFE RID: 7934 RVA: 0x00059641 File Offset: 0x00057841
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x2(bool v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06001EFF RID: 7935 RVA: 0x00059649 File Offset: 0x00057849
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x2(bool2x2 v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06001F00 RID: 7936 RVA: 0x00059651 File Offset: 0x00057851
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x2(int v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x00059659 File Offset: 0x00057859
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x2(int2x2 v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06001F02 RID: 7938 RVA: 0x00059661 File Offset: 0x00057861
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x2(float v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06001F03 RID: 7939 RVA: 0x00059669 File Offset: 0x00057869
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x2(float2x2 v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06001F04 RID: 7940 RVA: 0x00059671 File Offset: 0x00057871
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x2(double v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06001F05 RID: 7941 RVA: 0x00059679 File Offset: 0x00057879
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2x2(double2x2 v)
		{
			return new uint2x2(v);
		}

		// Token: 0x06001F06 RID: 7942 RVA: 0x00059681 File Offset: 0x00057881
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator *(uint2x2 lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);
		}

		// Token: 0x06001F07 RID: 7943 RVA: 0x000596AA File Offset: 0x000578AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator *(uint2x2 lhs, uint rhs)
		{
			return new uint2x2(lhs.c0 * rhs, lhs.c1 * rhs);
		}

		// Token: 0x06001F08 RID: 7944 RVA: 0x000596C9 File Offset: 0x000578C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator *(uint lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs * rhs.c0, lhs * rhs.c1);
		}

		// Token: 0x06001F09 RID: 7945 RVA: 0x000596E8 File Offset: 0x000578E8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator +(uint2x2 lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);
		}

		// Token: 0x06001F0A RID: 7946 RVA: 0x00059711 File Offset: 0x00057911
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator +(uint2x2 lhs, uint rhs)
		{
			return new uint2x2(lhs.c0 + rhs, lhs.c1 + rhs);
		}

		// Token: 0x06001F0B RID: 7947 RVA: 0x00059730 File Offset: 0x00057930
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator +(uint lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs + rhs.c0, lhs + rhs.c1);
		}

		// Token: 0x06001F0C RID: 7948 RVA: 0x0005974F File Offset: 0x0005794F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator -(uint2x2 lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);
		}

		// Token: 0x06001F0D RID: 7949 RVA: 0x00059778 File Offset: 0x00057978
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator -(uint2x2 lhs, uint rhs)
		{
			return new uint2x2(lhs.c0 - rhs, lhs.c1 - rhs);
		}

		// Token: 0x06001F0E RID: 7950 RVA: 0x00059797 File Offset: 0x00057997
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator -(uint lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs - rhs.c0, lhs - rhs.c1);
		}

		// Token: 0x06001F0F RID: 7951 RVA: 0x000597B6 File Offset: 0x000579B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator /(uint2x2 lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);
		}

		// Token: 0x06001F10 RID: 7952 RVA: 0x000597DF File Offset: 0x000579DF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator /(uint2x2 lhs, uint rhs)
		{
			return new uint2x2(lhs.c0 / rhs, lhs.c1 / rhs);
		}

		// Token: 0x06001F11 RID: 7953 RVA: 0x000597FE File Offset: 0x000579FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator /(uint lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs / rhs.c0, lhs / rhs.c1);
		}

		// Token: 0x06001F12 RID: 7954 RVA: 0x0005981D File Offset: 0x00057A1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator %(uint2x2 lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);
		}

		// Token: 0x06001F13 RID: 7955 RVA: 0x00059846 File Offset: 0x00057A46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator %(uint2x2 lhs, uint rhs)
		{
			return new uint2x2(lhs.c0 % rhs, lhs.c1 % rhs);
		}

		// Token: 0x06001F14 RID: 7956 RVA: 0x00059865 File Offset: 0x00057A65
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator %(uint lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs % rhs.c0, lhs % rhs.c1);
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x00059884 File Offset: 0x00057A84
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator ++(uint2x2 val)
		{
			uint2 @uint = ++val.c0;
			val.c0 = @uint;
			uint2 uint2 = @uint;
			@uint = ++val.c1;
			val.c1 = @uint;
			return new uint2x2(uint2, @uint);
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x000598CC File Offset: 0x00057ACC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator --(uint2x2 val)
		{
			uint2 @uint = --val.c0;
			val.c0 = @uint;
			uint2 uint2 = @uint;
			@uint = --val.c1;
			val.c1 = @uint;
			return new uint2x2(uint2, @uint);
		}

		// Token: 0x06001F17 RID: 7959 RVA: 0x00059912 File Offset: 0x00057B12
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <(uint2x2 lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);
		}

		// Token: 0x06001F18 RID: 7960 RVA: 0x0005993B File Offset: 0x00057B3B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <(uint2x2 lhs, uint rhs)
		{
			return new bool2x2(lhs.c0 < rhs, lhs.c1 < rhs);
		}

		// Token: 0x06001F19 RID: 7961 RVA: 0x0005995A File Offset: 0x00057B5A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <(uint lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs < rhs.c0, lhs < rhs.c1);
		}

		// Token: 0x06001F1A RID: 7962 RVA: 0x00059979 File Offset: 0x00057B79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <=(uint2x2 lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);
		}

		// Token: 0x06001F1B RID: 7963 RVA: 0x000599A2 File Offset: 0x00057BA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <=(uint2x2 lhs, uint rhs)
		{
			return new bool2x2(lhs.c0 <= rhs, lhs.c1 <= rhs);
		}

		// Token: 0x06001F1C RID: 7964 RVA: 0x000599C1 File Offset: 0x00057BC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator <=(uint lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs <= rhs.c0, lhs <= rhs.c1);
		}

		// Token: 0x06001F1D RID: 7965 RVA: 0x000599E0 File Offset: 0x00057BE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >(uint2x2 lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);
		}

		// Token: 0x06001F1E RID: 7966 RVA: 0x00059A09 File Offset: 0x00057C09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >(uint2x2 lhs, uint rhs)
		{
			return new bool2x2(lhs.c0 > rhs, lhs.c1 > rhs);
		}

		// Token: 0x06001F1F RID: 7967 RVA: 0x00059A28 File Offset: 0x00057C28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >(uint lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs > rhs.c0, lhs > rhs.c1);
		}

		// Token: 0x06001F20 RID: 7968 RVA: 0x00059A47 File Offset: 0x00057C47
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >=(uint2x2 lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);
		}

		// Token: 0x06001F21 RID: 7969 RVA: 0x00059A70 File Offset: 0x00057C70
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >=(uint2x2 lhs, uint rhs)
		{
			return new bool2x2(lhs.c0 >= rhs, lhs.c1 >= rhs);
		}

		// Token: 0x06001F22 RID: 7970 RVA: 0x00059A8F File Offset: 0x00057C8F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator >=(uint lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs >= rhs.c0, lhs >= rhs.c1);
		}

		// Token: 0x06001F23 RID: 7971 RVA: 0x00059AAE File Offset: 0x00057CAE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator -(uint2x2 val)
		{
			return new uint2x2(-val.c0, -val.c1);
		}

		// Token: 0x06001F24 RID: 7972 RVA: 0x00059ACB File Offset: 0x00057CCB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator +(uint2x2 val)
		{
			return new uint2x2(+val.c0, +val.c1);
		}

		// Token: 0x06001F25 RID: 7973 RVA: 0x00059AE8 File Offset: 0x00057CE8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator <<(uint2x2 x, int n)
		{
			return new uint2x2(x.c0 << n, x.c1 << n);
		}

		// Token: 0x06001F26 RID: 7974 RVA: 0x00059B07 File Offset: 0x00057D07
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator >>(uint2x2 x, int n)
		{
			return new uint2x2(x.c0 >> n, x.c1 >> n);
		}

		// Token: 0x06001F27 RID: 7975 RVA: 0x00059B26 File Offset: 0x00057D26
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ==(uint2x2 lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x06001F28 RID: 7976 RVA: 0x00059B4F File Offset: 0x00057D4F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ==(uint2x2 lhs, uint rhs)
		{
			return new bool2x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x06001F29 RID: 7977 RVA: 0x00059B6E File Offset: 0x00057D6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ==(uint lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x06001F2A RID: 7978 RVA: 0x00059B8D File Offset: 0x00057D8D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator !=(uint2x2 lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x06001F2B RID: 7979 RVA: 0x00059BB6 File Offset: 0x00057DB6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator !=(uint2x2 lhs, uint rhs)
		{
			return new bool2x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x06001F2C RID: 7980 RVA: 0x00059BD5 File Offset: 0x00057DD5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator !=(uint lhs, uint2x2 rhs)
		{
			return new bool2x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x06001F2D RID: 7981 RVA: 0x00059BF4 File Offset: 0x00057DF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator ~(uint2x2 val)
		{
			return new uint2x2(~val.c0, ~val.c1);
		}

		// Token: 0x06001F2E RID: 7982 RVA: 0x00059C11 File Offset: 0x00057E11
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator &(uint2x2 lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);
		}

		// Token: 0x06001F2F RID: 7983 RVA: 0x00059C3A File Offset: 0x00057E3A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator &(uint2x2 lhs, uint rhs)
		{
			return new uint2x2(lhs.c0 & rhs, lhs.c1 & rhs);
		}

		// Token: 0x06001F30 RID: 7984 RVA: 0x00059C59 File Offset: 0x00057E59
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator &(uint lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs & rhs.c0, lhs & rhs.c1);
		}

		// Token: 0x06001F31 RID: 7985 RVA: 0x00059C78 File Offset: 0x00057E78
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator |(uint2x2 lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);
		}

		// Token: 0x06001F32 RID: 7986 RVA: 0x00059CA1 File Offset: 0x00057EA1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator |(uint2x2 lhs, uint rhs)
		{
			return new uint2x2(lhs.c0 | rhs, lhs.c1 | rhs);
		}

		// Token: 0x06001F33 RID: 7987 RVA: 0x00059CC0 File Offset: 0x00057EC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator |(uint lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs | rhs.c0, lhs | rhs.c1);
		}

		// Token: 0x06001F34 RID: 7988 RVA: 0x00059CDF File Offset: 0x00057EDF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator ^(uint2x2 lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);
		}

		// Token: 0x06001F35 RID: 7989 RVA: 0x00059D08 File Offset: 0x00057F08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator ^(uint2x2 lhs, uint rhs)
		{
			return new uint2x2(lhs.c0 ^ rhs, lhs.c1 ^ rhs);
		}

		// Token: 0x06001F36 RID: 7990 RVA: 0x00059D27 File Offset: 0x00057F27
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2x2 operator ^(uint lhs, uint2x2 rhs)
		{
			return new uint2x2(lhs ^ rhs.c0, lhs ^ rhs.c1);
		}

		// Token: 0x170009BA RID: 2490
		public unsafe uint2 this[int index]
		{
			get
			{
				fixed (uint2x2* ptr = &this)
				{
					return ref *(uint2*)(ptr + (IntPtr)index * (IntPtr)sizeof(uint2) / (IntPtr)sizeof(uint2x2));
				}
			}
		}

		// Token: 0x06001F38 RID: 7992 RVA: 0x00059D63 File Offset: 0x00057F63
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(uint2x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x06001F39 RID: 7993 RVA: 0x00059D8C File Offset: 0x00057F8C
		public override bool Equals(object o)
		{
			if (o is uint2x2)
			{
				uint2x2 rhs = (uint2x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001F3A RID: 7994 RVA: 0x00059DB1 File Offset: 0x00057FB1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001F3B RID: 7995 RVA: 0x00059DC0 File Offset: 0x00057FC0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("uint2x2({0}, {1},  {2}, {3})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y
			});
		}

		// Token: 0x06001F3C RID: 7996 RVA: 0x00059E2C File Offset: 0x0005802C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("uint2x2({0}, {1},  {2}, {3})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000EB RID: 235
		public uint2 c0;

		// Token: 0x040000EC RID: 236
		public uint2 c1;

		// Token: 0x040000ED RID: 237
		public static readonly uint2x2 identity = new uint2x2(1U, 0U, 0U, 1U);

		// Token: 0x040000EE RID: 238
		public static readonly uint2x2 zero;
	}
}
