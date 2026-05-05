using System;
using UnityEngine;

// Token: 0x020001FA RID: 506
public class PlayBodyHitSound : MonoBehaviour
{
	// Token: 0x060007EA RID: 2026 RVA: 0x00038D64 File Offset: 0x00036F64
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

	// Token: 0x060007EB RID: 2027 RVA: 0x00038DC1 File Offset: 0x00036FC1
	private void OnTriggerStay(Collider other)
	{
		this.colliding = true;
	}

	// Token: 0x060007EC RID: 2028 RVA: 0x00038DCA File Offset: 0x00036FCA
	private void OnTriggerExit(Collider other)
	{
		this.colliding = false;
	}

	// Token: 0x060007ED RID: 2029 RVA: 0x00038DD3 File Offset: 0x00036FD3
	private void Update()
	{
		if (this.onCollision != this.colliding)
		{
			this.PlaySound();
			this.onCollision = this.colliding;
		}
	}

	// Token: 0x060007EE RID: 2030 RVA: 0x00038DF5 File Offset: 0x00036FF5
	public void PlaySound()
	{
		if (this.colliding)
		{
			this.soundManager.PlayBodyHitSound();
			if (this.networkSoundManager != null)
			{
				this.networkSoundManager.PlayBodyHitSound();
			}
		}
	}

	// Token: 0x04000DA5 RID: 3493
	private GameObject soundGameObject;

	// Token: 0x04000DA6 RID: 3494
	private SoundManager soundManager;

	// Token: 0x04000DA7 RID: 3495
	public bool colliding;

	// Token: 0x04000DA8 RID: 3496
	private bool onCollision;

	// Token: 0x04000DA9 RID: 3497
	private GameObject networkParent;

	// Token: 0x04000DAA RID: 3498
	private NetworkSoundManager networkSoundManager;
}
