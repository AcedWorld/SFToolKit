using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000AB RID: 171
	[MovedFrom("Unity.GameCore")]
	public class XblGuid
	{
		// Token: 0x0600055F RID: 1375 RVA: 0x0000AEE2 File Offset: 0x000090E2
		internal XblGuid(XblGuid interopStruct)
		{
			this.Value = interopStruct.GetValue();
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x0000AEF7 File Offset: 0x000090F7
		public string Value { get; }
	}
}
