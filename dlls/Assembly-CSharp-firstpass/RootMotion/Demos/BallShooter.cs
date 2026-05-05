using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x0200018E RID: 398
	public class BallShooter : MonoBehaviour
	{
		// Token: 0x06000B30 RID: 2864 RVA: 0x00046ED0 File Offset: 0x000450D0
		private void Update()
		{
			if (Input.GetKeyDown(this.keyCode))
			{
				Rigidbody component = Object.Instantiate<GameObject>(this.ball, base.transform.position + base.transform.rotation * this.spawnOffset, base.transform.rotation).GetComponent<Rigidbody>();
				if (component != null)
				{
					component.mass = this.mass;
					component.AddForce(Quaternion.LookRotation(Camera.main.ScreenPointToRay(Input.mousePosition).direction) * this.force, ForceMode.VelocityChange);
				}
			}
		}

		// Token: 0x04000B2D RID: 2861
		public KeyCode keyCode = KeyCode.Mouse0;

		// Token: 0x04000B2E RID: 2862
		public GameObject ball;

		// Token: 0x04000B2F RID: 2863
		public Vector3 spawnOffset = new Vector3(0f, 0.5f, 0f);

		// Token: 0x04000B30 RID: 2864
		public Vector3 force = new Vector3(0f, 0f, 7f);

		// Token: 0x04000B31 RID: 2865
		public float mass = 3f;
	}
}
