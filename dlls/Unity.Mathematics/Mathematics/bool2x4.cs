using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000008 RID: 8
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct bool2x4 : IEquatable<bool2x4>
	{
		// Token: 0x060007E2 RID: 2018 RVA: 0x0001B517 File Offset: 0x00019717
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2x4(bool2 c0, bool2 c1, bool2 c2, bool2 c3)
		{
			this.c0 = c0;
			this.c1 = c1;
			this.c2 = c2;
			this.c3 = c3;
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0001B536 File Offset: 0x00019736
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2x4(bool m00, bool m01, bool m02, bool m03, bool m10, bool m11, bool m12, bool m13)
		{
			this.c0 = new bool2(m00, m10);
			this.c1 = new bool2(m01, m11);
			this.c2 = new bool2(m02, m12);
			this.c3 = new bool2(m03, m13);
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0001B571 File Offset: 0x00019771
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2x4(bool v)
		{
			this.c0 = v;
			this.c1 = v;
			this.c2 = v;
			this.c3 = v;
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0001B5A3 File Offset: 0x000197A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool2x4(bool v)
		{
			return new bool2x4(v);
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0001B5AC File Offset: 0x000197AC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(bool2x4 lhs, bool2x4 rhs)
		{
			return new bool2x4(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x0001B602 File Offset: 0x00019802
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(bool2x4 lhs, bool rhs)
		{
			return new bool2x4(lhs.c0 == rhs, lhs.c1 == rhs, lhs.c2 == rhs, lhs.c3 == rhs);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0001B639 File Offset: 0x00019839
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ==(bool lhs, bool2x4 rhs)
		{
			return new bool2x4(lhs == rhs.c0, lhs == rhs.c1, lhs == rhs.c2, lhs == rhs.c3);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x0001B670 File Offset: 0x00019870
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(bool2x4 lhs, bool2x4 rhs)
		{
			return new bool2x4(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x0001B6C6 File Offset: 0x000198C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(bool2x4 lhs, bool rhs)
		{
			return new bool2x4(lhs.c0 != rhs, lhs.c1 != rhs, lhs.c2 != rhs, lhs.c3 != rhs);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0001B6FD File Offset: 0x000198FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !=(bool lhs, bool2x4 rhs)
		{
			return new bool2x4(lhs != rhs.c0, lhs != rhs.c1, lhs != rhs.c2, lhs != rhs.c3);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0001B734 File Offset: 0x00019934
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator !(bool2x4 val)
		{
			return new bool2x4(!val.c0, !val.c1, !val.c2, !val.c3);
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0001B768 File Offset: 0x00019968
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator &(bool2x4 lhs, bool2x4 rhs)
		{
			return new bool2x4(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2, lhs.c3 & rhs.c3);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0001B7BE File Offset: 0x000199BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator &(bool2x4 lhs, bool rhs)
		{
			return new bool2x4(lhs.c0 & rhs, lhs.c1 & rhs, lhs.c2 & rhs, lhs.c3 & rhs);
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0001B7F5 File Offset: 0x000199F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator &(bool lhs, bool2x4 rhs)
		{
			return new bool2x4(lhs & rhs.c0, lhs & rhs.c1, lhs & rhs.c2, lhs & rhs.c3);
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x0001B82C File Offset: 0x00019A2C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator |(bool2x4 lhs, bool2x4 rhs)
		{
			return new bool2x4(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2, lhs.c3 | rhs.c3);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x0001B882 File Offset: 0x00019A82
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator |(bool2x4 lhs, bool rhs)
		{
			return new bool2x4(lhs.c0 | rhs, lhs.c1 | rhs, lhs.c2 | rhs, lhs.c3 | rhs);
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0001B8B9 File Offset: 0x00019AB9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator |(bool lhs, bool2x4 rhs)
		{
			return new bool2x4(lhs | rhs.c0, lhs | rhs.c1, lhs | rhs.c2, lhs | rhs.c3);
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0001B8F0 File Offset: 0x00019AF0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ^(bool2x4 lhs, bool2x4 rhs)
		{
			return new bool2x4(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2, lhs.c3 ^ rhs.c3);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0001B946 File Offset: 0x00019B46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ^(bool2x4 lhs, bool rhs)
		{
			return new bool2x4(lhs.c0 ^ rhs, lhs.c1 ^ rhs, lhs.c2 ^ rhs, lhs.c3 ^ rhs);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0001B97D File Offset: 0x00019B7D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2x4 operator ^(bool lhs, bool2x4 rhs)
		{
			return new bool2x4(lhs ^ rhs.c0, lhs ^ rhs.c1, lhs ^ rhs.c2, lhs ^ rhs.c3);
		}

		// Token: 0x17000020 RID: 32
		public unsafe bool2 this[int index]
		{
			get
			{
				fixed (bool2x4* ptr = &this)
				{
					return ref *(bool2*)(ptr + (IntPtr)index * (IntPtr)sizeof(bool2) / (IntPtr)sizeof(bool2x4));
				}
			}
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0001B9D0 File Offset: 0x00019BD0
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(bool2x4 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1) && this.c2.Equals(rhs.c2) && this.c3.Equals(rhs.c3);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0001BA2C File Offset: 0x00019C2C
		public override bool Equals(object o)
		{
			if (o is bool2x4)
			{
				bool2x4 rhs = (bool2x4)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0001BA51 File Offset: 0x00019C51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0001BA60 File Offset: 0x00019C60
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("bool2x4({0}, {1}, {2}, {3},  {4}, {5}, {6}, {7})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c2.x,
				this.c3.x,
				this.c0.y,
				this.c1.y,
				this.c2.y,
				this.c3.y
			});
		}

		// Token: 0x0400001E RID: 30
		public bool2 c0;

		// Token: 0x0400001F RID: 31
		public bool2 c1;

		// Token: 0x04000020 RID: 32
		public bool2 c2;

		// Token: 0x04000021 RID: 33
		public bool2 c3;
	}
}
