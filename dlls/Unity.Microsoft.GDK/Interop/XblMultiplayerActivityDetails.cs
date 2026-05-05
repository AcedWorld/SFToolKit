using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001F7 RID: 503
	internal struct XblMultiplayerActivityDetails
	{
		// Token: 0x06000DA2 RID: 3490 RVA: 0x000106BC File Offset: 0x0000E8BC
		internal unsafe string GetHandleId()
		{
			byte[] handleId;
			byte* bytePointer;
			if ((handleId = this.HandleId) == null || handleId.Length == 0)
			{
				bytePointer = null;
			}
			else
			{
				bytePointer = &handleId[0];
			}
			return Converters.BytePointerToString(bytePointer, 40);
		}

		// Token: 0x040006B5 RID: 1717
		internal XblMultiplayerSessionReference SessionReference;

		// Token: 0x040006B6 RID: 1718
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
		internal byte[] HandleId;

		// Token: 0x040006B7 RID: 1719
		internal uint TitleId;

		// Token: 0x040006B8 RID: 1720
		internal XblMultiplayerSessionVisibility Visibility;

		// Token: 0x040006B9 RID: 1721
		internal XblMultiplayerSessionRestriction JoinRestriction;

		// Token: 0x040006BA RID: 1722
		[MarshalAs(UnmanagedType.U1)]
		internal bool Closed;

		// Token: 0x040006BB RID: 1723
		internal ulong OwnerXuid;

		// Token: 0x040006BC RID: 1724
		internal uint MaxMembersCount;

		// Token: 0x040006BD RID: 1725
		internal uint MembersCount;

		// Token: 0x040006BE RID: 1726
		internal UTF8StringPtr CustomSessionPropertiesJson;
	}
}
