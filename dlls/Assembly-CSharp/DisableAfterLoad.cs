using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000148 RID: 328
public class DisableAfterLoad : MonoBehaviour
{
	// Token: 0x06000535 RID: 1333 RVA: 0x00024193 File Offset: 0x00022393
	private void Start()
	{
		base.StartCoroutine(this.DelayLoad());
		this.rewiredController = GameObject.Find("Controller_Info").GetComponent<RewiredController>();
	}

	// Token: 0x06000536 RID: 1334 RVA: 0x000020BE File Offset: 0x000002BE
	private void Update()
	{
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x000241B7 File Offset: 0x000223B7
	private IEnumerator DelayLoad()
	{
		yield return new WaitForSecondsRealtime(this.timeToLoad);
		this.CloseMenuPanels();
		yield break;
	}

	// Token: 0x06000538 RID: 1336 RVA: 0x000241C8 File Offset: 0x000223C8
	public void CloseMenuPanels()
	{
		GameObject[] array = this.menuPanels.windowsToClose;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		array = this.menuPanels.windowsToOpen;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(true);
		}
		array = this.menuPanels.itemsToDelete;
		for (int i = 0; i < array.Length; i++)
		{
			Object.Destroy(array[i]);
		}
		this.mainMenuLogic.allowInput = true;
		this.mainMenuLogic.UnhideCustomizePanel();
		if (this.rewiredController.controllerName == "")
		{
			this.ControllerDisconnected();
			return;
		}
		this.ControllerConnected();
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x00024278 File Offset: 0x00022478
	private void ControllerConnected()
	{
		this.loadScreen.SetActive(false);
		this.OnStartPressed();
		Debug.Log("Controller Connected");
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x00024296 File Offset: 0x00022496
	private void ControllerDisconnected()
	{
		this.loadIcon.SetActive(false);
		this.pressStartText.SetActive(true);
		Debug.Log("Controller Not Connected");
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x000242BA File Offset: 0x000224BA
	public void OnStartPressed()
	{
		EventSystem.current.SetSelectedGameObject(this.firstSelected);
	}

	// Token: 0x0400083D RID: 2109
	public float timeToLoad;

	// Token: 0x0400083E RID: 2110
	public GameObject firstSelected;

	// Token: 0x0400083F RID: 2111
	public MainMenuLogic mainMenuLogic;

	// Token: 0x04000840 RID: 2112
	public MenuPanels menuPanels;

	// Token: 0x04000841 RID: 2113
	private RewiredController rewiredController;

	// Token: 0x04000842 RID: 2114
	public GameObject loadScreen;

	// Token: 0x04000843 RID: 2115
	public GameObject loadIcon;

	// Token: 0x04000844 RID: 2116
	public GameObject pressStartText;
}
