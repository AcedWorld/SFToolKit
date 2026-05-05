using System;
using UnityEngine;

// Token: 0x02000176 RID: 374
public class FixedTimeStep : MonoBehaviour
{
	// Token: 0x06000606 RID: 1542 RVA: 0x0002BC57 File Offset: 0x00029E57
	private void Awake()
	{
		this.SetCustomFixedTimeStep();
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x0002BC60 File Offset: 0x00029E60
	public virtual void SetCustomFixedTimeStep()
	{
		switch (this.customFixedTimeStep)
		{
		case FixedTimeStep.ScooterFlowFixedTimeStep.Default:
			break;
		case FixedTimeStep.ScooterFlowFixedTimeStep.FPS30:
			Time.fixedDeltaTime = 0.03333334f;
			return;
		case FixedTimeStep.ScooterFlowFixedTimeStep.FPS60:
			Time.fixedDeltaTime = 0.01666667f;
			return;
		case FixedTimeStep.ScooterFlowFixedTimeStep.FPS75:
			Time.fixedDeltaTime = 0.01333333f;
			return;
		case FixedTimeStep.ScooterFlowFixedTimeStep.FPS90:
			Time.fixedDeltaTime = 0.01111111f;
			return;
		case FixedTimeStep.ScooterFlowFixedTimeStep.FPS120:
			Time.fixedDeltaTime = 0.008333334f;
			return;
		case FixedTimeStep.ScooterFlowFixedTimeStep.FPS144:
			Time.fixedDeltaTime = 0.006944444f;
			break;
		default:
			return;
		}
	}

	// Token: 0x040009F3 RID: 2547
	[vHelpBox("Set the FixedTimeStep to match the FPS of your Game, \nEx: If your game aims to run at 30fps, select FPS30 to match the FixedUpdate Physics", vHelpBoxAttribute.MessageType.None)]
	public FixedTimeStep.ScooterFlowFixedTimeStep customFixedTimeStep = FixedTimeStep.ScooterFlowFixedTimeStep.FPS60;

	// Token: 0x02000177 RID: 375
	public enum ScooterFlowFixedTimeStep
	{
		// Token: 0x040009F5 RID: 2549
		Default,
		// Token: 0x040009F6 RID: 2550
		FPS30,
		// Token: 0x040009F7 RID: 2551
		FPS60,
		// Token: 0x040009F8 RID: 2552
		FPS75,
		// Token: 0x040009F9 RID: 2553
		FPS90,
		// Token: 0x040009FA RID: 2554
		FPS120,
		// Token: 0x040009FB RID: 2555
		FPS144
	}
}
