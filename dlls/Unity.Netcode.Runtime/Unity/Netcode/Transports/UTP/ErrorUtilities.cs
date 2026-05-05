using System;
using Unity.Collections;
using Unity.Networking.Transport.Error;

namespace Unity.Netcode.Transports.UTP
{
	// Token: 0x0200012C RID: 300
	public static class ErrorUtilities
	{
		// Token: 0x06000965 RID: 2405 RVA: 0x00023851 File Offset: 0x00021A51
		public static string ErrorToString(StatusCode error, ulong connectionId)
		{
			return ErrorUtilities.ErrorToString((int)error, connectionId);
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x0002385C File Offset: 0x00021A5C
		internal static string ErrorToString(int error, ulong connectionId)
		{
			return ErrorUtilities.ErrorToFixedString(error, connectionId).ToString();
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00023880 File Offset: 0x00021A80
		internal static FixedString128Bytes ErrorToFixedString(int error, ulong connectionId)
		{
			switch (error)
			{
			case -5:
				return ErrorUtilities.k_NetworkSendQueueFull;
			case -4:
				return ErrorUtilities.k_NetworkPacketOverflow;
			case -3:
				return FixedString.Format(ErrorUtilities.k_NetworkStateMismatch, connectionId);
			case -2:
				return FixedString.Format(ErrorUtilities.k_NetworkVersionMismatch, connectionId);
			case -1:
				return FixedString.Format(ErrorUtilities.k_NetworkIdMismatch, connectionId);
			case 0:
				return ErrorUtilities.k_NetworkSuccess;
			default:
				return FixedString.Format("Unknown error code {0}.", error);
			}
		}

		// Token: 0x0400039D RID: 925
		private static readonly FixedString128Bytes k_NetworkSuccess = "Success";

		// Token: 0x0400039E RID: 926
		private static readonly FixedString128Bytes k_NetworkIdMismatch = "Invalid connection ID {0}.";

		// Token: 0x0400039F RID: 927
		private static readonly FixedString128Bytes k_NetworkVersionMismatch = "Connection ID is invalid. Likely caused by sending on stale connection {0}.";

		// Token: 0x040003A0 RID: 928
		private static readonly FixedString128Bytes k_NetworkStateMismatch = "Connection state is invalid. Likely caused by sending on connection {0} which is stale or still connecting.";

		// Token: 0x040003A1 RID: 929
		private static readonly FixedString128Bytes k_NetworkPacketOverflow = "Packet is too large to be allocated by the transport.";

		// Token: 0x040003A2 RID: 930
		private static readonly FixedString128Bytes k_NetworkSendQueueFull = "Unable to queue packet in the transport. Likely caused by send queue size ('Max Send Queue Size') being too small.";
	}
}
