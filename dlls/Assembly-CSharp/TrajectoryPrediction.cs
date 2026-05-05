using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000160 RID: 352
public class TrajectoryPrediction : MonoBehaviour
{
	// Token: 0x060005A9 RID: 1449 RVA: 0x00028835 File Offset: 0x00026A35
	private void FixedUpdate()
	{
		if (this.characterStates.currentState == CharacterState.Idle)
		{
			this.predictionAllowed = true;
			return;
		}
		this.predictionAllowed = false;
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x00028854 File Offset: 0x00026A54
	private void Update()
	{
		if (this.predictionAllowed)
		{
			this.animator.SetBool("IsGroingToGrind", this.IsGroingToGrind);
			if (!this.IsGroingToGrind && !this.scooterController.isGrounded && !this.predictionDone)
			{
				this.PredictLanding();
				this.landCorrection.UpdateLandRotation();
				Vector3 boxSize = new Vector3(0.25f, 0.25f, 0.25f);
				LayerMask layerMask = LayerMask.GetMask(new string[]
				{
					"Default"
				});
				LayerMask.GetMask(new string[]
				{
					"Coping"
				});
				if (this.BoxcastAtPoint(this.closestPoint, boxSize, layerMask))
				{
					this.grindSystem.isledge = true;
				}
				else
				{
					this.grindSystem.isledge = false;
				}
				if (!this.IsApproachingFromOutside() && this.IsParallelToRailSegment() && this.grindSystem.isledge)
				{
					if (this.DebugOn)
					{
						Debug.Log("Ledge conditions met stopping grind");
					}
					this.stopPrediction();
				}
				if (!this.predictionDone && this.IsGroingToGrind)
				{
					this.RedirectVelocityTowardPoint();
				}
				this.predictionDone = true;
			}
			if (this.scooterController.isGrounded && !this.grindSystem.isGrinding)
			{
				this.predictionDone = false;
				this.IsGroingToGrind = false;
				this.smoothAnimAngle = false;
			}
			else if (Vector3.Distance(this.grindSystem.contactPoint.position, this.closestPoint) > 0.25f && this.grindSystem.cooldownTimer <= 0.025f && this.IsGroingToGrind && !this.grindSystem.isGrinding)
			{
				this.targetAngle = this.CalculateAngleRelativeToPoint(this.closestPoint);
				float @float = this.animator.GetFloat("Angle");
				this.smoothedAngle = Mathf.LerpAngle(@float, this.targetAngle, 7.5f * Time.deltaTime);
				this.smoothedAngle = Mathf.Repeat(this.smoothedAngle, 360f);
				this.animator.SetFloat("Angle", this.smoothedAngle);
			}
			float b = this.IsGroingToGrind ? 1f : -1f;
			this.grindValue = Mathf.Lerp(this.grindValue, b, this.lerpSpeed * Time.deltaTime);
			this.animator.SetFloat("GrindValue", this.grindValue, 0.15f, Time.deltaTime);
			if (this.grindSystem.isGrinding)
			{
				this.smoothAnimAngle = false;
			}
		}
		if (this.animationTrigger.lastGrindDirVertical > 0.4f)
		{
			this.grindSystem.blunt = true;
		}
		if (this.animationTrigger.lastGrindDirVertical < -0.4f)
		{
			this.grindSystem.sugar = true;
		}
		if (this.animationTrigger.lastGrindDirVertical > -0.4f && this.animationTrigger.lastGrindDirVertical < 0.4f)
		{
			this.grindSystem.blunt = false;
			this.grindSystem.sugar = false;
		}
		if (this.grindSystem.blunt)
		{
			this.grindSystem.contactPoint = this.grindSystem.bluntPoint;
		}
		else if (this.grindSystem.sugar)
		{
			this.grindSystem.contactPoint = this.grindSystem.sugarPoint;
		}
		else if (!this.grindSystem.blunt && !this.grindSystem.sugar)
		{
			this.grindSystem.contactPoint = this.grindSystem.centerPoint;
		}
		if (this.grindSystem.contactPoint != null && !this.scooterController.isGrounded && this.IsGroingToGrind)
		{
			Vector3 localPosition = this.grindSystem.contactPoint.localPosition;
			if (localPosition != this.lastContactPoint)
			{
				this.lastContactPoint = localPosition;
				this.RedirectVelocityTowardPoint();
				if (this.DebugOn)
				{
					Debug.Log("Changing Contact - redirecting Velocity");
				}
			}
		}
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x00028C30 File Offset: 0x00026E30
	private List<GameObject> FindNearbyRails(Vector3 point)
	{
		Collider[] array = Physics.OverlapCapsule(point + Vector3.down * 1.5f, point + Vector3.up * 1.5f, this.railCheckRadius);
		List<GameObject> list = new List<GameObject>();
		foreach (Collider collider in array)
		{
			if (collider.CompareTag("Rail") && !list.Contains(collider.gameObject))
			{
				list.Add(collider.gameObject);
			}
		}
		return list;
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x00028CB3 File Offset: 0x00026EB3
	public void stopPrediction()
	{
		this.predictionDone = true;
		this.IsGroingToGrind = false;
		this.smoothAnimAngle = false;
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x00028CCC File Offset: 0x00026ECC
	private bool IsApproachingFromOutside()
	{
		GameObject gameObject = this.FindNearestRail(this.closestPoint);
		if (gameObject == null)
		{
			return false;
		}
		Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
		Vector3 b = Vector3.zero;
		Vector3 a = Vector3.zero;
		float num = float.MaxValue;
		for (int i = 0; i < componentsInChildren.Length - 1; i++)
		{
			if (componentsInChildren[i].name.Contains("Point_") && componentsInChildren[i + 1].name.Contains("Point_"))
			{
				Vector3 position = componentsInChildren[i].position;
				Vector3 position2 = componentsInChildren[i + 1].position;
				Vector3 b2 = this.ClosestPointOnSegment(position, position2, this.closestPoint);
				float num2 = Vector3.Distance(this.closestPoint, b2);
				if (num2 < num)
				{
					num = num2;
					b = position;
					a = position2;
				}
			}
		}
		if (num == 3.4028235E+38f)
		{
			return false;
		}
		Vector3 normalized = Vector3.Cross((a - b).normalized, Vector3.up).normalized;
		return Vector3.Dot(this.grindSystem.contactPoint.position - this.closestPoint, normalized) > 0f;
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x00028DF0 File Offset: 0x00026FF0
	public bool IsParallelToRailSegment()
	{
		GameObject gameObject = this.FindNearestRail(this.closestPoint);
		if (gameObject == null)
		{
			return false;
		}
		Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
		Vector3 b = Vector3.zero;
		Vector3 a = Vector3.zero;
		float num = float.MaxValue;
		for (int i = 0; i < componentsInChildren.Length - 1; i++)
		{
			if (componentsInChildren[i].name.Contains("Point_") && componentsInChildren[i + 1].name.Contains("Point_"))
			{
				Vector3 position = componentsInChildren[i].position;
				Vector3 position2 = componentsInChildren[i + 1].position;
				Vector3 b2 = this.ClosestPointOnSegment(position, position2, this.closestPoint);
				float num2 = Vector3.Distance(this.closestPoint, b2);
				if (num2 < num)
				{
					num = num2;
					b = position;
					a = position2;
				}
			}
		}
		if (num == 3.4028235E+38f)
		{
			return false;
		}
		Vector3 normalized = (a - b).normalized;
		Vector3 normalized2 = this.grindSystem.contactPoint.forward.normalized;
		float num3 = Vector3.Angle(normalized2, normalized);
		Debug.DrawRay(this.closestPoint, normalized * 1.5f, Color.white);
		Debug.DrawRay(this.grindSystem.contactPoint.position, normalized2 * 1.5f, Color.yellow);
		return num3 <= 30f || num3 >= 150f;
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x00028F58 File Offset: 0x00027158
	private float CalculateAngleRelativeToPoint(Vector3 targetPoint)
	{
		Vector3 normalized = (targetPoint - this.grindSystem.contactPoint.position).normalized;
		normalized.y = 0f;
		Vector3 forward = this.grindSystem.contactPoint.forward;
		forward.y = 0f;
		float num = Vector3.SignedAngle(forward, normalized, Vector3.up);
		if (num < 0f)
		{
			num += 360f;
		}
		return num;
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x00028FCC File Offset: 0x000271CC
	public void PredictLanding()
	{
		List<Vector3> list = new List<Vector3>();
		Vector3 position = this.rb.position;
		Vector3 a = this.rb.velocity;
		Vector3 gravity = Physics.gravity;
		this.previousPosition = position;
		list.Add(position);
		float y = position.y;
		float num = y;
		float num2 = y;
		float num3 = 0f;
		while (num3 < this.maxPredictionTime)
		{
			this.nextPosition = position + a * this.segmentSize + 0.5f * gravity * this.segmentSize * this.segmentSize;
			list.Add(this.nextPosition);
			if (!this.predictionDone && this.nextPosition.y > num)
			{
				num = this.nextPosition.y;
			}
			Vector3 normalized = (this.nextPosition - this.previousPosition).normalized;
			float maxDistance = Vector3.Distance(this.previousPosition, this.nextPosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(this.previousPosition, normalized, out raycastHit, maxDistance, this.groundLayer))
			{
				this.landPoint = raycastHit.point;
				this.landNormal = raycastHit.normal;
				num2 = this.landPoint.y;
				if (this.FindNearestRail(this.landPoint) != null)
				{
					if (this.DebugOn)
					{
						Debug.Log("Found rail near landing point.");
					}
					List<GameObject> list2 = this.FindNearbyRails(this.landPoint);
					if (list2.Count > 0)
					{
						this.ProcessRail(list2);
					}
				}
				if (!this.predictionDone)
				{
					float num4 = (y + num2) / 2f;
					this.relativeHighestPoint = num - num4;
					break;
				}
				break;
			}
			else
			{
				this.previousPosition = this.nextPosition;
				position = this.nextPosition;
				a += gravity * this.segmentSize;
				num3 += this.segmentSize;
			}
		}
		if (!this.predictionDone)
		{
			float num4 = (y + num2) / 2f;
			this.relativeHighestPoint = num - num4;
		}
		this.trajectoryPoints = list.ToArray();
		this.DrawArc(this.trajectoryPoints);
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x000291F0 File Offset: 0x000273F0
	private void DrawArc(Vector3[] points)
	{
		for (int i = 0; i < points.Length - 1; i++)
		{
			Debug.DrawLine(points[i], points[i + 1], Color.green, 2f, false);
		}
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x0002922D File Offset: 0x0002742D
	public bool BoxcastAtPoint(Vector3 point, Vector3 boxSize, LayerMask layerMask)
	{
		return Physics.OverlapBox(point, boxSize / 2f, Quaternion.identity, layerMask).Length != 0;
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x00029250 File Offset: 0x00027450
	private GameObject FindNearestRail(Vector3 point)
	{
		foreach (Collider collider in Physics.OverlapCapsule(point + Vector3.down * 1.5f, point + Vector3.up * 1.5f, this.railCheckRadius))
		{
			if (collider.CompareTag("Rail"))
			{
				return collider.gameObject;
			}
		}
		return null;
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x000292BC File Offset: 0x000274BC
	public void ProcessRail(List<GameObject> rails)
	{
		this.closestPoint = Vector3.zero;
		float num = float.MaxValue;
		bool flag = false;
		foreach (GameObject gameObject in rails)
		{
			Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
			List<List<Transform>> list = new List<List<Transform>>();
			List<Transform> list2 = new List<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				if (transform.name.Contains("Point_"))
				{
					if (transform.name.EndsWith("1") && list2.Count > 0)
					{
						list.Add(new List<Transform>(list2));
						list2.Clear();
					}
					list2.Add(transform);
				}
			}
			if (list2.Count > 0)
			{
				list.Add(new List<Transform>(list2));
			}
			foreach (List<Transform> list3 in list)
			{
				for (int j = 0; j < list3.Count - 1; j++)
				{
					Vector3 position = list3[j].position;
					Vector3 position2 = list3[j + 1].position;
					Vector3 normalized = (position2 - position).normalized;
					Vector3 normalized2 = this.rb.velocity.normalized;
					Vector3 normalized3 = new Vector3(normalized.x, 0f, normalized.z).normalized;
					Vector3 normalized4 = new Vector3(normalized2.x, 0f, normalized2.z).normalized;
					if (Mathf.Abs(Vector3.Angle(normalized3, normalized4) - 90f) > 30f)
					{
						Debug.DrawLine(position, position2, Color.yellow, 2f);
						Vector3 vector = this.ClosestPointOnSegment(position, position2, this.landPoint);
						if (Mathf.Abs(vector.x - this.landPoint.x) <= this.railCheckRadius && Mathf.Abs(vector.z - this.landPoint.z) <= this.railCheckRadius)
						{
							flag = true;
							float num2 = Vector3.Distance(this.landPoint, vector);
							if (num2 < num)
							{
								num = num2;
								this.closestPoint = vector;
								Vector3 normalized5 = (position2 - position).normalized;
								Vector3 correctedSegmentNormal = this.GetCorrectedSegmentNormal(position, position2, base.transform);
								this.newland = correctedSegmentNormal;
							}
						}
					}
				}
			}
		}
		if (!flag || num == 3.4028235E+38f)
		{
			return;
		}
		this.IsGroingToGrind = true;
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x00029594 File Offset: 0x00027794
	private void RedirectVelocityTowardPoint()
	{
		Vector3 vector = this.closestPoint - this.grindSystem.contactPoint.position;
		vector.y = 0f;
		vector.Normalize();
		float f = Vector3.Dot(new Vector3(this.rb.velocity.x, 0f, this.rb.velocity.z).normalized, vector);
		Vector3 normalized = this.rb.velocity.normalized;
		Vector3 rhs = this.closestPoint - this.rb.position;
		if (Vector3.Dot(normalized, rhs) >= 0f && Vector3.Distance(this.rb.position, this.closestPoint) > 0.25f)
		{
			if (Mathf.Acos(f) * 57.29578f <= 60f)
			{
				float magnitude = new Vector3(this.rb.velocity.x, 0f, this.rb.velocity.z).magnitude;
				this.rb.velocity = new Vector3(vector.x * magnitude, this.rb.velocity.y, vector.z * magnitude);
				this.landNormal = this.newland;
				this.landCorrection.UpdateLandRotation();
				return;
			}
		}
		else if (this.DebugOn)
		{
			Debug.Log("Player contact point passed closest predicted point");
		}
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x0002970C File Offset: 0x0002790C
	private Vector3 ClosestPointOnSegment(Vector3 start, Vector3 end, Vector3 point)
	{
		Vector3 vector = end - start;
		float num = Vector3.Dot(point - start, vector) / Vector3.Dot(vector, vector);
		num = Mathf.Clamp01(num);
		return start + num * vector;
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x0002974C File Offset: 0x0002794C
	private Vector3 GetCorrectedSegmentNormal(Vector3 segmentStart, Vector3 segmentEnd, Transform reference)
	{
		Vector3 vector = (segmentEnd - segmentStart).normalized;
		Vector3 normalized = Vector3.Cross(Vector3.up, vector).normalized;
		Vector3 normalized2 = Vector3.Cross(vector, normalized).normalized;
		if (Vector3.Dot(Quaternion.LookRotation(vector, normalized2) * Vector3.forward, reference.forward) < 0f)
		{
			vector = -vector;
			normalized = Vector3.Cross(Vector3.up, vector).normalized;
			normalized2 = Vector3.Cross(vector, normalized).normalized;
		}
		return normalized2;
	}

	// Token: 0x0400093B RID: 2363
	[Header("Debug")]
	public bool DebugOn;

	// Token: 0x0400093C RID: 2364
	[Header("Player Rigidbody")]
	public Rigidbody rb;

	// Token: 0x0400093D RID: 2365
	[Header("Layers")]
	public LayerMask groundLayer;

	// Token: 0x0400093E RID: 2366
	[Header("Land Information")]
	public Vector3 landPoint;

	// Token: 0x0400093F RID: 2367
	public Vector3 landNormal;

	// Token: 0x04000940 RID: 2368
	[Header("Main Bools")]
	public bool IsGroingToGrind;

	// Token: 0x04000941 RID: 2369
	public bool predictionDone;

	// Token: 0x04000942 RID: 2370
	public bool smoothAnimAngle;

	// Token: 0x04000943 RID: 2371
	private Vector3[] trajectoryPoints;

	// Token: 0x04000944 RID: 2372
	private Vector3 closestPoint;

	// Token: 0x04000945 RID: 2373
	private float grindValue = -1f;

	// Token: 0x04000946 RID: 2374
	private float lerpSpeed = 5f;

	// Token: 0x04000947 RID: 2375
	[Header("References")]
	public Animator animator;

	// Token: 0x04000948 RID: 2376
	public ScooterController scooterController;

	// Token: 0x04000949 RID: 2377
	public GrindSystem grindSystem;

	// Token: 0x0400094A RID: 2378
	public CharacterStates characterStates;

	// Token: 0x0400094B RID: 2379
	public LandCorrection landCorrection;

	// Token: 0x0400094C RID: 2380
	public AnimationTrigger animationTrigger;

	// Token: 0x0400094D RID: 2381
	[Header("Height Information")]
	public float relativeHighestPoint;

	// Token: 0x0400094E RID: 2382
	private Vector3 newland;

	// Token: 0x0400094F RID: 2383
	private Vector3 nextPosition;

	// Token: 0x04000950 RID: 2384
	private Vector3 previousPosition;

	// Token: 0x04000951 RID: 2385
	private bool predictionAllowed;

	// Token: 0x04000952 RID: 2386
	private float smoothedAngle;

	// Token: 0x04000953 RID: 2387
	private float targetAngle;

	// Token: 0x04000954 RID: 2388
	private float railCheckRadius = 0.35f;

	// Token: 0x04000955 RID: 2389
	private float segmentSize = 0.2f;

	// Token: 0x04000956 RID: 2390
	private float maxPredictionTime = 10f;

	// Token: 0x04000957 RID: 2391
	private Vector3 lastContactPoint;
}
