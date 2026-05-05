using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kamgam.UGUIBlurredBackground.EditorSingleton
{
	// Token: 0x0200001A RID: 26
	[ExecuteAlways]
	public class EditorMonoBehaviour : MonoBehaviour
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00005094 File Offset: 0x00003294
		// (set) Token: 0x060000DF RID: 223 RVA: 0x0000509C File Offset: 0x0000329C
		public bool IsDestroyed { get; protected set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x000050A8 File Offset: 0x000032A8
		public static EditorMonoBehaviour Instance
		{
			get
			{
				if (EditorMonoBehaviour._instance == null || EditorMonoBehaviour._instance.IsDestroyed)
				{
					EditorMonoBehaviour._instance = EditorMonoBehaviour.FindRootObjectByType<EditorMonoBehaviour>(true);
					if (EditorMonoBehaviour._instance == null || EditorMonoBehaviour._instance.gameObject == null || EditorMonoBehaviour._instance.IsDestroyed)
					{
						GameObject gameObject = new GameObject(typeof(EditorMonoBehaviour).FullName);
						Object.DontDestroyOnLoad(gameObject);
						gameObject.hideFlags = (HideFlags.DontSaveInEditor | HideFlags.NotEditable | HideFlags.DontSaveInBuild | HideFlags.DontUnloadUnusedAsset);
						EditorMonoBehaviour._instance = gameObject.AddComponent<EditorMonoBehaviour>();
					}
				}
				return EditorMonoBehaviour._instance;
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00005138 File Offset: 0x00003338
		public static T FindRootObjectByType<T>(bool includeInactive) where T : Component
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (sceneAt.IsValid())
				{
					sceneAt.GetRootGameObjects(EditorMonoBehaviour._tmpSceneObjects);
					foreach (GameObject gameObject in EditorMonoBehaviour._tmpSceneObjects)
					{
						T component = gameObject.GetComponent<T>();
						if (!(component == null) && (includeInactive || component.gameObject.activeInHierarchy))
						{
							return component;
						}
					}
				}
			}
			return default(T);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000051EC File Offset: 0x000033EC
		public void OnEnable()
		{
			if (this.IsDestroyed)
			{
				return;
			}
			Action onEnableCallback = this.OnEnableCallback;
			if (onEnableCallback == null)
			{
				return;
			}
			onEnableCallback();
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00005207 File Offset: 0x00003407
		public void Update()
		{
			if (this.IsDestroyed)
			{
				return;
			}
			Action onUpdateCallback = this.OnUpdateCallback;
			if (onUpdateCallback == null)
			{
				return;
			}
			onUpdateCallback();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00005222 File Offset: 0x00003422
		public void OnDisable()
		{
			if (this.IsDestroyed)
			{
				return;
			}
			Action onDisableCallback = this.OnDisableCallback;
			if (onDisableCallback == null)
			{
				return;
			}
			onDisableCallback();
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000523D File Offset: 0x0000343D
		public void OnDestroy()
		{
			this.IsDestroyed = true;
			Action onDestroyCallback = this.OnDestroyCallback;
			if (onDestroyCallback == null)
			{
				return;
			}
			onDestroyCallback();
		}

		// Token: 0x04000074 RID: 116
		public Action OnEnableCallback;

		// Token: 0x04000075 RID: 117
		public Action OnUpdateCallback;

		// Token: 0x04000076 RID: 118
		public Action OnDisableCallback;

		// Token: 0x04000077 RID: 119
		public Action OnDestroyCallback;

		// Token: 0x04000078 RID: 120
		private static EditorMonoBehaviour _instance;

		// Token: 0x04000079 RID: 121
		private static List<GameObject> _tmpSceneObjects = new List<GameObject>(20);
	}
}
