using System;

namespace Steamworks
{
	// Token: 0x02000197 RID: 407
	[Serializable]
	public struct HTTPRequestHandle : IEquatable<HTTPRequestHandle>, IComparable<HTTPRequestHandle>
	{
		// Token: 0x060009AE RID: 2478 RVA: 0x0000ECC3 File Offset: 0x0000CEC3
		public HTTPRequestHandle(uint value)
		{
			this.m_HTTPRequestHandle = value;
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0000ECCC File Offset: 0x0000CECC
		public override string ToString()
		{
			return this.m_HTTPRequestHandle.ToString();
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0000ECD9 File Offset: 0x0000CED9
		public override bool Equals(object other)
		{
			return other is HTTPRequestHandle && this == (HTTPRequestHandle)other;
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0000ECF6 File Offset: 0x0000CEF6
		public override int GetHashCode()
		{
			return this.m_HTTPRequestHandle.GetHashCode();
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0000ED03 File Offset: 0x0000CF03
		public static bool operator ==(HTTPRequestHandle x, HTTPRequestHandle y)
		{
			return x.m_HTTPRequestHandle == y.m_HTTPRequestHandle;
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0000ED13 File Offset: 0x0000CF13
		public static bool operator !=(HTTPRequestHandle x, HTTPRequestHandle y)
		{
			return !(x == y);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x0000ED1F File Offset: 0x0000CF1F
		public static explicit operator HTTPRequestHandle(uint value)
		{
			return new HTTPRequestHandle(value);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0000ED27 File Offset: 0x0000CF27
		public static explicit operator uint(HTTPRequestHandle that)
		{
			return that.m_HTTPRequestHandle;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0000ED2F File Offset: 0x0000CF2F
		public bool Equals(HTTPRequestHandle other)
		{
			return this.m_HTTPRequestHandle == other.m_HTTPRequestHandle;
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x0000ED3F File Offset: 0x0000CF3F
		public int CompareTo(HTTPRequestHandle other)
		{
			return this.m_HTTPRequestHandle.CompareTo(other.m_HTTPRequestHandle);
		}

		// Token: 0x04000A62 RID: 2658
		public static readonly HTTPRequestHandle Invalid = new HTTPRequestHandle(0U);

		// Token: 0x04000A63 RID: 2659
		public uint m_HTTPRequestHandle;
	}
}
