using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000080 RID: 128
	[Singleton(Name = "VisualScripting GlobalEventListener", Automatic = true, Persistent = true)]
	[DisableAnnotation]
	[AddComponentMenu("")]
	[IncludeInSettings(false)]
	[TypeIcon(typeof(MessageListener))]
	public sealed class GlobalMessageListener : MonoBehaviour, ISingleton
	{
		// Token: 0x060003C8 RID: 968 RVA: 0x00009458 File Offset: 0x00007658
		private void OnGUI()
		{
			EventBus.Trigger("OnGUI");
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00009469 File Offset: 0x00007669
		private void OnApplicationFocus(bool focus)
		{
			if (focus)
			{
				EventBus.Trigger("OnApplicationFocus");
				return;
			}
			EventBus.Trigger("OnApplicationLostFocus");
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000948D File Offset: 0x0000768D
		private void OnApplicationPause(bool paused)
		{
			if (paused)
			{
				EventBus.Trigger("OnApplicationPause");
				return;
			}
			EventBus.Trigger("OnApplicationResume");
		}

		// Token: 0x060003CB RID: 971 RVA: 0x000094B1 File Offset: 0x000076B1
		private void OnApplicationQuit()
		{
			EventBus.Trigger("OnApplicationQuit");
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000094C2 File Offset: 0x000076C2
		public static void Require()
		{
			GlobalMessageListener instance = Singleton<GlobalMessageListener>.instance;
		}
	}
}
