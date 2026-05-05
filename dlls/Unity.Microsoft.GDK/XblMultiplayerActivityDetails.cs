using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200008C RID: 140
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerActivityDetails
	{
		// Token: 0x060004BF RID: 1215 RVA: 0x0000A388 File Offset: 0x00008588
		internal XblMultiplayerActivityDetails(XblMultiplayerActivityDetails interopHandle)
		{
			this.SessionReference = new XblMultiplayerSessionReference(interopHandle.SessionReference);
			this.HandleId = interopHandle.GetHandleId();
			this.TitleId = interopHandle.TitleId;
			this.Visibility = interopHandle.Visibility;
			this.JoinRestriction = interopHandle.JoinRestriction;
			this.Closed = interopHandle.Closed;
			this.OwnerXuid = interopHandle.OwnerXuid;
			this.MaxMembersCount = interopHandle.MaxMembersCount;
			this.MembersCount = interopHandle.MembersCount;
			this.CustomSessionPropertiesJson = interopHandle.CustomSessionPropertiesJson.GetString();
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0000A41F File Offset: 0x0000861F
		public XblMultiplayerSessionReference SessionReference { get; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x0000A427 File Offset: 0x00008627
		public string HandleId { get; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x0000A42F File Offset: 0x0000862F
		public uint TitleId { get; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x0000A437 File Offset: 0x00008637
		public XblMultiplayerSessionVisibility Visibility { get; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0000A43F File Offset: 0x0000863F
		public XblMultiplayerSessionRestriction JoinRestriction { get; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x0000A447 File Offset: 0x00008647
		public bool Closed { get; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0000A44F File Offset: 0x0000864F
		public ulong OwnerXuid { get; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x0000A457 File Offset: 0x00008657
		public uint MaxMembersCount { get; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x0000A45F File Offset: 0x0000865F
		public uint MembersCount { get; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x0000A467 File Offset: 0x00008667
		public string CustomSessionPropertiesJson { get; }
	}
}
