using System;
using UnityEngine;

// Token: 0x020001FB RID: 507
public class PlayCrashSound : MonoBehaviour
{
	// Token: 0x060007F0 RID: 2032 RVA: 0x00038E24 File Offset: 0x00037024
	private void Start()
	{
		this.soundGameObject = GameObject.Find("SoundFX_Manager");
		this.soundManager = this.soundGameObject.GetComponent<SoundManager>();
		this.networkParent = GameObject.Find("MultiPlayerWithComponenets");
		if (this.networkParent != null)
		{
			this.networkSoundManager = this.networkParent.GetComponent<NetworkSoundManager>();
		}
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x00038E81 File Offset: 0x00037081
	private void OnTriggerEnter(Collider other)
	{
		this.soundManager.PlayScooterCrashHitSound();
		if (this.networkSoundManager != null)
		{
			this.networkSoundManager.PlayScooterCrashHitSound();
		}
	}

	// Token: 0x04000DAB RID: 3499
	private GameObject soundGameObject;

	// Token: 0x04000DAC RID: 3500
	private SoundManager soundManager;

	// Token: 0x04000DAD RID: 3501
	private GameObject networkParent;

	// Token: 0x04000DAE RID: 3502
	private NetworkSoundManager networkSoundManager;
}
