using System;
using System.Runtime.CompilerServices;

namespace Unity.Burst.CompilerServices
{
	// Token: 0x02000025 RID: 37
	public static class Constant
	{
		// Token: 0x06000137 RID: 311 RVA: 0x00007A1A File Offset: 0x00005C1A
		public static bool IsConstantExpression<[IsUnmanaged] T>(T t) where T : struct, ValueType
		{
			return false;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00007A1D File Offset: 0x00005C1D
		public unsafe static bool IsConstantExpression(void* t)
		{
			return false;
		}
	}
}
