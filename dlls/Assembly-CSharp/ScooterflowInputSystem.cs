using System;
using Rewired;
using UnityEngine;

// Token: 0x02000152 RID: 338
public class ScooterflowInputSystem : MonoBehaviour
{
	// Token: 0x0600055F RID: 1375 RVA: 0x00024F06 File Offset: 0x00023106
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x00024F20 File Offset: 0x00023120
	private void Update()
	{
		this.RightStickY = this.player.GetAxis("RightStickY");
		this.RightStickX = this.player.GetAxis("RightStickX");
		this.LeftStickY = this.player.GetAxis("LeftStickY");
		this.LeftStickX = this.player.GetAxis("LeftStickX");
		this.AnimationInput();
		if (this.player.GetButtonDown("Start"))
		{
			this.requiresInput.menuLogic.ToggleMenu();
		}
		if (this.requiresInput.simpleReplay.state != SimpleReplay.ReplayState.ReplayingPlaying && this.requiresInput.simpleReplay.state != SimpleReplay.ReplayState.ReplayingPaused)
		{
			if (this.player.GetButtonDown("Select"))
			{
				this.requiresInput.cameraBrain.ChangeCamera();
			}
			if (!this.requiresInput.menuLogic.pauseMenu)
			{
				this.player.GetButtonDown("Square");
				if (this.player.GetButtonDown("Triangle"))
				{
					this.requiresInput.characterStates.ChangeCharacterState();
				}
				if (this.player.GetButtonDown("D-PadDown") && this.requiresInput.teleportPlayer.references.loadscreenParent.childCount == 0)
				{
					this.requiresInput.teleportPlayer.TeleportToSpawnpoint();
				}
				if (this.player.GetButtonDown("D-PadUp") && this.requiresInput.scooterController.isGrounded && !this.requiresInput.ragdollControl.ragdollActive)
				{
					this.requiresInput.teleportPlayer.SetMarker();
				}
				if (this.player.GetButtonDown("L3"))
				{
					this.requiresInput.timeSpeed.SlowTime();
				}
				if (this.allowPauseTime && this.player.GetButtonDown("R3"))
				{
					this.requiresInput.timeSpeed.TogglePauseTime();
				}
			}
			if (this.player.GetButton("Circle") || this.player.GetButton("Cross"))
			{
				this.ResetManuals();
			}
			this.ManualInput();
		}
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x00025143 File Offset: 0x00023343
	public void ManualInput()
	{
		this.HandleManual();
		this.HandleNoseManual();
		this.HandleFootJam();
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x00025158 File Offset: 0x00023358
	private void AnimationInput()
	{
		this.requiresInput.animationTrigger.L1Active = this.player.GetButton("L1");
		this.requiresInput.animationTrigger.L2Active = this.player.GetButton("L2");
		this.requiresInput.animationTrigger.R1Active = this.player.GetButton("R1");
		this.requiresInput.animationTrigger.R2Active = this.player.GetButton("R2");
		this.requiresInput.animationTrigger.CircleActive = this.player.GetButton("Circle");
		if (!this.requiresInput.scooterController.revertSettings.RevertPushCancel && !this.requiresInput.lockRotation.isGrinding)
		{
			this.requiresInput.animationTrigger.CrossActive = this.player.GetButton("Cross");
			return;
		}
		this.requiresInput.animationTrigger.CrossActive = false;
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x00025260 File Offset: 0x00023460
	private void HandleManual()
	{
		if (this.RightStickY < -0.3f && this.RightStickY > -0.8f && !this.requiresInput.scooterController.FootJam && !this.requiresInput.scooterController.revertSettings.RevertActivated)
		{
			this.ManualTimeLeft -= Time.deltaTime;
		}
		if (this.ManualTimeLeft < this.manualInput.ManualDelay)
		{
			this.requiresInput.scooterController.Manual = true;
		}
		if (this.RightStickY > -0.1f)
		{
			this.ManualTimeLeft = this.ManualTime;
			this.requiresInput.scooterController.Manual = false;
		}
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x00025310 File Offset: 0x00023510
	private void HandleNoseManual()
	{
		if (this.RightStickY > 0.3f && this.RightStickY < 0.8f && !this.requiresInput.scooterController.FootJam && !this.requiresInput.scooterController.revertSettings.RevertActivated)
		{
			this.NoseManualTimeLeft -= Time.deltaTime;
		}
		if (this.NoseManualTimeLeft < this.manualInput.NoseManualDelay)
		{
			this.requiresInput.scooterController.NoseManual = true;
		}
		if (this.RightStickY < 0.1f)
		{
			this.NoseManualTimeLeft = this.NoseManualTime;
			this.requiresInput.scooterController.NoseManual = false;
		}
	}

	// Token: 0x06000565 RID: 1381 RVA: 0x000253C0 File Offset: 0x000235C0
	private void HandleFootJam()
	{
		if (this.RightStickX > 0.3f && this.RightStickX < 0.8f && this.RightStickY > -0.3f && !this.requiresInput.scooterController.NoseManual && !this.requiresInput.scooterController.Manual && !this.requiresInput.scooterController.revertSettings.RevertActivated && this.RightStickY > -0.2f && this.RightStickY < 0.2f)
		{
			this.FootJamTimeLeft -= Time.deltaTime;
		}
		if (this.FootJamTimeLeft < this.manualInput.FootJamDelay && this.requiresInput.scooterController.velocityMagnitudeSettings.previousVelocityMagnitude < this.requiresInput.scooterController.footJamSettings.MaxJamVel)
		{
			this.requiresInput.scooterController.FootJam = true;
		}
		if (this.RightStickX < 0.1f && this.RightStickY > -0.1f)
		{
			this.FootJamTimeLeft = this.FootJamTime;
			this.requiresInput.scooterController.FootJam = false;
		}
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x000254E8 File Offset: 0x000236E8
	private void ResetManuals()
	{
		if (this.requiresInput.scooterController.Manual)
		{
			this.ManualTimeLeft = this.ManualTime;
			this.requiresInput.scooterController.Manual = false;
		}
		if (this.requiresInput.scooterController.NoseManual)
		{
			this.NoseManualTimeLeft = this.NoseManualTime;
			this.requiresInput.scooterController.NoseManual = false;
		}
		if (this.requiresInput.scooterController.FootJam)
		{
			this.FootJamTimeLeft = this.FootJamTime;
			this.requiresInput.scooterController.FootJam = false;
		}
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x00025584 File Offset: 0x00023784
	public void TeleportResetManuals()
	{
		this.ManualTimeLeft = this.ManualTime;
		this.requiresInput.scooterController.Manual = false;
		this.NoseManualTimeLeft = this.NoseManualTime;
		this.requiresInput.scooterController.NoseManual = false;
		this.FootJamTimeLeft = this.FootJamTime;
		this.requiresInput.scooterController.FootJam = false;
	}

	// Token: 0x04000886 RID: 2182
	public bool allowPauseTime;

	// Token: 0x04000887 RID: 2183
	public RequiresInput requiresInput;

	// Token: 0x04000888 RID: 2184
	public ManualInput manualInput;

	// Token: 0x04000889 RID: 2185
	private int playerId;

	// Token: 0x0400088A RID: 2186
	private Player player;

	// Token: 0x0400088B RID: 2187
	public float RightStickY;

	// Token: 0x0400088C RID: 2188
	public float RightStickX;

	// Token: 0x0400088D RID: 2189
	public float LeftStickY;

	// Token: 0x0400088E RID: 2190
	public float LeftStickX;

	// Token: 0x0400088F RID: 2191
	private float ManualTime;

	// Token: 0x04000890 RID: 2192
	private float ManualTimeLeft;

	// Token: 0x04000891 RID: 2193
	private float NoseManualTime;

	// Token: 0x04000892 RID: 2194
	private float NoseManualTimeLeft;

	// Token: 0x04000893 RID: 2195
	private float FootJamTime;

	// Token: 0x04000894 RID: 2196
	private float FootJamTimeLeft;

	// Token: 0x04000895 RID: 2197
	private const float MANUAL_START_THRESHOLD = -0.3f;

	// Token: 0x04000896 RID: 2198
	private const float MANUAL_END_THRESHOLD = -0.8f;

	// Token: 0x04000897 RID: 2199
	private const float NOSEMANUAL_START_THRESHOLD = 0.3f;

	// Token: 0x04000898 RID: 2200
	private const float NOSEMANUAL_END_THRESHOLD = 0.8f;

	// Token: 0x04000899 RID: 2201
	private const float FOOTJAM_START_THRESHOLD = 0.3f;

	// Token: 0x0400089A RID: 2202
	private const float FOOTJAM_END_THRESHOLD = 0.8f;

	// Token: 0x0400089B RID: 2203
	private const float MANUAL_RESET_THRESHOLD = -0.1f;

	// Token: 0x0400089C RID: 2204
	private const float NOSEMANUAL_RESET_THRESHOLD = 0.1f;

	// Token: 0x0400089D RID: 2205
	private const float FOOTJAM_RESET_THRESHOLD = 0.1f;
}
