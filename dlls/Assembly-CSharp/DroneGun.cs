using System;
using Rewired;
using UnityEngine;

// Token: 0x020000A3 RID: 163
public class DroneGun : MonoBehaviour
{
	// Token: 0x060002B5 RID: 693 RVA: 0x00015BC5 File Offset: 0x00013DC5
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x00015BE0 File Offset: 0x00013DE0
	private void Update()
	{
		if (this.player.GetButtonDown("R2"))
		{
			Object.Instantiate<GameObject>(this.projectile, base.transform.position, Quaternion.identity).GetComponent<Rigidbody>().AddForce(base.transform.forward * this.force);
		}
	}

	// Token: 0x0400034F RID: 847
	public GameObject projectile;

	// Token: 0x04000350 RID: 848
	private int playerId;

	// Token: 0x04000351 RID: 849
	private Player player;

	// Token: 0x04000352 RID: 850
	public float force;
}
