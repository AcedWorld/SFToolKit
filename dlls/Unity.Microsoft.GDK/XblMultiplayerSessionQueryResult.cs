using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200009B RID: 155
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionQueryResult
	{
		// Token: 0x06000527 RID: 1319 RVA: 0x0000AABC File Offset: 0x00008CBC
		internal XblMultiplayerSessionQueryResult(XblMultiplayerSessionQueryResult interopHandle)
		{
			this.StartTime = interopHandle.StartTime.DateTime;
			this.SessionReference = new XblMultiplayerSessionReference(interopHandle.SessionReference);
			this.Status = interopHandle.Status;
			this.Visibility = interopHandle.Visibility;
			this.IsMyTurn = interopHandle.IsMyTurn;
			this.Xuid = interopHandle.Xuid;
			this.AcceptedMemberCount = interopHandle.AcceptedMemberCount;
			this.JoinRestriction = interopHandle.JoinRestriction;
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x0000AB3A File Offset: 0x00008D3A
		public DateTime StartTime { get; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x0000AB42 File Offset: 0x00008D42
		public XblMultiplayerSessionReference SessionReference { get; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x0000AB4A File Offset: 0x00008D4A
		public XblMultiplayerSessionStatus Status { get; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x0000AB52 File Offset: 0x00008D52
		public XblMultiplayerSessionVisibility Visibility { get; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x0000AB5A File Offset: 0x00008D5A
		public bool IsMyTurn { get; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x0000AB62 File Offset: 0x00008D62
		public ulong Xuid { get; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x0000AB6A File Offset: 0x00008D6A
		public uint AcceptedMemberCount { get; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x0000AB72 File Offset: 0x00008D72
		public XblMultiplayerSessionRestriction JoinRestriction { get; }
	}
}
