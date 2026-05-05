using System;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000044 RID: 68
	internal class DependencyTreePackageHashException : HashException
	{
		// Token: 0x06000130 RID: 304 RVA: 0x000037B5 File Offset: 0x000019B5
		public DependencyTreePackageHashException(int hash) : base(hash)
		{
		}

		// Token: 0x06000131 RID: 305 RVA: 0x000037BE File Offset: 0x000019BE
		public DependencyTreePackageHashException(int hash, string message) : base(hash, message)
		{
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000037C8 File Offset: 0x000019C8
		public DependencyTreePackageHashException(int hash, string message, Exception inner) : base(hash, message, inner)
		{
		}
	}
}
