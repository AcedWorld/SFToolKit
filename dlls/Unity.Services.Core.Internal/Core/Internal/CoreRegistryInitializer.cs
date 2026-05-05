using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Unity.Services.Core.Internal
{
	// Token: 0x0200003E RID: 62
	internal class CoreRegistryInitializer
	{
		// Token: 0x06000115 RID: 277 RVA: 0x00002F9A File Offset: 0x0000119A
		public CoreRegistryInitializer([NotNull] CoreRegistry registry, [NotNull] List<int> sortedPackageTypeHashes)
		{
			this.m_Registry = registry;
			this.m_SortedPackageTypeHashes = sortedPackageTypeHashes;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00002FB0 File Offset: 0x000011B0
		public Task<List<PackageInitializationInfo>> InitializeRegistryAsync()
		{
			CoreRegistryInitializer.<InitializeRegistryAsync>d__3 <InitializeRegistryAsync>d__;
			<InitializeRegistryAsync>d__.<>t__builder = AsyncTaskMethodBuilder<List<PackageInitializationInfo>>.Create();
			<InitializeRegistryAsync>d__.<>4__this = this;
			<InitializeRegistryAsync>d__.<>1__state = -1;
			<InitializeRegistryAsync>d__.<>t__builder.Start<CoreRegistryInitializer.<InitializeRegistryAsync>d__3>(ref <InitializeRegistryAsync>d__);
			return <InitializeRegistryAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04000045 RID: 69
		[NotNull]
		private readonly CoreRegistry m_Registry;

		// Token: 0x04000046 RID: 70
		[NotNull]
		private readonly List<int> m_SortedPackageTypeHashes;
	}
}
