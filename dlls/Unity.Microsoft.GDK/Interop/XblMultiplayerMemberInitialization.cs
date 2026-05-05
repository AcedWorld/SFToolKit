using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000210 RID: 528
	internal struct XblMultiplayerMemberInitialization
	{
		// Token: 0x06000DC1 RID: 3521 RVA: 0x00010DA0 File Offset: 0x0000EFA0
		internal XblMultiplayerMemberInitialization(XblMultiplayerMemberInitialization publicObject)
		{
			this.JoinTimeout = publicObject.JoinTimeout;
			this.MeasurementTimeout = publicObject.MeasurementTimeout;
			this.EvaluationTimeout = publicObject.EvaluationTimeout;
			this.ExternalEvaluation = new NativeBool(publicObject.ExternalEvaluation);
			this.MembersNeededToStart = publicObject.MembersNeededToStart;
		}

		// Token: 0x0400073E RID: 1854
		internal readonly ulong JoinTimeout;

		// Token: 0x0400073F RID: 1855
		internal readonly ulong MeasurementTimeout;

		// Token: 0x04000740 RID: 1856
		internal readonly ulong EvaluationTimeout;

		// Token: 0x04000741 RID: 1857
		internal readonly NativeBool ExternalEvaluation;

		// Token: 0x04000742 RID: 1858
		internal readonly uint MembersNeededToStart;
	}
}
