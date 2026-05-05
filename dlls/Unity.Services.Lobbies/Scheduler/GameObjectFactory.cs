using System;
using UnityEngine;

namespace Unity.Services.Lobbies.Scheduler
{
	// Token: 0x0200002C RID: 44
	public static class GameObjectFactory
	{
		// Token: 0x06000145 RID: 325 RVA: 0x00006230 File Offset: 0x00004430
		public static GameObject CreateCoreSdkGameObject()
		{
			Random random = new Random();
			GameObject gameObject = new GameObject("_SdkCore-" + random.Next(0, int.MaxValue).ToString());
			gameObject.AddComponent<TaskSchedulerThreaded>();
			Object.DontDestroyOnLoad(gameObject);
			return gameObject;
		}
	}
}
