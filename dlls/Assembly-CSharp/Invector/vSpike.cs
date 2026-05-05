using System;
using Invector.vCharacterController;
using UnityEngine;

namespace Invector
{
	// Token: 0x020003A9 RID: 937
	public class vSpike : MonoBehaviour
	{
		// Token: 0x060012C6 RID: 4806 RVA: 0x0006361C File Offset: 0x0006181C
		private void Start()
		{
			this.joint = base.GetComponent<HingeJoint>();
		}

		// Token: 0x060012C7 RID: 4807 RVA: 0x0006362C File Offset: 0x0006182C
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.rigidbody != null && collision.collider.GetComponent<vDamageReceiver>() != null && !this.inConect)
			{
				bool flag = this.control == null || !this.control.attachColliders.Contains(collision.collider.transform);
				if (this.control)
				{
					this.control.attachColliders.Add(collision.collider.transform);
				}
				if (flag)
				{
					this.inConect = true;
					if (this.joint && collision.rigidbody)
					{
						this.joint.connectedBody = collision.rigidbody;
					}
					this.impaled = collision.transform;
					Rigidbody[] componentsInChildren = collision.transform.root.GetComponentsInChildren<Rigidbody>();
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						componentsInChildren[i].velocity = Vector3.zero;
					}
					vDamageReceiver component = collision.collider.GetComponent<vDamageReceiver>();
					if (component && component.ragdoll && component.ragdoll.iChar != null)
					{
						component.ragdoll.iChar.ChangeHealth((int)(-(int)component.ragdoll.iChar.currentHealth));
					}
				}
			}
		}

		// Token: 0x060012C8 RID: 4808 RVA: 0x00063784 File Offset: 0x00061984
		private void OnTriggerExit(Collider other)
		{
			if (other.transform != null && this.impaled != null && other.transform == this.impaled)
			{
				if (this.joint)
				{
					this.joint.connectedBody = null;
				}
				this.impaled = null;
				if (this.control != null && this.control.attachColliders.Contains(this.impaled))
				{
					this.control.attachColliders.Remove(this.impaled);
				}
				this.inConect = false;
			}
		}

		// Token: 0x040018A0 RID: 6304
		private HingeJoint joint;

		// Token: 0x040018A1 RID: 6305
		[HideInInspector]
		public vSpikeControl control;

		// Token: 0x040018A2 RID: 6306
		private bool inConect;

		// Token: 0x040018A3 RID: 6307
		private Transform impaled;
	}
}
