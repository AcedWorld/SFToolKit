using System;
using UnityEngine;

// Token: 0x020001E3 RID: 483
public class AssignWorldBounds : MonoBehaviour
{
	// Token: 0x06000791 RID: 1937 RVA: 0x00037DF4 File Offset: 0x00035FF4
	private void Start()
	{
		if (this.worldBounds == null)
		{
			this.worldBounds = Object.FindObjectOfType<WorldBounds>();
			if (this.worldBounds == null)
			{
				return;
			}
			Debug.Log("[AssignWorldBounds] Found WorldBounds: " + this.worldBounds.name);
		}
		if (this.worldBounds != null)
		{
			if (this.teleportPlayer != null)
			{
				this.worldBounds.references.teleportPlayer = this.teleportPlayer;
				Debug.Log("[AssignWorldBounds] Assigned TeleportPlayer to " + this.worldBounds.name);
			}
			else
			{
				Debug.LogWarning("[AssignWorldBounds] No TeleportPlayer set in this script.");
			}
			if (this.vibration != null)
			{
				this.worldBounds.references.vibration = this.vibration;
				Debug.Log("[AssignWorldBounds] Assigned Vibration to " + this.worldBounds.name);
				return;
			}
			Debug.LogWarning("[AssignWorldBounds] No Vibration set in this script.");
		}
	}

	// Token: 0x04000D42 RID: 3394
	[HideInInspector]
	public WorldBounds worldBounds;

	// Token: 0x04000D43 RID: 3395
	public TeleportPlayer teleportPlayer;

	// Token: 0x04000D44 RID: 3396
	public Vibration vibration;
}
