using System;

namespace Unity.Burst.CompilerServices
{
	// Token: 0x02000027 RID: 39
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class IgnoreWarningAttribute : Attribute
	{
		// Token: 0x0600013C RID: 316 RVA: 0x00007A28 File Offset: 0x00005C28
		public IgnoreWarningAttribute(int warning)
		{
		}
	}
}
