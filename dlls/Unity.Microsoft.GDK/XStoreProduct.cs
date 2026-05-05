using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200017F RID: 383
	[MovedFrom("Unity.GameCore")]
	public class XStoreProduct
	{
		// Token: 0x06000949 RID: 2377 RVA: 0x0000E97C File Offset: 0x0000CB7C
		internal XStoreProduct(ref XStoreProductInterop interop)
		{
			this.StoreId = interop.storeId;
			this.Title = interop.title;
			this.Description = interop.description;
			this.Language = interop.language;
			this.InAppOfferToken = interop.inAppOfferToken;
			this.LinkUri = interop.linkUri;
			this.ProductKind = interop.productKind;
			this.Price = new XStorePrice(interop.price);
			this.HasDigitalDownload = interop.hasDigitalDownload;
			this.IsInUserCollection = interop.isInUserCollection;
			this.Keywords = InteropHelpers.MarshalStringArrayAnsi(interop.keywords, interop.keywordsCount);
			this.Skus = InteropHelpers.MarshalArray<XStoreSkuInterop, XStoreSku>(interop.skus, interop.skusCount, (XStoreSkuInterop skuInterop) => new XStoreSku(ref skuInterop));
			this.Images = InteropHelpers.MarshalArray<XStoreImage, XStoreImage>(interop.images, interop.imagesCount, (XStoreImage imageInterop) => new XStoreImage(imageInterop));
			this.Videos = InteropHelpers.MarshalArray<XStoreVideo, XStoreVideo>(interop.videos, interop.videosCount, (XStoreVideo videoInterop) => new XStoreVideo(videoInterop));
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x0000EAC5 File Offset: 0x0000CCC5
		public string StoreId { get; }

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x0600094B RID: 2379 RVA: 0x0000EACD File Offset: 0x0000CCCD
		public string Title { get; }

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x0000EAD5 File Offset: 0x0000CCD5
		public string Description { get; }

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x0600094D RID: 2381 RVA: 0x0000EADD File Offset: 0x0000CCDD
		public string Language { get; }

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x0000EAE5 File Offset: 0x0000CCE5
		public string InAppOfferToken { get; }

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x0600094F RID: 2383 RVA: 0x0000EAED File Offset: 0x0000CCED
		public string LinkUri { get; }

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x0000EAF5 File Offset: 0x0000CCF5
		public XStoreProductKind ProductKind { get; }

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x0000EAFD File Offset: 0x0000CCFD
		public XStorePrice Price { get; }

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x0000EB05 File Offset: 0x0000CD05
		public bool HasDigitalDownload { get; }

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x0000EB0D File Offset: 0x0000CD0D
		public bool IsInUserCollection { get; }

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x0000EB15 File Offset: 0x0000CD15
		public string[] Keywords { get; }

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x0000EB1D File Offset: 0x0000CD1D
		public XStoreSku[] Skus { get; }

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x0000EB25 File Offset: 0x0000CD25
		public XStoreImage[] Images { get; }

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x0000EB2D File Offset: 0x0000CD2D
		public XStoreVideo[] Videos { get; }
	}
}
