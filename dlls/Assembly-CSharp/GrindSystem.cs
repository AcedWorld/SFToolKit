using System;
using Rewired;
using UnityEngine;

// Token: 0x0200015D RID: 349
public class GrindSystem : MonoBehaviour
{
	// Token: 0x0600058D RID: 1421 RVA: 0x000266C3 File Offset: 0x000248C3
	private void Start()
	{
		this.playerRb = base.GetComponent<Rigidbody>();
		this.player = ReInput.players.GetPlayer(this.playerId);
		if (this.hasDeckPegs)
		{
			this.BackRightPegActive = true;
			this.BackLeftPegActive = true;
		}
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x00026700 File Offset: 0x00024900
	public void SetPegs()
	{
		this.FrontLeftPegActive = this.DoesObjectExistAndActive(base.transform, "LeftPeg_Mesh");
		this.FrontRightPegActive = this.DoesObjectExistAndActive(base.transform, "RightPeg_Mesh");
		this.BackLeftPegActive = this.DoesObjectExistAndActive(base.transform, "RearLeftPeg_Mesh");
		this.BackRightPegActive = this.DoesObjectExistAndActive(base.transform, "RearRightPeg_Mesh");
	}

	// Token: 0x0600058F RID: 1423 RVA: 0x0002676C File Offset: 0x0002496C
	private bool DoesObjectExistAndActive(Transform parent, string objectName)
	{
		foreach (object obj in parent)
		{
			Transform transform = (Transform)obj;
			if (transform.name == objectName && transform.gameObject.activeInHierarchy)
			{
				return true;
			}
			if (this.DoesObjectExistAndActive(transform, objectName))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000590 RID: 1424 RVA: 0x000267EC File Offset: 0x000249EC
	public void PopulateGrindPoints(Transform railContainer)
	{
		this.railContainertemp = railContainer;
		int childCount = railContainer.childCount;
		this.grindPoints = new Transform[childCount];
		this.reverseGrindPoints = new Transform[childCount];
		for (int i = 0; i < childCount; i++)
		{
			this.grindPoints[i] = railContainer.GetChild(i);
			this.reverseGrindPoints[childCount - 1 - i] = this.grindPoints[i];
		}
	}

	// Token: 0x06000591 RID: 1425 RVA: 0x00026850 File Offset: 0x00024A50
	public void StartGrinding()
	{
		if (!this.isGrinding && this.trajectoryPrediction.IsGroingToGrind)
		{
			this.scooterController.GrindClear();
			this.playerRb.angularVelocity = Vector3.zero;
			this.lockRotation.isGrinding = true;
			this.cachedHorizontalVelocity = new Vector3(this.playerRb.velocity.x, 0f, this.playerRb.velocity.z);
			Vector3 normalized = this.cachedHorizontalVelocity.normalized;
			this.isReverseGrinding = this.ShouldReverseGrind(normalized);
			this.currentPointIndex = this.FindClosestPointIndex(normalized, this.isReverseGrinding ? this.reverseGrindPoints : this.grindPoints);
			this.raildecay = this.cachedHorizontalVelocity.magnitude;
			if (this.currentPointIndex != -1)
			{
				if (!this.FindValidGrindSegment())
				{
					this.StopGrinding(true, true);
					return;
				}
				this.isGrinding = true;
				this.UpdateGrindDirection(this.isReverseGrinding);
				this.tempEndpoint = this.grindPoints[this.grindPoints.Length - 1];
			}
			this.smoothedAngle = this.CalculateAngleRelativeToGrind();
		}
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x0002696C File Offset: 0x00024B6C
	private void Update()
	{
		this.UpdateGrindTilt();
		if (this.applyCoolDown)
		{
			this.cooldownTimer -= Time.deltaTime;
		}
		if (this.cooldownTimer <= 0.025f && this.applyCoolDown)
		{
			this.applyCoolDown = false;
			this.cooldownTimer = 0f;
			Physics.IgnoreLayerCollision(this.frontWheelCollider.gameObject.layer, 0, false);
			Physics.IgnoreLayerCollision(this.rearWheelCollider.gameObject.layer, 0, false);
		}
		if (this.blunt && !this.sugar)
		{
			this.contactPoint = this.bluntPoint;
			this.contactPointAnimVar = -1f;
		}
		if (!this.blunt && !this.sugar)
		{
			this.contactPoint = this.centerPoint;
			this.contactPointAnimVar = 0f;
		}
		if (this.sugar && !this.blunt)
		{
			this.contactPoint = this.sugarPoint;
			this.contactPointAnimVar = 1f;
		}
		if (this.isGrinding)
		{
			float num;
			if (this.is5050 || this.isFakie5050)
			{
				num = 1.25f;
			}
			else
			{
				num = 1f;
			}
			this.targetAngle = this.CalculateAngleRelativeToGrind();
			this.correctedAngle = this.targetAngle;
			this.clampedRailDecay = Mathf.Clamp(this.raildecay, 2f, 5f);
			this.newRotation = Quaternion.Slerp(this.playerRb.rotation, this.targetRotation, this.clampedRailDecay * num * Time.deltaTime);
			if (!this.physicsGrinds)
			{
				this.playerRb.MoveRotation(Quaternion.Normalize(this.newRotation));
			}
		}
		else
		{
			this.playerRb.constraints = RigidbodyConstraints.None;
		}
		if ((!this.applyCoolDown && !this.isGrinding && this.trajectoryPrediction.IsGroingToGrind) || this.is5050 || this.isFakie5050)
		{
			this.smoothedAngle = this.targetAngle;
		}
		else
		{
			this.smoothedAngle = Mathf.Lerp(this.smoothedAngle, this.correctedAngle, Time.deltaTime * 7.5f);
		}
		this.animator.SetFloat("AngleOnRail", Mathf.Repeat(this.smoothedAngle, 360f));
		if (this.isGrinding)
		{
			Physics.IgnoreLayerCollision(this.frontWheelCollider.gameObject.layer, 0, true);
			Physics.IgnoreLayerCollision(this.rearWheelCollider.gameObject.layer, 0, true);
			return;
		}
		Physics.IgnoreLayerCollision(this.frontWheelCollider.gameObject.layer, 0, false);
		Physics.IgnoreLayerCollision(this.rearWheelCollider.gameObject.layer, 0, false);
	}

	// Token: 0x06000593 RID: 1427 RVA: 0x00026BF8 File Offset: 0x00024DF8
	private bool ShouldReverseGrind(Vector3 approachDirection)
	{
		float num = float.PositiveInfinity;
		int num2 = -1;
		for (int i = 0; i < this.grindPoints.Length - 1; i++)
		{
			Vector3 position = this.grindPoints[i].position;
			Vector3 position2 = this.grindPoints[i + 1].position;
			Vector3 vector = this.ClosestPointOnSegment(position, position2, this.contactPoint.position);
			Vector3 boxSize = new Vector3(0.25f, 0.25f, 0.25f);
			LayerMask layerMask = LayerMask.GetMask(new string[]
			{
				"Default"
			});
			LayerMask.GetMask(new string[]
			{
				"Coping"
			});
			if (this.trajectoryPrediction.BoxcastAtPoint(vector, boxSize, layerMask))
			{
				this.isledge = true;
			}
			else
			{
				this.isledge = false;
			}
			float num3 = Vector3.Distance(this.contactPoint.position, vector);
			if (num3 < num)
			{
				num = num3;
				num2 = i;
			}
		}
		if (num2 == -1)
		{
			return false;
		}
		Vector3 position3 = this.grindPoints[num2].position;
		Vector3 normalized = (this.grindPoints[num2 + 1].position - position3).normalized;
		return Vector3.Dot(approachDirection, normalized) < 0f;
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x00026D34 File Offset: 0x00024F34
	private int FindClosestPointIndex(Vector3 approachDirection, Transform[] points)
	{
		float num = float.PositiveInfinity;
		int result = -1;
		for (int i = 0; i < points.Length - 1; i++)
		{
			Vector3 position = points[i].position;
			Vector3 position2 = points[i + 1].position;
			Vector3 b = this.ClosestPointOnSegment(position, position2, this.contactPoint.position);
			float num2 = Vector3.Distance(this.contactPoint.position, b);
			if (num2 < num)
			{
				num = num2;
				result = i;
			}
		}
		return result;
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x00026DA4 File Offset: 0x00024FA4
	private Vector3 ClosestPointOnSegment(Vector3 start, Vector3 end, Vector3 point)
	{
		Vector3 vector = end - start;
		float sqrMagnitude = vector.sqrMagnitude;
		if (sqrMagnitude == 0f)
		{
			return start;
		}
		float num = Vector3.Dot(point - start, vector) / sqrMagnitude;
		num = Mathf.Clamp01(num);
		return start + num * vector;
	}

	// Token: 0x06000596 RID: 1430 RVA: 0x00026DF0 File Offset: 0x00024FF0
	private void UpdateGrindDirection(bool reverse)
	{
		if (reverse)
		{
			this.grindPoints = this.reverseGrindPoints;
		}
		int num = (this.currentPointIndex + 1) % this.grindPoints.Length;
		this.nextPoint = this.grindPoints[num].position;
		this.grindDirection = (this.nextPoint - this.grindPoints[this.currentPointIndex].position).normalized;
		this.grindDirectionReal = this.nextPoint - this.grindPoints[this.currentPointIndex].position;
		Vector3 normalized = new Vector3(this.grindDirection.x, 0f, this.grindDirection.z).normalized;
		Vector3 normalized2 = new Vector3(this.playerRb.velocity.x, 0f, this.playerRb.velocity.z).normalized;
		if (Mathf.Abs(Vector3.Angle(normalized, normalized2) - 90f) <= 45f)
		{
			this.isGrinding = false;
			if (this.DebugOn)
			{
				Debug.LogWarning("not straight");
			}
		}
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x00026F0C File Offset: 0x0002510C
	private void OnDrawGizmos()
	{
		if (this.grindPoints != null && this.grindPoints.Length != 0)
		{
			for (int i = 0; i < this.grindPoints.Length - 1; i++)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine(this.grindPoints[i].position, this.grindPoints[i + 1].position);
			}
			if (this.isGrinding && this.currentPointIndex != -1)
			{
				Gizmos.color = Color.green;
				Vector3 position = this.grindPoints[this.currentPointIndex].position;
				Vector3 position2 = this.grindPoints[this.currentPointIndex + 1].position;
				Gizmos.DrawLine(position, position2);
			}
		}
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x00026FB8 File Offset: 0x000251B8
	public void StopGrinding(bool applyCooldown = false, bool applyforce = false)
	{
		this.playerRb.angularVelocity = Vector3.zero;
		this.isGrinding = false;
		this.LandTimer = 0f;
		this.cooldownTimer = this.grindOffCooldown;
		this.applyCoolDown = true;
		this.trajectoryPrediction.IsGroingToGrind = false;
		this.grindPoints = null;
		this.reverseGrindPoints = null;
		this.isledge = false;
		this.landLockOut = false;
		this.extraRotation = 0f;
		this.isLocked = false;
		this.lockedRotationIndex = -1;
		this.playerRb.constraints = RigidbodyConstraints.None;
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x00027048 File Offset: 0x00025248
	private void FixedUpdate()
	{
		if (this.isGrinding)
		{
			this.GrindLogic();
			if (!this.physicsGrinds)
			{
				this.playerRb.constraints = RigidbodyConstraints.FreezeRotation;
			}
			else
			{
				this.playerRb.constraints = RigidbodyConstraints.FreezeRotationX;
			}
			this.GrindCancelChecks();
		}
		else
		{
			this.is5050 = false;
			this.isFakie5050 = false;
			this.grindTilt = 0f;
		}
		if (this.applyCoolDown)
		{
			this.cooldownTimer -= Time.deltaTime;
		}
		if (this.cooldownTimer <= 0.025f)
		{
			this.applyCoolDown = false;
			this.cooldownTimer = 0f;
		}
		if ((this.isGrinding || this.trajectoryPrediction.IsGroingToGrind) && this.RagdollControl.ragdollActive)
		{
			this.StopGrinding(true, true);
			Physics.IgnoreLayerCollision(this.frontWheelCollider.gameObject.layer, 0, false);
			Physics.IgnoreLayerCollision(this.rearWheelCollider.gameObject.layer, 0, false);
		}
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x0002713C File Offset: 0x0002533C
	private bool FindValidGrindSegment()
	{
		if (this.grindPoints == null || this.grindPoints.Length < 2)
		{
			return false;
		}
		float num = float.MaxValue;
		bool result = false;
		for (int i = 0; i < this.grindPoints.Length - 1; i++)
		{
			Vector3 position = this.grindPoints[i].position;
			Vector3 position2 = this.grindPoints[i + 1].position;
			Vector3 normalized = (position2 - position).normalized;
			Vector3 normalized2 = this.playerRb.velocity.normalized;
			Vector3 normalized3 = new Vector3(normalized.x, 0f, normalized.z).normalized;
			Vector3 normalized4 = new Vector3(normalized2.x, 0f, normalized2.z).normalized;
			if (Mathf.Abs(Vector3.Angle(normalized3, normalized4) - 90f) > 30f)
			{
				Vector3 vector = this.ClosestPointOnSegment(position, position2, this.contactPoint.position);
				if (Mathf.Abs(vector.x - this.contactPoint.position.x) <= 0.5f && Mathf.Abs(vector.z - this.contactPoint.position.z) <= 0.5f)
				{
					result = true;
					float num2 = Vector3.Distance(this.contactPoint.position, vector);
					if (num2 < num)
					{
						num = num2;
						this.closestPointOnLine = vector;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x0600059B RID: 1435 RVA: 0x000272B0 File Offset: 0x000254B0
	private void UpdateGrindTilt()
	{
		float num = 0.1f;
		float b = (Mathf.Abs(this.grindDirection.y) < num) ? 0f : Mathf.Sign(this.grindDirection.y);
		this.grindTilt = Mathf.Lerp(this.grindTilt, b, Time.deltaTime * 5f);
	}

	// Token: 0x0600059C RID: 1436 RVA: 0x0002730C File Offset: 0x0002550C
	private float CalculateAngleRelativeToGrind()
	{
		if (this.grindDirection == Vector3.zero)
		{
			return 0f;
		}
		float y = base.transform.eulerAngles.y;
		float y2 = Quaternion.LookRotation(this.grindDirection).eulerAngles.y;
		float num = Mathf.DeltaAngle(y, y2);
		if (num < 0f)
		{
			num += 360f;
		}
		return num;
	}

	// Token: 0x0600059D RID: 1437 RVA: 0x00027374 File Offset: 0x00025574
	private void GrindCancelChecks()
	{
		if (this.playerRb.velocity.magnitude == 20f)
		{
			this.RagdollControl.ActivateRagdoll();
			if (this.DebugOn)
			{
				Debug.Log("Velocity to high-Ragdoll");
			}
		}
		if (this.raildecay < 0f)
		{
			if (this.grindDirection.y > 0.1f)
			{
				if (this.DebugOn)
				{
					Debug.Log("Grinding Up Rail Switiching to down");
				}
				this.grindDirection = -this.grindDirection * 1.25f;
				this.raildecay = 1f;
				this.tempEndpoint = this.grindPoints[0];
				this.StartGrinding();
			}
			else
			{
				this.characterStates.GetOffScooter();
				if (this.DebugOn)
				{
					Debug.Log("RailDecay dropped to zero-Get Off Scooter");
				}
			}
		}
		Vector3 vector = this.ClosestPointOnSegment(this.currentPoint, this.nextPoint, this.contactPoint.position);
		if (this.contactPoint.position.y + 0.2f < vector.y)
		{
			this.RagdollControl.ActivateRagdoll();
			if (this.DebugOn)
			{
				Debug.Log("Player dropped below grind segment");
			}
		}
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x0002749C File Offset: 0x0002569C
	private void GrindLogic()
	{
		if (this.lockRotation.isGrinding && this.isGrinding)
		{
			if (!this.landLockOut)
			{
				this.grindLand = true;
				this.LandTimer += Time.deltaTime;
			}
			if (this.playerRb.velocity.y < 0.1f && this.playerRb.velocity.y > -0.1f)
			{
				this.raildecay -= Time.deltaTime * 1.25f;
			}
			if (this.playerRb.velocity.y < -0.1f)
			{
				this.raildecay += Time.deltaTime * 3.5f;
			}
			if (this.playerRb.velocity.y > 0.1f)
			{
				this.raildecay -= Time.deltaTime * 2f;
			}
			if (this.LandTimer >= this.LandTime)
			{
				this.grindLand = false;
			}
		}
		this.currentPoint = this.grindPoints[this.currentPointIndex].position;
		int num = (this.currentPointIndex + 1) % this.grindPoints.Length;
		this.nextPoint = this.grindPoints[num].position;
		this.toNextPoint = this.nextPoint - this.currentPoint;
		float num2 = Vector3.Dot(this.contactPoint.position - this.currentPoint, this.toNextPoint) / this.toNextPoint.sqrMagnitude;
		num2 = Mathf.Clamp01(num2);
		Vector3 normalized = Vector3.Cross(this.playerRb.transform.up, this.toNextPoint.normalized).normalized;
		if (this.is5050 || this.isFakie5050)
		{
			Vector3 vector = this.currentPoint + num2 * this.toNextPoint;
			float num3 = Vector3.Dot(this.contactPoint.position - vector, normalized);
			float num4 = 0.03f;
			if (this.isledge)
			{
				if (this.is5050)
				{
					if (this.isReverseGrinding)
					{
						this.offset = ((Vector3.Dot(normalized, base.transform.right) > 0f) ? (-num4) : num4);
						this.GrindToLeft = true;
					}
					else
					{
						this.offset = ((Vector3.Dot(normalized, base.transform.right) > 0f) ? num4 : (-num4));
						this.GrindToLeft = false;
					}
				}
				if (this.isFakie5050)
				{
					if (this.isReverseGrinding)
					{
						this.offset = ((Vector3.Dot(normalized, base.transform.right) > 0f) ? num4 : (-num4));
						this.GrindToLeft = false;
					}
					else
					{
						this.offset = ((Vector3.Dot(normalized, base.transform.right) > 0f) ? (-num4) : num4);
						this.GrindToLeft = true;
					}
				}
			}
			else
			{
				this.offset = ((num3 > 0f) ? 0.035f : -0.035f);
			}
			this.closestPointOnLine = vector + normalized * this.offset;
		}
		else
		{
			this.closestPointOnLine = this.currentPoint + num2 * this.toNextPoint;
		}
		Vector3 vector2 = this.grindDirection * this.raildecay;
		if (!this.lockRotation.isGrinding)
		{
			this.correctionalVelocity = (this.closestPointOnLine - this.contactPoint.position) * 3f;
		}
		if (this.lockRotation.isGrinding)
		{
			if (this.is5050 || this.isFakie5050)
			{
				this.correctionalVelocity = (this.closestPointOnLine - this.contactPoint.position) * 15f;
			}
			else
			{
				this.correctionalVelocity = (this.closestPointOnLine - this.contactPoint.position) * 4f;
			}
		}
		Vector3 vector3 = vector2 + this.correctionalVelocity;
		if (!this.physicsGrinds)
		{
			this.playerRb.velocity = new Vector3(vector3.x, vector2.y - 0.5f, vector3.z);
		}
		Quaternion quaternion = this.SnapToNearestRotation(this.toNextPoint, this.playerRb.rotation);
		this.targetRotation = Quaternion.Euler(quaternion.eulerAngles.x, quaternion.eulerAngles.y, quaternion.eulerAngles.z);
		if (num2 >= 1f)
		{
			Vector3 from = this.grindPoints[num].position - this.grindPoints[this.currentPointIndex].position;
			Vector3 to = this.grindPoints[(num + 1) % this.grindPoints.Length].position - this.grindPoints[num].position;
			if (Vector3.Angle(from, to) > 30f)
			{
				this.StopGrinding(false, false);
				return;
			}
			this.currentPointIndex = num;
			this.UpdateGrindDirection(false);
		}
		if (Vector3.Distance(this.contactPoint.position, this.tempEndpoint.position) < 0.05f)
		{
			this.playerRb.velocity = this.playerRb.velocity + (this.grindDirection.normalized + Vector3.up) / 2f;
			this.StopGrinding(false, false);
			return;
		}
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x000279EC File Offset: 0x00025BEC
	private Quaternion SnapToNearestRotation(Vector3 forwardDirection, Quaternion currentRotation)
	{
		if (this.isledge)
		{
			this.edgetilt = 16f;
			this.feebletilt = 8f;
		}
		else if (this.blunt || (this.sugar && this.isledge))
		{
			if (this.isReverseGrinding)
			{
				this.edgetilt = 15f;
			}
			else
			{
				this.edgetilt = -15f;
			}
		}
		else
		{
			this.edgetilt = 0f;
		}
		if (this.animationTrigger.lastGrindDirVertical > 0.4f)
		{
			if ((this.FrontLeftPegActive && this.GrindToLeft) || (this.FrontRightPegActive && !this.GrindToLeft))
			{
				this.forwardtilt = -16f;
			}
			else
			{
				this.forwardtilt = 0f;
			}
		}
		if (this.animationTrigger.lastGrindDirVertical < -0.4f)
		{
			if ((this.BackLeftPegActive && this.GrindToLeft) || (this.BackRightPegActive && !this.GrindToLeft))
			{
				this.forwardtilt = 16f;
			}
			else
			{
				this.forwardtilt = 0f;
			}
		}
		if (this.animationTrigger.lastGrindDirVertical > -0.4f && this.animationTrigger.lastGrindDirVertical < 0.4f)
		{
			this.forwardtilt = 0f;
		}
		if (!this.blunt && !this.sugar)
		{
			this.extraRotation += this.player.GetAxis("LeftStickX") * Time.deltaTime * 250f;
		}
		float num = (float)(this.isReverseGrinding ? -1 : 1);
		Quaternion[] array;
		if (this.sugar)
		{
			array = new Quaternion[]
			{
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.forwardtilt, 0f, 0f),
				Quaternion.LookRotation(-forwardDirection) * Quaternion.Euler(this.forwardtilt, 0f, 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(-this.edgetilt * num, Mathf.Clamp(90f + this.extraRotation, 10f, 170f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(-90f + this.extraRotation, -170f, -10f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(-this.edgetilt * num, Mathf.Clamp(45f + this.extraRotation, 10f, 170f), this.edgetilt * 0.5f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(-this.edgetilt * num, Mathf.Clamp(135f + this.extraRotation, 10f, 170f), this.edgetilt * 0.5f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(-45f + this.extraRotation, -170f, -10f), -this.edgetilt * 0.5f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(-135f + this.extraRotation, -170f, -10f), -this.edgetilt * 0.5f)
			};
		}
		else if (this.blunt && this.isledge && !this.isReverseGrinding)
		{
			array = new Quaternion[]
			{
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.forwardtilt, 0f, 0f),
				Quaternion.LookRotation(-forwardDirection) * Quaternion.Euler(this.forwardtilt, 0f, 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(-this.edgetilt * num, Mathf.Clamp(90f + this.extraRotation, 10f, 170f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(-this.edgetilt * num, Mathf.Clamp(45f + this.extraRotation, 10f, 170f), this.edgetilt * 0.5f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(-this.edgetilt * num, Mathf.Clamp(135f + this.extraRotation, 10f, 170f), this.edgetilt * 0.5f)
			};
		}
		else if (this.blunt && this.isledge && this.isReverseGrinding)
		{
			array = new Quaternion[]
			{
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.forwardtilt, 0f, 0f),
				Quaternion.LookRotation(-forwardDirection) * Quaternion.Euler(this.forwardtilt, 0f, 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(-90f + this.extraRotation, -170f, -10f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(-45f + this.extraRotation, -170f, -10f), -this.edgetilt * 0.5f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(-135f + this.extraRotation, -170f, -10f), -this.edgetilt * 0.5f)
			};
		}
		else
		{
			array = new Quaternion[]
			{
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.forwardtilt, 0f, 0f),
				Quaternion.LookRotation(-forwardDirection) * Quaternion.Euler(this.forwardtilt, 0f, 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(-this.edgetilt * num, Mathf.Clamp(90f + this.extraRotation, 10f, 170f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(-90f + this.extraRotation, -170f, -10f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(-this.feebletilt * num, Mathf.Clamp(15f + this.extraRotation, 10f, 170f), this.edgetilt * 0.5f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(-this.feebletilt * num, Mathf.Clamp(165f + this.extraRotation, 10f, 170f), this.edgetilt * 0.5f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.feebletilt * num, Mathf.Clamp(-15f + this.extraRotation, -170f, -10f), -this.edgetilt * 0.5f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.feebletilt * num, Mathf.Clamp(-165f + this.extraRotation, -170f, -10f), -this.edgetilt * 0.5f)
			};
		}
		if (!this.isledge && !this.sugar)
		{
			array = new Quaternion[]
			{
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.forwardtilt, 0f, 0f),
				Quaternion.LookRotation(-forwardDirection) * Quaternion.Euler(this.forwardtilt, 0f, 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(90f + this.extraRotation, 10f, 170f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(-90f + this.extraRotation, -170f, -10f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(45f + this.extraRotation, 10f, 170f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(135f + this.extraRotation, 10f, 170f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(-45f + this.extraRotation, -170f, -10f), 0f),
				Quaternion.LookRotation(forwardDirection) * Quaternion.Euler(this.edgetilt * num, Mathf.Clamp(-135f + this.extraRotation, -170f, -10f), 0f)
			};
		}
		float num2 = float.MaxValue;
		int num3 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			float num4 = Quaternion.Angle(currentRotation, array[i]);
			if (num4 < num2)
			{
				num2 = num4;
				num3 = i;
			}
		}
		if (!this.isLocked)
		{
			this.lockedRotationIndex = num3;
			this.isLocked = true;
		}
		if (num3 == 1)
		{
			this.is5050 = true;
			this.isFakie5050 = false;
		}
		if (num3 == 0)
		{
			this.is5050 = false;
			this.isFakie5050 = true;
		}
		if (num3 == 2 || num3 == 4 || num3 == 5)
		{
			this.is5050 = false;
			this.isFakie5050 = false;
		}
		if (num3 == 3 || num3 == 6 || num3 == 7)
		{
			this.is5050 = false;
			this.isFakie5050 = false;
		}
		return array[this.lockedRotationIndex];
	}

	// Token: 0x040008E1 RID: 2273
	[Header("Debug")]
	public bool DebugOn;

	// Token: 0x040008E2 RID: 2274
	public bool physicsGrinds;

	// Token: 0x040008E3 RID: 2275
	[Header("Wheels")]
	public WheelCollider frontWheelCollider;

	// Token: 0x040008E4 RID: 2276
	public WheelCollider rearWheelCollider;

	// Token: 0x040008E5 RID: 2277
	[Header("References")]
	public ScooterController scooterController;

	// Token: 0x040008E6 RID: 2278
	public RagdollControl RagdollControl;

	// Token: 0x040008E7 RID: 2279
	public LockRotation lockRotation;

	// Token: 0x040008E8 RID: 2280
	public TrajectoryPrediction trajectoryPrediction;

	// Token: 0x040008E9 RID: 2281
	public AnimationTrigger animationTrigger;

	// Token: 0x040008EA RID: 2282
	public Hop hop;

	// Token: 0x040008EB RID: 2283
	public CharacterStates characterStates;

	// Token: 0x040008EC RID: 2284
	public Animator animator;

	// Token: 0x040008ED RID: 2285
	[Header("Variable Tilts")]
	public float cooldownTimer;

	// Token: 0x040008EE RID: 2286
	public float grindTilt;

	// Token: 0x040008EF RID: 2287
	[Header("Active Pegs")]
	public bool FrontLeftPegActive;

	// Token: 0x040008F0 RID: 2288
	public bool FrontRightPegActive;

	// Token: 0x040008F1 RID: 2289
	public bool BackLeftPegActive;

	// Token: 0x040008F2 RID: 2290
	public bool BackRightPegActive;

	// Token: 0x040008F3 RID: 2291
	public bool hasDeckPegs;

	// Token: 0x040008F4 RID: 2292
	[Header("Main grind bools")]
	public bool blunt;

	// Token: 0x040008F5 RID: 2293
	public bool sugar;

	// Token: 0x040008F6 RID: 2294
	public bool isGrinding;

	// Token: 0x040008F7 RID: 2295
	public bool applyCoolDown;

	// Token: 0x040008F8 RID: 2296
	public bool grindLand;

	// Token: 0x040008F9 RID: 2297
	public bool isledge;

	// Token: 0x040008FA RID: 2298
	[Header("Contact Points")]
	public Transform contactPoint;

	// Token: 0x040008FB RID: 2299
	public Transform bluntPoint;

	// Token: 0x040008FC RID: 2300
	public Transform sugarPoint;

	// Token: 0x040008FD RID: 2301
	public Transform centerPoint;

	// Token: 0x040008FE RID: 2302
	private int playerId;

	// Token: 0x040008FF RID: 2303
	private int lockedRotationIndex = -1;

	// Token: 0x04000900 RID: 2304
	private int currentPointIndex;

	// Token: 0x04000901 RID: 2305
	private Player player;

	// Token: 0x04000902 RID: 2306
	private Rigidbody playerRb;

	// Token: 0x04000903 RID: 2307
	private Transform[] grindPoints;

	// Token: 0x04000904 RID: 2308
	private Transform[] reverseGrindPoints;

	// Token: 0x04000905 RID: 2309
	private Transform tempEndpoint;

	// Token: 0x04000906 RID: 2310
	private Transform railContainertemp;

	// Token: 0x04000907 RID: 2311
	private Quaternion lockedRotation;

	// Token: 0x04000908 RID: 2312
	private Quaternion targetRotation;

	// Token: 0x04000909 RID: 2313
	private Quaternion newRotation;

	// Token: 0x0400090A RID: 2314
	private Vector3 cachedHorizontalVelocity;

	// Token: 0x0400090B RID: 2315
	private Vector3 currentPoint;

	// Token: 0x0400090C RID: 2316
	private Vector3 toNextPoint;

	// Token: 0x0400090D RID: 2317
	private Vector3 correctionalVelocity;

	// Token: 0x0400090E RID: 2318
	private Vector3 closestPointOnLine;

	// Token: 0x0400090F RID: 2319
	private Vector3 nextPoint;

	// Token: 0x04000910 RID: 2320
	[HideInInspector]
	public Vector3 grindDirection;

	// Token: 0x04000911 RID: 2321
	private Vector3 grindDirectionReal;

	// Token: 0x04000912 RID: 2322
	private bool isReverseGrinding;

	// Token: 0x04000913 RID: 2323
	private bool is5050;

	// Token: 0x04000914 RID: 2324
	private bool isFakie5050;

	// Token: 0x04000915 RID: 2325
	private bool landLockOut = true;

	// Token: 0x04000916 RID: 2326
	private bool GrindToLeft;

	// Token: 0x04000917 RID: 2327
	private bool isLocked;

	// Token: 0x04000918 RID: 2328
	private float forwardtilt;

	// Token: 0x04000919 RID: 2329
	private float correctedAngle;

	// Token: 0x0400091A RID: 2330
	private float clampedRailDecay;

	// Token: 0x0400091B RID: 2331
	private float extraRotation;

	// Token: 0x0400091C RID: 2332
	private float targetAngle;

	// Token: 0x0400091D RID: 2333
	private float smoothedAngle;

	// Token: 0x0400091E RID: 2334
	private float offset;

	// Token: 0x0400091F RID: 2335
	private float raildecay;

	// Token: 0x04000920 RID: 2336
	private float LandTimer;

	// Token: 0x04000921 RID: 2337
	private float LandTime = 0.25f;

	// Token: 0x04000922 RID: 2338
	private float edgetilt = 15f;

	// Token: 0x04000923 RID: 2339
	private float feebletilt = 15f;

	// Token: 0x04000924 RID: 2340
	private float grindOffCooldown = 0.25f;

	// Token: 0x04000925 RID: 2341
	public float contactPointAnimVar;
}
