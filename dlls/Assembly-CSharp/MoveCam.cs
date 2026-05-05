using System;
using Cinemachine;
using UnityEngine;

// Token: 0x02000048 RID: 72
public class MoveCam : MonoBehaviour
{
	// Token: 0x06000105 RID: 261 RVA: 0x000090F7 File Offset: 0x000072F7
	private void Start()
	{
		this.targetHeight = this.cinemachineFreeLook.m_Orbits[1].m_Height;
	}

	// Token: 0x06000106 RID: 262 RVA: 0x00009115 File Offset: 0x00007315
	private void Update()
	{
		this.ChangeCameraSettings();
	}

	// Token: 0x06000107 RID: 263 RVA: 0x00009120 File Offset: 0x00007320
	public void ChangeCameraSettings()
	{
		if ((!this.scooterController.isGrounded || this.grindSystem.isGrinding) && this.characterStates.currentState == CharacterState.Idle)
		{
			this.targetHeight = this.inAirHeight;
		}
		else
		{
			this.targetHeight = this.groundedHeight;
		}
		float height = Mathf.Lerp(this.cinemachineFreeLook.m_Orbits[1].m_Height, this.targetHeight, this.smoothSpeed * Time.deltaTime);
		this.cinemachineFreeLook.m_Orbits[1].m_Height = height;
	}

	// Token: 0x06000108 RID: 264 RVA: 0x000091B3 File Offset: 0x000073B3
	public void ResetCamera()
	{
		this.targetHeight = this.groundedHeight;
		this.cinemachineFreeLook.m_Orbits[1].m_Height = this.groundedHeight;
	}

	// Token: 0x04000136 RID: 310
	public ScooterController scooterController;

	// Token: 0x04000137 RID: 311
	public CinemachineFreeLook cinemachineFreeLook;

	// Token: 0x04000138 RID: 312
	public GrindSystem grindSystem;

	// Token: 0x04000139 RID: 313
	public CharacterStates characterStates;

	// Token: 0x0400013A RID: 314
	public float groundedHeight = 0.3f;

	// Token: 0x0400013B RID: 315
	public float inAirHeight = 1.5f;

	// Token: 0x0400013C RID: 316
	public float smoothSpeed = 5f;

	// Token: 0x0400013D RID: 317
	private float targetHeight;
}
