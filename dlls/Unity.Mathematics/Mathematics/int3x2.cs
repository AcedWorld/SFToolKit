using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000032 RID: 50
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int3x2 : IEquatable<int3x2>, IFormattable
	{
		// Token: 0x06001A3D RID: 6717 RVA: 0x00047C7A File Offset: 0x00045E7A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(int3 c0, int3 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x06001A3E RID: 6718 RVA: 0x00047C8A File Offset: 0x00045E8A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(int m00, int m01, int m10, int m11, int m20, int m21)
		{
			this.c0 = new int3(m00, m10, m20);
			this.c1 = new int3(m01, m11, m21);
		}

		// Token: 0x06001A3F RID: 6719 RVA: 0x00047CAB File Offset: 0x00045EAB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(int v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06001A40 RID: 6720 RVA: 0x00047CC5 File Offset: 0x00045EC5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(bool v)
		{
			this.c0 = math.select(new int3(0), new int3(1), v);
			this.c1 = math.select(new int3(0), new int3(1), v);
		}

		// Token: 0x06001A41 RID: 6721 RVA: 0x00047CF7 File Offset: 0x00045EF7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(bool3x2 v)
		{
			this.c0 = math.select(new int3(0), new int3(1), v.c0);
			this.c1 = math.select(new int3(0), new int3(1), v.c1);
		}

		// Token: 0x06001A42 RID: 6722 RVA: 0x00047D33 File Offset: 0x00045F33
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(uint v)
		{
			this.c0 = (int3)v;
			this.c1 = (int3)v;
		}

		// Token: 0x06001A43 RID: 6723 RVA: 0x00047D4D File Offset: 0x00045F4D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(uint3x2 v)
		{
			this.c0 = (int3)v.c0;
			this.c1 = (int3)v.c1;
		}

		// Token: 0x06001A44 RID: 6724 RVA: 0x00047D71 File Offset: 0x00045F71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(float v)
		{
			this.c0 = (int3)v;
			this.c1 = (int3)v;
		}

		// Token: 0x06001A45 RID: 6725 RVA: 0x00047D8B File Offset: 0x00045F8B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(float3x2 v)
		{
			this.c0 = (int3)v.c0;
			this.c1 = (int3)v.c1;
		}

		// Token: 0x06001A46 RID: 6726 RVA: 0x00047DAF File Offset: 0x00045FAF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(double v)
		{
			this.c0 = (int3)v;
			this.c1 = (int3)v;
		}

		// Token: 0x06001A47 RID: 6727 RVA: 0x00047DC9 File Offset: 0x00045FC9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int3x2(double3x2 v)
		{
			this.c0 = (int3)v.c0;
			this.c1 = (int3)v.c1;
		}

		// Token: 0x06001A48 RID: 6728 RVA: 0x00047DED File Offset: 0x00045FED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int3x2(int v)
		{
			return new int3x2(v);
		}

		// Token: 0x06001A49 RID: 6729 RVA: 0x00047DF5 File Offset: 0x00045FF5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x2(bool v)
		{
			return new int3x2(v);
		}

		// Token: 0x06001A4A RID: 6730 RVA: 0x00047DFD File Offset: 0x00045FFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x2(bool3x2 v)
		{
			return new int3x2(v);
		}

		// Token: 0x06001A4B RID: 6731 RVA: 0x00047E05 File Offset: 0x00046005
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x2(uint v)
		{
			return new int3x2(v);
		}

		// Token: 0x06001A4C RID: 6732 RVA: 0x00047E0D File Offset: 0x0004600D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x2(uint3x2 v)
		{
			return new int3x2(v);
		}

		// Token: 0x06001A4D RID: 6733 RVA: 0x00047E15 File Offset: 0x00046015
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x2(float v)
		{
			return new int3x2(v);
		}

		// Token: 0x06001A4E RID: 6734 RVA: 0x00047E1D File Offset: 0x0004601D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x2(float3x2 v)
		{
			return new int3x2(v);
		}

		// Token: 0x06001A4F RID: 6735 RVA: 0x00047E25 File Offset: 0x00046025
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x2(double v)
		{
			return new int3x2(v);
		}

		// Token: 0x06001A50 RID: 6736 RVA: 0x00047E2D File Offset: 0x0004602D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int3x2(double3x2 v)
		{
			return new int3x2(v);
		}

		// Token: 0x06001A51 RID: 6737 RVA: 0x00047E35 File Offset: 0x00046035
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator *(int3x2 lhs, int3x2 rhs)
		{
			return new int3x2(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1);
		}

		// Token: 0x06001A52 RID: 6738 RVA: 0x00047E5E File Offset: 0x0004605E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator *(int3x2 lhs, int rhs)
		{
			return new int3x2(lhs.c0 * rhs, lhs.c1 * rhs);
		}

		// Token: 0x06001A53 RID: 6739 RVA: 0x00047E7D File Offset: 0x0004607D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator *(int lhs, int3x2 rhs)
		{
			return new int3x2(lhs * rhs.c0, lhs * rhs.c1);
		}

		// Token: 0x06001A54 RID: 6740 RVA: 0x00047E9C File Offset: 0x0004609C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator +(int3x2 lhs, int3x2 rhs)
		{
			return new int3x2(lhs.c0 + rhs.c0, lhs.c1 + rhs.c1);
		}

		// Token: 0x06001A55 RID: 6741 RVA: 0x00047EC5 File Offset: 0x000460C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator +(int3x2 lhs, int rhs)
		{
			return new int3x2(lhs.c0 + rhs, lhs.c1 + rhs);
		}

		// Token: 0x06001A56 RID: 6742 RVA: 0x00047EE4 File Offset: 0x000460E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator +(int lhs, int3x2 rhs)
		{
			return new int3x2(lhs + rhs.c0, lhs + rhs.c1);
		}

		// Token: 0x06001A57 RID: 6743 RVA: 0x00047F03 File Offset: 0x00046103
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator -(int3x2 lhs, int3x2 rhs)
		{
			return new int3x2(lhs.c0 - rhs.c0, lhs.c1 - rhs.c1);
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x00047F2C File Offset: 0x0004612C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator -(int3x2 lhs, int rhs)
		{
			return new int3x2(lhs.c0 - rhs, lhs.c1 - rhs);
		}

		// Token: 0x06001A59 RID: 6745 RVA: 0x00047F4B File Offset: 0x0004614B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator -(int lhs, int3x2 rhs)
		{
			return new int3x2(lhs - rhs.c0, lhs - rhs.c1);
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x00047F6A File Offset: 0x0004616A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator /(int3x2 lhs, int3x2 rhs)
		{
			return new int3x2(lhs.c0 / rhs.c0, lhs.c1 / rhs.c1);
		}

		// Token: 0x06001A5B RID: 6747 RVA: 0x00047F93 File Offset: 0x00046193
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator /(int3x2 lhs, int rhs)
		{
			return new int3x2(lhs.c0 / rhs, lhs.c1 / rhs);
		}

		// Token: 0x06001A5C RID: 6748 RVA: 0x00047FB2 File Offset: 0x000461B2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator /(int lhs, int3x2 rhs)
		{
			return new int3x2(lhs / rhs.c0, lhs / rhs.c1);
		}

		// Token: 0x06001A5D RID: 6749 RVA: 0x00047FD1 File Offset: 0x000461D1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator %(int3x2 lhs, int3x2 rhs)
		{
			return new int3x2(lhs.c0 % rhs.c0, lhs.c1 % rhs.c1);
		}

		// Token: 0x06001A5E RID: 6750 RVA: 0x00047FFA File Offset: 0x000461FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator %(int3x2 lhs, int rhs)
		{
			return new int3x2(lhs.c0 % rhs, lhs.c1 % rhs);
		}

		// Token: 0x06001A5F RID: 6751 RVA: 0x00048019 File Offset: 0x00046219
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator %(int lhs, int3x2 rhs)
		{
			return new int3x2(lhs % rhs.c0, lhs % rhs.c1);
		}

		// Token: 0x06001A60 RID: 6752 RVA: 0x00048038 File Offset: 0x00046238
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator ++(int3x2 val)
		{
			int3 @int = ++val.c0;
			val.c0 = @int;
			int3 int2 = @int;
			@int = ++val.c1;
			val.c1 = @int;
			return new int3x2(int2, @int);
		}

		// Token: 0x06001A61 RID: 6753 RVA: 0x00048080 File Offset: 0x00046280
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator --(int3x2 val)
		{
			int3 @int = --val.c0;
			val.c0 = @int;
			int3 int2 = @int;
			@int = --val.c1;
			val.c1 = @int;
			return new int3x2(int2, @int);
		}

		// Token: 0x06001A62 RID: 6754 RVA: 0x000480C6 File Offset: 0x000462C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(int3x2 lhs, int3x2 rhs)
		{
			return new bool3x2(lhs.c0 < rhs.c0, lhs.c1 < rhs.c1);
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x000480EF File Offset: 0x000462EF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(int3x2 lhs, int rhs)
		{
			return new bool3x2(lhs.c0 < rhs, lhs.c1 < rhs);
		}

		// Token: 0x06001A64 RID: 6756 RVA: 0x0004810E File Offset: 0x0004630E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <(int lhs, int3x2 rhs)
		{
			return new bool3x2(lhs < rhs.c0, lhs < rhs.c1);
		}

		// Token: 0x06001A65 RID: 6757 RVA: 0x0004812D File Offset: 0x0004632D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(int3x2 lhs, int3x2 rhs)
		{
			return new bool3x2(lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1);
		}

		// Token: 0x06001A66 RID: 6758 RVA: 0x00048156 File Offset: 0x00046356
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(int3x2 lhs, int rhs)
		{
			return new bool3x2(lhs.c0 <= rhs, lhs.c1 <= rhs);
		}

		// Token: 0x06001A67 RID: 6759 RVA: 0x00048175 File Offset: 0x00046375
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator <=(int lhs, int3x2 rhs)
		{
			return new bool3x2(lhs <= rhs.c0, lhs <= rhs.c1);
		}

		// Token: 0x06001A68 RID: 6760 RVA: 0x00048194 File Offset: 0x00046394
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(int3x2 lhs, int3x2 rhs)
		{
			return new bool3x2(lhs.c0 > rhs.c0, lhs.c1 > rhs.c1);
		}

		// Token: 0x06001A69 RID: 6761 RVA: 0x000481BD File Offset: 0x000463BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(int3x2 lhs, int rhs)
		{
			return new bool3x2(lhs.c0 > rhs, lhs.c1 > rhs);
		}

		// Token: 0x06001A6A RID: 6762 RVA: 0x000481DC File Offset: 0x000463DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >(int lhs, int3x2 rhs)
		{
			return new bool3x2(lhs > rhs.c0, lhs > rhs.c1);
		}

		// Token: 0x06001A6B RID: 6763 RVA: 0x000481FB File Offset: 0x000463FB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(int3x2 lhs, int3x2 rhs)
		{
			return new bool3x2(lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1);
		}

		// Token: 0x06001A6C RID: 6764 RVA: 0x00048224 File Offset: 0x00046424
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(int3x2 lhs, int rhs)
		{
			return new bool3x2(lhs.c0 >= rhs, lhs.c1 >= rhs);
		}

		// Token: 0x06001A6D RID: 6765 RVA: 0x00048243 File Offset: 0x00046443
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator >=(int lhs, int3x2 rhs)
		{
			return new bool3x2(lhs >= rhs.c0, lhs >= rhs.c1);
		}

		// Token: 0x06001A6E RID: 6766 RVA: 0x00048262 File Offset: 0x00046462
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator -(int3x2 val)
		{
			return new int3x2(-val.c0, -val.c1);
		}

		// Token: 0x06001A6F RID: 6767 RVA: 0x0004827F File Offset: 0x0004647F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator +(int3x2 val)
		{
			return new int3x2(+val.c0, +val.c1);
		}

		// Token: 0x06001A70 RID: 6768 RVA: 0x0004829C File Offset: 0x0004649C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator <<(int3x2 x, int n)
		{
			return new int3x2(x.c0 << n, x.c1 << n);
		}

		// Token: 0x06001A71 RID: 6769 RVA: 0x000482BB File Offset: 0x000464BB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator >>(int3x2 x, int n)
		{
			return new int3x2(x.c0 >> n, x.c1 >> n);
		}

		// Token: 0x06001A72 RID: 6770 RVA: 0x000482DA File Offset: 0x000464DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(int3x2 lhs, int3x2 rhs)
		{
			return new bool3x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x06001A73 RID: 6771 RVA: 0x00048303 File Offset: 0x00046503
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(int3x2 lhs, int rhs)
		{
			return new bool3x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x06001A74 RID: 6772 RVA: 0x00048322 File Offset: 0x00046522
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(int lhs, int3x2 rhs)
		{
			return new bool3x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x06001A75 RID: 6773 RVA: 0x00048341 File Offset: 0x00046541
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(int3x2 lhs, int3x2 rhs)
		{
			return new bool3x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x06001A76 RID: 6774 RVA: 0x0004836A File Offset: 0x0004656A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(int3x2 lhs, int rhs)
		{
			return new bool3x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x06001A77 RID: 6775 RVA: 0x00048389 File Offset: 0x00046589
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(int lhs, int3x2 rhs)
		{
			return new bool3x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x06001A78 RID: 6776 RVA: 0x000483A8 File Offset: 0x000465A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator ~(int3x2 val)
		{
			return new int3x2(~val.c0, ~val.c1);
		}

		// Token: 0x06001A79 RID: 6777 RVA: 0x000483C5 File Offset: 0x000465C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator &(int3x2 lhs, int3x2 rhs)
		{
			return new int3x2(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);
		}

		// Token: 0x06001A7A RID: 6778 RVA: 0x000483EE File Offset: 0x000465EE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator &(int3x2 lhs, int rhs)
		{
			return new int3x2(lhs.c0 & rhs, lhs.c1 & rhs);
		}

		// Token: 0x06001A7B RID: 6779 RVA: 0x0004840D File Offset: 0x0004660D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator &(int lhs, int3x2 rhs)
		{
			return new int3x2(lhs & rhs.c0, lhs & rhs.c1);
		}

		// Token: 0x06001A7C RID: 6780 RVA: 0x0004842C File Offset: 0x0004662C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator |(int3x2 lhs, int3x2 rhs)
		{
			return new int3x2(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);
		}

		// Token: 0x06001A7D RID: 6781 RVA: 0x00048455 File Offset: 0x00046655
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator |(int3x2 lhs, int rhs)
		{
			return new int3x2(lhs.c0 | rhs, lhs.c1 | rhs);
		}

		// Token: 0x06001A7E RID: 6782 RVA: 0x00048474 File Offset: 0x00046674
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator |(int lhs, int3x2 rhs)
		{
			return new int3x2(lhs | rhs.c0, lhs | rhs.c1);
		}

		// Token: 0x06001A7F RID: 6783 RVA: 0x00048493 File Offset: 0x00046693
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator ^(int3x2 lhs, int3x2 rhs)
		{
			return new int3x2(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);
		}

		// Token: 0x06001A80 RID: 6784 RVA: 0x000484BC File Offset: 0x000466BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator ^(int3x2 lhs, int rhs)
		{
			return new int3x2(lhs.c0 ^ rhs, lhs.c1 ^ rhs);
		}

		// Token: 0x06001A81 RID: 6785 RVA: 0x000484DB File Offset: 0x000466DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3x2 operator ^(int lhs, int3x2 rhs)
		{
			return new int3x2(lhs ^ rhs.c0, lhs ^ rhs.c1);
		}

		// Token: 0x17000846 RID: 2118
		public unsafe int3 this[int index]
		{
			get
			{
				fixed (int3x2* ptr = &this)
				{
					return ref *(int3*)(ptr + (IntPtr)index * (IntPtr)sizeof(int3) / (IntPtr)sizeof(int3x2));
				}
			}
		}

		// Token: 0x06001A83 RID: 6787 RVA: 0x00048517 File Offset: 0x00046717
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int3x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x06001A84 RID: 6788 RVA: 0x00048540 File Offset: 0x00046740
		public override bool Equals(object o)
		{
			if (o is int3x2)
			{
				int3x2 rhs = (int3x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001A85 RID: 6789 RVA: 0x00048565 File Offset: 0x00046765
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001A86 RID: 6790 RVA: 0x00048574 File Offset: 0x00046774
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int3x2({0}, {1},  {2}, {3},  {4}, {5})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y,
				this.c0.z,
				this.c1.z
			});
		}

		// Token: 0x06001A87 RID: 6791 RVA: 0x00048604 File Offset: 0x00046804
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int3x2({0}, {1},  {2}, {3},  {4}, {5})", new object[]
			{
				this.c0.x.ToString(format, formatProvider),
				this.c1.x.ToString(format, formatProvider),
				this.c0.y.ToString(format, formatProvider),
				this.c1.y.ToString(format, formatProvider),
				this.c0.z.ToString(format, formatProvider),
				this.c1.z.ToString(format, formatProvider)
			});
		}

		// Token: 0x040000C3 RID: 195
		public int3 c0;

		// Token: 0x040000C4 RID: 196
		public int3 c1;

		// Token: 0x040000C5 RID: 197
		public static readonly int3x2 zero;
	}
}
