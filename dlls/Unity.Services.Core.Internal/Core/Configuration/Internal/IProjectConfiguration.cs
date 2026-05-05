using System;
using Unity.Services.Core.Internal;

namespace Unity.Services.Core.Configuration.Internal
{
	// Token: 0x02000024 RID: 36
	public interface IProjectConfiguration : IServiceComponent
	{
		// Token: 0x06000064 RID: 100
		bool GetBool(string key, bool defaultValue = false);

		// Token: 0x06000065 RID: 101
		int GetInt(string key, int defaultValue = 0);

		// Token: 0x06000066 RID: 102
		float GetFloat(string key, float defaultValue = 0f);

		// Token: 0x06000067 RID: 103
		string GetString(string key, string defaultValue = null);
	}
}
