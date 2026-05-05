using System;
using Rewired;
using UnityEngine;

// Token: 0x020001EA RID: 490
public class TempVidScript : MonoBehaviour
{
	// Token: 0x060007A4 RID: 1956 RVA: 0x000381A2 File Offset: 0x000363A2
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x000381BA File Offset: 0x000363BA
	private void Update()
	{
		if (this.player.GetButtonDown("Triangle"))
		{
			this.switchCam = !this.switchCam;
			this.SwitchCam();
		}
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x000381E4 File Offset: 0x000363E4
	public void SwitchCam()
	{
		if (this.switchCam)
		{
			this.thisCam.SetActive(true);
			this.mainCam.SetActive(false);
		}
		if (!this.switchCam)
		{
			this.thisCam.SetActive(false);
			this.mainCam.SetActive(true);
		}
	}

	// Token: 0x04000D59 RID: 3417
	public GameObject thisCam;

	// Token: 0x04000D5A RID: 3418
	public GameObject mainCam;

	// Token: 0x04000D5B RID: 3419
	private int playerId;

	// Token: 0x04000D5C RID: 3420
	private Player player;

	// Token: 0x04000D5D RID: 3421
	private bool switchCam;
}
