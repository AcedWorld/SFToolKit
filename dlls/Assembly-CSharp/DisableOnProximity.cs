using System;
using UnityEngine;

// Token: 0x020000AF RID: 175
public class DisableOnProximity : MonoBehaviour
{
	// Token: 0x060002E7 RID: 743 RVA: 0x00016E3C File Offset: 0x0001503C
	private void Start()
	{
		this.tutorialManager = Object.FindObjectOfType<TutorialManager>();
		if (this.tutorialManager == null)
		{
			Debug.LogError("TutorialManager not found in the scene!");
		}
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x00016E64 File Offset: 0x00015064
	private void Update()
	{
		if (this.player != null && Vector3.Distance(base.transform.position, this.player.position) <= this.proximityDistance && this.tutorialManager != null)
		{
			this.TriggerExplosion();
		}
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x00016EB8 File Offset: 0x000150B8
	private void TriggerExplosion()
	{
		this.tutorialManager.PlaySound(this.tutorialManager.smallSuccessSound);
		if (this.explosionEffectPrefab != null)
		{
			Object.Destroy(Object.Instantiate<GameObject>(this.explosionEffectPrefab, base.transform.position, Quaternion.identity), this.explosionDuration);
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x040003B2 RID: 946
	public Transform player;

	// Token: 0x040003B3 RID: 947
	public float proximityDistance = 0.5f;

	// Token: 0x040003B4 RID: 948
	public TutorialManager tutorialManager;

	// Token: 0x040003B5 RID: 949
	public GameObject explosionEffectPrefab;

	// Token: 0x040003B6 RID: 950
	public float explosionDuration = 3f;

	// Token: 0x040003B7 RID: 951
	public float disableDelay = 0.1f;
}
