using System;
using System.Threading.Tasks;

namespace Unity.Services.Core
{
	// Token: 0x0200000C RID: 12
	public interface IUnityServices
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000020 RID: 32
		// (remove) Token: 0x06000021 RID: 33
		event Action Initialized;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000022 RID: 34
		// (remove) Token: 0x06000023 RID: 35
		event Action<Exception> InitializeFailed;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000024 RID: 36
		ServicesInitializationState State { get; }

		// Token: 0x06000025 RID: 37
		Task InitializeAsync(InitializationOptions options = null);

		// Token: 0x06000026 RID: 38 RVA: 0x000022A9 File Offset: 0x000004A9
		string GetIdentifier()
		{
			return null;
		}

		// Token: 0x06000027 RID: 39
		T GetService<T>();
	}
}
