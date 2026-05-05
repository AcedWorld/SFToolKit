using System;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x0200009A RID: 154
	internal static class ConnectionAddressExtensions
	{
		// Token: 0x06000286 RID: 646 RVA: 0x0000DE38 File Offset: 0x0000C038
		public unsafe static ref RelayAllocationId AsRelayAllocationId(this NetworkInterfaceEndPoint address)
		{
			fixed (byte* ptr = &address.data.FixedElementField)
			{
				return ref *(RelayAllocationId*)ptr;
			}
		}
	}
}
