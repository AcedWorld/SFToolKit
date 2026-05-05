using System;
using System.Collections;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Token: 0x0200016E RID: 366
public class MapLoadBrain : MonoBehaviour
{
	// Token: 0x060005E7 RID: 1511 RVA: 0x0002B78C File Offset: 0x0002998C
	public void buttonPressed()
	{
		this.mapTitleText.text = this.MapTitle;
		this.mainMenuLogic.allowInput = false;
		this.cachedButton = EventSystem.current.currentSelectedGameObject;
		this.mapLoadScreen.OpenWindow();
		EventSystem.current.SetSelectedGameObject(this.loadButton);
	}

	// Token: 0x060005E8 RID: 1512 RVA: 0x0002B7E1 File Offset: 0x000299E1
	public void LoadLevel()
	{
		EventSystem.current.SetSelectedGameObject(null);
		this.openTipLoadScreen.OpenLoadScreen();
		this.progressBar.isOn = true;
		base.StartCoroutine(this.DelayLoadScene());
	}

	// Token: 0x060005E9 RID: 1513 RVA: 0x0002B812 File Offset: 0x00029A12
	private IEnumerator DelayLoadScene()
	{
		this.progressBar.gameObject.SetActive(true);
		yield return new WaitForSeconds((float)this.loadSceneTime);
		this.cachedLoadValue = this.progressBar.currentPercent + 0f;
		this.LoadSceneAsync();
		yield break;
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x0002B824 File Offset: 0x00029A24
	private void LoadSceneAsync()
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(this.sceneName);
		base.StartCoroutine(this.UpdateProgressBar(asyncLoad));
	}

	// Token: 0x060005EB RID: 1515 RVA: 0x0002B84B File Offset: 0x00029A4B
	private IEnumerator UpdateProgressBar(AsyncOperation asyncLoad)
	{
		while (!asyncLoad.isDone)
		{
			float num = this.cachedLoadValue + asyncLoad.progress * (1f - this.cachedLoadValue);
			num = Mathf.Clamp01(num);
			this.progressBar.currentPercent = (float)Mathf.FloorToInt(num * 100f);
			this.progressBar.UpdateUI();
			yield return null;
		}
		yield break;
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x0002B861 File Offset: 0x00029A61
	public void CancelLoadMap()
	{
		EventSystem.current.SetSelectedGameObject(this.cachedButton);
		this.mainMenuLogic.allowInput = true;
	}

	// Token: 0x040009CE RID: 2510
	public string sceneName;

	// Token: 0x040009CF RID: 2511
	public string MapTitle;

	// Token: 0x040009D0 RID: 2512
	public ModalWindowManager mapLoadScreen;

	// Token: 0x040009D1 RID: 2513
	public TMP_Text mapTitleText;

	// Token: 0x040009D2 RID: 2514
	public MainMenuLogic mainMenuLogic;

	// Token: 0x040009D3 RID: 2515
	public GameObject loadButton;

	// Token: 0x040009D4 RID: 2516
	public ProgressBar progressBar;

	// Token: 0x040009D5 RID: 2517
	public OpenTipLoadScreen openTipLoadScreen;

	// Token: 0x040009D6 RID: 2518
	public int loadSceneTime;

	// Token: 0x040009D7 RID: 2519
	private GameObject cachedButton;

	// Token: 0x040009D8 RID: 2520
	public float cachedLoadValue;
}
