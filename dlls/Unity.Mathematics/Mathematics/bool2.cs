using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x02000004 RID: 4
	[DebuggerTypeProxy(typeof(bool2.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct bool2 : IEquatable<bool2>
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020CB File Offset: 0x000002CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2(bool x, bool y)
		{
			this.x = x;
			this.y = y;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020DB File Offset: 0x000002DB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2(bool2 xy)
		{
			this.x = xy.x;
			this.y = xy.y;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020F5 File Offset: 0x000002F5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool2(bool v)
		{
			this.x = v;
			this.y = v;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002105 File Offset: 0x00000305
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool2(bool v)
		{
			return new bool2(v);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000210D File Offset: 0x0000030D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(bool2 lhs, bool2 rhs)
		{
			return new bool2(lhs.x == rhs.x, lhs.y == rhs.y);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002130 File Offset: 0x00000330
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(bool2 lhs, bool rhs)
		{
			return new bool2(lhs.x == rhs, lhs.y == rhs);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002149 File Offset: 0x00000349
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(bool lhs, bool2 rhs)
		{
			return new bool2(lhs == rhs.x, lhs == rhs.y);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002162 File Offset: 0x00000362
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(bool2 lhs, bool2 rhs)
		{
			return new bool2(lhs.x != rhs.x, lhs.y != rhs.y);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000218B File Offset: 0x0000038B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(bool2 lhs, bool rhs)
		{
			return new bool2(lhs.x != rhs, lhs.y != rhs);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021AA File Offset: 0x000003AA
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(bool lhs, bool2 rhs)
		{
			return new bool2(lhs != rhs.x, lhs != rhs.y);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021C9 File Offset: 0x000003C9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !(bool2 val)
		{
			return new bool2(!val.x, !val.y);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021E2 File Offset: 0x000003E2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator &(bool2 lhs, bool2 rhs)
		{
			return new bool2(lhs.x & rhs.x, lhs.y & rhs.y);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002203 File Offset: 0x00000403
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator &(bool2 lhs, bool rhs)
		{
			return new bool2(lhs.x && rhs, lhs.y && rhs);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000221A File Offset: 0x0000041A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator &(bool lhs, bool2 rhs)
		{
			return new bool2(lhs & rhs.x, lhs & rhs.y);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002231 File Offset: 0x00000431
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator |(bool2 lhs, bool2 rhs)
		{
			return new bool2(lhs.x | rhs.x, lhs.y | rhs.y);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002252 File Offset: 0x00000452
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator |(bool2 lhs, bool rhs)
		{
			return new bool2(lhs.x || rhs, lhs.y || rhs);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002269 File Offset: 0x00000469
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator |(bool lhs, bool2 rhs)
		{
			return new bool2(lhs | rhs.x, lhs | rhs.y);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002280 File Offset: 0x00000480
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ^(bool2 lhs, bool2 rhs)
		{
			return new bool2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000022A1 File Offset: 0x000004A1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ^(bool2 lhs, bool rhs)
		{
			return new bool2(lhs.x ^ rhs, lhs.y ^ rhs);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000022B8 File Offset: 0x000004B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ^(bool lhs, bool2 rhs)
		{
			return new bool2(lhs ^ rhs.x, lhs ^ rhs.y);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000022CF File Offset: 0x000004CF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000022EE File Offset: 0x000004EE
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001A RID: 26 RVA: 0x0000230D File Offset: 0x0000050D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001B RID: 27 RVA: 0x0000232C File Offset: 0x0000052C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000234B File Offset: 0x0000054B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001D RID: 29 RVA: 0x0000236A File Offset: 0x0000056A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002389 File Offset: 0x00000589
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000023A8 File Offset: 0x000005A8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000023C7 File Offset: 0x000005C7
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000023E6 File Offset: 0x000005E6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002405 File Offset: 0x00000605
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002424 File Offset: 0x00000624
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002443 File Offset: 0x00000643
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002462 File Offset: 0x00000662
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002481 File Offset: 0x00000681
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000024A0 File Offset: 0x000006A0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000024BF File Offset: 0x000006BF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.x, this.x);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000024D8 File Offset: 0x000006D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.x, this.y);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000024F1 File Offset: 0x000006F1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.y, this.x);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002B RID: 43 RVA: 0x0000250A File Offset: 0x0000070A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.x, this.y, this.y);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002523 File Offset: 0x00000723
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.x, this.x);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002D RID: 45 RVA: 0x0000253C File Offset: 0x0000073C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.x, this.y);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002555 File Offset: 0x00000755
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.y, this.x);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600002F RID: 47 RVA: 0x0000256E File Offset: 0x0000076E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool3(this.y, this.y, this.y);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002587 File Offset: 0x00000787
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.x, this.x);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000031 RID: 49 RVA: 0x0000259A File Offset: 0x0000079A
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000025AD File Offset: 0x000007AD
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

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000025C7 File Offset: 0x000007C7
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000025DA File Offset: 0x000007DA
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

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000025F4 File Offset: 0x000007F4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new bool2(this.y, this.y);
			}
		}

		// Token: 0x1700001D RID: 29
		public unsafe bool this[int index]
		{
			get
			{
				fixed (bool2* ptr = &this)
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

		// Token: 0x06000038 RID: 56 RVA: 0x00002639 File Offset: 0x00000839
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(bool2 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000265C File Offset: 0x0000085C
		public override bool Equals(object o)
		{
			if (o is bool2)
			{
				bool2 rhs = (bool2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002681 File Offset: 0x00000881
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000268E File Offset: 0x0000088E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("bool2({0}, {1})", this.x, this.y);
		}

		// Token: 0x04000001 RID: 1
		[MarshalAs(UnmanagedType.U1)]
		public bool x;

		// Token: 0x04000002 RID: 2
		[MarshalAs(UnmanagedType.U1)]
		public bool y;

		// Token: 0x02000050 RID: 80
		internal sealed class DebuggerProxy
		{
			// Token: 0x06002469 RID: 9321 RVA: 0x000674F8 File Offset: 0x000656F8
			public DebuggerProxy(bool2 v)
			{
				this.x = v.x;
				this.y = v.y;
			}

			// Token: 0x04000125 RID: 293
			public bool x;

			// Token: 0x04000126 RID: 294
			public bool y;
		}
	}
}
