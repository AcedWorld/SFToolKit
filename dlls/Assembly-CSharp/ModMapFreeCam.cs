using System;
using Invector.vCharacterController;
using Rewired;
using UnityEngine;

// Token: 0x02000209 RID: 521
public class ModMapFreeCam : MonoBehaviour
{
	// Token: 0x06000830 RID: 2096 RVA: 0x0003AA7E File Offset: 0x00038C7E
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x0003AA98 File Offset: 0x00038C98
	private void Update()
	{
		if (!this.menuLogic.pauseMenu && this.modMapLoaded)
		{
			if (this.player.GetButtonDown("Circle") && this.characterStates.currentState == CharacterState.Walking)
			{
				this.ToggleDrone();
			}
			if (this.player.GetButtonDown("Triangle") && this.inUse)
			{
				this.RemoveDrone();
			}
			if (this.inUse && this.player.GetButtonDown("D-PadUp"))
			{
				this.spawnPoint.transform.position = this.droneInfo.hit.point;
				Quaternion rhs = new Quaternion(0f, this.droneBase.transform.rotation.y, 0f, this.droneBase.transform.rotation.w);
				Quaternion rotation = Quaternion.FromToRotation(Vector3.up, this.droneInfo.hit.normal) * rhs;
				this.spawnPoint.transform.rotation = rotation;
			}
			if (this.inUse && this.player.GetButtonDown("D-PadDown"))
			{
				this.RemoveDrone();
				this.teleportPlayer.TeleportToSpawnpoint();
			}
		}
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x0003ABDE File Offset: 0x00038DDE
	public void ToggleDrone()
	{
		if (this.spawnedDrone == null)
		{
			this.SpawnDrone();
			return;
		}
		this.RemoveDrone();
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x0003ABFC File Offset: 0x00038DFC
	public void SpawnDrone()
	{
		if (this.simpleReplay != null)
		{
			this.simpleReplay.state = SimpleReplay.ReplayState.Stopped;
		}
		this.teleportPlayer.CreateLoadScreen();
		Object.Instantiate<GameObject>(this.DronePrefab, this.droneSpawn.position, this.droneSpawn.rotation);
		this.vThirdPersonController.enabled = false;
		this.vThirdPersonInput.enabled = false;
		this.CharacterAnimator.Rebind();
		this.inUse = true;
		this.onFootSpawnPoint.Usable = false;
		this.spawnedDrone = GameObject.Find("DroneParent(Clone)");
		this.spawnedDroneController = GameObject.Find("DroneController");
		this.droneBase = GameObject.Find("DroneBase");
		this.droneInfo = this.spawnedDroneController.GetComponent<DroneInfo>();
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x0003ACC8 File Offset: 0x00038EC8
	public void RemoveDrone()
	{
		if (this.simpleReplay != null)
		{
			this.simpleReplay.state = SimpleReplay.ReplayState.Recording;
		}
		this.teleportPlayer.CreateLoadScreen();
		this.vThirdPersonController.enabled = true;
		this.vThirdPersonInput.enabled = true;
		this.inUse = false;
		this.onFootSpawnPoint.Usable = true;
		Object.Destroy(this.spawnedDrone);
		this.spawnedDrone = null;
		this.spawnedDroneController = null;
		this.droneBase = null;
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x0003AD45 File Offset: 0x00038F45
	public void AllowDrone()
	{
		this.modMapLoaded = true;
	}

	// Token: 0x04000E60 RID: 3680
	public bool modMapLoaded;

	// Token: 0x04000E61 RID: 3681
	private int playerId;

	// Token: 0x04000E62 RID: 3682
	private Player player;

	// Token: 0x04000E63 RID: 3683
	public GameObject DronePrefab;

	// Token: 0x04000E64 RID: 3684
	public Transform droneSpawn;

	// Token: 0x04000E65 RID: 3685
	public vThirdPersonController vThirdPersonController;

	// Token: 0x04000E66 RID: 3686
	public vThirdPersonInput vThirdPersonInput;

	// Token: 0x04000E67 RID: 3687
	public onFootSpawnPoint onFootSpawnPoint;

	// Token: 0x04000E68 RID: 3688
	public Animator CharacterAnimator;

	// Token: 0x04000E69 RID: 3689
	public MenuLogic menuLogic;

	// Token: 0x04000E6A RID: 3690
	public DroneInfo droneInfo;

	// Token: 0x04000E6B RID: 3691
	public Transform spawnPoint;

	// Token: 0x04000E6C RID: 3692
	public GameObject walkingFreeCam;

	// Token: 0x04000E6D RID: 3693
	private bool inUse;

	// Token: 0x04000E6E RID: 3694
	public GameObject spawnedDrone;

	// Token: 0x04000E6F RID: 3695
	public GameObject spawnedDroneController;

	// Token: 0x04000E70 RID: 3696
	public GameObject droneBase;

	// Token: 0x04000E71 RID: 3697
	public TeleportPlayer teleportPlayer;

	// Token: 0x04000E72 RID: 3698
	public CharacterStates characterStates;

	// Token: 0x04000E73 RID: 3699
	public SimpleReplay simpleReplay;
}
