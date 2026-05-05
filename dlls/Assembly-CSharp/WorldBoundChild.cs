using System;
using UnityEngine;

// Token: 0x020001E4 RID: 484
public class WorldBoundChild : MonoBehaviour
{
	// Token: 0x06000793 RID: 1939 RVA: 0x00037EE7 File Offset: 0x000360E7
	private void Start()
	{
		this.worldBounds_ = GameObject.Find("Bounderies_");
		this.worldBounds = this.worldBounds_.GetComponent<WorldBounds>();
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x00037F0A File Offset: 0x0003610A
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "DroneBody")
		{
			return;
		}
		base.Invoke("DelayedTeleport", 0.1f);
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x00037F34 File Offset: 0x00036134
	private void DelayedTeleport()
	{
		this.worldBounds.OnFootOutOfBounds();
	}

	// Token: 0x04000D45 RID: 3397
	private GameObject worldBounds_;

	// Token: 0x04000D46 RID: 3398
	private WorldBounds worldBounds;
}
