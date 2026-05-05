using System;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200000B RID: 11
	internal abstract class EditorOnlyContext : IEditorSetupHandler, IContext
	{
		// Token: 0x06000013 RID: 19 RVA: 0x000021B4 File Offset: 0x000003B4
		void IEditorSetupHandler.EditorSetup()
		{
			this.Setup();
		}

		// Token: 0x06000014 RID: 20
		protected abstract void Setup();
	}
}
