using System;
using Rewired;
using UnityEngine;

// Token: 0x0200018A RID: 394
public class RampDirection : MonoBehaviour
{
	// Token: 0x06000631 RID: 1585 RVA: 0x0002CF44 File Offset: 0x0002B144
	private void Start()
	{
		this.player = ReInput.players.GetPlayer(this.playerId);
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x0002CF5C File Offset: 0x0002B15C
	private void Update()
	{
		if (this.LaunchAngle < 5f && this.adjustingDropIn)
		{
			Vector3 center = this.playerCollider.bounds.center;
			Vector3 b = Quaternion.FromToRotation(Vector3.up, this.rampNormal) * Vector3.down * 0.5f;
			center + b;
			RaycastHit raycastHit;
			Physics.Raycast(center, Vector3.down, out raycastHit, this.TransRayLength, this.groundLayer);
			RaycastHit raycastHit2;
			Physics.Raycast(base.transform.position + -base.transform.forward * 0.3f, Vector3.down, out raycastHit2, this.TransRayLength, this.groundLayer);
			RaycastHit raycastHit3;
			Physics.Raycast(base.transform.position + base.transform.forward * 0.3f, Vector3.down, out raycastHit3, this.TransRayLength, this.groundLayer);
			float num = Vector3.Angle(raycastHit2.normal, Vector3.up);
			float num2 = Vector3.Angle(raycastHit3.normal, Vector3.up);
			if (this.LaunchAngle < 5f && this.adjustingDropIn && Vector3.Angle(raycastHit.normal, Vector3.up) > 5f)
			{
				Vector3 rhs = this.landingTarget - base.transform.position;
				rhs.y = 0f;
				rhs.Normalize();
				Vector3 velocity = this.references.playerRigidbody.velocity;
				velocity.y = 0f;
				velocity.Normalize();
				if (Vector3.Dot(velocity, rhs) < 0f)
				{
					this.adjustingMidAir = false;
					Vector3 a = this.rampNormal;
					a.y = 0f;
					a.Normalize();
					int mask = LayerMask.GetMask(new string[]
					{
						"Coping"
					});
					if (num < 5f || num2 < 5f || (mask & 1 << raycastHit2.collider.gameObject.layer) != 0 || (mask & 1 << raycastHit3.collider.gameObject.layer) != 0)
					{
						this.rampTakeOff = raycastHit.point + a * 2f;
					}
					else
					{
						this.rampTakeOff = raycastHit.point;
					}
					this.rampNormal = raycastHit.normal;
					this.references.landCorrection.UpdateLandRotationCustom(this.rampNormal);
				}
			}
		}
		if (this.LookForCoping)
		{
			RaycastHit raycastHit4;
			Physics.Raycast(base.transform.position, Vector3.down, out raycastHit4, this.TransRayLength, this.groundLayer);
			if (Vector3.Angle(raycastHit4.normal, Vector3.up) < 5f)
			{
				this.switchoff();
			}
			else if (Vector3.Angle(raycastHit4.normal, this.rampNormal) < this.AiringAdjustAngleThreshold)
			{
				this.rampTakeOff = raycastHit4.point;
				this.rampNormal = raycastHit4.normal;
				this.references.landCorrection.UpdateLandRotationCustom(this.rampNormal);
			}
		}
		if (this.autoAir && this.references.scooterController.isGrounded)
		{
			this.autoAssits = true;
		}
		if (this.references.scooterController.isGrounded)
		{
			this.switchoff();
			if (this.player.GetButton("LeftStickDown"))
			{
				if (!this.transferHasPumped)
				{
					this.airTimeLeft = this.PumpTime;
				}
			}
			else if (this.airTimeLeft > 0f)
			{
				this.airTimeLeft -= Time.deltaTime;
			}
			if (this.airTimeLeft > 0f)
			{
				this.airHasPumped = true;
			}
			else
			{
				this.airHasPumped = false;
			}
			if (this.player.GetButton("LeftStickUp"))
			{
				if (!this.airHasPumped)
				{
					this.transferTimeLeft = this.PumpTime;
				}
			}
			else if (this.transferTimeLeft > 0f)
			{
				this.transferTimeLeft -= Time.deltaTime;
			}
			if (this.transferTimeLeft > 0f)
			{
				this.transferHasPumped = true;
			}
			else
			{
				this.transferHasPumped = false;
			}
			if ((this.airHasPumped || this.transferHasPumped) && this.references.hop.currentState == PlayerState.WallRiding)
			{
				this.transferHasPumped = false;
				this.airHasPumped = false;
			}
		}
		if (this.hopTriggerInitiated && !this.references.scooterController.isGrounded)
		{
			this.CalculateRamp();
			this.hopTrigger = true;
			this.hopTriggerInitiated = false;
		}
		if (this.enableRampAssist && !this.autoAir && !this.references.grindSystem.isGrinding && this.references.playerRigidbody.velocity.y > 0f && !this.references.trajectoryPrediction.IsGroingToGrind)
		{
			if ((this.references.scooterController.groundInformation.groundAngleX > this.AirableAngle && this.airHasPumped && this.LaunchSpeed < this.AirAllVel) || (this.references.scooterController.groundInformation.groundAngleX > this.FastAirableAngle && this.airHasPumped && this.LaunchSpeed > this.AirAllVel) || (this.transferHasPumped && this.references.scooterController.groundInformation.groundAngleX > this.TransferableAngle))
			{
				this.AirConditionsMet = true;
			}
			else
			{
				this.AirConditionsMet = false;
			}
			if (((!this.references.scooterController.isGrounded && this.LaunchAngle > this.AirableAngle && this.airHasPumped && this.LaunchSpeed < this.AirAllVel) || (!this.references.scooterController.isGrounded && this.LaunchAngle > this.FastAirableAngle && this.airHasPumped && this.LaunchSpeed > this.AirAllVel)) && !this.references.playerRigidbody.isKinematic && this.hopTrigger && this.references.hop.currentState != PlayerState.WallRiding)
			{
				this.AdjustPlayer();
				this.LookForCoping = true;
				this.airHasPumped = false;
				this.airTimeLeft = 0f;
				this.transferHasPumped = false;
				this.transferTimeLeft = 0f;
			}
			if (!this.references.scooterController.isGrounded && this.transferHasPumped && this.LaunchAngle > this.TransferableAngle && !this.references.playerRigidbody.isKinematic && this.hopTrigger)
			{
				this.transferHasPumped = false;
				this.transferTimeLeft = 0f;
				this.airHasPumped = false;
				this.airTimeLeft = 0f;
				this.runRays();
			}
		}
		if (this.enableRampAssist && this.autoAir && !this.references.grindSystem.isGrinding && this.references.playerRigidbody.velocity.y > 0f && !this.references.trajectoryPrediction.IsGroingToGrind)
		{
			if ((this.references.scooterController.groundInformation.groundAngleX > this.AirableAngle && this.autoAssits && this.LaunchSpeed < this.AirAllVel) || (this.references.scooterController.groundInformation.groundAngleX > this.FastAirableAngle && this.airHasPumped && this.LaunchSpeed > this.AirAllVel))
			{
				this.AirConditionsMet = true;
			}
			else if (this.autoAssits && this.references.scooterController.groundInformation.groundAngleX > this.TransferableAngle)
			{
				this.AirConditionsMet = true;
			}
			else
			{
				this.AirConditionsMet = false;
			}
			if ((!this.references.scooterController.isGrounded && this.LaunchAngle > this.AirableAngle && this.autoAssits && this.LaunchSpeed < this.AirAllVel) || (!this.references.scooterController.isGrounded && this.LaunchAngle > this.FastAirableAngle && this.autoAssits && this.LaunchSpeed > this.AirAllVel))
			{
				if (!this.references.playerRigidbody.isKinematic && this.hopTrigger && this.references.hop.currentState != PlayerState.WallRiding)
				{
					this.AdjustPlayer();
					this.LookForCoping = true;
					this.autoAssits = false;
					this.airHasPumped = false;
					this.airTimeLeft = 0f;
					this.transferHasPumped = false;
					this.transferTimeLeft = 0f;
					return;
				}
			}
			else if (this.autoAssits && !this.references.playerRigidbody.isKinematic && this.hopTrigger)
			{
				this.transferHasPumped = false;
				this.transferTimeLeft = 0f;
				this.autoAssits = false;
				this.airHasPumped = false;
				this.airTimeLeft = 0f;
				this.runRays();
			}
		}
	}

	// Token: 0x06000633 RID: 1587 RVA: 0x0002D86C File Offset: 0x0002BA6C
	private void runRays()
	{
		if (!this.RaysRan)
		{
			Vector3 a = base.transform.position + Vector3.up * this.TransRayHeight;
			Vector3 down = Vector3.down;
			Vector3? vector = null;
			Vector3? vector2 = null;
			Vector3? vector3 = null;
			Vector3? vector4 = null;
			Vector3? vector5 = null;
			Vector3? vector6 = null;
			Vector3? vector7 = null;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			for (int i = 0; i < this.TransNumRays; i++)
			{
				Vector3 velocity = this.references.playerRigidbody.velocity;
				velocity.y = 0f;
				velocity.Normalize();
				this.rayDirection = velocity;
				Vector3 b = this.rayDirection * (float)i * this.TransRaySpacing;
				RaycastHit raycastHit;
				if (Physics.Raycast(a + b, down, out raycastHit, this.TransRayLength, this.groundLayer))
				{
					float num = Vector3.Angle(raycastHit.normal, Vector3.up);
					Vector3 normalized = Vector3.Cross(Vector3.up, raycastHit.normal).normalized;
					Vector3 normalized2 = Vector3.Cross(raycastHit.normal, normalized).normalized;
					Vector3 normalized3 = (base.transform.position - raycastHit.point).normalized;
					if (!flag && num < this.TransFlatTolerance)
					{
						flag = true;
						Vector3 point = raycastHit.point;
						vector2 = new Vector3?(raycastHit.normal);
					}
					else if (flag && !flag2 && vector2 != null && Vector3.Angle(raycastHit.normal, vector2.Value) > this.TransCurvedTolerance)
					{
						if (Vector3.Dot(normalized2, normalized3) > 0f)
						{
							flag2 = true;
							vector = new Vector3?(raycastHit.point);
							vector3 = new Vector3?(raycastHit.normal);
						}
					}
					else if (flag2 && !flag3 && num < this.TransFlatTolerance)
					{
						flag3 = true;
						vector4 = new Vector3?(raycastHit.point);
						vector6 = new Vector3?(raycastHit.normal);
					}
					else if (flag3 && !flag4 && vector6 != null && Vector3.Angle(raycastHit.normal, vector6.Value) > this.TransCurvedTolerance && Vector3.Dot(normalized2, normalized3) > 0f)
					{
						flag4 = true;
						vector5 = new Vector3?(raycastHit.point);
						vector7 = new Vector3?(raycastHit.normal);
					}
				}
			}
			Vector3? vector8 = null;
			Vector3? vector9 = null;
			bool flag5 = vector4 != null && vector5 != null && vector6 != null && vector7 != null;
			if (vector != null && flag5)
			{
				float magnitude = this.references.playerRigidbody.velocity.magnitude;
				float num2 = Vector3.Distance(base.transform.position, vector.Value);
				float num3 = Vector3.Distance(base.transform.position, vector5.Value);
				float num4 = magnitude * 0.5f;
				float num5 = Mathf.Abs(num4 - num2);
				if (Mathf.Abs(num4 - num3) < num5)
				{
					vector8 = vector5;
					vector9 = vector7;
					this.firstRaycastHitNormal = vector7.Value;
				}
				else
				{
					vector8 = vector;
					vector9 = vector3;
					this.firstRaycastHitNormal = vector3.Value;
				}
			}
			else if (vector != null)
			{
				vector8 = vector;
				vector9 = vector3;
				this.firstRaycastHitNormal = vector3.Value;
			}
			Vector3 velocity2 = this.references.playerRigidbody.velocity;
			new Vector3(velocity2.x, 0f, velocity2.z);
			float num6 = Mathf.Abs(Physics.gravity.y);
			if (this.LaunchAngle < 5f)
			{
				this.apexHeight = base.transform.position.y + velocity2.y * velocity2.y / (2f * num6) + 0.35f;
			}
			else
			{
				this.apexHeight = base.transform.position.y + velocity2.y * velocity2.y / (2f * num6) + 0.25f;
			}
			this.relativePushAmount = 0.2f;
			Vector3 normalized4 = Vector3.Cross(Vector3.Cross(Vector3.up, this.firstRaycastHitNormal).normalized, this.firstRaycastHitNormal).normalized;
			if (vector9 != null)
			{
				Vector3 value = vector9.Value;
				value.y = 0f;
				value.Normalize();
				if (vector8 != null)
				{
					this.projectedForwardPoint = vector8.Value + value * this.relativePushAmount;
				}
			}
			Vector3 origin = this.projectedForwardPoint + Vector3.up * 2f;
			Vector3 down2 = Vector3.down;
			RaycastHit raycastHit2;
			if (Physics.Raycast(origin, down2, out raycastHit2, 4f, this.groundLayer))
			{
				if (vector8 != null)
				{
					this.landingTarget = raycastHit2.point;
					this.AdjustedRaycastHitNormal = raycastHit2.normal;
					Debug.DrawLine(this.landingTarget, this.landingTarget + Vector3.up * 2f, Color.cyan, 5f);
					this.adjustingMidAir = true;
				}
				else
				{
					this.switchoff();
				}
			}
			else if (vector8 != null)
			{
				this.landingTarget = vector8.Value;
				this.adjustingMidAir = true;
			}
			else
			{
				this.switchoff();
			}
			if (this.adjustingMidAir)
			{
				float num7 = this.apexHeight - base.transform.position.y;
				float num8 = Mathf.Sqrt(2f * num7 / num6);
				float num9 = this.apexHeight - this.landingTarget.y;
				float num10 = Mathf.Sqrt(2f * num9 / num6);
				this.totalFlightTime = num8 + num10;
				if (this.totalFlightTime <= 0.01f)
				{
					return;
				}
				this.timeElapsed = 0f;
				Vector3 a2 = this.landingTarget - base.transform.position;
				a2.y = 0f;
				Vector3 a3 = a2 / this.totalFlightTime;
				float num11 = Mathf.Sqrt(2f * num6 * num7);
				Vector3 vector10 = a3 + Vector3.up * num11;
				this.DrawTrajectory(base.transform.position, vector10, Color.magenta);
				bool flag6 = true;
				Vector3 vector11 = a3 + Vector3.up * (num11 - 0.55f);
				Vector3 vector12 = base.transform.position;
				Vector3 a4 = vector11;
				Mathf.Abs(Physics.gravity.y);
				float num12 = 0.1f;
				float num13 = this.totalFlightTime;
				float sqrMagnitude = (this.landingTarget - base.transform.position).sqrMagnitude;
				float num14 = 0f;
				while (num14 < num13)
				{
					Vector3 vector13 = vector12 + a4 * num12;
					a4 += Vector3.up * -num6 * num12;
					float sqrMagnitude2 = (vector13 - base.transform.position).sqrMagnitude;
					RaycastHit raycastHit3;
					if (Physics.Raycast(vector12, vector13 - vector12, out raycastHit3, (vector13 - vector12).magnitude, this.groundLayer) && sqrMagnitude2 < sqrMagnitude && vector3 != null && this.firstRaycastHitNormal == vector3.Value)
					{
						flag6 = false;
						if (this.DebugOn)
						{
							Debug.DrawLine(vector12, vector13, Color.red, 5f);
							break;
						}
						break;
					}
					else
					{
						if (this.DebugOn)
						{
							Debug.DrawLine(vector12, vector13, Color.yellow, 2f);
						}
						vector12 = vector13;
						num14 += num12;
					}
				}
				Vector2 vector14 = new Vector2(vector10.x, vector10.z);
				Vector2 vector15 = new Vector2(this.references.playerRigidbody.velocity.x, this.references.playerRigidbody.velocity.z);
				float magnitude2 = vector14.magnitude;
				float magnitude3 = vector15.magnitude;
				float num15 = (magnitude2 < magnitude3) ? ((magnitude3 - magnitude2) / magnitude3 * 100f) : 0f;
				float num16 = (magnitude3 < magnitude2) ? ((magnitude2 - magnitude3) / magnitude2 * 100f) : 0f;
				float num17 = Vector3.Angle(this.references.playerRigidbody.velocity.normalized, vector10.normalized);
				float num18 = 45f;
				if ((num17 < num18 && num15 < 2500f && flag6) || this.FootJamAssist)
				{
					if (num16 < 25f || vector8 == vector5 || this.FootJamAssist)
					{
						if (this.FootJamAssist)
						{
							Vector3 vector16 = new Vector3(this.landingTarget.x - this.references.playerRigidbody.position.x, 0f, this.landingTarget.z - this.references.playerRigidbody.position.z);
							bool flag7 = vector16.magnitude < 2f;
							if (this.DebugOn)
							{
								Debug.Log(vector16.magnitude);
							}
							if (flag7)
							{
								if (float.IsNaN(vector10.x) || float.IsNaN(vector10.y) || float.IsNaN(vector10.z))
								{
									if (this.DebugOn)
									{
										string str = "NaN detected in newVelocity: ";
										Vector3 vector17 = vector10;
										Debug.LogError(str + vector17.ToString());
									}
									this.switchoff();
								}
								else
								{
									this.references.playerRigidbody.velocity = new Vector3(this.references.playerRigidbody.velocity.x * 0.1f + vector10.x * 0.9f, vector10.y, this.references.playerRigidbody.velocity.z * 0.1f + vector10.z * 0.9f);
									this.references.trajectoryPrediction.PredictLanding();
									if (this.DebugOn)
									{
										Debug.Log("Foot jam On");
									}
								}
							}
							else
							{
								this.switchoff();
							}
						}
						else if (float.IsNaN(vector10.x) || float.IsNaN(vector10.y) || float.IsNaN(vector10.z))
						{
							if (this.DebugOn)
							{
								string str2 = "NaN detected in newVelocity: ";
								Vector3 vector17 = vector10;
								Debug.LogError(str2 + vector17.ToString());
							}
							this.switchoff();
						}
						else
						{
							if (this.LaunchAngle > 5f)
							{
								this.references.playerRigidbody.velocity = new Vector3(this.references.playerRigidbody.velocity.x * 0.1f + vector10.x * 0.9f, vector10.y, this.references.playerRigidbody.velocity.z * 0.1f + vector10.z * 0.9f);
							}
							else
							{
								this.references.playerRigidbody.velocity = new Vector3(this.references.playerRigidbody.velocity.x * 0.55f + vector10.x * 0.45f, vector10.y, this.references.playerRigidbody.velocity.z * 0.55f + vector10.z * 0.45f);
								this.adjustingDropIn = true;
							}
							this.references.trajectoryPrediction.PredictLanding();
						}
					}
					else
					{
						this.switchoff();
					}
				}
				else
				{
					this.switchoff();
				}
			}
		}
		this.RaysRan = true;
	}

	// Token: 0x06000634 RID: 1588 RVA: 0x0002E474 File Offset: 0x0002C674
	private void DrawTrajectory(Vector3 startPos, Vector3 velocity, Color color)
	{
		Vector3 vector = startPos;
		Vector3 a = velocity;
		float num = 0.1f;
		float num2 = 3f;
		float y = Physics.gravity.y;
		for (float num3 = 0f; num3 < num2; num3 += num)
		{
			Vector3 vector2 = vector + a * num;
			a += Vector3.up * y * num;
			if (this.DebugOn)
			{
				Debug.DrawLine(vector, vector2, color, 5f);
			}
			vector = vector2;
		}
	}

	// Token: 0x06000635 RID: 1589 RVA: 0x0002E4F4 File Offset: 0x0002C6F4
	private void CalculateRamp()
	{
		this.LaunchSpeed = this.references.scooterController.velocityMagnitudeSettings.previousFallMagnitude + this.references.scooterController.velocityMagnitudeSettings.previousVelocityMagnitude / 2f;
		this.LaunchAngle = this.references.scooterController.groundInformation.groundAngleX;
		this.rampNormal = this.references.scooterController.referencedItems.playerBalance.rearHit.normal;
		this.rampTakeOff = this.references.scooterController.referencedItems.playerBalance.rearHit.point;
		this.crossDirection = Vector3.Cross(this.rampNormal, Vector3.up);
	}

	// Token: 0x06000636 RID: 1590 RVA: 0x0002E5B4 File Offset: 0x0002C7B4
	private void AdjustPlayer()
	{
		Vector3 vector = Vector3.Project(this.references.playerRigidbody.velocity, this.crossDirection);
		this.references.playerRigidbody.velocity = new Vector3(vector.x, this.references.playerRigidbody.velocity.y, vector.z);
		this.references.trajectoryPrediction.PredictLanding();
		this.references.landCorrection.UpdateLandRotation();
	}

	// Token: 0x06000637 RID: 1591 RVA: 0x0002E634 File Offset: 0x0002C834
	private void FixedUpdate()
	{
		if (this.adjustingMidAir)
		{
			this.timeElapsed += Time.fixedDeltaTime;
			float d = Mathf.Max(this.totalFlightTime - this.timeElapsed, 0.01f);
			this.references.landCorrection.UpdateLandRotationCustom(this.AdjustedRaycastHitNormal);
			bool flag = Physics.Raycast(base.transform.position, Vector3.down, 0.5f, this.groundLayer);
			Vector3 center = this.playerCollider.bounds.center;
			Vector3 b = Quaternion.FromToRotation(Vector3.up, this.AdjustedRaycastHitNormal) * Vector3.down * 0.5f;
			Vector3 b2 = center + b;
			Vector3 normalized = Vector3.Cross(this.AdjustedRaycastHitNormal, Vector3.up).normalized;
			Vector3 vector = this.landingTarget - b2;
			new Vector3(vector.x, 0f, vector.z);
			Vector3 vector2 = Vector3.ProjectOnPlane(vector, normalized) / d;
			Vector3 vector3 = Vector3.Project(this.references.playerRigidbody.velocity, normalized);
			Vector3 vector4 = new Vector3(vector3.x + vector2.x, this.references.playerRigidbody.velocity.y, vector3.z + vector2.z);
			Vector3 velocity;
			if (this.LaunchAngle < 5f)
			{
				velocity = new Vector3(vector4.x * 0.05f + this.references.playerRigidbody.velocity.x * 0.95f, this.references.playerRigidbody.velocity.y, vector4.z * 0.05f + this.references.playerRigidbody.velocity.z * 0.95f);
			}
			else
			{
				velocity = new Vector3(vector4.x, this.references.playerRigidbody.velocity.y, vector4.z);
			}
			bool flag2 = Physics.Raycast(base.transform.position, Vector3.down, 0.25f, this.groundLayer);
			if (!flag)
			{
				this.references.playerRigidbody.velocity = velocity;
			}
			if (this.references.playerRigidbody.velocity.y < 0f && flag2)
			{
				this.switchoff();
			}
		}
		if (this.LookForCoping || (this.LaunchAngle < 5f && this.adjustingDropIn && !this.adjustingMidAir))
		{
			Vector3 center2 = this.playerCollider.bounds.center;
			Vector3 b3 = Quaternion.FromToRotation(Vector3.up, this.rampNormal) * Vector3.down * 0.5f;
			Vector3 b4 = center2 + b3;
			Vector3 normalized2 = Vector3.Cross(this.rampNormal, Vector3.up).normalized;
			Vector3 normalized3 = Vector3.ProjectOnPlane(this.rampTakeOff - b4, normalized2).normalized;
			Vector3 vector5 = Vector3.Project(this.references.playerRigidbody.velocity, normalized2);
			Vector3 velocity2;
			if (this.LaunchAngle < 5f)
			{
				velocity2 = new Vector3((vector5.x + normalized3.x) * (1f - this.PocketAssistStrengthDrop) + this.references.playerRigidbody.velocity.x * this.PocketAssistStrengthDrop, this.references.playerRigidbody.velocity.y, (vector5.z + normalized3.z) * (1f - this.PocketAssistStrengthDrop) + this.references.playerRigidbody.velocity.z * this.PocketAssistStrengthDrop);
			}
			else
			{
				velocity2 = new Vector3((vector5.x + normalized3.x) * (1f - this.PocketAssistStrength) + this.references.playerRigidbody.velocity.x * this.PocketAssistStrength, this.references.playerRigidbody.velocity.y, (vector5.z + normalized3.z) * (1f - this.PocketAssistStrength) + this.references.playerRigidbody.velocity.z * this.PocketAssistStrength);
			}
			this.references.playerRigidbody.velocity = velocity2;
			bool flag3 = Physics.Raycast(base.transform.position, Vector3.down, 0.5f, this.groundLayer);
			if (this.references.playerRigidbody.velocity.y < 0f && flag3)
			{
				this.adjustingDropIn = false;
				this.switchoff();
			}
		}
	}

	// Token: 0x06000638 RID: 1592 RVA: 0x0002EAFC File Offset: 0x0002CCFC
	public void switchoff()
	{
		this.LookForCoping = false;
		this.RaysRan = false;
		this.adjustingMidAir = false;
		this.hopTrigger = false;
		this.landingTarget = Vector3.zero;
		if (this.FootJamAssist && this.references.playerRigidbody.velocity.y < 0f)
		{
			if (this.DebugOn)
			{
				Debug.Log("footjam off again");
			}
			this.FootJamAssist = false;
		}
	}

	// Token: 0x04000A6D RID: 2669
	[Header("Debug Swtich")]
	public bool DebugOn;

	// Token: 0x04000A6E RID: 2670
	private int playerId;

	// Token: 0x04000A6F RID: 2671
	private Player player;

	// Token: 0x04000A70 RID: 2672
	private Vector3 crossDirection;

	// Token: 0x04000A71 RID: 2673
	[Header("References Container")]
	public RampDirectionReferences references;

	// Token: 0x04000A72 RID: 2674
	public bool enableRampAssist;

	// Token: 0x04000A73 RID: 2675
	public bool autoAir;

	// Token: 0x04000A74 RID: 2676
	[Header("Pumped Checks")]
	public float PumpTime = 0.75f;

	// Token: 0x04000A75 RID: 2677
	public bool airHasPumped;

	// Token: 0x04000A76 RID: 2678
	public bool transferHasPumped;

	// Token: 0x04000A77 RID: 2679
	[Header("Airing Conditions")]
	public float AirableAngle = 35f;

	// Token: 0x04000A78 RID: 2680
	public float FastAirableAngle = 55f;

	// Token: 0x04000A79 RID: 2681
	public float AirAllVel = 4f;

	// Token: 0x04000A7A RID: 2682
	[Header("Current Factors")]
	public float LaunchAngle;

	// Token: 0x04000A7B RID: 2683
	public float LaunchSpeed;

	// Token: 0x04000A7C RID: 2684
	[HideInInspector]
	public bool AirConditionsMet;

	// Token: 0x04000A7D RID: 2685
	private float airTimeLeft;

	// Token: 0x04000A7E RID: 2686
	private float transferTimeLeft;

	// Token: 0x04000A7F RID: 2687
	private float playerStrength;

	// Token: 0x04000A80 RID: 2688
	private bool hopTrigger;

	// Token: 0x04000A81 RID: 2689
	[HideInInspector]
	public bool hopTriggerInitiated;

	// Token: 0x04000A82 RID: 2690
	[Header("Ramp Finder")]
	public LayerMask groundLayer;

	// Token: 0x04000A83 RID: 2691
	public int TransNumRays = 150;

	// Token: 0x04000A84 RID: 2692
	public float TransRaySpacing = 0.15f;

	// Token: 0x04000A85 RID: 2693
	public float TransRayHeight = 4f;

	// Token: 0x04000A86 RID: 2694
	public float TransRayLength = 24f;

	// Token: 0x04000A87 RID: 2695
	public float TransferableAngle = 15f;

	// Token: 0x04000A88 RID: 2696
	private float TransFlatTolerance = 20f;

	// Token: 0x04000A89 RID: 2697
	private float TransCurvedTolerance = 30f;

	// Token: 0x04000A8A RID: 2698
	private Vector3 rayDirection;

	// Token: 0x04000A8B RID: 2699
	private Vector3 AdjustedRaycastHitNormal;

	// Token: 0x04000A8C RID: 2700
	private Vector3 firstRaycastHitNormal;

	// Token: 0x04000A8D RID: 2701
	public Vector3 landingTarget;

	// Token: 0x04000A8E RID: 2702
	[HideInInspector]
	public bool FootJamAssist;

	// Token: 0x04000A8F RID: 2703
	public bool adjustingMidAir;

	// Token: 0x04000A90 RID: 2704
	public bool adjustingDropIn;

	// Token: 0x04000A91 RID: 2705
	private bool autoAssits;

	// Token: 0x04000A92 RID: 2706
	private bool RaysRan;

	// Token: 0x04000A93 RID: 2707
	private float totalFlightTime;

	// Token: 0x04000A94 RID: 2708
	private float timeElapsed;

	// Token: 0x04000A95 RID: 2709
	[HideInInspector]
	public bool LookForCoping;

	// Token: 0x04000A96 RID: 2710
	[Header("Deck Position Prediction")]
	public BoxCollider playerCollider;

	// Token: 0x04000A97 RID: 2711
	private Vector3 rampNormal;

	// Token: 0x04000A98 RID: 2712
	private Vector3 rampTakeOff;

	// Token: 0x04000A99 RID: 2713
	private Vector3 projectedForwardPoint;

	// Token: 0x04000A9A RID: 2714
	private float relativePushAmount;

	// Token: 0x04000A9B RID: 2715
	private float AiringAdjustAngleThreshold = 15f;

	// Token: 0x04000A9C RID: 2716
	[Range(0f, 1f)]
	public float PocketAssistStrength = 0.8f;

	// Token: 0x04000A9D RID: 2717
	[Range(0f, 1f)]
	public float PocketAssistStrengthDrop = 0.95f;

	// Token: 0x04000A9E RID: 2718
	private float apexHeight;
}
