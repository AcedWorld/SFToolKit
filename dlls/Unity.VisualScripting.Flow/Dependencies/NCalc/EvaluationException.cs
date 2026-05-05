using System;

namespace Unity.VisualScripting.Dependencies.NCalc
{
	// Token: 0x02000187 RID: 391
	public sealed class EvaluationException : ApplicationException
	{
		// Token: 0x06000A70 RID: 2672 RVA: 0x00012E62 File Offset: 0x00011062
		public EvaluationException(string message) : base(message)
		{
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x00012E6B File Offset: 0x0001106B
		public EvaluationException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
