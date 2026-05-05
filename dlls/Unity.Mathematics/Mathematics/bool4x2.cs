using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200000E RID: 14
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct bool4x2 : IEquatable<bool4x2>
	{
		// Token: 0x06000A8F RID: 2703 RVA: 0x0002119D File Offset: 0x0001F39D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4x2(bool4 c0, bool4 c1)
		{
			this.c0 = c0;
			this.c1 = c1;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x000211AD File Offset: 0x0001F3AD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4x2(bool m00, bool m01, bool m10, bool m11, bool m20, bool m21, bool m30, bool m31)
		{
			this.c0 = new bool4(m00, m10, m20, m30);
			this.c1 = new bool4(m01, m11, m21, m31);
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x000211D2 File Offset: 0x0001F3D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool4x2(bool v)
		{
			this.c0 = v;
			this.c1 = v;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x000211EC File Offset: 0x0001F3EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool4x2(bool v)
		{
			return new bool4x2(v);
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x000211F4 File Offset: 0x0001F3F4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(bool4x2 lhs, bool4x2 rhs)
		{
			return new bool4x2(lhs.c0 == rhs.c0, lhs.c1 == rhs.c1);
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0002121D File Offset: 0x0001F41D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(bool4x2 lhs, bool rhs)
		{
			return new bool4x2(lhs.c0 == rhs, lhs.c1 == rhs);
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0002123C File Offset: 0x0001F43C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ==(bool lhs, bool4x2 rhs)
		{
			return new bool4x2(lhs == rhs.c0, lhs == rhs.c1);
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x0002125B File Offset: 0x0001F45B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(bool4x2 lhs, bool4x2 rhs)
		{
			return new bool4x2(lhs.c0 != rhs.c0, lhs.c1 != rhs.c1);
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x00021284 File Offset: 0x0001F484
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(bool4x2 lhs, bool rhs)
		{
			return new bool4x2(lhs.c0 != rhs, lhs.c1 != rhs);
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x000212A3 File Offset: 0x0001F4A3
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !=(bool lhs, bool4x2 rhs)
		{
			return new bool4x2(lhs != rhs.c0, lhs != rhs.c1);
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x000212C2 File Offset: 0x0001F4C2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator !(bool4x2 val)
		{
			return new bool4x2(!val.c0, !val.c1);
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x000212DF File Offset: 0x0001F4DF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator &(bool4x2 lhs, bool4x2 rhs)
		{
			return new bool4x2(lhs.c0 & rhs.c0, lhs.c1 & rhs.c1);
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x00021308 File Offset: 0x0001F508
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator &(bool4x2 lhs, bool rhs)
		{
			return new bool4x2(lhs.c0 & rhs, lhs.c1 & rhs);
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00021327 File Offset: 0x0001F527
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator &(bool lhs, bool4x2 rhs)
		{
			return new bool4x2(lhs & rhs.c0, lhs & rhs.c1);
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x00021346 File Offset: 0x0001F546
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator |(bool4x2 lhs, bool4x2 rhs)
		{
			return new bool4x2(lhs.c0 | rhs.c0, lhs.c1 | rhs.c1);
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0002136F File Offset: 0x0001F56F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator |(bool4x2 lhs, bool rhs)
		{
			return new bool4x2(lhs.c0 | rhs, lhs.c1 | rhs);
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x0002138E File Offset: 0x0001F58E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator |(bool lhs, bool4x2 rhs)
		{
			return new bool4x2(lhs | rhs.c0, lhs | rhs.c1);
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x000213AD File Offset: 0x0001F5AD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ^(bool4x2 lhs, bool4x2 rhs)
		{
			return new bool4x2(lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1);
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x000213D6 File Offset: 0x0001F5D6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ^(bool4x2 lhs, bool rhs)
		{
			return new bool4x2(lhs.c0 ^ rhs, lhs.c1 ^ rhs);
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x000213F5 File Offset: 0x0001F5F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4x2 operator ^(bool lhs, bool4x2 rhs)
		{
			return new bool4x2(lhs ^ rhs.c0, lhs ^ rhs.c1);
		}

		// Token: 0x170001EB RID: 491
		public unsafe bool4 this[int index]
		{
			get
			{
				fixed (bool4x2* ptr = &this)
				{
					return ref *(bool4*)(ptr + (IntPtr)index * (IntPtr)sizeof(bool4) / (IntPtr)sizeof(bool4x2));
				}
			}
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0002142F File Offset: 0x0001F62F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(bool4x2 rhs)
		{
			return this.c0.Equals(rhs.c0) && this.c1.Equals(rhs.c1);
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00021458 File Offset: 0x0001F658
		public override bool Equals(object o)
		{
			if (o is bool4x2)
			{
				bool4x2 rhs = (bool4x2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x0002147D File Offset: 0x0001F67D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0002148C File Offset: 0x0001F68C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("bool4x2({0}, {1},  {2}, {3},  {4}, {5},  {6}, {7})", new object[]
			{
				this.c0.x,
				this.c1.x,
				this.c0.y,
				this.c1.y,
				this.c0.z,
				this.c1.z,
				this.c0.w,
				this.c1.w
			});
		}

		// Token: 0x04000032 RID: 50
		public bool4 c0;

		// Token: 0x04000033 RID: 51
		public bool4 c1;
	}
}
