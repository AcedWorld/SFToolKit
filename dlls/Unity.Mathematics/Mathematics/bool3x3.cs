using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200000B RID: 11
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct bool3x3 : IEquatable<bool3x3>
	{
		// Token: 0x060008B1 RID: 2225 RVA: 0x0001D0F7 File Offset: 0x0001B2F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3x3(bool3 c0, bool3 c1, bool3 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x0001D10E File Offset: 0x0001B30E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3x3(bool m00, bool m01, bool m02, bool m10, bool m11, bool m12, bool m20, bool m21, bool m22)
		{
			this.c0 = new bool3(m00, m10, m20);
			this.c1 = new bool3(m01, m11, m21);
			this.c2 = new bool3(m02, m12, m22);
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x0001D140 File Offset: 0x0001B340
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3x3(bool v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x0001D166 File Offset: 0x0001B366
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool3x3(bool v)
		{
			return new bool3x3(v);
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x0001D16E File Offset: 0x0001B36E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(bool3x3 lhs, bool3x3 rhs)
		{
			return new bool3x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x0001D1A8 File Offset: 0x0001B3A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(bool3x3 lhs, bool rhs)
		{
			return new bool3x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x0001D1D3 File Offset: 0x0001B3D3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ==(bool lhs, bool3x3 rhs)
		{
			return new bool3x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x0001D1FE File Offset: 0x0001B3FE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(bool3x3 lhs, bool3x3 rhs)
		{
			return new bool3x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0001D238 File Offset: 0x0001B438
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(bool3x3 lhs, bool rhs)
		{
			return new bool3x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x0001D263 File Offset: 0x0001B463
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !=(bool lhs, bool3x3 rhs)
		{
			return new bool3x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x0001D28E File Offset: 0x0001B48E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator !(bool3x3 val)
		{
			return new bool3x3(!val.c0, !val.c1, !val.c2);
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x0001D2B6 File Offset: 0x0001B4B6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator &(bool3x3 lhs, bool3x3 rhs)
		{
			return new bool3x3(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x0001D2F0 File Offset: 0x0001B4F0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator &(bool3x3 lhs, bool rhs)
		{
			return new bool3x3(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0001D31B File Offset: 0x0001B51B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator &(bool lhs, bool3x3 rhs)
		{
			return new bool3x3(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2);
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x0001D346 File Offset: 0x0001B546
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator |(bool3x3 lhs, bool3x3 rhs)
		{
			return new bool3x3(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x0001D380 File Offset: 0x0001B580
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator |(bool3x3 lhs, bool rhs)
		{
			return new bool3x3(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0001D3AB File Offset: 0x0001B5AB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator |(bool lhs, bool3x3 rhs)
		{
			return new bool3x3(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2);
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0001D3D6 File Offset: 0x0001B5D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ^(bool3x3 lhs, bool3x3 rhs)
		{
			return new bool3x3(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0001D410 File Offset: 0x0001B610
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ^(bool3x3 lhs, bool rhs)
		{
			return new bool3x3(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs);
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0001D43B File Offset: 0x0001B63B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x3 operator ^(bool lhs, bool3x3 rhs)
		{
			return new bool3x3(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2);
		}

		// Token: 0x17000098 RID: 152
		public unsafe bool3 this[int index]
		{
			get
			{
				fixed (bool3x3* ptr = &this)
				{
					return ref *(bool3*)(ptr + (IntPtr)index * (IntPtr)sizeof(bool3) / (IntPtr)sizeof(bool3x3));
				}
			}
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0001D483 File Offset: 0x0001B683
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(bool3x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x0001D4C0 File Offset: 0x0001B6C0
		public override bool Equals(object o)
		{
			if (o is bool3x3)
			{
				bool3x3 rhs = (bool3x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x0001D4E5 File Offset: 0x0001B6E5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0001D4F4 File Offset: 0x0001B6F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("bool3x3({0}, {1}, {2},  {3}, {4}, {5},  {6}, {7}, {8})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c0.z,
				this.c1.z,
				this.c2.z
			});
		}

		// Token: 0x04000027 RID: 39
		public bool3 c0;

		// Token: 0x04000028 RID: 40
		public bool3 c1;

		// Token: 0x04000029 RID: 41
		public bool3 c2;
	}
}
