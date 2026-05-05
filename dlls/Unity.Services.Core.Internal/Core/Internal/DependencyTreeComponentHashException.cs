using System;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000045 RID: 69
	internal class DependencyTreeComponentHashException : HashException
	{
		// Token: 0x06000133 RID: 307 RVA: 0x000037D3 File Offset: 0x000019D3
		public DependencyTreeComponentHashException(int hash) : base(hash)
		{
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000037DC File Offset: 0x000019DC
		public DependencyTreeComponentHashException(int hash, string message) : base(hash, message)
		{
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000037E6 File Offset: 0x000019E6
		public DependencyTreeComponentHashException(int hash, string message, Exception inner) : base(hash, message, inner)
		{
		}
	}
}
