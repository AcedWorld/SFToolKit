using System;

namespace Invector.Utils
{
	// Token: 0x020003B0 RID: 944
	public interface vISceneLoadListener
	{
		// Token: 0x060012E3 RID: 4835
		void OnStartLoadScene(string sceneName);

		// Token: 0x060012E4 RID: 4836
		void OnFinishLoadScene(string sceneName);
	}
}
