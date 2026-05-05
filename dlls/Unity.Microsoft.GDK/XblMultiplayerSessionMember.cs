using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000097 RID: 151
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionMember
	{
		// Token: 0x060004ED RID: 1261 RVA: 0x0000A6B4 File Offset: 0x000088B4
		internal XblMultiplayerSessionMember(XblMultiplayerSessionMember interopHandle)
		{
			this.InteropHandle = interopHandle;
			this.MemberId = interopHandle.MemberId;
			this.TeamId = interopHandle.TeamId.GetString();
			this.InitialTeam = interopHandle.InitialTeam.GetString();
			this.ArbitrationStatus = interopHandle.ArbitrationStatus;
			this.Xuid = interopHandle.Xuid;
			this.CustomConstantsJson = interopHandle.CustomConstantsJson.GetString();
			this.SecureDeviceBaseAddress64 = interopHandle.SecureDeviceBaseAddress64.GetString();
			this.Roles = interopHandle.GetRoles<XblMultiplayerSessionMemberRole>((XblMultiplayerSessionMemberRole r) => new XblMultiplayerSessionMemberRole(r));
			this.CustomPropertiesJson = interopHandle.CustomPropertiesJson.GetString();
			this.Gamertag = interopHandle.GetGamertag();
			this.Status = interopHandle.Status;
			this.IsTurnAvailable = interopHandle.IsTurnAvailable;
			this.IsCurrentUser = interopHandle.IsCurrentUser;
			this.InitializeRequested = interopHandle.InitializeRequested;
			this.MatchmakingResultServerMeasurementsJson = interopHandle.MatchmakingResultServerMeasurementsJson.GetString();
			this.ServerMeasurementsJson = interopHandle.ServerMeasurementsJson.GetString();
			this.MembersInGroupIds = interopHandle.GetMembersInGroupIds<uint>((uint x) => x);
			this.QosMeasurementsJson = interopHandle.QosMeasurementsJson.GetString();
			this.DeviceToken = new XblDeviceToken(interopHandle.DeviceToken);
			this.Nat = interopHandle.Nat;
			this.ActiveTitleId = interopHandle.ActiveTitleId;
			this.InitializationEpisode = interopHandle.InitializationEpisode;
			this.JoinTime = interopHandle.JoinTime.DateTime;
			this.InitializationFailureCause = interopHandle.InitializationFailureCause;
			this.Groups = interopHandle.GetGroups();
			this.Encounters = interopHandle.GetEncounters();
			this.TournamentTeamSessionReference = new XblMultiplayerSessionReference(interopHandle.TournamentTeamSessionReference);
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x0000A895 File Offset: 0x00008A95
		public uint MemberId { get; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x0000A89D File Offset: 0x00008A9D
		public string TeamId { get; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x0000A8A5 File Offset: 0x00008AA5
		public string InitialTeam { get; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0000A8AD File Offset: 0x00008AAD
		public XblTournamentArbitrationStatus ArbitrationStatus { get; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x0000A8B5 File Offset: 0x00008AB5
		public ulong Xuid { get; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0000A8BD File Offset: 0x00008ABD
		public string CustomConstantsJson { get; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x0000A8C5 File Offset: 0x00008AC5
		public string SecureDeviceBaseAddress64 { get; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x0000A8CD File Offset: 0x00008ACD
		public XblMultiplayerSessionMemberRole[] Roles { get; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x0000A8D5 File Offset: 0x00008AD5
		public string CustomPropertiesJson { get; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x0000A8DD File Offset: 0x00008ADD
		public string Gamertag { get; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x0000A8E5 File Offset: 0x00008AE5
		public XblMultiplayerSessionMemberStatus Status { get; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x0000A8ED File Offset: 0x00008AED
		public bool IsTurnAvailable { get; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x0000A8F5 File Offset: 0x00008AF5
		public bool IsCurrentUser { get; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x0000A8FD File Offset: 0x00008AFD
		public bool InitializeRequested { get; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x0000A905 File Offset: 0x00008B05
		public string MatchmakingResultServerMeasurementsJson { get; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0000A90D File Offset: 0x00008B0D
		public string ServerMeasurementsJson { get; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x0000A915 File Offset: 0x00008B15
		public uint[] MembersInGroupIds { get; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x0000A91D File Offset: 0x00008B1D
		public string QosMeasurementsJson { get; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x0000A925 File Offset: 0x00008B25
		public XblDeviceToken DeviceToken { get; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x0000A92D File Offset: 0x00008B2D
		public XblNetworkAddressTranslationSetting Nat { get; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x0000A935 File Offset: 0x00008B35
		public uint ActiveTitleId { get; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x0000A93D File Offset: 0x00008B3D
		public uint InitializationEpisode { get; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x0000A945 File Offset: 0x00008B45
		public DateTime JoinTime { get; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x0000A94D File Offset: 0x00008B4D
		public XblMultiplayerMeasurementFailure InitializationFailureCause { get; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x0000A955 File Offset: 0x00008B55
		public string[] Groups { get; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x0000A95D File Offset: 0x00008B5D
		public string[] Encounters { get; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x0000A965 File Offset: 0x00008B65
		public XblMultiplayerSessionReference TournamentTeamSessionReference { get; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x0000A96D File Offset: 0x00008B6D
		internal XblMultiplayerSessionMember InteropHandle { get; }
	}
}
