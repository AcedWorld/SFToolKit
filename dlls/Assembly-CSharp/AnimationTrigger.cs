using System;
using UnityEngine;

// Token: 0x02000118 RID: 280
public class AnimationTrigger : MonoBehaviour
{
	// Token: 0x06000482 RID: 1154 RVA: 0x0001ECF4 File Offset: 0x0001CEF4
	private void Update()
	{
		this.RightStickX = this.references.scooterflowInputSystem.RightStickX;
		this.RightStickY = this.references.scooterflowInputSystem.RightStickY;
		this.LeftStickX = this.references.scooterflowInputSystem.LeftStickX;
		this.LeftStickY = this.references.scooterflowInputSystem.LeftStickY;
		this.CheckForTricks();
		this.AnimationInputs();
		if (!this.references.scooterController.isGrounded)
		{
			this.TrickInputs();
			this.GetButtonTrick();
		}
		if (this.groundedTrigger != this.references.scooterController.isGrounded)
		{
			if (this.references.scooterController.isGrounded)
			{
				this.OnPlayerLanded();
			}
			if (this.references.scooterController.isGrounded && !this.references.ragdollControl.ragdollActive)
			{
				this.RagdollForTricks();
			}
			this.groundedTrigger = this.references.scooterController.isGrounded;
		}
		float num = 0.85f;
		float num2 = 6f;
		float num3 = 1.2f;
		float num4 = 0.9f;
		float num5 = Mathf.Clamp(this.references.trajectoryPrediction.relativeHighestPoint, num, num2);
		this.speedModifier = num3 - (num5 - num) / (num2 - num) * (num3 - num4);
		this.references.animator.SetFloat("SpeedModifier", this.speedModifier);
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x0001EE54 File Offset: 0x0001D054
	private void CheckForTricks()
	{
		this.L1Trick = (this.L1Active && !this.L2Active && !this.R1Active && !this.R2Active);
		this.L2Trick = (!this.L1Active && this.L2Active && !this.R1Active && !this.R2Active);
		this.R1Trick = (!this.L1Active && !this.L2Active && this.R1Active && !this.R2Active);
		this.R2Trick = (!this.L1Active && !this.L2Active && !this.R1Active && this.R2Active);
		this.R2L2Trick = (!this.L1Active && this.L2Active && !this.R1Active && this.R2Active);
		this.L1R1Trick = (this.L1Active && !this.L2Active && this.R1Active && !this.R2Active);
		this.R2L1Trick = (this.L1Active && !this.L2Active && !this.R1Active && this.R2Active);
		this.R1L2Trick = (!this.L1Active && this.L2Active && this.R1Active && !this.R2Active);
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0001EFA8 File Offset: 0x0001D1A8
	private void GetButtonTrick()
	{
		this.rightStickUpPressed = false;
		this.rightStickDownPressed = false;
		this.rightStickLeftPressed = false;
		this.rightStickRightPressed = false;
		float num = Mathf.Abs(this.RightStickX);
		float num2 = Mathf.Abs(this.RightStickY);
		if (num > num2)
		{
			if (this.RightStickX > this.settings.joystickThreshold)
			{
				this.rightStickRightPressed = true;
			}
			else if (this.RightStickX < -this.settings.joystickThreshold)
			{
				this.rightStickLeftPressed = true;
			}
		}
		else if (num2 > num)
		{
			if (this.RightStickY > this.settings.joystickThreshold)
			{
				this.rightStickUpPressed = true;
			}
			else if (this.RightStickY < -this.settings.joystickThreshold)
			{
				this.rightStickDownPressed = true;
			}
		}
		this.CheckForButtonDown();
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x0001F068 File Offset: 0x0001D268
	private void CheckForButtonDown()
	{
		if (!this.prevRightStickUpPressed && this.rightStickUpPressed)
		{
			this.RightStickUp();
		}
		if (!this.prevRightStickDownPressed && this.rightStickDownPressed)
		{
			this.RightStickDown();
		}
		if (!this.prevRightStickLeftPressed && this.rightStickLeftPressed)
		{
			this.RightStickLeft();
		}
		if (!this.prevRightStickRightPressed && this.rightStickRightPressed)
		{
			this.RightStickRight();
		}
		this.prevRightStickUpPressed = this.rightStickUpPressed;
		this.prevRightStickDownPressed = this.rightStickDownPressed;
		this.prevRightStickLeftPressed = this.rightStickLeftPressed;
		this.prevRightStickRightPressed = this.rightStickRightPressed;
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x0001F0FD File Offset: 0x0001D2FD
	public void RightStickUp()
	{
		if (this.R2L2Trick)
		{
			this.references.animator.SetTrigger("WhipFrontScoot");
		}
		if (this.L1R1Trick)
		{
			this.references.animator.SetTrigger("BarTwist");
		}
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x0001F139 File Offset: 0x0001D339
	public void RightStickDown()
	{
		if (this.L1R1Trick)
		{
			this.references.animator.SetTrigger("BodyVar");
		}
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x0001F158 File Offset: 0x0001D358
	public void RightStickLeft()
	{
		if (this.R1Trick)
		{
			this.references.animator.SetTrigger("OppoBar");
		}
		if (this.L1R1Trick)
		{
			this.references.animator.SetTrigger("TDOBar");
		}
		if (this.R2Trick)
		{
			this.references.animator.SetTrigger("HeelFlip");
		}
		if (this.L2Trick)
		{
			this.references.animator.SetTrigger("Kickless");
		}
		if (this.R2L1Trick)
		{
			this.references.animator.SetTrigger("FullHeel");
		}
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x0001F1F8 File Offset: 0x0001D3F8
	public void RightStickRight()
	{
		if (this.R1Trick)
		{
			this.references.animator.SetTrigger("BarSpin");
		}
		if (this.R2Trick)
		{
			this.references.animator.SetTrigger("TailWhip");
		}
		if (this.R1L2Trick)
		{
			this.references.animator.SetTrigger("RotorWhip");
		}
		if (this.L2Trick)
		{
			this.references.animator.SetTrigger("WhipKickless");
		}
		if (this.R2L1Trick)
		{
			this.references.animator.SetTrigger("FullWhip");
		}
		if (this.L1R1Trick)
		{
			this.references.animator.SetTrigger("TDBar");
		}
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x0001F2B4 File Offset: 0x0001D4B4
	private void OnPlayerLanded()
	{
		foreach (string name in new string[]
		{
			"WhipFrontScoot",
			"BarTwist",
			"UnTwist",
			"OppoBar",
			"TDOBar",
			"HeelFlip",
			"Kickless",
			"FullHeel",
			"BarSpin",
			"TDBar",
			"TailWhip",
			"RotorWhip",
			"WhipKickless",
			"FullWhip",
			"BodyVar"
		})
		{
			this.references.animator.ResetTrigger(name);
		}
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x0001F36C File Offset: 0x0001D56C
	private void RagdollForTricks()
	{
		this.ActivateRagdollIfStateMatches("Turndown");
		this.ActivateRagdollIfStateMatches("DeckGrab");
		this.ActivateRagdollIfStateMatches("NoHander");
		this.ActivateRagdollIfStateMatches("superman");
		this.ActivateRagdollIfStateMatches("table");
		this.ActivateRagdollIfStateMatches("Inward Briflip");
		this.ActivateRagdollIfStateMatches("CanVert");
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x0001F3C8 File Offset: 0x0001D5C8
	private void ActivateRagdollIfStateMatches(string stateName)
	{
		if (this.references.animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) && this.references.scooterController.isGrounded)
		{
			this.references.ragdollControl.ActivateRagdoll();
		}
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x0001F414 File Offset: 0x0001D614
	private void AnimationInputs()
	{
		this.references.animator.SetFloat("horizontal", this.LeftStickX, this.settings.HorizontalInputSmooth, Time.deltaTime);
		this.references.animator.SetFloat("vertical", this.RightStickY, this.settings.VerticalInputSmooth, Time.deltaTime);
		this.references.animator.SetFloat("avertical", this.LeftStickY, this.settings.VerticalInputSmooth, Time.deltaTime);
		float value = this.references.scooterController.groundInformation.AnimationX * 1.3f;
		this.references.animator.SetFloat("XRotation", value, this.settings.ProceduralXSmooth, Time.deltaTime);
		float value2 = this.references.scooterController.groundInformation.AnimationX * 2f - 1f;
		this.references.animator.SetFloat("XRotationManual", value2, this.settings.ProceduralXSmooth, Time.deltaTime);
		float value3 = this.references.scooterController.groundInformation.AnimationX * 2f + 1f;
		this.references.animator.SetFloat("XRotationNManual", value3, this.settings.ProceduralXSmooth, Time.deltaTime);
		float value4 = Mathf.Abs(this.references.playerRigidbody.rotation.z - this.references.landCorrection.temp.z) * 2f;
		this.references.animator.SetFloat("zAirLean", value4, this.settings.ProceduralZSmooth, Time.deltaTime);
		float value5 = Mathf.Abs(this.references.playerRigidbody.rotation.x - this.references.landCorrection.temp.x) * 2f;
		this.references.animator.SetFloat("xAirLean", value5, this.settings.ProceduralZSmooth, Time.deltaTime);
		if (!this.references.grindSystem.isGrinding && this.references.trajectoryPrediction.IsGroingToGrind)
		{
			this.lastGrindDirVertical = this.RightStickY;
			this.lastGrindDirHorizontal = this.RightStickX;
		}
		if (!this.references.grindSystem.isGrinding && !this.references.trajectoryPrediction.IsGroingToGrind)
		{
			this.lastGrindDirVertical = this.RightStickY;
			this.lastGrindDirHorizontal = this.RightStickX;
		}
		if (!this.references.hop.vert)
		{
			float value6 = this.references.scooterController.groundInformation.AnimationZ * 1.3f;
			this.references.animator.SetFloat("ZRotation", value6, this.settings.ProceduralZSmooth, Time.deltaTime);
		}
		if (this.references.scooterController.isGrounded)
		{
			this.references.animator.SetBool("Stopping", this.CircleActive);
			this.references.animator.SetBool("Push", this.CrossActive);
		}
		this.references.animator.SetBool("IsGrounded", this.references.scooterController.isGrounded);
		this.references.animator.SetBool("Fakie", this.references.scooterController.fakie);
		this.references.animator.SetBool("Manual", this.references.scooterController.Manual);
		this.references.animator.SetBool("NoseManual", this.references.scooterController.NoseManual);
		this.references.animator.SetBool("Grind", this.references.lockRotation.isGrinding);
		this.references.animator.SetBool("JamManual", this.references.scooterController.FootJam);
		this.references.animator.SetBool("RevertLeft", this.references.scooterController.revertSettings.RevertLeft);
		this.references.animator.SetBool("RevertRight", this.references.scooterController.revertSettings.RevertRight);
		this.references.animator.SetBool("IsGrinding", this.references.grindSystem.isGrinding);
		this.references.animator.SetFloat("grindTilt", this.references.grindSystem.grindTilt, this.settings.VerticalInputSmooth, Time.deltaTime);
		if (this.references.grindSystem.grindLand)
		{
			this.references.animator.SetFloat("GrindCrouch", -1f, this.settings.VerticalInputSmooth * 0.2f, Time.deltaTime);
		}
		else
		{
			this.references.animator.SetFloat("GrindCrouch", Mathf.Clamp(this.RightStickY, -1f, 0f), this.settings.VerticalInputSmooth * 0.75f, Time.deltaTime);
		}
		this.references.animator.SetFloat("GrindVertical", this.references.grindSystem.contactPointAnimVar, this.settings.VerticalInputSmooth * 0.25f, Time.deltaTime);
		if (!this.references.scooterController.isGrounded)
		{
			this.references.animator.SetFloat("HopTilt", 0f, 0.2f, Time.deltaTime);
		}
		else if (this.references.scooterController.groundInformation.groundAngleX > 60f)
		{
			this.references.animator.SetFloat("HopTilt", 0f, 99f, Time.deltaTime);
		}
		if (!this.references.animator.GetCurrentAnimatorStateInfo(0).IsName("AirMovement") && (this.references.scooterController.isGrounded || this.references.lockRotation.isGrinding) && this.references.hop.hopTimerSettings.hopTimer == 0f)
		{
			if (this.references.scooterController.groundInformation.groundAngleX < 60f)
			{
				this.references.animator.SetFloat("HopTilt", -1f);
				return;
			}
			this.references.animator.SetFloat("HopTilt", 0f);
		}
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x0001FAC0 File Offset: 0x0001DCC0
	private void TrickInputs()
	{
		this.references.animator.SetBool("Table", this.rightStickRightPressed && this.L1Trick);
		this.references.animator.SetBool("Cannon", this.rightStickLeftPressed && this.L1Trick);
		this.references.animator.SetBool("CanVert", this.rightStickUpPressed && this.L1Trick);
		this.references.animator.SetBool("Turndown", this.rightStickDownPressed && this.L1Trick);
		this.references.animator.SetBool("Superman", this.rightStickDownPressed && this.L2Trick);
		this.references.animator.SetBool("NoHands", this.rightStickUpPressed && this.R1Trick);
		this.references.animator.SetBool("DeckGrab", this.rightStickDownPressed && this.R1Trick);
		this.references.animator.SetBool("ContWhip", this.rightStickRightPressed && this.R2L2Trick);
		this.references.animator.SetBool("MultiHeel", this.rightStickLeftPressed && this.R2L2Trick);
		this.references.animator.SetBool("Inward", this.rightStickUpPressed && this.R2Trick);
		this.references.animator.SetBool("BriFlip", this.rightStickDownPressed && this.R2Trick);
		this.references.animator.SetBool("FingerWhip", this.rightStickUpPressed && this.L2Trick);
		this.references.animator.SetBool("ButterCup", this.rightStickDownPressed && this.R2L2Trick);
		this.references.animator.SetBool("WhipFrontScoot", this.rightStickUpPressed && this.R2L2Trick);
		this.references.animator.SetBool("FrontScoot", this.rightStickUpPressed && this.R2L1Trick);
		this.references.animator.SetBool("Macflip", this.rightStickDownPressed && this.R2L1Trick);
		this.references.animator.SetBool("Umbrella", this.rightStickDownPressed && this.R1L2Trick);
		this.references.animator.SetBool("FrontButterCup", this.rightStickUpPressed && this.R1L2Trick);
		this.references.animator.SetBool("NothingFrontScoot", this.rightStickLeftPressed && this.R1L2Trick);
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x0001FD9F File Offset: 0x0001DF9F
	public void CatchableTrue()
	{
		this.references.animator.SetBool("Catchable", true);
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x0001FDB7 File Offset: 0x0001DFB7
	public void CatchableFalse()
	{
		this.references.animator.SetBool("Catchable", false);
	}

	// Token: 0x040006CD RID: 1741
	private bool groundedTrigger;

	// Token: 0x040006CE RID: 1742
	public AnimationReferences references;

	// Token: 0x040006CF RID: 1743
	public AnimationSettings settings;

	// Token: 0x040006D0 RID: 1744
	[HideInInspector]
	public bool L1Active;

	// Token: 0x040006D1 RID: 1745
	[HideInInspector]
	public bool L2Active;

	// Token: 0x040006D2 RID: 1746
	[HideInInspector]
	public bool R1Active;

	// Token: 0x040006D3 RID: 1747
	[HideInInspector]
	public bool R2Active;

	// Token: 0x040006D4 RID: 1748
	[HideInInspector]
	public bool CrossActive;

	// Token: 0x040006D5 RID: 1749
	[HideInInspector]
	public bool CircleActive;

	// Token: 0x040006D6 RID: 1750
	private bool L1Trick;

	// Token: 0x040006D7 RID: 1751
	private bool L2Trick;

	// Token: 0x040006D8 RID: 1752
	private bool R1Trick;

	// Token: 0x040006D9 RID: 1753
	private bool R2Trick;

	// Token: 0x040006DA RID: 1754
	private bool R2L2Trick;

	// Token: 0x040006DB RID: 1755
	private bool L1R1Trick;

	// Token: 0x040006DC RID: 1756
	private bool R2L1Trick;

	// Token: 0x040006DD RID: 1757
	private bool R1L2Trick;

	// Token: 0x040006DE RID: 1758
	private float RightStickX;

	// Token: 0x040006DF RID: 1759
	private float RightStickY;

	// Token: 0x040006E0 RID: 1760
	private float LeftStickX;

	// Token: 0x040006E1 RID: 1761
	private float LeftStickY;

	// Token: 0x040006E2 RID: 1762
	private bool rightStickUpPressed;

	// Token: 0x040006E3 RID: 1763
	private bool rightStickDownPressed;

	// Token: 0x040006E4 RID: 1764
	private bool rightStickLeftPressed;

	// Token: 0x040006E5 RID: 1765
	private bool rightStickRightPressed;

	// Token: 0x040006E6 RID: 1766
	public float speedModifier;

	// Token: 0x040006E7 RID: 1767
	public float lastGrindDirVertical;

	// Token: 0x040006E8 RID: 1768
	public float lastGrindDirHorizontal;

	// Token: 0x040006E9 RID: 1769
	private bool prevRightStickUpPressed;

	// Token: 0x040006EA RID: 1770
	private bool prevRightStickDownPressed;

	// Token: 0x040006EB RID: 1771
	private bool prevRightStickLeftPressed;

	// Token: 0x040006EC RID: 1772
	private bool prevRightStickRightPressed;
}
