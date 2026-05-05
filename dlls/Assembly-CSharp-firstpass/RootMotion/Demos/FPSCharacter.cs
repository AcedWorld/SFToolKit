using System;
using UnityEngine;

namespace RootMotion.Demos
{
	// Token: 0x02000162 RID: 354
	public class FPSCharacter : MonoBehaviour
	{
		// Token: 0x06000A90 RID: 2704 RVA: 0x00043782 File Offset: 0x00041982
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
			this.FPSAiming = base.GetComponent<FPSAiming>();
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0004379C File Offset: 0x0004199C
		private void Update()
		{
			this.FPSAiming.sightWeight = Mathf.SmoothDamp(this.FPSAiming.sightWeight, Input.GetMouseButton(1) ? 1f : 0f, ref this.sVel, 0.1f);
			if (this.FPSAiming.sightWeight < 0.001f)
			{
				this.FPSAiming.sightWeight = 0f;
			}
			if (this.FPSAiming.sightWeight > 0.999f)
			{
				this.FPSAiming.sightWeight = 1f;
			}
			this.animator.SetFloat("Speed", this.walkSpeed);
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0004383D File Offset: 0x00041A3D
		private void OnGUI()
		{
			GUI.Label(new Rect((float)(Screen.width - 210), 10f, 200f, 25f), "Hold RMB to aim down the sight");
		}

		// Token: 0x04000A47 RID: 2631
		[Range(0f, 1f)]
		public float walkSpeed = 0.5f;

		// Token: 0x04000A48 RID: 2632
		private float sVel;

		// Token: 0x04000A49 RID: 2633
		private Animator animator;

		// Token: 0x04000A4A RID: 2634
		private FPSAiming FPSAiming;
	}
}
