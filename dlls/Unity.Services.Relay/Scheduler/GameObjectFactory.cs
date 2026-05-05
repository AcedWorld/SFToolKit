using System;
using UnityEngine;

namespace Unity.Services.Relay.Scheduler
{
	// Token: 0x02000016 RID: 22
	public static class GameObjectFactory
	{
		// Token: 0x06000040 RID: 64 RVA: 0x000027D8 File Offset: 0x000009D8
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
