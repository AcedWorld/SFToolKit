using System;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class vPingPongRotation : MonoBehaviour
{
	// Token: 0x060000CC RID: 204 RVA: 0x000084AB File Offset: 0x000066AB
	private void Start()
	{
		if (this.targetTransform == null)
		{
			this.targetTransform = base.transform;
		}
		this.defaultLocalForward = this.targetTransform.parent.InverseTransformDirection(this.targetTransform.forward);
	}

	// Token: 0x060000CD RID: 205 RVA: 0x000084E8 File Offset: 0x000066E8
	private void OnEnable()
	{
		this.evaluateToDirection = 0f;
	}

	// Token: 0x060000CE RID: 206 RVA: 0x000084E8 File Offset: 0x000066E8
	public void Reset()
	{
		this.evaluateToDirection = 0f;
	}

	// Token: 0x060000CF RID: 207 RVA: 0x000084F8 File Offset: 0x000066F8
	private void Update()
	{
		Vector3 vector = this.targetTransform.parent.TransformDirection(this.defaultLocalForward);
		if (this.angleX.magnitude > 0f)
		{
			this.pingPongTime.x = Time.time * this.speed.x;
		}
		if (this.angleY.magnitude > 0f)
		{
			this.pingPongTime.y = Time.time * this.speed.y;
		}
		if (this.angleZ.magnitude > 0f)
		{
			this.pingPongTime.z = Time.time * this.speed.z;
		}
		if (this.evaluateToDirection < 1f)
		{
			this.evaluateToDirection += Time.deltaTime * this.speed.magnitude;
		}
		else
		{
			this.evaluateToDirection = 1f;
		}
		if (this.angleX.magnitude > 0f)
		{
			this.evaluate.x = Mathf.PingPong(this.pingPongTime.x, 1f);
		}
		if (this.angleY.magnitude > 0f)
		{
			this.evaluate.y = Mathf.PingPong(this.pingPongTime.y, 1f);
		}
		if (this.angleZ.magnitude > 0f)
		{
			this.pingPongTime.z = Time.time * this.speed.z;
		}
		this.evaluate.z = Mathf.PingPong(this.pingPongTime.z, 1f);
		if (this.angleX.magnitude > 0f)
		{
			this.euler.x = Mathf.Lerp(this.angleX.x, this.angleX.y, this.evaluate.x);
		}
		if (this.angleY.magnitude > 0f)
		{
			this.euler.y = Mathf.Lerp(this.angleY.x, this.angleY.y, this.evaluate.y);
		}
		if (this.angleZ.magnitude > 0f)
		{
			this.pingPongTime.z = Time.time * this.speed.z;
		}
		this.euler.z = Mathf.Lerp(this.angleZ.x, this.angleZ.y, this.evaluate.z);
		this.targetTransform.forward = Vector3.Lerp(vector, Quaternion.Euler(this.euler) * vector, this.evaluateToDirection);
	}

	// Token: 0x04000114 RID: 276
	[vHelpBox("This Component needs to be child of a root transform", vHelpBoxAttribute.MessageType.None)]
	[vMinMax(-180f, 180f)]
	public Vector2 angleX;

	// Token: 0x04000115 RID: 277
	[vMinMax(-180f, 180f)]
	public Vector2 angleY;

	// Token: 0x04000116 RID: 278
	[vMinMax(-180f, 180f)]
	public Vector2 angleZ;

	// Token: 0x04000117 RID: 279
	public Vector3 speed = Vector3.one;

	// Token: 0x04000118 RID: 280
	private Vector3 pingPongTime;

	// Token: 0x04000119 RID: 281
	private Vector3 euler;

	// Token: 0x0400011A RID: 282
	private float evaluateToDirection;

	// Token: 0x0400011B RID: 283
	private Vector3 defaultLocalForward;

	// Token: 0x0400011C RID: 284
	public Transform targetTransform;

	// Token: 0x0400011D RID: 285
	private Vector3 evaluate;
}
