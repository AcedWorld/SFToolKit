using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000176 RID: 374
	[MovedFrom("Unity.GameCore")]
	public class XStorePrice
	{
		// Token: 0x060008E5 RID: 2277 RVA: 0x0000E264 File Offset: 0x0000C464
		internal XStorePrice(XStorePrice interop)
		{
			this.interop = interop;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x0000E273 File Offset: 0x0000C473
		public XStorePrice()
		{
			this.interop = default(XStorePrice);
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x060008E7 RID: 2279 RVA: 0x0000E287 File Offset: 0x0000C487
		// (set) Token: 0x060008E8 RID: 2280 RVA: 0x0000E294 File Offset: 0x0000C494
		public float BasePrice
		{
			get
			{
				return this.interop.basePrice;
			}
			set
			{
				this.interop.basePrice = value;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x060008E9 RID: 2281 RVA: 0x0000E2A2 File Offset: 0x0000C4A2
		// (set) Token: 0x060008EA RID: 2282 RVA: 0x0000E2AF File Offset: 0x0000C4AF
		public float Price
		{
			get
			{
				return this.interop.price;
			}
			set
			{
				this.interop.price = value;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x0000E2BD File Offset: 0x0000C4BD
		// (set) Token: 0x060008EC RID: 2284 RVA: 0x0000E2CA File Offset: 0x0000C4CA
		public float RecurrencePrice
		{
			get
			{
				return this.interop.recurrencePrice;
			}
			set
			{
				this.interop.recurrencePrice = value;
			}
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x060008ED RID: 2285 RVA: 0x0000E2D8 File Offset: 0x0000C4D8
		// (set) Token: 0x060008EE RID: 2286 RVA: 0x0000E2E5 File Offset: 0x0000C4E5
		public string CurrencyCode
		{
			get
			{
				return this.interop.currencyCode;
			}
			set
			{
				this.interop.currencyCode = value;
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x0000E2F3 File Offset: 0x0000C4F3
		// (set) Token: 0x060008F0 RID: 2288 RVA: 0x0000E300 File Offset: 0x0000C500
		public string FormattedBasePrice
		{
			get
			{
				return this.interop.formattedBasePrice;
			}
			set
			{
				this.interop.formattedBasePrice = value;
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x060008F1 RID: 2289 RVA: 0x0000E30E File Offset: 0x0000C50E
		// (set) Token: 0x060008F2 RID: 2290 RVA: 0x0000E31B File Offset: 0x0000C51B
		public string FormattedPrice
		{
			get
			{
				return this.interop.formattedPrice;
			}
			set
			{
				this.interop.formattedPrice = value;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x060008F3 RID: 2291 RVA: 0x0000E329 File Offset: 0x0000C529
		// (set) Token: 0x060008F4 RID: 2292 RVA: 0x0000E336 File Offset: 0x0000C536
		public string FormattedRecurrencePrice
		{
			get
			{
				return this.interop.formattedRecurrencePrice;
			}
			set
			{
				this.interop.formattedRecurrencePrice = value;
			}
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x0000E344 File Offset: 0x0000C544
		// (set) Token: 0x060008F6 RID: 2294 RVA: 0x0000E351 File Offset: 0x0000C551
		public bool IsOnSale
		{
			get
			{
				return this.interop.isOnSale;
			}
			set
			{
				this.interop.isOnSale = value;
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x0000E35F File Offset: 0x0000C55F
		// (set) Token: 0x060008F8 RID: 2296 RVA: 0x0000E36C File Offset: 0x0000C56C
		public long SaleEndDate
		{
			get
			{
				return this.interop.saleEndDate;
			}
			set
			{
				this.interop.saleEndDate = value;
			}
		}

		// Token: 0x0400052E RID: 1326
		internal XStorePrice interop;
	}
}
