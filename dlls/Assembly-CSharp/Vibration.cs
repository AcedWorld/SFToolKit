using System;
using Rewired;
using UnityEngine;

// Token: 0x020001D4 RID: 468
public class Vibration : MonoBehaviour
{
	// Token: 0x06000751 RID: 1873 RVA: 0x00036B13 File Offset: 0x00034D13
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x06000752 RID: 1874 RVA: 0x00036B2B File Offset: 0x00034D2B
	public void Vibrate(float motorLevel, float duration)
	{
		if (this.allowVibration)
		{
			this.player.SetVibration(0, motorLevel, duration);
			this.player.SetVibration(1, motorLevel, duration);
		}
	}

	// Token: 0x04000CE0 RID: 3296
	private int playerId;

	// Token: 0x04000CE1 RID: 3297
	private Player player;

	// Token: 0x04000CE2 RID: 3298
	public bool allowVibration;
}
