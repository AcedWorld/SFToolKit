using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200008F RID: 143
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerMatchmakingServer
	{
		// Token: 0x060004CC RID: 1228 RVA: 0x0000A48C File Offset: 0x0000868C
		internal XblMultiplayerMatchmakingServer(XblMultiplayerMatchmakingServer interopHandle)
		{
			this.InteropHandle = interopHandle;
			this.Status = interopHandle.Status;
			this.StatusDetails = interopHandle.StatusDetails.GetString();
			this.TypicalWaitInSeconds = interopHandle.TypicalWaitInSeconds;
			this.TargetSessionRef = new XblMultiplayerSessionReference(interopHandle.TargetSessionRef);
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0000A4E1 File Offset: 0x000086E1
		public XblMatchmakingStatus Status { get; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x0000A4E9 File Offset: 0x000086E9
		public string StatusDetails { get; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x0000A4F1 File Offset: 0x000086F1
		public uint TypicalWaitInSeconds { get; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0000A4F9 File Offset: 0x000086F9
		public XblMultiplayerSessionReference TargetSessionRef { get; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x0000A501 File Offset: 0x00008701
		internal XblMultiplayerMatchmakingServer InteropHandle { get; }
	}
}
