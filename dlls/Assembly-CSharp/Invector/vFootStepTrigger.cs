using System;
using UnityEngine;
using UnityEngine.Events;

namespace Invector
{
	// Token: 0x02000345 RID: 837
	public class vFootStepTrigger : MonoBehaviour
	{
		// Token: 0x06001137 RID: 4407 RVA: 0x0005D494 File Offset: 0x0005B694
		private void OnDrawGizmos()
		{
			if (!this.trigger)
			{
				return;
			}
			Color green = Color.green;
			green.a = 0.5f;
			Gizmos.color = green;
			if (this.trigger is SphereCollider)
			{
				Gizmos.DrawSphere(this.trigger.bounds.center, (this.trigger as SphereCollider).radius);
			}
		}

		// Token: 0x06001138 RID: 4408 RVA: 0x0005D4FC File Offset: 0x0005B6FC
		private void Start()
		{
			this._fT = base.GetComponentInParent<vFootStepBase>();
			Rigidbody component = base.gameObject.GetComponent<Rigidbody>();
			if (component == null)
			{
				base.gameObject.AddComponent<Rigidbody>().isKinematic = true;
			}
			else
			{
				component.isKinematic = true;
			}
			if (this._fT == null)
			{
				Debug.Log(base.gameObject.name + " can't find the FootStepFromTexture");
				base.gameObject.SetActive(false);
				return;
			}
			foreach (Collider collider in this._fT.gameObject.GetComponentsInChildren<Collider>(true))
			{
				if (collider != null && collider.gameObject != this.trigger.gameObject)
				{
					Physics.IgnoreCollision(collider, this.trigger, true);
				}
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06001139 RID: 4409 RVA: 0x0005D5CB File Offset: 0x0005B7CB
		public Collider trigger
		{
			get
			{
				if (this._trigger == null)
				{
					this._trigger = base.gameObject.GetComponent<Collider>();
				}
				return this._trigger;
			}
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x0005D5F4 File Offset: 0x0005B7F4
		private void OnTriggerEnter(Collider other)
		{
			if (this._fT == null)
			{
				return;
			}
			if (this.lastCollider == null || this.lastCollider != other || this.footstepObj == null)
			{
				this.footstepObj = new FootStepObject(base.transform, other);
				this.lastCollider = other;
			}
			if (this.footstepObj.isTerrain)
			{
				this._fT.StepOnTerrain(this.footstepObj);
				this.OnStep.Invoke();
				return;
			}
			this._fT.StepOnMesh(this.footstepObj);
			this.OnStep.Invoke();
		}

		// Token: 0x04001715 RID: 5909
		protected Collider _trigger;

		// Token: 0x04001716 RID: 5910
		protected vFootStepBase _fT;

		// Token: 0x04001717 RID: 5911
		public UnityEvent OnStep;

		// Token: 0x04001718 RID: 5912
		protected Collider lastCollider;

		// Token: 0x04001719 RID: 5913
		internal FootStepObject footstepObj;
	}
}
