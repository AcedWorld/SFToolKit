using System;
using RootMotion.Dynamics;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200018F RID: 399
	public class BoardController : MonoBehaviour
	{
		// Token: 0x06000B32 RID: 2866 RVA: 0x00046FD1 File Offset: 0x000451D1
		private void Awake()
		{
			this.r = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x00046FE0 File Offset: 0x000451E0
		private void Update()
		{
			float axis = Input.GetAxis("Horizontal");
			this.rotationTarget.rotation = Quaternion.AngleAxis(axis * this.turnSensitivity * Mathf.Min(this.r.velocity.sqrMagnitude * 0.2f, 1f) * Time.deltaTime, Vector3.up) * this.rotationTarget.rotation;
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x00047050 File Offset: 0x00045250
		private void FixedUpdate()
		{
			Vector3 angularAcceleration = PhysXTools.GetAngularAcceleration(this.r.rotation, this.rotationTarget.rotation);
			this.r.AddTorque(angularAcceleration * this.torque);
			if (this.isGrounded)
			{
				Vector3 velocity = this.r.velocity;
				Vector3 a = V3Tools.ExtractHorizontal(velocity, this.r.rotation * Vector3.up, 1f);
				a = Vector3.Project(velocity, this.r.rotation * Vector3.right);
				this.r.velocity = velocity - Vector3.ClampMagnitude(a * this.skidDrag * Time.deltaTime, a.magnitude);
			}
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x00047114 File Offset: 0x00045314
		private void OnCollisionEnter(Collision c)
		{
			if (c.collider.gameObject.layer != this.groundLayer)
			{
				return;
			}
			this.isGrounded = true;
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x00047114 File Offset: 0x00045314
		private void OnCollisionStay(Collision c)
		{
			if (c.collider.gameObject.layer != this.groundLayer)
			{
				return;
			}
			this.isGrounded = true;
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x00047136 File Offset: 0x00045336
		private void OnCollisionExit(Collision c)
		{
			if (c.collider.gameObject.layer != this.groundLayer)
			{
				return;
			}
			this.isGrounded = false;
		}

		// Token: 0x04000B32 RID: 2866
		public int groundLayer = 4;

		// Token: 0x04000B33 RID: 2867
		public Transform rotationTarget;

		// Token: 0x04000B34 RID: 2868
		public float torque = 1f;

		// Token: 0x04000B35 RID: 2869
		public float skidDrag = 0.5f;

		// Token: 0x04000B36 RID: 2870
		public float turnSensitivity = 15f;

		// Token: 0x04000B37 RID: 2871
		private Rigidbody r;

		// Token: 0x04000B38 RID: 2872
		private bool isGrounded;
	}
}
