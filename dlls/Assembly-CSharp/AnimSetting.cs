using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200011A RID: 282
public class AnimSetting : MonoBehaviour
{
	// Token: 0x06000494 RID: 1172 RVA: 0x0001FDFF File Offset: 0x0001DFFF
	private void Start()
	{
		this.player = GameObject.Find("Player");
		this.playerRB = this.player.GetComponent<Rigidbody>();
		base.StartCoroutine(this.delay());
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x0001FE30 File Offset: 0x0001E030
	private void startAnim()
	{
		if (this.isAnimating)
		{
			this.playerRB.constraints = RigidbodyConstraints.FreezeAll;
			this.player.transform.position = this.player.transform.position + new Vector3(0f, 4f, 0f);
		}
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x0001FE8B File Offset: 0x0001E08B
	private IEnumerator delay()
	{
		yield return new WaitForSecondsRealtime(2f);
		this.startAnim();
		yield break;
	}

	// Token: 0x040006EF RID: 1775
	public bool isAnimating;

	// Token: 0x040006F0 RID: 1776
	private GameObject player;

	// Token: 0x040006F1 RID: 1777
	private Rigidbody playerRB;
}
