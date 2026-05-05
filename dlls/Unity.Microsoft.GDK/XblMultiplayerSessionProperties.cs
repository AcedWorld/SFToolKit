using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200009D RID: 157
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionProperties
	{
		// Token: 0x06000530 RID: 1328 RVA: 0x0000AB7C File Offset: 0x00008D7C
		internal XblMultiplayerSessionProperties(XblMultiplayerSessionProperties interopHandle)
		{
			this.InteropHandle = interopHandle;
			this.Keywords = interopHandle.GetKeywords();
			this.JoinRestriction = interopHandle.JoinRestriction;
			this.ReadRestriction = interopHandle.ReadRestriction;
			this.TurnCollection = interopHandle.GetTurnCollection<uint>((uint x) => x);
			this.MatchmakingTargetSessionConstantsJson = interopHandle.MatchmakingTargetSessionConstantsJson.GetString();
			this.SessionCustomPropertiesJson = interopHandle.SessionCustomPropertiesJson.GetString();
			this.MatchmakingServerConnectionString = interopHandle.MatchmakingServerConnectionString.GetString();
			this.ServerConnectionStringCandidates = interopHandle.GetServerConnectionStringCandidates();
			this.SessionOwnerMemberIds = interopHandle.GetSessionOwnerMemberIds<uint>((uint x) => x);
			this.HostDeviceToken = new XblDeviceToken(interopHandle.HostDeviceToken);
			this.Closed = interopHandle.Closed;
			this.Locked = interopHandle.Locked;
			this.AllocateCloudCompute = interopHandle.AllocateCloudCompute;
			this.MatchmakingResubmit = interopHandle.MatchmakingResubmit;
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x0000AC9D File Offset: 0x00008E9D
		public string[] Keywords { get; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000532 RID: 1330 RVA: 0x0000ACA5 File Offset: 0x00008EA5
		public XblMultiplayerSessionRestriction JoinRestriction { get; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0000ACAD File Offset: 0x00008EAD
		public XblMultiplayerSessionRestriction ReadRestriction { get; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x0000ACB5 File Offset: 0x00008EB5
		public uint[] TurnCollection { get; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x0000ACBD File Offset: 0x00008EBD
		public string MatchmakingTargetSessionConstantsJson { get; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0000ACC5 File Offset: 0x00008EC5
		public string SessionCustomPropertiesJson { get; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x0000ACCD File Offset: 0x00008ECD
		public string MatchmakingServerConnectionString { get; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x0000ACD5 File Offset: 0x00008ED5
		public string[] ServerConnectionStringCandidates { get; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x0000ACDD File Offset: 0x00008EDD
		public uint[] SessionOwnerMemberIds { get; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0000ACE5 File Offset: 0x00008EE5
		public XblDeviceToken HostDeviceToken { get; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x0000ACED File Offset: 0x00008EED
		public bool Closed { get; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x0000ACF5 File Offset: 0x00008EF5
		public bool Locked { get; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600053D RID: 1341 RVA: 0x0000ACFD File Offset: 0x00008EFD
		public bool AllocateCloudCompute { get; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x0000AD05 File Offset: 0x00008F05
		public bool MatchmakingResubmit { get; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x0000AD0D File Offset: 0x00008F0D
		internal XblMultiplayerSessionProperties InteropHandle { get; }
	}
}
