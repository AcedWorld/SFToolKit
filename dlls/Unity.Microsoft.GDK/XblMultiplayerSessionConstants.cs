using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000BA RID: 186
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerSessionConstants
	{
		// Token: 0x06000598 RID: 1432 RVA: 0x0000B434 File Offset: 0x00009634
		internal XblMultiplayerSessionConstants(XblMultiplayerSessionConstants interopStruct)
		{
			this.MaxMembersInSession = interopStruct.MaxMembersInSession;
			this.Visibility = interopStruct.Visibility;
			this.InitiatorXuids = interopStruct.GetInitiatorXuids<ulong>((ulong x) => x);
			this.CustomJson = interopStruct.CustomJson.GetString();
			this.SessionCloudComputePackageConstantsJson = interopStruct.SessionCloudComputePackageConstantsJson.GetString();
			this.MemberReservedTimeout = interopStruct.MemberReservedTimeout;
			this.MemberInactiveTimeout = interopStruct.MemberInactiveTimeout;
			this.MemberReadyTimeout = interopStruct.MemberReadyTimeout;
			this.SessionEmptyTimeout = interopStruct.SessionEmptyTimeout;
			this.ArbitrationTimeout = interopStruct.ArbitrationTimeout;
			this.ForfeitTimeout = interopStruct.ForfeitTimeout;
			this.EnableMetricsLatency = interopStruct.EnableMetricsLatency.Value;
			this.EnableMetricsBandwidthDown = interopStruct.EnableMetricsBandwidthDown.Value;
			this.EnableMetricsBandwidthUp = interopStruct.EnableMetricsBandwidthUp.Value;
			this.EnableMetricsCustom = interopStruct.EnableMetricsCustom.Value;
			this.MemberInitialization = interopStruct.GetMemberInitialization<XblMultiplayerMemberInitialization>((XblMultiplayerMemberInitialization x) => new XblMultiplayerMemberInitialization(x));
			this.PeerToPeerRequirements = new XblMultiplayerPeerToPeerRequirements(interopStruct.PeerToPeerRequirements);
			this.PeerToHostRequirements = new XblMultiplayerPeerToHostRequirements(interopStruct.PeerToHostRequirements);
			this.MeasurementServerAddressesJson = interopStruct.MeasurementServerAddressesJson.GetString();
			this.ClientMatchmakingCapable = interopStruct.ClientMatchmakingCapable.Value;
			this.SessionCapabilities = new XblMultiplayerSessionCapabilities(interopStruct.SessionCapabilities);
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x0000B5D2 File Offset: 0x000097D2
		public uint MaxMembersInSession { get; }

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0000B5DA File Offset: 0x000097DA
		public XblMultiplayerSessionVisibility Visibility { get; }

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x0000B5E2 File Offset: 0x000097E2
		public ulong[] InitiatorXuids { get; }

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0000B5EA File Offset: 0x000097EA
		public string CustomJson { get; }

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x0000B5F2 File Offset: 0x000097F2
		public string SessionCloudComputePackageConstantsJson { get; }

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x0000B5FA File Offset: 0x000097FA
		public ulong MemberReservedTimeout { get; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x0000B602 File Offset: 0x00009802
		public ulong MemberInactiveTimeout { get; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x0000B60A File Offset: 0x0000980A
		public ulong MemberReadyTimeout { get; }

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0000B612 File Offset: 0x00009812
		public ulong SessionEmptyTimeout { get; }

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x0000B61A File Offset: 0x0000981A
		public ulong ArbitrationTimeout { get; }

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0000B622 File Offset: 0x00009822
		public ulong ForfeitTimeout { get; }

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x0000B62A File Offset: 0x0000982A
		public bool EnableMetricsLatency { get; }

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0000B632 File Offset: 0x00009832
		public bool EnableMetricsBandwidthDown { get; }

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x0000B63A File Offset: 0x0000983A
		public bool EnableMetricsBandwidthUp { get; }

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0000B642 File Offset: 0x00009842
		public bool EnableMetricsCustom { get; }

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x0000B64A File Offset: 0x0000984A
		public XblMultiplayerMemberInitialization MemberInitialization { get; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0000B652 File Offset: 0x00009852
		public XblMultiplayerPeerToPeerRequirements PeerToPeerRequirements { get; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x0000B65A File Offset: 0x0000985A
		public XblMultiplayerPeerToHostRequirements PeerToHostRequirements { get; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060005AB RID: 1451 RVA: 0x0000B662 File Offset: 0x00009862
		public string MeasurementServerAddressesJson { get; }

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x0000B66A File Offset: 0x0000986A
		public bool ClientMatchmakingCapable { get; }

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060005AD RID: 1453 RVA: 0x0000B672 File Offset: 0x00009872
		public XblMultiplayerSessionCapabilities SessionCapabilities { get; }
	}
}
