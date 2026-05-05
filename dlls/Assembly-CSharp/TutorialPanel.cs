using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000213 RID: 531
public class TutorialPanel : MonoBehaviour
{
	// Token: 0x06000864 RID: 2148 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x000020BE File Offset: 0x000002BE
	private void Update()
	{
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x0003B448 File Offset: 0x00039648
	public void OpenPanel(string title, string description)
	{
		this.titleText.text = title;
		this.descriptionText.text = description;
		this.canvasGroup.alpha = 1f;
		this.canvasGroup.interactable = true;
		this.canvasGroup.blocksRaycasts = true;
		EventSystem.current.SetSelectedGameObject(this.button.gameObject);
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x0003B4AA File Offset: 0x000396AA
	public void ClosePanel()
	{
		this.canvasGroup.alpha = 0f;
		this.canvasGroup.interactable = false;
		this.canvasGroup.blocksRaycasts = false;
		EventSystem.current.SetSelectedGameObject(null);
	}

	// Token: 0x04000EA2 RID: 3746
	public CanvasGroup canvasGroup;

	// Token: 0x04000EA3 RID: 3747
	public TMP_Text titleText;

	// Token: 0x04000EA4 RID: 3748
	public TMP_Text descriptionText;

	// Token: 0x04000EA5 RID: 3749
	public Button button;
}
