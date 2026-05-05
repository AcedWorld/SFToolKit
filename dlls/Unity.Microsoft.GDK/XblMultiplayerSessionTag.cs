using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000A0 RID: 160
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionTag
	{
		// Token: 0x06000544 RID: 1348 RVA: 0x0000AD5D File Offset: 0x00008F5D
		public XblMultiplayerSessionTag(string value)
		{
			this.Value = value;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0000AD6C File Offset: 0x00008F6C
		internal XblMultiplayerSessionTag(XblMultiplayerSessionTag interopStruct)
		{
			this.Value = interopStruct.GetValue();
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x0000AD81 File Offset: 0x00008F81
		public string Value { get; }
	}
}
