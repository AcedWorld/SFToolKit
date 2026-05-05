using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x020001AE RID: 430
	public class PuppetBoard : MonoBehaviour
	{
		// Token: 0x06000BB1 RID: 2993 RVA: 0x00048961 File Offset: 0x00046B61
		private void Start()
		{
			this.r = base.GetComponent<Rigidbody>();
			Physics.IgnoreLayerCollision(base.gameObject.layer, this.target.gameObject.layer, true);
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x00048990 File Offset: 0x00046B90
		private void FixedUpdate()
		{
			this.r.MovePosition(this.target.position);
			this.r.MoveRotation(this.target.rotation);
			this.r.velocity = this.target.velocity;
			this.r.angularVelocity = this.target.angularVelocity;
			Quaternion lhs = Quaternion.FromToRotation(this.bodyTarget.position - base.transform.position, Vector3.up);
			this.bodyTargetPivot.rotation = lhs * this.bodyTarget.rotation;
		}

		// Token: 0x04000BBD RID: 3005
		[Tooltip("Board target Rigidbody.")]
		public Rigidbody target;

		// Token: 0x04000BBE RID: 3006
		[Tooltip("Pivot Transform of the body target.")]
		public Transform bodyTargetPivot;

		// Token: 0x04000BBF RID: 3007
		[Tooltip("The body target keeps the puppet upright by a SpringJoint connected to the body.")]
		public Transform bodyTarget;

		// Token: 0x04000BC0 RID: 3008
		private Rigidbody r;
	}
}
