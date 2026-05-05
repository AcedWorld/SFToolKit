using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000B1 RID: 177
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerManagerMember
	{
		// Token: 0x0600056F RID: 1391 RVA: 0x0000B05C File Offset: 0x0000925C
		internal XblMultiplayerManagerMember(XblMultiplayerManagerMember interopStruct)
		{
			this.MemberId = interopStruct.MemberId;
			this.TeamId = interopStruct.TeamId.GetString();
			this.InitialTeam = interopStruct.InitialTeam.GetString();
			this.Xuid = interopStruct.Xuid;
			this.DebugGamertag = interopStruct.DebugGamertag.GetString();
			this.IsLocal = interopStruct.IsLocal.Value;
			this.IsInLobby = interopStruct.IsInLobby.Value;
			this.IsInGame = interopStruct.IsInGame.Value;
			this.Status = interopStruct.Status;
			this.ConnectionAddress = interopStruct.ConnectionAddress.GetString();
			this.PropertiesJson = interopStruct.PropertiesJson.GetString();
			this.DeviceToken = interopStruct.DeviceToken.GetString();
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x0000B147 File Offset: 0x00009347
		public uint MemberId { get; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x0000B14F File Offset: 0x0000934F
		public string TeamId { get; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x0000B157 File Offset: 0x00009357
		public string InitialTeam { get; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x0000B15F File Offset: 0x0000935F
		public ulong Xuid { get; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x0000B167 File Offset: 0x00009367
		public string DebugGamertag { get; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x0000B16F File Offset: 0x0000936F
		public bool IsLocal { get; }

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x0000B177 File Offset: 0x00009377
		public bool IsInLobby { get; }

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x0000B17F File Offset: 0x0000937F
		public bool IsInGame { get; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x0000B187 File Offset: 0x00009387
		public XblMultiplayerSessionMemberStatus Status { get; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x0000B18F File Offset: 0x0000938F
		public string ConnectionAddress { get; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x0000B197 File Offset: 0x00009397
		public string PropertiesJson { get; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x0000B19F File Offset: 0x0000939F
		public string DeviceToken { get; }
	}
}
