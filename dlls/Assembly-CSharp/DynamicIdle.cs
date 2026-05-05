using System;
using UnityEngine;

// Token: 0x020001FF RID: 511
[DefaultExecutionOrder(1550)]
public class DynamicIdle : MonoBehaviour
{
	// Token: 0x0600080B RID: 2059 RVA: 0x00039BD2 File Offset: 0x00037DD2
	private void Start()
	{
		this.timeOffset = Random.Range(0f, 10f);
		this.smoothedWeightShift = 0f;
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x00039BF4 File Offset: 0x00037DF4
	private void LateUpdate()
	{
		float num = Time.time + this.timeOffset;
		float b = Mathf.Sin(num * this.idleSpeed) * this.idleIntensity;
		this.smoothedWeightShift = Mathf.Lerp(this.smoothedWeightShift, b, this.smoothFactor);
		if (this.spine0 && this.spine1 && this.spine2)
		{
			float num2 = this.smoothedWeightShift;
			this.spine0.localRotation *= Quaternion.Euler(-num2 * 0.2f, 0f, 0f);
			this.spine1.localRotation *= Quaternion.Euler(-num2 * 0.4f, 0f, 0f);
			this.spine2.localRotation *= Quaternion.Euler(-num2 * 0.6f, 0f, 0f);
			if (this.neck)
			{
				this.neck.localRotation *= Quaternion.Euler(-num2 * 0.2f, 0f, 0f);
			}
		}
		if (this.leftUpperArm && this.rightUpperArm)
		{
			float num3 = Mathf.Sin(num * (this.idleSpeed * 1.1f)) * this.idleIntensity * 0.4f;
			this.leftUpperArm.localRotation *= Quaternion.Euler(num3 * 1.2f, 0f, 0f);
			this.rightUpperArm.localRotation *= Quaternion.Euler(-num3 * 0.8f, 0f, 0f);
		}
		if (this.leftForearm && this.rightForearm)
		{
			float num4 = Mathf.Sin(num * (this.idleSpeed * 1.2f)) * this.idleIntensity * 0.3f;
			this.leftForearm.localRotation *= Quaternion.Euler(num4 * 1.2f, 0f, 0f);
			this.rightForearm.localRotation *= Quaternion.Euler(-num4 * 0.8f, 0f, 0f);
		}
		this.ApplyLegBalancing(this.leftUpperLeg, this.leftLowerLeg, this.leftFoot, true);
		this.ApplyLegBalancing(this.rightUpperLeg, this.rightLowerLeg, this.rightFoot, false);
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x00039E98 File Offset: 0x00038098
	private void ApplyLegBalancing(Transform upperLeg, Transform lowerLeg, Transform foot, bool isLeft)
	{
		if (upperLeg == null || lowerLeg == null || foot == null)
		{
			return;
		}
		float num = isLeft ? 1f : -1f;
		float num2 = Mathf.Sin(Time.time * (this.idleSpeed * 0.9f)) * this.idleIntensity * 25f;
		upperLeg.localRotation *= Quaternion.Euler(0f, 0f, num2 * 0.3f * num);
		lowerLeg.localRotation *= Quaternion.Euler(0f, 0f, -num2 * 0.3f * num);
		foot.localRotation *= Quaternion.Euler(0f, 0f, -num2 * 0.5f * num);
	}

	// Token: 0x04000E04 RID: 3588
	[Header("Body Parts to Smooth")]
	public Transform spine0;

	// Token: 0x04000E05 RID: 3589
	[Header("Body Parts to Smooth")]
	public Transform spine1;

	// Token: 0x04000E06 RID: 3590
	[Header("Body Parts to Smooth")]
	public Transform spine2;

	// Token: 0x04000E07 RID: 3591
	[Header("Body Parts to Smooth")]
	public Transform neck;

	// Token: 0x04000E08 RID: 3592
	public Transform leftUpperArm;

	// Token: 0x04000E09 RID: 3593
	public Transform leftForearm;

	// Token: 0x04000E0A RID: 3594
	public Transform leftHand;

	// Token: 0x04000E0B RID: 3595
	public Transform rightUpperArm;

	// Token: 0x04000E0C RID: 3596
	public Transform rightForearm;

	// Token: 0x04000E0D RID: 3597
	public Transform rightHand;

	// Token: 0x04000E0E RID: 3598
	public Transform leftUpperLeg;

	// Token: 0x04000E0F RID: 3599
	public Transform leftLowerLeg;

	// Token: 0x04000E10 RID: 3600
	public Transform leftFoot;

	// Token: 0x04000E11 RID: 3601
	public Transform rightUpperLeg;

	// Token: 0x04000E12 RID: 3602
	public Transform rightLowerLeg;

	// Token: 0x04000E13 RID: 3603
	public Transform rightFoot;

	// Token: 0x04000E14 RID: 3604
	[Header("Idle Movement")]
	public bool enableIdleMotion = true;

	// Token: 0x04000E15 RID: 3605
	public float idleIntensity = 3.5f;

	// Token: 0x04000E16 RID: 3606
	public float idleSpeed = 0.6f;

	// Token: 0x04000E17 RID: 3607
	[Header("Smoothing & Jitter Fix")]
	public float smoothFactor = 0.2f;

	// Token: 0x04000E18 RID: 3608
	private float timeOffset;

	// Token: 0x04000E19 RID: 3609
	private float smoothedWeightShift;
}
