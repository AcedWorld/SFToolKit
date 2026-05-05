using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000276 RID: 630
	internal struct XStoreSkuInterop
	{
		// Token: 0x04000881 RID: 2177
		[MarshalAs(UnmanagedType.LPStr)]
		internal string skuId;

		// Token: 0x04000882 RID: 2178
		[MarshalAs(UnmanagedType.LPStr)]
		internal string title;

		// Token: 0x04000883 RID: 2179
		[MarshalAs(UnmanagedType.LPStr)]
		internal string description;

		// Token: 0x04000884 RID: 2180
		[MarshalAs(UnmanagedType.LPStr)]
		internal string language;

		// Token: 0x04000885 RID: 2181
		internal XStorePrice price;

		// Token: 0x04000886 RID: 2182
		[MarshalAs(UnmanagedType.I1)]
		internal bool isTrial;

		// Token: 0x04000887 RID: 2183
		[MarshalAs(UnmanagedType.I1)]
		internal bool isInUserCollection;

		// Token: 0x04000888 RID: 2184
		internal XStoreCollectionData collectionData;

		// Token: 0x04000889 RID: 2185
		[MarshalAs(UnmanagedType.I1)]
		internal bool isSubscription;

		// Token: 0x0400088A RID: 2186
		internal XStoreSubscriptionInfo subscriptionInfo;

		// Token: 0x0400088B RID: 2187
		internal uint bundledSkusCount;

		// Token: 0x0400088C RID: 2188
		internal IntPtr bundledSkus;

		// Token: 0x0400088D RID: 2189
		internal uint imagesCount;

		// Token: 0x0400088E RID: 2190
		internal IntPtr images;

		// Token: 0x0400088F RID: 2191
		internal uint videosCount;

		// Token: 0x04000890 RID: 2192
		internal IntPtr videos;

		// Token: 0x04000891 RID: 2193
		internal uint availabilitiesCount;

		// Token: 0x04000892 RID: 2194
		internal IntPtr availabilities;
	}
}
