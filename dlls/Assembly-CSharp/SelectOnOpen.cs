using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001C1 RID: 449
public class SelectOnOpen : MonoBehaviour
{
	// Token: 0x060006FE RID: 1790 RVA: 0x000340B6 File Offset: 0x000322B6
	private void Start()
	{
		this.canvasGroup = base.GetComponent<CanvasGroup>();
		if (this.List.transform.childCount > 0)
		{
			this.selectable = this.List.transform.GetChild(0).gameObject;
		}
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x000340F3 File Offset: 0x000322F3
	private void Update()
	{
		if (this.interactabe != this.canvasGroup.interactable)
		{
			this.updateSelected();
			this.interactabe = this.canvasGroup.interactable;
		}
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0003411F File Offset: 0x0003231F
	public void updateSelected()
	{
		if (this.canvasGroup.interactable && this.mainMenuLogic.references.customizeMenu)
		{
			EventSystem.current.SetSelectedGameObject(this.selectable);
		}
	}

	// Token: 0x04000C5F RID: 3167
	public MainMenuLogic mainMenuLogic;

	// Token: 0x04000C60 RID: 3168
	private CanvasGroup canvasGroup;

	// Token: 0x04000C61 RID: 3169
	public GameObject List;

	// Token: 0x04000C62 RID: 3170
	private bool interactabe;

	// Token: 0x04000C63 RID: 3171
	private GameObject selectable;
}
