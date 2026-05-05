using System;
using Cinemachine;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class DynamicCinemachineDoF : MonoBehaviour
{
	// Token: 0x06000016 RID: 22 RVA: 0x000023A2 File Offset: 0x000005A2
	private void Start()
	{
		if (this.player != null)
		{
			this.originalPlayerLocalPosition = this.player.localPosition;
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000023C4 File Offset: 0x000005C4
	private void Update()
	{
		if (this.freeLookCamera == null || this.player == null)
		{
			return;
		}
		float fieldOfView = this.FocalLengthToFOV(this.focalLength, 36f);
		float b = Mathf.Max(Vector3.Distance(this.freeLookCamera.transform.position, this.player.position) + this.focalDistanceOffset, 0.1f);
		LensSettings lens = this.freeLookCamera.m_Lens;
		lens.FieldOfView = fieldOfView;
		lens.FocusDistance = Mathf.Lerp(lens.FocusDistance, b, Time.deltaTime * 5f);
		lens.Aperture = Mathf.Lerp(lens.Aperture, this.GetAmplifiedAperture(this.focalLength, this.dofAmplification), Time.deltaTime * 3f);
		this.freeLookCamera.m_Lens = lens;
		this.freeLookCamera.m_Orbits[1].m_Radius = this.middleRigRadius;
		Vector3 b2 = this.originalPlayerLocalPosition;
		b2.y += this.cameraOffset;
		this.player.localPosition = Vector3.Lerp(this.player.localPosition, b2, Time.deltaTime * 3f);
	}

	// Token: 0x06000018 RID: 24 RVA: 0x000024FA File Offset: 0x000006FA
	private float FocalLengthToFOV(float focalLength, float sensorWidth)
	{
		return 2f * Mathf.Atan(sensorWidth / (2f * focalLength)) * 57.29578f;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002516 File Offset: 0x00000716
	private float GetAmplifiedAperture(float focalLength, float amplification)
	{
		return Mathf.Clamp(Mathf.Clamp(16f - focalLength / 20f, 2f, 16f) / amplification, 0.5f, 16f);
	}

	// Token: 0x0400001A RID: 26
	public CinemachineFreeLook freeLookCamera;

	// Token: 0x0400001B RID: 27
	public Transform player;

	// Token: 0x0400001C RID: 28
	[Range(10f, 200f)]
	public float focalLength = 50f;

	// Token: 0x0400001D RID: 29
	[Range(1f, 10f)]
	public float middleRigRadius = 3f;

	// Token: 0x0400001E RID: 30
	[Range(1f, 5f)]
	public float dofAmplification = 1f;

	// Token: 0x0400001F RID: 31
	[Range(-0.5f, 0.5f)]
	public float cameraOffset;

	// Token: 0x04000020 RID: 32
	[Range(-5f, 5f)]
	public float focalDistanceOffset;

	// Token: 0x04000021 RID: 33
	private const float sensorSize = 36f;

	// Token: 0x04000022 RID: 34
	private Vector3 originalPlayerLocalPosition;
}
