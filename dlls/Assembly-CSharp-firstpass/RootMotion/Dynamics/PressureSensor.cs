using System;
using UnityEngine;

namespace RootMotion.Dynamics
{
	// Token: 0x0200005D RID: 93
	public class PressureSensor : MonoBehaviour
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x0000F235 File Offset: 0x0000D435
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x0000F23D File Offset: 0x0000D43D
		public Vector3 center { get; private set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060002AA RID: 682 RVA: 0x0000F246 File Offset: 0x0000D446
		// (set) Token: 0x060002AB RID: 683 RVA: 0x0000F24E File Offset: 0x0000D44E
		public bool inContact { get; private set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060002AC RID: 684 RVA: 0x0000F257 File Offset: 0x0000D457
		// (set) Token: 0x060002AD RID: 685 RVA: 0x0000F25F File Offset: 0x0000D45F
		public Vector3 bottom { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060002AE RID: 686 RVA: 0x0000F268 File Offset: 0x0000D468
		// (set) Token: 0x060002AF RID: 687 RVA: 0x0000F270 File Offset: 0x0000D470
		public Rigidbody r { get; private set; }

		// Token: 0x060002B0 RID: 688 RVA: 0x0000F279 File Offset: 0x0000D479
		private void Awake()
		{
			this.r = base.GetComponent<Rigidbody>();
			this.center = base.transform.position;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000F298 File Offset: 0x0000D498
		private void OnCollisionEnter(Collision c)
		{
			this.ProcessCollision(c);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000F298 File Offset: 0x0000D498
		private void OnCollisionStay(Collision c)
		{
			this.ProcessCollision(c);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000F2A1 File Offset: 0x0000D4A1
		private void OnCollisionExit(Collision c)
		{
			this.inContact = false;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000F2AA File Offset: 0x0000D4AA
		private void FixedUpdate()
		{
			this.fixedFrame = true;
			if (!this.r.IsSleeping())
			{
				this.P = Vector3.zero;
				this.count = 0;
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000F2D2 File Offset: 0x0000D4D2
		private void LateUpdate()
		{
			if (this.fixedFrame)
			{
				if (this.count > 0)
				{
					this.center = this.P / (float)this.count;
				}
				this.fixedFrame = false;
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000F304 File Offset: 0x0000D504
		private void ProcessCollision(Collision c)
		{
			if (!LayerMaskExtensions.Contains(this.layers, c.gameObject.layer))
			{
				return;
			}
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < c.contacts.Length; i++)
			{
				vector += c.contacts[i].point;
			}
			vector /= (float)c.contacts.Length;
			this.P += vector;
			this.count++;
			this.inContact = true;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000F392 File Offset: 0x0000D592
		private void OnDrawGizmos()
		{
			if (!this.visualize)
			{
				return;
			}
			Gizmos.DrawSphere(this.center, 0.1f);
		}

		// Token: 0x04000279 RID: 633
		public bool visualize;

		// Token: 0x0400027A RID: 634
		public LayerMask layers;

		// Token: 0x0400027F RID: 639
		private bool fixedFrame;

		// Token: 0x04000280 RID: 640
		private Vector3 P;

		// Token: 0x04000281 RID: 641
		private int count;
	}
}
