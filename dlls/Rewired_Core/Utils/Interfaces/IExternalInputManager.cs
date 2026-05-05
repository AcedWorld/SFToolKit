using System;
using Rewired.Platforms;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x02000529 RID: 1321
	public interface IExternalInputManager
	{
		// Token: 0x0600364A RID: 13898
		object Initialize(Platform platform, object configVars);

		// Token: 0x0600364B RID: 13899
		void Deinitialize();
	}
}
