using System;
using TMPro;
using UnityEngine;

// Token: 0x020001E9 RID: 489
public class PoleLogic : MonoBehaviour
{
	// Token: 0x0600079F RID: 1951 RVA: 0x00037FC0 File Offset: 0x000361C0
	private void Start()
	{
		this.player = GameObject.Find("Player");
		this.followPlayerCam.cameraTarget = GameObject.Find("CameraTarget_Parent");
		this.playerRB = this.player.GetComponent<Rigidbody>();
		this.pos = new Vector3(this.poleRing.position.x, this.poleRing.position.y, this.poleRing.position.z);
	}

	// Token: 0x060007A0 RID: 1952 RVA: 0x00038040 File Offset: 0x00036240
	private void LateUpdate()
	{
		this.poleRing.position = Vector3.Lerp(this.poleRing.position, this.pos, this.dampen * Time.deltaTime);
		this.distance = Vector3.Distance(this.player.transform.position, this.poleRing.position);
		if (this.distance < 20f)
		{
			this.MegaAir = true;
			if (this.poleRing.position.y < this.player.transform.position.y && this.player.transform.position.y > 9f)
			{
				this.updatePoleRing();
				return;
			}
		}
		else
		{
			this.MegaAir = false;
		}
	}

	// Token: 0x060007A1 RID: 1953 RVA: 0x00038108 File Offset: 0x00036308
	public void updatePoleRing()
	{
		this.pos = new Vector3(this.poleRing.position.x, this.player.transform.position.y, this.poleRing.position.z);
		this.height = this.poleRing.position.y - 9f;
		this.text.text = this.height.ToString("F2") + "m";
	}

	// Token: 0x060007A2 RID: 1954 RVA: 0x00038196 File Offset: 0x00036396
	public void takeShot()
	{
		Debug.Log("Shot Snapped");
	}

	// Token: 0x04000D4D RID: 3405
	public FollowPlayerCam followPlayerCam;

	// Token: 0x04000D4E RID: 3406
	private GameObject player;

	// Token: 0x04000D4F RID: 3407
	public Transform poleRing;

	// Token: 0x04000D50 RID: 3408
	public bool MegaAir;

	// Token: 0x04000D51 RID: 3409
	public float distance;

	// Token: 0x04000D52 RID: 3410
	public float height;

	// Token: 0x04000D53 RID: 3411
	public TMP_Text text;

	// Token: 0x04000D54 RID: 3412
	private Rigidbody playerRB;

	// Token: 0x04000D55 RID: 3413
	public bool allowedToShoot;

	// Token: 0x04000D56 RID: 3414
	public float tempHeight;

	// Token: 0x04000D57 RID: 3415
	private Vector3 pos;

	// Token: 0x04000D58 RID: 3416
	public float dampen;
}
