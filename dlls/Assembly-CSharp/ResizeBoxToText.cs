using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000B6 RID: 182
public class ResizeBoxToText : MonoBehaviour
{
	// Token: 0x06000313 RID: 787 RVA: 0x00018023 File Offset: 0x00016223
	private void Update()
	{
		this.ResizeBox();
	}

	// Token: 0x06000314 RID: 788 RVA: 0x0001802C File Offset: 0x0001622C
	private void ResizeBox()
	{
		Vector2 zero = Vector2.zero;
		if (this.textUI != null)
		{
			zero = new Vector2(this.textUI.preferredWidth, this.textUI.preferredHeight);
		}
		else if (this.textTMP != null)
		{
			zero = new Vector2(this.textTMP.preferredWidth, this.textTMP.preferredHeight);
		}
		this.backgroundBox.sizeDelta = zero + this.padding;
	}

	// Token: 0x04000420 RID: 1056
	public RectTransform backgroundBox;

	// Token: 0x04000421 RID: 1057
	public Text textUI;

	// Token: 0x04000422 RID: 1058
	public TextMeshProUGUI textTMP;

	// Token: 0x04000423 RID: 1059
	public Vector2 padding = new Vector2(10f, 10f);
}
