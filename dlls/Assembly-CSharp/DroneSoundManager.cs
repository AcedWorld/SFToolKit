using System;
using Rewired;
using UnityEngine;

// Token: 0x020000A6 RID: 166
public class DroneSoundManager : MonoBehaviour
{
	// Token: 0x060002BD RID: 701 RVA: 0x00015D55 File Offset: 0x00013F55
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x060002BE RID: 702 RVA: 0x00015D70 File Offset: 0x00013F70
	private void Update()
	{
		float axis = this.player.GetAxis("LeftStickX");
		float axis2 = this.player.GetAxis("LeftStickY");
		float axis3 = this.player.GetAxis("RightStickY");
		float axis4 = this.player.GetAxis("RightStickX");
		if (axis > 0f || axis == 0f)
		{
			this.pitch1 = axis + 1f;
		}
		if (axis < 0f)
		{
			this.pitch1 = -axis + 1f;
		}
		if (axis2 > 0f || axis2 == 0f)
		{
			this.pitch2 = axis2 + 1f;
		}
		if (axis2 < 0f)
		{
			this.pitch2 = -axis2 + 1f;
		}
		if (axis3 > 0f || axis3 == 0f)
		{
			this.pitch3 = axis3 + 1f;
		}
		if (axis3 < 0f)
		{
			this.pitch3 = -axis3 + 1f;
		}
		if (axis4 > 0f || axis4 == 0f)
		{
			this.pitch4 = axis4 + 1f;
		}
		if (axis4 < 0f)
		{
			this.pitch4 = -axis4 + 1f;
		}
		this.pitch = (this.pitch1 + this.pitch2 + this.pitch3 + this.pitch4) / 4f;
		this.droneSound.pitch = this.pitch;
	}

	// Token: 0x0400035B RID: 859
	private int playerId;

	// Token: 0x0400035C RID: 860
	private Player player;

	// Token: 0x0400035D RID: 861
	public float SoundDampen;

	// Token: 0x0400035E RID: 862
	public AudioSource droneSound;

	// Token: 0x0400035F RID: 863
	public float pitch;

	// Token: 0x04000360 RID: 864
	private float pitch1;

	// Token: 0x04000361 RID: 865
	private float pitch2;

	// Token: 0x04000362 RID: 866
	private float pitch3;

	// Token: 0x04000363 RID: 867
	private float pitch4;
}
