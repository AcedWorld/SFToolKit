using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200008E RID: 142
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerInviteHandle
	{
		// Token: 0x060004CA RID: 1226 RVA: 0x0000A46F File Offset: 0x0000866F
		internal XblMultiplayerInviteHandle(XblMultiplayerInviteHandle interopStruct)
		{
			this.Data = interopStruct.GetData();
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x0000A484 File Offset: 0x00008684
		public string Data { get; }
	}
}
