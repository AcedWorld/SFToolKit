using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200015E RID: 350
public class GrindTrigger : MonoBehaviour
{
	// Token: 0x060005A1 RID: 1441 RVA: 0x000284E8 File Offset: 0x000266E8
	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Rail") && !this.grindSystem.isGrinding && !this.grindSystem.applyCoolDown && this.playerRb.velocity.magnitude > 1f)
		{
			if (!this.trajectoryPrediction.IsGroingToGrind)
			{
				List<GameObject> rails = new List<GameObject>
				{
					other.gameObject
				};
				this.trajectoryPrediction.ProcessRail(rails);
				if (!this.trajectoryPrediction.IsParallelToRailSegment())
				{
					this.grindSystem.PopulateGrindPoints(other.transform);
					this.grindSystem.StartGrinding();
					return;
				}
				this.grindSystem.StopGrinding(false, false);
				return;
			}
			else
			{
				this.grindSystem.PopulateGrindPoints(other.transform);
				this.grindSystem.StartGrinding();
			}
		}
	}

	// Token: 0x04000926 RID: 2342
	public GrindSystem grindSystem;

	// Token: 0x04000927 RID: 2343
	public TrajectoryPrediction trajectoryPrediction;

	// Token: 0x04000928 RID: 2344
	public Rigidbody playerRb;

	// Token: 0x04000929 RID: 2345
	public ScooterController scooterController;
}
