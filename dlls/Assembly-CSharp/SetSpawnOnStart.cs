using System;
using UnityEngine;

// Token: 0x020001C2 RID: 450
public class SetSpawnOnStart : MonoBehaviour
{
	// Token: 0x06000702 RID: 1794 RVA: 0x000020BE File Offset: 0x000002BE
	private void Start()
	{
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x00034150 File Offset: 0x00032350
	private void Update()
	{
		if (!this.SpawnSet && this.groundTrigger != this.ScooterController.isGrounded)
		{
			this.SetSpawnMarkerToGround();
			this.groundTrigger = this.ScooterController.isGrounded;
		}
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x00034184 File Offset: 0x00032384
	public void SetSpawnMarkerToGround()
	{
		this.TeleportPlayer.SetMarker();
		this.SpawnSet = true;
	}

	// Token: 0x04000C64 RID: 3172
	public bool SpawnSet;

	// Token: 0x04000C65 RID: 3173
	private bool groundTrigger;

	// Token: 0x04000C66 RID: 3174
	public TeleportPlayer TeleportPlayer;

	// Token: 0x04000C67 RID: 3175
	public ScooterController ScooterController;
}
