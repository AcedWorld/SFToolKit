using System;

namespace Steamworks
{
	// Token: 0x02000196 RID: 406
	[Serializable]
	public struct HTTPCookieContainerHandle : IEquatable<HTTPCookieContainerHandle>, IComparable<HTTPCookieContainerHandle>
	{
		// Token: 0x060009A3 RID: 2467 RVA: 0x0000EC27 File Offset: 0x0000CE27
		public HTTPCookieContainerHandle(uint value)
		{
			this.m_HTTPCookieContainerHandle = value;
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0000EC30 File Offset: 0x0000CE30
		public override string ToString()
		{
			return this.m_HTTPCookieContainerHandle.ToString();
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0000EC3D File Offset: 0x0000CE3D
		public override bool Equals(object other)
		{
			return other is HTTPCookieContainerHandle && this == (HTTPCookieContainerHandle)other;
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0000EC5A File Offset: 0x0000CE5A
		public override int GetHashCode()
		{
			return this.m_HTTPCookieContainerHandle.GetHashCode();
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x0000EC67 File Offset: 0x0000CE67
		public static bool operator ==(HTTPCookieContainerHandle x, HTTPCookieContainerHandle y)
		{
			return x.m_HTTPCookieContainerHandle == y.m_HTTPCookieContainerHandle;
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0000EC77 File Offset: 0x0000CE77
		public static bool operator !=(HTTPCookieContainerHandle x, HTTPCookieContainerHandle y)
		{
			return !(x == y);
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0000EC83 File Offset: 0x0000CE83
		public static explicit operator HTTPCookieContainerHandle(uint value)
		{
			return new HTTPCookieContainerHandle(value);
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0000EC8B File Offset: 0x0000CE8B
		public static explicit operator uint(HTTPCookieContainerHandle that)
		{
			return that.m_HTTPCookieContainerHandle;
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0000EC93 File Offset: 0x0000CE93
		public bool Equals(HTTPCookieContainerHandle other)
		{
			return this.m_HTTPCookieContainerHandle == other.m_HTTPCookieContainerHandle;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0000ECA3 File Offset: 0x0000CEA3
		public int CompareTo(HTTPCookieContainerHandle other)
		{
			return this.m_HTTPCookieContainerHandle.CompareTo(other.m_HTTPCookieContainerHandle);
		}

		// Token: 0x04000A60 RID: 2656
		public static readonly HTTPCookieContainerHandle Invalid = new HTTPCookieContainerHandle(0U);

		// Token: 0x04000A61 RID: 2657
		public uint m_HTTPCookieContainerHandle;
	}
}
