using System;
using Rewired;
using UnityEngine;

// Token: 0x02000173 RID: 371
public class onFootSpawnPoint : MonoBehaviour
{
	// Token: 0x060005FD RID: 1533 RVA: 0x0002BA4F File Offset: 0x00029C4F
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x0002BA68 File Offset: 0x00029C68
	private void Update()
	{
		if (this.Usable && this.characterStates.currentState == CharacterState.Walking && !this.menuLogic.pauseMenu)
		{
			if (this.player.GetButtonDown("D-PadDown"))
			{
				this.ThumpyLocation.position = this.spawnPoint.position;
				Quaternion quaternion = new Quaternion(0f, this.spawnPoint.rotation.y, 0f, this.spawnPoint.rotation.w);
				Vector3 eulerAngles = quaternion.eulerAngles;
				eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y + 180f, eulerAngles.z);
				this.ThumpyLocation.rotation = Quaternion.Euler(eulerAngles);
			}
			if (this.player.GetButtonDown("D-PadUp") && !this.teleportPlayer.IsTutorial)
			{
				this.spawnPoint.transform.position = this.thumpyGroundInfo.hit.point;
				Quaternion rhs = new Quaternion(0f, this.ThumpySpawnLocation.rotation.y, 0f, this.ThumpySpawnLocation.rotation.w);
				Quaternion rotation = Quaternion.FromToRotation(Vector3.up, this.thumpyGroundInfo.hit.normal) * rhs;
				this.spawnPoint.transform.rotation = rotation;
			}
		}
	}

	// Token: 0x040009E6 RID: 2534
	public Transform ThumpyLocation;

	// Token: 0x040009E7 RID: 2535
	public Transform ThumpySpawnLocation;

	// Token: 0x040009E8 RID: 2536
	public Transform spawnPoint;

	// Token: 0x040009E9 RID: 2537
	public TeleportPlayer teleportPlayer;

	// Token: 0x040009EA RID: 2538
	public ThumpyGroundInfo thumpyGroundInfo;

	// Token: 0x040009EB RID: 2539
	public MenuLogic menuLogic;

	// Token: 0x040009EC RID: 2540
	public CharacterStates characterStates;

	// Token: 0x040009ED RID: 2541
	public bool Usable;

	// Token: 0x040009EE RID: 2542
	private int playerId;

	// Token: 0x040009EF RID: 2543
	private Player player;
}
