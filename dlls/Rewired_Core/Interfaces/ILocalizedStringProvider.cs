using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001F7 RID: 503
	public interface ILocalizedStringProvider
	{
		// Token: 0x06001923 RID: 6435
		bool TryGetLocalizedString(string key, out string result);
	}
}
