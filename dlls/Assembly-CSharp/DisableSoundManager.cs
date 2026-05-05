using System;
using UnityEngine;

// Token: 0x020001F9 RID: 505
public class DisableSoundManager : MonoBehaviour
{
	// Token: 0x060007E6 RID: 2022 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x00038D10 File Offset: 0x00036F10
	private void Update()
	{
		if (this.timeChanged != Time.timeScale)
		{
			this.disableSoundManager();
			this.timeChanged = Time.timeScale;
		}
	}

	// Token: 0x060007E8 RID: 2024 RVA: 0x00038D30 File Offset: 0x00036F30
	public void disableSoundManager()
	{
		if (Time.timeScale != 1f)
		{
			this.soundManager.SetActive(false);
		}
		if (Time.timeScale == 1f)
		{
			this.soundManager.SetActive(true);
		}
	}

	// Token: 0x04000DA3 RID: 3491
	public GameObject soundManager;

	// Token: 0x04000DA4 RID: 3492
	private float timeChanged;
}
