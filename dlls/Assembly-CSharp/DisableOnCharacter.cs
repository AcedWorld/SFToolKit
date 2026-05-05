using System;
using UnityEngine;

// Token: 0x020000AE RID: 174
public class DisableOnCharacter : MonoBehaviour
{
	// Token: 0x060002E3 RID: 739 RVA: 0x00016D34 File Offset: 0x00014F34
	private void Start()
	{
		this.tutorialManager = Object.FindObjectOfType<TutorialManager>();
		if (this.tutorialManager == null)
		{
			Debug.LogError("TutorialManager not found in the scene!");
		}
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x00016D5C File Offset: 0x00014F5C
	private void Update()
	{
		if (this.player != null && Vector3.Distance(base.transform.position, this.player.position) <= this.proximityDistance && this.tutorialManager != null)
		{
			this.TriggerExplosion();
		}
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x00016DB0 File Offset: 0x00014FB0
	private void TriggerExplosion()
	{
		this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
		if (this.explosionEffectPrefab != null)
		{
			Object.Destroy(Object.Instantiate<GameObject>(this.explosionEffectPrefab, base.transform.position, Quaternion.identity), this.explosionDuration);
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x040003AC RID: 940
	public Transform player;

	// Token: 0x040003AD RID: 941
	public float proximityDistance = 0.5f;

	// Token: 0x040003AE RID: 942
	public TutorialManager tutorialManager;

	// Token: 0x040003AF RID: 943
	public GameObject explosionEffectPrefab;

	// Token: 0x040003B0 RID: 944
	public float explosionDuration = 3f;

	// Token: 0x040003B1 RID: 945
	public float disableDelay = 0.1f;
}
