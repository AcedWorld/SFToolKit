using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Unity.Mathematics
{
	// Token: 0x0200002D RID: 45
	[DebuggerTypeProxy(typeof(int2.DebuggerProxy))]
	[Il2CppEagerStaticClassConstruction]
	[Serializable]
	public struct int2 : IEquatable<int2>, IFormattable
	{
		// Token: 0x06001822 RID: 6178 RVA: 0x00042EB5 File Offset: 0x000410B5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		// Token: 0x06001823 RID: 6179 RVA: 0x00042EC5 File Offset: 0x000410C5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(int2 xy)
		{
			this.x = xy.x;
			this.y = xy.y;
		}

		// Token: 0x06001824 RID: 6180 RVA: 0x00042EDF File Offset: 0x000410DF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(int v)
		{
			this.x = v;
			this.y = v;
		}

		// Token: 0x06001825 RID: 6181 RVA: 0x00042EEF File Offset: 0x000410EF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(bool v)
		{
			this.x = (v ? 1 : 0);
			this.y = (v ? 1 : 0);
		}

		// Token: 0x06001826 RID: 6182 RVA: 0x00042F0B File Offset: 0x0004110B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(bool2 v)
		{
			this.x = (v.x ? 1 : 0);
			this.y = (v.y ? 1 : 0);
		}

		// Token: 0x06001827 RID: 6183 RVA: 0x00042F31 File Offset: 0x00041131
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(uint v)
		{
			this.x = (int)v;
			this.y = (int)v;
		}

		// Token: 0x06001828 RID: 6184 RVA: 0x00042F41 File Offset: 0x00041141
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(uint2 v)
		{
			this.x = (int)v.x;
			this.y = (int)v.y;
		}

		// Token: 0x06001829 RID: 6185 RVA: 0x00042F5B File Offset: 0x0004115B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(float v)
		{
			this.x = (int)v;
			this.y = (int)v;
		}

		// Token: 0x0600182A RID: 6186 RVA: 0x00042F6D File Offset: 0x0004116D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(float2 v)
		{
			this.x = (int)v.x;
			this.y = (int)v.y;
		}

		// Token: 0x0600182B RID: 6187 RVA: 0x00042F89 File Offset: 0x00041189
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(double v)
		{
			this.x = (int)v;
			this.y = (int)v;
		}

		// Token: 0x0600182C RID: 6188 RVA: 0x00042F9B File Offset: 0x0004119B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int2(double2 v)
		{
			this.x = (int)v.x;
			this.y = (int)v.y;
		}

		// Token: 0x0600182D RID: 6189 RVA: 0x00042FB7 File Offset: 0x000411B7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int2(int v)
		{
			return new int2(v);
		}

		// Token: 0x0600182E RID: 6190 RVA: 0x00042FBF File Offset: 0x000411BF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2(bool v)
		{
			return new int2(v);
		}

		// Token: 0x0600182F RID: 6191 RVA: 0x00042FC7 File Offset: 0x000411C7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2(bool2 v)
		{
			return new int2(v);
		}

		// Token: 0x06001830 RID: 6192 RVA: 0x00042FCF File Offset: 0x000411CF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2(uint v)
		{
			return new int2(v);
		}

		// Token: 0x06001831 RID: 6193 RVA: 0x00042FD7 File Offset: 0x000411D7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2(uint2 v)
		{
			return new int2(v);
		}

		// Token: 0x06001832 RID: 6194 RVA: 0x00042FDF File Offset: 0x000411DF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2(float v)
		{
			return new int2(v);
		}

		// Token: 0x06001833 RID: 6195 RVA: 0x00042FE7 File Offset: 0x000411E7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2(float2 v)
		{
			return new int2(v);
		}

		// Token: 0x06001834 RID: 6196 RVA: 0x00042FEF File Offset: 0x000411EF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2(double v)
		{
			return new int2(v);
		}

		// Token: 0x06001835 RID: 6197 RVA: 0x00042FF7 File Offset: 0x000411F7
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int2(double2 v)
		{
			return new int2(v);
		}

		// Token: 0x06001836 RID: 6198 RVA: 0x00042FFF File Offset: 0x000411FF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator *(int2 lhs, int2 rhs)
		{
			return new int2(lhs.x * rhs.x, lhs.y * rhs.y);
		}

		// Token: 0x06001837 RID: 6199 RVA: 0x00043020 File Offset: 0x00041220
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator *(int2 lhs, int rhs)
		{
			return new int2(lhs.x * rhs, lhs.y * rhs);
		}

		// Token: 0x06001838 RID: 6200 RVA: 0x00043037 File Offset: 0x00041237
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator *(int lhs, int2 rhs)
		{
			return new int2(lhs * rhs.x, lhs * rhs.y);
		}

		// Token: 0x06001839 RID: 6201 RVA: 0x0004304E File Offset: 0x0004124E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator +(int2 lhs, int2 rhs)
		{
			return new int2(lhs.x + rhs.x, lhs.y + rhs.y);
		}

		// Token: 0x0600183A RID: 6202 RVA: 0x0004306F File Offset: 0x0004126F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator +(int2 lhs, int rhs)
		{
			return new int2(lhs.x + rhs, lhs.y + rhs);
		}

		// Token: 0x0600183B RID: 6203 RVA: 0x00043086 File Offset: 0x00041286
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator +(int lhs, int2 rhs)
		{
			return new int2(lhs + rhs.x, lhs + rhs.y);
		}

		// Token: 0x0600183C RID: 6204 RVA: 0x0004309D File Offset: 0x0004129D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator -(int2 lhs, int2 rhs)
		{
			return new int2(lhs.x - rhs.x, lhs.y - rhs.y);
		}

		// Token: 0x0600183D RID: 6205 RVA: 0x000430BE File Offset: 0x000412BE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator -(int2 lhs, int rhs)
		{
			return new int2(lhs.x - rhs, lhs.y - rhs);
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x000430D5 File Offset: 0x000412D5
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator -(int lhs, int2 rhs)
		{
			return new int2(lhs - rhs.x, lhs - rhs.y);
		}

		// Token: 0x0600183F RID: 6207 RVA: 0x000430EC File Offset: 0x000412EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator /(int2 lhs, int2 rhs)
		{
			return new int2(lhs.x / rhs.x, lhs.y / rhs.y);
		}

		// Token: 0x06001840 RID: 6208 RVA: 0x0004310D File Offset: 0x0004130D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator /(int2 lhs, int rhs)
		{
			return new int2(lhs.x / rhs, lhs.y / rhs);
		}

		// Token: 0x06001841 RID: 6209 RVA: 0x00043124 File Offset: 0x00041324
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator /(int lhs, int2 rhs)
		{
			return new int2(lhs / rhs.x, lhs / rhs.y);
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x0004313B File Offset: 0x0004133B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator %(int2 lhs, int2 rhs)
		{
			return new int2(lhs.x % rhs.x, lhs.y % rhs.y);
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x0004315C File Offset: 0x0004135C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator %(int2 lhs, int rhs)
		{
			return new int2(lhs.x % rhs, lhs.y % rhs);
		}

		// Token: 0x06001844 RID: 6212 RVA: 0x00043173 File Offset: 0x00041373
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator %(int lhs, int2 rhs)
		{
			return new int2(lhs % rhs.x, lhs % rhs.y);
		}

		// Token: 0x06001845 RID: 6213 RVA: 0x0004318C File Offset: 0x0004138C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator ++(int2 val)
		{
			int num = val.x + 1;
			val.x = num;
			int num2 = num;
			num = val.y + 1;
			val.y = num;
			return new int2(num2, num);
		}

		// Token: 0x06001846 RID: 6214 RVA: 0x000431BC File Offset: 0x000413BC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator --(int2 val)
		{
			int num = val.x - 1;
			val.x = num;
			int num2 = num;
			num = val.y - 1;
			val.y = num;
			return new int2(num2, num);
		}

		// Token: 0x06001847 RID: 6215 RVA: 0x000431EC File Offset: 0x000413EC
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(int2 lhs, int2 rhs)
		{
			return new bool2(lhs.x < rhs.x, lhs.y < rhs.y);
		}

		// Token: 0x06001848 RID: 6216 RVA: 0x0004320F File Offset: 0x0004140F
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(int2 lhs, int rhs)
		{
			return new bool2(lhs.x < rhs, lhs.y < rhs);
		}

		// Token: 0x06001849 RID: 6217 RVA: 0x00043228 File Offset: 0x00041428
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(int lhs, int2 rhs)
		{
			return new bool2(lhs < rhs.x, lhs < rhs.y);
		}

		// Token: 0x0600184A RID: 6218 RVA: 0x00043241 File Offset: 0x00041441
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(int2 lhs, int2 rhs)
		{
			return new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);
		}

		// Token: 0x0600184B RID: 6219 RVA: 0x0004326A File Offset: 0x0004146A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(int2 lhs, int rhs)
		{
			return new bool2(lhs.x <= rhs, lhs.y <= rhs);
		}

		// Token: 0x0600184C RID: 6220 RVA: 0x00043289 File Offset: 0x00041489
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(int lhs, int2 rhs)
		{
			return new bool2(lhs <= rhs.x, lhs <= rhs.y);
		}

		// Token: 0x0600184D RID: 6221 RVA: 0x000432A8 File Offset: 0x000414A8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(int2 lhs, int2 rhs)
		{
			return new bool2(lhs.x > rhs.x, lhs.y > rhs.y);
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x000432CB File Offset: 0x000414CB
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(int2 lhs, int rhs)
		{
			return new bool2(lhs.x > rhs, lhs.y > rhs);
		}

		// Token: 0x0600184F RID: 6223 RVA: 0x000432E4 File Offset: 0x000414E4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(int lhs, int2 rhs)
		{
			return new bool2(lhs > rhs.x, lhs > rhs.y);
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x000432FD File Offset: 0x000414FD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(int2 lhs, int2 rhs)
		{
			return new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);
		}

		// Token: 0x06001851 RID: 6225 RVA: 0x00043326 File Offset: 0x00041526
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(int2 lhs, int rhs)
		{
			return new bool2(lhs.x >= rhs, lhs.y >= rhs);
		}

		// Token: 0x06001852 RID: 6226 RVA: 0x00043345 File Offset: 0x00041545
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(int lhs, int2 rhs)
		{
			return new bool2(lhs >= rhs.x, lhs >= rhs.y);
		}

		// Token: 0x06001853 RID: 6227 RVA: 0x00043364 File Offset: 0x00041564
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator -(int2 val)
		{
			return new int2(-val.x, -val.y);
		}

		// Token: 0x06001854 RID: 6228 RVA: 0x00043379 File Offset: 0x00041579
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator +(int2 val)
		{
			return new int2(val.x, val.y);
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x0004338C File Offset: 0x0004158C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator <<(int2 x, int n)
		{
			return new int2(x.x << n, x.y << n);
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x000433A9 File Offset: 0x000415A9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator >>(int2 x, int n)
		{
			return new int2(x.x >> n, x.y >> n);
		}

		// Token: 0x06001857 RID: 6231 RVA: 0x000433C6 File Offset: 0x000415C6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(int2 lhs, int2 rhs)
		{
			return new bool2(lhs.x == rhs.x, lhs.y == rhs.y);
		}

		// Token: 0x06001858 RID: 6232 RVA: 0x000433E9 File Offset: 0x000415E9
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(int2 lhs, int rhs)
		{
			return new bool2(lhs.x == rhs, lhs.y == rhs);
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x00043402 File Offset: 0x00041602
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(int lhs, int2 rhs)
		{
			return new bool2(lhs == rhs.x, lhs == rhs.y);
		}

		// Token: 0x0600185A RID: 6234 RVA: 0x0004341B File Offset: 0x0004161B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(int2 lhs, int2 rhs)
		{
			return new bool2(lhs.x != rhs.x, lhs.y != rhs.y);
		}

		// Token: 0x0600185B RID: 6235 RVA: 0x00043444 File Offset: 0x00041644
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(int2 lhs, int rhs)
		{
			return new bool2(lhs.x != rhs, lhs.y != rhs);
		}

		// Token: 0x0600185C RID: 6236 RVA: 0x00043463 File Offset: 0x00041663
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(int lhs, int2 rhs)
		{
			return new bool2(lhs != rhs.x, lhs != rhs.y);
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x00043482 File Offset: 0x00041682
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator ~(int2 val)
		{
			return new int2(~val.x, ~val.y);
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x00043497 File Offset: 0x00041697
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator &(int2 lhs, int2 rhs)
		{
			return new int2(lhs.x & rhs.x, lhs.y & rhs.y);
		}

		// Token: 0x0600185F RID: 6239 RVA: 0x000434B8 File Offset: 0x000416B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator &(int2 lhs, int rhs)
		{
			return new int2(lhs.x & rhs, lhs.y & rhs);
		}

		// Token: 0x06001860 RID: 6240 RVA: 0x000434CF File Offset: 0x000416CF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator &(int lhs, int2 rhs)
		{
			return new int2(lhs & rhs.x, lhs & rhs.y);
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x000434E6 File Offset: 0x000416E6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator |(int2 lhs, int2 rhs)
		{
			return new int2(lhs.x | rhs.x, lhs.y | rhs.y);
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x00043507 File Offset: 0x00041707
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator |(int2 lhs, int rhs)
		{
			return new int2(lhs.x | rhs, lhs.y | rhs);
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x0004351E File Offset: 0x0004171E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator |(int lhs, int2 rhs)
		{
			return new int2(lhs | rhs.x, lhs | rhs.y);
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x00043535 File Offset: 0x00041735
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator ^(int2 lhs, int2 rhs)
		{
			return new int2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);
		}

		// Token: 0x06001865 RID: 6245 RVA: 0x00043556 File Offset: 0x00041756
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator ^(int2 lhs, int rhs)
		{
			return new int2(lhs.x ^ rhs, lhs.y ^ rhs);
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x0004356D File Offset: 0x0004176D
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator ^(int lhs, int2 rhs)
		{
			return new int2(lhs ^ rhs.x, lhs ^ rhs.y);
		}

		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x06001867 RID: 6247 RVA: 0x00043584 File Offset: 0x00041784
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.x, this.x);
			}
		}

		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x06001868 RID: 6248 RVA: 0x000435A3 File Offset: 0x000417A3
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.x, this.y);
			}
		}

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x06001869 RID: 6249 RVA: 0x000435C2 File Offset: 0x000417C2
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.y, this.x);
			}
		}

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x0600186A RID: 6250 RVA: 0x000435E1 File Offset: 0x000417E1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.x, this.y, this.y);
			}
		}

		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x0600186B RID: 6251 RVA: 0x00043600 File Offset: 0x00041800
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.x, this.x);
			}
		}

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x0600186C RID: 6252 RVA: 0x0004361F File Offset: 0x0004181F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.x, this.y);
			}
		}

		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x0600186D RID: 6253 RVA: 0x0004363E File Offset: 0x0004183E
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.y, this.x);
			}
		}

		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x0600186E RID: 6254 RVA: 0x0004365D File Offset: 0x0004185D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.x, this.y, this.y, this.y);
			}
		}

		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x0600186F RID: 6255 RVA: 0x0004367C File Offset: 0x0004187C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.x, this.x);
			}
		}

		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x06001870 RID: 6256 RVA: 0x0004369B File Offset: 0x0004189B
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.x, this.y);
			}
		}

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x06001871 RID: 6257 RVA: 0x000436BA File Offset: 0x000418BA
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.y, this.x);
			}
		}

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x06001872 RID: 6258 RVA: 0x000436D9 File Offset: 0x000418D9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.x, this.y, this.y);
			}
		}

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x06001873 RID: 6259 RVA: 0x000436F8 File Offset: 0x000418F8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.x, this.x);
			}
		}

		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x06001874 RID: 6260 RVA: 0x00043717 File Offset: 0x00041917
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.x, this.y);
			}
		}

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x06001875 RID: 6261 RVA: 0x00043736 File Offset: 0x00041936
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.y, this.x);
			}
		}

		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x06001876 RID: 6262 RVA: 0x00043755 File Offset: 0x00041955
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int4 yyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int4(this.y, this.y, this.y, this.y);
			}
		}

		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x06001877 RID: 6263 RVA: 0x00043774 File Offset: 0x00041974
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.x, this.x);
			}
		}

		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x06001878 RID: 6264 RVA: 0x0004378D File Offset: 0x0004198D
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.x, this.y);
			}
		}

		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x06001879 RID: 6265 RVA: 0x000437A6 File Offset: 0x000419A6
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.y, this.x);
			}
		}

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x0600187A RID: 6266 RVA: 0x000437BF File Offset: 0x000419BF
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 xyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.x, this.y, this.y);
			}
		}

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x0600187B RID: 6267 RVA: 0x000437D8 File Offset: 0x000419D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.x, this.x);
			}
		}

		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x0600187C RID: 6268 RVA: 0x000437F1 File Offset: 0x000419F1
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.x, this.y);
			}
		}

		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x0600187D RID: 6269 RVA: 0x0004380A File Offset: 0x00041A0A
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.y, this.x);
			}
		}

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x0600187E RID: 6270 RVA: 0x00043823 File Offset: 0x00041A23
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int3 yyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int3(this.y, this.y, this.y);
			}
		}

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x0600187F RID: 6271 RVA: 0x0004383C File Offset: 0x00041A3C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.x, this.x);
			}
		}

		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x06001880 RID: 6272 RVA: 0x0004384F File Offset: 0x00041A4F
		// (set) Token: 0x06001881 RID: 6273 RVA: 0x00043862 File Offset: 0x00041A62
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 xy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.x, this.y);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.x = value.x;
				this.y = value.y;
			}
		}

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x06001882 RID: 6274 RVA: 0x0004387C File Offset: 0x00041A7C
		// (set) Token: 0x06001883 RID: 6275 RVA: 0x0004388F File Offset: 0x00041A8F
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 yx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.y, this.x);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this.y = value.x;
				this.x = value.y;
			}
		}

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x06001884 RID: 6276 RVA: 0x000438A9 File Offset: 0x00041AA9
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int2 yy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return new int2(this.y, this.y);
			}
		}

		// Token: 0x170007CC RID: 1996
		public unsafe int this[int index]
		{
			get
			{
				fixed (int2* ptr = &this)
				{
					return ((int*)ptr)[index];
				}
			}
			set
			{
				fixed (int* ptr = &this.x)
				{
					ptr[index] = value;
				}
			}
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x000438F4 File Offset: 0x00041AF4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(int2 rhs)
		{
			return this.x == rhs.x && this.y == rhs.y;
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x00043914 File Offset: 0x00041B14
		public override bool Equals(object o)
		{
			if (o is int2)
			{
				int2 rhs = (int2)o;
				return this.Equals(rhs);
			}
			return false;
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x00043939 File Offset: 0x00041B39
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return (int)math.hash(this);
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x00043946 File Offset: 0x00041B46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("int2({0}, {1})", this.x, this.y);
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x00043968 File Offset: 0x00041B68
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("int2({0}, {1})", this.x.ToString(format, formatProvider), this.y.ToString(format, formatProvider));
		}

		// Token: 0x040000AF RID: 175
		public int x;

		// Token: 0x040000B0 RID: 176
		public int y;

		// Token: 0x040000B1 RID: 177
		public static readonly int2 zero;

		// Token: 0x02000060 RID: 96
		internal sealed class DebuggerProxy
		{
			// Token: 0x06002475 RID: 9333 RVA: 0x00067708 File Offset: 0x00065908
			public DebuggerProxy(int2 v)
			{
				this.x = v.x;
				this.y = v.y;
			}

			// Token: 0x0400015E RID: 350
			public int x;

			// Token: 0x0400015F RID: 351
			public int y;
		}
	}
}
