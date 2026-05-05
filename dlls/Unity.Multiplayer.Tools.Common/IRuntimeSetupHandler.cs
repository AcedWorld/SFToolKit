using System;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000009 RID: 9
	internal interface IRuntimeSetupHandler : IContext
	{
		// Token: 0x06000008 RID: 8
		void RuntimeSetup();

		// Token: 0x06000009 RID: 9
		void RuntimeTeardown();
	}
}
