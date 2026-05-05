using System;
using System.Collections;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000176 RID: 374
	public class ResetInteractionObject : MonoBehaviour
	{
		// Token: 0x06000AD8 RID: 2776 RVA: 0x00045408 File Offset: 0x00043608
		private void Start()
		{
			this.defaultPosition = base.transform.position;
			this.defaultRotation = base.transform.rotation;
			this.defaultParent = base.transform.parent;
			this.r = base.GetComponent<Rigidbody>();
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x00045454 File Offset: 0x00043654
		private void OnPickUp(Transform t)
		{
			if (!base.enabled)
			{
				return;
			}
			base.StopAllCoroutines();
			base.StartCoroutine(this.ResetObject(Time.time + this.resetDelay));
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0004547E File Offset: 0x0004367E
		private IEnumerator ResetObject(float resetTime)
		{
			while (Time.time < resetTime)
			{
				yield return null;
			}
			Poser component = base.transform.parent.GetComponent<Poser>();
			if (component != null)
			{
				component.poseRoot = null;
				component.weight = 0f;
			}
			base.transform.parent = this.defaultParent;
			base.transform.position = this.defaultPosition;
			base.transform.rotation = this.defaultRotation;
			if (this.r != null)
			{
				this.r.isKinematic = false;
			}
			yield break;
		}

		// Token: 0x04000AB2 RID: 2738
		public float resetDelay = 1f;

		// Token: 0x04000AB3 RID: 2739
		private Vector3 defaultPosition;

		// Token: 0x04000AB4 RID: 2740
		private Quaternion defaultRotation;

		// Token: 0x04000AB5 RID: 2741
		private Transform defaultParent;

		// Token: 0x04000AB6 RID: 2742
		private Rigidbody r;
	}
}
