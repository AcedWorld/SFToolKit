using System;

namespace Steamworks
{
	// Token: 0x020001B8 RID: 440
	[Serializable]
	public struct ScreenshotHandle : IEquatable<ScreenshotHandle>, IComparable<ScreenshotHandle>
	{
		// Token: 0x06000AD1 RID: 2769 RVA: 0x0000FCC1 File Offset: 0x0000DEC1
		public ScreenshotHandle(uint value)
		{
			this.m_ScreenshotHandle = value;
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0000FCCA File Offset: 0x0000DECA
		public override string ToString()
		{
			return this.m_ScreenshotHandle.ToString();
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x0000FCD7 File Offset: 0x0000DED7
		public override bool Equals(object other)
		{
			return other is ScreenshotHandle && this == (ScreenshotHandle)other;
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x0000FCF4 File Offset: 0x0000DEF4
		public override int GetHashCode()
		{
			return this.m_ScreenshotHandle.GetHashCode();
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x0000FD01 File Offset: 0x0000DF01
		public static bool operator ==(ScreenshotHandle x, ScreenshotHandle y)
		{
			return x.m_ScreenshotHandle == y.m_ScreenshotHandle;
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x0000FD11 File Offset: 0x0000DF11
		public static bool operator !=(ScreenshotHandle x, ScreenshotHandle y)
		{
			return !(x == y);
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x0000FD1D File Offset: 0x0000DF1D
		public static explicit operator ScreenshotHandle(uint value)
		{
			return new ScreenshotHandle(value);
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0000FD25 File Offset: 0x0000DF25
		public static explicit operator uint(ScreenshotHandle that)
		{
			return that.m_ScreenshotHandle;
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x0000FD2D File Offset: 0x0000DF2D
		public bool Equals(ScreenshotHandle other)
		{
			return this.m_ScreenshotHandle == other.m_ScreenshotHandle;
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0000FD3D File Offset: 0x0000DF3D
		public int CompareTo(ScreenshotHandle other)
		{
			return this.m_ScreenshotHandle.CompareTo(other.m_ScreenshotHandle);
		}

		// Token: 0x04000AA4 RID: 2724
		public static readonly ScreenshotHandle Invalid = new ScreenshotHandle(0U);

		// Token: 0x04000AA5 RID: 2725
		public uint m_ScreenshotHandle;
	}
}
