using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000177 RID: 375
	[MovedFrom("Unity.GameCore")]
	public class XStoreAvailability
	{
		// Token: 0x060008F9 RID: 2297 RVA: 0x0000E37A File Offset: 0x0000C57A
		internal XStoreAvailability(XStoreAvailability interop)
		{
			this._xstorePrice = new XStorePrice(interop.price);
			this._interop = interop;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0000E39A File Offset: 0x0000C59A
		public XStoreAvailability()
		{
			this._xstorePrice = new XStorePrice();
			this._interop = default(XStoreAvailability);
			this._interop.price = this._xstorePrice.interop;
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x0000E3CF File Offset: 0x0000C5CF
		// (set) Token: 0x060008FC RID: 2300 RVA: 0x0000E3ED File Offset: 0x0000C5ED
		internal XStoreAvailability interop
		{
			get
			{
				this._interop.price = this._xstorePrice.interop;
				return this._interop;
			}
			set
			{
				this._interop = value;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x0000E3F6 File Offset: 0x0000C5F6
		// (set) Token: 0x060008FE RID: 2302 RVA: 0x0000E403 File Offset: 0x0000C603
		public string AvailabilityId
		{
			get
			{
				return this._interop.availabilityId;
			}
			set
			{
				this._interop.availabilityId = value;
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x060008FF RID: 2303 RVA: 0x0000E411 File Offset: 0x0000C611
		// (set) Token: 0x06000900 RID: 2304 RVA: 0x0000E419 File Offset: 0x0000C619
		public XStorePrice Price
		{
			get
			{
				return this._xstorePrice;
			}
			set
			{
				this._interop.price = value.interop;
				this._xstorePrice = value;
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000901 RID: 2305 RVA: 0x0000E433 File Offset: 0x0000C633
		// (set) Token: 0x06000902 RID: 2306 RVA: 0x0000E440 File Offset: 0x0000C640
		public long EndDate
		{
			get
			{
				return this._interop.endDate;
			}
			set
			{
				this._interop.endDate = value;
			}
		}

		// Token: 0x0400052F RID: 1327
		internal XStoreAvailability _interop;

		// Token: 0x04000530 RID: 1328
		internal XStorePrice _xstorePrice;
	}
}
