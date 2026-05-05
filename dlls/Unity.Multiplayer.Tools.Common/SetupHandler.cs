using System;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200000A RID: 10
	internal abstract class SetupHandler : IEditorSetupHandler, IContext, IRuntimeSetupHandler
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000212E File Offset: 0x0000032E
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002136 File Offset: 0x00000336
		private protected SetupHandler.ContextStatus Status { protected get; private set; }

		// Token: 0x0600000C RID: 12 RVA: 0x0000213F File Offset: 0x0000033F
		void IEditorSetupHandler.EditorSetup()
		{
			this.Status = SetupHandler.ContextStatus.EnabledInEditor;
			this.Setup();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000214E File Offset: 0x0000034E
		void IRuntimeSetupHandler.RuntimeSetup()
		{
			if (this.Status == SetupHandler.ContextStatus.EnabledInEditor)
			{
				return;
			}
			this.Status = SetupHandler.ContextStatus.EnabledInRuntime;
			this.Setup();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002167 File Offset: 0x00000367
		void IRuntimeSetupHandler.RuntimeTeardown()
		{
			if (this.Status == SetupHandler.ContextStatus.EnabledInEditor)
			{
				return;
			}
			this.EnsureTeardown();
		}

		// Token: 0x0600000F RID: 15
		protected abstract void Setup();

		// Token: 0x06000010 RID: 16
		protected abstract void Teardown();

		// Token: 0x06000011 RID: 17 RVA: 0x0000217C File Offset: 0x0000037C
		private void EnsureTeardown()
		{
			try
			{
				this.Teardown();
			}
			finally
			{
				this.Status = SetupHandler.ContextStatus.Disabled;
			}
		}

		// Token: 0x02000025 RID: 37
		protected enum ContextStatus
		{
			// Token: 0x04000026 RID: 38
			Disabled,
			// Token: 0x04000027 RID: 39
			EnabledInEditor,
			// Token: 0x04000028 RID: 40
			EnabledInRuntime
		}
	}
}
