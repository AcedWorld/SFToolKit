using System;
using UnityEngine;

// Token: 0x020000B7 RID: 183
public class TricksOverBankTutorial : MonoBehaviour
{
	// Token: 0x06000316 RID: 790 RVA: 0x000180CB File Offset: 0x000162CB
	private void Update()
	{
		this.CheckTriggers();
	}

	// Token: 0x06000317 RID: 791 RVA: 0x000180D3 File Offset: 0x000162D3
	private void OnEnable()
	{
		this.ResetChallenge();
	}

	// Token: 0x06000318 RID: 792 RVA: 0x000180DC File Offset: 0x000162DC
	private void CheckTriggers()
	{
		if (this.IsWithinBounds(this.tutorialChecker, this.triggerA))
		{
			if (!this.hasTouchedA)
			{
				this.hasTouchedA = true;
			}
		}
		else if (this.hasTouchedA)
		{
			this.hasTouchedA = false;
		}
		if (this.IsBoundaryTriggered(this.resetBoundaryTriggers))
		{
			Debug.Log("Reset Boundary Triggered! Resetting Challenge...");
			this.ResetChallenge();
		}
	}

	// Token: 0x06000319 RID: 793 RVA: 0x0001813C File Offset: 0x0001633C
	private bool IsWithinBounds(Transform target, Collider collider)
	{
		return collider.bounds.Contains(target.position);
	}

	// Token: 0x0600031A RID: 794 RVA: 0x00018160 File Offset: 0x00016360
	private bool IsBoundaryTriggered(Collider[] boundaries)
	{
		foreach (Collider collider in boundaries)
		{
			if (this.IsWithinBounds(this.tutorialChecker, collider))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600031B RID: 795 RVA: 0x00018194 File Offset: 0x00016394
	private void ResetChallenge()
	{
		this.teleportPlayer.references.spawnpointTransform.position = this.dummySpawnPoint.position;
		this.teleportPlayer.references.spawnpointTransform.rotation = this.dummySpawnPoint.rotation;
		this.teleportPlayer.TeleportToSpawnpoint();
	}

	// Token: 0x04000424 RID: 1060
	public Transform tutorialChecker;

	// Token: 0x04000425 RID: 1061
	public Collider triggerA;

	// Token: 0x04000426 RID: 1062
	public Collider[] resetBoundaryTriggers;

	// Token: 0x04000427 RID: 1063
	public Transform dummySpawnPoint;

	// Token: 0x04000428 RID: 1064
	public bool hasTouchedA;

	// Token: 0x04000429 RID: 1065
	public TeleportPlayer teleportPlayer;

	// Token: 0x0400042A RID: 1066
	public TutorialManager tutorialManager;
}
