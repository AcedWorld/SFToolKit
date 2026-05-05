using System;
using UnityEngine;

// Token: 0x0200014D RID: 333
public class DynamicPelvisMovement : MonoBehaviour
{
	// Token: 0x06000550 RID: 1360 RVA: 0x00024400 File Offset: 0x00022600
	private void LateUpdate()
	{
		if (!this.pelvisTarget)
		{
			return;
		}
		float num = Mathf.Clamp(this.playerRigidbody.velocity.y / this.maxFallMagnitude, -1f, 1f) * this.maxAdjustment;
		Mathf.Clamp(base.transform.InverseTransformDirection(this.playerRigidbody.velocity).z / this.maxPelvisSpeedRange, -1f, 1f);
		float num2 = this.maxAdjustment;
		if (!this.grindSystem.isGrinding && this.scooterController.isGrounded)
		{
			float b = (this.playerRigidbody.velocity.y < 0f) ? (-num) : num;
			this.currentFallAdjustment = Mathf.Lerp(this.currentFallAdjustment, b, this.lerpSpeed * Time.deltaTime);
			this.PelvisFallAdjust = Mathf.Lerp(this.PelvisFallAdjust, 0f, this.lerpSpeed * Time.deltaTime);
		}
		else
		{
			float a = -10f;
			float b2 = 10f;
			float num3 = Mathf.InverseLerp(a, b2, this.playerRigidbody.velocity.y);
			float b3 = (1f - num3) * this.pelvisMaxAdjust;
			this.PelvisFallAdjust = Mathf.Lerp(this.PelvisFallAdjust, b3, this.lerpSpeed * Time.deltaTime);
			this.currentFallAdjustment = Mathf.Lerp(this.currentFallAdjustment, 0f, this.lerpSpeed * Time.deltaTime);
		}
		if (this.pumpMechanic.pumpTimer > 0.1f && !this.pumpMechanic.upPumpStart)
		{
			this.spineYOffset = Mathf.Lerp(this.spineYOffset, -0.25f, 2.5f * Time.deltaTime);
		}
		else if (this.pumpMechanic.pumpTimer > 0.1f && this.pumpMechanic.upPumpStart)
		{
			this.spineYOffset = Mathf.Lerp(this.spineYOffset, -0.25f, 2.5f * Time.deltaTime);
		}
		else
		{
			this.spineYOffset = Mathf.Lerp(this.spineYOffset, 0f, 5f * Time.deltaTime);
		}
		this.spineYOffset = Mathf.Clamp(this.spineYOffset, -0.1f, 0f);
		Vector3 vector = this.pelvisTarget.TransformDirection(new Vector3(0f, 0f, -this.PelvisFallAdjust / 20f)) - Vector3.up * (this.PelvisFallAdjust / 10f);
		if (!float.IsNaN(vector.x) && !float.IsNaN(vector.y) && !float.IsNaN(vector.z))
		{
			Vector3 direction = this.pelvisTarget.InverseTransformDirection(vector);
			float b4 = this.scooterController.isGrounded ? 1.5f : 1f;
			this.zLerpMultiplier = Mathf.Lerp(this.zLerpMultiplier, b4, 6f * Time.deltaTime);
			direction.z *= this.zLerpMultiplier;
			float b5 = this.scooterController.isGrounded ? -2f : 1.25f;
			this.xLerpMultiplier = Mathf.Lerp(this.xLerpMultiplier, b5, 6f * Time.deltaTime);
			direction.x *= this.xLerpMultiplier;
			float b6 = this.scooterController.isGrounded ? 1f : 0.25f;
			this.yLerpMultiplier = Mathf.Lerp(this.yLerpMultiplier, b6, 6f * Time.deltaTime);
			direction.y *= this.yLerpMultiplier;
			Vector3 b7 = this.pelvisTarget.TransformDirection(direction);
			this.pelvisTarget.position += b7;
			this.SpineTarget.localPosition += new Vector3(0f, this.spineYOffset, 0f);
		}
		this.AdjustLimbPosition(this.leftFootTarget, this.currentFallAdjustment / 30f, this.currentFallAdjustment / 50f, this.leftFootOffset);
		this.AdjustLimbPosition(this.rightFootTarget, -this.currentFallAdjustment / 30f, this.currentFallAdjustment / 50f, this.rightFootOffset);
		this.AdjustLimbPosition(this.leftHandTarget, 0f, -this.currentFallAdjustment / 30f, this.leftHandOffset);
		this.AdjustLimbPosition(this.rightHandTarget, 0f, this.currentFallAdjustment / 30f, this.rightHandOffset);
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x0002487D File Offset: 0x00022A7D
	private void AdjustLimbPosition(Transform limb, float zAdjustment, float xAdjustment, Vector3 limbOffset)
	{
		limb.localPosition += new Vector3(xAdjustment, 0f, -zAdjustment) + limbOffset;
	}

	// Token: 0x0400084D RID: 2125
	[Header("Transforms")]
	public Transform pelvisTarget;

	// Token: 0x0400084E RID: 2126
	public Transform leftFootTarget;

	// Token: 0x0400084F RID: 2127
	public Transform rightFootTarget;

	// Token: 0x04000850 RID: 2128
	public Transform leftHandTarget;

	// Token: 0x04000851 RID: 2129
	public Transform rightHandTarget;

	// Token: 0x04000852 RID: 2130
	public Transform SpineTarget;

	// Token: 0x04000853 RID: 2131
	[Header("Rigidbody")]
	public Rigidbody playerRigidbody;

	// Token: 0x04000854 RID: 2132
	[Header("Scripts")]
	public ScooterController scooterController;

	// Token: 0x04000855 RID: 2133
	public GrindSystem grindSystem;

	// Token: 0x04000856 RID: 2134
	public TrajectoryPrediction trajectoryPrediction;

	// Token: 0x04000857 RID: 2135
	public PumpMechanic pumpMechanic;

	// Token: 0x04000858 RID: 2136
	[Header("Floats")]
	public float maxAdjustment = 1.25f;

	// Token: 0x04000859 RID: 2137
	public float maxFallMagnitude = 3f;

	// Token: 0x0400085A RID: 2138
	public float maxPelvisSpeedRange = 6f;

	// Token: 0x0400085B RID: 2139
	public float lerpSpeed = 1.5f;

	// Token: 0x0400085C RID: 2140
	public float pelvisMaxAdjust = 2f;

	// Token: 0x0400085D RID: 2141
	private float PelvisFallAdjust;

	// Token: 0x0400085E RID: 2142
	private float currentFallAdjustment;

	// Token: 0x0400085F RID: 2143
	private float spineYOffset;

	// Token: 0x04000860 RID: 2144
	[Header("Offsets to allow for different sized characters")]
	public Vector3 leftFootOffset = Vector3.zero;

	// Token: 0x04000861 RID: 2145
	public Vector3 rightFootOffset = Vector3.zero;

	// Token: 0x04000862 RID: 2146
	public Vector3 leftHandOffset = Vector3.zero;

	// Token: 0x04000863 RID: 2147
	public Vector3 rightHandOffset = Vector3.zero;

	// Token: 0x04000864 RID: 2148
	private Quaternion lastRotation;

	// Token: 0x04000865 RID: 2149
	private float yLerpMultiplier = 0.25f;

	// Token: 0x04000866 RID: 2150
	private float zLerpMultiplier = 1f;

	// Token: 0x04000867 RID: 2151
	private float xLerpMultiplier = 1f;
}
