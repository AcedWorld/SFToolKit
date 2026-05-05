using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000B4 RID: 180
	[MovedFrom("Unity.GameCore")]
	public class XblMultiplayerMemberInitialization
	{
		// Token: 0x0600057C RID: 1404 RVA: 0x0000B1A8 File Offset: 0x000093A8
		internal XblMultiplayerMemberInitialization(XblMultiplayerMemberInitialization interopStruct)
		{
			this.JoinTimeout = interopStruct.JoinTimeout;
			this.MeasurementTimeout = interopStruct.MeasurementTimeout;
			this.EvaluationTimeout = interopStruct.EvaluationTimeout;
			this.ExternalEvaluation = interopStruct.ExternalEvaluation.Value;
			this.MembersNeededToStart = interopStruct.MembersNeededToStart;
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x0000B1FF File Offset: 0x000093FF
		public ulong JoinTimeout { get; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x0000B207 File Offset: 0x00009407
		public ulong MeasurementTimeout { get; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x0000B20F File Offset: 0x0000940F
		public ulong EvaluationTimeout { get; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x0000B217 File Offset: 0x00009417
		public bool ExternalEvaluation { get; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000581 RID: 1409 RVA: 0x0000B21F File Offset: 0x0000941F
		public uint MembersNeededToStart { get; }
	}
}
