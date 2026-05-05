using System;
using UnityEngine;

// Token: 0x02000207 RID: 519
public class GrindManager : MonoBehaviour
{
	// Token: 0x06000824 RID: 2084 RVA: 0x0003A833 File Offset: 0x00038A33
	private void Start()
	{
		this.CacheCurrentWheelFriction();
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x0003A83C File Offset: 0x00038A3C
	private void FixedUpdate()
	{
		if (this.references.grindCollision.grinding)
		{
			this.RotateWhileGrinding();
		}
		if (this.grinding != this.references.grindCollision.grinding)
		{
			this.ApplyWheelCurve();
			this.grinding = this.references.grindCollision.grinding;
		}
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x0003A895 File Offset: 0x00038A95
	private void ApplyWheelCurve()
	{
		if (this.references.grindCollision.grinding)
		{
			this.GrindWheelSettings();
			return;
		}
		this.NormalWheelSettings();
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x000020BE File Offset: 0x000002BE
	private void GrindWheelSettings()
	{
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x000020BE File Offset: 0x000002BE
	private void NormalWheelSettings()
	{
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x0003A8B8 File Offset: 0x00038AB8
	private void CacheCurrentWheelFriction()
	{
		this.frontWheelForwardFriction = this.references.frontWheel.forwardFriction;
		this.frontWheelSidewaysFriction = this.references.frontWheel.sidewaysFriction;
		this.rearWheelForwardFriction = this.references.frontWheel.forwardFriction;
		this.rearWheelSidewaysFriction = this.references.frontWheel.sidewaysFriction;
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x0003A91D File Offset: 0x00038B1D
	private void RotateWhileGrinding()
	{
		this.references.playerRigidbody.AddRelativeTorque(0f, this.references.ScooterflowInputSystem.LeftStickX, 0f * Time.deltaTime);
	}

	// Token: 0x04000E53 RID: 3667
	public GrindReferences references;

	// Token: 0x04000E54 RID: 3668
	public GrindSettings settings;

	// Token: 0x04000E55 RID: 3669
	public bool grinding;

	// Token: 0x04000E56 RID: 3670
	private WheelFrictionCurve frontWheelForwardFriction;

	// Token: 0x04000E57 RID: 3671
	private WheelFrictionCurve frontWheelSidewaysFriction;

	// Token: 0x04000E58 RID: 3672
	private WheelFrictionCurve rearWheelForwardFriction;

	// Token: 0x04000E59 RID: 3673
	private WheelFrictionCurve rearWheelSidewaysFriction;

	// Token: 0x04000E5A RID: 3674
	private WheelFrictionCurve wheelGrindingFriction;
}
