using System;
using UnityEngine;

// Token: 0x020001FC RID: 508
public class PlayHelmetHitSound : MonoBehaviour
{
	// Token: 0x060007F3 RID: 2035 RVA: 0x00038EA8 File Offset: 0x000370A8
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

	// Token: 0x060007F4 RID: 2036 RVA: 0x00038F05 File Offset: 0x00037105
	private void OnTriggerStay(Collider other)
	{
		this.colliding = true;
	}

	// Token: 0x060007F5 RID: 2037 RVA: 0x00038F0E File Offset: 0x0003710E
	private void OnTriggerExit(Collider other)
	{
		this.colliding = false;
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x00038F17 File Offset: 0x00037117
	private void Update()
	{
		if (this.onCollision != this.colliding)
		{
			this.PlaySound();
			this.onCollision = this.colliding;
		}
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x00038F39 File Offset: 0x00037139
	public void PlaySound()
	{
		if (this.colliding)
		{
			this.soundManager.PlayHelmetHit();
			if (this.networkSoundManager != null)
			{
				this.networkSoundManager.PlayHelmetHit();
			}
		}
	}

	// Token: 0x04000DAF RID: 3503
	private GameObject soundGameObject;

	// Token: 0x04000DB0 RID: 3504
	private SoundManager soundManager;

	// Token: 0x04000DB1 RID: 3505
	public bool colliding;

	// Token: 0x04000DB2 RID: 3506
	private bool onCollision;

	// Token: 0x04000DB3 RID: 3507
	private GameObject networkParent;

	// Token: 0x04000DB4 RID: 3508
	private NetworkSoundManager networkSoundManager;
}
