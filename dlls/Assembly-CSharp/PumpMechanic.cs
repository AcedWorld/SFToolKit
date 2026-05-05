using System;
using Rewired;
using UnityEngine;

// Token: 0x02000187 RID: 391
public class PumpMechanic : MonoBehaviour
{
	// Token: 0x06000626 RID: 1574 RVA: 0x0002CB37 File Offset: 0x0002AD37
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x06000627 RID: 1575 RVA: 0x0002CB4F File Offset: 0x0002AD4F
	public void ClearPump()
	{
		this.flatGroundReached = true;
		this.upPumpStart = true;
		this.airTrigger = true;
		this.pumpTimer = 0f;
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x0002CB74 File Offset: 0x0002AD74
	private void Update()
	{
		if (!this.scooterController.isGrounded)
		{
			this.flatGroundReached = true;
			this.upPumpStart = true;
			this.airTrigger = true;
			this.pumpTimer = 0f;
			return;
		}
		if (this.scooterController.groundInformation.groundAngleX < 5f)
		{
			if (this.pumpTimer <= 0f)
			{
				this.flatGroundReached = true;
				return;
			}
		}
		else
		{
			if (this.player.GetButton("RightStickDown") || this.autoPump)
			{
				if (!this.scooterController.downhill)
				{
					if (!this.upPumpStart && this.flatGroundReached)
					{
						this.pumpTimer = this.pumpTime;
						this.truePumpForce = this.pumpingForce * 0.2f;
						this.upPumpStart = true;
						if (this.scooterController.fakie)
						{
							this.pumpDirection = base.transform.forward;
						}
						else
						{
							this.pumpDirection = -base.transform.forward;
						}
					}
				}
				else if ((this.facingRamp || this.airTrigger || this.player.GetButton("RightStickDown")) && this.pumpTimer <= 0f && this.flatGroundReached)
				{
					this.pumpTimer = this.pumpTime;
					this.truePumpForce = this.pumpingForce * 0.7f;
					this.flatGroundReached = false;
					this.upPumpStart = false;
					if (this.airTrigger)
					{
						this.pumpDirection = Vector3.down;
					}
					else if (this.scooterController.fakie)
					{
						this.pumpDirection = (Vector3.down + base.transform.forward).normalized;
					}
					else
					{
						this.pumpDirection = (Vector3.down + -base.transform.forward).normalized;
					}
				}
			}
			this.truePumpForce = Mathf.Clamp(this.truePumpForce, 0f, 2500f);
			this.airTrigger = false;
		}
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x0002CD7E File Offset: 0x0002AF7E
	private void FixedUpdate()
	{
		this.AngleCheck();
		this.pumpTimerFunc();
	}

	// Token: 0x0600062A RID: 1578 RVA: 0x0002CD8C File Offset: 0x0002AF8C
	private void pumpTimerFunc()
	{
		if (this.pumpTimer > 0f)
		{
			this.pumpTimer -= Time.fixedDeltaTime;
			this.playerRigidbody.AddForce(this.pumpDirection * this.truePumpForce * Time.deltaTime, ForceMode.Impulse);
			this.playerIsPumping = true;
			return;
		}
		this.playerIsPumping = false;
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x0002CDF0 File Offset: 0x0002AFF0
	private void AngleCheck()
	{
		Vector3 normalized = this.scooterController.mainRaycast.normal.normalized;
		Vector3 vector = Vector3.Cross(Vector3.right, normalized);
		Vector3 normalized2 = new Vector3(vector.x, 0f, vector.z).normalized;
		Vector3 normalized3;
		if (this.scooterController.fakie)
		{
			normalized3 = new Vector3(base.transform.forward.x, 0f, base.transform.forward.z).normalized;
		}
		else
		{
			normalized3 = new Vector3(-base.transform.forward.x, 0f, -base.transform.forward.z).normalized;
		}
		float num = Vector3.Angle(normalized3, normalized2);
		if (num > 90f)
		{
			num = 180f - num;
		}
		this.facingRamp = (num <= 75f);
	}

	// Token: 0x04000A55 RID: 2645
	public ScooterController scooterController;

	// Token: 0x04000A56 RID: 2646
	public Rigidbody playerRigidbody;

	// Token: 0x04000A57 RID: 2647
	public float pumpTime = 0.6f;

	// Token: 0x04000A58 RID: 2648
	public float pumpTimer;

	// Token: 0x04000A59 RID: 2649
	public float pumpingForce = 2500f;

	// Token: 0x04000A5A RID: 2650
	private float truePumpForce;

	// Token: 0x04000A5B RID: 2651
	public bool flatGroundReached;

	// Token: 0x04000A5C RID: 2652
	public bool upPumpStart;

	// Token: 0x04000A5D RID: 2653
	public bool facingRamp;

	// Token: 0x04000A5E RID: 2654
	public bool airTrigger;

	// Token: 0x04000A5F RID: 2655
	private Vector3 pumpDirection;

	// Token: 0x04000A60 RID: 2656
	public bool playerIsPumping;

	// Token: 0x04000A61 RID: 2657
	public bool autoPump;

	// Token: 0x04000A62 RID: 2658
	private int playerId;

	// Token: 0x04000A63 RID: 2659
	private Player player;
}
