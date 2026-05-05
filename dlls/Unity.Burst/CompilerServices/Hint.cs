using System;

namespace Unity.Burst.CompilerServices
{
	// Token: 0x02000026 RID: 38
	public static class Hint
	{
		// Token: 0x06000139 RID: 313 RVA: 0x00007A20 File Offset: 0x00005C20
		public static bool Likely(bool condition)
		{
			return condition;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00007A23 File Offset: 0x00005C23
		public static bool Unlikely(bool condition)
		{
			return condition;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00007A26 File Offset: 0x00005C26
		public static void Assume(bool condition)
		{
		}
	}
}
