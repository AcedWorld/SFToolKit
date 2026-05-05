using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200000A RID: 10
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct bool3x2 : IEquatable<bool3x2>
	{
		// Token: 0x06000898 RID: 2200 RVA: 0x0001CD7B File Offset: 0x0001AF7B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3x2(bool3 c0, bool3 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0001CD8B File Offset: 0x0001AF8B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3x2(bool m00, bool m01, bool m10, bool m11, bool m20, bool m21)
		{
			this.c0 = new bool3(m00, m10, m20);
			this.c1 = new bool3(m01, m11, m21);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0001CDAC File Offset: 0x0001AFAC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool3x2(bool v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0001CDC6 File Offset: 0x0001AFC6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool3x2(bool v)
		{
			return new bool3x2(v);
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0001CDCE File Offset: 0x0001AFCE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(bool3x2 lhs, bool3x2 rhs)
		{
			return new bool3x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0001CDF7 File Offset: 0x0001AFF7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(bool3x2 lhs, bool rhs)
		{
			return new bool3x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0001CE16 File Offset: 0x0001B016
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ==(bool lhs, bool3x2 rhs)
		{
			return new bool3x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x0001CE35 File Offset: 0x0001B035
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(bool3x2 lhs, bool3x2 rhs)
		{
			return new bool3x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x0001CE5E File Offset: 0x0001B05E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(bool3x2 lhs, bool rhs)
		{
			return new bool3x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0001CE7D File Offset: 0x0001B07D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !=(bool lhs, bool3x2 rhs)
		{
			return new bool3x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x0001CE9C File Offset: 0x0001B09C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator !(bool3x2 val)
		{
			return new bool3x2(!val.c0, !val.c1);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0001CEB9 File Offset: 0x0001B0B9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator &(bool3x2 lhs, bool3x2 rhs)
		{
			return new bool3x2(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x0001CEE2 File Offset: 0x0001B0E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator &(bool3x2 lhs, bool rhs)
		{
			return new bool3x2(lhs.c0 & rhs, lhs.c1 & rhs);
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x0001CF01 File Offset: 0x0001B101
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator &(bool lhs, bool3x2 rhs)
		{
			return new bool3x2(lhs & rhs.c0, lhs & rhs.c1);
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x0001CF20 File Offset: 0x0001B120
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator |(bool3x2 lhs, bool3x2 rhs)
		{
			return new bool3x2(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x0001CF49 File Offset: 0x0001B149
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator |(bool3x2 lhs, bool rhs)
		{
			return new bool3x2(lhs.c0 | rhs, lhs.c1 | rhs);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x0001CF68 File Offset: 0x0001B168
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator |(bool lhs, bool3x2 rhs)
		{
			return new bool3x2(lhs | rhs.c0, lhs | rhs.c1);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0001CF87 File Offset: 0x0001B187
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ^(bool3x2 lhs, bool3x2 rhs)
		{
			return new bool3x2(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0001CFB0 File Offset: 0x0001B1B0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ^(bool3x2 lhs, bool rhs)
		{
			return new bool3x2(lhs.c0 ^ rhs, lhs.c1 ^ rhs);
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0001CFCF File Offset: 0x0001B1CF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool3x2 operator ^(bool lhs, bool3x2 rhs)
		{
			return new bool3x2(lhs ^ rhs.c0, lhs ^ rhs.c1);
		}

		// Token: 0x17000097 RID: 151
		public unsafe bool3 this[int index]
		{
			get
			{
				fixed (bool3x2* ptr = &this)
				{
					return ref *(bool3*)(ptr + (IntPtr)index * (IntPtr)sizeof(bool3) / (IntPtr)sizeof(bool3x2));
				}
			}
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x0001D00B File Offset: 0x0001B20B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(bool3x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x0001D034 File Offset: 0x0001B234
		public override bool Equals(object o)
		{
			if (o is bool3x2)
			{
				bool3x2 rhs = (bool3x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x0001D059 File Offset: 0x0001B259
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x0001D068 File Offset: 0x0001B268
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("bool3x2({0}, {1},  {2}, {3},  {4}, {5})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y,
				this.c0.z,
				this.c1.z
			});
		}

		// Token: 0x04000025 RID: 37
		public bool3 c0;

		// Token: 0x04000026 RID: 38
		public bool3 c1;
	}
}
