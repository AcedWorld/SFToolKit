using System;
using UnityEngine;

// Token: 0x0200019D RID: 413
public class upright : MonoBehaviour
{
	// Token: 0x06000676 RID: 1654 RVA: 0x00030FF0 File Offset: 0x0002F1F0
	private void OnDisable()
	{
		this.LeftStickX = 0f;
		this.leanAmount = 0f;
		this.centreOfMassZ = 0f;
		this.dampenedTurn = 0f;
		this.playerXRotation = 0f;
		this.playerZRotation = 0f;
		this.smoothZRotation = 0f;
	}

	// Token: 0x06000677 RID: 1655 RVA: 0x0003104A File Offset: 0x0002F24A
	private void Update()
	{
		this.LeftStickX = -this.references.inputSystem.LeftStickX;
		this.playerZRotation = this.LeftStickX * this.leanAmount;
	}

	// Token: 0x06000678 RID: 1656 RVA: 0x00031078 File Offset: 0x0002F278
	private void FixedUpdate()
	{
		this.smoothZRotation = Mathf.Lerp(this.smoothZRotation, this.playerZRotation, this.leanSmoothness);
		this.dampenedTurn = Mathf.Lerp(this.dampenedTurn, this.LeftStickX, this.turnDampen);
		this.WheelRaycasts();
		if (!this.references.scooterController.revertSettings.RevertActivated)
		{
			this.HandleCOM();
		}
		this.HandleLeanAmount();
		if (!this.references.ragdollControl.ragdollActive && !this.references.grindScript.isGrinding && !this.references.deckCollision.deckCollision && this.references.scooterController.isGrounded)
		{
			this.BalanceLogic();
		}
	}

