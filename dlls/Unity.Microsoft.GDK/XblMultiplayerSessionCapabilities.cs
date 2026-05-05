using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000B9 RID: 185
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionCapabilities
	{
		// Token: 0x0600058C RID: 1420 RVA: 0x0000B2EC File Offset: 0x000094EC
		internal XblMultiplayerSessionCapabilities(XblMultiplayerSessionCapabilities interopStruct)
		{
			this.Connectivity = interopStruct.Connectivity.Value;
			this.Team = interopStruct.Team.Value;
			this.Arbitration = interopStruct.Arbitration.Value;
			this.SuppressPresenceActivityCheck = interopStruct.SuppressPresenceActivityCheck.Value;
			this.Gameplay = interopStruct.Gameplay.Value;
			this.Large = interopStruct.Large.Value;
			this.ConnectionRequiredForActiveMembers = interopStruct.ConnectionRequiredForActiveMembers.Value;
			this.UserAuthorizationStyle = interopStruct.UserAuthorizationStyle.Value;
			this.Crossplay = interopStruct.Crossplay.Value;
			this.Searchable = interopStruct.Searchable.Value;
			this.HasOwners = interopStruct.HasOwners.Value;
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x0000B3DB File Offset: 0x000095DB
		public bool Connectivity { get; }

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x0000B3E3 File Offset: 0x000095E3
		public bool Team { get; }

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x0000B3EB File Offset: 0x000095EB
		public bool Arbitration { get; }

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x0000B3F3 File Offset: 0x000095F3
		public bool SuppressPresenceActivityCheck { get; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x0000B3FB File Offset: 0x000095FB
		public bool Gameplay { get; }

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x0000B403 File Offset: 0x00009603
		public bool Large { get; }

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x0000B40B File Offset: 0x0000960B
		public bool ConnectionRequiredForActiveMembers { get; }

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x0000B413 File Offset: 0x00009613
		public bool UserAuthorizationStyle { get; }

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x0000B41B File Offset: 0x0000961B
		public bool Crossplay { get; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x0000B423 File Offset: 0x00009623
		public bool Searchable { get; }

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000597 RID: 1431 RVA: 0x0000B42B File Offset: 0x0000962B
		public bool HasOwners { get; }
	}
}
