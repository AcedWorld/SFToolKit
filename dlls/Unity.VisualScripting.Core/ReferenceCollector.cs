using System;
using UnityEngine.SceneManagement;

namespace Unity.VisualScripting
{
	// Token: 0x02000162 RID: 354
	public static class ReferenceCollector
	{
		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000963 RID: 2403 RVA: 0x00028694 File Offset: 0x00026894
		// (remove) Token: 0x06000964 RID: 2404 RVA: 0x000286C8 File Offset: 0x000268C8
		public static event Action onSceneUnloaded;

		// Token: 0x06000965 RID: 2405 RVA: 0x000286FB File Offset: 0x000268FB
		internal static void Initialize()
		{
			SceneManager.sceneUnloaded += delegate(Scene scene)
			{
				Action action = ReferenceCollector.onSceneUnloaded;
				if (action == null)
				{
					return;
				}
				action();
			};
		}
	}
}
