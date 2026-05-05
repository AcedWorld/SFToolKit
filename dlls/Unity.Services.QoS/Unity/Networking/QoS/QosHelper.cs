using System;

namespace Unity.Networking.QoS
{
	// Token: 0x02000009 RID: 9
	internal static class QosHelper
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00002C93 File Offset: 0x00000E93
		internal static bool WouldBlock(ulong errorcode)
		{
			return errorcode == 10035UL || errorcode == 10060UL || errorcode == 11UL || errorcode == 35UL;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002CB5 File Offset: 0x00000EB5
		internal static bool ExpiredUtc(DateTime timeUtc)
		{
			return DateTime.UtcNow > timeUtc;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002CC4 File Offset: 0x00000EC4
		internal static string Since(DateTime dt)
		{
			return string.Format("{0:F0}ms", (DateTime.UtcNow - dt).TotalMilliseconds);
		}

		// Token: 0x0400001E RID: 30
		private const ulong WSAEWOULDBLOCK = 10035UL;

		// Token: 0x0400001F RID: 31
		private const ulong WSAETIMEDOUT = 10060UL;

		// Token: 0x04000020 RID: 32
		private const ulong EAGAIN_EWOULDBLOCK_1 = 11UL;

		// Token: 0x04000021 RID: 33
		private const ulong EAGAIN_EWOULDBLOCK_2 = 35UL;
	}
}
