using System;
using TMPro;
using UnityEngine;

// Token: 0x020000EF RID: 239
public class NoseManualToolTip : MonoBehaviour
{
	// Token: 0x060003FC RID: 1020 RVA: 0x0001D04E File Offset: 0x0001B24E
	private void Start()
	{
		this.animator.SetTrigger("StartAnimation");
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x0001D060 File Offset: 0x0001B260
	private void Update()
	{
		float t = Mathf.InverseLerp(this.minY, this.maxY, this.rectTransform.anchoredPosition.y);
		this.percentage = Mathf.RoundToInt(Mathf.Lerp(0f, 50f, t));
		this.PercentageText.text = this.percentage.ToString() + "%";
	}

	// Token: 0x040005D7 RID: 1495
	public RectTransform rectTransform;

	// Token: 0x040005D8 RID: 1496
	public float minY = -7f;

	// Token: 0x040005D9 RID: 1497
	public float maxY = 7f;

	// Token: 0x040005DA RID: 1498
	public int percentage;

	// Token: 0x040005DB RID: 1499
	public TMP_Text PercentageText;

	// Token: 0x040005DC RID: 1500
	public Animator animator;
}
