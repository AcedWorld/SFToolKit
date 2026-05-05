using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Netcode
{
	// Token: 0x020000DF RID: 223
	public class SceneEvent
	{
		// Token: 0x04000277 RID: 631
		public AsyncOperation AsyncOperation;

		// Token: 0x04000278 RID: 632
		public SceneEventType SceneEventType;

		// Token: 0x04000279 RID: 633
		public LoadSceneMode LoadSceneMode;

		// Token: 0x0400027A RID: 634
		public string SceneName;

		// Token: 0x0400027B RID: 635
		public Scene Scene;

		// Token: 0x0400027C RID: 636
		public ulong ClientId;

		// Token: 0x0400027D RID: 637
		public List<ulong> ClientsThatCompleted;

		// Token: 0x0400027E RID: 638
		public List<ulong> ClientsThatTimedOut;
	}
}
