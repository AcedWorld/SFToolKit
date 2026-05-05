using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kamgam.UGUIBlurredBackground.EditorSingleton
{
	// Token: 0x0200001B RID: 27
	public class EditorMonoBehaviourSingleton<T> where T : EditorMonoBehaviourSingleton<T>, new()
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x0000526C File Offset: 0x0000346C
		public static T Instance
		{
			get
			{
				if (EditorMonoBehaviourSingleton<T>._instance == null)
				{
					EditorMonoBehaviourSingleton<T>._instance = Activator.CreateInstance<T>();
				}
				return EditorMonoBehaviourSingleton<T>._instance;
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00005289 File Offset: 0x00003489
		public static void Destroy()
		{
			if (EditorMonoBehaviourSingleton<T>._instance != null)
			{
				EditorMonoBehaviourSingleton<T>.SmartDestroy(EditorMonoBehaviourSingleton<T>._instance.MonoBehaviour);
				EditorMonoBehaviourSingleton<T>._instance = default(T);
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000052B6 File Offset: 0x000034B6
		public static void SmartDestroy(Object obj)
		{
			if (obj == null)
			{
				return;
			}
			Object.Destroy(obj);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000052C8 File Offset: 0x000034C8
		protected virtual string getMonoBehaviourName()
		{
			return null;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000052CB File Offset: 0x000034CB
		public EditorMonoBehaviourSingleton()
		{
			this.createMonoBehaviour();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000052DC File Offset: 0x000034DC
		~EditorMonoBehaviourSingleton()
		{
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005304 File Offset: 0x00003504
		public void Refresh()
		{
			this.createMonoBehaviour();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000530C File Offset: 0x0000350C
		protected void createMonoBehaviour()
		{
			if ((this.MonoBehaviour == null || this.MonoBehaviour.IsDestroyed) && EditorMonoBehaviourSingleton<T>.IsSceneAccessible())
			{
				this.MonoBehaviour = EditorMonoBehaviour.Instance;
				if (!string.IsNullOrEmpty(this.getMonoBehaviourName()))
				{
					this.MonoBehaviour.gameObject.name = this.getMonoBehaviourName();
				}
				EditorMonoBehaviour monoBehaviour = this.MonoBehaviour;
				monoBehaviour.OnEnableCallback = (Action)Delegate.Combine(monoBehaviour.OnEnableCallback, new Action(this.onEnable));
				EditorMonoBehaviour monoBehaviour2 = this.MonoBehaviour;
				monoBehaviour2.OnUpdateCallback = (Action)Delegate.Combine(monoBehaviour2.OnUpdateCallback, new Action(this.onUpdate));
				EditorMonoBehaviour monoBehaviour3 = this.MonoBehaviour;
				monoBehaviour3.OnDisableCallback = (Action)Delegate.Combine(monoBehaviour3.OnDisableCallback, new Action(this.onDisable));
				EditorMonoBehaviour monoBehaviour4 = this.MonoBehaviour;
				monoBehaviour4.OnDestroyCallback = (Action)Delegate.Combine(monoBehaviour4.OnDestroyCallback, new Action(this.onDestroy));
				this.onMonoBehaviourCreated();
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00005411 File Offset: 0x00003611
		protected virtual void onMonoBehaviourCreated()
		{
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005413 File Offset: 0x00003613
		protected void onEnable()
		{
			Action onEnable = this.OnEnable;
			if (onEnable == null)
			{
				return;
			}
			onEnable();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00005425 File Offset: 0x00003625
		protected void onUpdate()
		{
			Action onUpdate = this.OnUpdate;
			if (onUpdate == null)
			{
				return;
			}
			onUpdate();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00005437 File Offset: 0x00003637
		protected void onDisable()
		{
			Action onDisable = this.OnDisable;
			if (onDisable == null)
			{
				return;
			}
			onDisable();
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000544C File Offset: 0x0000364C
		protected void onDestroy()
		{
			if (this.MonoBehaviour != null)
			{
				EditorMonoBehaviour monoBehaviour = this.MonoBehaviour;
				monoBehaviour.OnEnableCallback = (Action)Delegate.Remove(monoBehaviour.OnEnableCallback, new Action(this.onEnable));
				EditorMonoBehaviour monoBehaviour2 = this.MonoBehaviour;
				monoBehaviour2.OnUpdateCallback = (Action)Delegate.Remove(monoBehaviour2.OnUpdateCallback, new Action(this.onUpdate));
				EditorMonoBehaviour monoBehaviour3 = this.MonoBehaviour;
				monoBehaviour3.OnDisableCallback = (Action)Delegate.Remove(monoBehaviour3.OnDisableCallback, new Action(this.onDisable));
				EditorMonoBehaviour monoBehaviour4 = this.MonoBehaviour;
				monoBehaviour4.OnDestroyCallback = (Action)Delegate.Remove(monoBehaviour4.OnDestroyCallback, new Action(this.onDestroy));
			}
			this.MonoBehaviour = null;
			Action onDestroy = this.OnDestroy;
			if (onDestroy == null)
			{
				return;
			}
			onDestroy();
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00005520 File Offset: 0x00003720
		public static bool IsSceneAccessible()
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				if (!SceneManager.GetSceneAt(i).IsValid())
				{
					return false;
				}
			}
			return SceneManager.sceneCount > 0;
		}

		// Token: 0x0400007A RID: 122
		private static T _instance;

		// Token: 0x0400007B RID: 123
		public Action OnEnable;

		// Token: 0x0400007C RID: 124
		public Action OnUpdate;

		// Token: 0x0400007D RID: 125
		public Action OnDisable;

		// Token: 0x0400007E RID: 126
		public Action OnDestroy;

		// Token: 0x0400007F RID: 127
		public EditorMonoBehaviour MonoBehaviour;
	}
}
