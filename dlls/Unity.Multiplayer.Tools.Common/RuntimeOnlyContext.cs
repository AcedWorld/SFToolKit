using System;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200000C RID: 12
	internal abstract class RuntimeOnlyContext : IRuntimeSetupHandler, IContext
	{
		// Token: 0x06000016 RID: 22 RVA: 0x000021C4 File Offset: 0x000003C4
		void IRuntimeSetupHandler.RuntimeSetup()
		{
			this.Setup();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000021CC File Offset: 0x000003CC
		public void RuntimeTeardown()
		{
			this.Teardown();
		}

		// Token: 0x06000018 RID: 24
		protected abstract void Setup();

		// Token: 0x06000019 RID: 25
		protected abstract void Teardown();
	}
}
