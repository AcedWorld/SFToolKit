using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000AA RID: 170
	[MovedFrom("Unity.GameCore")]
	public class XblDeviceToken
	{
		// Token: 0x0600055C RID: 1372 RVA: 0x0000AEBC File Offset: 0x000090BC
		internal XblDeviceToken(XblDeviceToken interopStruct)
		{
			this.Value = interopStruct.GetValue();
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0000AED1 File Offset: 0x000090D1
		// (set) Token: 0x0600055E RID: 1374 RVA: 0x0000AED9 File Offset: 0x000090D9
		public string Value { get; set; }
	}
}
