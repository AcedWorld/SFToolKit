using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000BD RID: 189
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionReferenceUri
	{
		// Token: 0x060005B2 RID: 1458 RVA: 0x0000B6C1 File Offset: 0x000098C1
		internal XblMultiplayerSessionReferenceUri(XblMultiplayerSessionReferenceUri interopStruct)
		{
			this.Value = interopStruct.GetValue();
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060005B3 RID: 1459 RVA: 0x0000B6D6 File Offset: 0x000098D6
		public string Value { get; }
	}
}
