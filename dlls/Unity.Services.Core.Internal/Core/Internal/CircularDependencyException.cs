using System;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000037 RID: 55
	public class CircularDependencyException : ServicesInitializationException
	{
		// Token: 0x060000DE RID: 222 RVA: 0x00002B64 File Offset: 0x00000D64
		public CircularDependencyException()
		{
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00002B6C File Offset: 0x00000D6C
		public CircularDependencyException(string message) : base(message)
		{
		}
	}
}
