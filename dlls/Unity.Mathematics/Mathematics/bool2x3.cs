using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000007 RID: 7
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct bool2x3 : IEquatable<bool2x3>
	{
		// Token: 0x060007C9 RID: 1993 RVA: 0x0001B091 File Offset: 0x00019291
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2x3(bool2 c0, bool2 c1, bool2 c2)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0001B0A8 File Offset: 0x000192A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2x3(bool m00, bool m01, bool m02, bool m10, bool m11, bool m12)
		{
			this.c0 = new bool2(m00, m10);
			this.c1 = new bool2(m01, m11);
			this.c2 = new bool2(m02, m12);
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0001B0D4 File Offset: 0x000192D4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2x3(bool v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x0001B0FA File Offset: 0x000192FA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool2x3(bool v)
		{
			return new bool2x3(v);
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x0001B102 File Offset: 0x00019302
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(bool2x3 lhs, bool2x3 rhs)
		{
			return new bool2x3(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0001B13C File Offset: 0x0001933C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(bool2x3 lhs, bool rhs)
		{
			return new bool2x3(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs);
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x0001B167 File Offset: 0x00019367
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ==(bool lhs, bool2x3 rhs)
		{
			return new bool2x3(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0001B192 File Offset: 0x00019392
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(bool2x3 lhs, bool2x3 rhs)
		{
			return new bool2x3(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0001B1CC File Offset: 0x000193CC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(bool2x3 lhs, bool rhs)
		{
			return new bool2x3(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs);
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x0001B1F7 File Offset: 0x000193F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !=(bool lhs, bool2x3 rhs)
		{
			return new bool2x3(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2);
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0001B222 File Offset: 0x00019422
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator !(bool2x3 val)
		{
			return new bool2x3(!val.c0, !val.c1, !val.c2);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0001B24A File Offset: 0x0001944A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator &(bool2x3 lhs, bool2x3 rhs)
		{
			return new bool2x3(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0001B284 File Offset: 0x00019484
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator &(bool2x3 lhs, bool rhs)
		{
			return new bool2x3(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs);
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0001B2AF File Offset: 0x000194AF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator &(bool lhs, bool2x3 rhs)
		{
			return new bool2x3(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2);
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0001B2DA File Offset: 0x000194DA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator |(bool2x3 lhs, bool2x3 rhs)
		{
			return new bool2x3(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0001B314 File Offset: 0x00019514
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator |(bool2x3 lhs, bool rhs)
		{
			return new bool2x3(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs);
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0001B33F File Offset: 0x0001953F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator |(bool lhs, bool2x3 rhs)
		{
			return new bool2x3(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2);
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0001B36A File Offset: 0x0001956A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ^(bool2x3 lhs, bool2x3 rhs)
		{
			return new bool2x3(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0001B3A4 File Offset: 0x000195A4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ^(bool2x3 lhs, bool rhs)
		{
			return new bool2x3(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0001B3CF File Offset: 0x000195CF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x3 operator ^(bool lhs, bool2x3 rhs)
		{
			return new bool2x3(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2);
		}

		// Token: 0x1700001F RID: 31
		public unsafe bool2 this[int index]
		{
			get
			{
				fixed (bool2x3* ptr = &this)
				{
					return ref *(bool2*)(ptr + (IntPtr)index * (IntPtr)sizeof(bool2) / (IntPtr)sizeof(bool2x3));
				}
			}
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0001B417 File Offset: 0x00019617
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(bool2x3 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2);
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0001B454 File Offset: 0x00019654
		public override bool Equals(object o)
		{
			if (o is bool2x3)
			{
				bool2x3 rhs = (bool2x3)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0001B479 File Offset: 0x00019679
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0001B488 File Offset: 0x00019688
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("bool2x3({0}, {1}, {2},  {3}, {4}, {5})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c0.y,
				this.c1.y,
				this.c2.y
			});
		}

		// Token: 0x0400001B RID: 27
		public bool2 c0;

		// Token: 0x0400001C RID: 28
		public bool2 c1;

		// Token: 0x0400001D RID: 29
		public bool2 c2;
	}
}
