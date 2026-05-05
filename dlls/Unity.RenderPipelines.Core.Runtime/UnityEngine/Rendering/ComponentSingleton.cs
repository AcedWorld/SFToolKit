using System;

namespace UnityEngine.Rendering
{
	// Token: 0x02000036 RID: 54
	public static class ComponentSingleton<TType> where TType : Component
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001FF RID: 511 RVA: 0x0000A310 File Offset: 0x00008510
		public static TType instance
		{
			get
			{
				if (ComponentSingleton<TType>.s_Instance == null)
				{
					GameObject gameObject = new GameObject("Default " + typeof(TType).Name);
					gameObject.hideFlags = HideFlags.HideAndDontSave;
					Object.DontDestroyOnLoad(gameObject);
					gameObject.SetActive(false);
					ComponentSingleton<TType>.s_Instance = gameObject.AddComponent<TType>();
				}
				return ComponentSingleton<TType>.s_Instance;
			}
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000A371 File Offset: 0x00008571
		public static void Release()
		{
			if (ComponentSingleton<TType>.s_Instance != null)
			{
				CoreUtils.Destroy(ComponentSingleton<TType>.s_Instance.gameObject);
				ComponentSingleton<TType>.s_Instance = default(TType);
			}
		}

		// Token: 0x04000140 RID: 320
		private static TType s_Instance;
	}
}
