using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200005D RID: 93
	[MovedFrom("Unity.GameCore")]
	public class XStoreQueryResult
	{
		// Token: 0x060003DD RID: 989 RVA: 0x00009436 File Offset: 0x00007636
		internal XStoreQueryResult(XStoreProductQuery queryHandle, XStoreProduct[] pageItems, bool hasMorePages)
		{
			this.QueryHandle = queryHandle;
			this.PageItems = pageItems;
			this.HasMorePages = hasMorePages;
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00009453 File Offset: 0x00007653
		// (set) Token: 0x060003DF RID: 991 RVA: 0x0000945B File Offset: 0x0000765B
		internal XStoreProductQuery QueryHandle { get; private set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x00009464 File Offset: 0x00007664
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x0000946C File Offset: 0x0000766C
		public bool HasMorePages { get; private set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00009475 File Offset: 0x00007675
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x0000947D File Offset: 0x0000767D
		public XStoreProduct[] PageItems { get; private set; }

		// Token: 0x060003E4 RID: 996 RVA: 0x00009486 File Offset: 0x00007686
		public static implicit operator XStoreProductQuery(XStoreQueryResult result)
		{
			return result.QueryHandle;
		}
	}
}
