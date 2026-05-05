using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000009 RID: 9
	[DebuggerTypeProxy(typeof(bool3.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct bool3 : IEquatable<bool3>
	{
		// Token: 0x060007FB RID: 2043 RVA: 0x0001BB15 File Offset: 0x00019D15
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3(bool x, bool y, bool z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0001BB2C File Offset: 0x00019D2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3(bool x, bool2 yz)
		{
			this.x = x;
			this.y = yz.x;
			this.z = yz.y;
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0001BB4D File Offset: 0x00019D4D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3(bool2 xy, bool z)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = z;
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0001BB6E File Offset: 0x00019D6E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3(bool3 xyz)
		{
			this.x = xyz.x;
			this.y = xyz.y;
			this.z = xyz.z;
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0001BB94 File Offset: 0x00019D94
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3(bool v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0001BBAB File Offset: 0x00019DAB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool3(bool v)
		{
			return new bool3(v);
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0001BBB3 File Offset: 0x00019DB3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(bool3 lhs, bool3 rhs)
		{
			return new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0001BBE4 File Offset: 0x00019DE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(bool3 lhs, bool rhs)
		{
			return new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0001BC06 File Offset: 0x00019E06
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ==(bool lhs, bool3 rhs)
		{
			return new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0001BC28 File Offset: 0x00019E28
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(bool3 lhs, bool3 rhs)
		{
			return new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x0001BC62 File Offset: 0x00019E62
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(bool3 lhs, bool rhs)
		{
			return new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0001BC8D File Offset: 0x00019E8D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !=(bool lhs, bool3 rhs)
		{
			return new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0001BCB8 File Offset: 0x00019EB8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator !(bool3 val)
		{
			return new bool3(!val.x, !val.y, !val.z);
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0001BCDA File Offset: 0x00019EDA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator &(bool3 lhs, bool3 rhs)
		{
			return new bool3(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z);
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0001BD08 File Offset: 0x00019F08
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator &(bool3 lhs, bool rhs)
		{
			return new bool3(lhs.x && rhs, lhs.y && rhs, lhs.z && rhs);
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x0001BD27 File Offset: 0x00019F27
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator &(bool lhs, bool3 rhs)
		{
			return new bool3(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z);
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x0001BD46 File Offset: 0x00019F46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator |(bool3 lhs, bool3 rhs)
		{
			return new bool3(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z);
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0001BD74 File Offset: 0x00019F74
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator |(bool3 lhs, bool rhs)
		{
			return new bool3(lhs.x || rhs, lhs.y || rhs, lhs.z || rhs);
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x0001BD93 File Offset: 0x00019F93
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator |(bool lhs, bool3 rhs)
		{
			return new bool3(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0001BDB2 File Offset: 0x00019FB2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ^(bool3 lhs, bool3 rhs)
		{
			return new bool3(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z);
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0001BDE0 File Offset: 0x00019FE0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ^(bool3 lhs, bool rhs)
		{
			return new bool3(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs);
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0001BDFF File Offset: 0x00019FFF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3 operator ^(bool lhs, bool3 rhs)
		{
			return new bool3(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z);
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x0001BE1E File Offset: 0x0001A01E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x0001BE3D File Offset: 0x0001A03D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x0001BE5C File Offset: 0x0001A05C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.x, this.z);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x0001BE7B File Offset: 0x0001A07B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000815 RID: 2069 RVA: 0x0001BE9A File Offset: 0x0001A09A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x0001BEB9 File Offset: 0x0001A0B9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.y, this.z);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x0001BED8 File Offset: 0x0001A0D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x0001BEF7 File Offset: 0x0001A0F7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x0001BF16 File Offset: 0x0001A116
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.z, this.z);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x0001BF35 File Offset: 0x0001A135
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x0001BF54 File Offset: 0x0001A154
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600081C RID: 2076 RVA: 0x0001BF73 File Offset: 0x0001A173
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.x, this.z);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x0001BF92 File Offset: 0x0001A192
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x0001BFB1 File Offset: 0x0001A1B1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600081F RID: 2079 RVA: 0x0001BFD0 File Offset: 0x0001A1D0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x0001BFEF File Offset: 0x0001A1EF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x0001C00E File Offset: 0x0001A20E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x0001C02D File Offset: 0x0001A22D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000823 RID: 2083 RVA: 0x0001C04C File Offset: 0x0001A24C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.x, this.x);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000824 RID: 2084 RVA: 0x0001C06B File Offset: 0x0001A26B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000825 RID: 2085 RVA: 0x0001C08A File Offset: 0x0001A28A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000826 RID: 2086 RVA: 0x0001C0A9 File Offset: 0x0001A2A9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000827 RID: 2087 RVA: 0x0001C0C8 File Offset: 0x0001A2C8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000828 RID: 2088 RVA: 0x0001C0E7 File Offset: 0x0001A2E7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000829 RID: 2089 RVA: 0x0001C106 File Offset: 0x0001A306
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.z, this.x);
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x0001C125 File Offset: 0x0001A325
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.z, this.y);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600082B RID: 2091 RVA: 0x0001C144 File Offset: 0x0001A344
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.z, this.z);
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600082C RID: 2092 RVA: 0x0001C163 File Offset: 0x0001A363
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x0001C182 File Offset: 0x0001A382
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x0001C1A1 File Offset: 0x0001A3A1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.x, this.z);
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x0001C1C0 File Offset: 0x0001A3C0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x0001C1DF File Offset: 0x0001A3DF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x0001C1FE File Offset: 0x0001A3FE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.y, this.z);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x0001C21D File Offset: 0x0001A41D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x0001C23C File Offset: 0x0001A43C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x0001C25B File Offset: 0x0001A45B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000835 RID: 2101 RVA: 0x0001C27A File Offset: 0x0001A47A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x0001C299 File Offset: 0x0001A499
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x0001C2B8 File Offset: 0x0001A4B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0001C2D7 File Offset: 0x0001A4D7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x0001C2F6 File Offset: 0x0001A4F6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x0001C315 File Offset: 0x0001A515
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.y, this.z);
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x0001C334 File Offset: 0x0001A534
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.z, this.x);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x0001C353 File Offset: 0x0001A553
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.z, this.y);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x0001C372 File Offset: 0x0001A572
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.z, this.z);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0001C391 File Offset: 0x0001A591
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.x, this.x);
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x0001C3B0 File Offset: 0x0001A5B0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.x, this.y);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0001C3CF File Offset: 0x0001A5CF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.x, this.z);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x0001C3EE File Offset: 0x0001A5EE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.y, this.x);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x0001C40D File Offset: 0x0001A60D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x0001C42C File Offset: 0x0001A62C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x0001C44B File Offset: 0x0001A64B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x0001C46A File Offset: 0x0001A66A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0001C489 File Offset: 0x0001A689
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000847 RID: 2119 RVA: 0x0001C4A8 File Offset: 0x0001A6A8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x0001C4C7 File Offset: 0x0001A6C7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x0001C4E6 File Offset: 0x0001A6E6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.x, this.z);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x0001C505 File Offset: 0x0001A705
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x0001C524 File Offset: 0x0001A724
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.y, this.y);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x0001C543 File Offset: 0x0001A743
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.y, this.z);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0001C562 File Offset: 0x0001A762
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.z, this.x);
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x0001C581 File Offset: 0x0001A781
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.z, this.y);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x0001C5A0 File Offset: 0x0001A7A0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x0001C5BF File Offset: 0x0001A7BF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x0001C5DE File Offset: 0x0001A7DE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x0001C5FD File Offset: 0x0001A7FD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.x, this.z);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000853 RID: 2131 RVA: 0x0001C61C File Offset: 0x0001A81C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x0001C63B File Offset: 0x0001A83B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000855 RID: 2133 RVA: 0x0001C65A File Offset: 0x0001A85A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x0001C679 File Offset: 0x0001A879
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x0001C698 File Offset: 0x0001A898
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000858 RID: 2136 RVA: 0x0001C6B7 File Offset: 0x0001A8B7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x0001C6D6 File Offset: 0x0001A8D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.x, this.x);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600085A RID: 2138 RVA: 0x0001C6F5 File Offset: 0x0001A8F5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.x, this.y);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x0001C714 File Offset: 0x0001A914
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.x, this.z);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x0001C733 File Offset: 0x0001A933
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.y, this.x);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x0001C752 File Offset: 0x0001A952
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.y, this.y);
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600085E RID: 2142 RVA: 0x0001C771 File Offset: 0x0001A971
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.y, this.z);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x0001C790 File Offset: 0x0001A990
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000860 RID: 2144 RVA: 0x0001C7AF File Offset: 0x0001A9AF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x0001C7CE File Offset: 0x0001A9CE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x0001C7ED File Offset: 0x0001A9ED
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.x, this.x);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000863 RID: 2147 RVA: 0x0001C806 File Offset: 0x0001AA06
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.x, this.y);
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x0001C81F File Offset: 0x0001AA1F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.x, this.z);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000865 RID: 2149 RVA: 0x0001C838 File Offset: 0x0001AA38
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.y, this.x);
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x0001C851 File Offset: 0x0001AA51
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.y, this.y);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x0001C86A File Offset: 0x0001AA6A
		// (set) Token: 0x06000868 RID: 2152 RVA: 0x0001C883 File Offset: 0x0001AA83
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x0001C8A9 File Offset: 0x0001AAA9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.z, this.x);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x0001C8C2 File Offset: 0x0001AAC2
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x0001C8DB File Offset: 0x0001AADB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x0001C901 File Offset: 0x0001AB01
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.z, this.z);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x0001C91A File Offset: 0x0001AB1A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.x, this.x);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600086E RID: 2158 RVA: 0x0001C933 File Offset: 0x0001AB33
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.x, this.y);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600086F RID: 2159 RVA: 0x0001C94C File Offset: 0x0001AB4C
		// (set) Token: 0x06000870 RID: 2160 RVA: 0x0001C965 File Offset: 0x0001AB65
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x0001C98B File Offset: 0x0001AB8B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.y, this.x);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x0001C9A4 File Offset: 0x0001ABA4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.y, this.y);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x0001C9BD File Offset: 0x0001ABBD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.y, this.z);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x0001C9D6 File Offset: 0x0001ABD6
		// (set) Token: 0x06000875 RID: 2165 RVA: 0x0001C9EF File Offset: 0x0001ABEF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x0001CA15 File Offset: 0x0001AC15
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.z, this.y);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000877 RID: 2167 RVA: 0x0001CA2E File Offset: 0x0001AC2E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.z, this.z);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x0001CA47 File Offset: 0x0001AC47
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.x, this.x);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000879 RID: 2169 RVA: 0x0001CA60 File Offset: 0x0001AC60
		// (set) Token: 0x0600087A RID: 2170 RVA: 0x0001CA79 File Offset: 0x0001AC79
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600087B RID: 2171 RVA: 0x0001CA9F File Offset: 0x0001AC9F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.x, this.z);
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x0001CAB8 File Offset: 0x0001ACB8
		// (set) Token: 0x0600087D RID: 2173 RVA: 0x0001CAD1 File Offset: 0x0001ACD1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x0001CAF7 File Offset: 0x0001ACF7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.y, this.y);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600087F RID: 2175 RVA: 0x0001CB10 File Offset: 0x0001AD10
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.y, this.z);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x0001CB29 File Offset: 0x0001AD29
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.z, this.x);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000881 RID: 2177 RVA: 0x0001CB42 File Offset: 0x0001AD42
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.z, this.y);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x0001CB5B File Offset: 0x0001AD5B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.z, this.z);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000883 RID: 2179 RVA: 0x0001CB74 File Offset: 0x0001AD74
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.x, this.x);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x0001CB87 File Offset: 0x0001AD87
		// (set) Token: 0x06000885 RID: 2181 RVA: 0x0001CB9A File Offset: 0x0001AD9A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000886 RID: 2182 RVA: 0x0001CBB4 File Offset: 0x0001ADB4
		// (set) Token: 0x06000887 RID: 2183 RVA: 0x0001CBC7 File Offset: 0x0001ADC7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 xz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x0001CBE1 File Offset: 0x0001ADE1
		// (set) Token: 0x06000889 RID: 2185 RVA: 0x0001CBF4 File Offset: 0x0001ADF4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x0001CC0E File Offset: 0x0001AE0E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.y, this.y);
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x0001CC21 File Offset: 0x0001AE21
		// (set) Token: 0x0600088C RID: 2188 RVA: 0x0001CC34 File Offset: 0x0001AE34
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 yz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600088D RID: 2189 RVA: 0x0001CC4E File Offset: 0x0001AE4E
		// (set) Token: 0x0600088E RID: 2190 RVA: 0x0001CC61 File Offset: 0x0001AE61
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 zx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600088F RID: 2191 RVA: 0x0001CC7B File Offset: 0x0001AE7B
		// (set) Token: 0x06000890 RID: 2192 RVA: 0x0001CC8E File Offset: 0x0001AE8E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 zy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000891 RID: 2193 RVA: 0x0001CCA8 File Offset: 0x0001AEA8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.z, this.z);
			}
		}

		// Token: 0x17000096 RID: 150
		public unsafe bool this[int index]
		{
			get
			{
				fixed (bool3* ptr = &this)
				{
					return ((byte*)ptr)[index] != 0;
				}
			}
			set
			{
				fixed (bool* ptr = &this.x)
				{
					ptr[index] = value;
				}
			}
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0001CCED File Offset: 0x0001AEED
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(bool3 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y && this.z == rhs.z;
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0001CD1C File Offset: 0x0001AF1C
		public override bool Equals(object o)
		{
			if (o is bool3)
			{
				bool3 rhs = (bool3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0001CD41 File Offset: 0x0001AF41
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0001CD4E File Offset: 0x0001AF4E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("bool3({0}, {1}, {2})", this.x, this.y, this.z);
		}

		// Token: 0x04000022 RID: 34
		[MarshalAs(UnmanagedType.U1)]
		public bool x;

		// Token: 0x04000023 RID: 35
		[MarshalAs(UnmanagedType.U1)]
		public bool y;

		// Token: 0x04000024 RID: 36
		[MarshalAs(UnmanagedType.U1)]
		public bool z;

		// Token: 0x02000055 RID: 85
		internal sealed class DebuggerProxy
		{
			// Token: 0x0600246A RID: 9322 RVA: 0x00067518 File Offset: 0x00065718
			public DebuggerProxy(bool3 v)
			{
				this.x = v.x;
				this.y = v.y;
				this.z = v.z;
			}

			// Token: 0x0400013C RID: 316
			public bool x;

			// Token: 0x0400013D RID: 317
			public bool y;

			// Token: 0x0400013E RID: 318
			public bool z;
		}
	}
}
