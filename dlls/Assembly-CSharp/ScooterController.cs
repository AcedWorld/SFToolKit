using System;
using System.Collections;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x0200019A RID: 410
public class ScooterController : MonoBehaviour
{
	// Token: 0x06000648 RID: 1608 RVA: 0x0002ED58 File Offset: 0x0002CF58
	private void Start()
	{
		this.playerRigidbody = base.GetComponent<Rigidbody>();
		this.cachedPushForce = this.referencedItems.pushingForce.m_Thrust;
		this.player = ReInput.players.GetPlayer(this.playerId);
		this.revertSettings.stiffnessCache = this.ScooterWheels.frontWheel.sidewaysFriction.stiffness;
		this.revertSettings.extremumSlipCache = this.ScooterWheels.frontWheel.sidewaysFriction.extremumSlip;
		this.revertSettings.extremumValueCache = this.ScooterWheels.frontWheel.sidewaysFriction.extremumValue;
		this.revertSettings.asymptoteSlipCache = this.ScooterWheels.frontWheel.sidewaysFriction.asymptoteSlip;
		this.revertSettings.asymptoteValueCache = this.ScooterWheels.frontWheel.sidewaysFriction.asymptoteValue;
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x0002EE4C File Offset: 0x0002D04C
	private void Update()
	{
		this.RevertInput();
		if (this.fakieTrigger != this.fakie)
		{
			this.FakieSteerSettings();
			this.fakieTrigger = this.fakie;
		}
		if (this.fakie)
		{
			this.tempSteerAngle = Mathf.Lerp(this.tempSteerAngle, -this.player.GetAxis("LeftStickX"), Time.deltaTime * this.scooterWheelSettings.steerDampen);
		}
		if (!this.fakie)
		{
			this.tempSteerAngle = Mathf.Lerp(this.tempSteerAngle, this.player.GetAxis("LeftStickX"), Time.deltaTime * this.scooterWheelSettings.steerDampen);
		}
		if (this.localVelocity.z < this.pushSettings.maxSpeed && this.localVelocity.z > -3f && this.player.GetButton("Cross") && this.isGrounded && !this.referencedItems.lockRotation.isGrinding && !this.revertSettings.RevertPushCancel && !this.referencedItems.lockRotation.isGrinding)
		{
			base.StartCoroutine(this.AddPushForce());
			this.pushSettings.AddPushForceCoroutining = true;
		}
		this.StopDrag();
		if (!this.referencedItems.ragdollControl.ragdollActive)
		{
			this.RotatePlayer();
		}
		this.AnimationFloats();
		if (!this.isGrounded && this.FootJam)
		{
			this.footJamSettings.previousYRotation = base.transform.localEulerAngles.y;
		}
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x0002EFD4 File Offset: 0x0002D1D4
	private void OnDrawGizmos()
	{
		if (this.centreOfMassSettings.debug && this.playerRigidbody != null)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(this.playerRigidbody.transform.TransformPoint(this.playerRigidbody.centerOfMass), 0.05f);
		}
	}

	// Token: 0x0600064B RID: 1611 RVA: 0x0002F02B File Offset: 0x0002D22B
	private void StopDrag()
	{
		if (this.stopTrigger != this.player.GetButton("Circle"))
		{
			this.SetDrag();
			this.stopTrigger = this.player.GetButton("Circle");
		}
	}

	// Token: 0x0600064C RID: 1612 RVA: 0x0002F064 File Offset: 0x0002D264
	private void SetDrag()
	{
		if (this.player.GetButton("Circle"))
		{
			if (this.isGrounded)
			{
				this.playerRigidbody.drag = this.scooterWheelSettings.stopDrag;
				return;
			}
		}
		else
		{
			this.playerRigidbody.drag = 0f;
		}
	}

	// Token: 0x0600064D RID: 1613 RVA: 0x0002F0B4 File Offset: 0x0002D2B4
	private void FixedUpdate()
	{
		this.CheckScooterGroundedState();
		this.CheckFakie();
		this.WheelControl();
		this.MainRaycast();
		this.GetGroundInformation();
		this.CalculateForwardDirection();
		this.CheckFallMagnitude();
		this.CheckVelocityMagnitude();
		this.CheckFootJam();
		this.RevertControl();
		this.CentreOfMass();
		this.SetMaxVelocity();
		if (this.pushSettings.pushingForce && this.pushSettings.AddPushForceCoroutining)
		{
			this.playerRigidbody.AddForce(base.transform.forward * -this.pushSettings.initialPushForce);
		}
		if (!this.referencedItems.ragdollControl.ragdollActive)
		{
			this.FlipPlayer();
		}
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x0002F164 File Offset: 0x0002D364
	private void SetMaxVelocity()
	{
		if (this.playerRigidbody.velocity.magnitude > this.maxVelocity)
		{
			this.playerRigidbody.velocity = this.playerRigidbody.velocity.normalized * this.maxVelocity;
		}
	}

	// Token: 0x0600064F RID: 1615 RVA: 0x0002F1B8 File Offset: 0x0002D3B8
	private void CalculateForwardDirection()
	{
		this.information.forwardDirection = this.playerRigidbody.velocity.normalized;
	}

	// Token: 0x06000650 RID: 1616 RVA: 0x0002F1E4 File Offset: 0x0002D3E4
	private void MainRaycast()
	{
		this.mainRaycast = default(RaycastHit);
		if (Physics.Raycast(base.transform.position + this.groundInformation.raycastOffset, base.transform.TransformDirection(Vector3.down), out this.mainRaycast, float.PositiveInfinity, this.groundInformation.layerMask) && this.groundInformation.debug)
		{
			Debug.DrawRay(base.transform.position + this.groundInformation.raycastOffset, base.transform.TransformDirection(Vector3.down) * this.mainRaycast.distance, Color.yellow);
		}
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x0002F29C File Offset: 0x0002D49C
	private void GetGroundInformation()
	{
		if (this.groundInformation.transformX < 0f && this.groundInformation.groundAngleX != 0f)
		{
			this.downhill = true;
			if (this.FootJam)
			{
				this.groundInformation.groundAngleX = Vector3.Angle(this.referencedItems.playerBalance.frontHit.normal, Vector3.up);
			}
			if (!this.FootJam)
			{
				this.groundInformation.groundAngleX = Vector3.Angle(this.referencedItems.playerBalance.rearHit.normal, Vector3.up);
				return;
			}
		}
		else
		{
			this.downhill = false;
			if (this.FootJam)
			{
				this.groundInformation.groundAngleX = Vector3.Angle(this.referencedItems.playerBalance.frontHit.normal, Vector3.up);
			}
			if (!this.FootJam)
			{
				this.groundInformation.groundAngleX = Vector3.Angle(this.referencedItems.playerBalance.rearHit.normal, Vector3.up);
			}
		}
	}

	// Token: 0x06000652 RID: 1618 RVA: 0x0002F3AC File Offset: 0x0002D5AC
	private void AnimationFloats()
	{
		if (base.transform.localEulerAngles.x < 180f)
		{
			this.groundInformation.transformX = base.transform.localEulerAngles.x;
		}
		if (base.transform.localEulerAngles.x > 180f)
		{
			float num = 360f - base.transform.localEulerAngles.x;
			this.groundInformation.transformX = -num;
		}
		this.groundInformation.AnimationX = this.groundInformation.transformX / this.groundInformation.xDivider;
		if (base.transform.localEulerAngles.z < 180f)
		{
			this.groundInformation.transformZ = base.transform.localEulerAngles.z;
		}
		if (base.transform.localEulerAngles.z > 180f)
		{
			float num2 = 360f - base.transform.localEulerAngles.z;
			this.groundInformation.transformZ = -num2;
		}
		this.groundInformation.AnimationZ = this.groundInformation.transformZ / this.groundInformation.zDivider;
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x0002F4D8 File Offset: 0x0002D6D8
	public void CheckScooterGroundedState()
	{
		if (this.groundCheckTrigger != this.isGrounded)
		{
			this.GroundStateChange();
			this.groundCheckTrigger = this.isGrounded;
		}
		if (this.ScooterWheels.frontWheel.isGrounded || this.ScooterWheels.rearWheel.isGrounded || this.referencedItems.lockRotation.isGrinding || this.referencedItems.deckCollision.deckCollision)
		{
			this.isGrounded = true;
		}
		else if (!this.ScooterWheels.frontWheel.isGrounded && !this.ScooterWheels.rearWheel.isGrounded && !this.referencedItems.lockRotation.isGrinding && !this.referencedItems.deckCollision.deckCollision)
		{
			this.isGrounded = false;
		}
		this.frontWheelGrounded = this.ScooterWheels.frontWheel.isGrounded;
		this.rearWheelGrounded = this.ScooterWheels.rearWheel.isGrounded;
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x0002F5D1 File Offset: 0x0002D7D1
	public void GroundStateChange()
	{
		if (this.isGrounded)
		{
			this.OnPlayerLand();
		}
		if (!this.isGrounded)
		{
			this.OnPlayerJump();
		}
	}

	// Token: 0x06000655 RID: 1621 RVA: 0x0002F5F0 File Offset: 0x0002D7F0
	public void RailChecker()
	{
		this.StickLanding();
		Collider[] array = Physics.OverlapSphere(base.transform.position, 0.5f);
		bool flag = false;
		Collider[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			if (array2[i].CompareTag("Rail"))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			this.CheckAlignment();
		}
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x0002F648 File Offset: 0x0002D848
	private void StickLanding()
	{
		if (!this.playerRigidbody.isKinematic && this.UseStickLanding)
		{
			Vector3 normalized = (this.referencedItems.playerBalance.frontHit.normal + this.referencedItems.playerBalance.rearHit.normal).normalized;
			Vector3 a = Vector3.ProjectOnPlane(this.playerRigidbody.velocity.normalized, normalized);
			this.playerRigidbody.velocity = a * this.playerRigidbody.velocity.magnitude;
		}
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x0002F6E0 File Offset: 0x0002D8E0
	public void OnPlayerLand()
	{
		this.CheckFootJamSpun();
		this.RailChecker();
		if (this.onPlayerLand != null)
		{
			this.onPlayerLand.Invoke();
		}
		this.SetDrag();
		this.referencedItems.landCorrection.landAssist = true;
		this.referencedItems.landCorrection.OnLand();
		this.landIntensity = this.velocityMagnitudeSettings.previousVelocityMagnitude + this.velocityMagnitudeSettings.previousFallMagnitude;
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x0002F750 File Offset: 0x0002D950
	public void OnPlayerJump()
	{
		float num = 0.5f;
		float num2 = 7f;
		float num3 = 6f;
		float num4 = 2f;
		float num5 = Mathf.Clamp(this.referencedItems.trajectoryPrediction.relativeHighestPoint, num, num2);
		this.referencedItems.landCorrection.settings.tempSpeedBeforeInput = num3 - (num5 - num) / (num2 - num) * (num3 - num4);
		this.referencedItems.landCorrection.UpdateLandRotation();
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x0002F7C4 File Offset: 0x0002D9C4
	public void CheckFootJamSpun()
	{
		float y = base.transform.localEulerAngles.y;
		float num = Mathf.Abs(Mathf.DeltaAngle(this.footJamSettings.previousYRotation, y));
		if (num > 3f || num < -3f)
		{
			this.footJamSettings.FootJamSpun = true;
			return;
		}
		this.footJamSettings.FootJamSpun = false;
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x0002F824 File Offset: 0x0002DA24
	public void CheckFakie()
	{
		this.localVelocity = base.transform.InverseTransformDirection(this.playerRigidbody.velocity);
		float z = this.localVelocity.z;
		if (z > this.fakieSettings.fakieThreshold)
		{
			this.fakie = true;
			return;
		}
		if (z <= this.fakieSettings.fakieThreshold && z >= -this.fakieSettings.fakieThreshold)
		{
			this.fakie = false;
			return;
		}
		this.fakie = false;
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x0002F89B File Offset: 0x0002DA9B
	public void FakieSteerSettings()
	{
		if (this.fakie)
		{
			this.scooterWheelSettings.maxSteeringAngle = this.scooterWheelSettings.fakieSteerAngle;
		}
		if (!this.fakie)
		{
			this.scooterWheelSettings.maxSteeringAngle = 20f;
		}
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x0002F8D4 File Offset: 0x0002DAD4
	private void WheelControl()
	{
		if ((!this.revertSettings.RevertActivated || !this.revertSettings.RevertPushCancel) && !this.referencedItems.lockRotation.isGrinding)
		{
			this.wheelmotor = this.scooterWheelSettings.maxMotorTorque * this.player.GetAxis("Push");
		}
		if (this.revertSettings.RevertActivated || this.revertSettings.RevertPushCancel || this.referencedItems.lockRotation.isGrinding)
		{
			this.wheelmotor = 0f;
		}
		this.steering = this.scooterWheelSettings.maxSteeringAngle * this.tempSteerAngle;
		if (this.localVelocity.z < 1f && this.localVelocity.z > -10f)
		{
			this.motorSpeed = this.wheelmotor;
			this.referencedItems.pushingForce.m_Thrust = this.cachedPushForce;
		}
		if (this.localVelocity.z > 1f)
		{
			this.motorSpeed = 0f;
		}
		if (this.localVelocity.z < -10f)
		{
			this.motorSpeed = 0f;
			this.referencedItems.pushingForce.m_Thrust = 0f;
		}
		this.ScooterWheels.frontWheel.steerAngle = this.steering;
		this.ScooterWheels.frontWheel.motorTorque = this.motorSpeed;
		this.ScooterWheels.rearWheel.motorTorque = this.motorSpeed;
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x0002FA55 File Offset: 0x0002DC55
	public IEnumerator AddPushForce()
	{
		yield return new WaitForSecondsRealtime(this.pushSettings.delay);
		this.pushSettings.pushingForce = true;
		yield return new WaitForSecondsRealtime(this.pushSettings.duration);
		this.pushSettings.pushingForce = false;
		this.pushSettings.AddPushForceCoroutining = false;
		yield break;
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x0002FA64 File Offset: 0x0002DC64
	private void RotatePlayer()
	{
		if (!this.referencedItems.grindSystem.isGrinding)
		{
			this.rotationSettings.flip = this.player.GetAxis("LeftStickY") * -this.rotationSettings.flipSpeed;
			if (this.referencedItems.landLocation.correctFlip)
			{
				this.rotationSettings.spinSpeedAfter = Mathf.Lerp(this.rotationSettings.spinSpeedAfter, this.rotationSettings.fastSpin, Time.deltaTime * this.rotationSettings.normalToFastDampen);
			}
			if (!this.referencedItems.landLocation.correctFlip)
			{
				this.rotationSettings.spinSpeedAfter = this.rotationSettings.spinSpeed;
			}
			if (this.rotationSettings.disableLandCorrectionOnFlip && ((this.rotationSettings.flip < -this.rotationSettings.flipSpeed / 2f && !this.isGrounded) || (this.rotationSettings.flip > this.rotationSettings.flipSpeed / 2f && !this.isGrounded)))
			{
				this.referencedItems.landLocation.landAssist = false;
			}
			if (!this.isGrounded)
			{
				float num = 0.7f;
				float num2 = 6f;
				float num3 = 1.5f;
				float num4 = 0.7f;
				float num5 = Mathf.Clamp(this.referencedItems.trajectoryPrediction.relativeHighestPoint, num, num2);
				if (!this.flipLock)
				{
					if (this.groundInformation.groundAngleX < 40f)
					{
						this.speedModifier = num3 - (num5 - num) / (num2 - num) * (num3 - num4);
						this.flipLock = true;
					}
					else
					{
						this.speedModifier = 1f;
						this.flipLock = true;
					}
				}
				this.rotationSettings.hinput = Mathf.Lerp(this.rotationSettings.hinput, this.player.GetAxis("LeftStickX"), Time.deltaTime * this.rotationSettings.spinDampen);
				Quaternion rhs = Quaternion.Euler(new Vector3(0f, this.rotationSettings.hinput * this.rotationSettings.spinSpeedAfter, 0f) * this.speedModifier * Time.deltaTime);
				this.playerRigidbody.MoveRotation(this.playerRigidbody.rotation * rhs);
			}
			else
			{
				this.flipLock = false;
			}
			if (this.isGrounded)
			{
				this.rotationSettings.hinput = 0f;
			}
			if (this.referencedItems.landLocation.correctFlip)
			{
				this.rotationSettings.finalFlip = 0f;
			}
			if (!this.referencedItems.landLocation.correctFlip)
			{
				this.rotationSettings.finalFlip = this.rotationSettings.flip;
			}
		}
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x0002FD15 File Offset: 0x0002DF15
	private void FlipPlayer()
	{
		if (!this.isGrounded && !this.referencedItems.grindSystem.isGrinding)
		{
			this.playerRigidbody.AddRelativeTorque(this.rotationSettings.finalFlip, 0f, 0f, ForceMode.Acceleration);
		}
	}

	// Token: 0x06000660 RID: 1632 RVA: 0x0002FD52 File Offset: 0x0002DF52
	private void OnCollisionStay(Collision collision)
	{
		this.ScooterGrounded = true;
	}

	// Token: 0x06000661 RID: 1633 RVA: 0x0002FD5B File Offset: 0x0002DF5B
	private void OnCollisionExit(Collision collision)
	{
		this.ScooterGrounded = false;
	}

	// Token: 0x06000662 RID: 1634 RVA: 0x0002FD64 File Offset: 0x0002DF64
	public void CentreOfMass()
	{
		if (this.referencedItems.ragdollControl.ragdollActive)
		{
			this.currentState = COMStates.Ragdoll;
			this.playerRigidbody.automaticCenterOfMass = true;
			this.playerRigidbody.angularDrag = 0f;
			return;
		}
		if (!this.isGrounded)
		{
			this.currentState = COMStates.InAir;
			this.centreOfMassSettings.CentreOfMass.y = this.centreOfMassSettings.InAir.y;
			this.playerRigidbody.centerOfMass = this.centreOfMassSettings.CentreOfMass;
			this.playerRigidbody.angularDrag = this.rigidbodySettings.inAirAngularDrag;
			return;
		}
		this.currentState = COMStates.Normal;
		this.playerRigidbody.centerOfMass = this.centreOfMassSettings.CentreOfMass;
		this.playerRigidbody.angularDrag = this.rigidbodySettings.groundedAngularDrag;
		if (!this.revertSettings.RevertActivated)
		{
			this.centreOfMassSettings.CentreOfMass.y = this.centreOfMassSettings.Normal.y;
		}
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x0002FE64 File Offset: 0x0002E064
	public void CheckFootJam()
	{
		if (this.FootJam)
		{
			this.footJamSettings.JamTime += Time.deltaTime;
			this.ScooterWheels.frontWheel.wheelDampingRate = this.footJamSettings.WheelDamp;
			this.CheckFootJamSpin();
			this.CheckFootJamCrash();
			if (!this.isGrounded)
			{
				this.playerRigidbody.velocity = Vector3.Lerp(this.playerRigidbody.velocity, new Vector3(0f, this.playerRigidbody.velocity.y, 0f), Time.deltaTime * 1f);
			}
		}
		if (this.FootJam)
		{
			if ((this.groundInformation.groundAngleX > this.footJamSettings.MaxJamAngle && this.isGrounded) || (this.FootJam && this.velocityMagnitudeSettings.previousFallMagnitude > this.footJamSettings.MaxJamFall && this.isGrounded))
			{
				this.referencedItems.ragdollControl.ActivateRagdoll();
			}
			if (this.referencedItems.lockRotation.isGrinding)
			{
				this.referencedItems.ragdollControl.ActivateRagdoll();
			}
		}
		if (!this.FootJam)
		{
			this.footJamSettings.JamTime = 0f;
			this.ScooterWheels.frontWheel.wheelDampingRate = this.footJamSettings.DefaultWheelDamp;
			this.footJamSettings.JamisRotating = false;
			this.footJamSettings.FootJamSpun = false;
		}
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x0002FFD4 File Offset: 0x0002E1D4
	public void CheckFootJamSpin()
	{
		if (this.velocityMagnitudeSettings.AngularVelocityMagnitude > 1f || this.velocityMagnitudeSettings.AngularVelocityMagnitude < -1f)
		{
			this.footJamSettings.JamisRotating = true;
			return;
		}
		this.footJamSettings.JamisRotating = false;
	}

	// Token: 0x06000665 RID: 1637 RVA: 0x00030014 File Offset: 0x0002E214
	public void CheckFootJamCrash()
	{
		if ((this.footJamSettings.JamTime > 4f && !this.footJamSettings.JamisRotating) || (this.footJamSettings.JamTime > 6f && this.footJamSettings.JamisRotating))
		{
			this.referencedItems.ragdollControl.ActivateRagdoll();
		}
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x00030070 File Offset: 0x0002E270
	public void CheckVelocityMagnitude()
	{
		this.velocityMagnitudeSettings.AngularVelocityMagnitude = Vector3.Dot(this.playerRigidbody.angularVelocity, base.transform.up);
		this.velocityMagnitudeSettings.VelocityMagnitudeTime += Time.deltaTime;
		this.velocityMagnitudeSettings.currentVelocityMagnitude = new Vector3(this.playerRigidbody.velocity.x, 0f, this.playerRigidbody.velocity.z).magnitude;
		if (this.velocityMagnitudeSettings.VelocityMagnitudeTime >= this.velocityMagnitudeSettings.VelocityMagnitudeDelay)
		{
			this.velocityMagnitudeSettings.previousVelocityMagnitude = this.velocityMagnitudeSettings.currentVelocityMagnitude;
			this.velocityMagnitudeSettings.VelocityMagnitudeTime = 0f;
		}
	}

	// Token: 0x06000667 RID: 1639 RVA: 0x00030138 File Offset: 0x0002E338
	public void CheckFallMagnitude()
	{
		this.velocityMagnitudeSettings.VelocityMagnitudeTime += Time.deltaTime;
		this.velocityMagnitudeSettings.currentFallMagnitude = new Vector3(0f, this.playerRigidbody.velocity.y, 0f).magnitude;
		if (this.velocityMagnitudeSettings.VelocityMagnitudeTime >= this.velocityMagnitudeSettings.VelocityMagnitudeDelay)
		{
			this.velocityMagnitudeSettings.previousFallMagnitude = this.velocityMagnitudeSettings.currentFallMagnitude;
			this.velocityMagnitudeSettings.VelocityMagnitudeTime = 0f;
		}
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x000301CC File Offset: 0x0002E3CC
	public void CheckAlignment()
	{
		float num = Vector3.Angle(this.playerRigidbody.velocity.normalized, base.transform.forward);
		if (!this.referencedItems.trajectoryPrediction.IsGroingToGrind)
		{
			if (num > this.crashLandSettings.FrontInsideAlignedAngle && num <= this.crashLandSettings.FrontOutsideAlignedAngle && this.velocityMagnitudeSettings.previousVelocityMagnitude > this.crashLandSettings.AlignedLandingVelThreshold)
			{
				this.referencedItems.ragdollControl.ActivateRagdoll();
			}
			else if (num > this.crashLandSettings.BackInsideAlignedAngle && num <= this.crashLandSettings.BackOutsideAlignedAngle && this.velocityMagnitudeSettings.previousVelocityMagnitude > this.crashLandSettings.AlignedLandingVelThreshold)
			{
				this.referencedItems.ragdollControl.ActivateRagdoll();
			}
		}
		if (this.groundInformation.groundAngleX < this.crashLandSettings.FallFlatAngle && this.velocityMagnitudeSettings.previousFallMagnitude > this.crashLandSettings.FallFlatVelThreshold)
		{
			this.referencedItems.ragdollControl.ActivateRagdoll();
		}
	}

	// Token: 0x06000669 RID: 1641 RVA: 0x000302DC File Offset: 0x0002E4DC
	private void RevertInput()
	{
		if (this.isGrounded && !this.referencedItems.lockRotation.isGrinding && this.player.GetButtonDown("Cross") && this.fakie && !this.NoseManual && !this.Manual && !this.FootJam && this.localVelocity.z > 1f)
		{
			if ((double)this.player.GetAxis("LeftStickX") > 0.2 && this.velocityMagnitudeSettings.currentVelocityMagnitude > 0.25f && !this.revertSettings.RevertSetup && !this.stopTrigger)
			{
				this.revertSettings.RevertSetup = true;
				this.revertSettings.RevertFakieCache = this.fakie;
				this.revertSettings.RevertActivated = true;
				this.revertSettings.RevertPushCancel = true;
				this.revertSettings.OriginalDirection = base.transform.rotation.eulerAngles.y;
				this.revertSettings.RevertInverted = false;
				this.revertSettings.RevertRight = true;
			}
			if ((double)this.player.GetAxis("LeftStickX") < 0.2 && this.velocityMagnitudeSettings.currentVelocityMagnitude > 0.25f && !this.revertSettings.RevertSetup && !this.stopTrigger)
			{
				this.revertSettings.RevertSetup = true;
				this.revertSettings.RevertFakieCache = this.fakie;
				this.revertSettings.RevertActivated = true;
				this.revertSettings.RevertPushCancel = true;
				this.revertSettings.OriginalDirection = base.transform.rotation.eulerAngles.y;
				this.revertSettings.RevertInverted = true;
				this.revertSettings.RevertLeft = true;
			}
		}
		if (this.player.GetButtonUp("Cross") && this.revertSettings.RevertPushCancel)
		{
			this.revertSettings.RevertPushCancel = false;
		}
	}

	// Token: 0x0600066A RID: 1642 RVA: 0x000304FC File Offset: 0x0002E6FC
	private void RevertControl()
	{
		if (this.isGrounded && !this.referencedItems.lockRotation.isGrinding && this.revertSettings.RevertActivated)
		{
			this.revertSettings.CurrentRotation = base.transform.rotation.eulerAngles.y;
			this.revertSettings.angleDifference = Mathf.Abs(Mathf.DeltaAngle(this.revertSettings.OriginalDirection, this.revertSettings.CurrentRotation));
			if (this.groundInformation.groundAngleX > this.revertSettings.CrashAngle)
			{
				this.revertSettings.AngleCrashTimer += Time.deltaTime;
			}
			if (this.revertSettings.AngleCrashTimer > this.revertSettings.CrashTime)
			{
				this.referencedItems.ragdollControl.ActivateRagdoll();
				this.revertSettings.AngleCrashTimer = 0f;
				this.revertSettings.RevertActivated = false;
				this.revertSettings.RevertInverted = false;
				this.revertSettings.RevertFakieCache = false;
				this.revertSettings.RevertLeft = false;
				this.revertSettings.RevertRight = false;
				this.revertSettings.RevertSetup = false;
			}
			if (this.revertSettings.angleDifference <= 90f)
			{
				this.revertSettings.torqueStrength = Mathf.Lerp(this.revertSettings.torqueStart, this.revertSettings.torqueEnd, this.revertSettings.angleDifference / 90f);
			}
			if (this.revertSettings.angleDifference >= 90f)
			{
				this.revertSettings.torqueStrength = Mathf.Lerp(this.revertSettings.torqueEnd, this.revertSettings.torqueStart, (this.revertSettings.angleDifference - 90f) / 90f);
			}
			if (!this.Manual && !this.NoseManual)
			{
				if (this.revertSettings.RevertFakieCache && !this.revertSettings.RevertInverted)
				{
					this.playerRigidbody.AddTorque(base.transform.up * this.revertSettings.RevertTorque * this.revertSettings.torqueStrength);
				}
				else if (this.revertSettings.RevertFakieCache && this.revertSettings.RevertInverted)
				{
					this.playerRigidbody.AddTorque(base.transform.up * -this.revertSettings.RevertTorque * this.revertSettings.torqueStrength);
				}
			}
			if (!this.Manual && !this.NoseManual)
			{
				if (this.revertSettings.angleDifference < 90f)
				{
					float t = this.revertSettings.angleDifference / 90f;
					this.centreOfMassSettings.CentreOfMass.z = Mathf.Lerp(0f, this.revertSettings.RevertZ, t);
					this.centreOfMassSettings.CentreOfMass.y = Mathf.Lerp(0f, this.revertSettings.RevertY, t);
				}
				if (this.revertSettings.angleDifference > 90f)
				{
					float t2 = 1f - (this.revertSettings.angleDifference - 90f) / 90f;
					this.centreOfMassSettings.CentreOfMass.z = Mathf.Lerp(0f, this.revertSettings.RevertZ, t2);
					this.centreOfMassSettings.CentreOfMass.y = Mathf.Lerp(0f, this.revertSettings.RevertY, t2);
				}
			}
			if (this.revertSettings.angleDifference < 90f)
			{
				float t3 = this.revertSettings.angleDifference / 90f;
				WheelFrictionCurve sidewaysFriction = this.ScooterWheels.frontWheel.sidewaysFriction;
				sidewaysFriction.stiffness = Mathf.Lerp(this.revertSettings.stiffnessCache, 0f, t3);
				sidewaysFriction.extremumSlip = Mathf.Lerp(this.revertSettings.extremumSlipCache, 1f, t3);
				sidewaysFriction.extremumValue = Mathf.Lerp(this.revertSettings.extremumValueCache, 0f, t3);
				sidewaysFriction.asymptoteSlip = Mathf.Lerp(this.revertSettings.asymptoteSlipCache, 1f, t3);
				sidewaysFriction.asymptoteValue = Mathf.Lerp(this.revertSettings.asymptoteValueCache, 0f, t3);
				this.ScooterWheels.frontWheel.sidewaysFriction = sidewaysFriction;
				WheelFrictionCurve sidewaysFriction2 = this.ScooterWheels.rearWheel.sidewaysFriction;
				sidewaysFriction2.stiffness = Mathf.Lerp(this.revertSettings.stiffnessCache, 0f, t3);
				sidewaysFriction2.extremumSlip = Mathf.Lerp(this.revertSettings.extremumSlipCache, 1f, t3);
				sidewaysFriction2.extremumValue = Mathf.Lerp(this.revertSettings.extremumValueCache, 0f, t3);
				sidewaysFriction2.asymptoteSlip = Mathf.Lerp(this.revertSettings.asymptoteSlipCache, 1f, t3);
				sidewaysFriction2.asymptoteValue = Mathf.Lerp(this.revertSettings.asymptoteValueCache, 0f, t3);
				this.ScooterWheels.rearWheel.sidewaysFriction = sidewaysFriction2;
			}
			if (this.revertSettings.angleDifference > 90f)
			{
				float t4 = 1f - (this.revertSettings.angleDifference - 90f) / 90f;
				WheelFrictionCurve sidewaysFriction3 = this.ScooterWheels.frontWheel.sidewaysFriction;
				sidewaysFriction3.stiffness = Mathf.Lerp(0f, this.revertSettings.stiffnessCache, t4);
				sidewaysFriction3.extremumSlip = Mathf.Lerp(1f, this.revertSettings.extremumSlipCache, t4);
				sidewaysFriction3.extremumValue = Mathf.Lerp(0f, this.revertSettings.extremumValueCache, t4);
				sidewaysFriction3.asymptoteSlip = Mathf.Lerp(1f, this.revertSettings.asymptoteSlipCache, t4);
				sidewaysFriction3.asymptoteValue = Mathf.Lerp(0f, this.revertSettings.asymptoteValueCache, t4);
				this.ScooterWheels.frontWheel.sidewaysFriction = sidewaysFriction3;
				WheelFrictionCurve sidewaysFriction4 = this.ScooterWheels.rearWheel.sidewaysFriction;
				sidewaysFriction4.stiffness = Mathf.Lerp(0f, this.revertSettings.stiffnessCache, t4);
				sidewaysFriction4.extremumSlip = Mathf.Lerp(1f, this.revertSettings.extremumSlipCache, t4);
				sidewaysFriction4.extremumValue = Mathf.Lerp(0f, this.revertSettings.extremumValueCache, t4);
				sidewaysFriction4.asymptoteSlip = Mathf.Lerp(1f, this.revertSettings.asymptoteSlipCache, t4);
				sidewaysFriction4.asymptoteValue = Mathf.Lerp(0f, this.revertSettings.asymptoteValueCache, t4);
				this.ScooterWheels.rearWheel.sidewaysFriction = sidewaysFriction4;
			}
		}
		if ((this.revertSettings.RevertActivated && !this.isGrounded) || (this.revertSettings.RevertActivated && Mathf.Abs(this.revertSettings.angleDifference - 180f) < 5f) || (this.revertSettings.RevertActivated && this.playerRigidbody.isKinematic))
		{
			this.ResetReverts();
		}
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x00030C24 File Offset: 0x0002EE24
	private void ResetReverts()
	{
		this.revertSettings.AngleCrashTimer = 0f;
		this.revertSettings.RevertActivated = false;
		this.revertSettings.RevertInverted = false;
		this.revertSettings.RevertFakieCache = false;
		this.revertSettings.RevertLeft = false;
		this.revertSettings.RevertRight = false;
		this.revertSettings.RevertSetup = false;
	}

	// Token: 0x0600066C RID: 1644 RVA: 0x00030C8C File Offset: 0x0002EE8C
	public void ResetScooterController()
	{
		this.referencedItems.pumpMechanic.ClearPump();
		this.wheelmotor = 0f;
		this.tempSteerAngle = 0f;
		this.steering = 0f;
		this.localVelocity = Vector3.zero;
		this.cachedPushForce = 0f;
		this.velocityMagnitudeSettings.AngularVelocityMagnitude = 0f;
		this.velocityMagnitudeSettings.currentVelocityMagnitude = 0f;
		this.velocityMagnitudeSettings.previousVelocityMagnitude = 0f;
		this.velocityMagnitudeSettings.currentFallMagnitude = 0f;
		this.velocityMagnitudeSettings.previousFallMagnitude = 0f;
		this.velocityMagnitudeSettings.VelocityMagnitudeTime = 0f;
		this.groundInformation.groundAngleX = 0f;
		this.groundInformation.transformX = 0f;
		this.groundInformation.transformZ = 0f;
		this.groundInformation.AnimationX = 0f;
		this.groundInformation.AnimationZ = 0f;
		this.rotationSettings.flip = 0f;
		this.rotationSettings.finalFlip = 0f;
		this.rotationSettings.hinput = 0f;
		this.rotationSettings.spinSpeedAfter = 0f;
		this.motorSpeed = 0f;
		this.ResetReverts();
	}

	// Token: 0x0600066D RID: 1645 RVA: 0x00030DE4 File Offset: 0x0002EFE4
	public void GrindClear()
	{
		this.wheelmotor = 0f;
		this.tempSteerAngle = 0f;
		this.steering = 0f;
		this.cachedPushForce = 0f;
		this.velocityMagnitudeSettings.AngularVelocityMagnitude = 0f;
		this.velocityMagnitudeSettings.currentVelocityMagnitude = 0f;
		this.velocityMagnitudeSettings.previousVelocityMagnitude = 0f;
		this.velocityMagnitudeSettings.currentFallMagnitude = 0f;
		this.velocityMagnitudeSettings.previousFallMagnitude = 0f;
		this.velocityMagnitudeSettings.VelocityMagnitudeTime = 0f;
		this.groundInformation.groundAngleX = 0f;
		this.groundInformation.transformX = 0f;
		this.groundInformation.transformZ = 0f;
		this.groundInformation.AnimationX = 0f;
		this.groundInformation.AnimationZ = 0f;
		this.rotationSettings.flip = 0f;
		this.rotationSettings.finalFlip = 0f;
		this.rotationSettings.hinput = 0f;
		this.rotationSettings.spinSpeedAfter = 0f;
		this.motorSpeed = 0f;
		this.ResetReverts();
	}

	// Token: 0x04000B06 RID: 2822
	public bool isGrounded;

	// Token: 0x04000B07 RID: 2823
	public bool frontWheelGrounded;

	// Token: 0x04000B08 RID: 2824
	public bool rearWheelGrounded;

	// Token: 0x04000B09 RID: 2825
	public bool ScooterGrounded;

	// Token: 0x04000B0A RID: 2826
	public bool fakie;

	// Token: 0x04000B0B RID: 2827
	public bool Manual;

	// Token: 0x04000B0C RID: 2828
	public bool NoseManual;

	// Token: 0x04000B0D RID: 2829
	public bool downhill;

	// Token: 0x04000B0E RID: 2830
	public bool FootJam;

	// Token: 0x04000B0F RID: 2831
	public bool UseStickLanding;

	// Token: 0x04000B10 RID: 2832
	public RaycastHit mainRaycast;

	// Token: 0x04000B11 RID: 2833
	public ScooterControllerDependencies referencedItems;

	// Token: 0x04000B12 RID: 2834
	[Header("General Information")]
	public GeneralInformation information;

	// Token: 0x04000B13 RID: 2835
	[Header("Rigidbody")]
	public PlayerRigidbodySettings rigidbodySettings;

	// Token: 0x04000B14 RID: 2836
	[Header("Centre Of Mass")]
	public COMStates currentState;

	// Token: 0x04000B15 RID: 2837
	public CentreOfMassSettings centreOfMassSettings;

	// Token: 0x04000B16 RID: 2838
	[Header("Scooter Wheels")]
	public ScooterWheels ScooterWheels;

	// Token: 0x04000B17 RID: 2839
	public ScooterWheelSettings scooterWheelSettings;

	// Token: 0x04000B18 RID: 2840
	[Header("Push Settings")]
	public PushSettings pushSettings;

	// Token: 0x04000B19 RID: 2841
	[Header("Rotation Settings")]
	public RotationSettings rotationSettings;

	// Token: 0x04000B1A RID: 2842
	[Header("Fakie Settings")]
	public FakieSettings fakieSettings;

	// Token: 0x04000B1B RID: 2843
	[Header("Ground Information")]
	public GroundInformation groundInformation;

	// Token: 0x04000B1C RID: 2844
	[Header("Foot Jam Settings")]
	public FootJamSettings footJamSettings;

	// Token: 0x04000B1D RID: 2845
	[Header("Velocity Magnitude Settings")]
	public VelocityMagnitudeSettings velocityMagnitudeSettings;

	// Token: 0x04000B1E RID: 2846
	[Header("Crash Land Settings")]
	public CrashLandSettings crashLandSettings;

	// Token: 0x04000B1F RID: 2847
	[Header("Revert Settings")]
	public RevertSettings revertSettings;

	// Token: 0x04000B20 RID: 2848
	private int playerId;

	// Token: 0x04000B21 RID: 2849
	private Player player;

	// Token: 0x04000B22 RID: 2850
	private float cachedPushForce;

	// Token: 0x04000B23 RID: 2851
	private float motorSpeed;

	// Token: 0x04000B24 RID: 2852
	private bool fakieTrigger;

	// Token: 0x04000B25 RID: 2853
	private bool stopTrigger;

	// Token: 0x04000B26 RID: 2854
	private float tempSteerAngle;

	// Token: 0x04000B27 RID: 2855
	private float steering;

	// Token: 0x04000B28 RID: 2856
	private float maxVelocity = 25f;

	// Token: 0x04000B29 RID: 2857
	public bool hasCheckedRails;

	// Token: 0x04000B2A RID: 2858
	public Vector3 localVelocity;

	// Token: 0x04000B2B RID: 2859
	private Rigidbody playerRigidbody;

	// Token: 0x04000B2C RID: 2860
	private bool groundCheckTrigger;

	// Token: 0x04000B2D RID: 2861
	public float wheelmotor;

	// Token: 0x04000B2E RID: 2862
	[Header("Events")]
	public UnityEvent onPlayerLand;

	// Token: 0x04000B2F RID: 2863
	public float hopTilt;

	// Token: 0x04000B30 RID: 2864
	private bool flipLock;

	// Token: 0x04000B31 RID: 2865
	private float speedModifier;

	// Token: 0x04000B32 RID: 2866
	public float landIntensity;
}
