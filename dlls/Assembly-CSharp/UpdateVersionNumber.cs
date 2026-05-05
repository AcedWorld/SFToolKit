using System;
using TMPro;
using UnityEngine;

// Token: 0x020001D3 RID: 467
public class UpdateVersionNumber : MonoBehaviour
{
	// Token: 0x0600074E RID: 1870 RVA: 0x00036AE3 File Offset: 0x00034CE3
	private void Start()
	{
		this.versionNumberText = base.GetComponent<TMP_Text>();
		this.UpdateText();
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x00036AF7 File Offset: 0x00034CF7
	private void UpdateText()
	{
		this.versionNumberText.text = "SCOOTERFLOW (BETA) V" + Application.version;
	}

	// Token: 0x04000CDF RID: 3295
	private TMP_Text versionNumberText;
}
