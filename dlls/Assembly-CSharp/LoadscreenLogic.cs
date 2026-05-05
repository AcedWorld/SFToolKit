using System;
using UnityEngine;

// Token: 0x020000BF RID: 191
public class LoadscreenLogic : MonoBehaviour
{
	// Token: 0x06000346 RID: 838 RVA: 0x00019EC4 File Offset: 0x000180C4
	private void Start()
	{
		this.canvasGroup = base.GetComponent<CanvasGroup>();
	}

	// Token: 0x06000347 RID: 839 RVA: 0x00019ED2 File Offset: 0x000180D2
	private void Update()
	{
		if (this.canvasGroup.alpha == 0f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04000498 RID: 1176
	private CanvasGroup canvasGroup;
}
