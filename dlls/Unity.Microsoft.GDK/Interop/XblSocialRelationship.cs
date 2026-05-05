using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000226 RID: 550
	internal struct XblSocialRelationship
	{
		// Token: 0x06000DE0 RID: 3552 RVA: 0x0001126B File Offset: 0x0000F46B
		internal string[] GetSocialNetworks()
		{
			return Converters.PtrToClassArray<string, UTF8StringPtr>(this.socialNetworks, this.socialNetworksCount, (UTF8StringPtr s) => s.GetString());
		}

		// Token: 0x040007A3 RID: 1955
		internal readonly ulong xboxUserId;

		// Token: 0x040007A4 RID: 1956
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool isFavorite;

		// Token: 0x040007A5 RID: 1957
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool isFollowingCaller;

		// Token: 0x040007A6 RID: 1958
		internal readonly IntPtr socialNetworks;

		// Token: 0x040007A7 RID: 1959
		internal readonly SizeT socialNetworksCount;
	}
}