	// Token: 0x06000679 RID: 1657 RVA: 0x00031138 File Offset: 0x0002F338
	private void WheelRaycasts()
	{
		Vector3 direction = this.references.playerRB.transform.TransformDirection(Vector3.down);
		this.frontHit = default(RaycastHit);
		if (Physics.Raycast(this.references.frontWheel.transform.position, direction, out this.frontHit, float.PositiveInfinity, this.layerMask) && this.debug)
		{
			Debug.DrawLine(this.references.frontWheel.transform.position, this.frontHit.point, Color.white);
		}
		this.rearHit = default(RaycastHit);
		if (Physics.Raycast(this.references.rearWheel.transform.position, direction, out this.rearHit, float.PositiveInfinity, this.layerMask) && this.debug)
		{
			Debug.DrawLine(this.references.rearWheel.transform.position, this.rearHit.point, Color.white);
		}
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x00031244 File Offset: 0x0002F444
	private void HandleLeanAmount()
	{
		if (this.references.scooterController.Manual || this.references.scooterController.NoseManual)
		{
			if (this.references.scooterController.fakie)
			{
				this.leanAmount = -this.leanAmountManual;
			}
			if (!this.references.scooterController.fakie)
			{
				this.leanAmount = this.leanAmountManual;
				return;
			}
		}
		else
		{
			this.leanAmount = this.leanAmountNormal;
		}
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x000312C0 File Offset: 0x0002F4C0
	private void HandleCOM()
	{
		if (this.references.scooterController.isGrounded)
		{
			if (this.references.scooterController.Manual)
			{
				this.centreOfMassZ = this.manualFactor;
			}
			else if (this.references.scooterController.NoseManual)
			{
				this.centreOfMassZ = this.noseManualFactor;
			}
			else if (this.references.scooterController.FootJam)
			{
				this.centreOfMassZ = this.footJamFactor;
			}
			else
			{
				this.centreOfMassZ = 0f;
				this.references.scooterController.centreOfMassSettings.CentreOfMass.z = 0f;
			}
		}
		else
		{
			this.centreOfMassZ = 0f;
			this.references.scooterController.centreOfMassSettings.CentreOfMass.z = 0f;
		}
		this.playerXRotation = this.centreOfMassZ;
		this.references.scooterController.centreOfMassSettings.CentreOfMass.z = this.centreOfMassZ;
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x000313C8 File Offset: 0x0002F5C8
	private void BalanceLogic()
	{
		if (this.references.scooterController.Manual && !this.references.scooterController.FootJam)
		{
			this.AdjustPlayer(this.rearHit.normal.normalized);
			this.references.playerRB.AddRelativeTorque(0f, this.dampenedTurn * this.ManualTurnForce, 0f * Time.deltaTime, ForceMode.Acceleration);
		}
		if (this.references.scooterController.NoseManual && !this.references.scooterController.FootJam)
		{
			this.AdjustPlayer(this.frontHit.normal.normalized);
			this.references.playerRB.AddRelativeTorque(0f, this.dampenedTurn * this.NoseManualTurnForce, 0f * Time.deltaTime, ForceMode.Acceleration);
		}
		if (this.references.scooterController.FootJam && !this.references.scooterController.Manual && !this.references.scooterController.NoseManual)
		{
			if (this.references.scooterController.footJamSettings.FootJamSpun)
			{
				this.FootJamTurnTimer += Time.deltaTime;
				float t = this.FootJamTurnTimer / 2f;
				float num = Mathf.Lerp(1.6f, 1f, t);
				this.AdjustPlayer(this.frontHit.normal.normalized);
				float num2 = this.FootJamTurnForce * num;
				float num3 = this.dampenedTurn * num;
				this.references.playerRB.AddRelativeTorque(0f, num3 * num2, 0f * Time.deltaTime, ForceMode.Acceleration);
			}
			if (!this.references.scooterController.footJamSettings.FootJamSpun)
			{
				this.AdjustPlayer(this.frontHit.normal.normalized);
				this.references.playerRB.AddRelativeTorque(0f, this.dampenedTurn * this.FootJamTurnForce, 0f * Time.deltaTime, ForceMode.Acceleration);
			}
		}
		if (!this.references.scooterController.Manual && !this.references.scooterController.NoseManual && !this.references.scooterController.FootJam)
		{
			this.AdjustPlayer((this.frontHit.normal + this.rearHit.normal).normalized);
			this.FootJamTurnTimer = 0f;
		}
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x00031650 File Offset: 0x0002F850
	private void AdjustPlayer(Vector3 groundNormal)
	{
		Vector3 a = this.references.playerRB.transform.TransformDirection(Vector3.right);
		Vector3 a2 = this.references.playerRB.transform.TransformDirection(Vector3.forward);
		groundNormal += a * this.smoothZRotation + a2 * this.playerXRotation;
		float d;
		Vector3 vector;
		Quaternion.FromToRotation(this.references.playerRB.transform.up, groundNormal).ToAngleAxis(out d, out vector);
		this.references.playerRB.AddTorque(-this.references.playerRB.angularVelocity * this.dampenFactor, ForceMode.Acceleration);
		this.references.playerRB.AddTorque(vector.normalized * d * this.adjustFactor, ForceMode.Acceleration);
	}

	// Token: 0x04000B3E RID: 2878
	public bool debug;

	// Token: 0x04000B3F RID: 2879
	public BalanceReferences references;

	// Token: 0x04000B40 RID: 2880
	public LayerMask layerMask;

	// Token: 0x04000B41 RID: 2881
	[Header("Balance Settings")]
	public float dampenFactor;

	// Token: 0x04000B42 RID: 2882
	public float adjustFactor;

	// Token: 0x04000B43 RID: 2883
	[Header("Manual Settings")]
	[Tooltip("The amount the player will lean back")]
	public float manualFactor;

	// Token: 0x04000B44 RID: 2884
	[Tooltip("The amount the player will lean forward")]
	public float noseManualFactor;

	// Token: 0x04000B45 RID: 2885
	[Tooltip("The amount the player will lean forward")]
	public float footJamFactor;

	// Token: 0x04000B46 RID: 2886
	[Tooltip("The amount of force applied when turning the player during a manual")]
	public float ManualTurnForce;

	// Token: 0x04000B47 RID: 2887
	[Tooltip("The amount of force applied when turning the player during a nose manual")]
	public float NoseManualTurnForce;

	// Token: 0x04000B48 RID: 2888
	[Tooltip("The amount of force applied when turning the player during a Foot Jam")]
	public float FootJamTurnForce;

	// Token: 0x04000B49 RID: 2889
	[HideInInspector]
	public float FootJamTurnTimer;

	// Token: 0x04000B4A RID: 2890
	[Tooltip("Dampen the turn force for manual & nose manual")]
	public float turnDampen;

	// Token: 0x04000B4B RID: 2891
	[Header("Lean Settings")]
	[Tooltip("Dampen the leaning on the z axis while in manual & nose manual")]
	public float leanAmountNormal;

	// Token: 0x04000B4C RID: 2892
	public float leanAmountManual;

	// Token: 0x04000B4D RID: 2893
	public float leanSmoothness;

	// Token: 0x04000B4E RID: 2894
	private float centreOfMassZ;

	// Token: 0x04000B4F RID: 2895
	private float dampenedTurn;

	// Token: 0x04000B50 RID: 2896
	private float playerXRotation;

	// Token: 0x04000B51 RID: 2897
	private float playerZRotation;

	// Token: 0x04000B52 RID: 2898
	private float smoothZRotation;

	// Token: 0x04000B53 RID: 2899
	public RaycastHit frontHit;

	// Token: 0x04000B54 RID: 2900
	public RaycastHit rearHit;

	// Token: 0x04000B55 RID: 2901
	private float leanAmount;

	// Token: 0x04000B56 RID: 2902
	private float LeftStickX;
}
