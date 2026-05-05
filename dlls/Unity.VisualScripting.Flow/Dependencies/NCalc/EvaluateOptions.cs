using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x02000188 RID: 392
	[Flags]
	public enum EvaluateOptions
	{
		// Token: 0x04000240 RID: 576
		None = 1,
		// Token: 0x04000241 RID: 577
		IgnoreCase = 2,
		// Token: 0x04000242 RID: 578
		NoCache = 4,
		// Token: 0x04000243 RID: 579
		IterateParameters = 8,
		// Token: 0x04000244 RID: 580
		RoundAwayFromZero = 16
	}
}
