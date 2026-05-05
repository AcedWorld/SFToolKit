using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200003F RID: 63
	[DebuggerTypeProxy(typeof(uint2.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct uint2 : IEquatable<uint2>, IFormattable
	{
		// Token: 0x06001E88 RID: 7816 RVA: 0x000589ED File Offset: 0x00056BED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(uint x, uint y)
		{
			this.x = x;
			this.y = y;
		}

		// Token: 0x06001E89 RID: 7817 RVA: 0x000589FD File Offset: 0x00056BFD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(uint2 xy)
		{
			this.x = xy.x;
			this.y = xy.y;
		}

		// Token: 0x06001E8A RID: 7818 RVA: 0x00058A17 File Offset: 0x00056C17
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(uint v)
		{
			this.x = v;
			this.y = v;
		}

		// Token: 0x06001E8B RID: 7819 RVA: 0x00058A27 File Offset: 0x00056C27
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(bool v)
		{
			this.x = (v ? 1U : 0U);
			this.y = (v ? 1U : 0U);
		}

		// Token: 0x06001E8C RID: 7820 RVA: 0x00058A43 File Offset: 0x00056C43
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(bool2 v)
		{
			this.x = (v.x ? 1U : 0U);
			this.y = (v.y ? 1U : 0U);
		}

		// Token: 0x06001E8D RID: 7821 RVA: 0x00058A69 File Offset: 0x00056C69
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(int v)
		{
			this.x = (uint)v;
			this.y = (uint)v;
		}

		// Token: 0x06001E8E RID: 7822 RVA: 0x00058A79 File Offset: 0x00056C79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(int2 v)
		{
			this.x = (uint)v.x;
			this.y = (uint)v.y;
		}

		// Token: 0x06001E8F RID: 7823 RVA: 0x00058A93 File Offset: 0x00056C93
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(float v)
		{
			this.x = (uint)v;
			this.y = (uint)v;
		}

		// Token: 0x06001E90 RID: 7824 RVA: 0x00058AA5 File Offset: 0x00056CA5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(float2 v)
		{
			this.x = (uint)v.x;
			this.y = (uint)v.y;
		}

		// Token: 0x06001E91 RID: 7825 RVA: 0x00058AC1 File Offset: 0x00056CC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(double v)
		{
			this.x = (uint)v;
			this.y = (uint)v;
		}

		// Token: 0x06001E92 RID: 7826 RVA: 0x00058AD3 File Offset: 0x00056CD3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint2(double2 v)
		{
			this.x = (uint)v.x;
			this.y = (uint)v.y;
		}

		// Token: 0x06001E93 RID: 7827 RVA: 0x00058AEF File Offset: 0x00056CEF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator uint2(uint v)
		{
			return new uint2(v);
		}

		// Token: 0x06001E94 RID: 7828 RVA: 0x00058AF7 File Offset: 0x00056CF7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2(bool v)
		{
			return new uint2(v);
		}

		// Token: 0x06001E95 RID: 7829 RVA: 0x00058AFF File Offset: 0x00056CFF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2(bool2 v)
		{
			return new uint2(v);
		}

		// Token: 0x06001E96 RID: 7830 RVA: 0x00058B07 File Offset: 0x00056D07
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2(int v)
		{
			return new uint2(v);
		}

		// Token: 0x06001E97 RID: 7831 RVA: 0x00058B0F File Offset: 0x00056D0F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2(int2 v)
		{
			return new uint2(v);
		}

		// Token: 0x06001E98 RID: 7832 RVA: 0x00058B17 File Offset: 0x00056D17
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2(float v)
		{
			return new uint2(v);
		}

		// Token: 0x06001E99 RID: 7833 RVA: 0x00058B1F File Offset: 0x00056D1F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2(float2 v)
		{
			return new uint2(v);
		}

		// Token: 0x06001E9A RID: 7834 RVA: 0x00058B27 File Offset: 0x00056D27
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2(double v)
		{
			return new uint2(v);
		}

		// Token: 0x06001E9B RID: 7835 RVA: 0x00058B2F File Offset: 0x00056D2F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint2(double2 v)
		{
			return new uint2(v);
		}

		// Token: 0x06001E9C RID: 7836 RVA: 0x00058B37 File Offset: 0x00056D37
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator *(uint2 lhs, uint2 rhs)
		{
			return new uint2(lhs.x * rhs.x, lhs.y * rhs.y);
		}

		// Token: 0x06001E9D RID: 7837 RVA: 0x00058B58 File Offset: 0x00056D58
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator *(uint2 lhs, uint rhs)
		{
			return new uint2(lhs.x * rhs, lhs.y * rhs);
		}

		// Token: 0x06001E9E RID: 7838 RVA: 0x00058B6F File Offset: 0x00056D6F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator *(uint lhs, uint2 rhs)
		{
			return new uint2(lhs * rhs.x, lhs * rhs.y);
		}

		// Token: 0x06001E9F RID: 7839 RVA: 0x00058B86 File Offset: 0x00056D86
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator +(uint2 lhs, uint2 rhs)
		{
			return new uint2(lhs.x + rhs.x, lhs.y + rhs.y);
		}

		// Token: 0x06001EA0 RID: 7840 RVA: 0x00058BA7 File Offset: 0x00056DA7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator +(uint2 lhs, uint rhs)
		{
			return new uint2(lhs.x + rhs, lhs.y + rhs);
		}

		// Token: 0x06001EA1 RID: 7841 RVA: 0x00058BBE File Offset: 0x00056DBE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator +(uint lhs, uint2 rhs)
		{
			return new uint2(lhs + rhs.x, lhs + rhs.y);
		}

		// Token: 0x06001EA2 RID: 7842 RVA: 0x00058BD5 File Offset: 0x00056DD5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator -(uint2 lhs, uint2 rhs)
		{
			return new uint2(lhs.x - rhs.x, lhs.y - rhs.y);
		}

		// Token: 0x06001EA3 RID: 7843 RVA: 0x00058BF6 File Offset: 0x00056DF6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator -(uint2 lhs, uint rhs)
		{
			return new uint2(lhs.x - rhs, lhs.y - rhs);
		}

		// Token: 0x06001EA4 RID: 7844 RVA: 0x00058C0D File Offset: 0x00056E0D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator -(uint lhs, uint2 rhs)
		{
			return new uint2(lhs - rhs.x, lhs - rhs.y);
		}

		// Token: 0x06001EA5 RID: 7845 RVA: 0x00058C24 File Offset: 0x00056E24
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator /(uint2 lhs, uint2 rhs)
		{
			return new uint2(lhs.x / rhs.x, lhs.y / rhs.y);
		}

		// Token: 0x06001EA6 RID: 7846 RVA: 0x00058C45 File Offset: 0x00056E45
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator /(uint2 lhs, uint rhs)
		{
			return new uint2(lhs.x / rhs, lhs.y / rhs);
		}

		// Token: 0x06001EA7 RID: 7847 RVA: 0x00058C5C File Offset: 0x00056E5C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator /(uint lhs, uint2 rhs)
		{
			return new uint2(lhs / rhs.x, lhs / rhs.y);
		}

		// Token: 0x06001EA8 RID: 7848 RVA: 0x00058C73 File Offset: 0x00056E73
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator %(uint2 lhs, uint2 rhs)
		{
			return new uint2(lhs.x % rhs.x, lhs.y % rhs.y);
		}

		// Token: 0x06001EA9 RID: 7849 RVA: 0x00058C94 File Offset: 0x00056E94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator %(uint2 lhs, uint rhs)
		{
			return new uint2(lhs.x % rhs, lhs.y % rhs);
		}

		// Token: 0x06001EAA RID: 7850 RVA: 0x00058CAB File Offset: 0x00056EAB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator %(uint lhs, uint2 rhs)
		{
			return new uint2(lhs % rhs.x, lhs % rhs.y);
		}

		// Token: 0x06001EAB RID: 7851 RVA: 0x00058CC4 File Offset: 0x00056EC4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator ++(uint2 val)
		{
			uint num = val.x + 1U;
			val.x = num;
			uint num2 = num;
			num = val.y + 1U;
			val.y = num;
			return new uint2(num2, num);
		}

		// Token: 0x06001EAC RID: 7852 RVA: 0x00058CF4 File Offset: 0x00056EF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator --(uint2 val)
		{
			uint num = val.x - 1U;
			val.x = num;
			uint num2 = num;
			num = val.y - 1U;
			val.y = num;
			return new uint2(num2, num);
		}

		// Token: 0x06001EAD RID: 7853 RVA: 0x00058D24 File Offset: 0x00056F24
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(uint2 lhs, uint2 rhs)
		{
			return new bool2(lhs.x < rhs.x, lhs.y < rhs.y);
		}

		// Token: 0x06001EAE RID: 7854 RVA: 0x00058D47 File Offset: 0x00056F47
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(uint2 lhs, uint rhs)
		{
			return new bool2(lhs.x < rhs, lhs.y < rhs);
		}

		// Token: 0x06001EAF RID: 7855 RVA: 0x00058D60 File Offset: 0x00056F60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(uint lhs, uint2 rhs)
		{
			return new bool2(lhs < rhs.x, lhs < rhs.y);
		}

		// Token: 0x06001EB0 RID: 7856 RVA: 0x00058D79 File Offset: 0x00056F79
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(uint2 lhs, uint2 rhs)
		{
			return new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);
		}

		// Token: 0x06001EB1 RID: 7857 RVA: 0x00058DA2 File Offset: 0x00056FA2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(uint2 lhs, uint rhs)
		{
			return new bool2(lhs.x <= rhs, lhs.y <= rhs);
		}

		// Token: 0x06001EB2 RID: 7858 RVA: 0x00058DC1 File Offset: 0x00056FC1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(uint lhs, uint2 rhs)
		{
			return new bool2(lhs <= rhs.x, lhs <= rhs.y);
		}

		// Token: 0x06001EB3 RID: 7859 RVA: 0x00058DE0 File Offset: 0x00056FE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(uint2 lhs, uint2 rhs)
		{
			return new bool2(lhs.x > rhs.x, lhs.y > rhs.y);
		}

		// Token: 0x06001EB4 RID: 7860 RVA: 0x00058E03 File Offset: 0x00057003
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(uint2 lhs, uint rhs)
		{
			return new bool2(lhs.x > rhs, lhs.y > rhs);
		}

		// Token: 0x06001EB5 RID: 7861 RVA: 0x00058E1C File Offset: 0x0005701C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(uint lhs, uint2 rhs)
		{
			return new bool2(lhs > rhs.x, lhs > rhs.y);
		}

		// Token: 0x06001EB6 RID: 7862 RVA: 0x00058E35 File Offset: 0x00057035
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(uint2 lhs, uint2 rhs)
		{
			return new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);
		}

		// Token: 0x06001EB7 RID: 7863 RVA: 0x00058E5E File Offset: 0x0005705E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(uint2 lhs, uint rhs)
		{
			return new bool2(lhs.x >= rhs, lhs.y >= rhs);
		}

		// Token: 0x06001EB8 RID: 7864 RVA: 0x00058E7D File Offset: 0x0005707D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(uint lhs, uint2 rhs)
		{
			return new bool2(lhs >= rhs.x, lhs >= rhs.y);
		}

		// Token: 0x06001EB9 RID: 7865 RVA: 0x00058E9C File Offset: 0x0005709C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator -(uint2 val)
		{
			return new uint2((uint)(-(uint)((ulong)val.x)), (uint)(-(uint)((ulong)val.y)));
		}

		// Token: 0x06001EBA RID: 7866 RVA: 0x00058EB5 File Offset: 0x000570B5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator +(uint2 val)
		{
			return new uint2(val.x, val.y);
		}

		// Token: 0x06001EBB RID: 7867 RVA: 0x00058EC8 File Offset: 0x000570C8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator <<(uint2 x, int n)
		{
			return new uint2(x.x << n, x.y << n);
		}

		// Token: 0x06001EBC RID: 7868 RVA: 0x00058EE5 File Offset: 0x000570E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator >>(uint2 x, int n)
		{
			return new uint2(x.x >> n, x.y >> n);
		}

		// Token: 0x06001EBD RID: 7869 RVA: 0x00058F02 File Offset: 0x00057102
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(uint2 lhs, uint2 rhs)
		{
			return new bool2(lhs.x == rhs.x, lhs.y == rhs.y);
		}

		// Token: 0x06001EBE RID: 7870 RVA: 0x00058F25 File Offset: 0x00057125
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(uint2 lhs, uint rhs)
		{
			return new bool2(lhs.x == rhs, lhs.y == rhs);
		}

		// Token: 0x06001EBF RID: 7871 RVA: 0x00058F3E File Offset: 0x0005713E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(uint lhs, uint2 rhs)
		{
			return new bool2(lhs == rhs.x, lhs == rhs.y);
		}

		// Token: 0x06001EC0 RID: 7872 RVA: 0x00058F57 File Offset: 0x00057157
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(uint2 lhs, uint2 rhs)
		{
			return new bool2(lhs.x != rhs.x, lhs.y != rhs.y);
		}

		// Token: 0x06001EC1 RID: 7873 RVA: 0x00058F80 File Offset: 0x00057180
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(uint2 lhs, uint rhs)
		{
			return new bool2(lhs.x != rhs, lhs.y != rhs);
		}

		// Token: 0x06001EC2 RID: 7874 RVA: 0x00058F9F File Offset: 0x0005719F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(uint lhs, uint2 rhs)
		{
			return new bool2(lhs != rhs.x, lhs != rhs.y);
		}

		// Token: 0x06001EC3 RID: 7875 RVA: 0x00058FBE File Offset: 0x000571BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator ~(uint2 val)
		{
			return new uint2(~val.x, ~val.y);
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x00058FD3 File Offset: 0x000571D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator &(uint2 lhs, uint2 rhs)
		{
			return new uint2(lhs.x & rhs.x, lhs.y & rhs.y);
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x00058FF4 File Offset: 0x000571F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator &(uint2 lhs, uint rhs)
		{
			return new uint2(lhs.x & rhs, lhs.y & rhs);
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0005900B File Offset: 0x0005720B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator &(uint lhs, uint2 rhs)
		{
			return new uint2(lhs & rhs.x, lhs & rhs.y);
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x00059022 File Offset: 0x00057222
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator |(uint2 lhs, uint2 rhs)
		{
			return new uint2(lhs.x | rhs.x, lhs.y | rhs.y);
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x00059043 File Offset: 0x00057243
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator |(uint2 lhs, uint rhs)
		{
			return new uint2(lhs.x | rhs, lhs.y | rhs);
		}

		// Token: 0x06001EC9 RID: 7881 RVA: 0x0005905A File Offset: 0x0005725A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator |(uint lhs, uint2 rhs)
		{
			return new uint2(lhs | rhs.x, lhs | rhs.y);
		}

		// Token: 0x06001ECA RID: 7882 RVA: 0x00059071 File Offset: 0x00057271
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator ^(uint2 lhs, uint2 rhs)
		{
			return new uint2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);
		}

		// Token: 0x06001ECB RID: 7883 RVA: 0x00059092 File Offset: 0x00057292
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator ^(uint2 lhs, uint rhs)
		{
			return new uint2(lhs.x ^ rhs, lhs.y ^ rhs);
		}

		// Token: 0x06001ECC RID: 7884 RVA: 0x000590A9 File Offset: 0x000572A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 operator ^(uint lhs, uint2 rhs)
		{
			return new uint2(lhs ^ rhs.x, lhs ^ rhs.y);
		}

		// Token: 0x1700099D RID: 2461
		// (get) Token: 0x06001ECD RID: 7885 RVA: 0x000590C0 File Offset: 0x000572C0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x1700099E RID: 2462
		// (get) Token: 0x06001ECE RID: 7886 RVA: 0x000590DF File Offset: 0x000572DF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x1700099F RID: 2463
		// (get) Token: 0x06001ECF RID: 7887 RVA: 0x000590FE File Offset: 0x000572FE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x170009A0 RID: 2464
		// (get) Token: 0x06001ED0 RID: 7888 RVA: 0x0005911D File Offset: 0x0005731D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x170009A1 RID: 2465
		// (get) Token: 0x06001ED1 RID: 7889 RVA: 0x0005913C File Offset: 0x0005733C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x170009A2 RID: 2466
		// (get) Token: 0x06001ED2 RID: 7890 RVA: 0x0005915B File Offset: 0x0005735B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x170009A3 RID: 2467
		// (get) Token: 0x06001ED3 RID: 7891 RVA: 0x0005917A File Offset: 0x0005737A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x170009A4 RID: 2468
		// (get) Token: 0x06001ED4 RID: 7892 RVA: 0x00059199 File Offset: 0x00057399
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x170009A5 RID: 2469
		// (get) Token: 0x06001ED5 RID: 7893 RVA: 0x000591B8 File Offset: 0x000573B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x170009A6 RID: 2470
		// (get) Token: 0x06001ED6 RID: 7894 RVA: 0x000591D7 File Offset: 0x000573D7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x170009A7 RID: 2471
		// (get) Token: 0x06001ED7 RID: 7895 RVA: 0x000591F6 File Offset: 0x000573F6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x170009A8 RID: 2472
		// (get) Token: 0x06001ED8 RID: 7896 RVA: 0x00059215 File Offset: 0x00057415
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x170009A9 RID: 2473
		// (get) Token: 0x06001ED9 RID: 7897 RVA: 0x00059234 File Offset: 0x00057434
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x170009AA RID: 2474
		// (get) Token: 0x06001EDA RID: 7898 RVA: 0x00059253 File Offset: 0x00057453
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x170009AB RID: 2475
		// (get) Token: 0x06001EDB RID: 7899 RVA: 0x00059272 File Offset: 0x00057472
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x170009AC RID: 2476
		// (get) Token: 0x06001EDC RID: 7900 RVA: 0x00059291 File Offset: 0x00057491
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x170009AD RID: 2477
		// (get) Token: 0x06001EDD RID: 7901 RVA: 0x000592B0 File Offset: 0x000574B0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint3(this.x, this.x, this.x);
			}
		}

		// Token: 0x170009AE RID: 2478
		// (get) Token: 0x06001EDE RID: 7902 RVA: 0x000592C9 File Offset: 0x000574C9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint3(this.x, this.x, this.y);
			}
		}

		// Token: 0x170009AF RID: 2479
		// (get) Token: 0x06001EDF RID: 7903 RVA: 0x000592E2 File Offset: 0x000574E2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint3(this.x, this.y, this.x);
			}
		}

		// Token: 0x170009B0 RID: 2480
		// (get) Token: 0x06001EE0 RID: 7904 RVA: 0x000592FB File Offset: 0x000574FB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint3(this.x, this.y, this.y);
			}
		}

		// Token: 0x170009B1 RID: 2481
		// (get) Token: 0x06001EE1 RID: 7905 RVA: 0x00059314 File Offset: 0x00057514
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint3(this.y, this.x, this.x);
			}
		}

		// Token: 0x170009B2 RID: 2482
		// (get) Token: 0x06001EE2 RID: 7906 RVA: 0x0005932D File Offset: 0x0005752D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint3(this.y, this.x, this.y);
			}
		}

		// Token: 0x170009B3 RID: 2483
		// (get) Token: 0x06001EE3 RID: 7907 RVA: 0x00059346 File Offset: 0x00057546
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint3(this.y, this.y, this.x);
			}
		}

		// Token: 0x170009B4 RID: 2484
		// (get) Token: 0x06001EE4 RID: 7908 RVA: 0x0005935F File Offset: 0x0005755F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint3(this.y, this.y, this.y);
			}
		}

		// Token: 0x170009B5 RID: 2485
		// (get) Token: 0x06001EE5 RID: 7909 RVA: 0x00059378 File Offset: 0x00057578
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint2(this.x, this.x);
			}
		}

		// Token: 0x170009B6 RID: 2486
		// (get) Token: 0x06001EE6 RID: 7910 RVA: 0x0005938B File Offset: 0x0005758B
		// (set) Token: 0x06001EE7 RID: 7911 RVA: 0x0005939E File Offset: 0x0005759E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint2(this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x170009B7 RID: 2487
		// (get) Token: 0x06001EE8 RID: 7912 RVA: 0x000593B8 File Offset: 0x000575B8
		// (set) Token: 0x06001EE9 RID: 7913 RVA: 0x000593CB File Offset: 0x000575CB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint2(this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x170009B8 RID: 2488
		// (get) Token: 0x06001EEA RID: 7914 RVA: 0x000593E5 File Offset: 0x000575E5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new uint2(this.y, this.y);
			}
		}

		// Token: 0x170009B9 RID: 2489
		public unsafe uint this[int index]
		{
			get
			{
				fixed (uint2* ptr = &this)
				{
					return ((uint*)ptr)[index];
				}
			}
			set
			{
				fixed (uint* ptr = &this.x)
				{
					ptr[index] = value;
				}
			}
		}

		// Token: 0x06001EED RID: 7917 RVA: 0x00059430 File Offset: 0x00057630
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(uint2 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y;
		}

		// Token: 0x06001EEE RID: 7918 RVA: 0x00059450 File Offset: 0x00057650
		public override bool Equals(object o)
		{
			if (o is uint2)
			{
				uint2 rhs = (uint2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001EEF RID: 7919 RVA: 0x00059475 File Offset: 0x00057675
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06001EF0 RID: 7920 RVA: 0x00059482 File Offset: 0x00057682
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("uint2({0}, {1})", this.x, this.y);
		}

		// Token: 0x06001EF1 RID: 7921 RVA: 0x000594A4 File Offset: 0x000576A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("uint2({0}, {1})", this.x.ToString(format, formatProvider), this.y.ToString(format, formatProvider));
		}

		// Token: 0x040000E8 RID: 232
		public uint x;

		// Token: 0x040000E9 RID: 233
		public uint y;

		// Token: 0x040000EA RID: 234
		public static readonly uint2 zero;

		// Token: 0x02000063 RID: 99
		internal sealed class DebuggerProxy
		{
			// Token: 0x06002478 RID: 9336 RVA: 0x0006778C File Offset: 0x0006598C
			public DebuggerProxy(uint2 v)
			{
				this.x = v.x;
				this.y = v.y;
			}

			// Token: 0x04000167 RID: 359
			public uint x;

			// Token: 0x04000168 RID: 360
			public uint y;
		}
	}
}
