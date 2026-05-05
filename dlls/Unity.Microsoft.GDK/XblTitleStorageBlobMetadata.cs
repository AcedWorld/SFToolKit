using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200010B RID: 267
	[MovedFrom("Unity.GameCore")]
	public class XblTitleStorageBlobMetadata
	{
		// Token: 0x060006EC RID: 1772 RVA: 0x0000C550 File Offset: 0x0000A750
		internal XblTitleStorageBlobMetadata(XblTitleStorageBlobMetadata interopHandle)
		{
			this.interop = interopHandle;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0000C55F File Offset: 0x0000A75F
		public XblTitleStorageBlobMetadata()
		{
			this.interop = default(XblTitleStorageBlobMetadata);
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060006EE RID: 1774 RVA: 0x0000C573 File Offset: 0x0000A773
		// (set) Token: 0x060006EF RID: 1775 RVA: 0x0000C580 File Offset: 0x0000A780
		public string BlobPath
		{
			get
			{
				return this.interop.blobPath;
			}
			set
			{
				this.interop.blobPath = value;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060006F0 RID: 1776 RVA: 0x0000C58E File Offset: 0x0000A78E
		// (set) Token: 0x060006F1 RID: 1777 RVA: 0x0000C59B File Offset: 0x0000A79B
		public XblTitleStorageBlobType BlobType
		{
			get
			{
				return this.interop.blobType;
			}
			set
			{
				this.interop.blobType = value;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060006F2 RID: 1778 RVA: 0x0000C5A9 File Offset: 0x0000A7A9
		// (set) Token: 0x060006F3 RID: 1779 RVA: 0x0000C5B6 File Offset: 0x0000A7B6
		public XblTitleStorageType StorageType
		{
			get
			{
				return this.interop.storageType;
			}
			set
			{
				this.interop.storageType = value;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060006F4 RID: 1780 RVA: 0x0000C5C4 File Offset: 0x0000A7C4
		// (set) Token: 0x060006F5 RID: 1781 RVA: 0x0000C5D1 File Offset: 0x0000A7D1
		public string DisplayName
		{
			get
			{
				return this.interop.displayName;
			}
			set
			{
				this.interop.displayName = value;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060006F6 RID: 1782 RVA: 0x0000C5DF File Offset: 0x0000A7DF
		// (set) Token: 0x060006F7 RID: 1783 RVA: 0x0000C5EC File Offset: 0x0000A7EC
		public string ETag
		{
			get
			{
				return this.interop.eTag;
			}
			set
			{
				this.interop.eTag = value;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060006F8 RID: 1784 RVA: 0x0000C5FA File Offset: 0x0000A7FA
		// (set) Token: 0x060006F9 RID: 1785 RVA: 0x0000C60C File Offset: 0x0000A80C
		public DateTime ClientTimestamp
		{
			get
			{
				return this.interop.clientTimestamp.DateTime;
			}
			set
			{
				this.interop.clientTimestamp = new TimeT(value);
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060006FA RID: 1786 RVA: 0x0000C61F File Offset: 0x0000A81F
		// (set) Token: 0x060006FB RID: 1787 RVA: 0x0000C631 File Offset: 0x0000A831
		public ulong Length
		{
			get
			{
				return this.interop.length.ToUInt64();
			}
			set
			{
				this.interop.length = new SizeT(value);
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x0000C644 File Offset: 0x0000A844
		// (set) Token: 0x060006FD RID: 1789 RVA: 0x0000C651 File Offset: 0x0000A851
		public string ServiceConfigurationId
		{
			get
			{
				return this.interop.serviceConfigurationId;
			}
			set
			{
				this.interop.serviceConfigurationId = value;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x0000C65F File Offset: 0x0000A85F
		// (set) Token: 0x060006FF RID: 1791 RVA: 0x0000C66C File Offset: 0x0000A86C
		public ulong XboxUserId
		{
			get
			{
				return this.interop.xboxUserId;
			}
			set
			{
				this.interop.xboxUserId = value;
			}
		}

		// Token: 0x04000412 RID: 1042
		internal XblTitleStorageBlobMetadata interop;
	}
}
