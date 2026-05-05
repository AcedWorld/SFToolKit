using System;

namespace Unity.Burst.CompilerServices
{
	// Token: 0x02000024 RID: 36
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
	public class AssumeRangeAttribute : Attribute
	{
		// Token: 0x06000135 RID: 309 RVA: 0x00007A0A File Offset: 0x00005C0A
		public AssumeRangeAttribute(long min, long max)
		{
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00007A12 File Offset: 0x00005C12
		public AssumeRangeAttribute(ulong min, ulong max)
		{
		}
	}
}
