using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000096 RID: 150
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionInitializationInfo
	{
		// Token: 0x060004E9 RID: 1257 RVA: 0x0000A66A File Offset: 0x0000886A
		internal XblMultiplayerSessionInitializationInfo(XblMultiplayerSessionInitializationInfo interopHandle)
		{
			this.Stage = interopHandle.Stage;
			this.StageStartTime = interopHandle.StageStartTime.DateTime;
			this.Episode = interopHandle.Episode;
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x0000A69C File Offset: 0x0000889C
		public XblMultiplayerInitializationStage Stage { get; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0000A6A4 File Offset: 0x000088A4
		public DateTime StageStartTime { get; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x0000A6AC File Offset: 0x000088AC
		public uint Episode { get; }
	}
}
