using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000006 RID: 6
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct bool2x2 : IEquatable<bool2x2>
	{
		// Token: 0x060007B0 RID: 1968 RVA: 0x0001AD3E File Offset: 0x00018F3E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2x2(bool2 c0, bool2 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0001AD4E File Offset: 0x00018F4E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2x2(bool m00, bool m01, bool m10, bool m11)
		{
			this.c0 = new bool2(m00, m10);
			this.c1 = new bool2(m01, m11);
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0001AD6B File Offset: 0x00018F6B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2x2(bool v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x0001AD85 File Offset: 0x00018F85
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool2x2(bool v)
		{
			return new bool2x2(v);
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0001AD8D File Offset: 0x00018F8D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ==(bool2x2 lhs, bool2x2 rhs)
		{
			return new bool2x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0001ADB6 File Offset: 0x00018FB6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ==(bool2x2 lhs, bool rhs)
		{
			return new bool2x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0001ADD5 File Offset: 0x00018FD5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ==(bool lhs, bool2x2 rhs)
		{
			return new bool2x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0001ADF4 File Offset: 0x00018FF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator !=(bool2x2 lhs, bool2x2 rhs)
		{
			return new bool2x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0001AE1D File Offset: 0x0001901D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator !=(bool2x2 lhs, bool rhs)
		{
			return new bool2x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0001AE3C File Offset: 0x0001903C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator !=(bool lhs, bool2x2 rhs)
		{
			return new bool2x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0001AE5B File Offset: 0x0001905B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator !(bool2x2 val)
		{
			return new bool2x2(!val.c0, !val.c1);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0001AE78 File Offset: 0x00019078
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator &(bool2x2 lhs, bool2x2 rhs)
		{
			return new bool2x2(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0001AEA1 File Offset: 0x000190A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator &(bool2x2 lhs, bool rhs)
		{
			return new bool2x2(lhs.c0 & rhs, lhs.c1 & rhs);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0001AEC0 File Offset: 0x000190C0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator &(bool lhs, bool2x2 rhs)
		{
			return new bool2x2(lhs & rhs.c0, lhs & rhs.c1);
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0001AEDF File Offset: 0x000190DF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator |(bool2x2 lhs, bool2x2 rhs)
		{
			return new bool2x2(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0001AF08 File Offset: 0x00019108
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator |(bool2x2 lhs, bool rhs)
		{
			return new bool2x2(lhs.c0 | rhs, lhs.c1 | rhs);
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0001AF27 File Offset: 0x00019127
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator |(bool lhs, bool2x2 rhs)
		{
			return new bool2x2(lhs | rhs.c0, lhs | rhs.c1);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0001AF46 File Offset: 0x00019146
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ^(bool2x2 lhs, bool2x2 rhs)
		{
			return new bool2x2(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0001AF6F File Offset: 0x0001916F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ^(bool2x2 lhs, bool rhs)
		{
			return new bool2x2(lhs.c0 ^ rhs, lhs.c1 ^ rhs);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0001AF8E File Offset: 0x0001918E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x2 operator ^(bool lhs, bool2x2 rhs)
		{
			return new bool2x2(lhs ^ rhs.c0, lhs ^ rhs.c1);
		}

		// Token: 0x1700001E RID: 30
		public unsafe bool2 this[int index]
		{
			get
			{
				fixed (bool2x2* ptr = &this)
				{
					return ref *(bool2*)(ptr + (IntPtr)index * (IntPtr)sizeof(bool2) / (IntPtr)sizeof(bool2x2));
				}
			}
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0001AFCB File Offset: 0x000191CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(bool2x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0001AFF4 File Offset: 0x000191F4
		public override bool Equals(object o)
		{
			if (o is bool2x2)
			{
				bool2x2 rhs = (bool2x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x0001B019 File Offset: 0x00019219
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0001B028 File Offset: 0x00019228
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("bool2x2({0}, {1},  {2}, {3})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y
			});
		}

		// Token: 0x04000019 RID: 25
		public bool2 c0;

		// Token: 0x0400001A RID: 26
		public bool2 c1;
	}
}
