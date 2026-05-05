using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200011F RID: 287
public class ApplySettingsOnStart : MonoBehaviour
{
	// Token: 0x060004AE RID: 1198 RVA: 0x00020EC7 File Offset: 0x0001F0C7
	private void Start()
	{
		if (this._loadScene)
		{
			base.StartCoroutine(this.delayToLoadMenu());
			return;
		}
		base.StartCoroutine(this.delayToAlt());
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x00020EEC File Offset: 0x0001F0EC
	private IEnumerator delayToLoadMenu()
	{
		yield return new WaitForSecondsRealtime(1f);
		this.loadScene.LoadSceneName();
		yield break;
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x00020EFB File Offset: 0x0001F0FB
	private IEnumerator delayToAlt()
	{
		yield return new WaitForSecondsRealtime(3f);
		Screen.SetResolution(800, 250, FullScreenMode.Windowed);
		this.windowSettings = true;
		this.Canvas.SetActive(true);
		yield break;
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x00020F0A File Offset: 0x0001F10A
	private void OnApplicationQuit()
	{
		if (this.windowSettings)
		{
			PlayerPrefs.DeleteKey("Screenmanager Resolution Height");
			PlayerPrefs.DeleteKey("Screenmanager Resolution Width");
		}
	}

	// Token: 0x04000712 RID: 1810
	public LoadScene loadScene;

	// Token: 0x04000713 RID: 1811
	public bool _loadScene;

	// Token: 0x04000714 RID: 1812
	public GameObject Canvas;

	// Token: 0x04000715 RID: 1813
	private bool windowSettings;
}
