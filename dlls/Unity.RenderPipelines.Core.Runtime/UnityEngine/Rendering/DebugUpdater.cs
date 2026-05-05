using System;
using System.Collections;
using UnityEngine.EventSystems;

namespace UnityEngine.Rendering
{
	// Token: 0x02000069 RID: 105
	internal class DebugUpdater : MonoBehaviour
	{
		// Token: 0x06000377 RID: 887 RVA: 0x0000F8C9 File Offset: 0x0000DAC9
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void RuntimeInit()
		{
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000F8CB File Offset: 0x0000DACB
		internal static void SetEnabled(bool enabled)
		{
			if (enabled)
			{
				DebugUpdater.EnableRuntime();
				return;
			}
			DebugUpdater.DisableRuntime();
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000F8DC File Offset: 0x0000DADC
		private static void EnableRuntime()
		{
			if (DebugUpdater.s_Instance != null)
			{
				return;
			}
			GameObject gameObject = new GameObject();
			gameObject.name = "[Debug Updater]";
			DebugUpdater.s_Instance = gameObject.AddComponent<DebugUpdater>();
			DebugUpdater.s_Instance.m_Orientation = Screen.orientation;
			Object.DontDestroyOnLoad(gameObject);
			DebugManager.instance.EnableInputActions();
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000F930 File Offset: 0x0000DB30
		private static void DisableRuntime()
		{
			DebugManager instance = DebugManager.instance;
			instance.displayRuntimeUI = false;
			instance.displayPersistentRuntimeUI = false;
			if (DebugUpdater.s_Instance != null)
			{
				CoreUtils.Destroy(DebugUpdater.s_Instance.gameObject);
				DebugUpdater.s_Instance = null;
			}
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000F966 File Offset: 0x0000DB66
		internal static void HandleInternalEventSystemComponents(bool uiEnabled)
		{
			if (DebugUpdater.s_Instance == null)
			{
				return;
			}
			if (uiEnabled)
			{
				DebugUpdater.s_Instance.EnsureExactlyOneEventSystem();
				return;
			}
			DebugUpdater.s_Instance.DestroyDebugEventSystem();
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000F990 File Offset: 0x0000DB90
		private void EnsureExactlyOneEventSystem()
		{
			EventSystem[] array = Object.FindObjectsOfType<EventSystem>();
			EventSystem component = base.GetComponent<EventSystem>();
			if (array.Length > 1 && component != null)
			{
				Debug.Log("More than one EventSystem detected in scene. Destroying EventSystem owned by DebugUpdater.");
				this.DestroyDebugEventSystem();
				return;
			}
			if (array.Length == 0)
			{
				Debug.Log("No EventSystem available. Creating a new EventSystem to enable Rendering Debugger runtime UI.");
				this.CreateDebugEventSystem();
				return;
			}
			base.StartCoroutine(this.DoAfterInputModuleUpdated(new Action(this.CheckInputModuleExists)));
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0000F9F8 File Offset: 0x0000DBF8
		private IEnumerator DoAfterInputModuleUpdated(Action action)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			action();
			yield break;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000FA07 File Offset: 0x0000DC07
		private void CheckInputModuleExists()
		{
			if (EventSystem.current != null && EventSystem.current.currentInputModule == null)
			{
				Debug.LogWarning("Found a game object with EventSystem component but no corresponding BaseInputModule component - Debug UI input might not work correctly.");
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0000FA32 File Offset: 0x0000DC32
		private void CreateDebugEventSystem()
		{
			base.gameObject.AddComponent<EventSystem>();
			base.gameObject.AddComponent<StandaloneInputModule>();
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0000FA4C File Offset: 0x0000DC4C
		private void DestroyDebugEventSystem()
		{
			Object component = base.GetComponent<EventSystem>();
			CoreUtils.Destroy(base.GetComponent<StandaloneInputModule>());
			CoreUtils.Destroy(base.GetComponent<BaseInput>());
			CoreUtils.Destroy(component);
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000FA70 File Offset: 0x0000DC70
		private void Update()
		{
			DebugManager instance = DebugManager.instance;
			if (this.m_RuntimeUiWasVisibleLastFrame != instance.displayRuntimeUI)
			{
				DebugUpdater.HandleInternalEventSystemComponents(instance.displayRuntimeUI);
			}
			instance.UpdateActions();
			if (instance.GetAction(DebugAction.EnableDebugMenu) != 0f || instance.GetActionToggleDebugMenuWithTouch())
			{
				instance.displayRuntimeUI = !instance.displayRuntimeUI;
			}
			if (instance.displayRuntimeUI)
			{
				if (instance.GetAction(DebugAction.ResetAll) != 0f)
				{
					instance.Reset();
				}
				if (instance.GetActionReleaseScrollTarget())
				{
					instance.SetScrollTarget(null);
				}
			}
			if (this.m_Orientation != Screen.orientation)
			{
				base.StartCoroutine(DebugUpdater.RefreshRuntimeUINextFrame());
				this.m_Orientation = Screen.orientation;
			}
			this.m_RuntimeUiWasVisibleLastFrame = instance.displayRuntimeUI;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0000FB22 File Offset: 0x0000DD22
		private static IEnumerator RefreshRuntimeUINextFrame()
		{
			yield return null;
			DebugManager.instance.ReDrawOnScreenDebug();
			yield break;
		}

		// Token: 0x040001F6 RID: 502
		private static DebugUpdater s_Instance;

		// Token: 0x040001F7 RID: 503
		private ScreenOrientation m_Orientation;

		// Token: 0x040001F8 RID: 504
		private bool m_RuntimeUiWasVisibleLastFrame;
	}
}
