using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000277 RID: 631
	internal struct XStoreProductInterop
	{
		// Token: 0x04000893 RID: 2195
		[MarshalAs(UnmanagedType.LPStr)]
		internal string storeId;

		// Token: 0x04000894 RID: 2196
		[MarshalAs(UnmanagedType.LPStr)]
		internal string title;

		// Token: 0x04000895 RID: 2197
		[MarshalAs(UnmanagedType.LPStr)]
		internal string description;

		// Token: 0x04000896 RID: 2198
		[MarshalAs(UnmanagedType.LPStr)]
		internal string language;

		// Token: 0x04000897 RID: 2199
		[MarshalAs(UnmanagedType.LPStr)]
		internal string inAppOfferToken;

		// Token: 0x04000898 RID: 2200
		[MarshalAs(UnmanagedType.LPStr)]
		internal string linkUri;

		// Token: 0x04000899 RID: 2201
		internal XStoreProductKind productKind;

		// Token: 0x0400089A RID: 2202
		internal XStorePrice price;

		// Token: 0x0400089B RID: 2203
		[MarshalAs(UnmanagedType.I1)]
		internal bool hasDigitalDownload;

		// Token: 0x0400089C RID: 2204
		[MarshalAs(UnmanagedType.I1)]
		internal bool isInUserCollection;

		// Token: 0x0400089D RID: 2205
		internal uint keywordsCount;

		// Token: 0x0400089E RID: 2206
		internal IntPtr keywords;

		// Token: 0x0400089F RID: 2207
		internal uint skusCount;

		// Token: 0x040008A0 RID: 2208
		internal IntPtr skus;

		// Token: 0x040008A1 RID: 2209
		internal uint imagesCount;

		// Token: 0x040008A2 RID: 2210
		internal IntPtr images;

		// Token: 0x040008A3 RID: 2211
		internal uint videosCount;

		// Token: 0x040008A4 RID: 2212
		internal IntPtr videos;
	}
}
