using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000100 RID: 256
	[MovedFrom("Unity.GameCore")]
	public class XblVerifyStringResult
	{
		// Token: 0x060006BC RID: 1724 RVA: 0x0000C3F0 File Offset: 0x0000A5F0
		internal XblVerifyStringResult(XblVerifyStringResult interopStruct)
		{
			this.ResultCode = interopStruct.resultCode;
			this.FirstOffendingSubstring = interopStruct.firstOffendingSubstring.GetString();
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x0000C423 File Offset: 0x0000A623
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x0000C42B File Offset: 0x0000A62B
		public XblVerifyStringResultCode ResultCode { get; private set; }

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x0000C434 File Offset: 0x0000A634
		// (set) Token: 0x060006C0 RID: 1728 RVA: 0x0000C43C File Offset: 0x0000A63C
		public string FirstOffendingSubstring { get; private set; }
	}
}
