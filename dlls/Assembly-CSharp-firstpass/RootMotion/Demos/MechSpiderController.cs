using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200014F RID: 335
	public class MechSpiderController : MonoBehaviour
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000A40 RID: 2624 RVA: 0x00041155 File Offset: 0x0003F355
		public Vector3 inputVector
		{
			get
			{
				return new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
			}
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x00041178 File Offset: 0x0003F378
		private void Update()
		{
			Vector3 forward = this.cameraTransform.forward;
			Vector3 up = base.transform.up;
			Vector3.OrthoNormalize(ref up, ref forward);
			Quaternion quaternion = Quaternion.LookRotation(forward, base.transform.up);
			base.transform.Translate(quaternion * this.inputVector.normalized * Time.deltaTime * this.speed * this.mechSpider.scale, Space.World);
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, quaternion, Time.deltaTime * this.turnSpeed);
		}

		// Token: 0x040009C3 RID: 2499
		public MechSpider mechSpider;

		// Token: 0x040009C4 RID: 2500
		public Transform cameraTransform;

		// Token: 0x040009C5 RID: 2501
		public float speed = 6f;

		// Token: 0x040009C6 RID: 2502
		public float turnSpeed = 30f;
	}
}
