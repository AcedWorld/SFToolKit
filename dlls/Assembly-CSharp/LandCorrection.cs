using System;
using UnityEngine;

// Token: 0x02000186 RID: 390
public class LandCorrection : MonoBehaviour
{
	// Token: 0x0600061F RID: 1567 RVA: 0x0002C69C File Offset: 0x0002A89C
	private void Update()
	{
		if (this.references.scooterController.isGrounded)
		{
			this.speedDampen = 0f;
		}
		if (!this.references.scooterController.isGrounded)
		{
			this.speedDampen = Mathf.Lerp(this.speedDampen, this.settings.speedBeforeInput, Time.deltaTime * this.settings.dampeningAmount);
		}
		this.targetRotation = new Quaternion(0f, this.references.playerRB.rotation.y, 0f, this.references.playerRB.rotation.w);
		this.spawnRotation = Quaternion.FromToRotation(Vector3.up, this.landNormal) * this.targetRotation;
		this.temp = this.spawnRotation.normalized;
		if (this.landAssist && !this.references.scooterController.isGrounded)
		{
			this.references.playerRB.MoveRotation(Quaternion.Slerp(this.references.playerRB.rotation, this.temp, this.speedDampen * Time.deltaTime));
		}
		if (this.correctFlip && !this.references.scooterController.isGrounded)
		{
			this.r_Speed = Mathf.Lerp(this.r_Speed, this.settings.speedAfterInput, this.settings.dampeningAmount * Time.deltaTime);
			this.references.playerRB.MoveRotation(Quaternion.Slerp(this.references.playerRB.rotation, this.temp, this.r_Speed * Time.deltaTime));
		}
		if (this.correctFlipTrigger != this.correctFlip)
		{
			this.references.trajectoryPrediction.PredictLanding();
			this.UpdateLandRotation();
			this.correctFlipTrigger = this.correctFlip;
		}
	}

	// Token: 0x06000620 RID: 1568 RVA: 0x0002C878 File Offset: 0x0002AA78
	private void FixedUpdate()
	{
		float leftStickY = this.references.scooterflowInputSystem.LeftStickY;
		if (this.references.scooterController.groundInformation.transformX < this.settings.MaximumX && this.references.scooterController.groundInformation.transformX > this.settings.MinimumX && this.references.scooterController.groundInformation.transformZ < this.settings.MaximumZ && this.references.scooterController.groundInformation.transformZ > this.settings.MinimumZ && !this.references.scooterController.isGrounded && !this.landAssist && leftStickY == 0f)
		{
			this.correctFlip = true;
		}
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x0002C94C File Offset: 0x0002AB4C
	public void UpdateLandRotation()
	{
		this.landNormal = this.references.trajectoryPrediction.landNormal;
		Vector3 to = this.references.trajectoryPrediction.landNormal;
		float num = Vector3.Angle(Vector3.up, to);
		if (this.references.hop.currentState != PlayerState.WallRiding)
		{
			if (this.references.trajectoryPrediction.IsGroingToGrind)
			{
				this.settings.speedBeforeInput = 12f;
			}
			else
			{
				this.settings.speedBeforeInput = this.settings.tempSpeedBeforeInput;
			}
		}
		else
		{
			this.settings.speedBeforeInput = 10f;
		}
		if (num >= 89f && num <= 91f)
		{
			this.InstantiateWallHeightCheck();
		}
		if (this.debug)
		{
			Vector3 landPoint = this.references.trajectoryPrediction.landPoint;
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			gameObject.transform.position = landPoint;
			gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			Object.Destroy(gameObject.GetComponent<Collider>());
			gameObject.GetComponent<Renderer>().material.color = Color.red;
		}
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x0002CA6A File Offset: 0x0002AC6A
	public void UpdateLandRotationCustom(Vector3 groundnormcustom)
	{
		this.landNormal = groundnormcustom;
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x0002CA73 File Offset: 0x0002AC73
	public void OnLand()
	{
		this.correctFlip = false;
		this.r_Speed = 0f;
	}

	// Token: 0x06000624 RID: 1572 RVA: 0x0002CA88 File Offset: 0x0002AC88
	public void InstantiateWallHeightCheck()
	{
		if (this.settings.WallCheckPrefab != null)
		{
			Vector3 a = base.transform.position - this.references.trajectoryPrediction.landPoint;
			a.Normalize();
			Vector3 origin = this.references.trajectoryPrediction.landPoint + a * this.settings.offsetFromWall;
			Vector3 down = Vector3.down;
			RaycastHit raycastHit;
			if (Physics.Raycast(origin, down, out raycastHit) && raycastHit.distance < this.settings.minimumHeightForWall)
			{
				this.landNormal = new Vector3(0f, 0f, 0f);
			}
		}
	}

	// Token: 0x04000A49 RID: 2633
	public bool debug;

	// Token: 0x04000A4A RID: 2634
	public bool landAssist;

	// Token: 0x04000A4B RID: 2635
	public bool correctFlip;

	// Token: 0x04000A4C RID: 2636
	public LLReferences references;

	// Token: 0x04000A4D RID: 2637
	public LLSettings settings;

	// Token: 0x04000A4E RID: 2638
	private Quaternion spawnRotation;

	// Token: 0x04000A4F RID: 2639
	private Quaternion targetRotation;

	// Token: 0x04000A50 RID: 2640
	private float r_Speed;

	// Token: 0x04000A51 RID: 2641
	private float speedDampen;

	// Token: 0x04000A52 RID: 2642
	[HideInInspector]
	public Quaternion temp;

	// Token: 0x04000A53 RID: 2643
	private bool correctFlipTrigger;

	// Token: 0x04000A54 RID: 2644
	public Vector3 landNormal;
}
