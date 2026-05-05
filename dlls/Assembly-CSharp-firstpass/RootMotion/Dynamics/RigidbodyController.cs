using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x02000081 RID: 129
	public class RigidbodyController : MonoBehaviour
	{
		// Token: 0x06000422 RID: 1058 RVA: 0x00018A43 File Offset: 0x00016C43
		public void OnTargetTeleported()
		{
			this.lastTargetPos = this.target.position;
			this.lastTargetRot = this.target.rotation;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00018A67 File Offset: 0x00016C67
		private void Start()
		{
			this.r = base.GetComponent<Rigidbody>();
			this.OnTargetTeleported();
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00018A7C File Offset: 0x00016C7C
		private void FixedUpdate()
		{
			Vector3 b = Vector3.zero;
			Vector3 b2 = Vector3.zero;
			if (this.useTargetVelocity)
			{
				b = (this.target.position - this.lastTargetPos) / Time.deltaTime;
				b2 = PhysXTools.GetAngularVelocity(this.lastTargetRot, this.target.rotation, Time.deltaTime);
			}
			this.lastTargetPos = this.target.position;
			this.lastTargetRot = this.target.rotation;
			Vector3 vector = PhysXTools.GetLinearAcceleration(this.r.position, this.target.position);
			vector += b;
			vector -= this.r.velocity;
			if (this.r.useGravity)
			{
				vector -= Physics.gravity * Time.deltaTime;
			}
			vector *= this.forceWeight;
			this.r.AddForce(vector, ForceMode.VelocityChange);
			Vector3 vector2 = PhysXTools.GetAngularAcceleration(this.r.rotation, this.target.rotation);
			vector2 += b2;
			vector2 -= this.r.angularVelocity;
			vector2 *= this.torqueWeight;
			this.r.AddTorque(vector2, ForceMode.VelocityChange);
		}

		// Token: 0x040003AD RID: 941
		public Transform target;

		// Token: 0x040003AE RID: 942
		[Range(0f, 1f)]
		public float forceWeight = 1f;

		// Token: 0x040003AF RID: 943
		[Range(0f, 1f)]
		public float torqueWeight = 1f;

		// Token: 0x040003B0 RID: 944
		public bool useTargetVelocity = true;

		// Token: 0x040003B1 RID: 945
		private Rigidbody r;

		// Token: 0x040003B2 RID: 946
		private Vector3 lastTargetPos;

		// Token: 0x040003B3 RID: 947
		private Quaternion lastTargetRot = Quaternion.identity;
	}
}
