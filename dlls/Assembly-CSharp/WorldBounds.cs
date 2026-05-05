using System;
using UnityEngine;

// Token: 0x020001E6 RID: 486
public class WorldBounds : MonoBehaviour
{
	// Token: 0x06000798 RID: 1944 RVA: 0x000020BE File Offset: 0x000002BE
	public void Start()
	{
	}

	// Token: 0x06000799 RID: 1945 RVA: 0x00037F44 File Offset: 0x00036144
	public void OnFootOutOfBounds()
	{
		if (this.references.teleportPlayer.references.loadscreenParent.childCount == 0)
		{
			this.references.vibration.Vibrate(0.5f, 1f);
			this.references.teleportPlayer.TeleportToSpawnpoint();
		}
	}

	// Token: 0x04000D49 RID: 3401
	[HideInInspector]
	public WorldBoundsReferences references;
}
