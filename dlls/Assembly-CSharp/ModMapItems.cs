using System;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;

// Token: 0x020000FB RID: 251
[Serializable]
public class ModMapItems
{
	// Token: 0x04000616 RID: 1558
	public GameObject buttonPrefab;

	// Token: 0x04000617 RID: 1559
	public Transform buttonParent;

	// Token: 0x04000618 RID: 1560
	public GameObject modmapLoader;

	// Token: 0x04000619 RID: 1561
	public ModalWindowManager modalWindow;

	// Token: 0x0400061A RID: 1562
	public TMP_Text modalWindowTitle;

	// Token: 0x0400061B RID: 1563
	public GameObject modalWindowButton;

	// Token: 0x0400061C RID: 1564
	public GameObject playerComponents;

	// Token: 0x0400061D RID: 1565
	public CanvasGroup modalWindowCanvasGroup;

	// Token: 0x0400061E RID: 1566
	public ModalWindowManager noContentsWindow;

	// Token: 0x0400061F RID: 1567
	public GameObject noContentsButton;

	// Token: 0x04000620 RID: 1568
	public GameObject discordButton;

	// Token: 0x04000621 RID: 1569
	public GameObject communityMapsButton;

	// Token: 0x04000622 RID: 1570
	public OpenTipLoadScreen openTipLoadScreen;

	// Token: 0x04000623 RID: 1571
	public ProgressBar progressBar;
}
