using System;
using System.Threading.Tasks;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000047 RID: 71
	public interface IInitializablePackageV2 : IInitializablePackage
	{
		// Token: 0x06000137 RID: 311
		void Register(CorePackageRegistry registry);

		// Token: 0x06000138 RID: 312
		Task InitializeInstanceAsync(CoreRegistry registry);
	}
}
