using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000094 RID: 148
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionHandleId
	{
		// Token: 0x060004DE RID: 1246 RVA: 0x0000A601 File Offset: 0x00008801
		internal XblMultiplayerSessionHandleId(XblMultiplayerSessionHandleId interopHandle)
		{
			this.Value = interopHandle.GetValue();
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060004DF RID: 1247 RVA: 0x0000A616 File Offset: 0x00008816
		public string Value { get; }
	}
}
