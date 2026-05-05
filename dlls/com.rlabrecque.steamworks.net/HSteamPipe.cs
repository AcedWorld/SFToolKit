using System;

namespace Steamworks
{
	// Token: 0x020001C4 RID: 452
	[Serializable]
	public struct HSteamPipe : IEquatable<HSteamPipe>, IComparable<HSteamPipe>
	{
		// Token: 0x06000B4B RID: 2891 RVA: 0x00010526 File Offset: 0x0000E726
		public HSteamPipe(int value)
		{
			this.m_HSteamPipe = value;
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x0001052F File Offset: 0x0000E72F
		public override string ToString()
		{
			return this.m_HSteamPipe.ToString();
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0001053C File Offset: 0x0000E73C
		public override bool Equals(object other)
		{
			return other is HSteamPipe && this == (HSteamPipe)other;
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x00010559 File Offset: 0x0000E759
		public override int GetHashCode()
		{
			return this.m_HSteamPipe.GetHashCode();
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x00010566 File Offset: 0x0000E766
		public static bool operator ==(HSteamPipe x, HSteamPipe y)
		{
			return x.m_HSteamPipe == y.m_HSteamPipe;
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x00010576 File Offset: 0x0000E776
		public static bool operator !=(HSteamPipe x, HSteamPipe y)
		{
			return !(x == y);
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x00010582 File Offset: 0x0000E782
		public static explicit operator HSteamPipe(int value)
		{
			return new HSteamPipe(value);
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0001058A File Offset: 0x0000E78A
		public static explicit operator int(HSteamPipe that)
		{
			return that.m_HSteamPipe;
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x00010592 File Offset: 0x0000E792
		public bool Equals(HSteamPipe other)
		{
			return this.m_HSteamPipe == other.m_HSteamPipe;
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x000105A2 File Offset: 0x0000E7A2
		public int CompareTo(HSteamPipe other)
		{
			return this.m_HSteamPipe.CompareTo(other.m_HSteamPipe);
		}

		// Token: 0x04000AB9 RID: 2745
		public int m_HSteamPipe;
	}
}
