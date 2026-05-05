using System;
using System.Threading.Tasks;

namespace Unity.Services.Core.Internal
{
	// Token: 0x02000046 RID: 70
	public interface IInitializablePackage
	{
		// Token: 0x06000136 RID: 310
		Task Initialize(CoreRegistry registry);
	}
}
