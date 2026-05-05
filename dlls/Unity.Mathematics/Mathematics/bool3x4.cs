using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200000C RID: 12
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct bool3x4 : IEquatable<bool3x4>
	{
		// Token: 0x060008CA RID: 2250 RVA: 0x0001D5BD File Offset: 0x0001B7BD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3x4(bool3 c0, bool3 c1, bool3 c2, bool3 c3)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
			this.c3 = c3;
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0001D5DC File Offset: 0x0001B7DC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3x4(bool m00, bool m01, bool m02, bool m03, bool m10, bool m11, bool m12, bool m13, bool m20, bool m21, bool m22, bool m23)
		{
			this.c0 = new bool3(m00, m10, m20);
			this.c1 = new bool3(m01, m11, m21);
			this.c2 = new bool3(m02, m12, m22);
			this.c3 = new bool3(m03, m13, m23);
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x0001D62A File Offset: 0x0001B82A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3x4(bool v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0001D65C File Offset: 0x0001B85C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool3x4(bool v)
		{
			return new bool3x4(v);
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0001D664 File Offset: 0x0001B864
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ==(bool3x4 lhs, bool3x4 rhs)
		{
			return new bool3x4(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x0001D6BA File Offset: 0x0001B8BA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ==(bool3x4 lhs, bool rhs)
		{
			return new bool3x4(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs);
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x0001D6F1 File Offset: 0x0001B8F1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ==(bool lhs, bool3x4 rhs)
		{
			return new bool3x4(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3);
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x0001D728 File Offset: 0x0001B928
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator !=(bool3x4 lhs, bool3x4 rhs)
		{
			return new bool3x4(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0001D77E File Offset: 0x0001B97E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator !=(bool3x4 lhs, bool rhs)
		{
			return new bool3x4(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs);
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0001D7B5 File Offset: 0x0001B9B5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator !=(bool lhs, bool3x4 rhs)
		{
			return new bool3x4(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3);
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0001D7EC File Offset: 0x0001B9EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator !(bool3x4 val)
		{
			return new bool3x4(!val.c0, !val.c1, !val.c2, !val.c3);
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x0001D820 File Offset: 0x0001BA20
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator &(bool3x4 lhs, bool3x4 rhs)
		{
			return new bool3x4(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2, lhs.c3 & rhs.c3);
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x0001D876 File Offset: 0x0001BA76
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator &(bool3x4 lhs, bool rhs)
		{
			return new bool3x4(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs, lhs.c3 & rhs);
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0001D8AD File Offset: 0x0001BAAD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator &(bool lhs, bool3x4 rhs)
		{
			return new bool3x4(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2, lhs & rhs.c3);
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0001D8E4 File Offset: 0x0001BAE4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator |(bool3x4 lhs, bool3x4 rhs)
		{
			return new bool3x4(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2, lhs.c3 | rhs.c3);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0001D93A File Offset: 0x0001BB3A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator |(bool3x4 lhs, bool rhs)
		{
			return new bool3x4(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs, lhs.c3 | rhs);
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0001D971 File Offset: 0x0001BB71
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator |(bool lhs, bool3x4 rhs)
		{
			return new bool3x4(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2, lhs | rhs.c3);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0001D9A8 File Offset: 0x0001BBA8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ^(bool3x4 lhs, bool3x4 rhs)
		{
			return new bool3x4(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2, lhs.c3 ^ rhs.c3);
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0001D9FE File Offset: 0x0001BBFE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ^(bool3x4 lhs, bool rhs)
		{
			return new bool3x4(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs, lhs.c3 ^ rhs);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0001DA35 File Offset: 0x0001BC35
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x4 operator ^(bool lhs, bool3x4 rhs)
		{
			return new bool3x4(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2, lhs ^ rhs.c3);
		}

		// Token: 0x17000099 RID: 153
		public unsafe bool3 this[int index]
		{
			get
			{
				fixed (bool3x4* ptr = &this)
				{
					return ref *(bool3*)(ptr + (IntPtr)index * (IntPtr)sizeof(bool3) / (IntPtr)sizeof(bool3x4));
				}
			}
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0001DA88 File Offset: 0x0001BC88
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(bool3x4 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2) && this.c3.Equals(rhs.c3);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x0001DAE4 File Offset: 0x0001BCE4
		public override bool Equals(object o)
		{
			if (o is bool3x4)
			{
				bool3x4 rhs = (bool3x4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0001DB09 File Offset: 0x0001BD09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x0001DB18 File Offset: 0x0001BD18
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("bool3x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7},  {8}, {9}, {10}, {11})", new object[]
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
				this.c3.z
			});
		}

		// Token: 0x0400002A RID: 42
		public bool3 c0;

		// Token: 0x0400002B RID: 43
		public bool3 c1;

		// Token: 0x0400002C RID: 44
		public bool3 c2;

		// Token: 0x0400002D RID: 45
		public bool3 c3;
	}
}
