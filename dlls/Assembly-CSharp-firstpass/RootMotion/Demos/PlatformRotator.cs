using System;
using System.Collections;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000180 RID: 384
	public class PlatformRotator : MonoBehaviour
	{
		// Token: 0x06000B06 RID: 2822 RVA: 0x00046230 File Offset: 0x00044430
		private void Start()
		{
			this.defaultRotation = base.transform.rotation;
			this.targetPosition = base.transform.position + this.movePosition;
			this.r = base.GetComponent<Rigidbody>();
			base.StartCoroutine(this.SwitchRotation());
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00046284 File Offset: 0x00044484
		private void FixedUpdate()
		{
			this.r.MovePosition(Vector3.SmoothDamp(this.r.position, this.targetPosition, ref this.velocity, 1f, this.moveSpeed));
			if (Vector3.Distance(base.GetComponent<Rigidbody>().position, this.targetPosition) < 0.1f)
			{
				this.movePosition = -this.movePosition;
				this.targetPosition += this.movePosition;
			}
			this.r.MoveRotation(Quaternion.RotateTowards(this.r.rotation, this.targetRotation, this.rotationSpeed * Time.deltaTime));
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00046335 File Offset: 0x00044535
		private IEnumerator SwitchRotation()
		{
			for (;;)
			{
				float angle = Random.Range(-this.maxAngle, this.maxAngle);
				Vector3 onUnitSphere = Random.onUnitSphere;
				this.targetRotation = Quaternion.AngleAxis(angle, onUnitSphere) * this.defaultRotation;
				yield return new WaitForSeconds(this.switchRotationTime + Random.value * this.random);
			}
			yield break;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x00046344 File Offset: 0x00044544
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.layer == this.characterLayer)
			{
				CharacterThirdPerson component = collision.gameObject.GetComponent<CharacterThirdPerson>();
				if (component == null)
				{
					return;
				}
				if (component.smoothPhysics)
				{
					component.smoothPhysics = false;
				}
			}
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0004638C File Offset: 0x0004458C
		private void OnCollisionExit(Collision collision)
		{
			if (collision.gameObject.layer == this.characterLayer)
			{
				CharacterThirdPerson component = collision.gameObject.GetComponent<CharacterThirdPerson>();
				if (component == null)
				{
					return;
				}
				component.smoothPhysics = true;
			}
		}

		// Token: 0x04000AE7 RID: 2791
		public float maxAngle = 70f;

		// Token: 0x04000AE8 RID: 2792
		public float switchRotationTime = 0.5f;

		// Token: 0x04000AE9 RID: 2793
		public float random = 0.5f;

		// Token: 0x04000AEA RID: 2794
		public float rotationSpeed = 50f;

		// Token: 0x04000AEB RID: 2795
		public Vector3 movePosition;

		// Token: 0x04000AEC RID: 2796
		public float moveSpeed = 5f;

		// Token: 0x04000AED RID: 2797
		public int characterLayer;

		// Token: 0x04000AEE RID: 2798
		private Quaternion defaultRotation;

		// Token: 0x04000AEF RID: 2799
		private Quaternion targetRotation;

		// Token: 0x04000AF0 RID: 2800
		private Vector3 targetPosition;

		// Token: 0x04000AF1 RID: 2801
		private Vector3 velocity;

		// Token: 0x04000AF2 RID: 2802
		private Rigidbody r;
	}
}
