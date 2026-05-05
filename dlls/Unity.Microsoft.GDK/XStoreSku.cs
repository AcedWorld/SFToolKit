using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200017E RID: 382
	[MovedFrom("Unity.GameCore")]
	public class XStoreSku
	{
		// Token: 0x0600093A RID: 2362 RVA: 0x0000E7B8 File Offset: 0x0000C9B8
		internal XStoreSku(ref XStoreSkuInterop interop)
		{
			this.SkuId = interop.skuId;
			this.Title = interop.title;
			this.Description = interop.description;
			this.Language = interop.language;
			this.Price = new XStorePrice(interop.price);
			this.IsTrial = interop.isTrial;
			this.IsInUserCollection = interop.isInUserCollection;
			this.CollectionData = new XStoreCollectionData(interop.collectionData);
			this.IsSubscription = interop.isSubscription;
			this.SubscriptionInfo = new XStoreSubscriptionInfo(interop.subscriptionInfo);
			this.BundledSkus = InteropHelpers.MarshalStringArrayAnsi(interop.bundledSkus, interop.bundledSkusCount);
			this.Images = InteropHelpers.MarshalArray<XStoreImage, XStoreImage>(interop.images, interop.imagesCount, (XStoreImage imageInterop) => new XStoreImage(imageInterop));
			this.Videos = InteropHelpers.MarshalArray<XStoreVideo, XStoreVideo>(interop.videos, interop.videosCount, (XStoreVideo videoInterop) => new XStoreVideo(videoInterop));
			this.Availabilities = InteropHelpers.MarshalArray<XStoreAvailability, XStoreAvailability>(interop.availabilities, interop.availabilitiesCount, (XStoreAvailability availabilityInterop) => new XStoreAvailability(availabilityInterop));
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x0000E90B File Offset: 0x0000CB0B
		public string SkuId { get; }

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x0000E913 File Offset: 0x0000CB13
		public string Title { get; }

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x0000E91B File Offset: 0x0000CB1B
		public string Description { get; }

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x0000E923 File Offset: 0x0000CB23
		public string Language { get; }

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x0000E92B File Offset: 0x0000CB2B
		public XStorePrice Price { get; }

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x0000E933 File Offset: 0x0000CB33
		public bool IsTrial { get; }

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x0000E93B File Offset: 0x0000CB3B
		public bool IsInUserCollection { get; }

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x0000E943 File Offset: 0x0000CB43
		public XStoreCollectionData CollectionData { get; }

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000943 RID: 2371 RVA: 0x0000E94B File Offset: 0x0000CB4B
		public bool IsSubscription { get; }

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x0000E953 File Offset: 0x0000CB53
		public XStoreSubscriptionInfo SubscriptionInfo { get; }

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000945 RID: 2373 RVA: 0x0000E95B File Offset: 0x0000CB5B
		public string[] BundledSkus { get; }

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x0000E963 File Offset: 0x0000CB63
		public XStoreImage[] Images { get; }

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x0000E96B File Offset: 0x0000CB6B
		public XStoreVideo[] Videos { get; }

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000948 RID: 2376 RVA: 0x0000E973 File Offset: 0x0000CB73
		public XStoreAvailability[] Availabilities { get; }
	}
}
