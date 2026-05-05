using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000233 RID: 563
	internal struct XblTitleStorageBlobMetadata
	{
		// Token: 0x040007D8 RID: 2008
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 771)]
		internal string blobPath;

		// Token: 0x040007D9 RID: 2009
		internal XblTitleStorageBlobType blobType;

		// Token: 0x040007DA RID: 2010
		internal XblTitleStorageType storageType;

		// Token: 0x040007DB RID: 2011
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 387)]
		internal string displayName;

		// Token: 0x040007DC RID: 2012
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 54)]
		internal string eTag;

		// Token: 0x040007DD RID: 2013
		internal TimeT clientTimestamp;

		// Token: 0x040007DE RID: 2014
		internal SizeT length;

		// Token: 0x040007DF RID: 2015
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
		internal string serviceConfigurationId;

		// Token: 0x040007E0 RID: 2016
		internal ulong xboxUserId;
	}
}
