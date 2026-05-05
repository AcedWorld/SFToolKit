using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000BC RID: 188
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionReference
	{
		// Token: 0x060005AE RID: 1454 RVA: 0x0000B67A File Offset: 0x0000987A
		internal XblMultiplayerSessionReference(XblMultiplayerSessionReference interopStruct)
		{
			this.Scid = interopStruct.GetScid();
			this.SessionTemplateName = interopStruct.GetSessionTemplateName();
			this.SessionName = interopStruct.GetSessionName();
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060005AF RID: 1455 RVA: 0x0000B6A9 File Offset: 0x000098A9
		public string Scid { get; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0000B6B1 File Offset: 0x000098B1
		public string SessionTemplateName { get; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060005B1 RID: 1457 RVA: 0x0000B6B9 File Offset: 0x000098B9
		public string SessionName { get; }
	}
}
