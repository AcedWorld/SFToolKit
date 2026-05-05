using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000178 RID: 376
	[Singleton(Name = "VisualScripting SavedVariablesSerializer", Automatic = true, Persistent = true)]
	[AddComponentMenu("")]
	[DisableAnnotation]
	[IncludeInSettings(false)]
	public class VariablesSaver : MonoBehaviour, ISingleton
	{
		// Token: 0x06000A07 RID: 2567 RVA: 0x00029B0D File Offset: 0x00027D0D
		private void Awake()
		{
			Singleton<VariablesSaver>.Awake(this);
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x00029B15 File Offset: 0x00027D15
		private void OnDestroy()
		{
			Singleton<VariablesSaver>.OnDestroy(this);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00029B1D File Offset: 0x00027D1D
		private void OnApplicationQuit()
		{
			SavedVariables.OnExitPlayMode();
			ApplicationVariables.OnExitPlayMode();
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00029B29 File Offset: 0x00027D29
		private void OnApplicationPause(bool isPaused)
		{
			if (!isPaused)
			{
				return;
			}
			SavedVariables.OnExitPlayMode();
			ApplicationVariables.OnExitPlayMode();
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x00029B39 File Offset: 0x00027D39
		public static VariablesSaver instance
		{
			get
			{
				return Singleton<VariablesSaver>.instance;
			}
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00029B40 File Offset: 0x00027D40
		public static void Instantiate()
		{
			Singleton<VariablesSaver>.Instantiate();
		}
	}
}
