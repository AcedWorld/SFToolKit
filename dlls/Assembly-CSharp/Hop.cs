using System;
using Rewired;
using UnityEngine;

// Token: 0x02000183 RID: 387
public class Hop : MonoBehaviour
{
	// Token: 0x06000613 RID: 1555 RVA: 0x0002BCE7 File Offset: 0x00029EE7
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.lowpop = true;
	}

	// Token: 0x06000614 RID: 1556 RVA: 0x0002BD06 File Offset: 0x00029F06
	private void Update()
	{
		this.LowPopCheck();
		this.HopTimerCheck();
	}

	// Token: 0x06000615 RID: 1557 RVA: 0x0002BD14 File Offset: 0x00029F14
	private void HopTimerCheck()
	{
		if (!this.references.scooterController.isGrounded)
		{
			this.hopTimerSettings.hopTimer = this.hopTimerSettings.hopTime;
		}
		if (this.hopTimerSettings.hopTimer > 0f && this.references.scooterController.isGrounded)
		{
			this.hopTimerSettings.hopTimer -= Time.deltaTime;
		}
		if (this.hopTimerSettings.hopTimer < 0f && this.references.scooterController.isGrounded)
		{
			this.hopTimerSettings.hopTimer = 0f;
		}
	}

	// Token: 0x06000616 RID: 1558 RVA: 0x0002BDB8 File Offset: 0x00029FB8
	private void HopInput()
	{
		if (this.player.GetButton("RightStickDown"))
		{
			this.timeLeft = this.normalHopSettings.minimumTimeForJoystick;
		}
		if (this.timeLeft > -2f)
		{
			this.timeLeft -= Time.deltaTime;
		}
		if (this.player.GetButton("RightStickDown"))
		{
			this.timeHeld += Time.deltaTime;
		}
		if (this.references.scooterController.NoseManual)
		{
			this.noseManualTimeLeft = this.normalHopSettings.minimumTimeForJoystick;
		}
		if (this.noseManualTimeLeft > -2f)
		{
			this.noseManualTimeLeft -= Time.deltaTime;
		}
		if (this.references.scooterController.Manual)
		{
			this.ManualTimeLeft = this.normalHopSettings.minimumTimeForJoystick;
		}
		if (this.ManualTimeLeft > -2f)
		{
			this.ManualTimeLeft -= Time.deltaTime;
		}
		if (this.references.scooterController.FootJam)
		{
			this.footJamTimeLeft = this.normalHopSettings.minimumTimeForJoystick;
		}
		if (this.footJamTimeLeft > -2f)
		{
			this.footJamTimeLeft -= Time.deltaTime;
		}
	}

	// Token: 0x06000617 RID: 1559 RVA: 0x0002BEF4 File Offset: 0x0002A0F4
	private void LowPopCheck()
	{
		if (this.player.GetButtonUp("RightStickDown"))
		{
			this.timeHeld = 0f;
			this.cancelLowPop = true;
		}
		if (this.cancelLowPop)
		{
			this.cancelLowPopTime += Time.deltaTime;
			if (this.cancelLowPopTime > 0.5f)
			{
				this.lowpop = true;
				this.cancelLowPopTime = 0f;
				this.cancelLowPop = false;
			}
		}
		if (this.timeHeld > this.lowHopSettings.maximumTimeForJoystick)
		{
			this.lowpop = false;
		}
	}

	// Token: 0x06000618 RID: 1560 RVA: 0x0002BF80 File Offset: 0x0002A180
	private void FixedUpdate()
	{
		this.HopInput();
		this.RampCheck();
		this.CheckState();
		if (this.references.scooterController.isGrounded && this.hopTimerSettings.hopTimer == 0f)
		{
			if (this.timeLeft >= 1f && this.player.GetButton("RightStickUp"))
			{
				if (this.currentState == PlayerState.Normal || this.currentState == PlayerState.LowPop)
				{
					float axis = this.player.GetAxis("RightStickX");
					Vector3 vector = this.references.jumpDirection.transform.up;
					if (Mathf.Abs(axis) > 0.15f && this.references.playerRigidbody.velocity.magnitude > 0.1f)
					{
						Vector3 b = Vector3.Cross(this.references.playerRigidbody.velocity.normalized, Vector3.up) * axis * 0.25f;
						vector -= b;
						vector.Normalize();
					}
					float strength = (this.currentState == PlayerState.Normal) ? this.normalHopSettings.strength : this.lowHopSettings.strength;
					this.PlayerHop(false, vector, strength);
				}
				if (this.currentState == PlayerState.FootJam)
				{
					float axis2 = this.player.GetAxis("RightStickX");
					Vector3 vector2 = Vector3.up;
					if (Mathf.Abs(axis2) > 0.2f)
					{
						Vector3 b2 = Vector3.Cross(this.references.playerRigidbody.velocity.normalized, Vector3.up) * axis2 * 0.25f;
						vector2 -= b2;
						vector2.Normalize();
					}
					this.references.playerRigidbody.velocity = base.transform.forward.normalized * 1.25f;
					this.PlayerHop(false, vector2, this.footJamHopSettings.upwardStrength);
					this.PlayerHop(false, -base.transform.forward, this.footJamHopSettings.forwardStrength);
					this.references.rampDirection.FootJamAssist = true;
				}
				if (this.currentState == PlayerState.Grinding)
				{
					float axis3 = this.player.GetAxis("RightStickX");
					Vector3 grindDirection = this.references.grindSystem.grindDirection;
					Vector3 vector3 = Vector3.up * 0.95f + grindDirection * 0.05f;
					vector3.Normalize();
					if (Mathf.Abs(axis3) > 0.15f)
					{
						Vector3 b3 = Vector3.Cross(this.references.playerRigidbody.velocity.normalized, Vector3.up) * axis3 * 0.5f;
						vector3 -= b3;
						vector3.Normalize();
					}
					this.references.grindSystem.StopGrinding(false, false);
					this.PlayerHop(false, vector3, this.grindHopSettings.strength);
				}
				if (this.currentState == PlayerState.OnRamp)
				{
					this.PlayerHop(true, Vector3.up, this.rampHopSettings.strength);
				}
				if (this.currentState == PlayerState.OnVert)
				{
					this.PlayerHop(false, Vector3.up, this.vertHopSettings.strength);
				}
				if (this.currentState == PlayerState.WallRiding)
				{
					this.PlayerHop(false, Vector3.up, this.wallrideHopSettings.strength);
					this.references.playerRigidbody.AddRelativeForce(Vector3.up * this.wallrideHopSettings.outwardStrength * Time.deltaTime, this.forceMode);
				}
			}
			if (this.noseManualTimeLeft >= 1f && this.player.GetButton("RightStickDown") && this.currentState == PlayerState.NoseManual)
			{
				this.PlayerHop(false, this.references.jumpDirection.transform.up, this.noseManualHopSettings.strength);
			}
		}
	}

	// Token: 0x06000619 RID: 1561 RVA: 0x0002C36C File Offset: 0x0002A56C
	private void RampCheck()
	{
		if ((this.references.scooterController.groundInformation.groundAngleX > this.rampHopSettings.RampEnd && this.references.scooterController.groundInformation.groundAngleX < this.vertHopSettings.RampEnd) || (this.references.scooterController.groundInformation.groundAngleX < -this.rampHopSettings.RampEnd && this.references.scooterController.groundInformation.groundAngleX > -this.vertHopSettings.RampEnd))
		{
			this.vert = true;
		}
		else
		{
			this.vert = false;
		}
		if ((this.references.scooterController.groundInformation.groundAngleX > this.rampHopSettings.RampStart && this.references.scooterController.groundInformation.groundAngleX < this.rampHopSettings.RampEnd) || (this.references.scooterController.groundInformation.groundAngleX < -this.rampHopSettings.RampStart && this.references.scooterController.groundInformation.groundAngleX > -this.rampHopSettings.RampEnd))
		{
			this.ramp = true;
			return;
		}
		this.ramp = false;
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x0002C4AC File Offset: 0x0002A6AC
	private void CheckState()
	{
		if (this.references.scooterController.isGrounded)
		{
			if (this.references.lockRotation.isGrinding)
			{
				this.currentState = PlayerState.Grinding;
				return;
			}
			if (this.vert)
			{
				if (this.references.vertCheck.wall && this.ManualTimeLeft <= 1f)
				{
					this.currentState = PlayerState.WallRiding;
					return;
				}
				if (this.references.rampDirection.AirConditionsMet)
				{
					this.currentState = PlayerState.OnRamp;
					return;
				}
				this.currentState = PlayerState.OnVert;
				return;
			}
			else
			{
				if (this.ramp)
				{
					this.currentState = PlayerState.OnRamp;
					return;
				}
				if (this.noseManualTimeLeft >= 1f)
				{
					this.currentState = PlayerState.NoseManual;
					return;
				}
				if ((double)this.footJamTimeLeft >= 0.9 && this.references.playerRigidbody.velocity.magnitude < this.references.scooterController.footJamSettings.JamHopVelTheshold)
				{
					this.currentState = PlayerState.FootJam;
					return;
				}
				if (this.lowpop)
				{
					this.currentState = PlayerState.LowPop;
					return;
				}
				if (this.references.rampDirection.AirConditionsMet)
				{
					this.currentState = PlayerState.OnRamp;
					return;
				}
				this.currentState = PlayerState.Normal;
			}
		}
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x0002C5D8 File Offset: 0x0002A7D8
	public void PlayerHop(bool relativeForce, Vector3 direction, float strength)
	{
		if (!relativeForce)
		{
			this.references.playerRigidbody.AddForce(direction * strength * Time.deltaTime, this.forceMode);
		}
		if (relativeForce)
		{
			this.references.playerRigidbody.AddRelativeForce(direction * strength * Time.deltaTime, this.forceMode);
		}
		this.timeLeft = -1f;
		this.noseManualTimeLeft = 0f;
		if (this.debug)
		{
			Debug.Log(this.currentState);
		}
		this.references.rampDirection.hopTriggerInitiated = true;
		if (!this.references.scooterController.isGrounded)
		{
			this.references.rampDirection.FootJamAssist = true;
		}
	}

	// Token: 0x04000A1F RID: 2591
	public bool debug;

	// Token: 0x04000A20 RID: 2592
	public ForceMode forceMode;

	// Token: 0x04000A21 RID: 2593
	public PlayerState currentState;

	// Token: 0x04000A22 RID: 2594
	public References references;

	// Token: 0x04000A23 RID: 2595
	public NormalHopSettings normalHopSettings;

	// Token: 0x04000A24 RID: 2596
	public LowHopSettings lowHopSettings;

	// Token: 0x04000A25 RID: 2597
	public GrindHopSettings grindHopSettings;

	// Token: 0x04000A26 RID: 2598
	public RampHopSettings rampHopSettings;

	// Token: 0x04000A27 RID: 2599
	public VertHopSettings vertHopSettings;

	// Token: 0x04000A28 RID: 2600
	public WallrideHopSettings wallrideHopSettings;

	// Token: 0x04000A29 RID: 2601
	public NoseManualHopSettings noseManualHopSettings;

	// Token: 0x04000A2A RID: 2602
	public FootJamHopSettings footJamHopSettings;

	// Token: 0x04000A2B RID: 2603
	public HopTimerSettings hopTimerSettings;

	// Token: 0x04000A2C RID: 2604
	public float timeLeft;

	// Token: 0x04000A2D RID: 2605
	private float noseManualTimeLeft;

	// Token: 0x04000A2E RID: 2606
	private float ManualTimeLeft;

	// Token: 0x04000A2F RID: 2607
	private float footJamTimeLeft;

	// Token: 0x04000A30 RID: 2608
	private float timeHeld;

	// Token: 0x04000A31 RID: 2609
	private bool lowpop;

	// Token: 0x04000A32 RID: 2610
	private bool cancelLowPop;

	// Token: 0x04000A33 RID: 2611
	private float cancelLowPopTime;

	// Token: 0x04000A34 RID: 2612
	private Vector3 jumpDirection;

	// Token: 0x04000A35 RID: 2613
	private bool ramp;

	// Token: 0x04000A36 RID: 2614
	[HideInInspector]
	public bool vert;

	// Token: 0x04000A37 RID: 2615
	[HideInInspector]
	public int playerId;

	// Token: 0x04000A38 RID: 2616
	private Player player;
}
