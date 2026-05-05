using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200000D RID: 13
	[DebuggerTypeProxy(typeof(bool4.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct bool4 : IEquatable<bool4>
	{
		// Token: 0x060008E3 RID: 2275 RVA: 0x0001DC1D File Offset: 0x0001BE1D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4(bool x, bool y, bool z, bool w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x0001DC3C File Offset: 0x0001BE3C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4(bool x, bool y, bool2 zw)
		{
			this.x = x;
			this.y = y;
			this.z = zw.x;
			this.w = zw.y;
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0001DC64 File Offset: 0x0001BE64
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4(bool x, bool2 yz, bool w)
		{
			this.x = x;
			this.y = yz.x;
			this.z = yz.y;
			this.w = w;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x0001DC8C File Offset: 0x0001BE8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4(bool x, bool3 yzw)
		{
			this.x = x;
			this.y = yzw.x;
			this.z = yzw.y;
			this.w = yzw.z;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0001DCB9 File Offset: 0x0001BEB9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4(bool2 xy, bool z, bool w)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = z;
			this.w = w;
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0001DCE1 File Offset: 0x0001BEE1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4(bool2 xy, bool2 zw)
		{
			this.x = xy.x;
			this.y = xy.y;
			this.z = zw.x;
			this.w = zw.y;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0001DD13 File Offset: 0x0001BF13
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4(bool3 xyz, bool w)
		{
			this.x = xyz.x;
			this.y = xyz.y;
			this.z = xyz.z;
			this.w = w;
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0001DD40 File Offset: 0x0001BF40
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4(bool4 xyzw)
		{
			this.x = xyzw.x;
			this.y = xyzw.y;
			this.z = xyzw.z;
			this.w = xyzw.w;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x0001DD72 File Offset: 0x0001BF72
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4(bool v)
		{
			this.x = v;
			this.y = v;
			this.z = v;
			this.w = v;
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0001DD90 File Offset: 0x0001BF90
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool4(bool v)
		{
			return new bool4(v);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0001DD98 File Offset: 0x0001BF98
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(bool4 lhs, bool4 rhs)
		{
			return new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0001DDD7 File Offset: 0x0001BFD7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(bool4 lhs, bool rhs)
		{
			return new bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0001DE02 File Offset: 0x0001C002
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ==(bool lhs, bool4 rhs)
		{
			return new bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0001DE30 File Offset: 0x0001C030
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(bool4 lhs, bool4 rhs)
		{
			return new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0001DE86 File Offset: 0x0001C086
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(bool4 lhs, bool rhs)
		{
			return new bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0001DEBD File Offset: 0x0001C0BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !=(bool lhs, bool4 rhs)
		{
			return new bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0001DEF4 File Offset: 0x0001C0F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator !(bool4 val)
		{
			return new bool4(!val.x, !val.y, !val.z, !val.w);
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x0001DF1F File Offset: 0x0001C11F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator &(bool4 lhs, bool4 rhs)
		{
			return new bool4(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z, lhs.w & rhs.w);
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0001DF5A File Offset: 0x0001C15A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator &(bool4 lhs, bool rhs)
		{
			return new bool4(lhs.x && rhs, lhs.y && rhs, lhs.z && rhs, lhs.w && rhs);
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x0001DF81 File Offset: 0x0001C181
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator &(bool lhs, bool4 rhs)
		{
			return new bool4(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z, lhs & rhs.w);
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0001DFA8 File Offset: 0x0001C1A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator |(bool4 lhs, bool4 rhs)
		{
			return new bool4(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w);
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0001DFE3 File Offset: 0x0001C1E3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator |(bool4 lhs, bool rhs)
		{
			return new bool4(lhs.x || rhs, lhs.y || rhs, lhs.z || rhs, lhs.w || rhs);
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x0001E00A File Offset: 0x0001C20A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator |(bool lhs, bool4 rhs)
		{
			return new bool4(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z, lhs | rhs.w);
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0001E031 File Offset: 0x0001C231
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ^(bool4 lhs, bool4 rhs)
		{
			return new bool4(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z, lhs.w ^ rhs.w);
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x0001E06C File Offset: 0x0001C26C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ^(bool4 lhs, bool rhs)
		{
			return new bool4(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs, lhs.w ^ rhs);
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x0001E093 File Offset: 0x0001C293
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator ^(bool lhs, bool4 rhs)
		{
			return new bool4(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z, lhs ^ rhs.w);
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x0001E0BA File Offset: 0x0001C2BA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x0001E0D9 File Offset: 0x0001C2D9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060008FF RID: 2303 RVA: 0x0001E0F8 File Offset: 0x0001C2F8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.x, this.z);
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x0001E117 File Offset: 0x0001C317
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.x, this.w);
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000901 RID: 2305 RVA: 0x0001E136 File Offset: 0x0001C336
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x0001E155 File Offset: 0x0001C355
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000903 RID: 2307 RVA: 0x0001E174 File Offset: 0x0001C374
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.y, this.z);
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x0001E193 File Offset: 0x0001C393
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.y, this.w);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x0001E1B2 File Offset: 0x0001C3B2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.z, this.x);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0001E1D1 File Offset: 0x0001C3D1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.z, this.y);
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x0001E1F0 File Offset: 0x0001C3F0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.z, this.z);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x0001E20F File Offset: 0x0001C40F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.z, this.w);
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x0001E22E File Offset: 0x0001C42E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.w, this.x);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x0001E24D File Offset: 0x0001C44D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.w, this.y);
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600090B RID: 2315 RVA: 0x0001E26C File Offset: 0x0001C46C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.w, this.z);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600090C RID: 2316 RVA: 0x0001E28B File Offset: 0x0001C48B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.w, this.w);
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600090D RID: 2317 RVA: 0x0001E2AA File Offset: 0x0001C4AA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x0001E2C9 File Offset: 0x0001C4C9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x0001E2E8 File Offset: 0x0001C4E8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.x, this.z);
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x0001E307 File Offset: 0x0001C507
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.x, this.w);
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x0001E326 File Offset: 0x0001C526
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x0001E345 File Offset: 0x0001C545
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x0001E364 File Offset: 0x0001C564
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.y, this.z);
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x0001E383 File Offset: 0x0001C583
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.y, this.w);
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000915 RID: 2325 RVA: 0x0001E3A2 File Offset: 0x0001C5A2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.z, this.x);
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x0001E3C1 File Offset: 0x0001C5C1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.z, this.y);
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x0001E3E0 File Offset: 0x0001C5E0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.z, this.z);
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x0001E3FF File Offset: 0x0001C5FF
		// (set) Token: 0x06000919 RID: 2329 RVA: 0x0001E41E File Offset: 0x0001C61E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x0001E450 File Offset: 0x0001C650
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.w, this.x);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x0001E46F File Offset: 0x0001C66F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.w, this.y);
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600091C RID: 2332 RVA: 0x0001E48E File Offset: 0x0001C68E
		// (set) Token: 0x0600091D RID: 2333 RVA: 0x0001E4AD File Offset: 0x0001C6AD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.w = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600091E RID: 2334 RVA: 0x0001E4DF File Offset: 0x0001C6DF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.w, this.w);
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x0001E4FE File Offset: 0x0001C6FE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.x, this.x);
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000920 RID: 2336 RVA: 0x0001E51D File Offset: 0x0001C71D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.x, this.y);
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000921 RID: 2337 RVA: 0x0001E53C File Offset: 0x0001C73C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.x, this.z);
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000922 RID: 2338 RVA: 0x0001E55B File Offset: 0x0001C75B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.x, this.w);
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x0001E57A File Offset: 0x0001C77A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.y, this.x);
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000924 RID: 2340 RVA: 0x0001E599 File Offset: 0x0001C799
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.y, this.y);
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x0001E5B8 File Offset: 0x0001C7B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.y, this.z);
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000926 RID: 2342 RVA: 0x0001E5D7 File Offset: 0x0001C7D7
		// (set) Token: 0x06000927 RID: 2343 RVA: 0x0001E5F6 File Offset: 0x0001C7F6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.y = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000928 RID: 2344 RVA: 0x0001E628 File Offset: 0x0001C828
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.z, this.x);
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x0001E647 File Offset: 0x0001C847
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.z, this.y);
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600092A RID: 2346 RVA: 0x0001E666 File Offset: 0x0001C866
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.z, this.z);
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x0001E685 File Offset: 0x0001C885
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.z, this.w);
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600092C RID: 2348 RVA: 0x0001E6A4 File Offset: 0x0001C8A4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.w, this.x);
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x0001E6C3 File Offset: 0x0001C8C3
		// (set) Token: 0x0600092E RID: 2350 RVA: 0x0001E6E2 File Offset: 0x0001C8E2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.w = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x0001E714 File Offset: 0x0001C914
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.w, this.z);
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000930 RID: 2352 RVA: 0x0001E733 File Offset: 0x0001C933
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.z, this.w, this.w);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000931 RID: 2353 RVA: 0x0001E752 File Offset: 0x0001C952
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.x, this.x);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000932 RID: 2354 RVA: 0x0001E771 File Offset: 0x0001C971
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.x, this.y);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000933 RID: 2355 RVA: 0x0001E790 File Offset: 0x0001C990
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.x, this.z);
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000934 RID: 2356 RVA: 0x0001E7AF File Offset: 0x0001C9AF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.x, this.w);
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000935 RID: 2357 RVA: 0x0001E7CE File Offset: 0x0001C9CE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.y, this.x);
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000936 RID: 2358 RVA: 0x0001E7ED File Offset: 0x0001C9ED
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.y, this.y);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x0001E80C File Offset: 0x0001CA0C
		// (set) Token: 0x06000938 RID: 2360 RVA: 0x0001E82B File Offset: 0x0001CA2B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.y = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000939 RID: 2361 RVA: 0x0001E85D File Offset: 0x0001CA5D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.y, this.w);
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x0001E87C File Offset: 0x0001CA7C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.z, this.x);
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x0001E89B File Offset: 0x0001CA9B
		// (set) Token: 0x0600093C RID: 2364 RVA: 0x0001E8BA File Offset: 0x0001CABA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.z = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x0001E8EC File Offset: 0x0001CAEC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.z, this.z);
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x0001E90B File Offset: 0x0001CB0B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.z, this.w);
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x0001E92A File Offset: 0x0001CB2A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.w, this.x);
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x0001E949 File Offset: 0x0001CB49
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.w, this.y);
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x0001E968 File Offset: 0x0001CB68
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.w, this.z);
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x0001E987 File Offset: 0x0001CB87
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.w, this.w, this.w);
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000943 RID: 2371 RVA: 0x0001E9A6 File Offset: 0x0001CBA6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x0001E9C5 File Offset: 0x0001CBC5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000945 RID: 2373 RVA: 0x0001E9E4 File Offset: 0x0001CBE4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.x, this.z);
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x0001EA03 File Offset: 0x0001CC03
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.x, this.w);
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x0001EA22 File Offset: 0x0001CC22
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000948 RID: 2376 RVA: 0x0001EA41 File Offset: 0x0001CC41
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000949 RID: 2377 RVA: 0x0001EA60 File Offset: 0x0001CC60
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.y, this.z);
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x0001EA7F File Offset: 0x0001CC7F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.y, this.w);
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600094B RID: 2379 RVA: 0x0001EA9E File Offset: 0x0001CC9E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.z, this.x);
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x0001EABD File Offset: 0x0001CCBD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.z, this.y);
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600094D RID: 2381 RVA: 0x0001EADC File Offset: 0x0001CCDC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.z, this.z);
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x0001EAFB File Offset: 0x0001CCFB
		// (set) Token: 0x0600094F RID: 2383 RVA: 0x0001EB1A File Offset: 0x0001CD1A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.z = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x0001EB4C File Offset: 0x0001CD4C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.w, this.x);
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x0001EB6B File Offset: 0x0001CD6B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.w, this.y);
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x0001EB8A File Offset: 0x0001CD8A
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x0001EBA9 File Offset: 0x0001CDA9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.w = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x0001EBDB File Offset: 0x0001CDDB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.w, this.w);
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x0001EBFA File Offset: 0x0001CDFA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x0001EC19 File Offset: 0x0001CE19
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x0001EC38 File Offset: 0x0001CE38
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.x, this.z);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x0001EC57 File Offset: 0x0001CE57
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.x, this.w);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000959 RID: 2393 RVA: 0x0001EC76 File Offset: 0x0001CE76
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x0001EC95 File Offset: 0x0001CE95
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600095B RID: 2395 RVA: 0x0001ECB4 File Offset: 0x0001CEB4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.y, this.z);
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x0001ECD3 File Offset: 0x0001CED3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.y, this.w);
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600095D RID: 2397 RVA: 0x0001ECF2 File Offset: 0x0001CEF2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.z, this.x);
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600095E RID: 2398 RVA: 0x0001ED11 File Offset: 0x0001CF11
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.z, this.y);
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600095F RID: 2399 RVA: 0x0001ED30 File Offset: 0x0001CF30
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.z, this.z);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x0001ED4F File Offset: 0x0001CF4F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.z, this.w);
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000961 RID: 2401 RVA: 0x0001ED6E File Offset: 0x0001CF6E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.w, this.x);
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x0001ED8D File Offset: 0x0001CF8D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.w, this.y);
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000963 RID: 2403 RVA: 0x0001EDAC File Offset: 0x0001CFAC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.w, this.z);
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x0001EDCB File Offset: 0x0001CFCB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.w, this.w);
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000965 RID: 2405 RVA: 0x0001EDEA File Offset: 0x0001CFEA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.x, this.x);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x0001EE09 File Offset: 0x0001D009
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.x, this.y);
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000967 RID: 2407 RVA: 0x0001EE28 File Offset: 0x0001D028
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.x, this.z);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x0001EE47 File Offset: 0x0001D047
		// (set) Token: 0x06000969 RID: 2409 RVA: 0x0001EE66 File Offset: 0x0001D066
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.x = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x0001EE98 File Offset: 0x0001D098
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.y, this.x);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600096B RID: 2411 RVA: 0x0001EEB7 File Offset: 0x0001D0B7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x0001EED6 File Offset: 0x0001D0D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600096D RID: 2413 RVA: 0x0001EEF5 File Offset: 0x0001D0F5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.y, this.w);
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x0001EF14 File Offset: 0x0001D114
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600096F RID: 2415 RVA: 0x0001EF33 File Offset: 0x0001D133
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000970 RID: 2416 RVA: 0x0001EF52 File Offset: 0x0001D152
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000971 RID: 2417 RVA: 0x0001EF71 File Offset: 0x0001D171
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.z, this.w);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000972 RID: 2418 RVA: 0x0001EF90 File Offset: 0x0001D190
		// (set) Token: 0x06000973 RID: 2419 RVA: 0x0001EFAF File Offset: 0x0001D1AF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.w = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x0001EFE1 File Offset: 0x0001D1E1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.w, this.y);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000975 RID: 2421 RVA: 0x0001F000 File Offset: 0x0001D200
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.w, this.z);
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x0001F01F File Offset: 0x0001D21F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.z, this.w, this.w);
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000977 RID: 2423 RVA: 0x0001F03E File Offset: 0x0001D23E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.x, this.x);
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x0001F05D File Offset: 0x0001D25D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.x, this.y);
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000979 RID: 2425 RVA: 0x0001F07C File Offset: 0x0001D27C
		// (set) Token: 0x0600097A RID: 2426 RVA: 0x0001F09B File Offset: 0x0001D29B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.x = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600097B RID: 2427 RVA: 0x0001F0CD File Offset: 0x0001D2CD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.x, this.w);
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x0001F0EC File Offset: 0x0001D2EC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.y, this.x);
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600097D RID: 2429 RVA: 0x0001F10B File Offset: 0x0001D30B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.y, this.y);
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x0001F12A File Offset: 0x0001D32A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.y, this.z);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600097F RID: 2431 RVA: 0x0001F149 File Offset: 0x0001D349
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.y, this.w);
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x0001F168 File Offset: 0x0001D368
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x0001F187 File Offset: 0x0001D387
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.z = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x0001F1B9 File Offset: 0x0001D3B9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.z, this.y);
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000983 RID: 2435 RVA: 0x0001F1D8 File Offset: 0x0001D3D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.z, this.z);
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x0001F1F7 File Offset: 0x0001D3F7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.z, this.w);
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000985 RID: 2437 RVA: 0x0001F216 File Offset: 0x0001D416
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.w, this.x);
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x0001F235 File Offset: 0x0001D435
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.w, this.y);
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000987 RID: 2439 RVA: 0x0001F254 File Offset: 0x0001D454
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.w, this.z);
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x0001F273 File Offset: 0x0001D473
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 ywww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.w, this.w, this.w);
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000989 RID: 2441 RVA: 0x0001F292 File Offset: 0x0001D492
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.x, this.x);
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x0001F2B1 File Offset: 0x0001D4B1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.x, this.y);
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600098B RID: 2443 RVA: 0x0001F2D0 File Offset: 0x0001D4D0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.x, this.z);
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x0001F2EF File Offset: 0x0001D4EF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.x, this.w);
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600098D RID: 2445 RVA: 0x0001F30E File Offset: 0x0001D50E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x0001F32D File Offset: 0x0001D52D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600098F RID: 2447 RVA: 0x0001F34C File Offset: 0x0001D54C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.y, this.z);
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000990 RID: 2448 RVA: 0x0001F36B File Offset: 0x0001D56B
		// (set) Token: 0x06000991 RID: 2449 RVA: 0x0001F38A File Offset: 0x0001D58A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.y = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x0001F3BC File Offset: 0x0001D5BC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000993 RID: 2451 RVA: 0x0001F3DB File Offset: 0x0001D5DB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.z, this.y);
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x0001F3FA File Offset: 0x0001D5FA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000995 RID: 2453 RVA: 0x0001F419 File Offset: 0x0001D619
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.z, this.w);
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x0001F438 File Offset: 0x0001D638
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.w, this.x);
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000997 RID: 2455 RVA: 0x0001F457 File Offset: 0x0001D657
		// (set) Token: 0x06000998 RID: 2456 RVA: 0x0001F476 File Offset: 0x0001D676
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.w = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000999 RID: 2457 RVA: 0x0001F4A8 File Offset: 0x0001D6A8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.w, this.z);
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x0001F4C7 File Offset: 0x0001D6C7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.x, this.w, this.w);
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600099B RID: 2459 RVA: 0x0001F4E6 File Offset: 0x0001D6E6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.x, this.x);
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x0001F505 File Offset: 0x0001D705
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.x, this.y);
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600099D RID: 2461 RVA: 0x0001F524 File Offset: 0x0001D724
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.x, this.z);
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x0001F543 File Offset: 0x0001D743
		// (set) Token: 0x0600099F RID: 2463 RVA: 0x0001F562 File Offset: 0x0001D762
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.x = value.z;
				this.w = value.w;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x0001F594 File Offset: 0x0001D794
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.y, this.x);
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x0001F5B3 File Offset: 0x0001D7B3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x0001F5D2 File Offset: 0x0001D7D2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060009A3 RID: 2467 RVA: 0x0001F5F1 File Offset: 0x0001D7F1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.y, this.w);
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060009A4 RID: 2468 RVA: 0x0001F610 File Offset: 0x0001D810
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.z, this.x);
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x0001F62F File Offset: 0x0001D82F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060009A6 RID: 2470 RVA: 0x0001F64E File Offset: 0x0001D84E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060009A7 RID: 2471 RVA: 0x0001F66D File Offset: 0x0001D86D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.z, this.w);
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x0001F68C File Offset: 0x0001D88C
		// (set) Token: 0x060009A9 RID: 2473 RVA: 0x0001F6AB File Offset: 0x0001D8AB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.w = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060009AA RID: 2474 RVA: 0x0001F6DD File Offset: 0x0001D8DD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.w, this.y);
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060009AB RID: 2475 RVA: 0x0001F6FC File Offset: 0x0001D8FC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.w, this.z);
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x0001F71B File Offset: 0x0001D91B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.y, this.w, this.w);
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060009AD RID: 2477 RVA: 0x0001F73A File Offset: 0x0001D93A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.x, this.x);
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x0001F759 File Offset: 0x0001D959
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.x, this.y);
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060009AF RID: 2479 RVA: 0x0001F778 File Offset: 0x0001D978
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.x, this.z);
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x0001F797 File Offset: 0x0001D997
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.x, this.w);
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060009B1 RID: 2481 RVA: 0x0001F7B6 File Offset: 0x0001D9B6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.y, this.x);
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x0001F7D5 File Offset: 0x0001D9D5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060009B3 RID: 2483 RVA: 0x0001F7F4 File Offset: 0x0001D9F4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060009B4 RID: 2484 RVA: 0x0001F813 File Offset: 0x0001DA13
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.y, this.w);
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060009B5 RID: 2485 RVA: 0x0001F832 File Offset: 0x0001DA32
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060009B6 RID: 2486 RVA: 0x0001F851 File Offset: 0x0001DA51
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060009B7 RID: 2487 RVA: 0x0001F870 File Offset: 0x0001DA70
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x0001F88F File Offset: 0x0001DA8F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.z, this.w);
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0001F8AE File Offset: 0x0001DAAE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.w, this.x);
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x0001F8CD File Offset: 0x0001DACD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.w, this.y);
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060009BB RID: 2491 RVA: 0x0001F8EC File Offset: 0x0001DAEC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.w, this.z);
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060009BC RID: 2492 RVA: 0x0001F90B File Offset: 0x0001DB0B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.z, this.w, this.w);
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060009BD RID: 2493 RVA: 0x0001F92A File Offset: 0x0001DB2A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.x, this.x);
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x0001F949 File Offset: 0x0001DB49
		// (set) Token: 0x060009BF RID: 2495 RVA: 0x0001F968 File Offset: 0x0001DB68
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.x = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x0001F99A File Offset: 0x0001DB9A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.x, this.z);
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x0001F9B9 File Offset: 0x0001DBB9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.x, this.w);
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x0001F9D8 File Offset: 0x0001DBD8
		// (set) Token: 0x060009C3 RID: 2499 RVA: 0x0001F9F7 File Offset: 0x0001DBF7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.y = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x0001FA29 File Offset: 0x0001DC29
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.y, this.y);
			}
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060009C5 RID: 2501 RVA: 0x0001FA48 File Offset: 0x0001DC48
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.y, this.z);
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060009C6 RID: 2502 RVA: 0x0001FA67 File Offset: 0x0001DC67
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.y, this.w);
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060009C7 RID: 2503 RVA: 0x0001FA86 File Offset: 0x0001DC86
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.z, this.x);
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060009C8 RID: 2504 RVA: 0x0001FAA5 File Offset: 0x0001DCA5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.z, this.y);
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060009C9 RID: 2505 RVA: 0x0001FAC4 File Offset: 0x0001DCC4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.z, this.z);
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060009CA RID: 2506 RVA: 0x0001FAE3 File Offset: 0x0001DCE3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.z, this.w);
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060009CB RID: 2507 RVA: 0x0001FB02 File Offset: 0x0001DD02
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.w, this.x);
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060009CC RID: 2508 RVA: 0x0001FB21 File Offset: 0x0001DD21
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.w, this.y);
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060009CD RID: 2509 RVA: 0x0001FB40 File Offset: 0x0001DD40
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.w, this.z);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060009CE RID: 2510 RVA: 0x0001FB5F File Offset: 0x0001DD5F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 zwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.z, this.w, this.w, this.w);
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060009CF RID: 2511 RVA: 0x0001FB7E File Offset: 0x0001DD7E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.x, this.x);
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060009D0 RID: 2512 RVA: 0x0001FB9D File Offset: 0x0001DD9D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.x, this.y);
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060009D1 RID: 2513 RVA: 0x0001FBBC File Offset: 0x0001DDBC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.x, this.z);
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060009D2 RID: 2514 RVA: 0x0001FBDB File Offset: 0x0001DDDB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.x, this.w);
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060009D3 RID: 2515 RVA: 0x0001FBFA File Offset: 0x0001DDFA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060009D4 RID: 2516 RVA: 0x0001FC19 File Offset: 0x0001DE19
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060009D5 RID: 2517 RVA: 0x0001FC38 File Offset: 0x0001DE38
		// (set) Token: 0x060009D6 RID: 2518 RVA: 0x0001FC57 File Offset: 0x0001DE57
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.y = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060009D7 RID: 2519 RVA: 0x0001FC89 File Offset: 0x0001DE89
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.y, this.w);
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060009D8 RID: 2520 RVA: 0x0001FCA8 File Offset: 0x0001DEA8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.z, this.x);
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x0001FCC7 File Offset: 0x0001DEC7
		// (set) Token: 0x060009DA RID: 2522 RVA: 0x0001FCE6 File Offset: 0x0001DEE6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.z = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060009DB RID: 2523 RVA: 0x0001FD18 File Offset: 0x0001DF18
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.z, this.z);
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x0001FD37 File Offset: 0x0001DF37
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.z, this.w);
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x0001FD56 File Offset: 0x0001DF56
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.w, this.x);
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060009DE RID: 2526 RVA: 0x0001FD75 File Offset: 0x0001DF75
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.w, this.y);
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x0001FD94 File Offset: 0x0001DF94
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.w, this.z);
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x0001FDB3 File Offset: 0x0001DFB3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.x, this.w, this.w);
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060009E1 RID: 2529 RVA: 0x0001FDD2 File Offset: 0x0001DFD2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.x, this.x);
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060009E2 RID: 2530 RVA: 0x0001FDF1 File Offset: 0x0001DFF1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.x, this.y);
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060009E3 RID: 2531 RVA: 0x0001FE10 File Offset: 0x0001E010
		// (set) Token: 0x060009E4 RID: 2532 RVA: 0x0001FE2F File Offset: 0x0001E02F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.x = value.z;
				this.z = value.w;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x0001FE61 File Offset: 0x0001E061
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.x, this.w);
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x0001FE80 File Offset: 0x0001E080
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.y, this.x);
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x0001FE9F File Offset: 0x0001E09F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060009E8 RID: 2536 RVA: 0x0001FEBE File Offset: 0x0001E0BE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.y, this.z);
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060009E9 RID: 2537 RVA: 0x0001FEDD File Offset: 0x0001E0DD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.y, this.w);
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060009EA RID: 2538 RVA: 0x0001FEFC File Offset: 0x0001E0FC
		// (set) Token: 0x060009EB RID: 2539 RVA: 0x0001FF1B File Offset: 0x0001E11B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.z = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060009EC RID: 2540 RVA: 0x0001FF4D File Offset: 0x0001E14D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.z, this.y);
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060009ED RID: 2541 RVA: 0x0001FF6C File Offset: 0x0001E16C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.z, this.z);
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060009EE RID: 2542 RVA: 0x0001FF8B File Offset: 0x0001E18B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.z, this.w);
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060009EF RID: 2543 RVA: 0x0001FFAA File Offset: 0x0001E1AA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.w, this.x);
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060009F0 RID: 2544 RVA: 0x0001FFC9 File Offset: 0x0001E1C9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.w, this.y);
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x0001FFE8 File Offset: 0x0001E1E8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.w, this.z);
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x00020007 File Offset: 0x0001E207
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.y, this.w, this.w);
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x00020026 File Offset: 0x0001E226
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.x, this.x);
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060009F4 RID: 2548 RVA: 0x00020045 File Offset: 0x0001E245
		// (set) Token: 0x060009F5 RID: 2549 RVA: 0x00020064 File Offset: 0x0001E264
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.x = value.z;
				this.y = value.w;
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060009F6 RID: 2550 RVA: 0x00020096 File Offset: 0x0001E296
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.x, this.z);
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x000200B5 File Offset: 0x0001E2B5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.x, this.w);
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060009F8 RID: 2552 RVA: 0x000200D4 File Offset: 0x0001E2D4
		// (set) Token: 0x060009F9 RID: 2553 RVA: 0x000200F3 File Offset: 0x0001E2F3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.y = value.z;
				this.x = value.w;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x00020125 File Offset: 0x0001E325
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.y, this.y);
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x00020144 File Offset: 0x0001E344
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.y, this.z);
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060009FC RID: 2556 RVA: 0x00020163 File Offset: 0x0001E363
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.y, this.w);
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060009FD RID: 2557 RVA: 0x00020182 File Offset: 0x0001E382
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.z, this.x);
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060009FE RID: 2558 RVA: 0x000201A1 File Offset: 0x0001E3A1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.z, this.y);
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x000201C0 File Offset: 0x0001E3C0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.z, this.z);
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000A00 RID: 2560 RVA: 0x000201DF File Offset: 0x0001E3DF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.z, this.w);
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x000201FE File Offset: 0x0001E3FE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.w, this.x);
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000A02 RID: 2562 RVA: 0x0002021D File Offset: 0x0001E41D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.w, this.y);
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x0002023C File Offset: 0x0001E43C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.w, this.z);
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000A04 RID: 2564 RVA: 0x0002025B File Offset: 0x0001E45B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.z, this.w, this.w);
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x0002027A File Offset: 0x0001E47A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.x, this.x);
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000A06 RID: 2566 RVA: 0x00020299 File Offset: 0x0001E499
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.x, this.y);
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000A07 RID: 2567 RVA: 0x000202B8 File Offset: 0x0001E4B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.x, this.z);
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000A08 RID: 2568 RVA: 0x000202D7 File Offset: 0x0001E4D7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.x, this.w);
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000A09 RID: 2569 RVA: 0x000202F6 File Offset: 0x0001E4F6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.y, this.x);
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000A0A RID: 2570 RVA: 0x00020315 File Offset: 0x0001E515
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.y, this.y);
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x00020334 File Offset: 0x0001E534
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.y, this.z);
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000A0C RID: 2572 RVA: 0x00020353 File Offset: 0x0001E553
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.y, this.w);
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000A0D RID: 2573 RVA: 0x00020372 File Offset: 0x0001E572
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.z, this.x);
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000A0E RID: 2574 RVA: 0x00020391 File Offset: 0x0001E591
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.z, this.y);
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000A0F RID: 2575 RVA: 0x000203B0 File Offset: 0x0001E5B0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.z, this.z);
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000A10 RID: 2576 RVA: 0x000203CF File Offset: 0x0001E5CF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.z, this.w);
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x000203EE File Offset: 0x0001E5EE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.w, this.x);
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000A12 RID: 2578 RVA: 0x0002040D File Offset: 0x0001E60D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.w, this.y);
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000A13 RID: 2579 RVA: 0x0002042C File Offset: 0x0001E62C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.w, this.z);
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000A14 RID: 2580 RVA: 0x0002044B File Offset: 0x0001E64B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 wwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.w, this.w, this.w, this.w);
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000A15 RID: 2581 RVA: 0x0002046A File Offset: 0x0001E66A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.x, this.x);
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000A16 RID: 2582 RVA: 0x00020483 File Offset: 0x0001E683
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.x, this.y);
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000A17 RID: 2583 RVA: 0x0002049C File Offset: 0x0001E69C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.x, this.z);
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000A18 RID: 2584 RVA: 0x000204B5 File Offset: 0x0001E6B5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.x, this.w);
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000A19 RID: 2585 RVA: 0x000204CE File Offset: 0x0001E6CE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.y, this.x);
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000A1A RID: 2586 RVA: 0x000204E7 File Offset: 0x0001E6E7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.y, this.y);
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000A1B RID: 2587 RVA: 0x00020500 File Offset: 0x0001E700
		// (set) Token: 0x06000A1C RID: 2588 RVA: 0x00020519 File Offset: 0x0001E719
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

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000A1D RID: 2589 RVA: 0x0002053F File Offset: 0x0001E73F
		// (set) Token: 0x06000A1E RID: 2590 RVA: 0x00020558 File Offset: 0x0001E758
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000A1F RID: 2591 RVA: 0x0002057E File Offset: 0x0001E77E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.z, this.x);
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000A20 RID: 2592 RVA: 0x00020597 File Offset: 0x0001E797
		// (set) Token: 0x06000A21 RID: 2593 RVA: 0x000205B0 File Offset: 0x0001E7B0
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

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000A22 RID: 2594 RVA: 0x000205D6 File Offset: 0x0001E7D6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.z, this.z);
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000A23 RID: 2595 RVA: 0x000205EF File Offset: 0x0001E7EF
		// (set) Token: 0x06000A24 RID: 2596 RVA: 0x00020608 File Offset: 0x0001E808
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.z = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000A25 RID: 2597 RVA: 0x0002062E File Offset: 0x0001E82E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.w, this.x);
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000A26 RID: 2598 RVA: 0x00020647 File Offset: 0x0001E847
		// (set) Token: 0x06000A27 RID: 2599 RVA: 0x00020660 File Offset: 0x0001E860
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000A28 RID: 2600 RVA: 0x00020686 File Offset: 0x0001E886
		// (set) Token: 0x06000A29 RID: 2601 RVA: 0x0002069F File Offset: 0x0001E89F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000A2A RID: 2602 RVA: 0x000206C5 File Offset: 0x0001E8C5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.w, this.w);
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000A2B RID: 2603 RVA: 0x000206DE File Offset: 0x0001E8DE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.x, this.x);
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000A2C RID: 2604 RVA: 0x000206F7 File Offset: 0x0001E8F7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.x, this.y);
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000A2D RID: 2605 RVA: 0x00020710 File Offset: 0x0001E910
		// (set) Token: 0x06000A2E RID: 2606 RVA: 0x00020729 File Offset: 0x0001E929
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

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000A2F RID: 2607 RVA: 0x0002074F File Offset: 0x0001E94F
		// (set) Token: 0x06000A30 RID: 2608 RVA: 0x00020768 File Offset: 0x0001E968
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000A31 RID: 2609 RVA: 0x0002078E File Offset: 0x0001E98E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.y, this.x);
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000A32 RID: 2610 RVA: 0x000207A7 File Offset: 0x0001E9A7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.y, this.y);
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000A33 RID: 2611 RVA: 0x000207C0 File Offset: 0x0001E9C0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.y, this.z);
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000A34 RID: 2612 RVA: 0x000207D9 File Offset: 0x0001E9D9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.y, this.w);
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000A35 RID: 2613 RVA: 0x000207F2 File Offset: 0x0001E9F2
		// (set) Token: 0x06000A36 RID: 2614 RVA: 0x0002080B File Offset: 0x0001EA0B
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

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000A37 RID: 2615 RVA: 0x00020831 File Offset: 0x0001EA31
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.z, this.y);
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000A38 RID: 2616 RVA: 0x0002084A File Offset: 0x0001EA4A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.z, this.z);
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000A39 RID: 2617 RVA: 0x00020863 File Offset: 0x0001EA63
		// (set) Token: 0x06000A3A RID: 2618 RVA: 0x0002087C File Offset: 0x0001EA7C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.z = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000A3B RID: 2619 RVA: 0x000208A2 File Offset: 0x0001EAA2
		// (set) Token: 0x06000A3C RID: 2620 RVA: 0x000208BB File Offset: 0x0001EABB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 ywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000A3D RID: 2621 RVA: 0x000208E1 File Offset: 0x0001EAE1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 ywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.w, this.y);
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000A3E RID: 2622 RVA: 0x000208FA File Offset: 0x0001EAFA
		// (set) Token: 0x06000A3F RID: 2623 RVA: 0x00020913 File Offset: 0x0001EB13
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 ywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000A40 RID: 2624 RVA: 0x00020939 File Offset: 0x0001EB39
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.w, this.w);
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x00020952 File Offset: 0x0001EB52
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.x, this.x);
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000A42 RID: 2626 RVA: 0x0002096B File Offset: 0x0001EB6B
		// (set) Token: 0x06000A43 RID: 2627 RVA: 0x00020984 File Offset: 0x0001EB84
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

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000A44 RID: 2628 RVA: 0x000209AA File Offset: 0x0001EBAA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.x, this.z);
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x000209C3 File Offset: 0x0001EBC3
		// (set) Token: 0x06000A46 RID: 2630 RVA: 0x000209DC File Offset: 0x0001EBDC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.x = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000A47 RID: 2631 RVA: 0x00020A02 File Offset: 0x0001EC02
		// (set) Token: 0x06000A48 RID: 2632 RVA: 0x00020A1B File Offset: 0x0001EC1B
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

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000A49 RID: 2633 RVA: 0x00020A41 File Offset: 0x0001EC41
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.y, this.y);
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000A4A RID: 2634 RVA: 0x00020A5A File Offset: 0x0001EC5A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.y, this.z);
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x00020A73 File Offset: 0x0001EC73
		// (set) Token: 0x06000A4C RID: 2636 RVA: 0x00020A8C File Offset: 0x0001EC8C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.y = value.y;
				this.w = value.z;
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000A4D RID: 2637 RVA: 0x00020AB2 File Offset: 0x0001ECB2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.z, this.x);
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000A4E RID: 2638 RVA: 0x00020ACB File Offset: 0x0001ECCB
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.z, this.y);
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000A4F RID: 2639 RVA: 0x00020AE4 File Offset: 0x0001ECE4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.z, this.z);
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000A50 RID: 2640 RVA: 0x00020AFD File Offset: 0x0001ECFD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.z, this.w);
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000A51 RID: 2641 RVA: 0x00020B16 File Offset: 0x0001ED16
		// (set) Token: 0x06000A52 RID: 2642 RVA: 0x00020B2F File Offset: 0x0001ED2F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00020B55 File Offset: 0x0001ED55
		// (set) Token: 0x06000A54 RID: 2644 RVA: 0x00020B6E File Offset: 0x0001ED6E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000A55 RID: 2645 RVA: 0x00020B94 File Offset: 0x0001ED94
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.w, this.z);
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000A56 RID: 2646 RVA: 0x00020BAD File Offset: 0x0001EDAD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 zww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.z, this.w, this.w);
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000A57 RID: 2647 RVA: 0x00020BC6 File Offset: 0x0001EDC6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.x, this.x);
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000A58 RID: 2648 RVA: 0x00020BDF File Offset: 0x0001EDDF
		// (set) Token: 0x06000A59 RID: 2649 RVA: 0x00020BF8 File Offset: 0x0001EDF8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000A5A RID: 2650 RVA: 0x00020C1E File Offset: 0x0001EE1E
		// (set) Token: 0x06000A5B RID: 2651 RVA: 0x00020C37 File Offset: 0x0001EE37
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.x, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000A5C RID: 2652 RVA: 0x00020C5D File Offset: 0x0001EE5D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.x, this.w);
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000A5D RID: 2653 RVA: 0x00020C76 File Offset: 0x0001EE76
		// (set) Token: 0x06000A5E RID: 2654 RVA: 0x00020C8F File Offset: 0x0001EE8F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000A5F RID: 2655 RVA: 0x00020CB5 File Offset: 0x0001EEB5
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.y, this.y);
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000A60 RID: 2656 RVA: 0x00020CCE File Offset: 0x0001EECE
		// (set) Token: 0x06000A61 RID: 2657 RVA: 0x00020CE7 File Offset: 0x0001EEE7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.y, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000A62 RID: 2658 RVA: 0x00020D0D File Offset: 0x0001EF0D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.y, this.w);
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000A63 RID: 2659 RVA: 0x00020D26 File Offset: 0x0001EF26
		// (set) Token: 0x06000A64 RID: 2660 RVA: 0x00020D3F File Offset: 0x0001EF3F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.z, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.x = value.z;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000A65 RID: 2661 RVA: 0x00020D65 File Offset: 0x0001EF65
		// (set) Token: 0x06000A66 RID: 2662 RVA: 0x00020D7E File Offset: 0x0001EF7E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.z, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
				this.y = value.z;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000A67 RID: 2663 RVA: 0x00020DA4 File Offset: 0x0001EFA4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.z, this.z);
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000A68 RID: 2664 RVA: 0x00020DBD File Offset: 0x0001EFBD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.z, this.w);
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00020DD6 File Offset: 0x0001EFD6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.w, this.x);
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000A6A RID: 2666 RVA: 0x00020DEF File Offset: 0x0001EFEF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.w, this.y);
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000A6B RID: 2667 RVA: 0x00020E08 File Offset: 0x0001F008
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 wwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.w, this.z);
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000A6C RID: 2668 RVA: 0x00020E21 File Offset: 0x0001F021
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 www
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.w, this.w, this.w);
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000A6D RID: 2669 RVA: 0x00020E3A File Offset: 0x0001F03A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.x, this.x);
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000A6E RID: 2670 RVA: 0x00020E4D File Offset: 0x0001F04D
		// (set) Token: 0x06000A6F RID: 2671 RVA: 0x00020E60 File Offset: 0x0001F060
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

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000A70 RID: 2672 RVA: 0x00020E7A File Offset: 0x0001F07A
		// (set) Token: 0x06000A71 RID: 2673 RVA: 0x00020E8D File Offset: 0x0001F08D
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

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000A72 RID: 2674 RVA: 0x00020EA7 File Offset: 0x0001F0A7
		// (set) Token: 0x06000A73 RID: 2675 RVA: 0x00020EBA File Offset: 0x0001F0BA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 xw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.x, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000A74 RID: 2676 RVA: 0x00020ED4 File Offset: 0x0001F0D4
		// (set) Token: 0x06000A75 RID: 2677 RVA: 0x00020EE7 File Offset: 0x0001F0E7
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

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000A76 RID: 2678 RVA: 0x00020F01 File Offset: 0x0001F101
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.y, this.y);
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000A77 RID: 2679 RVA: 0x00020F14 File Offset: 0x0001F114
		// (set) Token: 0x06000A78 RID: 2680 RVA: 0x00020F27 File Offset: 0x0001F127
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

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000A79 RID: 2681 RVA: 0x00020F41 File Offset: 0x0001F141
		// (set) Token: 0x06000A7A RID: 2682 RVA: 0x00020F54 File Offset: 0x0001F154
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 yw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.y, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x00020F6E File Offset: 0x0001F16E
		// (set) Token: 0x06000A7C RID: 2684 RVA: 0x00020F81 File Offset: 0x0001F181
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

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000A7D RID: 2685 RVA: 0x00020F9B File Offset: 0x0001F19B
		// (set) Token: 0x06000A7E RID: 2686 RVA: 0x00020FAE File Offset: 0x0001F1AE
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

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000A7F RID: 2687 RVA: 0x00020FC8 File Offset: 0x0001F1C8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 zz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.z, this.z);
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000A80 RID: 2688 RVA: 0x00020FDB File Offset: 0x0001F1DB
		// (set) Token: 0x06000A81 RID: 2689 RVA: 0x00020FEE File Offset: 0x0001F1EE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 zw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.z, this.w);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.z = value.x;
				this.w = value.y;
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000A82 RID: 2690 RVA: 0x00021008 File Offset: 0x0001F208
		// (set) Token: 0x06000A83 RID: 2691 RVA: 0x0002101B File Offset: 0x0001F21B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 wx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.w, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000A84 RID: 2692 RVA: 0x00021035 File Offset: 0x0001F235
		// (set) Token: 0x06000A85 RID: 2693 RVA: 0x00021048 File Offset: 0x0001F248
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 wy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.w, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000A86 RID: 2694 RVA: 0x00021062 File Offset: 0x0001F262
		// (set) Token: 0x06000A87 RID: 2695 RVA: 0x00021075 File Offset: 0x0001F275
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 wz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.w, this.z);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.w = value.x;
				this.z = value.y;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000A88 RID: 2696 RVA: 0x0002108F File Offset: 0x0001F28F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 ww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.w, this.w);
			}
		}

		// Token: 0x170001EA RID: 490
		public unsafe bool this[int index]
		{
			get
			{
				fixed (bool4* ptr = &this)
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

		// Token: 0x06000A8B RID: 2699 RVA: 0x000210D5 File Offset: 0x0001F2D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(bool4 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y && this.z == rhs.z && this.w == rhs.w;
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x00021114 File Offset: 0x0001F314
		public override bool Equals(object o)
		{
			if (o is bool4)
			{
				bool4 rhs = (bool4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x00021139 File Offset: 0x0001F339
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00021148 File Offset: 0x0001F348
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("bool4({0}, {1}, {2}, {3})", new object[]
			{
				this.x,
				this.y,
				this.z,
				this.w
			});
		}

		// Token: 0x0400002E RID: 46
		[MarshalAs(UnmanagedType.U1)]
		public bool x;

		// Token: 0x0400002F RID: 47
		[MarshalAs(UnmanagedType.U1)]
		public bool y;

		// Token: 0x04000030 RID: 48
		[MarshalAs(UnmanagedType.U1)]
		public bool z;

		// Token: 0x04000031 RID: 49
		[MarshalAs(UnmanagedType.U1)]
		public bool w;

		// Token: 0x02000056 RID: 86
		internal sealed class DebuggerProxy
		{
			// Token: 0x0600246B RID: 9323 RVA: 0x00067544 File Offset: 0x00065744
			public DebuggerProxy(bool4 v)
			{
				this.x = v.x;
				this.y = v.y;
				this.z = v.z;
				this.w = v.w;
			}

			// Token: 0x0400013F RID: 319
			public bool x;

			// Token: 0x04000140 RID: 320
			public bool y;

			// Token: 0x04000141 RID: 321
			public bool z;

			// Token: 0x04000142 RID: 322
			public bool w;
		}
	}
}
