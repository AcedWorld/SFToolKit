using System;
using UnityEngine;

// Token: 0x0200015C RID: 348
public class GrindLeniency : MonoBehaviour
{
	// Token: 0x0600058B RID: 1419 RVA: 0x00026620 File Offset: 0x00024820
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Rail") && this.grindSystem.isGrinding)
		{
			this.grindSystem.StopGrinding(false, false);
			this.trajectoryPrediction.predictionDone = false;
			this.trajectoryPrediction.IsGroingToGrind = false;
			this.trajectoryPrediction.smoothAnimAngle = false;
		}
		if (other.CompareTag("Coping") && this.grindSystem.isGrinding)
		{
			this.grindSystem.StopGrinding(false, false);
			this.trajectoryPrediction.predictionDone = false;
			this.trajectoryPrediction.IsGroingToGrind = false;
			this.trajectoryPrediction.smoothAnimAngle = false;
		}
	}

	// Token: 0x040008DE RID: 2270
	public GrindSystem grindSystem;

	// Token: 0x040008DF RID: 2271
	public TrajectoryPrediction trajectoryPrediction;

	// Token: 0x040008E0 RID: 2272
	public Rigidbody Rigidbody;
}
